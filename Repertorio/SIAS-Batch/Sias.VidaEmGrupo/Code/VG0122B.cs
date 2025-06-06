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
using Sias.VidaEmGrupo.DB2.VG0122B;

namespace Code
{
    public class VG0122B
    {
        public bool IsCall { get; set; }

        public VG0122B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------                                              */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *       EMISSAO DE RELACAO GERAL DE SEGURADOS POR APOLICE        *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *            *            *              *                       *      */
        /*"      *     01     *  09/10/91  *   PROCAS     *                       *      */
        /*"      *     02     *    /  /    *   PROCAS     *                       *      */
        /*"      *     03     *    /  /    *   PROCAS     *                       *      */
        /*"      ******************************************************************      */
        /*"      * CONVERSAO PARA O ANO 2000.   CONSEDA02. EDUARDO. 29/05/1998.   *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 28/11/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _RVG0122B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVG0122B
        {
            get
            {
                _.Move(REG_IMPRESSAO, _RVG0122B); VarBasis.RedefinePassValue(REG_IMPRESSAO, _RVG0122B, REG_IMPRESSAO); return _RVG0122B;
            }
        }
        /*"01              REG-IMPRESSAO        PIC X(132).*/
        public StringBasis REG_IMPRESSAO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01          RELAT-IDSISTEM           PIC  X(002).*/
        public StringBasis RELAT_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"01          RELAT-CODRELAT           PIC  X(008).*/
        public StringBasis RELAT_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"01          RELAT-NUM-APOLICE        PIC S9(013) COMP-3.*/
        public IntBasis RELAT_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          RELAT-NUM-CERTIFIC       PIC S9(015) COMP-3.*/
        public IntBasis RELAT_NUM_CERTIFIC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          RELAT-COD-SUBES          PIC S9(004) COMP.*/
        public IntBasis RELAT_COD_SUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          RELAT-OPERACAO           PIC S9(004) COMP.*/
        public IntBasis RELAT_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          RELAT-SITUACAO           PIC  X(001).*/
        public StringBasis RELAT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          CLIENTE-COD-CLI          PIC S9(009) COMP.*/
        public IntBasis CLIENTE_COD_CLI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          CLIENTE-NOME-RAZAO       PIC  X(040).*/
        public StringBasis CLIENTE_NOME_RAZAO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01          CLIENTE-CGC-CPF          PIC S9(015) COMP-3.*/
        public IntBasis CLIENTE_CGC_CPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          HISTSEGVG-NUM-APOL       PIC S9(013)  COMP-3.*/
        public IntBasis HISTSEGVG_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          HISTSEGVG-NUM-ITEM       PIC S9(009)  COMP.*/
        public IntBasis HISTSEGVG_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          HISTSEGVG-COD-OPER       PIC S9(004)  COMP.*/
        public IntBasis HISTSEGVG_COD_OPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          HISTSEGVG-DATA-MOV       PIC  X(010).*/
        public StringBasis HISTSEGVG_DATA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          HISTSEGVG-OCORR-HI       PIC S9(004)  COMP.*/
        public IntBasis HISTSEGVG_OCORR_HI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          HISTSEGVG-COD-MOEDA-IMP  PIC S9(004)  COMP.*/
        public IntBasis HISTSEGVG_COD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          HISTSEGVG-COD-MOEDA-PRM  PIC S9(004)  COMP.*/
        public IntBasis HISTSEGVG_COD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SEGURAVG-NUM-APOL           PIC S9(013)    COMP-3.*/
        public IntBasis SEGURAVG_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          SEGURAVG-COD-SUBG           PIC S9(004)    COMP.*/
        public IntBasis SEGURAVG_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SEGURAVG-COD-CLI            PIC S9(009)    COMP.*/
        public IntBasis SEGURAVG_COD_CLI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          SEGURAVG-NUM-CERT           PIC S9(015)    COMP-3.*/
        public IntBasis SEGURAVG_NUM_CERT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          SEGURAVG-DAC-CERT           PIC  X(001).*/
        public StringBasis SEGURAVG_DAC_CERT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          SEGURAVG-TIPO-SEG           PIC  X(001).*/
        public StringBasis SEGURAVG_TIPO_SEG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          SEGURAVG-NUM-ITEM           PIC S9(009)    COMP.*/
        public IntBasis SEGURAVG_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          SEGURAVG-OCORR-HI           PIC S9(004)    COMP.*/
        public IntBasis SEGURAVG_OCORR_HI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SEGURAVG-EST-CIVIL          PIC  X(001).*/
        public StringBasis SEGURAVG_EST_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          SEGURAVG-IDE-SEXO           PIC  X(001).*/
        public StringBasis SEGURAVG_IDE_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          SEGURAVG-MATRICULA          PIC S9(015)    COMP-3.*/
        public IntBasis SEGURAVG_MATRICULA { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          SEGURAVG-DT-INIVI           PIC  X(010).*/
        public StringBasis SEGURAVG_DT_INIVI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          SEGURAVG-SIT-REG            PIC  X(001).*/
        public StringBasis SEGURAVG_SIT_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          SEGURAVG-DT-NASCI           PIC  X(010).*/
        public StringBasis SEGURAVG_DT_NASCI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          SISTEMA-DTMOVABE         PIC  X(010).*/
        public StringBasis SISTEMA_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          SISTEMA-DTCURRENT        PIC  X(010).*/
        public StringBasis SISTEMA_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01          NOME-EMPRESA             PIC  X(040).*/
        public StringBasis NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        /*"01          SUBGRUPO-NUM-APOL        PIC S9(013)  COMP-3.*/
        public IntBasis SUBGRUPO_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          SUBGRUPO-COD-SUBG        PIC S9(004)  COMP.*/
        public IntBasis SUBGRUPO_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SUBGRUPO-COD-CLI         PIC S9(009)  COMP.*/
        public IntBasis SUBGRUPO_COD_CLI { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          COBERAPOL-RAMO             PIC S9(004)  COMP.*/
        public IntBasis COBERAPOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          COBERAPOL-COBERT           PIC S9(004)  COMP.*/
        public IntBasis COBERAPOL_COBERT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          COBERAPOL-SEGUR-IX         PIC S9(013)V99    COMP-3.*/
        public DoubleBasis COBERAPOL_SEGUR_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          COBERAPOL-PREM-IX          PIC S9(010)V99999 COMP-3.*/
        public DoubleBasis COBERAPOL_PREM_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V99999"), 5);
        /*"01          COBERAPOL-FATOR-MULTIPLICA PIC S9(010)V99999 COMP-3.*/
        public DoubleBasis COBERAPOL_FATOR_MULTIPLICA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V99999"), 5);
        /*"01          CONDTEC-NUM-APOL         PIC S9(013)  COMP-3.*/
        public IntBasis CONDTEC_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          CONDTEC-COD-SUBG         PIC S9(004)  COMP.*/
        public IntBasis CONDTEC_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          CONDTEC-GAR-IEA          PIC S9(005)V99  COMP-3.*/
        public DoubleBasis CONDTEC_GAR_IEA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"01          CONDTEC-GAR-IPA          PIC S9(005)V99  COMP-3.*/
        public DoubleBasis CONDTEC_GAR_IPA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"01          CONDTEC-GAR-IPD          PIC S9(005)V99  COMP-3.*/
        public DoubleBasis CONDTEC_GAR_IPD { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"01          CONDTEC-GAR-HD           PIC S9(005)V99  COMP-3.*/
        public DoubleBasis CONDTEC_GAR_HD { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"01          MOEDA-VLCRUZADO      PIC S9(006)V999999999  COMP-3.*/
        public DoubleBasis MOEDA_VLCRUZADO { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V999999999"), 9);
        /*"01          PARAM-RAMO-VG            PIC S9(004)  COMP.*/
        public IntBasis PARAM_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          PARAM-RAMO-AP            PIC S9(004)  COMP.*/
        public IntBasis PARAM_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          CONTACOR-BANCO           PIC S9(004)  COMP.*/
        public IntBasis CONTACOR_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          CONTACOR-AGENCIA         PIC S9(004)  COMP.*/
        public IntBasis CONTACOR_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          CONTACOR-CTA-COR         PIC S9(017)  COMP-3.*/
        public IntBasis CONTACOR_CTA_COR { get; set; } = new IntBasis(new PIC("S9", "17", "S9(017)"));
        /*"01          CONTACOR-DAC             PIC  X(001).*/
        public StringBasis CONTACOR_DAC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          AUX-TIPO-SEGURADO        PIC  X(001).*/
        public StringBasis AUX_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          AUX-APOLICE              PIC S9(013)  COMP-3.*/
        public IntBasis AUX_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          AUX-SUBGRUPO-I           PIC S9(004)  COMP.*/
        public IntBasis AUX_SUBGRUPO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          AUX-SUBGRUPO-F           PIC S9(004)  COMP.*/
        public IntBasis AUX_SUBGRUPO_F { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          AUX-SUBGRUPO             PIC S9(004)  COMP.*/
        public IntBasis AUX_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          AUX-CERTIFICADO          PIC S9(015)  COMP-3.*/
        public IntBasis AUX_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          AUX-VLCRUZAD-IMP      PIC S9(006)V999999999 COMP-3.*/
        public DoubleBasis AUX_VLCRUZAD_IMP { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V999999999"), 9);
        /*"01          AUX-VLCRUZAD-PRM      PIC S9(006)V999999999 COMP-3.*/
        public DoubleBasis AUX_VLCRUZAD_PRM { get; set; } = new DoubleBasis(new PIC("S9", "6", "S9(006)V999999999"), 9);
        /*"01              WORK.*/
        public VG0122B_WORK WORK { get; set; } = new VG0122B_WORK();
        public class VG0122B_WORK : VarBasis
        {
            /*"    05      FILLER                   PIC  X(035) VALUE                'III INICIO DA WORKING-STORAGE III'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"III INICIO DA WORKING-STORAGE III");
            /*"    05      DATA-SQL.*/
            public VG0122B_DATA_SQL DATA_SQL { get; set; } = new VG0122B_DATA_SQL();
            public class VG0122B_DATA_SQL : VarBasis
            {
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05         DATA-MAQ.*/
                public VG0122B_DATA_MAQ DATA_MAQ { get; set; } = new VG0122B_DATA_MAQ();
                public class VG0122B_DATA_MAQ : VarBasis
                {
                    /*"    10       ANO               PIC  9(004).*/
                }
            }
            public IntBasis ANO_0 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    10       FILLER            PIC  X(001).*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       MES               PIC  9(002).*/
            public IntBasis MES_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    10       FILLER            PIC  X(001).*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10       DIA               PIC  9(002).*/
            public IntBasis DIA_0 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05      DATA-NORMAL              PIC  9(008).*/
            public IntBasis DATA_NORMAL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05      DATA-DDMMAA REDEFINES DATA-NORMAL.*/
            private _REDEF_VG0122B_DATA_DDMMAA _data_ddmmaa { get; set; }
            public _REDEF_VG0122B_DATA_DDMMAA DATA_DDMMAA
            {
                get { _data_ddmmaa = new _REDEF_VG0122B_DATA_DDMMAA(); _.Move(DATA_NORMAL, _data_ddmmaa); VarBasis.RedefinePassValue(DATA_NORMAL, _data_ddmmaa, DATA_NORMAL); _data_ddmmaa.ValueChanged += () => { _.Move(_data_ddmmaa, DATA_NORMAL); }; return _data_ddmmaa; }
                set { VarBasis.RedefinePassValue(value, _data_ddmmaa, DATA_NORMAL); }
            }  //Redefines
            public class _REDEF_VG0122B_DATA_DDMMAA : VarBasis
            {
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES_1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO_1 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05      DATA-INVERTIDA           PIC  9(008).*/

                public _REDEF_VG0122B_DATA_DDMMAA()
                {
                    DIA_1.ValueChanged += OnValueChanged;
                    MES_1.ValueChanged += OnValueChanged;
                    ANO_1.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis DATA_INVERTIDA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05      DATA-AAMMDD REDEFINES DATA-INVERTIDA.*/
            private _REDEF_VG0122B_DATA_AAMMDD _data_aammdd { get; set; }
            public _REDEF_VG0122B_DATA_AAMMDD DATA_AAMMDD
            {
                get { _data_aammdd = new _REDEF_VG0122B_DATA_AAMMDD(); _.Move(DATA_INVERTIDA, _data_aammdd); VarBasis.RedefinePassValue(DATA_INVERTIDA, _data_aammdd, DATA_INVERTIDA); _data_aammdd.ValueChanged += () => { _.Move(_data_aammdd, DATA_INVERTIDA); }; return _data_aammdd; }
                set { VarBasis.RedefinePassValue(value, _data_aammdd, DATA_INVERTIDA); }
            }  //Redefines
            public class _REDEF_VG0122B_DATA_AAMMDD : VarBasis
            {
                /*"      10    ANO                      PIC  9(004).*/
                public IntBasis ANO_2 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    MES                      PIC  9(002).*/
                public IntBasis MES_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    DIA                      PIC  9(002).*/
                public IntBasis DIA_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05            CAB-HORA-1          PIC 99999999.*/
                public IntBasis CAB_HORA_1 { get; set; } = new IntBasis(new PIC("9", "8", "99999999."));
                /*"  05            WHORA-PER-X REDEFINES CAB-HORA-1.*/
                private _REDEF_VG0122B_WHORA_PER_X _whora_per_x { get; set; }
                public _REDEF_VG0122B_WHORA_PER_X WHORA_PER_X
                {
                    get { _whora_per_x = new _REDEF_VG0122B_WHORA_PER_X(); _.Move(CAB_HORA_1, _whora_per_x); VarBasis.RedefinePassValue(CAB_HORA_1, _whora_per_x, CAB_HORA_1); _whora_per_x.ValueChanged += () => { _.Move(_whora_per_x, CAB_HORA_1); }; return _whora_per_x; }
                    set { VarBasis.RedefinePassValue(value, _whora_per_x, CAB_HORA_1); }
                }  //Redefines
                public class _REDEF_VG0122B_WHORA_PER_X : VarBasis
                {
                    /*"     10         CAB-HORA-2          PIC 999999.*/
                    public IntBasis CAB_HORA_2 { get; set; } = new IntBasis(new PIC("9", "6", "999999."));
                    /*"     10         FILLER              PIC 99.*/
                    public IntBasis FILLER_5 { get; set; } = new IntBasis(new PIC("9", "2", "99."));
                    /*"    05      FLAG-FIM-RELATORIO       PIC  9(001) VALUE 0.*/

                    public _REDEF_VG0122B_WHORA_PER_X()
                    {
                        CAB_HORA_2.ValueChanged += OnValueChanged;
                        FILLER_5.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VG0122B_DATA_AAMMDD()
                {
                    ANO_2.ValueChanged += OnValueChanged;
                    MES_2.ValueChanged += OnValueChanged;
                    DIA_2.ValueChanged += OnValueChanged;
                    CAB_HORA_1.ValueChanged += OnValueChanged;
                    WHORA_PER_X.ValueChanged += OnValueChanged;
                }

            }
        }

        public SelectorBasis FLAG_FIM_RELATORIO { get; set; } = new SelectorBasis("001", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-RELATORIO            VALUE 1. */
							new SelectorItemBasis("FIM_RELATORIO", "1")
                }
        };

        /*"    05      FLAG-EXISTE-REL          PIC  9(001) VALUE 0.*/

        public SelectorBasis FLAG_EXISTE_REL { get; set; } = new SelectorBasis("001", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88    HOUVE-RELATORIO          VALUE 1. */
							new SelectorItemBasis("HOUVE_RELATORIO", "1")
                }
        };

        /*"    05      FLAG-EXISTE-SEGUR        PIC  9(001) VALUE 0.*/

        public SelectorBasis FLAG_EXISTE_SEGUR { get; set; } = new SelectorBasis("001", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88    HOUVE-SEGURADO           VALUE 1. */
							new SelectorItemBasis("HOUVE_SEGURADO", "1")
                }
        };

        /*"    05      FLAG-CONJUGE             PIC  9(001) VALUE 0.*/

        public SelectorBasis FLAG_CONJUGE { get; set; } = new SelectorBasis("001", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88    POSSUI-CONJUGE           VALUE 1. */
							new SelectorItemBasis("POSSUI_CONJUGE", "1")
                }
        };

        /*"    05      FLAG-FIM-SEGURADO        PIC  9(001) VALUE 0.*/

        public SelectorBasis FLAG_FIM_SEGURADO { get; set; } = new SelectorBasis("001", "0")
        {
            Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-SEGURADO             VALUE 1. */
							new SelectorItemBasis("FIM_SEGURADO", "1")
                }
        };

        /*"    05      DATA-AUX.*/
        public VG0122B_DATA_AUX DATA_AUX { get; set; } = new VG0122B_DATA_AUX();
        public class VG0122B_DATA_AUX : VarBasis
        {
            /*"      10    DIA-AUX                  PIC  X(002).*/
            public StringBasis DIA_AUX { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"      10    FILLER                   PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10    MES-AUX                  PIC  X(002).*/
            public StringBasis MES_AUX { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"      10    FILLER                   PIC  X(001) VALUE '/'.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
            /*"      10    ANO-AUX                  PIC  X(004).*/
            public StringBasis ANO_AUX { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"    05      CONTA-CORRENTE           PIC  9(016).*/
        }
        public IntBasis CONTA_CORRENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
        /*"    05      CTA-CORR                 REDEFINES CONTA-CORRENTE.*/
        private _REDEF_VG0122B_CTA_CORR _cta_corr { get; set; }
        public _REDEF_VG0122B_CTA_CORR CTA_CORR
        {
            get { _cta_corr = new _REDEF_VG0122B_CTA_CORR(); _.Move(CONTA_CORRENTE, _cta_corr); VarBasis.RedefinePassValue(CONTA_CORRENTE, _cta_corr, CONTA_CORRENTE); _cta_corr.ValueChanged += () => { _.Move(_cta_corr, CONTA_CORRENTE); }; return _cta_corr; }
            set { VarBasis.RedefinePassValue(value, _cta_corr, CONTA_CORRENTE); }
        }  //Redefines
        public class _REDEF_VG0122B_CTA_CORR : VarBasis
        {
            /*"      10    CTA-OPERACAO             PIC  9(004).*/
            public IntBasis CTA_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"      10    CTA-NUM-CONTA            PIC  9(012).*/
            public IntBasis CTA_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
            /*"    05      CERTIFICADO-ANT          PIC  9(015).*/

            public _REDEF_VG0122B_CTA_CORR()
            {
                CTA_OPERACAO.ValueChanged += OnValueChanged;
                CTA_NUM_CONTA.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis CERTIFICADO_ANT { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
        /*"    05      AUX-CPF                  PIC  9(011).*/
        public IntBasis AUX_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
        /*"    05      FILLER                   REDEFINES  AUX-CPF.*/
        private _REDEF_VG0122B_FILLER_8 _filler_8 { get; set; }
        public _REDEF_VG0122B_FILLER_8 FILLER_8
        {
            get { _filler_8 = new _REDEF_VG0122B_FILLER_8(); _.Move(AUX_CPF, _filler_8); VarBasis.RedefinePassValue(AUX_CPF, _filler_8, AUX_CPF); _filler_8.ValueChanged += () => { _.Move(_filler_8, AUX_CPF); }; return _filler_8; }
            set { VarBasis.RedefinePassValue(value, _filler_8, AUX_CPF); }
        }  //Redefines
        public class _REDEF_VG0122B_FILLER_8 : VarBasis
        {
            /*"      10    AUX-CPF-1                PIC  9(009).*/
            public IntBasis AUX_CPF_1 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"      10    AUX-CPF-2                PIC  9(002).*/
            public IntBasis AUX_CPF_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05      AUX-VALORES.*/

            public _REDEF_VG0122B_FILLER_8()
            {
                AUX_CPF_1.ValueChanged += OnValueChanged;
                AUX_CPF_2.ValueChanged += OnValueChanged;
            }

        }
        public VG0122B_AUX_VALORES AUX_VALORES { get; set; } = new VG0122B_AUX_VALORES();
        public class VG0122B_AUX_VALORES : VarBasis
        {
            /*"      10    AUX-MORTE-NATURAL        PIC  9(013)V99.*/
            public DoubleBasis AUX_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"      10    AUX-MORTE-ACIDENTAL      PIC  9(013)V99.*/
            public DoubleBasis AUX_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"      10    AUX-PREM-MA              PIC  9(013)V99.*/
            public DoubleBasis AUX_PREM_MA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"      10    AUX-INV-PERMANENTE       PIC  9(013)V99.*/
            public DoubleBasis AUX_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"      10    AUX-PREM-IP              PIC  9(013)V99.*/
            public DoubleBasis AUX_PREM_IP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"      10    AUX-AMDS                 PIC  9(013)V99.*/
            public DoubleBasis AUX_AMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"      10    AUX-PREM-AMDS            PIC  9(013)V99.*/
            public DoubleBasis AUX_PREM_AMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"      10    AUX-DIARIA-HOSP          PIC  9(013)V99.*/
            public DoubleBasis AUX_DIARIA_HOSP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"      10    AUX-PREM-DH              PIC  9(013)V99.*/
            public DoubleBasis AUX_PREM_DH { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"      10    AUX-DIARIA-INT           PIC  9(013)V99.*/
            public DoubleBasis AUX_DIARIA_INT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"      10    AUX-PREM-DI              PIC  9(013)V99.*/
            public DoubleBasis AUX_PREM_DI { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05      AUX-TIPO-CLIENTE         PIC  X(030).*/
        }
        public StringBasis AUX_TIPO_CLIENTE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"    05      AUX-TIPO-IMPORT          PIC  X(030).*/
        public StringBasis AUX_TIPO_IMPORT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
        /*"    05      AUX-OUTROS               PIC  X(001) VALUE SPACES.*/
        public StringBasis AUX_OUTROS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"    05      I                        PIC  9(002) VALUE ZEROS.*/
        public IntBasis I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
        /*"    05      TABELA-DES-OPERACAO.*/
        public VG0122B_TABELA_DES_OPERACAO TABELA_DES_OPERACAO { get; set; } = new VG0122B_TABELA_DES_OPERACAO();
        public class VG0122B_TABELA_DES_OPERACAO : VarBasis
        {
            /*"      10    DESC-TAB-OPERACAO.*/
            public VG0122B_DESC_TAB_OPERACAO DESC_TAB_OPERACAO { get; set; } = new VG0122B_DESC_TAB_OPERACAO();
            public class VG0122B_DESC_TAB_OPERACAO : VarBasis
            {
                /*"        15  FILLER  PIC X(025) VALUE '0101 INCLUSAO DE SEGURADO'*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0101 INCLUSAO DE SEGURADO");
                /*"        15  FILLER  PIC X(025) VALUE '0102 INCL. SEG. AUTOMATIC'*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0102 INCL. SEG. AUTOMATIC");
                /*"        15  FILLER  PIC X(025) VALUE '0111 INCL. SEG. FOLLOW UP'*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0111 INCL. SEG. FOLLOW UP");
                /*"        15  FILLER  PIC X(025) VALUE '0112 INCL. SEG. FOL. AUT.'*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0112 INCL. SEG. FOL. AUT.");
                /*"        15  FILLER  PIC X(025) VALUE '0201 TRANSF. DEBITO      '*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0201 TRANSF. DEBITO      ");
                /*"        15  FILLER  PIC X(025) VALUE '0301 TRANSF. CREDITO     '*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0301 TRANSF. CREDITO     ");
                /*"        15  FILLER  PIC X(025) VALUE '0401 CANC. SOLICITADO    '*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0401 CANC. SOLICITADO    ");
                /*"        15  FILLER  PIC X(025) VALUE '0402 CANC. SINISTRO      '*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0402 CANC. SINISTRO      ");
                /*"        15  FILLER  PIC X(025) VALUE '0403 CANC. FALTA PAGTO   '*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0403 CANC. FALTA PAGTO   ");
                /*"        15  FILLER  PIC X(025) VALUE '0501 REAB. DE CANC. SOLI.'*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0501 REAB. DE CANC. SOLI.");
                /*"        15  FILLER  PIC X(025) VALUE '0502 REAB. DE CANC. SINI.'*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0502 REAB. DE CANC. SINI.");
                /*"        15  FILLER  PIC X(025) VALUE '0503 REAB. DE CANC. S/PG '*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0503 REAB. DE CANC. S/PG ");
                /*"        15  FILLER  PIC X(025) VALUE '0701 REDUCAO DE CAPITAL  '*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0701 REDUCAO DE CAPITAL  ");
                /*"        15  FILLER  PIC X(025) VALUE '0801 AUMENTO DE CAPITAL  '*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0801 AUMENTO DE CAPITAL  ");
                /*"        15  FILLER  PIC X(025) VALUE '0802 AUMENTO DE CAP. COL.'*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0802 AUMENTO DE CAP. COL.");
                /*"        15  FILLER  PIC X(025) VALUE '0000                     '*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"0000                     ");
                /*"    05      TAB-AUX             REDEFINES TABELA-DES-OPERACAO.*/
            }
        }
        private _REDEF_VG0122B_TAB_AUX _tab_aux { get; set; }
        public _REDEF_VG0122B_TAB_AUX TAB_AUX
        {
            get { _tab_aux = new _REDEF_VG0122B_TAB_AUX(); _.Move(TABELA_DES_OPERACAO, _tab_aux); VarBasis.RedefinePassValue(TABELA_DES_OPERACAO, _tab_aux, TABELA_DES_OPERACAO); _tab_aux.ValueChanged += () => { _.Move(_tab_aux, TABELA_DES_OPERACAO); }; return _tab_aux; }
            set { VarBasis.RedefinePassValue(value, _tab_aux, TABELA_DES_OPERACAO); }
        }  //Redefines
        public class _REDEF_VG0122B_TAB_AUX : VarBasis
        {
            /*"      10    TAB-OPERACAO             OCCURS 16.*/
            public ListBasis<VG0122B_TAB_OPERACAO> TAB_OPERACAO { get; set; } = new ListBasis<VG0122B_TAB_OPERACAO>(16);
            public class VG0122B_TAB_OPERACAO : VarBasis
            {
                /*"        15  TAB-COD-OPER             PIC  9(004).*/
                public IntBasis TAB_COD_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"        15  FILLER                   PIC  X(001).*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        15  TAB-DES-OPER             PIC  X(020).*/
                public StringBasis TAB_DES_OPER { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"    05      AC-SOLICITADO            PIC  9(009) COMP-3 VALUE 0.*/

                public VG0122B_TAB_OPERACAO()
                {
                    TAB_COD_OPER.ValueChanged += OnValueChanged;
                    FILLER_25.ValueChanged += OnValueChanged;
                    TAB_DES_OPER.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG0122B_TAB_AUX()
            {
                TAB_OPERACAO.ValueChanged += OnValueChanged;
            }

        }
        public IntBasis AC_SOLICITADO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    05      AC-EMITIDOS              PIC  9(009) COMP-3 VALUE 0.*/
        public IntBasis AC_EMITIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
        /*"    05      AC-LINHAS                PIC  9(002) VALUE 99.*/
        public IntBasis AC_LINHAS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 99);
        /*"    05      AC-PAGINAS               PIC  9(004) VALUE ZEROS.*/
        public IntBasis AC_PAGINAS { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
        /*"    05      AC-CAPITAIS.*/
        public VG0122B_AC_CAPITAIS AC_CAPITAIS { get; set; } = new VG0122B_AC_CAPITAIS();
        public class VG0122B_AC_CAPITAIS : VarBasis
        {
            /*"      10    AC-VIDAS                 PIC  S9(010)     VALUE +0.*/
            public IntBasis AC_VIDAS { get; set; } = new IntBasis(new PIC("S9", "10", "S9(010)"));
            /*"      10    AC-MORTE-NATURAL         PIC  S9(013)V99  VALUE +0.*/
            public DoubleBasis AC_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"      10    AC-MORTE-ACIDENTAL       PIC  S9(013)V99  VALUE +0.*/
            public DoubleBasis AC_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"      10    AC-INV-PERMANENTE        PIC  S9(013)V99  VALUE +0.*/
            public DoubleBasis AC_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"      10    AC-ASS-MEDICA            PIC  S9(013)V99  VALUE +0.*/
            public DoubleBasis AC_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"      10    AC-DIARIA-HOSPITALAR     PIC  S9(013)V99  VALUE +0.*/
            public DoubleBasis AC_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"      10    AC-DIARIA-INTERNACAO     PIC  S9(013)V99  VALUE +0.*/
            public DoubleBasis AC_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"      10    AC-PREM-MORTE-NATURAL    PIC  S9(013)V99  VALUE +0.*/
            public DoubleBasis AC_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"      10    AC-PREM-ACID-PESSOAIS    PIC  S9(013)V99  VALUE +0.*/
            public DoubleBasis AC_PREM_ACID_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    05      WABEND.*/
        }
        public VG0122B_WABEND WABEND { get; set; } = new VG0122B_WABEND();
        public class VG0122B_WABEND : VarBasis
        {
            /*"      10    FILLER                   PIC  X(010) VALUE            'VG0122B  '.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VG0122B  ");
            /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO EXEC SQL  ****'.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO EXEC SQL  ****");
            /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
            /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
            /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
            /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
            /*"    05      LOCALIZA-ABEND-1.*/
        }
        public VG0122B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VG0122B_LOCALIZA_ABEND_1();
        public class VG0122B_LOCALIZA_ABEND_1 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
            /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
            public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    05      LOCALIZA-ABEND-2.*/
        }
        public VG0122B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VG0122B_LOCALIZA_ABEND_2();
        public class VG0122B_LOCALIZA_ABEND_2 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
            /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
            public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
            /*"    05      TRACO.*/
        }
        public VG0122B_TRACO TRACO { get; set; } = new VG0122B_TRACO();
        public class VG0122B_TRACO : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(130) VALUE ALL '-'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"ALL");
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05      BRANCO.*/
        }
        public VG0122B_BRANCO BRANCO { get; set; } = new VG0122B_BRANCO();
        public class VG0122B_BRANCO : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(130) VALUE ALL ' '.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "130", "X(130)"), @"ALL");
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05      CAB-1.*/
        }
        public VG0122B_CAB_1 CAB_1 { get; set; } = new VG0122B_CAB_1();
        public class VG0122B_CAB_1 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(007) VALUE 'VG0122B'*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"VG0122B");
            /*"      10    FILLER                   PIC  X(035) VALUE SPACES.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
            /*"      10    CAB1-EMPRESA             PIC  X(040) VALUE SPACES.*/
            public StringBasis CAB1_EMPRESA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"      10    FILLER                   PIC  X(033) VALUE SPACES.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "33", "X(033)"), @"");
            /*"      10    FILLER                   PIC  X(011) VALUE            'PAGINA'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"PAGINA");
            /*"      10    CAB1-PAGINA              PIC  ZZZ9.*/
            public IntBasis CAB1_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05      CAB-2.*/
        }
        public VG0122B_CAB_2 CAB_2 { get; set; } = new VG0122B_CAB_2();
        public class VG0122B_CAB_2 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(115) VALUE SPACES.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "115", "X(115)"), @"");
            /*"      10    FILLER                   PIC  X(005) VALUE 'DATA '.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"DATA ");
            /*"      10    CAB2-DATA                PIC  99/99/9999.*/
            public IntBasis CAB2_DATA { get; set; } = new IntBasis(new PIC("9", "8", "99/99/9999."));
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05      CAB-3.*/
        }
        public VG0122B_CAB_3 CAB_3 { get; set; } = new VG0122B_CAB_3();
        public class VG0122B_CAB_3 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(030) VALUE SPACES.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
            /*"      10    FILLER                   PIC  X(048) VALUE            'SISTEMA DE VIDA EM GRUPO E/OU ACIDENTES PESSOAIS'.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"SISTEMA DE VIDA EM GRUPO E/OU ACIDENTES PESSOAIS");
            /*"      10    FILLER                   PIC  X(009) VALUE            ' COLETIVO'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" COLETIVO");
            /*"      10    FILLER                   PIC  X(028) VALUE SPACES.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"");
            /*"      10    FILLER                   PIC  X(007) VALUE 'HORA '.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"HORA ");
            /*"      10    CAB3-HORA                PIC  99.99.99.*/
            public IntBasis CAB3_HORA { get; set; } = new IntBasis(new PIC("9", "6", "99.99.99."));
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05      CAB-4.*/
        }
        public VG0122B_CAB_4 CAB_4 { get; set; } = new VG0122B_CAB_4();
        public class VG0122B_CAB_4 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    CAB4-TITULO              PIC  X(035) VALUE ' '.*/
            public StringBasis CAB4_TITULO { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" ");
            /*"      10    FILLER                   PIC  X(015) VALUE SPACES.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
            /*"      10    FILLER                   PIC  X(026) VALUE            'RELACAO GERAL DE SEGURADOS'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @"RELACAO GERAL DE SEGURADOS");
            /*"      10    FILLER                   PIC  X(055) VALUE ' '.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @" ");
            /*"    05      CAB-5.*/
        }
        public VG0122B_CAB_5 CAB_5 { get; set; } = new VG0122B_CAB_5();
        public class VG0122B_CAB_5 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(010) VALUE            'APOLICE = '.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"APOLICE = ");
            /*"      10    CAB5-APOLICE             PIC  ZZZZZZZZZZZZZ.*/
            public StringBasis CAB5_APOLICE { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZZZZ."), @"");
            /*"      10    FILLER                   PIC  X(005) VALUE '  -  '.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"  -  ");
            /*"      10    CAB5-ESTIP               PIC  X(038) VALUE ' '.*/
            public StringBasis CAB5_ESTIP { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @" ");
            /*"      10    FILLER                   PIC  X(003) VALUE ' '.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
            /*"      10    CAB5-RESTO.*/
            public VG0122B_CAB5_RESTO CAB5_RESTO { get; set; } = new VG0122B_CAB5_RESTO();
            public class VG0122B_CAB5_RESTO : VarBasis
            {
                /*"        15    FILLER                 PIC  X(018) VALUE            'SUB-ESTIPULANTE = '.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"SUB-ESTIPULANTE = ");
                /*"        15    CAB5-SUBG              PIC  ZZZZ.*/
                public StringBasis CAB5_SUBG { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZ."), @"");
                /*"        15    FILLER                 PIC  X(003) VALUE ' - '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" - ");
                /*"        15    CAB5-SUB-ESTIP         PIC  X(038) VALUE ' '.*/
                public StringBasis CAB5_SUB_ESTIP { get; set; } = new StringBasis(new PIC("X", "38", "X(038)"), @" ");
                /*"    05      CAB-6.*/
            }
        }
        public VG0122B_CAB_6 CAB_6 { get; set; } = new VG0122B_CAB_6();
        public class VG0122B_CAB_6 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(030) VALUE           'NOME DO SEGURADO              '.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"NOME DO SEGURADO              ");
            /*"      10    FILLER                   PIC  X(032) VALUE           '  SUBG        MORTE NAT      MOR'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"  SUBG        MORTE NAT      MOR");
            /*"      10    FILLER                   PIC  X(045) VALUE           'TE ACID      INV. PERM.        A.M.D.S       '.*/
            public StringBasis FILLER_70 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)"), @"TE ACID      INV. PERM.        A.M.D.S       ");
            /*"      10    FILLER                   PIC  X(023) VALUE           '     D.H          D.I.T'.*/
            public StringBasis FILLER_71 { get; set; } = new StringBasis(new PIC("X", "23", "X(023)"), @"     D.H          D.I.T");
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_72 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05      CAB-7.*/
        }
        public VG0122B_CAB_7 CAB_7 { get; set; } = new VG0122B_CAB_7();
        public class VG0122B_CAB_7 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_73 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(041) VALUE           '                                         '.*/
            public StringBasis FILLER_74 { get; set; } = new StringBasis(new PIC("X", "41", "X(041)"), @"                                         ");
            /*"      10    FILLER                   PIC  X(048) VALUE           'CPF        MATRICULA  SEXO  EST.CIVIL  DATA NASC'.*/
            public StringBasis FILLER_75 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"CPF        MATRICULA  SEXO  EST.CIVIL  DATA NASC");
            /*"      10    FILLER                   PIC  X(042) VALUE           '  DATA INIC      PREMIO VG      PREMIO AP '.*/
            public StringBasis FILLER_76 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"  DATA INIC      PREMIO VG      PREMIO AP ");
            /*"    05      CAB-8.*/
        }
        public VG0122B_CAB_8 CAB_8 { get; set; } = new VG0122B_CAB_8();
        public class VG0122B_CAB_8 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_77 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(030) VALUE ' '.*/
            public StringBasis FILLER_78 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
            /*"      10    FILLER                   PIC  X(052) VALUE       '     CERTIFICADO   DT.ULT.MOV   ULT. MOVIMENTACAO   '.*/
            public StringBasis FILLER_79 { get; set; } = new StringBasis(new PIC("X", "52", "X(052)"), @"     CERTIFICADO   DT.ULT.MOV   ULT. MOVIMENTACAO   ");
            /*"      10    FILLER                   PIC  X(050) VALUE       '          AGENCIA   OPERACAO   CTA. CORRENTE  DV'.*/
            public StringBasis FILLER_80 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"          AGENCIA   OPERACAO   CTA. CORRENTE  DV");
            /*"    05      DET-1.*/
        }
        public VG0122B_DET_1 DET_1 { get; set; } = new VG0122B_DET_1();
        public class VG0122B_DET_1 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_81 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    DET1-NOME                PIC  X(030) VALUE ' '.*/
            public StringBasis DET1_NOME { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
            /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
            public StringBasis FILLER_82 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
            /*"      10    DET1-SUBG                PIC  9999.*/
            public IntBasis DET1_SUBG { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
            /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
            public StringBasis FILLER_83 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
            /*"      10    DET1-CAP-VG              PIC  ZZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis DET1_CAP_VG { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_84 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    DET1-CAP-MA              PIC  ZZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis DET1_CAP_MA { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_85 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    DET1-CAP-IP              PIC  ZZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis DET1_CAP_IP { get; set; } = new DoubleBasis(new PIC("9", "10", "ZZZZ.ZZZ.ZZ9V99."), 2);
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_86 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    DET1-CAP-AMDS            PIC  ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis DET1_CAP_AMDS { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_87 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    DET1-CAP-DH              PIC  ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis DET1_CAP_DH { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_88 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    DET1-CAP-DIT             PIC  ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis DET1_CAP_DIT { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99."), 2);
            /*"    05      DET-2.*/
        }
        public VG0122B_DET_2 DET_2 { get; set; } = new VG0122B_DET_2();
        public class VG0122B_DET_2 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_89 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(030) VALUE ' '.*/
            public StringBasis FILLER_90 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
            /*"      10    DET2-CPF                 PIC  999.999.999.*/
            public IntBasis DET2_CPF { get; set; } = new IntBasis(new PIC("9", "9", "999.999.999."));
            /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
            public StringBasis FILLER_91 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
            /*"      10    DET2-CPF-CONT            PIC  99.*/
            public IntBasis DET2_CPF_CONT { get; set; } = new IntBasis(new PIC("9", "2", "99."));
            /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
            public StringBasis FILLER_92 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
            /*"      10    DET2-MATR                PIC  ZZZZZZZZZZZZ999.*/
            public IntBasis DET2_MATR { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZ999."));
            /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
            public StringBasis FILLER_93 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
            /*"      10    DET2-SEXO                PIC  X(004) VALUE ' '.*/
            public StringBasis DET2_SEXO { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" ");
            /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
            public StringBasis FILLER_94 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
            /*"      10    DET2-EST-CVL             PIC  X(010) VALUE ' '.*/
            public StringBasis DET2_EST_CVL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" ");
            /*"      10    FI1LER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FI1LER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    DET2-NASC                PIC  99/99/9999.*/
            public IntBasis DET2_NASC { get; set; } = new IntBasis(new PIC("9", "8", "99/99/9999."));
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_95 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    DET2-INIVIG              PIC  99/99/9999.*/
            public IntBasis DET2_INIVIG { get; set; } = new IntBasis(new PIC("9", "8", "99/99/9999."));
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_96 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    DET2-PREM-VG             PIC  ZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis DET2_PREM_VG { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
            /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
            public StringBasis FILLER_97 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
            /*"      10    DET2-PREM-AP             PIC  ZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis DET2_PREM_AP { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
            /*"    05      DET-3.*/
        }
        public VG0122B_DET_3 DET_3 { get; set; } = new VG0122B_DET_3();
        public class VG0122B_DET_3 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_98 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(031) VALUE ' '.*/
            public StringBasis FILLER_99 { get; set; } = new StringBasis(new PIC("X", "31", "X(031)"), @" ");
            /*"      10    DET3-CERT                PIC  ZZZZZZZZZZZZ999.*/
            public IntBasis DET3_CERT { get; set; } = new IntBasis(new PIC("9", "15", "ZZZZZZZZZZZZ999."));
            /*"      10    FILLER                   PIC  X(003) VALUE ' '.*/
            public StringBasis FILLER_100 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
            /*"      10    DET3-ULTI-ALT            PIC  99/99/9999.*/
            public IntBasis DET3_ULTI_ALT { get; set; } = new IntBasis(new PIC("9", "8", "99/99/9999."));
            /*"      10    FILLER                   PIC  X(003) VALUE ' '.*/
            public StringBasis FILLER_101 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @" ");
            /*"      10    DET3-DESC-ULT-ALT        PIC  X(025) VALUE ' '.*/
            public StringBasis DET3_DESC_ULT_ALT { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @" ");
            /*"      10    FILLER                   PIC  X(008) VALUE ' '.*/
            public StringBasis FILLER_102 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @" ");
            /*"      10    DET3-CONTA-CORRENTE.*/
            public VG0122B_DET3_CONTA_CORRENTE DET3_CONTA_CORRENTE { get; set; } = new VG0122B_DET3_CONTA_CORRENTE();
            public class VG0122B_DET3_CONTA_CORRENTE : VarBasis
            {
                /*"        15  DET3-AGENCIA             PIC  ZZZ9.*/
                public IntBasis DET3_AGENCIA { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9."));
                /*"        15  FILLER                   PIC  X(006) VALUE ' '.*/
                public StringBasis FILLER_103 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @" ");
                /*"        15  DET3-OPERACAO            PIC  9999.*/
                public IntBasis DET3_OPERACAO { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"        15  FILLER                   PIC  X(004) VALUE ' '.*/
                public StringBasis FILLER_104 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" ");
                /*"        15  DET3-CTA-CORR            PIC  ZZZ.ZZZ.ZZZ.ZZ9.*/
                public IntBasis DET3_CTA_CORR { get; set; } = new IntBasis(new PIC("9", "12", "ZZZ.ZZZ.ZZZ.ZZ9."));
                /*"        15  DET3-TRACO               PIC  X(001).*/
                public StringBasis DET3_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"        15  DET3-DAC-CONTA           PIC  X(001).*/
                public StringBasis DET3_DAC_CONTA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            }
            public StringBasis FILLER_105 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"    05      TOT-CAB-1.*/
        }
        public VG0122B_TOT_CAB_1 TOT_CAB_1 { get; set; } = new VG0122B_TOT_CAB_1();
        public class VG0122B_TOT_CAB_1 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_106 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(030) VALUE ' '.*/
            public StringBasis FILLER_107 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
            /*"      10    FILLER                   PIC  X(050) VALUE           '                       MORTE NATU.            INV.'.*/
            public StringBasis FILLER_108 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"                       MORTE NATU.            INV.");
            /*"      10    FILLER                   PIC  X(050) VALUE           ' PERM.                    DH            PREMIO  VG'.*/
            public StringBasis FILLER_109 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @" PERM.                    DH            PREMIO  VG");
            /*"    05      TOT-CAB-2.*/
        }
        public VG0122B_TOT_CAB_2 TOT_CAB_2 { get; set; } = new VG0122B_TOT_CAB_2();
        public class VG0122B_TOT_CAB_2 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_110 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(030) VALUE ' '.*/
            public StringBasis FILLER_111 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
            /*"      10    FILLER                   PIC  X(050) VALUE           'NUM. VIDAS             MORTE ACID.                '.*/
            public StringBasis FILLER_112 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"NUM. VIDAS             MORTE ACID.                ");
            /*"      10    FILLER                   PIC  X(050) VALUE           '  AMDS                   DIT            PREMIO APC'.*/
            public StringBasis FILLER_113 { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"  AMDS                   DIT            PREMIO APC");
            /*"    05      TOT-CAB-3.*/
        }
        public VG0122B_TOT_CAB_3 TOT_CAB_3 { get; set; } = new VG0122B_TOT_CAB_3();
        public class VG0122B_TOT_CAB_3 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_114 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(030) VALUE ' '.*/
            public StringBasis FILLER_115 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @" ");
            /*"      10    FILLER                   PIC  X(100) VALUE ALL '-'.*/
            public StringBasis FILLER_116 { get; set; } = new StringBasis(new PIC("X", "100", "X(100)"), @"ALL");
            /*"    05      TOT-DET-1.*/
        }
        public VG0122B_TOT_DET_1 TOT_DET_1 { get; set; } = new VG0122B_TOT_DET_1();
        public class VG0122B_TOT_DET_1 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_117 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(042) VALUE ' '.*/
            public StringBasis FILLER_118 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @" ");
            /*"      10    TOT1-CAP-VG              PIC  ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99*/
            public DoubleBasis TOT1_CAP_VG { get; set; } = new DoubleBasis(new PIC("9", "15", "ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99"), 2);
            /*"      10    TOT1-CAP-IP              PIC  ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99*/
            public DoubleBasis TOT1_CAP_IP { get; set; } = new DoubleBasis(new PIC("9", "15", "ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99"), 2);
            /*"      10    TOT1-CAP-DH              PIC  ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99*/
            public DoubleBasis TOT1_CAP_DH { get; set; } = new DoubleBasis(new PIC("9", "15", "ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99"), 2);
            /*"      10    TOT1-PREM-VG             PIC  ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99*/
            public DoubleBasis TOT1_PREM_VG { get; set; } = new DoubleBasis(new PIC("9", "15", "ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99"), 2);
            /*"    05      TOT-DET-2.*/
        }
        public VG0122B_TOT_DET_2 TOT_DET_2 { get; set; } = new VG0122B_TOT_DET_2();
        public class VG0122B_TOT_DET_2 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_119 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(030) VALUE            '       TOTAIS DA APOLICE....  '.*/
            public StringBasis FILLER_120 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"       TOTAIS DA APOLICE....  ");
            /*"      10    TOT1-VIDAS               PIC  ZZZZZZZZZZ.*/
            public StringBasis TOT1_VIDAS { get; set; } = new StringBasis(new PIC("X", "0", "ZZZZZZZZZZ."), @"");
            /*"      10    FILLER                   PIC  X(002) VALUE ' '.*/
            public StringBasis FILLER_121 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @" ");
            /*"      10    TOT1-CAP-MA              PIC  ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99*/
            public DoubleBasis TOT1_CAP_MA { get; set; } = new DoubleBasis(new PIC("9", "15", "ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99"), 2);
            /*"      10    TOT1-CAP-AMDS            PIC  ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99*/
            public DoubleBasis TOT1_CAP_AMDS { get; set; } = new DoubleBasis(new PIC("9", "15", "ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99"), 2);
            /*"      10    TOT1-CAP-DIT             PIC  ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99*/
            public DoubleBasis TOT1_CAP_DIT { get; set; } = new DoubleBasis(new PIC("9", "15", "ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99"), 2);
            /*"      10    TOT1-PREM-APC            PIC  ZZZ.ZZZ.ZZZ.ZZZ.ZZ9,99*/
            public DoubleBasis TOT1_PREM_APC { get; set; } = new DoubleBasis(new PIC("9", "15", "ZZZ.ZZZ.ZZZ.ZZZ.ZZ9V99"), 2);
            /*"    05      MEN-1.*/
        }
        public VG0122B_MEN_1 MEN_1 { get; set; } = new VG0122B_MEN_1();
        public class VG0122B_MEN_1 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_122 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(051) VALUE         'NAO HOUVE SOLICITACAO PARA ESTE RELATORIO          '.*/
            public StringBasis FILLER_123 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"NAO HOUVE SOLICITACAO PARA ESTE RELATORIO          ");
            /*"      10    FILLER                   PIC  X(080) VALUE ' '.*/
            public StringBasis FILLER_124 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @" ");
            /*"    05      MEN-2.*/
        }
        public VG0122B_MEN_2 MEN_2 { get; set; } = new VG0122B_MEN_2();
        public class VG0122B_MEN_2 : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_125 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(051) VALUE         'NAO HOUVE SELECAO DE SEGURADOS CONFORME SOLICITACAO'.*/
            public StringBasis FILLER_126 { get; set; } = new StringBasis(new PIC("X", "51", "X(051)"), @"NAO HOUVE SELECAO DE SEGURADOS CONFORME SOLICITACAO");
            /*"      10    FILLER                   PIC  X(080) VALUE ' '.*/
            public StringBasis FILLER_127 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @" ");
            /*"    05      MENSAGEM.*/
        }
        public VG0122B_MENSAGEM MENSAGEM { get; set; } = new VG0122B_MENSAGEM();
        public class VG0122B_MENSAGEM : VarBasis
        {
            /*"      10    FILLER                   PIC  X(001) VALUE ' '.*/
            public StringBasis FILLER_128 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
            /*"      10    FILLER                   PIC  X(131) VALUE ' '.*/
            public StringBasis FILLER_129 { get; set; } = new StringBasis(new PIC("X", "131", "X(131)"), @" ");
            /*"    05        LK-LINK.*/
        }
        public VG0122B_LK_LINK LK_LINK { get; set; } = new VG0122B_LK_LINK();
        public class VG0122B_LK_LINK : VarBasis
        {
            /*"      10      LK-RETURN-CODE           PIC S9(004) COMP VALUE +0*/
            public IntBasis LK_RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"      10      LK-TAMANHO              PIC S9(004) COMP VALUE +40*/
            public IntBasis LK_TAMANHO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"), +40);
            /*"      10      LK-TITULO                PIC  X(132) VALUE SPACES.*/
            public StringBasis LK_TITULO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
            /*"    05        PARAMETROS.*/
        }
        public VG0122B_PARAMETROS PARAMETROS { get; set; } = new VG0122B_PARAMETROS();
        public class VG0122B_PARAMETROS : VarBasis
        {
            /*"      10      LK-APOLICE               PIC S9(013) COMP-3.*/
            public IntBasis LK_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"      10      LK-SUBGRUPO              PIC S9(004) COMP.*/
            public IntBasis LK_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"      10      LK-IDADE                 PIC S9(004) COMP.*/
            public IntBasis LK_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"      10      LK-NASCIMENTO.*/
            public VG0122B_LK_NASCIMENTO LK_NASCIMENTO { get; set; } = new VG0122B_LK_NASCIMENTO();
            public class VG0122B_LK_NASCIMENTO : VarBasis
            {
                /*"        15 LK-DATA-NASCIMENTO          PIC  9(008).*/
                public IntBasis LK_DATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      10      LK-SALARIO               PIC S9(013)V99 COMP-3.*/
            }
            public DoubleBasis LK_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"    10      LK-COBT-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
        }
        public DoubleBasis LK_COBT_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-COBT-MORTE-ACIDENTAL  PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_COBT_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-COBT-INV-PERMANENTE   PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_COBT_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-COBT-INV-POR-DOENCA   PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_COBT_INV_POR_DOENCA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-COBT-ASS-MEDICA       PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_COBT_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-COBT-DIARIA-HOSPITALAR PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_COBT_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-COBT-DIARIA-INTERNACAO PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_COBT_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-PURO-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_PURO_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-PURO-MORTE-ACIDENTAL  PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_PURO_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-PURO-INV-PERMANENTE   PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_PURO_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-PURO-ASS-MEDICA       PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_PURO_ASS_MEDICA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-PURO-DIARIA-HOSPITALAR PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_PURO_DIARIA_HOSPITALAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-PURO-DIARIA-INTERNACAO PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_PURO_DIARIA_INTERNACAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-PREM-MORTE-NATURAL    PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_PREM_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-PREM-ACIDENTES-PESSOAIS PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_PREM_ACIDENTES_PESSOAIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-PREM-TOTAL            PIC S9(013)V99 COMP-3.*/
        public DoubleBasis LK_PREM_TOTAL { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"    10      LK-RETURN-CODE           PIC S9(03) COMP-3.*/
        public IntBasis LK_RETURN_CODE_0 { get; set; } = new IntBasis(new PIC("S9", "3", "S9(03)"));
        /*"    10      LK-MENSAGEM              PIC  X(77).*/
        public StringBasis LK_MENSAGEM { get; set; } = new StringBasis(new PIC("X", "77", "X(77)."), @"");
        /*"  05            FILLER               PIC X(034)  VALUE                'FFF FINAL DA WORKING-STORAGE FFF'.*/
        public StringBasis FILLER_130 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)"), @"FFF FINAL DA WORKING-STORAGE FFF");


        public VG0122B_RELATORIO RELATORIO { get; set; } = new VG0122B_RELATORIO();
        public VG0122B_SEGURADO1 SEGURADO1 { get; set; } = new VG0122B_SEGURADO1();
        public VG0122B_SEGURADO2 SEGURADO2 { get; set; } = new VG0122B_SEGURADO2();
        public VG0122B_SEGURADO3 SEGURADO3 { get; set; } = new VG0122B_SEGURADO3();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVG0122B_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVG0122B.SetFile(RVG0122B_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-000-PRINCIPAL */

                M_0000_000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-000-PRINCIPAL */
        private void M_0000_000_PRINCIPAL(bool isPerform = false)
        {
            /*" -656- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -659- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -662- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -665- MOVE '0000-000-PRINCIPAL' TO PARAGRAFO. */
            _.Move("0000-000-PRINCIPAL", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -667- MOVE 'SELECT... FROM SEGUROS.V1SISTEMA' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1SISTEMA", LOCALIZA_ABEND_2.COMANDO);

            /*" -672- PERFORM M_0000_000_PRINCIPAL_DB_SELECT_1 */

            M_0000_000_PRINCIPAL_DB_SELECT_1();

            /*" -675- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -677- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -679- MOVE SISTEMA-DTMOVABE TO DATA-SQL. */
            _.Move(SISTEMA_DTMOVABE, WORK.DATA_SQL);

            /*" -680- MOVE SISTEMA-DTCURRENT TO DATA-MAQ. */
            _.Move(SISTEMA_DTCURRENT, WORK.DATA_SQL.DATA_MAQ);

            /*" -681- MOVE CORR DATA-MAQ TO DATA-DDMMAA. */
            _.MoveCorr(WORK.DATA_SQL.DATA_MAQ, WORK.DATA_DDMMAA);

            /*" -682- MOVE DATA-NORMAL TO CAB2-DATA. */
            _.Move(WORK.DATA_NORMAL, CAB_2.CAB2_DATA);

            /*" -683- ACCEPT CAB-HORA-1 FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WORK.DATA_AAMMDD.CAB_HORA_1);

            /*" -684- MOVE CAB-HORA-2 TO CAB3-HORA. */
            _.Move(WORK.DATA_AAMMDD.WHORA_PER_X.CAB_HORA_2, CAB_3.CAB3_HORA);

            /*" -686- OPEN OUTPUT RVG0122B. */
            RVG0122B.Open(REG_IMPRESSAO);

            /*" -688- MOVE 'SELECT... FROM SEGUROS.V1EMPRESA' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1EMPRESA", LOCALIZA_ABEND_2.COMANDO);

            /*" -692- PERFORM M_0000_000_PRINCIPAL_DB_SELECT_2 */

            M_0000_000_PRINCIPAL_DB_SELECT_2();

            /*" -695- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -697- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -699- MOVE NOME-EMPRESA TO LK-TITULO. */
            _.Move(NOME_EMPRESA, LK_LINK.LK_TITULO);

            /*" -700- CALL 'PROALN01' USING LK-LINK. */
            _.Call("PROALN01", LK_LINK);

            /*" -701- IF LK-RETURN-CODE OF LK-LINK EQUAL ZEROS */

            if (LK_LINK.LK_RETURN_CODE == 00)
            {

                /*" -702- MOVE LK-TITULO TO CAB1-EMPRESA */
                _.Move(LK_LINK.LK_TITULO, CAB_1.CAB1_EMPRESA);

                /*" -703- ELSE */
            }
            else
            {


                /*" -704- DISPLAY 'PROBLEMA NO CALL AS0010S - ALINHA/ TITULO' */
                _.Display($"PROBLEMA NO CALL AS0010S - ALINHA/ TITULO");

                /*" -706- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -708- MOVE 'SELECT... FROM SEGUROS.V1PARAMRAMO' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1PARAMRAMO", LOCALIZA_ABEND_2.COMANDO);

            /*" -713- PERFORM M_0000_000_PRINCIPAL_DB_SELECT_3 */

            M_0000_000_PRINCIPAL_DB_SELECT_3();

            /*" -716- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -717- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -718- DISPLAY '    VG0122B - ERRO NO ACESSO A V1PARAMRAMO' */
                _.Display($"    VG0122B - ERRO NO ACESSO A V1PARAMRAMO");

                /*" -719- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -720- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -720- PERFORM 0010-000-INICI-PROCESSO. */

            M_0010_000_INICI_PROCESSO_SECTION();

        }

        [StopWatch]
        /*" M-0000-000-PRINCIPAL-DB-SELECT-1 */
        public void M_0000_000_PRINCIPAL_DB_SELECT_1()
        {
            /*" -672- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :SISTEMA-DTMOVABE, :SISTEMA-DTCURRENT FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VG' END-EXEC. */

            var m_0000_000_PRINCIPAL_DB_SELECT_1_Query1 = new M_0000_000_PRINCIPAL_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_0000_000_PRINCIPAL_DB_SELECT_1_Query1.Execute(m_0000_000_PRINCIPAL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMA_DTMOVABE, SISTEMA_DTMOVABE);
                _.Move(executed_1.SISTEMA_DTCURRENT, SISTEMA_DTCURRENT);
            }


        }

        [StopWatch]
        /*" M-0010-000-INICI-PROCESSO-SECTION */
        private void M_0010_000_INICI_PROCESSO_SECTION()
        {
            /*" -725- MOVE ZEROS TO AC-CAPITAIS. */
            _.Move(0, AC_CAPITAIS);

            /*" -726- PERFORM 0100-000-DECLARA-RELATORIO. */

            M_0100_000_DECLARA_RELATORIO_SECTION();

            /*" -727- PERFORM 0110-020-FETCH-RELATORIO. */

            M_0110_020_FETCH_RELATORIO_SECTION();

            /*" -730- PERFORM 0020-000-PROCESSA UNTIL FIM-RELATORIO. */

            while (!(FLAG_FIM_RELATORIO["FIM_RELATORIO"]))
            {

                M_0020_000_PROCESSA_SECTION();
            }

            /*" -731- IF HOUVE-RELATORIO */

            if (FLAG_EXISTE_REL["HOUVE_RELATORIO"])
            {

                /*" -732- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -733- DISPLAY ' PROGRAMA VG0122B ' */
                _.Display($" PROGRAMA VG0122B ");

                /*" -734- DISPLAY ' TOTAL DE SOLICITACAO          = ' AC-SOLICITADO */
                _.Display($" TOTAL DE SOLICITACAO          = {AC_SOLICITADO}");

                /*" -735- DISPLAY ' TOTAL DE SEGURADOS PROCESADOS = ' AC-EMITIDOS */
                _.Display($" TOTAL DE SEGURADOS PROCESADOS = {AC_EMITIDOS}");

                /*" -736- DISPLAY '-----------------------------------------------' */
                _.Display($"-----------------------------------------------");

                /*" -737- DISPLAY ' ' */
                _.Display($" ");

                /*" -738- PERFORM 0700-000-UPDATE */

                M_0700_000_UPDATE_SECTION();

                /*" -739- ELSE */
            }
            else
            {


                /*" -740- PERFORM 0600-500-000-IMPRIME-CABECALHO */

                M_0600_500_000_IMPRIME_CABECALHO_SECTION();

                /*" -742- DISPLAY '------------------------------------------------- '--------------------------' */
                _.Display($"------------------------------------------------- --------------------------");

                /*" -744- DISPLAY ' VG0122B - NAO HOUVE SELECAO DE SOLICITACAO NEST 'A DATA - ' SISTEMA-DTMOVABE */

                $" VG0122B - NAO HOUVE SELECAO DE SOLICITACAO NEST ADATA-{SISTEMA_DTMOVABE}"
                .Display();

                /*" -746- DISPLAY '------------------------------------------------- '--------------------------' */
                _.Display($"------------------------------------------------- --------------------------");

                /*" -747- DISPLAY ' ' */
                _.Display($" ");

                /*" -748- MOVE MEN-1 TO MENSAGEM */
                _.Move(MEN_1, MENSAGEM);

                /*" -750- PERFORM 0510-000-IMPRIME-MENSAGEM. */

                M_0510_000_IMPRIME_MENSAGEM_SECTION();
            }


            /*" -753- PERFORM 9000-000-CLOSE-CURSOR */

            M_9000_000_CLOSE_CURSOR_SECTION();

            /*" -753- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -757- CLOSE RVG0122B. */
            RVG0122B.Close();

            /*" -759- DISPLAY 'FIM NORMAL      **** VG0122B ****' . */
            _.Display($"FIM NORMAL      **** VG0122B ****");

            /*" -761- MOVE 0 TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -763- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" M-0000-000-PRINCIPAL-DB-SELECT-2 */
        public void M_0000_000_PRINCIPAL_DB_SELECT_2()
        {
            /*" -692- EXEC SQL SELECT NOME_EMPRESA INTO :NOME-EMPRESA FROM SEGUROS.V1EMPRESA WHERE COD_EMPRESA = 0 END-EXEC. */

            var m_0000_000_PRINCIPAL_DB_SELECT_2_Query1 = new M_0000_000_PRINCIPAL_DB_SELECT_2_Query1()
            {
            };

            var executed_1 = M_0000_000_PRINCIPAL_DB_SELECT_2_Query1.Execute(m_0000_000_PRINCIPAL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NOME_EMPRESA, NOME_EMPRESA);
            }


        }

        [StopWatch]
        /*" M-0020-000-PROCESSA-SECTION */
        private void M_0020_000_PROCESSA_SECTION()
        {
            /*" -769- PERFORM 0400-020-MONTA-ESTIPULANTE. */

            M_0400_020_MONTA_ESTIPULANTE_SECTION();

            /*" -770- PERFORM 0120-020-DECLARA-SEGURADOS. */

            M_0120_020_DECLARA_SEGURADOS_SECTION();

            /*" -771- PERFORM 0130-040-FETCH-SEGURADO. */

            M_0130_040_FETCH_SEGURADO_SECTION();

            /*" -773- PERFORM 0040-020-PROCESSA-RELATO UNTIL FIM-SEGURADO. */

            while (!(FLAG_FIM_SEGURADO["FIM_SEGURADO"]))
            {

                M_0040_020_PROCESSA_RELATO_SECTION();
            }

            /*" -775- IF HOUVE-SEGURADO NEXT SENTENCE */

            if (FLAG_EXISTE_SEGUR["HOUVE_SEGURADO"])
            {

                /*" -776- ELSE */
            }
            else
            {


                /*" -778- DISPLAY '------------------------------------------------- '---------------------------------------' */
                _.Display($"------------------------------------------------- ---------------------------------------");

                /*" -780- DISPLAY ' VG0122B - NAO HOUVE SELECAO DE SEGURADOS CONFORM 'E SOLICITACAO ' */

                $" VG0122B - NAO HOUVE SELECAO DE SEGURADOS CONFORM ESOLICITACAO"
                .Display();

                /*" -781- DISPLAY '           APOLICE  = ' RELAT-NUM-APOLICE */
                _.Display($"           APOLICE  = {RELAT_NUM_APOLICE}");

                /*" -782- DISPLAY '         SUB GRUPO  = ' RELAT-COD-SUBES */
                _.Display($"         SUB GRUPO  = {RELAT_COD_SUBES}");

                /*" -784- DISPLAY '------------------------------------------------- '---------------------------------------' */
                _.Display($"------------------------------------------------- ---------------------------------------");

                /*" -786- DISPLAY ' ' . */
                _.Display($" ");
            }


            /*" -787- PERFORM 9000-020-CLOSE-CURSOR-SEGURADO */

            M_9000_020_CLOSE_CURSOR_SEGURADO_SECTION();

            /*" -788- PERFORM 0520-020-IMPRIME-TOTAIS */

            M_0520_020_IMPRIME_TOTAIS_SECTION();

            /*" -789- MOVE ZEROS TO FLAG-EXISTE-SEGUR */
            _.Move(0, FLAG_EXISTE_SEGUR);

            /*" -790- MOVE ZEROS TO FLAG-FIM-SEGURADO */
            _.Move(0, FLAG_FIM_SEGURADO);

            /*" -791- MOVE ZEROS TO AC-PAGINAS */
            _.Move(0, AC_PAGINAS);

            /*" -791- PERFORM 0110-020-FETCH-RELATORIO. */

            M_0110_020_FETCH_RELATORIO_SECTION();

        }

        [StopWatch]
        /*" M-0000-000-PRINCIPAL-DB-SELECT-3 */
        public void M_0000_000_PRINCIPAL_DB_SELECT_3()
        {
            /*" -713- EXEC SQL SELECT RAMO_VG , RAMO_AP INTO :PARAM-RAMO-VG , :PARAM-RAMO-AP FROM SEGUROS.V1PARAMRAMO END-EXEC. */

            var m_0000_000_PRINCIPAL_DB_SELECT_3_Query1 = new M_0000_000_PRINCIPAL_DB_SELECT_3_Query1()
            {
            };

            var executed_1 = M_0000_000_PRINCIPAL_DB_SELECT_3_Query1.Execute(m_0000_000_PRINCIPAL_DB_SELECT_3_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAM_RAMO_VG, PARAM_RAMO_VG);
                _.Move(executed_1.PARAM_RAMO_AP, PARAM_RAMO_AP);
            }


        }

        [StopWatch]
        /*" M-0040-020-PROCESSA-RELATO-SECTION */
        private void M_0040_020_PROCESSA_RELATO_SECTION()
        {
            /*" -797- PERFORM 0140-040-060-ACESSA-HISTSEGVG. */

            M_0140_040_060_ACESSA_HISTSEGVG_SECTION();

            /*" -798- PERFORM 0145-020-060-ACESSA-MOEDA-IMP. */

            M_0145_020_060_ACESSA_MOEDA_IMP_SECTION();

            /*" -799- PERFORM 0145-020-060-ACESSA-MOEDA-PRM. */

            M_0145_020_060_ACESSA_MOEDA_PRM_SECTION();

            /*" -800- PERFORM 0060-040-MONTA-DETALHES. */

            M_0060_040_MONTA_DETALHES_SECTION();

            /*" -801- PERFORM 0130-040-FETCH-SEGURADO. */

            M_0130_040_FETCH_SEGURADO_SECTION();

        }

        [StopWatch]
        /*" M-0060-040-MONTA-DETALHES-SECTION */
        private void M_0060_040_MONTA_DETALHES_SECTION()
        {
            /*" -806- PERFORM 0070-060-PROCESSA-PRINCIPAL. */

            M_0070_060_PROCESSA_PRINCIPAL_SECTION();

            /*" -806- PERFORM 0080-060-PROCESSA-CONJUGE. */

            M_0080_060_PROCESSA_CONJUGE_SECTION();

        }

        [StopWatch]
        /*" M-0070-060-PROCESSA-PRINCIPAL-SECTION */
        private void M_0070_060_PROCESSA_PRINCIPAL_SECTION()
        {
            /*" -814- PERFORM 300-150-240-COBERTURAS. */

            M_300_150_240_COBERTURAS_SECTION();

            /*" -815- MOVE CLIENTE-NOME-RAZAO TO DET1-NOME */
            _.Move(CLIENTE_NOME_RAZAO, DET_1.DET1_NOME);

            /*" -816- MOVE SEGURAVG-COD-SUBG TO DET1-SUBG */
            _.Move(SEGURAVG_COD_SUBG, DET_1.DET1_SUBG);

            /*" -817- MOVE LK-COBT-MORTE-NATURAL TO DET1-CAP-VG */
            _.Move(LK_COBT_MORTE_NATURAL, DET_1.DET1_CAP_VG);

            /*" -818- MOVE LK-COBT-MORTE-ACIDENTAL TO DET1-CAP-MA */
            _.Move(LK_COBT_MORTE_ACIDENTAL, DET_1.DET1_CAP_MA);

            /*" -819- MOVE LK-COBT-INV-PERMANENTE TO DET1-CAP-IP */
            _.Move(LK_COBT_INV_PERMANENTE, DET_1.DET1_CAP_IP);

            /*" -820- MOVE LK-COBT-ASS-MEDICA TO DET1-CAP-AMDS */
            _.Move(LK_COBT_ASS_MEDICA, DET_1.DET1_CAP_AMDS);

            /*" -821- MOVE LK-COBT-DIARIA-HOSPITALAR TO DET1-CAP-DH */
            _.Move(LK_COBT_DIARIA_HOSPITALAR, DET_1.DET1_CAP_DH);

            /*" -822- MOVE LK-COBT-DIARIA-INTERNACAO TO DET1-CAP-DIT */
            _.Move(LK_COBT_DIARIA_INTERNACAO, DET_1.DET1_CAP_DIT);

            /*" -823- MOVE CLIENTE-CGC-CPF TO AUX-CPF */
            _.Move(CLIENTE_CGC_CPF, AUX_CPF);

            /*" -824- MOVE AUX-CPF-1 TO DET2-CPF */
            _.Move(FILLER_8.AUX_CPF_1, DET_2.DET2_CPF);

            /*" -825- MOVE AUX-CPF-2 TO DET2-CPF-CONT */
            _.Move(FILLER_8.AUX_CPF_2, DET_2.DET2_CPF_CONT);

            /*" -827- MOVE SEGURAVG-MATRICULA TO DET2-MATR */
            _.Move(SEGURAVG_MATRICULA, DET_2.DET2_MATR);

            /*" -828- IF SEGURAVG-IDE-SEXO EQUAL 'F' */

            if (SEGURAVG_IDE_SEXO == "F")
            {

                /*" -829- MOVE 'MASC' TO DET2-SEXO */
                _.Move("MASC", DET_2.DET2_SEXO);

                /*" -830- ELSE */
            }
            else
            {


                /*" -832- MOVE 'FEM ' TO DET2-SEXO. */
                _.Move("FEM ", DET_2.DET2_SEXO);
            }


            /*" -833- IF SEGURAVG-EST-CIVIL EQUAL 'S' */

            if (SEGURAVG_EST_CIVIL == "S")
            {

                /*" -834- MOVE 'SOLTEIRO  ' TO DET2-EST-CVL */
                _.Move("SOLTEIRO  ", DET_2.DET2_EST_CVL);

                /*" -835- ELSE */
            }
            else
            {


                /*" -836- IF SEGURAVG-EST-CIVIL EQUAL 'C' */

                if (SEGURAVG_EST_CIVIL == "C")
                {

                    /*" -837- MOVE 'CASADO    ' TO DET2-EST-CVL */
                    _.Move("CASADO    ", DET_2.DET2_EST_CVL);

                    /*" -838- ELSE */
                }
                else
                {


                    /*" -839- IF SEGURAVG-EST-CIVIL EQUAL 'D' */

                    if (SEGURAVG_EST_CIVIL == "D")
                    {

                        /*" -840- MOVE 'DESQUITADO' TO DET2-EST-CVL */
                        _.Move("DESQUITADO", DET_2.DET2_EST_CVL);

                        /*" -841- ELSE */
                    }
                    else
                    {


                        /*" -843- MOVE SEGURAVG-EST-CIVIL TO DET2-EST-CVL. */
                        _.Move(SEGURAVG_EST_CIVIL, DET_2.DET2_EST_CVL);
                    }

                }

            }


            /*" -844- MOVE SEGURAVG-DT-NASCI TO DATA-SQL */
            _.Move(SEGURAVG_DT_NASCI, WORK.DATA_SQL);

            /*" -845- MOVE ANO OF DATA-SQL TO ANO OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.ANO, WORK.DATA_DDMMAA.ANO_1);

            /*" -846- MOVE MES OF DATA-SQL TO MES OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.MES, WORK.DATA_DDMMAA.MES_1);

            /*" -847- MOVE DIA OF DATA-SQL TO DIA OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.DIA, WORK.DATA_DDMMAA.DIA_1);

            /*" -848- MOVE DATA-NORMAL TO DET2-NASC. */
            _.Move(WORK.DATA_NORMAL, DET_2.DET2_NASC);

            /*" -849- MOVE SEGURAVG-DT-INIVI TO DATA-SQL. */
            _.Move(SEGURAVG_DT_INIVI, WORK.DATA_SQL);

            /*" -850- MOVE ANO OF DATA-SQL TO ANO OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.ANO, WORK.DATA_DDMMAA.ANO_1);

            /*" -851- MOVE MES OF DATA-SQL TO MES OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.MES, WORK.DATA_DDMMAA.MES_1);

            /*" -852- MOVE DIA OF DATA-SQL TO DIA OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.DIA, WORK.DATA_DDMMAA.DIA_1);

            /*" -853- MOVE DATA-NORMAL TO DET2-INIVIG. */
            _.Move(WORK.DATA_NORMAL, DET_2.DET2_INIVIG);

            /*" -854- MOVE LK-PREM-MORTE-NATURAL TO DET2-PREM-VG. */
            _.Move(LK_PREM_MORTE_NATURAL, DET_2.DET2_PREM_VG);

            /*" -855- MOVE LK-PREM-ACIDENTES-PESSOAIS TO DET2-PREM-AP. */
            _.Move(LK_PREM_ACIDENTES_PESSOAIS, DET_2.DET2_PREM_AP);

            /*" -856- MOVE SEGURAVG-NUM-CERT TO DET3-CERT */
            _.Move(SEGURAVG_NUM_CERT, DET_3.DET3_CERT);

            /*" -857- MOVE HISTSEGVG-DATA-MOV TO DATA-SQL. */
            _.Move(HISTSEGVG_DATA_MOV, WORK.DATA_SQL);

            /*" -858- MOVE ANO OF DATA-SQL TO ANO OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.ANO, WORK.DATA_DDMMAA.ANO_1);

            /*" -859- MOVE MES OF DATA-SQL TO MES OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.MES, WORK.DATA_DDMMAA.MES_1);

            /*" -860- MOVE DIA OF DATA-SQL TO DIA OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.DIA, WORK.DATA_DDMMAA.DIA_1);

            /*" -861- MOVE DATA-NORMAL TO DET3-ULTI-ALT. */
            _.Move(WORK.DATA_NORMAL, DET_3.DET3_ULTI_ALT);

            /*" -865- PERFORM 0330-070-090-PESQUISA VARYING I FROM 1 BY 1 UNTIL I GREATER 15 OR TAB-COD-OPER(I) EQUAL HISTSEGVG-COD-OPER. */

            for (I.Value = 1; !(I > 15 || TAB_AUX.TAB_OPERACAO[I].TAB_COD_OPER == HISTSEGVG_COD_OPER); I.Value += 1)
            {

                M_0330_070_090_PESQUISA_SECTION();
            }

            /*" -867- MOVE TAB-DES-OPER(I) TO DET3-DESC-ULT-ALT. */
            _.Move(TAB_AUX.TAB_OPERACAO[I].TAB_DES_OPER, DET_3.DET3_DESC_ULT_ALT);

            /*" -869- PERFORM 0450-020-ACESSA-CTA-CORRENTE. */

            M_0450_020_ACESSA_CTA_CORRENTE_SECTION();

            /*" -870- PERFORM 0340-070-090-TOTALIZA. */

            M_0340_070_090_TOTALIZA_SECTION();

            /*" -870- PERFORM 0500-070-090-IMPRIME-DETALHES. */

            M_0500_070_090_IMPRIME_DETALHES_SECTION();

        }

        [StopWatch]
        /*" M-0080-060-PROCESSA-CONJUGE-SECTION */
        private void M_0080_060_PROCESSA_CONJUGE_SECTION()
        {
            /*" -876- PERFORM 0210-200-ACESSA-SEGURAVG */

            M_0210_200_ACESSA_SEGURAVG_SECTION();

            /*" -877- IF POSSUI-CONJUGE */

            if (FLAG_CONJUGE["POSSUI_CONJUGE"])
            {

                /*" -878- PERFORM 0220-200-ACESSA-CLIENTES */

                M_0220_200_ACESSA_CLIENTES_SECTION();

                /*" -879- PERFORM 0140-040-060-ACESSA-HISTSEGVG */

                M_0140_040_060_ACESSA_HISTSEGVG_SECTION();

                /*" -880- PERFORM 0145-020-060-ACESSA-MOEDA-IMP */

                M_0145_020_060_ACESSA_MOEDA_IMP_SECTION();

                /*" -881- PERFORM 0145-020-060-ACESSA-MOEDA-PRM */

                M_0145_020_060_ACESSA_MOEDA_PRM_SECTION();

                /*" -882- PERFORM 0090-080-MONTA-CONJUGE */

                M_0090_080_MONTA_CONJUGE_SECTION();

                /*" -882- MOVE ZEROS TO FLAG-CONJUGE. */
                _.Move(0, FLAG_CONJUGE);
            }


        }

        [StopWatch]
        /*" M-0090-080-MONTA-CONJUGE-SECTION */
        private void M_0090_080_MONTA_CONJUGE_SECTION()
        {
            /*" -889- PERFORM 300-150-240-COBERTURAS. */

            M_300_150_240_COBERTURAS_SECTION();

            /*" -890- MOVE CLIENTE-NOME-RAZAO TO DET1-NOME */
            _.Move(CLIENTE_NOME_RAZAO, DET_1.DET1_NOME);

            /*" -891- MOVE SEGURAVG-COD-SUBG TO DET1-SUBG */
            _.Move(SEGURAVG_COD_SUBG, DET_1.DET1_SUBG);

            /*" -892- MOVE LK-COBT-MORTE-NATURAL TO DET1-CAP-VG */
            _.Move(LK_COBT_MORTE_NATURAL, DET_1.DET1_CAP_VG);

            /*" -893- MOVE LK-COBT-MORTE-ACIDENTAL TO DET1-CAP-MA */
            _.Move(LK_COBT_MORTE_ACIDENTAL, DET_1.DET1_CAP_MA);

            /*" -894- MOVE LK-COBT-INV-PERMANENTE TO DET1-CAP-IP */
            _.Move(LK_COBT_INV_PERMANENTE, DET_1.DET1_CAP_IP);

            /*" -895- MOVE LK-COBT-ASS-MEDICA TO DET1-CAP-AMDS */
            _.Move(LK_COBT_ASS_MEDICA, DET_1.DET1_CAP_AMDS);

            /*" -896- MOVE LK-COBT-DIARIA-HOSPITALAR TO DET1-CAP-DH */
            _.Move(LK_COBT_DIARIA_HOSPITALAR, DET_1.DET1_CAP_DH);

            /*" -897- MOVE LK-COBT-DIARIA-INTERNACAO TO DET1-CAP-DIT */
            _.Move(LK_COBT_DIARIA_INTERNACAO, DET_1.DET1_CAP_DIT);

            /*" -898- MOVE CLIENTE-CGC-CPF TO AUX-CPF */
            _.Move(CLIENTE_CGC_CPF, AUX_CPF);

            /*" -899- MOVE AUX-CPF-1 TO DET2-CPF */
            _.Move(FILLER_8.AUX_CPF_1, DET_2.DET2_CPF);

            /*" -900- MOVE AUX-CPF-2 TO DET2-CPF-CONT */
            _.Move(FILLER_8.AUX_CPF_2, DET_2.DET2_CPF_CONT);

            /*" -902- MOVE SEGURAVG-MATRICULA TO DET2-MATR */
            _.Move(SEGURAVG_MATRICULA, DET_2.DET2_MATR);

            /*" -903- IF SEGURAVG-IDE-SEXO EQUAL 'F' */

            if (SEGURAVG_IDE_SEXO == "F")
            {

                /*" -904- MOVE 'FEM ' TO DET2-SEXO */
                _.Move("FEM ", DET_2.DET2_SEXO);

                /*" -905- ELSE */
            }
            else
            {


                /*" -907- MOVE 'MASC' TO DET2-SEXO. */
                _.Move("MASC", DET_2.DET2_SEXO);
            }


            /*" -908- IF SEGURAVG-EST-CIVIL EQUAL 'S' */

            if (SEGURAVG_EST_CIVIL == "S")
            {

                /*" -909- MOVE 'SOLTEIRO  ' TO DET2-EST-CVL */
                _.Move("SOLTEIRO  ", DET_2.DET2_EST_CVL);

                /*" -910- ELSE */
            }
            else
            {


                /*" -911- IF SEGURAVG-EST-CIVIL EQUAL 'C' */

                if (SEGURAVG_EST_CIVIL == "C")
                {

                    /*" -912- MOVE 'CASADO    ' TO DET2-EST-CVL */
                    _.Move("CASADO    ", DET_2.DET2_EST_CVL);

                    /*" -913- ELSE */
                }
                else
                {


                    /*" -914- IF SEGURAVG-EST-CIVIL EQUAL 'D' */

                    if (SEGURAVG_EST_CIVIL == "D")
                    {

                        /*" -915- MOVE 'DESQUITADO' TO DET2-EST-CVL */
                        _.Move("DESQUITADO", DET_2.DET2_EST_CVL);

                        /*" -916- ELSE */
                    }
                    else
                    {


                        /*" -918- MOVE SEGURAVG-EST-CIVIL TO DET2-EST-CVL. */
                        _.Move(SEGURAVG_EST_CIVIL, DET_2.DET2_EST_CVL);
                    }

                }

            }


            /*" -919- MOVE SEGURAVG-DT-NASCI TO DATA-SQL */
            _.Move(SEGURAVG_DT_NASCI, WORK.DATA_SQL);

            /*" -920- MOVE ANO OF DATA-SQL TO ANO OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.ANO, WORK.DATA_DDMMAA.ANO_1);

            /*" -921- MOVE MES OF DATA-SQL TO MES OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.MES, WORK.DATA_DDMMAA.MES_1);

            /*" -922- MOVE DIA OF DATA-SQL TO DIA OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.DIA, WORK.DATA_DDMMAA.DIA_1);

            /*" -923- MOVE DATA-NORMAL TO DET2-NASC. */
            _.Move(WORK.DATA_NORMAL, DET_2.DET2_NASC);

            /*" -924- MOVE SEGURAVG-DT-INIVI TO DATA-SQL. */
            _.Move(SEGURAVG_DT_INIVI, WORK.DATA_SQL);

            /*" -925- MOVE ANO OF DATA-SQL TO ANO OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.ANO, WORK.DATA_DDMMAA.ANO_1);

            /*" -926- MOVE MES OF DATA-SQL TO MES OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.MES, WORK.DATA_DDMMAA.MES_1);

            /*" -927- MOVE DIA OF DATA-SQL TO DIA OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.DIA, WORK.DATA_DDMMAA.DIA_1);

            /*" -928- MOVE DATA-NORMAL TO DET2-INIVIG. */
            _.Move(WORK.DATA_NORMAL, DET_2.DET2_INIVIG);

            /*" -929- MOVE LK-PREM-MORTE-NATURAL TO DET2-PREM-VG. */
            _.Move(LK_PREM_MORTE_NATURAL, DET_2.DET2_PREM_VG);

            /*" -930- MOVE LK-PREM-ACIDENTES-PESSOAIS TO DET2-PREM-AP. */
            _.Move(LK_PREM_ACIDENTES_PESSOAIS, DET_2.DET2_PREM_AP);

            /*" -931- MOVE SEGURAVG-NUM-CERT TO DET3-CERT */
            _.Move(SEGURAVG_NUM_CERT, DET_3.DET3_CERT);

            /*" -932- MOVE HISTSEGVG-DATA-MOV TO DATA-SQL. */
            _.Move(HISTSEGVG_DATA_MOV, WORK.DATA_SQL);

            /*" -933- MOVE ANO OF DATA-SQL TO ANO OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.ANO, WORK.DATA_DDMMAA.ANO_1);

            /*" -934- MOVE MES OF DATA-SQL TO MES OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.MES, WORK.DATA_DDMMAA.MES_1);

            /*" -935- MOVE DIA OF DATA-SQL TO DIA OF DATA-DDMMAA. */
            _.Move(WORK.DATA_SQL.DIA, WORK.DATA_DDMMAA.DIA_1);

            /*" -936- MOVE DATA-NORMAL TO DET3-ULTI-ALT. */
            _.Move(WORK.DATA_NORMAL, DET_3.DET3_ULTI_ALT);

            /*" -940- PERFORM 0330-070-090-PESQUISA VARYING I FROM 1 BY 1 UNTIL I GREATER 15 OR TAB-COD-OPER(I) EQUAL HISTSEGVG-COD-OPER. */

            for (I.Value = 1; !(I > 15 || TAB_AUX.TAB_OPERACAO[I].TAB_COD_OPER == HISTSEGVG_COD_OPER); I.Value += 1)
            {

                M_0330_070_090_PESQUISA_SECTION();
            }

            /*" -942- MOVE TAB-DES-OPER(I) TO DET3-DESC-ULT-ALT. */
            _.Move(TAB_AUX.TAB_OPERACAO[I].TAB_DES_OPER, DET_3.DET3_DESC_ULT_ALT);

            /*" -944- PERFORM 0450-020-ACESSA-CTA-CORRENTE. */

            M_0450_020_ACESSA_CTA_CORRENTE_SECTION();

            /*" -945- PERFORM 0340-070-090-TOTALIZA. */

            M_0340_070_090_TOTALIZA_SECTION();

            /*" -945- PERFORM 0500-070-090-IMPRIME-DETALHES. */

            M_0500_070_090_IMPRIME_DETALHES_SECTION();

        }

        [StopWatch]
        /*" M-0100-000-DECLARA-RELATORIO-SECTION */
        private void M_0100_000_DECLARA_RELATORIO_SECTION()
        {
            /*" -952- MOVE '0100-000-DECLARA-RELATORIO ' TO PARAGRAFO. */
            _.Move("0100-000-DECLARA-RELATORIO ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -954- MOVE 'DECLARE.. FROM SEGUROS.V0RELATORIOS' TO COMANDO. */
            _.Move("DECLARE.. FROM SEGUROS.V0RELATORIOS", LOCALIZA_ABEND_2.COMANDO);

            /*" -970- PERFORM M_0100_000_DECLARA_RELATORIO_DB_DECLARE_1 */

            M_0100_000_DECLARA_RELATORIO_DB_DECLARE_1();

            /*" -973- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -975- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -977- MOVE 'OPEN ...  CURSOR  RELATORIO      ' TO COMANDO. */
            _.Move("OPEN ...  CURSOR  RELATORIO      ", LOCALIZA_ABEND_2.COMANDO);

            /*" -978- PERFORM M_0100_000_DECLARA_RELATORIO_DB_OPEN_1 */

            M_0100_000_DECLARA_RELATORIO_DB_OPEN_1();

            /*" -981- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -981- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0100-000-DECLARA-RELATORIO-DB-DECLARE-1 */
        public void M_0100_000_DECLARA_RELATORIO_DB_DECLARE_1()
        {
            /*" -970- EXEC SQL DECLARE RELATORIO CURSOR FOR SELECT IDSISTEM , CODRELAT , NUM_APOLICE , NRCERTIF , CODSUBES , OPERACAO , SITUACAO FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'VG' AND SITUACAO = '0' AND CODRELAT = 'VG0122B' AND OPERACAO >= 1 AND OPERACAO <= 3 ORDER BY OPERACAO END-EXEC. */
            RELATORIO = new VG0122B_RELATORIO(false);
            string GetQuery_RELATORIO()
            {
                var query = @$"SELECT IDSISTEM
							, 
							CODRELAT
							, 
							NUM_APOLICE
							, 
							NRCERTIF
							, 
							CODSUBES
							, 
							OPERACAO
							, 
							SITUACAO 
							FROM SEGUROS.V0RELATORIOS 
							WHERE IDSISTEM = 'VG' 
							AND SITUACAO = '0' 
							AND CODRELAT = 'VG0122B' 
							AND OPERACAO >= 1 
							AND OPERACAO <= 3 
							ORDER BY OPERACAO";

                return query;
            }
            RELATORIO.GetQueryEvent += GetQuery_RELATORIO;

        }

        [StopWatch]
        /*" M-0100-000-DECLARA-RELATORIO-DB-OPEN-1 */
        public void M_0100_000_DECLARA_RELATORIO_DB_OPEN_1()
        {
            /*" -978- EXEC SQL OPEN RELATORIO END-EXEC. */

            RELATORIO.Open();

        }

        [StopWatch]
        /*" M-0121-120-DECLARA-SEGURADOS-DB-DECLARE-1 */
        public void M_0121_120_DECLARA_SEGURADOS_DB_DECLARE_1()
        {
            /*" -1094- EXEC SQL DECLARE SEGURADO1 CURSOR FOR SELECT T1.NUM_APOLICE , T1.COD_SUBGRUPO , T1.COD_CLIENTE , T1.NUM_CERTIFICADO , T1.DAC_CERTIFICADO , T1.TIPO_SEGURADO , T1.NUM_ITEM , T1.OCORR_HISTORICO , T1.ESTADO_CIVIL , T1.IDE_SEXO , T1.NUM_MATRICULA , T1.DATA_INIVIGENCIA , T1.SIT_REGISTRO , T1.DATA_NASCIMENTO , T2.COD_CLIENTE , T2.NOME_RAZAO , T2.CGCCPF FROM SEGUROS.V1SEGURAVG T1, SEGUROS.V1CLIENTE T2 WHERE T1.COD_CLIENTE = T2.COD_CLIENTE AND T1.NUM_APOLICE = :RELAT-NUM-APOLICE AND T1.COD_SUBGRUPO >= :AUX-SUBGRUPO-I AND T1.COD_SUBGRUPO <= :AUX-SUBGRUPO-F AND T1.TIPO_SEGURADO = '1' ORDER BY T2.NOME_RAZAO END-EXEC. */
            SEGURADO1 = new VG0122B_SEGURADO1(true);
            string GetQuery_SEGURADO1()
            {
                var query = @$"SELECT T1.NUM_APOLICE
							, 
							T1.COD_SUBGRUPO
							, 
							T1.COD_CLIENTE
							, 
							T1.NUM_CERTIFICADO
							, 
							T1.DAC_CERTIFICADO
							, 
							T1.TIPO_SEGURADO
							, 
							T1.NUM_ITEM
							, 
							T1.OCORR_HISTORICO
							, 
							T1.ESTADO_CIVIL
							, 
							T1.IDE_SEXO
							, 
							T1.NUM_MATRICULA
							, 
							T1.DATA_INIVIGENCIA
							, 
							T1.SIT_REGISTRO
							, 
							T1.DATA_NASCIMENTO
							, 
							T2.COD_CLIENTE
							, 
							T2.NOME_RAZAO
							, 
							T2.CGCCPF 
							FROM SEGUROS.V1SEGURAVG T1
							, 
							SEGUROS.V1CLIENTE T2 
							WHERE T1.COD_CLIENTE = T2.COD_CLIENTE 
							AND T1.NUM_APOLICE = '{RELAT_NUM_APOLICE}' 
							AND T1.COD_SUBGRUPO >= '{AUX_SUBGRUPO_I}' 
							AND T1.COD_SUBGRUPO <= '{AUX_SUBGRUPO_F}' 
							AND T1.TIPO_SEGURADO = '1' 
							ORDER BY T2.NOME_RAZAO";

                return query;
            }
            SEGURADO1.GetQueryEvent += GetQuery_SEGURADO1;

        }

        [StopWatch]
        /*" M-0110-020-FETCH-RELATORIO-SECTION */
        private void M_0110_020_FETCH_RELATORIO_SECTION()
        {
            /*" -987- MOVE '0110-020-FETCH-RELATORIO ' TO PARAGRAFO. */
            _.Move("0110-020-FETCH-RELATORIO ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -989- MOVE 'FETCH.... FROM SEGUROS.V0RELATORIOS' TO COMANDO. */
            _.Move("FETCH.... FROM SEGUROS.V0RELATORIOS", LOCALIZA_ABEND_2.COMANDO);

            /*" -997- PERFORM M_0110_020_FETCH_RELATORIO_DB_FETCH_1 */

            M_0110_020_FETCH_RELATORIO_DB_FETCH_1();

            /*" -1000- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1001- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -1002- DISPLAY 'ATENCAO -----------------------------------' */
                    _.Display($"ATENCAO -----------------------------------");

                    /*" -1003- DISPLAY '    VG0122B - ERRO NO FETCH DO RELATORIOS ' */
                    _.Display($"    VG0122B - ERRO NO FETCH DO RELATORIOS ");

                    /*" -1004- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -1005- GO TO 9999-999-ERRO */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1006- ELSE */
                }
                else
                {


                    /*" -1007- MOVE 1 TO FLAG-FIM-RELATORIO */
                    _.Move(1, FLAG_FIM_RELATORIO);

                    /*" -1008- ELSE */
                }

            }
            else
            {


                /*" -1009- MOVE 1 TO FLAG-EXISTE-REL */
                _.Move(1, FLAG_EXISTE_REL);

                /*" -1010- ADD 1 TO AC-SOLICITADO. */
                AC_SOLICITADO.Value = AC_SOLICITADO + 1;
            }


        }

        [StopWatch]
        /*" M-0110-020-FETCH-RELATORIO-DB-FETCH-1 */
        public void M_0110_020_FETCH_RELATORIO_DB_FETCH_1()
        {
            /*" -997- EXEC SQL FETCH RELATORIO INTO :RELAT-IDSISTEM , :RELAT-CODRELAT , :RELAT-NUM-APOLICE , :RELAT-NUM-CERTIFIC , :RELAT-COD-SUBES , :RELAT-OPERACAO , :RELAT-SITUACAO END-EXEC. */

            if (RELATORIO.Fetch())
            {
                _.Move(RELATORIO.RELAT_IDSISTEM, RELAT_IDSISTEM);
                _.Move(RELATORIO.RELAT_CODRELAT, RELAT_CODRELAT);
                _.Move(RELATORIO.RELAT_NUM_APOLICE, RELAT_NUM_APOLICE);
                _.Move(RELATORIO.RELAT_NUM_CERTIFIC, RELAT_NUM_CERTIFIC);
                _.Move(RELATORIO.RELAT_COD_SUBES, RELAT_COD_SUBES);
                _.Move(RELATORIO.RELAT_OPERACAO, RELAT_OPERACAO);
                _.Move(RELATORIO.RELAT_SITUACAO, RELAT_SITUACAO);
            }

        }

        [StopWatch]
        /*" M-0120-020-DECLARA-SEGURADOS-SECTION */
        private void M_0120_020_DECLARA_SEGURADOS_SECTION()
        {
            /*" -1036- MOVE '0120-020-DECLARA-SEGURADO  ' TO PARAGRAFO. */
            _.Move("0120-020-DECLARA-SEGURADO  ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1038- MOVE 'DECLARE.. FROM SEGUROS.V1SEGURAVG  ' TO COMANDO. */
            _.Move("DECLARE.. FROM SEGUROS.V1SEGURAVG  ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1039- IF RELAT-COD-SUBES NOT GREATER ZEROS */

            if (RELAT_COD_SUBES <= 00)
            {

                /*" -1040- MOVE ZEROS TO AUX-SUBGRUPO-I */
                _.Move(0, AUX_SUBGRUPO_I);

                /*" -1041- MOVE 9999 TO AUX-SUBGRUPO-F */
                _.Move(9999, AUX_SUBGRUPO_F);

                /*" -1042- ELSE */
            }
            else
            {


                /*" -1043- MOVE RELAT-COD-SUBES TO AUX-SUBGRUPO-I */
                _.Move(RELAT_COD_SUBES, AUX_SUBGRUPO_I);

                /*" -1047- MOVE RELAT-COD-SUBES TO AUX-SUBGRUPO-F. */
                _.Move(RELAT_COD_SUBES, AUX_SUBGRUPO_F);
            }


            /*" -1048- IF RELAT-OPERACAO EQUAL 0001 */

            if (RELAT_OPERACAO == 0001)
            {

                /*" -1049- PERFORM 0121-120-DECLARA-SEGURADOS */

                M_0121_120_DECLARA_SEGURADOS_SECTION();

                /*" -1051- MOVE 'SEGURADO POR APOLICE/NOME    ' TO CAB4-TITULO */
                _.Move("SEGURADO POR APOLICE/NOME    ", CAB_4.CAB4_TITULO);

                /*" -1052- PERFORM 0600-500-000-IMPRIME-CABECALHO */

                M_0600_500_000_IMPRIME_CABECALHO_SECTION();

                /*" -1053- ELSE */
            }
            else
            {


                /*" -1054- IF RELAT-OPERACAO EQUAL 0002 */

                if (RELAT_OPERACAO == 0002)
                {

                    /*" -1055- PERFORM 0122-120-DECLARA-SEGURADOS */

                    M_0122_120_DECLARA_SEGURADOS_SECTION();

                    /*" -1057- MOVE 'SEGURADO POR APOLICE/MATRICULA ' TO CAB4-TITULO */
                    _.Move("SEGURADO POR APOLICE/MATRICULA ", CAB_4.CAB4_TITULO);

                    /*" -1058- PERFORM 0600-500-000-IMPRIME-CABECALHO */

                    M_0600_500_000_IMPRIME_CABECALHO_SECTION();

                    /*" -1059- ELSE */
                }
                else
                {


                    /*" -1060- IF RELAT-OPERACAO EQUAL 0003 */

                    if (RELAT_OPERACAO == 0003)
                    {

                        /*" -1061- PERFORM 0123-120-DECLARA-SEGURADOS */

                        M_0123_120_DECLARA_SEGURADOS_SECTION();

                        /*" -1063- MOVE 'SEGURADO POR APOLICE/CERTIFICADO' TO CAB4-TITULO */
                        _.Move("SEGURADO POR APOLICE/CERTIFICADO", CAB_4.CAB4_TITULO);

                        /*" -1063- PERFORM 0600-500-000-IMPRIME-CABECALHO. */

                        M_0600_500_000_IMPRIME_CABECALHO_SECTION();
                    }

                }

            }


        }

        [StopWatch]
        /*" M-0121-120-DECLARA-SEGURADOS-SECTION */
        private void M_0121_120_DECLARA_SEGURADOS_SECTION()
        {
            /*" -1094- PERFORM M_0121_120_DECLARA_SEGURADOS_DB_DECLARE_1 */

            M_0121_120_DECLARA_SEGURADOS_DB_DECLARE_1();

            /*" -1097- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1098- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -1099- DISPLAY '  VG0122B - ERRO NO JOIN SEGURAVG/CLIENTE' */
                _.Display($"  VG0122B - ERRO NO JOIN SEGURAVG/CLIENTE");

                /*" -1100- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1102- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1104- MOVE 'OPEN ...  CURSOR   SEGURADO1     ' TO COMANDO. */
            _.Move("OPEN ...  CURSOR   SEGURADO1     ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1105- PERFORM M_0121_120_DECLARA_SEGURADOS_DB_OPEN_1 */

            M_0121_120_DECLARA_SEGURADOS_DB_OPEN_1();

            /*" -1108- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1108- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0121-120-DECLARA-SEGURADOS-DB-OPEN-1 */
        public void M_0121_120_DECLARA_SEGURADOS_DB_OPEN_1()
        {
            /*" -1105- EXEC SQL OPEN SEGURADO1 END-EXEC. */

            SEGURADO1.Open();

        }

        [StopWatch]
        /*" M-0122-120-DECLARA-SEGURADOS-DB-DECLARE-1 */
        public void M_0122_120_DECLARA_SEGURADOS_DB_DECLARE_1()
        {
            /*" -1139- EXEC SQL DECLARE SEGURADO2 CURSOR FOR SELECT T1.NUM_APOLICE , T1.COD_SUBGRUPO , T1.COD_CLIENTE , T1.NUM_CERTIFICADO , T1.DAC_CERTIFICADO , T1.TIPO_SEGURADO , T1.NUM_ITEM , T1.OCORR_HISTORICO , T1.ESTADO_CIVIL , T1.IDE_SEXO , T1.NUM_MATRICULA , T1.DATA_INIVIGENCIA , T1.SIT_REGISTRO , T1.DATA_NASCIMENTO , T2.COD_CLIENTE , T2.NOME_RAZAO , T2.CGCCPF FROM SEGUROS.V1SEGURAVG T1, SEGUROS.V1CLIENTE T2 WHERE T1.COD_CLIENTE = T2.COD_CLIENTE AND T1.NUM_APOLICE = :RELAT-NUM-APOLICE AND T1.COD_SUBGRUPO >= :AUX-SUBGRUPO-I AND T1.COD_SUBGRUPO <= :AUX-SUBGRUPO-F AND T1.TIPO_SEGURADO = '1' ORDER BY T1.NUM_MATRICULA END-EXEC. */
            SEGURADO2 = new VG0122B_SEGURADO2(true);
            string GetQuery_SEGURADO2()
            {
                var query = @$"SELECT T1.NUM_APOLICE
							, 
							T1.COD_SUBGRUPO
							, 
							T1.COD_CLIENTE
							, 
							T1.NUM_CERTIFICADO
							, 
							T1.DAC_CERTIFICADO
							, 
							T1.TIPO_SEGURADO
							, 
							T1.NUM_ITEM
							, 
							T1.OCORR_HISTORICO
							, 
							T1.ESTADO_CIVIL
							, 
							T1.IDE_SEXO
							, 
							T1.NUM_MATRICULA
							, 
							T1.DATA_INIVIGENCIA
							, 
							T1.SIT_REGISTRO
							, 
							T1.DATA_NASCIMENTO
							, 
							T2.COD_CLIENTE
							, 
							T2.NOME_RAZAO
							, 
							T2.CGCCPF 
							FROM SEGUROS.V1SEGURAVG T1
							, 
							SEGUROS.V1CLIENTE T2 
							WHERE T1.COD_CLIENTE = T2.COD_CLIENTE 
							AND T1.NUM_APOLICE = '{RELAT_NUM_APOLICE}' 
							AND T1.COD_SUBGRUPO >= '{AUX_SUBGRUPO_I}' 
							AND T1.COD_SUBGRUPO <= '{AUX_SUBGRUPO_F}' 
							AND T1.TIPO_SEGURADO = '1' 
							ORDER BY T1.NUM_MATRICULA";

                return query;
            }
            SEGURADO2.GetQueryEvent += GetQuery_SEGURADO2;

        }

        [StopWatch]
        /*" M-0122-120-DECLARA-SEGURADOS-SECTION */
        private void M_0122_120_DECLARA_SEGURADOS_SECTION()
        {
            /*" -1139- PERFORM M_0122_120_DECLARA_SEGURADOS_DB_DECLARE_1 */

            M_0122_120_DECLARA_SEGURADOS_DB_DECLARE_1();

            /*" -1142- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1143- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -1144- DISPLAY '  VG0122B - ERRO NO JOIN SEGURAVG/CLIENTE' */
                _.Display($"  VG0122B - ERRO NO JOIN SEGURAVG/CLIENTE");

                /*" -1145- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1147- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1149- MOVE 'OPEN ...  CURSOR   SEGURADO2     ' TO COMANDO. */
            _.Move("OPEN ...  CURSOR   SEGURADO2     ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1150- PERFORM M_0122_120_DECLARA_SEGURADOS_DB_OPEN_1 */

            M_0122_120_DECLARA_SEGURADOS_DB_OPEN_1();

            /*" -1153- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1153- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0122-120-DECLARA-SEGURADOS-DB-OPEN-1 */
        public void M_0122_120_DECLARA_SEGURADOS_DB_OPEN_1()
        {
            /*" -1150- EXEC SQL OPEN SEGURADO2 END-EXEC. */

            SEGURADO2.Open();

        }

        [StopWatch]
        /*" M-0123-120-DECLARA-SEGURADOS-DB-DECLARE-1 */
        public void M_0123_120_DECLARA_SEGURADOS_DB_DECLARE_1()
        {
            /*" -1185- EXEC SQL DECLARE SEGURADO3 CURSOR FOR SELECT T1.NUM_APOLICE , T1.COD_SUBGRUPO , T1.COD_CLIENTE , T1.NUM_CERTIFICADO , T1.DAC_CERTIFICADO , T1.TIPO_SEGURADO , T1.NUM_ITEM , T1.OCORR_HISTORICO , T1.ESTADO_CIVIL , T1.IDE_SEXO , T1.NUM_MATRICULA , T1.DATA_INIVIGENCIA , T1.SIT_REGISTRO , T1.DATA_NASCIMENTO , T2.COD_CLIENTE , T2.NOME_RAZAO , T2.CGCCPF FROM SEGUROS.V1SEGURAVG T1, SEGUROS.V1CLIENTE T2 WHERE T1.COD_CLIENTE = T2.COD_CLIENTE AND T1.NUM_APOLICE = :RELAT-NUM-APOLICE AND T1.COD_SUBGRUPO >= :AUX-SUBGRUPO-I AND T1.COD_SUBGRUPO <= :AUX-SUBGRUPO-F AND T1.TIPO_SEGURADO = '1' ORDER BY T1.NUM_CERTIFICADO END-EXEC. */
            SEGURADO3 = new VG0122B_SEGURADO3(true);
            string GetQuery_SEGURADO3()
            {
                var query = @$"SELECT T1.NUM_APOLICE
							, 
							T1.COD_SUBGRUPO
							, 
							T1.COD_CLIENTE
							, 
							T1.NUM_CERTIFICADO
							, 
							T1.DAC_CERTIFICADO
							, 
							T1.TIPO_SEGURADO
							, 
							T1.NUM_ITEM
							, 
							T1.OCORR_HISTORICO
							, 
							T1.ESTADO_CIVIL
							, 
							T1.IDE_SEXO
							, 
							T1.NUM_MATRICULA
							, 
							T1.DATA_INIVIGENCIA
							, 
							T1.SIT_REGISTRO
							, 
							T1.DATA_NASCIMENTO
							, 
							T2.COD_CLIENTE
							, 
							T2.NOME_RAZAO
							, 
							T2.CGCCPF 
							FROM SEGUROS.V1SEGURAVG T1
							, 
							SEGUROS.V1CLIENTE T2 
							WHERE T1.COD_CLIENTE = T2.COD_CLIENTE 
							AND T1.NUM_APOLICE = '{RELAT_NUM_APOLICE}' 
							AND T1.COD_SUBGRUPO >= '{AUX_SUBGRUPO_I}' 
							AND T1.COD_SUBGRUPO <= '{AUX_SUBGRUPO_F}' 
							AND T1.TIPO_SEGURADO = '1' 
							ORDER BY T1.NUM_CERTIFICADO";

                return query;
            }
            SEGURADO3.GetQueryEvent += GetQuery_SEGURADO3;

        }

        [StopWatch]
        /*" M-0123-120-DECLARA-SEGURADOS-SECTION */
        private void M_0123_120_DECLARA_SEGURADOS_SECTION()
        {
            /*" -1185- PERFORM M_0123_120_DECLARA_SEGURADOS_DB_DECLARE_1 */

            M_0123_120_DECLARA_SEGURADOS_DB_DECLARE_1();

            /*" -1188- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1189- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -1190- DISPLAY '  VG0122B - ERRO NO JOIN SEGURAVG/CLIENTE' */
                _.Display($"  VG0122B - ERRO NO JOIN SEGURAVG/CLIENTE");

                /*" -1191- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1193- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1195- MOVE 'OPEN ...  CURSOR   SEGURADO3     ' TO COMANDO. */
            _.Move("OPEN ...  CURSOR   SEGURADO3     ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1196- PERFORM M_0123_120_DECLARA_SEGURADOS_DB_OPEN_1 */

            M_0123_120_DECLARA_SEGURADOS_DB_OPEN_1();

            /*" -1199- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1201- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0123-120-DECLARA-SEGURADOS-DB-OPEN-1 */
        public void M_0123_120_DECLARA_SEGURADOS_DB_OPEN_1()
        {
            /*" -1196- EXEC SQL OPEN SEGURADO3 END-EXEC. */

            SEGURADO3.Open();

        }

        [StopWatch]
        /*" M-0130-040-FETCH-SEGURADO-SECTION */
        private void M_0130_040_FETCH_SEGURADO_SECTION()
        {
            /*" -1206- MOVE '0130-040-FETCH-SEGURADO            ' TO PARAGRAFO. */
            _.Move("0130-040-FETCH-SEGURADO            ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1210- MOVE 'FETCH.... FROM SEGUROS.V1SEGURAVG  ' TO COMANDO. */
            _.Move("FETCH.... FROM SEGUROS.V1SEGURAVG  ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1211- IF RELAT-OPERACAO EQUAL 0001 */

            if (RELAT_OPERACAO == 0001)
            {

                /*" -1212- PERFORM 0131-130-FETCH-SEGURADO */

                M_0131_130_FETCH_SEGURADO_SECTION();

                /*" -1213- ELSE */
            }
            else
            {


                /*" -1214- IF RELAT-OPERACAO EQUAL 0002 */

                if (RELAT_OPERACAO == 0002)
                {

                    /*" -1215- PERFORM 0132-130-FETCH-SEGURADO */

                    M_0132_130_FETCH_SEGURADO_SECTION();

                    /*" -1216- ELSE */
                }
                else
                {


                    /*" -1217- IF RELAT-OPERACAO EQUAL 0003 */

                    if (RELAT_OPERACAO == 0003)
                    {

                        /*" -1219- PERFORM 0133-130-FETCH-SEGURADO. */

                        M_0133_130_FETCH_SEGURADO_SECTION();
                    }

                }

            }


            /*" -1220- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1221- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -1222- DISPLAY 'ATENCAO -----------------------------------' */
                    _.Display($"ATENCAO -----------------------------------");

                    /*" -1223- DISPLAY '    VG0122B - ERRO NO FETCH NO SEGURADO   ' */
                    _.Display($"    VG0122B - ERRO NO FETCH NO SEGURADO   ");

                    /*" -1224- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -1225- GO TO 9999-999-ERRO */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1226- ELSE */
                }
                else
                {


                    /*" -1227- MOVE 1 TO FLAG-FIM-SEGURADO */
                    _.Move(1, FLAG_FIM_SEGURADO);

                    /*" -1228- ELSE */
                }

            }
            else
            {


                /*" -1228- MOVE 1 TO FLAG-EXISTE-SEGUR. */
                _.Move(1, FLAG_EXISTE_SEGUR);
            }


        }

        [StopWatch]
        /*" M-0131-130-FETCH-SEGURADO-SECTION */
        private void M_0131_130_FETCH_SEGURADO_SECTION()
        {
            /*" -1251- PERFORM M_0131_130_FETCH_SEGURADO_DB_FETCH_1 */

            M_0131_130_FETCH_SEGURADO_DB_FETCH_1();

        }

        [StopWatch]
        /*" M-0131-130-FETCH-SEGURADO-DB-FETCH-1 */
        public void M_0131_130_FETCH_SEGURADO_DB_FETCH_1()
        {
            /*" -1251- EXEC SQL FETCH SEGURADO1 INTO :SEGURAVG-NUM-APOL , :SEGURAVG-COD-SUBG , :SEGURAVG-COD-CLI , :SEGURAVG-NUM-CERT , :SEGURAVG-DAC-CERT , :SEGURAVG-TIPO-SEG , :SEGURAVG-NUM-ITEM , :SEGURAVG-OCORR-HI , :SEGURAVG-EST-CIVIL , :SEGURAVG-IDE-SEXO , :SEGURAVG-MATRICULA , :SEGURAVG-DT-INIVI , :SEGURAVG-SIT-REG , :SEGURAVG-DT-NASCI , :CLIENTE-COD-CLI , :CLIENTE-NOME-RAZAO , :CLIENTE-CGC-CPF END-EXEC. */

            if (SEGURADO1.Fetch())
            {
                _.Move(SEGURADO1.SEGURAVG_NUM_APOL, SEGURAVG_NUM_APOL);
                _.Move(SEGURADO1.SEGURAVG_COD_SUBG, SEGURAVG_COD_SUBG);
                _.Move(SEGURADO1.SEGURAVG_COD_CLI, SEGURAVG_COD_CLI);
                _.Move(SEGURADO1.SEGURAVG_NUM_CERT, SEGURAVG_NUM_CERT);
                _.Move(SEGURADO1.SEGURAVG_DAC_CERT, SEGURAVG_DAC_CERT);
                _.Move(SEGURADO1.SEGURAVG_TIPO_SEG, SEGURAVG_TIPO_SEG);
                _.Move(SEGURADO1.SEGURAVG_NUM_ITEM, SEGURAVG_NUM_ITEM);
                _.Move(SEGURADO1.SEGURAVG_OCORR_HI, SEGURAVG_OCORR_HI);
                _.Move(SEGURADO1.SEGURAVG_EST_CIVIL, SEGURAVG_EST_CIVIL);
                _.Move(SEGURADO1.SEGURAVG_IDE_SEXO, SEGURAVG_IDE_SEXO);
                _.Move(SEGURADO1.SEGURAVG_MATRICULA, SEGURAVG_MATRICULA);
                _.Move(SEGURADO1.SEGURAVG_DT_INIVI, SEGURAVG_DT_INIVI);
                _.Move(SEGURADO1.SEGURAVG_SIT_REG, SEGURAVG_SIT_REG);
                _.Move(SEGURADO1.SEGURAVG_DT_NASCI, SEGURAVG_DT_NASCI);
                _.Move(SEGURADO1.CLIENTE_COD_CLI, CLIENTE_COD_CLI);
                _.Move(SEGURADO1.CLIENTE_NOME_RAZAO, CLIENTE_NOME_RAZAO);
                _.Move(SEGURADO1.CLIENTE_CGC_CPF, CLIENTE_CGC_CPF);
            }

        }

        [StopWatch]
        /*" M-0132-130-FETCH-SEGURADO-SECTION */
        private void M_0132_130_FETCH_SEGURADO_SECTION()
        {
            /*" -1275- PERFORM M_0132_130_FETCH_SEGURADO_DB_FETCH_1 */

            M_0132_130_FETCH_SEGURADO_DB_FETCH_1();

        }

        [StopWatch]
        /*" M-0132-130-FETCH-SEGURADO-DB-FETCH-1 */
        public void M_0132_130_FETCH_SEGURADO_DB_FETCH_1()
        {
            /*" -1275- EXEC SQL FETCH SEGURADO2 INTO :SEGURAVG-NUM-APOL , :SEGURAVG-COD-SUBG , :SEGURAVG-COD-CLI , :SEGURAVG-NUM-CERT , :SEGURAVG-DAC-CERT , :SEGURAVG-TIPO-SEG , :SEGURAVG-NUM-ITEM , :SEGURAVG-OCORR-HI , :SEGURAVG-EST-CIVIL , :SEGURAVG-IDE-SEXO , :SEGURAVG-MATRICULA , :SEGURAVG-DT-INIVI , :SEGURAVG-SIT-REG , :SEGURAVG-DT-NASCI , :CLIENTE-COD-CLI , :CLIENTE-NOME-RAZAO , :CLIENTE-CGC-CPF END-EXEC. */

            if (SEGURADO2.Fetch())
            {
                _.Move(SEGURADO2.SEGURAVG_NUM_APOL, SEGURAVG_NUM_APOL);
                _.Move(SEGURADO2.SEGURAVG_COD_SUBG, SEGURAVG_COD_SUBG);
                _.Move(SEGURADO2.SEGURAVG_COD_CLI, SEGURAVG_COD_CLI);
                _.Move(SEGURADO2.SEGURAVG_NUM_CERT, SEGURAVG_NUM_CERT);
                _.Move(SEGURADO2.SEGURAVG_DAC_CERT, SEGURAVG_DAC_CERT);
                _.Move(SEGURADO2.SEGURAVG_TIPO_SEG, SEGURAVG_TIPO_SEG);
                _.Move(SEGURADO2.SEGURAVG_NUM_ITEM, SEGURAVG_NUM_ITEM);
                _.Move(SEGURADO2.SEGURAVG_OCORR_HI, SEGURAVG_OCORR_HI);
                _.Move(SEGURADO2.SEGURAVG_EST_CIVIL, SEGURAVG_EST_CIVIL);
                _.Move(SEGURADO2.SEGURAVG_IDE_SEXO, SEGURAVG_IDE_SEXO);
                _.Move(SEGURADO2.SEGURAVG_MATRICULA, SEGURAVG_MATRICULA);
                _.Move(SEGURADO2.SEGURAVG_DT_INIVI, SEGURAVG_DT_INIVI);
                _.Move(SEGURADO2.SEGURAVG_SIT_REG, SEGURAVG_SIT_REG);
                _.Move(SEGURADO2.SEGURAVG_DT_NASCI, SEGURAVG_DT_NASCI);
                _.Move(SEGURADO2.CLIENTE_COD_CLI, CLIENTE_COD_CLI);
                _.Move(SEGURADO2.CLIENTE_NOME_RAZAO, CLIENTE_NOME_RAZAO);
                _.Move(SEGURADO2.CLIENTE_CGC_CPF, CLIENTE_CGC_CPF);
            }

        }

        [StopWatch]
        /*" M-0133-130-FETCH-SEGURADO-SECTION */
        private void M_0133_130_FETCH_SEGURADO_SECTION()
        {
            /*" -1298- PERFORM M_0133_130_FETCH_SEGURADO_DB_FETCH_1 */

            M_0133_130_FETCH_SEGURADO_DB_FETCH_1();

        }

        [StopWatch]
        /*" M-0133-130-FETCH-SEGURADO-DB-FETCH-1 */
        public void M_0133_130_FETCH_SEGURADO_DB_FETCH_1()
        {
            /*" -1298- EXEC SQL FETCH SEGURADO3 INTO :SEGURAVG-NUM-APOL , :SEGURAVG-COD-SUBG , :SEGURAVG-COD-CLI , :SEGURAVG-NUM-CERT , :SEGURAVG-DAC-CERT , :SEGURAVG-TIPO-SEG , :SEGURAVG-NUM-ITEM , :SEGURAVG-OCORR-HI , :SEGURAVG-EST-CIVIL , :SEGURAVG-IDE-SEXO , :SEGURAVG-MATRICULA , :SEGURAVG-DT-INIVI , :SEGURAVG-SIT-REG , :SEGURAVG-DT-NASCI , :CLIENTE-COD-CLI , :CLIENTE-NOME-RAZAO , :CLIENTE-CGC-CPF END-EXEC. */

            if (SEGURADO3.Fetch())
            {
                _.Move(SEGURADO3.SEGURAVG_NUM_APOL, SEGURAVG_NUM_APOL);
                _.Move(SEGURADO3.SEGURAVG_COD_SUBG, SEGURAVG_COD_SUBG);
                _.Move(SEGURADO3.SEGURAVG_COD_CLI, SEGURAVG_COD_CLI);
                _.Move(SEGURADO3.SEGURAVG_NUM_CERT, SEGURAVG_NUM_CERT);
                _.Move(SEGURADO3.SEGURAVG_DAC_CERT, SEGURAVG_DAC_CERT);
                _.Move(SEGURADO3.SEGURAVG_TIPO_SEG, SEGURAVG_TIPO_SEG);
                _.Move(SEGURADO3.SEGURAVG_NUM_ITEM, SEGURAVG_NUM_ITEM);
                _.Move(SEGURADO3.SEGURAVG_OCORR_HI, SEGURAVG_OCORR_HI);
                _.Move(SEGURADO3.SEGURAVG_EST_CIVIL, SEGURAVG_EST_CIVIL);
                _.Move(SEGURADO3.SEGURAVG_IDE_SEXO, SEGURAVG_IDE_SEXO);
                _.Move(SEGURADO3.SEGURAVG_MATRICULA, SEGURAVG_MATRICULA);
                _.Move(SEGURADO3.SEGURAVG_DT_INIVI, SEGURAVG_DT_INIVI);
                _.Move(SEGURADO3.SEGURAVG_SIT_REG, SEGURAVG_SIT_REG);
                _.Move(SEGURADO3.SEGURAVG_DT_NASCI, SEGURAVG_DT_NASCI);
                _.Move(SEGURADO3.CLIENTE_COD_CLI, CLIENTE_COD_CLI);
                _.Move(SEGURADO3.CLIENTE_NOME_RAZAO, CLIENTE_NOME_RAZAO);
                _.Move(SEGURADO3.CLIENTE_CGC_CPF, CLIENTE_CGC_CPF);
            }

        }

        [StopWatch]
        /*" M-0140-040-060-ACESSA-HISTSEGVG-SECTION */
        private void M_0140_040_060_ACESSA_HISTSEGVG_SECTION()
        {
            /*" -1304- MOVE '0140-040-ACESSA-HISTSEGVG          ' TO PARAGRAFO. */
            _.Move("0140-040-ACESSA-HISTSEGVG          ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1306- MOVE 'SELECT... FROM SEGUROS.V1HISTSEGVG ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1HISTSEGVG ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1325- PERFORM M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1 */

            M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1();

            /*" -1328- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1329- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -1330- DISPLAY '    VG0122B - ERRO NO ACESSO A V1HISTSEGVG' */
                _.Display($"    VG0122B - ERRO NO ACESSO A V1HISTSEGVG");

                /*" -1331- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1331- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0140-040-060-ACESSA-HISTSEGVG-DB-SELECT-1 */
        public void M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1()
        {
            /*" -1325- EXEC SQL SELECT NUM_APOLICE , NUM_ITEM , COD_OPERACAO , DATA_MOVIMENTO , OCORR_HISTORICO , COD_MOEDA_IMP , COD_MOEDA_PRM INTO :HISTSEGVG-NUM-APOL , :HISTSEGVG-NUM-ITEM , :HISTSEGVG-COD-OPER , :HISTSEGVG-DATA-MOV , :HISTSEGVG-OCORR-HI , :HISTSEGVG-COD-MOEDA-IMP , :HISTSEGVG-COD-MOEDA-PRM FROM SEGUROS.V1HISTSEGVG WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL AND NUM_ITEM = :SEGURAVG-NUM-ITEM AND OCORR_HISTORICO = :SEGURAVG-OCORR-HI END-EXEC. */

            var m_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1 = new M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
                SEGURAVG_NUM_ITEM = SEGURAVG_NUM_ITEM.ToString(),
                SEGURAVG_OCORR_HI = SEGURAVG_OCORR_HI.ToString(),
            };

            var executed_1 = M_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1.Execute(m_0140_040_060_ACESSA_HISTSEGVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.HISTSEGVG_NUM_APOL, HISTSEGVG_NUM_APOL);
                _.Move(executed_1.HISTSEGVG_NUM_ITEM, HISTSEGVG_NUM_ITEM);
                _.Move(executed_1.HISTSEGVG_COD_OPER, HISTSEGVG_COD_OPER);
                _.Move(executed_1.HISTSEGVG_DATA_MOV, HISTSEGVG_DATA_MOV);
                _.Move(executed_1.HISTSEGVG_OCORR_HI, HISTSEGVG_OCORR_HI);
                _.Move(executed_1.HISTSEGVG_COD_MOEDA_IMP, HISTSEGVG_COD_MOEDA_IMP);
                _.Move(executed_1.HISTSEGVG_COD_MOEDA_PRM, HISTSEGVG_COD_MOEDA_PRM);
            }


        }

        [StopWatch]
        /*" M-0145-020-060-ACESSA-MOEDA-IMP-SECTION */
        private void M_0145_020_060_ACESSA_MOEDA_IMP_SECTION()
        {
            /*" -1337- MOVE '0145-020-ACESSA-MOEDA-IMP          ' TO PARAGRAFO. */
            _.Move("0145-020-ACESSA-MOEDA-IMP          ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1339- MOVE 'SELECT... FROM SEGUROS.V1MOEDA     ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1MOEDA     ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1347- PERFORM M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1 */

            M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1();

            /*" -1350- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1351- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -1352- DISPLAY '    VG0122B - ERRO NO ACESSO A V1MOEDA    ' */
                _.Display($"    VG0122B - ERRO NO ACESSO A V1MOEDA    ");

                /*" -1353- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1354- GO TO 9999-999-ERRO */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;

                /*" -1355- ELSE */
            }
            else
            {


                /*" -1355- MOVE MOEDA-VLCRUZADO TO AUX-VLCRUZAD-IMP. */
                _.Move(MOEDA_VLCRUZADO, AUX_VLCRUZAD_IMP);
            }


        }

        [StopWatch]
        /*" M-0145-020-060-ACESSA-MOEDA-IMP-DB-SELECT-1 */
        public void M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1()
        {
            /*" -1347- EXEC SQL SELECT VLCRUZAD , DTINIVIG , DTTERVIG INTO :MOEDA-VLCRUZADO FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :HISTSEGVG-COD-MOEDA-IMP AND DTINIVIG <= :HISTSEGVG-DATA-MOV AND DTTERVIG >= :HISTSEGVG-DATA-MOV END-EXEC. */

            var m_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1 = new M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1()
            {
                HISTSEGVG_COD_MOEDA_IMP = HISTSEGVG_COD_MOEDA_IMP.ToString(),
                HISTSEGVG_DATA_MOV = HISTSEGVG_DATA_MOV.ToString(),
            };

            var executed_1 = M_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1.Execute(m_0145_020_060_ACESSA_MOEDA_IMP_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDA_VLCRUZADO, MOEDA_VLCRUZADO);
            }


        }

        [StopWatch]
        /*" M-0145-020-060-ACESSA-MOEDA-PRM-SECTION */
        private void M_0145_020_060_ACESSA_MOEDA_PRM_SECTION()
        {
            /*" -1362- MOVE '0145-020-ACESSA-MOEDA-PRM          ' TO PARAGRAFO. */
            _.Move("0145-020-ACESSA-MOEDA-PRM          ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1364- MOVE 'SELECT... FROM SEGUROS.V1MOEDA     ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1MOEDA     ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1372- PERFORM M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1 */

            M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1();

            /*" -1375- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1376- DISPLAY 'ATENCAO -----------------------------------' */
                _.Display($"ATENCAO -----------------------------------");

                /*" -1377- DISPLAY '    VG0122B - ERRO NO ACESSO A V1MOEDA    ' */
                _.Display($"    VG0122B - ERRO NO ACESSO A V1MOEDA    ");

                /*" -1378- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1379- GO TO 9999-999-ERRO */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;

                /*" -1380- ELSE */
            }
            else
            {


                /*" -1380- MOVE MOEDA-VLCRUZADO TO AUX-VLCRUZAD-PRM. */
                _.Move(MOEDA_VLCRUZADO, AUX_VLCRUZAD_PRM);
            }


        }

        [StopWatch]
        /*" M-0145-020-060-ACESSA-MOEDA-PRM-DB-SELECT-1 */
        public void M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1()
        {
            /*" -1372- EXEC SQL SELECT VLCRUZAD , DTINIVIG , DTTERVIG INTO :MOEDA-VLCRUZADO FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :HISTSEGVG-COD-MOEDA-PRM AND DTINIVIG <= :HISTSEGVG-DATA-MOV AND DTTERVIG >= :HISTSEGVG-DATA-MOV END-EXEC. */

            var m_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1 = new M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1()
            {
                HISTSEGVG_COD_MOEDA_PRM = HISTSEGVG_COD_MOEDA_PRM.ToString(),
                HISTSEGVG_DATA_MOV = HISTSEGVG_DATA_MOV.ToString(),
            };

            var executed_1 = M_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1.Execute(m_0145_020_060_ACESSA_MOEDA_PRM_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOEDA_VLCRUZADO, MOEDA_VLCRUZADO);
            }


        }

        [StopWatch]
        /*" M-0210-200-ACESSA-SEGURAVG-SECTION */
        private void M_0210_200_ACESSA_SEGURAVG_SECTION()
        {
            /*" -1389- MOVE '0210-200-ACESSA-SEGURAVG           ' TO PARAGRAFO. */
            _.Move("0210-200-ACESSA-SEGURAVG           ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1391- MOVE 'SELECT... FROM SEGUROS.V1SEGURAVG  ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1SEGURAVG  ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1393- MOVE SEGURAVG-NUM-CERT TO AUX-CERTIFICADO */
            _.Move(SEGURAVG_NUM_CERT, AUX_CERTIFICADO);

            /*" -1424- PERFORM M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1 */

            M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1();

            /*" -1427- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1428- IF SQLCODE NOT EQUAL +100 */

                if (DB.SQLCODE != +100)
                {

                    /*" -1429- DISPLAY 'ATENCAO -----------------------------------' */
                    _.Display($"ATENCAO -----------------------------------");

                    /*" -1430- DISPLAY '    VG0122B - ERRO NO ACESSO A V1SEGURAVG ' */
                    _.Display($"    VG0122B - ERRO NO ACESSO A V1SEGURAVG ");

                    /*" -1431- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -1432- GO TO 9999-999-ERRO */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1433- ELSE */
                }
                else
                {


                    /*" -1434- MOVE ZEROS TO FLAG-CONJUGE */
                    _.Move(0, FLAG_CONJUGE);

                    /*" -1435- ELSE */
                }

            }
            else
            {


                /*" -1437- MOVE 1 TO FLAG-CONJUGE. */
                _.Move(1, FLAG_CONJUGE);
            }


        }

        [StopWatch]
        /*" M-0210-200-ACESSA-SEGURAVG-DB-SELECT-1 */
        public void M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1()
        {
            /*" -1424- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , COD_CLIENTE , NUM_CERTIFICADO , DAC_CERTIFICADO , TIPO_SEGURADO , NUM_ITEM , OCORR_HISTORICO , ESTADO_CIVIL , IDE_SEXO , NUM_MATRICULA , DATA_INIVIGENCIA , SIT_REGISTRO , DATA_NASCIMENTO INTO :SEGURAVG-NUM-APOL , :SEGURAVG-COD-SUBG , :SEGURAVG-COD-CLI , :SEGURAVG-NUM-CERT , :SEGURAVG-DAC-CERT , :SEGURAVG-TIPO-SEG , :SEGURAVG-NUM-ITEM , :SEGURAVG-OCORR-HI , :SEGURAVG-EST-CIVIL , :SEGURAVG-IDE-SEXO , :SEGURAVG-MATRICULA , :SEGURAVG-DT-INIVI , :SEGURAVG-SIT-REG , :SEGURAVG-DT-NASCI FROM SEGUROS.V1SEGURAVG WHERE NUM_CERTIFICADO = :AUX-CERTIFICADO AND TIPO_SEGURADO = '2' END-EXEC. */

            var m_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1 = new M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1()
            {
                AUX_CERTIFICADO = AUX_CERTIFICADO.ToString(),
            };

            var executed_1 = M_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1.Execute(m_0210_200_ACESSA_SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SEGURAVG_NUM_APOL, SEGURAVG_NUM_APOL);
                _.Move(executed_1.SEGURAVG_COD_SUBG, SEGURAVG_COD_SUBG);
                _.Move(executed_1.SEGURAVG_COD_CLI, SEGURAVG_COD_CLI);
                _.Move(executed_1.SEGURAVG_NUM_CERT, SEGURAVG_NUM_CERT);
                _.Move(executed_1.SEGURAVG_DAC_CERT, SEGURAVG_DAC_CERT);
                _.Move(executed_1.SEGURAVG_TIPO_SEG, SEGURAVG_TIPO_SEG);
                _.Move(executed_1.SEGURAVG_NUM_ITEM, SEGURAVG_NUM_ITEM);
                _.Move(executed_1.SEGURAVG_OCORR_HI, SEGURAVG_OCORR_HI);
                _.Move(executed_1.SEGURAVG_EST_CIVIL, SEGURAVG_EST_CIVIL);
                _.Move(executed_1.SEGURAVG_IDE_SEXO, SEGURAVG_IDE_SEXO);
                _.Move(executed_1.SEGURAVG_MATRICULA, SEGURAVG_MATRICULA);
                _.Move(executed_1.SEGURAVG_DT_INIVI, SEGURAVG_DT_INIVI);
                _.Move(executed_1.SEGURAVG_SIT_REG, SEGURAVG_SIT_REG);
                _.Move(executed_1.SEGURAVG_DT_NASCI, SEGURAVG_DT_NASCI);
            }


        }

        [StopWatch]
        /*" M-0220-200-ACESSA-CLIENTES-SECTION */
        private void M_0220_200_ACESSA_CLIENTES_SECTION()
        {
            /*" -1442- MOVE '0220-200-ACESSA-CLIENTES           ' TO PARAGRAFO. */
            _.Move("0220-200-ACESSA-CLIENTES           ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1444- MOVE 'SELECT... FROM SEGUROS.V1SEGURAVG  ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1SEGURAVG  ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1452- PERFORM M_0220_200_ACESSA_CLIENTES_DB_SELECT_1 */

            M_0220_200_ACESSA_CLIENTES_DB_SELECT_1();

            /*" -1455- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1456- DISPLAY ' ATENCAO----------------------------------' */
                _.Display($" ATENCAO----------------------------------");

                /*" -1457- DISPLAY '    VG0122B - ERRO NO ACESSO A V1CLIENTES ' */
                _.Display($"    VG0122B - ERRO NO ACESSO A V1CLIENTES ");

                /*" -1458- DISPLAY '-------------------------------------------' */
                _.Display($"-------------------------------------------");

                /*" -1458- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0220-200-ACESSA-CLIENTES-DB-SELECT-1 */
        public void M_0220_200_ACESSA_CLIENTES_DB_SELECT_1()
        {
            /*" -1452- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , CGCCPF INTO :CLIENTE-COD-CLI , :CLIENTE-NOME-RAZAO, :CLIENTE-CGC-CPF FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :SEGURAVG-COD-CLI END-EXEC. */

            var m_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1 = new M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1()
            {
                SEGURAVG_COD_CLI = SEGURAVG_COD_CLI.ToString(),
            };

            var executed_1 = M_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1.Execute(m_0220_200_ACESSA_CLIENTES_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTE_COD_CLI, CLIENTE_COD_CLI);
                _.Move(executed_1.CLIENTE_NOME_RAZAO, CLIENTE_NOME_RAZAO);
                _.Move(executed_1.CLIENTE_CGC_CPF, CLIENTE_CGC_CPF);
            }


        }

        [StopWatch]
        /*" M-300-150-240-COBERTURAS-SECTION */
        private void M_300_150_240_COBERTURAS_SECTION()
        {
            /*" -1467- MOVE ZEROS TO AUX-VALORES. */
            _.Move(0, AUX_VALORES);

            /*" -1468- MOVE 'MORTE NATURAL ' TO AUX-TIPO-IMPORT */
            _.Move("MORTE NATURAL ", AUX_TIPO_IMPORT);

            /*" -1469- MOVE PARAM-RAMO-VG TO COBERAPOL-RAMO. */
            _.Move(PARAM_RAMO_VG, COBERAPOL_RAMO);

            /*" -1470- MOVE 11 TO COBERAPOL-COBERT. */
            _.Move(11, COBERAPOL_COBERT);

            /*" -1471- PERFORM 0310-300-ACESSA-V1COBERAPOL. */

            M_0310_300_ACESSA_V1COBERAPOL_SECTION();

            /*" -1475- COMPUTE AUX-MORTE-NATURAL = COBERAPOL-SEGUR-IX * AUX-VLCRUZAD-IMP * COBERAPOL-FATOR-MULTIPLICA */
            AUX_VALORES.AUX_MORTE_NATURAL.Value = COBERAPOL_SEGUR_IX * AUX_VLCRUZAD_IMP * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1480- COMPUTE LK-PREM-MORTE-NATURAL = COBERAPOL-PREM-IX * AUX-VLCRUZAD-PRM * COBERAPOL-FATOR-MULTIPLICA */
            LK_PREM_MORTE_NATURAL.Value = COBERAPOL_PREM_IX * AUX_VLCRUZAD_PRM * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1481- MOVE 'MORTE ACIDENTAL' TO AUX-TIPO-IMPORT */
            _.Move("MORTE ACIDENTAL", AUX_TIPO_IMPORT);

            /*" -1482- MOVE PARAM-RAMO-AP TO COBERAPOL-RAMO. */
            _.Move(PARAM_RAMO_AP, COBERAPOL_RAMO);

            /*" -1483- MOVE 1 TO COBERAPOL-COBERT. */
            _.Move(1, COBERAPOL_COBERT);

            /*" -1484- PERFORM 0310-300-ACESSA-V1COBERAPOL. */

            M_0310_300_ACESSA_V1COBERAPOL_SECTION();

            /*" -1489- COMPUTE AUX-MORTE-ACIDENTAL = COBERAPOL-SEGUR-IX * AUX-VLCRUZAD-IMP * COBERAPOL-FATOR-MULTIPLICA */
            AUX_VALORES.AUX_MORTE_ACIDENTAL.Value = COBERAPOL_SEGUR_IX * AUX_VLCRUZAD_IMP * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1494- COMPUTE AUX-PREM-MA = COBERAPOL-PREM-IX * AUX-VLCRUZAD-PRM * COBERAPOL-FATOR-MULTIPLICA */
            AUX_VALORES.AUX_PREM_MA.Value = COBERAPOL_PREM_IX * AUX_VLCRUZAD_PRM * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1495- MOVE 'INV PERMANENTE' TO AUX-TIPO-IMPORT */
            _.Move("INV PERMANENTE", AUX_TIPO_IMPORT);

            /*" -1496- MOVE PARAM-RAMO-AP TO COBERAPOL-RAMO. */
            _.Move(PARAM_RAMO_AP, COBERAPOL_RAMO);

            /*" -1497- MOVE 2 TO COBERAPOL-COBERT. */
            _.Move(2, COBERAPOL_COBERT);

            /*" -1498- PERFORM 0310-300-ACESSA-V1COBERAPOL. */

            M_0310_300_ACESSA_V1COBERAPOL_SECTION();

            /*" -1502- COMPUTE AUX-INV-PERMANENTE = COBERAPOL-SEGUR-IX * AUX-VLCRUZAD-IMP * COBERAPOL-FATOR-MULTIPLICA */
            AUX_VALORES.AUX_INV_PERMANENTE.Value = COBERAPOL_SEGUR_IX * AUX_VLCRUZAD_IMP * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1507- COMPUTE AUX-PREM-IP = COBERAPOL-PREM-IX * AUX-VLCRUZAD-PRM * COBERAPOL-FATOR-MULTIPLICA */
            AUX_VALORES.AUX_PREM_IP.Value = COBERAPOL_PREM_IX * AUX_VLCRUZAD_PRM * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1508- MOVE 'AMDS          ' TO AUX-TIPO-IMPORT */
            _.Move("AMDS          ", AUX_TIPO_IMPORT);

            /*" -1509- MOVE PARAM-RAMO-AP TO COBERAPOL-RAMO. */
            _.Move(PARAM_RAMO_AP, COBERAPOL_RAMO);

            /*" -1510- MOVE 3 TO COBERAPOL-COBERT. */
            _.Move(3, COBERAPOL_COBERT);

            /*" -1511- PERFORM 0310-300-ACESSA-V1COBERAPOL. */

            M_0310_300_ACESSA_V1COBERAPOL_SECTION();

            /*" -1515- COMPUTE AUX-AMDS = COBERAPOL-SEGUR-IX * AUX-VLCRUZAD-IMP * COBERAPOL-FATOR-MULTIPLICA */
            AUX_VALORES.AUX_AMDS.Value = COBERAPOL_SEGUR_IX * AUX_VLCRUZAD_IMP * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1520- COMPUTE AUX-PREM-AMDS = COBERAPOL-PREM-IX * AUX-VLCRUZAD-PRM * COBERAPOL-FATOR-MULTIPLICA */
            AUX_VALORES.AUX_PREM_AMDS.Value = COBERAPOL_PREM_IX * AUX_VLCRUZAD_PRM * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1521- MOVE 'DIARIA HOSPITAL' TO AUX-TIPO-IMPORT */
            _.Move("DIARIA HOSPITAL", AUX_TIPO_IMPORT);

            /*" -1522- MOVE PARAM-RAMO-AP TO COBERAPOL-RAMO. */
            _.Move(PARAM_RAMO_AP, COBERAPOL_RAMO);

            /*" -1523- MOVE 4 TO COBERAPOL-COBERT. */
            _.Move(4, COBERAPOL_COBERT);

            /*" -1524- PERFORM 0310-300-ACESSA-V1COBERAPOL. */

            M_0310_300_ACESSA_V1COBERAPOL_SECTION();

            /*" -1528- COMPUTE AUX-DIARIA-HOSP = COBERAPOL-SEGUR-IX * AUX-VLCRUZAD-IMP * COBERAPOL-FATOR-MULTIPLICA */
            AUX_VALORES.AUX_DIARIA_HOSP.Value = COBERAPOL_SEGUR_IX * AUX_VLCRUZAD_IMP * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1533- COMPUTE AUX-PREM-DH = COBERAPOL-PREM-IX * AUX-VLCRUZAD-PRM * COBERAPOL-FATOR-MULTIPLICA */
            AUX_VALORES.AUX_PREM_DH.Value = COBERAPOL_PREM_IX * AUX_VLCRUZAD_PRM * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1534- MOVE 'DIARIA INTERNACAO' TO AUX-TIPO-IMPORT */
            _.Move("DIARIA INTERNACAO", AUX_TIPO_IMPORT);

            /*" -1535- MOVE PARAM-RAMO-AP TO COBERAPOL-RAMO. */
            _.Move(PARAM_RAMO_AP, COBERAPOL_RAMO);

            /*" -1536- MOVE 5 TO COBERAPOL-COBERT. */
            _.Move(5, COBERAPOL_COBERT);

            /*" -1537- PERFORM 0310-300-ACESSA-V1COBERAPOL. */

            M_0310_300_ACESSA_V1COBERAPOL_SECTION();

            /*" -1541- COMPUTE AUX-DIARIA-INT = COBERAPOL-SEGUR-IX * AUX-VLCRUZAD-IMP * COBERAPOL-FATOR-MULTIPLICA */
            AUX_VALORES.AUX_DIARIA_INT.Value = COBERAPOL_SEGUR_IX * AUX_VLCRUZAD_IMP * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1545- COMPUTE AUX-PREM-DI = COBERAPOL-PREM-IX * AUX-VLCRUZAD-PRM * COBERAPOL-FATOR-MULTIPLICA */
            AUX_VALORES.AUX_PREM_DI.Value = COBERAPOL_PREM_IX * AUX_VLCRUZAD_PRM * COBERAPOL_FATOR_MULTIPLICA;

            /*" -1551- COMPUTE LK-PREM-ACIDENTES-PESSOAIS = AUX-PREM-MA + AUX-PREM-IP + AUX-PREM-AMDS + AUX-PREM-DH + AUX-PREM-DI. */
            LK_PREM_ACIDENTES_PESSOAIS.Value = AUX_VALORES.AUX_PREM_MA + AUX_VALORES.AUX_PREM_IP + AUX_VALORES.AUX_PREM_AMDS + AUX_VALORES.AUX_PREM_DH + AUX_VALORES.AUX_PREM_DI;

            /*" -1559- COMPUTE LK-PREM-TOTAL = LK-PREM-ACIDENTES-PESSOAIS + LK-PREM-MORTE-NATURAL. */
            LK_PREM_TOTAL.Value = LK_PREM_ACIDENTES_PESSOAIS + LK_PREM_MORTE_NATURAL;

            /*" -1570- PERFORM M_300_150_240_COBERTURAS_DB_SELECT_1 */

            M_300_150_240_COBERTURAS_DB_SELECT_1();

            /*" -1573- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1576- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1578- COMPUTE LK-COBT-MORTE-NATURAL = AUX-MORTE-NATURAL. */
            LK_COBT_MORTE_NATURAL.Value = AUX_VALORES.AUX_MORTE_NATURAL;

            /*" -1581- COMPUTE LK-COBT-MORTE-ACIDENTAL ROUNDED = AUX-MORTE-ACIDENTAL + AUX-MORTE-NATURAL. */
            LK_COBT_MORTE_ACIDENTAL.Value = AUX_VALORES.AUX_MORTE_ACIDENTAL + AUX_VALORES.AUX_MORTE_NATURAL;

            /*" -1585- COMPUTE LK-COBT-MORTE-ACIDENTAL ROUNDED = LK-COBT-MORTE-ACIDENTAL + (AUX-MORTE-NATURAL * CONDTEC-GAR-IEA) / 100. */
            LK_COBT_MORTE_ACIDENTAL.Value = LK_COBT_MORTE_ACIDENTAL + (AUX_VALORES.AUX_MORTE_NATURAL * CONDTEC_GAR_IEA) / 100f;

            /*" -1589- COMPUTE LK-COBT-INV-PERMANENTE ROUNDED = AUX-INV-PERMANENTE + (AUX-MORTE-NATURAL * CONDTEC-GAR-IPA) / 100. */
            LK_COBT_INV_PERMANENTE.Value = AUX_VALORES.AUX_INV_PERMANENTE + (AUX_VALORES.AUX_MORTE_NATURAL * CONDTEC_GAR_IPA) / 100f;

            /*" -1592- COMPUTE LK-COBT-INV-POR-DOENCA ROUNDED = (AUX-MORTE-NATURAL * CONDTEC-GAR-IPD) / 100. */
            LK_COBT_INV_POR_DOENCA.Value = (AUX_VALORES.AUX_MORTE_NATURAL * CONDTEC_GAR_IPD) / 100f;

            /*" -1594- COMPUTE LK-COBT-ASS-MEDICA = AUX-AMDS. */
            LK_COBT_ASS_MEDICA.Value = AUX_VALORES.AUX_AMDS;

            /*" -1596- COMPUTE LK-COBT-DIARIA-HOSPITALAR = AUX-DIARIA-HOSP. */
            LK_COBT_DIARIA_HOSPITALAR.Value = AUX_VALORES.AUX_DIARIA_HOSP;

            /*" -1596- COMPUTE LK-COBT-DIARIA-INTERNACAO = AUX-DIARIA-INT. */
            LK_COBT_DIARIA_INTERNACAO.Value = AUX_VALORES.AUX_DIARIA_INT;

        }

        [StopWatch]
        /*" M-300-150-240-COBERTURAS-DB-SELECT-1 */
        public void M_300_150_240_COBERTURAS_DB_SELECT_1()
        {
            /*" -1570- EXEC SQL SELECT GARAN_ADIC_IEA, GARAN_ADIC_IPA, GARAN_ADIC_IPD, GARAN_ADIC_HD INTO :CONDTEC-GAR-IEA, :CONDTEC-GAR-IPA, :CONDTEC-GAR-IPD, :CONDTEC-GAR-HD FROM SEGUROS.V1CONDTEC WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL AND COD_SUBGRUPO = :SEGURAVG-COD-SUBG END-EXEC. */

            var m_300_150_240_COBERTURAS_DB_SELECT_1_Query1 = new M_300_150_240_COBERTURAS_DB_SELECT_1_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
                SEGURAVG_COD_SUBG = SEGURAVG_COD_SUBG.ToString(),
            };

            var executed_1 = M_300_150_240_COBERTURAS_DB_SELECT_1_Query1.Execute(m_300_150_240_COBERTURAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONDTEC_GAR_IEA, CONDTEC_GAR_IEA);
                _.Move(executed_1.CONDTEC_GAR_IPA, CONDTEC_GAR_IPA);
                _.Move(executed_1.CONDTEC_GAR_IPD, CONDTEC_GAR_IPD);
                _.Move(executed_1.CONDTEC_GAR_HD, CONDTEC_GAR_HD);
            }


        }

        [StopWatch]
        /*" M-0310-300-ACESSA-V1COBERAPOL-SECTION */
        private void M_0310_300_ACESSA_V1COBERAPOL_SECTION()
        {
            /*" -1616- PERFORM M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1 */

            M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1();

            /*" -1619- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -1622- MOVE ZEROS TO COBERAPOL-SEGUR-IX COBERAPOL-PREM-IX COBERAPOL-FATOR-MULTIPLICA */
                _.Move(0, COBERAPOL_SEGUR_IX, COBERAPOL_PREM_IX, COBERAPOL_FATOR_MULTIPLICA);

                /*" -1623- ELSE */
            }
            else
            {


                /*" -1624- IF SQLCODE NOT EQUAL ZEROS */

                if (DB.SQLCODE != 00)
                {

                    /*" -1625- DISPLAY 'ATENCAO -----------------------------------' */
                    _.Display($"ATENCAO -----------------------------------");

                    /*" -1626- DISPLAY '    VG0122B - ERRO NO ACESSO A V1COBERAPOL ' */
                    _.Display($"    VG0122B - ERRO NO ACESSO A V1COBERAPOL ");

                    /*" -1627- DISPLAY '    PARA SE OBTER O VALOR ' AUX-TIPO-IMPORT */
                    _.Display($"    PARA SE OBTER O VALOR {AUX_TIPO_IMPORT}");

                    /*" -1628- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -1628- GO TO 9999-999-ERRO. */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-0310-300-ACESSA-V1COBERAPOL-DB-SELECT-1 */
        public void M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1()
        {
            /*" -1616- EXEC SQL SELECT IMP_SEGURADA_IX , PRM_TARIFARIO_IX , FATOR_MULTIPLICA INTO :COBERAPOL-SEGUR-IX, :COBERAPOL-PREM-IX, :COBERAPOL-FATOR-MULTIPLICA FROM SEGUROS.V1COBERAPOL WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL AND NRENDOS = 0 AND NUM_ITEM = :SEGURAVG-NUM-ITEM AND OCORHIST = :SEGURAVG-OCORR-HI AND RAMOFR = :COBERAPOL-RAMO AND MODALIFR = 0 AND COD_COBERTURA = :COBERAPOL-COBERT END-EXEC. */

            var m_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1 = new M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
                SEGURAVG_NUM_ITEM = SEGURAVG_NUM_ITEM.ToString(),
                SEGURAVG_OCORR_HI = SEGURAVG_OCORR_HI.ToString(),
                COBERAPOL_COBERT = COBERAPOL_COBERT.ToString(),
                COBERAPOL_RAMO = COBERAPOL_RAMO.ToString(),
            };

            var executed_1 = M_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1.Execute(m_0310_300_ACESSA_V1COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.COBERAPOL_SEGUR_IX, COBERAPOL_SEGUR_IX);
                _.Move(executed_1.COBERAPOL_PREM_IX, COBERAPOL_PREM_IX);
                _.Move(executed_1.COBERAPOL_FATOR_MULTIPLICA, COBERAPOL_FATOR_MULTIPLICA);
            }


        }

        [StopWatch]
        /*" M-0330-070-090-PESQUISA-SECTION */
        private void M_0330_070_090_PESQUISA_SECTION()
        {
            /*" -1637- SECTION. */

        }

        [StopWatch]
        /*" M-0340-070-090-TOTALIZA-SECTION */
        private void M_0340_070_090_TOTALIZA_SECTION()
        {
            /*" -1641- ADD 1 TO AC-VIDAS */
            AC_CAPITAIS.AC_VIDAS.Value = AC_CAPITAIS.AC_VIDAS + 1;

            /*" -1642- ADD 1 TO AC-EMITIDOS */
            AC_EMITIDOS.Value = AC_EMITIDOS + 1;

            /*" -1643- ADD LK-COBT-MORTE-NATURAL TO AC-MORTE-NATURAL. */
            AC_CAPITAIS.AC_MORTE_NATURAL.Value = AC_CAPITAIS.AC_MORTE_NATURAL + LK_COBT_MORTE_NATURAL;

            /*" -1644- ADD LK-COBT-MORTE-ACIDENTAL TO AC-MORTE-ACIDENTAL. */
            AC_CAPITAIS.AC_MORTE_ACIDENTAL.Value = AC_CAPITAIS.AC_MORTE_ACIDENTAL + LK_COBT_MORTE_ACIDENTAL;

            /*" -1645- ADD LK-COBT-INV-PERMANENTE TO AC-INV-PERMANENTE. */
            AC_CAPITAIS.AC_INV_PERMANENTE.Value = AC_CAPITAIS.AC_INV_PERMANENTE + LK_COBT_INV_PERMANENTE;

            /*" -1646- ADD LK-COBT-ASS-MEDICA TO AC-ASS-MEDICA. */
            AC_CAPITAIS.AC_ASS_MEDICA.Value = AC_CAPITAIS.AC_ASS_MEDICA + LK_COBT_ASS_MEDICA;

            /*" -1647- ADD LK-COBT-DIARIA-HOSPITALAR TO AC-DIARIA-HOSPITALAR. */
            AC_CAPITAIS.AC_DIARIA_HOSPITALAR.Value = AC_CAPITAIS.AC_DIARIA_HOSPITALAR + LK_COBT_DIARIA_HOSPITALAR;

            /*" -1648- ADD LK-COBT-DIARIA-INTERNACAO TO AC-DIARIA-INTERNACAO. */
            AC_CAPITAIS.AC_DIARIA_INTERNACAO.Value = AC_CAPITAIS.AC_DIARIA_INTERNACAO + LK_COBT_DIARIA_INTERNACAO;

            /*" -1649- ADD LK-PREM-MORTE-NATURAL TO AC-PREM-MORTE-NATURAL. */
            AC_CAPITAIS.AC_PREM_MORTE_NATURAL.Value = AC_CAPITAIS.AC_PREM_MORTE_NATURAL + LK_PREM_MORTE_NATURAL;

            /*" -1649- ADD LK-PREM-ACIDENTES-PESSOAIS TO AC-PREM-ACID-PESSOAIS. */
            AC_CAPITAIS.AC_PREM_ACID_PESSOAIS.Value = AC_CAPITAIS.AC_PREM_ACID_PESSOAIS + LK_PREM_ACIDENTES_PESSOAIS;

        }

        [StopWatch]
        /*" M-0400-020-MONTA-ESTIPULANTE-SECTION */
        private void M_0400_020_MONTA_ESTIPULANTE_SECTION()
        {
            /*" -1656- MOVE RELAT-NUM-APOLICE TO AUX-APOLICE */
            _.Move(RELAT_NUM_APOLICE, AUX_APOLICE);

            /*" -1657- MOVE ZEROS TO AUX-SUBGRUPO */
            _.Move(0, AUX_SUBGRUPO);

            /*" -1658- PERFORM 0410-400-ACESSA-ESTIPULANTE. */

            M_0410_400_ACESSA_ESTIPULANTE_SECTION();

            /*" -1659- MOVE RELAT-NUM-APOLICE TO CAB5-APOLICE */
            _.Move(RELAT_NUM_APOLICE, CAB_5.CAB5_APOLICE);

            /*" -1660- MOVE CLIENTE-NOME-RAZAO TO CAB5-ESTIP */
            _.Move(CLIENTE_NOME_RAZAO, CAB_5.CAB5_ESTIP);

            /*" -1660- MOVE SPACES TO CAB5-RESTO. */
            _.Move("", CAB_5.CAB5_RESTO);

        }

        [StopWatch]
        /*" M-0410-400-ACESSA-ESTIPULANTE-SECTION */
        private void M_0410_400_ACESSA_ESTIPULANTE_SECTION()
        {
            /*" -1665- MOVE '0410-400-MONTA-ESTIPULANTE         ' TO PARAGRAFO. */
            _.Move("0410-400-MONTA-ESTIPULANTE         ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1667- MOVE 'SELECT... FROM SEGUROS.V1SUBGRUPO  ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1SUBGRUPO  ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1677- PERFORM M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1 */

            M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1();

            /*" -1681- MOVE 'SELECT... FROM SEGUROS.V1CLIENTES  ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V1CLIENTES  ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1689- PERFORM M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2 */

            M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2();

        }

        [StopWatch]
        /*" M-0410-400-ACESSA-ESTIPULANTE-DB-SELECT-1 */
        public void M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1()
        {
            /*" -1677- EXEC SQL SELECT NUM_APOLICE, COD_SUBGRUPO, COD_CLIENTE INTO :SUBGRUPO-NUM-APOL, :SUBGRUPO-COD-SUBG, :SUBGRUPO-COD-CLI FROM SEGUROS.V1SUBGRUPO WHERE NUM_APOLICE = :AUX-APOLICE AND COD_SUBGRUPO = :AUX-SUBGRUPO END-EXEC. */

            var m_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1 = new M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1()
            {
                AUX_SUBGRUPO = AUX_SUBGRUPO.ToString(),
                AUX_APOLICE = AUX_APOLICE.ToString(),
            };

            var executed_1 = M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1.Execute(m_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBGRUPO_NUM_APOL, SUBGRUPO_NUM_APOL);
                _.Move(executed_1.SUBGRUPO_COD_SUBG, SUBGRUPO_COD_SUBG);
                _.Move(executed_1.SUBGRUPO_COD_CLI, SUBGRUPO_COD_CLI);
            }


        }

        [StopWatch]
        /*" M-0450-020-ACESSA-CTA-CORRENTE-SECTION */
        private void M_0450_020_ACESSA_CTA_CORRENTE_SECTION()
        {
            /*" -1695- MOVE '0450-020-ACESA-CTA-CORRENTE' TO PARAGRAFO. */
            _.Move("0450-020-ACESA-CTA-CORRENTE", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1697- MOVE 'SELECT... FROM SEGUROS.V0CONTACOR  ' TO COMANDO. */
            _.Move("SELECT... FROM SEGUROS.V0CONTACOR  ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1708- PERFORM M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1 */

            M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1();

            /*" -1711- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1712- IF SQLCODE = +100 */

                if (DB.SQLCODE == +100)
                {

                    /*" -1713- MOVE SPACES TO DET3-CONTA-CORRENTE */
                    _.Move("", DET_3.DET3_CONTA_CORRENTE);

                    /*" -1714- ELSE */
                }
                else
                {


                    /*" -1715- DISPLAY 'ATENCAO -----------------------------------' */
                    _.Display($"ATENCAO -----------------------------------");

                    /*" -1716- DISPLAY '    VG0122B - ERRO NO ACESSO A V0CONTACOR ' */
                    _.Display($"    VG0122B - ERRO NO ACESSO A V0CONTACOR ");

                    /*" -1717- DISPLAY '-------------------------------------------' */
                    _.Display($"-------------------------------------------");

                    /*" -1718- GO TO 9999-999-ERRO */

                    M_9999_999_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1719- ELSE */
                }

            }
            else
            {


                /*" -1720- MOVE CONTACOR-AGENCIA TO DET3-AGENCIA */
                _.Move(CONTACOR_AGENCIA, DET_3.DET3_CONTA_CORRENTE.DET3_AGENCIA);

                /*" -1721- MOVE CONTACOR-CTA-COR TO CONTA-CORRENTE */
                _.Move(CONTACOR_CTA_COR, CONTA_CORRENTE);

                /*" -1722- MOVE CTA-OPERACAO TO DET3-OPERACAO */
                _.Move(CTA_CORR.CTA_OPERACAO, DET_3.DET3_CONTA_CORRENTE.DET3_OPERACAO);

                /*" -1723- MOVE CTA-NUM-CONTA TO DET3-CTA-CORR */
                _.Move(CTA_CORR.CTA_NUM_CONTA, DET_3.DET3_CONTA_CORRENTE.DET3_CTA_CORR);

                /*" -1724- MOVE ' - ' TO DET3-TRACO */
                _.Move(" - ", DET_3.DET3_CONTA_CORRENTE.DET3_TRACO);

                /*" -1724- MOVE CONTACOR-DAC TO DET3-DAC-CONTA. */
                _.Move(CONTACOR_DAC, DET_3.DET3_CONTA_CORRENTE.DET3_DAC_CONTA);
            }


        }

        [StopWatch]
        /*" M-0450-020-ACESSA-CTA-CORRENTE-DB-SELECT-1 */
        public void M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1()
        {
            /*" -1708- EXEC SQL SELECT COD_BANCO , COD_AGENCIA , NUM_CTA_CORRENTE , DAC_CTA_CORRENTE INTO :CONTACOR-BANCO , :CONTACOR-AGENCIA , :CONTACOR-CTA-COR , :CONTACOR-DAC FROM SEGUROS.V0CONTACOR WHERE NUM_APOLICE = :SEGURAVG-NUM-APOL AND NUM_CERTIFICADO = :SEGURAVG-NUM-CERT END-EXEC. */

            var m_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1 = new M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1()
            {
                SEGURAVG_NUM_APOL = SEGURAVG_NUM_APOL.ToString(),
                SEGURAVG_NUM_CERT = SEGURAVG_NUM_CERT.ToString(),
            };

            var executed_1 = M_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1.Execute(m_0450_020_ACESSA_CTA_CORRENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CONTACOR_BANCO, CONTACOR_BANCO);
                _.Move(executed_1.CONTACOR_AGENCIA, CONTACOR_AGENCIA);
                _.Move(executed_1.CONTACOR_CTA_COR, CONTACOR_CTA_COR);
                _.Move(executed_1.CONTACOR_DAC, CONTACOR_DAC);
            }


        }

        [StopWatch]
        /*" M-0410-400-ACESSA-ESTIPULANTE-DB-SELECT-2 */
        public void M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2()
        {
            /*" -1689- EXEC SQL SELECT COD_CLIENTE , NOME_RAZAO , CGCCPF INTO :CLIENTE-COD-CLI , :CLIENTE-NOME-RAZAO, :CLIENTE-CGC-CPF FROM SEGUROS.V1CLIENTE WHERE COD_CLIENTE = :SUBGRUPO-COD-CLI END-EXEC. */

            var m_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1 = new M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1()
            {
                SUBGRUPO_COD_CLI = SUBGRUPO_COD_CLI.ToString(),
            };

            var executed_1 = M_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1.Execute(m_0410_400_ACESSA_ESTIPULANTE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CLIENTE_COD_CLI, CLIENTE_COD_CLI);
                _.Move(executed_1.CLIENTE_NOME_RAZAO, CLIENTE_NOME_RAZAO);
                _.Move(executed_1.CLIENTE_CGC_CPF, CLIENTE_CGC_CPF);
            }


        }

        [StopWatch]
        /*" M-0500-070-090-IMPRIME-DETALHES-SECTION */
        private void M_0500_070_090_IMPRIME_DETALHES_SECTION()
        {
            /*" -1729- IF AC-LINHAS GREATER 55 */

            if (AC_LINHAS > 55)
            {

                /*" -1730- PERFORM 0600-500-000-IMPRIME-CABECALHO. */

                M_0600_500_000_IMPRIME_CABECALHO_SECTION();
            }


            /*" -1731- ADD 3 TO AC-LINHAS. */
            AC_LINHAS.Value = AC_LINHAS + 3;

            /*" -1732- WRITE REG-IMPRESSAO FROM DET-1. */
            _.Move(DET_1.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1733- WRITE REG-IMPRESSAO FROM DET-2. */
            _.Move(DET_2.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1733- WRITE REG-IMPRESSAO FROM DET-3. */
            _.Move(DET_3.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-0510-000-IMPRIME-MENSAGEM-SECTION */
        private void M_0510_000_IMPRIME_MENSAGEM_SECTION()
        {
            /*" -1738- WRITE REG-IMPRESSAO FROM MENSAGEM AFTER 3 */
            _.Move(MENSAGEM.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1738- WRITE REG-IMPRESSAO FROM TRACO. */
            _.Move(TRACO.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }

        [StopWatch]
        /*" M-0520-020-IMPRIME-TOTAIS-SECTION */
        private void M_0520_020_IMPRIME_TOTAIS_SECTION()
        {
            /*" -1745- MOVE AC-VIDAS TO TOT1-VIDAS. */
            _.Move(AC_CAPITAIS.AC_VIDAS, TOT_DET_2.TOT1_VIDAS);

            /*" -1746- MOVE AC-MORTE-NATURAL TO TOT1-CAP-VG. */
            _.Move(AC_CAPITAIS.AC_MORTE_NATURAL, TOT_DET_1.TOT1_CAP_VG);

            /*" -1747- MOVE AC-MORTE-ACIDENTAL TO TOT1-CAP-MA. */
            _.Move(AC_CAPITAIS.AC_MORTE_ACIDENTAL, TOT_DET_2.TOT1_CAP_MA);

            /*" -1748- MOVE AC-INV-PERMANENTE TO TOT1-CAP-IP. */
            _.Move(AC_CAPITAIS.AC_INV_PERMANENTE, TOT_DET_1.TOT1_CAP_IP);

            /*" -1749- MOVE AC-ASS-MEDICA TO TOT1-CAP-AMDS. */
            _.Move(AC_CAPITAIS.AC_ASS_MEDICA, TOT_DET_2.TOT1_CAP_AMDS);

            /*" -1750- MOVE AC-DIARIA-HOSPITALAR TO TOT1-CAP-DH. */
            _.Move(AC_CAPITAIS.AC_DIARIA_HOSPITALAR, TOT_DET_1.TOT1_CAP_DH);

            /*" -1751- MOVE AC-DIARIA-INTERNACAO TO TOT1-CAP-DIT. */
            _.Move(AC_CAPITAIS.AC_DIARIA_INTERNACAO, TOT_DET_2.TOT1_CAP_DIT);

            /*" -1752- MOVE AC-PREM-MORTE-NATURAL TO TOT1-PREM-VG. */
            _.Move(AC_CAPITAIS.AC_PREM_MORTE_NATURAL, TOT_DET_1.TOT1_PREM_VG);

            /*" -1754- MOVE AC-PREM-ACID-PESSOAIS TO TOT1-PREM-APC. */
            _.Move(AC_CAPITAIS.AC_PREM_ACID_PESSOAIS, TOT_DET_2.TOT1_PREM_APC);

            /*" -1755- WRITE REG-IMPRESSAO FROM TOT-CAB-1 AFTER 3. */
            _.Move(TOT_CAB_1.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1756- WRITE REG-IMPRESSAO FROM TOT-CAB-2. */
            _.Move(TOT_CAB_2.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1757- WRITE REG-IMPRESSAO FROM TOT-CAB-3. */
            _.Move(TOT_CAB_3.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1758- WRITE REG-IMPRESSAO FROM TOT-DET-1 AFTER 2. */
            _.Move(TOT_DET_1.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1759- WRITE REG-IMPRESSAO FROM TOT-DET-2. */
            _.Move(TOT_DET_2.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1759- MOVE ZEROS TO AC-CAPITAIS. */
            _.Move(0, AC_CAPITAIS);

        }

        [StopWatch]
        /*" M-0600-500-000-IMPRIME-CABECALHO-SECTION */
        private void M_0600_500_000_IMPRIME_CABECALHO_SECTION()
        {
            /*" -1764- ADD 1 TO AC-PAGINAS. */
            AC_PAGINAS.Value = AC_PAGINAS + 1;

            /*" -1765- MOVE AC-PAGINAS TO CAB1-PAGINA. */
            _.Move(AC_PAGINAS, CAB_1.CAB1_PAGINA);

            /*" -1766- WRITE REG-IMPRESSAO FROM CAB-1 AFTER PAGE. */
            _.Move(CAB_1.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1767- WRITE REG-IMPRESSAO FROM CAB-2. */
            _.Move(CAB_2.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1768- WRITE REG-IMPRESSAO FROM CAB-3. */
            _.Move(CAB_3.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1769- WRITE REG-IMPRESSAO FROM CAB-4. */
            _.Move(CAB_4.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1770- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1771- WRITE REG-IMPRESSAO FROM CAB-5. */
            _.Move(CAB_5.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1772- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1773- WRITE REG-IMPRESSAO FROM CAB-6. */
            _.Move(CAB_6.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1774- WRITE REG-IMPRESSAO FROM CAB-7. */
            _.Move(CAB_7.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1775- WRITE REG-IMPRESSAO FROM CAB-8. */
            _.Move(CAB_8.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1776- WRITE REG-IMPRESSAO FROM TRACO. */
            _.Move(TRACO.GetMoveValues(), REG_IMPRESSAO);

            RVG0122B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1776- MOVE 11 TO AC-LINHAS. */
            _.Move(11, AC_LINHAS);

        }

        [StopWatch]
        /*" M-0700-000-UPDATE-SECTION */
        private void M_0700_000_UPDATE_SECTION()
        {
            /*" -1782- MOVE '0700-000-UPDATE               ' TO PARAGRAFO. */
            _.Move("0700-000-UPDATE               ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1784- MOVE 'UPDATE...  SEGUROS.V1RELATORIOS  ' TO COMANDO. */
            _.Move("UPDATE...  SEGUROS.V1RELATORIOS  ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1792- PERFORM M_0700_000_UPDATE_DB_UPDATE_1 */

            M_0700_000_UPDATE_DB_UPDATE_1();

            /*" -1795- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1796- DISPLAY 'VG0122B - ERRO NA ATUALIZACAO DA V0RELATORIOS' */
                _.Display($"VG0122B - ERRO NA ATUALIZACAO DA V0RELATORIOS");

                /*" -1796- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-0700-000-UPDATE-DB-UPDATE-1 */
        public void M_0700_000_UPDATE_DB_UPDATE_1()
        {
            /*" -1792- EXEC SQL UPDATE SEGUROS.V0RELATORIOS SET SITUACAO = '1' , TIMESTAMP = CURRENT TIMESTAMP WHERE CODRELAT = 'VG0122B' AND IDSISTEM = 'VG' AND SITUACAO = '0' AND OPERACAO >= 1 AND OPERACAO <= 3 END-EXEC. */

            var m_0700_000_UPDATE_DB_UPDATE_1_Update1 = new M_0700_000_UPDATE_DB_UPDATE_1_Update1()
            {
            };

            M_0700_000_UPDATE_DB_UPDATE_1_Update1.Execute(m_0700_000_UPDATE_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" M-9000-000-CLOSE-CURSOR-SECTION */
        private void M_9000_000_CLOSE_CURSOR_SECTION()
        {
            /*" -1803- MOVE '9000-000-CLOSE-CURSOR      ' TO PARAGRAFO. */
            _.Move("9000-000-CLOSE-CURSOR      ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1805- MOVE 'CLOSE.... CURSOR  RELATORIO        ' TO COMANDO. */
            _.Move("CLOSE.... CURSOR  RELATORIO        ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1806- PERFORM M_9000_000_CLOSE_CURSOR_DB_CLOSE_1 */

            M_9000_000_CLOSE_CURSOR_DB_CLOSE_1();

            /*" -1809- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1809- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-9000-000-CLOSE-CURSOR-DB-CLOSE-1 */
        public void M_9000_000_CLOSE_CURSOR_DB_CLOSE_1()
        {
            /*" -1806- EXEC SQL CLOSE RELATORIO END-EXEC. */

            RELATORIO.Close();

        }

        [StopWatch]
        /*" M-9000-020-CLOSE-CURSOR-SEGURADO-SECTION */
        private void M_9000_020_CLOSE_CURSOR_SEGURADO_SECTION()
        {
            /*" -1815- MOVE '9000-000-CLOSE-CURSOR      ' TO PARAGRAFO. */
            _.Move("9000-000-CLOSE-CURSOR      ", LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1817- MOVE 'CLOSE.... CURSOR  SEGURADO         ' TO COMANDO. */
            _.Move("CLOSE.... CURSOR  SEGURADO         ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1818- IF RELAT-OPERACAO NOT EQUAL 0001 */

            if (RELAT_OPERACAO != 0001)
            {

                /*" -1819- GO TO 9000-020-SALTA1. */

                M_9000_020_SALTA1(); //GOTO
                return;
            }


            /*" -1819- PERFORM M_9000_020_CLOSE_CURSOR_SEGURADO_DB_CLOSE_1 */

            M_9000_020_CLOSE_CURSOR_SEGURADO_DB_CLOSE_1();

            /*" -1821- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1821- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM M_9000_020_SALTA1 */

            M_9000_020_SALTA1();

        }

        [StopWatch]
        /*" M-9000-020-CLOSE-CURSOR-SEGURADO-DB-CLOSE-1 */
        public void M_9000_020_CLOSE_CURSOR_SEGURADO_DB_CLOSE_1()
        {
            /*" -1819- EXEC SQL CLOSE SEGURADO1 END-EXEC. */

            SEGURADO1.Close();

        }

        [StopWatch]
        /*" M-9000-020-SALTA1 */
        private void M_9000_020_SALTA1(bool isPerform = false)
        {
            /*" -1826- MOVE 'CLOSE.... CURSOR  SEGURADO2        ' TO COMANDO. */
            _.Move("CLOSE.... CURSOR  SEGURADO2        ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1827- IF RELAT-OPERACAO NOT EQUAL 0002 */

            if (RELAT_OPERACAO != 0002)
            {

                /*" -1828- GO TO 9000-020-SALTA2. */

                M_9000_020_SALTA2(); //GOTO
                return;
            }


            /*" -1828- PERFORM M_9000_020_SALTA1_DB_CLOSE_1 */

            M_9000_020_SALTA1_DB_CLOSE_1();

            /*" -1830- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1830- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-9000-020-SALTA1-DB-CLOSE-1 */
        public void M_9000_020_SALTA1_DB_CLOSE_1()
        {
            /*" -1828- EXEC SQL CLOSE SEGURADO2 END-EXEC. */

            SEGURADO2.Close();

        }

        [StopWatch]
        /*" M-9000-020-SALTA2 */
        private void M_9000_020_SALTA2(bool isPerform = false)
        {
            /*" -1835- MOVE 'CLOSE.... CURSOR  SEGURADO3        ' TO COMANDO. */
            _.Move("CLOSE.... CURSOR  SEGURADO3        ", LOCALIZA_ABEND_2.COMANDO);

            /*" -1836- IF RELAT-OPERACAO NOT EQUAL 0003 */

            if (RELAT_OPERACAO != 0003)
            {

                /*" -1837- GO TO 9000-020-SALTA3. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_020_SALTA3*/ //GOTO
                return;
            }


            /*" -1837- PERFORM M_9000_020_SALTA2_DB_CLOSE_1 */

            M_9000_020_SALTA2_DB_CLOSE_1();

            /*" -1839- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1839- GO TO 9999-999-ERRO. */

                M_9999_999_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-9000-020-SALTA2-DB-CLOSE-1 */
        public void M_9000_020_SALTA2_DB_CLOSE_1()
        {
            /*" -1837- EXEC SQL CLOSE SEGURADO3 END-EXEC. */

            SEGURADO3.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9000_020_SALTA3*/

        [StopWatch]
        /*" M-9999-999-ERRO-SECTION */
        private void M_9999_999_ERRO_SECTION()
        {
            /*" -1848- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -1849- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WABEND.WSQLERRD1);

            /*" -1850- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WABEND.WSQLERRD2);

            /*" -1851- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -1852- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(LOCALIZA_ABEND_1);

            /*" -1854- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(LOCALIZA_ABEND_2);

            /*" -1854- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1857- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1860- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1860- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_9999_EXIT*/
    }
}