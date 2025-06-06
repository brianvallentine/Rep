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
using Sias.Emissao.DB2.EM8007B;

namespace Code
{
    public class EM8007B
    {
        public bool IsCall { get; set; }

        public EM8007B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  COBRANCA                           *      */
        /*"      *   PROGRAMA ...............  EM8007B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA DE REQUISITOS..  CLOVIS/DANIELA MARTINO             *      */
        /*"      *   PROGRAMADOR ............  WANGER C SILVA                     *      */
        /*"      *   CADMUS .... ............  XX.XXX    (PROJETO VISAO)          *      */
        /*"      *   DATA CODIFICACAO .......  11/10/2010                         *      */
        /*"      *   DATA REVISAO ...........  07/12/2010 - CLOVIS                *      */
        /*"      *   DATA REVISAO ...........  22/12/2010 - CLOVIS                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERACAO DE ARQUIVOS DO LATOUT      *      */
        /*"      *                             ARQUIVO H PARA O CNAB ( SICOB )    *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                    A L T E R A C O E S                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 - PROJETO AUTO - SUL AMERICA                       *      */
        /*"      *                                                                *      */
        /*"      *               - PREVISAO DOS NOVOS CEDENTES                    *      */
        /*"      *                 063087000000319-8 - ADESAO                     *      */
        /*"      *                 063087000000320-1 - DEMAIS PARCELAS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 26/05/2011 - CLOVIS                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   CADMUS 80080 - 15/03/2013 - GUILHERME CORREIA                *      */
        /*"      *                                                                *      */
        /*"      *               - NOVO CEDENTE                                   *      */
        /*"      *                 063087000000282-5  - RESSARCIMENTO             *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.02         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 03 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 30/04/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.03         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _ENTRADA { get; set; } = new FileBasis(new PIC("X", "300", "X(300)"));

        public FileBasis ENTRADA
        {
            get
            {
                _.Move(REG_ENTRADA, _ENTRADA); VarBasis.RedefinePassValue(REG_ENTRADA, _ENTRADA, REG_ENTRADA); return _ENTRADA;
            }
        }
        public FileBasis _SAIDA01 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA01
        {
            get
            {
                _.Move(REG_SAIDA01, _SAIDA01); VarBasis.RedefinePassValue(REG_SAIDA01, _SAIDA01, REG_SAIDA01); return _SAIDA01;
            }
        }
        public FileBasis _SAIDA02 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA02
        {
            get
            {
                _.Move(REG_SAIDA02, _SAIDA02); VarBasis.RedefinePassValue(REG_SAIDA02, _SAIDA02, REG_SAIDA02); return _SAIDA02;
            }
        }
        public FileBasis _SAIDA03 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA03
        {
            get
            {
                _.Move(REG_SAIDA03, _SAIDA03); VarBasis.RedefinePassValue(REG_SAIDA03, _SAIDA03, REG_SAIDA03); return _SAIDA03;
            }
        }
        public FileBasis _SAIDA04 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA04
        {
            get
            {
                _.Move(REG_SAIDA04, _SAIDA04); VarBasis.RedefinePassValue(REG_SAIDA04, _SAIDA04, REG_SAIDA04); return _SAIDA04;
            }
        }
        public FileBasis _SAIDA05 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA05
        {
            get
            {
                _.Move(REG_SAIDA05, _SAIDA05); VarBasis.RedefinePassValue(REG_SAIDA05, _SAIDA05, REG_SAIDA05); return _SAIDA05;
            }
        }
        public FileBasis _SAIDA06 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA06
        {
            get
            {
                _.Move(REG_SAIDA06, _SAIDA06); VarBasis.RedefinePassValue(REG_SAIDA06, _SAIDA06, REG_SAIDA06); return _SAIDA06;
            }
        }
        public FileBasis _SAIDA07 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA07
        {
            get
            {
                _.Move(REG_SAIDA07, _SAIDA07); VarBasis.RedefinePassValue(REG_SAIDA07, _SAIDA07, REG_SAIDA07); return _SAIDA07;
            }
        }
        public FileBasis _SAIDA08 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA08
        {
            get
            {
                _.Move(REG_SAIDA08, _SAIDA08); VarBasis.RedefinePassValue(REG_SAIDA08, _SAIDA08, REG_SAIDA08); return _SAIDA08;
            }
        }
        public FileBasis _SAIDA09 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA09
        {
            get
            {
                _.Move(REG_SAIDA09, _SAIDA09); VarBasis.RedefinePassValue(REG_SAIDA09, _SAIDA09, REG_SAIDA09); return _SAIDA09;
            }
        }
        public FileBasis _SAIDA10 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA10
        {
            get
            {
                _.Move(REG_SAIDA10, _SAIDA10); VarBasis.RedefinePassValue(REG_SAIDA10, _SAIDA10, REG_SAIDA10); return _SAIDA10;
            }
        }
        public FileBasis _SAIDA11 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA11
        {
            get
            {
                _.Move(REG_SAIDA11, _SAIDA11); VarBasis.RedefinePassValue(REG_SAIDA11, _SAIDA11, REG_SAIDA11); return _SAIDA11;
            }
        }
        public FileBasis _SAIDA12 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA12
        {
            get
            {
                _.Move(REG_SAIDA12, _SAIDA12); VarBasis.RedefinePassValue(REG_SAIDA12, _SAIDA12, REG_SAIDA12); return _SAIDA12;
            }
        }
        public FileBasis _SAIDA13 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA13
        {
            get
            {
                _.Move(REG_SAIDA13, _SAIDA13); VarBasis.RedefinePassValue(REG_SAIDA13, _SAIDA13, REG_SAIDA13); return _SAIDA13;
            }
        }
        public FileBasis _SAIDA14 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA14
        {
            get
            {
                _.Move(REG_SAIDA14, _SAIDA14); VarBasis.RedefinePassValue(REG_SAIDA14, _SAIDA14, REG_SAIDA14); return _SAIDA14;
            }
        }
        public FileBasis _SAIDA15 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA15
        {
            get
            {
                _.Move(REG_SAIDA15, _SAIDA15); VarBasis.RedefinePassValue(REG_SAIDA15, _SAIDA15, REG_SAIDA15); return _SAIDA15;
            }
        }
        public FileBasis _SAIDA16 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA16
        {
            get
            {
                _.Move(REG_SAIDA16, _SAIDA16); VarBasis.RedefinePassValue(REG_SAIDA16, _SAIDA16, REG_SAIDA16); return _SAIDA16;
            }
        }
        public FileBasis _SAIDA17 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA17
        {
            get
            {
                _.Move(REG_SAIDA17, _SAIDA17); VarBasis.RedefinePassValue(REG_SAIDA17, _SAIDA17, REG_SAIDA17); return _SAIDA17;
            }
        }
        public FileBasis _SAIDA18 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA18
        {
            get
            {
                _.Move(REG_SAIDA18, _SAIDA18); VarBasis.RedefinePassValue(REG_SAIDA18, _SAIDA18, REG_SAIDA18); return _SAIDA18;
            }
        }
        public FileBasis _SAIDA19 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA19
        {
            get
            {
                _.Move(REG_SAIDA19, _SAIDA19); VarBasis.RedefinePassValue(REG_SAIDA19, _SAIDA19, REG_SAIDA19); return _SAIDA19;
            }
        }
        public FileBasis _SAIDA20 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA20
        {
            get
            {
                _.Move(REG_SAIDA20, _SAIDA20); VarBasis.RedefinePassValue(REG_SAIDA20, _SAIDA20, REG_SAIDA20); return _SAIDA20;
            }
        }
        public FileBasis _SAIDA21 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA21
        {
            get
            {
                _.Move(REG_SAIDA21, _SAIDA21); VarBasis.RedefinePassValue(REG_SAIDA21, _SAIDA21, REG_SAIDA21); return _SAIDA21;
            }
        }
        public FileBasis _SAIDA22 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA22
        {
            get
            {
                _.Move(REG_SAIDA22, _SAIDA22); VarBasis.RedefinePassValue(REG_SAIDA22, _SAIDA22, REG_SAIDA22); return _SAIDA22;
            }
        }
        public FileBasis _SAIDA23 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA23
        {
            get
            {
                _.Move(REG_SAIDA23, _SAIDA23); VarBasis.RedefinePassValue(REG_SAIDA23, _SAIDA23, REG_SAIDA23); return _SAIDA23;
            }
        }
        public FileBasis _SAIDA24 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA24
        {
            get
            {
                _.Move(REG_SAIDA24, _SAIDA24); VarBasis.RedefinePassValue(REG_SAIDA24, _SAIDA24, REG_SAIDA24); return _SAIDA24;
            }
        }
        public FileBasis _SAIDA25 { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis SAIDA25
        {
            get
            {
                _.Move(REG_SAIDA25, _SAIDA25); VarBasis.RedefinePassValue(REG_SAIDA25, _SAIDA25, REG_SAIDA25); return _SAIDA25;
            }
        }
        public SortBasis<EM8007B_REG_ARQSORT> ARQSORT { get; set; } = new SortBasis<EM8007B_REG_ARQSORT>(new EM8007B_REG_ARQSORT());
        /*"01        REG-ARQSORT.*/
        public EM8007B_REG_ARQSORT REG_ARQSORT { get; set; } = new EM8007B_REG_ARQSORT();
        public class EM8007B_REG_ARQSORT : VarBasis
        {
            /*"  10      SOR-TIPO-ARQUIVO         PIC  X(010).*/
            public StringBasis SOR_TIPO_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  10      SOR-COD-REGISTRO         PIC  9(001).*/
            public IntBasis SOR_COD_REGISTRO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-TIPO-INSCRICAO       PIC  9(002).*/
            public IntBasis SOR_TIPO_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  10      SOR-NUM-INSCRICAO        PIC  9(014).*/
            public IntBasis SOR_NUM_INSCRICAO { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  10      SOR-COD-CEDENTE          PIC  9(016).*/
            public IntBasis SOR_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  10      SOR-COD-BANCO            PIC  9(003).*/
            public IntBasis SOR_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  10      SOR-NSAC                 PIC  9(005).*/
            public IntBasis SOR_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  10      SOR-DTGERACAO            PIC  9(006).*/
            public IntBasis SOR_DTGERACAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  10      SOR-TITULO-EMPRESA       PIC  9(016).*/
            public IntBasis SOR_TITULO_EMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  10      SOR-TITULO-BANCO         PIC  9(011).*/
            public IntBasis SOR_TITULO_BANCO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  10      SOR-COD-REJEICAO         PIC  9(003).*/
            public IntBasis SOR_COD_REJEICAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  10      SOR-COD-OCORRENCIA       PIC  9(002).*/
            public IntBasis SOR_COD_OCORRENCIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  10      SOR-DATA-OCORRENCIA      PIC  9(006).*/
            public IntBasis SOR_DATA_OCORRENCIA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  10      SOR-DATA-VENCIMENTO      PIC  9(006).*/
            public IntBasis SOR_DATA_VENCIMENTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  10      SOR-VLR-NOMINAL-TIT      PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_NOMINAL_TIT { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-COD-COMP-CAIXA       PIC  9(003).*/
            public IntBasis SOR_COD_COMP_CAIXA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  10      SOR-AGE-COBR             PIC  9(004).*/
            public IntBasis SOR_AGE_COBR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  10      SOR-AGE-DIG-COBR         PIC  9(001).*/
            public IntBasis SOR_AGE_DIG_COBR { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-ESPECIE              PIC  X(002).*/
            public StringBasis SOR_ESPECIE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  10      SOR-VLR-TARIFA           PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_TARIFA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-FORMA-LIQUIDACAO     PIC  9(003).*/
            public IntBasis SOR_FORMA_LIQUIDACAO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  10      SOR-FORMA-PAGAMENTO      PIC  9(001).*/
            public IntBasis SOR_FORMA_PAGAMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-QTD-DIAS-FLOAT       PIC  9(002).*/
            public IntBasis SOR_QTD_DIAS_FLOAT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  10      SOR-DATA-DEB-TARIFA      PIC  9(006).*/
            public IntBasis SOR_DATA_DEB_TARIFA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  10      SOR-VLR-IOF              PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_IOF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-ABATIMENTO       PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-DESCONTO         PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_DESCONTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-PRINCIPAL        PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_PRINCIPAL { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-JUROS            PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_JUROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-VLR-MULTA            PIC  9(011)V99.*/
            public DoubleBasis SOR_VLR_MULTA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  10      SOR-COD-MOEDA            PIC  9(001).*/
            public IntBasis SOR_COD_MOEDA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  10      SOR-DATA-CREDITO         PIC  9(006).*/
            public IntBasis SOR_DATA_CREDITO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  10      SOR-FINANCEIRO           PIC  9(016).*/
            public IntBasis SOR_FINANCEIRO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"01        REG-ENTRADA              PIC  X(300).*/
        }
        public StringBasis REG_ENTRADA { get; set; } = new StringBasis(new PIC("X", "300", "X(300)."), @"");
        /*"01        REG-SAIDA01                 PIC  X(400).*/
        public StringBasis REG_SAIDA01 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA02                 PIC  X(400).*/
        public StringBasis REG_SAIDA02 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA03                 PIC  X(400).*/
        public StringBasis REG_SAIDA03 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA04                 PIC  X(400).*/
        public StringBasis REG_SAIDA04 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA05                 PIC  X(400).*/
        public StringBasis REG_SAIDA05 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA06                 PIC  X(400).*/
        public StringBasis REG_SAIDA06 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA07                 PIC  X(400).*/
        public StringBasis REG_SAIDA07 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA08                 PIC  X(400).*/
        public StringBasis REG_SAIDA08 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA09                 PIC  X(400).*/
        public StringBasis REG_SAIDA09 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA10                 PIC  X(400).*/
        public StringBasis REG_SAIDA10 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA11                 PIC  X(400).*/
        public StringBasis REG_SAIDA11 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA12                 PIC  X(400).*/
        public StringBasis REG_SAIDA12 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA13                 PIC  X(400).*/
        public StringBasis REG_SAIDA13 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA14                 PIC  X(400).*/
        public StringBasis REG_SAIDA14 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA15                 PIC  X(400).*/
        public StringBasis REG_SAIDA15 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA16                 PIC  X(400).*/
        public StringBasis REG_SAIDA16 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA17                 PIC  X(400).*/
        public StringBasis REG_SAIDA17 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA18                 PIC  X(400).*/
        public StringBasis REG_SAIDA18 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA19                 PIC  X(400).*/
        public StringBasis REG_SAIDA19 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA20                 PIC  X(400).*/
        public StringBasis REG_SAIDA20 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA21                 PIC  X(400).*/
        public StringBasis REG_SAIDA21 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA22                 PIC  X(400).*/
        public StringBasis REG_SAIDA22 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA23                 PIC  X(400).*/
        public StringBasis REG_SAIDA23 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA24                 PIC  X(400).*/
        public StringBasis REG_SAIDA24 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        /*"01        REG-SAIDA25                 PIC  X(400).*/
        public StringBasis REG_SAIDA25 { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77    V0CNAB-COD-EMP            PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_COD_EMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CNAB-ORGAO              PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    V0CNAB-NRCTACED           PIC S9(021)    VALUE +0   COMP-3*/
        public IntBasis V0CNAB_NRCTACED { get; set; } = new IntBasis(new PIC("S9", "21", "S9(021)"));
        /*"77    V0CNAB-TIPOCOB            PIC  X(001).*/
        public StringBasis V0CNAB_TIPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77    V0CNAB-DTMOVTO            PIC  X(010).*/
        public StringBasis V0CNAB_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CNAB-DATCEF             PIC  X(010).*/
        public StringBasis V0CNAB_DATCEF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77    V0CNAB-NRSEQ              PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    V0CNAB-QTDREG             PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0CNAB_QTDREG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77    WSHOST-NRAVISO1           PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WSHOST_NRAVISO1 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77    WSHOST-NRAVISO2           PIC S9(009)    VALUE +0   COMP.*/
        public IntBasis WSHOST_NRAVISO2 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01  W.*/
        public EM8007B_W W { get; set; } = new EM8007B_W();
        public class EM8007B_W : VarBasis
        {
            /*"  03  WFIM-MOVIMENTO            PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-MOVIMENTO              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  DP-MOVIMENTO              PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis DP_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  GV-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis GV_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  WFIM-SORT                 PIC  X(001)    VALUE  'N'.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"  03  LD-SORT                   PIC  9(007)    VALUE   ZEROS.*/
            public IntBasis LD_SORT { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03  ATU-COD-CEDENTE           PIC  9(016)    VALUE   ZEROS.*/
            public IntBasis ATU_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  03  ANT-COD-CEDENTE           PIC  9(016)    VALUE   ZEROS.*/
            public IntBasis ANT_COD_CEDENTE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  03  AC-GRAV-SAIDA01           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA01 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA02           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA02 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA03           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA03 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA04           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA04 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA05           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA05 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA06           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA06 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA07           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA07 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA08           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA08 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA09           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA09 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA10           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA10 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA11           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA11 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA12           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA12 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA13           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA13 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA14           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA14 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA15           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA15 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA16           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA16 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA17           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA17 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA18           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA18 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA19           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA19 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA20           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA20 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA21           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA21 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA22           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA22 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA23           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA23 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA24           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA24 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  AC-GRAV-SAIDA25           PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis AC_GRAV_SAIDA25 { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03  WS-NRSEQ                  PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis WS_NRSEQ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         WS0-NRAVISO        PIC  9(009)    VALUE   ZEROS.*/
            public IntBasis WS0_NRAVISO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  03         FILLER             REDEFINES      WS0-NRAVISO.*/
            private _REDEF_EM8007B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_EM8007B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_EM8007B_FILLER_0(); _.Move(WS0_NRAVISO, _filler_0); VarBasis.RedefinePassValue(WS0_NRAVISO, _filler_0, WS0_NRAVISO); _filler_0.ValueChanged += () => { _.Move(_filler_0, WS0_NRAVISO); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WS0_NRAVISO); }
            }  //Redefines
            public class _REDEF_EM8007B_FILLER_0 : VarBasis
            {
                /*"    10       DS0-PRE-AVISO      PIC  9(004).*/
                public IntBasis DS0_PRE_AVISO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS0-NRO-NSAC       PIC  9(005).*/
                public IntBasis WS0_NRO_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"  03         WWORK-CODEMPRE     PIC  9(016)    VALUE   ZEROS.*/

                public _REDEF_EM8007B_FILLER_0()
                {
                    DS0_PRE_AVISO.ValueChanged += OnValueChanged;
                    WS0_NRO_NSAC.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WWORK_CODEMPRE { get; set; } = new IntBasis(new PIC("9", "16", "9(016)"));
            /*"  03         FILLER             REDEFINES      WWORK-CODEMPRE.*/
            private _REDEF_EM8007B_FILLER_1 _filler_1 { get; set; }
            public _REDEF_EM8007B_FILLER_1 FILLER_1
            {
                get { _filler_1 = new _REDEF_EM8007B_FILLER_1(); _.Move(WWORK_CODEMPRE, _filler_1); VarBasis.RedefinePassValue(WWORK_CODEMPRE, _filler_1, WWORK_CODEMPRE); _filler_1.ValueChanged += () => { _.Move(_filler_1, WWORK_CODEMPRE); }; return _filler_1; }
                set { VarBasis.RedefinePassValue(value, _filler_1, WWORK_CODEMPRE); }
            }  //Redefines
            public class _REDEF_EM8007B_FILLER_1 : VarBasis
            {
                /*"    10       WWORK-NRCTACED     PIC  9(015).*/
                public IntBasis WWORK_NRCTACED { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"    10       FILLER             PIC  9(001).*/
                public IntBasis FILLER_2 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"  03         WDATA-CABEC.*/

                public _REDEF_EM8007B_FILLER_1()
                {
                    WWORK_NRCTACED.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }
            public EM8007B_WDATA_CABEC WDATA_CABEC { get; set; } = new EM8007B_WDATA_CABEC();
            public class EM8007B_WDATA_CABEC : VarBasis
            {
                /*"    05       WDATA-DD-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_DD_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-MM-CABEC    PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WDATA_MM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    05       FILLER            PIC  X(001)    VALUE '/'.*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    05       WDATA-AA-CABEC    PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WDATA_AA_CABEC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"  03         WDATA-REL          PIC  X(010)    VALUE   SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER             REDEFINES      WDATA-REL.*/
            private _REDEF_EM8007B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_EM8007B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_EM8007B_FILLER_5(); _.Move(WDATA_REL, _filler_5); VarBasis.RedefinePassValue(WDATA_REL, _filler_5, WDATA_REL); _filler_5.ValueChanged += () => { _.Move(_filler_5, WDATA_REL); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, WDATA_REL); }
            }  //Redefines
            public class _REDEF_EM8007B_FILLER_5 : VarBasis
            {
                /*"    10       WDAT-REL-ANO       PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-MES       PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER             PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WDAT-REL-DIA       PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01  ABEN.*/

                public _REDEF_EM8007B_FILLER_5()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_6.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_7.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
        }
        public EM8007B_ABEN ABEN { get; set; } = new EM8007B_ABEN();
        public class EM8007B_ABEN : VarBasis
        {
            /*"  03        WABEND.*/
            public EM8007B_WABEND WABEND { get; set; } = new EM8007B_WABEND();
            public class EM8007B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' EM8007B  '.*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" EM8007B  ");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(040) VALUE    SPACES.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"  03        WABEND1.*/
            }
            public EM8007B_WABEND1 WABEND1 { get; set; } = new EM8007B_WABEND1();
            public class EM8007B_WABEND1 : VarBasis
            {
                /*"    05      FILLER              PIC  X(011) VALUE           ' SQLCODE = '.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @" SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD1 = '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD1 = ");
                /*"    05      WSQLERRD1           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05      FILLER              PIC  X(012) VALUE           ' SQLERRD2 = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @" SQLERRD2 = ");
                /*"    05      WSQLERRD2           PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"01        HEADER-REGISTRO.*/
            }
        }
        public EM8007B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new EM8007B_HEADER_REGISTRO();
        public class EM8007B_HEADER_REGISTRO : VarBasis
        {
            /*"  05      HEADER-CODREGISTR   PIC  X(001).*/
            public StringBasis HEADER_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-CODRETORNO   PIC  X(001).*/
            public StringBasis HEADER_CODRETORNO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      HEADER-LITRETORNO   PIC  X(007).*/
            public StringBasis HEADER_LITRETORNO { get; set; } = new StringBasis(new PIC("X", "7", "X(007)."), @"");
            /*"  05      HEADER-CODSERVICO   PIC  X(002).*/
            public StringBasis HEADER_CODSERVICO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      HEADER-LITSERVICO   PIC  X(015).*/
            public StringBasis HEADER_LITSERVICO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"  05      HEADER-CODEMPRESA   PIC  9(016).*/
            public IntBasis HEADER_CODEMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      FILLER              PIC  X(004).*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      HEADER-NOMEMPRESA   PIC  X(030).*/
            public StringBasis HEADER_NOMEMPRESA { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"  05      HEADER-CODBANCO     PIC  X(003).*/
            public StringBasis HEADER_CODBANCO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05      HEADER-NOMEBANCO    PIC  X(015).*/
            public StringBasis HEADER_NOMEBANCO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
            /*"  05      HEADER-DTGERACAO    PIC  9(006).*/
            public IntBasis HEADER_DTGERACAO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      FILLER              PIC  X(289).*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "289", "X(289)."), @"");
            /*"  05      HEADER-NUMFITA      PIC  9(005).*/
            public IntBasis HEADER_NUMFITA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
            /*"  05      HEADER-NRSEQ        PIC  9(006).*/
            public IntBasis HEADER_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        COBRAN-REGISTRO.*/
        }
        public EM8007B_COBRAN_REGISTRO COBRAN_REGISTRO { get; set; } = new EM8007B_COBRAN_REGISTRO();
        public class EM8007B_COBRAN_REGISTRO : VarBasis
        {
            /*"  05      COBRAN-CODREGISTR   PIC  X(001).*/
            public StringBasis COBRAN_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      COBRAN-INSCEMPRES   PIC  9(002).*/
            public IntBasis COBRAN_INSCEMPRES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-NUMINSCRIC   PIC  9(014).*/
            public IntBasis COBRAN_NUMINSCRIC { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"  05      COBRAN-CODEMPRESA   PIC  9(016).*/
            public IntBasis COBRAN_CODEMPRESA { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      FILLER              PIC  X(004).*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
            /*"  05      COBRAN-TITULO16     PIC  9(016).*/
            public IntBasis COBRAN_TITULO16 { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      FILLER              PIC  X(009).*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05      COBRAN-NOSS-NUMERO  PIC  9(011).*/
            public IntBasis COBRAN_NOSS_NUMERO { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
            /*"  05      FILLER              PIC  X(006).*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)."), @"");
            /*"  05      COBRAN-CODREJEIC    PIC  9(003).*/
            public IntBasis COBRAN_CODREJEIC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      FILLER              PIC  X(024).*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)."), @"");
            /*"  05      COBRAN-CODCARTEIRA  PIC  X(002).*/
            public StringBasis COBRAN_CODCARTEIRA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      COBRAN-CODOCORRENC  PIC  9(002).*/
            public IntBasis COBRAN_CODOCORRENC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-DATAOCORREN  PIC  9(006).*/
            public IntBasis COBRAN_DATAOCORREN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      FILLER              PIC  X(030).*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
            /*"  05      COBRAN-DTVENCTO     PIC  9(006).*/
            public IntBasis COBRAN_DTVENCTO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      COBRAN-VLR-CRS      PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_CRS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-COD-BCO      PIC  9(003).*/
            public IntBasis COBRAN_COD_BCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      COBRAN-AGE-COBRAN   PIC  9(004).*/
            public IntBasis COBRAN_AGE_COBRAN { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"  05      COBRAN-AGE-DIGITO   PIC  9(001).*/
            public IntBasis COBRAN_AGE_DIGITO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-ESPECIE      PIC  X(002).*/
            public StringBasis COBRAN_ESPECIE { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05      COBRAN-DESPESAS     PIC  9(011)V99.*/
            public DoubleBasis COBRAN_DESPESAS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-FORMA-LIQ    PIC  9(003).*/
            public IntBasis COBRAN_FORMA_LIQ { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      COBRAN-FORMA-PAG    PIC  9(001).*/
            public IntBasis COBRAN_FORMA_PAG { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      COBRAN-FLOAT        PIC  9(002).*/
            public IntBasis COBRAN_FLOAT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      COBRAN-DTARIFA      PIC  9(006).*/
            public IntBasis COBRAN_DTARIFA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      FILLER              PIC  X(014).*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"  05      COBRAN-IOF          PIC  9(011)V99.*/
            public DoubleBasis COBRAN_IOF { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-ABATIMENTO   PIC  9(011)V99.*/
            public DoubleBasis COBRAN_ABATIMENTO { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-DESC-CONCED  PIC  9(011)V99.*/
            public DoubleBasis COBRAN_DESC_CONCED { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-VLR-PRINC    PIC  9(011)V99.*/
            public DoubleBasis COBRAN_VLR_PRINC { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-JUROS        PIC  9(011)V99.*/
            public DoubleBasis COBRAN_JUROS { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-MULTA        PIC  9(011)V99.*/
            public DoubleBasis COBRAN_MULTA { get; set; } = new DoubleBasis(new PIC("9", "11", "9(011)V99."), 2);
            /*"  05      COBRAN-COD-MOEDA    PIC  X(001).*/
            public StringBasis COBRAN_COD_MOEDA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      COBRAN-DATA-CRED    PIC  9(006).*/
            public IntBasis COBRAN_DATA_CRED { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"  05      FILLER              PIC  X(034).*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "34", "X(034)."), @"");
            /*"  05      COBRAN-FINANCEIRO   PIC  9(016).*/
            public IntBasis COBRAN_FINANCEIRO { get; set; } = new IntBasis(new PIC("9", "16", "9(016)."));
            /*"  05      FILLER              PIC  X(045).*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "45", "X(045)."), @"");
            /*"  05      COBRAN-NRSEQ        PIC  9(006).*/
            public IntBasis COBRAN_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"01        TRAILL-REGISTRO.*/
        }
        public EM8007B_TRAILL_REGISTRO TRAILL_REGISTRO { get; set; } = new EM8007B_TRAILL_REGISTRO();
        public class EM8007B_TRAILL_REGISTRO : VarBasis
        {
            /*"  05      TRAILL-CODREGISTR   PIC  X(001).*/
            public StringBasis TRAILL_CODREGISTR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05      TRAILL-COD-RETORNO  PIC  9(001).*/
            public IntBasis TRAILL_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"  05      TRAILL-COD-SERVICO  PIC  9(002).*/
            public IntBasis TRAILL_COD_SERVICO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"  05      TRAILL-COD-BANCO    PIC  9(003).*/
            public IntBasis TRAILL_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"  05      FILLER              PIC  X(387).*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "387", "X(387)."), @"");
            /*"  05      TRAILL-NRSEQ        PIC  9(006).*/
            public IntBasis TRAILL_NRSEQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.AVISOCRE AVISOCRE { get; set; } = new Dclgens.AVISOCRE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQSORT_FILE_NAME_P, string ENTRADA_FILE_NAME_P, string SAIDA01_FILE_NAME_P, string SAIDA02_FILE_NAME_P, string SAIDA03_FILE_NAME_P, string SAIDA04_FILE_NAME_P, string SAIDA05_FILE_NAME_P, string SAIDA06_FILE_NAME_P, string SAIDA07_FILE_NAME_P, string SAIDA08_FILE_NAME_P, string SAIDA09_FILE_NAME_P, string SAIDA10_FILE_NAME_P, string SAIDA11_FILE_NAME_P, string SAIDA12_FILE_NAME_P, string SAIDA13_FILE_NAME_P, string SAIDA14_FILE_NAME_P, string SAIDA15_FILE_NAME_P, string SAIDA16_FILE_NAME_P, string SAIDA17_FILE_NAME_P, string SAIDA18_FILE_NAME_P, string SAIDA19_FILE_NAME_P, string SAIDA20_FILE_NAME_P, string SAIDA21_FILE_NAME_P, string SAIDA22_FILE_NAME_P, string SAIDA23_FILE_NAME_P, string SAIDA24_FILE_NAME_P, string SAIDA25_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);
                ENTRADA.SetFile(ENTRADA_FILE_NAME_P);
                SAIDA01.SetFile(SAIDA01_FILE_NAME_P);
                SAIDA02.SetFile(SAIDA02_FILE_NAME_P);
                SAIDA03.SetFile(SAIDA03_FILE_NAME_P);
                SAIDA04.SetFile(SAIDA04_FILE_NAME_P);
                SAIDA05.SetFile(SAIDA05_FILE_NAME_P);
                SAIDA06.SetFile(SAIDA06_FILE_NAME_P);
                SAIDA07.SetFile(SAIDA07_FILE_NAME_P);
                SAIDA08.SetFile(SAIDA08_FILE_NAME_P);
                SAIDA09.SetFile(SAIDA09_FILE_NAME_P);
                SAIDA10.SetFile(SAIDA10_FILE_NAME_P);
                SAIDA11.SetFile(SAIDA11_FILE_NAME_P);
                SAIDA12.SetFile(SAIDA12_FILE_NAME_P);
                SAIDA13.SetFile(SAIDA13_FILE_NAME_P);
                SAIDA14.SetFile(SAIDA14_FILE_NAME_P);
                SAIDA15.SetFile(SAIDA15_FILE_NAME_P);
                SAIDA16.SetFile(SAIDA16_FILE_NAME_P);
                SAIDA17.SetFile(SAIDA17_FILE_NAME_P);
                SAIDA18.SetFile(SAIDA18_FILE_NAME_P);
                SAIDA19.SetFile(SAIDA19_FILE_NAME_P);
                SAIDA20.SetFile(SAIDA20_FILE_NAME_P);
                SAIDA21.SetFile(SAIDA21_FILE_NAME_P);
                SAIDA22.SetFile(SAIDA22_FILE_NAME_P);
                SAIDA23.SetFile(SAIDA23_FILE_NAME_P);
                SAIDA24.SetFile(SAIDA24_FILE_NAME_P);
                SAIDA25.SetFile(SAIDA25_FILE_NAME_P);

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
            /*" -592- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -593- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -595- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -597- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -603- PERFORM R0050-00-INICIO. */

            R0050_00_INICIO_SECTION();

            /*" -618- SORT ARQSORT ON ASCENDING KEY SOR-NUM-INSCRICAO SOR-COD-CEDENTE SOR-DTGERACAO SOR-COD-BANCO SOR-NSAC SOR-TITULO-EMPRESA SOR-DATA-OCORRENCIA INPUT PROCEDURE R0200-00-INPUT-SORT THRU R0200-99-SAIDA OUTPUT PROCEDURE R0500-00-OUTPUT-SORT THRU R0500-99-SAIDA. */
            ARQSORT.Sort("SOR-NUM-INSCRICAO,SOR-COD-CEDENTE,SOR-DTGERACAO,SOR-COD-BANCO,SOR-NSAC,SOR-TITULO-EMPRESA,SOR-DATA-OCORRENCIA", () => R0200_00_INPUT_SORT_SECTION(), () => R0500_00_OUTPUT_SORT_SECTION());

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -623- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -652- CLOSE ENTRADA SAIDA01 SAIDA02 SAIDA03 SAIDA04 SAIDA05 SAIDA06 SAIDA07 SAIDA08 SAIDA09 SAIDA10 SAIDA11 SAIDA12 SAIDA13 SAIDA14 SAIDA15 SAIDA16 SAIDA17 SAIDA18 SAIDA19 SAIDA20 SAIDA21 SAIDA22 SAIDA23 SAIDA24 SAIDA25. */
            ENTRADA.Close();
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();
            SAIDA04.Close();
            SAIDA05.Close();
            SAIDA06.Close();
            SAIDA07.Close();
            SAIDA08.Close();
            SAIDA09.Close();
            SAIDA10.Close();
            SAIDA11.Close();
            SAIDA12.Close();
            SAIDA13.Close();
            SAIDA14.Close();
            SAIDA15.Close();
            SAIDA16.Close();
            SAIDA17.Close();
            SAIDA18.Close();
            SAIDA19.Close();
            SAIDA20.Close();
            SAIDA21.Close();
            SAIDA22.Close();
            SAIDA23.Close();
            SAIDA24.Close();
            SAIDA25.Close();

            /*" -654- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -655- DISPLAY ' ' */
            _.Display($" ");

            /*" -656- DISPLAY 'EM8007B - FIM NORMAL' . */
            _.Display($"EM8007B - FIM NORMAL");

            /*" -658- DISPLAY ' ' . */
            _.Display($" ");

            /*" -658- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-INICIO-SECTION */
        private void R0050_00_INICIO_SECTION()
        {
            /*" -671- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -672- OPEN INPUT ENTRADA */
            ENTRADA.Open(REG_ENTRADA);

            /*" -699- OUTPUT SAIDA01 SAIDA02 SAIDA03 SAIDA04 SAIDA05 SAIDA06 SAIDA07 SAIDA08 SAIDA09 SAIDA10 SAIDA11 SAIDA12 SAIDA13 SAIDA14 SAIDA15 SAIDA16 SAIDA17 SAIDA18 SAIDA19 SAIDA20 SAIDA21 SAIDA22 SAIDA23 SAIDA24 SAIDA25. */
            SAIDA25.Open(REG_SAIDA25);

            /*" -701- PERFORM R0100-00-SELECT-SISTEMA. */

            R0100_00_SELECT_SISTEMA_SECTION();

            /*" -702- MOVE SPACES TO WFIM-MOVIMENTO. */
            _.Move("", W.WFIM_MOVIMENTO);

            /*" -705- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

            /*" -706- IF WFIM-MOVIMENTO NOT EQUAL SPACES */

            if (!W.WFIM_MOVIMENTO.IsEmpty())
            {

                /*" -706- GO TO R9990-00-SEM-MOVIMENTO. */

                R9990_00_SEM_MOVIMENTO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-SECTION */
        private void R0100_00_SELECT_SISTEMA_SECTION()
        {
            /*" -719- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -727- PERFORM R0100_00_SELECT_SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMA_DB_SELECT_1();

            /*" -730- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -731- DISPLAY 'R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)' */
                _.Display($"R0100-00 - PROBLEMAS NO SELECT(SISTEMAS)");

                /*" -731- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMA_DB_SELECT_1()
        {
            /*" -727- EXEC SQL SELECT DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'EM' WITH UR END-EXEC. */

            var r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-INPUT-SORT-SECTION */
        private void R0200_00_INPUT_SORT_SECTION()
        {
            /*" -744- MOVE '0200' TO WNR-EXEC-SQL. */
            _.Move("0200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -748- PERFORM R0350-00-PROCESSA-MOVIMENTO UNTIL WFIM-MOVIMENTO NOT EQUAL SPACES. */

            while (!(!W.WFIM_MOVIMENTO.IsEmpty()))
            {

                R0350_00_PROCESSA_MOVIMENTO_SECTION();
            }

            /*" -749- DISPLAY ' ' */
            _.Display($" ");

            /*" -750- DISPLAY 'LIDOS MOVIMENTO ....... ' LD-MOVIMENTO */
            _.Display($"LIDOS MOVIMENTO ....... {W.LD_MOVIMENTO}");

            /*" -751- DISPLAY 'DESPREZA MOVIMENTO .... ' DP-MOVIMENTO */
            _.Display($"DESPREZA MOVIMENTO .... {W.DP_MOVIMENTO}");

            /*" -752- DISPLAY 'GRAVADOS SORT ......... ' GV-SORT */
            _.Display($"GRAVADOS SORT ......... {W.GV_SORT}");

            /*" -752- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-LER-MOVIMENTO-SECTION */
        private void R0300_00_LER_MOVIMENTO_SECTION()
        {
            /*" -765- MOVE '0300' TO WNR-EXEC-SQL. */
            _.Move("0300", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -766- READ ENTRADA AT END */
            try
            {
                ENTRADA.Read(() =>
                {

                    /*" -768- MOVE 'S' TO WFIM-MOVIMENTO */
                    _.Move("S", W.WFIM_MOVIMENTO);

                    /*" -771- GO TO R0300-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(ENTRADA.Value, REG_ENTRADA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -771- ADD 1 TO LD-MOVIMENTO. */
            W.LD_MOVIMENTO.Value = W.LD_MOVIMENTO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0350-00-PROCESSA-MOVIMENTO-SECTION */
        private void R0350_00_PROCESSA_MOVIMENTO_SECTION()
        {
            /*" -784- MOVE '0350' TO WNR-EXEC-SQL. */
            _.Move("0350", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -786- MOVE REG-ENTRADA TO REG-ARQSORT. */
            _.Move(ENTRADA?.Value, REG_ARQSORT);

            /*" -789- MOVE SOR-COD-CEDENTE TO WWORK-CODEMPRE. */
            _.Move(REG_ARQSORT.SOR_COD_CEDENTE, W.WWORK_CODEMPRE);

            /*" -812- IF WWORK-NRCTACED EQUAL 063000300000383 OR 063000300001010 OR 063000300041428 OR 063087000000011 OR 063087000000013 OR 063087000000031 OR 063087000000033 OR 063087000000044 OR 063087000000060 OR 063087000000061 OR 063087000000062 OR 063087000000072 OR 063087000000075 OR 063087000000100 OR 063087000000113 OR 063087000000114 OR 063087000000130 OR 063087000000233 OR 063087000000287 OR 063087000000288 OR 063087000000319 OR 063087000000320 OR 063087000000282 */

            if (W.FILLER_1.WWORK_NRCTACED.In("063000300000383", "063000300001010", "063000300041428", "063087000000011", "063087000000013", "063087000000031", "063087000000033", "063087000000044", "063087000000060", "063087000000061", "063087000000062", "063087000000072", "063087000000075", "063087000000100", "063087000000113", "063087000000114", "063087000000130", "063087000000233", "063087000000287", "063087000000288", "063087000000319", "063087000000320", "063087000000282"))
            {

                /*" -813- RELEASE REG-ARQSORT */
                ARQSORT.Release(REG_ARQSORT);

                /*" -814- ADD 1 TO GV-SORT */
                W.GV_SORT.Value = W.GV_SORT + 1;

                /*" -815- ELSE */
            }
            else
            {


                /*" -815- ADD 1 TO DP-MOVIMENTO. */
                W.DP_MOVIMENTO.Value = W.DP_MOVIMENTO + 1;
            }


            /*" -0- FLUXCONTROL_PERFORM R0350_90_LEITURA */

            R0350_90_LEITURA();

        }

        [StopWatch]
        /*" R0350-90-LEITURA */
        private void R0350_90_LEITURA(bool isPerform = false)
        {
            /*" -820- PERFORM R0300-00-LER-MOVIMENTO. */

            R0300_00_LER_MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0350_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-OUTPUT-SORT-SECTION */
        private void R0500_00_OUTPUT_SORT_SECTION()
        {
            /*" -832- MOVE '0500' TO WNR-EXEC-SQL. */
            _.Move("0500", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -833- MOVE SPACES TO WFIM-SORT. */
            _.Move("", W.WFIM_SORT);

            /*" -836- PERFORM R0510-00-LE-ARQSORT. */

            R0510_00_LE_ARQSORT_SECTION();

            /*" -840- PERFORM R0550-00-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

            while (!(!W.WFIM_SORT.IsEmpty()))
            {

                R0550_00_PROCESSA_SORT_SECTION();
            }

            /*" -841- DISPLAY ' ' */
            _.Display($" ");

            /*" -842- DISPLAY 'LIDOS SORT ............ ' LD-SORT */
            _.Display($"LIDOS SORT ............ {W.LD_SORT}");

            /*" -843- DISPLAY 'GRAVADOS SICOB 00383 .. ' AC-GRAV-SAIDA01. */
            _.Display($"GRAVADOS SICOB 00383 .. {W.AC_GRAV_SAIDA01}");

            /*" -844- DISPLAY 'GRAVADOS SICOB 01010 .. ' AC-GRAV-SAIDA02. */
            _.Display($"GRAVADOS SICOB 01010 .. {W.AC_GRAV_SAIDA02}");

            /*" -845- DISPLAY 'GRAVADOS SICOB 41428 .. ' AC-GRAV-SAIDA03. */
            _.Display($"GRAVADOS SICOB 41428 .. {W.AC_GRAV_SAIDA03}");

            /*" -846- DISPLAY 'GRAVADOS SICOB 00011 .. ' AC-GRAV-SAIDA04. */
            _.Display($"GRAVADOS SICOB 00011 .. {W.AC_GRAV_SAIDA04}");

            /*" -847- DISPLAY 'GRAVADOS SICOB 00013 .. ' AC-GRAV-SAIDA05. */
            _.Display($"GRAVADOS SICOB 00013 .. {W.AC_GRAV_SAIDA05}");

            /*" -848- DISPLAY 'GRAVADOS SICOB 00031 .. ' AC-GRAV-SAIDA06. */
            _.Display($"GRAVADOS SICOB 00031 .. {W.AC_GRAV_SAIDA06}");

            /*" -849- DISPLAY 'GRAVADOS SICOB 00033 .. ' AC-GRAV-SAIDA07. */
            _.Display($"GRAVADOS SICOB 00033 .. {W.AC_GRAV_SAIDA07}");

            /*" -850- DISPLAY 'GRAVADOS SICOB 00044 .. ' AC-GRAV-SAIDA08. */
            _.Display($"GRAVADOS SICOB 00044 .. {W.AC_GRAV_SAIDA08}");

            /*" -851- DISPLAY 'GRAVADOS SICOB 00060 .. ' AC-GRAV-SAIDA09. */
            _.Display($"GRAVADOS SICOB 00060 .. {W.AC_GRAV_SAIDA09}");

            /*" -852- DISPLAY 'GRAVADOS SICOB 00061 .. ' AC-GRAV-SAIDA10. */
            _.Display($"GRAVADOS SICOB 00061 .. {W.AC_GRAV_SAIDA10}");

            /*" -853- DISPLAY 'GRAVADOS SICOB 00062 .. ' AC-GRAV-SAIDA11. */
            _.Display($"GRAVADOS SICOB 00062 .. {W.AC_GRAV_SAIDA11}");

            /*" -854- DISPLAY 'GRAVADOS SICOB 00072 .. ' AC-GRAV-SAIDA12. */
            _.Display($"GRAVADOS SICOB 00072 .. {W.AC_GRAV_SAIDA12}");

            /*" -855- DISPLAY 'GRAVADOS SICOB 00075 .. ' AC-GRAV-SAIDA13. */
            _.Display($"GRAVADOS SICOB 00075 .. {W.AC_GRAV_SAIDA13}");

            /*" -856- DISPLAY 'GRAVADOS SICOB 00100 .. ' AC-GRAV-SAIDA14. */
            _.Display($"GRAVADOS SICOB 00100 .. {W.AC_GRAV_SAIDA14}");

            /*" -857- DISPLAY 'GRAVADOS SICOB 00113 .. ' AC-GRAV-SAIDA15. */
            _.Display($"GRAVADOS SICOB 00113 .. {W.AC_GRAV_SAIDA15}");

            /*" -858- DISPLAY 'GRAVADOS SICOB 00114 .. ' AC-GRAV-SAIDA16. */
            _.Display($"GRAVADOS SICOB 00114 .. {W.AC_GRAV_SAIDA16}");

            /*" -859- DISPLAY 'GRAVADOS SICOB 00130 .. ' AC-GRAV-SAIDA17. */
            _.Display($"GRAVADOS SICOB 00130 .. {W.AC_GRAV_SAIDA17}");

            /*" -860- DISPLAY 'GRAVADOS SICOB 00233 .. ' AC-GRAV-SAIDA18. */
            _.Display($"GRAVADOS SICOB 00233 .. {W.AC_GRAV_SAIDA18}");

            /*" -861- DISPLAY 'GRAVADOS SICOB 00287 .. ' AC-GRAV-SAIDA19. */
            _.Display($"GRAVADOS SICOB 00287 .. {W.AC_GRAV_SAIDA19}");

            /*" -862- DISPLAY 'GRAVADOS SICOB 00288 .. ' AC-GRAV-SAIDA20. */
            _.Display($"GRAVADOS SICOB 00288 .. {W.AC_GRAV_SAIDA20}");

            /*" -863- DISPLAY 'GRAVADOS SICOB 00319 .. ' AC-GRAV-SAIDA21. */
            _.Display($"GRAVADOS SICOB 00319 .. {W.AC_GRAV_SAIDA21}");

            /*" -864- DISPLAY 'GRAVADOS SICOB 00320 .. ' AC-GRAV-SAIDA22. */
            _.Display($"GRAVADOS SICOB 00320 .. {W.AC_GRAV_SAIDA22}");

            /*" -865- DISPLAY 'GRAVADOS SICOB 00282 .. ' AC-GRAV-SAIDA23. */
            _.Display($"GRAVADOS SICOB 00282 .. {W.AC_GRAV_SAIDA23}");

            /*" -866- DISPLAY 'GRAVADOS SICOB       .. ' AC-GRAV-SAIDA24. */
            _.Display($"GRAVADOS SICOB       .. {W.AC_GRAV_SAIDA24}");

            /*" -867- DISPLAY 'GRAVADOS SICOB       .. ' AC-GRAV-SAIDA25. */
            _.Display($"GRAVADOS SICOB       .. {W.AC_GRAV_SAIDA25}");

            /*" -867- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R0510-00-LE-ARQSORT-SECTION */
        private void R0510_00_LE_ARQSORT_SECTION()
        {
            /*" -880- MOVE '0510' TO WNR-EXEC-SQL. */
            _.Move("0510", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -882- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_ARQSORT, () =>
                {

                    /*" -883- MOVE ZEROS TO ATU-COD-CEDENTE */
                    _.Move(0, W.ATU_COD_CEDENTE);

                    /*" -884- MOVE 'S' TO WFIM-SORT */
                    _.Move("S", W.WFIM_SORT);

                    /*" -887- GO TO R0510-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -889- ADD 1 TO LD-SORT. */
            W.LD_SORT.Value = W.LD_SORT + 1;

            /*" -889- MOVE SOR-COD-CEDENTE TO ATU-COD-CEDENTE. */
            _.Move(REG_ARQSORT.SOR_COD_CEDENTE, W.ATU_COD_CEDENTE);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0510_99_SAIDA*/

        [StopWatch]
        /*" R0550-00-PROCESSA-SORT-SECTION */
        private void R0550_00_PROCESSA_SORT_SECTION()
        {
            /*" -902- MOVE '0550' TO WNR-EXEC-SQL. */
            _.Move("0550", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -904- MOVE ATU-COD-CEDENTE TO ANT-COD-CEDENTE. */
            _.Move(W.ATU_COD_CEDENTE, W.ANT_COD_CEDENTE);

            /*" -907- PERFORM R1100-00-GRAVA-HEADER. */

            R1100_00_GRAVA_HEADER_SECTION();

            /*" -912- PERFORM R1000-00-PROCESSA-DETALHE UNTIL ATU-COD-CEDENTE NOT EQUAL ANT-COD-CEDENTE OR WFIM-SORT NOT EQUAL SPACES. */

            while (!(W.ATU_COD_CEDENTE != W.ANT_COD_CEDENTE || !W.WFIM_SORT.IsEmpty()))
            {

                R1000_00_PROCESSA_DETALHE_SECTION();
            }

            /*" -912- PERFORM R1200-00-GRAVA-TRAILLER. */

            R1200_00_GRAVA_TRAILLER_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0550_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-DETALHE-SECTION */
        private void R1000_00_PROCESSA_DETALHE_SECTION()
        {
            /*" -925- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -927- MOVE SPACES TO COBRAN-REGISTRO. */
            _.Move("", COBRAN_REGISTRO);

            /*" -929- MOVE '1' TO COBRAN-CODREGISTR. */
            _.Move("1", COBRAN_REGISTRO.COBRAN_CODREGISTR);

            /*" -931- MOVE SOR-TIPO-INSCRICAO TO COBRAN-INSCEMPRES. */
            _.Move(REG_ARQSORT.SOR_TIPO_INSCRICAO, COBRAN_REGISTRO.COBRAN_INSCEMPRES);

            /*" -933- MOVE SOR-NUM-INSCRICAO TO COBRAN-NUMINSCRIC. */
            _.Move(REG_ARQSORT.SOR_NUM_INSCRICAO, COBRAN_REGISTRO.COBRAN_NUMINSCRIC);

            /*" -935- MOVE SOR-COD-CEDENTE TO COBRAN-CODEMPRESA. */
            _.Move(REG_ARQSORT.SOR_COD_CEDENTE, COBRAN_REGISTRO.COBRAN_CODEMPRESA);

            /*" -937- MOVE SOR-TITULO-EMPRESA TO COBRAN-TITULO16. */
            _.Move(REG_ARQSORT.SOR_TITULO_EMPRESA, COBRAN_REGISTRO.COBRAN_TITULO16);

            /*" -939- MOVE SOR-TITULO-BANCO TO COBRAN-NOSS-NUMERO. */
            _.Move(REG_ARQSORT.SOR_TITULO_BANCO, COBRAN_REGISTRO.COBRAN_NOSS_NUMERO);

            /*" -941- MOVE SOR-COD-REJEICAO TO COBRAN-CODREJEIC. */
            _.Move(REG_ARQSORT.SOR_COD_REJEICAO, COBRAN_REGISTRO.COBRAN_CODREJEIC);

            /*" -943- MOVE '14' TO COBRAN-CODCARTEIRA. */
            _.Move("14", COBRAN_REGISTRO.COBRAN_CODCARTEIRA);

            /*" -945- MOVE SOR-COD-OCORRENCIA TO COBRAN-CODOCORRENC. */
            _.Move(REG_ARQSORT.SOR_COD_OCORRENCIA, COBRAN_REGISTRO.COBRAN_CODOCORRENC);

            /*" -947- MOVE SOR-DATA-VENCIMENTO TO COBRAN-DTVENCTO. */
            _.Move(REG_ARQSORT.SOR_DATA_VENCIMENTO, COBRAN_REGISTRO.COBRAN_DTVENCTO);

            /*" -949- MOVE SOR-DATA-OCORRENCIA TO COBRAN-DATAOCORREN. */
            _.Move(REG_ARQSORT.SOR_DATA_OCORRENCIA, COBRAN_REGISTRO.COBRAN_DATAOCORREN);

            /*" -951- MOVE SOR-VLR-NOMINAL-TIT TO COBRAN-VLR-CRS. */
            _.Move(REG_ARQSORT.SOR_VLR_NOMINAL_TIT, COBRAN_REGISTRO.COBRAN_VLR_CRS);

            /*" -953- MOVE SOR-COD-COMP-CAIXA TO COBRAN-COD-BCO. */
            _.Move(REG_ARQSORT.SOR_COD_COMP_CAIXA, COBRAN_REGISTRO.COBRAN_COD_BCO);

            /*" -955- MOVE SOR-AGE-COBR TO COBRAN-AGE-COBRAN. */
            _.Move(REG_ARQSORT.SOR_AGE_COBR, COBRAN_REGISTRO.COBRAN_AGE_COBRAN);

            /*" -957- MOVE SOR-AGE-DIG-COBR TO COBRAN-AGE-DIGITO. */
            _.Move(REG_ARQSORT.SOR_AGE_DIG_COBR, COBRAN_REGISTRO.COBRAN_AGE_DIGITO);

            /*" -959- MOVE SOR-ESPECIE TO COBRAN-ESPECIE. */
            _.Move(REG_ARQSORT.SOR_ESPECIE, COBRAN_REGISTRO.COBRAN_ESPECIE);

            /*" -961- MOVE SOR-VLR-TARIFA TO COBRAN-DESPESAS. */
            _.Move(REG_ARQSORT.SOR_VLR_TARIFA, COBRAN_REGISTRO.COBRAN_DESPESAS);

            /*" -963- MOVE SOR-FORMA-LIQUIDACAO TO COBRAN-FORMA-LIQ. */
            _.Move(REG_ARQSORT.SOR_FORMA_LIQUIDACAO, COBRAN_REGISTRO.COBRAN_FORMA_LIQ);

            /*" -965- MOVE SOR-FORMA-PAGAMENTO TO COBRAN-FORMA-PAG. */
            _.Move(REG_ARQSORT.SOR_FORMA_PAGAMENTO, COBRAN_REGISTRO.COBRAN_FORMA_PAG);

            /*" -967- MOVE SOR-QTD-DIAS-FLOAT TO COBRAN-FLOAT. */
            _.Move(REG_ARQSORT.SOR_QTD_DIAS_FLOAT, COBRAN_REGISTRO.COBRAN_FLOAT);

            /*" -969- MOVE SOR-DATA-DEB-TARIFA TO COBRAN-DTARIFA. */
            _.Move(REG_ARQSORT.SOR_DATA_DEB_TARIFA, COBRAN_REGISTRO.COBRAN_DTARIFA);

            /*" -971- MOVE SOR-VLR-IOF TO COBRAN-IOF. */
            _.Move(REG_ARQSORT.SOR_VLR_IOF, COBRAN_REGISTRO.COBRAN_IOF);

            /*" -973- MOVE SOR-VLR-ABATIMENTO TO COBRAN-ABATIMENTO. */
            _.Move(REG_ARQSORT.SOR_VLR_ABATIMENTO, COBRAN_REGISTRO.COBRAN_ABATIMENTO);

            /*" -975- MOVE SOR-VLR-DESCONTO TO COBRAN-DESC-CONCED. */
            _.Move(REG_ARQSORT.SOR_VLR_DESCONTO, COBRAN_REGISTRO.COBRAN_DESC_CONCED);

            /*" -977- MOVE SOR-VLR-PRINCIPAL TO COBRAN-VLR-PRINC. */
            _.Move(REG_ARQSORT.SOR_VLR_PRINCIPAL, COBRAN_REGISTRO.COBRAN_VLR_PRINC);

            /*" -979- MOVE SOR-VLR-JUROS TO COBRAN-JUROS. */
            _.Move(REG_ARQSORT.SOR_VLR_JUROS, COBRAN_REGISTRO.COBRAN_JUROS);

            /*" -981- MOVE SOR-VLR-MULTA TO COBRAN-MULTA. */
            _.Move(REG_ARQSORT.SOR_VLR_MULTA, COBRAN_REGISTRO.COBRAN_MULTA);

            /*" -983- MOVE SOR-COD-MOEDA TO COBRAN-COD-MOEDA. */
            _.Move(REG_ARQSORT.SOR_COD_MOEDA, COBRAN_REGISTRO.COBRAN_COD_MOEDA);

            /*" -985- MOVE SOR-DATA-CREDITO TO COBRAN-DATA-CRED. */
            _.Move(REG_ARQSORT.SOR_DATA_CREDITO, COBRAN_REGISTRO.COBRAN_DATA_CRED);

            /*" -987- MOVE SOR-FINANCEIRO TO COBRAN-FINANCEIRO. */
            _.Move(REG_ARQSORT.SOR_FINANCEIRO, COBRAN_REGISTRO.COBRAN_FINANCEIRO);

            /*" -989- ADD 1 TO WS-NRSEQ. */
            W.WS_NRSEQ.Value = W.WS_NRSEQ + 1;

            /*" -993- MOVE WS-NRSEQ TO COBRAN-NRSEQ. */
            _.Move(W.WS_NRSEQ, COBRAN_REGISTRO.COBRAN_NRSEQ);

            /*" -994- IF WWORK-NRCTACED EQUAL 063000300000383 */

            if (W.FILLER_1.WWORK_NRCTACED == 063000300000383)
            {

                /*" -995- WRITE REG-SAIDA01 FROM COBRAN-REGISTRO */
                _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -996- ADD 1 TO AC-GRAV-SAIDA01 */
                W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;

                /*" -997- ELSE */
            }
            else
            {


                /*" -998- IF WWORK-NRCTACED EQUAL 063000300001010 */

                if (W.FILLER_1.WWORK_NRCTACED == 063000300001010)
                {

                    /*" -999- WRITE REG-SAIDA02 FROM COBRAN-REGISTRO */
                    _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -1000- ADD 1 TO AC-GRAV-SAIDA02 */
                    W.AC_GRAV_SAIDA02.Value = W.AC_GRAV_SAIDA02 + 1;

                    /*" -1001- ELSE */
                }
                else
                {


                    /*" -1002- IF WWORK-NRCTACED EQUAL 063000300041428 */

                    if (W.FILLER_1.WWORK_NRCTACED == 063000300041428)
                    {

                        /*" -1003- WRITE REG-SAIDA03 FROM COBRAN-REGISTRO */
                        _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA03);

                        SAIDA03.Write(REG_SAIDA03.GetMoveValues().ToString());

                        /*" -1004- ADD 1 TO AC-GRAV-SAIDA03 */
                        W.AC_GRAV_SAIDA03.Value = W.AC_GRAV_SAIDA03 + 1;

                        /*" -1005- ELSE */
                    }
                    else
                    {


                        /*" -1006- IF WWORK-NRCTACED EQUAL 063087000000011 */

                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000011)
                        {

                            /*" -1007- WRITE REG-SAIDA04 FROM COBRAN-REGISTRO */
                            _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA04);

                            SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                            /*" -1008- ADD 1 TO AC-GRAV-SAIDA04 */
                            W.AC_GRAV_SAIDA04.Value = W.AC_GRAV_SAIDA04 + 1;

                            /*" -1009- ELSE */
                        }
                        else
                        {


                            /*" -1010- IF WWORK-NRCTACED EQUAL 063087000000013 */

                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000013)
                            {

                                /*" -1011- WRITE REG-SAIDA05 FROM COBRAN-REGISTRO */
                                _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA05);

                                SAIDA05.Write(REG_SAIDA05.GetMoveValues().ToString());

                                /*" -1012- ADD 1 TO AC-GRAV-SAIDA05 */
                                W.AC_GRAV_SAIDA05.Value = W.AC_GRAV_SAIDA05 + 1;

                                /*" -1013- ELSE */
                            }
                            else
                            {


                                /*" -1014- IF WWORK-NRCTACED EQUAL 063087000000031 */

                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000031)
                                {

                                    /*" -1015- WRITE REG-SAIDA06 FROM COBRAN-REGISTRO */
                                    _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA06);

                                    SAIDA06.Write(REG_SAIDA06.GetMoveValues().ToString());

                                    /*" -1016- ADD 1 TO AC-GRAV-SAIDA06 */
                                    W.AC_GRAV_SAIDA06.Value = W.AC_GRAV_SAIDA06 + 1;

                                    /*" -1017- ELSE */
                                }
                                else
                                {


                                    /*" -1018- IF WWORK-NRCTACED EQUAL 063087000000033 */

                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000033)
                                    {

                                        /*" -1019- WRITE REG-SAIDA07 FROM COBRAN-REGISTRO */
                                        _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA07);

                                        SAIDA07.Write(REG_SAIDA07.GetMoveValues().ToString());

                                        /*" -1020- ADD 1 TO AC-GRAV-SAIDA07 */
                                        W.AC_GRAV_SAIDA07.Value = W.AC_GRAV_SAIDA07 + 1;

                                        /*" -1021- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1022- IF WWORK-NRCTACED EQUAL 063087000000044 */

                                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000044)
                                        {

                                            /*" -1023- WRITE REG-SAIDA08 FROM COBRAN-REGISTRO */
                                            _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA08);

                                            SAIDA08.Write(REG_SAIDA08.GetMoveValues().ToString());

                                            /*" -1024- ADD 1 TO AC-GRAV-SAIDA08 */
                                            W.AC_GRAV_SAIDA08.Value = W.AC_GRAV_SAIDA08 + 1;

                                            /*" -1025- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1026- IF WWORK-NRCTACED EQUAL 063087000000060 */

                                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000060)
                                            {

                                                /*" -1027- WRITE REG-SAIDA09 FROM COBRAN-REGISTRO */
                                                _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA09);

                                                SAIDA09.Write(REG_SAIDA09.GetMoveValues().ToString());

                                                /*" -1028- ADD 1 TO AC-GRAV-SAIDA09 */
                                                W.AC_GRAV_SAIDA09.Value = W.AC_GRAV_SAIDA09 + 1;

                                                /*" -1029- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1030- IF WWORK-NRCTACED EQUAL 063087000000061 */

                                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000061)
                                                {

                                                    /*" -1031- WRITE REG-SAIDA10 FROM COBRAN-REGISTRO */
                                                    _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA10);

                                                    SAIDA10.Write(REG_SAIDA10.GetMoveValues().ToString());

                                                    /*" -1032- ADD 1 TO AC-GRAV-SAIDA10 */
                                                    W.AC_GRAV_SAIDA10.Value = W.AC_GRAV_SAIDA10 + 1;

                                                    /*" -1033- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1034- IF WWORK-NRCTACED EQUAL 063087000000062 */

                                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000062)
                                                    {

                                                        /*" -1035- WRITE REG-SAIDA11 FROM COBRAN-REGISTRO */
                                                        _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA11);

                                                        SAIDA11.Write(REG_SAIDA11.GetMoveValues().ToString());

                                                        /*" -1036- ADD 1 TO AC-GRAV-SAIDA11 */
                                                        W.AC_GRAV_SAIDA11.Value = W.AC_GRAV_SAIDA11 + 1;

                                                        /*" -1037- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1038- IF WWORK-NRCTACED EQUAL 063087000000072 */

                                                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000072)
                                                        {

                                                            /*" -1039- WRITE REG-SAIDA12 FROM COBRAN-REGISTRO */
                                                            _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA12);

                                                            SAIDA12.Write(REG_SAIDA12.GetMoveValues().ToString());

                                                            /*" -1040- ADD 1 TO AC-GRAV-SAIDA12 */
                                                            W.AC_GRAV_SAIDA12.Value = W.AC_GRAV_SAIDA12 + 1;

                                                            /*" -1041- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -1042- IF WWORK-NRCTACED EQUAL 063087000000075 */

                                                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000075)
                                                            {

                                                                /*" -1043- WRITE REG-SAIDA13 FROM COBRAN-REGISTRO */
                                                                _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA13);

                                                                SAIDA13.Write(REG_SAIDA13.GetMoveValues().ToString());

                                                                /*" -1044- ADD 1 TO AC-GRAV-SAIDA13 */
                                                                W.AC_GRAV_SAIDA13.Value = W.AC_GRAV_SAIDA13 + 1;

                                                                /*" -1045- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -1046- IF WWORK-NRCTACED EQUAL 063087000000100 */

                                                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000100)
                                                                {

                                                                    /*" -1047- WRITE REG-SAIDA14 FROM COBRAN-REGISTRO */
                                                                    _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA14);

                                                                    SAIDA14.Write(REG_SAIDA14.GetMoveValues().ToString());

                                                                    /*" -1048- ADD 1 TO AC-GRAV-SAIDA14 */
                                                                    W.AC_GRAV_SAIDA14.Value = W.AC_GRAV_SAIDA14 + 1;

                                                                    /*" -1049- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -1050- IF WWORK-NRCTACED EQUAL 063087000000113 */

                                                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000113)
                                                                    {

                                                                        /*" -1051- WRITE REG-SAIDA15 FROM COBRAN-REGISTRO */
                                                                        _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA15);

                                                                        SAIDA15.Write(REG_SAIDA15.GetMoveValues().ToString());

                                                                        /*" -1052- ADD 1 TO AC-GRAV-SAIDA15 */
                                                                        W.AC_GRAV_SAIDA15.Value = W.AC_GRAV_SAIDA15 + 1;

                                                                        /*" -1053- ELSE */
                                                                    }
                                                                    else
                                                                    {


                                                                        /*" -1054- IF WWORK-NRCTACED EQUAL 063087000000114 */

                                                                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000114)
                                                                        {

                                                                            /*" -1055- WRITE REG-SAIDA16 FROM COBRAN-REGISTRO */
                                                                            _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA16);

                                                                            SAIDA16.Write(REG_SAIDA16.GetMoveValues().ToString());

                                                                            /*" -1056- ADD 1 TO AC-GRAV-SAIDA16 */
                                                                            W.AC_GRAV_SAIDA16.Value = W.AC_GRAV_SAIDA16 + 1;

                                                                            /*" -1057- ELSE */
                                                                        }
                                                                        else
                                                                        {


                                                                            /*" -1058- IF WWORK-NRCTACED EQUAL 063087000000130 */

                                                                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000130)
                                                                            {

                                                                                /*" -1059- WRITE REG-SAIDA17 FROM COBRAN-REGISTRO */
                                                                                _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA17);

                                                                                SAIDA17.Write(REG_SAIDA17.GetMoveValues().ToString());

                                                                                /*" -1060- ADD 1 TO AC-GRAV-SAIDA17 */
                                                                                W.AC_GRAV_SAIDA17.Value = W.AC_GRAV_SAIDA17 + 1;

                                                                                /*" -1061- ELSE */
                                                                            }
                                                                            else
                                                                            {


                                                                                /*" -1062- IF WWORK-NRCTACED EQUAL 063087000000233 */

                                                                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000233)
                                                                                {

                                                                                    /*" -1063- WRITE REG-SAIDA18 FROM COBRAN-REGISTRO */
                                                                                    _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA18);

                                                                                    SAIDA18.Write(REG_SAIDA18.GetMoveValues().ToString());

                                                                                    /*" -1064- ADD 1 TO AC-GRAV-SAIDA18 */
                                                                                    W.AC_GRAV_SAIDA18.Value = W.AC_GRAV_SAIDA18 + 1;

                                                                                    /*" -1065- ELSE */
                                                                                }
                                                                                else
                                                                                {


                                                                                    /*" -1066- IF WWORK-NRCTACED EQUAL 063087000000287 */

                                                                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000287)
                                                                                    {

                                                                                        /*" -1067- WRITE REG-SAIDA19 FROM COBRAN-REGISTRO */
                                                                                        _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA19);

                                                                                        SAIDA19.Write(REG_SAIDA19.GetMoveValues().ToString());

                                                                                        /*" -1068- ADD 1 TO AC-GRAV-SAIDA19 */
                                                                                        W.AC_GRAV_SAIDA19.Value = W.AC_GRAV_SAIDA19 + 1;

                                                                                        /*" -1069- ELSE */
                                                                                    }
                                                                                    else
                                                                                    {


                                                                                        /*" -1070- IF WWORK-NRCTACED EQUAL 063087000000288 */

                                                                                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000288)
                                                                                        {

                                                                                            /*" -1071- WRITE REG-SAIDA20 FROM COBRAN-REGISTRO */
                                                                                            _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA20);

                                                                                            SAIDA20.Write(REG_SAIDA20.GetMoveValues().ToString());

                                                                                            /*" -1072- ADD 1 TO AC-GRAV-SAIDA20 */
                                                                                            W.AC_GRAV_SAIDA20.Value = W.AC_GRAV_SAIDA20 + 1;

                                                                                            /*" -1073- ELSE */
                                                                                        }
                                                                                        else
                                                                                        {


                                                                                            /*" -1074- IF WWORK-NRCTACED EQUAL 063087000000319 */

                                                                                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000319)
                                                                                            {

                                                                                                /*" -1075- WRITE REG-SAIDA21 FROM COBRAN-REGISTRO */
                                                                                                _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA21);

                                                                                                SAIDA21.Write(REG_SAIDA21.GetMoveValues().ToString());

                                                                                                /*" -1076- ADD 1 TO AC-GRAV-SAIDA21 */
                                                                                                W.AC_GRAV_SAIDA21.Value = W.AC_GRAV_SAIDA21 + 1;

                                                                                                /*" -1077- ELSE */
                                                                                            }
                                                                                            else
                                                                                            {


                                                                                                /*" -1078- IF WWORK-NRCTACED EQUAL 063087000000320 */

                                                                                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000320)
                                                                                                {

                                                                                                    /*" -1079- WRITE REG-SAIDA22 FROM COBRAN-REGISTRO */
                                                                                                    _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA22);

                                                                                                    SAIDA22.Write(REG_SAIDA22.GetMoveValues().ToString());

                                                                                                    /*" -1080- ADD 1 TO AC-GRAV-SAIDA22 */
                                                                                                    W.AC_GRAV_SAIDA22.Value = W.AC_GRAV_SAIDA22 + 1;

                                                                                                    /*" -1081- ELSE */
                                                                                                }
                                                                                                else
                                                                                                {


                                                                                                    /*" -1082- IF WWORK-NRCTACED EQUAL 063087000000282 */

                                                                                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000282)
                                                                                                    {

                                                                                                        /*" -1083- WRITE REG-SAIDA23 FROM COBRAN-REGISTRO */
                                                                                                        _.Move(COBRAN_REGISTRO.GetMoveValues(), REG_SAIDA23);

                                                                                                        SAIDA23.Write(REG_SAIDA23.GetMoveValues().ToString());

                                                                                                        /*" -1083- ADD 1 TO AC-GRAV-SAIDA23. */
                                                                                                        W.AC_GRAV_SAIDA23.Value = W.AC_GRAV_SAIDA23 + 1;
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

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


            /*" -0- FLUXCONTROL_PERFORM R1000_90_LEITURA */

            R1000_90_LEITURA();

        }

        [StopWatch]
        /*" R1000-90-LEITURA */
        private void R1000_90_LEITURA(bool isPerform = false)
        {
            /*" -1088- PERFORM R0510-00-LE-ARQSORT. */

            R0510_00_LE_ARQSORT_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-GRAVA-HEADER-SECTION */
        private void R1100_00_GRAVA_HEADER_SECTION()
        {
            /*" -1100- MOVE '1100' TO WNR-EXEC-SQL. */
            _.Move("1100", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1102- MOVE SPACES TO HEADER-REGISTRO. */
            _.Move("", HEADER_REGISTRO);

            /*" -1104- MOVE '0' TO HEADER-CODREGISTR. */
            _.Move("0", HEADER_REGISTRO.HEADER_CODREGISTR);

            /*" -1106- MOVE '2' TO HEADER-CODRETORNO. */
            _.Move("2", HEADER_REGISTRO.HEADER_CODRETORNO);

            /*" -1108- MOVE 'RETORNO' TO HEADER-LITRETORNO. */
            _.Move("RETORNO", HEADER_REGISTRO.HEADER_LITRETORNO);

            /*" -1110- MOVE '01' TO HEADER-CODSERVICO. */
            _.Move("01", HEADER_REGISTRO.HEADER_CODSERVICO);

            /*" -1112- MOVE 'COBRANCA' TO HEADER-LITSERVICO. */
            _.Move("COBRANCA", HEADER_REGISTRO.HEADER_LITSERVICO);

            /*" -1114- MOVE 'CAIXA SEGURADORA SA' TO HEADER-NOMEMPRESA. */
            _.Move("CAIXA SEGURADORA SA", HEADER_REGISTRO.HEADER_NOMEMPRESA);

            /*" -1116- MOVE '104' TO HEADER-CODBANCO. */
            _.Move("104", HEADER_REGISTRO.HEADER_CODBANCO);

            /*" -1118- MOVE 'CAIXA ECON. FEDERAL' TO HEADER-NOMEBANCO. */
            _.Move("CAIXA ECON. FEDERAL", HEADER_REGISTRO.HEADER_NOMEBANCO);

            /*" -1122- MOVE 1 TO WS-NRSEQ HEADER-NRSEQ. */
            _.Move(1, W.WS_NRSEQ, HEADER_REGISTRO.HEADER_NRSEQ);

            /*" -1124- MOVE SOR-DTGERACAO TO HEADER-DTGERACAO. */
            _.Move(REG_ARQSORT.SOR_DTGERACAO, HEADER_REGISTRO.HEADER_DTGERACAO);

            /*" -1127- MOVE SOR-COD-CEDENTE TO HEADER-CODEMPRESA WWORK-CODEMPRE. */
            _.Move(REG_ARQSORT.SOR_COD_CEDENTE, HEADER_REGISTRO.HEADER_CODEMPRESA, W.WWORK_CODEMPRE);

            /*" -1130- MOVE WWORK-NRCTACED TO V0CNAB-NRCTACED. */
            _.Move(W.FILLER_1.WWORK_NRCTACED, V0CNAB_NRCTACED);

            /*" -1132- PERFORM R1150-00-SELECT-CNAB. */

            R1150_00_SELECT_CNAB_SECTION();

            /*" -1136- MOVE V0CNAB-NRSEQ TO HEADER-NUMFITA. */
            _.Move(V0CNAB_NRSEQ, HEADER_REGISTRO.HEADER_NUMFITA);

            /*" -1137- IF WWORK-NRCTACED EQUAL 063000300000383 */

            if (W.FILLER_1.WWORK_NRCTACED == 063000300000383)
            {

                /*" -1138- MOVE 838300000 TO WSHOST-NRAVISO1 */
                _.Move(838300000, WSHOST_NRAVISO1);

                /*" -1139- MOVE 838399999 TO WSHOST-NRAVISO2 */
                _.Move(838399999, WSHOST_NRAVISO2);

                /*" -1140- PERFORM R1170-00-TRATA-NSAC */

                R1170_00_TRATA_NSAC_SECTION();

                /*" -1141- WRITE REG-SAIDA01 FROM HEADER-REGISTRO */
                _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -1142- ADD 1 TO AC-GRAV-SAIDA01 */
                W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;

                /*" -1143- ELSE */
            }
            else
            {


                /*" -1144- IF WWORK-NRCTACED EQUAL 063000300001010 */

                if (W.FILLER_1.WWORK_NRCTACED == 063000300001010)
                {

                    /*" -1145- MOVE 801000000 TO WSHOST-NRAVISO1 */
                    _.Move(801000000, WSHOST_NRAVISO1);

                    /*" -1146- MOVE 801099999 TO WSHOST-NRAVISO2 */
                    _.Move(801099999, WSHOST_NRAVISO2);

                    /*" -1147- PERFORM R1170-00-TRATA-NSAC */

                    R1170_00_TRATA_NSAC_SECTION();

                    /*" -1148- WRITE REG-SAIDA02 FROM HEADER-REGISTRO */
                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -1149- ADD 1 TO AC-GRAV-SAIDA02 */
                    W.AC_GRAV_SAIDA02.Value = W.AC_GRAV_SAIDA02 + 1;

                    /*" -1150- ELSE */
                }
                else
                {


                    /*" -1151- IF WWORK-NRCTACED EQUAL 063000300041428 */

                    if (W.FILLER_1.WWORK_NRCTACED == 063000300041428)
                    {

                        /*" -1152- MOVE 842800000 TO WSHOST-NRAVISO1 */
                        _.Move(842800000, WSHOST_NRAVISO1);

                        /*" -1153- MOVE 842899999 TO WSHOST-NRAVISO2 */
                        _.Move(842899999, WSHOST_NRAVISO2);

                        /*" -1154- PERFORM R1170-00-TRATA-NSAC */

                        R1170_00_TRATA_NSAC_SECTION();

                        /*" -1155- WRITE REG-SAIDA03 FROM HEADER-REGISTRO */
                        _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA03);

                        SAIDA03.Write(REG_SAIDA03.GetMoveValues().ToString());

                        /*" -1156- ADD 1 TO AC-GRAV-SAIDA03 */
                        W.AC_GRAV_SAIDA03.Value = W.AC_GRAV_SAIDA03 + 1;

                        /*" -1157- ELSE */
                    }
                    else
                    {


                        /*" -1158- IF WWORK-NRCTACED EQUAL 063087000000011 */

                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000011)
                        {

                            /*" -1159- MOVE 801100000 TO WSHOST-NRAVISO1 */
                            _.Move(801100000, WSHOST_NRAVISO1);

                            /*" -1160- MOVE 801199999 TO WSHOST-NRAVISO2 */
                            _.Move(801199999, WSHOST_NRAVISO2);

                            /*" -1161- PERFORM R1170-00-TRATA-NSAC */

                            R1170_00_TRATA_NSAC_SECTION();

                            /*" -1162- WRITE REG-SAIDA04 FROM HEADER-REGISTRO */
                            _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA04);

                            SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                            /*" -1163- ADD 1 TO AC-GRAV-SAIDA04 */
                            W.AC_GRAV_SAIDA04.Value = W.AC_GRAV_SAIDA04 + 1;

                            /*" -1164- ELSE */
                        }
                        else
                        {


                            /*" -1165- IF WWORK-NRCTACED EQUAL 063087000000013 */

                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000013)
                            {

                                /*" -1166- MOVE 801300000 TO WSHOST-NRAVISO1 */
                                _.Move(801300000, WSHOST_NRAVISO1);

                                /*" -1167- MOVE 801399999 TO WSHOST-NRAVISO2 */
                                _.Move(801399999, WSHOST_NRAVISO2);

                                /*" -1168- PERFORM R1170-00-TRATA-NSAC */

                                R1170_00_TRATA_NSAC_SECTION();

                                /*" -1169- WRITE REG-SAIDA05 FROM HEADER-REGISTRO */
                                _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA05);

                                SAIDA05.Write(REG_SAIDA05.GetMoveValues().ToString());

                                /*" -1170- ADD 1 TO AC-GRAV-SAIDA05 */
                                W.AC_GRAV_SAIDA05.Value = W.AC_GRAV_SAIDA05 + 1;

                                /*" -1171- ELSE */
                            }
                            else
                            {


                                /*" -1172- IF WWORK-NRCTACED EQUAL 063087000000031 */

                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000031)
                                {

                                    /*" -1173- MOVE 803100000 TO WSHOST-NRAVISO1 */
                                    _.Move(803100000, WSHOST_NRAVISO1);

                                    /*" -1174- MOVE 803199999 TO WSHOST-NRAVISO2 */
                                    _.Move(803199999, WSHOST_NRAVISO2);

                                    /*" -1175- PERFORM R1170-00-TRATA-NSAC */

                                    R1170_00_TRATA_NSAC_SECTION();

                                    /*" -1176- WRITE REG-SAIDA06 FROM HEADER-REGISTRO */
                                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA06);

                                    SAIDA06.Write(REG_SAIDA06.GetMoveValues().ToString());

                                    /*" -1177- ADD 1 TO AC-GRAV-SAIDA06 */
                                    W.AC_GRAV_SAIDA06.Value = W.AC_GRAV_SAIDA06 + 1;

                                    /*" -1178- ELSE */
                                }
                                else
                                {


                                    /*" -1179- IF WWORK-NRCTACED EQUAL 063087000000033 */

                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000033)
                                    {

                                        /*" -1180- MOVE 803300000 TO WSHOST-NRAVISO1 */
                                        _.Move(803300000, WSHOST_NRAVISO1);

                                        /*" -1181- MOVE 803399999 TO WSHOST-NRAVISO2 */
                                        _.Move(803399999, WSHOST_NRAVISO2);

                                        /*" -1182- PERFORM R1170-00-TRATA-NSAC */

                                        R1170_00_TRATA_NSAC_SECTION();

                                        /*" -1183- WRITE REG-SAIDA07 FROM HEADER-REGISTRO */
                                        _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA07);

                                        SAIDA07.Write(REG_SAIDA07.GetMoveValues().ToString());

                                        /*" -1184- ADD 1 TO AC-GRAV-SAIDA07 */
                                        W.AC_GRAV_SAIDA07.Value = W.AC_GRAV_SAIDA07 + 1;

                                        /*" -1185- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1186- IF WWORK-NRCTACED EQUAL 063087000000044 */

                                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000044)
                                        {

                                            /*" -1187- MOVE 804400000 TO WSHOST-NRAVISO1 */
                                            _.Move(804400000, WSHOST_NRAVISO1);

                                            /*" -1188- MOVE 804499999 TO WSHOST-NRAVISO2 */
                                            _.Move(804499999, WSHOST_NRAVISO2);

                                            /*" -1189- PERFORM R1170-00-TRATA-NSAC */

                                            R1170_00_TRATA_NSAC_SECTION();

                                            /*" -1190- WRITE REG-SAIDA08 FROM HEADER-REGISTRO */
                                            _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA08);

                                            SAIDA08.Write(REG_SAIDA08.GetMoveValues().ToString());

                                            /*" -1191- ADD 1 TO AC-GRAV-SAIDA08 */
                                            W.AC_GRAV_SAIDA08.Value = W.AC_GRAV_SAIDA08 + 1;

                                            /*" -1192- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1193- IF WWORK-NRCTACED EQUAL 063087000000060 */

                                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000060)
                                            {

                                                /*" -1194- MOVE 806000000 TO WSHOST-NRAVISO1 */
                                                _.Move(806000000, WSHOST_NRAVISO1);

                                                /*" -1195- MOVE 806099999 TO WSHOST-NRAVISO2 */
                                                _.Move(806099999, WSHOST_NRAVISO2);

                                                /*" -1196- PERFORM R1170-00-TRATA-NSAC */

                                                R1170_00_TRATA_NSAC_SECTION();

                                                /*" -1197- WRITE REG-SAIDA09 FROM HEADER-REGISTRO */
                                                _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA09);

                                                SAIDA09.Write(REG_SAIDA09.GetMoveValues().ToString());

                                                /*" -1198- ADD 1 TO AC-GRAV-SAIDA09 */
                                                W.AC_GRAV_SAIDA09.Value = W.AC_GRAV_SAIDA09 + 1;

                                                /*" -1199- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1200- IF WWORK-NRCTACED EQUAL 063087000000061 */

                                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000061)
                                                {

                                                    /*" -1201- MOVE 806100000 TO WSHOST-NRAVISO1 */
                                                    _.Move(806100000, WSHOST_NRAVISO1);

                                                    /*" -1202- MOVE 806199999 TO WSHOST-NRAVISO2 */
                                                    _.Move(806199999, WSHOST_NRAVISO2);

                                                    /*" -1203- PERFORM R1170-00-TRATA-NSAC */

                                                    R1170_00_TRATA_NSAC_SECTION();

                                                    /*" -1204- WRITE REG-SAIDA10 FROM HEADER-REGISTRO */
                                                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA10);

                                                    SAIDA10.Write(REG_SAIDA10.GetMoveValues().ToString());

                                                    /*" -1205- ADD 1 TO AC-GRAV-SAIDA10 */
                                                    W.AC_GRAV_SAIDA10.Value = W.AC_GRAV_SAIDA10 + 1;

                                                    /*" -1206- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1207- IF WWORK-NRCTACED EQUAL 063087000000062 */

                                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000062)
                                                    {

                                                        /*" -1208- MOVE 806200000 TO WSHOST-NRAVISO1 */
                                                        _.Move(806200000, WSHOST_NRAVISO1);

                                                        /*" -1209- MOVE 806299999 TO WSHOST-NRAVISO2 */
                                                        _.Move(806299999, WSHOST_NRAVISO2);

                                                        /*" -1210- PERFORM R1170-00-TRATA-NSAC */

                                                        R1170_00_TRATA_NSAC_SECTION();

                                                        /*" -1211- WRITE REG-SAIDA11 FROM HEADER-REGISTRO */
                                                        _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA11);

                                                        SAIDA11.Write(REG_SAIDA11.GetMoveValues().ToString());

                                                        /*" -1212- ADD 1 TO AC-GRAV-SAIDA11 */
                                                        W.AC_GRAV_SAIDA11.Value = W.AC_GRAV_SAIDA11 + 1;

                                                        /*" -1213- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1214- IF WWORK-NRCTACED EQUAL 063087000000072 */

                                                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000072)
                                                        {

                                                            /*" -1215- MOVE 807200000 TO WSHOST-NRAVISO1 */
                                                            _.Move(807200000, WSHOST_NRAVISO1);

                                                            /*" -1216- MOVE 807299999 TO WSHOST-NRAVISO2 */
                                                            _.Move(807299999, WSHOST_NRAVISO2);

                                                            /*" -1217- PERFORM R1170-00-TRATA-NSAC */

                                                            R1170_00_TRATA_NSAC_SECTION();

                                                            /*" -1218- WRITE REG-SAIDA12 FROM HEADER-REGISTRO */
                                                            _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA12);

                                                            SAIDA12.Write(REG_SAIDA12.GetMoveValues().ToString());

                                                            /*" -1219- ADD 1 TO AC-GRAV-SAIDA12 */
                                                            W.AC_GRAV_SAIDA12.Value = W.AC_GRAV_SAIDA12 + 1;

                                                            /*" -1220- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -1221- IF WWORK-NRCTACED EQUAL 063087000000075 */

                                                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000075)
                                                            {

                                                                /*" -1222- MOVE 807500000 TO WSHOST-NRAVISO1 */
                                                                _.Move(807500000, WSHOST_NRAVISO1);

                                                                /*" -1223- MOVE 807599999 TO WSHOST-NRAVISO2 */
                                                                _.Move(807599999, WSHOST_NRAVISO2);

                                                                /*" -1224- PERFORM R1170-00-TRATA-NSAC */

                                                                R1170_00_TRATA_NSAC_SECTION();

                                                                /*" -1225- WRITE REG-SAIDA13 FROM HEADER-REGISTRO */
                                                                _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA13);

                                                                SAIDA13.Write(REG_SAIDA13.GetMoveValues().ToString());

                                                                /*" -1226- ADD 1 TO AC-GRAV-SAIDA13 */
                                                                W.AC_GRAV_SAIDA13.Value = W.AC_GRAV_SAIDA13 + 1;

                                                                /*" -1227- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -1228- IF WWORK-NRCTACED EQUAL 063087000000100 */

                                                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000100)
                                                                {

                                                                    /*" -1229- MOVE 810000000 TO WSHOST-NRAVISO1 */
                                                                    _.Move(810000000, WSHOST_NRAVISO1);

                                                                    /*" -1230- MOVE 810099999 TO WSHOST-NRAVISO2 */
                                                                    _.Move(810099999, WSHOST_NRAVISO2);

                                                                    /*" -1231- PERFORM R1170-00-TRATA-NSAC */

                                                                    R1170_00_TRATA_NSAC_SECTION();

                                                                    /*" -1232- WRITE REG-SAIDA14 FROM HEADER-REGISTRO */
                                                                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA14);

                                                                    SAIDA14.Write(REG_SAIDA14.GetMoveValues().ToString());

                                                                    /*" -1233- ADD 1 TO AC-GRAV-SAIDA14 */
                                                                    W.AC_GRAV_SAIDA14.Value = W.AC_GRAV_SAIDA14 + 1;

                                                                    /*" -1234- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -1235- IF WWORK-NRCTACED EQUAL 063087000000113 */

                                                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000113)
                                                                    {

                                                                        /*" -1236- MOVE 811300000 TO WSHOST-NRAVISO1 */
                                                                        _.Move(811300000, WSHOST_NRAVISO1);

                                                                        /*" -1237- MOVE 811399999 TO WSHOST-NRAVISO2 */
                                                                        _.Move(811399999, WSHOST_NRAVISO2);

                                                                        /*" -1238- PERFORM R1170-00-TRATA-NSAC */

                                                                        R1170_00_TRATA_NSAC_SECTION();

                                                                        /*" -1239- WRITE REG-SAIDA15 FROM HEADER-REGISTRO */
                                                                        _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA15);

                                                                        SAIDA15.Write(REG_SAIDA15.GetMoveValues().ToString());

                                                                        /*" -1240- ADD 1 TO AC-GRAV-SAIDA15 */
                                                                        W.AC_GRAV_SAIDA15.Value = W.AC_GRAV_SAIDA15 + 1;

                                                                        /*" -1241- ELSE */
                                                                    }
                                                                    else
                                                                    {


                                                                        /*" -1242- IF WWORK-NRCTACED EQUAL 063087000000114 */

                                                                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000114)
                                                                        {

                                                                            /*" -1243- MOVE 811400000 TO WSHOST-NRAVISO1 */
                                                                            _.Move(811400000, WSHOST_NRAVISO1);

                                                                            /*" -1244- MOVE 811499999 TO WSHOST-NRAVISO2 */
                                                                            _.Move(811499999, WSHOST_NRAVISO2);

                                                                            /*" -1245- PERFORM R1170-00-TRATA-NSAC */

                                                                            R1170_00_TRATA_NSAC_SECTION();

                                                                            /*" -1246- WRITE REG-SAIDA16 FROM HEADER-REGISTRO */
                                                                            _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA16);

                                                                            SAIDA16.Write(REG_SAIDA16.GetMoveValues().ToString());

                                                                            /*" -1247- ADD 1 TO AC-GRAV-SAIDA16 */
                                                                            W.AC_GRAV_SAIDA16.Value = W.AC_GRAV_SAIDA16 + 1;

                                                                            /*" -1248- ELSE */
                                                                        }
                                                                        else
                                                                        {


                                                                            /*" -1249- IF WWORK-NRCTACED EQUAL 063087000000130 */

                                                                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000130)
                                                                            {

                                                                                /*" -1250- MOVE 813000000 TO WSHOST-NRAVISO1 */
                                                                                _.Move(813000000, WSHOST_NRAVISO1);

                                                                                /*" -1251- MOVE 813099999 TO WSHOST-NRAVISO2 */
                                                                                _.Move(813099999, WSHOST_NRAVISO2);

                                                                                /*" -1252- PERFORM R1170-00-TRATA-NSAC */

                                                                                R1170_00_TRATA_NSAC_SECTION();

                                                                                /*" -1253- WRITE REG-SAIDA17 FROM HEADER-REGISTRO */
                                                                                _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA17);

                                                                                SAIDA17.Write(REG_SAIDA17.GetMoveValues().ToString());

                                                                                /*" -1254- ADD 1 TO AC-GRAV-SAIDA17 */
                                                                                W.AC_GRAV_SAIDA17.Value = W.AC_GRAV_SAIDA17 + 1;

                                                                                /*" -1255- ELSE */
                                                                            }
                                                                            else
                                                                            {


                                                                                /*" -1256- IF WWORK-NRCTACED EQUAL 063087000000233 */

                                                                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000233)
                                                                                {

                                                                                    /*" -1257- MOVE 823300000 TO WSHOST-NRAVISO1 */
                                                                                    _.Move(823300000, WSHOST_NRAVISO1);

                                                                                    /*" -1258- MOVE 823399999 TO WSHOST-NRAVISO2 */
                                                                                    _.Move(823399999, WSHOST_NRAVISO2);

                                                                                    /*" -1259- PERFORM R1170-00-TRATA-NSAC */

                                                                                    R1170_00_TRATA_NSAC_SECTION();

                                                                                    /*" -1260- WRITE REG-SAIDA18 FROM HEADER-REGISTRO */
                                                                                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA18);

                                                                                    SAIDA18.Write(REG_SAIDA18.GetMoveValues().ToString());

                                                                                    /*" -1261- ADD 1 TO AC-GRAV-SAIDA18 */
                                                                                    W.AC_GRAV_SAIDA18.Value = W.AC_GRAV_SAIDA18 + 1;

                                                                                    /*" -1262- ELSE */
                                                                                }
                                                                                else
                                                                                {


                                                                                    /*" -1263- IF WWORK-NRCTACED EQUAL 063087000000287 */

                                                                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000287)
                                                                                    {

                                                                                        /*" -1264- MOVE 828700000 TO WSHOST-NRAVISO1 */
                                                                                        _.Move(828700000, WSHOST_NRAVISO1);

                                                                                        /*" -1265- MOVE 828799999 TO WSHOST-NRAVISO2 */
                                                                                        _.Move(828799999, WSHOST_NRAVISO2);

                                                                                        /*" -1266- PERFORM R1170-00-TRATA-NSAC */

                                                                                        R1170_00_TRATA_NSAC_SECTION();

                                                                                        /*" -1267- WRITE REG-SAIDA19 FROM HEADER-REGISTRO */
                                                                                        _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA19);

                                                                                        SAIDA19.Write(REG_SAIDA19.GetMoveValues().ToString());

                                                                                        /*" -1268- ADD 1 TO AC-GRAV-SAIDA19 */
                                                                                        W.AC_GRAV_SAIDA19.Value = W.AC_GRAV_SAIDA19 + 1;

                                                                                        /*" -1269- ELSE */
                                                                                    }
                                                                                    else
                                                                                    {


                                                                                        /*" -1270- IF WWORK-NRCTACED EQUAL 063087000000288 */

                                                                                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000288)
                                                                                        {

                                                                                            /*" -1271- MOVE 828800000 TO WSHOST-NRAVISO1 */
                                                                                            _.Move(828800000, WSHOST_NRAVISO1);

                                                                                            /*" -1272- MOVE 828899999 TO WSHOST-NRAVISO2 */
                                                                                            _.Move(828899999, WSHOST_NRAVISO2);

                                                                                            /*" -1273- PERFORM R1170-00-TRATA-NSAC */

                                                                                            R1170_00_TRATA_NSAC_SECTION();

                                                                                            /*" -1274- WRITE REG-SAIDA20 FROM HEADER-REGISTRO */
                                                                                            _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA20);

                                                                                            SAIDA20.Write(REG_SAIDA20.GetMoveValues().ToString());

                                                                                            /*" -1275- ADD 1 TO AC-GRAV-SAIDA20 */
                                                                                            W.AC_GRAV_SAIDA20.Value = W.AC_GRAV_SAIDA20 + 1;

                                                                                            /*" -1276- ELSE */
                                                                                        }
                                                                                        else
                                                                                        {


                                                                                            /*" -1277- IF WWORK-NRCTACED EQUAL 063087000000319 */

                                                                                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000319)
                                                                                            {

                                                                                                /*" -1278- MOVE 831900000 TO WSHOST-NRAVISO1 */
                                                                                                _.Move(831900000, WSHOST_NRAVISO1);

                                                                                                /*" -1279- MOVE 831999999 TO WSHOST-NRAVISO2 */
                                                                                                _.Move(831999999, WSHOST_NRAVISO2);

                                                                                                /*" -1280- PERFORM R1170-00-TRATA-NSAC */

                                                                                                R1170_00_TRATA_NSAC_SECTION();

                                                                                                /*" -1281- WRITE REG-SAIDA21 FROM HEADER-REGISTRO */
                                                                                                _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA21);

                                                                                                SAIDA21.Write(REG_SAIDA21.GetMoveValues().ToString());

                                                                                                /*" -1282- ADD 1 TO AC-GRAV-SAIDA21 */
                                                                                                W.AC_GRAV_SAIDA21.Value = W.AC_GRAV_SAIDA21 + 1;

                                                                                                /*" -1283- ELSE */
                                                                                            }
                                                                                            else
                                                                                            {


                                                                                                /*" -1284- IF WWORK-NRCTACED EQUAL 063087000000320 */

                                                                                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000320)
                                                                                                {

                                                                                                    /*" -1285- MOVE 832000000 TO WSHOST-NRAVISO1 */
                                                                                                    _.Move(832000000, WSHOST_NRAVISO1);

                                                                                                    /*" -1286- MOVE 832099999 TO WSHOST-NRAVISO2 */
                                                                                                    _.Move(832099999, WSHOST_NRAVISO2);

                                                                                                    /*" -1287- PERFORM R1170-00-TRATA-NSAC */

                                                                                                    R1170_00_TRATA_NSAC_SECTION();

                                                                                                    /*" -1288- WRITE REG-SAIDA22 FROM HEADER-REGISTRO */
                                                                                                    _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA22);

                                                                                                    SAIDA22.Write(REG_SAIDA22.GetMoveValues().ToString());

                                                                                                    /*" -1289- ADD 1 TO AC-GRAV-SAIDA22 */
                                                                                                    W.AC_GRAV_SAIDA22.Value = W.AC_GRAV_SAIDA22 + 1;

                                                                                                    /*" -1290- ELSE */
                                                                                                }
                                                                                                else
                                                                                                {


                                                                                                    /*" -1291- IF WWORK-NRCTACED EQUAL 063087000000282 */

                                                                                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000282)
                                                                                                    {

                                                                                                        /*" -1292- MOVE 828200000 TO WSHOST-NRAVISO1 */
                                                                                                        _.Move(828200000, WSHOST_NRAVISO1);

                                                                                                        /*" -1293- MOVE 828299999 TO WSHOST-NRAVISO2 */
                                                                                                        _.Move(828299999, WSHOST_NRAVISO2);

                                                                                                        /*" -1294- PERFORM R1170-00-TRATA-NSAC */

                                                                                                        R1170_00_TRATA_NSAC_SECTION();

                                                                                                        /*" -1295- WRITE REG-SAIDA23 FROM HEADER-REGISTRO */
                                                                                                        _.Move(HEADER_REGISTRO.GetMoveValues(), REG_SAIDA23);

                                                                                                        SAIDA23.Write(REG_SAIDA23.GetMoveValues().ToString());

                                                                                                        /*" -1295- ADD 1 TO AC-GRAV-SAIDA23. */
                                                                                                        W.AC_GRAV_SAIDA23.Value = W.AC_GRAV_SAIDA23 + 1;
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

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1150-00-SELECT-CNAB-SECTION */
        private void R1150_00_SELECT_CNAB_SECTION()
        {
            /*" -1307- MOVE '1150' TO WNR-EXEC-SQL. */
            _.Move("1150", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1313- PERFORM R1150_00_SELECT_CNAB_DB_SELECT_1 */

            R1150_00_SELECT_CNAB_DB_SELECT_1();

            /*" -1317- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1318- DISPLAY 'R1150-00 - PROBLEMAS NO SELECT(CONTROCNAB)' */
                _.Display($"R1150-00 - PROBLEMAS NO SELECT(CONTROCNAB)");

                /*" -1321- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1322- ADD 1 TO V0CNAB-NRSEQ. */
            V0CNAB_NRSEQ.Value = V0CNAB_NRSEQ + 1;

        }

        [StopWatch]
        /*" R1150-00-SELECT-CNAB-DB-SELECT-1 */
        public void R1150_00_SELECT_CNAB_DB_SELECT_1()
        {
            /*" -1313- EXEC SQL SELECT VALUE(MAX(NRSEQ),0) INTO :V0CNAB-NRSEQ FROM SEGUROS.V0CONTROCNAB WHERE NRCTACED = :V0CNAB-NRCTACED WITH UR END-EXEC. */

            var r1150_00_SELECT_CNAB_DB_SELECT_1_Query1 = new R1150_00_SELECT_CNAB_DB_SELECT_1_Query1()
            {
                V0CNAB_NRCTACED = V0CNAB_NRCTACED.ToString(),
            };

            var executed_1 = R1150_00_SELECT_CNAB_DB_SELECT_1_Query1.Execute(r1150_00_SELECT_CNAB_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CNAB_NRSEQ, V0CNAB_NRSEQ);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1150_99_SAIDA*/

        [StopWatch]
        /*" R1170-00-TRATA-NSAC-SECTION */
        private void R1170_00_TRATA_NSAC_SECTION()
        {
            /*" -1335- MOVE '1170' TO WNR-EXEC-SQL. */
            _.Move("1170", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1337- PERFORM R1180-00-SELECT-AVISOCRE. */

            R1180_00_SELECT_AVISOCRE_SECTION();

            /*" -1341- MOVE AVISOCRE-NUM-AVISO-CREDITO TO WS0-NRAVISO. */
            _.Move(AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO, W.WS0_NRAVISO);

            /*" -1342- IF WS0-NRO-NSAC GREATER HEADER-NUMFITA */

            if (W.FILLER_0.WS0_NRO_NSAC > HEADER_REGISTRO.HEADER_NUMFITA)
            {

                /*" -1342- MOVE WS0-NRO-NSAC TO HEADER-NUMFITA. */
                _.Move(W.FILLER_0.WS0_NRO_NSAC, HEADER_REGISTRO.HEADER_NUMFITA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1170_99_SAIDA*/

        [StopWatch]
        /*" R1180-00-SELECT-AVISOCRE-SECTION */
        private void R1180_00_SELECT_AVISOCRE_SECTION()
        {
            /*" -1355- MOVE '1180' TO WNR-EXEC-SQL. */
            _.Move("1180", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1363- PERFORM R1180_00_SELECT_AVISOCRE_DB_SELECT_1 */

            R1180_00_SELECT_AVISOCRE_DB_SELECT_1();

            /*" -1367- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1368- DISPLAY 'R1180-00 - PROBLEMAS NO SELECT(AVISOCRE)' */
                _.Display($"R1180-00 - PROBLEMAS NO SELECT(AVISOCRE)");

                /*" -1371- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1372- ADD 1 TO AVISOCRE-NUM-AVISO-CREDITO. */
            AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO.Value = AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO + 1;

        }

        [StopWatch]
        /*" R1180-00-SELECT-AVISOCRE-DB-SELECT-1 */
        public void R1180_00_SELECT_AVISOCRE_DB_SELECT_1()
        {
            /*" -1363- EXEC SQL SELECT VALUE(MAX(NUM_AVISO_CREDITO),0) INTO :AVISOCRE-NUM-AVISO-CREDITO FROM SEGUROS.AVISO_CREDITO WHERE NUM_AVISO_CREDITO BETWEEN :WSHOST-NRAVISO1 AND :WSHOST-NRAVISO2 WITH UR END-EXEC. */

            var r1180_00_SELECT_AVISOCRE_DB_SELECT_1_Query1 = new R1180_00_SELECT_AVISOCRE_DB_SELECT_1_Query1()
            {
                WSHOST_NRAVISO1 = WSHOST_NRAVISO1.ToString(),
                WSHOST_NRAVISO2 = WSHOST_NRAVISO2.ToString(),
            };

            var executed_1 = R1180_00_SELECT_AVISOCRE_DB_SELECT_1_Query1.Execute(r1180_00_SELECT_AVISOCRE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.AVISOCRE_NUM_AVISO_CREDITO, AVISOCRE.DCLAVISO_CREDITO.AVISOCRE_NUM_AVISO_CREDITO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1180_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-GRAVA-TRAILLER-SECTION */
        private void R1200_00_GRAVA_TRAILLER_SECTION()
        {
            /*" -1385- MOVE '1200' TO WNR-EXEC-SQL. */
            _.Move("1200", ABEN.WABEND.WNR_EXEC_SQL);

            /*" -1387- MOVE SPACES TO TRAILL-REGISTRO. */
            _.Move("", TRAILL_REGISTRO);

            /*" -1389- MOVE '9' TO TRAILL-CODREGISTR. */
            _.Move("9", TRAILL_REGISTRO.TRAILL_CODREGISTR);

            /*" -1391- MOVE 2 TO TRAILL-COD-RETORNO. */
            _.Move(2, TRAILL_REGISTRO.TRAILL_COD_RETORNO);

            /*" -1393- MOVE 1 TO TRAILL-COD-SERVICO. */
            _.Move(1, TRAILL_REGISTRO.TRAILL_COD_SERVICO);

            /*" -1395- MOVE 104 TO TRAILL-COD-BANCO. */
            _.Move(104, TRAILL_REGISTRO.TRAILL_COD_BANCO);

            /*" -1396- ADD 1 TO WS-NRSEQ. */
            W.WS_NRSEQ.Value = W.WS_NRSEQ + 1;

            /*" -1398- MOVE WS-NRSEQ TO TRAILL-NRSEQ. */
            _.Move(W.WS_NRSEQ, TRAILL_REGISTRO.TRAILL_NRSEQ);

            /*" -1399- IF WWORK-NRCTACED EQUAL 063000300000383 */

            if (W.FILLER_1.WWORK_NRCTACED == 063000300000383)
            {

                /*" -1400- WRITE REG-SAIDA01 FROM TRAILL-REGISTRO */
                _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA01);

                SAIDA01.Write(REG_SAIDA01.GetMoveValues().ToString());

                /*" -1401- ADD 1 TO AC-GRAV-SAIDA01 */
                W.AC_GRAV_SAIDA01.Value = W.AC_GRAV_SAIDA01 + 1;

                /*" -1402- ELSE */
            }
            else
            {


                /*" -1403- IF WWORK-NRCTACED EQUAL 063000300001010 */

                if (W.FILLER_1.WWORK_NRCTACED == 063000300001010)
                {

                    /*" -1404- WRITE REG-SAIDA02 FROM TRAILL-REGISTRO */
                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA02);

                    SAIDA02.Write(REG_SAIDA02.GetMoveValues().ToString());

                    /*" -1405- ADD 1 TO AC-GRAV-SAIDA02 */
                    W.AC_GRAV_SAIDA02.Value = W.AC_GRAV_SAIDA02 + 1;

                    /*" -1406- ELSE */
                }
                else
                {


                    /*" -1407- IF WWORK-NRCTACED EQUAL 063000300041428 */

                    if (W.FILLER_1.WWORK_NRCTACED == 063000300041428)
                    {

                        /*" -1408- WRITE REG-SAIDA03 FROM TRAILL-REGISTRO */
                        _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA03);

                        SAIDA03.Write(REG_SAIDA03.GetMoveValues().ToString());

                        /*" -1409- ADD 1 TO AC-GRAV-SAIDA03 */
                        W.AC_GRAV_SAIDA03.Value = W.AC_GRAV_SAIDA03 + 1;

                        /*" -1410- ELSE */
                    }
                    else
                    {


                        /*" -1411- IF WWORK-NRCTACED EQUAL 063087000000011 */

                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000011)
                        {

                            /*" -1412- WRITE REG-SAIDA04 FROM TRAILL-REGISTRO */
                            _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA04);

                            SAIDA04.Write(REG_SAIDA04.GetMoveValues().ToString());

                            /*" -1413- ADD 1 TO AC-GRAV-SAIDA04 */
                            W.AC_GRAV_SAIDA04.Value = W.AC_GRAV_SAIDA04 + 1;

                            /*" -1414- ELSE */
                        }
                        else
                        {


                            /*" -1415- IF WWORK-NRCTACED EQUAL 063087000000013 */

                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000013)
                            {

                                /*" -1416- WRITE REG-SAIDA05 FROM TRAILL-REGISTRO */
                                _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA05);

                                SAIDA05.Write(REG_SAIDA05.GetMoveValues().ToString());

                                /*" -1417- ADD 1 TO AC-GRAV-SAIDA05 */
                                W.AC_GRAV_SAIDA05.Value = W.AC_GRAV_SAIDA05 + 1;

                                /*" -1418- ELSE */
                            }
                            else
                            {


                                /*" -1419- IF WWORK-NRCTACED EQUAL 063087000000031 */

                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000031)
                                {

                                    /*" -1420- WRITE REG-SAIDA06 FROM TRAILL-REGISTRO */
                                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA06);

                                    SAIDA06.Write(REG_SAIDA06.GetMoveValues().ToString());

                                    /*" -1421- ADD 1 TO AC-GRAV-SAIDA06 */
                                    W.AC_GRAV_SAIDA06.Value = W.AC_GRAV_SAIDA06 + 1;

                                    /*" -1422- ELSE */
                                }
                                else
                                {


                                    /*" -1423- IF WWORK-NRCTACED EQUAL 063087000000033 */

                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000033)
                                    {

                                        /*" -1424- WRITE REG-SAIDA07 FROM TRAILL-REGISTRO */
                                        _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA07);

                                        SAIDA07.Write(REG_SAIDA07.GetMoveValues().ToString());

                                        /*" -1425- ADD 1 TO AC-GRAV-SAIDA07 */
                                        W.AC_GRAV_SAIDA07.Value = W.AC_GRAV_SAIDA07 + 1;

                                        /*" -1426- ELSE */
                                    }
                                    else
                                    {


                                        /*" -1427- IF WWORK-NRCTACED EQUAL 063087000000044 */

                                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000044)
                                        {

                                            /*" -1428- WRITE REG-SAIDA08 FROM TRAILL-REGISTRO */
                                            _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA08);

                                            SAIDA08.Write(REG_SAIDA08.GetMoveValues().ToString());

                                            /*" -1429- ADD 1 TO AC-GRAV-SAIDA08 */
                                            W.AC_GRAV_SAIDA08.Value = W.AC_GRAV_SAIDA08 + 1;

                                            /*" -1430- ELSE */
                                        }
                                        else
                                        {


                                            /*" -1431- IF WWORK-NRCTACED EQUAL 063087000000060 */

                                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000060)
                                            {

                                                /*" -1432- WRITE REG-SAIDA09 FROM TRAILL-REGISTRO */
                                                _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA09);

                                                SAIDA09.Write(REG_SAIDA09.GetMoveValues().ToString());

                                                /*" -1433- ADD 1 TO AC-GRAV-SAIDA09 */
                                                W.AC_GRAV_SAIDA09.Value = W.AC_GRAV_SAIDA09 + 1;

                                                /*" -1434- ELSE */
                                            }
                                            else
                                            {


                                                /*" -1435- IF WWORK-NRCTACED EQUAL 063087000000061 */

                                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000061)
                                                {

                                                    /*" -1436- WRITE REG-SAIDA10 FROM TRAILL-REGISTRO */
                                                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA10);

                                                    SAIDA10.Write(REG_SAIDA10.GetMoveValues().ToString());

                                                    /*" -1437- ADD 1 TO AC-GRAV-SAIDA10 */
                                                    W.AC_GRAV_SAIDA10.Value = W.AC_GRAV_SAIDA10 + 1;

                                                    /*" -1438- ELSE */
                                                }
                                                else
                                                {


                                                    /*" -1439- IF WWORK-NRCTACED EQUAL 063087000000062 */

                                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000062)
                                                    {

                                                        /*" -1440- WRITE REG-SAIDA11 FROM TRAILL-REGISTRO */
                                                        _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA11);

                                                        SAIDA11.Write(REG_SAIDA11.GetMoveValues().ToString());

                                                        /*" -1441- ADD 1 TO AC-GRAV-SAIDA11 */
                                                        W.AC_GRAV_SAIDA11.Value = W.AC_GRAV_SAIDA11 + 1;

                                                        /*" -1442- ELSE */
                                                    }
                                                    else
                                                    {


                                                        /*" -1443- IF WWORK-NRCTACED EQUAL 063087000000072 */

                                                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000072)
                                                        {

                                                            /*" -1444- WRITE REG-SAIDA12 FROM TRAILL-REGISTRO */
                                                            _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA12);

                                                            SAIDA12.Write(REG_SAIDA12.GetMoveValues().ToString());

                                                            /*" -1445- ADD 1 TO AC-GRAV-SAIDA12 */
                                                            W.AC_GRAV_SAIDA12.Value = W.AC_GRAV_SAIDA12 + 1;

                                                            /*" -1446- ELSE */
                                                        }
                                                        else
                                                        {


                                                            /*" -1447- IF WWORK-NRCTACED EQUAL 063087000000075 */

                                                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000075)
                                                            {

                                                                /*" -1448- WRITE REG-SAIDA13 FROM TRAILL-REGISTRO */
                                                                _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA13);

                                                                SAIDA13.Write(REG_SAIDA13.GetMoveValues().ToString());

                                                                /*" -1449- ADD 1 TO AC-GRAV-SAIDA13 */
                                                                W.AC_GRAV_SAIDA13.Value = W.AC_GRAV_SAIDA13 + 1;

                                                                /*" -1450- ELSE */
                                                            }
                                                            else
                                                            {


                                                                /*" -1451- IF WWORK-NRCTACED EQUAL 063087000000100 */

                                                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000100)
                                                                {

                                                                    /*" -1452- WRITE REG-SAIDA14 FROM TRAILL-REGISTRO */
                                                                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA14);

                                                                    SAIDA14.Write(REG_SAIDA14.GetMoveValues().ToString());

                                                                    /*" -1453- ADD 1 TO AC-GRAV-SAIDA14 */
                                                                    W.AC_GRAV_SAIDA14.Value = W.AC_GRAV_SAIDA14 + 1;

                                                                    /*" -1454- ELSE */
                                                                }
                                                                else
                                                                {


                                                                    /*" -1455- IF WWORK-NRCTACED EQUAL 063087000000113 */

                                                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000113)
                                                                    {

                                                                        /*" -1456- WRITE REG-SAIDA15 FROM TRAILL-REGISTRO */
                                                                        _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA15);

                                                                        SAIDA15.Write(REG_SAIDA15.GetMoveValues().ToString());

                                                                        /*" -1457- ADD 1 TO AC-GRAV-SAIDA15 */
                                                                        W.AC_GRAV_SAIDA15.Value = W.AC_GRAV_SAIDA15 + 1;

                                                                        /*" -1458- ELSE */
                                                                    }
                                                                    else
                                                                    {


                                                                        /*" -1459- IF WWORK-NRCTACED EQUAL 063087000000114 */

                                                                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000114)
                                                                        {

                                                                            /*" -1460- WRITE REG-SAIDA16 FROM TRAILL-REGISTRO */
                                                                            _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA16);

                                                                            SAIDA16.Write(REG_SAIDA16.GetMoveValues().ToString());

                                                                            /*" -1461- ADD 1 TO AC-GRAV-SAIDA16 */
                                                                            W.AC_GRAV_SAIDA16.Value = W.AC_GRAV_SAIDA16 + 1;

                                                                            /*" -1462- ELSE */
                                                                        }
                                                                        else
                                                                        {


                                                                            /*" -1463- IF WWORK-NRCTACED EQUAL 063087000000130 */

                                                                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000130)
                                                                            {

                                                                                /*" -1464- WRITE REG-SAIDA17 FROM TRAILL-REGISTRO */
                                                                                _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA17);

                                                                                SAIDA17.Write(REG_SAIDA17.GetMoveValues().ToString());

                                                                                /*" -1465- ADD 1 TO AC-GRAV-SAIDA17 */
                                                                                W.AC_GRAV_SAIDA17.Value = W.AC_GRAV_SAIDA17 + 1;

                                                                                /*" -1466- ELSE */
                                                                            }
                                                                            else
                                                                            {


                                                                                /*" -1467- IF WWORK-NRCTACED EQUAL 063087000000233 */

                                                                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000233)
                                                                                {

                                                                                    /*" -1468- WRITE REG-SAIDA18 FROM TRAILL-REGISTRO */
                                                                                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA18);

                                                                                    SAIDA18.Write(REG_SAIDA18.GetMoveValues().ToString());

                                                                                    /*" -1469- ADD 1 TO AC-GRAV-SAIDA18 */
                                                                                    W.AC_GRAV_SAIDA18.Value = W.AC_GRAV_SAIDA18 + 1;

                                                                                    /*" -1470- ELSE */
                                                                                }
                                                                                else
                                                                                {


                                                                                    /*" -1471- IF WWORK-NRCTACED EQUAL 063087000000287 */

                                                                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000287)
                                                                                    {

                                                                                        /*" -1472- WRITE REG-SAIDA19 FROM TRAILL-REGISTRO */
                                                                                        _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA19);

