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
using Sias.Loterico.DB2.LT2036B;

namespace Code
{
    public class LT2036B
    {
        public bool IsCall { get; set; }

        public LT2036B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SISTEMA DE LOTERICO - FENAL        *      */
        /*"      *   PROGRAMA ...............  LT2036B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  JOSE G OLIVEIRA                    *      */
        /*"      *   PROGRAMADOR ............  JOSE G OLIVEIRA                    *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO/2001                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  A PARTIR DO ARQUIVO - V0LOTERICO01        */
        /*"      *                             SELECIONA O ULTIMO REGISTRO PARA   *      */
        /*"      *                             EMISSAO DO CERTIFICADO.            *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   REGISTROS ..............  V0LOTERICO01                       *      */
        /*"      *   REGISTROS ..............  VOENDERECOS                        *      */
        /*"      *   REGISTROS ..............  VOLOTCOBER                         *      */
        /*"      *   REGISTROS ..............  V0CLIENTE                          *      */
        /*"      *   REGISTROS ..............  V0LOTFATURA                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   PARA A TABELA LT-SOLICITA-PARAM (JEFFERSON EM 14/08/2001)    *      */
        /*"      *                                                                *      */
        /*"      *   LTSOLPAR-PARAM-INTG01 CONTEM O COD. DO LOTERICO VINDO LT1001B*      */
        /*"      *   LTSOLPAR-PARAM-DEC01  CONTEM O NUM. DA APOLICE VINDO LT1001B *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ALTERACAO EM 06/08/2003 - INCLUIR OBSERVACAO DE COFRE        *      */
        /*"      *     COM FECHADURA ELETRONICA/MECANICA DE RETARDO               *      */
        /*"      *     PROCURAR: OL0608                                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 16/02/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V1SISTEMA         INPUT    *      */
        /*"      * MOEDAS                              V1MOEDA           INPUT    *      */
        /*"      * COBERTURAS                          V0LOTCOBER01      INPUT    *      */
        /*"      * FATURAS                             V0LOTFATURA01     OUTPUT   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _MOV2036B { get; set; } = new FileBasis(new PIC("X", "212", "X(212)"));

        public FileBasis MOV2036B
        {
            get
            {
                _.Move(REG_MOV2036B, _MOV2036B); VarBasis.RedefinePassValue(REG_MOV2036B, _MOV2036B, REG_MOV2036B); return _MOV2036B;
            }
        }
        public FileBasis _RLT2036B { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis RLT2036B
        {
            get
            {
                _.Move(REG_RLT2036B, _RLT2036B); VarBasis.RedefinePassValue(REG_RLT2036B, _RLT2036B, REG_RLT2036B); return _RLT2036B;
            }
        }
        public SortBasis<LT2036B_REG_SORT> ARQSORT { get; set; } = new SortBasis<LT2036B_REG_SORT>(new LT2036B_REG_SORT());
        /*"01 REG-MOV2036B.*/
        public LT2036B_REG_MOV2036B REG_MOV2036B { get; set; } = new LT2036B_REG_MOV2036B();
        public class LT2036B_REG_MOV2036B : VarBasis
        {
            /*"   10 CAD-CODIGO         PIC X(10).*/
            public StringBasis CAD_CODIGO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   10 CAD-RAZAO-SOC      PIC X(41).*/
            public StringBasis CAD_RAZAO_SOC { get; set; } = new StringBasis(new PIC("X", "41", "X(41)."), @"");
            /*"   10 CAD-EN             PIC X(05).*/
            public StringBasis CAD_EN { get; set; } = new StringBasis(new PIC("X", "5", "X(05)."), @"");
            /*"   10 CAD-ENDERECO       PIC X(63).*/
            public StringBasis CAD_ENDERECO { get; set; } = new StringBasis(new PIC("X", "63", "X(63)."), @"");
            /*"   10 CAD-BAIRRO         PIC X(25).*/
            public StringBasis CAD_BAIRRO { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"   10 CAD-CIDADE         PIC X(25).*/
            public StringBasis CAD_CIDADE { get; set; } = new StringBasis(new PIC("X", "25", "X(25)."), @"");
            /*"   10 CAD-UF             PIC X(02).*/
            public StringBasis CAD_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
            /*"   10 CAD-CEP            PIC X(10).*/
            public StringBasis CAD_CEP { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   10 CAD-TELEFONE       PIC X(10).*/
            public StringBasis CAD_TELEFONE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   10 CAD-DDD            PIC X(04).*/
            public StringBasis CAD_DDD { get; set; } = new StringBasis(new PIC("X", "4", "X(04)."), @"");
            /*"   10 CAD-FAX            PIC X(10).*/
            public StringBasis CAD_FAX { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
            /*"   10 CAD-COD-FENAL      PIC X(07).*/
            public StringBasis CAD_COD_FENAL { get; set; } = new StringBasis(new PIC("X", "7", "X(07)."), @"");
            /*"01 REG-RLT2036B.*/
        }
        public LT2036B_REG_RLT2036B REG_RLT2036B { get; set; } = new LT2036B_REG_RLT2036B();
        public class LT2036B_REG_RLT2036B : VarBasis
        {
            /*"   10 REG-LINHA    PIC X(2250).*/
            public StringBasis REG_LINHA { get; set; } = new StringBasis(new PIC("X", "2250", "X(2250)."), @"");
            /*"01 REG-SORT.*/
        }
        public LT2036B_REG_SORT REG_SORT { get; set; } = new LT2036B_REG_SORT();
        public class LT2036B_REG_SORT : VarBasis
        {
            /*"  05     SORT-ESTIPULANTE       PIC X(055).*/
            public StringBasis SORT_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "55", "X(055)."), @"");
            /*"  05     SORT-CODCAIXA-X.*/
            public LT2036B_SORT_CODCAIXA_X SORT_CODCAIXA_X { get; set; } = new LT2036B_SORT_CODCAIXA_X();
            public class LT2036B_SORT_CODCAIXA_X : VarBasis
            {
                /*"   10    SORT-CODCAIXA          PIC ZZZZZZZZ9.*/
                public IntBasis SORT_CODCAIXA { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZZZZ9."));
                /*"  05     SORT-APOLICE-X.*/
            }
            public LT2036B_SORT_APOLICE_X SORT_APOLICE_X { get; set; } = new LT2036B_SORT_APOLICE_X();
            public class LT2036B_SORT_APOLICE_X : VarBasis
            {
                /*"   10    SORT-APOLICE           PIC 9(013).*/
                public IntBasis SORT_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"  05     SORT-AGENCIA-X.*/
            }
            public LT2036B_SORT_AGENCIA_X SORT_AGENCIA_X { get; set; } = new LT2036B_SORT_AGENCIA_X();
            public class LT2036B_SORT_AGENCIA_X : VarBasis
            {
                /*"   10    SORT-AGENCIA           PIC ZZZ9999.*/
                public IntBasis SORT_AGENCIA { get; set; } = new IntBasis(new PIC("9", "7", "ZZZ9999."));
                /*"  05     SORT-OPER-X.*/
            }
            public LT2036B_SORT_OPER_X SORT_OPER_X { get; set; } = new LT2036B_SORT_OPER_X();
            public class LT2036B_SORT_OPER_X : VarBasis
            {
                /*"   10    SORT-OPER              PIC 9999.*/
                public IntBasis SORT_OPER { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"  05     SORT-CONTA-X.*/
            }
            public LT2036B_SORT_CONTA_X SORT_CONTA_X { get; set; } = new LT2036B_SORT_CONTA_X();
            public class LT2036B_SORT_CONTA_X : VarBasis
            {
                /*"   10    SORT-CONTA             PIC ZZZZZZZZZZZZ9.*/
                public IntBasis SORT_CONTA { get; set; } = new IntBasis(new PIC("9", "13", "ZZZZZZZZZZZZ9."));
                /*"  05     SORT-RAZAO-SOCIAL      PIC X(040).*/
            }
            public StringBasis SORT_RAZAO_SOCIAL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"  05     SORT-CNPJ              PIC 99.999.999/9999.99.*/
            public IntBasis SORT_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "99.999.999/9999.99."));
            /*"  05     SORT-CNPF REDEFINES SORT-CNPJ PIC ZZZZ999.999.999.99.*/
            private _REDEF_IntBasis _sort_cnpf { get; set; }
            public _REDEF_IntBasis SORT_CNPF
            {
                get { _sort_cnpf = new _REDEF_IntBasis(new PIC("9", "ZZZZ999.999.999.99", "ZZZZ999.999.999.99.")); ; _.Move(SORT_CNPJ, _sort_cnpf); VarBasis.RedefinePassValue(SORT_CNPJ, _sort_cnpf, SORT_CNPJ); _sort_cnpf.ValueChanged += () => { _.Move(_sort_cnpf, SORT_CNPJ); }; return _sort_cnpf; }
                set { VarBasis.RedefinePassValue(value, _sort_cnpf, SORT_CNPJ); }
            }  //Redefines
            /*"  05     FILLER REDEFINES SORT-CNPF.*/
            private _REDEF_LT2036B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_LT2036B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_LT2036B_FILLER_0(); _.Move(SORT_CNPF, _filler_0); VarBasis.RedefinePassValue(SORT_CNPF, _filler_0, SORT_CNPF); _filler_0.ValueChanged += () => { _.Move(_filler_0, SORT_CNPF); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, SORT_CNPF); }
            }  //Redefines
            public class _REDEF_LT2036B_FILLER_0 : VarBasis
            {
                /*"   10    FILLER                 PIC X(015).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"   10    SORT-CNPF-TRACO        PIC X(001).*/
                public StringBasis SORT_CNPF_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10    FILLER                 PIC X(002).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05     SORT-ENDERECO          PIC X(055).*/

