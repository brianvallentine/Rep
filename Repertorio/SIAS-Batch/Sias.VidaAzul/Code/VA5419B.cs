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
using Sias.VidaAzul.DB2.VA5419B;

namespace Code
{
    public class VA5419B
    {
        public bool IsCall { get; set; }

        public VA5419B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *                    OBJETIVO DO PROGRAMA                        *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      * EMITE RELATORIO DE REPASSE DE SAF E ARQUIVO MOVIMENTO PARA A   *      */
        /*"      * SUL AMERICA SEGUROS.                                           *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *   VERSAO   *    DATA    *    AUTOR     *       HISTORICO       *      */
        /*"      *     01     *  22/11/1999*  FREDERICO   *                       *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RVA5419B { get; set; } = new FileBasis(new PIC("X", "132", "X(132)"));

        public FileBasis RVA5419B
        {
            get
            {
                _.Move(REG_IMPRESSAO, _RVA5419B); VarBasis.RedefinePassValue(REG_IMPRESSAO, _RVA5419B, REG_IMPRESSAO); return _RVA5419B;
            }
        }
        public FileBasis _FUND001I { get; set; } = new FileBasis(new PIC("X", "231", "X(231)"));

        public FileBasis FUND001I
        {
            get
            {
                _.Move(REG_FUND001I, _FUND001I); VarBasis.RedefinePassValue(REG_FUND001I, _FUND001I, REG_FUND001I); return _FUND001I;
            }
        }
        public FileBasis _FUND001C { get; set; } = new FileBasis(new PIC("X", "231", "X(231)"));

        public FileBasis FUND001C
        {
            get
            {
                _.Move(REG_FUND001C, _FUND001C); VarBasis.RedefinePassValue(REG_FUND001C, _FUND001C, REG_FUND001C); return _FUND001C;
            }
        }
        public FileBasis _FUND001R { get; set; } = new FileBasis(new PIC("X", "231", "X(231)"));

        public FileBasis FUND001R
        {
            get
            {
                _.Move(REG_FUND001R, _FUND001R); VarBasis.RedefinePassValue(REG_FUND001R, _FUND001R, REG_FUND001R); return _FUND001R;
            }
        }
        public FileBasis _FUND001A { get; set; } = new FileBasis(new PIC("X", "231", "X(231)"));

        public FileBasis FUND001A
        {
            get
            {
                _.Move(REG_FUND001A, _FUND001A); VarBasis.RedefinePassValue(REG_FUND001A, _FUND001A, REG_FUND001A); return _FUND001A;
            }
        }
        /*"01            REG-IMPRESSAO       PIC X(132).*/
        public StringBasis REG_IMPRESSAO { get; set; } = new StringBasis(new PIC("X", "132", "X(132)."), @"");
        /*"01            REG-FUND001I        PIC X(231).*/
        public StringBasis REG_FUND001I { get; set; } = new StringBasis(new PIC("X", "231", "X(231)."), @"");
        /*"01            REG-FUND001C        PIC X(231).*/
        public StringBasis REG_FUND001C { get; set; } = new StringBasis(new PIC("X", "231", "X(231)."), @"");
        /*"01            REG-FUND001R        PIC X(231).*/
        public StringBasis REG_FUND001R { get; set; } = new StringBasis(new PIC("X", "231", "X(231)."), @"");
        /*"01            REG-FUND001A        PIC X(231).*/
        public StringBasis REG_FUND001A { get; set; } = new StringBasis(new PIC("X", "231", "X(231)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77            VIND-DTREF          PIC S9(04) COMP VALUE +0.*/
        public IntBasis VIND_DTREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-DTMOVTO1       PIC S9(04) COMP VALUE +0.*/
        public IntBasis VIND_DTMOVTO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-DTMOVTO        PIC S9(04) COMP.*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-AGECTADEB      PIC S9(04) COMP.*/
        public IntBasis VIND_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-OPRCTADEB      PIC S9(04) COMP.*/
        public IntBasis VIND_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-NUMCTADEB      PIC S9(04) COMP.*/
        public IntBasis VIND_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            VIND-DIGCTADEB      PIC S9(04) COMP.*/
        public IntBasis VIND_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-CODCLIEN      PIC S9(09) COMP.*/
        public IntBasis WHOST_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            WHOST-NRCERTIF      PIC S9(15) COMP-3.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            WHOST-NRPARCEL      PIC S9(04) COMP.*/
        public IntBasis WHOST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-CODOPER       PIC S9(04) COMP.*/
        public IntBasis WHOST_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            WHOST-NLMSAF        PIC S9(09) COMP VALUE +0.*/
        public IntBasis WHOST_NLMSAF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            WHOST-DTINICIAL     PIC  X(10).*/
        public StringBasis WHOST_DTINICIAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTFINAL       PIC  X(10).*/
        public StringBasis WHOST_DTFINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTREF1        PIC  X(10).*/
        public StringBasis WHOST_DTREF1 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTREF         PIC  X(10).*/
        public StringBasis WHOST_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-DTREFANT      PIC  X(10).*/
        public StringBasis WHOST_DTREFANT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            WHOST-QTVIDAS       PIC S9(09) COMP.*/
        public IntBasis WHOST_QTVIDAS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            WHOST-VLCUSTAUXF    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis WHOST_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"77            V1SIST-DTMOVABEANT-I PIC S9(04) COMP.*/
        public IntBasis V1SIST_DTMOVABEANT_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V1SIST-DTMOVABE-I    PIC S9(04) COMP.*/
        public IntBasis V1SIST_DTMOVABE_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V1SIST-DTMOVABEANT   PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABEANT { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTMOVABE      PIC  X(10).*/
        public StringBasis V1SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V1SIST-DTHOJE        PIC  X(10).*/
        public StringBasis V1SIST_DTHOJE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0RELA-DTREFERENCIA  PIC  X(10).*/
        public StringBasis V0RELA_DTREFERENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0RSAF-CODCLIEN     PIC S9(09) COMP.*/
        public IntBasis V0RSAF_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0RSAF-CODCLIEN-SUB PIC S9(09) COMP.*/
        public IntBasis V0RSAF_CODCLIEN_SUB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0RSAF-CODCLIEN-ANT PIC S9(09) COMP.*/
        public IntBasis V0RSAF_CODCLIEN_ANT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0RSAF-DTREF        PIC  X(10).*/
        public StringBasis V0RSAF_DTREF { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0RSAF-NUM-APOLICE  PIC S9(13) COMP-3.*/
        public IntBasis V0RSAF_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0RSAF-CODSUBES     PIC S9(04) COMP.*/
        public IntBasis V0RSAF_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0RSAF-NUM-APOLANT  PIC S9(13) COMP-3.*/
        public IntBasis V0RSAF_NUM_APOLANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0RSAF-CODSUBESANT  PIC S9(04) COMP.*/
        public IntBasis V0RSAF_CODSUBESANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0RSAF-NRCERTIF     PIC S9(15) COMP-3.*/
        public IntBasis V0RSAF_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0RSAF-NRPARCEL     PIC S9(04) COMP.*/
        public IntBasis V0RSAF_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0RSAF-NRMATRFUN    PIC S9(15) COMP-3.*/
        public IntBasis V0RSAF_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0RSAF-VLCUSTAUXF   PIC S9(09)V99 COMP-3.*/
        public DoubleBasis V0RSAF_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V99"), 2);
        /*"77            V0RSAF-CODOPER      PIC S9(04) COMP.*/
        public IntBasis V0RSAF_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0RSAF-DTQITBCO     PIC  X(10).*/
        public StringBasis V0RSAF_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0RSAF-DTMOVTO      PIC  X(10).*/
        public StringBasis V0RSAF_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0RSAF1-NLMSAF      PIC S9(09) COMP.*/
        public IntBasis V0RSAF1_NLMSAF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0RSAF1-VLCUSTAUXF  PIC S9(09)V99 COMP-3.*/
        public DoubleBasis V0RSAF1_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "9", "S9(09)V99"), 2);
        /*"77            V0SAFC-DTINIVIG     PIC  X(10).*/
        public StringBasis V0SAFC_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0PROD-NRMSAF       PIC S9(04) COMP.*/
        public IntBasis V0PROD_NRMSAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0PROD-NLMSAF       PIC S9(09) COMP.*/
        public IntBasis V0PROD_NLMSAF { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"77            V0SEGV-APOLICE      PIC S9(13) COMP-3.*/
        public IntBasis V0SEGV_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"77            V0SEGV-SUBGRUPO     PIC S9(04) COMP.*/
        public IntBasis V0SEGV_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0CLIE-NOME         PIC  X(40).*/
        public StringBasis V0CLIE_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0CLIE-CGCCPF       PIC S9(15) COMP-3.*/
        public IntBasis V0CLIE_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"77            V0ENDO-DTEMIS       PIC  X(10).*/
        public StringBasis V0ENDO_DTEMIS { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"77            V0ENDO-RAMO         PIC S9(04) COMP.*/
        public IntBasis V0ENDO_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"77            V0ENDE-ENDERECO     PIC  X(40).*/
        public StringBasis V0ENDE_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
        /*"77            V0ENDE-BAIRRO       PIC  X(20).*/
        public StringBasis V0ENDE_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"77            V0ENDE-CIDADE       PIC  X(20).*/
        public StringBasis V0ENDE_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(20)."), @"");
        /*"77            V0ENDE-UF           PIC  X(02).*/
        public StringBasis V0ENDE_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(02)."), @"");
        /*"77            V0ENDE-CEP          PIC S9(09) COMP.*/
        public IntBasis V0ENDE_CEP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  WORK-AREA.*/
        public VA5419B_WORK_AREA WORK_AREA { get; set; } = new VA5419B_WORK_AREA();
        public class VA5419B_WORK_AREA : VarBasis
        {
            /*"    05        REGISTRO-SAF        PIC  X(231).*/
            public StringBasis REGISTRO_SAF { get; set; } = new StringBasis(new PIC("X", "231", "X(231)."), @"");
            /*"    05        REG-DETALHE1              REDEFINES REGISTRO-SAF.*/
            private _REDEF_VA5419B_REG_DETALHE1 _reg_detalhe1 { get; set; }
            public _REDEF_VA5419B_REG_DETALHE1 REG_DETALHE1
            {
                get { _reg_detalhe1 = new _REDEF_VA5419B_REG_DETALHE1(); _.Move(REGISTRO_SAF, _reg_detalhe1); VarBasis.RedefinePassValue(REGISTRO_SAF, _reg_detalhe1, REGISTRO_SAF); _reg_detalhe1.ValueChanged += () => { _.Move(_reg_detalhe1, REGISTRO_SAF); }; return _reg_detalhe1; }
                set { VarBasis.RedefinePassValue(value, _reg_detalhe1, REGISTRO_SAF); }
            }  //Redefines
            public class _REDEF_VA5419B_REG_DETALHE1 : VarBasis
            {
                /*"      10      DET1-NOME            PIC  X(040).*/
                public StringBasis DET1_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10      DET1-CPF             PIC  9(011).*/
                public IntBasis DET1_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"      10      DET1-ENDERECO        PIC  X(040).*/
                public StringBasis DET1_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      10      DET1-BAIRRO          PIC  X(017).*/
                public StringBasis DET1_BAIRRO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
                /*"      10      DET1-CIDADE          PIC  X(020).*/
                public StringBasis DET1_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      10      DET1-UF              PIC  X(002).*/
                public StringBasis DET1_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10      DET1-CEP             PIC  9(005).*/
                public IntBasis DET1_CEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      DET1-TELEFONE        PIC  X(016).*/
                public StringBasis DET1_TELEFONE { get; set; } = new StringBasis(new PIC("X", "16", "X(016)."), @"");
                /*"      10      DET1-SEGURADORA      PIC  9(004).*/
                public IntBasis DET1_SEGURADORA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      DET1-SUCURSAL        PIC  9(003).*/
                public IntBasis DET1_SUCURSAL { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      DET1-CARTEIRA        PIC  9(003).*/
                public IntBasis DET1_CARTEIRA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      DET1-APOLICE         PIC  9(009).*/
                public IntBasis DET1_APOLICE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      10      DET1-NRCERTIF        PIC  9(007).*/
                public IntBasis DET1_NRCERTIF { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"      10      DET1-CONSTANTE       PIC  9(012).*/
                public IntBasis DET1_CONSTANTE { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"      10      DET1-DTINIVIG        PIC  9(006).*/
                public IntBasis DET1_DTINIVIG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      DET1-DTTERVIG        PIC  9(006).*/
                public IntBasis DET1_DTTERVIG { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      DET1-DTEMISAPOL      PIC  9(006).*/
                public IntBasis DET1_DTEMISAPOL { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      DET1-PLANO           PIC  X(001).*/
                public StringBasis DET1_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      DET1-CONSTANTE-BR    PIC  X(009).*/
                public StringBasis DET1_CONSTANTE_BR { get; set; } = new StringBasis(new PIC("X", "9", "X(009)."), @"");
                /*"      10      DET1-CONSTANTE-01    PIC  X(002).*/
                public StringBasis DET1_CONSTANTE_01 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10      DET1-CONSTANTE-00    PIC  X(002).*/
                public StringBasis DET1_CONSTANTE_00 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10      DET1-CONSTANTE-U     PIC  X(001).*/
                public StringBasis DET1_CONSTANTE_U { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      DET1-CONSTANTE-BR1   PIC  X(002).*/
                public StringBasis DET1_CONSTANTE_BR1 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10      DET1-CONSTANTE-BR2   PIC  X(002).*/
                public StringBasis DET1_CONSTANTE_BR2 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      10      DET1-COMPL-CEP       PIC  9(003).*/
                public IntBasis DET1_COMPL_CEP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      10      DET1-PADRA           PIC  X(001).*/
                public StringBasis DET1_PADRA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      DET1-TIPO-MOVTO      PIC  X(001).*/
                public StringBasis DET1_TIPO_MOVTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05        WS-CODOPER-ANT      PIC S9(04) COMP.*/

                public _REDEF_VA5419B_REG_DETALHE1()
                {
                    DET1_NOME.ValueChanged += OnValueChanged;
                    DET1_CPF.ValueChanged += OnValueChanged;
                    DET1_ENDERECO.ValueChanged += OnValueChanged;
                    DET1_BAIRRO.ValueChanged += OnValueChanged;
                    DET1_CIDADE.ValueChanged += OnValueChanged;
                    DET1_UF.ValueChanged += OnValueChanged;
                    DET1_CEP.ValueChanged += OnValueChanged;
                    DET1_TELEFONE.ValueChanged += OnValueChanged;
                    DET1_SEGURADORA.ValueChanged += OnValueChanged;
                    DET1_SUCURSAL.ValueChanged += OnValueChanged;
                    DET1_CARTEIRA.ValueChanged += OnValueChanged;
                    DET1_APOLICE.ValueChanged += OnValueChanged;
                    DET1_NRCERTIF.ValueChanged += OnValueChanged;
                    DET1_CONSTANTE.ValueChanged += OnValueChanged;
                    DET1_DTINIVIG.ValueChanged += OnValueChanged;
                    DET1_DTTERVIG.ValueChanged += OnValueChanged;
                    DET1_DTEMISAPOL.ValueChanged += OnValueChanged;
                    DET1_PLANO.ValueChanged += OnValueChanged;
                    DET1_CONSTANTE_BR.ValueChanged += OnValueChanged;
                    DET1_CONSTANTE_01.ValueChanged += OnValueChanged;
                    DET1_CONSTANTE_00.ValueChanged += OnValueChanged;
                    DET1_CONSTANTE_U.ValueChanged += OnValueChanged;
                    DET1_CONSTANTE_BR1.ValueChanged += OnValueChanged;
                    DET1_CONSTANTE_BR2.ValueChanged += OnValueChanged;
                    DET1_COMPL_CEP.ValueChanged += OnValueChanged;
                    DET1_PADRA.ValueChanged += OnValueChanged;
                    DET1_TIPO_MOVTO.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CODOPER_ANT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
            /*"    05        DATA-SQL.*/
            public VA5419B_DATA_SQL DATA_SQL { get; set; } = new VA5419B_DATA_SQL();
            public class VA5419B_DATA_SQL : VarBasis
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
                /*"    05        DATA-FIL.*/
            }
            public VA5419B_DATA_FIL DATA_FIL { get; set; } = new VA5419B_DATA_FIL();
            public class VA5419B_DATA_FIL : VarBasis
            {
                /*"      10      ANO-FIL             PIC  9(002).*/
                public IntBasis ANO_FIL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      MES-FIL             PIC  9(002).*/
                public IntBasis MES_FIL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      DIA-FIL             PIC  9(002).*/
                public IntBasis DIA_FIL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        DATA-MAQ.*/
            }
            public VA5419B_DATA_MAQ DATA_MAQ { get; set; } = new VA5419B_DATA_MAQ();
            public class VA5419B_DATA_MAQ : VarBasis
            {
                /*"      10      ANO                 PIC  9(004).*/
                public IntBasis ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      MES                 PIC  9(002).*/
                public IntBasis MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      DIA                 PIC  9(002).*/
                public IntBasis DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        DATA-DET            PIC  9(008).*/
            }
            public IntBasis DATA_DET { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        DATA-DET-R          REDEFINES              DATA-DET.*/
            private _REDEF_VA5419B_DATA_DET_R _data_det_r { get; set; }
            public _REDEF_VA5419B_DATA_DET_R DATA_DET_R
            {
                get { _data_det_r = new _REDEF_VA5419B_DATA_DET_R(); _.Move(DATA_DET, _data_det_r); VarBasis.RedefinePassValue(DATA_DET, _data_det_r, DATA_DET); _data_det_r.ValueChanged += () => { _.Move(_data_det_r, DATA_DET); }; return _data_det_r; }
                set { VarBasis.RedefinePassValue(value, _data_det_r, DATA_DET); }
            }  //Redefines
            public class _REDEF_VA5419B_DATA_DET_R : VarBasis
            {
                /*"      10      DIA-DET             PIC  9(002).*/
                public IntBasis DIA_DET { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      MES-DET             PIC  9(002).*/
                public IntBasis MES_DET { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      ANO-DET             PIC  9(004).*/
                public IntBasis ANO_DET { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        MES-REFERENCIA      PIC  9(006).*/

                public _REDEF_VA5419B_DATA_DET_R()
                {
                    DIA_DET.ValueChanged += OnValueChanged;
                    MES_DET.ValueChanged += OnValueChanged;
                    ANO_DET.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis MES_REFERENCIA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05        MES-REFERENCIA-R    REDEFINES              MES-REFERENCIA.*/
            private _REDEF_VA5419B_MES_REFERENCIA_R _mes_referencia_r { get; set; }
            public _REDEF_VA5419B_MES_REFERENCIA_R MES_REFERENCIA_R
            {
                get { _mes_referencia_r = new _REDEF_VA5419B_MES_REFERENCIA_R(); _.Move(MES_REFERENCIA, _mes_referencia_r); VarBasis.RedefinePassValue(MES_REFERENCIA, _mes_referencia_r, MES_REFERENCIA); _mes_referencia_r.ValueChanged += () => { _.Move(_mes_referencia_r, MES_REFERENCIA); }; return _mes_referencia_r; }
                set { VarBasis.RedefinePassValue(value, _mes_referencia_r, MES_REFERENCIA); }
            }  //Redefines
            public class _REDEF_VA5419B_MES_REFERENCIA_R : VarBasis
            {
                /*"      10      MES-REF             PIC  9(002).*/
                public IntBasis MES_REF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      ANO-REF             PIC  9(004).*/
                public IntBasis ANO_REF { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WIND                PIC  9(002).*/

                public _REDEF_VA5419B_MES_REFERENCIA_R()
                {
                    MES_REF.ValueChanged += OnValueChanged;
                    ANO_REF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WIND { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05        WS-TIME             PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05        WS-TIME-R           REDEFINES WS-TIME.*/
            private _REDEF_VA5419B_WS_TIME_R _ws_time_r { get; set; }
            public _REDEF_VA5419B_WS_TIME_R WS_TIME_R
            {
                get { _ws_time_r = new _REDEF_VA5419B_WS_TIME_R(); _.Move(WS_TIME, _ws_time_r); VarBasis.RedefinePassValue(WS_TIME, _ws_time_r, WS_TIME); _ws_time_r.ValueChanged += () => { _.Move(_ws_time_r, WS_TIME); }; return _ws_time_r; }
                set { VarBasis.RedefinePassValue(value, _ws_time_r, WS_TIME); }
            }  //Redefines
            public class _REDEF_VA5419B_WS_TIME_R : VarBasis
            {
                /*"      10      WS-HOR              PIC  9(002).*/
                public IntBasis WS_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-MIN              PIC  9(002).*/
                public IntBasis WS_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-SEG              PIC  9(002).*/
                public IntBasis WS_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  9(002).*/
                public IntBasis FILLER_4 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA.*/

                public _REDEF_VA5419B_WS_TIME_R()
                {
                    WS_HOR.ValueChanged += OnValueChanged;
                    WS_MIN.ValueChanged += OnValueChanged;
                    WS_SEG.ValueChanged += OnValueChanged;
                    FILLER_4.ValueChanged += OnValueChanged;
                }

            }
            public VA5419B_WS_DATA WS_DATA { get; set; } = new VA5419B_WS_DATA();
            public class VA5419B_WS_DATA : VarBasis
            {
                /*"      10      WS-DIA              PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-BAR1             PIC  X(001).*/
                public StringBasis WS_BAR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MES              PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      WS-BAR2             PIC  X(001).*/
                public StringBasis WS_BAR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-ANO              PIC  9(004).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        WS-DTREFER.*/
            }
            public VA5419B_WS_DTREFER WS_DTREFER { get; set; } = new VA5419B_WS_DTREFER();
            public class VA5419B_WS_DTREFER : VarBasis
            {
                /*"      10      WS-AAREFER          PIC  9(004).*/
                public IntBasis WS_AAREFER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MMREFER          PIC  9(002).*/
                public IntBasis WS_MMREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DDREFER          PIC  9(002).*/
                public IntBasis WS_DDREFER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-DATA-CURSOR.*/
            }
            public VA5419B_WS_DATA_CURSOR WS_DATA_CURSOR { get; set; } = new VA5419B_WS_DATA_CURSOR();
            public class VA5419B_WS_DATA_CURSOR : VarBasis
            {
                /*"      10      WS-AACURSOR         PIC  9(004).*/
                public IntBasis WS_AACURSOR { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-MMCURSOR         PIC  9(002).*/
                public IntBasis WS_MMCURSOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10      WS-DDCURSOR         PIC  9(002).*/
                public IntBasis WS_DDCURSOR { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-CPF              PIC  9(015).*/
            }
            public IntBasis WS_CPF { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    05        WS-CPF-R            REDEFINES WS-CPF.*/
            private _REDEF_VA5419B_WS_CPF_R _ws_cpf_r { get; set; }
            public _REDEF_VA5419B_WS_CPF_R WS_CPF_R
            {
                get { _ws_cpf_r = new _REDEF_VA5419B_WS_CPF_R(); _.Move(WS_CPF, _ws_cpf_r); VarBasis.RedefinePassValue(WS_CPF, _ws_cpf_r, WS_CPF); _ws_cpf_r.ValueChanged += () => { _.Move(_ws_cpf_r, WS_CPF); }; return _ws_cpf_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cpf_r, WS_CPF); }
            }  //Redefines
            public class _REDEF_VA5419B_WS_CPF_R : VarBasis
            {
                /*"      10      WS-NRCPF            PIC  9(013).*/
                public IntBasis WS_NRCPF { get; set; } = new IntBasis(new PIC("9", "13", "9(013)."));
                /*"      10      WS-DVCPF            PIC  9(002).*/
                public IntBasis WS_DVCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05        WS-CEP              PIC  9(008).*/

                public _REDEF_VA5419B_WS_CPF_R()
                {
                    WS_NRCPF.ValueChanged += OnValueChanged;
                    WS_DVCPF.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        WS-CEP-R            REDEFINES WS-CEP.*/
            private _REDEF_VA5419B_WS_CEP_R _ws_cep_r { get; set; }
            public _REDEF_VA5419B_WS_CEP_R WS_CEP_R
            {
                get { _ws_cep_r = new _REDEF_VA5419B_WS_CEP_R(); _.Move(WS_CEP, _ws_cep_r); VarBasis.RedefinePassValue(WS_CEP, _ws_cep_r, WS_CEP); _ws_cep_r.ValueChanged += () => { _.Move(_ws_cep_r, WS_CEP); }; return _ws_cep_r; }
                set { VarBasis.RedefinePassValue(value, _ws_cep_r, WS_CEP); }
            }  //Redefines
            public class _REDEF_VA5419B_WS_CEP_R : VarBasis
            {
                /*"      10      WS-NRCEP            PIC  9(005).*/
                public IntBasis WS_NRCEP { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"      10      WS-CPCEP            PIC  9(003).*/
                public IntBasis WS_CPCEP { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"    05        WS-MATRICULA        PIC  9(007).*/

                public _REDEF_VA5419B_WS_CEP_R()
                {
                    WS_NRCEP.ValueChanged += OnValueChanged;
                    WS_CPCEP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_MATRICULA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
            /*"    05        WS-MATRICULA-R      REDEFINES WS-MATRICULA.*/
            private _REDEF_VA5419B_WS_MATRICULA_R _ws_matricula_r { get; set; }
            public _REDEF_VA5419B_WS_MATRICULA_R WS_MATRICULA_R
            {
                get { _ws_matricula_r = new _REDEF_VA5419B_WS_MATRICULA_R(); _.Move(WS_MATRICULA, _ws_matricula_r); VarBasis.RedefinePassValue(WS_MATRICULA, _ws_matricula_r, WS_MATRICULA); _ws_matricula_r.ValueChanged += () => { _.Move(_ws_matricula_r, WS_MATRICULA); }; return _ws_matricula_r; }
                set { VarBasis.RedefinePassValue(value, _ws_matricula_r, WS_MATRICULA); }
            }  //Redefines
            public class _REDEF_VA5419B_WS_MATRICULA_R : VarBasis
            {
                /*"      10      WS-NRMATRVEN        PIC  9(006).*/
                public IntBasis WS_NRMATRVEN { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10      WS-DVMATRVEN        PIC  9(001).*/
                public IntBasis WS_DVMATRVEN { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"    05        WS-VAL-REPASSE      PIC  9(013)V99.*/

                public _REDEF_VA5419B_WS_MATRICULA_R()
                {
                    WS_NRMATRVEN.ValueChanged += OnValueChanged;
                    WS_DVMATRVEN.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WS_VAL_REPASSE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05        WS-TOT-REPASSE      PIC  9(008).*/
            public IntBasis WS_TOT_REPASSE { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        WS-QTVIDAS          PIC  9(008).*/
            public IntBasis WS_QTVIDAS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
            /*"    05        WS-VLIRRF           PIC  9(013)V99.*/
            public DoubleBasis WS_VLIRRF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05        WS-VLDA             PIC  9(013)V99.*/
            public DoubleBasis WS_VLDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05        WS-VLSAFLIQ         PIC  9(013)V99.*/
            public DoubleBasis WS_VLSAFLIQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05        WS-VLCUSTSAF        PIC  9(013)V99.*/
            public DoubleBasis WS_VLCUSTSAF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05     TABELA-ULTIMOS-DIAS.*/
            public VA5419B_TABELA_ULTIMOS_DIAS TABELA_ULTIMOS_DIAS { get; set; } = new VA5419B_TABELA_ULTIMOS_DIAS();
            public class VA5419B_TABELA_ULTIMOS_DIAS : VarBasis
            {
                /*"       15  FILLER               PIC  X(024)           VALUE '312831303130313130313031'.*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "24", "X(024)"), @"312831303130313130313031");
                /*"    05     TAB-ULTIMOS-DIAS     REDEFINES           TABELA-ULTIMOS-DIAS.*/
            }
            private _REDEF_VA5419B_TAB_ULTIMOS_DIAS _tab_ultimos_dias { get; set; }
            public _REDEF_VA5419B_TAB_ULTIMOS_DIAS TAB_ULTIMOS_DIAS
            {
                get { _tab_ultimos_dias = new _REDEF_VA5419B_TAB_ULTIMOS_DIAS(); _.Move(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias); VarBasis.RedefinePassValue(TABELA_ULTIMOS_DIAS, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); _tab_ultimos_dias.ValueChanged += () => { _.Move(_tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }; return _tab_ultimos_dias; }
                set { VarBasis.RedefinePassValue(value, _tab_ultimos_dias, TABELA_ULTIMOS_DIAS); }
            }  //Redefines
            public class _REDEF_VA5419B_TAB_ULTIMOS_DIAS : VarBasis
            {
                /*"       15  TAB-DIA-MESES        OCCURS 12.*/
                public ListBasis<VA5419B_TAB_DIA_MESES> TAB_DIA_MESES { get; set; } = new ListBasis<VA5419B_TAB_DIA_MESES>(12);
                public class VA5419B_TAB_DIA_MESES : VarBasis
                {
                    /*"           20 TAB-ULT-DIA       PIC 9(002).*/
                    public IntBasis TAB_ULT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    05        WFIM-V0HISTREPSAF   PIC   X(01)  VALUE  ' '.*/

                    public VA5419B_TAB_DIA_MESES()
                    {
                        TAB_ULT_DIA.ValueChanged += OnValueChanged;
                    }

                }

                public _REDEF_VA5419B_TAB_ULTIMOS_DIAS()
                {
                    TAB_DIA_MESES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WFIM_V0HISTREPSAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-V1SISTEMA      PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_V1SISTEMA { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WFIM-SORT           PIC   X(01)  VALUE  ' '.*/
            public StringBasis WFIM_SORT { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        WTEM-SOLICITACAO    PIC   X(01)  VALUE  ' '.*/
            public StringBasis WTEM_SOLICITACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)"), @" ");
            /*"    05        DATA-AUX.*/
            public VA5419B_DATA_AUX DATA_AUX { get; set; } = new VA5419B_DATA_AUX();
            public class VA5419B_DATA_AUX : VarBasis
            {
                /*"      10      DIA-AUX             PIC  9(002).*/
                public IntBasis DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      MES-AUX             PIC  9(002).*/
                public IntBasis MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      ANO-AUX             PIC  9(004).*/
                public IntBasis ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05        AC-LIDOS            PIC  9(006) VALUE ZEROS.*/
            }
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-CONTA            PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-CONTA-102        PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_CONTA_102 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-CONTA-1100       PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_CONTA_1100 { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-LINHA            PIC  9(006) VALUE 90.*/
            public IntBasis AC_LINHA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"), 90);
            /*"    05        AC-PAGINA           PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_PAGINA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        AC-IMPRESSOS        PIC  9(006) VALUE ZEROS.*/
            public IntBasis AC_IMPRESSOS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    05        WABEND.*/
            public VA5419B_WABEND WABEND { get; set; } = new VA5419B_WABEND();
            public class VA5419B_WABEND : VarBasis
            {
                /*"      10      FILLER              PIC  X(010) VALUE             ' VA5419B'.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VA5419B");
                /*"      10      FILLER              PIC  X(026) VALUE             ' *** ERRO EXEC SQL NUMERO '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
                /*"      10      WNR-EXEC-SQL        PIC  X(004) VALUE '0000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
                /*"      10      FILLER              PIC  X(013) VALUE             ' *** SQLCODE '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
                /*"      10      WSQLCODE            PIC  ZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
                /*"    05        TRACO.*/
            }
            public VA5419B_TRACO TRACO { get; set; } = new VA5419B_TRACO();
            public class VA5419B_TRACO : VarBasis
            {
                /*"      10      FILLER              PIC  X(132) VALUE ALL '-'.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"ALL");
                /*"    05        BRANCO.*/
            }
            public VA5419B_BRANCO BRANCO { get; set; } = new VA5419B_BRANCO();
            public class VA5419B_BRANCO : VarBasis
            {
                /*"      10      FILLER              PIC  X(132) VALUE SPACES.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "132", "X(132)"), @"");
                /*"    05        LC01.*/
            }
            public VA5419B_LC01 LC01 { get; set; } = new VA5419B_LC01();
            public class VA5419B_LC01 : VarBasis
            {
                /*"      10      FILLER              PIC  X(008) VALUE 'VA5419B'.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"VA5419B");
                /*"      10      FILLER              PIC  X(037) VALUE SPACES.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "37", "X(037)"), @"");
                /*"      10      FILLER              PIC  X(040) VALUE             'SASSE - CIA NACIONAL DE SEGUROS GERAIS'.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"SASSE - CIA NACIONAL DE SEGUROS GERAIS");
                /*"      10      FILLER              PIC  X(030) VALUE SPACES.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"      10      FILLER              PIC  X(013) VALUE 'PAGINA'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"PAGINA");
                /*"      10      LC01-PAGINA         PIC  Z999.*/
                public IntBasis LC01_PAGINA { get; set; } = new IntBasis(new PIC("9", "4", "Z999."));
                /*"    05        LC02.*/
            }
            public VA5419B_LC02 LC02 { get; set; } = new VA5419B_LC02();
            public class VA5419B_LC02 : VarBasis
            {
                /*"      10      FILLER              PIC  X(115) VALUE SPACES.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "115", "X(115)"), @"");
                /*"      10      FILLER              PIC  X(007) VALUE 'DATA '.*/
                public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"DATA ");
                /*"      10      LC02-DIA            PIC  9(02).*/
                public IntBasis LC02_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC02-MES            PIC  9(02).*/
                public IntBasis LC02_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE '/'.*/
                public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"      10      LC02-ANO            PIC  9(04).*/
                public IntBasis LC02_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05        LC03.*/
            }
            public VA5419B_LC03 LC03 { get; set; } = new VA5419B_LC03();
            public class VA5419B_LC03 : VarBasis
            {
                /*"      10      FILLER              PIC  X(035) VALUE SPACES.*/
                public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @"");
                /*"      10      FILLER              PIC  X(042) VALUE             'REPASSE DE PREMIO DE COBERTURA PARA AUXILI'.*/
                public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "42", "X(042)"), @"REPASSE DE PREMIO DE COBERTURA PARA AUXILI");
                /*"      10      FILLER              PIC  X(032) VALUE             'O FUNERAL - SAF - SUL AMERICA '.*/
                public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "32", "X(032)"), @"O FUNERAL - SAF - SUL AMERICA ");
                /*"      10      FILLER              PIC  X(006) VALUE SPACES.*/
                public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "6", "X(006)"), @"");
                /*"      10      FILLER              PIC  X(009) VALUE 'HORA '.*/
                public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"HORA ");
                /*"      10      LC03-HOR            PIC  9(02).*/
                public IntBasis LC03_HOR { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"      10      LC03-MIN            PIC  9(02).*/
                public IntBasis LC03_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"      10      FILLER              PIC  X(001) VALUE ':'.*/
                public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"      10      LC03-SEG            PIC  9(02).*/
                public IntBasis LC03_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(02)."));
                /*"    05        LC03-1.*/
            }
            public VA5419B_LC03_1 LC03_1 { get; set; } = new VA5419B_LC03_1();
            public class VA5419B_LC03_1 : VarBasis
            {
                /*"      10      FILLER              PIC  X(048) VALUE SPACES.*/
                public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "48", "X(048)"), @"");
                /*"      10      FILLER              PIC  X(013) VALUE             'REFERENCIA :'.*/
                public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"REFERENCIA :");
                /*"      10      LC03-MES-REFER      PIC  X(09).*/
                public StringBasis LC03_MES_REFER { get; set; } = new StringBasis(new PIC("X", "9", "X(09)."), @"");
                /*"      10      FILLER              PIC  X(004) VALUE ' DE '.*/
                public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @" DE ");
                /*"      10      LC03-ANO-REFER      PIC  9(04).*/
                public IntBasis LC03_ANO_REFER { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"    05        LC04.*/
            }
            public VA5419B_LC04 LC04 { get; set; } = new VA5419B_LC04();
            public class VA5419B_LC04 : VarBasis
            {
                /*"      10      FILLER              PIC  X(10) VALUE             'APOLICE.: '.*/
                public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"APOLICE.: ");
                /*"      10      LC04-NUM-APOLICE    PIC  9(13).*/
                public IntBasis LC04_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)."));
                /*"      10      FILLER              PIC  X(03) VALUE ' - '.*/
                public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"      10      LC04-NOME-APOLICE   PIC  X(40).*/
                public StringBasis LC04_NOME_APOLICE { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    05        LC05.*/
            }
            public VA5419B_LC05 LC05 { get; set; } = new VA5419B_LC05();
            public class VA5419B_LC05 : VarBasis
            {
                /*"      10      FILLER              PIC  X(10) VALUE             'SUBGRUPO: '.*/
                public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)"), @"SUBGRUPO: ");
                /*"      10      LC05-COD-SUBGRUPO   PIC  9(04).*/
                public IntBasis LC05_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("9", "4", "9(04)."));
                /*"      10      FILLER              PIC  X(09) VALUE  SPACES.*/
                public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"");
                /*"      10      FILLER              PIC  X(03) VALUE ' - '.*/
                public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @" - ");
                /*"      10      LC05-NOME-SUBGRUPO  PIC  X(40).*/
                public StringBasis LC05_NOME_SUBGRUPO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)."), @"");
                /*"    05        LC07.*/
            }
            public VA5419B_LC07 LC07 { get; set; } = new VA5419B_LC07();
            public class VA5419B_LC07 : VarBasis
            {
                /*"      10      FILLER              PIC X(40) VALUE  SPACES.*/
                public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"      10      FILLER              PIC X(03) VALUE  SPACES.*/
                public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      FILLER              PIC X(09) VALUE             'QTD VIDAS'.*/
                public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "9", "X(09)"), @"QTD VIDAS");
                /*"      10      FILLER              PIC X(03) VALUE  SPACES.*/
                public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      FILLER              PIC X(03) VALUE  SPACES.*/
                public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      FILLER              PIC X(13) VALUE                                 'PRM SAF BRUTO'.*/
                public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"PRM SAF BRUTO");
                /*"      10      FILLER              PIC X(03) VALUE  SPACES.*/
                public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      FILLER              PIC X(13) VALUE                                 '   VALOR IRRF'.*/
                public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"   VALOR IRRF");
                /*"      10      FILLER              PIC X(03) VALUE  SPACES.*/
                public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      FILLER              PIC X(13) VALUE                                 '     VALOR DA'.*/
                public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "13", "X(13)"), @"     VALOR DA");
                /*"      10      FILLER              PIC X(03) VALUE  SPACES.*/
                public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      FILLER              PIC X(15) VALUE                                 'PRM SAF LIQUIDO'.*/
                public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "15", "X(15)"), @"PRM SAF LIQUIDO");
                /*"    05        LD01.*/
            }
            public VA5419B_LD01 LD01 { get; set; } = new VA5419B_LD01();
            public class VA5419B_LD01 : VarBasis
            {
                /*"      10      LD01-OPERACAO       PIC X(40)   VALUE SPACES.*/
                public StringBasis LD01_OPERACAO { get; set; } = new StringBasis(new PIC("X", "40", "X(40)"), @"");
                /*"      10      FILLER              PIC X(03)   VALUE SPACES.*/
                public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      LD01-QTVIDAS        PIC ZZZZZ.999.*/
                public IntBasis LD01_QTVIDAS { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZZ.999."));
                /*"      10      FILLER              PIC X(06)   VALUE SPACES.*/
                public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "6", "X(06)"), @"");
                /*"      10      LD01-VLSAFBRUTO     PIC ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLSAFBRUTO { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(03)   VALUE SPACES.*/
                public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      LD01-VLIRRF         PIC ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLIRRF { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(03)   VALUE SPACES.*/
                public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "3", "X(03)"), @"");
                /*"      10      LD01-VLDA           PIC ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLDA { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"      10      FILLER              PIC X(05)   VALUE SPACES.*/
                public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "5", "X(05)"), @"");
                /*"      10      LD01-VLSAFLIQ       PIC ZZ.ZZZ.ZZ9,99.*/
                public DoubleBasis LD01_VLSAFLIQ { get; set; } = new DoubleBasis(new PIC("9", "8", "ZZ.ZZZ.ZZ9V99."), 2);
                /*"01            TABELA-MESES.*/
            }
        }
        public VA5419B_TABELA_MESES TABELA_MESES { get; set; } = new VA5419B_TABELA_MESES();
        public class VA5419B_TABELA_MESES : VarBasis
        {
            /*"        15    FILLER           PIC  X(009) VALUE '  JANEIRO'.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  JANEIRO");
            /*"        15    FILLER           PIC  X(009) VALUE 'FEVEREIRO'.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"FEVEREIRO");
            /*"        15    FILLER           PIC  X(009) VALUE '    MARCO'.*/
            public StringBasis FILLER_60 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    MARCO");
            /*"        15    FILLER           PIC  X(009) VALUE '    ABRIL'.*/
            public StringBasis FILLER_61 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    ABRIL");
            /*"        15    FILLER           PIC  X(009) VALUE '     MAIO'.*/
            public StringBasis FILLER_62 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"     MAIO");
            /*"        15    FILLER           PIC  X(009) VALUE '    JUNHO'.*/
            public StringBasis FILLER_63 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JUNHO");
            /*"        15    FILLER           PIC  X(009) VALUE '    JULHO'.*/
            public StringBasis FILLER_64 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"    JULHO");
            /*"        15    FILLER           PIC  X(009) VALUE '   AGOSTO'.*/
            public StringBasis FILLER_65 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"   AGOSTO");
            /*"        15    FILLER           PIC  X(009) VALUE ' SETEMBRO'.*/
            public StringBasis FILLER_66 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" SETEMBRO");
            /*"        15    FILLER           PIC  X(009) VALUE '  OUTUBRO'.*/
            public StringBasis FILLER_67 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"  OUTUBRO");
            /*"        15    FILLER           PIC  X(009) VALUE ' NOVEMBRO'.*/
            public StringBasis FILLER_68 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" NOVEMBRO");
            /*"        15    FILLER           PIC  X(009) VALUE ' DEZEMBRO'.*/
            public StringBasis FILLER_69 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @" DEZEMBRO");
            /*"01            TABELA-MESES-R   REDEFINES              TABELA-MESES.*/
        }
        private _REDEF_VA5419B_TABELA_MESES_R _tabela_meses_r { get; set; }
        public _REDEF_VA5419B_TABELA_MESES_R TABELA_MESES_R
        {
            get { _tabela_meses_r = new _REDEF_VA5419B_TABELA_MESES_R(); _.Move(TABELA_MESES, _tabela_meses_r); VarBasis.RedefinePassValue(TABELA_MESES, _tabela_meses_r, TABELA_MESES); _tabela_meses_r.ValueChanged += () => { _.Move(_tabela_meses_r, TABELA_MESES); }; return _tabela_meses_r; }
            set { VarBasis.RedefinePassValue(value, _tabela_meses_r, TABELA_MESES); }
        }  //Redefines
        public class _REDEF_VA5419B_TABELA_MESES_R : VarBasis
        {
            /*"    05          TAB-MES       OCCURS 12 TIMES                               PIC  X(009).*/
            public ListBasis<StringBasis, string> TAB_MES { get; set; } = new ListBasis<StringBasis, string>(new PIC("X", "9", "X(009)."), 12);
            /*"01            TOTAIS-PRODUTOS.*/

            public _REDEF_VA5419B_TABELA_MESES_R()
            {
                TAB_MES.ValueChanged += OnValueChanged;
            }

        }
        public VA5419B_TOTAIS_PRODUTOS TOTAIS_PRODUTOS { get; set; } = new VA5419B_TOTAIS_PRODUTOS();
        public class VA5419B_TOTAIS_PRODUTOS : VarBasis
        {
            /*"    05          TOTAL-PRODUTO OCCURS 10 TIMES.*/
            public ListBasis<VA5419B_TOTAL_PRODUTO> TOTAL_PRODUTO { get; set; } = new ListBasis<VA5419B_TOTAL_PRODUTO>(10);
            public class VA5419B_TOTAL_PRODUTO : VarBasis
            {
                /*"       15    TOTP-QTVIDAS         PIC  9(006).*/
                public IntBasis TOTP_QTVIDAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"       15    TOTP-QTPARCE         PIC  9(007).*/
                public IntBasis TOTP_QTPARCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
                /*"       15    TOTP-VLSAFBRUTO      PIC  9(013)V99.*/
                public DoubleBasis TOTP_VLSAFBRUTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"       15    TOTP-VLIRRF          PIC  9(013)V99.*/
                public DoubleBasis TOTP_VLIRRF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"       15    TOTP-VLDA            PIC  9(013)V99.*/
                public DoubleBasis TOTP_VLDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"       15    TOTP-VLSAFLIQ        PIC  9(013)V99.*/
                public DoubleBasis TOTP_VLSAFLIQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"01            TOTAIS-GERAIS.*/
            }
        }
        public VA5419B_TOTAIS_GERAIS TOTAIS_GERAIS { get; set; } = new VA5419B_TOTAIS_GERAIS();
        public class VA5419B_TOTAIS_GERAIS : VarBasis
        {
            /*"       15    TOTG-QTVIDAS         PIC  9(006).*/
            public IntBasis TOTG_QTVIDAS { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"       15    TOTG-QTPARCE         PIC  9(007).*/
            public IntBasis TOTG_QTPARCE { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
            /*"       15    TOTG-VLSAFBRUTO      PIC  9(013)V99.*/
            public DoubleBasis TOTG_VLSAFBRUTO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"       15    TOTG-VLIRRF          PIC  9(013)V99.*/
            public DoubleBasis TOTG_VLIRRF { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"       15    TOTG-VLDA            PIC  9(013)V99.*/
            public DoubleBasis TOTG_VLDA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"       15    TOTG-VLSAFLIQ        PIC  9(013)V99.*/
            public DoubleBasis TOTG_VLSAFLIQ { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
        }


        public VA5419B_CREPAS CREPAS { get; set; } = new VA5419B_CREPAS();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RVA5419B_FILE_NAME_P, string FUND001I_FILE_NAME_P, string FUND001C_FILE_NAME_P, string FUND001R_FILE_NAME_P, string FUND001A_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RVA5419B.SetFile(RVA5419B_FILE_NAME_P);
                FUND001I.SetFile(FUND001I_FILE_NAME_P);
                FUND001C.SetFile(FUND001C_FILE_NAME_P);
                FUND001R.SetFile(FUND001R_FILE_NAME_P);
                FUND001A.SetFile(FUND001A_FILE_NAME_P);

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
            /*" -504- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -507- EXEC SQL WHENEVER SQLERROR GO TO R9999-00-ROT-ERRO END-EXEC. */

            /*" -510- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -519- MOVE ZEROS TO TOTAIS-PRODUTOS TOTAIS-GERAIS. */
            _.Move(0, TOTAIS_PRODUTOS, TOTAIS_GERAIS);

            /*" -521- PERFORM R0100-00-SELECT-V1SISTEMA. */

            R0100_00_SELECT_V1SISTEMA_SECTION();

            /*" -522- IF WFIM-V1SISTEMA NOT EQUAL SPACES */

            if (!WORK_AREA.WFIM_V1SISTEMA.IsEmpty())
            {

                /*" -523- DISPLAY '*** PROBLEMAS NA V0SISTEMA' */
                _.Display($"*** PROBLEMAS NA V0SISTEMA");

                /*" -524- MOVE 9 TO RETURN-CODE */
                _.Move(9, RETURN_CODE);

                /*" -526- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -528- PERFORM R0200-00-SELECT-V0RELATORIOS. */

            R0200_00_SELECT_V0RELATORIOS_SECTION();

            /*" -529- IF WTEM-SOLICITACAO EQUAL 'N' */

            if (WORK_AREA.WTEM_SOLICITACAO == "N")
            {

                /*" -530- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -531- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -533- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -535- PERFORM R0900-00-DECLARE-V0HISTREPSAF. */

            R0900_00_DECLARE_V0HISTREPSAF_SECTION();

            /*" -537- PERFORM R0910-00-FETCH-V0HISTREPSAF. */

            R0910_00_FETCH_V0HISTREPSAF_SECTION();

            /*" -538- IF WFIM-V0HISTREPSAF EQUAL 'S' */

            if (WORK_AREA.WFIM_V0HISTREPSAF == "S")
            {

                /*" -539- PERFORM R9800-00-ENCERRA-SEM-SOLIC */

                R9800_00_ENCERRA_SEM_SOLIC_SECTION();

                /*" -540- MOVE ZEROS TO RETURN-CODE */
                _.Move(0, RETURN_CODE);

                /*" -542- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -543- OPEN OUTPUT RVA5419B. */
            RVA5419B.Open(REG_IMPRESSAO);

            /*" -544- OPEN OUTPUT FUND001I. */
            FUND001I.Open(REG_FUND001I);

            /*" -545- OPEN OUTPUT FUND001C. */
            FUND001C.Open(REG_FUND001C);

            /*" -546- OPEN OUTPUT FUND001R. */
            FUND001R.Open(REG_FUND001R);

            /*" -548- OPEN OUTPUT FUND001A. */
            FUND001A.Open(REG_FUND001A);

            /*" -549- MOVE V0RSAF-NUM-APOLICE TO V0RSAF-NUM-APOLANT */
            _.Move(V0RSAF_NUM_APOLICE, V0RSAF_NUM_APOLANT);

            /*" -550- MOVE V0RSAF-CODSUBES TO V0RSAF-CODSUBESANT. */
            _.Move(V0RSAF_CODSUBES, V0RSAF_CODSUBESANT);

            /*" -552- MOVE V0RSAF-CODCLIEN-SUB TO V0RSAF-CODCLIEN-ANT. */
            _.Move(V0RSAF_CODCLIEN_SUB, V0RSAF_CODCLIEN_ANT);

            /*" -554- PERFORM R0050-00-SELECT-DTEFERENCIA */

            R0050_00_SELECT_DTEFERENCIA_SECTION();

            /*" -556- PERFORM R0010-00-GERA THRU R0010-99-SAIDA. */

            R0010_00_GERA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/


            /*" -556- PERFORM R2000-00-GERA-RELATORIO. */

            R2000_00_GERA_RELATORIO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -566- CLOSE RVA5419B FUND001I FUND001C FUND001R FUND001A. */
            RVA5419B.Close();
            FUND001I.Close();
            FUND001C.Close();
            FUND001R.Close();
            FUND001A.Close();

            /*" -568- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -568- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -571- DISPLAY '**************************************' */
            _.Display($"**************************************");

            /*" -572- DISPLAY '****** VA5419B - TERMINO NORMAL ******' */
            _.Display($"****** VA5419B - TERMINO NORMAL ******");

            /*" -573- DISPLAY '**************************************' */
            _.Display($"**************************************");

            /*" -574- DISPLAY '*** TOTAL DE REGISTROS PROCESSADOS ***  ' AC-LIDOS. */
            _.Display($"*** TOTAL DE REGISTROS PROCESSADOS ***  {WORK_AREA.AC_LIDOS}");

            /*" -576- DISPLAY '**************************************' */
            _.Display($"**************************************");

            /*" -576- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0010-00-GERA-SECTION */
        private void R0010_00_GERA_SECTION()
        {
            /*" -588- PERFORM R1000-00-PROCESSA-REGISTRO UNTIL WFIM-V0HISTREPSAF EQUAL 'S' . */

            while (!(WORK_AREA.WFIM_V0HISTREPSAF == "S"))
            {

                R1000_00_PROCESSA_REGISTRO_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0010_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-SELECT-DTEFERENCIA-SECTION */
        private void R0050_00_SELECT_DTEFERENCIA_SECTION()
        {
            /*" -601- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -609- PERFORM R0050_00_SELECT_DTEFERENCIA_DB_SELECT_1 */

            R0050_00_SELECT_DTEFERENCIA_DB_SELECT_1();

            /*" -612- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -613- DISPLAY 'R050 - PROBLEMAS ACESSO A V0HISTREPSAF..' */
                _.Display($"R050 - PROBLEMAS ACESSO A V0HISTREPSAF..");

                /*" -614- DISPLAY 'CODCLIEN....  ' V0RSAF-CODCLIEN-SUB */
                _.Display($"CODCLIEN....  {V0RSAF_CODCLIEN_SUB}");

                /*" -615- DISPLAY 'COPDOPER....  ' 1800 */
                _.Display($"COPDOPER....  1800");

                /*" -616- DISPLAY 'SQLCODE  ' SQLCODE */
                _.Display($"SQLCODE  {DB.SQLCODE}");

                /*" -618- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -619- IF V1SIST-DTMOVABEANT-I LESS ZEROS */

            if (V1SIST_DTMOVABEANT_I < 00)
            {

                /*" -620- MOVE SPACES TO V1SIST-DTMOVABE */
                _.Move("", V1SIST_DTMOVABE);

                /*" -622- MOVE SPACES TO V1SIST-DTMOVABEANT. */
                _.Move("", V1SIST_DTMOVABEANT);
            }


            /*" -623- IF V1SIST-DTMOVABEANT EQUAL SPACES */

            if (V1SIST_DTMOVABEANT.IsEmpty())
            {

                /*" -624- DISPLAY 'R050 - PROBLEMAS ACESSO A V0HISTREPSAF..' */
                _.Display($"R050 - PROBLEMAS ACESSO A V0HISTREPSAF..");

                /*" -625- DISPLAY 'CODCLIEN....  ' V0RSAF-CODCLIEN-SUB */
                _.Display($"CODCLIEN....  {V0RSAF_CODCLIEN_SUB}");

                /*" -626- DISPLAY 'COPDOPER....  ' 1800 */
                _.Display($"COPDOPER....  1800");

                /*" -627- DISPLAY 'DTMOVABEANT.  ' V1SIST-DTMOVABEANT */
                _.Display($"DTMOVABEANT.  {V1SIST_DTMOVABEANT}");

                /*" -629- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -631- MOVE V1SIST-DTMOVABE TO DATA-SQL. */
            _.Move(V1SIST_DTMOVABE, WORK_AREA.DATA_SQL);

            /*" -633- MOVE ANO-SQL TO LC03-ANO-REFER ANO-REF. */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.LC03_1.LC03_ANO_REFER, WORK_AREA.MES_REFERENCIA_R.ANO_REF);

            /*" -634- MOVE TAB-MES (MES-SQL) TO LC03-MES-REFER. */
            _.Move(TABELA_MESES_R.TAB_MES[WORK_AREA.DATA_SQL.MES_SQL], WORK_AREA.LC03_1.LC03_MES_REFER);

            /*" -635- MOVE MES-SQL TO MES-REF. */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.MES_REFERENCIA_R.MES_REF);

            /*" -636- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -638- MOVE DATA-SQL TO WHOST-DTREF. */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTREF);

            /*" -639- MOVE V1SIST-DTMOVABEANT TO DATA-SQL. */
            _.Move(V1SIST_DTMOVABEANT, WORK_AREA.DATA_SQL);

            /*" -640- MOVE 01 TO DIA-SQL. */
            _.Move(01, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -640- MOVE DATA-SQL TO WHOST-DTREFANT. */
            _.Move(WORK_AREA.DATA_SQL, WHOST_DTREFANT);

        }

        [StopWatch]
        /*" R0050-00-SELECT-DTEFERENCIA-DB-SELECT-1 */
        public void R0050_00_SELECT_DTEFERENCIA_DB_SELECT_1()
        {
            /*" -609- EXEC SQL SELECT MAX(DTREF), MAX(DTREF) + 1 MONTH INTO :V1SIST-DTMOVABEANT:V1SIST-DTMOVABEANT-I, :V1SIST-DTMOVABE:V1SIST-DTMOVABE-I FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0RSAF-CODCLIEN-SUB AND CODOPER = 1800 END-EXEC. */

            var r0050_00_SELECT_DTEFERENCIA_DB_SELECT_1_Query1 = new R0050_00_SELECT_DTEFERENCIA_DB_SELECT_1_Query1()
            {
                V0RSAF_CODCLIEN_SUB = V0RSAF_CODCLIEN_SUB.ToString(),
            };

            var executed_1 = R0050_00_SELECT_DTEFERENCIA_DB_SELECT_1_Query1.Execute(r0050_00_SELECT_DTEFERENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTMOVABEANT, V1SIST_DTMOVABEANT);
                _.Move(executed_1.V1SIST_DTMOVABEANT_I, V1SIST_DTMOVABEANT_I);
                _.Move(executed_1.V1SIST_DTMOVABE, V1SIST_DTMOVABE);
                _.Move(executed_1.V1SIST_DTMOVABE_I, V1SIST_DTMOVABE_I);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-SECTION */
        private void R0100_00_SELECT_V1SISTEMA_SECTION()
        {
            /*" -653- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -660- PERFORM R0100_00_SELECT_V1SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V1SISTEMA_DB_SELECT_1();

            /*" -663- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -664- DISPLAY 'VA5419B - SISTEMA VA NAO ESTA CADASTRADO' */
                _.Display($"VA5419B - SISTEMA VA NAO ESTA CADASTRADO");

                /*" -665- MOVE 'S' TO WFIM-V1SISTEMA */
                _.Move("S", WORK_AREA.WFIM_V1SISTEMA);

                /*" -667- GO TO R0100-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/ //GOTO
                return;
            }


            /*" -669- MOVE V1SIST-DTHOJE TO DATA-SQL. */
            _.Move(V1SIST_DTHOJE, WORK_AREA.DATA_SQL);

            /*" -670- MOVE ANO-SQL TO LC02-ANO */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.LC02.LC02_ANO);

            /*" -671- MOVE MES-SQL TO LC02-MES */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.LC02.LC02_MES);

            /*" -673- MOVE DIA-SQL TO LC02-DIA. */
            _.Move(WORK_AREA.DATA_SQL.DIA_SQL, WORK_AREA.LC02.LC02_DIA);

            /*" -674- ACCEPT WS-TIME FROM TIME. */
            _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

            /*" -675- MOVE WS-HOR TO LC03-HOR. */
            _.Move(WORK_AREA.WS_TIME_R.WS_HOR, WORK_AREA.LC03.LC03_HOR);

            /*" -676- MOVE WS-MIN TO LC03-MIN. */
            _.Move(WORK_AREA.WS_TIME_R.WS_MIN, WORK_AREA.LC03.LC03_MIN);

            /*" -678- MOVE WS-SEG TO LC03-SEG. */
            _.Move(WORK_AREA.WS_TIME_R.WS_SEG, WORK_AREA.LC03.LC03_SEG);

            /*" -680- MOVE '011' TO WNR-EXEC-SQL. */
            _.Move("011", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -680- MOVE ZEROS TO V0PROD-NRMSAF. */
            _.Move(0, V0PROD_NRMSAF);

        }

        [StopWatch]
        /*" R0100-00-SELECT-V1SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V1SISTEMA_DB_SELECT_1()
        {
            /*" -660- EXEC SQL SELECT CURRENT DATE INTO :V1SIST-DTHOJE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' END-EXEC. */

            var r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V1SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V1SIST_DTHOJE, V1SIST_DTHOJE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-SELECT-V0RELATORIOS-SECTION */
        private void R0200_00_SELECT_V0RELATORIOS_SECTION()
        {
            /*" -693- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -701- PERFORM R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1 */

            R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1();

            /*" -704- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -706- MOVE 'N' TO WTEM-SOLICITACAO. */
                _.Move("N", WORK_AREA.WTEM_SOLICITACAO);
            }


            /*" -708- MOVE V0RELA-DTREFERENCIA TO WS-DATA-CURSOR. */
            _.Move(V0RELA_DTREFERENCIA, WORK_AREA.WS_DATA_CURSOR);

            /*" -710- MOVE TAB-ULT-DIA(WS-MMCURSOR) TO WS-DDCURSOR. */
            _.Move(WORK_AREA.TAB_ULTIMOS_DIAS.TAB_DIA_MESES[WORK_AREA.WS_DATA_CURSOR.WS_MMCURSOR].TAB_ULT_DIA, WORK_AREA.WS_DATA_CURSOR.WS_DDCURSOR);

            /*" -710- MOVE WS-DATA-CURSOR TO V1SIST-DTMOVABE. */
            _.Move(WORK_AREA.WS_DATA_CURSOR, V1SIST_DTMOVABE);

        }

        [StopWatch]
        /*" R0200-00-SELECT-V0RELATORIOS-DB-SELECT-1 */
        public void R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1()
        {
            /*" -701- EXEC SQL SELECT DATA_REFERENCIA INTO :V0RELA-DTREFERENCIA FROM SEGUROS.V0RELATORIOS WHERE CODRELAT = 'VA1417B' AND SITUACAO = '0' END-EXEC. */

            var r0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1 = new R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1.Execute(r0200_00_SELECT_V0RELATORIOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RELA_DTREFERENCIA, V0RELA_DTREFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTREPSAF-SECTION */
        private void R0900_00_DECLARE_V0HISTREPSAF_SECTION()
        {
            /*" -723- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -755- PERFORM R0900_00_DECLARE_V0HISTREPSAF_DB_DECLARE_1 */

            R0900_00_DECLARE_V0HISTREPSAF_DB_DECLARE_1();

            /*" -757- PERFORM R0900_00_DECLARE_V0HISTREPSAF_DB_OPEN_1 */

            R0900_00_DECLARE_V0HISTREPSAF_DB_OPEN_1();

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTREPSAF-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0HISTREPSAF_DB_DECLARE_1()
        {
            /*" -755- EXEC SQL DECLARE CREPAS CURSOR FOR SELECT A.NUM_APOLICE, A.CODSUBES, A.DTQITBCO, D.COD_CLIENTE, B.CODCLIEN, B.DTREF, B.NRCERTIF, B.NRPARCEL, B.NRMATRFUN, B.VLCUSTAUX, B.CODOPER, B.DTMOVTO FROM SEGUROS.V0PROPOSTAVA A, SEGUROS.V0HISTREPSAF B, SEGUROS.V0PRODUTOSVG C, SEGUROS.V0SUBGRUPO D WHERE C.COD_SEGU_SAF = 2 AND C.DIA_FATURA = 31 AND A.NUM_APOLICE = C.NUM_APOLICE AND A.CODSUBES = C.CODSUBES AND A.NUM_APOLICE = D.NUM_APOLICE AND A.CODSUBES = D.COD_SUBGRUPO AND B.NRCERTIF = A.NRCERTIF AND B.CODCLIEN = A.CODCLIEN AND B.SITUACAO = '0' AND B.DTREF <= :V1SIST-DTMOVABE ORDER BY A.NUM_APOLICE, A.CODSUBES END-EXEC. */
            CREPAS = new VA5419B_CREPAS(true);
            string GetQuery_CREPAS()
            {
                var query = @$"SELECT 
							A.NUM_APOLICE
							, 
							A.CODSUBES
							, 
							A.DTQITBCO
							, 
							D.COD_CLIENTE
							, 
							B.CODCLIEN
							, 
							B.DTREF
							, 
							B.NRCERTIF
							, 
							B.NRPARCEL
							, 
							B.NRMATRFUN
							, 
							B.VLCUSTAUX
							, 
							B.CODOPER
							, 
							B.DTMOVTO 
							FROM SEGUROS.V0PROPOSTAVA A
							, 
							SEGUROS.V0HISTREPSAF B
							, 
							SEGUROS.V0PRODUTOSVG C
							, 
							SEGUROS.V0SUBGRUPO D 
							WHERE C.COD_SEGU_SAF = 2 
							AND C.DIA_FATURA = 31 
							AND A.NUM_APOLICE = C.NUM_APOLICE 
							AND A.CODSUBES = C.CODSUBES 
							AND A.NUM_APOLICE = D.NUM_APOLICE 
							AND A.CODSUBES = D.COD_SUBGRUPO 
							AND B.NRCERTIF = A.NRCERTIF 
							AND B.CODCLIEN = A.CODCLIEN 
							AND B.SITUACAO = '0' 
							AND B.DTREF <= '{V1SIST_DTMOVABE}' 
							ORDER BY 
							A.NUM_APOLICE
							, 
							A.CODSUBES";

                return query;
            }
            CREPAS.GetQueryEvent += GetQuery_CREPAS;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTREPSAF-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0HISTREPSAF_DB_OPEN_1()
        {
            /*" -757- EXEC SQL OPEN CREPAS END-EXEC. */

            CREPAS.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTREPSAF-SECTION */
        private void R0910_00_FETCH_V0HISTREPSAF_SECTION()
        {
            /*" -770- MOVE '091' TO WNR-EXEC-SQL. */
            _.Move("091", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -784- PERFORM R0910_00_FETCH_V0HISTREPSAF_DB_FETCH_1 */

            R0910_00_FETCH_V0HISTREPSAF_DB_FETCH_1();

            /*" -787- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -788- MOVE 'S' TO WFIM-V0HISTREPSAF */
                _.Move("S", WORK_AREA.WFIM_V0HISTREPSAF);

                /*" -788- PERFORM R0910_00_FETCH_V0HISTREPSAF_DB_CLOSE_1 */

                R0910_00_FETCH_V0HISTREPSAF_DB_CLOSE_1();

                /*" -790- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

                /*" -791- DISPLAY '*** LIDOS V0HISTREPSAF ' AC-LIDOS ' ' WS-TIME */

                $"*** LIDOS V0HISTREPSAF {WORK_AREA.AC_LIDOS} {WORK_AREA.WS_TIME}"
                .Display();

                /*" -793- MOVE ZEROS TO AC-CONTA AC-LIDOS */
                _.Move(0, WORK_AREA.AC_CONTA, WORK_AREA.AC_LIDOS);

                /*" -795- GO TO R0910-99-SAIDA. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/ //GOTO
                return;
            }


            /*" -798- ADD 1 TO AC-LIDOS AC-CONTA. */
            WORK_AREA.AC_LIDOS.Value = WORK_AREA.AC_LIDOS + 1;
            WORK_AREA.AC_CONTA.Value = WORK_AREA.AC_CONTA + 1;

            /*" -799- IF AC-CONTA > 4999 */

            if (WORK_AREA.AC_CONTA > 4999)
            {

                /*" -800- MOVE ZEROS TO AC-CONTA */
                _.Move(0, WORK_AREA.AC_CONTA);

                /*" -801- ACCEPT WS-TIME FROM TIME */
                _.Move(_.AcceptDate("TIME"), WORK_AREA.WS_TIME);

                /*" -801- DISPLAY '*** LIDOS V0HISTREPSAF ' AC-LIDOS ' ' WS-TIME. */

                $"*** LIDOS V0HISTREPSAF {WORK_AREA.AC_LIDOS} {WORK_AREA.WS_TIME}"
                .Display();
            }


        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTREPSAF-DB-FETCH-1 */
        public void R0910_00_FETCH_V0HISTREPSAF_DB_FETCH_1()
        {
            /*" -784- EXEC SQL FETCH CREPAS INTO :V0RSAF-NUM-APOLICE, :V0RSAF-CODSUBES, :V0RSAF-DTQITBCO, :V0RSAF-CODCLIEN-SUB, :V0RSAF-CODCLIEN, :V0RSAF-DTREF, :V0RSAF-NRCERTIF, :V0RSAF-NRPARCEL, :V0RSAF-NRMATRFUN, :V0RSAF-VLCUSTAUXF, :V0RSAF-CODOPER, :V0RSAF-DTMOVTO:VIND-DTMOVTO END-EXEC. */

            if (CREPAS.Fetch())
            {
                _.Move(CREPAS.V0RSAF_NUM_APOLICE, V0RSAF_NUM_APOLICE);
                _.Move(CREPAS.V0RSAF_CODSUBES, V0RSAF_CODSUBES);
                _.Move(CREPAS.V0RSAF_DTQITBCO, V0RSAF_DTQITBCO);
                _.Move(CREPAS.V0RSAF_CODCLIEN_SUB, V0RSAF_CODCLIEN_SUB);
                _.Move(CREPAS.V0RSAF_CODCLIEN, V0RSAF_CODCLIEN);
                _.Move(CREPAS.V0RSAF_DTREF, V0RSAF_DTREF);
                _.Move(CREPAS.V0RSAF_NRCERTIF, V0RSAF_NRCERTIF);
                _.Move(CREPAS.V0RSAF_NRPARCEL, V0RSAF_NRPARCEL);
                _.Move(CREPAS.V0RSAF_NRMATRFUN, V0RSAF_NRMATRFUN);
                _.Move(CREPAS.V0RSAF_VLCUSTAUXF, V0RSAF_VLCUSTAUXF);
                _.Move(CREPAS.V0RSAF_CODOPER, V0RSAF_CODOPER);
                _.Move(CREPAS.V0RSAF_DTMOVTO, V0RSAF_DTMOVTO);
                _.Move(CREPAS.VIND_DTMOVTO, VIND_DTMOVTO);
            }

        }

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTREPSAF-DB-CLOSE-1 */
        public void R0910_00_FETCH_V0HISTREPSAF_DB_CLOSE_1()
        {
            /*" -788- EXEC SQL CLOSE CREPAS END-EXEC */

            CREPAS.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-SECTION */
        private void R1000_00_PROCESSA_REGISTRO_SECTION()
        {
            /*" -814- MOVE ZEROS TO REGISTRO-SAF. */
            _.Move(0, WORK_AREA.REGISTRO_SAF);

            /*" -815- IF V0RSAF-NUM-APOLANT NOT EQUAL V0RSAF-NUM-APOLICE */

            if (V0RSAF_NUM_APOLANT != V0RSAF_NUM_APOLICE)
            {

                /*" -816- PERFORM R2000-00-GERA-RELATORIO */

                R2000_00_GERA_RELATORIO_SECTION();

                /*" -817- PERFORM R0050-00-SELECT-DTEFERENCIA */

                R0050_00_SELECT_DTEFERENCIA_SECTION();

                /*" -818- MOVE V0RSAF-NUM-APOLICE TO V0RSAF-NUM-APOLANT */
                _.Move(V0RSAF_NUM_APOLICE, V0RSAF_NUM_APOLANT);

                /*" -819- MOVE V0RSAF-CODSUBES TO V0RSAF-CODSUBESANT */
                _.Move(V0RSAF_CODSUBES, V0RSAF_CODSUBESANT);

                /*" -820- MOVE V0RSAF-CODCLIEN-SUB TO V0RSAF-CODCLIEN-ANT */
                _.Move(V0RSAF_CODCLIEN_SUB, V0RSAF_CODCLIEN_ANT);

                /*" -825- MOVE ZEROS TO TOTAIS-PRODUTOS TOTAIS-GERAIS. */
                _.Move(0, TOTAIS_PRODUTOS, TOTAIS_GERAIS);
            }


            /*" -826- IF V0RSAF-CODSUBESANT NOT EQUAL V0RSAF-CODSUBES */

            if (V0RSAF_CODSUBESANT != V0RSAF_CODSUBES)
            {

                /*" -827- PERFORM R2000-00-GERA-RELATORIO */

                R2000_00_GERA_RELATORIO_SECTION();

                /*" -828- PERFORM R0050-00-SELECT-DTEFERENCIA */

                R0050_00_SELECT_DTEFERENCIA_SECTION();

                /*" -829- MOVE V0RSAF-CODSUBES TO V0RSAF-CODSUBESANT */
                _.Move(V0RSAF_CODSUBES, V0RSAF_CODSUBESANT);

                /*" -830- MOVE V0RSAF-CODCLIEN-SUB TO V0RSAF-CODCLIEN-ANT */
                _.Move(V0RSAF_CODCLIEN_SUB, V0RSAF_CODCLIEN_ANT);

                /*" -833- MOVE ZEROS TO TOTAIS-PRODUTOS TOTAIS-GERAIS. */
                _.Move(0, TOTAIS_PRODUTOS, TOTAIS_GERAIS);
            }


            /*" -834- PERFORM R1100-00-SELECT-V0CLIENTE */

            R1100_00_SELECT_V0CLIENTE_SECTION();

            /*" -835- PERFORM R1200-00-SELECT-V0ENDERECOS */

            R1200_00_SELECT_V0ENDERECOS_SECTION();

            /*" -836- PERFORM R1300-00-SELECT-V0ENDOSSO */

            R1300_00_SELECT_V0ENDOSSO_SECTION();

            /*" -838- PERFORM R1400-00-SELECT-V0SAFCOBER */

            R1400_00_SELECT_V0SAFCOBER_SECTION();

            /*" -839- MOVE V0CLIE-NOME TO DET1-NOME */
            _.Move(V0CLIE_NOME, WORK_AREA.REG_DETALHE1.DET1_NOME);

            /*" -840- MOVE V0CLIE-CGCCPF TO DET1-CPF */
            _.Move(V0CLIE_CGCCPF, WORK_AREA.REG_DETALHE1.DET1_CPF);

            /*" -841- MOVE V0ENDE-ENDERECO TO DET1-ENDERECO */
            _.Move(V0ENDE_ENDERECO, WORK_AREA.REG_DETALHE1.DET1_ENDERECO);

            /*" -842- MOVE V0ENDE-BAIRRO TO DET1-BAIRRO */
            _.Move(V0ENDE_BAIRRO, WORK_AREA.REG_DETALHE1.DET1_BAIRRO);

            /*" -843- MOVE V0ENDE-CIDADE TO DET1-CIDADE */
            _.Move(V0ENDE_CIDADE, WORK_AREA.REG_DETALHE1.DET1_CIDADE);

            /*" -844- MOVE V0ENDE-UF TO DET1-UF */
            _.Move(V0ENDE_UF, WORK_AREA.REG_DETALHE1.DET1_UF);

            /*" -845- MOVE V0ENDE-CEP TO WS-CEP */
            _.Move(V0ENDE_CEP, WORK_AREA.WS_CEP);

            /*" -846- MOVE WS-NRCEP TO DET1-CEP */
            _.Move(WORK_AREA.WS_CEP_R.WS_NRCEP, WORK_AREA.REG_DETALHE1.DET1_CEP);

            /*" -847- MOVE ZEROS TO DET1-TELEFONE */
            _.Move(0, WORK_AREA.REG_DETALHE1.DET1_TELEFONE);

            /*" -848- MOVE 9512 TO DET1-SEGURADORA */
            _.Move(9512, WORK_AREA.REG_DETALHE1.DET1_SEGURADORA);

            /*" -850- MOVE 280 TO DET1-SUCURSAL */
            _.Move(280, WORK_AREA.REG_DETALHE1.DET1_SUCURSAL);

            /*" -851- IF V0ENDO-RAMO EQUAL 81 */

            if (V0ENDO_RAMO == 81)
            {

                /*" -852- MOVE 523 TO DET1-CARTEIRA */
                _.Move(523, WORK_AREA.REG_DETALHE1.DET1_CARTEIRA);

                /*" -853- ELSE */
            }
            else
            {


                /*" -855- MOVE 906 TO DET1-CARTEIRA. */
                _.Move(906, WORK_AREA.REG_DETALHE1.DET1_CARTEIRA);
            }


            /*" -856- MOVE V0RSAF-NUM-APOLICE TO DET1-APOLICE */
            _.Move(V0RSAF_NUM_APOLICE, WORK_AREA.REG_DETALHE1.DET1_APOLICE);

            /*" -857- MOVE V0RSAF-CODCLIEN TO DET1-NRCERTIF */
            _.Move(V0RSAF_CODCLIEN, WORK_AREA.REG_DETALHE1.DET1_NRCERTIF);

            /*" -860- MOVE ZEROS TO DET1-CONSTANTE */
            _.Move(0, WORK_AREA.REG_DETALHE1.DET1_CONSTANTE);

            /*" -862- IF V0RSAF-CODOPER > 99 AND V0RSAF-CODOPER < 200 */

            if (V0RSAF_CODOPER > 99 && V0RSAF_CODOPER < 200)
            {

                /*" -863- MOVE V0RSAF-DTQITBCO TO DATA-SQL */
                _.Move(V0RSAF_DTQITBCO, WORK_AREA.DATA_SQL);

                /*" -864- ELSE */
            }
            else
            {


                /*" -866- MOVE V0SAFC-DTINIVIG TO DATA-SQL. */
                _.Move(V0SAFC_DTINIVIG, WORK_AREA.DATA_SQL);
            }


            /*" -867- MOVE ANO-SQL TO ANO-FIL */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.DATA_FIL.ANO_FIL);

            /*" -868- MOVE MES-SQL TO MES-FIL */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.DATA_FIL.MES_FIL);

            /*" -869- MOVE DIA-SQL TO DIA-FIL */
            _.Move(WORK_AREA.DATA_SQL.DIA_SQL, WORK_AREA.DATA_FIL.DIA_FIL);

            /*" -871- MOVE DATA-FIL TO DET1-DTINIVIG */
            _.Move(WORK_AREA.DATA_FIL, WORK_AREA.REG_DETALHE1.DET1_DTINIVIG);

            /*" -873- MOVE 991231 TO DET1-DTTERVIG */
            _.Move(991231, WORK_AREA.REG_DETALHE1.DET1_DTTERVIG);

            /*" -874- MOVE V0ENDO-DTEMIS TO DATA-SQL */
            _.Move(V0ENDO_DTEMIS, WORK_AREA.DATA_SQL);

            /*" -875- MOVE ANO-SQL TO ANO-FIL */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.DATA_FIL.ANO_FIL);

            /*" -876- MOVE MES-SQL TO MES-FIL */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.DATA_FIL.MES_FIL);

            /*" -877- MOVE DIA-SQL TO DIA-FIL */
            _.Move(WORK_AREA.DATA_SQL.DIA_SQL, WORK_AREA.DATA_FIL.DIA_FIL);

            /*" -879- MOVE DATA-FIL TO DET1-DTEMISAPOL. */
            _.Move(WORK_AREA.DATA_FIL, WORK_AREA.REG_DETALHE1.DET1_DTEMISAPOL);

            /*" -880- MOVE 'I' TO DET1-PLANO. */
            _.Move("I", WORK_AREA.REG_DETALHE1.DET1_PLANO);

            /*" -881- MOVE SPACES TO DET1-CONSTANTE-BR */
            _.Move("", WORK_AREA.REG_DETALHE1.DET1_CONSTANTE_BR);

            /*" -882- MOVE '01' TO DET1-CONSTANTE-01 */
            _.Move("01", WORK_AREA.REG_DETALHE1.DET1_CONSTANTE_01);

            /*" -883- MOVE '00' TO DET1-CONSTANTE-00 */
            _.Move("00", WORK_AREA.REG_DETALHE1.DET1_CONSTANTE_00);

            /*" -884- MOVE 'U' TO DET1-CONSTANTE-U */
            _.Move("U", WORK_AREA.REG_DETALHE1.DET1_CONSTANTE_U);

            /*" -885- MOVE SPACES TO DET1-CONSTANTE-BR1 */
            _.Move("", WORK_AREA.REG_DETALHE1.DET1_CONSTANTE_BR1);

            /*" -886- MOVE SPACES TO DET1-CONSTANTE-BR2 */
            _.Move("", WORK_AREA.REG_DETALHE1.DET1_CONSTANTE_BR2);

            /*" -887- MOVE WS-CPCEP TO DET1-COMPL-CEP. */
            _.Move(WORK_AREA.WS_CEP_R.WS_CPCEP, WORK_AREA.REG_DETALHE1.DET1_COMPL_CEP);

            /*" -889- MOVE '1' TO DET1-PADRA. */
            _.Move("1", WORK_AREA.REG_DETALHE1.DET1_PADRA);

            /*" -890- IF VIND-DTMOVTO < +0 */

            if (VIND_DTMOVTO < +0)
            {

                /*" -891- MOVE V0RSAF-DTREF TO DATA-SQL */
                _.Move(V0RSAF_DTREF, WORK_AREA.DATA_SQL);

                /*" -892- ELSE */
            }
            else
            {


                /*" -894- MOVE V0RSAF-DTMOVTO TO DATA-SQL. */
                _.Move(V0RSAF_DTMOVTO, WORK_AREA.DATA_SQL);
            }


            /*" -895- MOVE DIA-SQL TO DIA-DET. */
            _.Move(WORK_AREA.DATA_SQL.DIA_SQL, WORK_AREA.DATA_DET_R.DIA_DET);

            /*" -896- MOVE MES-SQL TO MES-DET. */
            _.Move(WORK_AREA.DATA_SQL.MES_SQL, WORK_AREA.DATA_DET_R.MES_DET);

            /*" -898- MOVE ANO-SQL TO ANO-DET. */
            _.Move(WORK_AREA.DATA_SQL.ANO_SQL, WORK_AREA.DATA_DET_R.ANO_DET);

            /*" -900- IF V0RSAF-CODOPER > 99 AND V0RSAF-CODOPER < 200 */

            if (V0RSAF_CODOPER > 99 && V0RSAF_CODOPER < 200)
            {

                /*" -901- MOVE 1 TO WIND */
                _.Move(1, WORK_AREA.WIND);

                /*" -902- MOVE 'I' TO DET1-TIPO-MOVTO */
                _.Move("I", WORK_AREA.REG_DETALHE1.DET1_TIPO_MOVTO);

                /*" -903- WRITE REG-FUND001I FROM REGISTRO-SAF */
                _.Move(WORK_AREA.REGISTRO_SAF.GetMoveValues(), REG_FUND001I);

                FUND001I.Write(REG_FUND001I.GetMoveValues().ToString());

                /*" -904- ELSE */
            }
            else
            {


                /*" -906- IF V0RSAF-CODOPER > 399 AND V0RSAF-CODOPER < 500 */

                if (V0RSAF_CODOPER > 399 && V0RSAF_CODOPER < 500)
                {

                    /*" -907- MOVE 2 TO WIND */
                    _.Move(2, WORK_AREA.WIND);

                    /*" -908- MOVE 'C' TO DET1-TIPO-MOVTO */
                    _.Move("C", WORK_AREA.REG_DETALHE1.DET1_TIPO_MOVTO);

                    /*" -909- WRITE REG-FUND001C FROM REGISTRO-SAF */
                    _.Move(WORK_AREA.REGISTRO_SAF.GetMoveValues(), REG_FUND001C);

                    FUND001C.Write(REG_FUND001C.GetMoveValues().ToString());

                    /*" -910- ELSE */
                }
                else
                {


                    /*" -912- IF V0RSAF-CODOPER > 499 AND V0RSAF-CODOPER < 600 */

                    if (V0RSAF_CODOPER > 499 && V0RSAF_CODOPER < 600)
                    {

                        /*" -913- MOVE 3 TO WIND */
                        _.Move(3, WORK_AREA.WIND);

                        /*" -914- MOVE 'R' TO DET1-TIPO-MOVTO */
                        _.Move("R", WORK_AREA.REG_DETALHE1.DET1_TIPO_MOVTO);

                        /*" -915- WRITE REG-FUND001R FROM REGISTRO-SAF */
                        _.Move(WORK_AREA.REGISTRO_SAF.GetMoveValues(), REG_FUND001R);

                        FUND001R.Write(REG_FUND001R.GetMoveValues().ToString());

                        /*" -916- ELSE */
                    }
                    else
                    {


                        /*" -918- IF V0RSAF-CODOPER > 999 AND V0RSAF-CODOPER < 1100 */

                        if (V0RSAF_CODOPER > 999 && V0RSAF_CODOPER < 1100)
                        {

                            /*" -919- MOVE 4 TO WIND */
                            _.Move(4, WORK_AREA.WIND);

                            /*" -920- ELSE */
                        }
                        else
                        {


                            /*" -922- IF V0RSAF-CODOPER > 1099 AND V0RSAF-CODOPER < 1200 */

                            if (V0RSAF_CODOPER > 1099 && V0RSAF_CODOPER < 1200)
                            {

                                /*" -923- MOVE 5 TO WIND */
                                _.Move(5, WORK_AREA.WIND);

                                /*" -925- MOVE 'A' TO DET1-TIPO-MOVTO */
                                _.Move("A", WORK_AREA.REG_DETALHE1.DET1_TIPO_MOVTO);

                                /*" -926- ELSE */
                            }
                            else
                            {


                                /*" -928- IF V0RSAF-CODOPER > 1799 AND V0RSAF-CODOPER < 1900 */

                                if (V0RSAF_CODOPER > 1799 && V0RSAF_CODOPER < 1900)
                                {

                                    /*" -929- GO TO R1000-10-NEXT */

                                    R1000_10_NEXT(); //GOTO
                                    return;

                                    /*" -930- ELSE */
                                }
                                else
                                {


                                    /*" -932- DISPLAY 'VA5419B OPERACAO INESPERADA ' V0RSAF-NRCERTIF ' ' V0RSAF-CODOPER */

                                    $"VA5419B OPERACAO INESPERADA {V0RSAF_NRCERTIF} {V0RSAF_CODOPER}"
                                    .Display();

                                    /*" -934- GO TO R9999-00-ROT-ERRO. */

                                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                                    return;
                                }

                            }

                        }

                    }

                }

            }


            /*" -935- ADD 1 TO TOTP-QTVIDAS (WIND). */
            TOTAIS_PRODUTOS.TOTAL_PRODUTO[WORK_AREA.WIND].TOTP_QTVIDAS.Value = TOTAIS_PRODUTOS.TOTAL_PRODUTO[WORK_AREA.WIND].TOTP_QTVIDAS + 1;

            /*" -937- ADD V0RSAF-VLCUSTAUXF TO TOTP-VLSAFBRUTO (WIND). */
            TOTAIS_PRODUTOS.TOTAL_PRODUTO[WORK_AREA.WIND].TOTP_VLSAFBRUTO.Value = TOTAIS_PRODUTOS.TOTAL_PRODUTO[WORK_AREA.WIND].TOTP_VLSAFBRUTO + V0RSAF_VLCUSTAUXF;

            /*" -938- MOVE '108' TO WNR-EXEC-SQL */
            _.Move("108", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -946- PERFORM R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1 */

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1();

            /*" -948- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -950- DISPLAY '*** VA5419B PROBLEMAS NO ACESSO A V0HISTREPSAF ' V0RSAF-CODCLIEN */
                _.Display($"*** VA5419B PROBLEMAS NO ACESSO A V0HISTREPSAF {V0RSAF_CODCLIEN}");

                /*" -950- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R1000_10_NEXT */

            R1000_10_NEXT();

        }

        [StopWatch]
        /*" R1000-00-PROCESSA-REGISTRO-DB-UPDATE-1 */
        public void R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1()
        {
            /*" -946- EXEC SQL UPDATE SEGUROS.V0HISTREPSAF SET SITUACAO = '1' WHERE CODCLIEN = :V0RSAF-CODCLIEN AND DTREF = :V0RSAF-DTREF AND CODOPER = :V0RSAF-CODOPER AND NRCERTIF = :V0RSAF-NRCERTIF AND SITUACAO = '0' END-EXEC */

            var r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 = new R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1()
            {
                V0RSAF_CODCLIEN = V0RSAF_CODCLIEN.ToString(),
                V0RSAF_NRCERTIF = V0RSAF_NRCERTIF.ToString(),
                V0RSAF_CODOPER = V0RSAF_CODOPER.ToString(),
                V0RSAF_DTREF = V0RSAF_DTREF.ToString(),
            };

            R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1.Execute(r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1);

        }

        [StopWatch]
        /*" R1000-10-NEXT */
        private void R1000_10_NEXT(bool isPerform = false)
        {
            /*" -954- PERFORM R0910-00-FETCH-V0HISTREPSAF. */

            R0910_00_FETCH_V0HISTREPSAF_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-00-SELECT-V0CLIENTE-SECTION */
        private void R1100_00_SELECT_V0CLIENTE_SECTION()
        {
            /*" -967- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -974- PERFORM R1100_00_SELECT_V0CLIENTE_DB_SELECT_1 */

            R1100_00_SELECT_V0CLIENTE_DB_SELECT_1();

            /*" -977- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -979- DISPLAY '*** VA5419B PROBLEMAS NO ACESSO A V0CLIENTE  ' V0RSAF-CODCLIEN */
                _.Display($"*** VA5419B PROBLEMAS NO ACESSO A V0CLIENTE  {V0RSAF_CODCLIEN}");

                /*" -979- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1100-00-SELECT-V0CLIENTE-DB-SELECT-1 */
        public void R1100_00_SELECT_V0CLIENTE_DB_SELECT_1()
        {
            /*" -974- EXEC SQL SELECT NOME_RAZAO, CGCCPF INTO :V0CLIE-NOME, :V0CLIE-CGCCPF FROM SEGUROS.V0CLIENTE WHERE COD_CLIENTE = :V0RSAF-CODCLIEN END-EXEC. */

            var r1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 = new R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1()
            {
                V0RSAF_CODCLIEN = V0RSAF_CODCLIEN.ToString(),
            };

            var executed_1 = R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1.Execute(r1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME, V0CLIE_NOME);
                _.Move(executed_1.V0CLIE_CGCCPF, V0CLIE_CGCCPF);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R1200-00-SELECT-V0ENDERECOS-SECTION */
        private void R1200_00_SELECT_V0ENDERECOS_SECTION()
        {
            /*" -992- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1006- PERFORM R1200_00_SELECT_V0ENDERECOS_DB_SELECT_1 */

            R1200_00_SELECT_V0ENDERECOS_DB_SELECT_1();

            /*" -1009- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1011- DISPLAY '*** VA5419B PROBLEMAS NO ACESSO A V0ENDER    ' V0RSAF-CODCLIEN */
                _.Display($"*** VA5419B PROBLEMAS NO ACESSO A V0ENDER    {V0RSAF_CODCLIEN}");

                /*" -1011- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1200-00-SELECT-V0ENDERECOS-DB-SELECT-1 */
        public void R1200_00_SELECT_V0ENDERECOS_DB_SELECT_1()
        {
            /*" -1006- EXEC SQL SELECT ENDERECO, BAIRRO, CIDADE, SIGLA_UF, CEP INTO :V0ENDE-ENDERECO, :V0ENDE-BAIRRO, :V0ENDE-CIDADE, :V0ENDE-UF, :V0ENDE-CEP FROM SEGUROS.V0ENDERECOS WHERE COD_CLIENTE = :V0RSAF-CODCLIEN AND OCORR_ENDERECO = 1 END-EXEC. */

            var r1200_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1 = new R1200_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1()
            {
                V0RSAF_CODCLIEN = V0RSAF_CODCLIEN.ToString(),
            };

            var executed_1 = R1200_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1.Execute(r1200_00_SELECT_V0ENDERECOS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDE_ENDERECO, V0ENDE_ENDERECO);
                _.Move(executed_1.V0ENDE_BAIRRO, V0ENDE_BAIRRO);
                _.Move(executed_1.V0ENDE_CIDADE, V0ENDE_CIDADE);
                _.Move(executed_1.V0ENDE_UF, V0ENDE_UF);
                _.Move(executed_1.V0ENDE_CEP, V0ENDE_CEP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1200_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDOSSO-SECTION */
        private void R1300_00_SELECT_V0ENDOSSO_SECTION()
        {
            /*" -1024- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1034- PERFORM R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1 */

            R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1();

            /*" -1037- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1039- DISPLAY '*** VA5419B PROBLEMAS NO ACESSO A V0ENDOSSO  ' V0RSAF-NUM-APOLICE */
                _.Display($"*** VA5419B PROBLEMAS NO ACESSO A V0ENDOSSO  {V0RSAF_NUM_APOLICE}");

                /*" -1039- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0ENDOSSO-DB-SELECT-1 */
        public void R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1()
        {
            /*" -1034- EXEC SQL SELECT A.DTEMIS, B.RAMO INTO :V0ENDO-DTEMIS, :V0ENDO-RAMO FROM SEGUROS.V0ENDOSSO A, SEGUROS.V0APOLICE B WHERE A.NUM_APOLICE = :V0RSAF-NUM-APOLICE AND A.NRENDOS = 0 AND A.NUM_APOLICE = B.NUM_APOLICE END-EXEC. */

            var r1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 = new R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1()
            {
                V0RSAF_NUM_APOLICE = V0RSAF_NUM_APOLICE.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0ENDO_DTEMIS, V0ENDO_DTEMIS);
                _.Move(executed_1.V0ENDO_RAMO, V0ENDO_RAMO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1400-00-SELECT-V0SAFCOBER-SECTION */
        private void R1400_00_SELECT_V0SAFCOBER_SECTION()
        {
            /*" -1052- MOVE '140' TO WNR-EXEC-SQL. */
            _.Move("140", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1058- PERFORM R1400_00_SELECT_V0SAFCOBER_DB_SELECT_1 */

            R1400_00_SELECT_V0SAFCOBER_DB_SELECT_1();

            /*" -1061- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1062- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1075- PERFORM R1400_00_SELECT_V0SAFCOBER_DB_INSERT_1 */

                    R1400_00_SELECT_V0SAFCOBER_DB_INSERT_1();

                    /*" -1077- IF SQLCODE NOT EQUAL ZEROS */

                    if (DB.SQLCODE != 00)
                    {

                        /*" -1079- DISPLAY '*** VA5419B PROBLEMAS INSERT V0SAFCOBER ' V0RSAF-NUM-APOLICE ' ' V0RSAF-CODCLIEN */

                        $"*** VA5419B PROBLEMAS INSERT V0SAFCOBER {V0RSAF_NUM_APOLICE} {V0RSAF_CODCLIEN}"
                        .Display();

                        /*" -1080- GO TO R9999-00-ROT-ERRO */

                        R9999_00_ROT_ERRO_SECTION(); //GOTO
                        return;

                        /*" -1081- END-IF */
                    }


                    /*" -1082- MOVE V0RSAF-DTREF TO V0SAFC-DTINIVIG */
                    _.Move(V0RSAF_DTREF, V0SAFC_DTINIVIG);

                    /*" -1083- ELSE */
                }
                else
                {


                    /*" -1085- DISPLAY '*** VA5419B PROBLEMAS NO ACESSO A V0SAFCOBER ' V0RSAF-NUM-APOLICE ' ' V0RSAF-CODCLIEN */

                    $"*** VA5419B PROBLEMAS NO ACESSO A V0SAFCOBER {V0RSAF_NUM_APOLICE} {V0RSAF_CODCLIEN}"
                    .Display();

                    /*" -1085- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-V0SAFCOBER-DB-SELECT-1 */
        public void R1400_00_SELECT_V0SAFCOBER_DB_SELECT_1()
        {
            /*" -1058- EXEC SQL SELECT DTINIVIG INTO :V0SAFC-DTINIVIG FROM SEGUROS.V0SAFCOBER WHERE CODCLIEN = :V0RSAF-CODCLIEN AND DTTERVIG = '9999-12-31' END-EXEC. */

            var r1400_00_SELECT_V0SAFCOBER_DB_SELECT_1_Query1 = new R1400_00_SELECT_V0SAFCOBER_DB_SELECT_1_Query1()
            {
                V0RSAF_CODCLIEN = V0RSAF_CODCLIEN.ToString(),
            };

            var executed_1 = R1400_00_SELECT_V0SAFCOBER_DB_SELECT_1_Query1.Execute(r1400_00_SELECT_V0SAFCOBER_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SAFC_DTINIVIG, V0SAFC_DTINIVIG);
            }


        }

        [StopWatch]
        /*" R1400-00-SELECT-V0SAFCOBER-DB-INSERT-1 */
        public void R1400_00_SELECT_V0SAFCOBER_DB_INSERT_1()
        {
            /*" -1075- EXEC SQL INSERT INTO SEGUROS.V0SAFCOBER VALUES(:V0RSAF-CODCLIEN, :V0RSAF-DTREF, '9999-12-31' , 3000.00, :V0RSAF-VLCUSTAUXF, :V0RSAF-NRCERTIF, 0, '0' , 'VA5419B' , CURRENT TIMESTAMP) END-EXEC */

            var r1400_00_SELECT_V0SAFCOBER_DB_INSERT_1_Insert1 = new R1400_00_SELECT_V0SAFCOBER_DB_INSERT_1_Insert1()
            {
                V0RSAF_CODCLIEN = V0RSAF_CODCLIEN.ToString(),
                V0RSAF_DTREF = V0RSAF_DTREF.ToString(),
                V0RSAF_VLCUSTAUXF = V0RSAF_VLCUSTAUXF.ToString(),
                V0RSAF_NRCERTIF = V0RSAF_NRCERTIF.ToString(),
            };

            R1400_00_SELECT_V0SAFCOBER_DB_INSERT_1_Insert1.Execute(r1400_00_SELECT_V0SAFCOBER_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1400_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-GERA-RELATORIO-SECTION */
        private void R2000_00_GERA_RELATORIO_SECTION()
        {
            /*" -1097- PERFORM R5000-00-CABECALHOS. */

            R5000_00_CABECALHOS_SECTION();

            /*" -1099- MOVE '200' TO WNR-EXEC-SQL. */
            _.Move("200", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1108- PERFORM R2000_00_GERA_RELATORIO_DB_SELECT_1 */

            R2000_00_GERA_RELATORIO_DB_SELECT_1();

            /*" -1111- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1112- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -1114- MOVE ZEROS TO V0RSAF1-VLCUSTAUXF V0RSAF1-NLMSAF */
                    _.Move(0, V0RSAF1_VLCUSTAUXF, V0RSAF1_NLMSAF);

                    /*" -1116- ELSE */
                }
                else
                {


                    /*" -1117- DISPLAY '*** VA5419B PROBLEMAS NO ACESSO A V0HISTREPSAF ' */
                    _.Display($"*** VA5419B PROBLEMAS NO ACESSO A V0HISTREPSAF ");

                    /*" -1119- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1122- MOVE 'SEGUROS VIGENTES NO MES' TO LD01-OPERACAO. */
            _.Move("SEGUROS VIGENTES NO MES", WORK_AREA.LD01.LD01_OPERACAO);

            /*" -1124- COMPUTE WS-VLIRRF = V0RSAF1-VLCUSTAUXF * (1,50 / 100) */
            WORK_AREA.WS_VLIRRF.Value = V0RSAF1_VLCUSTAUXF * (1.50 / 100f);

            /*" -1126- COMPUTE WS-VLDA = (V0RSAF1-VLCUSTAUXF - WS-VLIRRF) * 0,1 */
            WORK_AREA.WS_VLDA.Value = (V0RSAF1_VLCUSTAUXF - WORK_AREA.WS_VLIRRF) * 0.1;

            /*" -1128- COMPUTE WS-VLSAFLIQ = V0RSAF1-VLCUSTAUXF - WS-VLIRRF - WS-VLDA. */
            WORK_AREA.WS_VLSAFLIQ.Value = V0RSAF1_VLCUSTAUXF - WORK_AREA.WS_VLIRRF - WORK_AREA.WS_VLDA;

            /*" -1129- MOVE V0RSAF1-NLMSAF TO LD01-QTVIDAS. */
            _.Move(V0RSAF1_NLMSAF, WORK_AREA.LD01.LD01_QTVIDAS);

            /*" -1130- MOVE V0RSAF1-VLCUSTAUXF TO LD01-VLSAFBRUTO. */
            _.Move(V0RSAF1_VLCUSTAUXF, WORK_AREA.LD01.LD01_VLSAFBRUTO);

            /*" -1131- MOVE WS-VLIRRF TO LD01-VLIRRF. */
            _.Move(WORK_AREA.WS_VLIRRF, WORK_AREA.LD01.LD01_VLIRRF);

            /*" -1132- MOVE WS-VLDA TO LD01-VLDA. */
            _.Move(WORK_AREA.WS_VLDA, WORK_AREA.LD01.LD01_VLDA);

            /*" -1133- MOVE WS-VLSAFLIQ TO LD01-VLSAFLIQ. */
            _.Move(WORK_AREA.WS_VLSAFLIQ, WORK_AREA.LD01.LD01_VLSAFLIQ);

            /*" -1135- WRITE REG-IMPRESSAO FROM LD01 AFTER 2. */
            _.Move(WORK_AREA.LD01.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1137- MOVE SPACES TO REGISTRO-SAF. */
            _.Move("", WORK_AREA.REGISTRO_SAF);

            /*" -1140- PERFORM R2100-00-IMPRIME VARYING WIND FROM 1 BY 1 UNTIL WIND > 4. */

            for (WORK_AREA.WIND.Value = 1; !(WORK_AREA.WIND > 4); WORK_AREA.WIND.Value += 1)
            {

                R2100_00_IMPRIME_SECTION();
            }

            /*" -1145- COMPUTE WS-QTVIDAS = V0RSAF1-NLMSAF + TOTP-QTVIDAS (1) - TOTP-QTVIDAS (2) + TOTP-QTVIDAS (3) - TOTP-QTVIDAS (4). */
            WORK_AREA.WS_QTVIDAS.Value = V0RSAF1_NLMSAF + TOTAIS_PRODUTOS.TOTAL_PRODUTO[1].TOTP_QTVIDAS.Value - TOTAIS_PRODUTOS.TOTAL_PRODUTO[2].TOTP_QTVIDAS.Value + TOTAIS_PRODUTOS.TOTAL_PRODUTO[3].TOTP_QTVIDAS.Value - TOTAIS_PRODUTOS.TOTAL_PRODUTO[4].TOTP_QTVIDAS.Value;

            /*" -1151- COMPUTE WS-VLCUSTSAF = V0RSAF1-VLCUSTAUXF + TOTP-VLSAFBRUTO (1) - TOTP-VLSAFBRUTO (2) + TOTP-VLSAFBRUTO (3) - TOTP-VLSAFBRUTO (4). */
            WORK_AREA.WS_VLCUSTSAF.Value = V0RSAF1_VLCUSTAUXF + TOTAIS_PRODUTOS.TOTAL_PRODUTO[1].TOTP_VLSAFBRUTO.Value - TOTAIS_PRODUTOS.TOTAL_PRODUTO[2].TOTP_VLSAFBRUTO.Value + TOTAIS_PRODUTOS.TOTAL_PRODUTO[3].TOTP_VLSAFBRUTO.Value - TOTAIS_PRODUTOS.TOTAL_PRODUTO[4].TOTP_VLSAFBRUTO.Value;

            /*" -1153- MOVE 'TOTAL DE SEGUROS' TO LD01-OPERACAO. */
            _.Move("TOTAL DE SEGUROS", WORK_AREA.LD01.LD01_OPERACAO);

            /*" -1156- COMPUTE WS-VLIRRF = WS-VLCUSTSAF * (1,50 / 100) */
            WORK_AREA.WS_VLIRRF.Value = WORK_AREA.WS_VLCUSTSAF * (1.50 / 100f);

            /*" -1158- COMPUTE WS-VLDA = (WS-VLCUSTSAF - WS-VLIRRF) * 0,1 */
            WORK_AREA.WS_VLDA.Value = (WORK_AREA.WS_VLCUSTSAF - WORK_AREA.WS_VLIRRF) * 0.1;

            /*" -1160- COMPUTE WS-VLSAFLIQ = WS-VLCUSTSAF - WS-VLIRRF - WS-VLDA. */
            WORK_AREA.WS_VLSAFLIQ.Value = WORK_AREA.WS_VLCUSTSAF - WORK_AREA.WS_VLIRRF - WORK_AREA.WS_VLDA;

            /*" -1162- MOVE WS-QTVIDAS TO LD01-QTVIDAS WHOST-QTVIDAS. */
            _.Move(WORK_AREA.WS_QTVIDAS, WORK_AREA.LD01.LD01_QTVIDAS, WHOST_QTVIDAS);

            /*" -1164- MOVE WS-VLCUSTSAF TO LD01-VLSAFBRUTO WHOST-VLCUSTAUXF. */
            _.Move(WORK_AREA.WS_VLCUSTSAF, WORK_AREA.LD01.LD01_VLSAFBRUTO, WHOST_VLCUSTAUXF);

            /*" -1165- MOVE WS-VLIRRF TO LD01-VLIRRF. */
            _.Move(WORK_AREA.WS_VLIRRF, WORK_AREA.LD01.LD01_VLIRRF);

            /*" -1166- MOVE WS-VLDA TO LD01-VLDA. */
            _.Move(WORK_AREA.WS_VLDA, WORK_AREA.LD01.LD01_VLDA);

            /*" -1167- MOVE WS-VLSAFLIQ TO LD01-VLSAFLIQ. */
            _.Move(WORK_AREA.WS_VLSAFLIQ, WORK_AREA.LD01.LD01_VLSAFLIQ);

            /*" -1169- WRITE REG-IMPRESSAO FROM LD01 AFTER 2. */
            _.Move(WORK_AREA.LD01.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1171- MOVE '201' TO WNR-EXEC-SQL. */
            _.Move("201", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1187- PERFORM R2000_00_GERA_RELATORIO_DB_INSERT_1 */

            R2000_00_GERA_RELATORIO_DB_INSERT_1();

            /*" -1190- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1191- DISPLAY '*** VA5419B PROBLEMAS NO INSERT A V0HISTREPSAF ' */
                _.Display($"*** VA5419B PROBLEMAS NO INSERT A V0HISTREPSAF ");

                /*" -1191- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R2000-00-GERA-RELATORIO-DB-SELECT-1 */
        public void R2000_00_GERA_RELATORIO_DB_SELECT_1()
        {
            /*" -1108- EXEC SQL SELECT VLCUSTAUX, NLMSAF INTO :V0RSAF1-VLCUSTAUXF, :V0RSAF1-NLMSAF FROM SEGUROS.V0HISTREPSAF WHERE CODCLIEN = :V0RSAF-CODCLIEN-ANT AND DTREF = :WHOST-DTREFANT AND CODOPER = 1800 END-EXEC. */

            var r2000_00_GERA_RELATORIO_DB_SELECT_1_Query1 = new R2000_00_GERA_RELATORIO_DB_SELECT_1_Query1()
            {
                V0RSAF_CODCLIEN_ANT = V0RSAF_CODCLIEN_ANT.ToString(),
                WHOST_DTREFANT = WHOST_DTREFANT.ToString(),
            };

            var executed_1 = R2000_00_GERA_RELATORIO_DB_SELECT_1_Query1.Execute(r2000_00_GERA_RELATORIO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0RSAF1_VLCUSTAUXF, V0RSAF1_VLCUSTAUXF);
                _.Move(executed_1.V0RSAF1_NLMSAF, V0RSAF1_NLMSAF);
            }


        }

        [StopWatch]
        /*" R2000-00-GERA-RELATORIO-DB-INSERT-1 */
        public void R2000_00_GERA_RELATORIO_DB_INSERT_1()
        {
            /*" -1187- EXEC SQL INSERT INTO SEGUROS.V0HISTREPSAF VALUES (:V0RSAF-CODCLIEN-ANT, :WHOST-DTREF, 0, 0, 0, :WHOST-VLCUSTAUXF, 1800, '1' , '0' , 0, :WHOST-QTVIDAS, 'VA5419B' , CURRENT TIMESTAMP, :WHOST-DTREF:VIND-DTMOVTO1) END-EXEC. */

            var r2000_00_GERA_RELATORIO_DB_INSERT_1_Insert1 = new R2000_00_GERA_RELATORIO_DB_INSERT_1_Insert1()
            {
                V0RSAF_CODCLIEN_ANT = V0RSAF_CODCLIEN_ANT.ToString(),
                WHOST_DTREF = WHOST_DTREF.ToString(),
                WHOST_VLCUSTAUXF = WHOST_VLCUSTAUXF.ToString(),
                WHOST_QTVIDAS = WHOST_QTVIDAS.ToString(),
                VIND_DTMOVTO1 = VIND_DTMOVTO1.ToString(),
            };

            R2000_00_GERA_RELATORIO_DB_INSERT_1_Insert1.Execute(r2000_00_GERA_RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-IMPRIME-SECTION */
        private void R2100_00_IMPRIME_SECTION()
        {
            /*" -1205- IF WIND = 1 */

            if (WORK_AREA.WIND == 1)
            {

                /*" -1206- MOVE 'SEGUROS INCLUIDOS NO MES' TO LD01-OPERACAO */
                _.Move("SEGUROS INCLUIDOS NO MES", WORK_AREA.LD01.LD01_OPERACAO);

                /*" -1207- ELSE */
            }
            else
            {


                /*" -1208- IF WIND = 2 */

                if (WORK_AREA.WIND == 2)
                {

                    /*" -1210- MOVE 'SEGUROS CANCELADOS NO MES' TO LD01-OPERACAO */
                    _.Move("SEGUROS CANCELADOS NO MES", WORK_AREA.LD01.LD01_OPERACAO);

                    /*" -1211- ELSE */
                }
                else
                {


                    /*" -1212- IF WIND = 3 */

                    if (WORK_AREA.WIND == 3)
                    {

                        /*" -1214- MOVE 'SEGUROS COM COBERTURA REABILITADA NO MES' TO LD01-OPERACAO */
                        _.Move("SEGUROS COM COBERTURA REABILITADA NO MES", WORK_AREA.LD01.LD01_OPERACAO);

                        /*" -1215- ELSE */
                    }
                    else
                    {


                        /*" -1216- IF WIND = 4 */

                        if (WORK_AREA.WIND == 4)
                        {

                            /*" -1218- MOVE 'SEGUROS COM COBERTURA SUSPENSA NO MES' TO LD01-OPERACAO */
                            _.Move("SEGUROS COM COBERTURA SUSPENSA NO MES", WORK_AREA.LD01.LD01_OPERACAO);

                            /*" -1219- ELSE */
                        }
                        else
                        {


                            /*" -1220- IF WIND = 5 */

                            if (WORK_AREA.WIND == 5)
                            {

                                /*" -1222- MOVE 'TOTAL DE SEGUROS' TO LD01-OPERACAO. */
                                _.Move("TOTAL DE SEGUROS", WORK_AREA.LD01.LD01_OPERACAO);
                            }

                        }

                    }

                }

            }


            /*" -1225- COMPUTE WS-VLIRRF = TOTP-VLSAFBRUTO (WIND) * (1,50 / 100) */
            WORK_AREA.WS_VLIRRF.Value = TOTAIS_PRODUTOS.TOTAL_PRODUTO[WORK_AREA.WIND].TOTP_VLSAFBRUTO.Value * (1.50 / 100f);

            /*" -1227- COMPUTE WS-VLDA = (TOTP-VLSAFBRUTO (WIND) - WS-VLIRRF) * 0,1 */
            WORK_AREA.WS_VLDA.Value = (TOTAIS_PRODUTOS.TOTAL_PRODUTO[WORK_AREA.WIND].TOTP_VLSAFBRUTO.Value - WORK_AREA.WS_VLIRRF) * 0.1;

            /*" -1229- COMPUTE WS-VLSAFLIQ = TOTP-VLSAFBRUTO (WIND) - WS-VLIRRF - WS-VLDA. */
            WORK_AREA.WS_VLSAFLIQ.Value = TOTAIS_PRODUTOS.TOTAL_PRODUTO[WORK_AREA.WIND].TOTP_VLSAFBRUTO.Value - WORK_AREA.WS_VLIRRF - WORK_AREA.WS_VLDA;

            /*" -1230- MOVE TOTP-QTVIDAS (WIND) TO LD01-QTVIDAS. */
            _.Move(TOTAIS_PRODUTOS.TOTAL_PRODUTO[WORK_AREA.WIND].TOTP_QTVIDAS, WORK_AREA.LD01.LD01_QTVIDAS);

            /*" -1231- MOVE TOTP-VLSAFBRUTO (WIND) TO LD01-VLSAFBRUTO. */
            _.Move(TOTAIS_PRODUTOS.TOTAL_PRODUTO[WORK_AREA.WIND].TOTP_VLSAFBRUTO, WORK_AREA.LD01.LD01_VLSAFBRUTO);

            /*" -1232- MOVE WS-VLIRRF TO LD01-VLIRRF. */
            _.Move(WORK_AREA.WS_VLIRRF, WORK_AREA.LD01.LD01_VLIRRF);

            /*" -1233- MOVE WS-VLDA TO LD01-VLDA. */
            _.Move(WORK_AREA.WS_VLDA, WORK_AREA.LD01.LD01_VLDA);

            /*" -1234- MOVE WS-VLSAFLIQ TO LD01-VLSAFLIQ. */
            _.Move(WORK_AREA.WS_VLSAFLIQ, WORK_AREA.LD01.LD01_VLSAFLIQ);

            /*" -1235- WRITE REG-IMPRESSAO FROM LD01 AFTER 2. */
            _.Move(WORK_AREA.LD01.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1236- ADD WS-VLIRRF TO TOTG-VLIRRF. */
            TOTAIS_GERAIS.TOTG_VLIRRF.Value = TOTAIS_GERAIS.TOTG_VLIRRF + WORK_AREA.WS_VLIRRF;

            /*" -1237- ADD WS-VLDA TO TOTG-VLDA. */
            TOTAIS_GERAIS.TOTG_VLDA.Value = TOTAIS_GERAIS.TOTG_VLDA + WORK_AREA.WS_VLDA;

            /*" -1238- ADD WS-VLSAFLIQ TO TOTG-VLSAFLIQ. */
            TOTAIS_GERAIS.TOTG_VLSAFLIQ.Value = TOTAIS_GERAIS.TOTG_VLSAFLIQ + WORK_AREA.WS_VLSAFLIQ;

            /*" -1239- ADD TOTP-QTVIDAS (WIND) TO TOTG-QTVIDAS. */
            TOTAIS_GERAIS.TOTG_QTVIDAS.Value = TOTAIS_GERAIS.TOTG_QTVIDAS + TOTAIS_PRODUTOS.TOTAL_PRODUTO[WORK_AREA.WIND].TOTP_QTVIDAS;

            /*" -1239- ADD TOTP-VLSAFBRUTO (WIND) TO TOTG-VLSAFBRUTO. */
            TOTAIS_GERAIS.TOTG_VLSAFBRUTO.Value = TOTAIS_GERAIS.TOTG_VLSAFBRUTO + TOTAIS_PRODUTOS.TOTAL_PRODUTO[WORK_AREA.WIND].TOTP_VLSAFBRUTO;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-CABECALHOS-SECTION */
        private void R5000_00_CABECALHOS_SECTION()
        {
            /*" -1252- PERFORM R999-NOME-APOLICE. */

            R999_NOME_APOLICE_SECTION();

            /*" -1253- MOVE ZEROS TO AC-LINHA. */
            _.Move(0, WORK_AREA.AC_LINHA);

            /*" -1254- ADD 1 TO AC-PAGINA. */
            WORK_AREA.AC_PAGINA.Value = WORK_AREA.AC_PAGINA + 1;

            /*" -1255- MOVE AC-PAGINA TO LC01-PAGINA. */
            _.Move(WORK_AREA.AC_PAGINA, WORK_AREA.LC01.LC01_PAGINA);

            /*" -1256- WRITE REG-IMPRESSAO FROM LC01 AFTER PAGE. */
            _.Move(WORK_AREA.LC01.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1257- WRITE REG-IMPRESSAO FROM LC02. */
            _.Move(WORK_AREA.LC02.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1258- WRITE REG-IMPRESSAO FROM LC03. */
            _.Move(WORK_AREA.LC03.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1259- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1260- WRITE REG-IMPRESSAO FROM LC03-1. */
            _.Move(WORK_AREA.LC03_1.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1261- WRITE REG-IMPRESSAO FROM TRACO. */
            _.Move(WORK_AREA.TRACO.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1262- WRITE REG-IMPRESSAO FROM LC04. */
            _.Move(WORK_AREA.LC04.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1263- WRITE REG-IMPRESSAO FROM LC05. */
            _.Move(WORK_AREA.LC05.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1264- WRITE REG-IMPRESSAO FROM TRACO. */
            _.Move(WORK_AREA.TRACO.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1265- WRITE REG-IMPRESSAO FROM LC07 AFTER 2. */
            _.Move(WORK_AREA.LC07.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

            /*" -1265- WRITE REG-IMPRESSAO FROM BRANCO. */
            _.Move(WORK_AREA.BRANCO.GetMoveValues(), REG_IMPRESSAO);

            RVA5419B.Write(REG_IMPRESSAO.GetMoveValues().ToString());

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R9800-00-ENCERRA-SEM-SOLIC-SECTION */
        private void R9800_00_ENCERRA_SEM_SOLIC_SECTION()
        {
            /*" -1278- DISPLAY '*------------------------------------------*' */
            _.Display($"*------------------------------------------*");

            /*" -1279- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1280- DISPLAY '*  VA5419B - EMISSAO RELATORIO REPASSE SAF *' */
            _.Display($"*  VA5419B - EMISSAO RELATORIO REPASSE SAF *");

            /*" -1281- DISPLAY '*  -------   ------- --------- ------- --- *' */
            _.Display($"*  -------   ------- --------- ------- --- *");

            /*" -1282- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1283- DISPLAY '*            NAO EXISTE SOLICITACAO        *' */
            _.Display($"*            NAO EXISTE SOLICITACAO        *");

            /*" -1284- DISPLAY '*                NESTA  DATA               *' */
            _.Display($"*                NESTA  DATA               *");

            /*" -1285- DISPLAY '*                                          *' */
            _.Display($"*                                          *");

            /*" -1285- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9800_99_SAIDA*/

        [StopWatch]
        /*" R999-NOME-APOLICE-SECTION */
        private void R999_NOME_APOLICE_SECTION()
        {
            /*" -1296- MOVE '999' TO WNR-EXEC-SQL. */
            _.Move("999", WORK_AREA.WABEND.WNR_EXEC_SQL);

            /*" -1303- PERFORM R999_NOME_APOLICE_DB_SELECT_1 */

            R999_NOME_APOLICE_DB_SELECT_1();

            /*" -1306- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1307- DISPLAY '*** VA5419B PROBLEMAS NO ACESSO A V0CLIENTE  ' */
                _.Display($"*** VA5419B PROBLEMAS NO ACESSO A V0CLIENTE  ");

                /*" -1308- DISPLAY '*** ERRO NA DESCRICAO DA APOLICE  ' */
                _.Display($"*** ERRO NA DESCRICAO DA APOLICE  ");

                /*" -1310- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1311- MOVE V0RSAF-NUM-APOLANT TO LC04-NUM-APOLICE */
            _.Move(V0RSAF_NUM_APOLANT, WORK_AREA.LC04.LC04_NUM_APOLICE);

            /*" -1314- MOVE V0CLIE-NOME TO LC04-NOME-APOLICE. */
            _.Move(V0CLIE_NOME, WORK_AREA.LC04.LC04_NOME_APOLICE);

            /*" -1322- PERFORM R999_NOME_APOLICE_DB_SELECT_2 */

            R999_NOME_APOLICE_DB_SELECT_2();

            /*" -1325- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1326- DISPLAY '*** VA5419B PROBLEMAS NO ACESSO A V0CLIENTE  ' */
                _.Display($"*** VA5419B PROBLEMAS NO ACESSO A V0CLIENTE  ");

                /*" -1327- DISPLAY '*** ERRO NA DESCRICAO DO SUBGRUPO ' */
                _.Display($"*** ERRO NA DESCRICAO DO SUBGRUPO ");

                /*" -1329- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1330- MOVE V0RSAF-CODSUBESANT TO LC05-COD-SUBGRUPO */
            _.Move(V0RSAF_CODSUBESANT, WORK_AREA.LC05.LC05_COD_SUBGRUPO);

            /*" -1330- MOVE V0CLIE-NOME TO LC05-NOME-SUBGRUPO. */
            _.Move(V0CLIE_NOME, WORK_AREA.LC05.LC05_NOME_SUBGRUPO);

        }

        [StopWatch]
        /*" R999-NOME-APOLICE-DB-SELECT-1 */
        public void R999_NOME_APOLICE_DB_SELECT_1()
        {
            /*" -1303- EXEC SQL SELECT B.NOME_RAZAO INTO :V0CLIE-NOME FROM SEGUROS.V0APOLICE A, SEGUROS.V0CLIENTE B WHERE A.NUM_APOLICE = :V0RSAF-NUM-APOLANT AND A.CODCLIEN = B.COD_CLIENTE END-EXEC. */

            var r999_NOME_APOLICE_DB_SELECT_1_Query1 = new R999_NOME_APOLICE_DB_SELECT_1_Query1()
            {
                V0RSAF_NUM_APOLANT = V0RSAF_NUM_APOLANT.ToString(),
            };

            var executed_1 = R999_NOME_APOLICE_DB_SELECT_1_Query1.Execute(r999_NOME_APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME, V0CLIE_NOME);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R999_99_SAIDA*/

        [StopWatch]
        /*" R999-NOME-APOLICE-DB-SELECT-2 */
        public void R999_NOME_APOLICE_DB_SELECT_2()
        {
            /*" -1322- EXEC SQL SELECT B.NOME_RAZAO INTO :V0CLIE-NOME FROM SEGUROS.V0SUBGRUPO A, SEGUROS.V0CLIENTE B WHERE A.NUM_APOLICE = :V0RSAF-NUM-APOLANT AND A.COD_SUBGRUPO = :V0RSAF-CODSUBESANT AND A.COD_CLIENTE = B.COD_CLIENTE END-EXEC. */

            var r999_NOME_APOLICE_DB_SELECT_2_Query1 = new R999_NOME_APOLICE_DB_SELECT_2_Query1()
            {
                V0RSAF_NUM_APOLANT = V0RSAF_NUM_APOLANT.ToString(),
                V0RSAF_CODSUBESANT = V0RSAF_CODSUBESANT.ToString(),
            };

            var executed_1 = R999_NOME_APOLICE_DB_SELECT_2_Query1.Execute(r999_NOME_APOLICE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0CLIE_NOME, V0CLIE_NOME);
            }


        }

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1345- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WORK_AREA.WABEND.WSQLCODE);

            /*" -1347- DISPLAY WABEND */
            _.Display(WORK_AREA.WABEND);

            /*" -1347- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -1349- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1353- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -1353- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}