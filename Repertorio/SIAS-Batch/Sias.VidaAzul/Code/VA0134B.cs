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
using Sias.VidaAzul.DB2.VA0134B;

namespace Code
{
    public class VA0134B
    {
        public bool IsCall { get; set; }

        public VA0134B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *  SISTEMA ...............  VIDA (SIAS)                          *      */
        /*"      *  PROGRAMA ..............  VA0134B                              *      */
        /*"      *  FINALIDADE:                                                   *      */
        /*"      *    1. GERAR RELATORIO DE CANCELAMENTOS POR SOLICITACAO         *      */
        /*"      *       DISRIMINANDO: 1. QUEM TEVE RESTITUICAO                   *      */
        /*"      *                     2. QUEM NAO TEVE                           *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORICO DE CORRECOES                                         *      */
        /*"      * ---------------------------------------------------------------*      */
        /*"      * VERSAO  DATA       RESPONSAVEL    DESCRICAO                    *      */
        /*"      * ------  ---------- -------------  -----------------------------*      */
        /*"      * 01.1    23.12.2019 NICODEMUS      CODIFICACAO INICIAL          *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _VA0134B1 { get; set; } = new FileBasis(new PIC("X", "480", "X(480)"));

        public FileBasis VA0134B1
        {
            get
            {
                _.Move(SAI_FD_VA0134B1, _VA0134B1); VarBasis.RedefinePassValue(SAI_FD_VA0134B1, _VA0134B1, SAI_FD_VA0134B1); return _VA0134B1;
            }
        }
        public FileBasis _VA0134B2 { get; set; } = new FileBasis(new PIC("X", "480", "X(480)"));

        public FileBasis VA0134B2
        {
            get
            {
                _.Move(SAI_FD_VA0134B2, _VA0134B2); VarBasis.RedefinePassValue(SAI_FD_VA0134B2, _VA0134B2, SAI_FD_VA0134B2); return _VA0134B2;
            }
        }
        /*"01  SAI-FD-VA0134B1                  PIC X(480).*/
        public StringBasis SAI_FD_VA0134B1 { get; set; } = new StringBasis(new PIC("X", "480", "X(480)."), @"");
        /*"01  SAI-FD-VA0134B2                  PIC X(480).*/
        public StringBasis SAI_FD_VA0134B2 { get; set; } = new StringBasis(new PIC("X", "480", "X(480)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WSS-VERSAO              PIC X(080) VALUE '01.1'.*/
        public StringBasis WSS_VERSAO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"01.1");
        /*"77 WS-DTPARM               PIC X(010) VALUE SPACES.*/
        public StringBasis WS_DTPARM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");

        /*"01  VARHOST.*/
        public VA0134B_VARHOST VARHOST { get; set; } = new VA0134B_VARHOST();
        public class VA0134B_VARHOST : VarBasis
        {
            /*"    03 WSS-NULL               COMP   PIC S9(04)    VALUE 0.*/
            public IntBasis WSS_NULL { get; set; } = new IntBasis(new PIC("X", "4", "S9(04)"));
            /*"    03 DB2-COD-SUSEP                 PIC X(025)    VALUE SPACE.*/
            public StringBasis DB2_COD_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"    03 DB2-SIT-COBRANCA              PIC X(001)    VALUE SPACE.*/
            public StringBasis DB2_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  VARFLAG.*/
        }
        public VA0134B_VARFLAG VARFLAG { get; set; } = new VA0134B_VARFLAG();
        public class VA0134B_VARFLAG : VarBasis
        {
            /*"    03 TABLE-STATUS                  PIC 9(001)    VALUE 0.*/

            public SelectorBasis TABLE_STATUS { get; set; } = new SelectorBasis("001", "0")
            {
                Items = new List<SelectorItemBasis> {
                            /*" 88 TOP-OF-TABLE                             VALUE 0. */
							new SelectorItemBasis("TOP_OF_TABLE", "0"),
							/*" 88 END-OF-TABLE                             VALUE 1. */
							new SelectorItemBasis("END_OF_TABLE", "1")
                }
            };

            /*"01  VARTEXT.*/
        }
        public VA0134B_VARTEXT VARTEXT { get; set; } = new VA0134B_VARTEXT();
        public class VA0134B_VARTEXT : VarBasis
        {
            /*"    03 WSS-MSG-ERRO                  PIC X(120).*/
            public StringBasis WSS_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)."), @"");
            /*"    03 WSS-DDD-CELULAR               PIC X(012).*/
            public StringBasis WSS_DDD_CELULAR { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"    03  FILLER REDEFINES    WSS-DDD-CELULAR.*/
            private _REDEF_VA0134B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA0134B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA0134B_FILLER_0(); _.Move(WSS_DDD_CELULAR, _filler_0); VarBasis.RedefinePassValue(WSS_DDD_CELULAR, _filler_0, WSS_DDD_CELULAR); _filler_0.ValueChanged += () => { _.Move(_filler_0, WSS_DDD_CELULAR); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WSS_DDD_CELULAR); }
            }  //Redefines
            public class _REDEF_VA0134B_FILLER_0 : VarBasis
            {
                /*"       05 WSS-COD-DDD                PIC 9(003).*/
                public IntBasis WSS_COD_DDD { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       05 WSS-NUM-TELEFONE           PIC 9(009).*/
                public IntBasis WSS_NUM_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"01  VARDISP.*/

                public _REDEF_VA0134B_FILLER_0()
                {
                    WSS_COD_DDD.ValueChanged += OnValueChanged;
                    WSS_NUM_TELEFONE.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA0134B_VARDISP VARDISP { get; set; } = new VA0134B_VARDISP();
        public class VA0134B_VARDISP : VarBasis
        {
            /*"    03 WSS-COD-ERRO                  PIC 9(004).*/
            public IntBasis WSS_COD_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 WSS-PSC-ERRO                  PIC 9(004).*/
            public IntBasis WSS_PSC_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 WSS-QTD-LIDOS                 PIC 9(009).*/
            public IntBasis WSS_QTD_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 WSS-QTD-COM                   PIC 9(009).*/
            public IntBasis WSS_QTD_COM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 WSS-QTD-SEM                   PIC 9(009).*/
            public IntBasis WSS_QTD_SEM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 WSS-QTD-DESP                  PIC 9(009).*/
            public IntBasis WSS_QTD_DESP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 WSS-QTD-WRITE                 PIC 9(009).*/
            public IntBasis WSS_QTD_WRITE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 WSS-COD-SQLC                  PIC -999.*/
            public IntBasis WSS_COD_SQLC { get; set; } = new IntBasis(new PIC("9", "3", "-999."));
            /*"01  WSS-FD-CABEC.*/
        }
        public VA0134B_WSS_FD_CABEC WSS_FD_CABEC { get; set; } = new VA0134B_WSS_FD_CABEC();
        public class VA0134B_WSS_FD_CABEC : VarBasis
        {
            /*"    03 PIC X(040) VALUE 'NOME'.*/
            public StringBasis PIC { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"NOME");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(014) VALUE 'CPF-CNPJ'.*/
            public StringBasis PIC_1 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"CPF-CNPJ");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(012) VALUE 'CELULAR'.*/
            public StringBasis PIC_3 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"CELULAR");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(010) VALUE 'VARIAVEL-1'.*/
            public StringBasis PIC_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VARIAVEL_1");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(010) VALUE 'VARIAVEL-2'.*/
            public StringBasis PIC_7 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VARIAVEL_2");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(010) VALUE 'VARIAVEL-3'.*/
            public StringBasis PIC_9 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VARIAVEL_3");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(010) VALUE 'VARIAVEL-4'.*/
            public StringBasis PIC_11 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VARIAVEL_4");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(010) VALUE 'VARIAVEL-5'.*/
            public StringBasis PIC_13 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VARIAVEL_5");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(072) VALUE 'LOGRADOURO'.*/
            public StringBasis PIC_15 { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"LOGRADOURO");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(072) VALUE 'BAIRRO'.*/
            public StringBasis PIC_17 { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"BAIRRO");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(072) VALUE 'CIDADE'.*/
            public StringBasis PIC_19 { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"CIDADE");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(002) VALUE 'UF'.*/
            public StringBasis PIC_21 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"UF");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(009) VALUE 'CEP'.*/
            public StringBasis PIC_23 { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"CEP");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_24 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(015) VALUE 'NUM-CONTRATO'.*/
            public StringBasis PIC_25 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"NUM_CONTRATO");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(011) VALUE 'COD-PRODUTO'.*/
            public StringBasis PIC_27 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"COD-PRODUTO");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(025) VALUE 'COD-SUSEP'.*/
            public StringBasis PIC_29 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"COD-SUSEP");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(012) VALUE 'COD-TEMPLATE'.*/
            public StringBasis PIC_31 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COD-TEMPLATE");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(040) VALUE 'EMAIL'.*/
            public StringBasis PIC_33 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"EMAIL");
            /*"01  WSS-FD-SAIDA.*/
        }
        public VA0134B_WSS_FD_SAIDA WSS_FD_SAIDA { get; set; } = new VA0134B_WSS_FD_SAIDA();
        public class VA0134B_WSS_FD_SAIDA : VarBasis
        {
            /*"    03 SAI-NOME                      PIC X(040).*/
            public StringBasis SAI_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-CPF-CNPJ                  PIC 9(014).*/
            public IntBasis SAI_CPF_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-CELULAR                   PIC X(012).*/
            public StringBasis SAI_CELULAR { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-VARIAVEL-1                PIC X(010).*/
            public StringBasis SAI_VARIAVEL_1 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-VARIAVEL-2                PIC X(010).*/
            public StringBasis SAI_VARIAVEL_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-VARIAVEL-3                PIC X(010).*/
            public StringBasis SAI_VARIAVEL_3 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-VARIAVEL-4                PIC X(010).*/
            public StringBasis SAI_VARIAVEL_4 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-VARIAVEL-5                PIC X(010).*/
            public StringBasis SAI_VARIAVEL_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-LOGRADOURO                PIC X(072).*/
            public StringBasis SAI_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-BAIRRO                    PIC X(072).*/
            public StringBasis SAI_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_43 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-CIDADE                    PIC X(072).*/
            public StringBasis SAI_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-UF                        PIC X(002).*/
            public StringBasis SAI_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_45 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-CEP                       PIC 9(009).*/
            public IntBasis SAI_CEP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-NUM-CONTRATO              PIC 9(015).*/
            public IntBasis SAI_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    03                               PIC X(007) VALUE ';'.*/
            public StringBasis PIC_47 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @";");
            /*"    03 SAI-COD-PRODUTO               PIC 9(004).*/
            public IntBasis SAI_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_48 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-COD-SUSEP                 PIC X(025).*/
            public StringBasis SAI_COD_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-COD-TEMPLATE              PIC X(012).*/
            public StringBasis SAI_COD_TEMPLATE { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_50 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-EMAIL                     PIC X(040).*/
            public StringBasis SAI_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
        }


        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.SEGVGAP SEGVGAP { get; set; } = new Dclgens.SEGVGAP();

        public VA0134B_C01 C01 { get; set; } = new VA0134B_C01(true);
        string GetQuery_C01()
        {
            var query = @$"SELECT VGAH.NUM_APOLICE
							, VGAP.NUM_CERTIFICADO
							, HLAN.CODRET
							, HLAN.TIPLANC
							, HLAN.CODCONV
							, HLAN.SIT_REGISTRO
							, HLAN.NUM_PARCELA
							, HLAN.DATA_VENCIMENTO
							, VAPP.COD_PRODUTO
							, VAPP.SIT_REGISTRO
							, VGAP.COD_CLIENTE
							, CLTE.CGCCPF
							, CLTE.NOME_RAZAO
							, ENDR.DDD
							, ENDR.TELEFONE
							, ENDR.ENDERECO
							, ENDR.BAIRRO
							, ENDR.CIDADE
							, ENDR.SIGLA_UF
							, ENDR.CEP
							, CLEM.EMAIL
							, PROD.NUM_PROCESSO_SUSEP
							, VGAP.DAC_COBRANCA
							FROM SEGUROS.SEGURADOSVGAP_HIST VGAH INNER
							JOIN SEGUROS.SEGURADOS_VGAP VGAP ON VGAP.NUM_APOLICE = VGAH.NUM_APOLICE AND VGAP.COD_SUBGRUPO = VGAH.COD_SUBGRUPO AND VGAP.NUM_ITEM = VGAH.NUM_ITEM INNER
							JOIN SEGUROS.HIST_LANC_CTA HLAN ON HLAN.NUM_CERTIFICADO = VGAP.NUM_CERTIFICADO INNER
							JOIN SEGUROS.PROPOSTAS_VA VAPP ON VAPP.NUM_CERTIFICADO = VGAP.NUM_CERTIFICADO AND VAPP.NUM_PARCELA = HLAN.NUM_PARCELA INNER
							JOIN SEGUROS.PRODUTO PROD ON PROD.COD_PRODUTO = VAPP.COD_PRODUTO INNER
							JOIN SEGUROS.CLIENTES CLTE ON CLTE.COD_CLIENTE = VGAP.COD_CLIENTE INNER
							JOIN SEGUROS.ENDERECOS ENDR ON ENDR.COD_CLIENTE = VGAP.COD_CLIENTE AND ENDR.OCORR_ENDERECO = VGAP.OCORR_ENDERECO INNER
							JOIN SEGUROS.CLIENTE_EMAIL CLEM ON CLEM.COD_CLIENTE = VGAP.COD_CLIENTE AND CLEM.SEQ_EMAIL = ( SELECT MAX(SEQ_EMAIL)
							FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = CLEM.COD_CLIENTE ) WHERE VGAH.COD_OPERACAO = 401 AND HLAN.CODCONV = 6090 AND HLAN.SIT_REGISTRO IN ('1'
							,'2') AND HLAN.TIPLANC = '2' AND VAPP.SIT_REGISTRO IN ('4') AND HLAN.DATA_VENCIMENTO = DATE('{WS_DTPARM}') - 4 DAY AND HLAN.DATA_VENCIMENTO = ( SELECT MAX(DATA_VENCIMENTO)
							FROM SEGUROS.HIST_LANC_CTA WHERE NUM_CERTIFICADO = HLAN.NUM_CERTIFICADO AND NUM_PARCELA = HLAN.NUM_PARCELA ) ORDER BY HLAN.DATA_VENCIMENTO DESC";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(StringBasis WS_DTPARM_P, string VA0134B1_FILE_NAME_P, string VA0134B2_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                this.WS_DTPARM.Value = WS_DTPARM_P.Value;
                VA0134B1.SetFile(VA0134B1_FILE_NAME_P);
                VA0134B2.SetFile(VA0134B2_FILE_NAME_P);
                InitializeGetQuery();

                /*" -248- PERFORM P1000-INICIALIZA */

                P1000_INICIALIZA(true);

                /*" -249- PERFORM P2000-PROCESSA */

                P2000_PROCESSA(true);

                /*" -250- PERFORM P9999-FINALIZA */

                P9999_FINALIZA(true);

                /*" -250- . */

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { WS_DTPARM, CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        public void InitializeGetQuery()
        {
            C01.GetQueryEvent += GetQuery_C01;
        }

        [StopWatch]
        /*" P1000-INICIALIZA */
        private void P1000_INICIALIZA(bool isPerform = false)
        {
            /*" -256- INITIALIZE VARDISP VARTEXT */
            _.Initialize(
                VARDISP
                , VARTEXT
            );

            /*" -258- OPEN OUTPUT VA0134B1 VA0134B2 */
            VA0134B1.Open(SAI_FD_VA0134B1);
            VA0134B2.Open(SAI_FD_VA0134B2);

            /*" -259- ACCEPT WS-DTPARM FROM SYSIN */
            /*-Accept convertido para parametro de entrada...*/

            /*" -261- DISPLAY 'WS-DTPARM.......: ' WS-DTPARM */
            _.Display($"WS-DTPARM.......: {WS_DTPARM}");

            /*" -261- PERFORM P1000_INICIALIZA_DB_OPEN_1 */

            P1000_INICIALIZA_DB_OPEN_1();

            /*" -264- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -265- MOVE 1001 TO WSS-COD-ERRO */
                _.Move(1001, VARDISP.WSS_COD_ERRO);

                /*" -266- PERFORM P9998-ERRO-DB2 */

                P9998_ERRO_DB2(true);

                /*" -266- END-IF. */
            }


        }

        [StopWatch]
        /*" P1000-INICIALIZA-DB-OPEN-1 */
        public void P1000_INICIALIZA_DB_OPEN_1()
        {
            /*" -261- EXEC SQL OPEN C01 END-EXEC. */

            C01.Open();

        }

        [StopWatch]
        /*" P2000-PROCESSA */
        private void P2000_PROCESSA(bool isPerform = false)
        {
            /*" -271- PERFORM P2100-FETCH */

            P2100_FETCH(true);

            /*" -274- PERFORM UNTIL END-OF-TABLE */

            while (!(VARFLAG.TABLE_STATUS["END_OF_TABLE"]))
            {

                /*" -275- PERFORM P2300-GRAVA-SAIDA */

                P2300_GRAVA_SAIDA(true);

                /*" -277- PERFORM P2100-FETCH */

                P2100_FETCH(true);

                /*" -277- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" P2100-FETCH */
        private void P2100_FETCH(bool isPerform = false)
        {
            /*" -306- PERFORM P2100_FETCH_DB_FETCH_1 */

            P2100_FETCH_DB_FETCH_1();

            /*" -321- MOVE SQLCODE TO WSS-COD-SQLC */
            _.Move(DB.SQLCODE, VARDISP.WSS_COD_SQLC);

            /*" -322- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -323- MOVE 1002 TO WSS-COD-ERRO */
                _.Move(1002, VARDISP.WSS_COD_ERRO);

                /*" -324- PERFORM P9998-ERRO-DB2 */

                P9998_ERRO_DB2(true);

                /*" -325- ELSE */
            }
            else
            {


                /*" -326- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -327- SET END-OF-TABLE TO TRUE */
                    VARFLAG.TABLE_STATUS["END_OF_TABLE"] = true;

                    /*" -328- ELSE */
                }
                else
                {


                    /*" -329- ADD 1 TO WSS-QTD-LIDOS */
                    VARDISP.WSS_QTD_LIDOS.Value = VARDISP.WSS_QTD_LIDOS + 1;

                    /*" -330- END-IF */
                }


                /*" -330- END-IF. */
            }


        }

        [StopWatch]
        /*" P2100-FETCH-DB-FETCH-1 */
        public void P2100_FETCH_DB_FETCH_1()
        {
            /*" -306- EXEC SQL FETCH C01 INTO :SEGVGAPH-NUM-APOLICE , :SEGVGAP-NUM-CERTIFICADO , :HISLANCT-CODRET :WSS-NULL, :HISLANCT-TIPLANC , :HISLANCT-CODCONV , :HISLANCT-SIT-REGISTRO , :HISLANCT-NUM-PARCELA , :HISLANCT-DATA-VENCIMENTO , :PROPOVA-COD-PRODUTO , :PROPOVA-SIT-REGISTRO , :PROPOVA-COD-CLIENTE , :CLIENTES-CGCCPF , :CLIENTES-NOME-RAZAO , :ENDERECO-DDD , :ENDERECO-TELEFONE , :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :CLIENEMA-EMAIL , :DB2-COD-SUSEP , :DB2-SIT-COBRANCA END-EXEC */

            if (C01.Fetch())
            {
                _.Move(C01.SEGVGAPH_NUM_APOLICE, SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_APOLICE);
                _.Move(C01.SEGVGAP_NUM_CERTIFICADO, SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO);
                _.Move(C01.HISLANCT_CODRET, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);
                _.Move(C01.WSS_NULL, VARHOST.WSS_NULL);
                _.Move(C01.HISLANCT_TIPLANC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);
                _.Move(C01.HISLANCT_CODCONV, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV);
                _.Move(C01.HISLANCT_SIT_REGISTRO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);
                _.Move(C01.HISLANCT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);
                _.Move(C01.HISLANCT_DATA_VENCIMENTO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO);
                _.Move(C01.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(C01.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(C01.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(C01.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(C01.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(C01.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(C01.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(C01.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(C01.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(C01.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(C01.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(C01.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(C01.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
                _.Move(C01.DB2_COD_SUSEP, VARHOST.DB2_COD_SUSEP);
                _.Move(C01.DB2_SIT_COBRANCA, VARHOST.DB2_SIT_COBRANCA);
            }

        }

        [StopWatch]
        /*" P2300-GRAVA-SAIDA */
        private void P2300_GRAVA_SAIDA(bool isPerform = false)
        {
            /*" -335- MOVE SPACE TO SAI-NOME */
            _.Move("", WSS_FD_SAIDA.SAI_NOME);

            /*" -336- MOVE ZERO TO SAI-CPF-CNPJ */
            _.Move(0, WSS_FD_SAIDA.SAI_CPF_CNPJ);

            /*" -337- MOVE SPACE TO SAI-CELULAR */
            _.Move("", WSS_FD_SAIDA.SAI_CELULAR);

            /*" -338- MOVE SPACE TO SAI-LOGRADOURO */
            _.Move("", WSS_FD_SAIDA.SAI_LOGRADOURO);

            /*" -339- MOVE SPACE TO SAI-BAIRRO */
            _.Move("", WSS_FD_SAIDA.SAI_BAIRRO);

            /*" -340- MOVE SPACE TO SAI-CIDADE */
            _.Move("", WSS_FD_SAIDA.SAI_CIDADE);

            /*" -341- MOVE SPACE TO SAI-UF */
            _.Move("", WSS_FD_SAIDA.SAI_UF);

            /*" -342- MOVE ZERO TO SAI-CEP */
            _.Move(0, WSS_FD_SAIDA.SAI_CEP);

            /*" -343- MOVE ZERO TO SAI-NUM-CONTRATO */
            _.Move(0, WSS_FD_SAIDA.SAI_NUM_CONTRATO);

            /*" -344- MOVE ZERO TO SAI-COD-PRODUTO */
            _.Move(0, WSS_FD_SAIDA.SAI_COD_PRODUTO);

            /*" -345- MOVE SPACE TO SAI-COD-SUSEP */
            _.Move("", WSS_FD_SAIDA.SAI_COD_SUSEP);

            /*" -346- MOVE SPACE TO SAI-COD-TEMPLATE */
            _.Move("", WSS_FD_SAIDA.SAI_COD_TEMPLATE);

            /*" -348- MOVE SPACE TO SAI-EMAIL */
            _.Move("", WSS_FD_SAIDA.SAI_EMAIL);

            /*" -349- MOVE ENDERECO-DDD TO WSS-COD-DDD */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, VARTEXT.FILLER_0.WSS_COD_DDD);

            /*" -351- MOVE ENDERECO-TELEFONE TO WSS-NUM-TELEFONE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, VARTEXT.FILLER_0.WSS_NUM_TELEFONE);

            /*" -352- MOVE CLIENTES-NOME-RAZAO TO SAI-NOME */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, WSS_FD_SAIDA.SAI_NOME);

            /*" -353- MOVE CLIENTES-CGCCPF TO SAI-CPF-CNPJ */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, WSS_FD_SAIDA.SAI_CPF_CNPJ);

            /*" -354- MOVE WSS-DDD-CELULAR TO SAI-CELULAR */
            _.Move(VARTEXT.WSS_DDD_CELULAR, WSS_FD_SAIDA.SAI_CELULAR);

            /*" -355- MOVE SPACE TO SAI-VARIAVEL-1 */
            _.Move("", WSS_FD_SAIDA.SAI_VARIAVEL_1);

            /*" -356- MOVE SPACE TO SAI-VARIAVEL-2 */
            _.Move("", WSS_FD_SAIDA.SAI_VARIAVEL_2);

            /*" -357- MOVE SPACE TO SAI-VARIAVEL-3 */
            _.Move("", WSS_FD_SAIDA.SAI_VARIAVEL_3);

            /*" -358- MOVE SPACE TO SAI-VARIAVEL-4 */
            _.Move("", WSS_FD_SAIDA.SAI_VARIAVEL_4);

            /*" -359- MOVE SPACE TO SAI-VARIAVEL-5 */
            _.Move("", WSS_FD_SAIDA.SAI_VARIAVEL_5);

            /*" -360- MOVE ENDERECO-ENDERECO TO SAI-LOGRADOURO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, WSS_FD_SAIDA.SAI_LOGRADOURO);

            /*" -361- MOVE ENDERECO-BAIRRO TO SAI-BAIRRO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, WSS_FD_SAIDA.SAI_BAIRRO);

            /*" -362- MOVE ENDERECO-CIDADE TO SAI-CIDADE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, WSS_FD_SAIDA.SAI_CIDADE);

            /*" -363- MOVE ENDERECO-SIGLA-UF TO SAI-UF */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, WSS_FD_SAIDA.SAI_UF);

            /*" -364- MOVE ENDERECO-CEP TO SAI-CEP */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, WSS_FD_SAIDA.SAI_CEP);

            /*" -365- MOVE SEGVGAP-NUM-CERTIFICADO TO SAI-NUM-CONTRATO */
            _.Move(SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO, WSS_FD_SAIDA.SAI_NUM_CONTRATO);

            /*" -366- MOVE PROPOVA-COD-PRODUTO TO SAI-COD-PRODUTO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, WSS_FD_SAIDA.SAI_COD_PRODUTO);

            /*" -367- MOVE DB2-COD-SUSEP TO SAI-COD-SUSEP */
            _.Move(VARHOST.DB2_COD_SUSEP, WSS_FD_SAIDA.SAI_COD_SUSEP);

            /*" -368- MOVE SPACE TO SAI-COD-TEMPLATE */
            _.Move("", WSS_FD_SAIDA.SAI_COD_TEMPLATE);

            /*" -371- MOVE CLIENEMA-EMAIL TO SAI-EMAIL */
            _.Move(CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL, WSS_FD_SAIDA.SAI_EMAIL);

            /*" -372- IF WSS-QTD-LIDOS EQUAL 1 */

            if (VARDISP.WSS_QTD_LIDOS == 1)
            {

                /*" -373- WRITE SAI-FD-VA0134B1 FROM WSS-FD-CABEC */
                _.Move(WSS_FD_CABEC.GetMoveValues(), SAI_FD_VA0134B1);

                VA0134B1.Write(SAI_FD_VA0134B1.GetMoveValues().ToString());

                /*" -374- WRITE SAI-FD-VA0134B2 FROM WSS-FD-CABEC */
                _.Move(WSS_FD_CABEC.GetMoveValues(), SAI_FD_VA0134B2);

                VA0134B2.Write(SAI_FD_VA0134B2.GetMoveValues().ToString());

                /*" -375- ADD 1 TO WSS-QTD-WRITE */
                VARDISP.WSS_QTD_WRITE.Value = VARDISP.WSS_QTD_WRITE + 1;

                /*" -377- END-IF */
            }


            /*" -378- IF HISLANCT-SIT-REGISTRO = '1' */

            if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO == "1")
            {

                /*" -379- IF SEGVGAP-NUM-CERTIFICADO = 10152130003267 */

                if (SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO == 10152130003267)
                {

                    /*" -380- DISPLAY 'HISLANCT-SIT-REGISTRO: ' HISLANCT-SIT-REGISTRO */
                    _.Display($"HISLANCT-SIT-REGISTRO: {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO}");

                    /*" -382- DISPLAY 'SEGVGAP-NUM-CERTIFICADO: ' SEGVGAP-NUM-CERTIFICADO */
                    _.Display($"SEGVGAP-NUM-CERTIFICADO: {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO}");

                    /*" -387- END-IF */
                }


                /*" -388- WRITE SAI-FD-VA0134B2 FROM WSS-FD-SAIDA */
                _.Move(WSS_FD_SAIDA.GetMoveValues(), SAI_FD_VA0134B2);

                VA0134B2.Write(SAI_FD_VA0134B2.GetMoveValues().ToString());

                /*" -389- ADD 1 TO WSS-QTD-COM */
                VARDISP.WSS_QTD_COM.Value = VARDISP.WSS_QTD_COM + 1;

                /*" -390- ADD 1 TO WSS-QTD-WRITE */
                VARDISP.WSS_QTD_WRITE.Value = VARDISP.WSS_QTD_WRITE + 1;

                /*" -391- ELSE */
            }
            else
            {


                /*" -392- IF SEGVGAP-NUM-CERTIFICADO = 10152130003267 */

                if (SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO == 10152130003267)
                {

                    /*" -393- DISPLAY 'HISLANCT-SIT-REGISTRO: ' HISLANCT-SIT-REGISTRO */
                    _.Display($"HISLANCT-SIT-REGISTRO: {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO}");

                    /*" -395- DISPLAY 'SEGVGAP-NUM-CERTIFICADO: ' SEGVGAP-NUM-CERTIFICADO */
                    _.Display($"SEGVGAP-NUM-CERTIFICADO: {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO}");

                    /*" -400- END-IF */
                }


                /*" -401- WRITE SAI-FD-VA0134B1 FROM WSS-FD-SAIDA */
                _.Move(WSS_FD_SAIDA.GetMoveValues(), SAI_FD_VA0134B1);

                VA0134B1.Write(SAI_FD_VA0134B1.GetMoveValues().ToString());

                /*" -402- ADD 1 TO WSS-QTD-SEM */
                VARDISP.WSS_QTD_SEM.Value = VARDISP.WSS_QTD_SEM + 1;

                /*" -403- ADD 1 TO WSS-QTD-WRITE */
                VARDISP.WSS_QTD_WRITE.Value = VARDISP.WSS_QTD_WRITE + 1;

                /*" -403- END-IF. */
            }


        }

        [StopWatch]
        /*" P9998-ERRO-DB2 */
        private void P9998_ERRO_DB2(bool isPerform = false)
        {
            /*" -409- MOVE SQLCODE TO WSS-COD-SQLC */
            _.Move(DB.SQLCODE, VARDISP.WSS_COD_SQLC);

            /*" -410- DISPLAY '//-**************************************-//' */
            _.Display($"//**************************************//");

            /*" -411- DISPLAY '  OCORRENCIA DE ERRO NO ACESSO A TABELA   ' */
            _.Display($"  OCORRENCIA DE ERRO NO ACESSO A TABELA   ");

            /*" -412- DISPLAY '//-**************************************-//' */
            _.Display($"//**************************************//");

            /*" -413- DISPLAY '  SQLCODE............ ' WSS-COD-SQLC */
            _.Display($"  SQLCODE............ {VARDISP.WSS_COD_SQLC}");

            /*" -414- DISPLAY '  SQLSTATE........... ' SQLSTATE */
            _.Display($"  SQLSTATE........... {DB.SQLSTATE}");

            /*" -415- DISPLAY '  SQLERRMC........... ' SQLERRMC */
            _.Display($"  SQLERRMC........... {DB.SQLERRMC}");

            /*" -416- DISPLAY '  POSICAO DO ERRO.... ' WSS-COD-ERRO */
            _.Display($"  POSICAO DO ERRO.... {VARDISP.WSS_COD_ERRO}");

            /*" -418- DISPLAY '//' */
            _.Display($"//");

            /*" -419- GO TO P9999-FINALIZA */

            P9999_FINALIZA(); //GOTO
            return;

            /*" -419- . */

        }

        [StopWatch]
        /*" P9998-DISPLAY-FETCH */
        private void P9998_DISPLAY_FETCH(bool isPerform = false)
        {
            /*" -424- IF WSS-QTD-LIDOS LESS 101 */

            if (VARDISP.WSS_QTD_LIDOS < 101)
            {

                /*" -425- DISPLAY '//DISPLAY-FETCH/SQLC=' SQLCODE */
                _.Display($"//DISPLAY-FETCH/SQLC={DB.SQLCODE}");

                /*" -426- DISPLAY '  APOLICE      = ' SEGVGAPH-NUM-APOLICE */
                _.Display($"  APOLICE      = {SEGVGAPH.DCLSEGURADOSVGAP_HIST.SEGVGAPH_NUM_APOLICE}");

                /*" -427- DISPLAY '  CERTIFICADO  = ' SEGVGAP-NUM-CERTIFICADO */
                _.Display($"  CERTIFICADO  = {SEGVGAP.DCLSEGURADOS_VGAP.SEGVGAP_NUM_CERTIFICADO}");

                /*" -428- DISPLAY '  CODRETORNO   = ' HISLANCT-CODRET */
                _.Display($"  CODRETORNO   = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET}");

                /*" -429- DISPLAY '  CODCONVENIO  = ' HISLANCT-CODCONV */
                _.Display($"  CODCONVENIO  = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODCONV}");

                /*" -430- DISPLAY '  SIT-REGISTRO = ' HISLANCT-SIT-REGISTRO */
                _.Display($"  SIT-REGISTRO = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO}");

                /*" -431- DISPLAY '  PRODUTO      = ' PROPOVA-COD-PRODUTO */
                _.Display($"  PRODUTO      = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO}");

                /*" -432- DISPLAY '  COD-CLIENTE  = ' PROPOVA-COD-CLIENTE */
                _.Display($"  COD-CLIENTE  = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}");

                /*" -433- DISPLAY '  CPF-CNPJ     = ' CLIENTES-CGCCPF */
                _.Display($"  CPF-CNPJ     = {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                /*" -434- DISPLAY '  NOME CLIENTE = ' CLIENTES-NOME-RAZAO */
                _.Display($"  NOME CLIENTE = {CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO}");

                /*" -435- DISPLAY '  DDD          = ' ENDERECO-DDD */
                _.Display($"  DDD          = {ENDERECO.DCLENDERECOS.ENDERECO_DDD}");

                /*" -436- DISPLAY '  TELEFONE     = ' ENDERECO-TELEFONE */
                _.Display($"  TELEFONE     = {ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE}");

                /*" -437- DISPLAY '  LOGRADOURO   = ' ENDERECO-ENDERECO */
                _.Display($"  LOGRADOURO   = {ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO}");

                /*" -438- DISPLAY '  BAIRRO       = ' ENDERECO-BAIRRO */
                _.Display($"  BAIRRO       = {ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO}");

                /*" -439- DISPLAY '  CIDADE       = ' ENDERECO-CIDADE */
                _.Display($"  CIDADE       = {ENDERECO.DCLENDERECOS.ENDERECO_CIDADE}");

                /*" -440- DISPLAY '  UF           = ' ENDERECO-SIGLA-UF */
                _.Display($"  UF           = {ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF}");

                /*" -441- DISPLAY '  CEPO         = ' ENDERECO-CEP */
                _.Display($"  CEPO         = {ENDERECO.DCLENDERECOS.ENDERECO_CEP}");

                /*" -442- DISPLAY '  EMAIL        = ' CLIENEMA-EMAIL */
                _.Display($"  EMAIL        = {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL}");

                /*" -443- DISPLAY '  SUSEP        = ' DB2-COD-SUSEP */
                _.Display($"  SUSEP        = {VARHOST.DB2_COD_SUSEP}");

                /*" -444- DISPLAY '//' */
                _.Display($"//");

                /*" -445- END-IF */
            }


            /*" -445- . */

        }

        [StopWatch]
        /*" P9999-FINALIZA */
        private void P9999_FINALIZA(bool isPerform = false)
        {
            /*" -449- PERFORM P9999_FINALIZA_DB_CLOSE_1 */

            P9999_FINALIZA_DB_CLOSE_1();

            /*" -453- CLOSE VA0134B1 VA0134B2 */
            VA0134B1.Close();
            VA0134B2.Close();

            /*" -454- IF WSS-COD-ERRO NOT EQUAL ZEROS */

            if (VARDISP.WSS_COD_ERRO != 00)
            {

                /*" -455- DISPLAY '//' */
                _.Display($"//");

                /*" -456- DISPLAY '//-**************************************-//' */
                _.Display($"//**************************************//");

                /*" -457- DISPLAY '  PROGRAMA VA0134B FINALIZADO COM ERRO    ' */
                _.Display($"  PROGRAMA VA0134B FINALIZADO COM ERRO    ");

                /*" -458- DISPLAY '//-**************************************-//' */
                _.Display($"//**************************************//");

                /*" -459- DISPLAY '  POSICAO DO ERRO.... ' WSS-COD-ERRO */
                _.Display($"  POSICAO DO ERRO.... {VARDISP.WSS_COD_ERRO}");

                /*" -460- DISPLAY '  Lidos.............. ' WSS-QTD-LIDOS */
                _.Display($"  Lidos.............. {VARDISP.WSS_QTD_LIDOS}");

                /*" -461- DISPLAY '   Com Restituicao... ' WSS-QTD-COM */
                _.Display($"   Com Restituicao... {VARDISP.WSS_QTD_COM}");

                /*" -462- DISPLAY '   Sem Restituicao... ' WSS-QTD-SEM */
                _.Display($"   Sem Restituicao... {VARDISP.WSS_QTD_SEM}");

                /*" -463- DISPLAY '//' */
                _.Display($"//");

                /*" -464- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -465- ELSE */
            }
            else
            {


                /*" -466- DISPLAY '//' */
                _.Display($"//");

                /*" -467- DISPLAY '//-***************************************-//' */
                _.Display($"//***************************************//");

                /*" -468- DISPLAY '  PROGRAMA VA0134B FINALIZADO COM EXITO    ' */
                _.Display($"  PROGRAMA VA0134B FINALIZADO COM EXITO    ");

                /*" -469- DISPLAY '//-***************************************-//' */
                _.Display($"//***************************************//");

                /*" -470- DISPLAY '  Lidos.............. ' WSS-QTD-LIDOS */
                _.Display($"  Lidos.............. {VARDISP.WSS_QTD_LIDOS}");

                /*" -471- DISPLAY '   Com Restituicao... ' WSS-QTD-COM */
                _.Display($"   Com Restituicao... {VARDISP.WSS_QTD_COM}");

                /*" -472- DISPLAY '   Sem Restituicao... ' WSS-QTD-SEM */
                _.Display($"   Sem Restituicao... {VARDISP.WSS_QTD_SEM}");

                /*" -473- DISPLAY '  Gravados........... ' WSS-QTD-WRITE */
                _.Display($"  Gravados........... {VARDISP.WSS_QTD_WRITE}");

                /*" -474- DISPLAY '   Com Restituicao... ' WSS-QTD-COM */
                _.Display($"   Com Restituicao... {VARDISP.WSS_QTD_COM}");

                /*" -475- DISPLAY '   Sem Restituicao... ' WSS-QTD-SEM */
                _.Display($"   Sem Restituicao... {VARDISP.WSS_QTD_SEM}");

                /*" -476- DISPLAY ' ' */
                _.Display($" ");

                /*" -477- END-IF */
            }


            /*" -477- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" P9999-FINALIZA-DB-CLOSE-1 */
        public void P9999_FINALIZA_DB_CLOSE_1()
        {
            /*" -449- EXEC SQL CLOSE C01 END-EXEC */

            C01.Close();

        }
    }
}