                public _REDEF_LT2036B_FILLER_0()
                {
                    FILLER_1.ValueChanged += OnValueChanged;
                    SORT_CNPF_TRACO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis SORT_ENDERECO { get; set; } = new StringBasis(new PIC("X", "55", "X(055)."), @"");
            /*"  05     SORT-BAIRRO            PIC X(020).*/
            public StringBasis SORT_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05     SORT-CIDADE            PIC X(020).*/
            public StringBasis SORT_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"  05     SORT-UF                PIC X(002).*/
            public StringBasis SORT_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"  05     SORT-CEP-X             PIC X(010).*/
            public StringBasis SORT_CEP_X { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  05     FILLER REDEFINES SORT-CEP-X.*/
            private _REDEF_LT2036B_FILLER_3 _filler_3 { get; set; }
            public _REDEF_LT2036B_FILLER_3 FILLER_3
            {
                get { _filler_3 = new _REDEF_LT2036B_FILLER_3(); _.Move(SORT_CEP_X, _filler_3); VarBasis.RedefinePassValue(SORT_CEP_X, _filler_3, SORT_CEP_X); _filler_3.ValueChanged += () => { _.Move(_filler_3, SORT_CEP_X); }; return _filler_3; }
                set { VarBasis.RedefinePassValue(value, _filler_3, SORT_CEP_X); }
            }  //Redefines
            public class _REDEF_LT2036B_FILLER_3 : VarBasis
            {
                /*"   10    SORT-CEP01             PIC 9(002).*/
                public IntBasis SORT_CEP01 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10    SORT-CEP-PTO           PIC X(001).*/
                public StringBasis SORT_CEP_PTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10    SORT-CEP02             PIC 9(003).*/
                public IntBasis SORT_CEP02 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"   10    SORT-CEP-TRACO         PIC X(001).*/
                public StringBasis SORT_CEP_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10    SORT-CEP03             PIC 9(003).*/
                public IntBasis SORT_CEP03 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  05     SORT-DDD-X.*/

                public _REDEF_LT2036B_FILLER_3()
                {
                    SORT_CEP01.ValueChanged += OnValueChanged;
                    SORT_CEP_PTO.ValueChanged += OnValueChanged;
                    SORT_CEP02.ValueChanged += OnValueChanged;
                    SORT_CEP_TRACO.ValueChanged += OnValueChanged;
                    SORT_CEP03.ValueChanged += OnValueChanged;
                }

            }
            public LT2036B_SORT_DDD_X SORT_DDD_X { get; set; } = new LT2036B_SORT_DDD_X();
            public class LT2036B_SORT_DDD_X : VarBasis
            {
                /*"   10    SORT-DDD               PIC ZZZ9 BLANK WHEN ZEROS.*/
                public IntBasis SORT_DDD { get; set; } = new IntBasis(new PIC("9", "4", "ZZZ9"));
                /*"  05     SORT-TELEFONE-X        PIC X(009).*/
            }
            public StringBasis SORT_TELEFONE_X { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05     FILLER REDEFINES SORT-TELEFONE-X.*/
            private _REDEF_LT2036B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_LT2036B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_LT2036B_FILLER_4(); _.Move(SORT_TELEFONE_X, _filler_4); VarBasis.RedefinePassValue(SORT_TELEFONE_X, _filler_4, SORT_TELEFONE_X); _filler_4.ValueChanged += () => { _.Move(_filler_4, SORT_TELEFONE_X); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, SORT_TELEFONE_X); }
            }  //Redefines
            public class _REDEF_LT2036B_FILLER_4 : VarBasis
            {
                /*"   10    SORT-FONE01            PIC Z999.*/
                public IntBasis SORT_FONE01 { get; set; } = new IntBasis(new PIC("9", "4", "Z999."));
                /*"   10    SORT-FONE-TRACO        PIC X(001).*/
                public StringBasis SORT_FONE_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10    SORT-FONE02            PIC 9999.*/
                public IntBasis SORT_FONE02 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"  05     SORT-E-MAIL            PIC X(050).*/

                public _REDEF_LT2036B_FILLER_4()
                {
                    SORT_FONE01.ValueChanged += OnValueChanged;
                    SORT_FONE_TRACO.ValueChanged += OnValueChanged;
                    SORT_FONE02.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis SORT_E_MAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"  05     SORT-FAX-X             PIC X(009).*/
            public StringBasis SORT_FAX_X { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05     FILLER REDEFINES SORT-FAX-X.*/
            private _REDEF_LT2036B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_LT2036B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_LT2036B_FILLER_5(); _.Move(SORT_FAX_X, _filler_5); VarBasis.RedefinePassValue(SORT_FAX_X, _filler_5, SORT_FAX_X); _filler_5.ValueChanged += () => { _.Move(_filler_5, SORT_FAX_X); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, SORT_FAX_X); }
            }  //Redefines
            public class _REDEF_LT2036B_FILLER_5 : VarBasis
            {
                /*"   10    SORT-FAX01             PIC Z999.*/
                public IntBasis SORT_FAX01 { get; set; } = new IntBasis(new PIC("9", "4", "Z999."));
                /*"   10    SORT-FAX-TRACO         PIC X(001).*/
                public StringBasis SORT_FAX_TRACO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10    SORT-FAX02             PIC 9999.*/
                public IntBasis SORT_FAX02 { get; set; } = new IntBasis(new PIC("9", "4", "9999."));
                /*"  05     SORT-ROUBO-X.*/

                public _REDEF_LT2036B_FILLER_5()
                {
                    SORT_FAX01.ValueChanged += OnValueChanged;
                    SORT_FAX_TRACO.ValueChanged += OnValueChanged;
                    SORT_FAX02.ValueChanged += OnValueChanged;
                }

            }
            public LT2036B_SORT_ROUBO_X SORT_ROUBO_X { get; set; } = new LT2036B_SORT_ROUBO_X();
            public class LT2036B_SORT_ROUBO_X : VarBasis
            {
                /*"   10    SORT-ROUBO             PIC 9(010)V99.*/
                public DoubleBasis SORT_ROUBO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                /*"  05     SORT-INCENDIO-X.*/
            }
            public LT2036B_SORT_INCENDIO_X SORT_INCENDIO_X { get; set; } = new LT2036B_SORT_INCENDIO_X();
            public class LT2036B_SORT_INCENDIO_X : VarBasis
            {
                /*"   10    SORT-INCENDIO          PIC 9(010)V99.*/
                public DoubleBasis SORT_INCENDIO { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                /*"  05     SORT-DANOS-X.*/
            }
            public LT2036B_SORT_DANOS_X SORT_DANOS_X { get; set; } = new LT2036B_SORT_DANOS_X();
            public class LT2036B_SORT_DANOS_X : VarBasis
            {
                /*"   10    SORT-DANOS             PIC 9(010)V99.*/
                public DoubleBasis SORT_DANOS { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                /*"  05     SORT-ACID-EMPR-X.*/
            }
            public LT2036B_SORT_ACID_EMPR_X SORT_ACID_EMPR_X { get; set; } = new LT2036B_SORT_ACID_EMPR_X();
            public class LT2036B_SORT_ACID_EMPR_X : VarBasis
            {
                /*"   10    SORT-ACID-EMPR         PIC 9(010)V99.*/
                public DoubleBasis SORT_ACID_EMPR { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                /*"  05     SORT-ACID-EMP-X.*/
            }
            public LT2036B_SORT_ACID_EMP_X SORT_ACID_EMP_X { get; set; } = new LT2036B_SORT_ACID_EMP_X();
            public class LT2036B_SORT_ACID_EMP_X : VarBasis
            {
                /*"   10    SORT-ACID-EMP          PIC 9(010)V99.*/
                public DoubleBasis SORT_ACID_EMP { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                /*"  05     SORT-RC-X.*/
            }
            public LT2036B_SORT_RC_X SORT_RC_X { get; set; } = new LT2036B_SORT_RC_X();
            public class LT2036B_SORT_RC_X : VarBasis
            {
                /*"   10    SORT-RC                PIC 9(010)V99.*/
                public DoubleBasis SORT_RC { get; set; } = new DoubleBasis(new PIC("9", "10", "9(010)V99."), 2);
                /*"  05     SORT-DATAI.*/
            }
            public LT2036B_SORT_DATAI SORT_DATAI { get; set; } = new LT2036B_SORT_DATAI();
            public class LT2036B_SORT_DATAI : VarBasis
            {
                /*"   10    SORT-DATAI-DD          PIC 9(002).*/
                public IntBasis SORT_DATAI_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10    SORT-TRACO01           PIC X(001).*/
                public StringBasis SORT_TRACO01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10    SORT-DATAI-MM          PIC 9(002).*/
                public IntBasis SORT_DATAI_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10    SORT-TRACO02           PIC X(001).*/
                public StringBasis SORT_TRACO02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10    SORT-DATAI-AA          PIC 9(004).*/
                public IntBasis SORT_DATAI_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05     SORT-DATAT.*/
            }
            public LT2036B_SORT_DATAT SORT_DATAT { get; set; } = new LT2036B_SORT_DATAT();
            public class LT2036B_SORT_DATAT : VarBasis
            {
                /*"   10    SORT-DATAT-DD          PIC 9(002).*/
                public IntBasis SORT_DATAT_DD { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10    SORT-TRACO03           PIC X(001).*/
                public StringBasis SORT_TRACO03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10    SORT-DATAT-MM          PIC 9(002).*/
                public IntBasis SORT_DATAT_MM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"   10    SORT-TRACO04           PIC X(001).*/
                public StringBasis SORT_TRACO04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"   10    SORT-DATAT-AA          PIC 9(004).*/
                public IntBasis SORT_DATAT_AA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05     SORT-LINHA             OCCURS 10 TIMES.*/
            }
            public ListBasis<LT2036B_SORT_LINHA> SORT_LINHA { get; set; } = new ListBasis<LT2036B_SORT_LINHA>(10);
            public class LT2036B_SORT_LINHA : VarBasis
            {
                /*"      15 SORT-PART1-LINHA       PIC X(070).*/
                public StringBasis SORT_PART1_LINHA { get; set; } = new StringBasis(new PIC("X", "70", "X(070)."), @"");
                /*"      15 SORT-VALOR-PERC.*/
                public LT2036B_SORT_VALOR_PERC SORT_VALOR_PERC { get; set; } = new LT2036B_SORT_VALOR_PERC();
                public class LT2036B_SORT_VALOR_PERC : VarBasis
                {
                    /*"       20 SORT-TRACO-LINHA      PIC X(002).*/
                    public StringBasis SORT_TRACO_LINHA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"       20 SORT-PART2-LINHA      PIC ZZ9,99.*/
                    public DoubleBasis SORT_PART2_LINHA { get; set; } = new DoubleBasis(new PIC("9", "3", "ZZ9V99."), 2);
                    /*"       20 SORT-PART3-LINHA      PIC X(002).*/
                    public StringBasis SORT_PART3_LINHA { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                    /*"  05     SORT-OBS1              PIC X(080).*/
                }
            }
            public StringBasis SORT_OBS1 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05     SORT-OBS2              PIC X(080).*/
            public StringBasis SORT_OBS2 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05     SORT-OBS3              PIC X(080).*/
            public StringBasis SORT_OBS3 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05     SORT-OBS4              PIC X(080).*/
            public StringBasis SORT_OBS4 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05     SORT-OBS5              PIC X(080).*/
            public StringBasis SORT_OBS5 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05     SORT-OBS6              PIC X(080).*/
            public StringBasis SORT_OBS6 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05     SORT-OBS7              PIC X(080).*/
            public StringBasis SORT_OBS7 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05     SORT-OBS8              PIC X(080).*/
            public StringBasis SORT_OBS8 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05     SORT-OBS9              PIC X(080).*/
            public StringBasis SORT_OBS9 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05     SORT-OBS10             PIC X(080).*/
            public StringBasis SORT_OBS10 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05     SORT-OBS11             PIC X(080).*/
            public StringBasis SORT_OBS11 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)."), @"");
            /*"  05     SORT-CORRETORA         PIC X(050).*/
            public StringBasis SORT_CORRETORA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)."), @"");
            /*"  05     SORT-SUSEP             PIC X(009).*/
            public StringBasis SORT_SUSEP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
            /*"  05     SORT-CENTRAL           PIC X(015).*/
            public StringBasis SORT_CENTRAL { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77   W-COD-ANT                 PIC  9(09).*/
        public IntBasis W_COD_ANT { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
        /*"77   W-UF-ANT                  PIC X(002) VALUE SPACES.*/
        public StringBasis W_UF_ANT { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
        /*"77   V0APO-NOME                 PIC  X(40).*/
        public StringBasis V0APO_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77   V0APO-DTINIVIG             PIC  X(10).*/
        public StringBasis V0APO_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77   V0APO-DTTERVIG             PIC  X(10).*/
        public StringBasis V0APO_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77   V0APO-RAMO                 PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0APO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   V0APO-MODALIDA             PIC S9(04) COMP   VALUE +0.*/
        public IntBasis V0APO_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   V0APO-NUM-APOLICE          PIC S9(13)  VALUE +0 COMP-3.*/
        public IntBasis V0APO_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77   V0APO-NUM-ENDOSSO          PIC S9(09)  VALUE +0 COMP.*/
        public IntBasis V0APO_NUM_ENDOSSO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0SIST-DTMOVABE             PIC  X(10).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0SIST-TIMESTAMP            PIC  X(26).*/
        public StringBasis V0SIST_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"77   V0LOT-COD-LOT-FENAL         PIC S9(09)  VALUE +0 COMP.*/
        public IntBasis V0LOT_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   V0LOT-COD-LOT-CEF           PIC S9(09)  VALUE +0 COMP.*/
        public IntBasis V0LOT_COD_LOT_CEF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   V0LOT-COD-CLIENTE           PIC S9(009) VALUE +0 COMP.*/
        public IntBasis V0LOT_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77   V0LOT-OCORR-ENDERECO        PIC S9(04)  VALUE +0 COMP.*/
        public IntBasis V0LOT_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   V0LOT-OPCAO-DEP             PIC  X(01).*/
        public StringBasis V0LOT_OPCAO_DEP { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77   V0LOT-DTINIVIG              PIC  X(10).*/
        public StringBasis V0LOT_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77   V0LOT-DTTERVIG              PIC  X(10).*/
        public StringBasis V0LOT_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77   V0LOT-FORMA-PGTO            PIC  X(01).*/
        public StringBasis V0LOT_FORMA_PGTO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77   V0LOT-NUM-CONTROLE-FENAL    PIC S9(09)  VALUE +0 COMP-3.*/
        public IntBasis V0LOT_NUM_CONTROLE_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   V0LOT-NUM-APOLICE           PIC S9(13)  VALUE +0 COMP-3.*/
        public IntBasis V0LOT_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77   V0LOT-SITUACAO              PIC  X(01).*/
        public StringBasis V0LOT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77   V0LOT-DATA-GERA-MOV         PIC  X(10).*/
        public StringBasis V0LOT_DATA_GERA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77   V0LOT-COD-EMPRESA           PIC S9(09)  VALUE +0 COMP.*/
        public IntBasis V0LOT_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   V0LOT-SINDICATO             PIC X(03).*/
        public StringBasis V0LOT_SINDICATO { get; set; } = new StringBasis(new PIC("X", "3", "X(03)."), @"");
        /*"77   V0BON-COD-LOT-FENAL         PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0BON_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   V0BON-NUM-APOLICE           PIC S9(13) VALUE +0 COMP-3.*/
        public IntBasis V0BON_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77   V0BON-DTINIVIG              PIC  X(10).*/
        public StringBasis V0BON_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77   V0BON-DTTERVIG              PIC  X(10).*/
        public StringBasis V0BON_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77   V0BON-COD-REGIAO            PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0BON_COD_REGIAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   V0BON-TIPO-BONUS            PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0BON_TIPO_BONUS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   V0BON-PERCENT-BONUS         PIC S9(08)V9(5) VALUE +0 COMP-3*/
        public DoubleBasis V0BON_PERCENT_BONUS { get; set; } = new DoubleBasis(new PIC("S9", "8", "S9(08)V9(5)"), 5);
        /*"77   V0BON-DATA-GERA-MOV         PIC  X(10).*/
        public StringBasis V0BON_DATA_GERA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77   V0BON-COD-EMPRESA           PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0BON_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   V0IMP-COD-LOT-FENAL         PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0IMP_COD_LOT_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   V0IMP-NUM-APOLICE           PIC S9(13) VALUE +0 COMP-3.*/
        public IntBasis V0IMP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77   V0IMP-NUM-CONTROLE-FENAL    PIC S9(09) VALUE +0 COMP.*/
        public IntBasis V0IMP_NUM_CONTROLE_FENAL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77   V0IMP-RAMO-COBERTURA        PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0IMP_RAMO_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   V0IMP-COD-COBERTURA         PIC S9(04) VALUE +0 COMP.*/
        public IntBasis V0IMP_COD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77   V0IMP-MODALIDA-COBERTURA    PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V0IMP_MODALIDA_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0IMP-DTINIVIG              PIC  X(10).*/
        public StringBasis V0IMP_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77   V0IMP-DTTERVIG              PIC  X(10).*/
        public StringBasis V0IMP_DTTERVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77   V0IMP-COD-MOEDA             PIC S9(004) VALUE +0 COMP.*/
        public IntBasis V0IMP_COD_MOEDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77   V0IMP-IMP-SEG               PIC S9(15)V9(2) VALUE +0 COMP-3*/
        public DoubleBasis V0IMP_IMP_SEG { get; set; } = new DoubleBasis(new PIC("S9", "15", "S9(15)V9(2)"), 2);
        /*"77   V0IMP-SITUACAO              PIC  X(01).*/
        public StringBasis V0IMP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"77   V0IMP-DATA-GERA-MOV         PIC  X(10).*/
        public StringBasis V0IMP_DATA_GERA_MOV { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77   V0IMP-COD-EMPRESA           PIC S9(09)  VALUE +0 COMP.*/
        public IntBasis V0IMP_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0RELA-CODUSU               PIC X(8).*/
        public StringBasis V0RELA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"77  V0RELA-DATA-SOLICITACAO     PIC X(10).*/
        public StringBasis V0RELA_DATA_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-IDSISTEM             PIC X(2).*/
        public StringBasis V0RELA_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(2)."), @"");
        /*"77  V0RELA-CODRELAT             PIC X(8).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(8)."), @"");
        /*"77  V0RELA-NRCOPIAS             PIC S9(04) COMP.*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-QUANTIDADE           PIC S9(04) COMP.*/
        public IntBasis V0RELA_QUANTIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-PERI-INICIAL         PIC X(10).*/
        public StringBasis V0RELA_PERI_INICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-PERI-FINAL           PIC X(10).*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-DATA-REFERENCIA      PIC X(10).*/
        public StringBasis V0RELA_DATA_REFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77  V0RELA-MES-REFERENCIA       PIC S9(04) COMP.*/
        public IntBasis V0RELA_MES_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-ANO-REFERENCIA       PIC S9(04) COMP.*/
        public IntBasis V0RELA_ANO_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-ORGAO                PIC S9(04) COMP.*/
        public IntBasis V0RELA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-FONTE                PIC S9(04) COMP.*/
        public IntBasis V0RELA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-CODPDT               PIC S9(09) COMP.*/
        public IntBasis V0RELA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0RELA-RAMO                 PIC S9(04) COMP.*/
        public IntBasis V0RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-MODALIDA             PIC S9(04) COMP.*/
        public IntBasis V0RELA_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-CONGENER             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-NUM-APOLICE          PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0RELA-NRENDOS              PIC S9(09) COMP.*/
        public IntBasis V0RELA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0RELA-NRPARCEL             PIC S9(04) COMP.*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-NRCERTIF             PIC S9(15) COMP-3.*/
        public IntBasis V0RELA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0RELA-NRTIT                PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0RELA-CODSUBES             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-OPERACAO             PIC S9(04) COMP.*/
        public IntBasis V0RELA_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-COD-PLANO            PIC S9(04) COMP.*/
        public IntBasis V0RELA_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-OCORHIST             PIC S9(04) COMP.*/
        public IntBasis V0RELA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-APOLIDER             PIC X(15).*/
        public StringBasis V0RELA_APOLIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0RELA-ENDOSLID             PIC X(15).*/
        public StringBasis V0RELA_ENDOSLID { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0RELA-NUM-PARC-LIDER       PIC S9(04) COMP.*/
        public IntBasis V0RELA_NUM_PARC_LIDER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-NUM-SINISTRO         PIC S9(13) COMP-3.*/
        public IntBasis V0RELA_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77  V0RELA-NUM-SINI-LIDER       PIC X(15).*/
        public StringBasis V0RELA_NUM_SINI_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(15)."), @"");
        /*"77  V0RELA-NUM-ORDEM            PIC S9(15) COMP-3.*/
        public IntBasis V0RELA_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77  V0RELA-CODUNIMO             PIC S9(04) COMP.*/
        public IntBasis V0RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-CORRECAO             PIC X(1).*/
        public StringBasis V0RELA_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELA-SITUACAO             PIC X(1).*/
        public StringBasis V0RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELA-PREVIA-DEFINITIVA    PIC X(1).*/
        public StringBasis V0RELA_PREVIA_DEFINITIVA { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELA-ANAL-RESUMO          PIC X(1).*/
        public StringBasis V0RELA_ANAL_RESUMO { get; set; } = new StringBasis(new PIC("X", "1", "X(1)."), @"");
        /*"77  V0RELA-COD-EMPRESA          PIC S9(09) COMP.*/
        public IntBasis V0RELA_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77  V0RELA-PERI-RENOVACAO       PIC S9(04) COMP.*/
        public IntBasis V0RELA_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77  V0RELA-PCT-AUMENTO          PIC S9(3)V9(2) COMP-3.*/
        public DoubleBasis V0RELA_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(3)V9(2)"), 2);
        /*"77  V0RELA-TIMESTAMP            PIC X(26).*/
        public StringBasis V0RELA_TIMESTAMP { get; set; } = new StringBasis(new PIC("X", "26", "X(26)."), @"");
        /*"01           AREA-DE-WORK.*/
        public LT2036B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new LT2036B_AREA_DE_WORK();
        public class LT2036B_AREA_DE_WORK : VarBasis
        {
            /*"  05         WORK-CONTA.*/
            public LT2036B_WORK_CONTA WORK_CONTA { get; set; } = new LT2036B_WORK_CONTA();
            public class LT2036B_WORK_CONTA : VarBasis
            {
                /*"    10       WORK-NUM-CONTA    PIC  9(012)    VALUE ZEROS.*/
                public IntBasis WORK_NUM_CONTA { get; set; } = new IntBasis(new PIC("9", "12", "9(012)"));
                /*"    10       WORK-DV-CONTA     PIC  9(001)    VALUE ZEROS.*/
                public IntBasis WORK_DV_CONTA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
                /*"  05         WORK-ENDERECO.*/
            }
            public LT2036B_WORK_ENDERECO WORK_ENDERECO { get; set; } = new LT2036B_WORK_ENDERECO();
            public class LT2036B_WORK_ENDERECO : VarBasis
            {
                /*"    10       WORK-ENDER-01     PIC  X(040)    VALUE SPACES.*/
                public StringBasis WORK_ENDER_01 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10       WORK-ENDER-02     PIC  X(015)    VALUE SPACES.*/
                public StringBasis WORK_ENDER_02 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"  05         WORK-DATA-FORM.*/
            }
            public LT2036B_WORK_DATA_FORM WORK_DATA_FORM { get; set; } = new LT2036B_WORK_DATA_FORM();
            public class LT2036B_WORK_DATA_FORM : VarBasis
            {
                /*"    10       WORK-DT-AA-FORM   PIC  9(004)    VALUE ZEROS.*/
                public IntBasis WORK_DT_AA_FORM { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WORK-DT-MM-FORM   PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WORK_DT_MM_FORM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10       FILLER            PIC  X(001)    VALUE SPACES.*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    10       WORK-DT-DD-FORM   PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WORK_DT_DD_FORM { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05         WORK-CEP          PIC  9(008)    VALUE ZEROS.*/
            }
            public IntBasis WORK_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05         FILLER REDEFINES WORK-CEP.*/
            private _REDEF_LT2036B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_LT2036B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_LT2036B_FILLER_8(); _.Move(WORK_CEP, _filler_8); VarBasis.RedefinePassValue(WORK_CEP, _filler_8, WORK_CEP); _filler_8.ValueChanged += () => { _.Move(_filler_8, WORK_CEP); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WORK_CEP); }
            }  //Redefines
            public class _REDEF_LT2036B_FILLER_8 : VarBasis
            {
                /*"    10       WORK-CEP-01       PIC  9(002).*/
                public IntBasis WORK_CEP_01 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WORK-CEP-02       PIC  9(003).*/
                public IntBasis WORK_CEP_02 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WORK-CEP-03       PIC  9(003).*/
                public IntBasis WORK_CEP_03 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"  05         WORK-TELEFONE     PIC  9(011)    VALUE ZEROS.*/

                public _REDEF_LT2036B_FILLER_8()
                {
                    WORK_CEP_01.ValueChanged += OnValueChanged;
                    WORK_CEP_02.ValueChanged += OnValueChanged;
                    WORK_CEP_03.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WORK_TELEFONE { get; set; } = new IntBasis(new PIC("9", "11", "9(011)"));
            /*"  05         FILLER REDEFINES WORK-TELEFONE.*/
            private _REDEF_LT2036B_FILLER_9 _filler_9 { get; set; }
            public _REDEF_LT2036B_FILLER_9 FILLER_9
            {
                get { _filler_9 = new _REDEF_LT2036B_FILLER_9(); _.Move(WORK_TELEFONE, _filler_9); VarBasis.RedefinePassValue(WORK_TELEFONE, _filler_9, WORK_TELEFONE); _filler_9.ValueChanged += () => { _.Move(_filler_9, WORK_TELEFONE); }; return _filler_9; }
                set { VarBasis.RedefinePassValue(value, _filler_9, WORK_TELEFONE); }
            }  //Redefines
            public class _REDEF_LT2036B_FILLER_9 : VarBasis
            {
                /*"    10       WORK-FONE-01      PIC  9(003).*/
                public IntBasis WORK_FONE_01 { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    10       WORK-FONE-02      PIC  9(004).*/
                public IntBasis WORK_FONE_02 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WORK-FONE-03      PIC  9(004).*/
                public IntBasis WORK_FONE_03 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"  05         WCONT-LOTERICO    PIC  9(009)    VALUE ZEROS.*/

                public _REDEF_LT2036B_FILLER_9()
                {
                    WORK_FONE_01.ValueChanged += OnValueChanged;
                    WORK_FONE_02.ValueChanged += OnValueChanged;
                    WORK_FONE_03.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WCONT_LOTERICO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WCONT-IMP-SEG     PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WCONT_IMP_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WCONT-BONUS       PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WCONT_BONUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WCONT-UF          PIC  9(006)    VALUE ZEROS.*/
            public IntBasis WCONT_UF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  05         WCONT-REG-GRAVADO PIC  9(009)    VALUE ZEROS.*/
            public IntBasis WCONT_REG_GRAVADO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05         WCONT-CODIGO      PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WCONT_CODIGO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05         WS-MAX-DTINIVIG   PIC  X(010)    VALUE SPACES.*/
            public StringBasis WS_MAX_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05         VIND-DTINIVIG     PIC S9(04) COMP VALUE +0.*/
            public IntBasis VIND_DTINIVIG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"  05   WS-FIM-CURS02     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WS_FIM_CURS02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05   WFIM-V1SISTEMA    PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05   WFIM-LTSOLPAR     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_LTSOLPAR { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05   WFIM-SORT         PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05   WFIM-REL          PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_REL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05   WLOT-ENCONTRADO   PIC  X(003)    VALUE SPACES.*/
            public StringBasis WLOT_ENCONTRADO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05     LD01.*/
            public LT2036B_LD01 LD01 { get; set; } = new LT2036B_LD01();
            public class LT2036B_LD01 : VarBasis
            {
                /*"    10   LD01-ESTIPULANTE       PIC X(011) VALUE SPACES.*/
                public StringBasis LD01_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-CODCAIXA-X        PIC X(008) VALUE SPACES.*/
                public StringBasis LD01_CODCAIXA_X { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-APOLICE-X         PIC X(007) VALUE SPACES.*/
                public StringBasis LD01_APOLICE_X { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-AGENCIA-X         PIC X(007) VALUE SPACES.*/
                public StringBasis LD01_AGENCIA_X { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-OPER-X            PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_OPER_X { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-CONTA-X           PIC X(005) VALUE SPACES.*/
                public StringBasis LD01_CONTA_X { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-RAZAO-SOCIAL      PIC X(011) VALUE SPACES.*/
                public StringBasis LD01_RAZAO_SOCIAL { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-CNPJ              PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_CNPJ { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-ENDERECO          PIC X(008) VALUE SPACES.*/
                public StringBasis LD01_ENDERECO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-BAIRRO            PIC X(006) VALUE SPACES.*/
                public StringBasis LD01_BAIRRO { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-CIDADE            PIC X(006) VALUE SPACES.*/
                public StringBasis LD01_CIDADE { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-UF                PIC X(002) VALUE SPACES.*/
                public StringBasis LD01_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-CEP-X             PIC X(003) VALUE SPACES.*/
                public StringBasis LD01_CEP_X { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-DDD-X             PIC X(003) VALUE SPACES.*/
                public StringBasis LD01_DDD_X { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-TELEFONE-X        PIC X(008) VALUE SPACES.*/
                public StringBasis LD01_TELEFONE_X { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-E-MAIL            PIC X(005) VALUE SPACES.*/
                public StringBasis LD01_E_MAIL { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-FAX-X             PIC X(003) VALUE SPACES.*/
                public StringBasis LD01_FAX_X { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-ROUBO-X           PIC X(005) VALUE SPACES.*/
                public StringBasis LD01_ROUBO_X { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-INCENDIO-X        PIC X(008) VALUE SPACES.*/
                public StringBasis LD01_INCENDIO_X { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-DANOS-X           PIC X(005) VALUE SPACES.*/
                public StringBasis LD01_DANOS_X { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-ACIDENTES-X       PIC X(009) VALUE SPACES.*/
                public StringBasis LD01_ACIDENTES_X { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-DATAI             PIC X(005) VALUE SPACES.*/
                public StringBasis LD01_DATAI { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-DATAT             PIC X(005) VALUE SPACES.*/
                public StringBasis LD01_DATAT { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-LINHA01           PIC X(006) VALUE SPACES.*/
                public StringBasis LD01_LINHA01 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-LINHA02           PIC X(006) VALUE SPACES.*/
                public StringBasis LD01_LINHA02 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-LINHA03           PIC X(006) VALUE SPACES.*/
                public StringBasis LD01_LINHA03 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-LINHA04           PIC X(006) VALUE SPACES.*/
                public StringBasis LD01_LINHA04 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-LINHA05           PIC X(006) VALUE SPACES.*/
                public StringBasis LD01_LINHA05 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-LINHA06           PIC X(006) VALUE SPACES.*/
                public StringBasis LD01_LINHA06 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-LINHA07           PIC X(006) VALUE SPACES.*/
                public StringBasis LD01_LINHA07 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-LINHA08           PIC X(006) VALUE SPACES.*/
                public StringBasis LD01_LINHA08 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-LINHA09           PIC X(006) VALUE SPACES.*/
                public StringBasis LD01_LINHA09 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-LINHA10           PIC X(007) VALUE SPACES.*/
                public StringBasis LD01_LINHA10 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-PERCBONUS1        PIC X(010) VALUE SPACES.*/
                public StringBasis LD01_PERCBONUS1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-PERCBONUS2        PIC X(010) VALUE SPACES.*/
                public StringBasis LD01_PERCBONUS2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-PERCBONUS3        PIC X(010) VALUE SPACES.*/
                public StringBasis LD01_PERCBONUS3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-PERCBONUS4        PIC X(010) VALUE SPACES.*/
                public StringBasis LD01_PERCBONUS4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-PERCBONUS5        PIC X(010) VALUE SPACES.*/
                public StringBasis LD01_PERCBONUS5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-PERCBONUS6        PIC X(010) VALUE SPACES.*/
                public StringBasis LD01_PERCBONUS6 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-PERCBONUS7        PIC X(010) VALUE SPACES.*/
                public StringBasis LD01_PERCBONUS7 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-PERCBONUS8        PIC X(010) VALUE SPACES.*/
                public StringBasis LD01_PERCBONUS8 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-PERCBONUS9        PIC X(010) VALUE SPACES.*/
                public StringBasis LD01_PERCBONUS9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-PERCBONUS10       PIC X(011) VALUE SPACES.*/
                public StringBasis LD01_PERCBONUS10 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-OBS1              PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_OBS1 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-OBS2              PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_OBS2 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-OBS3              PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_OBS3 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-OBS4              PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_OBS4 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-OBS5              PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_OBS5 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-OBS6              PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_OBS6 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-OBS7              PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_OBS7 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-OBS8              PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_OBS8 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-OBS9              PIC X(004) VALUE SPACES.*/
                public StringBasis LD01_OBS9 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-OBS10             PIC X(005) VALUE SPACES.*/
                public StringBasis LD01_OBS10 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-OBS11             PIC X(005) VALUE SPACES.*/
                public StringBasis LD01_OBS11 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-CORRETORA         PIC X(009) VALUE SPACES.*/
                public StringBasis LD01_CORRETORA { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-SUSEP             PIC X(005) VALUE SPACES.*/
                public StringBasis LD01_SUSEP { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
                /*"    10   FILLER                 PIC X(001) VALUE '|'.*/
                public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD01-CENTRAL           PIC X(007) VALUE SPACES.*/
                public StringBasis LD01_CENTRAL { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"  05     LD02.*/
            }
            public LT2036B_LD02 LD02 { get; set; } = new LT2036B_LD02();
            public class LT2036B_LD02 : VarBasis
            {
                /*"    10   LD02-ESTIPULANTE       PIC X(055) VALUE SPACES.*/
                public StringBasis LD02_ESTIPULANTE { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"");
                /*"    10   BARRA01                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-CODCAIXA-X        PIC X(009) VALUE SPACES.*/
                public StringBasis LD02_CODCAIXA_X { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10   BARRA02                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA02 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-APOLICE-X         PIC X(013) VALUE SPACES.*/
                public StringBasis LD02_APOLICE_X { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10   BARRA03                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA03 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-AGENCIA-X         PIC X(007) VALUE SPACES.*/
                public StringBasis LD02_AGENCIA_X { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"");
                /*"    10   BARRA04                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA04 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-OPER-X            PIC X(004) VALUE SPACES.*/
                public StringBasis LD02_OPER_X { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   BARRA05                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA05 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-CONTA-X           PIC X(013) VALUE SPACES.*/
                public StringBasis LD02_CONTA_X { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"");
                /*"    10   BARRA06                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA06 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-RAZAO-SOCIAL      PIC X(040) VALUE SPACES.*/
                public StringBasis LD02_RAZAO_SOCIAL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    10   BARRA07                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA07 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-CNPJ              PIC X(018) VALUE SPACES.*/
                public StringBasis LD02_CNPJ { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
                /*"    10   BARRA08                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA08 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-ENDERECO          PIC X(055) VALUE SPACES.*/
                public StringBasis LD02_ENDERECO { get; set; } = new StringBasis(new PIC("X", "55", "X(055)"), @"");
                /*"    10   BARRA09                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA09 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-BAIRRO            PIC X(020) VALUE SPACES.*/
                public StringBasis LD02_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10   BARRA10                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-CIDADE            PIC X(020) VALUE SPACES.*/
                public StringBasis LD02_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10   BARRA11                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-UF                PIC X(002) VALUE SPACES.*/
                public StringBasis LD02_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
                /*"    10   BARRA12                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-CEP-X             PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_CEP_X { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA13                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-DDD-X             PIC X(004) VALUE SPACES.*/
                public StringBasis LD02_DDD_X { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"");
                /*"    10   BARRA14                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-TELEFONE-X        PIC X(009) VALUE SPACES.*/
                public StringBasis LD02_TELEFONE_X { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10   BARRA15                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA15 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-E-MAIL            PIC X(050) VALUE SPACES.*/
                public StringBasis LD02_E_MAIL { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10   BARRA16                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-FAX-X             PIC X(009) VALUE SPACES.*/
                public StringBasis LD02_FAX_X { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10   BARRA17                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-ROUBO-X           PIC X(020) VALUE SPACES.*/
                public StringBasis LD02_ROUBO_X { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10   BARRA18                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-INCENDIO-X        PIC X(020) VALUE SPACES.*/
                public StringBasis LD02_INCENDIO_X { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10   BARRA19                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-DANOS-X           PIC X(020) VALUE SPACES.*/
                public StringBasis LD02_DANOS_X { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10   BARRA20                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-ACIDENTES-X       PIC X(020) VALUE SPACES.*/
                public StringBasis LD02_ACIDENTES_X { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"");
                /*"    10   BARRA21                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-DATAI             PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_DATAI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA22                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-DATAT             PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_DATAT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA23                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-LINHA01           PIC X(070) VALUE SPACES.*/
                public StringBasis LD02_LINHA01 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"    10   BARRA24                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-LINHA02           PIC X(070) VALUE SPACES.*/
                public StringBasis LD02_LINHA02 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"    10   BARRA25                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-LINHA03           PIC X(070) VALUE SPACES.*/
                public StringBasis LD02_LINHA03 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"    10   BARRA26                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-LINHA04           PIC X(070) VALUE SPACES.*/
                public StringBasis LD02_LINHA04 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"    10   BARRA27                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA27 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-LINHA05           PIC X(070) VALUE SPACES.*/
                public StringBasis LD02_LINHA05 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"    10   BARRA28                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-LINHA06           PIC X(070) VALUE SPACES.*/
                public StringBasis LD02_LINHA06 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"    10   BARRA29                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA29 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-LINHA07           PIC X(070) VALUE SPACES.*/
                public StringBasis LD02_LINHA07 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"    10   BARRA30                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-LINHA08           PIC X(070) VALUE SPACES.*/
                public StringBasis LD02_LINHA08 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"    10   BARRA31                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-LINHA09           PIC X(070) VALUE SPACES.*/
                public StringBasis LD02_LINHA09 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"    10   BARRA32                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-LINHA10           PIC X(070) VALUE SPACES.*/
                public StringBasis LD02_LINHA10 { get; set; } = new StringBasis(new PIC("X", "70", "X(070)"), @"");
                /*"    10   BARRA33                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-PERCBONUS01       PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_PERCBONUS01 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA34                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-PERCBONUS02       PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_PERCBONUS02 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA35                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-PERCBONUS03       PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_PERCBONUS03 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA36                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-PERCBONUS04       PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_PERCBONUS04 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA37                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-PERCBONUS05       PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_PERCBONUS05 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA38                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-PERCBONUS06       PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_PERCBONUS06 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA39                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-PERCBONUS07       PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_PERCBONUS07 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA40                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-PERCBONUS08       PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_PERCBONUS08 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA41                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-PERCBONUS09       PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_PERCBONUS09 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA42                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-PERCBONUS10       PIC X(010) VALUE SPACES.*/
                public StringBasis LD02_PERCBONUS10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*"    10   BARRA43                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-OBS1              PIC X(080) VALUE SPACES.*/
                public StringBasis LD02_OBS1 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"    10   BARRA44                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-OBS2              PIC X(080) VALUE SPACES.*/
                public StringBasis LD02_OBS2 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"    10   BARRA45                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-OBS3              PIC X(080) VALUE SPACES.*/
                public StringBasis LD02_OBS3 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"    10   BARRA46                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-OBS4              PIC X(080) VALUE SPACES.*/
                public StringBasis LD02_OBS4 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"    10   BARRA47                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-OBS5              PIC X(080) VALUE SPACES.*/
                public StringBasis LD02_OBS5 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"    10   BARRA48                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-OBS6              PIC X(080) VALUE SPACES.*/
                public StringBasis LD02_OBS6 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"    10   BARRA49                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-OBS7              PIC X(080) VALUE SPACES.*/
                public StringBasis LD02_OBS7 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"    10   BARRA50                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-OBS8              PIC X(080) VALUE SPACES.*/
                public StringBasis LD02_OBS8 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"    10   BARRA51                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-OBS9              PIC X(080) VALUE SPACES.*/
                public StringBasis LD02_OBS9 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"    10   BARRA52                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA52 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-OBS10             PIC X(080) VALUE SPACES.*/
                public StringBasis LD02_OBS10 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"    10   BARRA53                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-OBS11             PIC X(080) VALUE SPACES.*/
                public StringBasis LD02_OBS11 { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"");
                /*"    10   BARRA54                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-CORRETORA         PIC X(050) VALUE SPACES.*/
                public StringBasis LD02_CORRETORA { get; set; } = new StringBasis(new PIC("X", "50", "X(050)"), @"");
                /*"    10   BARRA55                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA55 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-SUSEP             PIC X(009) VALUE SPACES.*/
                public StringBasis LD02_SUSEP { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"");
                /*"    10   BARRA56                PIC X(001) VALUE '|'.*/
                public StringBasis BARRA56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"|");
                /*"    10   LD02-CENTRAL           PIC X(015) VALUE SPACES.*/
                public StringBasis LD02_CENTRAL { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
                /*"  05        WABEND.*/
            }
            public LT2036B_WABEND WABEND { get; set; } = new LT2036B_WABEND();
            public class LT2036B_WABEND : VarBasis
            {
                /*"    10      FILLER              PIC  X(008) VALUE           'LT2036B '.*/
                public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"LT2036B ");
                /*"    10      FILLER              PIC  X(025) VALUE           '*** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"*** ERRO EXEC SQL NUMERO ");
                /*"    10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"    10      FILLER              PIC  X(013) VALUE           ' *** SQLCODE '.*/
                public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"    10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
            }
        }


        public Dclgens.LOTERI01 LOTERI01 { get; set; } = new Dclgens.LOTERI01();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.LTSOLPAR LTSOLPAR { get; set; } = new Dclgens.LTSOLPAR();
        public Dclgens.OUTROCOB OUTROCOB { get; set; } = new Dclgens.OUTROCOB();
        public LT2036B_C1RELATO C1RELATO { get; set; } = new LT2036B_C1RELATO();
        public LT2036B_IMPSEG IMPSEG { get; set; } = new LT2036B_IMPSEG();
        public LT2036B_CURS02 CURS02 { get; set; } = new LT2036B_CURS02();
        public LT2036B_BONUS BONUS { get; set; } = new LT2036B_BONUS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string MOV2036B_FILE_NAME_P, string RLT2036B_FILE_NAME_P, string ARQSORT_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                MOV2036B.SetFile(MOV2036B_FILE_NAME_P);
                RLT2036B.SetFile(RLT2036B_FILE_NAME_P);
                ARQSORT.SetFile(ARQSORT_FILE_NAME_P);

                /*" -638- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

                /*" -640- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

                /*" -642- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

                /*" -646- PERFORM R8999-OPEN-ARQUIVOS. */

                R8999_OPEN_ARQUIVOS_SECTION();

                /*" -648- PERFORM R0100-SELECT-V1SISTEMA. */

                R0100_SELECT_V1SISTEMA_SECTION();

                /*" -649- IF WFIM-V1SISTEMA EQUAL 'S' */

                if (AREA_DE_WORK.WFIM_V1SISTEMA == "S")
                {

                    /*" -650- DISPLAY 'SAIDA POR ERRO DA V1SISTEMA' */
                    _.Display($"SAIDA POR ERRO DA V1SISTEMA");

                    /*" -656- GO TO R0000-99-STOP. */

                    R0000_99_STOP(); //GOTO
                    return Result;
                }


                /*" -658- PERFORM R8000-00-INCLUIR-RELATORIO */

                R8000_00_INCLUIR_RELATORIO_SECTION();

                /*" -662- SORT ARQSORT ON ASCENDING KEY SORT-UF, SORT-CODCAIXA INPUT PROCEDURE R0110-INPUT-SORT THRU R0110-SAIDA OUTPUT PROCEDURE R2000-OUTPUT-SORT THRU R2000-SAIDA. */
                ARQSORT.Sort("SORT-UF,,SORT-CODCAIXA", () => R0110_INPUT_SORT_SECTION(), () => R2000_OUTPUT_SORT_SECTION());

                /*" -662- FLUXCONTROL_PERFORM R0000-90-FINALIZA */

                R0000_90_FINALIZA();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -667- IF WCONT-LOTERICO > 0 */

            if (AREA_DE_WORK.WCONT_LOTERICO > 0)
            {

                /*" -668- PERFORM R6038-IMPRIMIR-FINAL */

                R6038_IMPRIMIR_FINAL_SECTION();

                /*" -670- PERFORM R0130-DEL-V0RELATORIOS . */

                R0130_DEL_V0RELATORIOS_SECTION();
            }


            /*" -672- DISPLAY 'TOTAL DE REGISTROS LIDOS ................:' WCONT-LOTERICO. */
            _.Display($"TOTAL DE REGISTROS LIDOS ................:{AREA_DE_WORK.WCONT_LOTERICO}");

            /*" -675- DISPLAY 'TOTAL DE CERTIFICADOS GRAVADOS ..........:' WCONT-REG-GRAVADO. */
            _.Display($"TOTAL DE CERTIFICADOS GRAVADOS ..........:{AREA_DE_WORK.WCONT_REG_GRAVADO}");

            /*" -677- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -677- PERFORM R7010-COMMIT-WORK. */

            R7010_COMMIT_WORK_SECTION();

        }

        [StopWatch]
        /*" R0000-99-STOP */
        private void R0000_99_STOP(bool isPerform = false)
        {
            /*" -683- PERFORM R9000-CLOSE-ARQUIVOS */

            R9000_CLOSE_ARQUIVOS_SECTION();

            /*" -685- DISPLAY 'LT2036B - FIM NORMAL' . */
            _.Display($"LT2036B - FIM NORMAL");

            /*" -685- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_SAIDA*/

        [StopWatch]
        /*" R0100-SELECT-V1SISTEMA-SECTION */
        private void R0100_SELECT_V1SISTEMA_SECTION()
        {
            /*" -694- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -699- PERFORM R0100_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -702- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -703- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -704- DISPLAY 'LT2036B - SISTEMA LT NAO CADASTRADO' */
                    _.Display($"LT2036B - SISTEMA LT NAO CADASTRADO");

                    /*" -705- MOVE 'S' TO WFIM-V1SISTEMA */
                    _.Move("S", AREA_DE_WORK.WFIM_V1SISTEMA);

                    /*" -706- GO TO R0100-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_SAIDA*/ //GOTO
                    return;

                    /*" -707- ELSE */
                }
                else
                {


                    /*" -708- DISPLAY 'PROBLEMA SELECT V1SISTEMA' */
                    _.Display($"PROBLEMA SELECT V1SISTEMA");

                    /*" -708- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0100-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -699- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'LT' END-EXEC. */

            var r0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_SAIDA*/

        [StopWatch]
        /*" R0110-INPUT-SORT-SECTION */
        private void R0110_INPUT_SORT_SECTION()
        {
            /*" -718- MOVE '0110' TO WNR-EXEC-SQL. */
            _.Move("0110", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -727- PERFORM R0110_INPUT_SORT_DB_DECLARE_1 */

            R0110_INPUT_SORT_DB_DECLARE_1();

            /*" -729- PERFORM R0110_INPUT_SORT_DB_OPEN_1 */

            R0110_INPUT_SORT_DB_OPEN_1();

            /*" -732- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -733- DISPLAY 'PROBLEMAS DE OPEN NA V0RELATORIOS' */
                _.Display($"PROBLEMAS DE OPEN NA V0RELATORIOS");

                /*" -733- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R0110_LER_SOLICITACAO */

            R0110_LER_SOLICITACAO();

        }

        [StopWatch]
        /*" R0110-INPUT-SORT-DB-DECLARE-1 */
        public void R0110_INPUT_SORT_DB_DECLARE_1()
        {
            /*" -727- EXEC SQL DECLARE C1RELATO CURSOR FOR SELECT CODPDT, NUM_APOLICE, NRENDOS FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'LT' AND CODRELAT = 'LT2036B1' END-EXEC. */
            C1RELATO = new LT2036B_C1RELATO(false);
            string GetQuery_C1RELATO()
            {
                var query = @$"SELECT 
							CODPDT
							, 
							NUM_APOLICE
							, 
							NRENDOS 
							FROM 
							SEGUROS.V0RELATORIOS 
							WHERE 
							IDSISTEM = 'LT' 
							AND CODRELAT = 'LT2036B1'";

                return query;
            }
            C1RELATO.GetQueryEvent += GetQuery_C1RELATO;

        }

        [StopWatch]
        /*" R0110-INPUT-SORT-DB-OPEN-1 */
        public void R0110_INPUT_SORT_DB_OPEN_1()
        {
            /*" -729- EXEC SQL OPEN C1RELATO END-EXEC. */

            C1RELATO.Open();

        }

        [StopWatch]
        /*" R0210-SELECT-IMP-SEG-DB-DECLARE-1 */
        public void R0210_SELECT_IMP_SEG_DB_DECLARE_1()
        {
            /*" -1089- EXEC SQL DECLARE IMPSEG CURSOR FOR SELECT T1.COD_COBERTURA, T1.IMP_SEG FROM SEGUROS.V0LOTIMPSEG01 T1 WHERE T1.NUM_APOLICE = :V0APO-NUM-APOLICE AND T1.COD_LOT_FENAL = :V0LOT-COD-LOT-FENAL AND T1.DTINIVIG = ( SELECT MIN(T2.DTINIVIG) FROM SEGUROS.V0LOTIMPSEG01 T2 WHERE T2.NUM_APOLICE = T1.NUM_APOLICE AND T2.COD_LOT_FENAL = T1.COD_LOT_FENAL AND T2.COD_COBERTURA = T1.COD_COBERTURA ) END-EXEC. */
            IMPSEG = new LT2036B_IMPSEG(true);
            string GetQuery_IMPSEG()
            {
                var query = @$"SELECT T1.COD_COBERTURA
							, 
							T1.IMP_SEG 
							FROM SEGUROS.V0LOTIMPSEG01 T1 
							WHERE T1.NUM_APOLICE = '{V0APO_NUM_APOLICE}' 
							AND T1.COD_LOT_FENAL = '{V0LOT_COD_LOT_FENAL}' 
							AND T1.DTINIVIG = ( SELECT MIN(T2.DTINIVIG) 
							FROM SEGUROS.V0LOTIMPSEG01 T2 
							WHERE T2.NUM_APOLICE = T1.NUM_APOLICE 
							AND T2.COD_LOT_FENAL = T1.COD_LOT_FENAL 
							AND T2.COD_COBERTURA = T1.COD_COBERTURA )";

                return query;
            }
            IMPSEG.GetQueryEvent += GetQuery_IMPSEG;

        }

        [StopWatch]
        /*" R0110-LER-SOLICITACAO */
        private void R0110_LER_SOLICITACAO(bool isPerform = false)
        {
            /*" -744- PERFORM R0110_LER_SOLICITACAO_DB_FETCH_1 */

            R0110_LER_SOLICITACAO_DB_FETCH_1();

            /*" -747- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -748- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -748- PERFORM R0110_LER_SOLICITACAO_DB_CLOSE_1 */

                    R0110_LER_SOLICITACAO_DB_CLOSE_1();

                    /*" -750- MOVE 'S' TO WFIM-REL */
                    _.Move("S", AREA_DE_WORK.WFIM_REL);

                    /*" -751- GO TO R0110-FIM-LEITURA */

                    R0110_FIM_LEITURA(); //GOTO
                    return;

                    /*" -752- ELSE */
                }
                else
                {


                    /*" -753- DISPLAY 'PROBLEMAS DE ACESSO NA V0RELATORIOS' */
                    _.Display($"PROBLEMAS DE ACESSO NA V0RELATORIOS");

                    /*" -756- GO TO R9999-00-ROT-ERRO . */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -758- ADD 1 TO WCONT-LOTERICO. */
            AREA_DE_WORK.WCONT_LOTERICO.Value = AREA_DE_WORK.WCONT_LOTERICO + 1;

            /*" -762- DISPLAY ' R0110-LIDO LOT : ' V0LOT-COD-LOT-FENAL ' APOLICE : ' V0APO-NUM-APOLICE ' ENDOSSO : ' V0APO-NUM-ENDOSSO . */

            $" R0110-LIDO LOT : {V0LOT_COD_LOT_FENAL} APOLICE : {V0APO_NUM_APOLICE} ENDOSSO : {V0APO_NUM_ENDOSSO}"
            .Display();

            /*" -764- PERFORM R0160-SELECT-V0LOTERICO. */

            R0160_SELECT_V0LOTERICO_SECTION();

            /*" -765- IF WLOT-ENCONTRADO = 'NAO' */

            if (AREA_DE_WORK.WLOT_ENCONTRADO == "NAO")
            {

                /*" -766- MOVE SPACES TO WLOT-ENCONTRADO */
                _.Move("", AREA_DE_WORK.WLOT_ENCONTRADO);

                /*" -767- ELSE */
            }
            else
            {


                /*" -770- PERFORM R0170-PROCESSA-LOTERICO. */

                R0170_PROCESSA_LOTERICO_SECTION();
            }


            /*" -770- GO TO R0110-LER-SOLICITACAO. */
            new Task(() => R0110_LER_SOLICITACAO()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0110-LER-SOLICITACAO-DB-FETCH-1 */
        public void R0110_LER_SOLICITACAO_DB_FETCH_1()
        {
            /*" -744- EXEC SQL FETCH C1RELATO INTO :V0LOT-COD-LOT-FENAL , :V0APO-NUM-APOLICE , :V0APO-NUM-ENDOSSO END-EXEC. */

            if (C1RELATO.Fetch())
            {
                _.Move(C1RELATO.V0LOT_COD_LOT_FENAL, V0LOT_COD_LOT_FENAL);
                _.Move(C1RELATO.V0APO_NUM_APOLICE, V0APO_NUM_APOLICE);
                _.Move(C1RELATO.V0APO_NUM_ENDOSSO, V0APO_NUM_ENDOSSO);
            }

        }

        [StopWatch]
        /*" R0110-LER-SOLICITACAO-DB-CLOSE-1 */
        public void R0110_LER_SOLICITACAO_DB_CLOSE_1()
        {
            /*" -748- EXEC SQL CLOSE C1RELATO END-EXEC */

            C1RELATO.Close();

        }

        [StopWatch]
        /*" R0110-FIM-LEITURA */
        private void R0110_FIM_LEITURA(bool isPerform = false)
        {
            /*" -776- IF WCONT-LOTERICO = ZEROS */

            if (AREA_DE_WORK.WCONT_LOTERICO == 00)
            {

                /*" -777- DISPLAY 'SOLIC. NAO ENCONTRADA NA LT-SOLICITA-PARAM' */
                _.Display($"SOLIC. NAO ENCONTRADA NA LT-SOLICITA-PARAM");

                /*" -778- ELSE */
            }
            else
            {


                /*" -778- DISPLAY 'TOTAL REGISTROS LIDOS :' WCONT-LOTERICO. */
                _.Display($"TOTAL REGISTROS LIDOS :{AREA_DE_WORK.WCONT_LOTERICO}");
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0110_SAIDA*/

        [StopWatch]
        /*" R0130-DEL-V0RELATORIOS-SECTION */
        private void R0130_DEL_V0RELATORIOS_SECTION()
        {
            /*" -789- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -794- PERFORM R0130_DEL_V0RELATORIOS_DB_DELETE_1 */

            R0130_DEL_V0RELATORIOS_DB_DELETE_1();

            /*" -797- IF SQLCODE NOT EQUAL 0 AND 100 */

            if (!DB.SQLCODE.In("0", "100"))
            {

                /*" -798- DISPLAY 'PROBLEMAS DE DELETE NA V0RELATORIOS' */
                _.Display($"PROBLEMAS DE DELETE NA V0RELATORIOS");

                /*" -798- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0130-DEL-V0RELATORIOS-DB-DELETE-1 */
        public void R0130_DEL_V0RELATORIOS_DB_DELETE_1()
        {
            /*" -794- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'LT' AND CODRELAT = 'LT2036B1' END-EXEC. */

            var r0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1 = new R0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1()
            {
            };

            R0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1.Execute(r0130_DEL_V0RELATORIOS_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0130_99_SAIDA*/

        [StopWatch]
        /*" R0160-SELECT-V0LOTERICO-SECTION */
        private void R0160_SELECT_V0LOTERICO_SECTION()
        {
            /*" -809- MOVE '0160' TO WNR-EXEC-SQL. */
            _.Move("0160", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -815- PERFORM R0160_SELECT_V0LOTERICO_DB_SELECT_1 */

            R0160_SELECT_V0LOTERICO_DB_SELECT_1();

            /*" -818- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -821- DISPLAY 'R0160-ERRO MAX DTINIVIG LOTERICO' ' LOTERICO ' V0LOT-COD-LOT-FENAL ' SQLCODE  ' SQLCODE */

                $"R0160-ERRO MAX DTINIVIG LOTERICO LOTERICO {V0LOT_COD_LOT_FENAL} SQLCODE  {DB.SQLCODE}"
                .Display();

                /*" -823- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -876- PERFORM R0160_SELECT_V0LOTERICO_DB_SELECT_2 */

            R0160_SELECT_V0LOTERICO_DB_SELECT_2();

            /*" -879- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -880- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -881- MOVE 'NAO' TO WLOT-ENCONTRADO */
                    _.Move("NAO", AREA_DE_WORK.WLOT_ENCONTRADO);

                    /*" -882- DISPLAY 'LOTERICO NAO ENCONTRADO.' */
                    _.Display($"LOTERICO NAO ENCONTRADO.");

                    /*" -883- DISPLAY 'NUMERO DA APOLICE...: ' V0APO-NUM-APOLICE */
                    _.Display($"NUMERO DA APOLICE...: {V0APO_NUM_APOLICE}");

                    /*" -884- DISPLAY 'CODIGO DO LOTERICO..: ' V0LOT-COD-LOT-FENAL */
                    _.Display($"CODIGO DO LOTERICO..: {V0LOT_COD_LOT_FENAL}");

                    /*" -885- DISPLAY 'MAXDTINIVI..........: ' WS-MAX-DTINIVIG */
                    _.Display($"MAXDTINIVI..........: {AREA_DE_WORK.WS_MAX_DTINIVIG}");

                    /*" -886- ELSE */
                }
                else
                {


                    /*" -887- DISPLAY 'PROBLEMAS NO ACESSO A LOTERICO01' */
                    _.Display($"PROBLEMAS NO ACESSO A LOTERICO01");

                    /*" -889- GO TO R9999-00-ROT-ERRO. R0160-SAIDA. EXIT. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0160-SELECT-V0LOTERICO-DB-SELECT-1 */
        public void R0160_SELECT_V0LOTERICO_DB_SELECT_1()
        {
            /*" -815- EXEC SQL SELECT VALUE(MAX(DTINIVIG), '9999-12-31' ) INTO :WS-MAX-DTINIVIG FROM SEGUROS.LOTERICO01 WHERE NUM_APOLICE = :V0APO-NUM-APOLICE AND COD_LOT_CEF = :V0LOT-COD-LOT-FENAL END-EXEC. */

            var r0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1 = new R0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1()
            {
                V0LOT_COD_LOT_FENAL = V0LOT_COD_LOT_FENAL.ToString(),
                V0APO_NUM_APOLICE = V0APO_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1.Execute(r0160_SELECT_V0LOTERICO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_DTINIVIG, AREA_DE_WORK.WS_MAX_DTINIVIG);
            }


        }

        [StopWatch]
        /*" R0170-PROCESSA-LOTERICO-SECTION */
        private void R0170_PROCESSA_LOTERICO_SECTION()
        {
            /*" -897- MOVE '0170' TO WNR-EXEC-SQL. */
            _.Move("0170", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -899- PERFORM R0180-SELECT-APOLICE. */

            R0180_SELECT_APOLICE_SECTION();

            /*" -900- MOVE V0APO-NOME TO SORT-ESTIPULANTE */
            _.Move(V0APO_NOME, REG_SORT.SORT_ESTIPULANTE);

            /*" -901- MOVE V0LOT-COD-LOT-FENAL TO SORT-CODCAIXA */
            _.Move(V0LOT_COD_LOT_FENAL, REG_SORT.SORT_CODCAIXA_X.SORT_CODCAIXA);

            /*" -902- MOVE V0LOT-NUM-APOLICE TO SORT-APOLICE */
            _.Move(V0LOT_NUM_APOLICE, REG_SORT.SORT_APOLICE_X.SORT_APOLICE);

            /*" -903- MOVE LOTERI01-AGENCIA TO SORT-AGENCIA */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_AGENCIA, REG_SORT.SORT_AGENCIA_X.SORT_AGENCIA);

            /*" -904- MOVE LOTERI01-OPERACAO-CONTA TO SORT-OPER */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_OPERACAO_CONTA, REG_SORT.SORT_OPER_X.SORT_OPER);

            /*" -905- MOVE LOTERI01-NUMERO-CONTA TO WORK-NUM-CONTA */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUMERO_CONTA, AREA_DE_WORK.WORK_CONTA.WORK_NUM_CONTA);

            /*" -906- MOVE LOTERI01-DV-CONTA TO WORK-DV-CONTA */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_DV_CONTA, AREA_DE_WORK.WORK_CONTA.WORK_DV_CONTA);

            /*" -907- MOVE WORK-CONTA TO SORT-CONTA */
            _.Move(AREA_DE_WORK.WORK_CONTA, REG_SORT.SORT_CONTA_X.SORT_CONTA);

            /*" -909- MOVE CLIENTES-NOME-RAZAO TO SORT-RAZAO-SOCIAL */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, REG_SORT.SORT_RAZAO_SOCIAL);

            /*" -910- IF CLIENTES-TIPO-PESSOA = 'F' */

            if (CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA == "F")
            {

                /*" -911- MOVE CLIENTES-CGCCPF TO SORT-CNPF */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, REG_SORT.SORT_CNPF);

                /*" -912- ELSE */
            }
            else
            {


                /*" -913- MOVE CLIENTES-CGCCPF TO SORT-CNPJ. */
                _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, REG_SORT.SORT_CNPJ);
            }


            /*" -915- MOVE '-' TO SORT-CNPF-TRACO. */
            _.Move("-", REG_SORT.FILLER_0.SORT_CNPF_TRACO);

            /*" -916- MOVE LOTERI01-ENDERECO TO WORK-ENDER-01 */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_ENDERECO, AREA_DE_WORK.WORK_ENDERECO.WORK_ENDER_01);

            /*" -917- MOVE LOTERI01-COMPL-ENDERECO TO WORK-ENDER-02 */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_COMPL_ENDERECO, AREA_DE_WORK.WORK_ENDERECO.WORK_ENDER_02);

            /*" -918- MOVE WORK-ENDERECO TO SORT-ENDERECO */
            _.Move(AREA_DE_WORK.WORK_ENDERECO, REG_SORT.SORT_ENDERECO);

            /*" -919- MOVE LOTERI01-BAIRRO TO SORT-BAIRRO */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_BAIRRO, REG_SORT.SORT_BAIRRO);

            /*" -920- IF LOTERI01-CEP = ZEROS */

            if (LOTERI01.DCLLOTERICO01.LOTERI01_CEP == 00)
            {

                /*" -921- MOVE SPACES TO SORT-CEP-X */
                _.Move("", REG_SORT.SORT_CEP_X);

                /*" -922- ELSE */
            }
            else
            {


                /*" -923- MOVE LOTERI01-CEP TO WORK-CEP */
                _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_CEP, AREA_DE_WORK.WORK_CEP);

                /*" -924- MOVE WORK-CEP-01 TO SORT-CEP01 */
                _.Move(AREA_DE_WORK.FILLER_8.WORK_CEP_01, REG_SORT.FILLER_3.SORT_CEP01);

                /*" -925- MOVE WORK-CEP-02 TO SORT-CEP02 */
                _.Move(AREA_DE_WORK.FILLER_8.WORK_CEP_02, REG_SORT.FILLER_3.SORT_CEP02);

                /*" -926- MOVE WORK-CEP-03 TO SORT-CEP03 */
                _.Move(AREA_DE_WORK.FILLER_8.WORK_CEP_03, REG_SORT.FILLER_3.SORT_CEP03);

                /*" -927- MOVE '.' TO SORT-CEP-PTO */
                _.Move(".", REG_SORT.FILLER_3.SORT_CEP_PTO);

                /*" -928- MOVE '-' TO SORT-CEP-TRACO. */
                _.Move("-", REG_SORT.FILLER_3.SORT_CEP_TRACO);
            }


            /*" -929- MOVE LOTERI01-CIDADE TO SORT-CIDADE */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_CIDADE, REG_SORT.SORT_CIDADE);

            /*" -930- MOVE LOTERI01-SIGLA-UF TO SORT-UF */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_SIGLA_UF, REG_SORT.SORT_UF);

            /*" -931- MOVE LOTERI01-DDD TO SORT-DDD */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_DDD, REG_SORT.SORT_DDD_X.SORT_DDD);

            /*" -932- IF LOTERI01-NUM-FONE = ZEROS */

            if (LOTERI01.DCLLOTERICO01.LOTERI01_NUM_FONE == 00)
            {

                /*" -933- MOVE SPACES TO SORT-TELEFONE-X */
                _.Move("", REG_SORT.SORT_TELEFONE_X);

                /*" -934- ELSE */
            }
            else
            {


                /*" -935- MOVE LOTERI01-NUM-FONE TO WORK-TELEFONE */
                _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUM_FONE, AREA_DE_WORK.WORK_TELEFONE);

                /*" -936- MOVE WORK-FONE-02 TO SORT-FONE01 */
                _.Move(AREA_DE_WORK.FILLER_9.WORK_FONE_02, REG_SORT.FILLER_4.SORT_FONE01);

                /*" -937- MOVE WORK-FONE-03 TO SORT-FONE02 */
                _.Move(AREA_DE_WORK.FILLER_9.WORK_FONE_03, REG_SORT.FILLER_4.SORT_FONE02);

                /*" -939- MOVE '-' TO SORT-FONE-TRACO. */
                _.Move("-", REG_SORT.FILLER_4.SORT_FONE_TRACO);
            }


            /*" -941- MOVE LOTERI01-DES-EMAIL TO SORT-E-MAIL */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_DES_EMAIL, REG_SORT.SORT_E_MAIL);

            /*" -942- IF LOTERI01-NUM-FAX = ZEROS */

            if (LOTERI01.DCLLOTERICO01.LOTERI01_NUM_FAX == 00)
            {

                /*" -943- MOVE SPACES TO SORT-FAX-X */
                _.Move("", REG_SORT.SORT_FAX_X);

                /*" -944- ELSE */
            }
            else
            {


                /*" -945- MOVE LOTERI01-NUM-FAX TO WORK-TELEFONE */
                _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_NUM_FAX, AREA_DE_WORK.WORK_TELEFONE);

                /*" -946- MOVE WORK-FONE-02 TO SORT-FAX01 */
                _.Move(AREA_DE_WORK.FILLER_9.WORK_FONE_02, REG_SORT.FILLER_5.SORT_FAX01);

                /*" -947- MOVE WORK-FONE-03 TO SORT-FAX02 */
                _.Move(AREA_DE_WORK.FILLER_9.WORK_FONE_03, REG_SORT.FILLER_5.SORT_FAX02);

                /*" -949- MOVE '-' TO SORT-FAX-TRACO. */
                _.Move("-", REG_SORT.FILLER_5.SORT_FAX_TRACO);
            }


            /*" -951- PERFORM R0190-SELECT-DTINIVIG-INI. */

            R0190_SELECT_DTINIVIG_INI_SECTION();

            /*" -952- MOVE LOTERI01-DTINIVIG TO WORK-DATA-FORM */
            _.Move(LOTERI01.DCLLOTERICO01.LOTERI01_DTINIVIG, AREA_DE_WORK.WORK_DATA_FORM);

            /*" -953- MOVE WORK-DT-DD-FORM TO SORT-DATAI-DD */
            _.Move(AREA_DE_WORK.WORK_DATA_FORM.WORK_DT_DD_FORM, REG_SORT.SORT_DATAI.SORT_DATAI_DD);

            /*" -954- MOVE WORK-DT-MM-FORM TO SORT-DATAI-MM */
            _.Move(AREA_DE_WORK.WORK_DATA_FORM.WORK_DT_MM_FORM, REG_SORT.SORT_DATAI.SORT_DATAI_MM);

            /*" -955- MOVE WORK-DT-AA-FORM TO SORT-DATAI-AA */
            _.Move(AREA_DE_WORK.WORK_DATA_FORM.WORK_DT_AA_FORM, REG_SORT.SORT_DATAI.SORT_DATAI_AA);

            /*" -956- MOVE V0APO-DTTERVIG TO WORK-DATA-FORM */
            _.Move(V0APO_DTTERVIG, AREA_DE_WORK.WORK_DATA_FORM);

            /*" -957- MOVE WORK-DT-DD-FORM TO SORT-DATAT-DD */
            _.Move(AREA_DE_WORK.WORK_DATA_FORM.WORK_DT_DD_FORM, REG_SORT.SORT_DATAT.SORT_DATAT_DD);

            /*" -958- MOVE WORK-DT-MM-FORM TO SORT-DATAT-MM */
            _.Move(AREA_DE_WORK.WORK_DATA_FORM.WORK_DT_MM_FORM, REG_SORT.SORT_DATAT.SORT_DATAT_MM);

            /*" -959- MOVE WORK-DT-AA-FORM TO SORT-DATAT-AA */
            _.Move(AREA_DE_WORK.WORK_DATA_FORM.WORK_DT_AA_FORM, REG_SORT.SORT_DATAT.SORT_DATAT_AA);

            /*" -962- MOVE '/' TO SORT-TRACO01 SORT-TRACO02 SORT-TRACO03 SORT-TRACO04. */
            _.Move("/", REG_SORT.SORT_DATAI.SORT_TRACO01, REG_SORT.SORT_DATAI.SORT_TRACO02, REG_SORT.SORT_DATAT.SORT_TRACO03, REG_SORT.SORT_DATAT.SORT_TRACO04);

            /*" -963- MOVE 0 TO SORT-INCENDIO. */
            _.Move(0, REG_SORT.SORT_INCENDIO_X.SORT_INCENDIO);

            /*" -964- MOVE 0 TO SORT-DANOS. */
            _.Move(0, REG_SORT.SORT_DANOS_X.SORT_DANOS);

            /*" -965- MOVE 0 TO SORT-ACID-EMPR. */
            _.Move(0, REG_SORT.SORT_ACID_EMPR_X.SORT_ACID_EMPR);

            /*" -966- MOVE 0 TO SORT-ACID-EMP. */
            _.Move(0, REG_SORT.SORT_ACID_EMP_X.SORT_ACID_EMP);

            /*" -967- MOVE 0 TO SORT-ROUBO. */
            _.Move(0, REG_SORT.SORT_ROUBO_X.SORT_ROUBO);

            /*" -969- MOVE 0 TO SORT-RC. */
            _.Move(0, REG_SORT.SORT_RC_X.SORT_RC);

            /*" -970- IF V0APO-DTINIVIG LESS THAN '2004-01-01' */

            if (V0APO_DTINIVIG < "2004-01-01")
            {

                /*" -971- PERFORM R0210-SELECT-IMP-SEG */

                R0210_SELECT_IMP_SEG_SECTION();

                /*" -972- ELSE */
            }
            else
            {


                /*" -974- PERFORM R2500-00-COBERTURAS . */

                R2500_00_COBERTURAS_SECTION();
            }


            /*" -975- MOVE SPACES TO SORT-LINHA(1). */
            _.Move("", REG_SORT.SORT_LINHA[1]);

            /*" -976- MOVE SPACES TO SORT-LINHA(2). */
            _.Move("", REG_SORT.SORT_LINHA[2]);

            /*" -977- MOVE SPACES TO SORT-LINHA(3). */
            _.Move("", REG_SORT.SORT_LINHA[3]);

            /*" -978- MOVE SPACES TO SORT-LINHA(4). */
            _.Move("", REG_SORT.SORT_LINHA[4]);

            /*" -979- MOVE SPACES TO SORT-LINHA(5). */
            _.Move("", REG_SORT.SORT_LINHA[5]);

            /*" -980- MOVE SPACES TO SORT-LINHA(6). */
            _.Move("", REG_SORT.SORT_LINHA[6]);

            /*" -981- MOVE SPACES TO SORT-LINHA(7). */
            _.Move("", REG_SORT.SORT_LINHA[7]);

            /*" -982- MOVE SPACES TO SORT-LINHA(8). */
            _.Move("", REG_SORT.SORT_LINHA[8]);

            /*" -983- MOVE SPACES TO SORT-LINHA(9). */
            _.Move("", REG_SORT.SORT_LINHA[9]);

            /*" -985- MOVE SPACES TO SORT-LINHA(10). */
            _.Move("", REG_SORT.SORT_LINHA[10]);

            /*" -986- MOVE SPACES TO SORT-OBS1 */
            _.Move("", REG_SORT.SORT_OBS1);

            /*" -987- MOVE SPACES TO SORT-OBS2 */
            _.Move("", REG_SORT.SORT_OBS2);

            /*" -988- MOVE SPACES TO SORT-OBS3 */
            _.Move("", REG_SORT.SORT_OBS3);

            /*" -989- MOVE SPACES TO SORT-OBS4 */
            _.Move("", REG_SORT.SORT_OBS4);

            /*" -990- MOVE SPACES TO SORT-OBS5 */
            _.Move("", REG_SORT.SORT_OBS5);

            /*" -991- MOVE SPACES TO SORT-OBS6 */
            _.Move("", REG_SORT.SORT_OBS6);

            /*" -992- MOVE SPACES TO SORT-OBS7 */
            _.Move("", REG_SORT.SORT_OBS7);

            /*" -993- MOVE SPACES TO SORT-OBS8 */
            _.Move("", REG_SORT.SORT_OBS8);

            /*" -994- MOVE SPACES TO SORT-OBS9 */
            _.Move("", REG_SORT.SORT_OBS9);

            /*" -995- MOVE SPACES TO SORT-OBS10 */
            _.Move("", REG_SORT.SORT_OBS10);

            /*" -997- MOVE SPACES TO SORT-OBS11 */
            _.Move("", REG_SORT.SORT_OBS11);

            /*" -999- PERFORM R0230-SELECT-BONUS. */

            R0230_SELECT_BONUS_SECTION();

            /*" -1001- MOVE 'FENAE CORRETORA DE SEGUROS E ADM. DE BENS S/A' TO SORT-CORRETORA */
            _.Move("FENAE CORRETORA DE SEGUROS E ADM. DE BENS S/A", REG_SORT.SORT_CORRETORA);

            /*" -1002- MOVE '100109541' TO SORT-SUSEP */
            _.Move("100109541", REG_SORT.SORT_SUSEP);

            /*" -1004- MOVE '(0800) 282-0151' TO SORT-CENTRAL */
            _.Move("(0800) 282-0151", REG_SORT.SORT_CENTRAL);

            /*" -1005- MOVE ZEROS TO WCONT-IMP-SEG. */
            _.Move(0, AREA_DE_WORK.WCONT_IMP_SEG);

            /*" -1007- MOVE ZEROS TO WCONT-BONUS. */
            _.Move(0, AREA_DE_WORK.WCONT_BONUS);

            /*" -1007- RELEASE REG-SORT. */
            ARQSORT.Release(REG_SORT);

        }

        [StopWatch]
        /*" R0160-SELECT-V0LOTERICO-DB-SELECT-2 */
        public void R0160_SELECT_V0LOTERICO_DB_SELECT_2()
        {
            /*" -876- EXEC SQL SELECT L.COD_LOT_FENAL, L.COD_LOT_CEF, L.NUM_APOLICE, L.AGENCIA, L.OPERACAO_CONTA, L.NUMERO_CONTA, L.DV_CONTA, L.COD_CLIENTE, L.ENDERECO, L.COMPL_ENDERECO, L.BAIRRO, L.CEP, L.CIDADE, L.SIGLA_UF, L.DDD, L.NUM_FONE, L.DES_EMAIL, L.NUM_FAX, L.DTINIVIG, L.DTTERVIG, C.NOME_RAZAO, C.CGCCPF, C.TIPO_PESSOA INTO :V0LOT-COD-LOT-FENAL, :V0LOT-COD-LOT-CEF, :V0LOT-NUM-APOLICE, :LOTERI01-AGENCIA, :LOTERI01-OPERACAO-CONTA, :LOTERI01-NUMERO-CONTA, :LOTERI01-DV-CONTA, :V0LOT-COD-CLIENTE, :LOTERI01-ENDERECO, :LOTERI01-COMPL-ENDERECO, :LOTERI01-BAIRRO, :LOTERI01-CEP, :LOTERI01-CIDADE, :LOTERI01-SIGLA-UF, :LOTERI01-DDD, :LOTERI01-NUM-FONE, :LOTERI01-DES-EMAIL, :LOTERI01-NUM-FAX, :V0LOT-DTINIVIG, :V0LOT-DTTERVIG, :CLIENTES-NOME-RAZAO, :CLIENTES-CGCCPF, :CLIENTES-TIPO-PESSOA FROM SEGUROS.V0LOTERICO01 L, SEGUROS.CLIENTES C WHERE L.NUM_APOLICE = :V0APO-NUM-APOLICE AND L.COD_LOT_CEF = :V0LOT-COD-LOT-FENAL AND L.DTINIVIG = :WS-MAX-DTINIVIG AND L.COD_CLIENTE = C.COD_CLIENTE END-EXEC. */

            var r0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1 = new R0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1()
            {
                V0LOT_COD_LOT_FENAL = V0LOT_COD_LOT_FENAL.ToString(),
                V0APO_NUM_APOLICE = V0APO_NUM_APOLICE.ToString(),
                WS_MAX_DTINIVIG = AREA_DE_WORK.WS_MAX_DTINIVIG.ToString(),
            };

            var executed_1 = R0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1.Execute(r0160_SELECT_V0LOTERICO_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0LOT_COD_LOT_FENAL, V0LOT_COD_LOT_FENAL);
                _.Move(executed_1.V0LOT_COD_LOT_CEF, V0LOT_COD_LOT_CEF);
                _.Move(executed_1.V0LOT_NUM_APOLICE, V0LOT_NUM_APOLICE);
                _.Move(executed_1.LOTERI01_AGENCIA, LOTERI01.DCLLOTERICO01.LOTERI01_AGENCIA);
                _.Move(executed_1.LOTERI01_OPERACAO_CONTA, LOTERI01.DCLLOTERICO01.LOTERI01_OPERACAO_CONTA);
                _.Move(executed_1.LOTERI01_NUMERO_CONTA, LOTERI01.DCLLOTERICO01.LOTERI01_NUMERO_CONTA);
                _.Move(executed_1.LOTERI01_DV_CONTA, LOTERI01.DCLLOTERICO01.LOTERI01_DV_CONTA);
                _.Move(executed_1.V0LOT_COD_CLIENTE, V0LOT_COD_CLIENTE);
                _.Move(executed_1.LOTERI01_ENDERECO, LOTERI01.DCLLOTERICO01.LOTERI01_ENDERECO);
                _.Move(executed_1.LOTERI01_COMPL_ENDERECO, LOTERI01.DCLLOTERICO01.LOTERI01_COMPL_ENDERECO);
                _.Move(executed_1.LOTERI01_BAIRRO, LOTERI01.DCLLOTERICO01.LOTERI01_BAIRRO);
                _.Move(executed_1.LOTERI01_CEP, LOTERI01.DCLLOTERICO01.LOTERI01_CEP);
                _.Move(executed_1.LOTERI01_CIDADE, LOTERI01.DCLLOTERICO01.LOTERI01_CIDADE);
                _.Move(executed_1.LOTERI01_SIGLA_UF, LOTERI01.DCLLOTERICO01.LOTERI01_SIGLA_UF);
                _.Move(executed_1.LOTERI01_DDD, LOTERI01.DCLLOTERICO01.LOTERI01_DDD);
                _.Move(executed_1.LOTERI01_NUM_FONE, LOTERI01.DCLLOTERICO01.LOTERI01_NUM_FONE);
                _.Move(executed_1.LOTERI01_DES_EMAIL, LOTERI01.DCLLOTERICO01.LOTERI01_DES_EMAIL);
                _.Move(executed_1.LOTERI01_NUM_FAX, LOTERI01.DCLLOTERICO01.LOTERI01_NUM_FAX);
                _.Move(executed_1.V0LOT_DTINIVIG, V0LOT_DTINIVIG);
                _.Move(executed_1.V0LOT_DTTERVIG, V0LOT_DTTERVIG);
                _.Move(executed_1.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(executed_1.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(executed_1.CLIENTES_TIPO_PESSOA, CLIENTES.DCLCLIENTES.CLIENTES_TIPO_PESSOA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0170_SAIDA*/

        [StopWatch]
        /*" R0180-SELECT-APOLICE-SECTION */
        private void R0180_SELECT_APOLICE_SECTION()
        {
            /*" -1017- MOVE '0180' TO WNR-EXEC-SQL. */
            _.Move("0180", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1025- PERFORM R0180_SELECT_APOLICE_DB_SELECT_1 */

            R0180_SELECT_APOLICE_DB_SELECT_1();

            /*" -1028- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1029- DISPLAY 'R0180-ERRO SELECT V0APOLICE = ' V0APO-NUM-APOLICE */
                _.Display($"R0180-ERRO SELECT V0APOLICE = {V0APO_NUM_APOLICE}");

                /*" -1031- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1040- PERFORM R0180_SELECT_APOLICE_DB_SELECT_2 */

            R0180_SELECT_APOLICE_DB_SELECT_2();

            /*" -1043- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1044- DISPLAY 'R0180-ERRO-SELECT-V0APOLICE = ' V0APO-NUM-APOLICE */
                _.Display($"R0180-ERRO-SELECT-V0APOLICE = {V0APO_NUM_APOLICE}");

                /*" -1046- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1047- DISPLAY 'R0180-LIDO V0APOLICE = ' V0APO-NUM-APOLICE ' ESTIP=' V0APO-NOME . */

            $"R0180-LIDO V0APOLICE = {V0APO_NUM_APOLICE} ESTIP={V0APO_NOME}"
            .Display();

        }

        [StopWatch]
        /*" R0180-SELECT-APOLICE-DB-SELECT-1 */
        public void R0180_SELECT_APOLICE_DB_SELECT_1()
        {
            /*" -1025- EXEC SQL SELECT DTINIVIG , DTTERVIG INTO :V0APO-DTINIVIG , :V0APO-DTTERVIG FROM SEGUROS.V0ENDOSSO WHERE NUM_APOLICE = :V0APO-NUM-APOLICE AND NRENDOS = :V0APO-NUM-ENDOSSO END-EXEC. */

            var r0180_SELECT_APOLICE_DB_SELECT_1_Query1 = new R0180_SELECT_APOLICE_DB_SELECT_1_Query1()
            {
                V0APO_NUM_APOLICE = V0APO_NUM_APOLICE.ToString(),
                V0APO_NUM_ENDOSSO = V0APO_NUM_ENDOSSO.ToString(),
            };

            var executed_1 = R0180_SELECT_APOLICE_DB_SELECT_1_Query1.Execute(r0180_SELECT_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APO_DTINIVIG, V0APO_DTINIVIG);
                _.Move(executed_1.V0APO_DTTERVIG, V0APO_DTTERVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0180_SAIDA*/

        [StopWatch]
        /*" R0180-SELECT-APOLICE-DB-SELECT-2 */
        public void R0180_SELECT_APOLICE_DB_SELECT_2()
        {
            /*" -1040- EXEC SQL SELECT A.NOME INTO :V0APO-NOME FROM SEGUROS.V1APOLICE A, SEGUROS.V0ENDOSSO E WHERE A.NUM_APOLICE = :V0APO-NUM-APOLICE AND A.NUM_APOLICE = E.NUM_APOLICE AND E.NRENDOS = 0 END-EXEC. */

            var r0180_SELECT_APOLICE_DB_SELECT_2_Query1 = new R0180_SELECT_APOLICE_DB_SELECT_2_Query1()
            {
                V0APO_NUM_APOLICE = V0APO_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0180_SELECT_APOLICE_DB_SELECT_2_Query1.Execute(r0180_SELECT_APOLICE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0APO_NOME, V0APO_NOME);
            }


        }

        [StopWatch]
        /*" R0190-SELECT-DTINIVIG-INI-SECTION */
        private void R0190_SELECT_DTINIVIG_INI_SECTION()
        {
            /*" -1057- MOVE '0190' TO WNR-EXEC-SQL. */
            _.Move("0190", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1063- PERFORM R0190_SELECT_DTINIVIG_INI_DB_SELECT_1 */

            R0190_SELECT_DTINIVIG_INI_DB_SELECT_1();

            /*" -1066- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1067- DISPLAY 'R0190-ERRO SELECT V0APOLICE = ' V0APO-NUM-APOLICE */
                _.Display($"R0190-ERRO SELECT V0APOLICE = {V0APO_NUM_APOLICE}");

                /*" -1067- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0190-SELECT-DTINIVIG-INI-DB-SELECT-1 */
        public void R0190_SELECT_DTINIVIG_INI_DB_SELECT_1()
        {
            /*" -1063- EXEC SQL SELECT MIN(DTINIVIG) - 1 DAY INTO :LOTERI01-DTINIVIG FROM SEGUROS.LOTERICO01 WHERE NUM_APOLICE = :V0APO-NUM-APOLICE AND COD_LOT_CEF = :V0LOT-COD-LOT-FENAL END-EXEC. */

            var r0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1 = new R0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1()
            {
                V0LOT_COD_LOT_FENAL = V0LOT_COD_LOT_FENAL.ToString(),
                V0APO_NUM_APOLICE = V0APO_NUM_APOLICE.ToString(),
            };

            var executed_1 = R0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1.Execute(r0190_SELECT_DTINIVIG_INI_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.LOTERI01_DTINIVIG, LOTERI01.DCLLOTERICO01.LOTERI01_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0190_SAIDA*/

        [StopWatch]
        /*" R0210-SELECT-IMP-SEG-SECTION */
        private void R0210_SELECT_IMP_SEG_SECTION()
        {
            /*" -1077- MOVE '0210' TO WNR-EXEC-SQL. */
            _.Move("0210", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1089- PERFORM R0210_SELECT_IMP_SEG_DB_DECLARE_1 */

            R0210_SELECT_IMP_SEG_DB_DECLARE_1();

            /*" -1091- PERFORM R0210_SELECT_IMP_SEG_DB_OPEN_1 */

            R0210_SELECT_IMP_SEG_DB_OPEN_1();

            /*" -1094- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1095- DISPLAY 'ERRO DECLARE DA V0LOTIMPSEG01' */
                _.Display($"ERRO DECLARE DA V0LOTIMPSEG01");

                /*" -1095- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R0210_LER_IMP_SEG */

            R0210_LER_IMP_SEG();

        }

        [StopWatch]
        /*" R0210-SELECT-IMP-SEG-DB-OPEN-1 */
        public void R0210_SELECT_IMP_SEG_DB_OPEN_1()
        {
            /*" -1091- EXEC SQL OPEN IMPSEG END-EXEC. */

            IMPSEG.Open();

        }

        [StopWatch]
        /*" R2500-00-COBERTURAS-DB-DECLARE-1 */
        public void R2500_00_COBERTURAS_DB_DECLARE_1()
        {
            /*" -1166- EXEC SQL DECLARE CURS02 CURSOR FOR SELECT DISTINCT A.COD_COBERTURA , A.IMP_SEGURADA_IX , A.PRM_TARIFARIO_IX , A.VAL_FRANQ_OBR_IX , A.MODALI_COBERTURA FROM SEGUROS.OUTROS_COBERTURAS A WHERE A.NUM_APOLICE = :V0APO-NUM-APOLICE AND A.NUM_ENDOSSO = :V0APO-NUM-ENDOSSO ORDER BY A.COD_COBERTURA END-EXEC. */
            CURS02 = new LT2036B_CURS02(true);
            string GetQuery_CURS02()
            {
                var query = @$"SELECT DISTINCT A.COD_COBERTURA
							, 
							A.IMP_SEGURADA_IX
							, 
							A.PRM_TARIFARIO_IX
							, 
							A.VAL_FRANQ_OBR_IX
							, 
							A.MODALI_COBERTURA 
							FROM SEGUROS.OUTROS_COBERTURAS A 
							WHERE A.NUM_APOLICE = '{V0APO_NUM_APOLICE}' 
							AND A.NUM_ENDOSSO = '{V0APO_NUM_ENDOSSO}' 
							ORDER BY A.COD_COBERTURA";

                return query;
            }
            CURS02.GetQueryEvent += GetQuery_CURS02;

        }

        [StopWatch]
        /*" R0210-LER-IMP-SEG */
        private void R0210_LER_IMP_SEG(bool isPerform = false)
        {
            /*" -1103- PERFORM R0210_LER_IMP_SEG_DB_FETCH_1 */

            R0210_LER_IMP_SEG_DB_FETCH_1();

            /*" -1106- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1107- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1108- IF WCONT-IMP-SEG = 0 */

                    if (AREA_DE_WORK.WCONT_IMP_SEG == 0)
                    {

                        /*" -1112- DISPLAY ' R0210' ' APO:' V0APO-NUM-APOLICE ' LOT:' V0LOT-COD-LOT-FENAL ' LOTERICO N/TEM I.S' */

                        $" R0210 APO:{V0APO_NUM_APOLICE} LOT:{V0LOT_COD_LOT_FENAL} LOTERICO N/TEM I.S"
                        .Display();

                        /*" -1113- END-IF */
                    }


                    /*" -1113- PERFORM R0210_LER_IMP_SEG_DB_CLOSE_1 */

                    R0210_LER_IMP_SEG_DB_CLOSE_1();

                    /*" -1115- GO TO R0210-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_SAIDA*/ //GOTO
                    return;

                    /*" -1116- ELSE */
                }
                else
                {


                    /*" -1117- DISPLAY 'ERRO NO FETCH DA V0LOTIMPSEG01' */
                    _.Display($"ERRO NO FETCH DA V0LOTIMPSEG01");

                    /*" -1119- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1121- ADD 1 TO WCONT-IMP-SEG. */
            AREA_DE_WORK.WCONT_IMP_SEG.Value = AREA_DE_WORK.WCONT_IMP_SEG + 1;

            /*" -1122- IF V0IMP-COD-COBERTURA = 1 */

            if (V0IMP_COD_COBERTURA == 1)
            {

                /*" -1124- MOVE V0IMP-IMP-SEG TO SORT-INCENDIO. */
                _.Move(V0IMP_IMP_SEG, REG_SORT.SORT_INCENDIO_X.SORT_INCENDIO);
            }


            /*" -1125- IF V0IMP-COD-COBERTURA = 2 */

            if (V0IMP_COD_COBERTURA == 2)
            {

                /*" -1127- MOVE V0IMP-IMP-SEG TO SORT-DANOS. */
                _.Move(V0IMP_IMP_SEG, REG_SORT.SORT_DANOS_X.SORT_DANOS);
            }


            /*" -1128- IF V0IMP-COD-COBERTURA = 3 */

            if (V0IMP_COD_COBERTURA == 3)
            {

                /*" -1129- MOVE V0IMP-IMP-SEG TO SORT-ACID-EMPR */
                _.Move(V0IMP_IMP_SEG, REG_SORT.SORT_ACID_EMPR_X.SORT_ACID_EMPR);

                /*" -1132- MOVE ZEROS TO SORT-ACID-EMP SORT-RC. */
                _.Move(0, REG_SORT.SORT_ACID_EMP_X.SORT_ACID_EMP, REG_SORT.SORT_RC_X.SORT_RC);
            }


            /*" -1133- IF V0IMP-COD-COBERTURA = 4 */

            if (V0IMP_COD_COBERTURA == 4)
            {

                /*" -1135- MOVE V0IMP-IMP-SEG TO SORT-ROUBO. */
                _.Move(V0IMP_IMP_SEG, REG_SORT.SORT_ROUBO_X.SORT_ROUBO);
            }


            /*" -1141- DISPLAY ' R0210' ' APO:' V0APO-NUM-APOLICE ' LOT:' V0LOT-COD-LOT-FENAL ' I.S:' V0IMP-IMP-SEG ' COB:' V0IMP-COD-COBERTURA . */

            $" R0210 APO:{V0APO_NUM_APOLICE} LOT:{V0LOT_COD_LOT_FENAL} I.S:{V0IMP_IMP_SEG} COB:{V0IMP_COD_COBERTURA}"
            .Display();

            /*" -1141- GO TO R0210-LER-IMP-SEG. */
            new Task(() => R0210_LER_IMP_SEG()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0210-LER-IMP-SEG-DB-FETCH-1 */
        public void R0210_LER_IMP_SEG_DB_FETCH_1()
        {
            /*" -1103- EXEC SQL FETCH IMPSEG INTO :V0IMP-COD-COBERTURA, :V0IMP-IMP-SEG END-EXEC. */

            if (IMPSEG.Fetch())
            {
                _.Move(IMPSEG.V0IMP_COD_COBERTURA, V0IMP_COD_COBERTURA);
                _.Move(IMPSEG.V0IMP_IMP_SEG, V0IMP_IMP_SEG);
            }

        }

        [StopWatch]
        /*" R0210-LER-IMP-SEG-DB-CLOSE-1 */
        public void R0210_LER_IMP_SEG_DB_CLOSE_1()
        {
            /*" -1113- EXEC SQL CLOSE IMPSEG END-EXEC */

            IMPSEG.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0210_SAIDA*/

        [StopWatch]
        /*" R2500-00-COBERTURAS-SECTION */
        private void R2500_00_COBERTURAS_SECTION()
        {
            /*" -1156- MOVE ' ' TO WS-FIM-CURS02. */
            _.Move(" ", AREA_DE_WORK.WS_FIM_CURS02);

            /*" -1166- PERFORM R2500_00_COBERTURAS_DB_DECLARE_1 */

            R2500_00_COBERTURAS_DB_DECLARE_1();

            /*" -1170- PERFORM R2501-00-OPEN-CURS02. */

            R2501_00_OPEN_CURS02_SECTION();

            /*" -1172- PERFORM R2502-00-FETCH-CURS02. */

            R2502_00_FETCH_CURS02_SECTION();

            /*" -1173- PERFORM R2503-00-PROCESSA-CURS02 UNTIL WS-FIM-CURS02 EQUAL 'S' . */

            while (!(AREA_DE_WORK.WS_FIM_CURS02 == "S"))
            {

                R2503_00_PROCESSA_CURS02_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2501-00-OPEN-CURS02-SECTION */
        private void R2501_00_OPEN_CURS02_SECTION()
        {
            /*" -1182- PERFORM R2501_00_OPEN_CURS02_DB_OPEN_1 */

            R2501_00_OPEN_CURS02_DB_OPEN_1();

            /*" -1185- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1186- MOVE 'S' TO WS-FIM-CURS02 */
                _.Move("S", AREA_DE_WORK.WS_FIM_CURS02);

                /*" -1187- DISPLAY 'R2501-ERRO OPEN-CURS02' */
                _.Display($"R2501-ERRO OPEN-CURS02");

                /*" -1187- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2501-00-OPEN-CURS02-DB-OPEN-1 */
        public void R2501_00_OPEN_CURS02_DB_OPEN_1()
        {
            /*" -1182- EXEC SQL OPEN CURS02 END-EXEC. */

            CURS02.Open();

        }

        [StopWatch]
        /*" R0230-SELECT-BONUS-DB-DECLARE-1 */
        public void R0230_SELECT_BONUS_DB_DECLARE_1()
        {
            /*" -1256- EXEC SQL DECLARE BONUS CURSOR FOR SELECT TIPO_BONUS, PERCENT_BONUS FROM SEGUROS.V0LOTBONUS01 WHERE NUM_APOLICE = :V0APO-NUM-APOLICE AND COD_LOT_FENAL = :V0LOT-COD-LOT-FENAL END-EXEC. */
            BONUS = new LT2036B_BONUS(true);
            string GetQuery_BONUS()
            {
                var query = @$"SELECT TIPO_BONUS
							, 
							PERCENT_BONUS 
							FROM SEGUROS.V0LOTBONUS01 
							WHERE NUM_APOLICE = '{V0APO_NUM_APOLICE}' 
							AND COD_LOT_FENAL = '{V0LOT_COD_LOT_FENAL}'";

                return query;
            }
            BONUS.GetQueryEvent += GetQuery_BONUS;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2501_99_EXIT*/

        [StopWatch]
        /*" R2502-00-FETCH-CURS02-SECTION */
        private void R2502_00_FETCH_CURS02_SECTION()
        {
            /*" -1200- PERFORM R2502_00_FETCH_CURS02_DB_FETCH_1 */

            R2502_00_FETCH_CURS02_DB_FETCH_1();

            /*" -1203- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1204- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1205- MOVE 'S' TO WS-FIM-CURS02 */
                    _.Move("S", AREA_DE_WORK.WS_FIM_CURS02);

                    /*" -1205- PERFORM R2502_00_FETCH_CURS02_DB_CLOSE_1 */

                    R2502_00_FETCH_CURS02_DB_CLOSE_1();

                    /*" -1207- ELSE */
                }
                else
                {


                    /*" -1208- DISPLAY 'R2502-ERRO FETCH-CURS02' */
                    _.Display($"R2502-ERRO FETCH-CURS02");

                    /*" -1208- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R2502-00-FETCH-CURS02-DB-FETCH-1 */
        public void R2502_00_FETCH_CURS02_DB_FETCH_1()
        {
            /*" -1200- EXEC SQL FETCH CURS02 INTO :OUTROCOB-COD-COBERTURA , :OUTROCOB-IMP-SEGURADA-IX , :OUTROCOB-PRM-TARIFARIO-IX , :OUTROCOB-VAL-FRANQ-OBR-IX END-EXEC. */

            if (CURS02.Fetch())
            {
                _.Move(CURS02.OUTROCOB_COD_COBERTURA, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA);
                _.Move(CURS02.OUTROCOB_IMP_SEGURADA_IX, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX);
                _.Move(CURS02.OUTROCOB_PRM_TARIFARIO_IX, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_PRM_TARIFARIO_IX);
                _.Move(CURS02.OUTROCOB_VAL_FRANQ_OBR_IX, OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_VAL_FRANQ_OBR_IX);
            }

        }

        [StopWatch]
        /*" R2502-00-FETCH-CURS02-DB-CLOSE-1 */
        public void R2502_00_FETCH_CURS02_DB_CLOSE_1()
        {
            /*" -1205- EXEC SQL CLOSE CURS02 END-EXEC */

            CURS02.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2502_99_SAIDA*/

        [StopWatch]
        /*" R2503-00-PROCESSA-CURS02-SECTION */
        private void R2503_00_PROCESSA_CURS02_SECTION()
        {
            /*" -1220- IF OUTROCOB-COD-COBERTURA = 1 */

            if (OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA == 1)
            {

                /*" -1222- MOVE OUTROCOB-IMP-SEGURADA-IX TO SORT-INCENDIO. */
                _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX, REG_SORT.SORT_INCENDIO_X.SORT_INCENDIO);
            }


            /*" -1223- IF OUTROCOB-COD-COBERTURA = 2 */

            if (OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA == 2)
            {

                /*" -1225- MOVE OUTROCOB-IMP-SEGURADA-IX TO SORT-ROUBO. */
                _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX, REG_SORT.SORT_ROUBO_X.SORT_ROUBO);
            }


            /*" -1226- IF OUTROCOB-COD-COBERTURA = 3 */

            if (OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA == 3)
            {

                /*" -1228- MOVE OUTROCOB-IMP-SEGURADA-IX TO SORT-DANOS */
                _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX, REG_SORT.SORT_DANOS_X.SORT_DANOS);

                /*" -1229- IF OUTROCOB-COD-COBERTURA = 4 */

                if (OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA == 4)
                {

                    /*" -1231- MOVE OUTROCOB-IMP-SEGURADA-IX TO SORT-ACID-EMPR. */
                    _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX, REG_SORT.SORT_ACID_EMPR_X.SORT_ACID_EMPR);
                }

            }


            /*" -1232- IF OUTROCOB-COD-COBERTURA = 5 */

            if (OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA == 5)
            {

                /*" -1234- MOVE OUTROCOB-IMP-SEGURADA-IX TO SORT-ACID-EMP. */
                _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX, REG_SORT.SORT_ACID_EMP_X.SORT_ACID_EMP);
            }


            /*" -1235- IF OUTROCOB-COD-COBERTURA = 6 */

            if (OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_COD_COBERTURA == 6)
            {

                /*" -1238- MOVE OUTROCOB-IMP-SEGURADA-IX TO SORT-RC. */
                _.Move(OUTROCOB.DCLOUTROS_COBERTURAS.OUTROCOB_IMP_SEGURADA_IX, REG_SORT.SORT_RC_X.SORT_RC);
            }


            /*" -1238- PERFORM R2502-00-FETCH-CURS02. */

            R2502_00_FETCH_CURS02_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R503_99_SAIDA*/

        [StopWatch]
        /*" R0230-SELECT-BONUS-SECTION */
        private void R0230_SELECT_BONUS_SECTION()
        {
            /*" -1249- MOVE '0230' TO WNR-EXEC-SQL. */
            _.Move("0230", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1256- PERFORM R0230_SELECT_BONUS_DB_DECLARE_1 */

            R0230_SELECT_BONUS_DB_DECLARE_1();

            /*" -1258- PERFORM R0230_SELECT_BONUS_DB_OPEN_1 */

            R0230_SELECT_BONUS_DB_OPEN_1();

            /*" -1261- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1262- DISPLAY 'ERRO DECLARE DA V0LOTBONUS01' */
                _.Display($"ERRO DECLARE DA V0LOTBONUS01");

                /*" -1262- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R0230_LER_BONUS */

            R0230_LER_BONUS();

        }

        [StopWatch]
        /*" R0230-SELECT-BONUS-DB-OPEN-1 */
        public void R0230_SELECT_BONUS_DB_OPEN_1()
        {
            /*" -1258- EXEC SQL OPEN BONUS END-EXEC. */

            BONUS.Open();

        }

        [StopWatch]
        /*" R0230-LER-BONUS */
        private void R0230_LER_BONUS(bool isPerform = false)
        {
            /*" -1268- PERFORM R0230_LER_BONUS_DB_FETCH_1 */

            R0230_LER_BONUS_DB_FETCH_1();

            /*" -1271- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1272- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1273- IF WCONT-BONUS = 0 */

                    if (AREA_DE_WORK.WCONT_BONUS == 0)
                    {

                        /*" -1274- DISPLAY 'LOTERICO N/TEM BONUS' */
                        _.Display($"LOTERICO N/TEM BONUS");

                        /*" -1275- DISPLAY 'NUMERO DA APOLICE..: ' V0APO-NUM-APOLICE */
                        _.Display($"NUMERO DA APOLICE..: {V0APO_NUM_APOLICE}");

                        /*" -1276- DISPLAY 'NUM DO LOTERICO....; ' V0LOT-COD-LOT-FENAL */
                        _.Display($"NUM DO LOTERICO....; {V0LOT_COD_LOT_FENAL}");

                        /*" -1277- END-IF */
                    }


                    /*" -1277- PERFORM R0230_LER_BONUS_DB_CLOSE_1 */

                    R0230_LER_BONUS_DB_CLOSE_1();

                    /*" -1279- GO TO R0230-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_SAIDA*/ //GOTO
                    return;

                    /*" -1280- ELSE */
                }
                else
                {


                    /*" -1281- DISPLAY 'ERRO NO FETCH DA V0LOTBONUS01' */
                    _.Display($"ERRO NO FETCH DA V0LOTBONUS01");

                    /*" -1283- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1285- ADD 1 TO WCONT-BONUS. */
            AREA_DE_WORK.WCONT_BONUS.Value = AREA_DE_WORK.WCONT_BONUS + 1;

            /*" -1286- IF V0BON-TIPO-BONUS = 1 */

            if (V0BON_TIPO_BONUS == 1)
            {

                /*" -1288- MOVE 'BONUS SINISTRALIDADE' TO SORT-PART1-LINHA (WCONT-BONUS) */
                _.Move("BONUS SINISTRALIDADE", REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_PART1_LINHA);

                /*" -1290- MOVE ': ' TO SORT-TRACO-LINHA (WCONT-BONUS) */
                _.Move(": ", REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_VALOR_PERC.SORT_TRACO_LINHA);

                /*" -1292- MOVE V0BON-PERCENT-BONUS TO SORT-PART2-LINHA (WCONT-BONUS) */
                _.Move(V0BON_PERCENT_BONUS, REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_VALOR_PERC.SORT_PART2_LINHA);

                /*" -1295- MOVE ' %' TO SORT-PART3-LINHA (WCONT-BONUS). */
                _.Move(" %", REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_VALOR_PERC.SORT_PART3_LINHA);
            }


            /*" -1296- IF V0BON-TIPO-BONUS = 2 */

            if (V0BON_TIPO_BONUS == 2)
            {

                /*" -1298- MOVE 'ALARME              ' TO SORT-PART1-LINHA (WCONT-BONUS) */
                _.Move("ALARME              ", REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_PART1_LINHA);

                /*" -1300- MOVE ': ' TO SORT-TRACO-LINHA (WCONT-BONUS) */
                _.Move(": ", REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_VALOR_PERC.SORT_TRACO_LINHA);

                /*" -1302- MOVE V0BON-PERCENT-BONUS TO SORT-PART2-LINHA (WCONT-BONUS) */
                _.Move(V0BON_PERCENT_BONUS, REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_VALOR_PERC.SORT_PART2_LINHA);

                /*" -1305- MOVE ' %' TO SORT-PART3-LINHA (WCONT-BONUS). */
                _.Move(" %", REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_VALOR_PERC.SORT_PART3_LINHA);
            }


            /*" -1306- IF V0BON-TIPO-BONUS = 3 */

            if (V0BON_TIPO_BONUS == 3)
            {

                /*" -1309- MOVE 'CIRCUITO DE TV (CAMERA E MONITOR OU CAMERA E VIDEO)' TO SORT-PART1-LINHA (WCONT-BONUS) */
                _.Move("CIRCUITO DE TV (CAMERA E MONITOR OU CAMERA E VIDEO)", REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_PART1_LINHA);

                /*" -1311- MOVE ': ' TO SORT-TRACO-LINHA (WCONT-BONUS) */
                _.Move(": ", REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_VALOR_PERC.SORT_TRACO_LINHA);

                /*" -1313- MOVE V0BON-PERCENT-BONUS TO SORT-PART2-LINHA (WCONT-BONUS) */
                _.Move(V0BON_PERCENT_BONUS, REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_VALOR_PERC.SORT_PART2_LINHA);

                /*" -1318- MOVE ' %' TO SORT-PART3-LINHA (WCONT-BONUS) . */
                _.Move(" %", REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_VALOR_PERC.SORT_PART3_LINHA);
            }


            /*" -1319- IF V0BON-TIPO-BONUS = 4 */

            if (V0BON_TIPO_BONUS == 4)
            {

                /*" -1322- MOVE 'COFRE BOCA DE LOBO COM FECHADURA ELETRONICA/MECANICA DE RETARDO' TO SORT-PART1-LINHA (WCONT-BONUS) */
                _.Move("COFRE BOCA DE LOBO COM FECHADURA ELETRONICA/MECANICA DE RETARDO", REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_PART1_LINHA);

                /*" -1324- MOVE ': ' TO SORT-TRACO-LINHA (WCONT-BONUS) */
                _.Move(": ", REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_VALOR_PERC.SORT_TRACO_LINHA);

                /*" -1326- MOVE V0BON-PERCENT-BONUS TO SORT-PART2-LINHA (WCONT-BONUS) */
                _.Move(V0BON_PERCENT_BONUS, REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_VALOR_PERC.SORT_PART2_LINHA);

                /*" -1331- MOVE ' %' TO SORT-PART3-LINHA (WCONT-BONUS). */
                _.Move(" %", REG_SORT.SORT_LINHA[AREA_DE_WORK.WCONT_BONUS].SORT_VALOR_PERC.SORT_PART3_LINHA);
            }


            /*" -1331- GO TO R0230-LER-BONUS. */
            new Task(() => R0230_LER_BONUS()).RunSynchronously(); //GOTO
            return;//Recursividade detectada, cuidado...

        }

        [StopWatch]
        /*" R0230-LER-BONUS-DB-FETCH-1 */
        public void R0230_LER_BONUS_DB_FETCH_1()
        {
            /*" -1268- EXEC SQL FETCH BONUS INTO :V0BON-TIPO-BONUS, :V0BON-PERCENT-BONUS END-EXEC. */

            if (BONUS.Fetch())
            {
                _.Move(BONUS.V0BON_TIPO_BONUS, V0BON_TIPO_BONUS);
                _.Move(BONUS.V0BON_PERCENT_BONUS, V0BON_PERCENT_BONUS);
            }

        }

        [StopWatch]
        /*" R0230-LER-BONUS-DB-CLOSE-1 */
        public void R0230_LER_BONUS_DB_CLOSE_1()
        {
            /*" -1277- EXEC SQL CLOSE BONUS END-EXEC */

            BONUS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0230_SAIDA*/

        [StopWatch]
        /*" R2000-OUTPUT-SORT-SECTION */
        private void R2000_OUTPUT_SORT_SECTION()
        {
            /*" -1341- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1342- MOVE SPACES TO WFIM-SORT. */
            _.Move("", AREA_DE_WORK.WFIM_SORT);

            /*" -1343- MOVE SPACES TO W-UF-ANT. */
            _.Move("", W_UF_ANT);

            /*" -1345- MOVE 0 TO W-COD-ANT. */
            _.Move(0, W_COD_ANT);

            /*" -1346- IF WCONT-LOTERICO = 0 */

            if (AREA_DE_WORK.WCONT_LOTERICO == 0)
            {

                /*" -1347- MOVE 'SIM' TO WFIM-SORT */
                _.Move("SIM", AREA_DE_WORK.WFIM_SORT);

                /*" -1348- DISPLAY 'R2000-NENHUM REGISTRO SELECIONADO' */
                _.Display($"R2000-NENHUM REGISTRO SELECIONADO");

                /*" -1349- ELSE */
            }
            else
            {


                /*" -1350- PERFORM R6036-IMPRIMIR-CODIGO */

                R6036_IMPRIMIR_CODIGO_SECTION();

                /*" -1351- PERFORM R2100-PROCESSA-SORT UNTIL WFIM-SORT NOT EQUAL SPACES. */

                while (!(!AREA_DE_WORK.WFIM_SORT.IsEmpty()))
                {

                    R2100_PROCESSA_SORT_SECTION();
                }
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_SAIDA*/

        [StopWatch]
        /*" R2100-PROCESSA-SORT-SECTION */
        private void R2100_PROCESSA_SORT_SECTION()
        {
            /*" -1356- SECTION. */

            /*" -0- FLUXCONTROL_PERFORM R2100_LER_LOTERICO */

            R2100_LER_LOTERICO();

        }

        [StopWatch]
        /*" R2100-LER-LOTERICO */
        private void R2100_LER_LOTERICO(bool isPerform = false)
        {
            /*" -1360- MOVE '2100' TO WNR-EXEC-SQL. */
            _.Move("2100", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1361- RETURN ARQSORT AT END */
            try
            {
                ARQSORT.Return(REG_SORT, () =>
                {

                    /*" -1362- MOVE 'SIM' TO WFIM-SORT */
                    _.Move("SIM", AREA_DE_WORK.WFIM_SORT);

                    /*" -1368- GO TO R2100-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_SAIDA*/ //GOTO
                    return;

                });
            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -1370- PERFORM R6035-IMPRIMIR-LOTERICO. */

            R6035_IMPRIMIR_LOTERICO_SECTION();

            /*" -1370- MOVE SORT-CODCAIXA TO W-COD-ANT. */
            _.Move(REG_SORT.SORT_CODCAIXA_X.SORT_CODCAIXA, W_COD_ANT);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_SAIDA*/

        [StopWatch]
        /*" R6035-IMPRIMIR-LOTERICO-SECTION */
        private void R6035_IMPRIMIR_LOTERICO_SECTION()
        {
            /*" -1380- MOVE '6035' TO WNR-EXEC-SQL. */
            _.Move("6035", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1381- IF W-UF-ANT = SPACES */

            if (W_UF_ANT.IsEmpty())
            {

                /*" -1383- MOVE SORT-UF TO W-UF-ANT. */
                _.Move(REG_SORT.SORT_UF, W_UF_ANT);
            }


            /*" -1384- IF W-UF-ANT NOT = SORT-UF */

            if (W_UF_ANT != REG_SORT.SORT_UF)
            {

                /*" -1385- PERFORM R6037-IMPRIMIR-UF */

                R6037_IMPRIMIR_UF_SECTION();

                /*" -1387- PERFORM R6036-IMPRIMIR-CODIGO. */

                R6036_IMPRIMIR_CODIGO_SECTION();
            }


            /*" -1389- MOVE SORT-UF TO W-UF-ANT. */
            _.Move(REG_SORT.SORT_UF, W_UF_ANT);

            /*" -1390- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1391- MOVE SPACES TO LD02. */
            _.Move("", AREA_DE_WORK.LD02);

            /*" -1392- MOVE SORT-ESTIPULANTE TO LD02-ESTIPULANTE. */
            _.Move(REG_SORT.SORT_ESTIPULANTE, AREA_DE_WORK.LD02.LD02_ESTIPULANTE);

            /*" -1393- MOVE SORT-CODCAIXA-X TO LD02-CODCAIXA-X. */
            _.Move(REG_SORT.SORT_CODCAIXA_X, AREA_DE_WORK.LD02.LD02_CODCAIXA_X);

            /*" -1394- MOVE SORT-APOLICE-X TO LD02-APOLICE-X. */
            _.Move(REG_SORT.SORT_APOLICE_X, AREA_DE_WORK.LD02.LD02_APOLICE_X);

            /*" -1395- MOVE SORT-AGENCIA-X TO LD02-AGENCIA-X. */
            _.Move(REG_SORT.SORT_AGENCIA_X, AREA_DE_WORK.LD02.LD02_AGENCIA_X);

            /*" -1396- MOVE SORT-OPER-X TO LD02-OPER-X. */
            _.Move(REG_SORT.SORT_OPER_X, AREA_DE_WORK.LD02.LD02_OPER_X);

            /*" -1397- MOVE SORT-CONTA-X TO LD02-CONTA-X. */
            _.Move(REG_SORT.SORT_CONTA_X, AREA_DE_WORK.LD02.LD02_CONTA_X);

            /*" -1398- MOVE SORT-RAZAO-SOCIAL TO LD02-RAZAO-SOCIAL. */
            _.Move(REG_SORT.SORT_RAZAO_SOCIAL, AREA_DE_WORK.LD02.LD02_RAZAO_SOCIAL);

            /*" -1399- MOVE SORT-CNPJ TO LD02-CNPJ. */
            _.Move(REG_SORT.SORT_CNPJ, AREA_DE_WORK.LD02.LD02_CNPJ);

            /*" -1400- MOVE SORT-ENDERECO TO LD02-ENDERECO. */
            _.Move(REG_SORT.SORT_ENDERECO, AREA_DE_WORK.LD02.LD02_ENDERECO);

            /*" -1401- MOVE SORT-BAIRRO TO LD02-BAIRRO. */
            _.Move(REG_SORT.SORT_BAIRRO, AREA_DE_WORK.LD02.LD02_BAIRRO);

            /*" -1402- MOVE SORT-CIDADE TO LD02-CIDADE. */
            _.Move(REG_SORT.SORT_CIDADE, AREA_DE_WORK.LD02.LD02_CIDADE);

            /*" -1403- MOVE SORT-UF TO LD02-UF. */
            _.Move(REG_SORT.SORT_UF, AREA_DE_WORK.LD02.LD02_UF);

            /*" -1404- MOVE SORT-CEP-X TO LD02-CEP-X. */
            _.Move(REG_SORT.SORT_CEP_X, AREA_DE_WORK.LD02.LD02_CEP_X);

            /*" -1405- MOVE SORT-DDD-X TO LD02-DDD-X. */
            _.Move(REG_SORT.SORT_DDD_X, AREA_DE_WORK.LD02.LD02_DDD_X);

            /*" -1406- MOVE SORT-TELEFONE-X TO LD02-TELEFONE-X. */
            _.Move(REG_SORT.SORT_TELEFONE_X, AREA_DE_WORK.LD02.LD02_TELEFONE_X);

            /*" -1407- MOVE SORT-E-MAIL TO LD02-E-MAIL. */
            _.Move(REG_SORT.SORT_E_MAIL, AREA_DE_WORK.LD02.LD02_E_MAIL);

            /*" -1409- MOVE SORT-FAX-X TO LD02-FAX-X. */
            _.Move(REG_SORT.SORT_FAX_X, AREA_DE_WORK.LD02.LD02_FAX_X);

            /*" -1410- MOVE SORT-ROUBO-X TO LD02-ROUBO-X. */
            _.Move(REG_SORT.SORT_ROUBO_X, AREA_DE_WORK.LD02.LD02_ROUBO_X);

            /*" -1411- MOVE SORT-INCENDIO-X TO LD02-INCENDIO-X. */
            _.Move(REG_SORT.SORT_INCENDIO_X, AREA_DE_WORK.LD02.LD02_INCENDIO_X);

            /*" -1415- MOVE SORT-DANOS-X TO LD02-DANOS-X. */
            _.Move(REG_SORT.SORT_DANOS_X, AREA_DE_WORK.LD02.LD02_DANOS_X);

            /*" -1416- IF SORT-ACID-EMPR GREATER THAN ZEROS */

            if (REG_SORT.SORT_ACID_EMPR_X.SORT_ACID_EMPR > 00)
            {

                /*" -1417- MOVE SORT-ACID-EMPR-X TO LD02-ACIDENTES-X */
                _.Move(REG_SORT.SORT_ACID_EMPR_X, AREA_DE_WORK.LD02.LD02_ACIDENTES_X);

                /*" -1418- ELSE */
            }
            else
            {


                /*" -1419- IF SORT-ACID-EMP GREATER THAN ZEROS */

                if (REG_SORT.SORT_ACID_EMP_X.SORT_ACID_EMP > 00)
                {

                    /*" -1420- MOVE SORT-ACID-EMP-X TO LD02-ACIDENTES-X */
                    _.Move(REG_SORT.SORT_ACID_EMP_X, AREA_DE_WORK.LD02.LD02_ACIDENTES_X);

                    /*" -1421- ELSE */
                }
                else
                {


                    /*" -1422- IF SORT-RC GREATER THAN ZEROS */

                    if (REG_SORT.SORT_RC_X.SORT_RC > 00)
                    {

                        /*" -1425- MOVE SORT-RC-X TO LD02-ACIDENTES-X . */
                        _.Move(REG_SORT.SORT_RC_X, AREA_DE_WORK.LD02.LD02_ACIDENTES_X);
                    }

                }

            }


            /*" -1426- MOVE SORT-DATAI TO LD02-DATAI. */
            _.Move(REG_SORT.SORT_DATAI, AREA_DE_WORK.LD02.LD02_DATAI);

            /*" -1429- MOVE SORT-DATAT TO LD02-DATAT. */
            _.Move(REG_SORT.SORT_DATAT, AREA_DE_WORK.LD02.LD02_DATAT);

            /*" -1430- MOVE SORT-PART1-LINHA(1) TO LD02-LINHA01. */
            _.Move(REG_SORT.SORT_LINHA[1].SORT_PART1_LINHA, AREA_DE_WORK.LD02.LD02_LINHA01);

            /*" -1431- MOVE SORT-VALOR-PERC(1) TO LD02-PERCBONUS01. */
            _.Move(REG_SORT.SORT_LINHA[1].SORT_VALOR_PERC, AREA_DE_WORK.LD02.LD02_PERCBONUS01);

            /*" -1432- MOVE SORT-PART1-LINHA(2) TO LD02-LINHA02. */
            _.Move(REG_SORT.SORT_LINHA[2].SORT_PART1_LINHA, AREA_DE_WORK.LD02.LD02_LINHA02);

            /*" -1433- MOVE SORT-VALOR-PERC(2) TO LD02-PERCBONUS02. */
            _.Move(REG_SORT.SORT_LINHA[2].SORT_VALOR_PERC, AREA_DE_WORK.LD02.LD02_PERCBONUS02);

            /*" -1434- MOVE SORT-PART1-LINHA(3) TO LD02-LINHA03. */
            _.Move(REG_SORT.SORT_LINHA[3].SORT_PART1_LINHA, AREA_DE_WORK.LD02.LD02_LINHA03);

            /*" -1435- MOVE SORT-VALOR-PERC(3) TO LD02-PERCBONUS03. */
            _.Move(REG_SORT.SORT_LINHA[3].SORT_VALOR_PERC, AREA_DE_WORK.LD02.LD02_PERCBONUS03);

            /*" -1436- MOVE SORT-PART1-LINHA(4) TO LD02-LINHA04. */
            _.Move(REG_SORT.SORT_LINHA[4].SORT_PART1_LINHA, AREA_DE_WORK.LD02.LD02_LINHA04);

            /*" -1438- MOVE SORT-VALOR-PERC(4) TO LD02-PERCBONUS04. */
            _.Move(REG_SORT.SORT_LINHA[4].SORT_VALOR_PERC, AREA_DE_WORK.LD02.LD02_PERCBONUS04);

            /*" -1439- MOVE SORT-OBS1 TO LD02-OBS1. */
            _.Move(REG_SORT.SORT_OBS1, AREA_DE_WORK.LD02.LD02_OBS1);

            /*" -1440- MOVE SORT-OBS2 TO LD02-OBS2. */
            _.Move(REG_SORT.SORT_OBS2, AREA_DE_WORK.LD02.LD02_OBS2);

            /*" -1441- MOVE SORT-OBS3 TO LD02-OBS3. */
            _.Move(REG_SORT.SORT_OBS3, AREA_DE_WORK.LD02.LD02_OBS3);

            /*" -1442- MOVE SORT-OBS4 TO LD02-OBS4. */
            _.Move(REG_SORT.SORT_OBS4, AREA_DE_WORK.LD02.LD02_OBS4);

            /*" -1443- MOVE SORT-OBS5 TO LD02-OBS5. */
            _.Move(REG_SORT.SORT_OBS5, AREA_DE_WORK.LD02.LD02_OBS5);

            /*" -1444- MOVE SORT-OBS6 TO LD02-OBS6. */
            _.Move(REG_SORT.SORT_OBS6, AREA_DE_WORK.LD02.LD02_OBS6);

            /*" -1445- MOVE SORT-OBS7 TO LD02-OBS7. */
            _.Move(REG_SORT.SORT_OBS7, AREA_DE_WORK.LD02.LD02_OBS7);

            /*" -1446- MOVE SORT-OBS8 TO LD02-OBS8. */
            _.Move(REG_SORT.SORT_OBS8, AREA_DE_WORK.LD02.LD02_OBS8);

            /*" -1447- MOVE SORT-OBS9 TO LD02-OBS9. */
            _.Move(REG_SORT.SORT_OBS9, AREA_DE_WORK.LD02.LD02_OBS9);

            /*" -1449- MOVE SORT-OBS10 TO LD02-OBS10. */
            _.Move(REG_SORT.SORT_OBS10, AREA_DE_WORK.LD02.LD02_OBS10);

            /*" -1450- MOVE SORT-CORRETORA TO LD02-CORRETORA. */
            _.Move(REG_SORT.SORT_CORRETORA, AREA_DE_WORK.LD02.LD02_CORRETORA);

            /*" -1451- MOVE SORT-SUSEP TO LD02-SUSEP. */
            _.Move(REG_SORT.SORT_SUSEP, AREA_DE_WORK.LD02.LD02_SUSEP);

            /*" -1453- MOVE SORT-CENTRAL TO LD02-CENTRAL. */
            _.Move(REG_SORT.SORT_CENTRAL, AREA_DE_WORK.LD02.LD02_CENTRAL);

            /*" -1466- MOVE '|' TO BARRA01 BARRA02 BARRA03 BARRA04 BARRA05 BARRA06 BARRA07 BARRA08 BARRA09 BARRA10 BARRA11 BARRA12 BARRA13 BARRA14 BARRA15 BARRA16 BARRA17 BARRA18 BARRA19 BARRA20 BARRA21 BARRA22 BARRA23 BARRA24 BARRA25 BARRA26 BARRA27 BARRA28 BARRA29 BARRA30 BARRA31 BARRA32 BARRA33 BARRA34 BARRA35 BARRA36 BARRA37 BARRA38 BARRA39 BARRA40 BARRA41 BARRA42 BARRA43 BARRA44 BARRA45 BARRA46 BARRA47 BARRA48 BARRA49 BARRA50 BARRA51 BARRA52 BARRA53 BARRA54 BARRA55 BARRA56. */
            _.Move("|", AREA_DE_WORK.LD02.BARRA01, AREA_DE_WORK.LD02.BARRA02, AREA_DE_WORK.LD02.BARRA03, AREA_DE_WORK.LD02.BARRA04, AREA_DE_WORK.LD02.BARRA05, AREA_DE_WORK.LD02.BARRA06, AREA_DE_WORK.LD02.BARRA07, AREA_DE_WORK.LD02.BARRA08, AREA_DE_WORK.LD02.BARRA09, AREA_DE_WORK.LD02.BARRA10, AREA_DE_WORK.LD02.BARRA11, AREA_DE_WORK.LD02.BARRA12, AREA_DE_WORK.LD02.BARRA13, AREA_DE_WORK.LD02.BARRA14, AREA_DE_WORK.LD02.BARRA15, AREA_DE_WORK.LD02.BARRA16, AREA_DE_WORK.LD02.BARRA17, AREA_DE_WORK.LD02.BARRA18, AREA_DE_WORK.LD02.BARRA19, AREA_DE_WORK.LD02.BARRA20, AREA_DE_WORK.LD02.BARRA21, AREA_DE_WORK.LD02.BARRA22, AREA_DE_WORK.LD02.BARRA23, AREA_DE_WORK.LD02.BARRA24, AREA_DE_WORK.LD02.BARRA25, AREA_DE_WORK.LD02.BARRA26, AREA_DE_WORK.LD02.BARRA27, AREA_DE_WORK.LD02.BARRA28, AREA_DE_WORK.LD02.BARRA29, AREA_DE_WORK.LD02.BARRA30, AREA_DE_WORK.LD02.BARRA31, AREA_DE_WORK.LD02.BARRA32, AREA_DE_WORK.LD02.BARRA33, AREA_DE_WORK.LD02.BARRA34, AREA_DE_WORK.LD02.BARRA35, AREA_DE_WORK.LD02.BARRA36, AREA_DE_WORK.LD02.BARRA37, AREA_DE_WORK.LD02.BARRA38, AREA_DE_WORK.LD02.BARRA39, AREA_DE_WORK.LD02.BARRA40, AREA_DE_WORK.LD02.BARRA41, AREA_DE_WORK.LD02.BARRA42, AREA_DE_WORK.LD02.BARRA43, AREA_DE_WORK.LD02.BARRA44, AREA_DE_WORK.LD02.BARRA45, AREA_DE_WORK.LD02.BARRA46, AREA_DE_WORK.LD02.BARRA47, AREA_DE_WORK.LD02.BARRA48, AREA_DE_WORK.LD02.BARRA49, AREA_DE_WORK.LD02.BARRA50, AREA_DE_WORK.LD02.BARRA51, AREA_DE_WORK.LD02.BARRA52, AREA_DE_WORK.LD02.BARRA53, AREA_DE_WORK.LD02.BARRA54, AREA_DE_WORK.LD02.BARRA55, AREA_DE_WORK.LD02.BARRA56);

            /*" -1468- MOVE LD02 TO REG-RLT2036B. */
            _.Move(AREA_DE_WORK.LD02, REG_RLT2036B);

            /*" -1470- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1472- PERFORM R6060-GRAVAR-ARQ-ETIQUETA. */

            R6060_GRAVAR_ARQ_ETIQUETA_SECTION();

            /*" -1474- ADD 1 TO WCONT-UF. */
            AREA_DE_WORK.WCONT_UF.Value = AREA_DE_WORK.WCONT_UF + 1;

            /*" -1474- ADD 1 TO WCONT-REG-GRAVADO. */
            AREA_DE_WORK.WCONT_REG_GRAVADO.Value = AREA_DE_WORK.WCONT_REG_GRAVADO + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6035_SAIDA*/

        [StopWatch]
        /*" R6036-IMPRIMIR-CODIGO-SECTION */
        private void R6036_IMPRIMIR_CODIGO_SECTION()
        {
            /*" -1484- MOVE '6036' TO WNR-EXEC-SQL. */
            _.Move("6036", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1486- ADD 1 TO WCONT-CODIGO. */
            AREA_DE_WORK.WCONT_CODIGO.Value = AREA_DE_WORK.WCONT_CODIGO + 1;

            /*" -1487- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1488- MOVE '%!' TO REG-RLT2036B. */
            _.Move("%!", REG_RLT2036B);

            /*" -1490- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1491- IF WCONT-CODIGO = 1 */

            if (AREA_DE_WORK.WCONT_CODIGO == 1)
            {

                /*" -1492- MOVE SPACES TO REG-RLT2036B */
                _.Move("", REG_RLT2036B);

                /*" -1494- MOVE '%%DocumentMedia: papel1 595 842 75 white normal' TO REG-RLT2036B */
                _.Move("%%DocumentMedia: papel1 595 842 75 white normal", REG_RLT2036B);

                /*" -1495- WRITE REG-RLT2036B */
                RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

                /*" -1496- MOVE SPACES TO REG-RLT2036B */
                _.Move("", REG_RLT2036B);

                /*" -1498- MOVE '%%+papel2 595 842 75 blue azul' TO REG-RLT2036B */
                _.Move("%%+papel2 595 842 75 blue azul", REG_RLT2036B);

                /*" -1500- WRITE REG-RLT2036B. */
                RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());
            }


            /*" -1501- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1502- MOVE '(|) SETDBSEP' TO REG-RLT2036B. */
            _.Move("(|) SETDBSEP", REG_RLT2036B);

            /*" -1504- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1505- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1506- MOVE '(lt01.dbm) STARTDBM' TO REG-RLT2036B. */
            _.Move("(lt01.dbm) STARTDBM", REG_RLT2036B);

            /*" -1508- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1509- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1510- MOVE 'ESTIPULANTE' TO LD01-ESTIPULANTE. */
            _.Move("ESTIPULANTE", AREA_DE_WORK.LD01.LD01_ESTIPULANTE);

            /*" -1511- MOVE 'CODCAIXA' TO LD01-CODCAIXA-X. */
            _.Move("CODCAIXA", AREA_DE_WORK.LD01.LD01_CODCAIXA_X);

            /*" -1512- MOVE 'APOLICE' TO LD01-APOLICE-X. */
            _.Move("APOLICE", AREA_DE_WORK.LD01.LD01_APOLICE_X);

            /*" -1513- MOVE 'AGENCIA' TO LD01-AGENCIA-X. */
            _.Move("AGENCIA", AREA_DE_WORK.LD01.LD01_AGENCIA_X);

            /*" -1514- MOVE 'OPER' TO LD01-OPER-X. */
            _.Move("OPER", AREA_DE_WORK.LD01.LD01_OPER_X);

            /*" -1515- MOVE 'CONTA' TO LD01-CONTA-X. */
            _.Move("CONTA", AREA_DE_WORK.LD01.LD01_CONTA_X);

            /*" -1516- MOVE 'RAZAOSOCIAL' TO LD01-RAZAO-SOCIAL. */
            _.Move("RAZAOSOCIAL", AREA_DE_WORK.LD01.LD01_RAZAO_SOCIAL);

            /*" -1517- MOVE 'CNPJ' TO LD01-CNPJ. */
            _.Move("CNPJ", AREA_DE_WORK.LD01.LD01_CNPJ);

            /*" -1518- MOVE 'ENDERECO' TO LD01-ENDERECO. */
            _.Move("ENDERECO", AREA_DE_WORK.LD01.LD01_ENDERECO);

            /*" -1519- MOVE 'BAIRRO' TO LD01-BAIRRO. */
            _.Move("BAIRRO", AREA_DE_WORK.LD01.LD01_BAIRRO);

            /*" -1520- MOVE 'CIDADE' TO LD01-CIDADE. */
            _.Move("CIDADE", AREA_DE_WORK.LD01.LD01_CIDADE);

            /*" -1521- MOVE 'UF' TO LD01-UF. */
            _.Move("UF", AREA_DE_WORK.LD01.LD01_UF);

            /*" -1522- MOVE 'CEP' TO LD01-CEP-X. */
            _.Move("CEP", AREA_DE_WORK.LD01.LD01_CEP_X);

            /*" -1523- MOVE 'DDD' TO LD01-DDD-X. */
            _.Move("DDD", AREA_DE_WORK.LD01.LD01_DDD_X);

            /*" -1524- MOVE 'TELEFONE' TO LD01-TELEFONE-X. */
            _.Move("TELEFONE", AREA_DE_WORK.LD01.LD01_TELEFONE_X);

            /*" -1525- MOVE 'EMAIL' TO LD01-E-MAIL. */
            _.Move("EMAIL", AREA_DE_WORK.LD01.LD01_E_MAIL);

            /*" -1526- MOVE 'FAX' TO LD01-FAX-X. */
            _.Move("FAX", AREA_DE_WORK.LD01.LD01_FAX_X);

            /*" -1527- MOVE 'ROUBO' TO LD01-ROUBO-X. */
            _.Move("ROUBO", AREA_DE_WORK.LD01.LD01_ROUBO_X);

            /*" -1528- MOVE 'INCENDIO' TO LD01-INCENDIO-X. */
            _.Move("INCENDIO", AREA_DE_WORK.LD01.LD01_INCENDIO_X);

            /*" -1529- MOVE 'DANOS' TO LD01-DANOS-X. */
            _.Move("DANOS", AREA_DE_WORK.LD01.LD01_DANOS_X);

            /*" -1530- MOVE 'ACIDENTES' TO LD01-ACIDENTES-X. */
            _.Move("ACIDENTES", AREA_DE_WORK.LD01.LD01_ACIDENTES_X);

            /*" -1531- MOVE 'DATAI' TO LD01-DATAI. */
            _.Move("DATAI", AREA_DE_WORK.LD01.LD01_DATAI);

            /*" -1532- MOVE 'DATAT' TO LD01-DATAT. */
            _.Move("DATAT", AREA_DE_WORK.LD01.LD01_DATAT);

            /*" -1533- MOVE 'LINHA1' TO LD01-LINHA01. */
            _.Move("LINHA1", AREA_DE_WORK.LD01.LD01_LINHA01);

            /*" -1534- MOVE 'LINHA2' TO LD01-LINHA02. */
            _.Move("LINHA2", AREA_DE_WORK.LD01.LD01_LINHA02);

            /*" -1535- MOVE 'LINHA3' TO LD01-LINHA03. */
            _.Move("LINHA3", AREA_DE_WORK.LD01.LD01_LINHA03);

            /*" -1536- MOVE 'LINHA4' TO LD01-LINHA04. */
            _.Move("LINHA4", AREA_DE_WORK.LD01.LD01_LINHA04);

            /*" -1537- MOVE 'LINHA5' TO LD01-LINHA05. */
            _.Move("LINHA5", AREA_DE_WORK.LD01.LD01_LINHA05);

            /*" -1538- MOVE 'LINHA6' TO LD01-LINHA06. */
            _.Move("LINHA6", AREA_DE_WORK.LD01.LD01_LINHA06);

            /*" -1539- MOVE 'LINHA7' TO LD01-LINHA07. */
            _.Move("LINHA7", AREA_DE_WORK.LD01.LD01_LINHA07);

            /*" -1540- MOVE 'LINHA8' TO LD01-LINHA08. */
            _.Move("LINHA8", AREA_DE_WORK.LD01.LD01_LINHA08);

            /*" -1541- MOVE 'LINHA9' TO LD01-LINHA09. */
            _.Move("LINHA9", AREA_DE_WORK.LD01.LD01_LINHA09);

            /*" -1542- MOVE 'LINHA10' TO LD01-LINHA10. */
            _.Move("LINHA10", AREA_DE_WORK.LD01.LD01_LINHA10);

            /*" -1543- MOVE 'PERCBONUS1' TO LD01-PERCBONUS1. */
            _.Move("PERCBONUS1", AREA_DE_WORK.LD01.LD01_PERCBONUS1);

            /*" -1544- MOVE 'PERCBONUS2' TO LD01-PERCBONUS2. */
            _.Move("PERCBONUS2", AREA_DE_WORK.LD01.LD01_PERCBONUS2);

            /*" -1545- MOVE 'PERCBONUS3' TO LD01-PERCBONUS3. */
            _.Move("PERCBONUS3", AREA_DE_WORK.LD01.LD01_PERCBONUS3);

            /*" -1546- MOVE 'PERCBONUS4' TO LD01-PERCBONUS4. */
            _.Move("PERCBONUS4", AREA_DE_WORK.LD01.LD01_PERCBONUS4);

            /*" -1547- MOVE 'PERCBONUS5' TO LD01-PERCBONUS5. */
            _.Move("PERCBONUS5", AREA_DE_WORK.LD01.LD01_PERCBONUS5);

            /*" -1548- MOVE 'PERCBONUS6' TO LD01-PERCBONUS6. */
            _.Move("PERCBONUS6", AREA_DE_WORK.LD01.LD01_PERCBONUS6);

            /*" -1549- MOVE 'PERCBONUS7' TO LD01-PERCBONUS7. */
            _.Move("PERCBONUS7", AREA_DE_WORK.LD01.LD01_PERCBONUS7);

            /*" -1550- MOVE 'PERCBONUS8' TO LD01-PERCBONUS8. */
            _.Move("PERCBONUS8", AREA_DE_WORK.LD01.LD01_PERCBONUS8);

            /*" -1551- MOVE 'PERCBONUS9' TO LD01-PERCBONUS9. */
            _.Move("PERCBONUS9", AREA_DE_WORK.LD01.LD01_PERCBONUS9);

            /*" -1552- MOVE 'PERCBONUS10' TO LD01-PERCBONUS10. */
            _.Move("PERCBONUS10", AREA_DE_WORK.LD01.LD01_PERCBONUS10);

            /*" -1553- MOVE 'OBS1' TO LD01-OBS1. */
            _.Move("OBS1", AREA_DE_WORK.LD01.LD01_OBS1);

            /*" -1554- MOVE 'OBS2' TO LD01-OBS2. */
            _.Move("OBS2", AREA_DE_WORK.LD01.LD01_OBS2);

            /*" -1555- MOVE 'OBS3' TO LD01-OBS3. */
            _.Move("OBS3", AREA_DE_WORK.LD01.LD01_OBS3);

            /*" -1556- MOVE 'OBS4' TO LD01-OBS4. */
            _.Move("OBS4", AREA_DE_WORK.LD01.LD01_OBS4);

            /*" -1557- MOVE 'OBS5' TO LD01-OBS5. */
            _.Move("OBS5", AREA_DE_WORK.LD01.LD01_OBS5);

            /*" -1558- MOVE 'OBS6' TO LD01-OBS6. */
            _.Move("OBS6", AREA_DE_WORK.LD01.LD01_OBS6);

            /*" -1559- MOVE 'OBS7' TO LD01-OBS7. */
            _.Move("OBS7", AREA_DE_WORK.LD01.LD01_OBS7);

            /*" -1560- MOVE 'OBS8' TO LD01-OBS8. */
            _.Move("OBS8", AREA_DE_WORK.LD01.LD01_OBS8);

            /*" -1561- MOVE 'OBS9' TO LD01-OBS9. */
            _.Move("OBS9", AREA_DE_WORK.LD01.LD01_OBS9);

            /*" -1562- MOVE 'OBS10' TO LD01-OBS10. */
            _.Move("OBS10", AREA_DE_WORK.LD01.LD01_OBS10);

            /*" -1563- MOVE 'OBS11' TO LD01-OBS11. */
            _.Move("OBS11", AREA_DE_WORK.LD01.LD01_OBS11);

            /*" -1564- MOVE 'CORRETORA' TO LD01-CORRETORA. */
            _.Move("CORRETORA", AREA_DE_WORK.LD01.LD01_CORRETORA);

            /*" -1565- MOVE 'SUSEP' TO LD01-SUSEP. */
            _.Move("SUSEP", AREA_DE_WORK.LD01.LD01_SUSEP);

            /*" -1566- MOVE 'CENTRAL' TO LD01-CENTRAL. */
            _.Move("CENTRAL", AREA_DE_WORK.LD01.LD01_CENTRAL);

            /*" -1567- MOVE LD01 TO REG-RLT2036B. */
            _.Move(AREA_DE_WORK.LD01, REG_RLT2036B);

            /*" -1567- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6036_SAIDA*/

        [StopWatch]
        /*" R6037-IMPRIMIR-UF-SECTION */
        private void R6037_IMPRIMIR_UF_SECTION()
        {
            /*" -1576- MOVE '6037' TO WNR-EXEC-SQL. */
            _.Move("6037", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1577- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1578- MOVE '%%EOF' TO REG-RLT2036B. */
            _.Move("%%EOF", REG_RLT2036B);

            /*" -1580- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1581- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1582- MOVE '%!' TO REG-RLT2036B. */
            _.Move("%!", REG_RLT2036B);

            /*" -1584- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1585- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1587- MOVE '<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>setpagedevice' TO REG-RLT2036B. */
            _.Move("<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>setpagedevice", REG_RLT2036B);

            /*" -1589- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1590- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1591- MOVE '(portrait.jdt) STARTLM' TO REG-RLT2036B. */
            _.Move("(portrait.jdt) STARTLM", REG_RLT2036B);

            /*" -1593- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1594- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1595- MOVE ' FOLHA SEPARADORA' TO REG-RLT2036B. */
            _.Move(" FOLHA SEPARADORA", REG_RLT2036B);

            /*" -1597- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1598- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1599- MOVE ' UNIDADE DE FEDERACAO IMPRESSA' TO REG-RLT2036B. */
            _.Move(" UNIDADE DE FEDERACAO IMPRESSA", REG_RLT2036B);

            /*" -1601- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1602- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1603- MOVE SPACES TO LD02. */
            _.Move("", AREA_DE_WORK.LD02);

            /*" -1604- MOVE SPACES TO LD02-ESTIPULANTE. */
            _.Move("", AREA_DE_WORK.LD02.LD02_ESTIPULANTE);

            /*" -1605- MOVE W-UF-ANT TO LD02-CODCAIXA-X. */
            _.Move(W_UF_ANT, AREA_DE_WORK.LD02.LD02_CODCAIXA_X);

            /*" -1606- MOVE LD02 TO REG-RLT2036B. */
            _.Move(AREA_DE_WORK.LD02, REG_RLT2036B);

            /*" -1608- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1609- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1610- MOVE ' TOTAL CERTIFICADOS DA UF' TO REG-RLT2036B. */
            _.Move(" TOTAL CERTIFICADOS DA UF", REG_RLT2036B);

            /*" -1612- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1613- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1614- MOVE WCONT-UF TO REG-RLT2036B. */
            _.Move(AREA_DE_WORK.WCONT_UF, REG_RLT2036B);

            /*" -1616- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1617- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1618- MOVE '%%EOF' TO REG-RLT2036B. */
            _.Move("%%EOF", REG_RLT2036B);

            /*" -1620- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1620- MOVE ZEROS TO WCONT-UF. */
            _.Move(0, AREA_DE_WORK.WCONT_UF);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6037_SAIDA*/

        [StopWatch]
        /*" R6038-IMPRIMIR-FINAL-SECTION */
        private void R6038_IMPRIMIR_FINAL_SECTION()
        {
            /*" -1629- MOVE '6038' TO WNR-EXEC-SQL. */
            _.Move("6038", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1630- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1631- MOVE '%%EOF' TO REG-RLT2036B. */
            _.Move("%%EOF", REG_RLT2036B);

            /*" -1633- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1634- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1635- MOVE '%!' TO REG-RLT2036B. */
            _.Move("%!", REG_RLT2036B);

            /*" -1637- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1638- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1640- MOVE '<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>setpagedevice' TO REG-RLT2036B. */
            _.Move("<</MediaColor (blue) /MediaWeight 75/MediaType(azul)>>setpagedevice", REG_RLT2036B);

            /*" -1642- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1643- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1644- MOVE '(portrait.jdt) STARTLM' TO REG-RLT2036B. */
            _.Move("(portrait.jdt) STARTLM", REG_RLT2036B);

            /*" -1646- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1647- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1648- MOVE ' FOLHA SEPARADORA' TO REG-RLT2036B. */
            _.Move(" FOLHA SEPARADORA", REG_RLT2036B);

            /*" -1650- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1651- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1652- MOVE ' UNIDADE DE FEDERACAO IMPRESSA' TO REG-RLT2036B. */
            _.Move(" UNIDADE DE FEDERACAO IMPRESSA", REG_RLT2036B);

            /*" -1654- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1655- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1656- MOVE SPACES TO LD02. */
            _.Move("", AREA_DE_WORK.LD02);

            /*" -1657- MOVE SPACES TO LD02-ESTIPULANTE. */
            _.Move("", AREA_DE_WORK.LD02.LD02_ESTIPULANTE);

            /*" -1658- MOVE W-UF-ANT TO LD02-CODCAIXA-X. */
            _.Move(W_UF_ANT, AREA_DE_WORK.LD02.LD02_CODCAIXA_X);

            /*" -1659- MOVE LD02 TO REG-RLT2036B. */
            _.Move(AREA_DE_WORK.LD02, REG_RLT2036B);

            /*" -1661- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1662- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1663- MOVE ' TOTAL CERTIFICADOS DA UF' TO REG-RLT2036B. */
            _.Move(" TOTAL CERTIFICADOS DA UF", REG_RLT2036B);

            /*" -1665- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1666- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1667- MOVE WCONT-UF TO REG-RLT2036B. */
            _.Move(AREA_DE_WORK.WCONT_UF, REG_RLT2036B);

            /*" -1669- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1670- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1671- MOVE ' TOTAL DE CERTIFICADOS IMPRESSOS' TO REG-RLT2036B. */
            _.Move(" TOTAL DE CERTIFICADOS IMPRESSOS", REG_RLT2036B);

            /*" -1673- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1674- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1675- MOVE WCONT-REG-GRAVADO TO REG-RLT2036B. */
            _.Move(AREA_DE_WORK.WCONT_REG_GRAVADO, REG_RLT2036B);

            /*" -1677- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

            /*" -1678- MOVE SPACES TO REG-RLT2036B. */
            _.Move("", REG_RLT2036B);

            /*" -1679- MOVE '%%EOF' TO REG-RLT2036B. */
            _.Move("%%EOF", REG_RLT2036B);

            /*" -1679- WRITE REG-RLT2036B. */
            RLT2036B.Write(REG_RLT2036B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6038_SAIDA*/

        [StopWatch]
        /*" R6060-GRAVAR-ARQ-ETIQUETA-SECTION */
        private void R6060_GRAVAR_ARQ_ETIQUETA_SECTION()
        {
            /*" -1688- MOVE '6060' TO WNR-EXEC-SQL. */
            _.Move("6060", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1689- MOVE SORT-CODCAIXA TO CAD-COD-FENAL. */
            _.Move(REG_SORT.SORT_CODCAIXA_X.SORT_CODCAIXA, REG_MOV2036B.CAD_COD_FENAL);

            /*" -1690- MOVE SORT-CODCAIXA TO CAD-CODIGO. */
            _.Move(REG_SORT.SORT_CODCAIXA_X.SORT_CODCAIXA, REG_MOV2036B.CAD_CODIGO);

            /*" -1691- MOVE SPACES TO CAD-EN. */
            _.Move("", REG_MOV2036B.CAD_EN);

            /*" -1692- MOVE SORT-RAZAO-SOCIAL TO CAD-RAZAO-SOC. */
            _.Move(REG_SORT.SORT_RAZAO_SOCIAL, REG_MOV2036B.CAD_RAZAO_SOC);

            /*" -1694- MOVE SORT-ENDERECO TO CAD-ENDERECO. */
            _.Move(REG_SORT.SORT_ENDERECO, REG_MOV2036B.CAD_ENDERECO);

            /*" -1695- MOVE SORT-BAIRRO TO CAD-BAIRRO. */
            _.Move(REG_SORT.SORT_BAIRRO, REG_MOV2036B.CAD_BAIRRO);

            /*" -1696- MOVE SORT-CIDADE TO CAD-CIDADE. */
            _.Move(REG_SORT.SORT_CIDADE, REG_MOV2036B.CAD_CIDADE);

            /*" -1698- MOVE SORT-UF TO CAD-UF. */
            _.Move(REG_SORT.SORT_UF, REG_MOV2036B.CAD_UF);

            /*" -1699- MOVE SORT-CEP-X TO CAD-CEP. */
            _.Move(REG_SORT.SORT_CEP_X, REG_MOV2036B.CAD_CEP);

            /*" -1700- MOVE SORT-DDD-X TO CAD-DDD. */
            _.Move(REG_SORT.SORT_DDD_X, REG_MOV2036B.CAD_DDD);

            /*" -1701- MOVE SORT-TELEFONE-X TO CAD-TELEFONE. */
            _.Move(REG_SORT.SORT_TELEFONE_X, REG_MOV2036B.CAD_TELEFONE);

            /*" -1702- MOVE SORT-FAX-X TO CAD-FAX. */
            _.Move(REG_SORT.SORT_FAX_X, REG_MOV2036B.CAD_FAX);

            /*" -1702- WRITE REG-MOV2036B. */
            MOV2036B.Write(REG_MOV2036B.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6060_SAIDA*/

        [StopWatch]
        /*" R7010-COMMIT-WORK-SECTION */
        private void R7010_COMMIT_WORK_SECTION()
        {
            /*" -1711- MOVE '7010' TO WNR-EXEC-SQL. */
            _.Move("7010", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1711- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -1714- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1715- DISPLAY 'ERRO COMMIT WORK .............................' */
                _.Display($"ERRO COMMIT WORK .............................");

                /*" -1715- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7010_SAIDA*/

        [StopWatch]
        /*" R7020-ROLLBACK-SECTION */
        private void R7020_ROLLBACK_SECTION()
        {
            /*" -1725- MOVE '7020' TO WNR-EXEC-SQL. */
            _.Move("7020", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1725- EXEC SQL ROLLBACK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1728- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1729- DISPLAY 'R7020 - ERRO ROLLBACK ' */
                _.Display($"R7020 - ERRO ROLLBACK ");

                /*" -1729- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R7020_SAIDA*/

        [StopWatch]
        /*" R8000-00-INCLUIR-RELATORIO-SECTION */
        private void R8000_00_INCLUIR_RELATORIO_SECTION()
        {
            /*" -1747- MOVE 'R8000' TO WNR-EXEC-SQL. */
            _.Move("R8000", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1748- IF V0SIST-DTMOVABE NOT EQUAL '2007-08-27' */

            if (V0SIST_DTMOVABE != "2007-08-27")
            {

                /*" -1751- GO TO R8000-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1752- MOVE 180044257 TO V0RELA-CODPDT */
            _.Move(180044257, V0RELA_CODPDT);

            /*" -1753- MOVE 101800046018 TO V0RELA-NUM-APOLICE */
            _.Move(101800046018, V0RELA_NUM_APOLICE);

            /*" -1755- PERFORM R8901-00-INSERT-RELATORIO . */

            R8901_00_INSERT_RELATORIO_SECTION();

            /*" -1756- MOVE 180044257 TO V0RELA-CODPDT */
            _.Move(180044257, V0RELA_CODPDT);

            /*" -1757- MOVE 101800054071 TO V0RELA-NUM-APOLICE */
            _.Move(101800054071, V0RELA_NUM_APOLICE);

            /*" -1759- PERFORM R8901-00-INSERT-RELATORIO . */

            R8901_00_INSERT_RELATORIO_SECTION();

            /*" -1762- GO TO R8000-99-SAIDA. */
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/ //GOTO
            return;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8000_99_SAIDA*/

        [StopWatch]
        /*" R8901-00-INSERT-RELATORIO-SECTION */
        private void R8901_00_INSERT_RELATORIO_SECTION()
        {
            /*" -1796- MOVE 'R8901' TO WNR-EXEC-SQL. */
            _.Move("R8901", AREA_DE_WORK.WABEND.WNR_EXEC_SQL);

            /*" -1797- MOVE 'LT2036B' TO V0RELA-CODUSU */
            _.Move("LT2036B", V0RELA_CODUSU);

            /*" -1798- MOVE V0SIST-DTMOVABE TO V0RELA-DATA-SOLICITACAO */
            _.Move(V0SIST_DTMOVABE, V0RELA_DATA_SOLICITACAO);

            /*" -1799- MOVE 'LT' TO V0RELA-IDSISTEM */
            _.Move("LT", V0RELA_IDSISTEM);

            /*" -1800- MOVE 'LT2036B1' TO V0RELA-CODRELAT */
            _.Move("LT2036B1", V0RELA_CODRELAT);

            /*" -1801- MOVE ZEROS TO V0RELA-NRCOPIAS */
            _.Move(0, V0RELA_NRCOPIAS);

            /*" -1802- MOVE 0 TO V0RELA-QUANTIDADE */
            _.Move(0, V0RELA_QUANTIDADE);

            /*" -1803- MOVE V0SIST-DTMOVABE TO V0RELA-PERI-INICIAL */
            _.Move(V0SIST_DTMOVABE, V0RELA_PERI_INICIAL);

            /*" -1804- MOVE V0SIST-DTMOVABE TO V0RELA-PERI-FINAL */
            _.Move(V0SIST_DTMOVABE, V0RELA_PERI_FINAL);

            /*" -1805- MOVE V0SIST-DTMOVABE TO V0RELA-DATA-REFERENCIA */
            _.Move(V0SIST_DTMOVABE, V0RELA_DATA_REFERENCIA);

            /*" -1806- MOVE ZEROS TO V0RELA-MES-REFERENCIA */
            _.Move(0, V0RELA_MES_REFERENCIA);

            /*" -1807- MOVE ZEROS TO V0RELA-ANO-REFERENCIA */
            _.Move(0, V0RELA_ANO_REFERENCIA);

            /*" -1808- MOVE ZEROS TO V0RELA-ORGAO */
            _.Move(0, V0RELA_ORGAO);

            /*" -1810- MOVE ZEROS TO V0RELA-FONTE */
            _.Move(0, V0RELA_FONTE);

            /*" -1811- MOVE ZEROS TO V0RELA-RAMO */
            _.Move(0, V0RELA_RAMO);

            /*" -1812- MOVE ZEROS TO V0RELA-MODALIDA */
            _.Move(0, V0RELA_MODALIDA);

            /*" -1814- MOVE ZEROS TO V0RELA-CONGENER */
            _.Move(0, V0RELA_CONGENER);

            /*" -1815- MOVE ZEROS TO V0RELA-NRENDOS */
            _.Move(0, V0RELA_NRENDOS);

            /*" -1816- MOVE ZEROS TO V0RELA-NRPARCEL */
            _.Move(0, V0RELA_NRPARCEL);

            /*" -1817- MOVE ZEROS TO V0RELA-NRCERTIF */
            _.Move(0, V0RELA_NRCERTIF);

            /*" -1818- MOVE ZEROS TO V0RELA-NRTIT */
            _.Move(0, V0RELA_NRTIT);

            /*" -1819- MOVE ZEROS TO V0RELA-CODSUBES */
            _.Move(0, V0RELA_CODSUBES);

            /*" -1820- MOVE ZEROS TO V0RELA-OPERACAO */
            _.Move(0, V0RELA_OPERACAO);

            /*" -1821- MOVE ZEROS TO V0RELA-COD-PLANO */
            _.Move(0, V0RELA_COD_PLANO);

            /*" -1822- MOVE ZEROS TO V0RELA-OCORHIST */
            _.Move(0, V0RELA_OCORHIST);

            /*" -1823- MOVE ' ' TO V0RELA-APOLIDER */
            _.Move(" ", V0RELA_APOLIDER);

            /*" -1824- MOVE ' ' TO V0RELA-ENDOSLID */
            _.Move(" ", V0RELA_ENDOSLID);

            /*" -1825- MOVE ZEROS TO V0RELA-NUM-PARC-LIDER */
            _.Move(0, V0RELA_NUM_PARC_LIDER);

            /*" -1826- MOVE ZEROS TO V0RELA-NUM-SINISTRO */
            _.Move(0, V0RELA_NUM_SINISTRO);

            /*" -1827- MOVE ' ' TO V0RELA-NUM-SINI-LIDER */
            _.Move(" ", V0RELA_NUM_SINI_LIDER);

            /*" -1828- MOVE ZEROS TO V0RELA-NUM-ORDEM */
            _.Move(0, V0RELA_NUM_ORDEM);

            /*" -1829- MOVE ZEROS TO V0RELA-CODUNIMO */
            _.Move(0, V0RELA_CODUNIMO);

            /*" -1830- MOVE ' ' TO V0RELA-CORRECAO */
            _.Move(" ", V0RELA_CORRECAO);

            /*" -1831- MOVE ' ' TO V0RELA-SITUACAO */
            _.Move(" ", V0RELA_SITUACAO);

            /*" -1832- MOVE ' ' TO V0RELA-PREVIA-DEFINITIVA */
            _.Move(" ", V0RELA_PREVIA_DEFINITIVA);

            /*" -1833- MOVE ' ' TO V0RELA-ANAL-RESUMO */
            _.Move(" ", V0RELA_ANAL_RESUMO);

            /*" -1834- MOVE 0 TO V0RELA-COD-EMPRESA */
            _.Move(0, V0RELA_COD_EMPRESA);

            /*" -1835- MOVE ZEROS TO V0RELA-PERI-RENOVACAO */
            _.Move(0, V0RELA_PERI_RENOVACAO);

            /*" -1837- MOVE ZEROS TO V0RELA-PCT-AUMENTO. */
            _.Move(0, V0RELA_PCT_AUMENTO);

            /*" -1880- PERFORM R8901_00_INSERT_RELATORIO_DB_INSERT_1 */

            R8901_00_INSERT_RELATORIO_DB_INSERT_1();

            /*" -1883- IF SQLCODE EQUAL -803 */

            if (DB.SQLCODE == -803)
            {

                /*" -1884- DISPLAY 'R8901- REGISTRO DUPLICADO    ' */
                _.Display($"R8901- REGISTRO DUPLICADO    ");

                /*" -1886- GO TO R8901-99-SAIDA . */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R8901_99_SAIDA*/ //GOTO
                return;
            }


            /*" -1887- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1888- DISPLAY 'R8901- PROBLEMAS INSERT V0RELATORIOS ' */
                _.Display($"R8901- PROBLEMAS INSERT V0RELATORIOS ");

                /*" -1890- GO TO R9999-00-ROT-ERRO . */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1893- DISPLAY 'R8901-' V0RELA-CODPDT ' / ' V0RELA-NUM-APOLICE ' / ' V0RELA-NRENDOS ' INSERT V0RELATORIO COM SUCESSO ' . */

            $"R8901-{V0RELA_CODPDT} / {V0RELA_NUM_APOLICE} / {V0RELA_NRENDOS} INSERT V0RELATORIO COM SUCESSO "
            .Display();

        }

        [StopWatch]
        /*" R8901-00-INSERT-RELATORIO-DB-INSERT-1 */
        public void R8901_00_INSERT_RELATORIO_DB_INSERT_1()
        {
            /*" -1880- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELA-CODUSU, :V0RELA-DATA-SOLICITACAO, :V0RELA-IDSISTEM, :V0RELA-CODRELAT, :V0RELA-NRCOPIAS, :V0RELA-QUANTIDADE, :V0RELA-PERI-INICIAL, :V0RELA-PERI-FINAL, :V0RELA-DATA-REFERENCIA, :V0RELA-MES-REFERENCIA, :V0RELA-ANO-REFERENCIA, :V0RELA-ORGAO, :V0RELA-FONTE, :V0RELA-CODPDT, :V0RELA-RAMO, :V0RELA-MODALIDA, :V0RELA-CONGENER, :V0RELA-NUM-APOLICE, :V0RELA-NRENDOS, :V0RELA-NRPARCEL, :V0RELA-NRCERTIF, :V0RELA-NRTIT, :V0RELA-CODSUBES, :V0RELA-OPERACAO, :V0RELA-COD-PLANO, :V0RELA-OCORHIST, :V0RELA-APOLIDER, :V0RELA-ENDOSLID, :V0RELA-NUM-PARC-LIDER, :V0RELA-NUM-SINISTRO, :V0RELA-NUM-SINI-LIDER, :V0RELA-NUM-ORDEM, :V0RELA-CODUNIMO, :V0RELA-CORRECAO, :V0RELA-SITUACAO, :V0RELA-PREVIA-DEFINITIVA, :V0RELA-ANAL-RESUMO, :V0RELA-COD-EMPRESA, :V0RELA-PERI-RENOVACAO, :V0RELA-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var r8901_00_INSERT_RELATORIO_DB_INSERT_1_Insert1 = new R8901_00_INSERT_RELATORIO_DB_INSERT_1_Insert1()
            {
                V0RELA_CODUSU = V0RELA_CODUSU.ToString(),
                V0RELA_DATA_SOLICITACAO = V0RELA_DATA_SOLICITACAO.ToString(),
                V0RELA_IDSISTEM = V0RELA_IDSISTEM.ToString(),
                V0RELA_CODRELAT = V0RELA_CODRELAT.ToString(),
                V0RELA_NRCOPIAS = V0RELA_NRCOPIAS.ToString(),
                V0RELA_QUANTIDADE = V0RELA_QUANTIDADE.ToString(),
                V0RELA_PERI_INICIAL = V0RELA_PERI_INICIAL.ToString(),
                V0RELA_PERI_FINAL = V0RELA_PERI_FINAL.ToString(),
                V0RELA_DATA_REFERENCIA = V0RELA_DATA_REFERENCIA.ToString(),
                V0RELA_MES_REFERENCIA = V0RELA_MES_REFERENCIA.ToString(),
                V0RELA_ANO_REFERENCIA = V0RELA_ANO_REFERENCIA.ToString(),
                V0RELA_ORGAO = V0RELA_ORGAO.ToString(),
                V0RELA_FONTE = V0RELA_FONTE.ToString(),
                V0RELA_CODPDT = V0RELA_CODPDT.ToString(),
                V0RELA_RAMO = V0RELA_RAMO.ToString(),
                V0RELA_MODALIDA = V0RELA_MODALIDA.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
                V0RELA_NUM_APOLICE = V0RELA_NUM_APOLICE.ToString(),
                V0RELA_NRENDOS = V0RELA_NRENDOS.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
                V0RELA_NRCERTIF = V0RELA_NRCERTIF.ToString(),
                V0RELA_NRTIT = V0RELA_NRTIT.ToString(),
                V0RELA_CODSUBES = V0RELA_CODSUBES.ToString(),
                V0RELA_OPERACAO = V0RELA_OPERACAO.ToString(),
                V0RELA_COD_PLANO = V0RELA_COD_PLANO.ToString(),
                V0RELA_OCORHIST = V0RELA_OCORHIST.ToString(),
                V0RELA_APOLIDER = V0RELA_APOLIDER.ToString(),
                V0RELA_ENDOSLID = V0RELA_ENDOSLID.ToString(),
                V0RELA_NUM_PARC_LIDER = V0RELA_NUM_PARC_LIDER.ToString(),
                V0RELA_NUM_SINISTRO = V0RELA_NUM_SINISTRO.ToString(),
                V0RELA_NUM_SINI_LIDER = V0RELA_NUM_SINI_LIDER.ToString(),
                V0RELA_NUM_ORDEM = V0RELA_NUM_ORDEM.ToString(),
                V0RELA_CODUNIMO = V0RELA_CODUNIMO.ToString(),
                V0RELA_CORRECAO = V0RELA_CORRECAO.ToString(),
                V0RELA_SITUACAO = V0RELA_SITUACAO.ToString(),
                V0RELA_PREVIA_DEFINITIVA = V0RELA_PREVIA_DEFINITIVA.ToString(),
                V0RELA_ANAL_RESUMO = V0RELA_ANAL_RESUMO.ToString(),
                V0RELA_COD_EMPRESA = V0RELA_COD_EMPRESA.ToString(),
                V0RELA_PERI_RENOVACAO = V0RELA_PERI_RENOVACAO.ToString(),
                V0RELA_PCT_AUMENTO = V0RELA_PCT_AUMENTO.ToString(),
            };

            R8901_00_INSERT_RELATORIO_DB_INSERT_1_Insert1.Execute(r8901_00_INSERT_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8901_99_SAIDA*/

        [StopWatch]
        /*" R8999-OPEN-ARQUIVOS-SECTION */
        private void R8999_OPEN_ARQUIVOS_SECTION()
        {
            /*" -1902- OPEN OUTPUT RLT2036B MOV2036B. */
            RLT2036B.Open(REG_RLT2036B);
            MOV2036B.Open(REG_MOV2036B);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R8999_SAIDA*/

        [StopWatch]
        /*" R9000-CLOSE-ARQUIVOS-SECTION */
        private void R9000_CLOSE_ARQUIVOS_SECTION()
        {
            /*" -1910- CLOSE RLT2036B MOV2036B. */
            RLT2036B.Close();
            MOV2036B.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1921- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, AREA_DE_WORK.WABEND.WSQLCODE);

            /*" -1923- DISPLAY WABEND */
            _.Display(AREA_DE_WORK.WABEND);

            /*" -1925- PERFORM R9000-CLOSE-ARQUIVOS */

            R9000_CLOSE_ARQUIVOS_SECTION();

            /*" -1925- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -1927- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1931- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1931- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_SAIDA*/
    }
}