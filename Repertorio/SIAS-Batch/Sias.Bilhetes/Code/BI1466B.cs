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
using Sias.Bilhetes.DB2.BI1466B;

namespace Code
{
    public class BI1466B
    {
        public bool IsCall { get; set; }

        public BI1466B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *     GERA ARQUIVO ANALITICO DE BILHETES AP EM CRITICA.          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.06  * VERSAO 06 - DEMANDA 402.982                                    *      */
        /*"      *           - SUBSTITUIR CONSULTA DA TABELA BILHETE_ERROS        *      */
        /*"      *             PELA NA NOVA TABELA VG_CRITICA_PROPOSTA            *      */
        /*"      *           - SOMAR 10000 AOS COD-ERRO UTILIZADOS NAS TABELAS    *      */
        /*"      *             DE BILHETE E VIDA AO MESMO TEMPO                   *      */
        /*"      *                                                                *      */
        /*"      * EM 14/02/2023 - ELIERMES OLIVEIRA                              *      */
        /*"      *                                        PROCURE POR V.06        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 05 - HISTORIA 192977                                  *      */
        /*"      *               PASSAR A LISTAR ERROS DE BILHETES DO RAMO 69     *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/03/2019 - BRICEHO(ALTRAN)          PROCURE POR V.05    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 04 - HISTORIA 180114                                  *      */
        /*"      *               PASSAR A LISTAR ERROS DE BILHETES DO RAMO 37     *      */
        /*"      *                                                                *      */
        /*"      *   EM 19/02/2019 - BRICEHO(ALTRAN)          PROCURE POR V.04    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO ..............  02/09/2010                         *      */
        /*"      *   CAD-47136   - MARCO PAIVA (FAST COMPUTER) - CAD45765         *      */
        /*"      *                 TRATAR OS PRODUTOS (SYSTEM CRED)               *      */
        /*"      *                 - 8114 (AP VIDA TRANQUILA PREMIADO EDUCACIONAL)*      */
        /*"      *                 - 8115 (AP VIDA TRANQUILA PREMIADO SAF)        *      */
        /*"      *                 - 8116 (AP VIDA TRANQUILO PREMIADO CHECK LAR)  *      */
        /*"      *                 - 8117 (AP VIDA TRANQUILO PREMIADO HELP DESK)  *      */
        /*"      *                 - 8118 (AP VIDA TRANQUILO PREMIADO NUTRICIONAL)*      */
        /*"      *                                                                *      */
        /*"      *                                         PROCURE POR V.03       *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 02 - DESPRESA REGISTRO QUANDO O RCAP NAO ESTIVER      *      */
        /*"      *               PENDENTE.                                        *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/07/2007 - FAST COMPUTER            PROCURE POR V.02    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     *  16/02/00  *   MESSIAS    *                       *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _ABI1466B { get; set; } = new FileBasis(new PIC("X", "500", "X(500)"));

        public FileBasis ABI1466B
        {
            get
            {
                _.Move(REG_ABI1466B, _ABI1466B); VarBasis.RedefinePassValue(REG_ABI1466B, _ABI1466B, REG_ABI1466B); return _ABI1466B;
            }
        }
        public FileBasis _DBI1466B { get; set; } = new FileBasis(new PIC("X", "200", "X(200)"));

        public FileBasis DBI1466B
        {
            get
            {
                _.Move(REG_DBI1466B, _DBI1466B); VarBasis.RedefinePassValue(REG_DBI1466B, _DBI1466B, REG_DBI1466B); return _DBI1466B;
            }
        }
        public SortBasis<BI1466B_REG_SBI1466B> SBI1466B { get; set; } = new SortBasis<BI1466B_REG_SBI1466B>(new BI1466B_REG_SBI1466B());
        /*"01            REG-ABI1466B        PIC X(500).*/
        public StringBasis REG_ABI1466B { get; set; } = new StringBasis(new PIC("X", "500", "X(500)."), @"");
        /*"01            REG-DBI1466B        PIC X(200).*/
        public StringBasis REG_DBI1466B { get; set; } = new StringBasis(new PIC("X", "200", "X(200)."), @"");
        /*"01            REG-SBI1466B.*/
        public BI1466B_REG_SBI1466B REG_SBI1466B { get; set; } = new BI1466B_REG_SBI1466B();
        public class BI1466B_REG_SBI1466B : VarBasis
        {
            /*"    05        SVA-NUMBIL          PIC  9(015).*/
            public IntBasis SVA_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        SVA-CODPRODU        PIC  9(004).*/
            public IntBasis SVA_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-DTQITBCO        PIC  X(010).*/
            public StringBasis SVA_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-CODUSU          PIC  X(008).*/
            public StringBasis SVA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        SVA-PROFISSAO       PIC  X(008).*/
            public StringBasis SVA_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        SVA-AGECOBR         PIC  9(004).*/
            public IntBasis SVA_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-CDFONTE         PIC  9(004).*/
            public IntBasis SVA_CDFONTE { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-CDESCNEG        PIC  9(004).*/
            public IntBasis SVA_CDESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05        SVA-VLPREMIO        PIC  9(13)V99.*/
            public DoubleBasis SVA_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99."), 2);
            /*"    05        SVA-SITUACAO        PIC  X(01).*/
            public StringBasis SVA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"    05        SVA-NOME-RAZAO      PIC  X(40).*/
            public StringBasis SVA_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05        SVA-CGCCPF          PIC  9(14).*/
            public IntBasis SVA_CGCCPF { get; set; } = new IntBasis(new PIC("9", "14", "9(14)."));
            /*"    05        SVA-DTNASC          PIC  X(10).*/
            public StringBasis SVA_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"    05        SVA-ENDERECO        PIC  X(40).*/
            public StringBasis SVA_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"    05        SVA-BAIRRO          PIC  X(20).*/
            public StringBasis SVA_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"    05        SVA-CIDADE          PIC  X(20).*/
            public StringBasis SVA_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"    05        SVA-SIGLA-UF        PIC  X(02).*/
            public StringBasis SVA_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"    05        SVA-CEP             PIC  9(08).*/
            public IntBasis SVA_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
            /*"    05        SVA-DDD             PIC  9(04).*/
            public IntBasis SVA_DDD { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"    05        SVA-TELEFONE        PIC  9(09).*/
            public IntBasis SVA_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"    05        SVA-RAMO            PIC  9(03).*/
            public IntBasis SVA_RAMO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
            /*"    05        SVA-COD-ERRO        PIC  9(05).*/
            public IntBasis SVA_COD_ERRO { get; set; } = new IntBasis(new PIC("9", "5", "9(05)."));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"*/
        public IntBasis I01 { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"77            WHOST-NUMTIT        PIC S9(13) COMP-3.*/
        public IntBasis WHOST_NUMTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            WHOST-APOLICE       PIC S9(13) COMP-3.*/
        public IntBasis WHOST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            WHOST-CODSUBES      PIC S9(04) COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-COD-ESCNEG    PIC S9(04) COMP.*/
        public IntBasis WHOST_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-CODPRODU      PIC S9(04) COMP.*/
        public IntBasis WHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-SITUACAO      PIC  X(01).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            WHOST-DTINICIAL     PIC  X(10).*/
        public StringBasis WHOST_DTINICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL       PIC  X(10).*/
        public StringBasis WHOST_DTFINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0FONT-CODFTE       PIC S9(04) COMP.*/
        public IntBasis V0FONT_CODFTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0FONT-NOMEFTE      PIC  X(40).*/
        public StringBasis V0FONT_NOMEFTE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0PROD-NOMPRODU     PIC  X(40).*/
        public StringBasis V0PROD_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V1SIST-DTMOVABE     PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE-1Y  PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE_1Y { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTHOJE       PIC  X(10).*/
        public StringBasis V1SIST_DTHOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0CONT-DATCEF       PIC  X(10).*/
        public StringBasis V0CONT_DATCEF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0ESCN-CODESC       PIC S9(04) COMP.*/
        public IntBasis V0ESCN_CODESC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0ESCN-NOMEESC      PIC  X(40).*/
        public StringBasis V0ESCN_NOMEESC { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0ESCN-FONTE        PIC S9(04) COMP.*/
        public IntBasis V0ESCN_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-AGECOBR     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_AGECOBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-VLPREMIO    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PROP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V0PROP-PROFISSAO   PIC  X(20).*/
        public StringBasis V0PROP_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"77            V0PROP-APOLICE     PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0PROP-CODSUBES    PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-NUMBIL      PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0PROP-RAMO        PIC S9(04)    COMP.*/
        public IntBasis V0PROP_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-CODUSU      PIC  X(08).*/
        public StringBasis V0PROP_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
        /*"77            V0PROP-CODCLIEN    PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0PROP-OCOREND     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_OCOREND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROP-DTQITBCO    PIC  X(10).*/
        public StringBasis V0PROP_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROP-SITUACAO    PIC  X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            CONV-NUM-SICOB     PIC S9(15)    COMP-3.*/
        public IntBasis CONV_NUM_SICOB { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0CLIE-NOME-RAZAO  PIC  X(40).*/
        public StringBasis V0CLIE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0CLIE-CGCCPF      PIC S9(15)    COMP-3.*/
        public IntBasis V0CLIE_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0CLIE-DTNASC      PIC  X(10).*/
        public StringBasis V0CLIE_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            VIND-DTNASC        PIC S9(04)    COMP.*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77             V0ENDE-ENDERECO     PIC  X(040).*/
        public StringBasis V0ENDE_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"77             V0ENDE-BAIRRO       PIC  X(020).*/
        public StringBasis V0ENDE_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77             V0ENDE-CIDADE       PIC  X(020).*/
        public StringBasis V0ENDE_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
        /*"77             V0ENDE-SIGLA-UF     PIC  X(002).*/
        public StringBasis V0ENDE_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77             V0ENDE-CEP          PIC S9(009) COMP.*/
        public IntBasis V0ENDE_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77             V0ENDE-DDD          PIC S9(004) COMP.*/
        public IntBasis V0ENDE_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77             V0ENDE-TELEFONE     PIC S9(009) COMP.*/
        public IntBasis V0ENDE_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77            V0MALHA-CDESCNEG     PIC S9(04)    COMP.*/
        public IntBasis V0MALHA_CDESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0MALHA-CDFONTE      PIC S9(04)    COMP.*/
        public IntBasis V0MALHA_CDFONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WORK-AREA.*/
        public BI1466B_WORK_AREA WORK_AREA { get; set; } = new BI1466B_WORK_AREA();
        public class BI1466B_WORK_AREA : VarBasis
        {
            /*"    05        DATA-SQL.*/
            public BI1466B_DATA_SQL DATA_SQL { get; set; } = new BI1466B_DATA_SQL();
            public class BI1466B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        IND                 PIC  9(005) VALUE ZEROS.*/
            }
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WS-TIME             PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-ESCNEG           PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_ESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-FONTE-ANT        PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_FONTE_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-COD-ESCNEG-ANT   PIC  9(004) VALUE 9999.*/
            public IntBasis WS_COD_ESCNEG_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"), 9999);
            /*"    05        WS-APOLICE-ANT      PIC  9(013) VALUE ZEROS.*/
            public IntBasis WS_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05        WS-CODSUBES-ANT     PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-ESCNEG-ANT       PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_ESCNEG_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WFIM-V0COMISICOB    PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_V0COMISICOB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-V1SISTEMA      PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SORT           PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SORT1          PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SORT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-FONTES         PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_FONTES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-ESCNEG         PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_ESCNEG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-CONTA            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WABEND.*/
            public BI1466B_WABEND WABEND { get; set; } = new BI1466B_WABEND();
            public class BI1466B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' BI1466B'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" BI1466B");
                /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05        LD00.*/
            }
            public BI1466B_LD00 LD00 { get; set; } = new BI1466B_LD00();
            public class BI1466B_LD00 : VarBasis
            {
                /*"      10      FILLER              PIC X(07)   VALUE 'BI1466B'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"BI1466B");
                /*"      10      FILLER              PIC X(08)   VALUE  SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"");
                /*"      10      FILLER              PIC X(44)   VALUE             'ESTOQUE DE PROPOSTAS EM CRITICA POR PRODUTO'.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "44", "X(44)"), @"ESTOQUE DE PROPOSTAS EM CRITICA POR PRODUTO");
                /*"      10      FILLER              PIC X(08)   VALUE             ' DATA : '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @" DATA : ");
                /*"      10      LD00-DATAINI        PIC X(10).*/
                public StringBasis LD00_DATAINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"      10      FILLER              PIC X(03)   VALUE ';'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @";");
                /*"    05        LD00-1.*/
            }
            public BI1466B_LD00_1 LD00_1 { get; set; } = new BI1466B_LD00_1();
            public class BI1466B_LD00_1 : VarBasis
            {
                /*"      10      FILLER              PIC X(07)   VALUE 'PRODUTO'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(06)   VALUE 'FILIAL'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"FILIAL");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(02)   VALUE 'EN'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"EN");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(11)   VALUE             'CERTIFICADO'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(04)   VALUE 'NOME'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"NOME");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(09)   VALUE 'PROFISSAO'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PROFISSAO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(03)   VALUE 'CPF'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CPF");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(06)   VALUE 'DTNASC'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"DTNASC");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(03)   VALUE 'DDD'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"DDD");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(08)   VALUE 'TELEFONE'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"TELEFONE");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(08)   VALUE 'ENDERECO'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"ENDERECO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(06)   VALUE 'BAIRRO'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"BAIRRO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(06)   VALUE 'CIDADE'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"CIDADE");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(02)   VALUE 'UF'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"UF");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(03)   VALUE 'CEP'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CEP");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(08)   VALUE 'QUITACAO'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"QUITACAO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(07)   VALUE 'AGENCIA'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AGENCIA");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(06)   VALUE 'PREMIO'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"PREMIO");
                /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      FILLER              PIC X(07)   VALUE 'USUARIO'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"USUARIO");
                /*"    05        LD01.*/
            }
            public BI1466B_LD01 LD01 { get; set; } = new BI1466B_LD01();
            public class BI1466B_LD01 : VarBasis
            {
                /*"      10      LD01-NOMPRODU       PIC X(30)   VALUE SPACES.*/
                public StringBasis LD01_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "30", "X(30)"), @"");
                /*"      10      LD01-FIL1           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CODFILIAL      PIC 9(04)   VALUE ZEROES.*/
                public IntBasis LD01_CODFILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"      10      LD01-TRA1           PIC X(01)   VALUE '-'.*/
                public StringBasis LD01_TRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      10      LD01-NOMFILIAL      PIC X(31)   VALUE SPACES.*/
                public StringBasis LD01_NOMFILIAL { get; set; } = new StringBasis(new PIC("X", "31", "X(31)"), @"");
                /*"      10      LD01-FIL2           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-COD-ESCNEG     PIC 9(04)   VALUE ZEROES.*/
                public IntBasis LD01_COD_ESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"      10      LD01-TRA1A          PIC X(01)   VALUE '-'.*/
                public StringBasis LD01_TRA1A { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
                /*"      10      LD01-REGIAO-ESCNEG  PIC X(31)   VALUE SPACES.*/
                public StringBasis LD01_REGIAO_ESCNEG { get; set; } = new StringBasis(new PIC("X", "31", "X(31)"), @"");
                /*"      10      LD01-FIL2A          PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL2A { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-NUMBIL         PIC 9(15).*/
                public IntBasis LD01_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"      10      LD01-FIL3           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-NOME-RAZAO     PIC X(40).*/
                public StringBasis LD01_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      LD01-FIL3-A         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_A { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-PROFISSAO      PIC X(20).*/
                public StringBasis LD01_PROFISSAO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      LD01-FIL3-AB        PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_AB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CGCCPF         PIC 9(15).*/
                public IntBasis LD01_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"      10      LD01-FIL3-B         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_B { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-DTNASC         PIC X(10).*/
                public StringBasis LD01_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"      10      LD01-FIL3-BA        PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_BA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-DDD            PIC 9(04).*/
                public IntBasis LD01_DDD { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      LD01-FIL3-C         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_C { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-TELEFONE       PIC 9(09).*/
                public IntBasis LD01_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
                /*"      10      LD01-FIL3-D         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_D { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-ENDERECO       PIC X(40).*/
                public StringBasis LD01_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      LD01-FIL3-E         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_E { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-BAIRRO         PIC X(20).*/
                public StringBasis LD01_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      LD01-FIL3-F         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_F { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CIDADE         PIC X(20).*/
                public StringBasis LD01_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
                /*"      10      LD01-FIL3-G         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_G { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-SIGLA-UF       PIC X(02).*/
                public StringBasis LD01_SIGLA_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
                /*"      10      LD01-FIL3-H         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_H { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CEP            PIC 9(08).*/
                public IntBasis LD01_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(08)."));
                /*"      10      LD01-FIL3-I         PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL3_I { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-DTQITBCO       PIC X(10).*/
                public StringBasis LD01_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
                /*"      10      LD01-FIL4           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-AGECOBR        PIC 9(04).*/
                public IntBasis LD01_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      LD01-FIL5           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-VLPREMIO       PIC 9999999999999,99.*/
                public DoubleBasis LD01_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
                /*"      10      LD01-FIL6           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CODUSU         PIC X(08).*/
                public StringBasis LD01_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
                /*"      10      LD01-FIL7           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CODPRODU       PIC 9(04).*/
                public IntBasis LD01_CODPRODU { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      LD01-FIL8           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD01-CODERRO        PIC X(50).*/
                public StringBasis LD01_CODERRO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
                /*"      10      LD01-FIL9           PIC X(01)   VALUE ';'.*/
                public StringBasis LD01_FIL9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"    05        LD02.*/
            }
            public BI1466B_LD02 LD02 { get; set; } = new BI1466B_LD02();
            public class BI1466B_LD02 : VarBasis
            {
                /*"      10      LD02-COD-DOC        PIC 9(04)   VALUE 103.*/
                public IntBasis LD02_COD_DOC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"), 103);
                /*"      10      LD02-FIL1           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-AGECOBR        PIC 9(04).*/
                public IntBasis LD02_AGECOBR { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      LD02-FIL2           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL2 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-CODFILIAL      PIC 9(04)   VALUE ZEROES.*/
                public IntBasis LD02_CODFILIAL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"));
                /*"      10      LD02-FIL3           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL3 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-COD-SOLIC      PIC 9(03)   VALUE 140.*/
                public IntBasis LD02_COD_SOLIC { get; set; } = new IntBasis(new PIC("9", "3", "9(03)"), 140);
                /*"      10      LD02-FIL4           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL4 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-COD-AREA-RESP  PIC 9(04)   VALUE 11.*/
                public IntBasis LD02_COD_AREA_RESP { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"), 11);
                /*"      10      LD02-FIL5           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL5 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-COD-AREA-SOLIC PIC 9(04)   VALUE 11.*/
                public IntBasis LD02_COD_AREA_SOLIC { get; set; } = new IntBasis(new PIC("9", "4", "9(04)"), 11);
                /*"      10      LD02-FIL6           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL6 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-NUMBIL         PIC 9(15).*/
                public IntBasis LD02_NUMBIL { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"      10      LD02-FIL7           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL7 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-NOME-RAZAO     PIC X(40).*/
                public StringBasis LD02_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"      10      LD02-FIL8           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL8 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-CGCCPF         PIC 9(15).*/
                public IntBasis LD02_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
                /*"      10      LD02-FIL9           PIC X(01)   VALUE ';'.*/
                public StringBasis LD02_FIL9 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"      10      LD02-DESC-DOC.*/
                public BI1466B_LD02_DESC_DOC LD02_DESC_DOC { get; set; } = new BI1466B_LD02_DESC_DOC();
                public class BI1466B_LD02_DESC_DOC : VarBasis
                {
                    /*"        15    LD02-DESC-P1        PIC X(22)   VALUE             'PROPOSTA EM CRITICA - '.*/
                    public StringBasis LD02_DESC_P1 { get; set; } = new StringBasis(new PIC("X", "22", "X(22)"), @"PROPOSTA EM CRITICA - ");
                    /*"        15    LD02-NOMPRODU       PIC X(40)   VALUE 'BILHETE AP'*/
                    public StringBasis LD02_NOMPRODU { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"BILHETE AP");
                    /*"      10      LD02-FIL10          PIC X(01)   VALUE ';'.*/
                }
                public StringBasis LD02_FIL10 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
                /*"01            TABELA-FONTES1.*/
            }
        }
        public BI1466B_TABELA_FONTES1 TABELA_FONTES1 { get; set; } = new BI1466B_TABELA_FONTES1();
        public class BI1466B_TABELA_FONTES1 : VarBasis
        {
            /*"    10      TAB-FTE1            OCCURS 99 TIMES.*/
            public ListBasis<BI1466B_TAB_FTE1> TAB_FTE1 { get; set; } = new ListBasis<BI1466B_TAB_FTE1>(99);
            public class BI1466B_TAB_FTE1 : VarBasis
            {
                /*"      15    TBFT-NMFONTE        PIC  X(040).*/
                public StringBasis TBFT_NMFONTE { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"01            TABELA-FONTES.*/
            }
        }
        public BI1466B_TABELA_FONTES TABELA_FONTES { get; set; } = new BI1466B_TABELA_FONTES();
        public class BI1466B_TABELA_FONTES : VarBasis
        {
            /*"    10      TAB-FTE             OCCURS 99 TIMES.*/
            public ListBasis<BI1466B_TAB_FTE> TAB_FTE { get; set; } = new ListBasis<BI1466B_TAB_FTE>(99);
            public class BI1466B_TAB_FTE : VarBasis
            {
                /*"      15    TBFT-QT-ESTOQ       PIC  9(006).*/
                public IntBasis TBFT_QT_ESTOQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      15    TBFT-VL-ESTOQ       PIC  9(013)V99.*/
                public DoubleBasis TBFT_VL_ESTOQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"01            TABELA-ESCNEG.*/
            }
        }
        public BI1466B_TABELA_ESCNEG TABELA_ESCNEG { get; set; } = new BI1466B_TABELA_ESCNEG();
        public class BI1466B_TABELA_ESCNEG : VarBasis
        {
            /*"    10      TAB-EN              OCCURS 200 TIMES                                INDEXED BY I01.*/
            public ListBasis<BI1466B_TAB_EN> TAB_EN { get; set; } = new ListBasis<BI1466B_TAB_EN>(200);
            public class BI1466B_TAB_EN : VarBasis
            {
                /*"      15    TBEN-CDFONTE        PIC  9(002).*/
                public IntBasis TBEN_CDFONTE { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      15    TBEN-CDESCNEG       PIC  9(004).*/
                public IntBasis TBEN_CDESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      15    TBEN-NMESCNEG       PIC  X(030).*/
                public StringBasis TBEN_NMESCNEG { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"      15    TBEN-QT-ESTOQ       PIC  9(006).*/
                public IntBasis TBEN_QT_ESTOQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      15    TBEN-VL-ESTOQ       PIC  9(013)V99.*/
                public DoubleBasis TBEN_VL_ESTOQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"01            WZEROS              PIC S9(005) VALUE +0 COMP-3.*/
            }
        }
        public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));


        public Dclgens.BILHEERR BILHEERR { get; set; } = new Dclgens.BILHEERR();
        public BI1466B_TCOMIS TCOMIS { get; set; } = new BI1466B_TCOMIS();
        public BI1466B_CFONTES CFONTES { get; set; } = new BI1466B_CFONTES();
        public BI1466B_CESCNEG CESCNEG { get; set; } = new BI1466B_CESCNEG();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SBI1466B_FILE_NAME_P, string ABI1466B_FILE_NAME_P, string DBI1466B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SBI1466B.SetFile(SBI1466B_FILE_NAME_P);
                ABI1466B.SetFile(ABI1466B_FILE_NAME_P);
                DBI1466B.SetFile(DBI1466B_FILE_NAME_P);

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
            /*" -431- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -434- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -437- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -440- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -441- DISPLAY '*        PROGRAMA EM EXECUCAO: BI1466B         *' . */
            _.Display($"*        PROGRAMA EM EXECUCAO: BI1466B         *");

            /*" -442- DISPLAY '*                                              *' . */
            _.Display($"*                                              *");

            /*" -443- DISPLAY '*  VERSAO:  09 - DEMANDA 402.982 - 16/11/2022  *' . */
            _.Display($"*  VERSAO:  09 - DEMANDA 402.982 - 16/11/2022  *");

            /*" -444- DISPLAY '************************************************' . */
            _.Display($"************************************************");

            /*" -457- DISPLAY '*  BI1466B - INICIO  EM ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2). */

            $"*  BI1466B - INICIO  EM {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -457- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -463- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -467- INITIALIZE TABELA-FONTES TABELA-ESCNEG LD01. */
            _.Initialize(
                TABELA_FONTES
                , TABELA_ESCNEG
                , WORK_AREA.LD01
            );

            /*" -468- PERFORM R3100-00-DECLARE-FONTES. */

            R3100_00_DECLARE_FONTES_SECTION();

            /*" -470- PERFORM R3110-00-FETCH-FONTES. */

            R3110_00_FETCH_FONTES_SECTION();

            /*" -471- IF WFIM-FONTES NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_FONTES.IsEmpty())
            {

                /*" -472- DISPLAY '0000 - PROBLEMA NO FETCH DA FONTES      ' */
                _.Display($"0000 - PROBLEMA NO FETCH DA FONTES      ");

                /*" -474- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -477- PERFORM R3120-00-CARREGA-FONTES UNTIL WFIM-FONTES EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_FONTES == "S"))
            {

                R3120_00_CARREGA_FONTES_SECTION();
            }

            /*" -478- PERFORM R3200-00-DECLARE-ESCNEG. */

            R3200_00_DECLARE_ESCNEG_SECTION();

            /*" -480- PERFORM R3210-00-FETCH-ESCNEG. */

            R3210_00_FETCH_ESCNEG_SECTION();

            /*" -481- IF WFIM-ESCNEG NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_ESCNEG.IsEmpty())
            {

                /*" -482- DISPLAY '0000 - PROBLEMA NO FETCH DA ESCNEG      ' */
                _.Display($"0000 - PROBLEMA NO FETCH DA ESCNEG      ");

                /*" -484- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -486- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -487- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -488- DISPLAY '*** PROBLEMAS NA V0SISTEMA' */
                _.Display($"*** PROBLEMAS NA V0SISTEMA");

                /*" -489- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -491- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -492- PERFORM R0900-00-DECLARE-V0BILHETE. */

            R0900_00_DECLARE_V0BILHETE_SECTION();

            /*" -494- PERFORM R0910-00-FETCH-V0BILHETE. */

            R0910_00_FETCH_V0BILHETE_SECTION();

            /*" -495- IF WFIM-V0COMISICOB EQUAL 'S' */

            if (WORK_AREA.WFIM_V0COMISICOB == "S")
            {

                /*" -496- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -497- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -499- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -501- MOVE +400000 TO SORT-FILE-SIZE. */
            _.Move(+400000, SORT_FILE_SIZE);

            /*" -506- SORT SBI1466B ON ASCENDING KEY SVA-CDFONTE SVA-CDESCNEG INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-GERA-ARQ THRU R0020-FIM. */
            SORT_RETURN.Value = SBI1466B.Sort("SVA-CDFONTE,SVA-CDESCNEG", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_GERA_ARQ_SECTION());

            /*" -509- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -510- DISPLAY '*** BI1466B *** PROBLEMAS NO SORT ' */
                _.Display($"*** BI1466B *** PROBLEMAS NO SORT ");

                /*" -511- DISPLAY '*** BI1466B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** BI1466B *** SORT-RETURN = {SORT_RETURN}");

                /*" -512- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -512- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -518- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -518- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -521- DISPLAY '*** BI1466B - ' */
            _.Display($"*** BI1466B - ");

            /*" -523- DISPLAY 'LIDOS V0COMISICOBVA      ' AC-LIDOS. */
            _.Display($"LIDOS V0COMISICOBVA      {WORK_AREA.AC_LIDOS}");

            /*" -525- DISPLAY '*** BI1466B - TERMINO NORMAL ***' */
            _.Display($"*** BI1466B - TERMINO NORMAL ***");

            /*" -525- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -539- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-V0COMISICOB EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_V0COMISICOB == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

            /*" -539- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-GERA-ARQ-SECTION */
        private void R0020_00_GERA_ARQ_SECTION()
        {
            /*" -553- OPEN OUTPUT ABI1466B DBI1466B. */
            ABI1466B.Open(REG_ABI1466B);
            DBI1466B.Open(REG_DBI1466B);

            /*" -554- WRITE REG-ABI1466B FROM LD00. */
            _.Move(WORK_AREA.LD00.GetMoveValues(), REG_ABI1466B);

            ABI1466B.Write(REG_ABI1466B.GetMoveValues().ToString());

            /*" -556- WRITE REG-ABI1466B FROM LD00-1. */
            _.Move(WORK_AREA.LD00_1.GetMoveValues(), REG_ABI1466B);

            ABI1466B.Write(REG_ABI1466B.GetMoveValues().ToString());

            /*" -558- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

            /*" -561- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -562- CLOSE ABI1466B DBI1466B. */
            ABI1466B.Close();
            DBI1466B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -575- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -584- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -587- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -588- DISPLAY 'BI1466B - SISTEMA VA NAO ESTA CADASTRADO' */
                _.Display($"BI1466B - SISTEMA VA NAO ESTA CADASTRADO");

                /*" -589- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", WORK_AREA.WFIM_V1SISTEMA);

                /*" -591- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -593- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -598- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_2 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_2();

            /*" -601- IF SQLCODE NOT EQUAL ZEROES */

            if (DB.SQLCODE != 00)
            {

                /*" -602- DISPLAY 'BI1466B - PROBLEMAS NO ACESSO A V0CONTROCNAB' */
                _.Display($"BI1466B - PROBLEMAS NO ACESSO A V0CONTROCNAB");

                /*" -605- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -607- MOVE V0CONT-DATCEF TO DATA-SQL. */
            _.Move(V0CONT_DATCEF, WORK_AREA.DATA_SQL);

            /*" -609- MOVE DATA-SQL TO WHOST-DTFINAL */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTFINAL);

            /*" -610- MOVE 01 TO DIA-SQL */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -611- MOVE DATA-SQL TO WHOST-DTINICIAL */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTINICIAL);

            /*" -612- MOVE V1SIST-DTHOJE(1:4) TO LD00-DATAINI(7:4) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(1, 4), WORK_AREA.LD00.LD00_DATAINI, 7, 4);

            /*" -613- MOVE '/' TO LD00-DATAINI(3:1) */
            _.MoveAtPosition("/", WORK_AREA.LD00.LD00_DATAINI, 3, 1);

            /*" -614- MOVE V1SIST-DTHOJE(6:2) TO LD00-DATAINI(4:2) */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(6, 2), WORK_AREA.LD00.LD00_DATAINI, 4, 2);

            /*" -615- MOVE '/' TO LD00-DATAINI(6:1) */
            _.MoveAtPosition("/", WORK_AREA.LD00.LD00_DATAINI, 6, 1);

            /*" -615- MOVE V1SIST-DTHOJE(9:2) TO LD00-DATAINI(1:2). */
            _.MoveAtPosition(V1SIST_DTHOJE.Substring(9, 2), WORK_AREA.LD00.LD00_DATAINI, 1, 2);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -584- EXEC SQL SELECT DTMOVABE, DTMOVABE - 1 YEAR, CURRENT DATE INTO :V1SIST-DTMOVABE, :V1SIST-DTMOVABE-1Y, :V1SIST-DTHOJE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'BI' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTMOVABE_1Y, V1SIST_DTMOVABE_1Y);
                _.Move(executed_1.V1SIST_DTHOJE, V1SIST_DTHOJE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-2 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_2()
        {
            /*" -598- EXEC SQL SELECT MAX(DATCEF) INTO :V0CONT-DATCEF FROM SEGUROS.V0CONTROCNAB WHERE NRCTACED = 63000300001004 END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CONT_DATCEF, V0CONT_DATCEF);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-SECTION */
        private void R0900_00_DECLARE_V0BILHETE_SECTION()
        {
            /*" -628- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -646- PERFORM R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1 */

            R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1();

            /*" -648- PERFORM R0900_00_DECLARE_V0BILHETE_DB_OPEN_1 */

            R0900_00_DECLARE_V0BILHETE_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0BILHETE_DB_DECLARE_1()
        {
            /*" -646- EXEC SQL DECLARE TCOMIS CURSOR FOR SELECT NUMBIL, RAMO, AGECOBR, DTQITBCO, COD_USUARIO, CODCLIEN, OCORR_ENDERECO, VLRCAP, PROFISSAO, SITUACAO FROM SEGUROS.V0BILHETE WHERE SITUACAO IN ( '1' , 'F' , 'E' ) AND DTQITBCO > :V1SIST-DTMOVABE-1Y END-EXEC. */
            TCOMIS = new BI1466B_TCOMIS(true);
            string GetQuery_TCOMIS()
            {
                var query = @$"SELECT 
							NUMBIL
							, 
							RAMO
							, 
							AGECOBR
							, 
							DTQITBCO
							, 
							COD_USUARIO
							, 
							CODCLIEN
							, 
							OCORR_ENDERECO
							, 
							VLRCAP
							, 
							PROFISSAO
							, 
							SITUACAO 
							FROM SEGUROS.V0BILHETE 
							WHERE SITUACAO IN ( '1'
							, 'F'
							, 'E' ) 
							AND DTQITBCO > '{V1SIST_DTMOVABE_1Y}'";

                return query;
            }
            TCOMIS.GetQueryEvent += GetQuery_TCOMIS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0BILHETE-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0BILHETE_DB_OPEN_1()
        {
            /*" -648- EXEC SQL OPEN TCOMIS END-EXEC. */

            TCOMIS.Open();

        }

        [StopWatch]
        /*" R3100-00-DECLARE-FONTES-DB-DECLARE-1 */
        public void R3100_00_DECLARE_FONTES_DB_DECLARE_1()
        {
            /*" -1122- EXEC SQL DECLARE CFONTES CURSOR FOR SELECT FONTE, NOMEFTE FROM SEGUROS.V0FONTE ORDER BY FONTE END-EXEC. */
            CFONTES = new BI1466B_CFONTES(false);
            string GetQuery_CFONTES()
            {
                var query = @$"SELECT FONTE
							, 
							NOMEFTE 
							FROM SEGUROS.V0FONTE 
							ORDER BY FONTE";

                return query;
            }
            CFONTES.GetQueryEvent += GetQuery_CFONTES;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0BILHETE-SECTION */
        private void R0910_00_FETCH_V0BILHETE_SECTION()
        {
            /*" -661- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -673- PERFORM R0910_00_FETCH_V0BILHETE_DB_FETCH_1 */

            R0910_00_FETCH_V0BILHETE_DB_FETCH_1();

            /*" -676- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -677- MOVE 'S' TO WFIM-V0COMISICOB */
                _.Move("S", WORK_AREA.WFIM_V0COMISICOB);

                /*" -677- PERFORM R0910_00_FETCH_V0BILHETE_DB_CLOSE_1 */

                R0910_00_FETCH_V0BILHETE_DB_CLOSE_1();

                /*" -684- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -685- IF V0PROP-RAMO NOT EQUAL 82 AND 81 AND 37 AND 69 */

            if (!V0PROP_RAMO.In("82", "81", "37", "69"))
            {

                /*" -687- GO TO R0910-00-FETCH-V0BILHETE. */
                new Task(() => R0910_00_FETCH_V0BILHETE_SECTION()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -690- ADD 1 TO AC-LIDOS AC-CONTA. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            WORK_AREA.AC_CONTA.Value = WORK_AREA.AC_CONTA + 1;

            /*" -691- IF AC-CONTA GREATER 4999 */

            if (WORK_AREA.AC_CONTA > 4999)
            {

                /*" -692- MOVE ZEROS TO AC-CONTA */
                _.Move(0, WORK_AREA.AC_CONTA);

                /*" -693- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

                /*" -693- DISPLAY 'LIDOS........... ' AC-LIDOS ' ' WS-TIME. */

                $"LIDOS........... {WORK_AREA.AC_LIDOS} {WORK_AREA.WS_TIME}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-V0BILHETE-DB-FETCH-1 */
        public void R0910_00_FETCH_V0BILHETE_DB_FETCH_1()
        {
            /*" -673- EXEC SQL FETCH TCOMIS INTO :V0PROP-NUMBIL, :V0PROP-RAMO, :V0PROP-AGECOBR, :V0PROP-DTQITBCO, :V0PROP-CODUSU, :V0PROP-CODCLIEN, :V0PROP-OCOREND, :V0PROP-VLPREMIO, :V0PROP-PROFISSAO, :V0PROP-SITUACAO END-EXEC. */

            if (TCOMIS.Fetch())
            {
                _.Move(TCOMIS.V0PROP_NUMBIL, V0PROP_NUMBIL);
                _.Move(TCOMIS.V0PROP_RAMO, V0PROP_RAMO);
                _.Move(TCOMIS.V0PROP_AGECOBR, V0PROP_AGECOBR);
                _.Move(TCOMIS.V0PROP_DTQITBCO, V0PROP_DTQITBCO);
                _.Move(TCOMIS.V0PROP_CODUSU, V0PROP_CODUSU);
                _.Move(TCOMIS.V0PROP_CODCLIEN, V0PROP_CODCLIEN);
                _.Move(TCOMIS.V0PROP_OCOREND, V0PROP_OCOREND);
                _.Move(TCOMIS.V0PROP_VLPREMIO, V0PROP_VLPREMIO);
                _.Move(TCOMIS.V0PROP_PROFISSAO, V0PROP_PROFISSAO);
                _.Move(TCOMIS.V0PROP_SITUACAO, V0PROP_SITUACAO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0BILHETE-DB-CLOSE-1 */
        public void R0910_00_FETCH_V0BILHETE_DB_CLOSE_1()
        {
            /*" -677- EXEC SQL CLOSE TCOMIS END-EXEC */

            TCOMIS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -706- PERFORM R1010-00-SELECT-CONVERSAO. */

            R1010_00_SELECT_CONVERSAO_SECTION();

            /*" -707- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -708- MOVE CONV-NUM-SICOB TO WHOST-NUMTIT */
                _.Move(CONV_NUM_SICOB, WHOST_NUMTIT);

                /*" -709- ELSE */
            }
            else
            {


                /*" -711- MOVE V0PROP-NUMBIL TO WHOST-NUMTIT. */
                _.Move(V0PROP_NUMBIL, WHOST_NUMTIT);
            }


            /*" -713- PERFORM R1020-00-SELECT-V0RCAP. */

            R1020_00_SELECT_V0RCAP_SECTION();

            /*" -714- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -716- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -717- IF WHOST-SITUACAO NOT EQUAL '0' */

            if (WHOST_SITUACAO != "0")
            {

                /*" -719- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -721- PERFORM R1100-00-SELECT-V0CLIENTE. */

            R1100_00_SELECT_V0CLIENTE_SECTION();

            /*" -722- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -724- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -726- PERFORM R1200-00-SELECT-V0ENDERECO. */

            R1200_00_SELECT_V0ENDERECO_SECTION();

            /*" -727- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -729- GO TO R1000-10-NEXT. */

                R1000_10_NEXT(); //GOTO
                return;
            }


            /*" -731- PERFORM R1300-00-SELECT-V0AGENCIACEF. */

            R1300_00_SELECT_V0AGENCIACEF_SECTION();

            /*" -733- PERFORM R1400-00-SELECT-BILHETE-ERRO. */

            R1400_00_SELECT_BILHETE_ERRO_SECTION();

            /*" -734- MOVE V0CLIE-NOME-RAZAO TO SVA-NOME-RAZAO. */
            _.Move(V0CLIE_NOME_RAZAO, REG_SBI1466B.SVA_NOME_RAZAO);

            /*" -735- MOVE V0CLIE-CGCCPF TO SVA-CGCCPF. */
            _.Move(V0CLIE_CGCCPF, REG_SBI1466B.SVA_CGCCPF);

            /*" -736- MOVE V0CLIE-DTNASC TO SVA-DTNASC. */
            _.Move(V0CLIE_DTNASC, REG_SBI1466B.SVA_DTNASC);

            /*" -737- MOVE V0ENDE-ENDERECO TO SVA-ENDERECO. */
            _.Move(V0ENDE_ENDERECO, REG_SBI1466B.SVA_ENDERECO);

            /*" -738- MOVE V0ENDE-BAIRRO TO SVA-BAIRRO. */
            _.Move(V0ENDE_BAIRRO, REG_SBI1466B.SVA_BAIRRO);

            /*" -739- MOVE V0ENDE-CIDADE TO SVA-CIDADE. */
            _.Move(V0ENDE_CIDADE, REG_SBI1466B.SVA_CIDADE);

            /*" -740- MOVE V0ENDE-SIGLA-UF TO SVA-SIGLA-UF. */
            _.Move(V0ENDE_SIGLA_UF, REG_SBI1466B.SVA_SIGLA_UF);

            /*" -741- MOVE V0ENDE-CEP TO SVA-CEP. */
            _.Move(V0ENDE_CEP, REG_SBI1466B.SVA_CEP);

            /*" -742- MOVE V0ENDE-DDD TO SVA-DDD. */
            _.Move(V0ENDE_DDD, REG_SBI1466B.SVA_DDD);

            /*" -743- MOVE V0ENDE-TELEFONE TO SVA-TELEFONE. */
            _.Move(V0ENDE_TELEFONE, REG_SBI1466B.SVA_TELEFONE);

            /*" -744- MOVE V0PROP-NUMBIL TO SVA-NUMBIL. */
            _.Move(V0PROP_NUMBIL, REG_SBI1466B.SVA_NUMBIL);

            /*" -745- MOVE V0PROP-CODUSU TO SVA-CODUSU. */
            _.Move(V0PROP_CODUSU, REG_SBI1466B.SVA_CODUSU);

            /*" -746- MOVE V0PROP-DTQITBCO TO SVA-DTQITBCO. */
            _.Move(V0PROP_DTQITBCO, REG_SBI1466B.SVA_DTQITBCO);

            /*" -747- MOVE V0PROP-AGECOBR TO SVA-AGECOBR. */
            _.Move(V0PROP_AGECOBR, REG_SBI1466B.SVA_AGECOBR);

            /*" -748- MOVE V0PROP-PROFISSAO TO SVA-PROFISSAO. */
            _.Move(V0PROP_PROFISSAO, REG_SBI1466B.SVA_PROFISSAO);

            /*" -749- MOVE V0MALHA-CDFONTE TO SVA-CDFONTE. */
            _.Move(V0MALHA_CDFONTE, REG_SBI1466B.SVA_CDFONTE);

            /*" -750- MOVE V0MALHA-CDESCNEG TO SVA-CDESCNEG. */
            _.Move(V0MALHA_CDESCNEG, REG_SBI1466B.SVA_CDESCNEG);

            /*" -751- MOVE V0PROP-VLPREMIO TO SVA-VLPREMIO. */
            _.Move(V0PROP_VLPREMIO, REG_SBI1466B.SVA_VLPREMIO);

            /*" -752- MOVE WHOST-CODPRODU TO SVA-CODPRODU. */
            _.Move(WHOST_CODPRODU, REG_SBI1466B.SVA_CODPRODU);

            /*" -753- MOVE V0PROP-RAMO TO SVA-RAMO. */
            _.Move(V0PROP_RAMO, REG_SBI1466B.SVA_RAMO);

            /*" -754- MOVE V0PROP-SITUACAO TO SVA-SITUACAO. */
            _.Move(V0PROP_SITUACAO, REG_SBI1466B.SVA_SITUACAO);

            /*" -756- MOVE BILHEERR-COD-ERRO TO SVA-COD-ERRO. */
            _.Move(BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO, REG_SBI1466B.SVA_COD_ERRO);

            /*" -756- RELEASE REG-SBI1466B. */
            SBI1466B.Release(REG_SBI1466B);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -760- PERFORM R0910-00-FETCH-V0BILHETE. */

            R0910_00_FETCH_V0BILHETE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1010-00-SELECT-CONVERSAO-SECTION */
        private void R1010_00_SELECT_CONVERSAO_SECTION()
        {
            /*" -773- MOVE '101' TO WNR-EXEC-SQL. */
            _.Move("101", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -778- PERFORM R1010_00_SELECT_CONVERSAO_DB_SELECT_1 */

            R1010_00_SELECT_CONVERSAO_DB_SELECT_1();

            /*" -781- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -781- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1010-00-SELECT-CONVERSAO-DB-SELECT-1 */
        public void R1010_00_SELECT_CONVERSAO_DB_SELECT_1()
        {
            /*" -778- EXEC SQL SELECT NUM_SICOB INTO :CONV-NUM-SICOB FROM SEGUROS.CONVERSAO_SICOB WHERE NUM_PROPOSTA_SIVPF = :V0PROP-NUMBIL END-EXEC. */

            var r1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1 = new R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1()
            {
                V0PROP_NUMBIL = V0PROP_NUMBIL.ToString(),
            };

            var executed_1 = R1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1.Execute(r1010_00_SELECT_CONVERSAO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONV_NUM_SICOB, CONV_NUM_SICOB);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1010_99_SAIDA*/

        [StopWatch]
        /*" R1020-00-SELECT-V0RCAP-SECTION */
        private void R1020_00_SELECT_V0RCAP_SECTION()
        {
            /*" -794- MOVE '102' TO WNR-EXEC-SQL. */
            _.Move("102", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -801- PERFORM R1020_00_SELECT_V0RCAP_DB_SELECT_1 */

            R1020_00_SELECT_V0RCAP_DB_SELECT_1();

            /*" -804- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -804- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1020-00-SELECT-V0RCAP-DB-SELECT-1 */
        public void R1020_00_SELECT_V0RCAP_DB_SELECT_1()
        {
            /*" -801- EXEC SQL SELECT CODPRODU , SITUACAO INTO :WHOST-CODPRODU , :WHOST-SITUACAO FROM SEGUROS.V0RCAP WHERE NRTIT = :WHOST-NUMTIT END-EXEC. */

            var r1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1 = new R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1()
            {
                WHOST_NUMTIT = WHOST_NUMTIT.ToString(),
            };

            var executed_1 = R1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1.Execute(r1020_00_SELECT_V0RCAP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_CODPRODU, WHOST_CODPRODU);
                _.Move(executed_1.WHOST_SITUACAO, WHOST_SITUACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1020_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V0CLIENTE-SECTION */
        private void R1100_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -817- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -826- PERFORM R1100_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R1100_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -829- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -831- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -832- IF VIND-DTNASC LESS +0 */

            if (VIND_DTNASC < +0)
            {

                /*" -832- MOVE '0001-01-01' TO V0CLIE-DTNASC. */
                _.Move("0001-01-01", V0CLIE_DTNASC);
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R1100_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -826- EXEC SQL SELECT NOME_RAZAO, CGCCPF, DATA_NASCIMENTO INTO :V0CLIE-NOME-RAZAO, :V0CLIE-CGCCPF, :V0CLIE-DTNASC:VIND-DTNASC FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0PROP-CODCLIEN END-EXEC. */

            var r1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME_RAZAO, V0CLIE_NOME_RAZAO);
                _.Move(executed_1.V0CLIE_CGCCPF, V0CLIE_CGCCPF);
                _.Move(executed_1.V0CLIE_DTNASC, V0CLIE_DTNASC);
                _.Move(executed_1.VIND_DTNASC, VIND_DTNASC);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0ENDERECO-SECTION */
        private void R1200_00_SELECT_V0ENDERECO_SECTION()
        {
            /*" -845- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -863- PERFORM R1200_00_SELECT_V0ENDERECO_DB_SELECT_1 */

            R1200_00_SELECT_V0ENDERECO_DB_SELECT_1();

            /*" -866- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -866- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0ENDERECO-DB-SELECT-1 */
        public void R1200_00_SELECT_V0ENDERECO_DB_SELECT_1()
        {
            /*" -863- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP, DDD, TELEFONE INTO :V0ENDE-ENDERECO, :V0ENDE-BAIRRO, :V0ENDE-CIDADE, :V0ENDE-SIGLA-UF, :V0ENDE-CEP, :V0ENDE-DDD, :V0ENDE-TELEFONE FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V0PROP-CODCLIEN AND OCORR_ENDERECO = :V0PROP-OCOREND END-EXEC. */

            var r1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1 = new R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1()
            {
                V0PROP_CODCLIEN = V0PROP_CODCLIEN.ToString(),
                V0PROP_OCOREND = V0PROP_OCOREND.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V0ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDE_ENDERECO, V0ENDE_ENDERECO);
                _.Move(executed_1.V0ENDE_BAIRRO, V0ENDE_BAIRRO);
                _.Move(executed_1.V0ENDE_CIDADE, V0ENDE_CIDADE);
                _.Move(executed_1.V0ENDE_SIGLA_UF, V0ENDE_SIGLA_UF);
                _.Move(executed_1.V0ENDE_CEP, V0ENDE_CEP);
                _.Move(executed_1.V0ENDE_DDD, V0ENDE_DDD);
                _.Move(executed_1.V0ENDE_TELEFONE, V0ENDE_TELEFONE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0AGENCIACEF-SECTION */
        private void R1300_00_SELECT_V0AGENCIACEF_SECTION()
        {
            /*" -879- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -888- PERFORM R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1 */

            R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1();

            /*" -891- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -892- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -893- MOVE 99 TO V0MALHA-CDFONTE */
                    _.Move(99, V0MALHA_CDFONTE);

                    /*" -894- MOVE 4172 TO V0MALHA-CDESCNEG */
                    _.Move(4172, V0MALHA_CDESCNEG);

                    /*" -895- ELSE */
                }
                else
                {


                    /*" -895- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0AGENCIACEF-DB-SELECT-1 */
        public void R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1()
        {
            /*" -888- EXEC SQL SELECT B.COD_FONTE, A.COD_ESCNEG INTO :V0MALHA-CDFONTE, :V0MALHA-CDESCNEG FROM SEGUROS.V0AGENCIACEF A, SEGUROS.V0MALHACEF B WHERE A.COD_AGENCIA = :V0PROP-AGECOBR AND B.COD_SUREG = A.COD_ESCNEG END-EXEC. */

            var r1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1 = new R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1()
            {
                V0PROP_AGECOBR = V0PROP_AGECOBR.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V0AGENCIACEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0MALHA_CDFONTE, V0MALHA_CDFONTE);
                _.Move(executed_1.V0MALHA_CDESCNEG, V0MALHA_CDESCNEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-BILHETE-ERRO-SECTION */
        private void R1400_00_SELECT_BILHETE_ERRO_SECTION()
        {
            /*" -919- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -932- PERFORM R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1 */

            R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1();

            /*" -936- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -937- MOVE ZEROS TO BILHEERR-COD-ERRO */
                _.Move(0, BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO);

                /*" -938- ELSE */
            }
            else
            {


                /*" -939- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -939- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-BILHETE-ERRO-DB-SELECT-1 */
        public void R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1()
        {
            /*" -932- EXEC SQL SELECT A.NUM_CERTIFICADO, A.COD_MSG_CRITICA INTO :BILHEERR-NUM-BILHETE, :BILHEERR-COD-ERRO FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :V0PROP-NUMBIL AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND A.COD_MSG_CRITICA = B.COD_MSG_CRITICA AND B.COD_TP_MSG_CRITICA <> '3' FETCH FIRST 1 ROWS ONLY WITH UR END-EXEC. */

            var r1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1 = new R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1()
            {
                V0PROP_NUMBIL = V0PROP_NUMBIL.ToString(),
            };

            var executed_1 = R1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_BILHETE_ERRO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.BILHEERR_NUM_BILHETE, BILHEERR.DCLBILHETE_ERROS.BILHEERR_NUM_BILHETE);
                _.Move(executed_1.BILHEERR_COD_ERRO, BILHEERR.DCLBILHETE_ERROS.BILHEERR_COD_ERRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -952- MOVE SVA-CDFONTE TO WS-FONTE-ANT. */
            _.Move(REG_SBI1466B.SVA_CDFONTE, WORK_AREA.WS_FONTE_ANT);

            /*" -954- PERFORM R2200-00-PROCESSA-FONTE UNTIL SVA-CDFONTE NOT EQUAL WS-FONTE-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_SBI1466B.SVA_CDFONTE != WORK_AREA.WS_FONTE_ANT || WORK_AREA.WFIM_SORT == "S"))
            {

                R2200_00_PROCESSA_FONTE_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-PROCESSA-FONTE-SECTION */
        private void R2200_00_PROCESSA_FONTE_SECTION()
        {
            /*" -968- MOVE '-' TO LD01-TRA1 LD01-TRA1A */
            _.Move("-", WORK_AREA.LD01.LD01_TRA1, WORK_AREA.LD01.LD01_TRA1A);

            /*" -1000- MOVE ';' TO LD01-FIL1 LD01-FIL2 LD01-FIL2A LD01-FIL3 LD01-FIL3-A LD01-FIL3-AB LD01-FIL3-B LD01-FIL3-BA LD01-FIL3-C LD01-FIL3-D LD01-FIL3-E LD01-FIL3-F LD01-FIL3-G LD01-FIL3-H LD01-FIL3-I LD01-FIL4 LD01-FIL5 LD01-FIL6 LD01-FIL7 LD01-FIL8 LD01-FIL9 LD02-FIL1 LD02-FIL2 LD02-FIL3 LD02-FIL4 LD02-FIL5 LD02-FIL6 LD02-FIL7 LD02-FIL8 LD02-FIL9 LD02-FIL10 */
            _.Move(";", WORK_AREA.LD01.LD01_FIL1, WORK_AREA.LD01.LD01_FIL2, WORK_AREA.LD01.LD01_FIL2A, WORK_AREA.LD01.LD01_FIL3, WORK_AREA.LD01.LD01_FIL3_A, WORK_AREA.LD01.LD01_FIL3_AB, WORK_AREA.LD01.LD01_FIL3_B, WORK_AREA.LD01.LD01_FIL3_BA, WORK_AREA.LD01.LD01_FIL3_C, WORK_AREA.LD01.LD01_FIL3_D, WORK_AREA.LD01.LD01_FIL3_E, WORK_AREA.LD01.LD01_FIL3_F, WORK_AREA.LD01.LD01_FIL3_G, WORK_AREA.LD01.LD01_FIL3_H, WORK_AREA.LD01.LD01_FIL3_I, WORK_AREA.LD01.LD01_FIL4, WORK_AREA.LD01.LD01_FIL5, WORK_AREA.LD01.LD01_FIL6, WORK_AREA.LD01.LD01_FIL7, WORK_AREA.LD01.LD01_FIL8, WORK_AREA.LD01.LD01_FIL9, WORK_AREA.LD02.LD02_FIL1, WORK_AREA.LD02.LD02_FIL2, WORK_AREA.LD02.LD02_FIL3, WORK_AREA.LD02.LD02_FIL4, WORK_AREA.LD02.LD02_FIL5, WORK_AREA.LD02.LD02_FIL6, WORK_AREA.LD02.LD02_FIL7, WORK_AREA.LD02.LD02_FIL8, WORK_AREA.LD02.LD02_FIL9, WORK_AREA.LD02.LD02_FIL10);

            /*" -1001- IF SVA-CDESCNEG NOT EQUAL WS-COD-ESCNEG-ANT */

            if (REG_SBI1466B.SVA_CDESCNEG != WORK_AREA.WS_COD_ESCNEG_ANT)
            {

                /*" -1003- MOVE SVA-CDESCNEG TO WS-COD-ESCNEG-ANT WHOST-COD-ESCNEG */
                _.Move(REG_SBI1466B.SVA_CDESCNEG, WORK_AREA.WS_COD_ESCNEG_ANT, WHOST_COD_ESCNEG);

                /*" -1004- PERFORM R3190-00-SELECT-ESCNEG */

                R3190_00_SELECT_ESCNEG_SECTION();

                /*" -1006- MOVE V0ESCN-NOMEESC TO LD01-REGIAO-ESCNEG. */
                _.Move(V0ESCN_NOMEESC, WORK_AREA.LD01.LD01_REGIAO_ESCNEG);
            }


            /*" -1009- MOVE SVA-NOME-RAZAO TO LD01-NOME-RAZAO LD02-NOME-RAZAO. */
            _.Move(REG_SBI1466B.SVA_NOME_RAZAO, WORK_AREA.LD01.LD01_NOME_RAZAO, WORK_AREA.LD02.LD02_NOME_RAZAO);

            /*" -1012- MOVE SVA-CGCCPF TO LD01-CGCCPF LD02-CGCCPF. */
            _.Move(REG_SBI1466B.SVA_CGCCPF, WORK_AREA.LD01.LD01_CGCCPF, WORK_AREA.LD02.LD02_CGCCPF);

            /*" -1013- MOVE SVA-ENDERECO TO LD01-ENDERECO. */
            _.Move(REG_SBI1466B.SVA_ENDERECO, WORK_AREA.LD01.LD01_ENDERECO);

            /*" -1014- MOVE SVA-PROFISSAO TO LD01-PROFISSAO. */
            _.Move(REG_SBI1466B.SVA_PROFISSAO, WORK_AREA.LD01.LD01_PROFISSAO);

            /*" -1015- MOVE SVA-BAIRRO TO LD01-BAIRRO. */
            _.Move(REG_SBI1466B.SVA_BAIRRO, WORK_AREA.LD01.LD01_BAIRRO);

            /*" -1016- MOVE SVA-CIDADE TO LD01-CIDADE. */
            _.Move(REG_SBI1466B.SVA_CIDADE, WORK_AREA.LD01.LD01_CIDADE);

            /*" -1017- MOVE SVA-SIGLA-UF TO LD01-SIGLA-UF. */
            _.Move(REG_SBI1466B.SVA_SIGLA_UF, WORK_AREA.LD01.LD01_SIGLA_UF);

            /*" -1018- MOVE SVA-CEP TO LD01-CEP. */
            _.Move(REG_SBI1466B.SVA_CEP, WORK_AREA.LD01.LD01_CEP);

            /*" -1019- MOVE SVA-DDD TO LD01-DDD. */
            _.Move(REG_SBI1466B.SVA_DDD, WORK_AREA.LD01.LD01_DDD);

            /*" -1020- MOVE SVA-TELEFONE TO LD01-TELEFONE. */
            _.Move(REG_SBI1466B.SVA_TELEFONE, WORK_AREA.LD01.LD01_TELEFONE);

            /*" -1022- MOVE SVA-CDESCNEG TO LD01-COD-ESCNEG */
            _.Move(REG_SBI1466B.SVA_CDESCNEG, WORK_AREA.LD01.LD01_COD_ESCNEG);

            /*" -1023- IF SVA-RAMO EQUAL 81 AND SVA-SITUACAO EQUAL 'F' */

            if (REG_SBI1466B.SVA_RAMO == 81 && REG_SBI1466B.SVA_SITUACAO == "F")
            {

                /*" -1025- MOVE 'AP VIDA TRANQUILA PREMIADO' TO LD01-NOMPRODU */
                _.Move("AP VIDA TRANQUILA PREMIADO", WORK_AREA.LD01.LD01_NOMPRODU);

                /*" -1026- ELSE */
            }
            else
            {


                /*" -1028- MOVE 'CAIXA FACIL ACIDENTES PESSOAIS' TO LD01-NOMPRODU */
                _.Move("CAIXA FACIL ACIDENTES PESSOAIS", WORK_AREA.LD01.LD01_NOMPRODU);

                /*" -1030- END-IF. */
            }


            /*" -1032- MOVE SVA-CDFONTE TO LD01-CODFILIAL LD02-CODFILIAL */
            _.Move(REG_SBI1466B.SVA_CDFONTE, WORK_AREA.LD01.LD01_CODFILIAL, WORK_AREA.LD02.LD02_CODFILIAL);

            /*" -1033- MOVE TBFT-NMFONTE(SVA-CDFONTE) TO LD01-NOMFILIAL */
            _.Move(TABELA_FONTES1.TAB_FTE1[REG_SBI1466B.SVA_CDFONTE].TBFT_NMFONTE, WORK_AREA.LD01.LD01_NOMFILIAL);

            /*" -1035- MOVE SVA-NUMBIL TO LD01-NUMBIL LD02-NUMBIL */
            _.Move(REG_SBI1466B.SVA_NUMBIL, WORK_AREA.LD01.LD01_NUMBIL, WORK_AREA.LD02.LD02_NUMBIL);

            /*" -1036- MOVE SVA-CODUSU TO LD01-CODUSU */
            _.Move(REG_SBI1466B.SVA_CODUSU, WORK_AREA.LD01.LD01_CODUSU);

            /*" -1037- MOVE SVA-DTQITBCO (1:4) TO LD01-DTQITBCO(7:4) */
            _.MoveAtPosition(REG_SBI1466B.SVA_DTQITBCO.Substring(1, 4), WORK_AREA.LD01.LD01_DTQITBCO, 7, 4);

            /*" -1038- MOVE '/' TO LD01-DTQITBCO(3:1) */
            _.MoveAtPosition("/", WORK_AREA.LD01.LD01_DTQITBCO, 3, 1);

            /*" -1039- MOVE SVA-DTQITBCO (6:2) TO LD01-DTQITBCO(4:2) */
            _.MoveAtPosition(REG_SBI1466B.SVA_DTQITBCO.Substring(6, 2), WORK_AREA.LD01.LD01_DTQITBCO, 4, 2);

            /*" -1040- MOVE '/' TO LD01-DTQITBCO(6:1) */
            _.MoveAtPosition("/", WORK_AREA.LD01.LD01_DTQITBCO, 6, 1);

            /*" -1041- MOVE SVA-DTQITBCO (9:2) TO LD01-DTQITBCO(1:2) */
            _.MoveAtPosition(REG_SBI1466B.SVA_DTQITBCO.Substring(9, 2), WORK_AREA.LD01.LD01_DTQITBCO, 1, 2);

            /*" -1042- MOVE SVA-DTNASC (1:4) TO LD01-DTNASC (7:4) */
            _.MoveAtPosition(REG_SBI1466B.SVA_DTNASC.Substring(1, 4), WORK_AREA.LD01.LD01_DTNASC, 7, 4);

            /*" -1043- MOVE '/' TO LD01-DTNASC (3:1) */
            _.MoveAtPosition("/", WORK_AREA.LD01.LD01_DTNASC, 3, 1);

            /*" -1044- MOVE SVA-DTNASC (6:2) TO LD01-DTNASC (4:2) */
            _.MoveAtPosition(REG_SBI1466B.SVA_DTNASC.Substring(6, 2), WORK_AREA.LD01.LD01_DTNASC, 4, 2);

            /*" -1045- MOVE '/' TO LD01-DTNASC (6:1) */
            _.MoveAtPosition("/", WORK_AREA.LD01.LD01_DTNASC, 6, 1);

            /*" -1046- MOVE SVA-DTNASC (9:2) TO LD01-DTNASC (1:2) */
            _.MoveAtPosition(REG_SBI1466B.SVA_DTNASC.Substring(9, 2), WORK_AREA.LD01.LD01_DTNASC, 1, 2);

            /*" -1048- MOVE SVA-AGECOBR TO LD01-AGECOBR LD02-AGECOBR */
            _.Move(REG_SBI1466B.SVA_AGECOBR, WORK_AREA.LD01.LD01_AGECOBR, WORK_AREA.LD02.LD02_AGECOBR);

            /*" -1049- MOVE SVA-VLPREMIO TO LD01-VLPREMIO */
            _.Move(REG_SBI1466B.SVA_VLPREMIO, WORK_AREA.LD01.LD01_VLPREMIO);

            /*" -1051- MOVE SVA-CODPRODU TO LD01-CODPRODU. */
            _.Move(REG_SBI1466B.SVA_CODPRODU, WORK_AREA.LD01.LD01_CODPRODU);

            /*" -1052- IF SVA-COD-ERRO EQUAL ZEROS */

            if (REG_SBI1466B.SVA_COD_ERRO == 00)
            {

                /*" -1053- MOVE SPACES TO LD01-CODERRO */
                _.Move("", WORK_AREA.LD01.LD01_CODERRO);

                /*" -1055- ELSE */
            }
            else
            {


                /*" -1056- IF SVA-COD-ERRO EQUAL 10902 */

                if (REG_SBI1466B.SVA_COD_ERRO == 10902)
                {

                    /*" -1058- MOVE 'CGCCPF INVALIDO            ' TO LD01-CODERRO */
                    _.Move("CGCCPF INVALIDO            ", WORK_AREA.LD01.LD01_CODERRO);

                    /*" -1060- ELSE */
                }
                else
                {


                    /*" -1061- IF SVA-COD-ERRO EQUAL 11502 */

                    if (REG_SBI1466B.SVA_COD_ERRO == 11502)
                    {

                        /*" -1063- MOVE 'OPCAO DE COBERTURA INVALIDA' TO LD01-CODERRO */
                        _.Move("OPCAO DE COBERTURA INVALIDA", WORK_AREA.LD01.LD01_CODERRO);

                        /*" -1065- ELSE */
                    }
                    else
                    {


                        /*" -1066- IF SVA-COD-ERRO EQUAL 11802 */

                        if (REG_SBI1466B.SVA_COD_ERRO == 11802)
                        {

                            /*" -1068- MOVE 'DADOS PAG/CRED NAO CADASTRADO' TO LD01-CODERRO */
                            _.Move("DADOS PAG/CRED NAO CADASTRADO", WORK_AREA.LD01.LD01_CODERRO);

                            /*" -1069- ELSE */
                        }
                        else
                        {


                            /*" -1070- IF SVA-COD-ERRO EQUAL 0834 */

                            if (REG_SBI1466B.SVA_COD_ERRO == 0834)
                            {

                                /*" -1072- MOVE 'ULTRAPASSA LIMITE DE RISCO' TO LD01-CODERRO */
                                _.Move("ULTRAPASSA LIMITE DE RISCO", WORK_AREA.LD01.LD01_CODERRO);

                                /*" -1074- ELSE */
                            }
                            else
                            {


                                /*" -1075- IF SVA-COD-ERRO EQUAL 11001 */

                                if (REG_SBI1466B.SVA_COD_ERRO == 11001)
                                {

                                    /*" -1077- MOVE 'SEM DATA NASCIMENTO       ' TO LD01-CODERRO */
                                    _.Move("SEM DATA NASCIMENTO       ", WORK_AREA.LD01.LD01_CODERRO);

                                    /*" -1079- ELSE */
                                }
                                else
                                {


                                    /*" -1080- IF SVA-COD-ERRO EQUAL 11101 */

                                    if (REG_SBI1466B.SVA_COD_ERRO == 11101)
                                    {

                                        /*" -1082- MOVE 'IDADE FORA DA COBERTURA ' TO LD01-CODERRO */
                                        _.Move("IDADE FORA DA COBERTURA ", WORK_AREA.LD01.LD01_CODERRO);

                                        /*" -1083- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1086- MOVE 'OUTRAS DIVERGENCIAS     ' TO LD01-CODERRO. */
                                        _.Move("OUTRAS DIVERGENCIAS     ", WORK_AREA.LD01.LD01_CODERRO);
                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -1087- WRITE REG-ABI1466B FROM LD01. */
            _.Move(WORK_AREA.LD01.GetMoveValues(), REG_ABI1466B);

            ABI1466B.Write(REG_ABI1466B.GetMoveValues().ToString());

            /*" -1087- WRITE REG-DBI1466B FROM LD02. */
            _.Move(WORK_AREA.LD02.GetMoveValues(), REG_DBI1466B);

            DBI1466B.Write(REG_DBI1466B.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R2200_90_LER */

            R2200_90_LER();

        }

        [StopWatch]
        /*" R2200-90-LER */
        private void R2200_90_LER(bool isPerform = false)
        {
            /*" -1091- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-LE-SORT-SECTION */
        private void R2400_00_LE_SORT_SECTION()
        {
            /*" -1104- RETURN SBI1466B AT END */
            try
            {
                SBI1466B.Return(REG_SBI1466B, () =>
                {

                    /*" -1104- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WORK_AREA.WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-DECLARE-FONTES-SECTION */
        private void R3100_00_DECLARE_FONTES_SECTION()
        {
            /*" -1117- MOVE '310' TO WNR-EXEC-SQL. */
            _.Move("310", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1122- PERFORM R3100_00_DECLARE_FONTES_DB_DECLARE_1 */

            R3100_00_DECLARE_FONTES_DB_DECLARE_1();

            /*" -1124- PERFORM R3100_00_DECLARE_FONTES_DB_OPEN_1 */

            R3100_00_DECLARE_FONTES_DB_OPEN_1();

            /*" -1127- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1128- DISPLAY 'R3100 - PROBLEMAS DECLARE (V0FONTE  ) ..' */
                _.Display($"R3100 - PROBLEMAS DECLARE (V0FONTE  ) ..");

                /*" -1129- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1129- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3100-00-DECLARE-FONTES-DB-OPEN-1 */
        public void R3100_00_DECLARE_FONTES_DB_OPEN_1()
        {
            /*" -1124- EXEC SQL OPEN CFONTES END-EXEC. */

            CFONTES.Open();

        }

        [StopWatch]
        /*" R3200-00-DECLARE-ESCNEG-DB-DECLARE-1 */
        public void R3200_00_DECLARE_ESCNEG_DB_DECLARE_1()
        {
            /*" -1221- EXEC SQL DECLARE CESCNEG CURSOR FOR SELECT COD_ESCNEG, REGIAO_ESCNEG, COD_FONTE FROM SEGUROS.V0ESCNEG ORDER BY COD_ESCNEG END-EXEC. */
            CESCNEG = new BI1466B_CESCNEG(false);
            string GetQuery_CESCNEG()
            {
                var query = @$"SELECT COD_ESCNEG
							, 
							REGIAO_ESCNEG
							, 
							COD_FONTE 
							FROM SEGUROS.V0ESCNEG 
							ORDER BY COD_ESCNEG";

                return query;
            }
            CESCNEG.GetQueryEvent += GetQuery_CESCNEG;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-FETCH-FONTES-SECTION */
        private void R3110_00_FETCH_FONTES_SECTION()
        {
            /*" -1142- MOVE '311' TO WNR-EXEC-SQL. */
            _.Move("311", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1145- PERFORM R3110_00_FETCH_FONTES_DB_FETCH_1 */

            R3110_00_FETCH_FONTES_DB_FETCH_1();

            /*" -1148- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1149- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1150- MOVE 'S' TO WFIM-FONTES */
                    _.Move("S", WORK_AREA.WFIM_FONTES);

                    /*" -1150- PERFORM R3110_00_FETCH_FONTES_DB_CLOSE_1 */

                    R3110_00_FETCH_FONTES_DB_CLOSE_1();

                    /*" -1152- ELSE */
                }
                else
                {


                    /*" -1152- PERFORM R3110_00_FETCH_FONTES_DB_CLOSE_2 */

                    R3110_00_FETCH_FONTES_DB_CLOSE_2();

                    /*" -1154- DISPLAY '3110 - (PROBLEMAS NO FETCH CFONTES  ) ..' */
                    _.Display($"3110 - (PROBLEMAS NO FETCH CFONTES  ) ..");

                    /*" -1155- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1155- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3110-00-FETCH-FONTES-DB-FETCH-1 */
        public void R3110_00_FETCH_FONTES_DB_FETCH_1()
        {
            /*" -1145- EXEC SQL FETCH CFONTES INTO :V0FONT-CODFTE, :V0FONT-NOMEFTE END-EXEC. */

            if (CFONTES.Fetch())
            {
                _.Move(CFONTES.V0FONT_CODFTE, V0FONT_CODFTE);
                _.Move(CFONTES.V0FONT_NOMEFTE, V0FONT_NOMEFTE);
            }

        }

        [StopWatch]
        /*" R3110-00-FETCH-FONTES-DB-CLOSE-1 */
        public void R3110_00_FETCH_FONTES_DB_CLOSE_1()
        {
            /*" -1150- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3110_99_SAIDA*/

        [StopWatch]
        /*" R3110-00-FETCH-FONTES-DB-CLOSE-2 */
        public void R3110_00_FETCH_FONTES_DB_CLOSE_2()
        {
            /*" -1152- EXEC SQL CLOSE CFONTES END-EXEC */

            CFONTES.Close();

        }

        [StopWatch]
        /*" R3120-00-CARREGA-FONTES-SECTION */
        private void R3120_00_CARREGA_FONTES_SECTION()
        {
            /*" -1168- MOVE '311' TO WNR-EXEC-SQL. */
            _.Move("311", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1169- IF V0FONT-CODFTE LESS 100 */

            if (V0FONT_CODFTE < 100)
            {

                /*" -1172- MOVE V0FONT-NOMEFTE TO TBFT-NMFONTE (V0FONT-CODFTE). */
                _.Move(V0FONT_NOMEFTE, TABELA_FONTES1.TAB_FTE1[V0FONT_CODFTE].TBFT_NMFONTE);
            }


            /*" -1172- PERFORM R3110-00-FETCH-FONTES. */

            R3110_00_FETCH_FONTES_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3120_99_SAIDA*/

        [StopWatch]
        /*" R3190-00-SELECT-ESCNEG-SECTION */
        private void R3190_00_SELECT_ESCNEG_SECTION()
        {
            /*" -1185- MOVE '319' TO WNR-EXEC-SQL. */
            _.Move("319", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1194- PERFORM R3190_00_SELECT_ESCNEG_DB_SELECT_1 */

            R3190_00_SELECT_ESCNEG_DB_SELECT_1();

            /*" -1197- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1198- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1199- MOVE 'NAO CADASTRADO' TO V0ESCN-NOMEESC */
                    _.Move("NAO CADASTRADO", V0ESCN_NOMEESC);

                    /*" -1200- ELSE */
                }
                else
                {


                    /*" -1201- DISPLAY 'R3190 - PROBLEMAS SELECT  (V0ESCNEG ) ..' */
                    _.Display($"R3190 - PROBLEMAS SELECT  (V0ESCNEG ) ..");

                    /*" -1202- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1202- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3190-00-SELECT-ESCNEG-DB-SELECT-1 */
        public void R3190_00_SELECT_ESCNEG_DB_SELECT_1()
        {
            /*" -1194- EXEC SQL SELECT COD_ESCNEG, REGIAO_ESCNEG, COD_FONTE INTO :V0ESCN-CODESC, :V0ESCN-NOMEESC, :V0ESCN-FONTE FROM SEGUROS.V0ESCNEG WHERE COD_ESCNEG = :WHOST-COD-ESCNEG END-EXEC. */

            var r3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1 = new R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1()
            {
                WHOST_COD_ESCNEG = WHOST_COD_ESCNEG.ToString(),
            };

            var executed_1 = R3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1.Execute(r3190_00_SELECT_ESCNEG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ESCN_CODESC, V0ESCN_CODESC);
                _.Move(executed_1.V0ESCN_NOMEESC, V0ESCN_NOMEESC);
                _.Move(executed_1.V0ESCN_FONTE, V0ESCN_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3190_99_SAIDA*/

        [StopWatch]
        /*" R3200-00-DECLARE-ESCNEG-SECTION */
        private void R3200_00_DECLARE_ESCNEG_SECTION()
        {
            /*" -1215- MOVE '320' TO WNR-EXEC-SQL. */
            _.Move("320", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1221- PERFORM R3200_00_DECLARE_ESCNEG_DB_DECLARE_1 */

            R3200_00_DECLARE_ESCNEG_DB_DECLARE_1();

            /*" -1223- PERFORM R3200_00_DECLARE_ESCNEG_DB_OPEN_1 */

            R3200_00_DECLARE_ESCNEG_DB_OPEN_1();

            /*" -1226- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1227- DISPLAY 'R3200 - PROBLEMAS DECLARE (V0ESCNEG ) ..' */
                _.Display($"R3200 - PROBLEMAS DECLARE (V0ESCNEG ) ..");

                /*" -1228- DISPLAY 'SQLCODE - ' SQLCODE */
                _.Display($"SQLCODE - {DB.SQLCODE}");

                /*" -1228- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R3200-00-DECLARE-ESCNEG-DB-OPEN-1 */
        public void R3200_00_DECLARE_ESCNEG_DB_OPEN_1()
        {
            /*" -1223- EXEC SQL OPEN CESCNEG END-EXEC. */

            CESCNEG.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3200_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-SECTION */
        private void R3210_00_FETCH_ESCNEG_SECTION()
        {
            /*" -1241- MOVE '321' TO WNR-EXEC-SQL. */
            _.Move("321", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1245- PERFORM R3210_00_FETCH_ESCNEG_DB_FETCH_1 */

            R3210_00_FETCH_ESCNEG_DB_FETCH_1();

            /*" -1248- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1249- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1250- MOVE 'S' TO WFIM-ESCNEG */
                    _.Move("S", WORK_AREA.WFIM_ESCNEG);

                    /*" -1250- PERFORM R3210_00_FETCH_ESCNEG_DB_CLOSE_1 */

                    R3210_00_FETCH_ESCNEG_DB_CLOSE_1();

                    /*" -1252- ELSE */
                }
                else
                {


                    /*" -1252- PERFORM R3210_00_FETCH_ESCNEG_DB_CLOSE_2 */

                    R3210_00_FETCH_ESCNEG_DB_CLOSE_2();

                    /*" -1254- DISPLAY '3210 - (PROBLEMAS NO FETCH CESCNEG  ) ..' */
                    _.Display($"3210 - (PROBLEMAS NO FETCH CESCNEG  ) ..");

                    /*" -1255- DISPLAY 'SQLCODE - ' SQLCODE */
                    _.Display($"SQLCODE - {DB.SQLCODE}");

                    /*" -1255- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-DB-FETCH-1 */
        public void R3210_00_FETCH_ESCNEG_DB_FETCH_1()
        {
            /*" -1245- EXEC SQL FETCH CESCNEG INTO :V0ESCN-CODESC, :V0ESCN-NOMEESC, :V0ESCN-FONTE END-EXEC. */

            if (CESCNEG.Fetch())
            {
                _.Move(CESCNEG.V0ESCN_CODESC, V0ESCN_CODESC);
                _.Move(CESCNEG.V0ESCN_NOMEESC, V0ESCN_NOMEESC);
                _.Move(CESCNEG.V0ESCN_FONTE, V0ESCN_FONTE);
            }

        }

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-DB-CLOSE-1 */
        public void R3210_00_FETCH_ESCNEG_DB_CLOSE_1()
        {
            /*" -1250- EXEC SQL CLOSE CESCNEG END-EXEC */

            CESCNEG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3210_99_SAIDA*/

        [StopWatch]
        /*" R3210-00-FETCH-ESCNEG-DB-CLOSE-2 */
        public void R3210_00_FETCH_ESCNEG_DB_CLOSE_2()
        {
            /*" -1252- EXEC SQL CLOSE CESCNEG END-EXEC */

            CESCNEG.Close();

        }

        [StopWatch]
        /*" R4000-00-ZERA-TB-ESCNEG-SECTION */
        private void R4000_00_ZERA_TB_ESCNEG_SECTION()
        {
            /*" -1267- MOVE ZEROS TO TBEN-QT-ESTOQ (IND). */
            _.Move(0, TABELA_ESCNEG.TAB_EN[WORK_AREA.IND].TBEN_QT_ESTOQ);

            /*" -1267- MOVE ZEROS TO TBEN-QT-ESTOQ (IND). */
            _.Move(0, TABELA_ESCNEG.TAB_EN[WORK_AREA.IND].TBEN_QT_ESTOQ);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -1281- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1282- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1283- DISPLAY '*   BI1466B - GERA RELATORIO MULTPREMIADO  *' */
            _.Display($"*   BI1466B - GERA RELATORIO MULTPREMIADO  *");

            /*" -1284- DISPLAY '*   -------   -------------- ------------  *' */
            _.Display($"*   -------   -------------- ------------  *");

            /*" -1285- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1286- DISPLAY '*             NAO EXISTE PRODUCAO PARA     *' */
            _.Display($"*             NAO EXISTE PRODUCAO PARA     *");

            /*" -1287- DISPLAY '*             O PERIODO PEDIDO.            *' */
            _.Display($"*             O PERIODO PEDIDO.            *");

            /*" -1288- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1288- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1302- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -1304- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -1304- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1306- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1310- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1310- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}