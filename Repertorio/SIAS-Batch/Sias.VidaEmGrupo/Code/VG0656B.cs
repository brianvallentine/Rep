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
using Sias.VidaEmGrupo.DB2.VG0656B;

namespace Code
{
    public class VG0656B
    {
        public bool IsCall { get; set; }

        public VG0656B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO ................. EMISSAO DE RELATORIO MENSAL OU      *      */
        /*"      *                            EVENTUAL DE PROPOSTAS DECLINADAS    *      */
        /*"      *                            MANUALMENTE.                        *      */
        /*"      *                                                                *      */
        /*"      *                             . ANALITICO                        *      */
        /*"      *                             . SINTETICO POR PRODUTO            *      */
        /*"      *                             . SINTETICO POR FILIAL E PRODUTO   *      */
        /*"      *                                                                *      */
        /*"      *                               CAD 15.844                       *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR.............  LEANDRO CORTES    - FAST COMPUTER  *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG0656B.                           *      */
        /*"      *                                                                *      */
        /*"      *   DATA ...................  16/10/2008.                        *      */
        /*"      *                                                                *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01  -  NSGD - CADMUS 103659.                          *      */
        /*"      *              -  NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 10/02/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   VERSAO 02 - CIELO - ADEQUA�AO AO CAMPO NUM_CARTAO_CREDITO    *      */
        /*"      *               O NUMERO DO CARTAO DE CREDITO FOI ALTERADO NA    *      */
        /*"      *               TABELA OPCAO_PAG_VIDAZUL PARA CHAR(16), POIS O   *      */
        /*"      *               NUMERO QUE O LEGADO RECEBE ESTA MASCARADO COM "*"*      */
        /*"      *                                                                *      */
        /*"      *   EM 24/08/2019 - DANIEL MEDINA GOMIDE - MILLENIUM             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"V.03  *   VERSAO 03 - DEMANDA 402.982                                  *      */
        /*"      *             - SUBSTITUIR CONSULTA DA TABELA ERROS_PROP_VIDAZUL *      */
        /*"      *               PELA NA NOVA TABELA VG_CRITICA_PROPOSTA          *      */
        /*"      *                                                                *      */
        /*"      *   EM 14/02/2022 - ELIERMES OLIVEIRA                            *      */
        /*"      *                                        PROCURE POR V.03        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MDETALHE { get; set; } = new FileBasis(new PIC("X", "600", "X(600)"));

        public FileBasis MDETALHE
        {
            get
            {
                _.Move(REG_MDETALHE, _MDETALHE); VarBasis.RedefinePassValue(REG_MDETALHE, _MDETALHE, REG_MDETALHE); return _MDETALHE;
            }
        }
        public FileBasis _MPRODUTO { get; set; } = new FileBasis(new PIC("X", "100", "X(100)"));

        public FileBasis MPRODUTO
        {
            get
            {
                _.Move(REG_MPRODUTO, _MPRODUTO); VarBasis.RedefinePassValue(REG_MPRODUTO, _MPRODUTO, REG_MPRODUTO); return _MPRODUTO;
            }
        }
        public FileBasis _MTRAB { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis MTRAB
        {
            get
            {
                _.Move(REG_MTRAB, _MTRAB); VarBasis.RedefinePassValue(REG_MTRAB, _MTRAB, REG_MTRAB); return _MTRAB;
            }
        }
        public SortBasis<VG0656B_REG_ARQSORT1> ARQSORT1 { get; set; } = new SortBasis<VG0656B_REG_ARQSORT1>(new VG0656B_REG_ARQSORT1());
        public SortBasis<VG0656B_REG_ARQSORT2> ARQSORT2 { get; set; } = new SortBasis<VG0656B_REG_ARQSORT2>(new VG0656B_REG_ARQSORT2());
        /*"01            REG-MDETALHE        PIC X(600).*/
        public StringBasis REG_MDETALHE { get; set; } = new StringBasis(new PIC("X", "600", "X(600)."), @"");
        /*"01            REG-MPRODUTO        PIC X(100).*/
        public StringBasis REG_MPRODUTO { get; set; } = new StringBasis(new PIC("X", "100", "X(100)."), @"");
        /*"01            REG-MTRAB.*/
        public VG0656B_REG_MTRAB REG_MTRAB { get; set; } = new VG0656B_REG_MTRAB();
        public class VG0656B_REG_MTRAB : VarBasis
        {
            /*"    05        TMP-COD-FONTE       PIC S9(004).*/
            public IntBasis TMP_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
            /*"    05        TMP-PRODUTO-AG      PIC S9(004) COMP.*/
            public IntBasis TMP_PRODUTO_AG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        TMP-NUM-APOLICE     PIC S9(013) COMP-3.*/
            public IntBasis TMP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05        TMP-COD-SUBGRUPO    PIC S9(004) COMP.*/
            public IntBasis TMP_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        TMP-NOME-PRODUTO    PIC  X(030).*/
            public StringBasis TMP_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05        TMP-VLPREMIO        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis TMP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"01            REG-ARQSORT1.*/
        }
        public VG0656B_REG_ARQSORT1 REG_ARQSORT1 { get; set; } = new VG0656B_REG_ARQSORT1();
        public class VG0656B_REG_ARQSORT1 : VarBasis
        {
            /*"    05        SVA-PRODUTO-AG      PIC S9(004) COMP.*/
            public IntBasis SVA_PRODUTO_AG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-NUM-APOLICE     PIC S9(013) COMP-3.*/
            public IntBasis SVA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05        SVA-COD-SUBGRUPO    PIC S9(004) COMP.*/
            public IntBasis SVA_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA-NOME-PRODUTO    PIC  X(030).*/
            public StringBasis SVA_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05        SVA-NUM-CERTIFICADO PIC S9(015) COMP-3.*/
            public IntBasis SVA_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    05        SVA-NUM-MATRI-VENDEDOR PIC S9(015) COMP-3.*/
            public IntBasis SVA_NUM_MATRI_VENDEDOR { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"    05        SVA-DATA-QUITACAO   PIC  X(010).*/
            public StringBasis SVA_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-AGE-COBRANCA    PIC S9(004).*/
            public IntBasis SVA_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
            /*"    05        SVA-COD-FONTE       PIC S9(004).*/
            public IntBasis SVA_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
            /*"    05        SVA-COD-CLIENTE     PIC S9(009) COMP.*/
            public IntBasis SVA_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05        SVA-DATA-CANCEL     PIC  X(010).*/
            public StringBasis SVA_DATA_CANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    05        SVA-COD-USUARIO     PIC  X(008).*/
            public StringBasis SVA_COD_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"01            REG-ARQSORT2.*/
        }
        public VG0656B_REG_ARQSORT2 REG_ARQSORT2 { get; set; } = new VG0656B_REG_ARQSORT2();
        public class VG0656B_REG_ARQSORT2 : VarBasis
        {
            /*"    05        SVA2-COD-FONTE       PIC S9(004).*/
            public IntBasis SVA2_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)."));
            /*"    05        SVA2-PRODUTO-AG      PIC S9(004) COMP.*/
            public IntBasis SVA2_PRODUTO_AG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA2-NUM-APOLICE     PIC S9(013) COMP-3.*/
            public IntBasis SVA2_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"    05        SVA2-COD-SUBGRUPO    PIC S9(004) COMP.*/
            public IntBasis SVA2_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"    05        SVA2-NOME-PRODUTO    PIC  X(030).*/
            public StringBasis SVA2_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05        SVA2-VLPREMIO        PIC S9(013)V99 COMP-3.*/
            public DoubleBasis SVA2_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_RETURN { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis SORT_FILE_SIZE { get; set; } = new IntBasis(new PIC("S9", "08", "S9(08)"));
        /*"77            VIND-OPE-PAG        PIC S9(004)   COMP.*/
        public IntBasis VIND_OPE_PAG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-AGENCIA        PIC S9(004)   COMP.*/
        public IntBasis VIND_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-OPER           PIC S9(004)   COMP.*/
        public IntBasis VIND_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-CTADEB         PIC S9(004)   COMP.*/
        public IntBasis VIND_CTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-DGCTA          PIC S9(004)   COMP.*/
        public IntBasis VIND_DGCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-CERTIF         PIC S9(004)   COMP.*/
        public IntBasis VIND_CERTIF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            VIND-CARTAO         PIC S9(004)   COMP.*/
        public IntBasis VIND_CARTAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77            WHOST-SITUACAO      PIC  X(01).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77            WHOST-NRCERTIF      PIC S9(15) COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            WHOST-NUMTIT        PIC S9(13) COMP-3.*/
        public IntBasis WHOST_NUMTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            WHOST-APOLICE       PIC S9(13) COMP-3.*/
        public IntBasis WHOST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            WHOST-CODSUBES      PIC S9(04) COMP.*/
        public IntBasis WHOST_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-COD-ESCNEG    PIC S9(04) COMP.*/
        public IntBasis WHOST_COD_ESCNEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-DT-INICIO     PIC  X(10).*/
        public StringBasis WHOST_DT_INICIO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DT-FIM        PIC  X(10).*/
        public StringBasis WHOST_DT_FIM { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DT-CORRENTE   PIC  X(10).*/
        public StringBasis WHOST_DT_CORRENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTINICIAL     PIC  X(10).*/
        public StringBasis WHOST_DTINICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL       PIC  X(10).*/
        public StringBasis WHOST_DTFINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  WORK-AREA.*/
        public VG0656B_WORK_AREA WORK_AREA { get; set; } = new VG0656B_WORK_AREA();
        public class VG0656B_WORK_AREA : VarBasis
        {
            /*"    05  TAB-OPC-PGTO.*/
            public VG0656B_TAB_OPC_PGTO TAB_OPC_PGTO { get; set; } = new VG0656B_TAB_OPC_PGTO();
            public class VG0656B_TAB_OPC_PGTO : VarBasis
            {
                /*"        10  FILLER                PIC X(011) VALUE '1-DEB CONTA'*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"1-DEB CONTA");
                /*"        10  FILLER                PIC X(011) VALUE '2-POUPANCA '*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"2-POUPANCA ");
                /*"        10  FILLER                PIC X(011) VALUE '3-BOLETO   '*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"3-BOLETO   ");
                /*"        10  FILLER                PIC X(011) VALUE '4-AVERBACAO'*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"4-AVERBACAO");
                /*"        10  FILLER                PIC X(011) VALUE '5-CARTAO   '*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"5-CARTAO   ");
                /*"    05  TAB-OPC-PGTO-RED  REDEFINES  TAB-OPC-PGTO.*/
            }
            private _REDEF_VG0656B_TAB_OPC_PGTO_RED _tab_opc_pgto_red { get; set; }
            public _REDEF_VG0656B_TAB_OPC_PGTO_RED TAB_OPC_PGTO_RED
            {
                get { _tab_opc_pgto_red = new _REDEF_VG0656B_TAB_OPC_PGTO_RED(); _.Move(TAB_OPC_PGTO, _tab_opc_pgto_red); VarBasis.RedefinePassValue(TAB_OPC_PGTO, _tab_opc_pgto_red, TAB_OPC_PGTO); _tab_opc_pgto_red.ValueChanged += () => { _.Move(_tab_opc_pgto_red, TAB_OPC_PGTO); }; return _tab_opc_pgto_red; }
                set { VarBasis.RedefinePassValue(value, _tab_opc_pgto_red, TAB_OPC_PGTO); }
            }  //Redefines
            public class _REDEF_VG0656B_TAB_OPC_PGTO_RED : VarBasis
            {
                /*"      10  TB-OPC-PAGTO            PIC X(011)  OCCURS 5 TIMES.*/
                public ListBasis<StringBasis, string> TB_OPC_PAGTO { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "11", "X(011)"), 5);
                /*"    05        DATA-SQL.*/

                public _REDEF_VG0656B_TAB_OPC_PGTO_RED()
                {
                    TB_OPC_PAGTO.ValueChanged += OnValueChanged;
                }

            }
            public VG0656B_DATA_SQL DATA_SQL { get; set; } = new VG0656B_DATA_SQL();
            public class VG0656B_DATA_SQL : VarBasis
            {
                /*"      10      ANO-SQL             PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      MES-SQL             PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10      DIA-SQL             PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05       WS-TIME               PIC  X(008).*/
            }
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05       WS-CHAVE-ATU.*/
            public VG0656B_WS_CHAVE_ATU WS_CHAVE_ATU { get; set; } = new VG0656B_WS_CHAVE_ATU();
            public class VG0656B_WS_CHAVE_ATU : VarBasis
            {
                /*"      10     WS-CHAVE-ATU-APOLICE  PIC  9(013).*/
                public IntBasis WS_CHAVE_ATU_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10     WS-CHAVE-ATU-SUBGRUPO PIC  9(005).*/
                public IntBasis WS_CHAVE_ATU_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05       WS-CHAVE-ANT.*/
            }
            public VG0656B_WS_CHAVE_ANT WS_CHAVE_ANT { get; set; } = new VG0656B_WS_CHAVE_ANT();
            public class VG0656B_WS_CHAVE_ANT : VarBasis
            {
                /*"      10     WS-CHAVE-ANT-APOLICE  PIC  9(013).*/
                public IntBasis WS_CHAVE_ANT_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10     WS-CHAVE-ANT-SUBGRUPO PIC  9(005).*/
                public IntBasis WS_CHAVE_ANT_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"    05       WS-DTH-CRITICA       PIC  9(008).*/
            }
            public IntBasis WS_DTH_CRITICA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05       WS-DTH-CRITICA-R     REDEFINES   WS-DTH-CRITICA.*/
            private _REDEF_VG0656B_WS_DTH_CRITICA_R _ws_dth_critica_r { get; set; }
            public _REDEF_VG0656B_WS_DTH_CRITICA_R WS_DTH_CRITICA_R
            {
                get { _ws_dth_critica_r = new _REDEF_VG0656B_WS_DTH_CRITICA_R(); _.Move(WS_DTH_CRITICA, _ws_dth_critica_r); VarBasis.RedefinePassValue(WS_DTH_CRITICA, _ws_dth_critica_r, WS_DTH_CRITICA); _ws_dth_critica_r.ValueChanged += () => { _.Move(_ws_dth_critica_r, WS_DTH_CRITICA); }; return _ws_dth_critica_r; }
                set { VarBasis.RedefinePassValue(value, _ws_dth_critica_r, WS_DTH_CRITICA); }
            }  //Redefines
            public class _REDEF_VG0656B_WS_DTH_CRITICA_R : VarBasis
            {
                /*"      10     WS-CRITICA-ANO       PIC  9(004).*/
                public IntBasis WS_CRITICA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     WS-CRITICA-MES       PIC  9(002).*/
                public IntBasis WS_CRITICA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     WS-CRITICA-DIA       PIC  9(002).*/
                public IntBasis WS_CRITICA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-NULL             PIC S9(04) COMP VALUE ZEROS.*/

                public _REDEF_VG0656B_WS_DTH_CRITICA_R()
                {
                    WS_CRITICA_ANO.ValueChanged += OnValueChanged;
                    WS_CRITICA_MES.ValueChanged += OnValueChanged;
                    WS_CRITICA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_NULL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05        WS-PRODUTO-ANT      PIC  X(030).*/
            public StringBasis WS_PRODUTO_ANT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"    05        IND                 PIC  9(005) VALUE ZEROS.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05        WS-ESCNEG           PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_ESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-PRODUTO-AG-ANT   PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_PRODUTO_AG_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-FONTE-ANT        PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_FONTE_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-AGE-COBRANCA-ANT PIC  9(004) VALUE 9999.*/
            public IntBasis WS_AGE_COBRANCA_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"), 9999);
            /*"    05        WS-APOLICE-ANT      PIC  9(013) VALUE ZEROS.*/
            public IntBasis WS_APOLICE_ANT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    05        WS-CODSUBES-ANT     PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_CODSUBES_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-ESCNEG-ANT       PIC  9(004) VALUE ZEROS.*/
            public IntBasis WS_ESCNEG_ANT { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    05        WS-ERRO-DATA        PIC  X(003) VALUE SPACES.*/
            public StringBasis WS_ERRO_DATA { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"   05       AUX-RESULTADO       PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AUX_RESULTADO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"   05       AUX-RESTO           PIC  9(09)     VALUE  ZEROS.*/
            public IntBasis AUX_RESTO { get; set; } = new IntBasis(new PIC("9", "9", "9(09)"));
            /*"    05        WFIM-PROPOVA        PIC   X(01)  VALUE  ' '.*/
        }
        public StringBasis WFIM_PROPOVA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"    05        WFIM-V0ERROSPROP    PIC   X(01)  VALUE  ' '.*/
        public StringBasis WFIM_V0ERROSPROP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"    05        WFIM-SISTEMAS       PIC   X(01)  VALUE  ' '.*/
        public StringBasis WFIM_SISTEMAS { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"    05        WFIM-SORT           PIC   X(01)  VALUE  ' '.*/
        public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"    05        WFIM-SORT1          PIC   X(01)  VALUE  ' '.*/
        public StringBasis WFIM_SORT1 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"    05        WFIM-FONTES         PIC   X(01)  VALUE  ' '.*/
        public StringBasis WFIM_FONTES { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"    05        WFIM-ESCNEG         PIC   X(01)  VALUE  ' '.*/
        public StringBasis WFIM_ESCNEG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"    05        WFIM-MTRAB          PIC   X(01)  VALUE  ' '.*/
        public StringBasis WFIM_MTRAB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
        /*"    05        AC-PREMIO-AG        PIC  9(013)V99 COMP-3  VALUE 0*/
        public DoubleBasis AC_PREMIO_AG { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"    05        AC-PREMIO-TT        PIC  9(013)V99 COMP-3  VALUE 0*/
        public DoubleBasis AC_PREMIO_TT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"    05        AC-PREMIO-FI        PIC  9(013)V99 COMP-3  VALUE 0*/
        public DoubleBasis AC_PREMIO_FI { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"    05        AC-PREMIO-PR        PIC  9(013)V99 COMP-3  VALUE 0*/
        public DoubleBasis AC_PREMIO_PR { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99"), 2);
        /*"    05        AC-QUANT-TT         PIC  9(013)    COMP-3  VALUE 0*/
        public IntBasis AC_QUANT_TT { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"    05        AC-QUANT-AG         PIC  9(013)    COMP-3  VALUE 0*/
        public IntBasis AC_QUANT_AG { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"    05        AC-QUANT-FI         PIC  9(013)    COMP-3  VALUE 0*/
        public IntBasis AC_QUANT_FI { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"    05        AC-QUANT-PR         PIC  9(013)    COMP-3  VALUE 0*/
        public IntBasis AC_QUANT_PR { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"    05        AC-PROPOSTA         PIC  9(013)    COMP-3  VALUE 0*/
        public IntBasis AC_PROPOSTA { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
        /*"    05        AC-LIDOS            PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05        AC-CONTA            PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05        AC-LIDOS-MTRAB      PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_LIDOS_MTRAB { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05        AC-DESP-1           PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_DESP_1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05        AC-DESP-2           PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_DESP_2 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05        AC-DESP-3           PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_DESP_3 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05        AC-DESP-4           PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_DESP_4 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05        AC-DESP-5           PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_DESP_5 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05        AC-DESP-6           PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_DESP_6 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05        AC-DESP-7           PIC  9(007) VALUE ZEROS.*/
        public IntBasis AC_DESP_7 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
        /*"    05       WPAR-PARAMETROS     PIC  X(17).*/
        public StringBasis WPAR_PARAMETROS { get; set; } = new StringBasis(new PIC("X", "17", "X(17)."), @"");
        /*"    05        FILLER REDEFINES    WPAR-PARAMETROS.*/
        private _REDEF_VG0656B_FILLER_7 _filler_7 { get; set; }
        public _REDEF_VG0656B_FILLER_7 FILLER_7
        {
            get { _filler_7 = new _REDEF_VG0656B_FILLER_7(); _.Move(WPAR_PARAMETROS, _filler_7); VarBasis.RedefinePassValue(WPAR_PARAMETROS, _filler_7, WPAR_PARAMETROS); _filler_7.ValueChanged += () => { _.Move(_filler_7, WPAR_PARAMETROS); }; return _filler_7; }
            set { VarBasis.RedefinePassValue(value, _filler_7, WPAR_PARAMETROS); }
        }  //Redefines
        public class _REDEF_VG0656B_FILLER_7 : VarBasis
        {
            /*"      10     WPAR-ROTINA         PIC  X(01).*/
            public StringBasis WPAR_ROTINA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
            /*"      10     WPAR-INICIO         PIC  X(08).*/
            public StringBasis WPAR_INICIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"      10     WPAR-FIM            PIC  X(08).*/
            public StringBasis WPAR_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"  05        WABEND.*/
            public VG0656B_WABEND WABEND { get; set; } = new VG0656B_WABEND();
            public class VG0656B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(010) VALUE           ' VG0656B'.*/
            }

            public _REDEF_VG0656B_FILLER_7()
            {
                WPAR_ROTINA.ValueChanged += OnValueChanged;
                WPAR_INICIO.ValueChanged += OnValueChanged;
                WPAR_FIM.ValueChanged += OnValueChanged;
                WABEND.ValueChanged += OnValueChanged;
            }

        }
        public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG0656B");
        /*"    10      FILLER              PIC  X(026) VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
        public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
        /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
        public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
        /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
        public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
        /*"    10      WSQLCODE            PIC  ZZZZZ999-.*/
        public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-."));
        /*"    05        LD00-BRANCOS.*/
        public VG0656B_LD00_BRANCOS LD00_BRANCOS { get; set; } = new VG0656B_LD00_BRANCOS();
        public class VG0656B_LD00_BRANCOS : VarBasis
        {
            /*"      10      FILLER              PIC X(100)  VALUE  SPACES.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"");
            /*"    05        LD00.*/
        }
        public VG0656B_LD00 LD00 { get; set; } = new VG0656B_LD00();
        public class VG0656B_LD00 : VarBasis
        {
            /*"      10      LD00-PROGRAMA       PIC X(08).*/
            public StringBasis LD00_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(35)   VALUE            'PROPOSTAS DECLINADAS MANUALMENTE - '.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "35", "X(35)"), @"PROPOSTAS DECLINADAS MANUALMENTE - ");
            /*"      10      LD00-TIPO-RELATORIO PIC X(18).*/
            public StringBasis LD00_TIPO_RELATORIO { get; set; } = new StringBasis(new PIC("X", "18", "X(18)."), @"");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(06)   VALUE             'DATA:'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"DATA:");
            /*"      10      LD00-DATA           PIC X(10).*/
            public StringBasis LD00_DATA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05        LD00-11.*/
        }
        public VG0656B_LD00_11 LD00_11 { get; set; } = new VG0656B_LD00_11();
        public class VG0656B_LD00_11 : VarBasis
        {
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(09)   VALUE             'PERIODO:'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"PERIODO:");
            /*"      10      LD00-11-DATAINI     PIC X(10).*/
            public StringBasis LD00_11_DATAINI { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"      10      LD00-11-A           PIC X(05)   VALUE   SPACES.*/
            public StringBasis LD00_11_A { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
            /*"      10      LD00-11-DATAFIN     PIC X(10)   VALUE   SPACES.*/
            public StringBasis LD00_11_DATAFIN { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05        LD00-1.*/
        }
        public VG0656B_LD00_1 LD00_1 { get; set; } = new VG0656B_LD00_1();
        public class VG0656B_LD00_1 : VarBasis
        {
            /*"      10      FILLER              PIC X(07)   VALUE 'PRODUTO'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(06)   VALUE 'FILIAL'.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"FILIAL");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(02)   VALUE 'SR'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "2", "X(02)"), @"SR");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(07)   VALUE 'AGENCIA'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AGENCIA");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(09)   VALUE 'INDICADOR'.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"INDICADOR");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(09)   VALUE 'NOME AGEN'.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"NOME AGEN");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(09)   VALUE 'MATR VEND'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"MATR VEND");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(11)   VALUE             'CERTIFICADO'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "11", "X(11)"), @"CERTIFICADO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(04)   VALUE 'NOME'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"NOME");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(03)   VALUE 'CPF'.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"CPF");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(08)   VALUE 'QUITACAO'.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"QUITACAO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(06)   VALUE 'PREMIO'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"PREMIO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(06)   VALUE 'IMP.SG'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"IMP.SG");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(09)   VALUE 'DT CANCEL'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DT CANCEL");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(07)   VALUE 'OPC PAG'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"OPC PAG");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(07)   VALUE 'AGE DEB'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"AGE DEB");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(09)   VALUE 'OPE CONTA'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"OPE CONTA");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(09)   VALUE 'CONTA DEB'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"CONTA DEB");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(08)   VALUE 'DIA VENC'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"DIA VENC");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(08)   VALUE 'NUM CHEQ'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"NUM CHEQ");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(08)   VALUE 'DIA QUIT'.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "8", "X(08)"), @"DIA QUIT");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(10)   VALUE 'NUM CARTAO'*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"NUM CARTAO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(09)   VALUE 'COD DEVOL'.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"COD DEVOL");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(09)   VALUE 'DESC MOTV'.*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"DESC MOTV");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(07)   VALUE 'USUARIO'.*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"USUARIO");
            /*"    05        LD01.*/
        }
        public VG0656B_LD01 LD01 { get; set; } = new VG0656B_LD01();
        public class VG0656B_LD01 : VarBasis
        {
            /*"      10      LD01-NOME-PRODUTO     PIC X(30).*/
            public StringBasis LD01_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "30", "X(30)."), @"");
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-COD-FONTE        PIC 9(02).*/
            public IntBasis LD01_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-NOME-FONTE       PIC X(31).*/
            public StringBasis LD01_NOME_FONTE { get; set; } = new StringBasis(new PIC("X", "31", "X(31)."), @"");
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-COD-ESCNEG       PIC 9(04).*/
            public IntBasis LD01_COD_ESCNEG { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"      10      FILLER                PIC X(01)   VALUE '-'.*/
            public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"      10      LD01-REGIAO-ESCNEG    PIC X(31).*/
            public StringBasis LD01_REGIAO_ESCNEG { get; set; } = new StringBasis(new PIC("X", "31", "X(31)."), @"");
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-COD-AGENCIA      PIC 9(04).*/
            public IntBasis LD01_COD_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-NOME-AGENCIA     PIC X(31).*/
            public StringBasis LD01_NOME_AGENCIA { get; set; } = new StringBasis(new PIC("X", "31", "X(31)."), @"");
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-NUM-MATRI-VENDEDOR PIC 9(15).*/
            public IntBasis LD01_NUM_MATRI_VENDEDOR { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-NUM-CERTIFICADO  PIC 9(15).*/
            public IntBasis LD01_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-NOME-RAZAO       PIC X(40).*/
            public StringBasis LD01_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-CGCCPF           PIC 9(15).*/
            public IntBasis LD01_CGCCPF { get; set; } = new IntBasis(new PIC("9", "15", "9(15)."));
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-DATA-QUITACAO    PIC X(10).*/
            public StringBasis LD01_DATA_QUITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-VLPREMIO         PIC 9999999999999,99.*/
            public DoubleBasis LD01_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-IMP-MORNATU      PIC 9999999999999,99.*/
            public DoubleBasis LD01_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-DTCANCEL         PIC X(10).*/
            public StringBasis LD01_DTCANCEL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-OPC-PAG          PIC X(11).*/
            public StringBasis LD01_OPC_PAG { get; set; } = new StringBasis(new PIC("X", "11", "X(11)."), @"");
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-AGE-DEB          PIC 9(04).*/
            public IntBasis LD01_AGE_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"      10      FILLER                PIC X(03)   VALUE ';'.*/
            public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @";");
            /*"      10      LD01-OPER-DEB         PIC 9(04).*/
            public IntBasis LD01_OPER_DEB { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-CTA-DEB          PIC 9(12).*/
            public IntBasis LD01_CTA_DEB { get; set; } = new IntBasis(new PIC("9", "12", "9(12)."));
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-DV-CONTA         PIC 9(04).*/
            public IntBasis LD01_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-CHEQUE           PIC 9(09).*/
            public IntBasis LD01_CHEQUE { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-DVCHEQ           PIC 9(04).*/
            public IntBasis LD01_DVCHEQ { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-CARTAO           PIC X(16).*/
            public StringBasis LD01_CARTAO { get; set; } = new StringBasis(new PIC("X", "16", "X(16)."), @"");
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-COD-DEVOL        PIC 9(04).*/
            public IntBasis LD01_COD_DEVOL { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-DESCR-ERRO       PIC X(50).*/
            public StringBasis LD01_DESCR_ERRO { get; set; } = new StringBasis(new PIC("X", "50", "X(50)."), @"");
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD01-USUARIO          PIC X(08).*/
            public StringBasis LD01_USUARIO { get; set; } = new StringBasis(new PIC("X", "8", "X(08)."), @"");
            /*"    05        LD00-02.*/
        }
        public VG0656B_LD00_02 LD00_02 { get; set; } = new VG0656B_LD00_02();
        public class VG0656B_LD00_02 : VarBasis
        {
            /*"      10      FILLER              PIC X(14)              VALUE 'CAIXA SEGUROS'.*/
            public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "14", "X(14)"), @"CAIXA SEGUROS");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD00-02-MES         PIC X(03).*/
            public StringBasis LD00_02_MES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"      10      FILLER              PIC X(01)   VALUE '/'.*/
            public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
            /*"      10      LD00-02-ANO         PIC 9(02).*/
            public IntBasis LD00_02_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"      10      FILLER              PIC X(03)   VALUE ';'.*/
            public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @";");
            /*"    05        LD00-1-02.*/
        }
        public VG0656B_LD00_1_02 LD00_1_02 { get; set; } = new VG0656B_LD00_1_02();
        public class VG0656B_LD00_1_02 : VarBasis
        {
            /*"      10      FILLER              PIC X(07)   VALUE 'PRODUTO'.*/
            public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(04)   VALUE 'QTDE'.*/
            public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"QTDE");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(06)   VALUE 'PREMIO'.*/
            public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"PREMIO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05        LD02.*/
        }
        public VG0656B_LD02 LD02 { get; set; } = new VG0656B_LD02();
        public class VG0656B_LD02 : VarBasis
        {
            /*"      10      LD02-NOME-PRODUTO     PIC X(40) VALUE SPACES.*/
            public StringBasis LD02_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"      10      FILLER                PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD02-QUANTIDADE       PIC 999999999.*/
            public IntBasis LD02_QUANTIDADE { get; set; } = new IntBasis(new PIC("9", "9", "999999999."));
            /*"      10      FILLER                PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD02-VLPREMIO         PIC 9999999999999,99.*/
            public DoubleBasis LD02_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"      10      FILLER                PIC X(01) VALUE ';'.*/
            public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05        LD00-03.*/
        }
        public VG0656B_LD00_03 LD00_03 { get; set; } = new VG0656B_LD00_03();
        public class VG0656B_LD00_03 : VarBasis
        {
            /*"      10      FILLER              PIC X(06)   VALUE 'FILIAL'.*/
            public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"FILIAL");
            /*"      10      LD00-03-COD-FONTE   PIC 9(02).*/
            public IntBasis LD00_03_COD_FONTE { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"      10      FILLER              PIC X(01)   VALUE '-'.*/
            public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"-");
            /*"      10      LD00-03-NOME-FONTE  PIC X(20).*/
            public StringBasis LD00_03_NOME_FONTE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD00-03-MES         PIC X(03).*/
            public StringBasis LD00_03_MES { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
            /*"      10      FILLER              PIC X(01)   VALUE '/'.*/
            public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @"/");
            /*"      10      LD00-03-ANO         PIC 9(02).*/
            public IntBasis LD00_03_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05        LD00-1-03.*/
        }
        public VG0656B_LD00_1_03 LD00_1_03 { get; set; } = new VG0656B_LD00_1_03();
        public class VG0656B_LD00_1_03 : VarBasis
        {
            /*"      10      FILLER              PIC X(07)   VALUE 'PRODUTO'.*/
            public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "7", "X(07)"), @"PRODUTO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(04)   VALUE 'QTDE'.*/
            public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "4", "X(04)"), @"QTDE");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      FILLER              PIC X(06)   VALUE 'PREMIO'.*/
            public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"PREMIO");
            /*"      10      FILLER              PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"    05        LD03.*/
        }
        public VG0656B_LD03 LD03 { get; set; } = new VG0656B_LD03();
        public class VG0656B_LD03 : VarBasis
        {
            /*"      10      LD03-NOME-PRODUTO     PIC X(40) VALUE SPACES.*/
            public StringBasis LD03_NOME_PRODUTO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD03-QUANTIDADE       PIC 999999999.*/
            public IntBasis LD03_QUANTIDADE { get; set; } = new IntBasis(new PIC("9", "9", "999999999."));
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"      10      LD03-VLPREMIO         PIC 9999999999999,99.*/
            public DoubleBasis LD03_VLPREMIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9999999999999V99."), 2);
            /*"      10      FILLER                PIC X(01)   VALUE ';'.*/
            public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @";");
            /*"01            TABELA-MES.*/
        }
        public VG0656B_TABELA_MES TABELA_MES { get; set; } = new VG0656B_TABELA_MES();
        public class VG0656B_TABELA_MES : VarBasis
        {
            /*"      10      FILLER              PIC X(36) VALUE       'JANFEVMARABRMAIJUNJULAGOSETOUTNOVDEZ'.*/
            public StringBasis FILLER_131 { get; set; } = new StringBasis(new PIC("X", "36", "X(36)"), @"JANFEVMARABRMAIJUNJULAGOSETOUTNOVDEZ");
            /*"01            TABELA-MESES  REDEFINES TABELA-MES.*/
        }
        private _REDEF_VG0656B_TABELA_MESES _tabela_meses { get; set; }
        public _REDEF_VG0656B_TABELA_MESES TABELA_MESES
        {
            get { _tabela_meses = new _REDEF_VG0656B_TABELA_MESES(); _.Move(TABELA_MES, _tabela_meses); VarBasis.RedefinePassValue(TABELA_MES, _tabela_meses, TABELA_MES); _tabela_meses.ValueChanged += () => { _.Move(_tabela_meses, TABELA_MES); }; return _tabela_meses; }
            set { VarBasis.RedefinePassValue(value, _tabela_meses, TABELA_MES); }
        }  //Redefines
        public class _REDEF_VG0656B_TABELA_MESES : VarBasis
        {
            /*"      10      TAB-MES1            OCCURS 12 TIMES.*/
            public ListBasis<VG0656B_TAB_MES1> TAB_MES1 { get; set; } = new ListBasis<VG0656B_TAB_MES1>(12);
            public class VG0656B_TAB_MES1 : VarBasis
            {
                /*"        15    TBME-MES            PIC  X(003).*/
                public StringBasis TBME_MES { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
                /*"01            TABELA-FONTES1.*/

                public VG0656B_TAB_MES1()
                {
                    TBME_MES.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG0656B_TABELA_MESES()
            {
                TAB_MES1.ValueChanged += OnValueChanged;
            }

        }
        public VG0656B_TABELA_FONTES1 TABELA_FONTES1 { get; set; } = new VG0656B_TABELA_FONTES1();
        public class VG0656B_TABELA_FONTES1 : VarBasis
        {
            /*"   05         TAB-PRD1            OCCURS  4 TIMES.*/
            public ListBasis<VG0656B_TAB_PRD1> TAB_PRD1 { get; set; } = new ListBasis<VG0656B_TAB_PRD1>(4);
            public class VG0656B_TAB_PRD1 : VarBasis
            {
                /*"      10      TAB-FTE1            OCCURS 30 TIMES.*/
                public ListBasis<VG0656B_TAB_FTE1> TAB_FTE1 { get; set; } = new ListBasis<VG0656B_TAB_FTE1>(30);
                public class VG0656B_TAB_FTE1 : VarBasis
                {
                    /*"        15    TBFT-QUANT          PIC S9(009)     COMP.*/
                    public IntBasis TBFT_QUANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                    /*"        15    TBFT-VLPREMIO       PIC S9(013)V99  COMP-3.*/
                    public DoubleBasis TBFT_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                    /*"01            WZEROS              PIC S9(005) VALUE +0 COMP-3.*/
                }
            }
        }
        public IntBasis WZEROS { get; set; } = new IntBasis(new PIC("S9", "5", "S9(005)"));


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.PRODUVG PRODUVG { get; set; } = new Dclgens.PRODUVG();
        public Dclgens.ESCRINEG ESCRINEG { get; set; } = new Dclgens.ESCRINEG();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.HISCOBPR HISCOBPR { get; set; } = new Dclgens.HISCOBPR();
        public Dclgens.CBCONDEV CBCONDEV { get; set; } = new Dclgens.CBCONDEV();
        public Dclgens.OPCPAGVI OPCPAGVI { get; set; } = new Dclgens.OPCPAGVI();
        public Dclgens.DEVOLVID DEVOLVID { get; set; } = new Dclgens.DEVOLVID();
        public Dclgens.COBHISVI COBHISVI { get; set; } = new Dclgens.COBHISVI();
        public Dclgens.AGENCCEF AGENCCEF { get; set; } = new Dclgens.AGENCCEF();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.ERRPROVI ERRPROVI { get; set; } = new Dclgens.ERRPROVI();
        public Dclgens.ERROSVID ERROSVID { get; set; } = new Dclgens.ERROSVID();
        public VG0656B_C01_PROPOVA C01_PROPOVA { get; set; } = new VG0656B_C01_PROPOVA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(StringBasis WPAR_PARAMETROS_P, string MDETALHE_FILE_NAME_P, string MPRODUTO_FILE_NAME_P, string MTRAB_FILE_NAME_P, string ARQSORT1_FILE_NAME_P, string ARQSORT2_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                this.WPAR_PARAMETROS.Value = WPAR_PARAMETROS_P.Value;
                MDETALHE.SetFile(MDETALHE_FILE_NAME_P);
                MPRODUTO.SetFile(MPRODUTO_FILE_NAME_P);
                MTRAB.SetFile(MTRAB_FILE_NAME_P);
                ARQSORT1.SetFile(ARQSORT1_FILE_NAME_P);
                ARQSORT2.SetFile(ARQSORT2_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL */

                M_0000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { WPAR_PARAMETROS, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL */
        private void M_0000_PRINCIPAL(bool isPerform = false)
        {
            /*" -519- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -522- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -525- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -526- PERFORM R0000-00-PRINCIPAL. */

            R0000_00_PRINCIPAL_SECTION();

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -536- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WNR_EXEC_SQL);

            /*" -538- INITIALIZE TABELA-FONTES1. */
            _.Initialize(
                TABELA_FONTES1
            );

            /*" -540- ACCEPT WPAR-PARAMETROS FROM SYSIN. */
            /*-Accept convertido para parametro de entrada...*/

            /*" -541- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -542- DISPLAY 'PROGRAMA EM EXECUCAO VG0656B  ' */
            _.Display($"PROGRAMA EM EXECUCAO VG0656B  ");

            /*" -543- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -544- DISPLAY 'VERSAO V.03 402.982 14/02/2023' */
            _.Display($"VERSAO V.03 402.982 14/02/2023");

            /*" -545- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -546- DISPLAY '------------------------------' */
            _.Display($"------------------------------");

            /*" -548- DISPLAY '                              ' */
            _.Display($"                              ");

            /*" -551- MOVE 'NAO' TO WS-ERRO-DATA. */
            _.Move("NAO", WORK_AREA.WS_ERRO_DATA);

            /*" -552- IF WPAR-ROTINA EQUAL 'E' */

            if (FILLER_7.WPAR_ROTINA == "E")
            {

                /*" -554- IF WPAR-INICIO EQUAL '00000000' AND WPAR-FIM EQUAL '00000000' */

                if (FILLER_7.WPAR_INICIO == "00000000" && FILLER_7.WPAR_FIM == "00000000")
                {

                    /*" -556- DISPLAY '*** NAO HOUVE SOLICITACAO  ' WPAR-PARAMETROS */
                    _.Display($"*** NAO HOUVE SOLICITACAO  {WPAR_PARAMETROS}");

                    /*" -557- STOP RUN */

                    throw new GoBack();   // => STOP RUN.

                    /*" -559- END-IF */
                }


                /*" -562- MOVE WPAR-INICIO TO WS-DTH-CRITICA-R */
                _.Move(FILLER_7.WPAR_INICIO, WORK_AREA.WS_DTH_CRITICA_R);

                /*" -564- PERFORM R0400-00-CONSISTE-DATA */

                R0400_00_CONSISTE_DATA_SECTION();

                /*" -565- IF WS-ERRO-DATA EQUAL 'NAO' */

                if (WORK_AREA.WS_ERRO_DATA == "NAO")
                {

                    /*" -568- MOVE WPAR-FIM TO WS-DTH-CRITICA-R */
                    _.Move(FILLER_7.WPAR_FIM, WORK_AREA.WS_DTH_CRITICA_R);

                    /*" -569- PERFORM R0400-00-CONSISTE-DATA */

                    R0400_00_CONSISTE_DATA_SECTION();

                    /*" -570- END-IF */
                }


                /*" -572- END-IF. */
            }


            /*" -575- IF WPAR-ROTINA EQUAL ( 'E' OR 'M' ) AND WS-ERRO-DATA EQUAL 'NAO' NEXT SENTENCE */

            if (FILLER_7.WPAR_ROTINA.In("E", "M") && WORK_AREA.WS_ERRO_DATA == "NAO")
            {

                /*" -576- ELSE */
            }
            else
            {


                /*" -578- DISPLAY '*** PROBLEMAS NOS PARAMETROS INFORMADOS ' WPAR-PARAMETROS */
                _.Display($"*** PROBLEMAS NOS PARAMETROS INFORMADOS {WPAR_PARAMETROS}");

                /*" -579- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -581- END-IF. */
            }


            /*" -583- PERFORM R0100-00-SELECT-SISTEMAS. */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -584- IF WFIM-SISTEMAS NOT EQUAL SPACES */

            if (!WFIM_SISTEMAS.IsEmpty())
            {

                /*" -585- DISPLAY '*** PROBLEMAS NA SISTEMAS' */
                _.Display($"*** PROBLEMAS NA SISTEMAS");

                /*" -586- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -588- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -589- IF WPAR-ROTINA EQUAL 'E' */

            if (FILLER_7.WPAR_ROTINA == "E")
            {

                /*" -590- PERFORM R0300-00-MONTA-DATA-PARAMETROS */

                R0300_00_MONTA_DATA_PARAMETROS_SECTION();

                /*" -591- ELSE */
            }
            else
            {


                /*" -594- DISPLAY 'VG0656B ---> PERIODO DE ' ' ' WHOST-DT-INICIO ' ' WHOST-DT-FIM */

                $"VG0656B ---> PERIODO DE  {WHOST_DT_INICIO} {WHOST_DT_FIM}"
                .Display();

                /*" -596- END-IF. */
            }


            /*" -598- PERFORM R0900-00-DECLARE-PROPOVA. */

            R0900_00_DECLARE_PROPOVA_SECTION();

            /*" -600- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

            /*" -601- IF WFIM-PROPOVA EQUAL 'S' */

            if (WFIM_PROPOVA == "S")
            {

                /*" -602- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -603- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -606- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -608- MOVE +400000 TO SORT-FILE-SIZE. */
            _.Move(+400000, SORT_FILE_SIZE);

            /*" -617- SORT ARQSORT1 ON ASCENDING KEY SVA-PRODUTO-AG SVA-NOME-PRODUTO SVA-COD-FONTE SVA-AGE-COBRANCA INPUT PROCEDURE R0010-00-SELECIONA THRU R0010-FIM OUTPUT PROCEDURE R0020-00-GERA-ARQ THRU R0020-FIM. */
            SORT_RETURN.Value = ARQSORT1.Sort("SVA-PRODUTO-AG,SVA-NOME-PRODUTO,SVA-COD-FONTE,SVA-AGE-COBRANCA", () => R0010_00_SELECIONA_SECTION(), () => R0020_00_GERA_ARQ_SECTION());

            /*" -620- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -621- DISPLAY '*** VG0656B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VG0656B *** PROBLEMAS NO SORT ");

                /*" -622- DISPLAY '*** VG0656B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VG0656B *** SORT-RETURN = {SORT_RETURN}");

                /*" -623- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -626- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -628- MOVE +400000 TO SORT-FILE-SIZE. */
            _.Move(+400000, SORT_FILE_SIZE);

            /*" -636- SORT ARQSORT2 ON ASCENDING KEY SVA2-COD-FONTE SVA2-PRODUTO-AG SVA2-NOME-PRODUTO USING MTRAB GIVING MTRAB. */
            MTRAB.AllLines = MTRAB.SortFile("SVA2-COD-FONTE,SVA2-PRODUTO-AG,SVA2-NOME-PRODUTO", ARQSORT2.FileLayout);

            /*" -639- IF SORT-RETURN NOT EQUAL ZEROS */

            if (SORT_RETURN != 00)
            {

                /*" -640- DISPLAY '*** VG0656B *** PROBLEMAS NO SORT ' */
                _.Display($"*** VG0656B *** PROBLEMAS NO SORT ");

                /*" -641- DISPLAY '*** VG0656B *** SORT-RETURN = ' SORT-RETURN */
                _.Display($"*** VG0656B *** SORT-RETURN = {SORT_RETURN}");

                /*" -642- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -644- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -644- PERFORM R0040-00-GERA-ARQ THRU R0040-FIM. */

            R0040_00_GERA_ARQ_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0040_FIM*/


            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -650- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -650- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -653- DISPLAY '*** VG0656B - ' */
            _.Display($"*** VG0656B - ");

            /*" -654- DISPLAY 'LIDOS PROPOVA            ' AC-LIDOS. */
            _.Display($"LIDOS PROPOVA            {AC_LIDOS}");

            /*" -655- DISPLAY 'DESPREZADOS 1            ' AC-DESP-1. */
            _.Display($"DESPREZADOS 1            {AC_DESP_1}");

            /*" -656- DISPLAY 'DESPREZADOS 2            ' AC-DESP-2. */
            _.Display($"DESPREZADOS 2            {AC_DESP_2}");

            /*" -657- DISPLAY 'DESPREZADOS 3            ' AC-DESP-3. */
            _.Display($"DESPREZADOS 3            {AC_DESP_3}");

            /*" -658- DISPLAY 'DESPREZADOS 4            ' AC-DESP-4. */
            _.Display($"DESPREZADOS 4            {AC_DESP_4}");

            /*" -659- DISPLAY 'DESPREZADOS 5            ' AC-DESP-5. */
            _.Display($"DESPREZADOS 5            {AC_DESP_5}");

            /*" -660- DISPLAY 'DESPREZADOS 6            ' AC-DESP-6. */
            _.Display($"DESPREZADOS 6            {AC_DESP_6}");

            /*" -662- DISPLAY 'DESPREZADOS 7            ' AC-DESP-7. */
            _.Display($"DESPREZADOS 7            {AC_DESP_7}");

            /*" -664- DISPLAY '*** VG0656B - TERMINO NORMAL ***' */
            _.Display($"*** VG0656B - TERMINO NORMAL ***");

            /*" -664- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-SELECIONA-SECTION */
        private void R0010_00_SELECIONA_SECTION()
        {
            /*" -678- MOVE '0010' TO WNR-EXEC-SQL. */
            _.Move("0010", WNR_EXEC_SQL);

            /*" -681- PERFORM R1000-00-PROCESSA-INPUT UNTIL WFIM-PROPOVA EQUAL 'S' . */

            while (!(WFIM_PROPOVA == "S"))
            {

                R1000_00_PROCESSA_INPUT_SECTION();
            }

            /*" -681- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_FIM*/

        [StopWatch]
        /*" R0020-00-GERA-ARQ-SECTION */
        private void R0020_00_GERA_ARQ_SECTION()
        {
            /*" -695- MOVE '0020' TO WNR-EXEC-SQL. */
            _.Move("0020", WNR_EXEC_SQL);

            /*" -699- OPEN OUTPUT MDETALHE MPRODUTO MTRAB. */
            MDETALHE.Open(REG_MDETALHE);
            MPRODUTO.Open(REG_MPRODUTO);
            MTRAB.Open(REG_MTRAB);

            /*" -702- MOVE 'VG0656B1' TO LD00-PROGRAMA */
            _.Move("VG0656B1", LD00.LD00_PROGRAMA);

            /*" -705- MOVE 'ANALITICO' TO LD00-TIPO-RELATORIO */
            _.Move("ANALITICO", LD00.LD00_TIPO_RELATORIO);

            /*" -706- WRITE REG-MDETALHE FROM LD00. */
            _.Move(LD00.GetMoveValues(), REG_MDETALHE);

            MDETALHE.Write(REG_MDETALHE.GetMoveValues().ToString());

            /*" -707- WRITE REG-MDETALHE FROM LD00-BRANCOS. */
            _.Move(LD00_BRANCOS.GetMoveValues(), REG_MDETALHE);

            MDETALHE.Write(REG_MDETALHE.GetMoveValues().ToString());

            /*" -708- WRITE REG-MDETALHE FROM LD00-11. */
            _.Move(LD00_11.GetMoveValues(), REG_MDETALHE);

            MDETALHE.Write(REG_MDETALHE.GetMoveValues().ToString());

            /*" -709- WRITE REG-MDETALHE FROM LD00-BRANCOS. */
            _.Move(LD00_BRANCOS.GetMoveValues(), REG_MDETALHE);

            MDETALHE.Write(REG_MDETALHE.GetMoveValues().ToString());

            /*" -711- WRITE REG-MDETALHE FROM LD00-1. */
            _.Move(LD00_1.GetMoveValues(), REG_MDETALHE);

            MDETALHE.Write(REG_MDETALHE.GetMoveValues().ToString());

            /*" -714- MOVE 'VG0656B2' TO LD00-PROGRAMA */
            _.Move("VG0656B2", LD00.LD00_PROGRAMA);

            /*" -717- MOVE 'POR PRODUTO' TO LD00-TIPO-RELATORIO */
            _.Move("POR PRODUTO", LD00.LD00_TIPO_RELATORIO);

            /*" -718- WRITE REG-MPRODUTO FROM LD00. */
            _.Move(LD00.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -719- WRITE REG-MPRODUTO FROM LD00-BRANCOS. */
            _.Move(LD00_BRANCOS.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -720- WRITE REG-MPRODUTO FROM LD00-11. */
            _.Move(LD00_11.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -721- WRITE REG-MPRODUTO FROM LD00-BRANCOS. */
            _.Move(LD00_BRANCOS.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -722- WRITE REG-MPRODUTO FROM LD00-02. */
            _.Move(LD00_02.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -724- WRITE REG-MPRODUTO FROM LD00-1-02. */
            _.Move(LD00_1_02.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -726- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

            /*" -729- PERFORM R2000-00-PROCESSA-OUTPUT UNTIL WFIM-SORT EQUAL 'S' . */

            while (!(WFIM_SORT == "S"))
            {

                R2000_00_PROCESSA_OUTPUT_SECTION();
            }

            /*" -732- MOVE '     TOTAL GERAL        ' TO LD02-NOME-PRODUTO. */
            _.Move("     TOTAL GERAL        ", LD02.LD02_NOME_PRODUTO);

            /*" -735- MOVE AC-QUANT-TT TO LD02-QUANTIDADE */
            _.Move(AC_QUANT_TT, LD02.LD02_QUANTIDADE);

            /*" -738- MOVE AC-PREMIO-TT TO LD02-VLPREMIO */
            _.Move(AC_PREMIO_TT, LD02.LD02_VLPREMIO);

            /*" -741- WRITE REG-MPRODUTO FROM LD02. */
            _.Move(LD02.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -742- CLOSE MDETALHE MTRAB. */
            MDETALHE.Close();
            MTRAB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_FIM*/

        [StopWatch]
        /*" R0040-00-GERA-ARQ-SECTION */
        private void R0040_00_GERA_ARQ_SECTION()
        {
            /*" -756- MOVE '0040' TO WNR-EXEC-SQL. */
            _.Move("0040", WNR_EXEC_SQL);

            /*" -758- OPEN INPUT MTRAB. */
            MTRAB.Open(REG_MTRAB);

            /*" -761- MOVE 'VG0656B3' TO LD00-PROGRAMA */
            _.Move("VG0656B3", LD00.LD00_PROGRAMA);

            /*" -765- MOVE 'POR FILIAL/PRODUTO' TO LD00-TIPO-RELATORIO */
            _.Move("POR FILIAL/PRODUTO", LD00.LD00_TIPO_RELATORIO);

            /*" -766- WRITE REG-MPRODUTO FROM LD00-BRANCOS. */
            _.Move(LD00_BRANCOS.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -767- WRITE REG-MPRODUTO FROM LD00-BRANCOS. */
            _.Move(LD00_BRANCOS.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -768- WRITE REG-MPRODUTO FROM LD00-BRANCOS. */
            _.Move(LD00_BRANCOS.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -769- WRITE REG-MPRODUTO FROM LD00-BRANCOS. */
            _.Move(LD00_BRANCOS.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -770- WRITE REG-MPRODUTO FROM LD00. */
            _.Move(LD00.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -771- WRITE REG-MPRODUTO FROM LD00-BRANCOS. */
            _.Move(LD00_BRANCOS.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -772- WRITE REG-MPRODUTO FROM LD00-11. */
            _.Move(LD00_11.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -774- WRITE REG-MPRODUTO FROM LD00-BRANCOS. */
            _.Move(LD00_BRANCOS.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -782- MOVE ZEROS TO AC-QUANT-AG AC-PREMIO-AG AC-QUANT-TT AC-PREMIO-TT AC-QUANT-PR AC-PREMIO-PR. */
            _.Move(0, AC_QUANT_AG, AC_PREMIO_AG, AC_QUANT_TT, AC_PREMIO_TT, AC_QUANT_PR, AC_PREMIO_PR);

            /*" -784- PERFORM R3100-00-LE-MTRAB */

            R3100_00_LE_MTRAB_SECTION();

            /*" -787- PERFORM R4000-00-PROCESSA-MTRAB UNTIL WFIM-MTRAB EQUAL 'S' . */

            while (!(WFIM_MTRAB == "S"))
            {

                R4000_00_PROCESSA_MTRAB_SECTION();
            }

            /*" -790- MOVE '     TOTAL GERAL        ' TO LD03-NOME-PRODUTO. */
            _.Move("     TOTAL GERAL        ", LD03.LD03_NOME_PRODUTO);

            /*" -793- MOVE AC-QUANT-TT TO LD03-QUANTIDADE */
            _.Move(AC_QUANT_TT, LD03.LD03_QUANTIDADE);

            /*" -796- MOVE AC-PREMIO-TT TO LD03-VLPREMIO */
            _.Move(AC_PREMIO_TT, LD03.LD03_VLPREMIO);

            /*" -799- WRITE REG-MPRODUTO FROM LD03. */
            _.Move(LD03.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -799- CLOSE MTRAB. */
            MTRAB.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0040_FIM*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -813- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WNR_EXEC_SQL);

            /*" -820- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -823- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -824- DISPLAY 'VG0656B - SISTEMA VA NAO ESTA CADASTRADO' */
                _.Display($"VG0656B - SISTEMA VA NAO ESTA CADASTRADO");

                /*" -825- MOVE 'S' TO WFIM-SISTEMAS */
                _.Move("S", WFIM_SISTEMAS);

                /*" -827- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -829- MOVE WHOST-DT-CORRENTE (1:4) TO LD00-DATA (7:4) */
            _.MoveAtPosition(WHOST_DT_CORRENTE.Substring(1, 4), LD00.LD00_DATA, 7, 4);

            /*" -830- MOVE '/' TO LD00-DATA (3:1) */
            _.MoveAtPosition("/", LD00.LD00_DATA, 3, 1);

            /*" -832- MOVE WHOST-DT-CORRENTE (6:2) TO LD00-DATA (4:2) */
            _.MoveAtPosition(WHOST_DT_CORRENTE.Substring(6, 2), LD00.LD00_DATA, 4, 2);

            /*" -833- MOVE '/' TO LD00-DATA (6:1) */
            _.MoveAtPosition("/", LD00.LD00_DATA, 6, 1);

            /*" -836- MOVE WHOST-DT-CORRENTE (9:2) TO LD00-DATA (1:2). */
            _.MoveAtPosition(WHOST_DT_CORRENTE.Substring(9, 2), LD00.LD00_DATA, 1, 2);

            /*" -839- MOVE SISTEMAS-DATA-MOV-ABERTO TO DATA-SQL. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WORK_AREA.DATA_SQL);

            /*" -843- MOVE TBME-MES(MES-SQL) TO LD00-02-MES LD00-03-MES */
            _.Move(TABELA_MESES.TAB_MES1[WORK_AREA.DATA_SQL.MES_SQL].TBME_MES, LD00_02.LD00_02_MES, LD00_03.LD00_03_MES);

            /*" -847- MOVE ANO-SQL TO LD00-02-ANO LD00-03-ANO */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, LD00_02.LD00_02_ANO, LD00_03.LD00_03_ANO);

            /*" -849- MOVE DATA-SQL TO WHOST-DTFINAL */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTFINAL);

            /*" -850- MOVE 01 TO DIA-SQL */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -851- MOVE DATA-SQL TO WHOST-DTINICIAL */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTINICIAL);

            /*" -853- MOVE WHOST-DTINICIAL (1:4) TO LD00-11-DATAINI(7:4) */
            _.MoveAtPosition(WHOST_DTINICIAL.Substring(1, 4), LD00_11.LD00_11_DATAINI, 7, 4);

            /*" -854- MOVE '/' TO LD00-11-DATAINI(3:1) */
            _.MoveAtPosition("/", LD00_11.LD00_11_DATAINI, 3, 1);

            /*" -856- MOVE WHOST-DTINICIAL (6:2) TO LD00-11-DATAINI(4:2) */
            _.MoveAtPosition(WHOST_DTINICIAL.Substring(6, 2), LD00_11.LD00_11_DATAINI, 4, 2);

            /*" -857- MOVE '/' TO LD00-11-DATAINI(6:1) */
            _.MoveAtPosition("/", LD00_11.LD00_11_DATAINI, 6, 1);

            /*" -860- MOVE WHOST-DTINICIAL (9:2) TO LD00-11-DATAINI(1:2). */
            _.MoveAtPosition(WHOST_DTINICIAL.Substring(9, 2), LD00_11.LD00_11_DATAINI, 1, 2);

            /*" -863- MOVE '  A  ' TO LD00-11-A */
            _.Move("  A  ", LD00_11.LD00_11_A);

            /*" -866- MOVE SISTEMAS-DATA-MOV-ABERTO (1:4) TO LD00-11-DATAFIN(7:4) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(1, 4), LD00_11.LD00_11_DATAFIN, 7, 4);

            /*" -868- MOVE '/' TO LD00-11-DATAFIN(3:1) */
            _.MoveAtPosition("/", LD00_11.LD00_11_DATAFIN, 3, 1);

            /*" -871- MOVE SISTEMAS-DATA-MOV-ABERTO (6:2) TO LD00-11-DATAFIN(4:2) */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(6, 2), LD00_11.LD00_11_DATAFIN, 4, 2);

            /*" -873- MOVE '/' TO LD00-11-DATAFIN(6:1) */
            _.MoveAtPosition("/", LD00_11.LD00_11_DATAFIN, 6, 1);

            /*" -876- MOVE SISTEMAS-DATA-MOV-ABERTO (9:2) TO LD00-11-DATAFIN(1:2). */
            _.MoveAtPosition(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Substring(9, 2), LD00_11.LD00_11_DATAFIN, 1, 2);

            /*" -880- MOVE SISTEMAS-DATA-MOV-ABERTO TO WHOST-DT-INICIO WHOST-DT-FIM. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, WHOST_DT_INICIO, WHOST_DT_FIM);

            /*" -881- MOVE 01 TO WHOST-DT-INICIO(9:2). */
            _.MoveAtPosition(01, WHOST_DT_INICIO, 9, 2);

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -820- EXEC SQL SELECT DATA_MOV_ABERTO , CURRENT DATE INTO :SISTEMAS-DATA-MOV-ABERTO , :WHOST-DT-CORRENTE FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'RG' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.WHOST_DT_CORRENTE, WHOST_DT_CORRENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-MONTA-DATA-PARAMETROS-SECTION */
        private void R0300_00_MONTA_DATA_PARAMETROS_SECTION()
        {
            /*" -895- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", WNR_EXEC_SQL);

            /*" -899- MOVE WPAR-INICIO (1:4) TO LD00-11-DATAINI(7:4) */
            _.MoveAtPosition(FILLER_7.WPAR_INICIO.Substring(1, 4), LD00_11.LD00_11_DATAINI, 7, 4);

            /*" -899- MOVE WPAR-INICIO (1:4) TO WHOST-DT-INICIO(1:4) */
            _.MoveAtPosition(FILLER_7.WPAR_INICIO.Substring(1, 4), WHOST_DT_INICIO, 1, 4);

            /*" -903- MOVE WPAR-INICIO (5:2) TO LD00-11-DATAINI(4:2) */
            _.MoveAtPosition(FILLER_7.WPAR_INICIO.Substring(5, 2), LD00_11.LD00_11_DATAINI, 4, 2);

            /*" -903- MOVE WPAR-INICIO (5:2) TO WHOST-DT-INICIO(6:2) */
            _.MoveAtPosition(FILLER_7.WPAR_INICIO.Substring(5, 2), WHOST_DT_INICIO, 6, 2);

            /*" -907- MOVE WPAR-INICIO (7:2) TO LD00-11-DATAINI(1:2) */
            _.MoveAtPosition(FILLER_7.WPAR_INICIO.Substring(7, 2), LD00_11.LD00_11_DATAINI, 1, 2);

            /*" -907- MOVE WPAR-INICIO (7:2) TO WHOST-DT-INICIO(9:2) */
            _.MoveAtPosition(FILLER_7.WPAR_INICIO.Substring(7, 2), WHOST_DT_INICIO, 9, 2);

            /*" -911- MOVE '/' TO LD00-11-DATAINI(6:1) */
            _.MoveAtPosition("/", LD00_11.LD00_11_DATAINI, 6, 1);

            /*" -911- MOVE '/' TO LD00-11-DATAINI(3:1) */
            _.MoveAtPosition("/", LD00_11.LD00_11_DATAINI, 3, 1);

            /*" -915- MOVE WPAR-FIM (1:4) TO LD00-11-DATAFIN(7:4) */
            _.MoveAtPosition(FILLER_7.WPAR_FIM.Substring(1, 4), LD00_11.LD00_11_DATAFIN, 7, 4);

            /*" -915- MOVE WPAR-FIM (1:4) TO WHOST-DT-FIM(1:4) */
            _.MoveAtPosition(FILLER_7.WPAR_FIM.Substring(1, 4), WHOST_DT_FIM, 1, 4);

            /*" -917- IF WPAR-FIM (1:4) GREATER WHOST-DT-CORRENTE (1:4) */

            if (FILLER_7.WPAR_FIM.Substring(1, 4) > WHOST_DT_CORRENTE.Substring(1, 4))
            {

                /*" -919- MOVE WHOST-DT-CORRENTE (1:4) TO LD00-11-DATAFIN (7:4) */
                _.MoveAtPosition(WHOST_DT_CORRENTE.Substring(1, 4), LD00_11.LD00_11_DATAFIN, 7, 4);

                /*" -921- END-IF. */
            }


            /*" -925- MOVE WPAR-FIM (5:2) TO LD00-11-DATAFIN(4:2) */
            _.MoveAtPosition(FILLER_7.WPAR_FIM.Substring(5, 2), LD00_11.LD00_11_DATAFIN, 4, 2);

            /*" -925- MOVE WPAR-FIM (5:2) TO WHOST-DT-FIM(6:2) */
            _.MoveAtPosition(FILLER_7.WPAR_FIM.Substring(5, 2), WHOST_DT_FIM, 6, 2);

            /*" -929- MOVE WPAR-FIM (7:2) TO LD00-11-DATAFIN(1:2) */
            _.MoveAtPosition(FILLER_7.WPAR_FIM.Substring(7, 2), LD00_11.LD00_11_DATAFIN, 1, 2);

            /*" -929- MOVE WPAR-FIM (7:2) TO WHOST-DT-FIM(9:2) */
            _.MoveAtPosition(FILLER_7.WPAR_FIM.Substring(7, 2), WHOST_DT_FIM, 9, 2);

            /*" -935- MOVE '/' TO LD00-11-DATAFIN(6:1) */
            _.MoveAtPosition("/", LD00_11.LD00_11_DATAFIN, 6, 1);

            /*" -935- MOVE '/' TO LD00-11-DATAFIN(3:1) */
            _.MoveAtPosition("/", LD00_11.LD00_11_DATAFIN, 3, 1);

            /*" -935- MOVE '/' TO LD00-11-DATAINI(6:1) */
            _.MoveAtPosition("/", LD00_11.LD00_11_DATAINI, 6, 1);

            /*" -935- MOVE '/' TO LD00-11-DATAINI(3:1) */
            _.MoveAtPosition("/", LD00_11.LD00_11_DATAINI, 3, 1);

            /*" -938- MOVE '  A  ' TO LD00-11-A */
            _.Move("  A  ", LD00_11.LD00_11_A);

            /*" -944- MOVE '-' TO WHOST-DT-FIM(8:1). */
            _.MoveAtPosition("-", WHOST_DT_FIM, 8, 1);

            /*" -944- MOVE '-' TO WHOST-DT-FIM(5:1) */
            _.MoveAtPosition("-", WHOST_DT_FIM, 5, 1);

            /*" -944- MOVE '-' TO WHOST-DT-INICIO(8:1) */
            _.MoveAtPosition("-", WHOST_DT_INICIO, 8, 1);

            /*" -944- MOVE '-' TO WHOST-DT-INICIO(5:1) */
            _.MoveAtPosition("-", WHOST_DT_INICIO, 5, 1);

            /*" -945- DISPLAY '***     PARAMETROS  ***' */
            _.Display($"***     PARAMETROS  ***");

            /*" -946- DISPLAY '*** TIPO DE ROTINA   ' WPAR-ROTINA */
            _.Display($"*** TIPO DE ROTINA   {FILLER_7.WPAR_ROTINA}");

            /*" -947- DISPLAY '*** DATA DE INICIO   ' LD00-11-DATAINI */
            _.Display($"*** DATA DE INICIO   {LD00_11.LD00_11_DATAINI}");

            /*" -947- DISPLAY '*** DATA DE FIM      ' LD00-11-DATAFIN. */
            _.Display($"*** DATA DE FIM      {LD00_11.LD00_11_DATAFIN}");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-CONSISTE-DATA-SECTION */
        private void R0400_00_CONSISTE_DATA_SECTION()
        {
            /*" -961- MOVE '0400' TO WNR-EXEC-SQL. */
            _.Move("0400", WNR_EXEC_SQL);

            /*" -963- MOVE 'NAO' TO WS-ERRO-DATA */
            _.Move("NAO", WORK_AREA.WS_ERRO_DATA);

            /*" -965- IF WS-CRITICA-ANO LESS 1900 OR WS-CRITICA-ANO IS NOT NUMERIC */

            if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_ANO < 1900 || !WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_ANO.IsNumeric())
            {

                /*" -966- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                /*" -967- GO TO R0400-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;

                /*" -969- END-IF. */
            }


            /*" -972- IF WS-CRITICA-MES EQUAL ZEROS OR WS-CRITICA-MES GREATER 12 OR WS-CRITICA-MES IS NOT NUMERIC */

            if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES == 00 || WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES > 12 || !WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -973- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                /*" -974- GO TO R0400-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;

                /*" -976- END-IF */
            }


            /*" -978- IF WS-CRITICA-DIA EQUAL ZEROS OR WS-CRITICA-MES IS NOT NUMERIC */

            if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_DIA == 00 || !WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES.IsNumeric())
            {

                /*" -979- MOVE 'SIM' TO WS-ERRO-DATA */
                _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                /*" -980- GO TO R0400-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                return;

                /*" -982- END-IF. */
            }


            /*" -985- IF WS-CRITICA-MES EQUAL 01 OR 03 OR 05 OR 07 OR 08 OR 10 OR 12 */

            if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("01", "03", "05", "07", "08", "10", "12"))
            {

                /*" -986- IF WS-CRITICA-DIA GREATER 31 */

                if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 31)
                {

                    /*" -987- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                    /*" -988- GO TO R0400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                    return;

                    /*" -990- END-IF. */
                }

            }


            /*" -991- IF WS-CRITICA-MES EQUAL 04 OR 06 OR 09 OR 11 */

            if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES.In("04", "06", "09", "11"))
            {

                /*" -992- IF WS-CRITICA-DIA GREATER 30 */

                if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 30)
                {

                    /*" -993- MOVE 'SIM' TO WS-ERRO-DATA */
                    _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                    /*" -994- GO TO R0400-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                    return;

                    /*" -995- END-IF */
                }


                /*" -997- END-IF. */
            }


            /*" -998- IF WS-CRITICA-MES EQUAL 02 */

            if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_MES == 02)
            {

                /*" -1002- DIVIDE WS-CRITICA-ANO BY 4 GIVING AUX-RESULTADO REMAINDER AUX-RESTO */
                _.Divide(WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_ANO, 4, WORK_AREA.AUX_RESULTADO, WORK_AREA.AUX_RESTO);

                /*" -1003- IF AUX-RESTO EQUAL ZEROS */

                if (WORK_AREA.AUX_RESTO == 00)
                {

                    /*" -1004- IF WS-CRITICA-DIA GREATER 29 */

                    if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 29)
                    {

                        /*" -1005- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                        /*" -1006- GO TO R0400-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                        return;

                        /*" -1007- END-IF */
                    }


                    /*" -1008- ELSE */
                }
                else
                {


                    /*" -1009- IF WS-CRITICA-DIA GREATER 28 */

                    if (WORK_AREA.WS_DTH_CRITICA_R.WS_CRITICA_DIA > 28)
                    {

                        /*" -1010- MOVE 'SIM' TO WS-ERRO-DATA */
                        _.Move("SIM", WORK_AREA.WS_ERRO_DATA);

                        /*" -1011- GO TO R0400-99-SAIDA */
                        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/ //GOTO
                        return;

                        /*" -1012- END-IF */
                    }


                    /*" -1013- END-IF */
                }


                /*" -1013- END-IF. */
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-SECTION */
        private void R0900_00_DECLARE_PROPOVA_SECTION()
        {
            /*" -1027- MOVE '0900' TO WNR-EXEC-SQL. */
            _.Move("0900", WNR_EXEC_SQL);

            /*" -1064- PERFORM R0900_00_DECLARE_PROPOVA_DB_DECLARE_1 */

            R0900_00_DECLARE_PROPOVA_DB_DECLARE_1();

            /*" -1066- PERFORM R0900_00_DECLARE_PROPOVA_DB_OPEN_1 */

            R0900_00_DECLARE_PROPOVA_DB_OPEN_1();

            /*" -1069- IF SQLCODE NOT EQUAL ZERO */

            if (DB.SQLCODE != 00)
            {

                /*" -1070- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1071- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1072- ELSE */
                }
                else
                {


                    /*" -1073- DISPLAY ' PROBLEMA NO DECLARE PROPOVA ' */
                    _.Display($" PROBLEMA NO DECLARE PROPOVA ");

                    /*" -1074- END-IF */
                }


                /*" -1074- END-IF. */
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-DB-DECLARE-1 */
        public void R0900_00_DECLARE_PROPOVA_DB_DECLARE_1()
        {
            /*" -1064- EXEC SQL DECLARE C01_PROPOVA CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_CERTIFICADO, AGE_COBRANCA, DATA_QUITACAO, COD_CLIENTE, NUM_MATRI_VENDEDOR, DATA_VENCIMENTO, COD_USUARIO, DATA_MOVIMENTO FROM SEGUROS.PROPOSTAS_VA WHERE NUM_APOLICE IN ( 109300000709 , 109300001392 , 109300001393 , 109300000909 , 109300000550 , 109300001394 , 109300000598 , 109300001294 , 109300001391 ) AND DATA_QUITACAO BETWEEN :WHOST-DT-INICIO AND :WHOST-DT-FIM AND COD_USUARIO NOT IN ( 'VA0458B' , 'VA0459B' , 'VA0469B' , 'VA0851B' , 'PF0601B' ) AND SIT_REGISTRO = '2' ORDER BY NUM_APOLICE,COD_SUBGRUPO END-EXEC. */
            C01_PROPOVA = new VG0656B_C01_PROPOVA(true);
            string GetQuery_C01_PROPOVA()
            {
                var query = @$"SELECT 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							COD_FONTE
							, 
							NUM_CERTIFICADO
							, 
							AGE_COBRANCA
							, 
							DATA_QUITACAO
							, 
							COD_CLIENTE
							, 
							NUM_MATRI_VENDEDOR
							, 
							DATA_VENCIMENTO
							, 
							COD_USUARIO
							, 
							DATA_MOVIMENTO 
							FROM SEGUROS.PROPOSTAS_VA 
							WHERE NUM_APOLICE IN 
							( 109300000709
							, 
							109300001392
							, 
							109300001393
							, 
							109300000909
							, 
							109300000550
							, 
							109300001394
							, 
							109300000598
							, 
							109300001294
							, 
							109300001391 ) 
							AND DATA_QUITACAO BETWEEN '{WHOST_DT_INICIO}' 
							AND '{WHOST_DT_FIM}' 
							AND COD_USUARIO NOT IN ( 'VA0458B'
							, 'VA0459B'
							, 
							'VA0469B'
							, 'VA0851B'
							, 
							'PF0601B' ) 
							AND SIT_REGISTRO = '2' 
							ORDER BY NUM_APOLICE
							,COD_SUBGRUPO";

                return query;
            }
            C01_PROPOVA.GetQueryEvent += GetQuery_C01_PROPOVA;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-PROPOVA-DB-OPEN-1 */
        public void R0900_00_DECLARE_PROPOVA_DB_OPEN_1()
        {
            /*" -1066- EXEC SQL OPEN C01_PROPOVA END-EXEC. */

            C01_PROPOVA.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-SECTION */
        private void R0910_00_FETCH_PROPOVA_SECTION()
        {
            /*" -1088- MOVE '0910' TO WNR-EXEC-SQL. */
            _.Move("0910", WNR_EXEC_SQL);

            /*" -1101- PERFORM R0910_00_FETCH_PROPOVA_DB_FETCH_1 */

            R0910_00_FETCH_PROPOVA_DB_FETCH_1();

            /*" -1104- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1105- MOVE 'S' TO WFIM-PROPOVA */
                _.Move("S", WFIM_PROPOVA);

                /*" -1105- PERFORM R0910_00_FETCH_PROPOVA_DB_CLOSE_1 */

                R0910_00_FETCH_PROPOVA_DB_CLOSE_1();

                /*" -1108- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1111- ADD 1 TO AC-LIDOS AC-CONTA. */
            AC_LIDOS.Value = AC_LIDOS + 1;
            AC_CONTA.Value = AC_CONTA + 1;

            /*" -1112- IF AC-CONTA GREATER 999 */

            if (AC_CONTA > 999)
            {

                /*" -1113- MOVE ZEROS TO AC-CONTA */
                _.Move(0, AC_CONTA);

                /*" -1114- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

                /*" -1119- DISPLAY 'LIDOS PROPOVA ...... ' ' ' AC-LIDOS ' ' PROPOVA-NUM-CERTIFICADO ' ' WS-TIME. */

                $"LIDOS PROPOVA ......  {AC_LIDOS} {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO} {WORK_AREA.WS_TIME}"
                .Display();
            }


            /*" -1122- MOVE PROPOVA-NUM-APOLICE TO WS-CHAVE-ATU-APOLICE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, WORK_AREA.WS_CHAVE_ATU.WS_CHAVE_ATU_APOLICE);

            /*" -1123- MOVE PROPOVA-COD-SUBGRUPO TO WS-CHAVE-ATU-SUBGRUPO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, WORK_AREA.WS_CHAVE_ATU.WS_CHAVE_ATU_SUBGRUPO);

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-FETCH-1 */
        public void R0910_00_FETCH_PROPOVA_DB_FETCH_1()
        {
            /*" -1101- EXEC SQL FETCH C01_PROPOVA INTO :PROPOVA-NUM-APOLICE, :PROPOVA-COD-SUBGRUPO, :PROPOVA-COD-FONTE, :PROPOVA-NUM-CERTIFICADO, :PROPOVA-AGE-COBRANCA, :PROPOVA-DATA-QUITACAO, :PROPOVA-COD-CLIENTE, :PROPOVA-NUM-MATRI-VENDEDOR, :PROPOVA-DATA-VENCIMENTO, :PROPOVA-COD-USUARIO, :PROPOVA-DATA-MOVIMENTO END-EXEC. */

            if (C01_PROPOVA.Fetch())
            {
                _.Move(C01_PROPOVA.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(C01_PROPOVA.PROPOVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);
                _.Move(C01_PROPOVA.PROPOVA_COD_FONTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE);
                _.Move(C01_PROPOVA.PROPOVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);
                _.Move(C01_PROPOVA.PROPOVA_AGE_COBRANCA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA);
                _.Move(C01_PROPOVA.PROPOVA_DATA_QUITACAO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO);
                _.Move(C01_PROPOVA.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(C01_PROPOVA.PROPOVA_NUM_MATRI_VENDEDOR, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR);
                _.Move(C01_PROPOVA.PROPOVA_DATA_VENCIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_VENCIMENTO);
                _.Move(C01_PROPOVA.PROPOVA_COD_USUARIO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_USUARIO);
                _.Move(C01_PROPOVA.PROPOVA_DATA_MOVIMENTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-PROPOVA-DB-CLOSE-1 */
        public void R0910_00_FETCH_PROPOVA_DB_CLOSE_1()
        {
            /*" -1105- EXEC SQL CLOSE C01_PROPOVA END-EXEC */

            C01_PROPOVA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-INPUT-SECTION */
        private void R1000_00_PROCESSA_INPUT_SECTION()
        {
            /*" -1137- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WNR_EXEC_SQL);

            /*" -1139- IF WS-CHAVE-ATU NOT EQUAL WS-CHAVE-ANT */

            if (WORK_AREA.WS_CHAVE_ATU != WORK_AREA.WS_CHAVE_ANT)
            {

                /*" -1142- MOVE WS-CHAVE-ATU TO WS-CHAVE-ANT */
                _.Move(WORK_AREA.WS_CHAVE_ATU, WORK_AREA.WS_CHAVE_ANT);

                /*" -1145- MOVE PROPOVA-NUM-APOLICE TO WHOST-APOLICE */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, WHOST_APOLICE);

                /*" -1148- MOVE PROPOVA-COD-SUBGRUPO TO WHOST-CODSUBES */
                _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, WHOST_CODSUBES);

                /*" -1150- PERFORM R2800-00-SELECT-PRODUVG */

                R2800_00_SELECT_PRODUVG_SECTION();

                /*" -1153- MOVE PRODUVG-NOME-PRODUTO TO SVA-NOME-PRODUTO */
                _.Move(PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO, REG_ARQSORT1.SVA_NOME_PRODUTO);

                /*" -1157- END-IF. */
            }


            /*" -1160- IF PROPOVA-NUM-APOLICE EQUAL 109300000709 OR 109300001392 OR 109300001393 */

            if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("109300000709", "109300001392", "109300001393"))
            {

                /*" -1165- MOVE 2 TO SVA-PRODUTO-AG */
                _.Move(2, REG_ARQSORT1.SVA_PRODUTO_AG);

                /*" -1166- ELSE */
            }
            else
            {


                /*" -1167- IF PROPOVA-NUM-APOLICE EQUAL 109300000909 */

                if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE == 109300000909)
                {

                    /*" -1169- MOVE 3 TO SVA-PRODUTO-AG */
                    _.Move(3, REG_ARQSORT1.SVA_PRODUTO_AG);

                    /*" -1173- ELSE */
                }
                else
                {


                    /*" -1175- IF PROPOVA-NUM-APOLICE EQUAL 109300000550 OR 109300001394 */

                    if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("109300000550", "109300001394"))
                    {

                        /*" -1177- MOVE 1 TO SVA-PRODUTO-AG */
                        _.Move(1, REG_ARQSORT1.SVA_PRODUTO_AG);

                        /*" -1181- ELSE */
                    }
                    else
                    {


                        /*" -1184- IF PROPOVA-NUM-APOLICE EQUAL 109300000598 OR 109300001294 OR 109300001391 */

                        if (PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.In("109300000598", "109300001294", "109300001391"))
                        {

                            /*" -1187- MOVE 4 TO SVA-PRODUTO-AG. */
                            _.Move(4, REG_ARQSORT1.SVA_PRODUTO_AG);
                        }

                    }

                }

            }


            /*" -1190- MOVE PROPOVA-COD-CLIENTE TO SVA-COD-CLIENTE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE, REG_ARQSORT1.SVA_COD_CLIENTE);

            /*" -1193- MOVE PROPOVA-NUM-APOLICE TO SVA-NUM-APOLICE . */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE, REG_ARQSORT1.SVA_NUM_APOLICE);

            /*" -1196- MOVE PROPOVA-COD-SUBGRUPO TO SVA-COD-SUBGRUPO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO, REG_ARQSORT1.SVA_COD_SUBGRUPO);

            /*" -1199- MOVE PROPOVA-NUM-CERTIFICADO TO SVA-NUM-CERTIFICADO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO, REG_ARQSORT1.SVA_NUM_CERTIFICADO);

            /*" -1202- MOVE PROPOVA-NUM-MATRI-VENDEDOR TO SVA-NUM-MATRI-VENDEDOR. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_MATRI_VENDEDOR, REG_ARQSORT1.SVA_NUM_MATRI_VENDEDOR);

            /*" -1205- MOVE PROPOVA-DATA-QUITACAO TO SVA-DATA-QUITACAO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_QUITACAO, REG_ARQSORT1.SVA_DATA_QUITACAO);

            /*" -1208- MOVE PROPOVA-AGE-COBRANCA TO SVA-AGE-COBRANCA. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_AGE_COBRANCA, REG_ARQSORT1.SVA_AGE_COBRANCA);

            /*" -1211- MOVE PROPOVA-COD-FONTE TO SVA-COD-FONTE. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_FONTE, REG_ARQSORT1.SVA_COD_FONTE);

            /*" -1214- MOVE PROPOVA-DATA-MOVIMENTO TO SVA-DATA-CANCEL. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_DATA_MOVIMENTO, REG_ARQSORT1.SVA_DATA_CANCEL);

            /*" -1217- MOVE PROPOVA-COD-USUARIO TO SVA-COD-USUARIO. */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_USUARIO, REG_ARQSORT1.SVA_COD_USUARIO);

            /*" -1217- RELEASE REG-ARQSORT1. */
            ARQSORT1.Release(REG_ARQSORT1);

            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -1221- PERFORM R0910-00-FETCH-PROPOVA. */

            R0910_00_FETCH_PROPOVA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-PROCESSA-OUTPUT-SECTION */
        private void R2000_00_PROCESSA_OUTPUT_SECTION()
        {
            /*" -1235- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WNR_EXEC_SQL);

            /*" -1237- MOVE SVA-PRODUTO-AG TO WS-PRODUTO-AG-ANT */
            _.Move(REG_ARQSORT1.SVA_PRODUTO_AG, WORK_AREA.WS_PRODUTO_AG_ANT);

            /*" -1243- PERFORM R2010-00-PROCESSA-PRODUTO-AG UNTIL SVA-PRODUTO-AG NOT EQUAL WS-PRODUTO-AG-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_ARQSORT1.SVA_PRODUTO_AG != WORK_AREA.WS_PRODUTO_AG_ANT || WFIM_SORT == "S"))
            {

                R2010_00_PROCESSA_PRODUTO_AG_SECTION();
            }

            /*" -1244- IF WS-PRODUTO-AG-ANT EQUAL 2 */

            if (WORK_AREA.WS_PRODUTO_AG_ANT == 2)
            {

                /*" -1249- MOVE '     TOTAL VIDA MULHER' TO LD02-NOME-PRODUTO */
                _.Move("     TOTAL VIDA MULHER", LD02.LD02_NOME_PRODUTO);

                /*" -1250- ELSE */
            }
            else
            {


                /*" -1251- IF WS-PRODUTO-AG-ANT EQUAL 3 */

                if (WORK_AREA.WS_PRODUTO_AG_ANT == 3)
                {

                    /*" -1253- MOVE '     TOTAL VIDA SENIOR' TO LD02-NOME-PRODUTO */
                    _.Move("     TOTAL VIDA SENIOR", LD02.LD02_NOME_PRODUTO);

                    /*" -1257- ELSE */
                }
                else
                {


                    /*" -1258- IF WS-PRODUTO-AG-ANT EQUAL 1 */

                    if (WORK_AREA.WS_PRODUTO_AG_ANT == 1)
                    {

                        /*" -1260- MOVE '     TOTAL MULTIPREMIADO' TO LD02-NOME-PRODUTO */
                        _.Move("     TOTAL MULTIPREMIADO", LD02.LD02_NOME_PRODUTO);

                        /*" -1264- ELSE */
                    }
                    else
                    {


                        /*" -1265- IF WS-PRODUTO-AG-ANT EQUAL 4 */

                        if (WORK_AREA.WS_PRODUTO_AG_ANT == 4)
                        {

                            /*" -1267- MOVE '     TOTAL VIDA DA GENTE' TO LD02-NOME-PRODUTO */
                            _.Move("     TOTAL VIDA DA GENTE", LD02.LD02_NOME_PRODUTO);

                            /*" -1271- ELSE */
                        }
                        else
                        {


                            /*" -1274- MOVE '     TOTAL OUTROS       ' TO LD02-NOME-PRODUTO. */
                            _.Move("     TOTAL OUTROS       ", LD02.LD02_NOME_PRODUTO);
                        }

                    }

                }

            }


            /*" -1277- MOVE AC-QUANT-AG TO LD02-QUANTIDADE */
            _.Move(AC_QUANT_AG, LD02.LD02_QUANTIDADE);

            /*" -1280- MOVE AC-PREMIO-AG TO LD02-VLPREMIO */
            _.Move(AC_PREMIO_AG, LD02.LD02_VLPREMIO);

            /*" -1283- WRITE REG-MPRODUTO FROM LD02. */
            _.Move(LD02.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -1285- MOVE ZEROS TO AC-QUANT-AG AC-PREMIO-AG. */
            _.Move(0, AC_QUANT_AG, AC_PREMIO_AG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2010-00-PROCESSA-PRODUTO-AG-SECTION */
        private void R2010_00_PROCESSA_PRODUTO_AG_SECTION()
        {
            /*" -1299- MOVE '2010' TO WNR-EXEC-SQL. */
            _.Move("2010", WNR_EXEC_SQL);

            /*" -1301- MOVE SVA-NOME-PRODUTO TO WS-PRODUTO-ANT */
            _.Move(REG_ARQSORT1.SVA_NOME_PRODUTO, WORK_AREA.WS_PRODUTO_ANT);

            /*" -1306- PERFORM R2100-00-PROCESSA-REGISTRO UNTIL SVA-PRODUTO-AG NOT EQUAL WS-PRODUTO-AG-ANT OR SVA-NOME-PRODUTO NOT EQUAL WS-PRODUTO-ANT OR WFIM-SORT EQUAL 'S' . */

            while (!(REG_ARQSORT1.SVA_PRODUTO_AG != WORK_AREA.WS_PRODUTO_AG_ANT || REG_ARQSORT1.SVA_NOME_PRODUTO != WORK_AREA.WS_PRODUTO_ANT || WFIM_SORT == "S"))
            {

                R2100_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -1309- MOVE WS-PRODUTO-ANT TO LD02-NOME-PRODUTO. */
            _.Move(WORK_AREA.WS_PRODUTO_ANT, LD02.LD02_NOME_PRODUTO);

            /*" -1312- MOVE AC-QUANT-PR TO LD02-QUANTIDADE */
            _.Move(AC_QUANT_PR, LD02.LD02_QUANTIDADE);

            /*" -1315- MOVE AC-PREMIO-PR TO LD02-VLPREMIO */
            _.Move(AC_PREMIO_PR, LD02.LD02_VLPREMIO);

            /*" -1318- WRITE REG-MPRODUTO FROM LD02. */
            _.Move(LD02.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -1320- MOVE ZEROS TO AC-QUANT-PR AC-PREMIO-PR. */
            _.Move(0, AC_QUANT_PR, AC_PREMIO_PR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2010_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-PROCESSA-REGISTRO-SECTION */
        private void R2100_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -1334- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", WNR_EXEC_SQL);

            /*" -1336- MOVE ZEROS TO TMP-COD-FONTE. */
            _.Move(0, REG_MTRAB.TMP_COD_FONTE);

            /*" -1337- IF SVA-AGE-COBRANCA NOT EQUAL WS-AGE-COBRANCA-ANT */

            if (REG_ARQSORT1.SVA_AGE_COBRANCA != WORK_AREA.WS_AGE_COBRANCA_ANT)
            {

                /*" -1339- MOVE SVA-AGE-COBRANCA TO WS-AGE-COBRANCA-ANT AGENCCEF-COD-AGENCIA */
                _.Move(REG_ARQSORT1.SVA_AGE_COBRANCA, WORK_AREA.WS_AGE_COBRANCA_ANT, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);

                /*" -1340- PERFORM R2700-00-SELECT-AGENCCEF */

                R2700_00_SELECT_AGENCCEF_SECTION();

                /*" -1342- END-IF. */
            }


            /*" -1343- IF SVA-COD-FONTE NOT EQUAL WS-FONTE-ANT */

            if (REG_ARQSORT1.SVA_COD_FONTE != WORK_AREA.WS_FONTE_ANT)
            {

                /*" -1346- MOVE SVA-COD-FONTE TO WS-FONTE-ANT FONTES-COD-FONTE */
                _.Move(REG_ARQSORT1.SVA_COD_FONTE, WORK_AREA.WS_FONTE_ANT, FONTES.DCLFONTES.FONTES_COD_FONTE);

                /*" -1348- PERFORM R3050-00-SELECT-FONTES */

                R3050_00_SELECT_FONTES_SECTION();

                /*" -1350- END-IF. */
            }


            /*" -1353- MOVE SVA-NOME-PRODUTO TO LD01-NOME-PRODUTO */
            _.Move(REG_ARQSORT1.SVA_NOME_PRODUTO, LD01.LD01_NOME_PRODUTO);

            /*" -1356- MOVE SVA-COD-FONTE TO LD01-COD-FONTE */
            _.Move(REG_ARQSORT1.SVA_COD_FONTE, LD01.LD01_COD_FONTE);

            /*" -1359- MOVE FONTES-NOME-FONTE TO LD01-NOME-FONTE */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, LD01.LD01_NOME_FONTE);

            /*" -1362- MOVE AGENCCEF-COD-ESCNEG TO LD01-COD-ESCNEG */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG, LD01.LD01_COD_ESCNEG);

            /*" -1365- MOVE ESCRINEG-REGIAO-ESCNEG TO LD01-REGIAO-ESCNEG */
            _.Move(ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_REGIAO_ESCNEG, LD01.LD01_REGIAO_ESCNEG);

            /*" -1368- MOVE AGENCCEF-COD-AGENCIA TO LD01-COD-AGENCIA */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA, LD01.LD01_COD_AGENCIA);

            /*" -1371- MOVE AGENCCEF-NOME-AGENCIA TO LD01-NOME-AGENCIA */
            _.Move(AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA, LD01.LD01_NOME_AGENCIA);

            /*" -1375- MOVE SVA-NUM-CERTIFICADO TO LD01-NUM-CERTIFICADO HISCOBPR-NUM-CERTIFICADO */
            _.Move(REG_ARQSORT1.SVA_NUM_CERTIFICADO, LD01.LD01_NUM_CERTIFICADO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_NUM_CERTIFICADO);

            /*" -1378- MOVE SVA-NUM-MATRI-VENDEDOR TO LD01-NUM-MATRI-VENDEDOR */
            _.Move(REG_ARQSORT1.SVA_NUM_MATRI_VENDEDOR, LD01.LD01_NUM_MATRI_VENDEDOR);

            /*" -1381- MOVE SVA-COD-CLIENTE TO CLIENTES-COD-CLIENTE */
            _.Move(REG_ARQSORT1.SVA_COD_CLIENTE, CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE);

            /*" -1383- PERFORM R2500-00-SELECT-CLIENTES */

            R2500_00_SELECT_CLIENTES_SECTION();

            /*" -1386- MOVE CLIENTES-NOME-RAZAO TO LD01-NOME-RAZAO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, LD01.LD01_NOME_RAZAO);

            /*" -1389- MOVE CLIENTES-CGCCPF TO LD01-CGCCPF */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, LD01.LD01_CGCCPF);

            /*" -1392- MOVE SVA-DATA-QUITACAO TO LD01-DATA-QUITACAO */
            _.Move(REG_ARQSORT1.SVA_DATA_QUITACAO, LD01.LD01_DATA_QUITACAO);

            /*" -1394- PERFORM R2600-00-SELECT-HISCOBPR */

            R2600_00_SELECT_HISCOBPR_SECTION();

            /*" -1398- MOVE HISCOBPR-VLPREMIO TO LD01-VLPREMIO TMP-VLPREMIO. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, LD01.LD01_VLPREMIO, REG_MTRAB.TMP_VLPREMIO);

            /*" -1401- MOVE HISCOBPR-IMP-MORNATU TO LD01-IMP-MORNATU. */
            _.Move(HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU, LD01.LD01_IMP_MORNATU);

            /*" -1404- MOVE SVA-DATA-CANCEL TO LD01-DTCANCEL. */
            _.Move(REG_ARQSORT1.SVA_DATA_CANCEL, LD01.LD01_DTCANCEL);

            /*" -1407- MOVE SVA-COD-FONTE TO TMP-COD-FONTE. */
            _.Move(REG_ARQSORT1.SVA_COD_FONTE, REG_MTRAB.TMP_COD_FONTE);

            /*" -1410- MOVE SVA-PRODUTO-AG TO TMP-PRODUTO-AG. */
            _.Move(REG_ARQSORT1.SVA_PRODUTO_AG, REG_MTRAB.TMP_PRODUTO_AG);

            /*" -1413- MOVE SVA-NUM-APOLICE TO TMP-NUM-APOLICE. */
            _.Move(REG_ARQSORT1.SVA_NUM_APOLICE, REG_MTRAB.TMP_NUM_APOLICE);

            /*" -1416- MOVE SVA-COD-SUBGRUPO TO TMP-COD-SUBGRUPO. */
            _.Move(REG_ARQSORT1.SVA_COD_SUBGRUPO, REG_MTRAB.TMP_COD_SUBGRUPO);

            /*" -1419- MOVE SVA-NOME-PRODUTO TO TMP-NOME-PRODUTO. */
            _.Move(REG_ARQSORT1.SVA_NOME_PRODUTO, REG_MTRAB.TMP_NOME_PRODUTO);

            /*" -1424- ADD HISCOBPR-VLPREMIO TO AC-PREMIO-AG AC-PREMIO-PR AC-PREMIO-TT */
            AC_PREMIO_AG.Value = AC_PREMIO_AG + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO;
            AC_PREMIO_PR.Value = AC_PREMIO_PR + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO;
            AC_PREMIO_TT.Value = AC_PREMIO_TT + HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO;

            /*" -1430- ADD 1 TO AC-QUANT-AG AC-QUANT-PR AC-QUANT-TT AC-PROPOSTA. */
            AC_QUANT_AG.Value = AC_QUANT_AG + 1;
            AC_QUANT_PR.Value = AC_QUANT_PR + 1;
            AC_QUANT_TT.Value = AC_QUANT_TT + 1;
            AC_PROPOSTA.Value = AC_PROPOSTA + 1;

            /*" -1432- PERFORM R2900-BUSCA-DADOS-OPCAO-PAGTO. */

            R2900_BUSCA_DADOS_OPCAO_PAGTO_SECTION();

            /*" -1434- WRITE REG-MDETALHE FROM LD01. */
            _.Move(LD01.GetMoveValues(), REG_MDETALHE);

            MDETALHE.Write(REG_MDETALHE.GetMoveValues().ToString());

            /*" -1434- WRITE REG-MTRAB. */
            MTRAB.Write(REG_MTRAB.GetMoveValues().ToString());

            /*" -0- FLUXCONTROL_PERFORM R2100_10_LER */

            R2100_10_LER();

        }

        [StopWatch]
        /*" R2100-10-LER */
        private void R2100_10_LER(bool isPerform = false)
        {
            /*" -1438- PERFORM R2400-00-LE-SORT. */

            R2400_00_LE_SORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2400-00-LE-SORT-SECTION */
        private void R2400_00_LE_SORT_SECTION()
        {
            /*" -1453- MOVE '2400' TO WNR-EXEC-SQL. */
            _.Move("2400", WNR_EXEC_SQL);

            /*" -1455- RETURN ARQSORT1 AT END */
            try
            {
                ARQSORT1.Return(REG_ARQSORT1, () =>
                {

                    /*" -1455- MOVE 'S' TO WFIM-SORT. */
                    _.Move("S", WFIM_SORT);

                });
            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2400_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-SELECT-CLIENTES-SECTION */
        private void R2500_00_SELECT_CLIENTES_SECTION()
        {
            /*" -1469- MOVE '2500' TO WNR-EXEC-SQL. */
            _.Move("2500", WNR_EXEC_SQL);

            /*" -1476- PERFORM R2500_00_SELECT_CLIENTES_DB_SELECT_1 */

            R2500_00_SELECT_CLIENTES_DB_SELECT_1();

            /*" -1479- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1480- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1480- END-IF. */
            }


        }

        [StopWatch]
        /*" R2500-00-SELECT-CLIENTES-DB-SELECT-1 */
        public void R2500_00_SELECT_CLIENTES_DB_SELECT_1()
        {
            /*" -1476- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF FROM SEGUROS.CLIENTES WHERE COD_CLIENTE = :CLIENTES-COD-CLIENTE END-EXEC. */

            var r2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1 = new R2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1()
            {
                CLIENTES_COD_CLIENTE = CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.ToString(),
            };

            var executed_1 = R2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1.Execute(r2500_00_SELECT_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2600-00-SELECT-HISCOBPR-SECTION */
        private void R2600_00_SELECT_HISCOBPR_SECTION()
        {
            /*" -1494- MOVE '2600' TO WNR-EXEC-SQL. */
            _.Move("2600", WNR_EXEC_SQL);

            /*" -1502- PERFORM R2600_00_SELECT_HISCOBPR_DB_SELECT_1 */

            R2600_00_SELECT_HISCOBPR_DB_SELECT_1();

            /*" -1505- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1506- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1509- MOVE ZEROS TO HISCOBPR-VLPREMIO HISCOBPR-IMP-MORNATU */
                    _.Move(0, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);

                    /*" -1510- ELSE */
                }
                else
                {


                    /*" -1510- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2600-00-SELECT-HISCOBPR-DB-SELECT-1 */
        public void R2600_00_SELECT_HISCOBPR_DB_SELECT_1()
        {
            /*" -1502- EXEC SQL SELECT VLPREMIO, IMP_MORNATU INTO :HISCOBPR-VLPREMIO, :HISCOBPR-IMP-MORNATU FROM SEGUROS.HIS_COBER_PROPOST WHERE NUM_CERTIFICADO = :SVA-NUM-CERTIFICADO AND OCORR_HISTORICO = 1 END-EXEC. */

            var r2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 = new R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1()
            {
                SVA_NUM_CERTIFICADO = REG_ARQSORT1.SVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1.Execute(r2600_00_SELECT_HISCOBPR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISCOBPR_VLPREMIO, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_VLPREMIO);
                _.Move(executed_1.HISCOBPR_IMP_MORNATU, HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_IMP_MORNATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2600_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-SELECT-AGENCCEF-SECTION */
        private void R2700_00_SELECT_AGENCCEF_SECTION()
        {
            /*" -1524- MOVE '2700' TO WNR-EXEC-SQL. */
            _.Move("2700", WNR_EXEC_SQL);

            /*" -1535- PERFORM R2700_00_SELECT_AGENCCEF_DB_SELECT_1 */

            R2700_00_SELECT_AGENCCEF_DB_SELECT_1();

            /*" -1538- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1539- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1540- MOVE 05 TO AGENCCEF-COD-AGENCIA */
                    _.Move(05, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA);

                    /*" -1541- MOVE 4172 TO AGENCCEF-COD-ESCNEG */
                    _.Move(4172, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG);

                    /*" -1542- ELSE */
                }
                else
                {


                    /*" -1542- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2700-00-SELECT-AGENCCEF-DB-SELECT-1 */
        public void R2700_00_SELECT_AGENCCEF_DB_SELECT_1()
        {
            /*" -1535- EXEC SQL SELECT A.NOME_AGENCIA, A.COD_ESCNEG, B.REGIAO_ESCNEG INTO :AGENCCEF-NOME-AGENCIA, :AGENCCEF-COD-ESCNEG, :ESCRINEG-REGIAO-ESCNEG FROM SEGUROS.AGENCIAS_CEF A, SEGUROS.ESCRITORIO_NEGOCIO B WHERE A.COD_AGENCIA = :AGENCCEF-COD-AGENCIA AND B.COD_ESCNEG = A.COD_ESCNEG END-EXEC. */

            var r2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1 = new R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1()
            {
                AGENCCEF_COD_AGENCIA = AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA.ToString(),
            };

            var executed_1 = R2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1.Execute(r2700_00_SELECT_AGENCCEF_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AGENCCEF_NOME_AGENCIA, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_NOME_AGENCIA);
                _.Move(executed_1.AGENCCEF_COD_ESCNEG, AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_ESCNEG);
                _.Move(executed_1.ESCRINEG_REGIAO_ESCNEG, ESCRINEG.DCLESCRITORIO_NEGOCIO.ESCRINEG_REGIAO_ESCNEG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R2800-00-SELECT-PRODUVG-SECTION */
        private void R2800_00_SELECT_PRODUVG_SECTION()
        {
            /*" -1556- MOVE '2800' TO WNR-EXEC-SQL. */
            _.Move("2800", WNR_EXEC_SQL);

            /*" -1562- PERFORM R2800_00_SELECT_PRODUVG_DB_SELECT_1 */

            R2800_00_SELECT_PRODUVG_DB_SELECT_1();

            /*" -1565- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1566- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1567- MOVE 'PRODUTO INEXISTENTE' TO PRODUVG-NOME-PRODUTO */
                    _.Move("PRODUTO INEXISTENTE", PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);

                    /*" -1568- ELSE */
                }
                else
                {


                    /*" -1569- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1570- END-IF */
                }


                /*" -1570- END-IF. */
            }


        }

        [StopWatch]
        /*" R2800-00-SELECT-PRODUVG-DB-SELECT-1 */
        public void R2800_00_SELECT_PRODUVG_DB_SELECT_1()
        {
            /*" -1562- EXEC SQL SELECT NOME_PRODUTO INTO :PRODUVG-NOME-PRODUTO FROM SEGUROS.PRODUTOS_VG WHERE NUM_APOLICE = :WHOST-APOLICE AND COD_SUBGRUPO = :WHOST-CODSUBES END-EXEC. */

            var r2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1 = new R2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1()
            {
                WHOST_CODSUBES = WHOST_CODSUBES.ToString(),
                WHOST_APOLICE = WHOST_APOLICE.ToString(),
            };

            var executed_1 = R2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1.Execute(r2800_00_SELECT_PRODUVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PRODUVG_NOME_PRODUTO, PRODUVG.DCLPRODUTOS_VG.PRODUVG_NOME_PRODUTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2800_99_SAIDA*/

        [StopWatch]
        /*" R2900-BUSCA-DADOS-OPCAO-PAGTO-SECTION */
        private void R2900_BUSCA_DADOS_OPCAO_PAGTO_SECTION()
        {
            /*" -1584- MOVE '2900' TO WNR-EXEC-SQL. */
            _.Move("2900", WNR_EXEC_SQL);

            /*" -1586- INITIALIZE DCLOPCAO-PAG-VIDAZUL */
            _.Initialize(
                OPCPAGVI.DCLOPCAO_PAG_VIDAZUL
            );

            /*" -1588- MOVE SVA-NUM-CERTIFICADO TO OPCPAGVI-NUM-CERTIFICADO. */
            _.Move(REG_ARQSORT1.SVA_NUM_CERTIFICADO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO);

            /*" -1604- PERFORM R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1 */

            R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1();

            /*" -1607- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1608- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1610- DISPLAY 'DADOS OPCAO PAG NAO CONSTAM NA OPCAO_PAG_VIDAZUL' */
                    _.Display($"DADOS OPCAO PAG NAO CONSTAM NA OPCAO_PAG_VIDAZUL");

                    /*" -1611- GO TO R2900-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/ //GOTO
                    return;

                    /*" -1612- ELSE */
                }
                else
                {


                    /*" -1613- DISPLAY 'ERRO SELECT - TAB OPCAO_PAG_VIDAZUL' */
                    _.Display($"ERRO SELECT - TAB OPCAO_PAG_VIDAZUL");

                    /*" -1614- DISPLAY 'ERRO SELECT - TAB OPCAO_PAG_VIDAZUL' */
                    _.Display($"ERRO SELECT - TAB OPCAO_PAG_VIDAZUL");

                    /*" -1615- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1616- END-IF */
                }


                /*" -1618- END-IF. */
            }


            /*" -1619- IF VIND-OPE-PAG LESS THAN ZERO */

            if (VIND_OPE_PAG < 00)
            {

                /*" -1620- MOVE ZEROS TO OPCPAGVI-OPCAO-PAGAMENTO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);

                /*" -1622- END-IF. */
            }


            /*" -1623- IF VIND-AGENCIA LESS THAN ZERO */

            if (VIND_AGENCIA < 00)
            {

                /*" -1624- MOVE ZEROS TO OPCPAGVI-COD-AGENCIA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);

                /*" -1626- END-IF. */
            }


            /*" -1627- IF VIND-OPER LESS THAN ZERO */

            if (VIND_OPER < 00)
            {

                /*" -1628- MOVE ZEROS TO OPCPAGVI-OPE-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);

                /*" -1630- END-IF. */
            }


            /*" -1631- IF VIND-CTADEB LESS THAN ZERO */

            if (VIND_CTADEB < 00)
            {

                /*" -1632- MOVE ZEROS TO OPCPAGVI-NUM-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);

                /*" -1634- END-IF. */
            }


            /*" -1635- IF VIND-DGCTA LESS THAN ZERO */

            if (VIND_DGCTA < 00)
            {

                /*" -1636- MOVE ZEROS TO OPCPAGVI-DIG-CONTA-DEBITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);

                /*" -1638- END-IF. */
            }


            /*" -1640- IF VIND-CARTAO LESS THAN ZERO OR OPCPAGVI-NUM-CARTAO-CREDITO NOT NUMERIC */

            if (VIND_CARTAO < 00 || !OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO.IsNumeric())
            {

                /*" -1641- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO */
                _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                /*" -1643- END-IF. */
            }


            /*" -1644- EVALUATE OPCPAGVI-OPCAO-PAGAMENTO */
            switch (OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO.Value.Trim())
            {

                /*" -1645- WHEN    '1' */
                case "1":

                    /*" -1646- MOVE TB-OPC-PAGTO (1) TO LD01-OPC-PAG */
                    _.Move(WORK_AREA.TAB_OPC_PGTO_RED.TB_OPC_PAGTO[1], LD01.LD01_OPC_PAG);

                    /*" -1648- MOVE ZERO TO LD01-CHEQUE LD01-DVCHEQ */
                    _.Move(0, LD01.LD01_CHEQUE, LD01.LD01_DVCHEQ);

                    /*" -1649- WHEN    '2' */
                    break;
                case "2":

                    /*" -1650- MOVE TB-OPC-PAGTO (2) TO LD01-OPC-PAG */
                    _.Move(WORK_AREA.TAB_OPC_PGTO_RED.TB_OPC_PAGTO[2], LD01.LD01_OPC_PAG);

                    /*" -1652- MOVE ZERO TO LD01-CHEQUE LD01-DVCHEQ */
                    _.Move(0, LD01.LD01_CHEQUE, LD01.LD01_DVCHEQ);

                    /*" -1653- WHEN    '3' */
                    break;
                case "3":

                    /*" -1654- MOVE TB-OPC-PAGTO (3) TO LD01-OPC-PAG */
                    _.Move(WORK_AREA.TAB_OPC_PGTO_RED.TB_OPC_PAGTO[3], LD01.LD01_OPC_PAG);

                    /*" -1655- PERFORM R2910-BUSCA-NUM-CHEQUE */

                    R2910_BUSCA_NUM_CHEQUE_SECTION();

                    /*" -1656- MOVE CBCONDEV-NUM-CHEQUE-INTERNO TO LD01-CHEQUE */
                    _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO, LD01.LD01_CHEQUE);

                    /*" -1657- MOVE CBCONDEV-DIG-CHEQUE-INTERNO TO LD01-DVCHEQ */
                    _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO, LD01.LD01_DVCHEQ);

                    /*" -1658- WHEN    '4' */
                    break;
                case "4":

                    /*" -1659- MOVE TB-OPC-PAGTO (4) TO LD01-OPC-PAG */
                    _.Move(WORK_AREA.TAB_OPC_PGTO_RED.TB_OPC_PAGTO[4], LD01.LD01_OPC_PAG);

                    /*" -1660- WHEN    '5' */
                    break;
                case "5":

                    /*" -1661- MOVE TB-OPC-PAGTO (5) TO LD01-OPC-PAG */
                    _.Move(WORK_AREA.TAB_OPC_PGTO_RED.TB_OPC_PAGTO[5], LD01.LD01_OPC_PAG);

                    /*" -1662- MOVE OPCPAGVI-NUM-CARTAO-CREDITO TO LD01-CARTAO */
                    _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO, LD01.LD01_CARTAO);

                    /*" -1663- WHEN    OTHER */
                    break;
                default:

                    /*" -1664- MOVE 'NAO CONSTA' TO LD01-OPC-PAG */
                    _.Move("NAO CONSTA", LD01.LD01_OPC_PAG);

                    /*" -1666- END-EVALUATE. */
                    break;
            }


            /*" -1667- MOVE OPCPAGVI-COD-AGENCIA-DEBITO TO LD01-AGE-DEB. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO, LD01.LD01_AGE_DEB);

            /*" -1668- MOVE OPCPAGVI-OPE-CONTA-DEBITO TO LD01-OPER-DEB. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO, LD01.LD01_OPER_DEB);

            /*" -1669- MOVE OPCPAGVI-NUM-CONTA-DEBITO TO LD01-CTA-DEB. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO, LD01.LD01_CTA_DEB);

            /*" -1671- MOVE OPCPAGVI-DIG-CONTA-DEBITO TO LD01-DV-CONTA. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO, LD01.LD01_DV_CONTA);

            /*" -1671- PERFORM R2920-BUSCA-MOTIVO-CANCEL. */

            R2920_BUSCA_MOTIVO_CANCEL_SECTION();

        }

        [StopWatch]
        /*" R2900-BUSCA-DADOS-OPCAO-PAGTO-DB-SELECT-1 */
        public void R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1()
        {
            /*" -1604- EXEC SQL SELECT OPCAO_PAGAMENTO , COD_AGENCIA_DEBITO , OPE_CONTA_DEBITO , NUM_CONTA_DEBITO , DIG_CONTA_DEBITO , NUM_CARTAO_CREDITO INTO :OPCPAGVI-OPCAO-PAGAMENTO:VIND-OPE-PAG , :OPCPAGVI-COD-AGENCIA-DEBITO:VIND-AGENCIA , :OPCPAGVI-OPE-CONTA-DEBITO:VIND-OPER , :OPCPAGVI-NUM-CONTA-DEBITO:VIND-CTADEB , :OPCPAGVI-DIG-CONTA-DEBITO:VIND-DGCTA , :OPCPAGVI-NUM-CARTAO-CREDITO:VIND-CARTAO FROM SEGUROS.OPCAO_PAG_VIDAZUL WHERE NUM_CERTIFICADO = :OPCPAGVI-NUM-CERTIFICADO AND DATA_TERVIGENCIA = '9999-12-31' END-EXEC. */

            var r2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1 = new R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1()
            {
                OPCPAGVI_NUM_CERTIFICADO = OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1.Execute(r2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OPCPAGVI_OPCAO_PAGAMENTO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPCAO_PAGAMENTO);
                _.Move(executed_1.VIND_OPE_PAG, VIND_OPE_PAG);
                _.Move(executed_1.OPCPAGVI_COD_AGENCIA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_COD_AGENCIA_DEBITO);
                _.Move(executed_1.VIND_AGENCIA, VIND_AGENCIA);
                _.Move(executed_1.OPCPAGVI_OPE_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_OPE_CONTA_DEBITO);
                _.Move(executed_1.VIND_OPER, VIND_OPER);
                _.Move(executed_1.OPCPAGVI_NUM_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CONTA_DEBITO);
                _.Move(executed_1.VIND_CTADEB, VIND_CTADEB);
                _.Move(executed_1.OPCPAGVI_DIG_CONTA_DEBITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DIG_CONTA_DEBITO);
                _.Move(executed_1.VIND_DGCTA, VIND_DGCTA);
                _.Move(executed_1.OPCPAGVI_NUM_CARTAO_CREDITO, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);
                _.Move(executed_1.VIND_CARTAO, VIND_CARTAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2900_99_SAIDA*/

        [StopWatch]
        /*" R2910-BUSCA-NUM-CHEQUE-SECTION */
        private void R2910_BUSCA_NUM_CHEQUE_SECTION()
        {
            /*" -1684- MOVE '2910' TO WNR-EXEC-SQL. */
            _.Move("2910", WNR_EXEC_SQL);

            /*" -1685- MOVE SVA-NUM-CERTIFICADO TO PROPOVA-NUM-CERTIFICADO. */
            _.Move(REG_ARQSORT1.SVA_NUM_CERTIFICADO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO);

            /*" -1686- MOVE SVA-NUM-APOLICE TO PROPOVA-NUM-APOLICE. */
            _.Move(REG_ARQSORT1.SVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);

            /*" -1688- MOVE SVA-COD-SUBGRUPO TO PROPOVA-COD-SUBGRUPO. */
            _.Move(REG_ARQSORT1.SVA_COD_SUBGRUPO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO);

            /*" -1699- PERFORM R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1 */

            R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1();

            /*" -1702- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1703- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1704- MOVE ZEROS TO CBCONDEV-NUM-CHEQUE-INTERNO */
                    _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO);

                    /*" -1705- MOVE ZEROS TO CBCONDEV-DIG-CHEQUE-INTERNO */
                    _.Move(0, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO);

                    /*" -1706- MOVE ZEROS TO OPCPAGVI-NUM-CARTAO-CREDITO */
                    _.Move(0, OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO);

                    /*" -1707- GO TO R2910-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/ //GOTO
                    return;

                    /*" -1708- ELSE */
                }
                else
                {


                    /*" -1709- DISPLAY 'R2910 - ERRO SELECT CB_CONTR_DEVPREMIO' */
                    _.Display($"R2910 - ERRO SELECT CB_CONTR_DEVPREMIO");

                    /*" -1710- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1711- END-IF */
                }


                /*" -1713- END-IF. */
            }


            /*" -1714- MOVE CBCONDEV-NUM-CHEQUE-INTERNO TO LD01-CHEQUE. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO, LD01.LD01_CHEQUE);

            /*" -1715- MOVE CBCONDEV-DIG-CHEQUE-INTERNO TO LD01-DVCHEQ. */
            _.Move(CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO, LD01.LD01_DVCHEQ);

            /*" -1715- MOVE OPCPAGVI-NUM-CARTAO-CREDITO TO LD01-CARTAO. */
            _.Move(OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CARTAO_CREDITO, LD01.LD01_CARTAO);

        }

        [StopWatch]
        /*" R2910-BUSCA-NUM-CHEQUE-DB-SELECT-1 */
        public void R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1()
        {
            /*" -1699- EXEC SQL SELECT NUM_CHEQUE_INTERNO , DIG_CHEQUE_INTERNO INTO :CBCONDEV-NUM-CHEQUE-INTERNO , :CBCONDEV-DIG-CHEQUE-INTERNO FROM SEGUROS.CB_CONTR_DEVPREMIO WHERE TIPO_MOVIMENTO = '8' AND NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND NUM_APOLICE = :PROPOVA-NUM-APOLICE AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO END-EXEC. */

            var r2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1 = new R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                PROPOVA_COD_SUBGRUPO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.ToString(),
                PROPOVA_NUM_APOLICE = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.ToString(),
            };

            var executed_1 = R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1.Execute(r2910_BUSCA_NUM_CHEQUE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CBCONDEV_NUM_CHEQUE_INTERNO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_NUM_CHEQUE_INTERNO);
                _.Move(executed_1.CBCONDEV_DIG_CHEQUE_INTERNO, CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DIG_CHEQUE_INTERNO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2910_99_SAIDA*/

        [StopWatch]
        /*" R2920-BUSCA-MOTIVO-CANCEL-SECTION */
        private void R2920_BUSCA_MOTIVO_CANCEL_SECTION()
        {
            /*" -1729- MOVE '2920' TO WNR-EXEC-SQL. */
            _.Move("2920", WNR_EXEC_SQL);

            /*" -1731- MOVE SVA-NUM-CERTIFICADO TO COBHISVI-NUM-CERTIFICADO. */
            _.Move(REG_ARQSORT1.SVA_NUM_CERTIFICADO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO);

            /*" -1741- PERFORM R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1 */

            R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1();

            /*" -1744- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1745- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1746- MOVE ZEROS TO COBHISVI-COD-DEVOLUCAO */
                    _.Move(0, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_DEVOLUCAO);

                    /*" -1747- MOVE SPACES TO DEVOLVID-DESC-DEVOLUCAO */
                    _.Move("", DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_DESC_DEVOLUCAO);

                    /*" -1748- ELSE */
                }
                else
                {


                    /*" -1749- DISPLAY 'PROBLEMAS NO SELECT MOTIVO CANCELAMENTO' */
                    _.Display($"PROBLEMAS NO SELECT MOTIVO CANCELAMENTO");

                    /*" -1750- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1751- END-IF */
                }


                /*" -1753- END-IF. */
            }


            /*" -1754- MOVE ZEROS TO LD01-COD-DEVOL. */
            _.Move(0, LD01.LD01_COD_DEVOL);

            /*" -1756- MOVE COBHISVI-COD-DEVOLUCAO TO LD01-COD-DEVOL. */
            _.Move(COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_DEVOLUCAO, LD01.LD01_COD_DEVOL);

            /*" -1759- MOVE 1862 TO ERRPROVI-COD-ERRO */
            _.Move(1862, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

            /*" -1761- PERFORM R2921-00-SELECT-ERRPROVI */

            R2921_00_SELECT_ERRPROVI_SECTION();

            /*" -1762- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -1763- MOVE 'CPF INATIVO' TO LD01-DESCR-ERRO */
                _.Move("CPF INATIVO", LD01.LD01_DESCR_ERRO);

                /*" -1764- ELSE */
            }
            else
            {


                /*" -1766- MOVE 1800 TO ERRPROVI-COD-ERRO */
                _.Move(1800, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                /*" -1767- PERFORM R2921-00-SELECT-ERRPROVI */

                R2921_00_SELECT_ERRPROVI_SECTION();

                /*" -1768- IF SQLCODE EQUAL ZEROS */

                if (DB.SQLCODE == 00)
                {

                    /*" -1770- MOVE 'PROPOSTA FISICA NAO RECEPCIONADA' TO LD01-DESCR-ERRO */
                    _.Move("PROPOSTA FISICA NAO RECEPCIONADA", LD01.LD01_DESCR_ERRO);

                    /*" -1771- ELSE */
                }
                else
                {


                    /*" -1773- MOVE 1807 TO ERRPROVI-COD-ERRO */
                    _.Move(1807, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                    /*" -1774- PERFORM R2921-00-SELECT-ERRPROVI */

                    R2921_00_SELECT_ERRPROVI_SECTION();

                    /*" -1775- IF SQLCODE EQUAL ZEROS */

                    if (DB.SQLCODE == 00)
                    {

                        /*" -1777- MOVE 'APOSENTADO POR INVALIDEZ' TO LD01-DESCR-ERRO */
                        _.Move("APOSENTADO POR INVALIDEZ", LD01.LD01_DESCR_ERRO);

                        /*" -1778- ELSE */
                    }
                    else
                    {


                        /*" -1780- MOVE 1855 TO ERRPROVI-COD-ERRO */
                        _.Move(1855, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);

                        /*" -1781- PERFORM R2921-00-SELECT-ERRPROVI */

                        R2921_00_SELECT_ERRPROVI_SECTION();

                        /*" -1782- IF SQLCODE EQUAL ZEROS */

                        if (DB.SQLCODE == 00)
                        {

                            /*" -1784- MOVE 'LIMITE DE CAPITAL ULTRAPASSADO' TO LD01-DESCR-ERRO */
                            _.Move("LIMITE DE CAPITAL ULTRAPASSADO", LD01.LD01_DESCR_ERRO);

                            /*" -1785- ELSE */
                        }
                        else
                        {


                            /*" -1786- PERFORM R2922-00-SELECT-ERRPROVI */

                            R2922_00_SELECT_ERRPROVI_SECTION();

                            /*" -1789- MOVE ERROSVID-DESCR-ERRO TO LD01-DESCR-ERRO. */
                            _.Move(ERROSVID.DCLERROS_VIDAZUL.ERROSVID_DESCR_ERRO, LD01.LD01_DESCR_ERRO);
                        }

                    }

                }

            }


            /*" -1789- MOVE SVA-COD-USUARIO TO LD01-USUARIO. */
            _.Move(REG_ARQSORT1.SVA_COD_USUARIO, LD01.LD01_USUARIO);

        }

        [StopWatch]
        /*" R2920-BUSCA-MOTIVO-CANCEL-DB-SELECT-1 */
        public void R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1()
        {
            /*" -1741- EXEC SQL SELECT A.COD_DEVOLUCAO, B.DESC_DEVOLUCAO INTO :COBHISVI-COD-DEVOLUCAO, :DEVOLVID-DESC-DEVOLUCAO FROM SEGUROS.COBER_HIST_VIDAZUL A, SEGUROS.DEVOLUCAO_VIDAZUL B WHERE A.COD_DEVOLUCAO = B.COD_DEVOLUCAO AND A.NUM_CERTIFICADO = :COBHISVI-NUM-CERTIFICADO END-EXEC. */

            var r2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1 = new R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1()
            {
                COBHISVI_NUM_CERTIFICADO = COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1.Execute(r2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBHISVI_COD_DEVOLUCAO, COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_COD_DEVOLUCAO);
                _.Move(executed_1.DEVOLVID_DESC_DEVOLUCAO, DEVOLVID.DCLDEVOLUCAO_VIDAZUL.DEVOLVID_DESC_DEVOLUCAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2920_99_SAIDA*/

        [StopWatch]
        /*" R2921-00-SELECT-ERRPROVI-SECTION */
        private void R2921_00_SELECT_ERRPROVI_SECTION()
        {
            /*" -1816- MOVE '2921' TO WNR-EXEC-SQL. */
            _.Move("2921", WNR_EXEC_SQL);

            /*" -1827- PERFORM R2921_00_SELECT_ERRPROVI_DB_SELECT_1 */

            R2921_00_SELECT_ERRPROVI_DB_SELECT_1();

            /*" -1830- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -1831- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1831- END-IF. */
            }


        }

        [StopWatch]
        /*" R2921-00-SELECT-ERRPROVI-DB-SELECT-1 */
        public void R2921_00_SELECT_ERRPROVI_DB_SELECT_1()
        {
            /*" -1827- EXEC SQL SELECT A.COD_MSG_CRITICA, SUBSTR(VALUE(B.DES_ABREV_MSG_CRITICA, ' ' ),1,40) INTO :ERRPROVI-COD-ERRO , :ERROSVID-DESCR-ERRO FROM SEGUROS.VG_CRITICA_PROPOSTA A, SEGUROS.VG_DM_MSG_CRITICA B WHERE A.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND A.COD_MSG_CRITICA = :ERRPROVI-COD-ERRO AND A.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND B.COD_MSG_CRITICA = A.COD_MSG_CRITICA END-EXEC. */

            var r2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1 = new R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
                ERRPROVI_COD_ERRO = ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO.ToString(),
            };

            var executed_1 = R2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1.Execute(r2921_00_SELECT_ERRPROVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ERRPROVI_COD_ERRO, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);
                _.Move(executed_1.ERROSVID_DESCR_ERRO, ERROSVID.DCLERROS_VIDAZUL.ERROSVID_DESCR_ERRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2921_99_SAIDA*/

        [StopWatch]
        /*" R2922-00-SELECT-ERRPROVI-SECTION */
        private void R2922_00_SELECT_ERRPROVI_SECTION()
        {
            /*" -1853- MOVE '2922' TO WNR-EXEC-SQL. */
            _.Move("2922", WNR_EXEC_SQL);

            /*" -1862- PERFORM R2922_00_SELECT_ERRPROVI_DB_SELECT_1 */

            R2922_00_SELECT_ERRPROVI_DB_SELECT_1();

            /*" -1865- IF ERRPROVI-COD-ERRO EQUAL ZEROS */

            if (ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO == 00)
            {

                /*" -1866- MOVE 'OUTROS' TO LD01-DESCR-ERRO */
                _.Move("OUTROS", LD01.LD01_DESCR_ERRO);

                /*" -1867- GO TO R2922-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R2922_99_SAIDA*/ //GOTO
                return;

                /*" -1869- END-IF. */
            }


            /*" -1869- PERFORM R2921-00-SELECT-ERRPROVI. */

            R2921_00_SELECT_ERRPROVI_SECTION();

        }

        [StopWatch]
        /*" R2922-00-SELECT-ERRPROVI-DB-SELECT-1 */
        public void R2922_00_SELECT_ERRPROVI_DB_SELECT_1()
        {
            /*" -1862- EXEC SQL SELECT VALUE(MIN(T1.COD_MSG_CRITICA),0) INTO :ERRPROVI-COD-ERRO FROM SEGUROS.VG_CRITICA_PROPOSTA T1, SEGUROS.VG_DM_MSG_CRITICA T2 WHERE T1.NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO AND T1.STA_CRITICA IN ( '0' , '1' , '2' , '4' , '5' , '8' ) AND T1.COD_MSG_CRITICA = T2.COD_MSG_CRITICA AND T2.COD_TP_MSG_CRITICA <> '3' END-EXEC. */

            var r2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1 = new R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1()
            {
                PROPOVA_NUM_CERTIFICADO = PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.ToString(),
            };

            var executed_1 = R2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1.Execute(r2922_00_SELECT_ERRPROVI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ERRPROVI_COD_ERRO, ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2922_99_SAIDA*/

        [StopWatch]
        /*" R3050-00-SELECT-FONTES-SECTION */
        private void R3050_00_SELECT_FONTES_SECTION()
        {
            /*" -1883- MOVE '3050' TO WNR-EXEC-SQL. */
            _.Move("3050", WNR_EXEC_SQL);

            /*" -1888- PERFORM R3050_00_SELECT_FONTES_DB_SELECT_1 */

            R3050_00_SELECT_FONTES_DB_SELECT_1();

            /*" -1891- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1892- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1893- MOVE 'FONTE INEXISTENTE' TO FONTES-NOME-FONTE */
                    _.Move("FONTE INEXISTENTE", FONTES.DCLFONTES.FONTES_NOME_FONTE);

                    /*" -1894- ELSE */
                }
                else
                {


                    /*" -1895- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1896- END-IF */
                }


                /*" -1896- END-IF. */
            }


        }

        [StopWatch]
        /*" R3050-00-SELECT-FONTES-DB-SELECT-1 */
        public void R3050_00_SELECT_FONTES_DB_SELECT_1()
        {
            /*" -1888- EXEC SQL SELECT NOME_FONTE INTO :FONTES-NOME-FONTE FROM SEGUROS.FONTES WHERE COD_FONTE = :FONTES-COD-FONTE END-EXEC. */

            var r3050_00_SELECT_FONTES_DB_SELECT_1_Query1 = new R3050_00_SELECT_FONTES_DB_SELECT_1_Query1()
            {
                FONTES_COD_FONTE = FONTES.DCLFONTES.FONTES_COD_FONTE.ToString(),
            };

            var executed_1 = R3050_00_SELECT_FONTES_DB_SELECT_1_Query1.Execute(r3050_00_SELECT_FONTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTES_NOME_FONTE, FONTES.DCLFONTES.FONTES_NOME_FONTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3050_99_SAIDA*/

        [StopWatch]
        /*" R3100-00-LE-MTRAB-SECTION */
        private void R3100_00_LE_MTRAB_SECTION()
        {
            /*" -1909- MOVE '3100' TO WNR-EXEC-SQL. */
            _.Move("3100", WNR_EXEC_SQL);

            /*" -1910- READ MTRAB AT END */
            try
            {
                MTRAB.Read(() =>
                {

                    /*" -1912- MOVE 'S' TO WFIM-MTRAB */
                    _.Move("S", WFIM_MTRAB);

                    /*" -1914- GO TO R3100-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(MTRAB.Value, REG_MTRAB);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1914- ADD 1 TO AC-LIDOS-MTRAB. */
            AC_LIDOS_MTRAB.Value = AC_LIDOS_MTRAB + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R3100_99_SAIDA*/

        [StopWatch]
        /*" R4000-00-PROCESSA-MTRAB-SECTION */
        private void R4000_00_PROCESSA_MTRAB_SECTION()
        {
            /*" -1928- MOVE '4000' TO WNR-EXEC-SQL. */
            _.Move("4000", WNR_EXEC_SQL);

            /*" -1932- MOVE TMP-COD-FONTE TO WS-FONTE-ANT FONTES-COD-FONTE LD00-03-COD-FONTE. */
            _.Move(REG_MTRAB.TMP_COD_FONTE, WORK_AREA.WS_FONTE_ANT, FONTES.DCLFONTES.FONTES_COD_FONTE, LD00_03.LD00_03_COD_FONTE);

            /*" -1934- PERFORM R3050-00-SELECT-FONTES */

            R3050_00_SELECT_FONTES_SECTION();

            /*" -1937- MOVE FONTES-NOME-FONTE TO LD00-03-NOME-FONTE */
            _.Move(FONTES.DCLFONTES.FONTES_NOME_FONTE, LD00_03.LD00_03_NOME_FONTE);

            /*" -1938- WRITE REG-MPRODUTO FROM LD00-03. */
            _.Move(LD00_03.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -1940- WRITE REG-MPRODUTO FROM LD00-1-03. */
            _.Move(LD00_1_03.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -1944- PERFORM R4005-00-PROCESSA-FONTE UNTIL TMP-COD-FONTE NOT EQUAL WS-FONTE-ANT OR WFIM-MTRAB EQUAL 'S' . */

            while (!(REG_MTRAB.TMP_COD_FONTE != WORK_AREA.WS_FONTE_ANT || WFIM_MTRAB == "S"))
            {

                R4005_00_PROCESSA_FONTE_SECTION();
            }

            /*" -1947- MOVE '     TOTAL FILIAL     ' TO LD03-NOME-PRODUTO. */
            _.Move("     TOTAL FILIAL     ", LD03.LD03_NOME_PRODUTO);

            /*" -1950- MOVE AC-QUANT-FI TO LD03-QUANTIDADE. */
            _.Move(AC_QUANT_FI, LD03.LD03_QUANTIDADE);

            /*" -1953- MOVE AC-PREMIO-FI TO LD03-VLPREMIO. */
            _.Move(AC_PREMIO_FI, LD03.LD03_VLPREMIO);

            /*" -1956- WRITE REG-MPRODUTO FROM LD03. */
            _.Move(LD03.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -1959- WRITE REG-MPRODUTO FROM LD00-BRANCOS. */
            _.Move(LD00_BRANCOS.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -1961- MOVE ZEROS TO AC-QUANT-FI AC-PREMIO-FI. */
            _.Move(0, AC_QUANT_FI, AC_PREMIO_FI);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4000_99_SAIDA*/

        [StopWatch]
        /*" R4005-00-PROCESSA-FONTE-SECTION */
        private void R4005_00_PROCESSA_FONTE_SECTION()
        {
            /*" -1975- MOVE '4005' TO WNR-EXEC-SQL. */
            _.Move("4005", WNR_EXEC_SQL);

            /*" -1977- MOVE TMP-PRODUTO-AG TO WS-PRODUTO-AG-ANT */
            _.Move(REG_MTRAB.TMP_PRODUTO_AG, WORK_AREA.WS_PRODUTO_AG_ANT);

            /*" -1984- PERFORM R4010-00-PROCESSA-PRODUTO-AG UNTIL TMP-COD-FONTE NOT EQUAL WS-FONTE-ANT OR TMP-PRODUTO-AG NOT EQUAL WS-PRODUTO-AG-ANT OR WFIM-MTRAB EQUAL 'S' . */

            while (!(REG_MTRAB.TMP_COD_FONTE != WORK_AREA.WS_FONTE_ANT || REG_MTRAB.TMP_PRODUTO_AG != WORK_AREA.WS_PRODUTO_AG_ANT || WFIM_MTRAB == "S"))
            {

                R4010_00_PROCESSA_PRODUTO_AG_SECTION();
            }

            /*" -1985- IF WS-PRODUTO-AG-ANT EQUAL 2 */

            if (WORK_AREA.WS_PRODUTO_AG_ANT == 2)
            {

                /*" -1990- MOVE '     TOTAL VIDA MULHER' TO LD03-NOME-PRODUTO */
                _.Move("     TOTAL VIDA MULHER", LD03.LD03_NOME_PRODUTO);

                /*" -1991- ELSE */
            }
            else
            {


                /*" -1992- IF WS-PRODUTO-AG-ANT EQUAL 3 */

                if (WORK_AREA.WS_PRODUTO_AG_ANT == 3)
                {

                    /*" -1994- MOVE '     TOTAL VIDA SENIOR' TO LD03-NOME-PRODUTO */
                    _.Move("     TOTAL VIDA SENIOR", LD03.LD03_NOME_PRODUTO);

                    /*" -1998- ELSE */
                }
                else
                {


                    /*" -1999- IF WS-PRODUTO-AG-ANT EQUAL 1 */

                    if (WORK_AREA.WS_PRODUTO_AG_ANT == 1)
                    {

                        /*" -2001- MOVE '     TOTAL MULTIPREMIADO' TO LD03-NOME-PRODUTO */
                        _.Move("     TOTAL MULTIPREMIADO", LD03.LD03_NOME_PRODUTO);

                        /*" -2005- ELSE */
                    }
                    else
                    {


                        /*" -2006- IF WS-PRODUTO-AG-ANT EQUAL 4 */

                        if (WORK_AREA.WS_PRODUTO_AG_ANT == 4)
                        {

                            /*" -2008- MOVE '     TOTAL VIDA DA GENTE' TO LD03-NOME-PRODUTO */
                            _.Move("     TOTAL VIDA DA GENTE", LD03.LD03_NOME_PRODUTO);

                            /*" -2012- ELSE */
                        }
                        else
                        {


                            /*" -2015- MOVE '     TOTAL OUTROS       ' TO LD03-NOME-PRODUTO. */
                            _.Move("     TOTAL OUTROS       ", LD03.LD03_NOME_PRODUTO);
                        }

                    }

                }

            }


            /*" -2018- MOVE AC-QUANT-AG TO LD03-QUANTIDADE */
            _.Move(AC_QUANT_AG, LD03.LD03_QUANTIDADE);

            /*" -2021- MOVE AC-PREMIO-AG TO LD03-VLPREMIO */
            _.Move(AC_PREMIO_AG, LD03.LD03_VLPREMIO);

            /*" -2024- WRITE REG-MPRODUTO FROM LD03. */
            _.Move(LD03.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -2026- MOVE ZEROS TO AC-QUANT-AG AC-PREMIO-AG. */
            _.Move(0, AC_QUANT_AG, AC_PREMIO_AG);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4005_99_SAIDA*/

        [StopWatch]
        /*" R4010-00-PROCESSA-PRODUTO-AG-SECTION */
        private void R4010_00_PROCESSA_PRODUTO_AG_SECTION()
        {
            /*" -2040- MOVE '4010' TO WNR-EXEC-SQL. */
            _.Move("4010", WNR_EXEC_SQL);

            /*" -2042- MOVE TMP-NOME-PRODUTO TO WS-PRODUTO-ANT */
            _.Move(REG_MTRAB.TMP_NOME_PRODUTO, WORK_AREA.WS_PRODUTO_ANT);

            /*" -2048- PERFORM R4100-00-PROCESSA-REGISTRO UNTIL TMP-COD-FONTE NOT EQUAL WS-FONTE-ANT OR TMP-PRODUTO-AG NOT EQUAL WS-PRODUTO-AG-ANT OR TMP-NOME-PRODUTO NOT EQUAL WS-PRODUTO-ANT OR WFIM-MTRAB EQUAL 'S' . */

            while (!(REG_MTRAB.TMP_COD_FONTE != WORK_AREA.WS_FONTE_ANT || REG_MTRAB.TMP_PRODUTO_AG != WORK_AREA.WS_PRODUTO_AG_ANT || REG_MTRAB.TMP_NOME_PRODUTO != WORK_AREA.WS_PRODUTO_ANT || WFIM_MTRAB == "S"))
            {

                R4100_00_PROCESSA_REGISTRO_SECTION();
            }

            /*" -2051- MOVE WS-PRODUTO-ANT TO LD03-NOME-PRODUTO. */
            _.Move(WORK_AREA.WS_PRODUTO_ANT, LD03.LD03_NOME_PRODUTO);

            /*" -2054- MOVE AC-QUANT-PR TO LD03-QUANTIDADE. */
            _.Move(AC_QUANT_PR, LD03.LD03_QUANTIDADE);

            /*" -2057- MOVE AC-PREMIO-PR TO LD03-VLPREMIO. */
            _.Move(AC_PREMIO_PR, LD03.LD03_VLPREMIO);

            /*" -2060- WRITE REG-MPRODUTO FROM LD03. */
            _.Move(LD03.GetMoveValues(), REG_MPRODUTO);

            MPRODUTO.Write(REG_MPRODUTO.GetMoveValues().ToString());

            /*" -2062- MOVE ZEROS TO AC-QUANT-PR AC-PREMIO-PR. */
            _.Move(0, AC_QUANT_PR, AC_PREMIO_PR);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4010_99_SAIDA*/

        [StopWatch]
        /*" R4100-00-PROCESSA-REGISTRO-SECTION */
        private void R4100_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -2076- MOVE '4100' TO WNR-EXEC-SQL. */
            _.Move("4100", WNR_EXEC_SQL);

            /*" -2082- ADD TMP-VLPREMIO TO AC-PREMIO-AG AC-PREMIO-PR AC-PREMIO-FI AC-PREMIO-TT */
            AC_PREMIO_AG.Value = AC_PREMIO_AG + REG_MTRAB.TMP_VLPREMIO;
            AC_PREMIO_PR.Value = AC_PREMIO_PR + REG_MTRAB.TMP_VLPREMIO;
            AC_PREMIO_FI.Value = AC_PREMIO_FI + REG_MTRAB.TMP_VLPREMIO;
            AC_PREMIO_TT.Value = AC_PREMIO_TT + REG_MTRAB.TMP_VLPREMIO;

            /*" -2087- ADD 1 TO AC-QUANT-AG AC-QUANT-PR AC-QUANT-FI AC-QUANT-TT AC-PROPOSTA. */
            AC_QUANT_AG.Value = AC_QUANT_AG + 1;
            AC_QUANT_PR.Value = AC_QUANT_PR + 1;
            AC_QUANT_FI.Value = AC_QUANT_FI + 1;
            AC_QUANT_TT.Value = AC_QUANT_TT + 1;
            AC_PROPOSTA.Value = AC_PROPOSTA + 1;

            /*" -0- FLUXCONTROL_PERFORM R4100_10_LER */

            R4100_10_LER();

        }

        [StopWatch]
        /*" R4100-10-LER */
        private void R4100_10_LER(bool isPerform = false)
        {
            /*" -2091- PERFORM R3100-00-LE-MTRAB. */

            R3100_00_LE_MTRAB_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R4100_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -2104- DISPLAY '////////////////////////////////////////////' */
            _.Display($"////////////////////////////////////////////");

            /*" -2105- DISPLAY '/                                          /' */
            _.Display($"/                                          /");

            /*" -2106- DISPLAY '/   VG0656B - GERA RELATORIO MULTPREMIADO  /' */
            _.Display($"/   VG0656B - GERA RELATORIO MULTPREMIADO  /");

            /*" -2107- DISPLAY '/   -------   -------------- ------------  /' */
            _.Display($"/   -------   -------------- ------------  /");

            /*" -2108- DISPLAY '/                                          /' */
            _.Display($"/                                          /");

            /*" -2109- DISPLAY '/             NAO EXISTE PRODUCAO PARA     /' */
            _.Display($"/             NAO EXISTE PRODUCAO PARA     /");

            /*" -2110- DISPLAY '/             O PERIODO PEDIDO.            /' */
            _.Display($"/             O PERIODO PEDIDO.            /");

            /*" -2111- DISPLAY '/                                          /' */
            _.Display($"/                                          /");

            /*" -2111- DISPLAY '////////////////////////////////////////////' . */
            _.Display($"////////////////////////////////////////////");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -2124- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WSQLCODE);

            /*" -2126- DISPLAY WABEND */
            _.Display(FILLER_7.WABEND);

            /*" -2126- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2128- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2132- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -2132- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}