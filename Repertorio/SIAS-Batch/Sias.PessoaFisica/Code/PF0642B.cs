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
using Sias.PessoaFisica.DB2.PF0642B;

namespace Code
{
    public class PF0642B
    {
        public bool IsCall { get; set; }

        public PF0642B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   ANALISE/PROGRAMACAO..  LUIZ CARLOS.                          *      */
        /*"      *   PROGRAMA ............  PF0642B                               *      */
        /*"      *   DATA ................  02/08/2004.                           *      */
        /*"      *   REVISAO PROGRAMACAO..  REGINALDO DA SILVA                    *      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ..............  GERA ESTOQUE DO VIDA EMPRESARIAL AO   *      */
        /*"      *                          SIGPF.                                *      */
        /*"      *                                                                *      */
        /*"      *   OBS..................  ESTE PROGRAMA GERA AO SIGPF AS PROPOS *      */
        /*"      *                          TAS MANUAIS DO NOVO VIDA EMPRESARIAL. *      */
        /*"      *                                                                *      */
        /*"      *                          EM COMUM ACORDO COM A REDEA/SP,    OS *      */
        /*"      *                          PROGRAMAS PF0623B E PF0642B,   PASSAM *      */
        /*"      *                          A PROCESSAR SIMULTANEAMENTE,  DEVENDO *      */
        /*"      *                          O PF0623B SER SUBSTITUIDO PELO PF0642 *      */
        /*"      *                                                                *      */
        /*"      *                          QUANDO A SUBSTITUICAO OCORRER PODEMOS *      */
        /*"      *                          SIMPLESMENTE SUSPENDER O PF0623B, CON *      */
        /*"      *                          TINUANDO A EXECUCAO DO PF0642B, OU,   *      */
        /*"      *                          SOBREPOR O PF0623B COM O PF0642B, LI- *      */
        /*"      *                          BERANDO O CODIGO PF0642B PARA USO  EM *      */
        /*"      *                          OUTRO PROCESSO, FICANDO ATIVO SOMENTE *      */
        /*"      *                          O PF0623B COMO HOJE.                  *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 18 - 18/03/2019 KINKAS - JV1 - TAREFA 192760            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 17             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      *                       IND_TP_CONTA NA TABELA PROPOSTA_FIDELIZ. *      */
        /*"      * ATENDE DEMANDA 175.167                                         *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.17          MARCUS VALERIO                           *      */
        /*"      *                       05/02/2019                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 16             IMPACTO DA INCLUSAO DO CAMPO             *      */
        /*"      * ATENDE CADMUS 140.553 IND_TP_PROPOSTA NA TABELA                *      */
        /*"      *                       PROPOSTA_FIDELIZ.                        *      */
        /*"      * PROCURE V.16          FRANK CARVALHO                           *      */
        /*"      *                       08/08/2016                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 15             AJUSTAR SELECT NA TAB DE PRODUTOS_SIVPF  *      */
        /*"      * ATENDE CADMUS 109986  ACRESCENTANDO O COD_EMPRESA              *      */
        /*"      *                                                                *      */
        /*"      * PROCURE DIRSA         REGINALDO SILVA                          *      */
        /*"      *                       28/07/2015                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 14             ALTERACOES NOS REGISTROS TIPO 3 E TIPO A *      */
        /*"      * ATENDE CADMUS 97713   CAMPOS :  OPERACAO E NUMERO DE CONTA     *      */
        /*"      *                                                                *      */
        /*"      * PROCURE NSGD          REGINALDO SILVA                          *      */
        /*"      *                       23/05/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 13             AJUSTE NA ROTINA INSERT R3360            *      */
        /*"      * ATENDE CADMUS 112140                                           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.13          REGINALDO SILVA                          *      */
        /*"      *                       12/03/2015                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 12             AJUSTE NA LEITURA E ROTINA R6000         *      */
        /*"      * ATENDE CADMUS 93600                                            *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.12          REGINALDO SILVA                          *      */
        /*"      *                       10/03/2015                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 11             AJUSTE PERIODICIDADE DE PAGAMENTO        *      */
        /*"      * ATENDE CADMUS 93600   PERI-PAGAMENTO E R3-PERIPGTO             *      */
        /*"      *                                                                *      */
        /*"      * PROCURE V.11          REGINALDO SILVA                          *      */
        /*"      *                       10/04/2014                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 10             AJUSTE INSERT HIST_PROP_FIDELIZ          *      */
        /*"      * ATENDE CADMUS 88764   COD-EMPRESA    E   COD-PRODUTO           *      */
        /*"      *                                                                *      */
        /*"      * PROCURE IHP           REGINALDO SILVA / SERGIO LORETO          *      */
        /*"      *                       25/11/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 09             AJUSTES NOS SELECTS V10                  *      */
        /*"      * ATENDE CADMUS 84811   DB2.V10  SELECTS                         *      */
        /*"      *                                                                *      */
        /*"      *                       REGINALDO SILVA                          *      */
        /*"      *                       10/09/2013                               *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 08 - CAD 83.382                                       *      */
        /*"      *                                                                *      */
        /*"      *               - TRATAR AS APOLICE 108210933403 E 109300002585  *      */
        /*"      *                 QUE TEM COMO CARACTERISTICA O PAGAMENTO        *      */
        /*"      *                 ANTECIPADO.                                    *      */
        /*"      *                                                                *      */
        /*"      *               - FOI RETIRADO O FILTRO DE APOLICE DEVIDO AO     *      */
        /*"      *                 FATO DE QUE TODAS AS APOLICES EMPRESARIAL      *      */
        /*"      *                 DEVEM SENSIBILIZAR O SIGPF                     *      */
        /*"      *                                                                *      */
        /*"      *   EM 06/06/2012 - FAST COMPUTER - PEDRO SILVERIO               *      */
        /*"      *                                                                *      */
        /*"      *                                            PROCURE POR V.08    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 07 - CAD 73.003                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUSAO DA APOLICE 109300002142               *      */
        /*"      *                 EM SUBSTITUICAO DA  109300001819 EM FUNCAO     *      */
        /*"      *                 DE ESTOURO NA COLUNA COD_SUBGRUPO DA TABELA    *      */
        /*"      *                 SEGUROS.SUBGRUPOS_VGAP.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 08/08/2012 - FAST COMPUTER - AUGUSTO ANASTACIO            *      */
        /*"      *                                            PROCURE POR V.07    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 06 - CAD 61.042                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUSAO DA APOLICE 109300001819               *      */
        /*"      *                 EM SUBSTITUICAO DA  109300001670 EM FUNCAO     *      */
        /*"      *                 DE ESTOURO NA COLUNA COD_SUBGRUPO DA TABELA    *      */
        /*"      *                 SEGUROS.SUBGRUPOS_VGAP.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 29/08/2011 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                            PROCURE POR V.06    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 05 - CAD 49916                                        *      */
        /*"      *                                                                *      */
        /*"      *               - TRATA APOLICES NAO SENSIBILIZADAS.             *      */
        /*"      *   EM 05/11/2010 - ATTPS         - EDSON MARQUES                *      */
        /*"      *                                            PROCURE POR C49916  *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - CAD 33.292                                       *      */
        /*"      *                                                                *      */
        /*"      *               - INCLUSAO DA APOLICE 109300001670               *      */
        /*"      *                 EM SUBSTITUICAO DA  109300000959 EM FUNCAO     *      */
        /*"      *                 DE ESTOURO NA COLUNA COD_SUBGRUPO DA TABELA    *      */
        /*"      *                 SEGUROS.SUBGRUPOS_VGAP.                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 25/11/2009 - FAST COMPUTER - EDIVALDO GOMES               *      */
        /*"      *                                            PROCURE POR V.04    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 1                                                       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 3      EM  28/08/2008             LUCIA VIEIRA          *      */
        /*"      *    ATENDE SSI 23353 - INCLUI NOVA APOLICE NO CURSOR PRINCIPAL  *      */
        /*"      * PROCURAR POR V.03                                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 2      EM  21/01/2008             LUCIA VIEIRA          *      */
        /*"      *    ATENDE SSI 15069 - INCLUI TRATAMENTO APOLICE 109300000959   *      */
        /*"      * PROCURAR POR V.02                                              *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _MOVTO_PRP_SASSE { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis MOVTO_PRP_SASSE
        {
            get
            {
                _.Move(REG_PRP_SASSE, _MOVTO_PRP_SASSE); VarBasis.RedefinePassValue(REG_PRP_SASSE, _MOVTO_PRP_SASSE, REG_PRP_SASSE); return _MOVTO_PRP_SASSE;
            }
        }
        public FileBasis _MOVTO_STA_SASSE { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MOVTO_STA_SASSE
        {
            get
            {
                _.Move(REG_STA_SASSE, _MOVTO_STA_SASSE); VarBasis.RedefinePassValue(REG_STA_SASSE, _MOVTO_STA_SASSE, REG_STA_SASSE); return _MOVTO_STA_SASSE;
            }
        }
        /*"01   REG-PRP-SASSE                      PIC X(300).*/
        public StringBasis REG_PRP_SASSE { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01   REG-STA-SASSE                      PIC X(100).*/
        public StringBasis REG_STA_SASSE { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01  WHOST-DATA-REFERENCIA            PIC X(010).*/
        public StringBasis WHOST_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01  WHOST-NUM-TERMO                  PIC S9(15)V USAGE COMP-3.*/
        public DoubleBasis WHOST_NUM_TERMO { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V"), 0);
        /*"01  VIND-RCAP                         PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASCI                      PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASCI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-VAL-IOCC                     PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_VAL_IOCC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-VAL-RCAP                     PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_VAL_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DATA-RCAP                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DATA_RCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-AGECTADEB                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-OPRCTADEB                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NUMCTADEB                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DIGCTADEB                    PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-VAL-PREMIO                   PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_VAL_PREMIO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-FAIXA-RENDA-IND              PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA_IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-FAIXA-RENDA-FAM              PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_FAIXA_RENDA_FAM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-DTNASC-ESPOSA                PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_DTNASC_ESPOSA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CODPORTEMP                   PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_CODPORTEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-NATATIV                      PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_NATATIV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-RAMATIV                      PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_RAMATIV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  VIND-CODATIV                      PIC S9(4)  COMP VALUE +0.*/
        public IntBasis VIND_CODATIV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(4)"));
        /*"01  TAB-FILIAIS.*/
        public PF0642B_TAB_FILIAIS TAB_FILIAIS { get; set; } = new PF0642B_TAB_FILIAIS();
        public class PF0642B_TAB_FILIAIS : VarBasis
        {
            /*"   05      TAB-FILIAL.*/
            public PF0642B_TAB_FILIAL TAB_FILIAL { get; set; } = new PF0642B_TAB_FILIAL();
            public class PF0642B_TAB_FILIAL : VarBasis
            {
                /*"     10    FILLER    OCCURS    9999   TIMES.*/
                public ListBasis<PF0642B_FILLER_0> FILLER_0 { get; set; } = new ListBasis<PF0642B_FILLER_0>(9999);
                public class PF0642B_FILLER_0 : VarBasis
                {
                    /*"       15  TAB-AGENCIA              PIC  9(4).*/
                    public IntBasis TAB_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"       15  TAB-FONTE                PIC  9(4).*/
                    public IntBasis TAB_FONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(4)."));
                    /*"01  WAREA-AUXILIAR.*/
                }
            }
        }
        public PF0642B_WAREA_AUXILIAR WAREA_AUXILIAR { get; set; } = new PF0642B_WAREA_AUXILIAR();
        public class PF0642B_WAREA_AUXILIAR : VarBasis
        {
            /*"    05  W-FIM-TERNIV                  PIC X(001)  VALUE SPACES.*/
            public StringBasis W_FIM_TERNIV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05  W-FIM-FUNCIONARIOS            PIC X(001)  VALUE SPACES.*/
            public StringBasis W_FIM_FUNCIONARIOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05  W-FIM-COBERTURAS              PIC X(001)  VALUE SPACES.*/
            public StringBasis W_FIM_COBERTURAS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05  W-FIM-COBER-FUNC              PIC X(001)  VALUE SPACES.*/
            public StringBasis W_FIM_COBER_FUNC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05  W-FIM-MOVTO-TERMO             PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_MOVTO_TERMO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-EMAIL            PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  W-FIM-CURSOR-ENDERECO         PIC X(003)  VALUE SPACES.*/
            public StringBasis W_FIM_CURSOR_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"    05  WFIM-AGENCEF                  PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_AGENCEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05  WFIM-ENDERECOS                PIC  X(001) VALUE ' '.*/
            public StringBasis WFIM_ENDERECOS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05  W-TOT-PROCESSADO              PIC 9(006)  VALUE ZEROS.*/
            public IntBasis W_TOT_PROCESSADO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-AC-CONTROLE                 PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_AC_CONTROLE { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-IND-NIVEL                   PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_IND_NIVEL { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-IND-COB-FUN                 PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_IND_COB_FUN { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  W-INDEX                       PIC  9(01)  VALUE ZERO.*/
            public IntBasis W_INDEX { get; set; } = new IntBasis(new PIC("9", "1", "9(01)"));
            /*"    05  WS-RESULT                     PIC  9(006)  VALUE ZEROS.*/
            public IntBasis WS_RESULT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  WS-RESTO                      PIC  9(004)  VALUE ZEROS.*/
            public IntBasis WS_RESTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  WS-COUNT                      PIC  9(006)  VALUE ZEROS.*/
            public IntBasis WS_COUNT { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05  W-IND-IOF                     PIC S9(01)V9(4) COMP-3.*/
            public DoubleBasis W_IND_IOF { get; set; } = new DoubleBasis(new PIC("S9", "1", "S9(01)V9(4)"), 4);
            /*"    05  W-PRM-LIQ                     PIC  9(13)V99 VALUE ZEROS.*/
            public DoubleBasis W_PRM_LIQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05  W-TIME                        PIC X(08).*/
            public StringBasis W_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05  W-TIME-EDIT                   PIC 99.99.99.99.*/
            public IntBasis W_TIME_EDIT { get; set; } = new IntBasis(new PIC("9", "8", "99.99.99.99."));
            /*"    05  W-DESPREZADO-01               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO_01 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-DESPREZADO-02               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO_02 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-DESPREZADO-03               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO_03 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-DESPREZADO-04               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO_04 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-DESPREZADO-05               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO_05 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-DESPREZADO-06               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO_06 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-DESPREZADO-07               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO_07 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-DESPREZADO-08               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO_08 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-DESPREZADO-09               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO_09 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-DESPREZADO-10               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO_10 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-DESPREZADO-11               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_DESPREZADO_11 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-0               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_0 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-1               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_1 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-2               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_2 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-3               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_3 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-4               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_4 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-5               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_5 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-6               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_6 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-7               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-8               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_8 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-9               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_9 { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-A               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_A { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-B               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_B { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-C               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_C { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-D               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_D { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-E               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_E { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-F               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_F { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-G               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_G { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-H               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_H { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-I               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_I { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-QTD-LD-TIPO-J               PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_QTD_LD_TIPO_J { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-TOT-GERADO-PRP              PIC  9(08)  VALUE ZEROS.*/
            public IntBasis W_TOT_GERADO_PRP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)"));
            /*"    05  W-SEQ-FONE                    PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_FONE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-SEQ-EMAIL                   PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_SEQ_EMAIL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-COD-PESSOA                  PIC 9(009)  VALUE ZEROS.*/
            public IntBasis W_COD_PESSOA { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"    05  W-COD-RELACION                PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_COD_RELACION { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-ACHOU-EMAIL                 PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_EMAIL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-TELEFONE              PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_TELEFONE { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-ENDERECO              PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_ENDERECO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-ACHOU-RELACIONAMENTO        PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_ACHOU_RELACIONAMENTO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-OCORR-ENDERECO              PIC 9(004)  VALUE ZEROS.*/
            public IntBasis W_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  W-OBTER-MAX-RELAC             PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_OBTER_MAX_RELAC { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-OBTER-MAX-PESSOA            PIC X(003)  VALUE 'NAO'.*/
            public StringBasis W_OBTER_MAX_PESSOA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"NAO");
            /*"    05  W-NUM-IDENTIF                 PIC 9(015)  VALUE ZEROS.*/
            public IntBasis W_NUM_IDENTIF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"    05  W-NSAS                        PIC 9(006).*/
            public IntBasis W_NSAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-NSL                         PIC 9(008).*/
            public IntBasis W_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05  W-CONTROLE                    PIC 9(006).*/
            public IntBasis W_CONTROLE { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05  W-CONTROLE-TP-0               PIC 9(001)  VALUE ZERO.*/
            public IntBasis W_CONTROLE_TP_0 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05  W-DATA-TRABALHO               PIC 9(008)  VALUE ZEROS.*/
            public IntBasis W_DATA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-TRABALHO.*/
            private _REDEF_PF0642B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_PF0642B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_PF0642B_FILLER_1(); _.Move(W_DATA_TRABALHO, _filler_1); VarBasis.RedefinePassValue(W_DATA_TRABALHO, _filler_1, W_DATA_TRABALHO); _filler_1.ValueChanged += () => { _.Move(_filler_1, W_DATA_TRABALHO); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, W_DATA_TRABALHO); }
            }  //Redefines
            public class _REDEF_PF0642B_FILLER_1 : VarBasis
            {
                /*"        07  W-DIA-TRABALHO            PIC 9(002).*/
                public IntBasis W_DIA_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-TRABALHO            PIC 9(002).*/
                public IntBasis W_MES_TRABALHO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-TRABALHO            PIC 9(004).*/
                public IntBasis W_ANO_TRABALHO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-NASCIMENTO             PIC 9(008)  VALUE ZEROS.*/

                public _REDEF_PF0642B_FILLER_1()
                {
                    W_DIA_TRABALHO.ValueChanged += OnValueChanged;
                    W_MES_TRABALHO.ValueChanged += OnValueChanged;
                    W_ANO_TRABALHO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    05  FILLER REDEFINES W-DATA-NASCIMENTO.*/
            private _REDEF_PF0642B_FILLER_2 _filler_2 { get; set; }
            public _REDEF_PF0642B_FILLER_2 FILLER_2
            {
                get { _filler_2 = new _REDEF_PF0642B_FILLER_2(); _.Move(W_DATA_NASCIMENTO, _filler_2); VarBasis.RedefinePassValue(W_DATA_NASCIMENTO, _filler_2, W_DATA_NASCIMENTO); _filler_2.ValueChanged += () => { _.Move(_filler_2, W_DATA_NASCIMENTO); }; return _filler_2; }
                set { VarBasis.RedefinePassValue(value, _filler_2, W_DATA_NASCIMENTO); }
            }  //Redefines
            public class _REDEF_PF0642B_FILLER_2 : VarBasis
            {
                /*"        07  W-DIA-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_DIA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-MES-NASCIMENTO          PIC 9(002).*/
                public IntBasis W_MES_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-ANO-NASCIMENTO          PIC 9(004).*/
                public IntBasis W_ANO_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-COD-COBERTURA               PIC 9(004)  VALUE ZEROS.*/

                public _REDEF_PF0642B_FILLER_2()
                {
                    W_DIA_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_MES_NASCIMENTO.ValueChanged += OnValueChanged;
                    W_ANO_NASCIMENTO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_COD_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05  FILLER REDEFINES W-COD-COBERTURA.*/
            private _REDEF_PF0642B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_PF0642B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_PF0642B_FILLER_3(); _.Move(W_COD_COBERTURA, _filler_3); VarBasis.RedefinePassValue(W_COD_COBERTURA, _filler_3, W_COD_COBERTURA); _filler_3.ValueChanged += () => { _.Move(_filler_3, W_COD_COBERTURA); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, W_COD_COBERTURA); }
            }  //Redefines
            public class _REDEF_PF0642B_FILLER_3 : VarBasis
            {
                /*"        10  W-SUBPRODUTO              PIC 9(003).*/
                public IntBasis W_SUBPRODUTO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        10  W-COBERTURA               PIC 9(001).*/
                public IntBasis W_COBERTURA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05  W-DTMOVABE                    PIC X(010).*/

                public _REDEF_PF0642B_FILLER_3()
                {
                    W_SUBPRODUTO.ValueChanged += OnValueChanged;
                    W_COBERTURA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE1 REDEFINES W-DTMOVABE.*/
            private _REDEF_PF0642B_W_DTMOVABE1 _w_dtmovabe1 { get; set; }
            public _REDEF_PF0642B_W_DTMOVABE1 W_DTMOVABE1
            {
                get { _w_dtmovabe1 = new _REDEF_PF0642B_W_DTMOVABE1(); _.Move(W_DTMOVABE, _w_dtmovabe1); VarBasis.RedefinePassValue(W_DTMOVABE, _w_dtmovabe1, W_DTMOVABE); _w_dtmovabe1.ValueChanged += () => { _.Move(_w_dtmovabe1, W_DTMOVABE); }; return _w_dtmovabe1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe1, W_DTMOVABE); }
            }  //Redefines
            public class _REDEF_PF0642B_W_DTMOVABE1 : VarBasis
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
                /*"    05  W-DTMOVABE-I                  PIC X(010).*/

                public _REDEF_PF0642B_W_DTMOVABE1()
                {
                    W_ANO_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA1.ValueChanged += OnValueChanged;
                    W_MES_MOVABE.ValueChanged += OnValueChanged;
                    W_BARRA2.ValueChanged += OnValueChanged;
                    W_DIA_MOVABE.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DTMOVABE_I { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DTMOVABE-I1 REDEFINES W-DTMOVABE-I.*/
            private _REDEF_PF0642B_W_DTMOVABE_I1 _w_dtmovabe_i1 { get; set; }
            public _REDEF_PF0642B_W_DTMOVABE_I1 W_DTMOVABE_I1
            {
                get { _w_dtmovabe_i1 = new _REDEF_PF0642B_W_DTMOVABE_I1(); _.Move(W_DTMOVABE_I, _w_dtmovabe_i1); VarBasis.RedefinePassValue(W_DTMOVABE_I, _w_dtmovabe_i1, W_DTMOVABE_I); _w_dtmovabe_i1.ValueChanged += () => { _.Move(_w_dtmovabe_i1, W_DTMOVABE_I); }; return _w_dtmovabe_i1; }
                set { VarBasis.RedefinePassValue(value, _w_dtmovabe_i1, W_DTMOVABE_I); }
            }  //Redefines
            public class _REDEF_PF0642B_W_DTMOVABE_I1 : VarBasis
            {
                /*"        07  W-DIA-MOVABE              PIC 9(002).*/
                public IntBasis W_DIA_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-MOVABE              PIC 9(002).*/
                public IntBasis W_MES_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-ANO-MOVABE              PIC 9(004).*/
                public IntBasis W_ANO_MOVABE_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05  W-DATA-SQL                    PIC X(010).*/

                public _REDEF_PF0642B_W_DTMOVABE_I1()
                {
                    W_DIA_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA1_0.ValueChanged += OnValueChanged;
                    W_MES_MOVABE_0.ValueChanged += OnValueChanged;
                    W_BARRA2_0.ValueChanged += OnValueChanged;
                    W_ANO_MOVABE_0.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis W_DATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05  W-DATA-SQL1 REDEFINES W-DATA-SQL.*/
            private _REDEF_PF0642B_W_DATA_SQL1 _w_data_sql1 { get; set; }
            public _REDEF_PF0642B_W_DATA_SQL1 W_DATA_SQL1
            {
                get { _w_data_sql1 = new _REDEF_PF0642B_W_DATA_SQL1(); _.Move(W_DATA_SQL, _w_data_sql1); VarBasis.RedefinePassValue(W_DATA_SQL, _w_data_sql1, W_DATA_SQL); _w_data_sql1.ValueChanged += () => { _.Move(_w_data_sql1, W_DATA_SQL); }; return _w_data_sql1; }
                set { VarBasis.RedefinePassValue(value, _w_data_sql1, W_DATA_SQL); }
            }  //Redefines
            public class _REDEF_PF0642B_W_DATA_SQL1 : VarBasis
            {
                /*"        07  W-ANO-SQL                 PIC 9(004).*/
                public IntBasis W_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        07  W-BARRA1                  PIC X(001).*/
                public StringBasis W_BARRA1_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-MES-SQL                 PIC 9(002).*/
                public IntBasis W_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"        07  W-BARRA2                  PIC X(001).*/
                public StringBasis W_BARRA2_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        07  W-DIA-SQL                 PIC 9(002).*/
                public IntBasis W_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05  W-NR-SICOB                    PIC 9(015).*/

                public _REDEF_PF0642B_W_DATA_SQL1()
                {
                    W_ANO_SQL.ValueChanged += OnValueChanged;
                    W_BARRA1_1.ValueChanged += OnValueChanged;
                    W_MES_SQL.ValueChanged += OnValueChanged;
                    W_BARRA2_1.ValueChanged += OnValueChanged;
                    W_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NR_SICOB { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05  FILLER REDEFINES W-NR-SICOB.*/
            private _REDEF_PF0642B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_PF0642B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_PF0642B_FILLER_4(); _.Move(W_NR_SICOB, _filler_4); VarBasis.RedefinePassValue(W_NR_SICOB, _filler_4, W_NR_SICOB); _filler_4.ValueChanged += () => { _.Move(_filler_4, W_NR_SICOB); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, W_NR_SICOB); }
            }  //Redefines
            public class _REDEF_PF0642B_FILLER_4 : VarBasis
            {
                /*"        07  W-NR-PROD-SICOB           PIC 9(003).*/
                public IntBasis W_NR_PROD_SICOB { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  W-NR-NSAC-SICOB           PIC 9(006).*/
                public IntBasis W_NR_NSAC_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"        07  W-NR-NSL-SICOB            PIC 9(006).*/
                public IntBasis W_NR_NSL_SICOB { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"    05  W-NUM-PROPOSTA                PIC 9(014).*/

                public _REDEF_PF0642B_FILLER_4()
                {
                    W_NR_PROD_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSAC_SICOB.ValueChanged += OnValueChanged;
                    W_NR_NSL_SICOB.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W_NUM_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    05  CANAL  REDEFINES W-NUM-PROPOSTA.*/
            private _REDEF_PF0642B_CANAL _canal { get; set; }
            public _REDEF_PF0642B_CANAL CANAL
            {
                get { _canal = new _REDEF_PF0642B_CANAL(); _.Move(W_NUM_PROPOSTA, _canal); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _canal, W_NUM_PROPOSTA); _canal.ValueChanged += () => { _.Move(_canal, W_NUM_PROPOSTA); }; return _canal; }
                set { VarBasis.RedefinePassValue(value, _canal, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0642B_CANAL : VarBasis
            {
                /*"        07  W-CANAL-PROPOSTA          PIC 9(001).*/

                public SelectorBasis W_CANAL_PROPOSTA { get; set; } = new SelectorBasis("001")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 CANAL-VENDA-PAPEL                  VALUE 0. */
							new SelectorItemBasis("CANAL_VENDA_PAPEL", "0"),
							/*" 88 CANAL-VENDA-CEF                    VALUE 1. */
							new SelectorItemBasis("CANAL_VENDA_CEF", "1"),
							/*" 88 CANAL-SASSE-FILIAL                 VALUE 2. */
							new SelectorItemBasis("CANAL_SASSE_FILIAL", "2"),
							/*" 88 CANAL-CORRETOR                     VALUE 3. */
							new SelectorItemBasis("CANAL_CORRETOR", "3"),
							/*" 88 CANAL-CORREIO                      VALUE 4. */
							new SelectorItemBasis("CANAL_CORREIO", "4"),
							/*" 88 CANAL-GITEL                        VALUE 5. */
							new SelectorItemBasis("CANAL_GITEL", "5"),
							/*" 88 CANAL-INTERNET                     VALUE 7. */
							new SelectorItemBasis("CANAL_INTERNET", "7"),
							/*" 88 CANAL-INTRANET                     VALUE 8. */
							new SelectorItemBasis("CANAL_INTRANET", "8")
                }
                };

                /*"        07  FILLER                    PIC X(013).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)."), @"");
                /*"    05  FAIXAS  REDEFINES W-NUM-PROPOSTA.*/

                public _REDEF_PF0642B_CANAL()
                {
                    W_CANAL_PROPOSTA.ValueChanged += OnValueChanged;
                    FILLER_5.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_PF0642B_FAIXAS _faixas { get; set; }
            public _REDEF_PF0642B_FAIXAS FAIXAS
            {
                get { _faixas = new _REDEF_PF0642B_FAIXAS(); _.Move(W_NUM_PROPOSTA, _faixas); VarBasis.RedefinePassValue(W_NUM_PROPOSTA, _faixas, W_NUM_PROPOSTA); _faixas.ValueChanged += () => { _.Move(_faixas, W_NUM_PROPOSTA); }; return _faixas; }
                set { VarBasis.RedefinePassValue(value, _faixas, W_NUM_PROPOSTA); }
            }  //Redefines
            public class _REDEF_PF0642B_FAIXAS : VarBasis
            {
                /*"        07  FILLER                    PIC 9(003).*/
                public IntBasis FILLER_6 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"        07  FAIXA-NUMERACAO           PIC 9(003).*/

                public SelectorBasis FAIXA_NUMERACAO { get; set; } = new SelectorBasis("003")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88 FAIXA-NUMERACAO-MULT-SUPER VALUE               845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT_SUPER", "845,846"),
							/*" 88 FAIXA-NUMERACAO-MULT       VALUE               848, 850. */
							new SelectorItemBasis("FAIXA_NUMERACAO_MULT", "848,850"),
							/*" 88 FAIXA-NUMERACAO-BILHETE    VALUE               823, 824, 826, 827, 829, 837, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_BILHETE", "823,824,826,827,829,837,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-SENIOR     VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_SENIOR", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-EXECUTIVO  VALUE               821, 850, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_EXECUTIVO", "821,850,845,846"),
							/*" 88 FAIXA-NUMERACAO-AUTO       VALUE               828, 837, 847, 845, 846. */
							new SelectorItemBasis("FAIXA_NUMERACAO_AUTO", "828,837,847,845,846")
                }
                };

                /*"        07  FILLER                    PIC 9(008).*/
                public IntBasis FILLER_7 { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"    05 W-LER-CLIENTE                  PIC  9(001) VALUE ZERO.*/

                public _REDEF_PF0642B_FAIXAS()
                {
                    FILLER_6.ValueChanged += OnValueChanged;
                    FAIXA_NUMERACAO.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                }

            }

            public SelectorBasis W_LER_CLIENTE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 EXISTE-CLIENTE                          VALUE 1. */
							new SelectorItemBasis("EXISTE_CLIENTE", "1")
                }
            };

            /*"    05 W-COD-EMPRESA                  PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_COD_EMPRESA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SASSE                                   VALUE 1. */
							new SelectorItemBasis("SASSE", "1"),
							/*" 88 FEDERALPREV                             VALUE 2. */
							new SelectorItemBasis("FEDERALPREV", "2"),
							/*" 88 FEDERALCAP                              VALUE 3. */
							new SelectorItemBasis("FEDERALCAP", "3")
                }
            };

            /*"    05 W-RELACIONAMENTO               PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_RELACIONAMENTO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SEGURO-VIDA                             VALUE 1. */
							new SelectorItemBasis("SEGURO_VIDA", "1"),
							/*" 88 CAPITALIZACAO                           VALUE 2. */
							new SelectorItemBasis("CAPITALIZACAO", "2"),
							/*" 88 PREVIDENCIA                             VALUE 3. */
							new SelectorItemBasis("PREVIDENCIA", "3"),
							/*" 88 BILHETE                                 VALUE 4. */
							new SelectorItemBasis("BILHETE", "4")
                }
            };

            /*"    05 W-CURSOR                       PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CURSOR { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CURSOR-MONTADO                          VALUE 1. */
							new SelectorItemBasis("CURSOR_MONTADO", "1"),
							/*" 88 CURSOR-N-MONTADO                        VALUE 2. */
							new SelectorItemBasis("CURSOR_N_MONTADO", "2")
                }
            };

            /*"    05 W-RCAPS                        PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_RCAPS { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAP-CADASTRADO                         VALUE 1. */
							new SelectorItemBasis("RCAP_CADASTRADO", "1"),
							/*" 88 RCAP-N-CADASTRADO                       VALUE 2. */
							new SelectorItemBasis("RCAP_N_CADASTRADO", "2")
                }
            };

            /*"    05 W-RCAPCOMP                     PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_RCAPCOMP { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 RCAPCOMP-CADASTRADO                     VALUE 1. */
							new SelectorItemBasis("RCAPCOMP_CADASTRADO", "1"),
							/*" 88 RCAPCOMP-N-CADASTRADO                   VALUE 2. */
							new SelectorItemBasis("RCAPCOMP_N_CADASTRADO", "2")
                }
            };

            /*"    05 W-CLIENTE                      PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_CLIENTE { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 CLIENTE-CADASTRADO                      VALUE 1. */
							new SelectorItemBasis("CLIENTE_CADASTRADO", "1"),
							/*" 88 CLIENTE-NAO-CADASTRADO                  VALUE 2. */
							new SelectorItemBasis("CLIENTE_NAO_CADASTRADO", "2")
                }
            };

            /*"    05 W-ENDERECO                     PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_ENDERECO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 ENDERECO-CADASTRADO                      VALUE 1. */
							new SelectorItemBasis("ENDERECO_CADASTRADO", "1"),
							/*" 88 ENDERECO-NAO-CADASTRADO                  VALUE 2. */
							new SelectorItemBasis("ENDERECO_NAO_CADASTRADO", "2")
                }
            };

            /*"    05 W-SUBGRUPO                     PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_SUBGRUPO { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 SUBGRUPO-CADASTRADO                      VALUE 1. */
							new SelectorItemBasis("SUBGRUPO_CADASTRADO", "1"),
							/*" 88 SUBGRUPO-NAO-CADASTRADO                  VALUE 2. */
							new SelectorItemBasis("SUBGRUPO_NAO_CADASTRADO", "2")
                }
            };

            /*"    05 W-PROPOSTAVA                   PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_PROPOSTAVA { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTAVA-CADASTRADA                   VALUE 1. */
							new SelectorItemBasis("PROPOSTAVA_CADASTRADA", "1"),
							/*" 88 PROPOSTAVA-NAO-CADASTRADA               VALUE 2. */
							new SelectorItemBasis("PROPOSTAVA_NAO_CADASTRADA", "2")
                }
            };

            /*"    05 W-FIDELIZ                      PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_FIDELIZ { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 PROPOSTA-CADASTRADA                     VALUE 1. */
							new SelectorItemBasis("PROPOSTA_CADASTRADA", "1"),
							/*" 88 PROPOSTA-NAO-CADASTRADA                 VALUE 2. */
							new SelectorItemBasis("PROPOSTA_NAO_CADASTRADA", "2")
                }
            };

            /*"    05 W-COBERTURAS                   PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_COBERTURAS { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 COBERTURA-CADASTRADA                    VALUE 1. */
							new SelectorItemBasis("COBERTURA_CADASTRADA", "1"),
							/*" 88 COBERTURA-NAO-CADASTRADA                VALUE 2. */
							new SelectorItemBasis("COBERTURA_NAO_CADASTRADA", "2")
                }
            };

            /*"    05 W-OPCAOPAG                     PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_OPCAOPAG { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 OPCAO-PAG-CADASTRADA                    VALUE 1. */
							new SelectorItemBasis("OPCAO_PAG_CADASTRADA", "1"),
							/*" 88 OPCAO-PAG-NAO-CADASTRADA                VALUE 2. */
							new SelectorItemBasis("OPCAO_PAG_NAO_CADASTRADA", "2")
                }
            };

            /*"    05 W-NUM-FUNCIONARIOS             PIC  9(001) VALUE ZERO.*/

            public SelectorBasis W_NUM_FUNCIONARIOS { get; set; } = new SelectorBasis("001", "ZERO")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 FUNCIONARIOS-LIBERADOS                  VALUE 1. */
							new SelectorItemBasis("FUNCIONARIOS_LIBERADOS", "1"),
							/*" 88 FUNCIONARIOS-NAO-LIBERADOS              VALUE 2. */
							new SelectorItemBasis("FUNCIONARIOS_NAO_LIBERADOS", "2")
                }
            };

            /*"    05  W-CODIGO-CNAE               PIC  9(010)   VALUE ZEROS.*/
            public IntBasis W_CODIGO_CNAE { get; set; } = new IntBasis(new PIC("9", "10", "9(010)"));
            /*"    05  FILLER   REDEFINES   W-CODIGO-CNAE.*/
            private _REDEF_PF0642B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_PF0642B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_PF0642B_FILLER_8(); _.Move(W_CODIGO_CNAE, _filler_8); VarBasis.RedefinePassValue(W_CODIGO_CNAE, _filler_8, W_CODIGO_CNAE); _filler_8.ValueChanged += () => { _.Move(_filler_8, W_CODIGO_CNAE); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, W_CODIGO_CNAE); }
            }  //Redefines
            public class _REDEF_PF0642B_FILLER_8 : VarBasis
            {
                /*"      10    W-COD-NATU-ATIVIDADE    PIC  9(005).*/
                public IntBasis W_COD_NATU_ATIVIDADE { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10    W-COD-RAMO-ATIVIDADE    PIC  9(001).*/
                public IntBasis W_COD_RAMO_ATIVIDADE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"      10    W-COD-ATIVIDADE         PIC  9(004).*/
                public IntBasis W_COD_ATIVIDADE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"01  WABEND*/

                public _REDEF_PF0642B_FILLER_8()
                {
                    W_COD_NATU_ATIVIDADE.ValueChanged += OnValueChanged;
                    W_COD_RAMO_ATIVIDADE.ValueChanged += OnValueChanged;
                    W_COD_ATIVIDADE.ValueChanged += OnValueChanged;
                }

            }
        }
        public PF0642B_WABEND WABEND { get; set; } = new PF0642B_WABEND();
        public class PF0642B_WABEND : VarBasis
        {
            /*"    05 FILLER.*/
            public PF0642B_FILLER_9 FILLER_9 { get; set; } = new PF0642B_FILLER_9();
            public class PF0642B_FILLER_9 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'PF0642B  '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"PF0642B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL *** '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL *** ");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public PF0642B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new PF0642B_LOCALIZA_ABEND_1();
            public class PF0642B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public PF0642B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new PF0642B_LOCALIZA_ABEND_2();
            public class PF0642B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            }
        }


        public Copies.LXFPF990 LXFPF990 { get; set; } = new Copies.LXFPF990();
        public Copies.LBFPF011 LBFPF011 { get; set; } = new Copies.LBFPF011();
        public Copies.LBFPF012 LBFPF012 { get; set; } = new Copies.LBFPF012();
        public Copies.LXFCT004 LXFCT004 { get; set; } = new Copies.LXFCT004();
        public Copies.LXFPF004 LXFPF004 { get; set; } = new Copies.LXFPF004();
        public Copies.LBFPF160 LBFPF160 { get; set; } = new Copies.LBFPF160();
        public Copies.LBFPF991 LBFPF991 { get; set; } = new Copies.LBFPF991();
        public Copies.LBFCT011 LBFCT011 { get; set; } = new Copies.LBFCT011();
        public Copies.LBFCT016 LBFCT016 { get; set; } = new Copies.LBFCT016();
        public Copies.LBFPF200 LBFPF200 { get; set; } = new Copies.LBFPF200();
        public Dclgens.TARIBCEF TARIBCEF { get; set; } = new Dclgens.TARIBCEF();
        public Dclgens.PROPSSVD PROPSSVD { get; set; } = new Dclgens.PROPSSVD();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.RAMOCOMP RAMOCOMP { get; set; } = new Dclgens.RAMOCOMP();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.FDCOMVA FDCOMVA { get; set; } = new Dclgens.FDCOMVA();
        public Dclgens.TERMOADE TERMOADE { get; set; } = new Dclgens.TERMOADE();
        public Dclgens.VGCOMTRO VGCOMTRO { get; set; } = new Dclgens.VGCOMTRO();
        public Dclgens.VGMOVFUN VGMOVFUN { get; set; } = new Dclgens.VGMOVFUN();
        public Dclgens.VGTERNIV VGTERNIV { get; set; } = new Dclgens.VGTERNIV();
        public Dclgens.VGCOBTER VGCOBTER { get; set; } = new Dclgens.VGCOBTER();
        public Dclgens.VGFUNCOB VGFUNCOB { get; set; } = new Dclgens.VGFUNCOB();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.SUBGVGAP SUBGVGAP { get; set; } = new Dclgens.SUBGVGAP();
        public Dclgens.PESJUR PESJUR { get; set; } = new Dclgens.PESJUR();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.TPENDER TPENDER { get; set; } = new Dclgens.TPENDER();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.RTPRELAC RTPRELAC { get; set; } = new Dclgens.RTPRELAC();
        public Dclgens.IDERELAC IDERELAC { get; set; } = new Dclgens.IDERELAC();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public Dclgens.COVSIVPF COVSIVPF { get; set; } = new Dclgens.COVSIVPF();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PRDSIVPF PRDSIVPF { get; set; } = new Dclgens.PRDSIVPF();
        public Dclgens.PROPFIDH PROPFIDH { get; set; } = new Dclgens.PROPFIDH();
        public Dclgens.PROPOFID PROPOFID { get; set; } = new Dclgens.PROPOFID();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.RCAPS RCAPS { get; set; } = new Dclgens.RCAPS();
        public Dclgens.RCAPCOMP RCAPCOMP { get; set; } = new Dclgens.RCAPCOMP();
        public Dclgens.AGENCEF AGENCEF { get; set; } = new Dclgens.AGENCEF();
        public Dclgens.MALHACEF MALHACEF { get; set; } = new Dclgens.MALHACEF();
        public Dclgens.ARQSIVPF ARQSIVPF { get; set; } = new Dclgens.ARQSIVPF();
        public PF0642B_TERMO_ADESAO TERMO_ADESAO { get; set; } = new PF0642B_TERMO_ADESAO();
        public PF0642B_C01_RCAPCOMP C01_RCAPCOMP { get; set; } = new PF0642B_C01_RCAPCOMP();
        public PF0642B_C01_ENDERECO C01_ENDERECO { get; set; } = new PF0642B_C01_ENDERECO();
        public PF0642B_COBERTURAS COBERTURAS { get; set; } = new PF0642B_COBERTURAS();
        public PF0642B_FUNDOCOMISVA FUNDOCOMISVA { get; set; } = new PF0642B_FUNDOCOMISVA();
        public PF0642B_C2 C2 { get; set; } = new PF0642B_C2();
        public PF0642B_FUNCIONARIOS FUNCIONARIOS { get; set; } = new PF0642B_FUNCIONARIOS();
        public PF0642B_COBERFUNC COBERFUNC { get; set; } = new PF0642B_COBERFUNC();
        public PF0642B_EMAIL EMAIL { get; set; } = new PF0642B_EMAIL();
        public PF0642B_ENDERECOS ENDERECOS { get; set; } = new PF0642B_ENDERECOS();
        public PF0642B_C01_AGENCEF C01_AGENCEF { get; set; } = new PF0642B_C01_AGENCEF();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOVTO_PRP_SASSE_FILE_NAME_P, string MOVTO_STA_SASSE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOVTO_PRP_SASSE.SetFile(MOVTO_PRP_SASSE_FILE_NAME_P);
                MOVTO_STA_SASSE.SetFile(MOVTO_STA_SASSE_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -707- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -708- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -709- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -712- DISPLAY ' ' */
            _.Display($" ");

            /*" -713- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -714- DISPLAY '*               PROGRAMA PF0642B               *' . */
            _.Display($"*               PROGRAMA PF0642B               *");

            /*" -715- DISPLAY '*         ESTOQUE DO VIDA EMPRESARIAL          *' . */
            _.Display($"*         ESTOQUE DO VIDA EMPRESARIAL          *");

            /*" -723- DISPLAY '* VERSAO: 18 - DD/MM/AAAA AS HH,MM,SS          *' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) '          *' */

            $"* VERSAO: 18 - DD/MM/AAAA AS HH,MM,SS          *FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}          *"
            .Display();

            /*" -724- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -725- DISPLAY ' ' */
            _.Display($" ");

            /*" -733- DISPLAY 'PF0642B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"PF0642B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -735- DISPLAY ' ' */
            _.Display($" ");

            /*" -737- PERFORM R0001-00-INICIALIZAR. */

            R0001_00_INICIALIZAR_SECTION();

            /*" -739- PERFORM R0005-00-OBTER-DATA-DIA. */

            R0005_00_OBTER_DATA_DIA_SECTION();

            /*" -741- PERFORM R0010-00-ABRIR-ARQUIVOS. */

            R0010_00_ABRIR_ARQUIVOS_SECTION();

            /*" -743- PERFORM R0020-00-OBTER-MAX-NSAS. */

            R0020_00_OBTER_MAX_NSAS_SECTION();

            /*" -745- MOVE 1 TO W-CURSOR. */
            _.Move(1, WAREA_AUXILIAR.W_CURSOR);

            /*" -747- PERFORM R0050-00-SELECIONA-MOVTO */

            R0050_00_SELECIONA_MOVTO_SECTION();

            /*" -749- PERFORM R0070-00-LER-MOVTO */

            R0070_00_LER_MOVTO_SECTION();

            /*" -750- IF W-FIM-MOVTO-TERMO EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM")
            {

                /*" -751- DISPLAY '*-----------------------------------------*' */
                _.Display($"*-----------------------------------------*");

                /*" -752- DISPLAY '*  PF0642B - TERMINO NORMAL, NAO HOUVE    *' */
                _.Display($"*  PF0642B - TERMINO NORMAL, NAO HOUVE    *");

                /*" -753- DISPLAY '*            MOVIMENTO NA DATA SOLICITADA *' */
                _.Display($"*            MOVIMENTO NA DATA SOLICITADA *");

                /*" -754- DISPLAY '*-----------------------------------------*' */
                _.Display($"*-----------------------------------------*");

                /*" -755- DISPLAY ' ' */
                _.Display($" ");

                /*" -756- PERFORM R1100-00-GERAR-TOTAIS */

                R1100_00_GERAR_TOTAIS_SECTION();

                /*" -757- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -759- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -761- PERFORM R0080-00-GERAR-HEADER */

            R0080_00_GERAR_HEADER_SECTION();

            /*" -763- PERFORM R0085-00-LER-PRODUTOS-SIVPF. */

            R0085_00_LER_PRODUTOS_SIVPF_SECTION();

            /*" -766- PERFORM R0150-00-PROCESSAR-MOVIMENTO UNTIL W-FIM-MOVTO-TERMO EQUAL 'FIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM"))
            {

                R0150_00_PROCESSAR_MOVIMENTO_SECTION();
            }

            /*" -768- PERFORM R1000-00-GERAR-TRAILLER. */

            R1000_00_GERAR_TRAILLER_SECTION();

            /*" -770- PERFORM R1050-00-CONTROLAR-ARQ-ENVIADO */

            R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION();

            /*" -772- PERFORM R1100-00-GERAR-TOTAIS. */

            R1100_00_GERAR_TOTAIS_SECTION();

            /*" -774- PERFORM R9988-00-FECHAR-ARQUIVOS. */

            R9988_00_FECHAR_ARQUIVOS_SECTION();

            /*" -774- PERFORM R9999-00-FINALIZAR. */

            R9999_00_FINALIZAR_SECTION();

        }

        [StopWatch]
        /*" R0001-00-INICIALIZAR-SECTION */
        private void R0001_00_INICIALIZAR_SECTION()
        {
            /*" -782- MOVE 'R0001-00-INICIALIZAR' TO PARAGRAFO. */
            _.Move("R0001-00-INICIALIZAR", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -784- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -786- INITIALIZE REG-TRAILLER, REG-TRAILLER-STA. */
            _.Initialize(
                LBFPF991.REG_TRAILLER
                , LBFCT011.REG_TRAILLER_STA
            );

            /*" -788- MOVE ZEROS TO TAB-FILIAIS. */
            _.Move(0, TAB_FILIAIS);

            /*" -790- PERFORM R6000-00-DECLARE-AGENCEF. */

            R6000_00_DECLARE_AGENCEF_SECTION();

            /*" -792- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

            /*" -793- IF WFIM-AGENCEF NOT EQUAL SPACES */

            if (!WAREA_AUXILIAR.WFIM_AGENCEF.IsEmpty())
            {

                /*" -794- DISPLAY '6000 - PROBLEMA NO FETCH DA AGENCIACEF' */
                _.Display($"6000 - PROBLEMA NO FETCH DA AGENCIACEF");

                /*" -796- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -797- PERFORM R6020-00-CARREGA-FILIAL UNTIL WFIM-AGENCEF EQUAL 'S' . */

            while (!(WAREA_AUXILIAR.WFIM_AGENCEF == "S"))
            {

                R6020_00_CARREGA_FILIAL_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0001_SAIDA*/

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-SECTION */
        private void R0005_00_OBTER_DATA_DIA_SECTION()
        {
            /*" -807- MOVE 'R0005-00-OBTER-DATA-DIA' TO PARAGRAFO. */
            _.Move("R0005-00-OBTER-DATA-DIA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -809- MOVE 'SELECT SEGUROS.SISTEMAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.SISTEMAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -811- MOVE 'PF' TO SISTEMAS-IDE-SISTEMA OF DCLSISTEMAS. */
            _.Move("PF", SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA);

            /*" -819- PERFORM R0005_00_OBTER_DATA_DIA_DB_SELECT_1 */

            R0005_00_OBTER_DATA_DIA_DB_SELECT_1();

            /*" -824- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO W-DTMOVABE. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WAREA_AUXILIAR.W_DTMOVABE);

            /*" -826- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_DIA_MOVABE_0);

            /*" -828- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_MES_MOVABE_0);

            /*" -831- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-MOVABE OF W-DTMOVABE-I1. */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.W_DTMOVABE_I1.W_ANO_MOVABE_0);

            /*" -835- MOVE '-' TO W-BARRA1 OF W-DTMOVABE-I1, W-BARRA2 OF W-DTMOVABE-I1. */
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA1_0);
            _.Move("-", WAREA_AUXILIAR.W_DTMOVABE_I1.W_BARRA2_0);


            /*" -836- DISPLAY 'PF0642B - DATA DO PROCESSAMENTO ==> ' W-DTMOVABE-I1. */
            _.Display($"PF0642B - DATA DO PROCESSAMENTO ==> {WAREA_AUXILIAR.W_DTMOVABE_I1}");

        }

        [StopWatch]
        /*" R0005-00-OBTER-DATA-DIA-DB-SELECT-1 */
        public void R0005_00_OBTER_DATA_DIA_DB_SELECT_1()
        {
            /*" -819- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO INTO :DCLSISTEMAS.SISTEMAS-DATA-MOV-ABERTO, :WHOST-DATA-REFERENCIA FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = :DCLSISTEMAS.SISTEMAS-IDE-SISTEMA WITH UR END-EXEC. */

            var r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1 = new R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1()
            {
                SISTEMAS_IDE_SISTEMA = SISTEMAS.DCLSISTEMAS.SISTEMAS_IDE_SISTEMA.ToString(),
            };

            var executed_1 = R0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1.Execute(r0005_00_OBTER_DATA_DIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DATA_REFERENCIA, WHOST_DATA_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0005_SAIDA*/

        [StopWatch]
        /*" R0010-00-ABRIR-ARQUIVOS-SECTION */
        private void R0010_00_ABRIR_ARQUIVOS_SECTION()
        {
            /*" -846- MOVE 'R0010-00-ABRIR-ARQUIVOS' TO PARAGRAFO. */
            _.Move("R0010-00-ABRIR-ARQUIVOS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -848- MOVE 'OPEN' TO COMANDO. */
            _.Move("OPEN", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -849- OPEN OUTPUT MOVTO-PRP-SASSE, MOVTO-STA-SASSE. */
            MOVTO_PRP_SASSE.Open(REG_PRP_SASSE);
            MOVTO_STA_SASSE.Open(REG_STA_SASSE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_SAIDA*/

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-SECTION */
        private void R0020_00_OBTER_MAX_NSAS_SECTION()
        {
            /*" -859- MOVE 'R0020-00-OBTER-MAX-NSAS' TO PARAGRAFO. */
            _.Move("R0020-00-OBTER-MAX-NSAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -861- MOVE 'SELECT MAX ARQUIVOS-SIVPF' TO COMANDO. */
            _.Move("SELECT MAX ARQUIVOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -863- MOVE SPACES TO REG-HEADER, REG-HEADER-STA. */
            _.Move("", LXFPF990.REG_HEADER, LBFCT011.REG_HEADER_STA);

            /*" -866- MOVE 'PRPSASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("PRPSASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -869- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -878- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_1 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_1();

            /*" -881- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -882- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -883- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -885- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -886- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -888- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -891- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -893- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -898- MOVE W-NSAS TO RH-NSAS OF REG-HEADER. */
            _.Move(WAREA_AUXILIAR.W_NSAS, LXFPF990.REG_HEADER.RH_NSAS);

            /*" -901- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -905- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -914- PERFORM R0020_00_OBTER_MAX_NSAS_DB_SELECT_2 */

            R0020_00_OBTER_MAX_NSAS_DB_SELECT_2();

            /*" -917- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -918- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -919- DISPLAY '          ERRO SELECT MAX ARQUIVOS-SIVPF' */
                _.Display($"          ERRO SELECT MAX ARQUIVOS-SIVPF");

                /*" -921- DISPLAY '          SQLCODE........................ ' SQLCODE */
                _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                /*" -922- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -924- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -927- MOVE ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF TO W-NSAS. */
            _.Move(ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF, WAREA_AUXILIAR.W_NSAS);

            /*" -929- ADD 1 TO W-NSAS. */
            WAREA_AUXILIAR.W_NSAS.Value = WAREA_AUXILIAR.W_NSAS + 1;

            /*" -929- MOVE W-NSAS TO RH-NSAS OF REG-HEADER-STA. */
            _.Move(WAREA_AUXILIAR.W_NSAS, LBFCT011.REG_HEADER_STA.RH_NSAS);

        }

        [StopWatch]
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-1 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_1()
        {
            /*" -878- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

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
        /*" R0020-00-OBTER-MAX-NSAS-DB-SELECT-2 */
        public void R0020_00_OBTER_MAX_NSAS_DB_SELECT_2()
        {
            /*" -914- EXEC SQL SELECT VALUE(MAX(NSAS_SIVPF),0) INTO :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF FROM SEGUROS.ARQUIVOS_SIVPF WHERE SIGLA_ARQUIVO = :DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO AND SISTEMA_ORIGEM = :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM WITH UR END-EXEC. */

            var r0020_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1 = new R0020_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1()
            {
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
            };

            var executed_1 = R0020_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1.Execute(r0020_00_OBTER_MAX_NSAS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ARQSIVPF_NSAS_SIVPF, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);
            }


        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-SECTION */
        private void R0050_00_SELECIONA_MOVTO_SECTION()
        {
            /*" -939- MOVE 'R0050-00-SELECIONA-MOVTO' TO PARAGRAFO. */
            _.Move("R0050-00-SELECIONA-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -941- MOVE 'DECLER MOVIMENTO' TO COMANDO. */
            _.Move("DECLER MOVIMENTO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -942- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -944- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -952- DISPLAY '** PF0642B ** INICIO DECLARE V0MOVIMENTO...  ' W-TIME-EDIT. */
            _.Display($"** PF0642B ** INICIO DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -1041- PERFORM R0050_00_SELECIONA_MOVTO_DB_DECLARE_1 */

            R0050_00_SELECIONA_MOVTO_DB_DECLARE_1();

            /*" -1043- PERFORM R0050_00_SELECIONA_MOVTO_DB_OPEN_1 */

            R0050_00_SELECIONA_MOVTO_DB_OPEN_1();

            /*" -1047- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1050- MOVE 2 TO W-CURSOR. */
                _.Move(2, WAREA_AUXILIAR.W_CURSOR);
            }


            /*" -1051- ACCEPT W-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

            /*" -1053- MOVE W-TIME TO W-TIME-EDIT. */
            _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

            /*" -1055- DISPLAY '** PF0642B ** FIM    DECLARE V0MOVIMENTO...  ' W-TIME-EDIT */
            _.Display($"** PF0642B ** FIM    DECLARE V0MOVIMENTO...  {WAREA_AUXILIAR.W_TIME_EDIT}");

            /*" -1055- DISPLAY ' ' . */
            _.Display($" ");

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-DECLARE-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_DECLARE_1()
        {
            /*" -1041- EXEC SQL DECLARE TERMO-ADESAO CURSOR FOR SELECT A.NUM_TERMO , A.COD_SUBGRUPO , A.DATA_ADESAO , A.COD_AGENCIA_OP , A.NUM_MATRICULA_VEN , A.CODPDTVEN , A.PCCOMVEN , A.PCADIANTVEN , A.COD_AGENCIA_VEN , A.OPERACAO_CONTA_VEN , A.NUM_CONTA_VEN , A.DIG_CONTA_VEN , A.NUM_MATRICULA_GER , A.CODPDTGER , A.PCCOMGER , A.COD_AGENCIA_GER , A.OPERACAO_CONTA_GER , A.NUM_CONTA_GER , A.DIG_CONTA_GER , A.NUM_MATRICULA_SUR , A.CODPDTSUR , A.PCCOMSUR , A.NUM_MATRICULA_GCO , A.CODPDTGCO , A.PCCOMGCO , A.MODALIDADE_CAPITAL , A.TIPO_PLANO , A.IND_PLANO_ASSOCIAD , A.COD_PLANO_VGAPC , A.COD_PLANO_APC , A.VAL_CONTRATADO , A.VAL_COMISSAO_ADIAN , A.QUANT_VIDAS , A.TIPO_COBERTURA , A.PERI_PAGAMENTO , A.TIPO_CORRECAO , A.PERIODO_CORRECAO , A.COD_MOEDA_IMP , A.COD_MOEDA_PRM , A.COD_CLIENTE , A.OCORR_ENDERECO , A.COD_CORRETOR , A.PCCOMCOR , A.COD_ADMINISTRADOR , A.PCCOMADM , A.COD_USUARIO , A.DATA_INCLUSAO , A.SITUACAO , A.NUM_PROPOSTA , A.NUM_RCAP , A.DATA_RCAP , A.VAL_RCAP , A.NUM_APOLICE , B.NUM_PROPOSTA_SIVPF , B.DTH_DIA_DEBITO , B.COD_AGENCIA_DEB , B.OPERACAO_CONTA_DEB , B.NUM_CONTA_DEBITO , B.DIG_CONTA_DEBITO , B.DTH_LIBERACAO FROM SEGUROS.TERMO_ADESAO A, SEGUROS.VG_COMPL_TERMO B WHERE A.SITUACAO = '0' AND B.NUM_TERMO = A.NUM_TERMO AND B.DTH_LIBERACAO = :SISTEMAS-DATA-MOV-ABERTO WITH UR END-EXEC. */
            TERMO_ADESAO = new PF0642B_TERMO_ADESAO(true);
            string GetQuery_TERMO_ADESAO()
            {
                var query = @$"SELECT A.NUM_TERMO
							, 
							A.COD_SUBGRUPO
							, 
							A.DATA_ADESAO
							, 
							A.COD_AGENCIA_OP
							, 
							A.NUM_MATRICULA_VEN
							, 
							A.CODPDTVEN
							, 
							A.PCCOMVEN
							, 
							A.PCADIANTVEN
							, 
							A.COD_AGENCIA_VEN
							, 
							A.OPERACAO_CONTA_VEN
							, 
							A.NUM_CONTA_VEN
							, 
							A.DIG_CONTA_VEN
							, 
							A.NUM_MATRICULA_GER
							, 
							A.CODPDTGER
							, 
							A.PCCOMGER
							, 
							A.COD_AGENCIA_GER
							, 
							A.OPERACAO_CONTA_GER
							, 
							A.NUM_CONTA_GER
							, 
							A.DIG_CONTA_GER
							, 
							A.NUM_MATRICULA_SUR
							, 
							A.CODPDTSUR
							, 
							A.PCCOMSUR
							, 
							A.NUM_MATRICULA_GCO
							, 
							A.CODPDTGCO
							, 
							A.PCCOMGCO
							, 
							A.MODALIDADE_CAPITAL
							, 
							A.TIPO_PLANO
							, 
							A.IND_PLANO_ASSOCIAD
							, 
							A.COD_PLANO_VGAPC
							, 
							A.COD_PLANO_APC
							, 
							A.VAL_CONTRATADO
							, 
							A.VAL_COMISSAO_ADIAN
							, 
							A.QUANT_VIDAS
							, 
							A.TIPO_COBERTURA
							, 
							A.PERI_PAGAMENTO
							, 
							A.TIPO_CORRECAO
							, 
							A.PERIODO_CORRECAO
							, 
							A.COD_MOEDA_IMP
							, 
							A.COD_MOEDA_PRM
							, 
							A.COD_CLIENTE
							, 
							A.OCORR_ENDERECO
							, 
							A.COD_CORRETOR
							, 
							A.PCCOMCOR
							, 
							A.COD_ADMINISTRADOR
							, 
							A.PCCOMADM
							, 
							A.COD_USUARIO
							, 
							A.DATA_INCLUSAO
							, 
							A.SITUACAO
							, 
							A.NUM_PROPOSTA
							, 
							A.NUM_RCAP
							, 
							A.DATA_RCAP
							, 
							A.VAL_RCAP
							, 
							A.NUM_APOLICE
							, 
							B.NUM_PROPOSTA_SIVPF
							, 
							B.DTH_DIA_DEBITO
							, 
							B.COD_AGENCIA_DEB
							, 
							B.OPERACAO_CONTA_DEB
							, 
							B.NUM_CONTA_DEBITO
							, 
							B.DIG_CONTA_DEBITO
							, 
							B.DTH_LIBERACAO 
							FROM SEGUROS.TERMO_ADESAO A
							, 
							SEGUROS.VG_COMPL_TERMO B 
							WHERE A.SITUACAO = '0' 
							AND B.NUM_TERMO = A.NUM_TERMO 
							AND B.DTH_LIBERACAO = 
							'{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}'";

                return query;
            }
            TERMO_ADESAO.GetQueryEvent += GetQuery_TERMO_ADESAO;

        }

        [StopWatch]
        /*" R0050-00-SELECIONA-MOVTO-DB-OPEN-1 */
        public void R0050_00_SELECIONA_MOVTO_DB_OPEN_1()
        {
            /*" -1043- EXEC SQL OPEN TERMO-ADESAO END-EXEC. */

            TERMO_ADESAO.Open();

        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-DECLARE-1 */
        public void R0205_00_LER_RCAPCOMP_DB_DECLARE_1()
        {
            /*" -1552- EXEC SQL DECLARE C01_RCAPCOMP CURSOR FOR SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP, COD_OPERACAO FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 ORDER BY COD_OPERACAO DESC WITH UR END-EXEC */
            C01_RCAPCOMP = new PF0642B_C01_RCAPCOMP(true);
            string GetQuery_C01_RCAPCOMP()
            {
                var query = @$"SELECT BCO_AVISO
							, 
							AGE_AVISO
							, 
							NUM_AVISO_CREDITO
							, 
							DATA_MOVIMENTO
							, 
							DATA_RCAP
							, 
							COD_OPERACAO 
							FROM SEGUROS.RCAP_COMPLEMENTAR 
							WHERE COD_FONTE = '{RCAPS.DCLRCAPS.RCAPS_COD_FONTE}' 
							AND NUM_RCAP = '{RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}' 
							AND NUM_RCAP_COMPLEMEN = 0 
							ORDER BY COD_OPERACAO DESC";

                return query;
            }
            C01_RCAPCOMP.GetQueryEvent += GetQuery_C01_RCAPCOMP;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-SECTION */
        private void R0070_00_LER_MOVTO_SECTION()
        {
            /*" -1065- MOVE 'R0070-00-LER-MOVTO' TO PARAGRAFO. */
            _.Move("R0070-00-LER-MOVTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1067- MOVE 'FETCH TERMO-ADESAO' TO COMANDO. */
            _.Move("FETCH TERMO-ADESAO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1129- PERFORM R0070_00_LER_MOVTO_DB_FETCH_1 */

            R0070_00_LER_MOVTO_DB_FETCH_1();

            /*" -1132- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1133- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1134- MOVE 'FIM' TO W-FIM-MOVTO-TERMO */
                    _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_TERMO);

                    /*" -1134- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_1 */

                    R0070_00_LER_MOVTO_DB_CLOSE_1();

                    /*" -1136- ELSE */
                }
                else
                {


                    /*" -1137- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -1139- DISPLAY '          ERRO FETCH CURSOR V0MOVIMENTO  ' SQLCODE */
                    _.Display($"          ERRO FETCH CURSOR V0MOVIMENTO  {DB.SQLCODE}");

                    /*" -1140- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1141- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1142- END-IF */
                }


                /*" -1147- ELSE */
            }
            else
            {


                /*" -1148- IF VIND-RCAP LESS 0 */

                if (VIND_RCAP < 0)
                {

                    /*" -1151- DISPLAY 'REJEITANDO POR NUM-RCAP MENOR QUE ZERO - ' TERMOADE-NUM-TERMO ' ' VGCOMTRO-NUM-PROPOSTA-SIVPF */

                    $"REJEITANDO POR NUM-RCAP MENOR QUE ZERO - {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO} {VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF}"
                    .Display();

                    /*" -1152- GO TO R0070-00-LER-MOVTO */
                    new Task(() => R0070_00_LER_MOVTO_SECTION()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1154- END-IF */
                }


                /*" -1157- ADD 1 TO W-NSL, W-CONTROLE */
                WAREA_AUXILIAR.W_NSL.Value = WAREA_AUXILIAR.W_NSL + 1;
                WAREA_AUXILIAR.W_CONTROLE.Value = WAREA_AUXILIAR.W_CONTROLE + 1;

                /*" -1169- COMPUTE W-TOT-PROCESSADO = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J */
                WAREA_AUXILIAR.W_TOT_PROCESSADO.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9 + WAREA_AUXILIAR.W_QTD_LD_TIPO_A + WAREA_AUXILIAR.W_QTD_LD_TIPO_B + WAREA_AUXILIAR.W_QTD_LD_TIPO_C + WAREA_AUXILIAR.W_QTD_LD_TIPO_D + WAREA_AUXILIAR.W_QTD_LD_TIPO_E + WAREA_AUXILIAR.W_QTD_LD_TIPO_F + WAREA_AUXILIAR.W_QTD_LD_TIPO_G + WAREA_AUXILIAR.W_QTD_LD_TIPO_H + WAREA_AUXILIAR.W_QTD_LD_TIPO_I + WAREA_AUXILIAR.W_QTD_LD_TIPO_J;

                /*" -1170- IF W-CONTROLE > 999 */

                if (WAREA_AUXILIAR.W_CONTROLE > 999)
                {

                    /*" -1171- ACCEPT W-TIME FROM TIME */
                    _.Move(_.AcceptDate("TIME"), WAREA_AUXILIAR.W_TIME);

                    /*" -1172- MOVE W-TIME TO W-TIME-EDIT */
                    _.Move(WAREA_AUXILIAR.W_TIME, WAREA_AUXILIAR.W_TIME_EDIT);

                    /*" -1173- MOVE ZEROS TO W-CONTROLE */
                    _.Move(0, WAREA_AUXILIAR.W_CONTROLE);

                    /*" -1174- DISPLAY ' ' */
                    _.Display($" ");

                    /*" -1176- DISPLAY '** PF0642B ** TOTAL LIDOS..  ' W-NSL ' ' W-TIME-EDIT */

                    $"** PF0642B ** TOTAL LIDOS..  {WAREA_AUXILIAR.W_NSL} {WAREA_AUXILIAR.W_TIME_EDIT}"
                    .Display();

                    /*" -1178- END-IF */
                }


                /*" -1179- IF W-TOT-PROCESSADO GREATER 99999 */

                if (WAREA_AUXILIAR.W_TOT_PROCESSADO > 99999)
                {

                    /*" -1180- IF W-FIM-MOVTO-TERMO NOT EQUAL 'FIM' */

                    if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO != "FIM")
                    {

                        /*" -1181- MOVE 'FIM' TO W-FIM-MOVTO-TERMO */
                        _.Move("FIM", WAREA_AUXILIAR.W_FIM_MOVTO_TERMO);

                        /*" -1181- PERFORM R0070_00_LER_MOVTO_DB_CLOSE_2 */

                        R0070_00_LER_MOVTO_DB_CLOSE_2();

                        /*" -1183- END-IF */
                    }


                    /*" -1184- END-IF */
                }


                /*" -1184- END-IF. */
            }


        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-FETCH-1 */
        public void R0070_00_LER_MOVTO_DB_FETCH_1()
        {
            /*" -1129- EXEC SQL FETCH TERMO-ADESAO INTO :TERMOADE-NUM-TERMO , :TERMOADE-COD-SUBGRUPO , :TERMOADE-DATA-ADESAO , :TERMOADE-COD-AGENCIA-OP , :TERMOADE-NUM-MATRICULA-VEN , :TERMOADE-CODPDTVEN , :TERMOADE-PCCOMVEN , :TERMOADE-PCADIANTVEN , :TERMOADE-COD-AGENCIA-VEN , :TERMOADE-OPERACAO-CONTA-VEN , :TERMOADE-NUM-CONTA-VEN , :TERMOADE-DIG-CONTA-VEN , :TERMOADE-NUM-MATRICULA-GER , :TERMOADE-CODPDTGER , :TERMOADE-PCCOMGER , :TERMOADE-COD-AGENCIA-GER , :TERMOADE-OPERACAO-CONTA-GER , :TERMOADE-NUM-CONTA-GER , :TERMOADE-DIG-CONTA-GER , :TERMOADE-NUM-MATRICULA-SUR , :TERMOADE-CODPDTSUR , :TERMOADE-PCCOMSUR , :TERMOADE-NUM-MATRICULA-GCO , :TERMOADE-CODPDTGCO , :TERMOADE-PCCOMGCO , :TERMOADE-MODALIDADE-CAPITAL , :TERMOADE-TIPO-PLANO , :TERMOADE-IND-PLANO-ASSOCIAD , :TERMOADE-COD-PLANO-VGAPC , :TERMOADE-COD-PLANO-APC , :TERMOADE-VAL-CONTRATADO , :TERMOADE-VAL-COMISSAO-ADIAN , :TERMOADE-QUANT-VIDAS , :TERMOADE-TIPO-COBERTURA , :TERMOADE-PERI-PAGAMENTO , :TERMOADE-TIPO-CORRECAO , :TERMOADE-PERIODO-CORRECAO , :TERMOADE-COD-MOEDA-IMP , :TERMOADE-COD-MOEDA-PRM , :TERMOADE-COD-CLIENTE , :TERMOADE-OCORR-ENDERECO , :TERMOADE-COD-CORRETOR , :TERMOADE-PCCOMCOR , :TERMOADE-COD-ADMINISTRADOR , :TERMOADE-PCCOMADM , :TERMOADE-COD-USUARIO , :TERMOADE-DATA-INCLUSAO , :TERMOADE-SITUACAO , :TERMOADE-NUM-PROPOSTA , :TERMOADE-NUM-RCAP:VIND-RCAP , :TERMOADE-DATA-RCAP:VIND-DATA-RCAP , :TERMOADE-VAL-RCAP:VIND-VAL-RCAP , :TERMOADE-NUM-APOLICE , :VGCOMTRO-NUM-PROPOSTA-SIVPF , :VGCOMTRO-DTH-DIA-DEBITO , :VGCOMTRO-COD-AGENCIA-DEB , :VGCOMTRO-OPERACAO-CONTA-DEB , :VGCOMTRO-NUM-CONTA-DEBITO , :VGCOMTRO-DIG-CONTA-DEBITO , :VGCOMTRO-DTH-LIBERACAO END-EXEC. */

            if (TERMO_ADESAO.Fetch())
            {
                _.Move(TERMO_ADESAO.TERMOADE_NUM_TERMO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO);
                _.Move(TERMO_ADESAO.TERMOADE_COD_SUBGRUPO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO);
                _.Move(TERMO_ADESAO.TERMOADE_DATA_ADESAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO);
                _.Move(TERMO_ADESAO.TERMOADE_COD_AGENCIA_OP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_OP);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN);
                _.Move(TERMO_ADESAO.TERMOADE_CODPDTVEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_CODPDTVEN);
                _.Move(TERMO_ADESAO.TERMOADE_PCCOMVEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMVEN);
                _.Move(TERMO_ADESAO.TERMOADE_PCADIANTVEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCADIANTVEN);
                _.Move(TERMO_ADESAO.TERMOADE_COD_AGENCIA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_VEN);
                _.Move(TERMO_ADESAO.TERMOADE_OPERACAO_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_OPERACAO_CONTA_VEN);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_CONTA_VEN);
                _.Move(TERMO_ADESAO.TERMOADE_DIG_CONTA_VEN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DIG_CONTA_VEN);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_MATRICULA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_GER);
                _.Move(TERMO_ADESAO.TERMOADE_CODPDTGER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_CODPDTGER);
                _.Move(TERMO_ADESAO.TERMOADE_PCCOMGER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMGER);
                _.Move(TERMO_ADESAO.TERMOADE_COD_AGENCIA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_GER);
                _.Move(TERMO_ADESAO.TERMOADE_OPERACAO_CONTA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_OPERACAO_CONTA_GER);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_CONTA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_CONTA_GER);
                _.Move(TERMO_ADESAO.TERMOADE_DIG_CONTA_GER, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DIG_CONTA_GER);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_MATRICULA_SUR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_SUR);
                _.Move(TERMO_ADESAO.TERMOADE_CODPDTSUR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_CODPDTSUR);
                _.Move(TERMO_ADESAO.TERMOADE_PCCOMSUR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMSUR);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_MATRICULA_GCO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_GCO);
                _.Move(TERMO_ADESAO.TERMOADE_CODPDTGCO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_CODPDTGCO);
                _.Move(TERMO_ADESAO.TERMOADE_PCCOMGCO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMGCO);
                _.Move(TERMO_ADESAO.TERMOADE_MODALIDADE_CAPITAL, TERMOADE.DCLTERMO_ADESAO.TERMOADE_MODALIDADE_CAPITAL);
                _.Move(TERMO_ADESAO.TERMOADE_TIPO_PLANO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_PLANO);
                _.Move(TERMO_ADESAO.TERMOADE_IND_PLANO_ASSOCIAD, TERMOADE.DCLTERMO_ADESAO.TERMOADE_IND_PLANO_ASSOCIAD);
                _.Move(TERMO_ADESAO.TERMOADE_COD_PLANO_VGAPC, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_VGAPC);
                _.Move(TERMO_ADESAO.TERMOADE_COD_PLANO_APC, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_APC);
                _.Move(TERMO_ADESAO.TERMOADE_VAL_CONTRATADO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_CONTRATADO);
                _.Move(TERMO_ADESAO.TERMOADE_VAL_COMISSAO_ADIAN, TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_COMISSAO_ADIAN);
                _.Move(TERMO_ADESAO.TERMOADE_QUANT_VIDAS, TERMOADE.DCLTERMO_ADESAO.TERMOADE_QUANT_VIDAS);
                _.Move(TERMO_ADESAO.TERMOADE_TIPO_COBERTURA, TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_COBERTURA);
                _.Move(TERMO_ADESAO.TERMOADE_PERI_PAGAMENTO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERI_PAGAMENTO);
                _.Move(TERMO_ADESAO.TERMOADE_TIPO_CORRECAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_CORRECAO);
                _.Move(TERMO_ADESAO.TERMOADE_PERIODO_CORRECAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERIODO_CORRECAO);
                _.Move(TERMO_ADESAO.TERMOADE_COD_MOEDA_IMP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_MOEDA_IMP);
                _.Move(TERMO_ADESAO.TERMOADE_COD_MOEDA_PRM, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_MOEDA_PRM);
                _.Move(TERMO_ADESAO.TERMOADE_COD_CLIENTE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE);
                _.Move(TERMO_ADESAO.TERMOADE_OCORR_ENDERECO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_OCORR_ENDERECO);
                _.Move(TERMO_ADESAO.TERMOADE_COD_CORRETOR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CORRETOR);
                _.Move(TERMO_ADESAO.TERMOADE_PCCOMCOR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMCOR);
                _.Move(TERMO_ADESAO.TERMOADE_COD_ADMINISTRADOR, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_ADMINISTRADOR);
                _.Move(TERMO_ADESAO.TERMOADE_PCCOMADM, TERMOADE.DCLTERMO_ADESAO.TERMOADE_PCCOMADM);
                _.Move(TERMO_ADESAO.TERMOADE_COD_USUARIO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_USUARIO);
                _.Move(TERMO_ADESAO.TERMOADE_DATA_INCLUSAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_INCLUSAO);
                _.Move(TERMO_ADESAO.TERMOADE_SITUACAO, TERMOADE.DCLTERMO_ADESAO.TERMOADE_SITUACAO);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_PROPOSTA, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_PROPOSTA);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_RCAP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_RCAP);
                _.Move(TERMO_ADESAO.VIND_RCAP, VIND_RCAP);
                _.Move(TERMO_ADESAO.TERMOADE_DATA_RCAP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_RCAP);
                _.Move(TERMO_ADESAO.VIND_DATA_RCAP, VIND_DATA_RCAP);
                _.Move(TERMO_ADESAO.TERMOADE_VAL_RCAP, TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_RCAP);
                _.Move(TERMO_ADESAO.VIND_VAL_RCAP, VIND_VAL_RCAP);
                _.Move(TERMO_ADESAO.TERMOADE_NUM_APOLICE, TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE);
                _.Move(TERMO_ADESAO.VGCOMTRO_NUM_PROPOSTA_SIVPF, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF);
                _.Move(TERMO_ADESAO.VGCOMTRO_DTH_DIA_DEBITO, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_DTH_DIA_DEBITO);
                _.Move(TERMO_ADESAO.VGCOMTRO_COD_AGENCIA_DEB, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_COD_AGENCIA_DEB);
                _.Move(TERMO_ADESAO.VGCOMTRO_OPERACAO_CONTA_DEB, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_OPERACAO_CONTA_DEB);
                _.Move(TERMO_ADESAO.VGCOMTRO_NUM_CONTA_DEBITO, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_CONTA_DEBITO);
                _.Move(TERMO_ADESAO.VGCOMTRO_DIG_CONTA_DEBITO, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_DIG_CONTA_DEBITO);
                _.Move(TERMO_ADESAO.VGCOMTRO_DTH_LIBERACAO, VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_DTH_LIBERACAO);
            }

        }

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-1 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_1()
        {
            /*" -1134- EXEC SQL CLOSE TERMO-ADESAO END-EXEC */

            TERMO_ADESAO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0070_SAIDA*/

        [StopWatch]
        /*" R0070-00-LER-MOVTO-DB-CLOSE-2 */
        public void R0070_00_LER_MOVTO_DB_CLOSE_2()
        {
            /*" -1181- EXEC SQL CLOSE TERMO-ADESAO END-EXEC */

            TERMO_ADESAO.Close();

        }

        [StopWatch]
        /*" R0080-00-GERAR-HEADER-SECTION */
        private void R0080_00_GERAR_HEADER_SECTION()
        {
            /*" -1194- MOVE 'R0080-00-GERAR-HEADER' TO PARAGRAFO. */
            _.Move("R0080-00-GERAR-HEADER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1196- MOVE 'WRITE REG-HEADER' TO COMANDO. */
            _.Move("WRITE REG-HEADER", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1199- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER */
            _.Move("H", LXFPF990.REG_HEADER.RH_TIPO_REG);

            /*" -1202- MOVE 'PRPSASSE' TO RH-NOME OF REG-HEADER */
            _.Move("PRPSASSE", LXFPF990.REG_HEADER.RH_NOME);

            /*" -1203- MOVE W-DIA-MOVABE OF W-DTMOVABE1 TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_DIA_MOVABE, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -1204- MOVE W-MES-MOVABE OF W-DTMOVABE1 TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_MES_MOVABE, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -1206- MOVE W-ANO-MOVABE OF W-DTMOVABE1 TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DTMOVABE1.W_ANO_MOVABE, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -1209- MOVE W-DATA-TRABALHO TO RH-DATA-GERACAO OF REG-HEADER */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFPF990.REG_HEADER.RH_DATA_GERACAO);

            /*" -1212- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER */
            _.Move(4, LXFPF990.REG_HEADER.RH_SIST_ORIGEM);

            /*" -1215- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER */
            _.Move(1, LXFPF990.REG_HEADER.RH_SIST_DESTINO);

            /*" -1217- MOVE 1 TO RH-TIPO-ARQUIVO OF REG-HEADER. */
            _.Move(1, LXFPF990.REG_HEADER.RH_TIPO_ARQUIVO);

            /*" -1222- WRITE REG-PRP-SASSE FROM REG-HEADER. */
            _.Move(LXFPF990.REG_HEADER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -1225- MOVE 'H' TO RH-TIPO-REG OF REG-HEADER-STA */
            _.Move("H", LBFCT011.REG_HEADER_STA.RH_TIPO_REG);

            /*" -1228- MOVE 'STASASSE' TO RH-NOME-EMPRESA OF REG-HEADER-STA */
            _.Move("STASASSE", LBFCT011.REG_HEADER_STA.RH_NOME_EMPRESA);

            /*" -1231- MOVE RH-DATA-GERACAO OF REG-HEADER TO RH-DATA-GERACAO OF REG-HEADER-STA */
            _.Move(LXFPF990.REG_HEADER.RH_DATA_GERACAO, LBFCT011.REG_HEADER_STA.RH_DATA_GERACAO);

            /*" -1234- MOVE 4 TO RH-SIST-ORIGEM OF REG-HEADER-STA */
            _.Move(4, LBFCT011.REG_HEADER_STA.RH_SIST_ORIGEM);

            /*" -1237- MOVE 1 TO RH-SIST-DESTINO OF REG-HEADER-STA */
            _.Move(1, LBFCT011.REG_HEADER_STA.RH_SIST_DESTINO);

            /*" -1237- WRITE REG-STA-SASSE FROM REG-HEADER-STA. */
            _.Move(LBFCT011.REG_HEADER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0080_SAIDA*/

        [StopWatch]
        /*" R0085-00-LER-PRODUTOS-SIVPF-SECTION */
        private void R0085_00_LER_PRODUTOS_SIVPF_SECTION()
        {
            /*" -1247- MOVE 'R0085-00-LER-PRODUTOS-SIVPF' TO PARAGRAFO. */
            _.Move("R0085-00-LER-PRODUTOS-SIVPF", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1249- MOVE 'SELECT PRODUTOS-SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS-SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1251- MOVE 16 TO PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF. */
            _.Move(16, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF);

            /*" -1264- PERFORM R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1 */

            R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1();

            /*" -1267- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1268- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -1269- DISPLAY '  R0085   ERRO SELECT PRODUTOS-SIVPF' */
                _.Display($"  R0085   ERRO SELECT PRODUTOS-SIVPF");

                /*" -1271- DISPLAY '          CODIGO PRODUTO SIVPF......' PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF */
                _.Display($"          CODIGO PRODUTO SIVPF......{PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF}");

                /*" -1273- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1274- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1274- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0085-00-LER-PRODUTOS-SIVPF-DB-SELECT-1 */
        public void R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1()
        {
            /*" -1264- EXEC SQL SELECT DISTINCT COD_EMPRESA_SIVPF , COD_RELAC INTO :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-EMPRESA-SIVPF , :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-RELAC FROM SEGUROS.PRODUTOS_SIVPF WHERE COD_EMPRESA_SIVPF = 1 AND COD_PRODUTO_SIVPF = :DCLPRODUTOS-SIVPF.PRDSIVPF-COD-PRODUTO-SIVPF ORDER BY COD_EMPRESA_SIVPF, COD_RELAC WITH UR END-EXEC. */

            var r0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1 = new R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1()
            {
                PRDSIVPF_COD_PRODUTO_SIVPF = PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF.ToString(),
            };

            var executed_1 = R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1.Execute(r0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRDSIVPF_COD_EMPRESA_SIVPF, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF);
                _.Move(executed_1.PRDSIVPF_COD_RELAC, PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0085_SAIDA*/

        [StopWatch]
        /*" R0150-00-PROCESSAR-MOVIMENTO-SECTION */
        private void R0150_00_PROCESSAR_MOVIMENTO_SECTION()
        {
            /*" -1284- MOVE 'R0150-00-PROCESSA-MOVIMENTO' TO PARAGRAFO. */
            _.Move("R0150-00-PROCESSA-MOVIMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1286- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1290- MOVE 'N' TO WFIM-ENDERECOS. */
            _.Move("N", WAREA_AUXILIAR.WFIM_ENDERECOS);

            /*" -1292- PERFORM R0210-00-LER-PRP-FIDELIZ. */

            R0210_00_LER_PRP_FIDELIZ_SECTION();

            /*" -1293- IF PROPOSTA-CADASTRADA */

            if (WAREA_AUXILIAR.W_FIDELIZ["PROPOSTA_CADASTRADA"])
            {

                /*" -1295- ADD 1 TO W-DESPREZADO-01 */
                WAREA_AUXILIAR.W_DESPREZADO_01.Value = WAREA_AUXILIAR.W_DESPREZADO_01 + 1;

                /*" -1297- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1298- IF VGCOMTRO-NUM-PROPOSTA-SIVPF GREATER 10000000000 */

            if (VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF > 10000000000)
            {

                /*" -1299- IF VGCOMTRO-NUM-PROPOSTA-SIVPF LESS 19999999999 */

                if (VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF < 19999999999)
                {

                    /*" -1301- ADD 1 TO W-DESPREZADO-02 */
                    WAREA_AUXILIAR.W_DESPREZADO_02.Value = WAREA_AUXILIAR.W_DESPREZADO_02 + 1;

                    /*" -1303- DISPLAY 'PF0642B - PROBLEMA NA FAIXA DE NUMERACAO   ' TERMOADE-NUM-TERMO '  ' VGCOMTRO-NUM-PROPOSTA-SIVPF */

                    $"PF0642B - PROBLEMA NA FAIXA DE NUMERACAO   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF}"
                    .Display();

                    /*" -1304- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1306- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -1308- PERFORM R0200-00-LER-RCAPS */

            R0200_00_LER_RCAPS_SECTION();

            /*" -1309- IF RCAP-N-CADASTRADO */

            if (WAREA_AUXILIAR.W_RCAPS["RCAP_N_CADASTRADO"])
            {

                /*" -1310- MOVE TERMOADE-COD-AGENCIA-OP TO RCAPS-AGE-COBRANCA */
                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_OP, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);

                /*" -1311- MOVE TERMOADE-DATA-INCLUSAO TO RCAPS-DATA-MOVIMENTO */
                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_INCLUSAO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);

                /*" -1313- MOVE TERMOADE-NUM-TERMO TO RCAPS-NUM-TITULO */
                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);

                /*" -1314- IF VIND-VAL-RCAP >= ZEROS */

                if (VIND_VAL_RCAP >= 00)
                {

                    /*" -1315- MOVE TERMOADE-VAL-RCAP TO RCAPS-VAL-RCAP */
                    _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);

                    /*" -1316- GO TO R0150-10-SEGUE */

                    R0150_10_SEGUE(); //GOTO
                    return;

                    /*" -1317- ELSE */
                }
                else
                {


                    /*" -1318- MOVE ZEROS TO RCAPS-VAL-RCAP */
                    _.Move(0, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);

                    /*" -1320- GO TO R0150-10-SEGUE. */

                    R0150_10_SEGUE(); //GOTO
                    return;
                }

            }


            /*" -1322- PERFORM R0205-00-LER-RCAPCOMP. */

            R0205_00_LER_RCAPCOMP_SECTION();

            /*" -1323- IF RCAPCOMP-N-CADASTRADO */

            if (WAREA_AUXILIAR.W_RCAPCOMP["RCAPCOMP_N_CADASTRADO"])
            {

                /*" -1325- ADD 1 TO W-DESPREZADO-04 */
                WAREA_AUXILIAR.W_DESPREZADO_04.Value = WAREA_AUXILIAR.W_DESPREZADO_04 + 1;

                /*" -1327- DISPLAY 'PF0642B - RCAPCOMP NAO CADASTRADO NUM.TERMO => ' TERMOADE-NUM-TERMO '  ' VGCOMTRO-NUM-PROPOSTA-SIVPF */

                $"PF0642B - RCAPCOMP NAO CADASTRADO NUM.TERMO => {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF}"
                .Display();

                /*" -1327- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R0150_10_SEGUE */

            R0150_10_SEGUE();

        }

        [StopWatch]
        /*" R0150-10-SEGUE */
        private void R0150_10_SEGUE(bool isPerform = false)
        {
            /*" -1333- PERFORM R0300-00-LER-CLIENTE */

            R0300_00_LER_CLIENTE_SECTION();

            /*" -1334- IF CLIENTE-NAO-CADASTRADO */

            if (WAREA_AUXILIAR.W_CLIENTE["CLIENTE_NAO_CADASTRADO"])
            {

                /*" -1336- ADD 1 TO W-DESPREZADO-05 */
                WAREA_AUXILIAR.W_DESPREZADO_05.Value = WAREA_AUXILIAR.W_DESPREZADO_05 + 1;

                /*" -1338- DISPLAY 'PF0642B - CLIENTE NAO CADASTRADO ==> ' TERMOADE-COD-CLIENTE */
                _.Display($"PF0642B - CLIENTE NAO CADASTRADO ==> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}");

                /*" -1344- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1345- IF CLIENTES-CGCCPF EQUAL ZEROS */

            if (CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF == 00)
            {

                /*" -1347- ADD 1 TO W-DESPREZADO-06 */
                WAREA_AUXILIAR.W_DESPREZADO_06.Value = WAREA_AUXILIAR.W_DESPREZADO_06 + 1;

                /*" -1350- DISPLAY 'PF0642B - CLIENTE COM CGC ZERADO ==> ' TERMOADE-NUM-TERMO '   ' TERMOADE-COD-CLIENTE */

                $"PF0642B - CLIENTE COM CGC ZERADO ==> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}"
                .Display();

                /*" -1352- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1353- PERFORM R0350-00-DECLER-ENDERECO. */

            R0350_00_DECLER_ENDERECO_SECTION();

            /*" -1355- PERFORM R0370-00-LER-ENDERECO. */

            R0370_00_LER_ENDERECO_SECTION();

            /*" -1356- IF ENDERECO-NAO-CADASTRADO */

            if (WAREA_AUXILIAR.W_ENDERECO["ENDERECO_NAO_CADASTRADO"])
            {

                /*" -1358- ADD 1 TO W-DESPREZADO-07 */
                WAREA_AUXILIAR.W_DESPREZADO_07.Value = WAREA_AUXILIAR.W_DESPREZADO_07 + 1;

                /*" -1362- DISPLAY 'PF0642B - ENDERECO NAO CADASTRADO ==> ' PROPOFID-NUM-PROPOSTA-SIVPF '  ' TERMOADE-NUM-TERMO '  ' TERMOADE-COD-CLIENTE */

                $"PF0642B - ENDERECO NAO CADASTRADO ==> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}  {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}"
                .Display();

                /*" -1364- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1366- PERFORM R0400-00-LER-SUBGRUPO. */

            R0400_00_LER_SUBGRUPO_SECTION();

            /*" -1367- IF SUBGRUPO-NAO-CADASTRADO */

            if (WAREA_AUXILIAR.W_SUBGRUPO["SUBGRUPO_NAO_CADASTRADO"])
            {

                /*" -1369- ADD 1 TO W-DESPREZADO-08 */
                WAREA_AUXILIAR.W_DESPREZADO_08.Value = WAREA_AUXILIAR.W_DESPREZADO_08 + 1;

                /*" -1373- DISPLAY 'PF0642B - SUBGRUPO NAO CADASTRADO ==> ' TERMOADE-NUM-TERMO '   ' TERMOADE-NUM-APOLICE '   ' TERMOADE-COD-SUBGRUPO */

                $"PF0642B - SUBGRUPO NAO CADASTRADO ==> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO}"
                .Display();

                /*" -1375- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1377- PERFORM R0450-00-OBTER-COBERTURA. */

            R0450_00_OBTER_COBERTURA_SECTION();

            /*" -1378- IF COBERTURA-NAO-CADASTRADA */

            if (WAREA_AUXILIAR.W_COBERTURAS["COBERTURA_NAO_CADASTRADA"])
            {

                /*" -1380- ADD 1 TO W-DESPREZADO-09 */
                WAREA_AUXILIAR.W_DESPREZADO_09.Value = WAREA_AUXILIAR.W_DESPREZADO_09 + 1;

                /*" -1385- DISPLAY 'PF0642B - COBERTURA NAO CADASTRADA ==> ' TERMOADE-NUM-TERMO '   ' TERMOADE-NUM-APOLICE '   ' TERMOADE-COD-SUBGRUPO */

                $"PF0642B - COBERTURA NAO CADASTRADA ==> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO}"
                .Display();

                /*" -1387- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1389- PERFORM R0470-00-LER-PROPOSTA */

            R0470_00_LER_PROPOSTA_SECTION();

            /*" -1390- IF PROPOSTAVA-NAO-CADASTRADA */

            if (WAREA_AUXILIAR.W_PROPOSTAVA["PROPOSTAVA_NAO_CADASTRADA"])
            {

                /*" -1392- ADD 1 TO W-DESPREZADO-10 */
                WAREA_AUXILIAR.W_DESPREZADO_10.Value = WAREA_AUXILIAR.W_DESPREZADO_10 + 1;

                /*" -1395- DISPLAY 'PF0642B - PROPOSTAVA NAO CADASTRADA ==> ' PROPOVA-NUM-CERTIFICADO '   ' TERMOADE-NUM-TERMO */

                $"PF0642B - PROPOSTAVA NAO CADASTRADA ==> {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}"
                .Display();

                /*" -1397- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1399- PERFORM R0500-00-OBTER-OPCAOPAG. */

            R0500_00_OBTER_OPCAOPAG_SECTION();

            /*" -1400- IF OPCAO-PAG-NAO-CADASTRADA */

            if (WAREA_AUXILIAR.W_OPCAOPAG["OPCAO_PAG_NAO_CADASTRADA"])
            {

                /*" -1402- ADD 1 TO W-DESPREZADO-11 */
                WAREA_AUXILIAR.W_DESPREZADO_11.Value = WAREA_AUXILIAR.W_DESPREZADO_11 + 1;

                /*" -1405- DISPLAY 'PF0642B - OPCAOPAG NAO CADASTRADA ==> ' TERMOADE-NUM-TERMO '   /    ' PROPOVA-NUM-CERTIFICADO */

                $"PF0642B - OPCAOPAG NAO CADASTRADA ==> {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}   /    {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}"
                .Display();

                /*" -1407- GO TO R0150-LEITURA. */

                R0150_LEITURA(); //GOTO
                return;
            }


            /*" -1408- PERFORM R0570-00-LER-COMISSAO */

            R0570_00_LER_COMISSAO_SECTION();

            /*" -1409- PERFORM R0580-00-OBTER-VAL-TARIFA */

            R0580_00_OBTER_VAL_TARIFA_SECTION();

            /*" -1411- PERFORM R0600-00-PROPOSTA-REGISTRO-TP1 */

            R0600_00_PROPOSTA_REGISTRO_TP1_SECTION();

            /*" -1414- PERFORM R0650-00-PROPOSTA-REGISTRO-TP2 UNTIL WFIM-ENDERECOS EQUAL 'S' */

            while (!(WAREA_AUXILIAR.WFIM_ENDERECOS == "S"))
            {

                R0650_00_PROPOSTA_REGISTRO_TP2_SECTION();
            }

            /*" -1415- PERFORM R0680-00-PROPOSTA-REGISTRO-TP3 */

            R0680_00_PROPOSTA_REGISTRO_TP3_SECTION();

            /*" -1416- PERFORM R0700-00-PROPOSTA-REGISTRO-TP6 */

            R0700_00_PROPOSTA_REGISTRO_TP6_SECTION();

            /*" -1417- PERFORM R0800-00-STATUS-REGISTRO-TP1 */

            R0800_00_STATUS_REGISTRO_TP1_SECTION();

            /*" -1418- PERFORM R0850-00-STATUS-REGISTRO-TP2 */

            R0850_00_STATUS_REGISTRO_TP2_SECTION();

            /*" -1419- PERFORM R0900-00-STATUS-REGISTRO-TP3 */

            R0900_00_STATUS_REGISTRO_TP3_SECTION();

            /*" -1420- PERFORM R0950-00-STATUS-REGISTRO-TP4 */

            R0950_00_STATUS_REGISTRO_TP4_SECTION();

            /*" -1421- PERFORM R0970-00-STATUS-REGISTRO-TP5. */

            R0970_00_STATUS_REGISTRO_TP5_SECTION();

            /*" -1421- PERFORM R3000-GERAR-TB-CORPORATIVAS. */

            R3000_GERAR_TB_CORPORATIVAS_SECTION();

        }

        [StopWatch]
        /*" R0150-LEITURA */
        private void R0150_LEITURA(bool isPerform = false)
        {
            /*" -1430- IF W-FIM-MOVTO-TERMO NOT EQUAL 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO != "FIM")
            {

                /*" -1430- PERFORM R0070-00-LER-MOVTO. */

                R0070_00_LER_MOVTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0150_SAIDA*/

        [StopWatch]
        /*" R0200-00-LER-RCAPS-SECTION */
        private void R0200_00_LER_RCAPS_SECTION()
        {
            /*" -1440- MOVE 'R0200-00-LER-RCAPS' TO PARAGRAFO. */
            _.Move("R0200-00-LER-RCAPS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1442- MOVE 'SELECT TABELA RCAPS' TO COMANDO. */
            _.Move("SELECT TABELA RCAPS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1445- MOVE VGCOMTRO-NUM-PROPOSTA-SIVPF TO RCAPS-NUM-CERTIFICADO */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF, RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO);

            /*" -1473- PERFORM R0200_00_LER_RCAPS_DB_SELECT_1 */

            R0200_00_LER_RCAPS_DB_SELECT_1();

            /*" -1476- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1477- MOVE 1 TO W-RCAPS */
                _.Move(1, WAREA_AUXILIAR.W_RCAPS);

                /*" -1478- ELSE */
            }
            else
            {


                /*" -1479- IF SQLCODE EQUAL 100 OR -811 */

                if (DB.SQLCODE.In("100", "-811"))
                {

                    /*" -1480- MOVE 2 TO W-RCAPS */
                    _.Move(2, WAREA_AUXILIAR.W_RCAPS);

                    /*" -1481- ELSE */
                }
                else
                {


                    /*" -1482- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -1483- DISPLAY '          ERRO SELECT TABELA RCAPS' */
                    _.Display($"          ERRO SELECT TABELA RCAPS");

                    /*" -1485- DISPLAY '          NUMERO CERTIFICDO...... ' RCAPS-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICDO...... {RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO}");

                    /*" -1487- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1488- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1488- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0200-00-LER-RCAPS-DB-SELECT-1 */
        public void R0200_00_LER_RCAPS_DB_SELECT_1()
        {
            /*" -1473- EXEC SQL SELECT COD_FONTE , NUM_PROPOSTA , VAL_RCAP , VAL_RCAP_PRINCIPAL , DATA_CADASTRAMENTO , DATA_MOVIMENTO , SIT_REGISTRO , COD_OPERACAO , NUM_TITULO , AGE_COBRANCA , NUM_RCAP INTO :RCAPS-COD-FONTE , :RCAPS-NUM-PROPOSTA , :RCAPS-VAL-RCAP , :RCAPS-VAL-RCAP-PRINCIPAL, :RCAPS-DATA-CADASTRAMENTO, :RCAPS-DATA-MOVIMENTO , :RCAPS-SIT-REGISTRO , :RCAPS-COD-OPERACAO , :RCAPS-NUM-TITULO , :RCAPS-AGE-COBRANCA , :RCAPS-NUM-RCAP FROM SEGUROS.RCAPS WHERE NUM_CERTIFICADO = :RCAPS-NUM-CERTIFICADO WITH UR END-EXEC. */

            var r0200_00_LER_RCAPS_DB_SELECT_1_Query1 = new R0200_00_LER_RCAPS_DB_SELECT_1_Query1()
            {
                RCAPS_NUM_CERTIFICADO = RCAPS.DCLRCAPS.RCAPS_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R0200_00_LER_RCAPS_DB_SELECT_1_Query1.Execute(r0200_00_LER_RCAPS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPS_COD_FONTE, RCAPS.DCLRCAPS.RCAPS_COD_FONTE);
                _.Move(executed_1.RCAPS_NUM_PROPOSTA, RCAPS.DCLRCAPS.RCAPS_NUM_PROPOSTA);
                _.Move(executed_1.RCAPS_VAL_RCAP, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP);
                _.Move(executed_1.RCAPS_VAL_RCAP_PRINCIPAL, RCAPS.DCLRCAPS.RCAPS_VAL_RCAP_PRINCIPAL);
                _.Move(executed_1.RCAPS_DATA_CADASTRAMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO);
                _.Move(executed_1.RCAPS_DATA_MOVIMENTO, RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPS_SIT_REGISTRO, RCAPS.DCLRCAPS.RCAPS_SIT_REGISTRO);
                _.Move(executed_1.RCAPS_COD_OPERACAO, RCAPS.DCLRCAPS.RCAPS_COD_OPERACAO);
                _.Move(executed_1.RCAPS_NUM_TITULO, RCAPS.DCLRCAPS.RCAPS_NUM_TITULO);
                _.Move(executed_1.RCAPS_AGE_COBRANCA, RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA);
                _.Move(executed_1.RCAPS_NUM_RCAP, RCAPS.DCLRCAPS.RCAPS_NUM_RCAP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_SAIDA*/

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-SECTION */
        private void R0205_00_LER_RCAPCOMP_SECTION()
        {
            /*" -1498- MOVE 'R0205-00-LER-RCAPCOMP' TO PARAGRAFO. */
            _.Move("R0205-00-LER-RCAPCOMP", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1500- MOVE 'SELECT TABELA RCAPS-COMP' TO COMANDO. */
            _.Move("SELECT TABELA RCAPS-COMP", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1502- MOVE 2 TO W-RCAPCOMP. */
            _.Move(2, WAREA_AUXILIAR.W_RCAPCOMP);

            /*" -1519- PERFORM R0205_00_LER_RCAPCOMP_DB_SELECT_1 */

            R0205_00_LER_RCAPCOMP_DB_SELECT_1();

            /*" -1522- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1523- MOVE 1 TO W-RCAPCOMP */
                _.Move(1, WAREA_AUXILIAR.W_RCAPCOMP);

                /*" -1524- ELSE */
            }
            else
            {


                /*" -1525- IF SQLCODE NOT EQUAL 100 AND -811 */

                if (!DB.SQLCODE.In("100", "-811"))
                {

                    /*" -1526- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -1527- DISPLAY '          ERRO SELECT TABELA RCAPSCOMP' */
                    _.Display($"          ERRO SELECT TABELA RCAPSCOMP");

                    /*" -1529- DISPLAY '          NUMERO DO TERMO........ ' TERMOADE-NUM-TERMO */
                    _.Display($"          NUMERO DO TERMO........ {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -1531- DISPLAY '          NUMERO DO RCAPS........ ' RCAPS-NUM-RCAP */
                    _.Display($"          NUMERO DO RCAPS........ {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                    /*" -1533- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1534- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1535- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1536- ELSE */
                }
                else
                {


                    /*" -1552- PERFORM R0205_00_LER_RCAPCOMP_DB_DECLARE_1 */

                    R0205_00_LER_RCAPCOMP_DB_DECLARE_1();

                    /*" -1554- PERFORM R0205_00_LER_RCAPCOMP_DB_OPEN_1 */

                    R0205_00_LER_RCAPCOMP_DB_OPEN_1();

                    /*" -1557- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1558- DISPLAY 'PF0642B - FIM ANORMAL' */
                        _.Display($"PF0642B - FIM ANORMAL");

                        /*" -1559- DISPLAY '          ERRO NO OPEN DO CURSOR RCAPCOMP' */
                        _.Display($"          ERRO NO OPEN DO CURSOR RCAPCOMP");

                        /*" -1561- DISPLAY '          NUMERO DO TERMO........ ' TERMOADE-NUM-TERMO */
                        _.Display($"          NUMERO DO TERMO........ {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                        /*" -1563- DISPLAY '          NUMERO DO RCAPS........ ' RCAPS-NUM-RCAP */
                        _.Display($"          NUMERO DO RCAPS........ {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -1565- DISPLAY '          SQLCODE.................... ' SQLCODE */
                        _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                        /*" -1566- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1567- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -1569- END-IF */
                    }


                    /*" -1580- PERFORM R0205_00_LER_RCAPCOMP_DB_FETCH_1 */

                    R0205_00_LER_RCAPCOMP_DB_FETCH_1();

                    /*" -1583- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1584- DISPLAY 'PF0642B - FIM ANORMAL' */
                        _.Display($"PF0642B - FIM ANORMAL");

                        /*" -1585- DISPLAY '          ERRO NO FETCH DO CURSOR RCAPCOMP' */
                        _.Display($"          ERRO NO FETCH DO CURSOR RCAPCOMP");

                        /*" -1587- DISPLAY '          NUMERO DO TERMO........ ' TERMOADE-NUM-TERMO */
                        _.Display($"          NUMERO DO TERMO........ {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                        /*" -1589- DISPLAY '          NUMERO DO RCAPS........ ' RCAPS-NUM-RCAP */
                        _.Display($"          NUMERO DO RCAPS........ {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -1591- DISPLAY '          SQLCODE.................... ' SQLCODE */
                        _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                        /*" -1592- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1593- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -1594- ELSE */
                    }
                    else
                    {


                        /*" -1595- MOVE 1 TO W-RCAPCOMP */
                        _.Move(1, WAREA_AUXILIAR.W_RCAPCOMP);

                        /*" -1597- END-IF */
                    }


                    /*" -1597- PERFORM R0205_00_LER_RCAPCOMP_DB_CLOSE_1 */

                    R0205_00_LER_RCAPCOMP_DB_CLOSE_1();

                    /*" -1600- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1601- DISPLAY 'PF0642B - FIM ANORMAL' */
                        _.Display($"PF0642B - FIM ANORMAL");

                        /*" -1602- DISPLAY '          ERRO NO CLOSE DO CURSOR RCAPCOMP' */
                        _.Display($"          ERRO NO CLOSE DO CURSOR RCAPCOMP");

                        /*" -1604- DISPLAY '          NUMERO DO TERMO........ ' TERMOADE-NUM-TERMO */
                        _.Display($"          NUMERO DO TERMO........ {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                        /*" -1606- DISPLAY '          NUMERO DO RCAPS........ ' RCAPS-NUM-RCAP */
                        _.Display($"          NUMERO DO RCAPS........ {RCAPS.DCLRCAPS.RCAPS_NUM_RCAP}");

                        /*" -1608- DISPLAY '          SQLCODE.................... ' SQLCODE */
                        _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                        /*" -1609- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -1609- PERFORM R9999-00-FINALIZAR. */

                        R9999_00_FINALIZAR_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-SELECT-1 */
        public void R0205_00_LER_RCAPCOMP_DB_SELECT_1()
        {
            /*" -1519- EXEC SQL SELECT BCO_AVISO, AGE_AVISO, NUM_AVISO_CREDITO, DATA_MOVIMENTO, DATA_RCAP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP FROM SEGUROS.RCAP_COMPLEMENTAR WHERE COD_FONTE = :DCLRCAPS.RCAPS-COD-FONTE AND NUM_RCAP = :DCLRCAPS.RCAPS-NUM-RCAP AND NUM_RCAP_COMPLEMEN = 0 AND COD_OPERACAO BETWEEN 100 AND 199 WITH UR END-EXEC. */

            var r0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1 = new R0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1()
            {
                RCAPS_COD_FONTE = RCAPS.DCLRCAPS.RCAPS_COD_FONTE.ToString(),
                RCAPS_NUM_RCAP = RCAPS.DCLRCAPS.RCAPS_NUM_RCAP.ToString(),
            };

            var executed_1 = R0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1.Execute(r0205_00_LER_RCAPCOMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(executed_1.RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(executed_1.RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(executed_1.RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(executed_1.RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
            }


        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-OPEN-1 */
        public void R0205_00_LER_RCAPCOMP_DB_OPEN_1()
        {
            /*" -1554- EXEC SQL OPEN C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Open();

        }

        [StopWatch]
        /*" R0350-00-DECLER-ENDERECO-DB-DECLARE-1 */
        public void R0350_00_DECLER_ENDERECO_DB_DECLARE_1()
        {
            /*" -1743- EXEC SQL DECLARE C01_ENDERECO CURSOR FOR SELECT COD_CLIENTE , COD_ENDERECO , OCORR_ENDERECO , ENDERECO , BAIRRO , CIDADE , SIGLA_UF , CEP , DDD , TELEFONE , FAX , TELEX , SIT_REGISTRO FROM SEGUROS.ENDERECOS WHERE COD_CLIENTE = :DCLENDERECOS.ENDERECO-COD-CLIENTE AND SIT_REGISTRO = '0' ORDER BY COD_ENDERECO WITH UR END-EXEC. */
            C01_ENDERECO = new PF0642B_C01_ENDERECO(true);
            string GetQuery_C01_ENDERECO()
            {
                var query = @$"SELECT 
							COD_CLIENTE
							, 
							COD_ENDERECO
							, 
							OCORR_ENDERECO
							, 
							ENDERECO
							, 
							BAIRRO
							, 
							CIDADE
							, 
							SIGLA_UF
							, 
							CEP
							, 
							DDD
							, 
							TELEFONE
							, 
							FAX
							, 
							TELEX
							, 
							SIT_REGISTRO 
							FROM SEGUROS.ENDERECOS 
							WHERE COD_CLIENTE = 
							'{ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}' 
							AND SIT_REGISTRO = '0' 
							ORDER BY COD_ENDERECO";

                return query;
            }
            C01_ENDERECO.GetQueryEvent += GetQuery_C01_ENDERECO;

        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-FETCH-1 */
        public void R0205_00_LER_RCAPCOMP_DB_FETCH_1()
        {
            /*" -1580- EXEC SQL FETCH C01_RCAPCOMP INTO :DCLRCAP-COMPLEMENTAR.RCAPCOMP-BCO-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-AGE-AVISO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-NUM-AVISO-CREDITO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-MOVIMENTO, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-DATA-RCAP, :DCLRCAP-COMPLEMENTAR.RCAPCOMP-COD-OPERACAO END-EXEC */

            if (C01_RCAPCOMP.Fetch())
            {
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_BCO_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_BCO_AVISO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_AGE_AVISO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_AGE_AVISO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_NUM_AVISO_CREDITO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_NUM_AVISO_CREDITO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_MOVIMENTO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_DATA_RCAP, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP);
                _.Move(C01_RCAPCOMP.DCLRCAP_COMPLEMENTAR_RCAPCOMP_COD_OPERACAO, RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_COD_OPERACAO);
            }

        }

        [StopWatch]
        /*" R0205-00-LER-RCAPCOMP-DB-CLOSE-1 */
        public void R0205_00_LER_RCAPCOMP_DB_CLOSE_1()
        {
            /*" -1597- EXEC SQL CLOSE C01_RCAPCOMP END-EXEC */

            C01_RCAPCOMP.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0205_SAIDA*/

        [StopWatch]
        /*" R0210-00-LER-PRP-FIDELIZ-SECTION */
        private void R0210_00_LER_PRP_FIDELIZ_SECTION()
        {
            /*" -1619- MOVE 'R0210-00-LER-PRP-FIDELIZ' TO PARAGRAFO. */
            _.Move("R0210-00-LER-PRP-FIDELIZ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1621- MOVE 'SELECT PROPOSTA-FIDELIZ' TO COMANDO. */
            _.Move("SELECT PROPOSTA-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1624- MOVE VGCOMTRO-NUM-PROPOSTA-SIVPF TO PROPOFID-NUM-PROPOSTA-SIVPF. */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);

            /*" -1632- PERFORM R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1 */

            R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1();

            /*" -1635- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1636- MOVE 1 TO W-FIDELIZ */
                _.Move(1, WAREA_AUXILIAR.W_FIDELIZ);

                /*" -1637- ELSE */
            }
            else
            {


                /*" -1638- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1639- MOVE 2 TO W-FIDELIZ */
                    _.Move(2, WAREA_AUXILIAR.W_FIDELIZ);

                    /*" -1640- ELSE */
                }
                else
                {


                    /*" -1641- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -1642- DISPLAY '          ERRO SELECT PROPOSTA-FIDELIZ' */
                    _.Display($"          ERRO SELECT PROPOSTA-FIDELIZ");

                    /*" -1644- DISPLAY '          NUMERO PROPOSTA............ ' PROPOFID-NUM-PROPOSTA-SIVPF */
                    _.Display($"          NUMERO PROPOSTA............ {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                    /*" -1646- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1647- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1647- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0210-00-LER-PRP-FIDELIZ-DB-SELECT-1 */
        public void R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1()
        {
            /*" -1632- EXEC SQL SELECT SIT_PROPOSTA, NUM_PROPOSTA_SIVPF INTO :PROPOFID-SIT-PROPOSTA, :PROPOFID-NUM-PROPOSTA-SIVPF FROM SEGUROS.PROPOSTA_FIDELIZ WHERE NUM_PROPOSTA_SIVPF = :PROPOFID-NUM-PROPOSTA-SIVPF WITH UR END-EXEC. */

            var r0210_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1 = new R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1()
            {
                PROPOFID_NUM_PROPOSTA_SIVPF = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF.ToString(),
            };

            var executed_1 = R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1.Execute(r0210_00_LER_PRP_FIDELIZ_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOFID_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);
                _.Move(executed_1.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-SECTION */
        private void R0300_00_LER_CLIENTE_SECTION()
        {
            /*" -1657- MOVE 'R0300-00-LER-CLIENTES' TO PARAGRAFO. */
            _.Move("R0300-00-LER-CLIENTES", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1659- MOVE 'SELECT CLIENTES' TO COMANDO. */
            _.Move("SELECT CLIENTES", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1662- MOVE TERMOADE-COD-CLIENTE TO CLIENTES-COD-CLIENTE. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -1688- PERFORM R0300_00_LER_CLIENTE_DB_SELECT_1 */

            R0300_00_LER_CLIENTE_DB_SELECT_1();

            /*" -1691- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1692- MOVE 1 TO W-CLIENTE */
                _.Move(1, WAREA_AUXILIAR.W_CLIENTE);

                /*" -1693- ELSE */
            }
            else
            {


                /*" -1694- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1695- MOVE 2 TO W-CLIENTE */
                    _.Move(2, WAREA_AUXILIAR.W_CLIENTE);

                    /*" -1696- ELSE */
                }
                else
                {


                    /*" -1697- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -1698- DISPLAY '          ERRO SELECT TABELA CLIENTES' */
                    _.Display($"          ERRO SELECT TABELA CLIENTES");

                    /*" -1700- DISPLAY '          NUMERO DO TERMO............ ' TERMOADE-NUM-TERMO */
                    _.Display($"          NUMERO DO TERMO............ {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -1702- DISPLAY '          CODIGO DO CLIENTE.......... ' TERMOADE-COD-CLIENTE */
                    _.Display($"          CODIGO DO CLIENTE.......... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE}");

                    /*" -1704- DISPLAY '          SQLCODE.................... ' SQLCODE */
                    _.Display($"          SQLCODE.................... {DB.SQLCODE}");

                    /*" -1705- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1705- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0300-00-LER-CLIENTE-DB-SELECT-1 */
        public void R0300_00_LER_CLIENTE_DB_SELECT_1()
        {
            /*" -1688- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , TIPO_PESSOA , CGCCPF , SIT_REGISTRO , DATA_NASCIMENTO , COD_PORTE_EMP , COD_NATUREZA_ATIV , COD_RAMO_ATIVIDADE , COD_ATIVIDADE INTO :CLIENTES-COD-CLIENTE , :CLIENTES-NOME-RAZAO , :CLIENTES-TIPO-PESSOA , :CLIENTES-CGCCPF , :CLIENTES-SIT-REGISTRO , :CLIENTES-DATA-NASCIMENTO:VIND-DTNASCI , :CLIENTES-COD-PORTE-EMP:VIND-CODPORTEMP , :CLIENTES-COD-NATUREZA-ATIV:VIND-NATATIV , :CLIENTES-COD-RAMO-ATIVIDADE:VIND-RAMATIV, :CLIENTES-COD-ATIVIDADE:VIND-CODATIV FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE WITH UR END-EXEC. */

            var r0300_00_LER_CLIENTE_DB_SELECT_1_Query1 = new R0300_00_LER_CLIENTE_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R0300_00_LER_CLIENTE_DB_SELECT_1_Query1.Execute(r0300_00_LER_CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_SIT_REGISTRO, CLIENTES.DCLCLIENTES.CLIENTES_SIT_REGISTRO);
                _.Move(executed_1.CLIENTES_DATA_NASCIMENTO, CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO);
                _.Move(executed_1.VIND_DTNASCI, VIND_DTNASCI);
                _.Move(executed_1.CLIENTES_COD_PORTE_EMP, CLIENTES.DCLCLIENTES.CLIENTES_COD_PORTE_EMP);
                _.Move(executed_1.VIND_CODPORTEMP, VIND_CODPORTEMP);
                _.Move(executed_1.CLIENTES_COD_NATUREZA_ATIV, CLIENTES.DCLCLIENTES.CLIENTES_COD_NATUREZA_ATIV);
                _.Move(executed_1.VIND_NATATIV, VIND_NATATIV);
                _.Move(executed_1.CLIENTES_COD_RAMO_ATIVIDADE, CLIENTES.DCLCLIENTES.CLIENTES_COD_RAMO_ATIVIDADE);
                _.Move(executed_1.VIND_RAMATIV, VIND_RAMATIV);
                _.Move(executed_1.CLIENTES_COD_ATIVIDADE, CLIENTES.DCLCLIENTES.CLIENTES_COD_ATIVIDADE);
                _.Move(executed_1.VIND_CODATIV, VIND_CODATIV);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_SAIDA*/

        [StopWatch]
        /*" R0350-00-DECLER-ENDERECO-SECTION */
        private void R0350_00_DECLER_ENDERECO_SECTION()
        {
            /*" -1715- MOVE 'R0350-00-DECLER-ENDERECO' TO PARAGRAFO. */
            _.Move("R0350-00-DECLER-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1717- MOVE 'DECLER ENDERECO ' TO COMANDO. */
            _.Move("DECLER ENDERECO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1720- MOVE TERMOADE-COD-CLIENTE TO ENDERECO-COD-CLIENTE OF DCLENDERECOS. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);

            /*" -1743- PERFORM R0350_00_DECLER_ENDERECO_DB_DECLARE_1 */

            R0350_00_DECLER_ENDERECO_DB_DECLARE_1();

            /*" -1746- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1747- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -1748- DISPLAY '          ERRO DECLARE CURSOR ENDERECO ' */
                _.Display($"          ERRO DECLARE CURSOR ENDERECO ");

                /*" -1751- DISPLAY '          NUMERO CERTIFICADO/TERMO.... ' PROPOFID-NUM-PROPOSTA-SIVPF '   ' TERMOADE-NUM-TERMO */

                $"          NUMERO CERTIFICADO/TERMO.... {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}"
                .Display();

                /*" -1753- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -1754- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1756- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -1758- MOVE 'OPEN C01_ENDERECO ' TO COMANDO. */
            _.Move("OPEN C01_ENDERECO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1758- PERFORM R0350_00_DECLER_ENDERECO_DB_OPEN_1 */

            R0350_00_DECLER_ENDERECO_DB_OPEN_1();

            /*" -1761- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -1762- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -1763- DISPLAY '          ERRO OPEN CURSOR ENDERECO ' */
                _.Display($"          ERRO OPEN CURSOR ENDERECO ");

                /*" -1766- DISPLAY '          NUMERO CERTIFICADO/TERMO. ' PROPOFID-NUM-PROPOSTA-SIVPF '   ' TERMOADE-NUM-TERMO */

                $"          NUMERO CERTIFICADO/TERMO. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}"
                .Display();

                /*" -1768- DISPLAY '          SQLCODE.................. ' SQLCODE */
                _.Display($"          SQLCODE.................. {DB.SQLCODE}");

                /*" -1769- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1769- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0350-00-DECLER-ENDERECO-DB-OPEN-1 */
        public void R0350_00_DECLER_ENDERECO_DB_OPEN_1()
        {
            /*" -1758- EXEC SQL OPEN C01_ENDERECO END-EXEC. */

            C01_ENDERECO.Open();

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-DECLARE-1 */
        public void R0450_00_OBTER_COBERTURA_DB_DECLARE_1()
        {
            /*" -2022- EXEC SQL DECLARE COBERTURAS CURSOR FOR SELECT NUM_CERTIFICADO , OCORR_HISTORICO , DATA_INIVIGENCIA , DATA_TERVIGENCIA , IMP_MORNATU , IMPMORACID , IMPINVPERM FROM SEGUROS.HIS_COBER_PROPOST WHERE (NUM_CERTIFICADO = :HISCOBPR-NUM-CERTIFICADO OR NUM_CERTIFICADO = :WHOST-NUM-TERMO) AND DATA_TERVIGENCIA = :HISCOBPR-DATA-TERVIGENCIA WITH UR END-EXEC. */
            COBERTURAS = new PF0642B_COBERTURAS(true);
            string GetQuery_COBERTURAS()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							OCORR_HISTORICO
							, 
							DATA_INIVIGENCIA
							, 
							DATA_TERVIGENCIA
							, 
							IMP_MORNATU
							, 
							IMPMORACID
							, 
							IMPINVPERM 
							FROM SEGUROS.HIS_COBER_PROPOST 
							WHERE (NUM_CERTIFICADO = '{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}' 
							OR NUM_CERTIFICADO = '{WHOST_NUM_TERMO}') 
							AND DATA_TERVIGENCIA = '{HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA}'";

                return query;
            }
            COBERTURAS.GetQueryEvent += GetQuery_COBERTURAS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_SAIDA*/

        [StopWatch]
        /*" R0370-00-LER-ENDERECO-SECTION */
        private void R0370_00_LER_ENDERECO_SECTION()
        {
            /*" -1779- MOVE 'R0370-00-LER-ENDERECO' TO PARAGRAFO. */
            _.Move("R0370-00-LER-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1781- MOVE 'FETCH C01_ENDERECO ' TO COMANDO. */
            _.Move("FETCH C01_ENDERECO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1797- PERFORM R0370_00_LER_ENDERECO_DB_FETCH_1 */

            R0370_00_LER_ENDERECO_DB_FETCH_1();

            /*" -1800- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1801- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1802- MOVE 'S' TO WFIM-ENDERECOS */
                    _.Move("S", WAREA_AUXILIAR.WFIM_ENDERECOS);

                    /*" -1802- PERFORM R0370_00_LER_ENDERECO_DB_CLOSE_1 */

                    R0370_00_LER_ENDERECO_DB_CLOSE_1();

                    /*" -1804- MOVE 2 TO W-ENDERECO */
                    _.Move(2, WAREA_AUXILIAR.W_ENDERECO);

                    /*" -1805- ELSE */
                }
                else
                {


                    /*" -1806- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -1807- DISPLAY '          ERRO FETCH CURSOR ENDERECO' */
                    _.Display($"          ERRO FETCH CURSOR ENDERECO");

                    /*" -1811- DISPLAY '          PROPOSTA/TERMO/COD.CLIENTE.. ' PROPOFID-NUM-PROPOSTA-SIVPF '   ' TERMOADE-NUM-TERMO '   ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */

                    $"          PROPOSTA/TERMO/COD.CLIENTE.. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}   {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}"
                    .Display();

                    /*" -1813- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -1814- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1815- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -1816- ELSE */
                }

            }
            else
            {


                /*" -1816- MOVE 1 TO W-ENDERECO. */
                _.Move(1, WAREA_AUXILIAR.W_ENDERECO);
            }


        }

        [StopWatch]
        /*" R0370-00-LER-ENDERECO-DB-FETCH-1 */
        public void R0370_00_LER_ENDERECO_DB_FETCH_1()
        {
            /*" -1797- EXEC SQL FETCH C01_ENDERECO INTO :DCLENDERECOS.ENDERECO-COD-CLIENTE , :DCLENDERECOS.ENDERECO-COD-ENDERECO , :DCLENDERECOS.ENDERECO-OCORR-ENDERECO , :DCLENDERECOS.ENDERECO-ENDERECO , :DCLENDERECOS.ENDERECO-BAIRRO , :DCLENDERECOS.ENDERECO-CIDADE , :DCLENDERECOS.ENDERECO-SIGLA-UF , :DCLENDERECOS.ENDERECO-CEP , :DCLENDERECOS.ENDERECO-DDD , :DCLENDERECOS.ENDERECO-TELEFONE , :DCLENDERECOS.ENDERECO-FAX , :DCLENDERECOS.ENDERECO-TELEX , :DCLENDERECOS.ENDERECO-SIT-REGISTRO END-EXEC. */

            if (C01_ENDERECO.Fetch())
            {
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_COD_CLIENTE, ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_COD_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_FAX, ENDERECO.DCLENDERECOS.ENDERECO_FAX);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_TELEX, ENDERECO.DCLENDERECOS.ENDERECO_TELEX);
                _.Move(C01_ENDERECO.DCLENDERECOS_ENDERECO_SIT_REGISTRO, ENDERECO.DCLENDERECOS.ENDERECO_SIT_REGISTRO);
            }

        }

        [StopWatch]
        /*" R0370-00-LER-ENDERECO-DB-CLOSE-1 */
        public void R0370_00_LER_ENDERECO_DB_CLOSE_1()
        {
            /*" -1802- EXEC SQL CLOSE C01_ENDERECO END-EXEC */

            C01_ENDERECO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0370_SAIDA*/

        [StopWatch]
        /*" R0460-CLOSE-ENDERECO-SECTION */
        private void R0460_CLOSE_ENDERECO_SECTION()
        {
            /*" -1826- MOVE 'R0460-CLOSE-ENDERECO' TO PARAGRAFO. */
            _.Move("R0460-CLOSE-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1828- MOVE 'CLOSE C01_ENDERECO ' TO COMANDO. */
            _.Move("CLOSE C01_ENDERECO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1830- MOVE 'S' TO WFIM-ENDERECOS */
            _.Move("S", WAREA_AUXILIAR.WFIM_ENDERECOS);

            /*" -1830- PERFORM R0460_CLOSE_ENDERECO_DB_CLOSE_1 */

            R0460_CLOSE_ENDERECO_DB_CLOSE_1();

            /*" -1834- MOVE 2 TO W-ENDERECO. */
            _.Move(2, WAREA_AUXILIAR.W_ENDERECO);

            /*" -1836- IF SQLCODE NOT EQUAL ZEROS AND SQLCODE NOT EQUAL -501 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != -501)
            {

                /*" -1837- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -1838- DISPLAY '          ERRO CLOSE ENDERECO' */
                _.Display($"          ERRO CLOSE ENDERECO");

                /*" -1842- DISPLAY '          PROPOSTA/TERMO/COD.CLIENTE.. ' PROPOFID-NUM-PROPOSTA-SIVPF '   ' TERMOADE-NUM-TERMO '   ' ENDERECO-COD-CLIENTE OF DCLENDERECOS */

                $"          PROPOSTA/TERMO/COD.CLIENTE.. {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}   {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}   {ENDERECO.DCLENDERECOS.ENDERECO_COD_CLIENTE}"
                .Display();

                /*" -1844- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -1845- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -1845- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0460-CLOSE-ENDERECO-DB-CLOSE-1 */
        public void R0460_CLOSE_ENDERECO_DB_CLOSE_1()
        {
            /*" -1830- EXEC SQL CLOSE C01_ENDERECO END-EXEC. */

            C01_ENDERECO.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0460_SAIDA*/

        [StopWatch]
        /*" R0400-00-LER-SUBGRUPO-SECTION */
        private void R0400_00_LER_SUBGRUPO_SECTION()
        {
            /*" -1855- MOVE 'R0400-00-LER-SUBGRUPO' TO PARAGRAFO. */
            _.Move("R0400-00-LER-SUBGRUPO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1857- MOVE 'SELECT SUBGRUPO ' TO COMANDO. */
            _.Move("SELECT SUBGRUPO ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1858- MOVE TERMOADE-NUM-APOLICE TO SUBGVGAP-NUM-APOLICE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE);

            /*" -1860- MOVE TERMOADE-COD-SUBGRUPO TO SUBGVGAP-COD-SUBGRUPO. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);

            /*" -1921- PERFORM R0400_00_LER_SUBGRUPO_DB_SELECT_1 */

            R0400_00_LER_SUBGRUPO_DB_SELECT_1();

            /*" -1924- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1925- MOVE 1 TO W-SUBGRUPO */
                _.Move(1, WAREA_AUXILIAR.W_SUBGRUPO);

                /*" -1926- ELSE */
            }
            else
            {


                /*" -1927- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1928- MOVE 2 TO W-SUBGRUPO */
                    _.Move(2, WAREA_AUXILIAR.W_SUBGRUPO);

                    /*" -1929- ELSE */
                }
                else
                {


                    /*" -1930- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -1931- DISPLAY '          ERRO SELECT TABELA SUBGRUPOS' */
                    _.Display($"          ERRO SELECT TABELA SUBGRUPOS");

                    /*" -1933- DISPLAY '          CODIGO SUBGRUPO............. ' SUBGVGAP-COD-SUBGRUPO */
                    _.Display($"          CODIGO SUBGRUPO............. {SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO}");

                    /*" -1935- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                    _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -1937- DISPLAY '          SQLCODE..................... ' SQLCODE */
                    _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                    /*" -1938- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1938- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0400-00-LER-SUBGRUPO-DB-SELECT-1 */
        public void R0400_00_LER_SUBGRUPO_DB_SELECT_1()
        {
            /*" -1921- EXEC SQL SELECT COD_SUBGRUPO , COD_CLIENTE , CLASSE_APOLICE , COD_FONTE , TIPO_FATURAMENTO , FORMA_FATURAMENTO , FORMA_AVERBACAO , TIPO_PLANO , PERI_FATURAMENTO , PERI_RENOVACAO , PERI_RETROATI_INC , PERI_RETROATI_CAN , OCORR_ENDERECO , OCORR_END_COBRAN , BCO_COBRANCA , AGE_COBRANCA , DAC_COBRANCA , TIPO_COBRANCA , COD_PAG_ANGARIACAO , PCT_CONJUGE_VG , PCT_CONJUGE_AP , OPCAO_COBERTURA , OPCAO_CORRETAGEM , IND_CONSISTE_MATRI , IND_PLANO_ASSOCIA , SIT_REGISTRO , OPCAO_CONJUGE INTO :SUBGVGAP-COD-SUBGRUPO , :SUBGVGAP-COD-CLIENTE , :SUBGVGAP-CLASSE-APOLICE , :SUBGVGAP-COD-FONTE , :SUBGVGAP-TIPO-FATURAMENTO , :SUBGVGAP-FORMA-FATURAMENTO , :SUBGVGAP-FORMA-AVERBACAO , :SUBGVGAP-TIPO-PLANO , :SUBGVGAP-PERI-FATURAMENTO , :SUBGVGAP-PERI-RENOVACAO , :SUBGVGAP-PERI-RETROATI-INC , :SUBGVGAP-PERI-RETROATI-CAN , :SUBGVGAP-OCORR-ENDERECO , :SUBGVGAP-OCORR-END-COBRAN , :SUBGVGAP-BCO-COBRANCA , :SUBGVGAP-AGE-COBRANCA , :SUBGVGAP-DAC-COBRANCA , :SUBGVGAP-TIPO-COBRANCA , :SUBGVGAP-COD-PAG-ANGARIACAO , :SUBGVGAP-PCT-CONJUGE-VG , :SUBGVGAP-PCT-CONJUGE-AP , :SUBGVGAP-OPCAO-COBERTURA , :SUBGVGAP-OPCAO-CORRETAGEM , :SUBGVGAP-IND-CONSISTE-MATRI , :SUBGVGAP-IND-PLANO-ASSOCIA , :SUBGVGAP-SIT-REGISTRO , :SUBGVGAP-OPCAO-CONJUGE FROM SEGUROS.SUBGRUPOS_VGAP WHERE NUM_APOLICE = :SUBGVGAP-NUM-APOLICE AND COD_SUBGRUPO = :SUBGVGAP-COD-SUBGRUPO WITH UR END-EXEC. */

            var r0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1 = new R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1()
            {
                SUBGVGAP_COD_SUBGRUPO = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.ToString(),
                SUBGVGAP_NUM_APOLICE = SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1.Execute(r0400_00_LER_SUBGRUPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGVGAP_COD_SUBGRUPO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO);
                _.Move(executed_1.SUBGVGAP_COD_CLIENTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_CLIENTE);
                _.Move(executed_1.SUBGVGAP_CLASSE_APOLICE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_CLASSE_APOLICE);
                _.Move(executed_1.SUBGVGAP_COD_FONTE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_FONTE);
                _.Move(executed_1.SUBGVGAP_TIPO_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_FORMA_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_FORMA_AVERBACAO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_FORMA_AVERBACAO);
                _.Move(executed_1.SUBGVGAP_TIPO_PLANO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_PLANO);
                _.Move(executed_1.SUBGVGAP_PERI_FATURAMENTO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_FATURAMENTO);
                _.Move(executed_1.SUBGVGAP_PERI_RENOVACAO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RENOVACAO);
                _.Move(executed_1.SUBGVGAP_PERI_RETROATI_INC, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RETROATI_INC);
                _.Move(executed_1.SUBGVGAP_PERI_RETROATI_CAN, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PERI_RETROATI_CAN);
                _.Move(executed_1.SUBGVGAP_OCORR_ENDERECO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_ENDERECO);
                _.Move(executed_1.SUBGVGAP_OCORR_END_COBRAN, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OCORR_END_COBRAN);
                _.Move(executed_1.SUBGVGAP_BCO_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_BCO_COBRANCA);
                _.Move(executed_1.SUBGVGAP_AGE_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_AGE_COBRANCA);
                _.Move(executed_1.SUBGVGAP_DAC_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_DAC_COBRANCA);
                _.Move(executed_1.SUBGVGAP_TIPO_COBRANCA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_TIPO_COBRANCA);
                _.Move(executed_1.SUBGVGAP_COD_PAG_ANGARIACAO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_PAG_ANGARIACAO);
                _.Move(executed_1.SUBGVGAP_PCT_CONJUGE_VG, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_VG);
                _.Move(executed_1.SUBGVGAP_PCT_CONJUGE_AP, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_PCT_CONJUGE_AP);
                _.Move(executed_1.SUBGVGAP_OPCAO_COBERTURA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_COBERTURA);
                _.Move(executed_1.SUBGVGAP_OPCAO_CORRETAGEM, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CORRETAGEM);
                _.Move(executed_1.SUBGVGAP_IND_CONSISTE_MATRI, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_CONSISTE_MATRI);
                _.Move(executed_1.SUBGVGAP_IND_PLANO_ASSOCIA, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_IND_PLANO_ASSOCIA);
                _.Move(executed_1.SUBGVGAP_SIT_REGISTRO, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_SIT_REGISTRO);
                _.Move(executed_1.SUBGVGAP_OPCAO_CONJUGE, SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_OPCAO_CONJUGE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_SAIDA*/

        [StopWatch]
        /*" R0500-00-OBTER-OPCAOPAG-SECTION */
        private void R0500_00_OBTER_OPCAOPAG_SECTION()
        {
            /*" -1948- MOVE 'R0500-00-OBTER-OPCAOPAG' TO PARAGRAFO. */
            _.Move("R0500-00-OBTER-OPCAOPAG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1950- MOVE 'SELECT OPCAOPAGVA' TO COMANDO. */
            _.Move("SELECT OPCAOPAGVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -1951- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO OPCPAGVI-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

            /*" -1953- MOVE '9999-12-31' TO OPCPAGVI-DATA-TERVIGENCIA */
            _.Move("9999-12-31", OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA);

            /*" -1975- PERFORM R0500_00_OBTER_OPCAOPAG_DB_SELECT_1 */

            R0500_00_OBTER_OPCAOPAG_DB_SELECT_1();

            /*" -1978- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1979- MOVE 1 TO W-OPCAOPAG */
                _.Move(1, WAREA_AUXILIAR.W_OPCAOPAG);

                /*" -1980- ELSE */
            }
            else
            {


                /*" -1981- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1982- MOVE 2 TO W-OPCAOPAG */
                    _.Move(2, WAREA_AUXILIAR.W_OPCAOPAG);

                    /*" -1983- ELSE */
                }
                else
                {


                    /*" -1984- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -1985- DISPLAY '          ERRO SELECT TABELA OPCAOPAGVA' */
                    _.Display($"          ERRO SELECT TABELA OPCAOPAGVA");

                    /*" -1987- DISPLAY '          CERTIFICADO................. ' OPCPAGVI-NUM-CERTIFICADO */
                    _.Display($"          CERTIFICADO................. {OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO}");

                    /*" -1989- DISPLAY '          SQLCODE..................... ' SQLCODE */
                    _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                    /*" -1990- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -1990- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0500-00-OBTER-OPCAOPAG-DB-SELECT-1 */
        public void R0500_00_OBTER_OPCAOPAG_DB_SELECT_1()
        {
            /*" -1975- EXEC SQL SELECT OPCAO_PAGAMENTO , PERI_PAGAMENTO , DIA_DEBITO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO INTO :OPCPAGVI-OPCAO-PAGAMENTO , :OPCPAGVI-PERI-PAGAMENTO , :OPCPAGVI-DIA-DEBITO , :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGECTADEB, :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPRCTADEB , :OPCPAGVI-NUM-CONTA-DEBITO:VIND-NUMCTADEB , :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DIGCTADEB FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE (NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO OR NUM_CERTIFICADO = :WHOST-NUM-TERMO) AND DATA_TERVIGENCIA = :OPCPAGVI-DATA-TERVIGENCIA WITH UR END-EXEC. */

            var r0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1 = new R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1()
            {
                OPCPAGVI_DATA_TERVIGENCIA = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA.ToString(),
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
                WHOST_NUM_TERMO = WHOST_NUM_TERMO.ToString(),
            };

            var executed_1 = R0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1.Execute(r0500_00_OBTER_OPCAOPAG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_PERI_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO);
                _.Move(executed_1.OPCPAGVI_DIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGECTADEB, VIND_AGECTADEB);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPRCTADEB, VIND_OPRCTADEB);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_NUMCTADEB, VIND_NUMCTADEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DIGCTADEB, VIND_DIGCTADEB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_SAIDA*/

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-SECTION */
        private void R0450_00_OBTER_COBERTURA_SECTION()
        {
            /*" -2000- MOVE 'R0450-00-OBTER-COBERTURA' TO PARAGRAFO. */
            _.Move("R0450-00-OBTER-COBERTURA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2002- MOVE 'SELECT COBERPROPVA' TO COMANDO. */
            _.Move("SELECT COBERPROPVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2003- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO HISCOBPR-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);

            /*" -2004- MOVE TERMOADE-NUM-TERMO TO WHOST-NUM-TERMO */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO, WHOST_NUM_TERMO);

            /*" -2006- MOVE '9999-12-31' TO HISCOBPR-DATA-TERVIGENCIA */
            _.Move("9999-12-31", HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);

            /*" -2008- MOVE 2 TO W-COBERTURAS */
            _.Move(2, WAREA_AUXILIAR.W_COBERTURAS);

            /*" -2022- PERFORM R0450_00_OBTER_COBERTURA_DB_DECLARE_1 */

            R0450_00_OBTER_COBERTURA_DB_DECLARE_1();

            /*" -2024- PERFORM R0450_00_OBTER_COBERTURA_DB_OPEN_1 */

            R0450_00_OBTER_COBERTURA_DB_OPEN_1();

            /*" -2027- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2028- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -2029- DISPLAY '          ERRO OPEN DO CURSOR COBERTURAS' */
                _.Display($"          ERRO OPEN DO CURSOR COBERTURAS");

                /*" -2031- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -2033- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -2035- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -2036- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2038- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2047- PERFORM R0450_00_OBTER_COBERTURA_DB_FETCH_1 */

            R0450_00_OBTER_COBERTURA_DB_FETCH_1();

            /*" -2050- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2051- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -2052- DISPLAY '  R0450   ERRO FETCH DO CURSOR COBERTURAS' */
                _.Display($"  R0450   ERRO FETCH DO CURSOR COBERTURAS");

                /*" -2054- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -2056- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                /*" -2059- DISPLAY '          SQLCODE..................... ' SQLCODE */
                _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                /*" -2059- PERFORM R0450_00_OBTER_COBERTURA_DB_CLOSE_1 */

                R0450_00_OBTER_COBERTURA_DB_CLOSE_1();

                /*" -2062- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2063- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -2064- DISPLAY '          ERRO CLOSE DO CURSOR COBERTURAS' */
                    _.Display($"          ERRO CLOSE DO CURSOR COBERTURAS");

                    /*" -2066- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                    _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -2068- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                    /*" -2071- DISPLAY '          SQLCODE..................... ' SQLCODE */
                    _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                    /*" -2072- GO TO R0450-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/ //GOTO
                    return;

                    /*" -2074- ELSE */
                }
                else
                {


                    /*" -2074- PERFORM R0450_00_OBTER_COBERTURA_DB_CLOSE_2 */

                    R0450_00_OBTER_COBERTURA_DB_CLOSE_2();

                    /*" -2077- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2078- DISPLAY 'PF0642B - FIM ANORMAL' */
                        _.Display($"PF0642B - FIM ANORMAL");

                        /*" -2079- DISPLAY '          ERRO CLOSE DO CURSOR ENDERECOS ' */
                        _.Display($"          ERRO CLOSE DO CURSOR ENDERECOS ");

                        /*" -2081- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                        _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                        /*" -2083- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                        _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                        /*" -2085- DISPLAY '          SQLCODE..................... ' SQLCODE */
                        _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                        /*" -2086- GO TO R0450-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/ //GOTO
                        return;

                        /*" -2088- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -2090- ELSE */
                    }

                }

            }
            else
            {


                /*" -2092- MOVE 1 TO W-COBERTURAS */
                _.Move(1, WAREA_AUXILIAR.W_COBERTURAS);

                /*" -2092- PERFORM R0450_00_OBTER_COBERTURA_DB_CLOSE_3 */

                R0450_00_OBTER_COBERTURA_DB_CLOSE_3();

                /*" -2095- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -2096- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -2097- DISPLAY '          ERRO CLOSE DO CURSOR COBERTURAS' */
                    _.Display($"          ERRO CLOSE DO CURSOR COBERTURAS");

                    /*" -2099- DISPLAY '          NUMERO DO TERMO ADESAO...... ' TERMOADE-NUM-TERMO */
                    _.Display($"          NUMERO DO TERMO ADESAO...... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                    /*" -2101- DISPLAY '          NUMERO CERTIFICADO.......... ' HISCOBPR-NUM-CERTIFICADO */
                    _.Display($"          NUMERO CERTIFICADO.......... {HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO}");

                    /*" -2103- DISPLAY '          SQLCODE..................... ' SQLCODE */
                    _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                    /*" -2104- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2104- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-OPEN-1 */
        public void R0450_00_OBTER_COBERTURA_DB_OPEN_1()
        {
            /*" -2024- EXEC SQL OPEN COBERTURAS END-EXEC. */

            COBERTURAS.Open();

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-DECLARE-1 */
        public void R0570_00_LER_COMISSAO_DB_DECLARE_1()
        {
            /*" -2178- EXEC SQL DECLARE FUNDOCOMISVA CURSOR FOR SELECT NUM_CERTIFICADO , VAL_COMISSAO_VG , VAL_COMISSAO_AP FROM SEGUROS.FUNDO_COMISSAO_VA WHERE (NUM_CERTIFICADO = :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO OR NUM_CERTIFICADO = :WHOST-NUM-TERMO) AND COD_OPERACAO = :DCLFUNDO-COMISSAO-VA.COD-OPERACAO WITH UR END-EXEC. */
            FUNDOCOMISVA = new PF0642B_FUNDOCOMISVA(true);
            string GetQuery_FUNDOCOMISVA()
            {
                var query = @$"SELECT NUM_CERTIFICADO
							, 
							VAL_COMISSAO_VG
							, 
							VAL_COMISSAO_AP 
							FROM SEGUROS.FUNDO_COMISSAO_VA 
							WHERE (NUM_CERTIFICADO = 
							'{FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}' 
							OR NUM_CERTIFICADO = '{WHOST_NUM_TERMO}') 
							AND COD_OPERACAO = 
							'{FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO}'";

                return query;
            }
            FUNDOCOMISVA.GetQueryEvent += GetQuery_FUNDOCOMISVA;

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-FETCH-1 */
        public void R0450_00_OBTER_COBERTURA_DB_FETCH_1()
        {
            /*" -2047- EXEC SQL FETCH COBERTURAS INTO :HISCOBPR-NUM-CERTIFICADO , :HISCOBPR-OCORR-HISTORICO , :HISCOBPR-DATA-INIVIGENCIA , :HISCOBPR-DATA-TERVIGENCIA , :HISCOBPR-IMP-MORNATU , :HISCOBPR-IMPMORACID , :HISCOBPR-IMPINVPERM END-EXEC. */

            if (COBERTURAS.Fetch())
            {
                _.Move(COBERTURAS.HISCOBPR_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);
                _.Move(COBERTURAS.HISCOBPR_OCORR_HISTORICO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_OCORR_HISTORICO);
                _.Move(COBERTURAS.HISCOBPR_DATA_INIVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA);
                _.Move(COBERTURAS.HISCOBPR_DATA_TERVIGENCIA, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA);
                _.Move(COBERTURAS.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
                _.Move(COBERTURAS.HISCOBPR_IMPMORACID, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID);
                _.Move(COBERTURAS.HISCOBPR_IMPINVPERM, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM);
            }

        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-CLOSE-1 */
        public void R0450_00_OBTER_COBERTURA_DB_CLOSE_1()
        {
            /*" -2059- EXEC SQL CLOSE COBERTURAS END-EXEC */

            COBERTURAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0450_SAIDA*/

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-CLOSE-2 */
        public void R0450_00_OBTER_COBERTURA_DB_CLOSE_2()
        {
            /*" -2074- EXEC SQL CLOSE C01_ENDERECO END-EXEC */

            C01_ENDERECO.Close();

        }

        [StopWatch]
        /*" R0470-00-LER-PROPOSTA-SECTION */
        private void R0470_00_LER_PROPOSTA_SECTION()
        {
            /*" -2114- MOVE 'R0470-00-OBTER-OPCAOPAG' TO PARAGRAFO. */
            _.Move("R0470-00-OBTER-OPCAOPAG", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2116- MOVE 'SELECT LER PROPOSTA' TO COMANDO. */
            _.Move("SELECT LER PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2118- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO PROPOVA-NUM-CERTIFICADO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -2133- PERFORM R0470_00_LER_PROPOSTA_DB_SELECT_1 */

            R0470_00_LER_PROPOSTA_DB_SELECT_1();

            /*" -2136- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -2137- MOVE 1 TO W-PROPOSTAVA */
                _.Move(1, WAREA_AUXILIAR.W_PROPOSTAVA);

                /*" -2138- ELSE */
            }
            else
            {


                /*" -2139- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2140- MOVE 2 TO W-PROPOSTAVA */
                    _.Move(2, WAREA_AUXILIAR.W_PROPOSTAVA);

                    /*" -2141- ELSE */
                }
                else
                {


                    /*" -2142- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -2143- DISPLAY '          ERRO SELECT TABELA PROPOSTAVA' */
                    _.Display($"          ERRO SELECT TABELA PROPOSTAVA");

                    /*" -2145- DISPLAY '          CERTIFICADO................. ' PROPOVA-NUM-CERTIFICADO */
                    _.Display($"          CERTIFICADO................. {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO}");

                    /*" -2147- DISPLAY '          SQLCODE..................... ' SQLCODE */
                    _.Display($"          SQLCODE..................... {DB.SQLCODE}");

                    /*" -2148- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2148- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0470-00-LER-PROPOSTA-DB-SELECT-1 */
        public void R0470_00_LER_PROPOSTA_DB_SELECT_1()
        {
            /*" -2133- EXEC SQL SELECT DATA_QUITACAO , FAIXA_RENDA_IND , FAIXA_RENDA_FAM INTO :PROPOVA-DATA-QUITACAO , :PROPOVA-FAIXA-RENDA-IND :VIND-FAIXA-RENDA-IND , :PROPOVA-FAIXA-RENDA-FAM :VIND-FAIXA-RENDA-FAM FROM SEGUROS.PROPOSTAS_VA WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO OR NUM_CERTIFICADO = :WHOST-NUM-TERMO WITH UR END-EXEC. */

            var r0470_00_LER_PROPOSTA_DB_SELECT_1_Query1 = new R0470_00_LER_PROPOSTA_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                WHOST_NUM_TERMO = WHOST_NUM_TERMO.ToString(),
            };

            var executed_1 = R0470_00_LER_PROPOSTA_DB_SELECT_1_Query1.Execute(r0470_00_LER_PROPOSTA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(executed_1.PROPOVA_FAIXA_RENDA_IND, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND);
                _.Move(executed_1.VIND_FAIXA_RENDA_IND, VIND_FAIXA_RENDA_IND);
                _.Move(executed_1.PROPOVA_FAIXA_RENDA_FAM, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM);
                _.Move(executed_1.VIND_FAIXA_RENDA_FAM, VIND_FAIXA_RENDA_FAM);
            }


        }

        [StopWatch]
        /*" R0450-00-OBTER-COBERTURA-DB-CLOSE-3 */
        public void R0450_00_OBTER_COBERTURA_DB_CLOSE_3()
        {
            /*" -2092- EXEC SQL CLOSE COBERTURAS END-EXEC */

            COBERTURAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0470_SAIDA*/

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-SECTION */
        private void R0570_00_LER_COMISSAO_SECTION()
        {
            /*" -2158- MOVE 'R0570-00-LER-COMISSAO' TO PARAGRAFO. */
            _.Move("R0570-00-LER-COMISSAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2160- MOVE 'SELECT FUNDOCOMISVA' TO COMANDO. */
            _.Move("SELECT FUNDOCOMISVA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2163- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);

            /*" -2166- MOVE 1101 TO COD-OPERACAO OF DCLFUNDO-COMISSAO-VA */
            _.Move(1101, FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO);

            /*" -2178- PERFORM R0570_00_LER_COMISSAO_DB_DECLARE_1 */

            R0570_00_LER_COMISSAO_DB_DECLARE_1();

            /*" -2181- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2182- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -2183- DISPLAY '          ERRO DECLARE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO DECLARE CURSOR FUNDOCOMISVA");

                /*" -2185- DISPLAY '          NUMERO CERTIFICADO.............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO.............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -2187- DISPLAY '          SQLCODE......................... ' SQLCODE */
                _.Display($"          SQLCODE......................... {DB.SQLCODE}");

                /*" -2188- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2190- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2190- PERFORM R0570_00_LER_COMISSAO_DB_OPEN_1 */

            R0570_00_LER_COMISSAO_DB_OPEN_1();

            /*" -2193- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2194- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -2195- DISPLAY '          ERRO OPEN CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO OPEN CURSOR FUNDOCOMISVA");

                /*" -2197- DISPLAY '          NUMERO CERTIFICADO........... ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO........... {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -2199- DISPLAY '          SQLCODE...................... ' SQLCODE */
                _.Display($"          SQLCODE...................... {DB.SQLCODE}");

                /*" -2200- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2202- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2208- PERFORM R0570_00_LER_COMISSAO_DB_FETCH_1 */

            R0570_00_LER_COMISSAO_DB_FETCH_1();

            /*" -2211- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2212- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2215- MOVE ZEROS TO VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA, VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA */
                    _.Move(0, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);

                    /*" -2216- ELSE */
                }
                else
                {


                    /*" -2217- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -2218- DISPLAY '          ERRO SELECT CURSOR FUNDOCOMISVA' */
                    _.Display($"          ERRO SELECT CURSOR FUNDOCOMISVA");

                    /*" -2220- DISPLAY '          NUMERO CERTIFICADO............. ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                    _.Display($"          NUMERO CERTIFICADO............. {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                    /*" -2222- DISPLAY '          SQLCODE........................ ' SQLCODE */
                    _.Display($"          SQLCODE........................ {DB.SQLCODE}");

                    /*" -2223- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2225- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


            /*" -2225- PERFORM R0570_00_LER_COMISSAO_DB_CLOSE_1 */

            R0570_00_LER_COMISSAO_DB_CLOSE_1();

            /*" -2228- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2229- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -2230- DISPLAY '          ERRO CLOSE CURSOR FUNDOCOMISVA' */
                _.Display($"          ERRO CLOSE CURSOR FUNDOCOMISVA");

                /*" -2232- DISPLAY '          NUMERO CERTIFICADO............ ' NUM-CERTIFICADO OF DCLFUNDO-COMISSAO-VA */
                _.Display($"          NUMERO CERTIFICADO............ {FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO}");

                /*" -2234- DISPLAY '          SQLCODE....................... ' SQLCODE */
                _.Display($"          SQLCODE....................... {DB.SQLCODE}");

                /*" -2235- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2235- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-OPEN-1 */
        public void R0570_00_LER_COMISSAO_DB_OPEN_1()
        {
            /*" -2190- EXEC SQL OPEN FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Open();

        }

        [StopWatch]
        /*" R0710-OBTER-NIVEL-EMPRESA-DB-DECLARE-1 */
        public void R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1()
        {
            /*" -2717- EXEC SQL DECLARE C2 CURSOR FOR SELECT NUM_PROPOSTA_SIVPF, DTH_INI_VIGENCIA, NUM_NIVEL_CARGO, DTH_FIM_VIGENCIA, IMP_SEGURADA, VLR_PRM_INDIVIDUAL, QTD_VIDAS FROM SEGUROS.VG_TERMO_NIVEL WHERE NUM_PROPOSTA_SIVPF = :VGTERNIV-NUM-PROPOSTA-SIVPF AND DTH_INI_VIGENCIA <= :VGTERNIV-DTH-INI-VIGENCIA AND DTH_FIM_VIGENCIA >= :VGTERNIV-DTH-INI-VIGENCIA ORDER BY NUM_NIVEL_CARGO WITH UR END-EXEC. */
            C2 = new PF0642B_C2(true);
            string GetQuery_C2()
            {
                var query = @$"SELECT 
							NUM_PROPOSTA_SIVPF
							, 
							DTH_INI_VIGENCIA
							, 
							NUM_NIVEL_CARGO
							, 
							DTH_FIM_VIGENCIA
							, 
							IMP_SEGURADA
							, 
							VLR_PRM_INDIVIDUAL
							, 
							QTD_VIDAS 
							FROM 
							SEGUROS.VG_TERMO_NIVEL 
							WHERE 
							NUM_PROPOSTA_SIVPF = '{VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF}' 
							AND DTH_INI_VIGENCIA <= '{VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA}' 
							AND DTH_FIM_VIGENCIA >= '{VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA}' 
							ORDER BY NUM_NIVEL_CARGO";

                return query;
            }
            C2.GetQueryEvent += GetQuery_C2;

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-FETCH-1 */
        public void R0570_00_LER_COMISSAO_DB_FETCH_1()
        {
            /*" -2208- EXEC SQL FETCH FUNDOCOMISVA INTO :DCLFUNDO-COMISSAO-VA.NUM-CERTIFICADO , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-VG , :DCLFUNDO-COMISSAO-VA.VAL-COMISSAO-AP END-EXEC. */

            if (FUNDOCOMISVA.Fetch())
            {
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_NUM_CERTIFICADO, FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO);
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_VG, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG);
                _.Move(FUNDOCOMISVA.DCLFUNDO_COMISSAO_VA_VAL_COMISSAO_AP, FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP);
            }

        }

        [StopWatch]
        /*" R0570-00-LER-COMISSAO-DB-CLOSE-1 */
        public void R0570_00_LER_COMISSAO_DB_CLOSE_1()
        {
            /*" -2225- EXEC SQL CLOSE FUNDOCOMISVA END-EXEC. */

            FUNDOCOMISVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0570_SAIDA*/

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-SECTION */
        private void R0580_00_OBTER_VAL_TARIFA_SECTION()
        {
            /*" -2245- MOVE 'R0580-00-OBTER-VAL-TARIFA' TO PARAGRAFO. */
            _.Move("R0580-00-OBTER-VAL-TARIFA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2247- MOVE 'SELECT TARIFA-BALCAO-CEF' TO COMANDO. */
            _.Move("SELECT TARIFA-BALCAO-CEF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2250- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO);

            /*" -2263- PERFORM R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1 */

            R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1();

            /*" -2266- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -2267- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2268- MOVE ZEROS TO VAL-TARIFA OF DCLTARIFA-BALCAO-CEF */
                    _.Move(0, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);

                    /*" -2269- ELSE */
                }
                else
                {


                    /*" -2270- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -2271- DISPLAY '          ERRO SELECT TAB. TARIFA-BALCAO-CEF' */
                    _.Display($"          ERRO SELECT TAB. TARIFA-BALCAO-CEF");

                    /*" -2273- DISPLAY '          NUMERO CERTIFICADO........ ' NUM-CERTIFICADO OF DCLTARIFA-BALCAO-CEF */
                    _.Display($"          NUMERO CERTIFICADO........ {TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO}");

                    /*" -2275- DISPLAY '          SQLCODE................... ' SQLCODE */
                    _.Display($"          SQLCODE................... {DB.SQLCODE}");

                    /*" -2276- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2276- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0580-00-OBTER-VAL-TARIFA-DB-SELECT-1 */
        public void R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1()
        {
            /*" -2263- EXEC SQL SELECT VAL_TARIFA INTO :DCLTARIFA-BALCAO-CEF.VAL-TARIFA FROM SEGUROS.TARIFA_BALCAO_CEF WHERE COD_EMPRESA = 0 AND NUM_MATRICULA = 9999999 AND TIPO_FUNCIONARIO = '5' AND (NUM_CERTIFICADO = :DCLTARIFA-BALCAO-CEF.NUM-CERTIFICADO OR NUM_CERTIFICADO = :WHOST-NUM-TERMO) WITH UR END-EXEC. */

            var r0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1 = new R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1()
            {
                NUM_CERTIFICADO = TARIBCEF.DCLTARIFA_BALCAO_CEF.NUM_CERTIFICADO.ToString(),
                WHOST_NUM_TERMO = WHOST_NUM_TERMO.ToString(),
            };

            var executed_1 = R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1.Execute(r0580_00_OBTER_VAL_TARIFA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VAL_TARIFA, TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0580_SAIDA*/

        [StopWatch]
        /*" R0600-00-PROPOSTA-REGISTRO-TP1-SECTION */
        private void R0600_00_PROPOSTA_REGISTRO_TP1_SECTION()
        {
            /*" -2287- MOVE 'R0600-00-PROPOSTA-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0600-00-PROPOSTA-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2290- INITIALIZE REG-CLIENTES, REG-PRP-SASSE. */
            _.Initialize(
                LBFPF011.REG_CLIENTES
                , REG_PRP_SASSE
            );

            /*" -2292- MOVE '1' TO R1-TIPO-REG OF REG-CLIENTES */
            _.Move("1", LBFPF011.REG_CLIENTES.R1_TIPO_REG);

            /*" -2295- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R1-NUM-PROPOSTA OF REG-CLIENTES */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA);

            /*" -2297- MOVE CLIENTES-CGCCPF TO R1-CGC-CPF OF REG-CLIENTES */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, LBFPF011.REG_CLIENTES.R1_CGC_CPF);

            /*" -2299- MOVE '01010001' TO R1-DATA-NASCIMENTO OF REG-CLIENTES */
            _.Move("01010001", LBFPF011.REG_CLIENTES.R1_DATA_NASCIMENTO);

            /*" -2302- MOVE CLIENTES-NOME-RAZAO TO R1-NOME-PESSOA OF REG-CLIENTES. */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LBFPF011.REG_CLIENTES.R1_NOME_PESSOA);

            /*" -2304- MOVE 2 TO R1-TIPO-PESSOA OF REG-CLIENTES. */
            _.Move(2, LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA);

            /*" -2307- MOVE ZEROS TO R1-NUM-IDENTIDADE OF REG-CLIENTES. */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_NUM_IDENTIDADE);

            /*" -2311- MOVE SPACES TO R1-ORGAO-EXPEDIDOR OF REG-CLIENTES, R1-UF-EXPEDIDORA OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_ORGAO_EXPEDIDOR, LBFPF011.REG_CLIENTES.R1_UF_EXPEDIDORA);

            /*" -2315- MOVE ZEROS TO R1-ESTADO-CIVIL OF REG-CLIENTES R1-IDE-SEXO OF REG-CLIENTES R1-COD-CBO OF REG-CLIENTES. */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_ESTADO_CIVIL, LBFPF011.REG_CLIENTES.R1_IDE_SEXO, LBFPF011.REG_CLIENTES.R1_COD_CBO);

            /*" -2318- MOVE ENDERECO-DDD OF DCLENDERECOS TO R1-DDD(2). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_DDD);

            /*" -2321- MOVE ENDERECO-TELEFONE OF DCLENDERECOS TO R1-NUM-FONE(2). */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, LBFPF011.REG_CLIENTES.R1_TELEFONE[2].R1_NUM_FONE);

            /*" -2322- IF ENDERECO-FAX OF DCLENDERECOS GREATER ZERO */

            if (ENDERECO.DCLENDERECOS.ENDERECO_FAX > 00)
            {

                /*" -2324- MOVE ENDERECO-FAX OF DCLENDERECOS TO R1-NUM-FONE(3) */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_FAX, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_NUM_FONE);

                /*" -2327- MOVE ENDERECO-DDD OF DCLENDERECOS TO R1-DDD(3). */
                _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, LBFPF011.REG_CLIENTES.R1_TELEFONE[3].R1_DDD);
            }


            /*" -2331- MOVE ZEROS TO R1-DDD(1) */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_DDD);

            /*" -2335- MOVE ZEROS TO R1-NUM-FONE(1) */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_TELEFONE[1].R1_NUM_FONE);

            /*" -2337- MOVE SPACES TO R1-NOME-CONJUGE OF REG-CLIENTES */
            _.Move("", LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE);

            /*" -2339- MOVE ZEROS TO R1-DTNASC-CONJUGE OF REG-CLIENTES */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE);

            /*" -2341- MOVE -1 TO VIND-DTNASC-ESPOSA */
            _.Move(-1, VIND_DTNASC_ESPOSA);

            /*" -2343- MOVE ZEROS TO R1-CBO-CONJUGE OF REG-CLIENTES. */
            _.Move(0, LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE);

            /*" -2345- MOVE SPACES TO R1-EMAIL OF REG-CLIENTES. */
            _.Move("", LBFPF011.REG_CLIENTES.R1_EMAIL);

            /*" -2346- IF VIND-FAIXA-RENDA-IND NOT LESS 0 */

            if (VIND_FAIXA_RENDA_IND >= 0)
            {

                /*" -2349- MOVE PROPOVA-FAIXA-RENDA-IND TO R1-RENDA-INDIVIDUAL OF REG-CLIENTES. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, LBFPF011.REG_CLIENTES.R1_RENDA_INDIVIDUAL);
            }


            /*" -2350- IF VIND-FAIXA-RENDA-FAM NOT LESS 0 */

            if (VIND_FAIXA_RENDA_FAM >= 0)
            {

                /*" -2353- MOVE PROPOVA-FAIXA-RENDA-FAM TO R1-RENDA-FAMILIAR OF REG-CLIENTES. */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM, LBFPF011.REG_CLIENTES.R1_RENDA_FAMILIAR);
            }


            /*" -2355- WRITE REG-PRP-SASSE FROM REG-CLIENTES. */
            _.Move(LBFPF011.REG_CLIENTES.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2355- ADD 1 TO W-QTD-LD-TIPO-1. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_1.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0600_SAIDA*/

        [StopWatch]
        /*" R0650-00-PROPOSTA-REGISTRO-TP2-SECTION */
        private void R0650_00_PROPOSTA_REGISTRO_TP2_SECTION()
        {
            /*" -2367- MOVE 'R0650-00-PROPOSTA-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0650-00-PROPOSTA-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2369- INITIALIZE REG-PRP-SASSE. */
            _.Initialize(
                REG_PRP_SASSE
            );

            /*" -2371- MOVE '2' TO R2-TIPO-REG OF REG-ENDERECO */
            _.Move("2", LBFPF012.REG_ENDERECO.R2_TIPO_REG);

            /*" -2374- MOVE ENDERECO-COD-ENDERECO OF DCLENDERECOS TO R2-TIPO-ENDER OF REG-ENDERECO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_COD_ENDERECO, LBFPF012.REG_ENDERECO.R2_TIPO_ENDER);

            /*" -2377- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R2-NUM-PROPOSTA OF REG-ENDERECO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA);

            /*" -2380- MOVE ENDERECO-ENDERECO OF DCLENDERECOS TO R2-ENDERECO OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, LBFPF012.REG_ENDERECO.R2_ENDERECO);

            /*" -2383- MOVE ENDERECO-BAIRRO OF DCLENDERECOS TO R2-BAIRRO OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, LBFPF012.REG_ENDERECO.R2_BAIRRO);

            /*" -2386- MOVE ENDERECO-CIDADE OF DCLENDERECOS TO R2-CIDADE OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, LBFPF012.REG_ENDERECO.R2_CIDADE);

            /*" -2389- MOVE ENDERECO-SIGLA-UF OF DCLENDERECOS TO R2-SIGLA-UF OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, LBFPF012.REG_ENDERECO.R2_SIGLA_UF);

            /*" -2392- MOVE ENDERECO-CEP OF DCLENDERECOS TO R2-CEP OF REG-ENDERECO. */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, LBFPF012.REG_ENDERECO.R2_CEP);

            /*" -2394- WRITE REG-PRP-SASSE FROM REG-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2396- ADD 1 TO W-QTD-LD-TIPO-2. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_2.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + 1;

            /*" -2396- PERFORM R0370-00-LER-ENDERECO. */

            R0370_00_LER_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0650_SAIDA*/

        [StopWatch]
        /*" R0680-00-PROPOSTA-REGISTRO-TP3-SECTION */
        private void R0680_00_PROPOSTA_REGISTRO_TP3_SECTION()
        {
            /*" -2407- MOVE 'R0680-00-PROPOSTA-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0680-00-PROPOSTA-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2410- MOVE SPACES TO REG-PROPOSTA-SASSE REG-PRP-SASSE. */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE, REG_PRP_SASSE);

            /*" -2413- MOVE '3' TO R3-TIPO-REG OF REG-PROPOSTA-SASSE */
            _.Move("3", LXFCT004.REG_PROPOSTA_SASSE.R3_TIPO_REG);

            /*" -2416- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA);

            /*" -2419- MOVE PRDSIVPF-COD-PRODUTO-SIVPF OF DCLPRODUTOS-SIVPF TO R3-COD-PRODUTO OF REG-PROPOSTA-SASSE */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_PRODUTO_SIVPF, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO);

            /*" -2422- MOVE TERMOADE-COD-AGENCIA-OP TO R3-AGECOBR OF REG-PROPOSTA-SASSE. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_OP, LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR);

            /*" -2424- MOVE TERMOADE-DATA-ADESAO TO W-DATA-SQL */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2425- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -2426- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -2427- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -2430- MOVE W-DATA-TRABALHO TO R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA);

            /*" -2431- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 1 OR 2 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.In("1", "2"))
            {

                /*" -2433- MOVE 1 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(1, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2434- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 3 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 3)
            {

                /*" -2436- MOVE 2 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(2, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2437- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 4 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 4)
            {

                /*" -2439- MOVE 4 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(4, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2440- IF OPCPAGVI-OPCAO-PAGAMENTO EQUAL 5 */

            if (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO == 5)
            {

                /*" -2442- MOVE 3 TO R3-OPCAOPAG OF REG-PROPOSTA-SASSE. */
                _.Move(3, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG);
            }


            /*" -2443- IF R3-OPCAOPAG OF REG-PROPOSTA-SASSE EQUAL 1 OR 4 */

            if (LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG.In("1", "4"))
            {

                /*" -2446- MOVE OPCPAGVI-DIA-DEBITO TO R3-DIA-DEBITO OF REG-PROPOSTA-SASSE */
                _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO);

                /*" -2447- IF VIND-AGECTADEB LESS 0 */

                if (VIND_AGECTADEB < 0)
                {

                    /*" -2448- MOVE ZEROS TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                    /*" -2449- ELSE */
                }
                else
                {


                    /*" -2451- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO R3-AGECTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB);

                    /*" -2453- END-IF */
                }


                /*" -2454- IF VIND-OPRCTADEB LESS 0 */

                if (VIND_OPRCTADEB < 0)
                {

                    /*" -2455- MOVE ZEROS TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);

                    /*" -2456- ELSE */
                }
                else
                {


                    /*" -2458- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO R3-OPRCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB);

                    /*" -2460- END-IF */
                }


                /*" -2461- IF VIND-NUMCTADEB LESS 0 */

                if (VIND_NUMCTADEB < 0)
                {

                    /*" -2462- MOVE ZEROS TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);

                    /*" -2463- ELSE */
                }
                else
                {


                    /*" -2465- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO R3-NUMCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB);

                    /*" -2467- END-IF */
                }


                /*" -2468- IF VIND-DIGCTADEB LESS 0 */

                if (VIND_DIGCTADEB < 0)
                {

                    /*" -2469- MOVE ZEROS TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);

                    /*" -2470- ELSE */
                }
                else
                {


                    /*" -2472- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO R3-DIGCTADEB OF REG-PROPOSTA-SASSE */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB);

                    /*" -2473- END-IF */
                }


                /*" -2474- ELSE */
            }
            else
            {


                /*" -2481- MOVE ZEROS TO R3-AGECTADEB OF REG-PROPOSTA-SASSE R3-OPRCTADEB OF REG-PROPOSTA-SASSE R3-NUMCTADEB OF REG-PROPOSTA-SASSE R3-DIGCTADEB OF REG-PROPOSTA-SASSE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE. */
                _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO);
            }


            /*" -2485- MOVE SPACES TO R3-DPS-TITULAR OF REG-PROPOSTA-SASSE R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR, LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE);

            /*" -2488- MOVE TERMOADE-NUM-MATRICULA-VEN TO R3-NRMATRVEN OF REG-PROPOSTA-SASSE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_MATRICULA_VEN, LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN);

            /*" -2492- MOVE SPACES TO R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE R3-RENOVACAO-AUTOM OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ, LXFCT004.REG_PROPOSTA_SASSE.R3_RENOVACAO_AUTOM);

            /*" -2496- MOVE ZEROS TO R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE);

            /*" -2502- MOVE SPACES TO R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE */
            _.Move("", LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE);

            /*" -2505- MOVE 'MAN' TO R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move("MAN", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA);

            /*" -2508- MOVE 'PAG' TO R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE. */
            _.Move("PAG", LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA);

            /*" -2511- MOVE ZEROS TO R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE. */
            _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO);

            /*" -2514- MOVE TERMOADE-TIPO-COBERTURA TO R3-COBERTURA OF REG-PROPOSTA-SASSE. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_TIPO_COBERTURA, LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER_R.R3_COBERTURA);

            /*" -2515- IF TERMOADE-COD-PLANO-VGAPC GREATER ZEROS */

            if (TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_VGAPC > 00)
            {

                /*" -2517- MOVE TERMOADE-COD-PLANO-VGAPC TO R3-COD-PLANO OF REG-PROPOSTA-SASSE */
                _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_VGAPC, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

                /*" -2518- ELSE */
            }
            else
            {


                /*" -2519- IF TERMOADE-COD-PLANO-APC GREATER ZEROS */

                if (TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_APC > 00)
                {

                    /*" -2521- MOVE TERMOADE-COD-PLANO-APC TO R3-COD-PLANO OF REG-PROPOSTA-SASSE */
                    _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_PLANO_APC, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);

                    /*" -2522- ELSE */
                }
                else
                {


                    /*" -2524- MOVE ZEROS TO R3-COD-PLANO OF REG-PROPOSTA-SASSE. */
                    _.Move(0, LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO);
                }

            }


            /*" -2527- MOVE PROPOVA-DATA-QUITACAO TO W-DATA-SQL */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2528- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -2529- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -2530- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -2533- MOVE W-DATA-TRABALHO TO R3-DTQITBCO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO);

            /*" -2537- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO R3-VAL-PAGO OF REG-PROPOSTA-SASSE R3-VALOR-PREMIO-TOTAL OF REG-PROPOSTA-SASSE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_PAGO, LXFCT004.REG_PROPOSTA_SASSE.R3_VALOR_PREMIO_TOTAL);

            /*" -2540- MOVE RCAPS-AGE-COBRANCA OF DCLRCAPS TO R3-AGEPGTO OF REG-PROPOSTA-SASSE. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, LXFCT004.REG_PROPOSTA_SASSE.R3_AGEPGTO);

            /*" -2543- MOVE VAL-TARIFA OF DCLTARIFA-BALCAO-CEF TO R3-VAL-TARIFA OF REG-PROPOSTA-SASSE. */
            _.Move(TARIBCEF.DCLTARIFA_BALCAO_CEF.VAL_TARIFA, LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA);

            /*" -2545- MOVE RCAPS-DATA-MOVIMENTO OF DCLRCAPS TO W-DATA-SQL */
            _.Move(RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2546- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -2547- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -2548- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -2551- MOVE W-DATA-TRABALHO TO R3-DATA-CREDITO OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO);

            /*" -2558- COMPUTE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE = VAL-COMISSAO-VG OF DCLFUNDO-COMISSAO-VA + VAL-COMISSAO-AP OF DCLFUNDO-COMISSAO-VA. */
            LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO.Value = FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_VG + FDCOMVA.DCLFUNDO_COMISSAO_VA.VAL_COMISSAO_AP;

            /*" -2563- MOVE OPCPAGVI-PERI-PAGAMENTO TO R3-PERIPGTO OF REG-PROPOSTA-SASSE */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_PERI_PAGAMENTO, LXFCT004.REG_PROPOSTA_SASSE.R3_PERIPGTO);

            /*" -2566- MOVE RH-NSAS OF REG-HEADER TO R3-NSAS OF REG-PROPOSTA-SASSE. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, LXFCT004.REG_PROPOSTA_SASSE.R3_NSAS);

            /*" -2568- MOVE 6 TO R3-ORIGEM-PROPOSTA OF REG-PROPOSTA-SASSE. */
            _.Move(6, LXFCT004.REG_PROPOSTA_SASSE.R3_ORIGEM_PROPOSTA_AIC);

            /*" -2570- ADD 1 TO W-QTD-LD-TIPO-3. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_3.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + 1;

            /*" -2573- MOVE W-QTD-LD-TIPO-3 TO R3-NSL OF REG-PROPOSTA-SASSE. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LXFCT004.REG_PROPOSTA_SASSE.R3_NSL);

            /*" -2573- WRITE REG-PRP-SASSE FROM REG-PROPOSTA-SASSE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0680_SAIDA*/

        [StopWatch]
        /*" R0700-00-PROPOSTA-REGISTRO-TP6-SECTION */
        private void R0700_00_PROPOSTA_REGISTRO_TP6_SECTION()
        {
            /*" -2585- MOVE 'R0700-00-PROPOSTA-REGISTRO-TP6' TO PARAGRAFO. */
            _.Move("R0700-00-PROPOSTA-REGISTRO-TP6", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2587- MOVE SPACES TO REGISTRO-VIDA-EMPRESARIAL */
            _.Move("", LBFPF160.REGISTRO_VIDA_EMPRESARIAL);

            /*" -2589- MOVE '6' TO R6-TIPO-REG */
            _.Move("6", LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_TIPO_REG);

            /*" -2592- MOVE PROPOFID-NUM-PROPOSTA-SIVPF TO R6-NUM-PROPOSTA. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA);

            /*" -2593- PERFORM R0705-00-REGISTRO-EMPRESA. */

            R0705_00_REGISTRO_EMPRESA_SECTION();

            /*" -2594- PERFORM R0740-00-REGISTRO-FUNCIONARIO. */

            R0740_00_REGISTRO_FUNCIONARIO_SECTION();

            /*" -2594- PERFORM R0770-00-REGISTRO-COBERTURAS. */

            R0770_00_REGISTRO_COBERTURAS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0700_SAIDA*/

        [StopWatch]
        /*" R0705-00-REGISTRO-EMPRESA-SECTION */
        private void R0705_00_REGISTRO_EMPRESA_SECTION()
        {
            /*" -2605- MOVE 'R0705-00-REGISTRO-EMPRESA' TO PARAGRAFO. */
            _.Move("R0705-00-REGISTRO-EMPRESA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2610- INITIALIZE R6-INFO, R6-INFO-EMPRESA, R5-REG-QTDE-VIDAS-VE, W-IND-NIVEL. */
            _.Initialize(
                LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO
                , LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA
                , LBFPF200.R5_REG_QTDE_VIDAS_VE
                , WAREA_AUXILIAR.W_IND_NIVEL
            );

            /*" -2611- MOVE 5 TO R5-TIPO-REG. */
            _.Move(5, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_TIPO_REG);

            /*" -2613- MOVE R6-NUM-PROPOSTA TO R5-NUM-PROPOSTA. */
            _.Move(LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_NUM_PROPOSTA);

            /*" -2615- MOVE 1 TO R6-TIPO-INFORMACAO */
            _.Move(1, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_TIPO_INFORMACAO);

            /*" -2617- MOVE ZEROS TO R6-VERSAO. */
            _.Move(0, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_VERSAO);

            /*" -2618- IF TERMOADE-MODALIDADE-CAPITAL EQUAL "2" */

            if (TERMOADE.DCLTERMO_ADESAO.TERMOADE_MODALIDADE_CAPITAL == "2")
            {

                /*" -2620- MOVE 1 TO R6-TIPO-CAPITAL. */
                _.Move(1, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_TIPO_CAPITAL);
            }


            /*" -2621- IF TERMOADE-MODALIDADE-CAPITAL EQUAL "3" */

            if (TERMOADE.DCLTERMO_ADESAO.TERMOADE_MODALIDADE_CAPITAL == "3")
            {

                /*" -2623- MOVE 2 TO R6-TIPO-CAPITAL. */
                _.Move(2, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_TIPO_CAPITAL);
            }


            /*" -2624- MOVE TERMOADE-VAL-CONTRATADO TO R6-CAPITAL-CONTRATADO. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_VAL_CONTRATADO, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_CAPITAL_CONTRATADO);

            /*" -2626- MOVE TERMOADE-PERI-PAGAMENTO TO R6-PERIPGTO. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_PERI_PAGAMENTO, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_PERIPGTO);

            /*" -2628- PERFORM R0708-OBTER-VALOR-FATURA */

            R0708_OBTER_VALOR_FATURA_SECTION();

            /*" -2630- MOVE VGFUNCOB-VLR-PREMIO TO R6-VALOR-DA-FATURA */
            _.Move(VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_VLR_PREMIO, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_VALOR_DA_FATURA);

            /*" -2632- MOVE TERMOADE-QUANT-VIDAS TO R6-TOTAL-DE-VIDAS */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_QUANT_VIDAS, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_TOTAL_DE_VIDAS);

            /*" -2634- MOVE CLIENTES-COD-PORTE-EMP TO R6-PORTE-EMPRESA */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_PORTE_EMP, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_PORTE_EMPRESA);

            /*" -2635- MOVE CLIENTES-COD-NATUREZA-ATIV TO W-COD-NATU-ATIVIDADE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_NATUREZA_ATIV, WAREA_AUXILIAR.FILLER_8.W_COD_NATU_ATIVIDADE);

            /*" -2636- MOVE CLIENTES-COD-RAMO-ATIVIDADE TO W-COD-RAMO-ATIVIDADE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_RAMO_ATIVIDADE, WAREA_AUXILIAR.FILLER_8.W_COD_RAMO_ATIVIDADE);

            /*" -2638- MOVE CLIENTES-COD-ATIVIDADE TO W-COD-ATIVIDADE */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_COD_ATIVIDADE, WAREA_AUXILIAR.FILLER_8.W_COD_ATIVIDADE);

            /*" -2640- MOVE W-CODIGO-CNAE TO R6-CODIGO-CNAE */
            _.Move(WAREA_AUXILIAR.W_CODIGO_CNAE, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_CODIGO_CNAE);

            /*" -2642- PERFORM R0710-OBTER-NIVEL-EMPRESA */

            R0710_OBTER_NIVEL_EMPRESA_SECTION();

            /*" -2644- PERFORM R0715-FETCH-NIVEL-EMPRESA. */

            R0715_FETCH_NIVEL_EMPRESA_SECTION();

            /*" -2647- PERFORM R0720-MONTA-NIVEL-CARGO UNTIL W-FIM-TERNIV = 'S' . */

            while (!(WAREA_AUXILIAR.W_FIM_TERNIV == "S"))
            {

                R0720_MONTA_NIVEL_CARGO_SECTION();
            }

            /*" -2649- MOVE W-IND-NIVEL TO R6-QUANT-NIVEIS. */
            _.Move(WAREA_AUXILIAR.W_IND_NIVEL, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_QUANT_NIVEIS);

            /*" -2651- WRITE REG-PRP-SASSE FROM REGISTRO-VIDA-EMPRESARIAL. */
            _.Move(LBFPF160.REGISTRO_VIDA_EMPRESARIAL.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -2651- ADD 1 TO W-QTD-LD-TIPO-6. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_6.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0705_SAIDA*/

        [StopWatch]
        /*" R0708-OBTER-VALOR-FATURA-SECTION */
        private void R0708_OBTER_VALOR_FATURA_SECTION()
        {
            /*" -2661- MOVE 'R0708-OBTER-VALOR-FATURA' TO PARAGRAFO. */
            _.Move("R0708-OBTER-VALOR-FATURA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2663- MOVE 'SOMA PREMIO DA VG_FUNC_COBERTURA' TO COMANDO. */
            _.Move("SOMA PREMIO DA VG_FUNC_COBERTURA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2664- MOVE R6-NUM-PROPOSTA TO VGFUNCOB-NUM-PROPOSTA-SIVPF */
            _.Move(LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_NUM_PROPOSTA_SIVPF);

            /*" -2665- MOVE TERMOADE-DATA-ADESAO TO VGFUNCOB-DTH-INI-VIGENCIA */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_DTH_INI_VIGENCIA);

            /*" -2667- MOVE 17 TO VGFUNCOB-COD-GARANTIA */
            _.Move(17, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_COD_GARANTIA);

            /*" -2679- PERFORM R0708_OBTER_VALOR_FATURA_DB_SELECT_1 */

            R0708_OBTER_VALOR_FATURA_DB_SELECT_1();

            /*" -2682- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2684- DISPLAY 'PF0642B - ERRO SELECT (SUM) VG_FUNC_COBERTURA  ' SQLCODE '    ' R6-NUM-PROPOSTA */

                $"PF0642B - ERRO SELECT (SUM) VG_FUNC_COBERTURA  {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                .Display();

                /*" -2685- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2685- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0708-OBTER-VALOR-FATURA-DB-SELECT-1 */
        public void R0708_OBTER_VALOR_FATURA_DB_SELECT_1()
        {
            /*" -2679- EXEC SQL SELECT VALUE (SUM(VLR_PREMIO),0) INTO :VGFUNCOB-VLR-PREMIO FROM SEGUROS.VG_FUNC_COBERTURA WHERE NUM_PROPOSTA_SIVPF = :VGFUNCOB-NUM-PROPOSTA-SIVPF AND DTH_INI_VIGENCIA = :VGFUNCOB-DTH-INI-VIGENCIA AND COD_GARANTIA = :VGFUNCOB-COD-GARANTIA WITH UR END-EXEC. */

            var r0708_OBTER_VALOR_FATURA_DB_SELECT_1_Query1 = new R0708_OBTER_VALOR_FATURA_DB_SELECT_1_Query1()
            {
                VGFUNCOB_NUM_PROPOSTA_SIVPF = VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_NUM_PROPOSTA_SIVPF.ToString(),
                VGFUNCOB_DTH_INI_VIGENCIA = VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_DTH_INI_VIGENCIA.ToString(),
                VGFUNCOB_COD_GARANTIA = VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_COD_GARANTIA.ToString(),
            };

            var executed_1 = R0708_OBTER_VALOR_FATURA_DB_SELECT_1_Query1.Execute(r0708_OBTER_VALOR_FATURA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.VGFUNCOB_VLR_PREMIO, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_VLR_PREMIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0708_SAIDA*/

        [StopWatch]
        /*" R0710-OBTER-NIVEL-EMPRESA-SECTION */
        private void R0710_OBTER_NIVEL_EMPRESA_SECTION()
        {
            /*" -2692- MOVE 'R0710-OBTER-NIVEL-EMPRESA  ' TO PARAGRAFO. */
            _.Move("R0710-OBTER-NIVEL-EMPRESA  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2694- MOVE 'DECLARE CURSOR C2      ' TO COMANDO. */
            _.Move("DECLARE CURSOR C2      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2695- MOVE R6-NUM-PROPOSTA TO VGTERNIV-NUM-PROPOSTA-SIVPF. */
            _.Move(LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF);

            /*" -2696- MOVE TERMOADE-DATA-ADESAO TO VGTERNIV-DTH-INI-VIGENCIA. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA);

            /*" -2698- MOVE 'N' TO W-FIM-TERNIV. */
            _.Move("N", WAREA_AUXILIAR.W_FIM_TERNIV);

            /*" -2717- PERFORM R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1 */

            R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1();

            /*" -2720- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2722- DISPLAY 'PF0642B - ERRO NO DECLER DO CURSOR C2 - NIVEL ' SQLCODE '    ' R6-NUM-PROPOSTA */

                $"PF0642B - ERRO NO DECLER DO CURSOR C2 - NIVEL {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                .Display();

                /*" -2723- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2725- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2727- MOVE 'OPEN CURSOR C2      ' TO COMANDO. */
            _.Move("OPEN CURSOR C2      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2727- PERFORM R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1 */

            R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1();

            /*" -2730- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2732- DISPLAY 'PF0642B - ERRO NO OPEN DO CURSOR C2 - NIVEL ' SQLCODE '    ' R6-NUM-PROPOSTA */

                $"PF0642B - ERRO NO OPEN DO CURSOR C2 - NIVEL {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                .Display();

                /*" -2733- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2733- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0710-OBTER-NIVEL-EMPRESA-DB-OPEN-1 */
        public void R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1()
        {
            /*" -2727- EXEC SQL OPEN C2 END-EXEC. */

            C2.Open();

        }

        [StopWatch]
        /*" R0745-OBTER-FUNC-EMPRESA-DB-DECLARE-1 */
        public void R0745_OBTER_FUNC_EMPRESA_DB_DECLARE_1()
        {
            /*" -2891- EXEC SQL DECLARE FUNCIONARIOS CURSOR FOR SELECT NUM_PROPOSTA_SIVPF, DTH_INI_VIGENCIA, NUM_CPF, DTH_FIM_VIGENCIA, NUM_NIVEL_CARGO, NUM_MATRICULA, NOM_FUNCIONARIO, DTH_NASCIMENTO, NUM_IDADE, STA_SEXO, STA_ESTADO_CIVIL, COD_PROFISSAO, IND_REPR_EMPRE, IND_IMP_DPS, DES_MOTIVO, NUM_DDD, NUM_TELEFONE, NUM_RG, COD_ORGAO_RG, COD_UF_ORGAO_RG, DTH_EMISSAO_RG, STA_FUNCIONARIO, COD_USUARIO FROM SEGUROS.VG_MOV_FUNCIONARIO WHERE NUM_PROPOSTA_SIVPF = :VGMOVFUN-NUM-PROPOSTA-SIVPF AND DTH_INI_VIGENCIA <= :VGMOVFUN-DTH-FIM-VIGENCIA AND DTH_FIM_VIGENCIA >= :VGMOVFUN-DTH-FIM-VIGENCIA AND STA_FUNCIONARIO = :VGMOVFUN-STA-FUNCIONARIO ORDER BY NUM_MATRICULA, DTH_INI_VIGENCIA WITH UR END-EXEC. */
            FUNCIONARIOS = new PF0642B_FUNCIONARIOS(true);
            string GetQuery_FUNCIONARIOS()
            {
                var query = @$"SELECT 
							NUM_PROPOSTA_SIVPF
							, 
							DTH_INI_VIGENCIA
							, 
							NUM_CPF
							, 
							DTH_FIM_VIGENCIA
							, 
							NUM_NIVEL_CARGO
							, 
							NUM_MATRICULA
							, 
							NOM_FUNCIONARIO
							, 
							DTH_NASCIMENTO
							, 
							NUM_IDADE
							, 
							STA_SEXO
							, 
							STA_ESTADO_CIVIL
							, 
							COD_PROFISSAO
							, 
							IND_REPR_EMPRE
							, 
							IND_IMP_DPS
							, 
							DES_MOTIVO
							, 
							NUM_DDD
							, 
							NUM_TELEFONE
							, 
							NUM_RG
							, 
							COD_ORGAO_RG
							, 
							COD_UF_ORGAO_RG
							, 
							DTH_EMISSAO_RG
							, 
							STA_FUNCIONARIO
							, 
							COD_USUARIO 
							FROM 
							SEGUROS.VG_MOV_FUNCIONARIO 
							WHERE 
							NUM_PROPOSTA_SIVPF = '{VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_PROPOSTA_SIVPF}' 
							AND DTH_INI_VIGENCIA <= '{VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_FIM_VIGENCIA}' 
							AND DTH_FIM_VIGENCIA >= '{VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_FIM_VIGENCIA}' 
							AND STA_FUNCIONARIO = '{VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_FUNCIONARIO}' 
							ORDER BY NUM_MATRICULA
							, DTH_INI_VIGENCIA";

                return query;
            }
            FUNCIONARIOS.GetQueryEvent += GetQuery_FUNCIONARIOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0710_SAIDA*/

        [StopWatch]
        /*" R0715-FETCH-NIVEL-EMPRESA-SECTION */
        private void R0715_FETCH_NIVEL_EMPRESA_SECTION()
        {
            /*" -2741- MOVE 'R0715-FETCH-NIVEL-EMPRESA' TO PARAGRAFO. */
            _.Move("R0715-FETCH-NIVEL-EMPRESA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2743- MOVE 'FETCH CURSOR C2  ' TO COMANDO. */
            _.Move("FETCH CURSOR C2  ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2753- PERFORM R0715_FETCH_NIVEL_EMPRESA_DB_FETCH_1 */

            R0715_FETCH_NIVEL_EMPRESA_DB_FETCH_1();

            /*" -2756- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2757- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2758- MOVE 'S' TO W-FIM-TERNIV */
                    _.Move("S", WAREA_AUXILIAR.W_FIM_TERNIV);

                    /*" -2758- PERFORM R0715_FETCH_NIVEL_EMPRESA_DB_CLOSE_1 */

                    R0715_FETCH_NIVEL_EMPRESA_DB_CLOSE_1();

                    /*" -2760- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2762- DISPLAY 'PF0642B - ERRO CLOSE DO CURSOR C2 - NIVEL ' SQLCODE '    ' R6-NUM-PROPOSTA */

                        $"PF0642B - ERRO CLOSE DO CURSOR C2 - NIVEL {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                        .Display();

                        /*" -2763- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -2764- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -2766- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -2767- ELSE */
                    }

                }
                else
                {


                    /*" -2769- DISPLAY 'PF0642B - ERRO NO FETCH DO CURSOR C2 - NIVEL ' SQLCODE '    ' R6-NUM-PROPOSTA */

                    $"PF0642B - ERRO NO FETCH DO CURSOR C2 - NIVEL {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                    .Display();

                    /*" -2770- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2770- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0715-FETCH-NIVEL-EMPRESA-DB-FETCH-1 */
        public void R0715_FETCH_NIVEL_EMPRESA_DB_FETCH_1()
        {
            /*" -2753- EXEC SQL FETCH C2 INTO :VGTERNIV-NUM-PROPOSTA-SIVPF, :VGTERNIV-DTH-INI-VIGENCIA, :VGTERNIV-NUM-NIVEL-CARGO, :VGTERNIV-DTH-FIM-VIGENCIA, :VGTERNIV-IMP-SEGURADA, :VGTERNIV-VLR-PRM-INDIVIDUAL, :VGTERNIV-QTD-VIDAS END-EXEC. */

            if (C2.Fetch())
            {
                _.Move(C2.VGTERNIV_NUM_PROPOSTA_SIVPF, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_PROPOSTA_SIVPF);
                _.Move(C2.VGTERNIV_DTH_INI_VIGENCIA, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA);
                _.Move(C2.VGTERNIV_NUM_NIVEL_CARGO, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_NIVEL_CARGO);
                _.Move(C2.VGTERNIV_DTH_FIM_VIGENCIA, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_FIM_VIGENCIA);
                _.Move(C2.VGTERNIV_IMP_SEGURADA, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_IMP_SEGURADA);
                _.Move(C2.VGTERNIV_VLR_PRM_INDIVIDUAL, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_VLR_PRM_INDIVIDUAL);
                _.Move(C2.VGTERNIV_QTD_VIDAS, VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_QTD_VIDAS);
            }

        }

        [StopWatch]
        /*" R0715-FETCH-NIVEL-EMPRESA-DB-CLOSE-1 */
        public void R0715_FETCH_NIVEL_EMPRESA_DB_CLOSE_1()
        {
            /*" -2758- EXEC SQL CLOSE C2 END-EXEC */

            C2.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0715_SAIDA*/

        [StopWatch]
        /*" R0720-MONTA-NIVEL-CARGO-SECTION */
        private void R0720_MONTA_NIVEL_CARGO_SECTION()
        {
            /*" -2778- MOVE 'R0720-MONTA-NIVEL-CARGO' TO PARAGRAFO. */
            _.Move("R0720-MONTA-NIVEL-CARGO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2780- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2782- ADD 1 TO W-IND-NIVEL. */
            WAREA_AUXILIAR.W_IND_NIVEL.Value = WAREA_AUXILIAR.W_IND_NIVEL + 1;

            /*" -2783- IF W-IND-NIVEL GREATER 5 */

            if (WAREA_AUXILIAR.W_IND_NIVEL > 5)
            {

                /*" -2784- IF W-FIM-TERNIV NOT EQUAL 'S' */

                if (WAREA_AUXILIAR.W_FIM_TERNIV != "S")
                {

                    /*" -2784- PERFORM R0720_MONTA_NIVEL_CARGO_DB_CLOSE_1 */

                    R0720_MONTA_NIVEL_CARGO_DB_CLOSE_1();

                    /*" -2786- MOVE 'S' TO W-FIM-TERNIV */
                    _.Move("S", WAREA_AUXILIAR.W_FIM_TERNIV);

                    /*" -2787- END-IF */
                }


                /*" -2788- GO TO R0720-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0720_SAIDA*/ //GOTO
                return;

                /*" -2790- END-IF. */
            }


            /*" -2791- IF VGTERNIV-NUM-NIVEL-CARGO EQUAL ZERO */

            if (VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_NIVEL_CARGO == 00)
            {

                /*" -2793- MOVE W-IND-NIVEL TO R6-NIVEL-CARGO (W-IND-NIVEL) */
                _.Move(WAREA_AUXILIAR.W_IND_NIVEL, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_NIVEIS_CARGO[WAREA_AUXILIAR.W_IND_NIVEL].R6_NIVEL_CARGO);

                /*" -2794- ELSE */
            }
            else
            {


                /*" -2797- MOVE VGTERNIV-NUM-NIVEL-CARGO TO R6-NIVEL-CARGO (W-IND-NIVEL). */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_NIVEL_CARGO, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_NIVEIS_CARGO[WAREA_AUXILIAR.W_IND_NIVEL].R6_NIVEL_CARGO);
            }


            /*" -2798- MOVE VGTERNIV-IMP-SEGURADA TO R6-IS-CARGO (W-IND-NIVEL) */
            _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_IMP_SEGURADA, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_NIVEIS_CARGO[WAREA_AUXILIAR.W_IND_NIVEL].R6_IS_CARGO);

            /*" -2801- MOVE VGTERNIV-QTD-VIDAS TO R6-VIDAS-CARGO (W-IND-NIVEL) */
            _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_QTD_VIDAS, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_EMPRESA.R6_NIVEIS_CARGO[WAREA_AUXILIAR.W_IND_NIVEL].R6_VIDAS_CARGO);

            /*" -2802- IF W-IND-NIVEL NOT GREATER 5 */

            if (WAREA_AUXILIAR.W_IND_NIVEL <= 5)
            {

                /*" -2805- MOVE VGTERNIV-NUM-NIVEL-CARGO TO R5-NUM-NIVEL-CARGO (W-IND-NIVEL) */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_NUM_NIVEL_CARGO, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_NOVO.R5_DADOS_NIVEL[WAREA_AUXILIAR.W_IND_NIVEL].R5_NUM_NIVEL_CARGO);

                /*" -2808- MOVE VGTERNIV-IMP-SEGURADA TO R5-IMP-SEGURADA (W-IND-NIVEL) */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_IMP_SEGURADA, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_NOVO.R5_DADOS_NIVEL[WAREA_AUXILIAR.W_IND_NIVEL].R5_IMP_SEGURADA);

                /*" -2809- MOVE VGTERNIV-QTD-VIDAS TO R5-QUANTIDADE-VIDAS (W-IND-NIVEL). */
                _.Move(VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_QTD_VIDAS, LBFPF200.R5_REG_QTDE_VIDAS_VE.R5_DADOS_VE_NOVO.R5_DADOS_NIVEL[WAREA_AUXILIAR.W_IND_NIVEL].R5_QUANTIDADE_VIDAS);
            }


            /*" -0- FLUXCONTROL_PERFORM R0720_NEXT */

            R0720_NEXT();

        }

        [StopWatch]
        /*" R0720-MONTA-NIVEL-CARGO-DB-CLOSE-1 */
        public void R0720_MONTA_NIVEL_CARGO_DB_CLOSE_1()
        {
            /*" -2784- EXEC SQL CLOSE C2 END-EXEC */

            C2.Close();

        }

        [StopWatch]
        /*" R0720-NEXT */
        private void R0720_NEXT(bool isPerform = false)
        {
            /*" -2819- PERFORM R0715-FETCH-NIVEL-EMPRESA. */

            R0715_FETCH_NIVEL_EMPRESA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0720_SAIDA*/

        [StopWatch]
        /*" R0740-00-REGISTRO-FUNCIONARIO-SECTION */
        private void R0740_00_REGISTRO_FUNCIONARIO_SECTION()
        {
            /*" -2831- MOVE 'R0740-00-REGISTRO-FUNCIONARIO' TO PARAGRAFO. */
            _.Move("R0740-00-REGISTRO-FUNCIONARIO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2834- INITIALIZE R6-INFO, R6-INFO-FUNCIONARIO. */
            _.Initialize(
                LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO
                , LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO
            );

            /*" -2836- MOVE 2 TO R6-TIPO-INFORMACAO */
            _.Move(2, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_TIPO_INFORMACAO);

            /*" -2837- PERFORM R0745-OBTER-FUNC-EMPRESA */

            R0745_OBTER_FUNC_EMPRESA_SECTION();

            /*" -2838- PERFORM R0750-FETCH-FUNC-EMPRESA. */

            R0750_FETCH_FUNC_EMPRESA_SECTION();

            /*" -2839- PERFORM R0755-MONTA-REG-FUNC-EMPRESA UNTIL W-FIM-FUNCIONARIOS = 'S' . */

            while (!(WAREA_AUXILIAR.W_FIM_FUNCIONARIOS == "S"))
            {

                R0755_MONTA_REG_FUNC_EMPRESA_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0740_SAIDA*/

        [StopWatch]
        /*" R0745-OBTER-FUNC-EMPRESA-SECTION */
        private void R0745_OBTER_FUNC_EMPRESA_SECTION()
        {
            /*" -2846- MOVE 'R0745-OBTER-FUNC-EMPRESA  ' TO PARAGRAFO. */
            _.Move("R0745-OBTER-FUNC-EMPRESA  ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2848- MOVE 'DECLARE CURSOR FUNCIONARIOS' TO COMANDO. */
            _.Move("DECLARE CURSOR FUNCIONARIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2849- MOVE R6-NUM-PROPOSTA TO VGMOVFUN-NUM-PROPOSTA-SIVPF */
            _.Move(LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_PROPOSTA_SIVPF);

            /*" -2850- MOVE TERMOADE-DATA-ADESAO TO VGMOVFUN-DTH-FIM-VIGENCIA. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_FIM_VIGENCIA);

            /*" -2852- MOVE 'E' TO VGMOVFUN-STA-FUNCIONARIO. */
            _.Move("E", VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_FUNCIONARIO);

            /*" -2854- MOVE 'N' TO W-FIM-FUNCIONARIOS. */
            _.Move("N", WAREA_AUXILIAR.W_FIM_FUNCIONARIOS);

            /*" -2891- PERFORM R0745_OBTER_FUNC_EMPRESA_DB_DECLARE_1 */

            R0745_OBTER_FUNC_EMPRESA_DB_DECLARE_1();

            /*" -2894- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2896- DISPLAY 'PF0642B - ERRO DECLER DO CURSOR FUNCIONARIOS  ' SQLCODE '    ' R6-NUM-PROPOSTA */

                $"PF0642B - ERRO DECLER DO CURSOR FUNCIONARIOS  {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                .Display();

                /*" -2897- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2899- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -2901- MOVE 'OPEN CURSOR FUNCIONARIOS' TO COMANDO. */
            _.Move("OPEN CURSOR FUNCIONARIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2901- PERFORM R0745_OBTER_FUNC_EMPRESA_DB_OPEN_1 */

            R0745_OBTER_FUNC_EMPRESA_DB_OPEN_1();

            /*" -2904- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2906- DISPLAY 'PF0642B - ERRO OPEN DO CURSOR FUNCIONARIOS  ' SQLCODE '    ' R6-NUM-PROPOSTA */

                $"PF0642B - ERRO OPEN DO CURSOR FUNCIONARIOS  {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                .Display();

                /*" -2907- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -2907- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0745-OBTER-FUNC-EMPRESA-DB-OPEN-1 */
        public void R0745_OBTER_FUNC_EMPRESA_DB_OPEN_1()
        {
            /*" -2901- EXEC SQL OPEN FUNCIONARIOS END-EXEC. */

            FUNCIONARIOS.Open();

        }

        [StopWatch]
        /*" R0775-OBTER-COBERTURA-FUNC-DB-DECLARE-1 */
        public void R0775_OBTER_COBERTURA_FUNC_DB_DECLARE_1()
        {
            /*" -3086- EXEC SQL DECLARE COBERFUNC CURSOR FOR SELECT A.NUM_PROPOSTA_SIVPF, A.DTH_INI_VIGENCIA, A.NUM_CPF, A.COD_GARANTIA, A.IMP_SEGURADA, A.VLR_PREMIO, A.VLR_TAXA_CALC_PRM, B.NUM_MATRICULA FROM SEGUROS.VG_FUNC_COBERTURA A, SEGUROS.VG_MOV_FUNCIONARIO B WHERE A.NUM_PROPOSTA_SIVPF = :VGFUNCOB-NUM-PROPOSTA-SIVPF AND A.DTH_INI_VIGENCIA = :VGFUNCOB-DTH-INI-VIGENCIA AND A.COD_GARANTIA <> :VGFUNCOB-COD-GARANTIA AND B.NUM_PROPOSTA_SIVPF = A.NUM_PROPOSTA_SIVPF AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA AND B.NUM_CPF = A.NUM_CPF AND B.STA_FUNCIONARIO = :VGMOVFUN-STA-FUNCIONARIO ORDER BY A.NUM_PROPOSTA_SIVPF, A.DTH_INI_VIGENCIA , A.COD_GARANTIA , B.NUM_MATRICULA WITH UR END-EXEC. */
            COBERFUNC = new PF0642B_COBERFUNC(true);
            string GetQuery_COBERFUNC()
            {
                var query = @$"SELECT 
							A.NUM_PROPOSTA_SIVPF
							, 
							A.DTH_INI_VIGENCIA
							, 
							A.NUM_CPF
							, 
							A.COD_GARANTIA
							, 
							A.IMP_SEGURADA
							, 
							A.VLR_PREMIO
							, 
							A.VLR_TAXA_CALC_PRM
							, 
							B.NUM_MATRICULA 
							FROM 
							SEGUROS.VG_FUNC_COBERTURA A
							, 
							SEGUROS.VG_MOV_FUNCIONARIO B 
							WHERE 
							A.NUM_PROPOSTA_SIVPF = '{VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_NUM_PROPOSTA_SIVPF}' 
							AND A.DTH_INI_VIGENCIA = '{VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_DTH_INI_VIGENCIA}' 
							AND A.COD_GARANTIA <> '{VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_COD_GARANTIA}' 
							AND B.NUM_PROPOSTA_SIVPF = A.NUM_PROPOSTA_SIVPF 
							AND B.DTH_INI_VIGENCIA = A.DTH_INI_VIGENCIA 
							AND B.NUM_CPF = A.NUM_CPF 
							AND B.STA_FUNCIONARIO = '{VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_FUNCIONARIO}' 
							ORDER BY A.NUM_PROPOSTA_SIVPF
							, 
							A.DTH_INI_VIGENCIA
							, 
							A.COD_GARANTIA
							, 
							B.NUM_MATRICULA";

                return query;
            }
            COBERFUNC.GetQueryEvent += GetQuery_COBERFUNC;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0745_SAIDA*/

        [StopWatch]
        /*" R0750-FETCH-FUNC-EMPRESA-SECTION */
        private void R0750_FETCH_FUNC_EMPRESA_SECTION()
        {
            /*" -2915- MOVE 'R0750-FETCH-FUNC-EMPRESA' TO PARAGRAFO. */
            _.Move("R0750-FETCH-FUNC-EMPRESA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2917- MOVE 'FETCH CURSOR FUNCIONARIOS' TO COMANDO. */
            _.Move("FETCH CURSOR FUNCIONARIOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2943- PERFORM R0750_FETCH_FUNC_EMPRESA_DB_FETCH_1 */

            R0750_FETCH_FUNC_EMPRESA_DB_FETCH_1();

            /*" -2946- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2947- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -2948- MOVE 'S' TO W-FIM-FUNCIONARIOS */
                    _.Move("S", WAREA_AUXILIAR.W_FIM_FUNCIONARIOS);

                    /*" -2948- PERFORM R0750_FETCH_FUNC_EMPRESA_DB_CLOSE_1 */

                    R0750_FETCH_FUNC_EMPRESA_DB_CLOSE_1();

                    /*" -2950- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -2952- DISPLAY 'PF0642B - ERRO CLOSE CURSOR FUNCIONARIOS  ' SQLCODE '    ' R6-NUM-PROPOSTA */

                        $"PF0642B - ERRO CLOSE CURSOR FUNCIONARIOS  {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                        .Display();

                        /*" -2953- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -2954- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -2956- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -2957- ELSE */
                    }

                }
                else
                {


                    /*" -2959- DISPLAY 'PF0642B - ERRO FETCH DO CURSOR FUNCIONARIOS  ' SQLCODE '    ' R6-NUM-PROPOSTA */

                    $"PF0642B - ERRO FETCH DO CURSOR FUNCIONARIOS  {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                    .Display();

                    /*" -2960- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -2960- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0750-FETCH-FUNC-EMPRESA-DB-FETCH-1 */
        public void R0750_FETCH_FUNC_EMPRESA_DB_FETCH_1()
        {
            /*" -2943- EXEC SQL FETCH FUNCIONARIOS INTO :VGMOVFUN-NUM-PROPOSTA-SIVPF, :VGMOVFUN-DTH-INI-VIGENCIA, :VGMOVFUN-NUM-CPF, :VGMOVFUN-DTH-FIM-VIGENCIA, :VGMOVFUN-NUM-NIVEL-CARGO, :VGMOVFUN-NUM-MATRICULA, :VGMOVFUN-NOM-FUNCIONARIO, :VGMOVFUN-DTH-NASCIMENTO, :VGMOVFUN-NUM-IDADE, :VGMOVFUN-STA-SEXO, :VGMOVFUN-STA-ESTADO-CIVIL, :VGMOVFUN-COD-PROFISSAO, :VGMOVFUN-IND-REPR-EMPRE, :VGMOVFUN-IND-IMP-DPS, :VGMOVFUN-DES-MOTIVO, :VGMOVFUN-NUM-DDD, :VGMOVFUN-NUM-TELEFONE, :VGMOVFUN-NUM-RG, :VGMOVFUN-COD-ORGAO-RG, :VGMOVFUN-COD-UF-ORGAO-RG, :VGMOVFUN-DTH-EMISSAO-RG, :VGMOVFUN-STA-FUNCIONARIO, :VGMOVFUN-COD-USUARIO END-EXEC. */

            if (FUNCIONARIOS.Fetch())
            {
                _.Move(FUNCIONARIOS.VGMOVFUN_NUM_PROPOSTA_SIVPF, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_PROPOSTA_SIVPF);
                _.Move(FUNCIONARIOS.VGMOVFUN_DTH_INI_VIGENCIA, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_INI_VIGENCIA);
                _.Move(FUNCIONARIOS.VGMOVFUN_NUM_CPF, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_CPF);
                _.Move(FUNCIONARIOS.VGMOVFUN_DTH_FIM_VIGENCIA, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_FIM_VIGENCIA);
                _.Move(FUNCIONARIOS.VGMOVFUN_NUM_NIVEL_CARGO, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_NIVEL_CARGO);
                _.Move(FUNCIONARIOS.VGMOVFUN_NUM_MATRICULA, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_MATRICULA);
                _.Move(FUNCIONARIOS.VGMOVFUN_NOM_FUNCIONARIO, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NOM_FUNCIONARIO);
                _.Move(FUNCIONARIOS.VGMOVFUN_DTH_NASCIMENTO, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_NASCIMENTO);
                _.Move(FUNCIONARIOS.VGMOVFUN_NUM_IDADE, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_IDADE);
                _.Move(FUNCIONARIOS.VGMOVFUN_STA_SEXO, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_SEXO);
                _.Move(FUNCIONARIOS.VGMOVFUN_STA_ESTADO_CIVIL, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_ESTADO_CIVIL);
                _.Move(FUNCIONARIOS.VGMOVFUN_COD_PROFISSAO, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_COD_PROFISSAO);
                _.Move(FUNCIONARIOS.VGMOVFUN_IND_REPR_EMPRE, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_IND_REPR_EMPRE);
                _.Move(FUNCIONARIOS.VGMOVFUN_IND_IMP_DPS, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_IND_IMP_DPS);
                _.Move(FUNCIONARIOS.VGMOVFUN_DES_MOTIVO, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DES_MOTIVO);
                _.Move(FUNCIONARIOS.VGMOVFUN_NUM_DDD, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_DDD);
                _.Move(FUNCIONARIOS.VGMOVFUN_NUM_TELEFONE, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_TELEFONE);
                _.Move(FUNCIONARIOS.VGMOVFUN_NUM_RG, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_RG);
                _.Move(FUNCIONARIOS.VGMOVFUN_COD_ORGAO_RG, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_COD_ORGAO_RG);
                _.Move(FUNCIONARIOS.VGMOVFUN_COD_UF_ORGAO_RG, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_COD_UF_ORGAO_RG);
                _.Move(FUNCIONARIOS.VGMOVFUN_DTH_EMISSAO_RG, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_EMISSAO_RG);
                _.Move(FUNCIONARIOS.VGMOVFUN_STA_FUNCIONARIO, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_FUNCIONARIO);
                _.Move(FUNCIONARIOS.VGMOVFUN_COD_USUARIO, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_COD_USUARIO);
            }

        }

        [StopWatch]
        /*" R0750-FETCH-FUNC-EMPRESA-DB-CLOSE-1 */
        public void R0750_FETCH_FUNC_EMPRESA_DB_CLOSE_1()
        {
            /*" -2948- EXEC SQL CLOSE FUNCIONARIOS END-EXEC */

            FUNCIONARIOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0750_SAIDA*/

        [StopWatch]
        /*" R0755-MONTA-REG-FUNC-EMPRESA-SECTION */
        private void R0755_MONTA_REG_FUNC_EMPRESA_SECTION()
        {
            /*" -2968- MOVE 'R0755-MONTA-REG-FUNC-EMPRESA' TO PARAGRAFO. */
            _.Move("R0755-MONTA-REG-FUNC-EMPRESA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -2970- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -2971- MOVE VGMOVFUN-NUM-MATRICULA TO R6-NUM-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_MATRICULA, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_NUM_FUNC);

            /*" -2972- MOVE VGMOVFUN-NUM-CPF TO R6-CPF-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_CPF, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_CPF_FUNC);

            /*" -2974- MOVE VGMOVFUN-NOM-FUNCIONARIO TO R6-NOME-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NOM_FUNCIONARIO, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_NOME_FUNC);

            /*" -2975- MOVE VGMOVFUN-DTH-NASCIMENTO TO W-DATA-SQL */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_NASCIMENTO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -2976- MOVE W-DIA-SQL TO W-DIA-NASCIMENTO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_2.W_DIA_NASCIMENTO);

            /*" -2977- MOVE W-MES-SQL TO W-MES-NASCIMENTO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_2.W_MES_NASCIMENTO);

            /*" -2978- MOVE W-ANO-SQL TO W-ANO-NASCIMENTO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_2.W_ANO_NASCIMENTO);

            /*" -2980- MOVE W-DATA-NASCIMENTO TO R6-DATA-NASC-FUNC */
            _.Move(WAREA_AUXILIAR.W_DATA_NASCIMENTO, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_DATA_NASC_FUNC);

            /*" -2982- MOVE VGMOVFUN-NUM-IDADE TO R6-IDADE-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_IDADE, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_IDADE_FUNC);

            /*" -2983- IF VGMOVFUN-STA-SEXO EQUAL 'M' */

            if (VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_SEXO == "M")
            {

                /*" -2984- MOVE 01 TO R6-SEXO-FUNC. */
                _.Move(01, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_SEXO_FUNC);
            }


            /*" -2985- IF VGMOVFUN-STA-SEXO EQUAL 'F' */

            if (VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_SEXO == "F")
            {

                /*" -2987- MOVE 02 TO R6-SEXO-FUNC. */
                _.Move(02, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_SEXO_FUNC);
            }


            /*" -2988- IF VGMOVFUN-STA-ESTADO-CIVIL EQUAL 'S' */

            if (VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_ESTADO_CIVIL == "S")
            {

                /*" -2989- MOVE 01 TO R6-ESTADO-CIVIL-FUNC. */
                _.Move(01, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_ESTADO_CIVIL_FUNC);
            }


            /*" -2990- IF VGMOVFUN-STA-ESTADO-CIVIL EQUAL 'C' */

            if (VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_ESTADO_CIVIL == "C")
            {

                /*" -2991- MOVE 02 TO R6-ESTADO-CIVIL-FUNC. */
                _.Move(02, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_ESTADO_CIVIL_FUNC);
            }


            /*" -2992- IF VGMOVFUN-STA-ESTADO-CIVIL EQUAL 'V' */

            if (VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_ESTADO_CIVIL == "V")
            {

                /*" -2993- MOVE 03 TO R6-ESTADO-CIVIL-FUNC. */
                _.Move(03, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_ESTADO_CIVIL_FUNC);
            }


            /*" -2994- IF VGMOVFUN-STA-ESTADO-CIVIL EQUAL 'O' */

            if (VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_ESTADO_CIVIL == "O")
            {

                /*" -2996- MOVE 04 TO R6-ESTADO-CIVIL-FUNC. */
                _.Move(04, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_ESTADO_CIVIL_FUNC);
            }


            /*" -2997- MOVE VGMOVFUN-NUM-DDD TO R6-DDD-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_DDD, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_DDD_FUNC);

            /*" -2998- MOVE VGMOVFUN-NUM-TELEFONE TO R6-TEL-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_TELEFONE, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_TEL_FUNC);

            /*" -2999- MOVE VGMOVFUN-NUM-RG TO R6-RG-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_RG, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_RG_FUNC);

            /*" -3000- MOVE VGMOVFUN-COD-ORGAO-RG TO R6-ORGAO-RG-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_COD_ORGAO_RG, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_ORGAO_RG_FUNC);

            /*" -3002- MOVE VGMOVFUN-COD-UF-ORGAO-RG TO R6-UF-RG-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_COD_UF_ORGAO_RG, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_UF_RG_FUNC);

            /*" -3003- MOVE VGMOVFUN-DTH-EMISSAO-RG TO W-DATA-SQL */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_EMISSAO_RG, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -3004- MOVE W-DIA-SQL TO W-DIA-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -3005- MOVE W-MES-SQL TO W-MES-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -3006- MOVE W-ANO-SQL TO W-ANO-TRABALHO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -3008- MOVE W-DATA-TRABALHO TO R6-DATA-EMIS-RG-FUNC. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_DATA_EMIS_RG_FUNC);

            /*" -3009- MOVE VGMOVFUN-NUM-NIVEL-CARGO TO R6-NIVEL-CARGO-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_NIVEL_CARGO, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_NIVEL_CARGO_FUNC);

            /*" -3010- MOVE VGMOVFUN-COD-PROFISSAO TO R6-CBO-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_COD_PROFISSAO, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_CBO_FUNC);

            /*" -3011- MOVE VGMOVFUN-IND-REPR-EMPRE TO R6-IND-REPRESE-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_IND_REPR_EMPRE, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_IND_REPRESE_FUNC);

            /*" -3013- MOVE VGMOVFUN-IND-IMP-DPS TO R6-IND-IMP-DPS-FUNC */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_IND_IMP_DPS, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_FUNCIONARIO.R6_IND_IMP_DPS_FUNC);

            /*" -3015- WRITE REG-PRP-SASSE FROM REGISTRO-VIDA-EMPRESARIAL. */
            _.Move(LBFPF160.REGISTRO_VIDA_EMPRESARIAL.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -3015- ADD 1 TO W-QTD-LD-TIPO-6. */
            WAREA_AUXILIAR.W_QTD_LD_TIPO_6.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + 1;

            /*" -0- FLUXCONTROL_PERFORM R0755_NEXT */

            R0755_NEXT();

        }

        [StopWatch]
        /*" R0755-NEXT */
        private void R0755_NEXT(bool isPerform = false)
        {
            /*" -3019- PERFORM R0750-FETCH-FUNC-EMPRESA. */

            R0750_FETCH_FUNC_EMPRESA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0755_SAIDA*/

        [StopWatch]
        /*" R0770-00-REGISTRO-COBERTURAS-SECTION */
        private void R0770_00_REGISTRO_COBERTURAS_SECTION()
        {
            /*" -3031- MOVE 'R0770-00-REGISTRO-COBERTURAS' TO PARAGRAFO. */
            _.Move("R0770-00-REGISTRO-COBERTURAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3034- INITIALIZE R6-INFO, R6-INFO-COBERTURAS-FUNC */
            _.Initialize(
                LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO
                , LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_COBERTURAS_FUNC
            );

            /*" -3036- MOVE 3 TO R6-TIPO-INFORMACAO */
            _.Move(3, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_TIPO_INFORMACAO);

            /*" -3037- PERFORM R0775-OBTER-COBERTURA-FUNC */

            R0775_OBTER_COBERTURA_FUNC_SECTION();

            /*" -3038- PERFORM R0780-FETCH-COBERTURA-FUNC */

            R0780_FETCH_COBERTURA_FUNC_SECTION();

            /*" -3039- PERFORM R0785-MONTA-REG-COBERTURA-FUNC UNTIL W-FIM-COBER-FUNC = 'S' . */

            while (!(WAREA_AUXILIAR.W_FIM_COBER_FUNC == "S"))
            {

                R0785_MONTA_REG_COBERTURA_FUNC_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0770_SAIDA*/

        [StopWatch]
        /*" R0775-OBTER-COBERTURA-FUNC-SECTION */
        private void R0775_OBTER_COBERTURA_FUNC_SECTION()
        {
            /*" -3050- MOVE 'R0775-OBTER-COBERTURA-FUNC' TO PARAGRAFO. */
            _.Move("R0775-OBTER-COBERTURA-FUNC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3052- MOVE 'DECLARE CURSOR COBERFUNC' TO COMANDO. */
            _.Move("DECLARE CURSOR COBERFUNC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3053- MOVE R6-NUM-PROPOSTA TO VGFUNCOB-NUM-PROPOSTA-SIVPF */
            _.Move(LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_NUM_PROPOSTA_SIVPF);

            /*" -3054- MOVE TERMOADE-DATA-ADESAO TO VGFUNCOB-DTH-INI-VIGENCIA */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_DTH_INI_VIGENCIA);

            /*" -3055- MOVE 'N' TO W-FIM-COBER-FUNC. */
            _.Move("N", WAREA_AUXILIAR.W_FIM_COBER_FUNC);

            /*" -3056- MOVE 'E' TO VGMOVFUN-STA-FUNCIONARIO */
            _.Move("E", VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_STA_FUNCIONARIO);

            /*" -3058- MOVE 17 TO VGFUNCOB-COD-GARANTIA */
            _.Move(17, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_COD_GARANTIA);

            /*" -3086- PERFORM R0775_OBTER_COBERTURA_FUNC_DB_DECLARE_1 */

            R0775_OBTER_COBERTURA_FUNC_DB_DECLARE_1();

            /*" -3089- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3091- DISPLAY 'PF0642B - ERRO DECLER CURSOR COBERFUNC  ' SQLCODE '    ' R6-NUM-PROPOSTA */

                $"PF0642B - ERRO DECLER CURSOR COBERFUNC  {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                .Display();

                /*" -3092- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3094- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3096- MOVE 'OPEN CURSOR COBERFUNC' TO COMANDO. */
            _.Move("OPEN CURSOR COBERFUNC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3096- PERFORM R0775_OBTER_COBERTURA_FUNC_DB_OPEN_1 */

            R0775_OBTER_COBERTURA_FUNC_DB_OPEN_1();

            /*" -3099- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3101- DISPLAY 'PF0642B - ERRO OPEN CURSOR COBERFUNC  ' SQLCODE '    ' R6-NUM-PROPOSTA */

                $"PF0642B - ERRO OPEN CURSOR COBERFUNC  {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                .Display();

                /*" -3102- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3102- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0775-OBTER-COBERTURA-FUNC-DB-OPEN-1 */
        public void R0775_OBTER_COBERTURA_FUNC_DB_OPEN_1()
        {
            /*" -3096- EXEC SQL OPEN COBERFUNC END-EXEC. */

            COBERFUNC.Open();

        }

        [StopWatch]
        /*" R3136-RELACIONA-EMAIL-DB-DECLARE-1 */
        public void R3136_RELACIONA_EMAIL_DB_DECLARE_1()
        {
            /*" -3974- EXEC SQL DECLARE EMAIL CURSOR FOR SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA ORDER BY SEQ_EMAIL WITH UR END-EXEC. */
            EMAIL = new PF0642B_EMAIL(true);
            string GetQuery_EMAIL()
            {
                var query = @$"SELECT COD_PESSOA
							, 
							SEQ_EMAIL
							, 
							EMAIL
							, 
							SITUACAO_EMAIL 
							FROM SEGUROS.PESSOA_EMAIL 
							WHERE COD_PESSOA = '{PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}' 
							ORDER BY SEQ_EMAIL";

                return query;
            }
            EMAIL.GetQueryEvent += GetQuery_EMAIL;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0775_SAIDA*/

        [StopWatch]
        /*" R0780-FETCH-COBERTURA-FUNC-SECTION */
        private void R0780_FETCH_COBERTURA_FUNC_SECTION()
        {
            /*" -3110- MOVE 'R0780-FETCH-COBERTURA-FUNC' TO PARAGRAFO. */
            _.Move("R0780-FETCH-COBERTURA-FUNC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3112- MOVE 'FETCH CURSOR COBERFUNC' TO COMANDO. */
            _.Move("FETCH CURSOR COBERFUNC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3123- PERFORM R0780_FETCH_COBERTURA_FUNC_DB_FETCH_1 */

            R0780_FETCH_COBERTURA_FUNC_DB_FETCH_1();

            /*" -3126- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -3127- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -3128- MOVE 'S' TO W-FIM-COBER-FUNC */
                    _.Move("S", WAREA_AUXILIAR.W_FIM_COBER_FUNC);

                    /*" -3128- PERFORM R0780_FETCH_COBERTURA_FUNC_DB_CLOSE_1 */

                    R0780_FETCH_COBERTURA_FUNC_DB_CLOSE_1();

                    /*" -3130- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -3132- DISPLAY 'PF0642B - ERRO CLOSE CURSOR COBERFUNC ' SQLCODE '    ' R6-NUM-PROPOSTA */

                        $"PF0642B - ERRO CLOSE CURSOR COBERFUNC {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                        .Display();

                        /*" -3133- PERFORM R9988-00-FECHAR-ARQUIVOS */

                        R9988_00_FECHAR_ARQUIVOS_SECTION();

                        /*" -3134- PERFORM R9999-00-FINALIZAR */

                        R9999_00_FINALIZAR_SECTION();

                        /*" -3136- ELSE NEXT SENTENCE */
                    }
                    else
                    {


                        /*" -3137- ELSE */
                    }

                }
                else
                {


                    /*" -3139- DISPLAY 'PF0642B - ERRO FETCH DO CURSOR COBERFUNC  ' SQLCODE '    ' R6-NUM-PROPOSTA */

                    $"PF0642B - ERRO FETCH DO CURSOR COBERFUNC  {DB.SQLCODE}    {LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_NUM_PROPOSTA}"
                    .Display();

                    /*" -3140- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -3140- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R0780-FETCH-COBERTURA-FUNC-DB-FETCH-1 */
        public void R0780_FETCH_COBERTURA_FUNC_DB_FETCH_1()
        {
            /*" -3123- EXEC SQL FETCH COBERFUNC INTO :VGFUNCOB-NUM-PROPOSTA-SIVPF, :VGFUNCOB-DTH-INI-VIGENCIA, :VGFUNCOB-NUM-CPF, :VGFUNCOB-COD-GARANTIA, :VGFUNCOB-IMP-SEGURADA, :VGFUNCOB-VLR-PREMIO, :VGFUNCOB-VLR-TAXA-CALC-PRM, :VGMOVFUN-NUM-MATRICULA END-EXEC. */

            if (COBERFUNC.Fetch())
            {
                _.Move(COBERFUNC.VGFUNCOB_NUM_PROPOSTA_SIVPF, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_NUM_PROPOSTA_SIVPF);
                _.Move(COBERFUNC.VGFUNCOB_DTH_INI_VIGENCIA, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_DTH_INI_VIGENCIA);
                _.Move(COBERFUNC.VGFUNCOB_NUM_CPF, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_NUM_CPF);
                _.Move(COBERFUNC.VGFUNCOB_COD_GARANTIA, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_COD_GARANTIA);
                _.Move(COBERFUNC.VGFUNCOB_IMP_SEGURADA, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_IMP_SEGURADA);
                _.Move(COBERFUNC.VGFUNCOB_VLR_PREMIO, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_VLR_PREMIO);
                _.Move(COBERFUNC.VGFUNCOB_VLR_TAXA_CALC_PRM, VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_VLR_TAXA_CALC_PRM);
                _.Move(COBERFUNC.VGMOVFUN_NUM_MATRICULA, VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_MATRICULA);
            }

        }

        [StopWatch]
        /*" R0780-FETCH-COBERTURA-FUNC-DB-CLOSE-1 */
        public void R0780_FETCH_COBERTURA_FUNC_DB_CLOSE_1()
        {
            /*" -3128- EXEC SQL CLOSE COBERFUNC END-EXEC */

            COBERFUNC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0780_SAIDA*/

        [StopWatch]
        /*" R0785-MONTA-REG-COBERTURA-FUNC-SECTION */
        private void R0785_MONTA_REG_COBERTURA_FUNC_SECTION()
        {
            /*" -3147- MOVE 'R0785-MONTA-REG-COBERTURA-FUNC' TO PARAGRAFO. */
            _.Move("R0785-MONTA-REG-COBERTURA-FUNC", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3149- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3151- ADD 1 TO W-IND-COB-FUN. */
            WAREA_AUXILIAR.W_IND_COB_FUN.Value = WAREA_AUXILIAR.W_IND_COB_FUN + 1;

            /*" -3153- MOVE VGMOVFUN-NUM-MATRICULA TO R6-NUM-FUNC-COB (W-IND-COB-FUN) */
            _.Move(VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_NUM_MATRICULA, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_COBERTURAS_FUNC.R6_COBERTURAS_FUNC[WAREA_AUXILIAR.W_IND_COB_FUN].R6_NUM_FUNC_COB);

            /*" -3155- MOVE VGFUNCOB-COD-GARANTIA TO R6-COD-COBERTURA (W-IND-COB-FUN) */
            _.Move(VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_COD_GARANTIA, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_COBERTURAS_FUNC.R6_COBERTURAS_FUNC[WAREA_AUXILIAR.W_IND_COB_FUN].R6_COD_COBERTURA);

            /*" -3157- MOVE VGFUNCOB-IMP-SEGURADA TO R6-VALOR-IS (W-IND-COB-FUN) */
            _.Move(VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_IMP_SEGURADA, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_COBERTURAS_FUNC.R6_COBERTURAS_FUNC[WAREA_AUXILIAR.W_IND_COB_FUN].R6_VALOR_IS);

            /*" -3159- MOVE VGFUNCOB-VLR-PREMIO TO R6-VALOR-PREMIO (W-IND-COB-FUN) */
            _.Move(VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_VLR_PREMIO, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_COBERTURAS_FUNC.R6_COBERTURAS_FUNC[WAREA_AUXILIAR.W_IND_COB_FUN].R6_VALOR_PREMIO);

            /*" -3160- MOVE VGFUNCOB-VLR-TAXA-CALC-PRM TO R6-VALOR-TAXA (W-IND-COB-FUN). */
            _.Move(VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_VLR_TAXA_CALC_PRM, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_COBERTURAS_FUNC.R6_COBERTURAS_FUNC[WAREA_AUXILIAR.W_IND_COB_FUN].R6_VALOR_TAXA);

            /*" -0- FLUXCONTROL_PERFORM R0785_NEXT */

            R0785_NEXT();

        }

        [StopWatch]
        /*" R0785-NEXT */
        private void R0785_NEXT(bool isPerform = false)
        {
            /*" -3166- PERFORM R0780-FETCH-COBERTURA-FUNC. */

            R0780_FETCH_COBERTURA_FUNC_SECTION();

            /*" -3168- IF W-IND-COB-FUN EQUAL 6 OR W-FIM-COBER-FUNC EQUAL 'S' */

            if (WAREA_AUXILIAR.W_IND_COB_FUN == 6 || WAREA_AUXILIAR.W_FIM_COBER_FUNC == "S")
            {

                /*" -3169- MOVE W-IND-COB-FUN TO R6-QUANT-COBERTURAS */
                _.Move(WAREA_AUXILIAR.W_IND_COB_FUN, LBFPF160.REGISTRO_VIDA_EMPRESARIAL.R6_INFO_COBERTURAS_FUNC.R6_QUANT_COBERTURAS);

                /*" -3170- WRITE REG-PRP-SASSE FROM REGISTRO-VIDA-EMPRESARIAL */
                _.Move(LBFPF160.REGISTRO_VIDA_EMPRESARIAL.GetMoveValues(), REG_PRP_SASSE);

                MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

                /*" -3171- MOVE ZEROS TO W-IND-COB-FUN */
                _.Move(0, WAREA_AUXILIAR.W_IND_COB_FUN);

                /*" -3171- ADD 1 TO W-QTD-LD-TIPO-6. */
                WAREA_AUXILIAR.W_QTD_LD_TIPO_6.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0785_SAIDA*/

        [StopWatch]
        /*" R0800-00-STATUS-REGISTRO-TP1-SECTION */
        private void R0800_00_STATUS_REGISTRO_TP1_SECTION()
        {
            /*" -3182- MOVE 'R0800-00-STATUS-REGISTRO-TP1' TO PARAGRAFO. */
            _.Move("R0800-00-STATUS-REGISTRO-TP1", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3184- MOVE SPACES TO REG-STA-PROPOSTA. */
            _.Move("", LBFCT011.REG_STA_PROPOSTA);

            /*" -3187- MOVE '1' TO R1-TIPO-REG OF REG-STA-PROPOSTA. */
            _.Move("1", LBFCT011.REG_STA_PROPOSTA.R1_TIPO_REG);

            /*" -3190- MOVE VGCOMTRO-NUM-PROPOSTA-SIVPF TO R1-NUM-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF, LBFCT011.REG_STA_PROPOSTA.R1_NUM_PROPOSTA);

            /*" -3193- MOVE 'EMT' TO R1-SIT-PROPOSTA OF REG-STA-PROPOSTA. */
            _.Move("EMT", LBFCT011.REG_STA_PROPOSTA.R1_SIT_PROPOSTA);

            /*" -3194- IF VGCOMTRO-DTH-LIBERACAO >= '2007-01-01' */

            if (VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_DTH_LIBERACAO >= "2007-01-01")
            {

                /*" -3196- MOVE 228 TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA */
                _.Move(228, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);

                /*" -3197- ELSE */
            }
            else
            {


                /*" -3200- MOVE ZEROS TO R1-SIT-MOTIVO OF REG-STA-PROPOSTA. */
                _.Move(0, LBFCT011.REG_STA_PROPOSTA.R1_SIT_MOTIVO);
            }


            /*" -3203- MOVE VGCOMTRO-DTH-LIBERACAO TO W-DATA-SQL. */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_DTH_LIBERACAO, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -3204- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -3205- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -3207- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -3210- MOVE W-DATA-TRABALHO TO R1-DATA-SITUACAO OF REG-STA-PROPOSTA. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT011.REG_STA_PROPOSTA.R1_DATA_SITUACAO);

            /*" -3212- ADD 1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER-STA */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + 1;

            /*" -3215- MOVE RH-NSAS OF REG-HEADER-STA TO R1-NSAS OF REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, LBFCT011.REG_STA_PROPOSTA.R1_NSAS);

            /*" -3218- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO R1-NSL OF REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, LBFCT011.REG_STA_PROPOSTA.R1_NSL);

            /*" -3218- WRITE REG-STA-SASSE FROM REG-STA-PROPOSTA. */
            _.Move(LBFCT011.REG_STA_PROPOSTA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0800_SAIDA*/

        [StopWatch]
        /*" R0850-00-STATUS-REGISTRO-TP2-SECTION */
        private void R0850_00_STATUS_REGISTRO_TP2_SECTION()
        {
            /*" -3229- MOVE 'R0850-00-STATUS-REGISTRO-TP2' TO PARAGRAFO. */
            _.Move("R0850-00-STATUS-REGISTRO-TP2", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3231- MOVE SPACES TO REG-STA-PROPOSTA. */
            _.Move("", LBFCT011.REG_STA_PROPOSTA);

            /*" -3234- MOVE '2' TO R2-TIPO-REG OF REG-APOL-SASSE */
            _.Move("2", LBFCT016.REG_APOL_SASSE.R2_TIPO_REG);

            /*" -3238- MOVE VGCOMTRO-NUM-PROPOSTA-SIVPF TO R2-NUM-PROPOSTA OF REG-APOL-SASSE R2-NRCERTIF OF REG-APOL-SASSE. */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF, LBFCT016.REG_APOL_SASSE.R2_NUM_PROPOSTA, LBFCT016.REG_APOL_SASSE.R2_NRCERTIF);

            /*" -3241- MOVE HISCOBPR-DATA-INIVIGENCIA TO W-DATA-SQL. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -3242- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -3243- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -3245- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -3248- MOVE W-DATA-TRABALHO TO R2-DTINIVIG OF REG-APOL-SASSE. */
            _.Move(WAREA_AUXILIAR.W_DATA_TRABALHO, LBFCT016.REG_APOL_SASSE.R2_DTINIVIG);

            /*" -3251- MOVE HISCOBPR-DATA-TERVIGENCIA TO W-DATA-SQL. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA, WAREA_AUXILIAR.W_DATA_SQL);

            /*" -3252- MOVE W-DIA-SQL TO W-DIA-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL, WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO);

            /*" -3253- MOVE W-MES-SQL TO W-MES-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL, WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO);

            /*" -3256- MOVE W-ANO-SQL TO W-ANO-TRABALHO. */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL, WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO);

            /*" -3259- MOVE 31129999 TO R2-DTTERVIG OF REG-APOL-SASSE. */
            _.Move(31129999, LBFCT016.REG_APOL_SASSE.R2_DTTERVIG);

            /*" -3260- PERFORM R0860-LER-APOLICE */

            R0860_LER_APOLICE_SECTION();

            /*" -3262- PERFORM R0870-LER-RAMOIND */

            R0870_LER_RAMOIND_SECTION();

            /*" -3264- COMPUTE W-IND-IOF = (RAMOCOMP-PCT-IOCC-RAMO / 100) + 1 */
            WAREA_AUXILIAR.W_IND_IOF.Value = (RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO / 100f) + 1;

            /*" -3267- COMPUTE W-PRM-LIQ = RCAPS-VAL-RCAP OF DCLRCAPS / W-IND-IOF */
            WAREA_AUXILIAR.W_PRM_LIQ.Value = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP / WAREA_AUXILIAR.W_IND_IOF;

            /*" -3271- COMPUTE R2-VAL-IOF OF REG-APOL-SASSE ROUNDED = RCAPS-VAL-RCAP OF DCLRCAPS - W-PRM-LIQ */
            LBFCT016.REG_APOL_SASSE.R2_VAL_IOF.Value = RCAPS.DCLRCAPS.RCAPS_VAL_RCAP - WAREA_AUXILIAR.W_PRM_LIQ;

            /*" -3273- MOVE W-PRM-LIQ TO R2-VAL-PREMIO OF REG-APOL-SASSE */
            _.Move(WAREA_AUXILIAR.W_PRM_LIQ, LBFCT016.REG_APOL_SASSE.R2_VAL_PREMIO);

            /*" -3275- ADD 1 TO RT-QTDE-TIPO-2 OF REG-TRAILLER-STA */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + 1;

            /*" -3275- WRITE REG-STA-SASSE FROM REG-APOL-SASSE. */
            _.Move(LBFCT016.REG_APOL_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0850_SAIDA*/

        [StopWatch]
        /*" R0860-LER-APOLICE-SECTION */
        private void R0860_LER_APOLICE_SECTION()
        {
            /*" -3285- MOVE 'R0860-00-LER-APOLICE' TO PARAGRAFO. */
            _.Move("R0860-00-LER-APOLICE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3287- MOVE 'SELECT TABELA APOLICE' TO COMANDO. */
            _.Move("SELECT TABELA APOLICE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3289- MOVE TERMOADE-NUM-APOLICE TO APOLICES-NUM-APOLICE */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE, APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE);

            /*" -3297- PERFORM R0860_LER_APOLICE_DB_SELECT_1 */

            R0860_LER_APOLICE_DB_SELECT_1();

            /*" -3300- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3301- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -3302- DISPLAY '          ERRO SELECT TABELA APOLICE' */
                _.Display($"          ERRO SELECT TABELA APOLICE");

                /*" -3304- DISPLAY '          NUMERO DO TERMO ADESAO.... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO.... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -3306- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -3307- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3307- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0860-LER-APOLICE-DB-SELECT-1 */
        public void R0860_LER_APOLICE_DB_SELECT_1()
        {
            /*" -3297- EXEC SQL SELECT RAMO_EMISSOR INTO :APOLICES-RAMO-EMISSOR FROM SEGUROS.APOLICES WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE WITH UR END-EXEC. */

            var r0860_LER_APOLICE_DB_SELECT_1_Query1 = new R0860_LER_APOLICE_DB_SELECT_1_Query1()
            {
                APOLICES_NUM_APOLICE = APOLICES.DCLAPOLICES.APOLICES_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0860_LER_APOLICE_DB_SELECT_1_Query1.Execute(r0860_LER_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOLICES_RAMO_EMISSOR, APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0860_SAIDA*/

        [StopWatch]
        /*" R0870-LER-RAMOIND-SECTION */
        private void R0870_LER_RAMOIND_SECTION()
        {
            /*" -3317- MOVE 'R0870-00-LER-RAMOIND' TO PARAGRAFO. */
            _.Move("R0870-00-LER-RAMOIND", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3319- MOVE 'SELECT TABELA RAMOIND' TO COMANDO. */
            _.Move("SELECT TABELA RAMOIND", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3329- PERFORM R0870_LER_RAMOIND_DB_SELECT_1 */

            R0870_LER_RAMOIND_DB_SELECT_1();

            /*" -3332- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3333- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -3334- DISPLAY '          ERRO SELECT TAB. RAMO COMPLEMENTAR' */
                _.Display($"          ERRO SELECT TAB. RAMO COMPLEMENTAR");

                /*" -3336- DISPLAY '          NUMERO DO TERMO ADESAO.... ' TERMOADE-NUM-TERMO */
                _.Display($"          NUMERO DO TERMO ADESAO.... {TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_TERMO}");

                /*" -3338- DISPLAY '          SQLCODE................... ' SQLCODE */
                _.Display($"          SQLCODE................... {DB.SQLCODE}");

                /*" -3339- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3339- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R0870-LER-RAMOIND-DB-SELECT-1 */
        public void R0870_LER_RAMOIND_DB_SELECT_1()
        {
            /*" -3329- EXEC SQL SELECT PCT_IOCC_RAMO INTO :RAMOCOMP-PCT-IOCC-RAMO FROM SEGUROS.RAMO_COMPLEMENTAR WHERE RAMO_EMISSOR = :APOLICES-RAMO-EMISSOR AND DATA_INIVIGENCIA <= :HISCOBPR-DATA-INIVIGENCIA AND DATA_TERVIGENCIA >= :HISCOBPR-DATA-INIVIGENCIA WITH UR END-EXEC. */

            var r0870_LER_RAMOIND_DB_SELECT_1_Query1 = new R0870_LER_RAMOIND_DB_SELECT_1_Query1()
            {
                HISCOBPR_DATA_INIVIGENCIA = HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.ToString(),
                APOLICES_RAMO_EMISSOR = APOLICES.DCLAPOLICES.APOLICES_RAMO_EMISSOR.ToString(),
            };

            var executed_1 = R0870_LER_RAMOIND_DB_SELECT_1_Query1.Execute(r0870_LER_RAMOIND_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.RAMOCOMP_PCT_IOCC_RAMO, RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_PCT_IOCC_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0870_SAIDA*/

        [StopWatch]
        /*" R0900-00-STATUS-REGISTRO-TP3-SECTION */
        private void R0900_00_STATUS_REGISTRO_TP3_SECTION()
        {
            /*" -3350- MOVE 'R0900-00-STATUS-REGISTRO-TP3' TO PARAGRAFO. */
            _.Move("R0900-00-STATUS-REGISTRO-TP3", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3352- MOVE SPACES TO REG-COBER-SASSE. */
            _.Move("", LBFCT016.REG_COBER_SASSE);

            /*" -3355- MOVE '3' TO R3-TIPO-REG OF REG-COBER-SASSE. */
            _.Move("3", LBFCT016.REG_COBER_SASSE.R3_TIPO_REG);

            /*" -3358- MOVE VGCOMTRO-NUM-PROPOSTA-SIVPF TO R3-NUM-PROPOSTA OF REG-COBER-SASSE. */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF, LBFCT016.REG_COBER_SASSE.R3_NUM_PROPOSTA);

            /*" -3360- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO W-SUBPRODUTO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, WAREA_AUXILIAR.FILLER_3.W_SUBPRODUTO);

            /*" -3361- IF HISCOBPR-IMP-MORNATU GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU > 00)
            {

                /*" -3363- MOVE HISCOBPR-IMP-MORNATU TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -3364- MOVE 1 TO W-COBERTURA */
                _.Move(1, WAREA_AUXILIAR.FILLER_3.W_COBERTURA);

                /*" -3366- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -3368- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -3370- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -3371- IF HISCOBPR-IMPMORACID GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID > 00)
            {

                /*" -3373- MOVE HISCOBPR-IMPMORACID TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPMORACID, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -3374- MOVE 2 TO W-COBERTURA */
                _.Move(2, WAREA_AUXILIAR.FILLER_3.W_COBERTURA);

                /*" -3376- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -3378- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -3380- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


            /*" -3381- IF HISCOBPR-IMPINVPERM GREATER ZEROS */

            if (HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM > 00)
            {

                /*" -3383- MOVE HISCOBPR-IMPINVPERM TO R3-VAL-COBERTURA OF REG-COBER-SASSE */
                _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMPINVPERM, LBFCT016.REG_COBER_SASSE.R3_VAL_COBERTURA);

                /*" -3384- MOVE 3 TO W-COBERTURA */
                _.Move(3, WAREA_AUXILIAR.FILLER_3.W_COBERTURA);

                /*" -3386- MOVE W-COD-COBERTURA TO R3-COD-COBERTURA OF REG-COBER-SASSE */
                _.Move(WAREA_AUXILIAR.W_COD_COBERTURA, LBFCT016.REG_COBER_SASSE.R3_COD_COBERTURA);

                /*" -3388- ADD 1 TO RT-QTDE-TIPO-3 OF REG-TRAILLER-STA */
                LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + 1;

                /*" -3388- WRITE REG-STA-SASSE FROM REG-COBER-SASSE. */
                _.Move(LBFCT016.REG_COBER_SASSE.GetMoveValues(), REG_STA_SASSE);

                MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_SAIDA*/

        [StopWatch]
        /*" R0950-00-STATUS-REGISTRO-TP4-SECTION */
        private void R0950_00_STATUS_REGISTRO_TP4_SECTION()
        {
            /*" -3399- MOVE 'R0990-00-STATUS-REGISTRO-TP4' TO PARAGRAFO. */
            _.Move("R0990-00-STATUS-REGISTRO-TP4", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3401- MOVE SPACES TO REG-PGTO-SASSE. */
            _.Move("", LBFCT016.REG_PGTO_SASSE);

            /*" -3404- MOVE '4' TO R4-TIPO-REG OF REG-PGTO-SASSE. */
            _.Move("4", LBFCT016.REG_PGTO_SASSE.R4_TIPO_REG);

            /*" -3407- MOVE VGCOMTRO-NUM-PROPOSTA-SIVPF TO R4-NUM-PROPOSTA OF REG-PGTO-SASSE. */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_NUM_PROPOSTA_SIVPF, LBFCT016.REG_PGTO_SASSE.R4_NUM_PROPOSTA);

            /*" -3410- MOVE 'PAG' TO R4-SIT-COBRANCA OF REG-PGTO-SASSE. */
            _.Move("PAG", LBFCT016.REG_PGTO_SASSE.R4_SIT_COBRANCA);

            /*" -3413- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO R4-DATA-SITUACAO OF REG-PGTO-SASSE. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, LBFCT016.REG_PGTO_SASSE.R4_DATA_SITUACAO);

            /*" -3416- MOVE 1 TO R4-PARCELAS-PAGAS OF REG-PGTO-SASSE */
            _.Move(1, LBFCT016.REG_PGTO_SASSE.R4_PARCELAS_PAGAS);

            /*" -3419- MOVE ZEROS TO R4-TOTAL-PARCELAS OF REG-PGTO-SASSE */
            _.Move(0, LBFCT016.REG_PGTO_SASSE.R4_TOTAL_PARCELAS);

            /*" -3421- WRITE REG-STA-SASSE FROM REG-PGTO-SASSE. */
            _.Move(LBFCT016.REG_PGTO_SASSE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -3421- ADD 1 TO RT-QTDE-TIPO-4 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0950_SAIDA*/

        [StopWatch]
        /*" R0970-00-STATUS-REGISTRO-TP5-SECTION */
        private void R0970_00_STATUS_REGISTRO_TP5_SECTION()
        {
            /*" -3434- MOVE 'R0970-00-STATUS-REGISTRO-TP5' TO PARAGRAFO. */
            _.Move("R0970-00-STATUS-REGISTRO-TP5", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3436- WRITE REG-STA-SASSE FROM R5-REG-QTDE-VIDAS-VE */
            _.Move(LBFPF200.R5_REG_QTDE_VIDAS_VE.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

            /*" -3436- ADD 1 TO RT-QTDE-TIPO-5 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0970_SAIDA*/

        [StopWatch]
        /*" R1000-00-GERAR-TRAILLER-SECTION */
        private void R1000_00_GERAR_TRAILLER_SECTION()
        {
            /*" -3446- MOVE 'R1000-00-GERAR-TRAILLER' TO PARAGRAFO. */
            _.Move("R1000-00-GERAR-TRAILLER", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3448- MOVE 'WRITE REG-TRAILLER - PROPOSTA' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER - PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3450- MOVE SPACES TO REG-PRP-SASSE */
            _.Move("", REG_PRP_SASSE);

            /*" -3453- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER. */
            _.Move("T", LBFPF991.REG_TRAILLER.RT_TIPO_REG);

            /*" -3456- MOVE 'PRPSASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER. */
            _.Move("PRPSASSE", LBFPF991.REG_TRAILLER.RT_NOME_EMPRESA);

            /*" -3459- MOVE W-QTD-LD-TIPO-0 TO RT-QTDE-TIPO-0 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_0, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0);

            /*" -3462- MOVE W-QTD-LD-TIPO-1 TO RT-QTDE-TIPO-1 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_1, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1);

            /*" -3465- MOVE W-QTD-LD-TIPO-2 TO RT-QTDE-TIPO-2 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_2, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2);

            /*" -3468- MOVE W-QTD-LD-TIPO-3 TO RT-QTDE-TIPO-3 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_3, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3);

            /*" -3471- MOVE W-QTD-LD-TIPO-4 TO RT-QTDE-TIPO-4 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_4, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4);

            /*" -3474- MOVE W-QTD-LD-TIPO-5 TO RT-QTDE-TIPO-5 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_5, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5);

            /*" -3477- MOVE W-QTD-LD-TIPO-6 TO RT-QTDE-TIPO-6 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_6, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6);

            /*" -3480- MOVE W-QTD-LD-TIPO-7 TO RT-QTDE-TIPO-7 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_7, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7);

            /*" -3483- MOVE W-QTD-LD-TIPO-8 TO RT-QTDE-TIPO-8 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_8, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8);

            /*" -3486- MOVE W-QTD-LD-TIPO-9 TO RT-QTDE-TIPO-9 OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_9, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9);

            /*" -3489- MOVE W-QTD-LD-TIPO-A TO RT-QTDE-TIPO-A OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_A, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A);

            /*" -3492- MOVE W-QTD-LD-TIPO-B TO RT-QTDE-TIPO-B OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_B, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B);

            /*" -3495- MOVE W-QTD-LD-TIPO-C TO RT-QTDE-TIPO-C OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_C, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C);

            /*" -3498- MOVE W-QTD-LD-TIPO-D TO RT-QTDE-TIPO-D OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_D, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D);

            /*" -3501- MOVE W-QTD-LD-TIPO-E TO RT-QTDE-TIPO-E OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_E, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E);

            /*" -3504- MOVE W-QTD-LD-TIPO-F TO RT-QTDE-TIPO-F OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_F, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F);

            /*" -3507- MOVE W-QTD-LD-TIPO-G TO RT-QTDE-TIPO-G OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_G, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G);

            /*" -3510- MOVE W-QTD-LD-TIPO-H TO RT-QTDE-TIPO-H OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_H, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H);

            /*" -3513- MOVE W-QTD-LD-TIPO-I TO RT-QTDE-TIPO-I OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_I, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I);

            /*" -3516- MOVE W-QTD-LD-TIPO-J TO RT-QTDE-TIPO-J OF REG-TRAILLER. */
            _.Move(WAREA_AUXILIAR.W_QTD_LD_TIPO_J, LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J);

            /*" -3538- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER = RT-QTDE-TIPO-0 OF REG-TRAILLER + RT-QTDE-TIPO-1 OF REG-TRAILLER + RT-QTDE-TIPO-2 OF REG-TRAILLER + RT-QTDE-TIPO-3 OF REG-TRAILLER + RT-QTDE-TIPO-4 OF REG-TRAILLER + RT-QTDE-TIPO-5 OF REG-TRAILLER + RT-QTDE-TIPO-6 OF REG-TRAILLER + RT-QTDE-TIPO-7 OF REG-TRAILLER + RT-QTDE-TIPO-8 OF REG-TRAILLER + RT-QTDE-TIPO-9 OF REG-TRAILLER + RT-QTDE-TIPO-A OF REG-TRAILLER + RT-QTDE-TIPO-B OF REG-TRAILLER + RT-QTDE-TIPO-C OF REG-TRAILLER + RT-QTDE-TIPO-D OF REG-TRAILLER + RT-QTDE-TIPO-E OF REG-TRAILLER + RT-QTDE-TIPO-F OF REG-TRAILLER + RT-QTDE-TIPO-G OF REG-TRAILLER + RT-QTDE-TIPO-H OF REG-TRAILLER + RT-QTDE-TIPO-I OF REG-TRAILLER + RT-QTDE-TIPO-J OF REG-TRAILLER */
            LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL.Value = LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_0 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_2 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_3 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_4 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_5 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_6 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_7 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_8 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_9 + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_A + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_B + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_C + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_D + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_E + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_F + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_G + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_H + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_I + LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_J;

            /*" -3542- WRITE REG-PRP-SASSE FROM REG-TRAILLER. */
            _.Move(LBFPF991.REG_TRAILLER.GetMoveValues(), REG_PRP_SASSE);

            MOVTO_PRP_SASSE.Write(REG_PRP_SASSE.GetMoveValues().ToString());

            /*" -3544- MOVE 'WRITE REG-TRAILLER - STATUS' TO COMANDO. */
            _.Move("WRITE REG-TRAILLER - STATUS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3546- MOVE SPACES TO REG-STA-SASSE. */
            _.Move("", REG_STA_SASSE);

            /*" -3549- MOVE 'T' TO RT-TIPO-REG OF REG-TRAILLER-STA */
            _.Move("T", LBFCT011.REG_TRAILLER_STA.RT_TIPO_REG);

            /*" -3552- MOVE 'STASASSE' TO RT-NOME-EMPRESA OF REG-TRAILLER-STA */
            _.Move("STASASSE", LBFCT011.REG_TRAILLER_STA.RT_NOME_EMPRESA);

            /*" -3563- COMPUTE RT-QTDE-TOTAL OF REG-TRAILLER-STA = RT-QTDE-TIPO-1 OF REG-TRAILLER-STA + RT-QTDE-TIPO-2 OF REG-TRAILLER-STA + RT-QTDE-TIPO-3 OF REG-TRAILLER-STA + RT-QTDE-TIPO-4 OF REG-TRAILLER-STA + RT-QTDE-TIPO-5 OF REG-TRAILLER-STA + RT-QTDE-TIPO-6 OF REG-TRAILLER-STA + RT-QTDE-TIPO-7 OF REG-TRAILLER-STA + RT-QTDE-TIPO-8 OF REG-TRAILLER-STA + RT-QTDE-TIPO-9 OF REG-TRAILLER-STA. */
            LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL.Value = LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_2 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_4 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_5 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_6 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_7 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_8 + LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_9;

            /*" -3563- WRITE REG-STA-SASSE FROM REG-TRAILLER-STA. */
            _.Move(LBFCT011.REG_TRAILLER_STA.GetMoveValues(), REG_STA_SASSE);

            MOVTO_STA_SASSE.Write(REG_STA_SASSE.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-SECTION */
        private void R1050_00_CONTROLAR_ARQ_ENVIADO_SECTION()
        {
            /*" -3573- MOVE 'R1050-00-CONTROLAR-ARQ-ENVIADO' TO PARAGRAFO. */
            _.Move("R1050-00-CONTROLAR-ARQ-ENVIADO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3575- MOVE 'INSERT ARQUIVOS-SIVPF - PROPOSTA' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF - PROPOSTA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3578- MOVE 'PRPSASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("PRPSASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -3581- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -3585- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO);

            /*" -3588- MOVE RT-QTDE-TOTAL OF REG-TRAILLER TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFPF991.REG_TRAILLER.RT_QTDE_TOTAL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -3591- MOVE RH-NSAS OF REG-HEADER TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -3599- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();

            /*" -3602- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3603- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -3604- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -3606- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -3608- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -3610- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -3612- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -3614- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -3615- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3619- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3621- MOVE 'INSERT ARQUIVOS-SIVPF - STATUS' TO COMANDO. */
            _.Move("INSERT ARQUIVOS-SIVPF - STATUS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3624- MOVE 'STASASSE' TO ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF. */
            _.Move("STASASSE", ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO);

            /*" -3627- MOVE 4 TO ARQSIVPF-SISTEMA-ORIGEM OF DCLARQUIVOS-SIVPF. */
            _.Move(4, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM);

            /*" -3631- MOVE SISTEMAS-DATA-MOV-ABERTO OF DCLSISTEMAS TO ARQSIVPF-DATA-PROCESSAMENTO OF DCLARQUIVOS-SIVPF, ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO);

            /*" -3634- MOVE RH-NSAS OF REG-HEADER-STA TO ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF);

            /*" -3637- MOVE RT-QTDE-TOTAL OF REG-TRAILLER-STA TO ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF. */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TOTAL, ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER);

            /*" -3645- PERFORM R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2 */

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2();

            /*" -3648- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3649- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -3650- DISPLAY '          ERRO INSERT TABELA ARQUIVOS-SIVPF' */
                _.Display($"          ERRO INSERT TABELA ARQUIVOS-SIVPF");

                /*" -3652- DISPLAY '          SIGLA DO ARQIVO..................  ' ARQSIVPF-SIGLA-ARQUIVO OF DCLARQUIVOS-SIVPF */
                _.Display($"          SIGLA DO ARQIVO..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO}");

                /*" -3654- DISPLAY '          NSAS SIVPF.......................  ' ARQSIVPF-NSAS-SIVPF OF DCLARQUIVOS-SIVPF */
                _.Display($"          NSAS SIVPF.......................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF}");

                /*" -3656- DISPLAY '          DATA GERACAO.....................  ' ARQSIVPF-DATA-GERACAO OF DCLARQUIVOS-SIVPF */
                _.Display($"          DATA GERACAO.....................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO}");

                /*" -3658- DISPLAY '          QTDE. REGISTROS..................  ' ARQSIVPF-QTDE-REG-GER OF DCLARQUIVOS-SIVPF */
                _.Display($"          QTDE. REGISTROS..................  {ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER}");

                /*" -3660- DISPLAY '          SQLCODE..........................  ' SQLCODE */
                _.Display($"          SQLCODE..........................  {DB.SQLCODE}");

                /*" -3661- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3661- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-1 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1()
        {
            /*" -3599- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1 = new R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1.Execute(r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1050_SAIDA*/

        [StopWatch]
        /*" R1050-00-CONTROLAR-ARQ-ENVIADO-DB-INSERT-2 */
        public void R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2()
        {
            /*" -3645- EXEC SQL INSERT INTO SEGUROS.ARQUIVOS_SIVPF VALUES (:DCLARQUIVOS-SIVPF.ARQSIVPF-SIGLA-ARQUIVO, :DCLARQUIVOS-SIVPF.ARQSIVPF-SISTEMA-ORIGEM, :DCLARQUIVOS-SIVPF.ARQSIVPF-NSAS-SIVPF, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-GERACAO, :DCLARQUIVOS-SIVPF.ARQSIVPF-QTDE-REG-GER, :DCLARQUIVOS-SIVPF.ARQSIVPF-DATA-PROCESSAMENTO) END-EXEC. */

            var r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2_Insert1 = new R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2_Insert1()
            {
                ARQSIVPF_SIGLA_ARQUIVO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SIGLA_ARQUIVO.ToString(),
                ARQSIVPF_SISTEMA_ORIGEM = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_SISTEMA_ORIGEM.ToString(),
                ARQSIVPF_NSAS_SIVPF = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_NSAS_SIVPF.ToString(),
                ARQSIVPF_DATA_GERACAO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.ToString(),
                ARQSIVPF_QTDE_REG_GER = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_QTDE_REG_GER.ToString(),
                ARQSIVPF_DATA_PROCESSAMENTO = ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.ToString(),
            };

            R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2_Insert1.Execute(r1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2_Insert1);

        }

        [StopWatch]
        /*" R1100-00-GERAR-TOTAIS-SECTION */
        private void R1100_00_GERAR_TOTAIS_SECTION()
        {
            /*" -3672- MOVE 'R1100-00-GERAR-TOTIAS' TO PARAGRAFO. */
            _.Move("R1100-00-GERAR-TOTIAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3674- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3694- COMPUTE W-TOT-GERADO-PRP = W-QTD-LD-TIPO-1 + W-QTD-LD-TIPO-2 + W-QTD-LD-TIPO-3 + W-QTD-LD-TIPO-4 + W-QTD-LD-TIPO-5 + W-QTD-LD-TIPO-6 + W-QTD-LD-TIPO-7 + W-QTD-LD-TIPO-8 + W-QTD-LD-TIPO-9 + W-QTD-LD-TIPO-A + W-QTD-LD-TIPO-B + W-QTD-LD-TIPO-C + W-QTD-LD-TIPO-D + W-QTD-LD-TIPO-E + W-QTD-LD-TIPO-F + W-QTD-LD-TIPO-G + W-QTD-LD-TIPO-H + W-QTD-LD-TIPO-I + W-QTD-LD-TIPO-J. */
            WAREA_AUXILIAR.W_TOT_GERADO_PRP.Value = WAREA_AUXILIAR.W_QTD_LD_TIPO_1 + WAREA_AUXILIAR.W_QTD_LD_TIPO_2 + WAREA_AUXILIAR.W_QTD_LD_TIPO_3 + WAREA_AUXILIAR.W_QTD_LD_TIPO_4 + WAREA_AUXILIAR.W_QTD_LD_TIPO_5 + WAREA_AUXILIAR.W_QTD_LD_TIPO_6 + WAREA_AUXILIAR.W_QTD_LD_TIPO_7 + WAREA_AUXILIAR.W_QTD_LD_TIPO_8 + WAREA_AUXILIAR.W_QTD_LD_TIPO_9 + WAREA_AUXILIAR.W_QTD_LD_TIPO_A + WAREA_AUXILIAR.W_QTD_LD_TIPO_B + WAREA_AUXILIAR.W_QTD_LD_TIPO_C + WAREA_AUXILIAR.W_QTD_LD_TIPO_D + WAREA_AUXILIAR.W_QTD_LD_TIPO_E + WAREA_AUXILIAR.W_QTD_LD_TIPO_F + WAREA_AUXILIAR.W_QTD_LD_TIPO_G + WAREA_AUXILIAR.W_QTD_LD_TIPO_H + WAREA_AUXILIAR.W_QTD_LD_TIPO_I + WAREA_AUXILIAR.W_QTD_LD_TIPO_J;

            /*" -3695- DISPLAY 'PF0642B - TOTAIS DO PROCESSAMENTO' */
            _.Display($"PF0642B - TOTAIS DO PROCESSAMENTO");

            /*" -3696- DISPLAY '          TOTAL  REGISTROS LIDOS........... ' W-NSL */
            _.Display($"          TOTAL  REGISTROS LIDOS........... {WAREA_AUXILIAR.W_NSL}");

            /*" -3698- DISPLAY '          TOTAL  DESPREZADO-01............. ' W-DESPREZADO-01 */
            _.Display($"          TOTAL  DESPREZADO-01............. {WAREA_AUXILIAR.W_DESPREZADO_01}");

            /*" -3700- DISPLAY '          TOTAL  DESPREZADO-02............. ' W-DESPREZADO-02 */
            _.Display($"          TOTAL  DESPREZADO-02............. {WAREA_AUXILIAR.W_DESPREZADO_02}");

            /*" -3702- DISPLAY '          TOTAL  DESPREZADO-03............. ' W-DESPREZADO-03 */
            _.Display($"          TOTAL  DESPREZADO-03............. {WAREA_AUXILIAR.W_DESPREZADO_03}");

            /*" -3704- DISPLAY '          TOTAL  DESPREZADO-04............. ' W-DESPREZADO-04 */
            _.Display($"          TOTAL  DESPREZADO-04............. {WAREA_AUXILIAR.W_DESPREZADO_04}");

            /*" -3706- DISPLAY '          TOTAL  DESPREZADO-05............. ' W-DESPREZADO-05 */
            _.Display($"          TOTAL  DESPREZADO-05............. {WAREA_AUXILIAR.W_DESPREZADO_05}");

            /*" -3708- DISPLAY '          TOTAL  DESPREZADO-06............. ' W-DESPREZADO-06 */
            _.Display($"          TOTAL  DESPREZADO-06............. {WAREA_AUXILIAR.W_DESPREZADO_06}");

            /*" -3710- DISPLAY '          TOTAL  DESPREZADO-07............. ' W-DESPREZADO-07 */
            _.Display($"          TOTAL  DESPREZADO-07............. {WAREA_AUXILIAR.W_DESPREZADO_07}");

            /*" -3712- DISPLAY '          TOTAL  DESPREZADO-08............. ' W-DESPREZADO-08 */
            _.Display($"          TOTAL  DESPREZADO-08............. {WAREA_AUXILIAR.W_DESPREZADO_08}");

            /*" -3714- DISPLAY '          TOTAL  DESPREZADO-09............. ' W-DESPREZADO-09 */
            _.Display($"          TOTAL  DESPREZADO-09............. {WAREA_AUXILIAR.W_DESPREZADO_09}");

            /*" -3716- DISPLAY '          TOTAL  DESPREZADO-10............. ' W-DESPREZADO-10 */
            _.Display($"          TOTAL  DESPREZADO-10............. {WAREA_AUXILIAR.W_DESPREZADO_10}");

            /*" -3718- DISPLAY '          TOTAL  DESPREZADO-11............. ' W-DESPREZADO-11 */
            _.Display($"          TOTAL  DESPREZADO-11............. {WAREA_AUXILIAR.W_DESPREZADO_11}");

            /*" -3720- DISPLAY '          TOTAL  GERADO ARQUIVO PROPOSTA... ' RT-QTDE-TIPO-1 OF REG-TRAILLER */
            _.Display($"          TOTAL  GERADO ARQUIVO PROPOSTA... {LBFPF991.REG_TRAILLER.RT_QTDE_TIPO_1}");

            /*" -3721- DISPLAY '          TOTAL  GERADO ARQUIVO STATUS..... ' RT-QTDE-TIPO-1 OF REG-TRAILLER-STA. */
            _.Display($"          TOTAL  GERADO ARQUIVO STATUS..... {LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_SAIDA*/

        [StopWatch]
        /*" R3000-GERAR-TB-CORPORATIVAS-SECTION */
        private void R3000_GERAR_TB_CORPORATIVAS_SECTION()
        {
            /*" -3730- PERFORM R3100-TRATA-CLIENTE. */

            R3100_TRATA_CLIENTE_SECTION();

            /*" -3731- PERFORM R3200-TRATA-END-TEL */

            R3200_TRATA_END_TEL_SECTION();

            /*" -3731- PERFORM R3300-TRATA-PROPOSTA. */

            R3300_TRATA_PROPOSTA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3000_SAIDA*/

        [StopWatch]
        /*" R3100-TRATA-CLIENTE-SECTION */
        private void R3100_TRATA_CLIENTE_SECTION()
        {
            /*" -3741- MOVE 'R3100-TRATA-CLIENTE' TO PARAGRAFO. */
            _.Move("R3100-TRATA-CLIENTE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3751- MOVE '    ' TO COMANDO. */
            _.Move("    ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3753- PERFORM R3110-LER-PESSOA-JURIDICA. */

            R3110_LER_PESSOA_JURIDICA_SECTION();

            /*" -3754- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -3755- PERFORM R3115-INCLUIR-TAB-CORPORATIVAS */

                R3115_INCLUIR_TAB_CORPORATIVAS_SECTION();

                /*" -3756- ELSE */
            }
            else
            {


                /*" -3757- IF SQLCODE EQUAL 00 */

                if (DB.SQLCODE == 00)
                {

                    /*" -3760- PERFORM R3150-LER-TAB-CORPORATIVAS */

                    R3150_LER_TAB_CORPORATIVAS_SECTION();

                    /*" -3760- PERFORM R3135-INCLUIR-END-EMAIL. */

                    R3135_INCLUIR_END_EMAIL_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_SAIDA*/

        [StopWatch]
        /*" R3110-LER-PESSOA-JURIDICA-SECTION */
        private void R3110_LER_PESSOA_JURIDICA_SECTION()
        {
            /*" -3770- MOVE 'R3110-LER-PESSOA-JURIDICA' TO PARAGRAFO. */
            _.Move("R3110-LER-PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3772- MOVE 'SELECT' TO COMANDO. */
            _.Move("SELECT", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3775- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -3789- PERFORM R3110_LER_PESSOA_JURIDICA_DB_SELECT_1 */

            R3110_LER_PESSOA_JURIDICA_DB_SELECT_1();

            /*" -3792- IF SQLCODE NOT EQUAL 00 AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -3793- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -3794- DISPLAY '          ERRO NO ACESSO A PESSOA-JURIDICA' */
                _.Display($"          ERRO NO ACESSO A PESSOA-JURIDICA");

                /*" -3796- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3798- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3799- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3799- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3110-LER-PESSOA-JURIDICA-DB-SELECT-1 */
        public void R3110_LER_PESSOA_JURIDICA_DB_SELECT_1()
        {
            /*" -3789- EXEC SQL SELECT COD_PESSOA, CGC, NOME_FANTASIA, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, :DCLPESSOA-JURIDICA.TIMESTAMP FROM SEGUROS.PESSOA_JURIDICA WHERE CGC = :DCLPESSOA-JURIDICA.CGC WITH UR END-EXEC. */

            var r3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1 = new R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1()
            {
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
            };

            var executed_1 = R3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1.Execute(r3110_LER_PESSOA_JURIDICA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);
                _.Move(executed_1.CGC, PESJUR.DCLPESSOA_JURIDICA.CGC);
                _.Move(executed_1.NOME_FANTASIA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);
                _.Move(executed_1.COD_USUARIO, PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);
                _.Move(executed_1.TIMESTAMP, PESJUR.DCLPESSOA_JURIDICA.TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_SAIDA*/

        [StopWatch]
        /*" R3115-INCLUIR-TAB-CORPORATIVAS-SECTION */
        private void R3115_INCLUIR_TAB_CORPORATIVAS_SECTION()
        {
            /*" -3808- MOVE 'R3115-INCLUIR-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R3115-INCLUIR-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3810- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3812- PERFORM R3120-INCLUIR-TAB-PESSOA. */

            R3120_INCLUIR_TAB_PESSOA_SECTION();

            /*" -3814- PERFORM R3130-INCLUIR-PESSOA-JURIDICA. */

            R3130_INCLUIR_PESSOA_JURIDICA_SECTION();

            /*" -3814- PERFORM R3135-INCLUIR-END-EMAIL. */

            R3135_INCLUIR_END_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3115_SAIDA*/

        [StopWatch]
        /*" R3120-INCLUIR-TAB-PESSOA-SECTION */
        private void R3120_INCLUIR_TAB_PESSOA_SECTION()
        {
            /*" -3824- MOVE 'R3120-INCLUIR-TAB-PESSOA' TO PARAGRAFO. */
            _.Move("R3120-INCLUIR-TAB-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3826- MOVE '      ' TO COMANDO. */
            _.Move("      ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3827- IF W-OBTER-MAX-PESSOA EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_OBTER_MAX_PESSOA == "NAO")
            {

                /*" -3828- MOVE 'SIM' TO W-OBTER-MAX-PESSOA */
                _.Move("SIM", WAREA_AUXILIAR.W_OBTER_MAX_PESSOA);

                /*" -3830- PERFORM R3121-OBTER-MAX-COD-PESSOA. */

                R3121_OBTER_MAX_COD_PESSOA_SECTION();
            }


            /*" -3833- COMPUTE W-COD-PESSOA = W-COD-PESSOA + 1 */
            WAREA_AUXILIAR.W_COD_PESSOA.Value = WAREA_AUXILIAR.W_COD_PESSOA + 1;

            /*" -3836- MOVE W-COD-PESSOA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
            _.Move(WAREA_AUXILIAR.W_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

            /*" -3839- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO PESSOA-NOME-PESSOA OF DCLPESSOA. */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -3842- MOVE ' ' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
            _.Move(" ", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

            /*" -3843- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 1 */

            if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 1)
            {

                /*" -3845- MOVE 'F' TO PESSOA-TIPO-PESSOA OF DCLPESSOA */
                _.Move("F", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

                /*" -3846- ELSE */
            }
            else
            {


                /*" -3847- IF R1-TIPO-PESSOA OF REG-CLIENTES EQUAL 2 */

                if (LBFPF011.REG_CLIENTES.R1_TIPO_PESSOA == 2)
                {

                    /*" -3850- MOVE 'J' TO PESSOA-TIPO-PESSOA OF DCLPESSOA. */
                    _.Move("J", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                }

            }


            /*" -3853- MOVE 'PF0642B' TO PESSOA-COD-USUARIO OF DCLPESSOA. */
            _.Move("PF0642B", PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);

            /*" -3861- PERFORM R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1 */

            R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1();

            /*" -3864- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3865- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -3866- DISPLAY '          ERRO INSERT DA TABELA PESSOA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA");

                /*" -3868- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -3870- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -3872- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3874- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3875- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3875- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3120-INCLUIR-TAB-PESSOA-DB-INSERT-1 */
        public void R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1()
        {
            /*" -3861- EXEC SQL INSERT INTO SEGUROS.PESSOA VALUES (:DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, CURRENT TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO, :DCLPESSOA.PESSOA-TIPO-PESSOA, NULL) END-EXEC. */

            var r3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1 = new R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                PESSOA_COD_USUARIO = PESSOA.DCLPESSOA.PESSOA_COD_USUARIO.ToString(),
                PESSOA_TIPO_PESSOA = PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA.ToString(),
            };

            R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1.Execute(r3120_INCLUIR_TAB_PESSOA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_SAIDA*/

        [StopWatch]
        /*" R3121-OBTER-MAX-COD-PESSOA-SECTION */
        private void R3121_OBTER_MAX_COD_PESSOA_SECTION()
        {
            /*" -3885- MOVE 'R3121-OBTER-MAX-COD-PESSOA' TO PARAGRAFO. */
            _.Move("R3121-OBTER-MAX-COD-PESSOA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3887- MOVE 'MAX SEGUROS.PESSOA' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3892- PERFORM R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1 */

            R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1();

            /*" -3895- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3896- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -3897- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA");

                /*" -3899- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3901- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3902- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3904- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -3905- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO W-COD-PESSOA. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, WAREA_AUXILIAR.W_COD_PESSOA);

        }

        [StopWatch]
        /*" R3121-OBTER-MAX-COD-PESSOA-DB-SELECT-1 */
        public void R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1()
        {
            /*" -3892- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) INTO :DCLPESSOA.PESSOA-COD-PESSOA FROM SEGUROS.PESSOA WITH UR END-EXEC. */

            var r3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1 = new R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1.Execute(r3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3121_SAIDA*/

        [StopWatch]
        /*" R3130-INCLUIR-PESSOA-JURIDICA-SECTION */
        private void R3130_INCLUIR_PESSOA_JURIDICA_SECTION()
        {
            /*" -3915- MOVE 'R3130-INCLUIR-PESSOAS-JURIDICA' TO PARAGRAFO. */
            _.Move("R3130-INCLUIR-PESSOAS-JURIDICA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3917- MOVE 'INSERT PESSOA-JURIDICA' TO COMANDO. */
            _.Move("INSERT PESSOA-JURIDICA", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3920- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-JURIDICA */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA);

            /*" -3923- MOVE R1-CGC-CPF OF REG-CLIENTES TO CGC OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_CGC_CPF, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -3926- MOVE R1-NOME-PESSOA OF REG-CLIENTES TO NOME-FANTASIA OF DCLPESSOA-JURIDICA */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_PESSOA, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);

            /*" -3930- MOVE 'PF0642B' TO COD-USUARIO OF DCLPESSOA-JURIDICA */
            _.Move("PF0642B", PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);

            /*" -3937- PERFORM R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1 */

            R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1();

            /*" -3940- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -3941- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -3942- DISPLAY '          ERRO INSERT DA TABELA PESSOA JURIDICA' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA JURIDICA");

                /*" -3944- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-JURIDICA */
                _.Display($"          CODIGO PESSOA.................  {PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA}");

                /*" -3946- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3948- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3949- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3949- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3130-INCLUIR-PESSOA-JURIDICA-DB-INSERT-1 */
        public void R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1()
        {
            /*" -3937- EXEC SQL INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES (:DCLPESSOA-JURIDICA.COD-PESSOA, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1 = new R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA.ToString(),
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
                NOME_FANTASIA = PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA.ToString(),
                COD_USUARIO = PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO.ToString(),
            };

            R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1.Execute(r3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3130_SAIDA*/

        [StopWatch]
        /*" R3136-RELACIONA-EMAIL-SECTION */
        private void R3136_RELACIONA_EMAIL_SECTION()
        {
            /*" -3959- MOVE 'R3136-RELACIONA-EMAIL' TO PARAGRAFO. */
            _.Move("R3136-RELACIONA-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3961- MOVE 'DECLARE PESSOA-EMAIL' TO COMANDO. */
            _.Move("DECLARE PESSOA-EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -3964- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -3974- PERFORM R3136_RELACIONA_EMAIL_DB_DECLARE_1 */

            R3136_RELACIONA_EMAIL_DB_DECLARE_1();

            /*" -3978- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -3979- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -3980- DISPLAY '          ERRO DECLARE DA TABELA PESSOA EMAIL' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA EMAIL");

                /*" -3982- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -3984- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -3986- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -3987- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -3987- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3136_SAIDA*/

        [StopWatch]
        /*" R3135-INCLUIR-END-EMAIL-SECTION */
        private void R3135_INCLUIR_END_EMAIL_SECTION()
        {
            /*" -3996- MOVE 'R3135-INCLUIR-END-EMAIL' TO PARAGRAFO. */
            _.Move("R3135-INCLUIR-END-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -3998- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4000- PERFORM R3136-RELACIONA-EMAIL. */

            R3136_RELACIONA_EMAIL_SECTION();

            /*" -4002- MOVE 'OPEN CURSOR EMAIL' TO COMANDO. */
            _.Move("OPEN CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4002- PERFORM R3135_INCLUIR_END_EMAIL_DB_OPEN_1 */

            R3135_INCLUIR_END_EMAIL_DB_OPEN_1();

            /*" -4006- MOVE 'NAO' TO W-ACHOU-EMAIL. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_EMAIL);

            /*" -4008- MOVE SPACES TO W-FIM-CURSOR-EMAIL. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

            /*" -4010- PERFORM R3137-FETCH-EMAIL */

            R3137_FETCH_EMAIL_SECTION();

            /*" -4011- IF W-FIM-CURSOR-EMAIL EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM")
            {

                /*" -4012- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

                if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
                {

                    /*" -4014- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
                }

            }


            /*" -4017- PERFORM R3138-VERIFICA-EXISTE-EMAIL UNTIL W-FIM-CURSOR-EMAIL EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL == "SIM"))
            {

                R3138_VERIFICA_EXISTE_EMAIL_SECTION();
            }

            /*" -4018- IF W-ACHOU-EMAIL EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_EMAIL == "NAO")
            {

                /*" -4018- PERFORM R3139-INCLUIR-NOVO-EMAIL. */

                R3139_INCLUIR_NOVO_EMAIL_SECTION();
            }


        }

        [StopWatch]
        /*" R3135-INCLUIR-END-EMAIL-DB-OPEN-1 */
        public void R3135_INCLUIR_END_EMAIL_DB_OPEN_1()
        {
            /*" -4002- EXEC SQL OPEN EMAIL END-EXEC. */

            EMAIL.Open();

        }

        [StopWatch]
        /*" R3205-RELACIONA-ENDERECO-DB-DECLARE-1 */
        public void R3205_RELACIONA_ENDERECO_DB_DECLARE_1()
        {
            /*" -4363- EXEC SQL DECLARE ENDERECOS CURSOR FOR SELECT OCORR_ENDERECO, COD_PESSOA, ENDERECO, TIPO_ENDER, BAIRRO, CEP, CIDADE, SIGLA_UF, SITUACAO_ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA ORDER BY OCORR_ENDERECO WITH UR END-EXEC. */
            ENDERECOS = new PF0642B_ENDERECOS(true);
            string GetQuery_ENDERECOS()
            {
                var query = @$"SELECT OCORR_ENDERECO
							, 
							COD_PESSOA
							, 
							ENDERECO
							, 
							TIPO_ENDER
							, 
							BAIRRO
							, 
							CEP
							, 
							CIDADE
							, 
							SIGLA_UF
							, 
							SITUACAO_ENDERECO 
							FROM SEGUROS.PESSOA_ENDERECO 
							WHERE COD_PESSOA = '{PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}' 
							ORDER BY OCORR_ENDERECO";

                return query;
            }
            ENDERECOS.GetQueryEvent += GetQuery_ENDERECOS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3135_SAIDA*/

        [StopWatch]
        /*" R3137-FETCH-EMAIL-SECTION */
        private void R3137_FETCH_EMAIL_SECTION()
        {
            /*" -4028- MOVE 'R3137-FETCH-EMAIL' TO PARAGRAFO. */
            _.Move("R3137-FETCH-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4030- MOVE 'FETCH CURSOR EMAIL' TO COMANDO. */
            _.Move("FETCH CURSOR EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4036- PERFORM R3137_FETCH_EMAIL_DB_FETCH_1 */

            R3137_FETCH_EMAIL_DB_FETCH_1();

            /*" -4039- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4040- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4041- MOVE 'SIM' TO W-FIM-CURSOR-EMAIL */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_EMAIL);

                    /*" -4041- PERFORM R3137_FETCH_EMAIL_DB_CLOSE_1 */

                    R3137_FETCH_EMAIL_DB_CLOSE_1();

                    /*" -4043- ELSE */
                }
                else
                {


                    /*" -4044- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -4045- DISPLAY '          ERRO FETCH CURSOR EMAIL' */
                    _.Display($"          ERRO FETCH CURSOR EMAIL");

                    /*" -4047- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                    _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                    /*" -4049- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                    /*" -4051- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4052- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4052- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3137-FETCH-EMAIL-DB-FETCH-1 */
        public void R3137_FETCH_EMAIL_DB_FETCH_1()
        {
            /*" -4036- EXEC SQL FETCH EMAIL INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL END-EXEC. */

            if (EMAIL.Fetch())
            {
                _.Move(EMAIL.DCLPESSOA_EMAIL_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);
                _.Move(EMAIL.DCLPESSOA_EMAIL_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
                _.Move(EMAIL.DCLPESSOA_EMAIL_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
                _.Move(EMAIL.DCLPESSOA_EMAIL_SITUACAO_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);
            }

        }

        [StopWatch]
        /*" R3137-FETCH-EMAIL-DB-CLOSE-1 */
        public void R3137_FETCH_EMAIL_DB_CLOSE_1()
        {
            /*" -4041- EXEC SQL CLOSE EMAIL END-EXEC */

            EMAIL.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3137_SAIDA*/

        [StopWatch]
        /*" R3138-VERIFICA-EXISTE-EMAIL-SECTION */
        private void R3138_VERIFICA_EXISTE_EMAIL_SECTION()
        {
            /*" -4062- MOVE 'R3138-VERIFICA-EXISTE-EMAIL' TO PARAGRAFO. */
            _.Move("R3138-VERIFICA-EXISTE-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4064- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4066- IF R1-EMAIL OF REG-CLIENTES EQUAL EMAIL OF DCLPESSOA-EMAIL */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL == PESEMAIL.DCLPESSOA_EMAIL.EMAIL)
            {

                /*" -4068- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -4069- IF R1-EMAIL OF REG-CLIENTES EQUAL SPACES */

            if (LBFPF011.REG_CLIENTES.R1_EMAIL.IsEmpty())
            {

                /*" -4071- MOVE 'SIM' TO W-ACHOU-EMAIL. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_EMAIL);
            }


            /*" -4071- PERFORM R3137-FETCH-EMAIL. */

            R3137_FETCH_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3138_SAIDA*/

        [StopWatch]
        /*" R3139-INCLUIR-NOVO-EMAIL-SECTION */
        private void R3139_INCLUIR_NOVO_EMAIL_SECTION()
        {
            /*" -4081- MOVE 'R3139-INCLUIR-NOVO-EMAIL' TO PARAGRAFO. */
            _.Move("R3139-INCLUIR-NOVO-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4090- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4093- MOVE SEQ-EMAIL OF DCLPESSOA-EMAIL TO W-SEQ-EMAIL */
            _.Move(PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL, WAREA_AUXILIAR.W_SEQ_EMAIL);

            /*" -4095- COMPUTE W-SEQ-EMAIL = W-SEQ-EMAIL + 1. */
            WAREA_AUXILIAR.W_SEQ_EMAIL.Value = WAREA_AUXILIAR.W_SEQ_EMAIL + 1;

            /*" -4095- PERFORM R3141-INCLUIR-EMAIL. */

            R3141_INCLUIR_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3139_SAIDA*/

        [StopWatch]
        /*" R3140-OBTER-MAX-EMAIL-SECTION */
        private void R3140_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -4105- MOVE 'R3140-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R3140-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4107- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4110- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -4116- PERFORM R3140_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R3140_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -4119- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4120- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -4121- DISPLAY '          ERRO NO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO NO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -4123- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4125- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4126- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4126- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3140-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R3140_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -4116- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

            var r3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 = new R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1.Execute(r3140_OBTER_MAX_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3140_SAIDA*/

        [StopWatch]
        /*" R3141-INCLUIR-EMAIL-SECTION */
        private void R3141_INCLUIR_EMAIL_SECTION()
        {
            /*" -4135- MOVE 'R3141-INCLUI-EMAIL' TO PARAGRAFO. */
            _.Move("R3141-INCLUI-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4137- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4140- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -4143- MOVE W-SEQ-EMAIL TO SEQ-EMAIL OF DCLPESSOA-EMAIL. */
            _.Move(WAREA_AUXILIAR.W_SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);

            /*" -4146- MOVE R1-EMAIL OF REG-CLIENTES TO EMAIL OF DCLPESSOA-EMAIL */
            _.Move(LBFPF011.REG_CLIENTES.R1_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -4149- MOVE 'A' TO SITUACAO-EMAIL OF DCLPESSOA-EMAIL */
            _.Move("A", PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);

            /*" -4153- MOVE 'PF0642B' TO COD-USUARIO OF DCLPESSOA-EMAIL. */
            _.Move("PF0642B", PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);

            /*" -4161- PERFORM R3141_INCLUIR_EMAIL_DB_INSERT_1 */

            R3141_INCLUIR_EMAIL_DB_INSERT_1();

            /*" -4164- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4165- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -4166- DISPLAY '          ERRO INSERT DA TABELA PESSOA-EMAIL' */
                _.Display($"          ERRO INSERT DA TABELA PESSOA-EMAIL");

                /*" -4168- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -4170- DISPLAY '          NOME DA PESSOA................  ' PESSOA-NOME-PESSOA OF DCLPESSOA */
                _.Display($"          NOME DA PESSOA................  {PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA}");

                /*" -4172- DISPLAY '          NUMERO PROPOSTA...............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4174- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4175- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4175- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3141-INCLUIR-EMAIL-DB-INSERT-1 */
        public void R3141_INCLUIR_EMAIL_DB_INSERT_1()
        {
            /*" -4161- EXEC SQL INSERT INTO SEGUROS.PESSOA_EMAIL VALUES (:DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1 = new R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
                SITUACAO_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL.ToString(),
                COD_USUARIO = PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO.ToString(),
            };

            R3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1.Execute(r3141_INCLUIR_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3141_SAIDA*/

        [StopWatch]
        /*" R3150-LER-TAB-CORPORATIVAS-SECTION */
        private void R3150_LER_TAB_CORPORATIVAS_SECTION()
        {
            /*" -4185- MOVE 'R3150-LER-TAB-CORPORATIVAS' TO PARAGRAFO. */
            _.Move("R3150-LER-TAB-CORPORATIVAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4187- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4190- MOVE COD-PESSOA OF DCLPESSOA-JURIDICA TO PESSOA-COD-PESSOA OF DCLPESSOA. */
            _.Move(PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);

            /*" -4192- PERFORM R3155-LER-TAB-PESSOA. */

            R3155_LER_TAB_PESSOA_SECTION();

            /*" -4192- PERFORM R3160-LER-TAB-EMAIL. */

            R3160_LER_TAB_EMAIL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3150_SAIDA*/

        [StopWatch]
        /*" R3155-LER-TAB-PESSOA-SECTION */
        private void R3155_LER_TAB_PESSOA_SECTION()
        {
            /*" -4202- MOVE 'R3150-LER-TAB-PESSOAS' TO PARAGRAFO. */
            _.Move("R3150-LER-TAB-PESSOAS", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4204- MOVE 'SELECT SEGUROS.PESSOAS' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOAS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4218- PERFORM R3155_LER_TAB_PESSOA_DB_SELECT_1 */

            R3155_LER_TAB_PESSOA_DB_SELECT_1();

            /*" -4221- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4222- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -4223- DISPLAY '          ERRO ACESSO TAB. SEGUROS.PESSOA' */
                _.Display($"          ERRO ACESSO TAB. SEGUROS.PESSOA");

                /*" -4225- DISPLAY '          CODIGO PESSOA.................  ' PESSOA-COD-PESSOA OF DCLPESSOA */
                _.Display($"          CODIGO PESSOA.................  {PESSOA.DCLPESSOA.PESSOA_COD_PESSOA}");

                /*" -4227- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4228- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4228- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3155-LER-TAB-PESSOA-DB-SELECT-1 */
        public void R3155_LER_TAB_PESSOA_DB_SELECT_1()
        {
            /*" -4218- EXEC SQL SELECT COD_PESSOA, NOME_PESSOA, TIPO_PESSOA, TIMESTAMP, COD_USUARIO INTO :DCLPESSOA.PESSOA-COD-PESSOA, :DCLPESSOA.PESSOA-NOME-PESSOA, :DCLPESSOA.PESSOA-TIPO-PESSOA, :DCLPESSOA.PESSOA-TIMESTAMP, :DCLPESSOA.PESSOA-COD-USUARIO FROM SEGUROS.PESSOA WHERE COD_PESSOA = :DCLPESSOA.PESSOA-COD-PESSOA WITH UR END-EXEC. */

            var r3155_LER_TAB_PESSOA_DB_SELECT_1_Query1 = new R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1()
            {
                PESSOA_COD_PESSOA = PESSOA.DCLPESSOA.PESSOA_COD_PESSOA.ToString(),
            };

            var executed_1 = R3155_LER_TAB_PESSOA_DB_SELECT_1_Query1.Execute(r3155_LER_TAB_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PESSOA_COD_PESSOA, PESSOA.DCLPESSOA.PESSOA_COD_PESSOA);
                _.Move(executed_1.PESSOA_NOME_PESSOA, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);
                _.Move(executed_1.PESSOA_TIPO_PESSOA, PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);
                _.Move(executed_1.PESSOA_TIMESTAMP, PESSOA.DCLPESSOA.PESSOA_TIMESTAMP);
                _.Move(executed_1.PESSOA_COD_USUARIO, PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3155_SAIDA*/

        [StopWatch]
        /*" R3160-LER-TAB-EMAIL-SECTION */
        private void R3160_LER_TAB_EMAIL_SECTION()
        {
            /*" -4237- MOVE 'R3160-LER-TAB-EMAIL' TO PARAGRAFO. */
            _.Move("R3160-LER-TAB-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4239- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4241- PERFORM R3165-OBTER-MAX-EMAIL. */

            R3165_OBTER_MAX_EMAIL_SECTION();

            /*" -4241- PERFORM R3170-LER-EMAIL-ATUAL. */

            R3170_LER_EMAIL_ATUAL_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3160_SAIDA*/

        [StopWatch]
        /*" R3165-OBTER-MAX-EMAIL-SECTION */
        private void R3165_OBTER_MAX_EMAIL_SECTION()
        {
            /*" -4251- MOVE 'R3165-OBTER-MAX-EMAIL' TO PARAGRAFO. */
            _.Move("R3165-OBTER-MAX-EMAIL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4253- MOVE 'MAX SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4256- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -4262- PERFORM R3165_OBTER_MAX_EMAIL_DB_SELECT_1 */

            R3165_OBTER_MAX_EMAIL_DB_SELECT_1();

            /*" -4265- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4266- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -4267- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-EMAIL");

                /*" -4269- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -4271- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4272- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4272- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3165-OBTER-MAX-EMAIL-DB-SELECT-1 */
        public void R3165_OBTER_MAX_EMAIL_DB_SELECT_1()
        {
            /*" -4262- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :DCLPESSOA-EMAIL.SEQ-EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA WITH UR END-EXEC. */

            var r3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1 = new R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
            };

            var executed_1 = R3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1.Execute(r3165_OBTER_MAX_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3165_SAIDA*/

        [StopWatch]
        /*" R3170-LER-EMAIL-ATUAL-SECTION */
        private void R3170_LER_EMAIL_ATUAL_SECTION()
        {
            /*" -4282- MOVE 'R3170-LER-EMAIL-ATUAL' TO PARAGRAFO. */
            _.Move("R3170-LER-EMAIL-ATUAL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4284- MOVE 'SELECT SEGUROS.PESSOA_EMAIL' TO COMANDO. */
            _.Move("SELECT SEGUROS.PESSOA_EMAIL", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4287- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-EMAIL. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);

            /*" -4304- PERFORM R3170_LER_EMAIL_ATUAL_DB_SELECT_1 */

            R3170_LER_EMAIL_ATUAL_DB_SELECT_1();

            /*" -4308- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4309- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -4310- DISPLAY '          ERRO SELECT TAB. PESSOA-EMAIL' */
                _.Display($"          ERRO SELECT TAB. PESSOA-EMAIL");

                /*" -4312- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-EMAIL */
                _.Display($"          CODIGO PESSOA.................  {PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA}");

                /*" -4314- DISPLAY '          SEQUENCIAEMAIL................  ' SEQ-EMAIL OF DCLPESSOA-EMAIL */
                _.Display($"          SEQUENCIAEMAIL................  {PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL}");

                /*" -4316- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4317- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4317- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3170-LER-EMAIL-ATUAL-DB-SELECT-1 */
        public void R3170_LER_EMAIL_ATUAL_DB_SELECT_1()
        {
            /*" -4304- EXEC SQL SELECT COD_PESSOA, SEQ_EMAIL, EMAIL, SITUACAO_EMAIL, COD_USUARIO, TIMESTAMP INTO :DCLPESSOA-EMAIL.COD-PESSOA, :DCLPESSOA-EMAIL.SEQ-EMAIL, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, :DCLPESSOA-EMAIL.TIMESTAMP FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :DCLPESSOA-EMAIL.COD-PESSOA AND SEQ_EMAIL = :DCLPESSOA-EMAIL.SEQ-EMAIL WITH UR END-EXEC. */

            var r3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1 = new R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA.ToString(),
                SEQ_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL.ToString(),
            };

            var executed_1 = R3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1.Execute(r3170_LER_EMAIL_ATUAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, PESEMAIL.DCLPESSOA_EMAIL.COD_PESSOA);
                _.Move(executed_1.SEQ_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SEQ_EMAIL);
                _.Move(executed_1.EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
                _.Move(executed_1.SITUACAO_EMAIL, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);
                _.Move(executed_1.COD_USUARIO, PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);
                _.Move(executed_1.TIMESTAMP, PESEMAIL.DCLPESSOA_EMAIL.TIMESTAMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3170_SAIDA*/

        [StopWatch]
        /*" R3200-TRATA-END-TEL-SECTION */
        private void R3200_TRATA_END_TEL_SECTION()
        {
            /*" -4327- MOVE 'R3200-TRATA-END-TEL' TO PARAGRAFO. */
            _.Move("R3200-TRATA-END-TEL", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4329- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4331- PERFORM R3201-TRATA-ENDERECO. */

            R3201_TRATA_ENDERECO_SECTION();

            /*" -4333- MOVE ZEROS TO W-INDEX. */
            _.Move(0, WAREA_AUXILIAR.W_INDEX);

            /*" -4333- PERFORM R3250-TRATA-TELEFONES 4 TIMES. */

            for (int i = 0; i < 4; i++)
            {

                R3250_TRATA_TELEFONES_SECTION();

            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_SAIDA*/

        [StopWatch]
        /*" R3205-RELACIONA-ENDERECO-SECTION */
        private void R3205_RELACIONA_ENDERECO_SECTION()
        {
            /*" -4343- MOVE 'R3205-RELACIONA-ENDERECO' TO PARAGRAFO. */
            _.Move("R3205-RELACIONA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4345- MOVE 'DECLARE PESSOA-ENDERECO' TO COMANDO. */
            _.Move("DECLARE PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4348- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -4363- PERFORM R3205_RELACIONA_ENDERECO_DB_DECLARE_1 */

            R3205_RELACIONA_ENDERECO_DB_DECLARE_1();

            /*" -4367- IF SQLCODE NOT EQUAL 00 AND SQLCODE NOT EQUAL 100 */

            if (DB.SQLCODE != 00 && DB.SQLCODE != 100)
            {

                /*" -4368- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -4369- DISPLAY '          ERRO DECLARE DA TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO DECLARE DA TABELA PESSOA-ENDERECO");

                /*" -4371- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -4373- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -4375- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4376- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4376- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3205_SAIDA*/

        [StopWatch]
        /*" R3201-TRATA-ENDERECO-SECTION */
        private void R3201_TRATA_ENDERECO_SECTION()
        {
            /*" -4386- MOVE 'R3201-TRATA-ENDERECO' TO PARAGRAFO. */
            _.Move("R3201-TRATA-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4388- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4392- MOVE ZEROS TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO, W-OCORR-ENDERECO. */
            _.Move(0, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -4394- PERFORM R3205-RELACIONA-ENDERECO. */

            R3205_RELACIONA_ENDERECO_SECTION();

            /*" -4396- MOVE 'OPEN CURSOR ENDERECOS' TO COMANDO. */
            _.Move("OPEN CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4396- PERFORM R3201_TRATA_ENDERECO_DB_OPEN_1 */

            R3201_TRATA_ENDERECO_DB_OPEN_1();

            /*" -4400- MOVE 'NAO' TO W-ACHOU-ENDERECO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_ENDERECO);

            /*" -4402- MOVE SPACES TO W-FIM-CURSOR-ENDERECO. */
            _.Move("", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

            /*" -4404- PERFORM R3210-FETCH-ENDERECO. */

            R3210_FETCH_ENDERECO_SECTION();

            /*" -4405- IF W-FIM-CURSOR-ENDERECO EQUAL 'SIM' */

            if (WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM")
            {

                /*" -4408- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

                if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
                {

                    /*" -4410- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                    _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
                }

            }


            /*" -4413- PERFORM R3215-VERIFICA-EXISTE-ENDERECO UNTIL W-FIM-CURSOR-ENDERECO EQUAL 'SIM' . */

            while (!(WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO == "SIM"))
            {

                R3215_VERIFICA_EXISTE_ENDERECO_SECTION();
            }

            /*" -4414- IF W-ACHOU-ENDERECO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_ENDERECO == "NAO")
            {

                /*" -4414- PERFORM R3220-INCLUIR-NOVO-ENDERECO. */

                R3220_INCLUIR_NOVO_ENDERECO_SECTION();
            }


        }

        [StopWatch]
        /*" R3201-TRATA-ENDERECO-DB-OPEN-1 */
        public void R3201_TRATA_ENDERECO_DB_OPEN_1()
        {
            /*" -4396- EXEC SQL OPEN ENDERECOS END-EXEC. */

            ENDERECOS.Open();

        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-DECLARE-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_DECLARE_1()
        {
            /*" -5491- EXEC SQL DECLARE C01_AGENCEF CURSOR FOR SELECT A.COD_AGENCIA, B.COD_FONTE FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.MALHA_CEF B WHERE A.COD_ESCNEG > 99 AND A.COD_ESCNEG < 9999 AND A.COD_ESCNEG = B.COD_SUREG ORDER BY A.COD_AGENCIA WITH UR END-EXEC. */
            C01_AGENCEF = new PF0642B_C01_AGENCEF(false);
            string GetQuery_C01_AGENCEF()
            {
                var query = @$"SELECT A.COD_AGENCIA
							, 
							B.COD_FONTE 
							FROM SEGUROS.AGENCIAS_CEF A
							, 
							SEGUROS.MALHA_CEF B 
							WHERE A.COD_ESCNEG > 99 
							AND A.COD_ESCNEG < 9999 
							AND A.COD_ESCNEG = B.COD_SUREG 
							ORDER BY A.COD_AGENCIA";

                return query;
            }
            C01_AGENCEF.GetQueryEvent += GetQuery_C01_AGENCEF;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3201_SAIDA*/

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-SECTION */
        private void R3210_FETCH_ENDERECO_SECTION()
        {
            /*" -4424- MOVE 'R3210-FETCH-ENDERECO' TO PARAGRAFO. */
            _.Move("R3210-FETCH-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4426- MOVE 'FETCH CURSOR ENDERECOS' TO COMANDO. */
            _.Move("FETCH CURSOR ENDERECOS", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4437- PERFORM R3210_FETCH_ENDERECO_DB_FETCH_1 */

            R3210_FETCH_ENDERECO_DB_FETCH_1();

            /*" -4440- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4441- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4442- MOVE 'SIM' TO W-FIM-CURSOR-ENDERECO */
                    _.Move("SIM", WAREA_AUXILIAR.W_FIM_CURSOR_ENDERECO);

                    /*" -4442- PERFORM R3210_FETCH_ENDERECO_DB_CLOSE_1 */

                    R3210_FETCH_ENDERECO_DB_CLOSE_1();

                    /*" -4444- ELSE */
                }
                else
                {


                    /*" -4445- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -4446- DISPLAY '          ERRO FETCH CURSOR ENDERECO' */
                    _.Display($"          ERRO FETCH CURSOR ENDERECO");

                    /*" -4448- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                    _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                    /*" -4450- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -4452- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4453- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4453- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-DB-FETCH-1 */
        public void R3210_FETCH_ENDERECO_DB_FETCH_1()
        {
            /*" -4437- EXEC SQL FETCH ENDERECOS INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO END-EXEC. */

            if (ENDERECOS.Fetch())
            {
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);
                _.Move(ENDERECOS.DCLPESSOA_ENDERECO_SITUACAO_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);
            }

        }

        [StopWatch]
        /*" R3210-FETCH-ENDERECO-DB-CLOSE-1 */
        public void R3210_FETCH_ENDERECO_DB_CLOSE_1()
        {
            /*" -4442- EXEC SQL CLOSE ENDERECOS END-EXEC */

            ENDERECOS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_SAIDA*/

        [StopWatch]
        /*" R3215-VERIFICA-EXISTE-ENDERECO-SECTION */
        private void R3215_VERIFICA_EXISTE_ENDERECO_SECTION()
        {
            /*" -4463- MOVE 'R3215-VERIFICA-EXISTE-ENDERECO' TO PARAGRAFO. */
            _.Move("R3215-VERIFICA-EXISTE-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4465- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4477- IF R2-TIPO-ENDER OF REG-ENDERECO EQUAL TIPO-ENDER OF DCLPESSOA-ENDERECO AND R2-ENDERECO OF REG-ENDERECO EQUAL ENDERECO OF DCLPESSOA-ENDERECO AND R2-CIDADE OF REG-ENDERECO EQUAL CIDADE OF DCLPESSOA-ENDERECO AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SIGLA-UF OF DCLPESSOA-ENDERECO AND R2-CEP OF REG-ENDERECO EQUAL CEP OF DCLPESSOA-ENDERECO */

            if (LBFPF012.REG_ENDERECO.R2_TIPO_ENDER == PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER && LBFPF012.REG_ENDERECO.R2_ENDERECO == PESENDER.DCLPESSOA_ENDERECO.ENDERECO && LBFPF012.REG_ENDERECO.R2_CIDADE == PESENDER.DCLPESSOA_ENDERECO.CIDADE && LBFPF012.REG_ENDERECO.R2_SIGLA_UF == PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF && LBFPF012.REG_ENDERECO.R2_CEP == PESENDER.DCLPESSOA_ENDERECO.CEP)
            {

                /*" -4479- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -4482- IF R2-ENDERECO OF REG-ENDERECO EQUAL SPACES AND R2-CIDADE OF REG-ENDERECO EQUAL SPACES AND R2-SIGLA-UF OF REG-ENDERECO EQUAL SPACES */

            if (LBFPF012.REG_ENDERECO.R2_ENDERECO.IsEmpty() && LBFPF012.REG_ENDERECO.R2_CIDADE.IsEmpty() && LBFPF012.REG_ENDERECO.R2_SIGLA_UF.IsEmpty())
            {

                /*" -4484- MOVE 'SIM' TO W-ACHOU-ENDERECO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_ENDERECO);
            }


            /*" -4484- PERFORM R3210-FETCH-ENDERECO. */

            R3210_FETCH_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3215_SAIDA*/

        [StopWatch]
        /*" R3220-INCLUIR-NOVO-ENDERECO-SECTION */
        private void R3220_INCLUIR_NOVO_ENDERECO_SECTION()
        {
            /*" -4494- MOVE 'R3220-INCLUIR-NOVO-ENDERECO' TO PARAGRAFO. */
            _.Move("R3220-INCLUIR-NOVO-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4503- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4506- MOVE OCORR-ENDERECO OF DCLPESSOA-ENDERECO TO W-OCORR-ENDERECO */
            _.Move(PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO, WAREA_AUXILIAR.W_OCORR_ENDERECO);

            /*" -4508- COMPUTE W-OCORR-ENDERECO = W-OCORR-ENDERECO + 1. */
            WAREA_AUXILIAR.W_OCORR_ENDERECO.Value = WAREA_AUXILIAR.W_OCORR_ENDERECO + 1;

            /*" -4508- PERFORM R3230-INCLUIR-ENDERECO. */

            R3230_INCLUIR_ENDERECO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3220_SAIDA*/

        [StopWatch]
        /*" R3225-OBTER-MAX-ENDERECO-SECTION */
        private void R3225_OBTER_MAX_ENDERECO_SECTION()
        {
            /*" -4518- MOVE 'R3225-OBTER-MAX-ENDERECO' TO PARAGRAFO. */
            _.Move("R3225-OBTER-MAX-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4520- MOVE 'MAX SEGUROS.PESSOA_ENDERECO' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4523- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -4529- PERFORM R3225_OBTER_MAX_ENDERECO_DB_SELECT_1 */

            R3225_OBTER_MAX_ENDERECO_DB_SELECT_1();

            /*" -4532- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4533- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -4534- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-ENDERECO' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-ENDERECO");

                /*" -4536- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -4538- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -4540- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4541- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4541- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3225-OBTER-MAX-ENDERECO-DB-SELECT-1 */
        public void R3225_OBTER_MAX_ENDERECO_DB_SELECT_1()
        {
            /*" -4529- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :DCLPESSOA-ENDERECO.OCORR-ENDERECO FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :DCLPESSOA-ENDERECO.COD-PESSOA WITH UR END-EXEC. */

            var r3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1 = new R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA.ToString(),
            };

            var executed_1 = R3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1.Execute(r3225_OBTER_MAX_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3225_SAIDA*/

        [StopWatch]
        /*" R3230-INCLUIR-ENDERECO-SECTION */
        private void R3230_INCLUIR_ENDERECO_SECTION()
        {
            /*" -4551- MOVE 'R3230-INCLUI-ENDERECO' TO PARAGRAFO. */
            _.Move("R3230-INCLUI-ENDERECO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4553- MOVE 'INSERT PESSOA-ENDERECO' TO COMANDO. */
            _.Move("INSERT PESSOA-ENDERECO", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4556- MOVE W-OCORR-ENDERECO TO OCORR-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(WAREA_AUXILIAR.W_OCORR_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO);

            /*" -4559- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-ENDERECO. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA);

            /*" -4562- MOVE R2-ENDERECO OF REG-ENDERECO TO ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_ENDERECO, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);

            /*" -4565- MOVE R2-TIPO-ENDER OF REG-ENDERECO TO TIPO-ENDER OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_TIPO_ENDER, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);

            /*" -4568- MOVE R2-BAIRRO OF REG-ENDERECO TO BAIRRO OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_BAIRRO, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);

            /*" -4571- MOVE R2-CEP OF REG-ENDERECO TO CEP OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);

            /*" -4574- MOVE R2-CIDADE OF REG-ENDERECO TO CIDADE OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_CIDADE, PESENDER.DCLPESSOA_ENDERECO.CIDADE);

            /*" -4577- MOVE R2-SIGLA-UF OF REG-ENDERECO TO SIGLA-UF OF DCLPESSOA-ENDERECO. */
            _.Move(LBFPF012.REG_ENDERECO.R2_SIGLA_UF, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);

            /*" -4580- MOVE 'A' TO SITUACAO-ENDERECO OF DCLPESSOA-ENDERECO. */
            _.Move("A", PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);

            /*" -4583- MOVE 'PF0642B' TO COD-USUARIO OF DCLPESSOA-ENDERECO. */
            _.Move("PF0642B", PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO);

            /*" -4588- IF TIPO-ENDER OF DCLPESSOA-ENDERECO = 0 AND (ENDERECO OF DCLPESSOA-ENDERECO = SPACES OR ENDERECO OF DCLPESSOA-ENDERECO <= ' ' ) AND (CIDADE OF DCLPESSOA-ENDERECO = SPACES OR CIDADE OF DCLPESSOA-ENDERECO <= ' ' ) */

            if (PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER == 0 && (PESENDER.DCLPESSOA_ENDERECO.ENDERECO.IsEmpty() || PESENDER.DCLPESSOA_ENDERECO.ENDERECO <= " ") && (PESENDER.DCLPESSOA_ENDERECO.CIDADE.IsEmpty() || PESENDER.DCLPESSOA_ENDERECO.CIDADE <= " "))
            {

                /*" -4589- GO TO R3230-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R3230_SAIDA*/ //GOTO
                return;

                /*" -4591- END-IF. */
            }


            /*" -4605- PERFORM R3230_INCLUIR_ENDERECO_DB_INSERT_1 */

            R3230_INCLUIR_ENDERECO_DB_INSERT_1();

            /*" -4608- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4609- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -4610- DISPLAY '          ERRO INSERT TABELA PESSOA-ENDERECO' */
                _.Display($"          ERRO INSERT TABELA PESSOA-ENDERECO");

                /*" -4612- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-ENDERECO */
                _.Display($"          CODIGO PESSOA.................  {PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA}");

                /*" -4614- DISPLAY '          OCORRENCIA ENDERECO...........  ' OCORR-ENDERECO OF DCLPESSOA-ENDERECO */
                _.Display($"          OCORRENCIA ENDERECO...........  {PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO}");

                /*" -4616- DISPLAY '          TIPO ENDERECO.................  ' TIPO-ENDER OF DCLPESSOA-ENDERECO */
                _.Display($"          TIPO ENDERECO.................  {PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER}");

                /*" -4618- DISPLAY '          NUMERO DA PROPOSTA............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -4620- DISPLAY '          ENDERECO......................  ' ENDERECO OF DCLPESSOA-ENDERECO */
                _.Display($"          ENDERECO......................  {PESENDER.DCLPESSOA_ENDERECO.ENDERECO}");

                /*" -4622- DISPLAY '          CIDADE........................  ' CIDADE OF DCLPESSOA-ENDERECO */
                _.Display($"          CIDADE........................  {PESENDER.DCLPESSOA_ENDERECO.CIDADE}");

                /*" -4624- DISPLAY '          BAIRRO........................  ' BAIRRO OF DCLPESSOA-ENDERECO */
                _.Display($"          BAIRRO........................  {PESENDER.DCLPESSOA_ENDERECO.BAIRRO}");

                /*" -4626- DISPLAY '          CEP...........................  ' CEP OF DCLPESSOA-ENDERECO */
                _.Display($"          CEP...........................  {PESENDER.DCLPESSOA_ENDERECO.CEP}");

                /*" -4628- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4629- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4629- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3230-INCLUIR-ENDERECO-DB-INSERT-1 */
        public void R3230_INCLUIR_ENDERECO_DB_INSERT_1()
        {
            /*" -4605- EXEC SQL INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES (:DCLPESSOA-ENDERECO.COD-PESSOA, :DCLPESSOA-ENDERECO.OCORR-ENDERECO, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, NULL, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO, :DCLPESSOA-ENDERECO.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1 = new R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESENDER.DCLPESSOA_ENDERECO.COD_PESSOA.ToString(),
                OCORR_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.OCORR_ENDERECO.ToString(),
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                TIPO_ENDER = PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                SITUACAO_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO.ToString(),
                COD_USUARIO = PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO.ToString(),
            };

            R3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1.Execute(r3230_INCLUIR_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3230_SAIDA*/

        [StopWatch]
        /*" R3250-TRATA-TELEFONES-SECTION */
        private void R3250_TRATA_TELEFONES_SECTION()
        {
            /*" -4639- MOVE 'R3250-TRATA-TELEFONE' TO PARAGRAFO. */
            _.Move("R3250-TRATA-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4641- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4643- ADD 1 TO W-INDEX. */
            WAREA_AUXILIAR.W_INDEX.Value = WAREA_AUXILIAR.W_INDEX + 1;

            /*" -4645- MOVE 'NAO' TO W-ACHOU-TELEFONE. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

            /*" -4646- IF R1-NUM-FONE (W-INDEX) GREATER ZEROS */

            if (LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE > 00)
            {

                /*" -4647- PERFORM R3255-LER-TELEFONE */

                R3255_LER_TELEFONE_SECTION();

                /*" -4648- IF W-ACHOU-TELEFONE EQUAL 'NAO' */

                if (WAREA_AUXILIAR.W_ACHOU_TELEFONE == "NAO")
                {

                    /*" -4648- PERFORM R3260-INCLUIR-NOVO-TELEFONE. */

                    R3260_INCLUIR_NOVO_TELEFONE_SECTION();
                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3250_SAIDA*/

        [StopWatch]
        /*" R3255-LER-TELEFONE-SECTION */
        private void R3255_LER_TELEFONE_SECTION()
        {
            /*" -4658- MOVE 'R3255-LER-TELEFONE' TO PARAGRAFO. */
            _.Move("R3255-LER-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4660- MOVE 'SELECT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("SELECT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4666- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -4672- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -4680- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -4683- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -4692- PERFORM R3255_LER_TELEFONE_DB_SELECT_1 */

            R3255_LER_TELEFONE_DB_SELECT_1();

            /*" -4695- IF SQLCODE EQUAL 00 */

            if (DB.SQLCODE == 00)
            {

                /*" -4696- MOVE 'SIM' TO W-ACHOU-TELEFONE */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                /*" -4697- ELSE */
            }
            else
            {


                /*" -4698- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4699- MOVE 'NAO' TO W-ACHOU-TELEFONE */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_TELEFONE);

                    /*" -4700- ELSE */
                }
                else
                {


                    /*" -4701- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -4702- DISPLAY '          ERRO SELECT TABELA PESSOA-TELEFONE' */
                    _.Display($"          ERRO SELECT TABELA PESSOA-TELEFONE");

                    /*" -4704- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                    _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                    /*" -4706- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                    _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                    /*" -4708- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4709- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4709- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R3255-LER-TELEFONE-DB-SELECT-1 */
        public void R3255_LER_TELEFONE_DB_SELECT_1()
        {
            /*" -4692- EXEC SQL SELECT SITUACAO_FONE INTO :DCLPESSOA-TELEFONE.SITUACAO-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA AND TIPO_FONE = :DCLPESSOA-TELEFONE.TIPO-FONE AND NUM_FONE = :DCLPESSOA-TELEFONE.NUM-FONE AND DDD = :DCLPESSOA-TELEFONE.DDD WITH UR END-EXEC. */

            var r3255_LER_TELEFONE_DB_SELECT_1_Query1 = new R3255_LER_TELEFONE_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
            };

            var executed_1 = R3255_LER_TELEFONE_DB_SELECT_1_Query1.Execute(r3255_LER_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SITUACAO_FONE, PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3255_SAIDA*/

        [StopWatch]
        /*" R3260-INCLUIR-NOVO-TELEFONE-SECTION */
        private void R3260_INCLUIR_NOVO_TELEFONE_SECTION()
        {
            /*" -4719- MOVE 'R3260-INCLUIR-NOVO-TELEFONE' TO PARAGRAFO. */
            _.Move("R3260-INCLUIR-NOVO-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4721- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4723- PERFORM R3265-OBTER-MAX-TELEFONE. */

            R3265_OBTER_MAX_TELEFONE_SECTION();

            /*" -4726- MOVE SEQ-FONE OF DCLPESSOA-TELEFONE TO W-SEQ-FONE */
            _.Move(PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE, WAREA_AUXILIAR.W_SEQ_FONE);

            /*" -4728- COMPUTE W-SEQ-FONE = W-SEQ-FONE + 1. */
            WAREA_AUXILIAR.W_SEQ_FONE.Value = WAREA_AUXILIAR.W_SEQ_FONE + 1;

            /*" -4728- PERFORM R3270-INCLUIR-TELEFONE. */

            R3270_INCLUIR_TELEFONE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3260_SAIDA*/

        [StopWatch]
        /*" R3265-OBTER-MAX-TELEFONE-SECTION */
        private void R3265_OBTER_MAX_TELEFONE_SECTION()
        {
            /*" -4738- MOVE 'R3265-OBTER-MAX-TELEFONE' TO PARAGRAFO. */
            _.Move("R3265-OBTER-MAX-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4740- MOVE 'MAX SEGUROS.PESSOA_TELEFONE' TO COMANDO. */
            _.Move("MAX SEGUROS.PESSOA_TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4746- PERFORM R3265_OBTER_MAX_TELEFONE_DB_SELECT_1 */

            R3265_OBTER_MAX_TELEFONE_DB_SELECT_1();

            /*" -4749- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4750- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -4751- DISPLAY '          ERRO SELECT MAX TAB. PESSOA-TELEFONE' */
                _.Display($"          ERRO SELECT MAX TAB. PESSOA-TELEFONE");

                /*" -4753- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -4755- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4757- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4758- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4758- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3265-OBTER-MAX-TELEFONE-DB-SELECT-1 */
        public void R3265_OBTER_MAX_TELEFONE_DB_SELECT_1()
        {
            /*" -4746- EXEC SQL SELECT VALUE(MAX(SEQ_FONE),0) INTO :DCLPESSOA-TELEFONE.SEQ-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :DCLPESSOA-TELEFONE.COD-PESSOA WITH UR END-EXEC. */

            var r3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1 = new R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
            };

            var executed_1 = R3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1.Execute(r3265_OBTER_MAX_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3265_SAIDA*/

        [StopWatch]
        /*" R3270-INCLUIR-TELEFONE-SECTION */
        private void R3270_INCLUIR_TELEFONE_SECTION()
        {
            /*" -4768- MOVE 'R3270-INCLUI-TELEFONE' TO PARAGRAFO. */
            _.Move("R3270-INCLUI-TELEFONE", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4770- MOVE 'INSERT PESSOA-TELEFONE' TO COMANDO. */
            _.Move("INSERT PESSOA-TELEFONE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4774- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLPESSOA-TELEFONE. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA);

            /*" -4777- MOVE W-INDEX TO TIPO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_INDEX, PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE);

            /*" -4780- MOVE W-SEQ-FONE TO SEQ-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(WAREA_AUXILIAR.W_SEQ_FONE, PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE);

            /*" -4783- MOVE 55 TO DDI OF DCLPESSOA-TELEFONE. */
            _.Move(55, PESFONE.DCLPESSOA_TELEFONE.DDI);

            /*" -4786- MOVE R1-DDD (W-INDEX) TO DDD OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -4789- MOVE R1-NUM-FONE (W-INDEX) TO NUM-FONE OF DCLPESSOA-TELEFONE. */
            _.Move(LBFPF011.REG_CLIENTES.R1_TELEFONE[WAREA_AUXILIAR.W_INDEX].R1_NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -4792- MOVE 'A' TO SITUACAO-FONE OF DCLPESSOA-TELEFONE. */
            _.Move("A", PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);

            /*" -4795- MOVE 'PF0642B' TO COD-USUARIO OF DCLPESSOA-TELEFONE. */
            _.Move("PF0642B", PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO);

            /*" -4806- PERFORM R3270_INCLUIR_TELEFONE_DB_INSERT_1 */

            R3270_INCLUIR_TELEFONE_DB_INSERT_1();

            /*" -4809- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4810- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -4811- DISPLAY '          ERRO INSERT TABELA PESSOA-TELEFONE' */
                _.Display($"          ERRO INSERT TABELA PESSOA-TELEFONE");

                /*" -4813- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLPESSOA-TELEFONE */
                _.Display($"          CODIGO PESSOA.................  {PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA}");

                /*" -4815- DISPLAY '          NUMERO DA PROPOSTA............  ' R1-NUM-PROPOSTA OF REG-CLIENTES */
                _.Display($"          NUMERO DA PROPOSTA............  {LBFPF011.REG_CLIENTES.R1_NUM_PROPOSTA}");

                /*" -4817- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4818- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4818- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3270-INCLUIR-TELEFONE-DB-INSERT-1 */
        public void R3270_INCLUIR_TELEFONE_DB_INSERT_1()
        {
            /*" -4806- EXEC SQL INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES (:DCLPESSOA-TELEFONE.COD-PESSOA, :DCLPESSOA-TELEFONE.TIPO-FONE, :DCLPESSOA-TELEFONE.SEQ-FONE, :DCLPESSOA-TELEFONE.DDI, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE, :DCLPESSOA-TELEFONE.SITUACAO-FONE, :DCLPESSOA-TELEFONE.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1 = new R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = PESFONE.DCLPESSOA_TELEFONE.COD_PESSOA.ToString(),
                TIPO_FONE = PESFONE.DCLPESSOA_TELEFONE.TIPO_FONE.ToString(),
                SEQ_FONE = PESFONE.DCLPESSOA_TELEFONE.SEQ_FONE.ToString(),
                DDI = PESFONE.DCLPESSOA_TELEFONE.DDI.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                SITUACAO_FONE = PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE.ToString(),
                COD_USUARIO = PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO.ToString(),
            };

            R3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1.Execute(r3270_INCLUIR_TELEFONE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3270_SAIDA*/

        [StopWatch]
        /*" R3300-TRATA-PROPOSTA-SECTION */
        private void R3300_TRATA_PROPOSTA_SECTION()
        {
            /*" -4828- MOVE 'R3300-TRATA-PROPOSTA' TO PARAGRAFO. */
            _.Move("R3300-TRATA-PROPOSTA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4830- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4831- PERFORM R3310-TRATA-TAB-RELACIONAMENTO. */

            R3310_TRATA_TAB_RELACIONAMENTO_SECTION();

            /*" -4832- PERFORM R3350-TRATA-TAB-IDE-RELACIONAM. */

            R3350_TRATA_TAB_IDE_RELACIONAM_SECTION();

            /*" -4833- PERFORM R3360-TRATA-PROP-FIDELIZACAO. */

            R3360_TRATA_PROP_FIDELIZACAO_SECTION();

            /*" -4834- PERFORM R3370-GERA-PROP-VIDA. */

            R3370_GERA_PROP_VIDA_SECTION();

            /*" -4834- PERFORM R3390-GERA-HIST-FIDELIZACAO. */

            R3390_GERA_HIST_FIDELIZACAO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3300_SAIDA*/

        [StopWatch]
        /*" R3310-TRATA-TAB-RELACIONAMENTO-SECTION */
        private void R3310_TRATA_TAB_RELACIONAMENTO_SECTION()
        {
            /*" -4844- MOVE 'R3310-TRATA-TAB-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3310-TRATA-TAB-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4846- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4848- PERFORM R3315-DETERMINA-RELACIONAMENTO */

            R3315_DETERMINA_RELACIONAMENTO_SECTION();

            /*" -4850- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO. */
            _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

            /*" -4852- PERFORM R3320-VERIFICA-EXISTE-RELACION. */

            R3320_VERIFICA_EXISTE_RELACION_SECTION();

            /*" -4853- IF W-ACHOU-RELACIONAMENTO EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO == "NAO")
            {

                /*" -4853- PERFORM R3330-GERA-RELACIONAMENTO. */

                R3330_GERA_RELACIONAMENTO_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3310_SAIDA*/

        [StopWatch]
        /*" R3315-DETERMINA-RELACIONAMENTO-SECTION */
        private void R3315_DETERMINA_RELACIONAMENTO_SECTION()
        {
            /*" -4863- MOVE 'R3315-DETERMINA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3315-DETERMINA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4865- MOVE 'SELECT PRODUTOS_SIVPF' TO COMANDO. */
            _.Move("SELECT PRODUTOS_SIVPF", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4868- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO W-COD-EMPRESA. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, WAREA_AUXILIAR.W_COD_EMPRESA);

            /*" -4870- MOVE PRDSIVPF-COD-RELAC OF DCLPRODUTOS-SIVPF TO W-COD-RELACION, W-RELACIONAMENTO. */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_RELAC, WAREA_AUXILIAR.W_COD_RELACION, WAREA_AUXILIAR.W_RELACIONAMENTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3315_SAIDA*/

        [StopWatch]
        /*" R3320-VERIFICA-EXISTE-RELACION-SECTION */
        private void R3320_VERIFICA_EXISTE_RELACION_SECTION()
        {
            /*" -4880- MOVE 'R3320-VERIFICA-EXISTE-RELACION' TO PARAGRAFO. */
            _.Move("R3320-VERIFICA-EXISTE-RELACION", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4882- MOVE 'SELECT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("SELECT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4885- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -4888- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -4897- PERFORM R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1 */

            R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1();

            /*" -4900- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4901- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -4902- MOVE 'NAO' TO W-ACHOU-RELACIONAMENTO */
                    _.Move("NAO", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);

                    /*" -4903- ELSE */
                }
                else
                {


                    /*" -4904- DISPLAY 'PF0642B - FIM ANORMAL' */
                    _.Display($"PF0642B - FIM ANORMAL");

                    /*" -4905- DISPLAY '          ERRO SELECT TAB. PESSOA-TIPORELAC' */
                    _.Display($"          ERRO SELECT TAB. PESSOA-TIPORELAC");

                    /*" -4907- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                    /*" -4909- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                    _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                    /*" -4911- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                    _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                    /*" -4912- PERFORM R9988-00-FECHAR-ARQUIVOS */

                    R9988_00_FECHAR_ARQUIVOS_SECTION();

                    /*" -4913- PERFORM R9999-00-FINALIZAR */

                    R9999_00_FINALIZAR_SECTION();

                    /*" -4914- ELSE */
                }

            }
            else
            {


                /*" -4914- MOVE 'SIM' TO W-ACHOU-RELACIONAMENTO. */
                _.Move("SIM", WAREA_AUXILIAR.W_ACHOU_RELACIONAMENTO);
            }


        }

        [StopWatch]
        /*" R3320-VERIFICA-EXISTE-RELACION-DB-SELECT-1 */
        public void R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1()
        {
            /*" -4897- EXEC SQL SELECT COD_PESSOA, COD_RELAC INTO :DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC FROM SEGUROS.R_PESSOA_TIPORELAC WHERE COD_PESSOA = :DCLR-PESSOA-TIPORELAC.COD-PESSOA AND COD_RELAC = :DCLR-PESSOA-TIPORELAC.COD-RELAC WITH UR END-EXEC. */

            var r3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1 = new R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            var executed_1 = R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1.Execute(r3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);
                _.Move(executed_1.COD_RELAC, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3320_SAIDA*/

        [StopWatch]
        /*" R3330-GERA-RELACIONAMENTO-SECTION */
        private void R3330_GERA_RELACIONAMENTO_SECTION()
        {
            /*" -4924- MOVE 'R3330-GERA-RELACIONAMENTO' TO PARAGRAFO. */
            _.Move("R3330-GERA-RELACIONAMENTO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4926- MOVE 'INSERT PESSOAS_TIPORELAC' TO COMANDO. */
            _.Move("INSERT PESSOAS_TIPORELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4929- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO COD-PESSOA OF DCLR-PESSOA-TIPORELAC. */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA);

            /*" -4932- MOVE W-COD-RELACION TO COD-RELAC OF DCLR-PESSOA-TIPORELAC. */
            _.Move(WAREA_AUXILIAR.W_COD_RELACION, RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC);

            /*" -4936- PERFORM R3330_GERA_RELACIONAMENTO_DB_INSERT_1 */

            R3330_GERA_RELACIONAMENTO_DB_INSERT_1();

            /*" -4939- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4940- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -4941- DISPLAY '          ERRO INSERT TAB. PESSOA-TIPORELAC' */
                _.Display($"          ERRO INSERT TAB. PESSOA-TIPORELAC");

                /*" -4943- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO PESSOA.................  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA}");

                /*" -4945- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLR-PESSOA-TIPORELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC}");

                /*" -4947- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -4948- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -4948- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3330-GERA-RELACIONAMENTO-DB-INSERT-1 */
        public void R3330_GERA_RELACIONAMENTO_DB_INSERT_1()
        {
            /*" -4936- EXEC SQL INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES (:DCLR-PESSOA-TIPORELAC.COD-PESSOA, :DCLR-PESSOA-TIPORELAC.COD-RELAC) END-EXEC. */

            var r3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1 = new R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1()
            {
                COD_PESSOA = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA.ToString(),
                COD_RELAC = RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC.ToString(),
            };

            R3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1.Execute(r3330_GERA_RELACIONAMENTO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3330_SAIDA*/

        [StopWatch]
        /*" R3350-TRATA-TAB-IDE-RELACIONAM-SECTION */
        private void R3350_TRATA_TAB_IDE_RELACIONAM_SECTION()
        {
            /*" -4958- IF W-OBTER-MAX-RELAC EQUAL 'NAO' */

            if (WAREA_AUXILIAR.W_OBTER_MAX_RELAC == "NAO")
            {

                /*" -4959- MOVE 'SIM' TO W-OBTER-MAX-RELAC */
                _.Move("SIM", WAREA_AUXILIAR.W_OBTER_MAX_RELAC);

                /*" -4961- PERFORM R3355-OBTER-MAX-ID-RELACIONAM. */

                R3355_OBTER_MAX_ID_RELACIONAM_SECTION();
            }


            /*" -4962- MOVE 'R3350-TRATA-TAB-RELACIONAM' TO PARAGRAFO. */
            _.Move("R3350-TRATA-TAB-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -4964- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -4967- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO W-NUM-IDENTIF. */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, WAREA_AUXILIAR.W_NUM_IDENTIF);

            /*" -4970- COMPUTE W-NUM-IDENTIF = W-NUM-IDENTIF + 1. */
            WAREA_AUXILIAR.W_NUM_IDENTIF.Value = WAREA_AUXILIAR.W_NUM_IDENTIF + 1;

            /*" -4973- MOVE W-NUM-IDENTIF TO NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC. */
            _.Move(WAREA_AUXILIAR.W_NUM_IDENTIF, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);

            /*" -4976- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -4979- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -4983- MOVE 'PF0642B' TO COD-USUARIO OF DCLIDENTIFICA-RELAC. */
            _.Move("PF0642B", IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO);

            /*" -4990- PERFORM R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1 */

            R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1();

            /*" -4993- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -4994- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -4995- DISPLAY '          ERRO INSERT TABELA IDENTIFICA-RELAC.' */
                _.Display($"          ERRO INSERT TABELA IDENTIFICA-RELAC.");

                /*" -4997- DISPLAY '          NUM IDENTIFICACAO.............  ' NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC */
                _.Display($"          NUM IDENTIFICACAO.............  {IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO}");

                /*" -4999- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -5001- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -5003- DISPLAY '          NUMERO PROPOSTA...............  ' R2-NUM-PROPOSTA OF REG-ENDERECO */
                _.Display($"          NUMERO PROPOSTA...............  {LBFPF012.REG_ENDERECO.R2_NUM_PROPOSTA}");

                /*" -5005- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5006- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5006- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3350-TRATA-TAB-IDE-RELACIONAM-DB-INSERT-1 */
        public void R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1()
        {
            /*" -4990- EXEC SQL INSERT INTO SEGUROS.IDENTIFICA_RELAC VALUES (:DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO, :DCLIDENTIFICA-RELAC.COD-PESSOA, :DCLIDENTIFICA-RELAC.COD-RELAC, :DCLIDENTIFICA-RELAC.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1 = new R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1()
            {
                NUM_IDENTIFICACAO = IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO.ToString(),
                COD_PESSOA = IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA.ToString(),
                COD_RELAC = IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC.ToString(),
                COD_USUARIO = IDERELAC.DCLIDENTIFICA_RELAC.COD_USUARIO.ToString(),
            };

            R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1.Execute(r3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3350_SAIDA*/

        [StopWatch]
        /*" R3355-OBTER-MAX-ID-RELACIONAM-SECTION */
        private void R3355_OBTER_MAX_ID_RELACIONAM_SECTION()
        {
            /*" -5016- MOVE 'R3355-OBTER-MAX-ID-RELACIONAM' TO PARAGRAFO. */
            _.Move("R3355-OBTER-MAX-ID-RELACIONAM", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5018- MOVE 'MAX IDENTIFICA_RELAC' TO COMANDO. */
            _.Move("MAX IDENTIFICA_RELAC", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5021- MOVE COD-PESSOA OF DCLR-PESSOA-TIPORELAC TO COD-PESSOA OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_PESSOA, IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA);

            /*" -5024- MOVE COD-RELAC OF DCLR-PESSOA-TIPORELAC TO COD-RELAC OF DCLIDENTIFICA-RELAC. */
            _.Move(RTPRELAC.DCLR_PESSOA_TIPORELAC.COD_RELAC, IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC);

            /*" -5031- PERFORM R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1 */

            R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1();

            /*" -5034- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5035- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -5036- DISPLAY '          ERRO SELECT MAX TAB. IDENTIFICA-RELAC' */
                _.Display($"          ERRO SELECT MAX TAB. IDENTIFICA-RELAC");

                /*" -5038- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -5040- DISPLAY '          CODIGO RELACIONAMENTO.........  ' COD-RELAC OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO RELACIONAMENTO.........  {IDERELAC.DCLIDENTIFICA_RELAC.COD_RELAC}");

                /*" -5042- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5043- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5043- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3355-OBTER-MAX-ID-RELACIONAM-DB-SELECT-1 */
        public void R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1()
        {
            /*" -5031- EXEC SQL SELECT VALUE(MAX(NUM_IDENTIFICACAO),0) INTO :DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO FROM SEGUROS.IDENTIFICA_RELAC WITH UR END-EXEC. */

            var r3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1 = new R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1.Execute(r3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_IDENTIFICACAO, IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3355_SAIDA*/

        [StopWatch]
        /*" R3360-TRATA-PROP-FIDELIZACAO-SECTION */
        private void R3360_TRATA_PROP_FIDELIZACAO_SECTION()
        {
            /*" -5053- MOVE 'R3360-TRATA-PROP-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3360-TRATA-PROP-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5055- MOVE ' ' TO COMANDO. */
            _.Move(" ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5059- MOVE R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-NUM-PROPOSTA-SIVPF W-NUM-PROPOSTA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF, WAREA_AUXILIAR.W_NUM_PROPOSTA);

            /*" -5061- MOVE RCAPS-NUM-TITULO TO PROPOFID-NUM-SICOB. */
            _.Move(RCAPS.DCLRCAPS.RCAPS_NUM_TITULO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_SICOB);

            /*" -5064- MOVE NUM-IDENTIFICACAO OF DCLIDENTIFICA-RELAC TO PROPOFID-NUM-IDENTIFICACAO */
            _.Move(IDERELAC.DCLIDENTIFICA_RELAC.NUM_IDENTIFICACAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO);

            /*" -5067- MOVE R3-DATA-PROPOSTA OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_PROPOSTA, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5069- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5071- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5074- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5078- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5081- MOVE W-DATA-SQL TO PROPOFID-DATA-PROPOSTA */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA);

            /*" -5084- MOVE R3-COD-PRODUTO OF REG-PROPOSTA-SASSE TO PROPOFID-COD-PRODUTO-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PRODUTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF);

            /*" -5087- MOVE PRDSIVPF-COD-EMPRESA-SIVPF OF DCLPRODUTOS-SIVPF TO PROPOFID-COD-EMPRESA-SIVPF */
            _.Move(PRDSIVPF.DCLPRODUTOS_SIVPF.PRDSIVPF_COD_EMPRESA_SIVPF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF);

            /*" -5090- MOVE R3-AGECOBR OF REG-PROPOSTA-SASSE TO PROPOFID-AGECOBR */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_AGECOBR, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECOBR);

            /*" -5093- MOVE R3-DIA-DEBITO OF REG-PROPOSTA-SASSE TO PROPOFID-DIA-DEBITO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DIA_DEBITO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIA_DEBITO);

            /*" -5096- MOVE R3-OPCAOPAG OF REG-PROPOSTA-SASSE TO PROPOFID-OPCAOPAG */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAOPAG, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAOPAG);

            /*" -5099- MOVE R3-AGECTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-AGECTADEB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_AGECTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTADEB);

            /*" -5102- MOVE R3-OPRCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-OPRCTADEB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_OPRCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTADEB);

            /*" -5105- MOVE R3-NUMCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-NUMCTADEB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_NUMCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTADEB);

            /*" -5108- MOVE R3-DIGCTADEB OF REG-PROPOSTA-SASSE TO PROPOFID-DIGCTADEB */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CONTA_DEBITO.R3_DIGCTADEB, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTADEB);

            /*" -5111- MOVE R3-PCT-DESCONTO OF REG-PROPOSTA-SASSE TO PROPOFID-PERC-DESCONTO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_PCT_DESCONTO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PERC_DESCONTO);

            /*" -5114- MOVE R3-NRMATRVEN OF REG-PROPOSTA-SASSE TO PROPOFID-NRMATRVEN */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NRMATRVEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRVEN);

            /*" -5117- MOVE TERMOADE-COD-AGENCIA-VEN TO PROPOFID-AGECTAVEN */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_AGENCIA_VEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGECTAVEN);

            /*" -5120- MOVE TERMOADE-OPERACAO-CONTA-VEN TO PROPOFID-OPRCTAVEN */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_OPERACAO_CONTA_VEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPRCTAVEN);

            /*" -5123- MOVE TERMOADE-NUM-CONTA-VEN TO PROPOFID-NUMCTAVEN */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_CONTA_VEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUMCTAVEN);

            /*" -5132- MOVE TERMOADE-DIG-CONTA-VEN TO PROPOFID-DIGCTAVEN */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_DIG_CONTA_VEN, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DIGCTAVEN);

            /*" -5135- MOVE R3-CGC-CONVENENTE OF REG-PROPOSTA-SASSE TO PROPOFID-CGC-CONVENENTE */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_CGC_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CGC_CONVENENTE);

            /*" -5138- MOVE R3-NOME-CONVENENTE OF REG-PROPOSTA-SASSE TO PROPOFID-NOME-CONVENENTE */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_NOME_CONVENENTE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONVENENTE);

            /*" -5141- MOVE ZEROS TO PROPOFID-NRMATRCON */
            _.Move(0, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NRMATRCON);

            /*" -5144- MOVE R3-DTQITBCO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DTQITBCO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5146- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5148- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5151- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5155- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5158- MOVE W-DATA-SQL TO PROPOFID-DTQITBCO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO);

            /*" -5161- MOVE RCAPS-VAL-RCAP OF DCLRCAPS TO PROPOFID-VAL-PAGO */
            _.Move(RCAPS.DCLRCAPS.RCAPS_VAL_RCAP, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_PAGO);

            /*" -5164- MOVE RCAPS-AGE-COBRANCA OF DCLRCAPS TO PROPOFID-AGEPGTO */
            _.Move(RCAPS.DCLRCAPS.RCAPS_AGE_COBRANCA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_AGEPGTO);

            /*" -5167- MOVE R3-VAL-TARIFA OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-TARIFA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_TARIFA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_TARIFA);

            /*" -5170- MOVE R2-VAL-IOF OF REG-APOL-SASSE TO PROPOFID-VAL-IOF */
            _.Move(LBFCT016.REG_APOL_SASSE.R2_VAL_IOF, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_IOF);

            /*" -5173- MOVE R3-DATA-CREDITO OF REG-PROPOSTA-SASSE TO W-DATA-TRABALHO. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DATA_CREDITO, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5175- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5177- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5180- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5184- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5187- MOVE W-DATA-SQL TO PROPOFID-DATA-CREDITO */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO);

            /*" -5190- MOVE R3-VAL-COMISSAO OF REG-PROPOSTA-SASSE TO PROPOFID-VAL-COMISSAO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_VAL_COMISSAO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_VAL_COMISSAO);

            /*" -5193- MOVE R3-SIT-PROPOSTA OF REG-PROPOSTA-SASSE TO PROPOFID-SIT-PROPOSTA */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SIT_PROPOSTA);

            /*" -5196- MOVE 'PF0642B' TO PROPOFID-COD-USUARIO */
            _.Move("PF0642B", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_USUARIO);

            /*" -5199- MOVE RH-NSAS OF REG-HEADER-STA TO PROPOFID-NSAS-SIVPF */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAS_SIVPF);

            /*" -5202- MOVE RH-NSAS OF REG-HEADER TO PROPOFID-NSAC-SIVPF */
            _.Move(LXFPF990.REG_HEADER.RH_NSAS, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSAC_SIVPF);

            /*" -5205- MOVE RT-QTDE-TIPO-1 OF REG-TRAILLER-STA TO PROPOFID-NSL */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_1, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NSL);

            /*" -5206- IF CANAL-VENDA-PAPEL */

            if (WAREA_AUXILIAR.CANAL.W_CANAL_PROPOSTA["CANAL_VENDA_PAPEL"])
            {

                /*" -5208- MOVE 2 TO PROPOFID-CANAL-PROPOSTA */
                _.Move(2, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);

                /*" -5209- ELSE */
            }
            else
            {


                /*" -5212- MOVE W-CANAL-PROPOSTA TO PROPOFID-CANAL-PROPOSTA. */
                _.Move(WAREA_AUXILIAR.CANAL.W_CANAL_PROPOSTA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_CANAL_PROPOSTA);
            }


            /*" -5215- MOVE 6 TO PROPOFID-ORIGEM-PROPOSTA */
            _.Move(6, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_ORIGEM_PROPOSTA);

            /*" -5218- MOVE 'R' TO PROPOFID-SITUACAO-ENVIO */
            _.Move("R", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_SITUACAO_ENVIO);

            /*" -5221- MOVE PESSOA-COD-PESSOA OF DCLPESSOA TO PROPOFID-COD-PESSOA */
            _.Move(PESSOA.DCLPESSOA.PESSOA_COD_PESSOA, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA);

            /*" -5224- MOVE R3-OPCAO-COBER OF REG-PROPOSTA-SASSE TO PROPOFID-OPCAO-COBER */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_OPCAO_COBER, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_OPCAO_COBER);

            /*" -5227- MOVE R3-COD-PLANO OF REG-PROPOSTA-SASSE TO PROPOFID-COD-PLANO */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_COD_PLANO, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PLANO);

            /*" -5230- MOVE R1-NOME-CONJUGE OF REG-CLIENTES TO PROPOFID-NOME-CONJUGE */
            _.Move(LBFPF011.REG_CLIENTES.R1_NOME_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NOME_CONJUGE);

            /*" -5233- MOVE R1-DTNASC-CONJUGE OF REG-CLIENTES TO W-DATA-TRABALHO. */
            _.Move(LBFPF011.REG_CLIENTES.R1_DTNASC_CONJUGE, WAREA_AUXILIAR.W_DATA_TRABALHO);

            /*" -5235- MOVE W-DIA-TRABALHO TO W-DIA-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_DIA_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_DIA_SQL);

            /*" -5237- MOVE W-MES-TRABALHO TO W-MES-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_MES_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_MES_SQL);

            /*" -5240- MOVE W-ANO-TRABALHO TO W-ANO-SQL OF W-DATA-SQL1. */
            _.Move(WAREA_AUXILIAR.FILLER_1.W_ANO_TRABALHO, WAREA_AUXILIAR.W_DATA_SQL1.W_ANO_SQL);

            /*" -5244- MOVE '-' TO W-BARRA1 OF W-DATA-SQL1, W-BARRA2 OF W-DATA-SQL1. */
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA1_1);
            _.Move("-", WAREA_AUXILIAR.W_DATA_SQL1.W_BARRA2_1);


            /*" -5247- MOVE W-DATA-SQL TO PROPOFID-DATA-NASC-CONJUGE */
            _.Move(WAREA_AUXILIAR.W_DATA_SQL, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE);

            /*" -5250- MOVE R1-CBO-CONJUGE OF REG-CLIENTES TO PROPOFID-PROFISSAO-CONJUGE */
            _.Move(LBFPF011.REG_CLIENTES.R1_CBO_CONJUGE, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_PROFISSAO_CONJUGE);

            /*" -5251- MOVE PROPOVA-FAIXA-RENDA-IND TO PROPOFID-FAIXA-RENDA-IND */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_IND, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND);

            /*" -5253- MOVE PROPOVA-FAIXA-RENDA-FAM TO PROPOFID-FAIXA-RENDA-FAM. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_FAIXA_RENDA_FAM, PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM);

            /*" -5255- MOVE 'N' TO PROPOFID-IND-TIPO-CONTA. */
            _.Move("N", PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA);

            /*" -5305- PERFORM R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1 */

            R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1();

            /*" -5308- IF SQLCODE NOT EQUAL 00 AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -5309- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -5310- DISPLAY '          ERRO INSERT TABELA PROPOSTA FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA PROPOSTA FIDELIZ");

                /*" -5312- DISPLAY '          CODIGO PESSOA.................  ' PROPOFID-COD-PESSOA */
                _.Display($"          CODIGO PESSOA.................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PESSOA}");

                /*" -5314- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -5316- DISPLAY '          COD-EMPRESA...................  ' PROPOFID-COD-EMPRESA-SIVPF */
                _.Display($"          COD-EMPRESA...................  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF}");

                /*" -5318- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5319- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5321- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


            /*" -5322- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -5323- DISPLAY 'PF0642B - PROPOSTA JA CADASTRADA ==> ' PROPOFID-NUM-PROPOSTA-SIVPF. */
                _.Display($"PF0642B - PROPOSTA JA CADASTRADA ==> {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");
            }


        }

        [StopWatch]
        /*" R3360-TRATA-PROP-FIDELIZACAO-DB-INSERT-1 */
        public void R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -5305- EXEC SQL INSERT INTO SEGUROS.PROPOSTA_FIDELIZ VALUES (:PROPOFID-NUM-PROPOSTA-SIVPF, :PROPOFID-NUM-IDENTIFICACAO, :PROPOFID-COD-EMPRESA-SIVPF, :PROPOFID-COD-PESSOA, :PROPOFID-NUM-SICOB, :PROPOFID-DATA-PROPOSTA, :PROPOFID-COD-PRODUTO-SIVPF, :PROPOFID-AGECOBR, :PROPOFID-DIA-DEBITO, :PROPOFID-OPCAOPAG, :PROPOFID-AGECTADEB, :PROPOFID-OPRCTADEB, :PROPOFID-NUMCTADEB, :PROPOFID-DIGCTADEB, :PROPOFID-PERC-DESCONTO, :PROPOFID-NRMATRVEN, :PROPOFID-AGECTAVEN, :PROPOFID-OPRCTAVEN, :PROPOFID-NUMCTAVEN, :PROPOFID-DIGCTAVEN, :PROPOFID-CGC-CONVENENTE, :PROPOFID-NOME-CONVENENTE, :PROPOFID-NRMATRCON, :PROPOFID-DTQITBCO, :PROPOFID-VAL-PAGO, :PROPOFID-AGEPGTO, :PROPOFID-VAL-TARIFA, :PROPOFID-VAL-IOF, :PROPOFID-DATA-CREDITO, :PROPOFID-VAL-COMISSAO, :PROPOFID-SIT-PROPOSTA, :PROPOFID-COD-USUARIO, :PROPOFID-CANAL-PROPOSTA, :PROPOFID-NSAS-SIVPF, :PROPOFID-ORIGEM-PROPOSTA, CURRENT TIMESTAMP, :PROPOFID-NSL, :PROPOFID-NSAC-SIVPF, :PROPOFID-SITUACAO-ENVIO, :PROPOFID-OPCAO-COBER, :PROPOFID-COD-PLANO, :PROPOFID-NOME-CONJUGE, :PROPOFID-DATA-NASC-CONJUGE:VIND-DTNASC-ESPOSA, :PROPOFID-PROFISSAO-CONJUGE, :PROPOFID-FAIXA-RENDA-IND:VIND-FAIXA-RENDA-IND, :PROPOFID-FAIXA-RENDA-FAM:VIND-FAIXA-RENDA-FAM, NULL, :PROPOFID-IND-TIPO-CONTA) END-EXEC. */

            var r3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1 = new R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1()
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
                PROPOFID_DTQITBCO = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.ToString(),
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
                PROPOFID_FAIXA_RENDA_IND = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_IND.ToString(),
                VIND_FAIXA_RENDA_IND = VIND_FAIXA_RENDA_IND.ToString(),
                PROPOFID_FAIXA_RENDA_FAM = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_FAIXA_RENDA_FAM.ToString(),
                VIND_FAIXA_RENDA_FAM = VIND_FAIXA_RENDA_FAM.ToString(),
                PROPOFID_IND_TIPO_CONTA = PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_IND_TIPO_CONTA.ToString(),
            };

            R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3360_SAIDA*/

        [StopWatch]
        /*" R3370-GERA-PROP-VIDA-SECTION */
        private void R3370_GERA_PROP_VIDA_SECTION()
        {
            /*" -5333- MOVE 'R3370-GERA-PROP-VIDA' TO PARAGRAFO */
            _.Move("R3370-GERA-PROP-VIDA", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5335- MOVE 'INSERT PROPOSTA-SASSE' TO COMANDO */
            _.Move("INSERT PROPOSTA-SASSE", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5338- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPSSVD-NUM-IDENTIFICACAO OF DCLPROP-SASSE-VIDA */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO);

            /*" -5341- MOVE R3-DPS-TITULAR OF REG-PROPOSTA-SASSE TO PROPSSVD-DPS-TITULAR OF DCLPROP-SASSE-VIDA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_TITULAR, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR);

            /*" -5344- MOVE R3-DPS-CONJUGE OF REG-PROPOSTA-SASSE TO PROPSSVD-DPS-CONJUGE OF DCLPROP-SASSE-VIDA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_DPS_CONJUGE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE);

            /*" -5347- MOVE R3-APOS-INVALIDEZ OF REG-PROPOSTA-SASSE TO PROPSSVD-APOS-INVALIDEZ OF DCLPROP-SASSE-VIDA. */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_APOS_INVALIDEZ, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ);

            /*" -5350- MOVE 'PF0642B' TO PROPSSVD-COD-USUARIO OF DCLPROP-SASSE-VIDA. */
            _.Move("PF0642B", PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_USUARIO);

            /*" -5353- MOVE TERMOADE-NUM-APOLICE TO PROPSSVD-NUM-APOLICE OF DCLPROP-SASSE-VIDA. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_NUM_APOLICE, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE);

            /*" -5356- MOVE TERMOADE-COD-SUBGRUPO TO PROPSSVD-COD-SUBGRUPO OF DCLPROP-SASSE-VIDA. */
            _.Move(TERMOADE.DCLTERMO_ADESAO.TERMOADE_COD_SUBGRUPO, PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO);

            /*" -5372- PERFORM R3370_GERA_PROP_VIDA_DB_INSERT_1 */

            R3370_GERA_PROP_VIDA_DB_INSERT_1();

            /*" -5375- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5376- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -5377- DISPLAY '          ERRO INSERT TAB. PROPOSTA SASSE VIDA' */
                _.Display($"          ERRO INSERT TAB. PROPOSTA SASSE VIDA");

                /*" -5379- DISPLAY '          NUMERO PROPOSTA...............  ' PROPOFID-NUM-PROPOSTA-SIVPF */
                _.Display($"          NUMERO PROPOSTA...............  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_PROPOSTA_SIVPF}");

                /*" -5381- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPOFID-NUM-IDENTIFICACAO */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO}");

                /*" -5383- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5384- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5384- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3370-GERA-PROP-VIDA-DB-INSERT-1 */
        public void R3370_GERA_PROP_VIDA_DB_INSERT_1()
        {
            /*" -5372- EXEC SQL INSERT INTO SEGUROS.PROP_SASSE_VIDA VALUES ( :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-IDENTIFICACAO, :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-TITULAR, :DCLPROP-SASSE-VIDA.PROPSSVD-DPS-CONJUGE, :DCLPROP-SASSE-VIDA.PROPSSVD-APOS-INVALIDEZ, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-USUARIO, :DCLPROP-SASSE-VIDA.PROPSSVD-NUM-APOLICE, :DCLPROP-SASSE-VIDA.PROPSSVD-COD-SUBGRUPO, CURRENT TIMESTAMP , NULL , NULL , NULL , NULL ) END-EXEC. */

            var r3370_GERA_PROP_VIDA_DB_INSERT_1_Insert1 = new R3370_GERA_PROP_VIDA_DB_INSERT_1_Insert1()
            {
                PROPSSVD_NUM_IDENTIFICACAO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_IDENTIFICACAO.ToString(),
                PROPSSVD_DPS_TITULAR = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_TITULAR.ToString(),
                PROPSSVD_DPS_CONJUGE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_DPS_CONJUGE.ToString(),
                PROPSSVD_APOS_INVALIDEZ = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_APOS_INVALIDEZ.ToString(),
                PROPSSVD_COD_USUARIO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_USUARIO.ToString(),
                PROPSSVD_NUM_APOLICE = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_NUM_APOLICE.ToString(),
                PROPSSVD_COD_SUBGRUPO = PROPSSVD.DCLPROP_SASSE_VIDA.PROPSSVD_COD_SUBGRUPO.ToString(),
            };

            R3370_GERA_PROP_VIDA_DB_INSERT_1_Insert1.Execute(r3370_GERA_PROP_VIDA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3370_SAIDA*/

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-SECTION */
        private void R3390_GERA_HIST_FIDELIZACAO_SECTION()
        {
            /*" -5394- MOVE 'R3390-GERA-HIST-FIDELIZACAO' TO PARAGRAFO. */
            _.Move("R3390-GERA-HIST-FIDELIZACAO", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5396- MOVE 'INSERT HIST-PROP-FIDELIZ' TO COMANDO. */
            _.Move("INSERT HIST-PROP-FIDELIZ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5400- MOVE PROPOFID-NUM-IDENTIFICACAO TO PROPFIDH-NUM-IDENTIFICACAO */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_NUM_IDENTIFICACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO);

            /*" -5404- MOVE VGCOMTRO-DTH-LIBERACAO TO PROPFIDH-DATA-SITUACAO */
            _.Move(VGCOMTRO.DCLVG_COMPL_TERMO.VGCOMTRO_DTH_LIBERACAO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO);

            /*" -5408- MOVE RH-NSAS OF REG-HEADER-STA TO PROPFIDH-NSAS-SIVPF */
            _.Move(LBFCT011.REG_HEADER_STA.RH_NSAS, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF);

            /*" -5412- MOVE RT-QTDE-TIPO-3 OF REG-TRAILLER-STA TO PROPFIDH-NSL */
            _.Move(LBFCT011.REG_TRAILLER_STA.RT_QTDE_TIPO_3, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL);

            /*" -5416- MOVE 'EMT' TO PROPFIDH-SIT-PROPOSTA */
            _.Move("EMT", PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA);

            /*" -5420- MOVE R3-SIT-COBRANCA OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-COBRANCA-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_COBRANCA, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF);

            /*" -5436- MOVE R3-SIT-MOTIVO OF REG-PROPOSTA-SASSE TO PROPFIDH-SIT-MOTIVO-SIVPF */
            _.Move(LXFCT004.REG_PROPOSTA_SASSE.R3_SIT_MOTIVO, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF);

            /*" -5439- MOVE PROPOFID-COD-EMPRESA-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-EMPRESA-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_EMPRESA_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF);

            /*" -5442- MOVE PROPOFID-COD-PRODUTO-SIVPF OF DCLPROPOSTA-FIDELIZ TO PROPFIDH-COD-PRODUTO-SIVPF. */
            _.Move(PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_COD_PRODUTO_SIVPF, PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF);

            /*" -5455- PERFORM R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1 */

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1();

            /*" -5458- IF SQLCODE NOT EQUAL 00 */

            if (DB.SQLCODE != 00)
            {

                /*" -5459- DISPLAY 'PF0642B - FIM ANORMAL' */
                _.Display($"PF0642B - FIM ANORMAL");

                /*" -5460- DISPLAY '          ERRO INSERT TABELA HIST-PROP-FIDELIZ' */
                _.Display($"          ERRO INSERT TABELA HIST-PROP-FIDELIZ");

                /*" -5462- DISPLAY '          CODIGO PESSOA.................  ' COD-PESSOA OF DCLIDENTIFICA-RELAC */
                _.Display($"          CODIGO PESSOA.................  {IDERELAC.DCLIDENTIFICA_RELAC.COD_PESSOA}");

                /*" -5464- DISPLAY '          NUMERO PROPOSTA...............  ' R3-NUM-PROPOSTA OF REG-PROPOSTA-SASSE */
                _.Display($"          NUMERO PROPOSTA...............  {LXFCT004.REG_PROPOSTA_SASSE.R3_NUM_PROPOSTA}");

                /*" -5467- DISPLAY '          NUMERO IDENTIFICACAO..........  ' PROPFIDH-NUM-IDENTIFICACAO */
                _.Display($"          NUMERO IDENTIFICACAO..........  {PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO}");

                /*" -5469- DISPLAY '          SQLCODE.......................  ' SQLCODE */
                _.Display($"          SQLCODE.......................  {DB.SQLCODE}");

                /*" -5470- PERFORM R9988-00-FECHAR-ARQUIVOS */

                R9988_00_FECHAR_ARQUIVOS_SECTION();

                /*" -5470- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R3390-GERA-HIST-FIDELIZACAO-DB-INSERT-1 */
        public void R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1()
        {
            /*" -5455- EXEC SQL INSERT INTO SEGUROS.HIST_PROP_FIDELIZ VALUES ( :PROPFIDH-NUM-IDENTIFICACAO , :PROPFIDH-DATA-SITUACAO , :PROPFIDH-NSAS-SIVPF , :PROPFIDH-NSL , :PROPFIDH-SIT-PROPOSTA , :PROPFIDH-SIT-COBRANCA-SIVPF , :PROPFIDH-SIT-MOTIVO-SIVPF , :PROPFIDH-COD-EMPRESA-SIVPF , :PROPFIDH-COD-PRODUTO-SIVPF ) END-EXEC. */

            var r3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1 = new R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1()
            {
                PROPFIDH_NUM_IDENTIFICACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NUM_IDENTIFICACAO.ToString(),
                PROPFIDH_DATA_SITUACAO = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.ToString(),
                PROPFIDH_NSAS_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSAS_SIVPF.ToString(),
                PROPFIDH_NSL = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_NSL.ToString(),
                PROPFIDH_SIT_PROPOSTA = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_PROPOSTA.ToString(),
                PROPFIDH_SIT_COBRANCA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_COBRANCA_SIVPF.ToString(),
                PROPFIDH_SIT_MOTIVO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_SIT_MOTIVO_SIVPF.ToString(),
                PROPFIDH_COD_EMPRESA_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_EMPRESA_SIVPF.ToString(),
                PROPFIDH_COD_PRODUTO_SIVPF = PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_COD_PRODUTO_SIVPF.ToString(),
            };

            R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1.Execute(r3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3390_SAIDA*/

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-SECTION */
        private void R6000_00_DECLARE_AGENCEF_SECTION()
        {
            /*" -5479- MOVE 'R6000-DECLA-AGENCEF   ' TO PARAGRAFO. */
            _.Move("R6000-DECLA-AGENCEF   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5481- MOVE 'DECLARE AGENCIACEF   ' TO COMANDO. */
            _.Move("DECLARE AGENCIACEF   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5491- PERFORM R6000_00_DECLARE_AGENCEF_DB_DECLARE_1 */

            R6000_00_DECLARE_AGENCEF_DB_DECLARE_1();

            /*" -5493- PERFORM R6000_00_DECLARE_AGENCEF_DB_OPEN_1 */

            R6000_00_DECLARE_AGENCEF_DB_OPEN_1();

            /*" -5496- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5497- DISPLAY 'R6000 - PROBLEMAS DECLARE (AGENCEF) ..' */
                _.Display($"R6000 - PROBLEMAS DECLARE (AGENCEF) ..");

                /*" -5498- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -5498- PERFORM R9999-00-FINALIZAR. */

                R9999_00_FINALIZAR_SECTION();
            }


        }

        [StopWatch]
        /*" R6000-00-DECLARE-AGENCEF-DB-OPEN-1 */
        public void R6000_00_DECLARE_AGENCEF_DB_OPEN_1()
        {
            /*" -5493- EXEC SQL OPEN C01_AGENCEF END-EXEC. */

            C01_AGENCEF.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-SECTION */
        private void R6010_00_FETCH_AGENCEF_SECTION()
        {
            /*" -5508- MOVE 'R6010-FETCH-AGENCEF   ' TO PARAGRAFO. */
            _.Move("R6010-FETCH-AGENCEF   ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5510- MOVE 'FETCH   AGENCIACEF   ' TO COMANDO. */
            _.Move("FETCH   AGENCIACEF   ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5513- PERFORM R6010_00_FETCH_AGENCEF_DB_FETCH_1 */

            R6010_00_FETCH_AGENCEF_DB_FETCH_1();

            /*" -5516- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -5517- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -5518- MOVE 'S' TO WFIM-AGENCEF */
                    _.Move("S", WAREA_AUXILIAR.WFIM_AGENCEF);

                    /*" -5518- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_1 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_1();

                    /*" -5520- ELSE */
                }
                else
                {


                    /*" -5520- PERFORM R6010_00_FETCH_AGENCEF_DB_CLOSE_2 */

                    R6010_00_FETCH_AGENCEF_DB_CLOSE_2();

                    /*" -5522- DISPLAY '3100 - (PROBLEMAS NO FETCH AGENCEF) ..' */
                    _.Display($"3100 - (PROBLEMAS NO FETCH AGENCEF) ..");

                    /*" -5523- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -5523- PERFORM R9999-00-FINALIZAR. */

                    R9999_00_FINALIZAR_SECTION();
                }

            }


        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-FETCH-1 */
        public void R6010_00_FETCH_AGENCEF_DB_FETCH_1()
        {
            /*" -5513- EXEC SQL FETCH C01_AGENCEF INTO :DCLAGENCIAS-CEF.COD-AGENCIA, :DCLMALHA-CEF.MALHACEF-COD-FONTE END-EXEC. */

            if (C01_AGENCEF.Fetch())
            {
                _.Move(C01_AGENCEF.DCLAGENCIAS_CEF_COD_AGENCIA, AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA);
                _.Move(C01_AGENCEF.DCLMALHA_CEF_MALHACEF_COD_FONTE, MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE);
            }

        }

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-1 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_1()
        {
            /*" -5518- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6010_99_SAIDA*/

        [StopWatch]
        /*" R6010-00-FETCH-AGENCEF-DB-CLOSE-2 */
        public void R6010_00_FETCH_AGENCEF_DB_CLOSE_2()
        {
            /*" -5520- EXEC SQL CLOSE C01_AGENCEF END-EXEC */

            C01_AGENCEF.Close();

        }

        [StopWatch]
        /*" R6020-00-CARREGA-FILIAL-SECTION */
        private void R6020_00_CARREGA_FILIAL_SECTION()
        {
            /*" -5533- MOVE 'R6020-CARREGA-FILIAL    ' TO PARAGRAFO. */
            _.Move("R6020-CARREGA-FILIAL    ", WABEND.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -5535- MOVE 'CARREGA FILIAL         ' TO COMANDO. */
            _.Move("CARREGA FILIAL         ", WABEND.LOCALIZA_ABEND_2.COMANDO);

            /*" -5537- MOVE COD-AGENCIA OF DCLAGENCIAS-CEF TO TAB-AGENCIA (COD-AGENCIA OF DCLAGENCIAS-CEF) */
            _.Move(AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA, TAB_FILIAIS.TAB_FILIAL.FILLER_0[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_AGENCIA);

            /*" -5540- MOVE MALHACEF-COD-FONTE OF DCLMALHA-CEF TO TAB-FONTE (COD-AGENCIA OF DCLAGENCIAS-CEF) */
            _.Move(MALHACEF.DCLMALHA_CEF.MALHACEF_COD_FONTE, TAB_FILIAIS.TAB_FILIAL.FILLER_0[AGENCEF.DCLAGENCIAS_CEF.COD_AGENCIA].TAB_FONTE);

            /*" -5540- PERFORM R6010-00-FETCH-AGENCEF. */

            R6010_00_FETCH_AGENCEF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6020_99_SAIDA*/

        [StopWatch]
        /*" R9988-00-FECHAR-ARQUIVOS-SECTION */
        private void R9988_00_FECHAR_ARQUIVOS_SECTION()
        {
            /*" -5551- CLOSE MOVTO-PRP-SASSE, MOVTO-STA-SASSE. */
            MOVTO_PRP_SASSE.Close();
            MOVTO_STA_SASSE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9988_SAIDA*/

        [StopWatch]
        /*" R9999-00-FINALIZAR-SECTION */
        private void R9999_00_FINALIZAR_SECTION()
        {
            /*" -5562- DISPLAY ' ' */
            _.Display($" ");

            /*" -5563- IF W-FIM-MOVTO-TERMO = 'FIM' */

            if (WAREA_AUXILIAR.W_FIM_MOVTO_TERMO == "FIM")
            {

                /*" -5564- DISPLAY 'PF0642B - FIM NORMAL' */
                _.Display($"PF0642B - FIM NORMAL");

                /*" -5565- MOVE 0 TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -5569- DISPLAY '*** PF0642B *** TABELAS ATUALIZADAS ***' */
                _.Display($"*** PF0642B *** TABELAS ATUALIZADAS ***");

                /*" -5570- MOVE 'COMMIT WORK' TO COMANDO */
                _.Move("COMMIT WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -5570- EXEC SQL COMMIT WORK END-EXEC */

                DatabaseConnection.Instance.CommitTransaction();

                /*" -5572- ELSE */
            }
            else
            {


                /*" -5573- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, WABEND.FILLER_9.WSQLCODE);

                /*" -5574- MOVE SQLERRD(1) TO WSQLERRD1 */
                _.Move(DB.SQLERRD[1], WABEND.FILLER_9.WSQLERRD1);

                /*" -5575- MOVE SQLERRD(2) TO WSQLERRD2 */
                _.Move(DB.SQLERRD[2], WABEND.FILLER_9.WSQLERRD2);

                /*" -5576- DISPLAY WABEND */
                _.Display(WABEND);

                /*" -5577- DISPLAY '*** PF0642B *** ROLLBACK EM ANDAMENTO ...' */
                _.Display($"*** PF0642B *** ROLLBACK EM ANDAMENTO ...");

                /*" -5578- MOVE 'ROLLBACK WORK' TO COMANDO */
                _.Move("ROLLBACK WORK", WABEND.LOCALIZA_ABEND_2.COMANDO);

                /*" -5578- EXEC SQL ROLLBACK WORK END-EXEC */

                DatabaseConnection.Instance.RollbackTransaction();

                /*" -5581- MOVE 99 TO RETURN-CODE. */
                _.Move(99, RETURN_CODE);
            }


            /*" -5581- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}