                                                                                        SAIDA19.Write(REG_SAIDA19.GetMoveValues().ToString());

                                                                                        /*" -1473- ADD 1 TO AC-GRAV-SAIDA19 */
                                                                                        W.AC_GRAV_SAIDA19.Value = W.AC_GRAV_SAIDA19 + 1;

                                                                                        /*" -1474- ELSE */
                                                                                    }
                                                                                    else
                                                                                    {


                                                                                        /*" -1475- IF WWORK-NRCTACED EQUAL 063087000000288 */

                                                                                        if (W.FILLER_1.WWORK_NRCTACED == 063087000000288)
                                                                                        {

                                                                                            /*" -1476- WRITE REG-SAIDA20 FROM TRAILL-REGISTRO */
                                                                                            _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA20);

                                                                                            SAIDA20.Write(REG_SAIDA20.GetMoveValues().ToString());

                                                                                            /*" -1477- ADD 1 TO AC-GRAV-SAIDA20 */
                                                                                            W.AC_GRAV_SAIDA20.Value = W.AC_GRAV_SAIDA20 + 1;

                                                                                            /*" -1478- ELSE */
                                                                                        }
                                                                                        else
                                                                                        {


                                                                                            /*" -1479- IF WWORK-NRCTACED EQUAL 063087000000319 */

                                                                                            if (W.FILLER_1.WWORK_NRCTACED == 063087000000319)
                                                                                            {

                                                                                                /*" -1480- WRITE REG-SAIDA21 FROM TRAILL-REGISTRO */
                                                                                                _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA21);

                                                                                                SAIDA21.Write(REG_SAIDA21.GetMoveValues().ToString());

                                                                                                /*" -1481- ADD 1 TO AC-GRAV-SAIDA21 */
                                                                                                W.AC_GRAV_SAIDA21.Value = W.AC_GRAV_SAIDA21 + 1;

                                                                                                /*" -1482- ELSE */
                                                                                            }
                                                                                            else
                                                                                            {


                                                                                                /*" -1483- IF WWORK-NRCTACED EQUAL 063087000000320 */

                                                                                                if (W.FILLER_1.WWORK_NRCTACED == 063087000000320)
                                                                                                {

                                                                                                    /*" -1484- WRITE REG-SAIDA22 FROM TRAILL-REGISTRO */
                                                                                                    _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA22);

                                                                                                    SAIDA22.Write(REG_SAIDA22.GetMoveValues().ToString());

                                                                                                    /*" -1485- ADD 1 TO AC-GRAV-SAIDA22 */
                                                                                                    W.AC_GRAV_SAIDA22.Value = W.AC_GRAV_SAIDA22 + 1;

                                                                                                    /*" -1486- ELSE */
                                                                                                }
                                                                                                else
                                                                                                {


                                                                                                    /*" -1487- IF WWORK-NRCTACED EQUAL 063087000000282 */

                                                                                                    if (W.FILLER_1.WWORK_NRCTACED == 063087000000282)
                                                                                                    {

                                                                                                        /*" -1488- WRITE REG-SAIDA23 FROM TRAILL-REGISTRO */
                                                                                                        _.Move(TRAILL_REGISTRO.GetMoveValues(), REG_SAIDA23);

                                                                                                        SAIDA23.Write(REG_SAIDA23.GetMoveValues().ToString());

                                                                                                        /*" -1488- ADD 1 TO AC-GRAV-SAIDA23. */
                                                                                                        W.AC_GRAV_SAIDA23.Value = W.AC_GRAV_SAIDA23 + 1;
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

                                        }

                                    }

                                }

                            }

                        }

                    }

                }

            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R9990-00-SEM-MOVIMENTO-SECTION */
        private void R9990_00_SEM_MOVIMENTO_SECTION()
        {
            /*" -1500- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, W.WDATA_REL);

            /*" -1501- MOVE WDAT-REL-DIA TO WDATA-DD-CABEC */
            _.Move(W.FILLER_5.WDAT_REL_DIA, W.WDATA_CABEC.WDATA_DD_CABEC);

            /*" -1502- MOVE WDAT-REL-MES TO WDATA-MM-CABEC */
            _.Move(W.FILLER_5.WDAT_REL_MES, W.WDATA_CABEC.WDATA_MM_CABEC);

            /*" -1504- MOVE WDAT-REL-ANO TO WDATA-AA-CABEC. */
            _.Move(W.FILLER_5.WDAT_REL_ANO, W.WDATA_CABEC.WDATA_AA_CABEC);

            /*" -1506- DISPLAY 'SEM MOVIMENTO NESTA DATA  ' WDATA-CABEC. */
            _.Display($"SEM MOVIMENTO NESTA DATA  {W.WDATA_CABEC}");

            /*" -1533- CLOSE ENTRADA SAIDA01 SAIDA02 SAIDA03 SAIDA04 SAIDA05 SAIDA06 SAIDA07 SAIDA08 SAIDA09 SAIDA10 SAIDA11 SAIDA12 SAIDA13 SAIDA14 SAIDA15 SAIDA16 SAIDA17 SAIDA18 SAIDA19 SAIDA20 SAIDA21 SAIDA22 SAIDA23 SAIDA24 SAIDA25. */
            ENTRADA.Close();
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();
            SAIDA04.Close();
            SAIDA05.Close();
            SAIDA06.Close();
            SAIDA07.Close();
            SAIDA08.Close();
            SAIDA09.Close();
            SAIDA10.Close();
            SAIDA11.Close();
            SAIDA12.Close();
            SAIDA13.Close();
            SAIDA14.Close();
            SAIDA15.Close();
            SAIDA16.Close();
            SAIDA17.Close();
            SAIDA18.Close();
            SAIDA19.Close();
            SAIDA20.Close();
            SAIDA21.Close();
            SAIDA22.Close();
            SAIDA23.Close();
            SAIDA24.Close();
            SAIDA25.Close();

            /*" -1535- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -1535- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1542- MOVE SQLCODE TO WSQLCODE */
            _.Move(DB.SQLCODE, ABEN.WABEND1.WSQLCODE);

            /*" -1543- MOVE SQLERRD(1) TO WSQLERRD1 */
            _.Move(DB.SQLERRD[1], ABEN.WABEND1.WSQLERRD1);

            /*" -1544- MOVE SQLERRD(2) TO WSQLERRD2 */
            _.Move(DB.SQLERRD[2], ABEN.WABEND1.WSQLERRD2);

            /*" -1545- DISPLAY WABEND. */
            _.Display(ABEN.WABEND);

            /*" -1547- DISPLAY WABEND1. */
            _.Display(ABEN.WABEND1);

            /*" -1547- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1576- CLOSE ENTRADA SAIDA01 SAIDA02 SAIDA03 SAIDA04 SAIDA05 SAIDA06 SAIDA07 SAIDA08 SAIDA09 SAIDA10 SAIDA11 SAIDA12 SAIDA13 SAIDA14 SAIDA15 SAIDA16 SAIDA17 SAIDA18 SAIDA19 SAIDA20 SAIDA21 SAIDA22 SAIDA23 SAIDA24 SAIDA25. */
            ENTRADA.Close();
            SAIDA01.Close();
            SAIDA02.Close();
            SAIDA03.Close();
            SAIDA04.Close();
            SAIDA05.Close();
            SAIDA06.Close();
            SAIDA07.Close();
            SAIDA08.Close();
            SAIDA09.Close();
            SAIDA10.Close();
            SAIDA11.Close();
            SAIDA12.Close();
            SAIDA13.Close();
            SAIDA14.Close();
            SAIDA15.Close();
            SAIDA16.Close();
            SAIDA17.Close();
            SAIDA18.Close();
            SAIDA19.Close();
            SAIDA20.Close();
            SAIDA21.Close();
            SAIDA22.Close();
            SAIDA23.Close();
            SAIDA24.Close();
            SAIDA25.Close();

            /*" -1578- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1578- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}