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
using Sias.VidaAzul.DB2.VA0133B;

namespace Code
{
    public class VA0133B
    {
        public bool IsCall { get; set; }

        public VA0133B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *  SISTEMA ...............  VIDA (SIAS)                          *      */
        /*"      *  PROGRAMA ..............  VA0133B                              *      */
        /*"      *  FINALIDADE:                                                   *      */
        /*"      *    1. GERAR ARQUIVOS DE CREDITOS PAGOS E CREDITOS REJEITADOS   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * HISTORICO DE CORRECOES                                         *      */
        /*"      * -------------------------------------------------------------- *      */
        /*"      * VERSAO  DATA       RESPONSAVEL    DESCRICAO                    *      */
        /*"      * ------  ---------- -------------  ---------------------------- *      */
        /*"      * 01.1    05.12.2019 NICODEMUS      CODIFICACAO INICIAL          *      */
        /*"      *----------------------------------------------------------------*      */
        #endregion


        #region VARIABLES

        public FileBasis _VA0133B1 { get; set; } = new FileBasis(new PIC("X", "445", "X(445)"));

        public FileBasis VA0133B1
        {
            get
            {
                _.Move(SAI_FD_VA0133B1, _VA0133B1); VarBasis.RedefinePassValue(SAI_FD_VA0133B1, _VA0133B1, SAI_FD_VA0133B1); return _VA0133B1;
            }
        }
        public FileBasis _VA0133B2 { get; set; } = new FileBasis(new PIC("X", "445", "X(445)"));

        public FileBasis VA0133B2
        {
            get
            {
                _.Move(SAI_FD_VA0133B2, _VA0133B2); VarBasis.RedefinePassValue(SAI_FD_VA0133B2, _VA0133B2, SAI_FD_VA0133B2); return _VA0133B2;
            }
        }
        /*"01  SAI-FD-VA0133B1                  PIC X(445).*/
        public StringBasis SAI_FD_VA0133B1 { get; set; } = new StringBasis(new PIC("X", "445", "X(445)."), @"");
        /*"01  SAI-FD-VA0133B2                  PIC X(445).*/
        public StringBasis SAI_FD_VA0133B2 { get; set; } = new StringBasis(new PIC("X", "445", "X(445)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77 WSS-VERSAO              PIC X(080) VALUE '01.1'.*/
        public StringBasis WSS_VERSAO { get; set; } = new StringBasis(new PIC("X", "80", "X(080)"), @"01.1");
        /*"77 WS-DTPARM               PIC X(010) VALUE SPACES.*/
        public StringBasis WS_DTPARM { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");

        /*"01  VARHOST.*/
        public VA0133B_VARHOST VARHOST { get; set; } = new VA0133B_VARHOST();
        public class VA0133B_VARHOST : VarBasis
        {
            /*"    03 WSS-NULL               COMP   PIC S9(04)    VALUE 0.*/
            public IntBasis WSS_NULL { get; set; } = new IntBasis(new PIC("X", "4", "S9(04)"));
            /*"    03 DB2-VLR-CREDITO        COMP-3 PIC S9(13)V99 VALUE 0.*/
            public DoubleBasis DB2_VLR_CREDITO { get; set; } = new DoubleBasis(new PIC("X", "13", "S9(13)V99"), 2);
            /*"    03 DB2-DTA-CREDITO               PIC X(010)    VALUE SPACE.*/
            public StringBasis DB2_DTA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    03 DB2-COD-SUSEP                 PIC X(025)    VALUE SPACE.*/
            public StringBasis DB2_COD_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"    03 DB2-SIT-COBRANCA              PIC X(001)    VALUE SPACE.*/
            public StringBasis DB2_SIT_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"01  VARFLAG.*/
        }
        public VA0133B_VARFLAG VARFLAG { get; set; } = new VA0133B_VARFLAG();
        public class VA0133B_VARFLAG : VarBasis
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
        public VA0133B_VARTEXT VARTEXT { get; set; } = new VA0133B_VARTEXT();
        public class VA0133B_VARTEXT : VarBasis
        {
            /*"    03 WSS-MSG-ERRO                  PIC X(120).*/
            public StringBasis WSS_MSG_ERRO { get; set; } = new StringBasis(new PIC("X", "120", "X(120)."), @"");
            /*"    03 WSS-DDD-CELULAR               PIC X(012).*/
            public StringBasis WSS_DDD_CELULAR { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"    03  FILLER REDEFINES    WSS-DDD-CELULAR.*/
            private _REDEF_VA0133B_FILLER_0 _filler_0 { get; set; }
            public _REDEF_VA0133B_FILLER_0 FILLER_0
            {
                get { _filler_0 = new _REDEF_VA0133B_FILLER_0(); _.Move(WSS_DDD_CELULAR, _filler_0); VarBasis.RedefinePassValue(WSS_DDD_CELULAR, _filler_0, WSS_DDD_CELULAR); _filler_0.ValueChanged += () => { _.Move(_filler_0, WSS_DDD_CELULAR); }; return _filler_0; }
                set { VarBasis.RedefinePassValue(value, _filler_0, WSS_DDD_CELULAR); }
            }  //Redefines
            public class _REDEF_VA0133B_FILLER_0 : VarBasis
            {
                /*"       05 WSS-COD-DDD                PIC 9(003).*/
                public IntBasis WSS_COD_DDD { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       05 WSS-NUM-TELEFONE           PIC 9(009).*/
                public IntBasis WSS_NUM_TELEFONE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"01  VARDISP.*/

                public _REDEF_VA0133B_FILLER_0()
                {
                    WSS_COD_DDD.ValueChanged += OnValueChanged;
                    WSS_NUM_TELEFONE.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA0133B_VARDISP VARDISP { get; set; } = new VA0133B_VARDISP();
        public class VA0133B_VARDISP : VarBasis
        {
            /*"    03 WSS-COD-ERRO                  PIC 9(004).*/
            public IntBasis WSS_COD_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 WSS-PSC-ERRO                  PIC 9(004).*/
            public IntBasis WSS_PSC_ERRO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03 WSS-QTD-LIDOS                 PIC 9(009).*/
            public IntBasis WSS_QTD_LIDOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 WSS-QTD-PAGOS                 PIC 9(009).*/
            public IntBasis WSS_QTD_PAGOS { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 WSS-QTD-DESP                  PIC 9(009).*/
            public IntBasis WSS_QTD_DESP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 WSS-QTD-WRITE                 PIC 9(009).*/
            public IntBasis WSS_QTD_WRITE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 WSS-QTD-REJ                   PIC 9(009).*/
            public IntBasis WSS_QTD_REJ { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03 WSS-COD-SQLC                  PIC -999.*/
            public IntBasis WSS_COD_SQLC { get; set; } = new IntBasis(new PIC("9", "3", "-999."));
            /*"01  WSS-FD-CABEC.*/
        }
        public VA0133B_WSS_FD_CABEC WSS_FD_CABEC { get; set; } = new VA0133B_WSS_FD_CABEC();
        public class VA0133B_WSS_FD_CABEC : VarBasis
        {
            /*"    03 PIC X(015) VALUE 'NUM-CONTRATO'.*/
            public StringBasis PIC { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"NUM_CONTRATO");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(011) VALUE 'COD-PRODUTO'.*/
            public StringBasis PIC_1 { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"COD-PRODUTO");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(025) VALUE 'COD-SUSEP'.*/
            public StringBasis PIC_3 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"COD-SUSEP");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(012) VALUE 'COD-TEMPLATE'.*/
            public StringBasis PIC_5 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COD-TEMPLATE");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(014) VALUE 'CPF-CNPJ      '.*/
            public StringBasis PIC_7 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"CPF-CNPJ      ");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(040) VALUE 'NOME'.*/
            public StringBasis PIC_9 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"NOME");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(040) VALUE 'EMAIL'.*/
            public StringBasis PIC_11 { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"EMAIL");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(012) VALUE 'CELULAR'.*/
            public StringBasis PIC_13 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"CELULAR");
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
            /*"    03 PIC X(019) VALUE '       VLR. CREDITO'.*/
            public StringBasis PIC_25 { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"       VLR. CREDITO");
            /*"    03 PIC X(001) VALUE ';'.*/
            public StringBasis PIC_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 PIC X(015) VALUE 'DATA VENCIMENTO'.*/
            public StringBasis PIC_27 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"DATA VENCIMENTO");
            /*"01  WSS-FD-SAIDA.*/
        }
        public VA0133B_WSS_FD_SAIDA WSS_FD_SAIDA { get; set; } = new VA0133B_WSS_FD_SAIDA();
        public class VA0133B_WSS_FD_SAIDA : VarBasis
        {
            /*"    03 SAI-NUM-CONTRATO              PIC 9(015).*/
            public IntBasis SAI_NUM_CONTRATO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03                               PIC X(007) VALUE ' '.*/
            public StringBasis PIC_29 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @" ");
            /*"    03 SAI-COD-PRODUTO               PIC 9(004).*/
            public IntBasis SAI_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-COD-SUSEP                 PIC X(025).*/
            public StringBasis SAI_COD_SUSEP { get; set; } = new StringBasis(new PIC("X", "25", "X(025)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-COD-TEMPLATE              PIC X(012).*/
            public StringBasis SAI_COD_TEMPLATE { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_32 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-CPF-CNPJ                  PIC 9(014).*/
            public IntBasis SAI_CPF_CNPJ { get; set; } = new IntBasis(new PIC("9", "14", "9(014)."));
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-NOME                      PIC X(040).*/
            public StringBasis SAI_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-EMAIL                     PIC X(040).*/
            public StringBasis SAI_EMAIL { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-CELULAR                   PIC X(012).*/
            public StringBasis SAI_CELULAR { get; set; } = new StringBasis(new PIC("X", "12", "X(012)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-LOGRADOURO                PIC X(072).*/
            public StringBasis SAI_LOGRADOURO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-BAIRRO                    PIC X(072).*/
            public StringBasis SAI_BAIRRO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_38 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-CIDADE                    PIC X(072).*/
            public StringBasis SAI_CIDADE { get; set; } = new StringBasis(new PIC("X", "72", "X(072)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-UF                        PIC X(002).*/
            public StringBasis SAI_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_40 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-CEP                       PIC 9(009).*/
            public IntBasis SAI_CEP { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-VLR-CREDITO               PIC -ZZZ.ZZZ.ZZZ.ZZ9,99.*/
            public DoubleBasis SAI_VLR_CREDITO { get; set; } = new DoubleBasis(new PIC("9", "12", "-ZZZ.ZZZ.ZZZ.ZZ9V99."), 2);
            /*"    03                               PIC X(001) VALUE ';'.*/
            public StringBasis PIC_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"    03 SAI-DTA-CREDITO               PIC X(010).*/
            public StringBasis SAI_DTA_CREDITO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        }


        public Dclgens.HISLANCT HISLANCT { get; set; } = new Dclgens.HISLANCT();
        public Dclgens.PROPOVA PROPOVA { get; set; } = new Dclgens.PROPOVA();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.CLIENEMA CLIENEMA { get; set; } = new Dclgens.CLIENEMA();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();

        public VA0133B_C01 C01 { get; set; } = new VA0133B_C01(true);
        string GetQuery_C01()
        {
            var query = @$"SELECT HL.NUM_CERTIFICADO
							, HL.SIT_REGISTRO
							, HL.CODRET
							, HL.TIPLANC
							, HL.NUM_PARCELA
							, HL.PRM_TOTAL
							, HL.DATA_VENCIMENTO
							, PP.COD_PRODUTO
							, PP.COD_CLIENTE
							, PP.NUM_APOLICE
							, PP.NUM_PARCELA
							, PP.SIT_REGISTRO
							, CL.CGCCPF
							, CL.NOME_RAZAO
							, EN.OCORR_ENDERECO
							, EN.ENDERECO
							, EN.BAIRRO
							, EN.CIDADE
							, EN.SIGLA_UF
							, EN.CEP
							, EN.DDD
							, EN.TELEFONE
							, CE.EMAIL
							, PD.NUM_PROCESSO_SUSEP
							FROM SEGUROS.HIST_LANC_CTA HL INNER
							JOIN SEGUROS.PROPOSTAS_VA PP ON PP.NUM_CERTIFICADO = HL.NUM_CERTIFICADO AND PP.NUM_PARCELA = HL.NUM_PARCELA INNER
							JOIN SEGUROS.PRODUTO PD ON PD.COD_PRODUTO = PP.COD_PRODUTO
							JOIN SEGUROS.CLIENTES CL ON CL.COD_CLIENTE = PP.COD_CLIENTE INNER
							JOIN SEGUROS.ENDERECOS EN ON EN.COD_CLIENTE = PP.COD_CLIENTE AND EN.OCORR_ENDERECO = PP.OCOREND INNER
							JOIN SEGUROS.CLIENTE_EMAIL CE ON CE.COD_CLIENTE = PP.COD_CLIENTE AND CE.SEQ_EMAIL = ( SELECT MAX(SEQ_EMAIL)
							FROM SEGUROS.CLIENTE_EMAIL WHERE COD_CLIENTE = CE.COD_CLIENTE ) WHERE HL.CODCONV = 6090 AND HL.SIT_REGISTRO IN (' '
							,'1') AND HL.TIPLANC = '2' AND PP.SIT_REGISTRO = '4' AND HL.DATA_VENCIMENTO = DATE('{WS_DTPARM}') - 4 DAY AND HL.DATA_VENCIMENTO = ( SELECT MAX(DATA_VENCIMENTO)
							FROM SEGUROS.HIST_LANC_CTA WHERE NUM_CERTIFICADO = HL.NUM_CERTIFICADO AND NUM_PARCELA = HL.NUM_PARCELA ) ORDER BY HL.DATA_VENCIMENTO DESC";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(StringBasis WS_DTPARM_P, string VA0133B1_FILE_NAME_P, string VA0133B2_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                this.WS_DTPARM.Value = WS_DTPARM_P.Value;
                VA0133B1.SetFile(VA0133B1_FILE_NAME_P);
                VA0133B2.SetFile(VA0133B2_FILE_NAME_P);
                InitializeGetQuery();

                /*" -225- PERFORM P1000-INICIALIZA */

                P1000_INICIALIZA(true);

                /*" -226- PERFORM P2000-PROCESSA */

                P2000_PROCESSA(true);

                /*" -227- PERFORM P9999-FINALIZA */

                P9999_FINALIZA(true);

                /*" -227- . */

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
            /*" -233- INITIALIZE VARDISP VARTEXT */
            _.Initialize(
                VARDISP
                , VARTEXT
            );

            /*" -235- OPEN OUTPUT VA0133B1 VA0133B2 */
            VA0133B1.Open(SAI_FD_VA0133B1);
            VA0133B2.Open(SAI_FD_VA0133B2);

            /*" -236- ACCEPT WS-DTPARM FROM SYSIN */
            /*-Accept convertido para parametro de entrada...*/

            /*" -238- DISPLAY 'WS-DTPARM.......: ' WS-DTPARM */
            _.Display($"WS-DTPARM.......: {WS_DTPARM}");

            /*" -238- PERFORM P1000_INICIALIZA_DB_OPEN_1 */

            P1000_INICIALIZA_DB_OPEN_1();

            /*" -241- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -242- MOVE 1001 TO WSS-COD-ERRO */
                _.Move(1001, VARDISP.WSS_COD_ERRO);

                /*" -243- PERFORM P9998-ERRO-DB2 */

                P9998_ERRO_DB2(true);

                /*" -243- END-IF. */
            }


        }

        [StopWatch]
        /*" P1000-INICIALIZA-DB-OPEN-1 */
        public void P1000_INICIALIZA_DB_OPEN_1()
        {
            /*" -238- EXEC SQL OPEN C01 END-EXEC. */

            C01.Open();

        }

        [StopWatch]
        /*" P2000-PROCESSA */
        private void P2000_PROCESSA(bool isPerform = false)
        {
            /*" -248- PERFORM P2100-FETCH */

            P2100_FETCH(true);

            /*" -251- PERFORM UNTIL END-OF-TABLE */

            while (!(VARFLAG.TABLE_STATUS["END_OF_TABLE"]))
            {

                /*" -252- PERFORM P2300-GRAVA-SAIDA */

                P2300_GRAVA_SAIDA(true);

                /*" -254- PERFORM P2100-FETCH */

                P2100_FETCH(true);

                /*" -254- END-PERFORM. */
            }

        }

        [StopWatch]
        /*" P2100-FETCH */
        private void P2100_FETCH(bool isPerform = false)
        {
            /*" -259- MOVE ZEROS TO DB2-VLR-CREDITO */
            _.Move(0, VARHOST.DB2_VLR_CREDITO);

            /*" -260- MOVE SPACE TO DB2-DTA-CREDITO */
            _.Move("", VARHOST.DB2_DTA_CREDITO);

            /*" -262- MOVE SPACE TO DB2-COD-SUSEP */
            _.Move("", VARHOST.DB2_COD_SUSEP);

            /*" -288- PERFORM P2100_FETCH_DB_FETCH_1 */

            P2100_FETCH_DB_FETCH_1();

            /*" -304- MOVE SQLCODE TO WSS-COD-SQLC */
            _.Move(DB.SQLCODE, VARDISP.WSS_COD_SQLC);

            /*" -305- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -306- MOVE 1002 TO WSS-COD-ERRO */
                _.Move(1002, VARDISP.WSS_COD_ERRO);

                /*" -307- PERFORM P9998-ERRO-DB2 */

                P9998_ERRO_DB2(true);

                /*" -308- ELSE */
            }
            else
            {


                /*" -309- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -310- SET END-OF-TABLE TO TRUE */
                    VARFLAG.TABLE_STATUS["END_OF_TABLE"] = true;

                    /*" -311- ELSE */
                }
                else
                {


                    /*" -312- ADD 1 TO WSS-QTD-LIDOS */
                    VARDISP.WSS_QTD_LIDOS.Value = VARDISP.WSS_QTD_LIDOS + 1;

                    /*" -313- END-IF */
                }


                /*" -313- END-IF. */
            }


        }

        [StopWatch]
        /*" P2100-FETCH-DB-FETCH-1 */
        public void P2100_FETCH_DB_FETCH_1()
        {
            /*" -288- EXEC SQL FETCH C01 INTO :HISLANCT-NUM-CERTIFICADO , :HISLANCT-SIT-REGISTRO , :HISLANCT-CODRET :WSS-NULL , :HISLANCT-TIPLANC , :HISLANCT-NUM-PARCELA , :HISLANCT-PRM-TOTAL , :HISLANCT-DATA-VENCIMENTO , :PROPOVA-COD-PRODUTO , :PROPOVA-COD-CLIENTE , :PROPOVA-NUM-APOLICE , :PROPOVA-NUM-PARCELA , :PROPOVA-SIT-REGISTRO , :CLIENTES-CGCCPF , :CLIENTES-NOME-RAZAO , :ENDERECO-OCORR-ENDERECO , :ENDERECO-ENDERECO , :ENDERECO-BAIRRO , :ENDERECO-CIDADE , :ENDERECO-SIGLA-UF , :ENDERECO-CEP , :ENDERECO-DDD , :ENDERECO-TELEFONE , :CLIENEMA-EMAIL , :DB2-COD-SUSEP END-EXEC */

            if (C01.Fetch())
            {
                _.Move(C01.HISLANCT_NUM_CERTIFICADO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO);
                _.Move(C01.HISLANCT_SIT_REGISTRO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO);
                _.Move(C01.HISLANCT_CODRET, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET);
                _.Move(C01.WSS_NULL, VARHOST.WSS_NULL);
                _.Move(C01.HISLANCT_TIPLANC, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_TIPLANC);
                _.Move(C01.HISLANCT_NUM_PARCELA, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_PARCELA);
                _.Move(C01.HISLANCT_PRM_TOTAL, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL);
                _.Move(C01.HISLANCT_DATA_VENCIMENTO, HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO);
                _.Move(C01.PROPOVA_COD_PRODUTO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO);
                _.Move(C01.PROPOVA_COD_CLIENTE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE);
                _.Move(C01.PROPOVA_NUM_APOLICE, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE);
                _.Move(C01.PROPOVA_NUM_PARCELA, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA);
                _.Move(C01.PROPOVA_SIT_REGISTRO, PROPOVA.DCLPROPOSTAS_VA.PROPOVA_SIT_REGISTRO);
                _.Move(C01.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(C01.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(C01.ENDERECO_OCORR_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO);
                _.Move(C01.ENDERECO_ENDERECO, ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO);
                _.Move(C01.ENDERECO_BAIRRO, ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO);
                _.Move(C01.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(C01.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(C01.ENDERECO_CEP, ENDERECO.DCLENDERECOS.ENDERECO_CEP);
                _.Move(C01.ENDERECO_DDD, ENDERECO.DCLENDERECOS.ENDERECO_DDD);
                _.Move(C01.ENDERECO_TELEFONE, ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE);
                _.Move(C01.CLIENEMA_EMAIL, CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL);
                _.Move(C01.DB2_COD_SUSEP, VARHOST.DB2_COD_SUSEP);
            }

        }

        [StopWatch]
        /*" P2300-GRAVA-SAIDA */
        private void P2300_GRAVA_SAIDA(bool isPerform = false)
        {
            /*" -318- MOVE ZEROS TO SAI-NUM-CONTRATO */
            _.Move(0, WSS_FD_SAIDA.SAI_NUM_CONTRATO);

            /*" -319- MOVE 0 TO SAI-COD-PRODUTO */
            _.Move(0, WSS_FD_SAIDA.SAI_COD_PRODUTO);

            /*" -320- MOVE 0 TO SAI-CPF-CNPJ */
            _.Move(0, WSS_FD_SAIDA.SAI_CPF_CNPJ);

            /*" -321- MOVE 0 TO SAI-CEP */
            _.Move(0, WSS_FD_SAIDA.SAI_CEP);

            /*" -323- MOVE 0 TO SAI-VLR-CREDITO */
            _.Move(0, WSS_FD_SAIDA.SAI_VLR_CREDITO);

            /*" -324- MOVE SPACE TO SAI-NOME */
            _.Move("", WSS_FD_SAIDA.SAI_NOME);

            /*" -325- MOVE SPACE TO SAI-EMAIL */
            _.Move("", WSS_FD_SAIDA.SAI_EMAIL);

            /*" -326- MOVE SPACE TO SAI-CELULAR */
            _.Move("", WSS_FD_SAIDA.SAI_CELULAR);

            /*" -327- MOVE SPACE TO SAI-LOGRADOURO */
            _.Move("", WSS_FD_SAIDA.SAI_LOGRADOURO);

            /*" -328- MOVE SPACE TO SAI-BAIRRO */
            _.Move("", WSS_FD_SAIDA.SAI_BAIRRO);

            /*" -329- MOVE SPACE TO SAI-CIDADE */
            _.Move("", WSS_FD_SAIDA.SAI_CIDADE);

            /*" -330- MOVE SPACE TO SAI-UF */
            _.Move("", WSS_FD_SAIDA.SAI_UF);

            /*" -331- MOVE SPACE TO SAI-DTA-CREDITO */
            _.Move("", WSS_FD_SAIDA.SAI_DTA_CREDITO);

            /*" -333- MOVE SPACE TO SAI-COD-SUSEP */
            _.Move("", WSS_FD_SAIDA.SAI_COD_SUSEP);

            /*" -334- MOVE ENDERECO-DDD TO WSS-COD-DDD */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_DDD, VARTEXT.FILLER_0.WSS_COD_DDD);

            /*" -336- MOVE ENDERECO-TELEFONE TO WSS-NUM-TELEFONE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE, VARTEXT.FILLER_0.WSS_NUM_TELEFONE);

            /*" -337- MOVE HISLANCT-NUM-CERTIFICADO TO SAI-NUM-CONTRATO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO, WSS_FD_SAIDA.SAI_NUM_CONTRATO);

            /*" -338- MOVE PROPOVA-COD-PRODUTO TO SAI-COD-PRODUTO */
            _.Move(PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO, WSS_FD_SAIDA.SAI_COD_PRODUTO);

            /*" -339- MOVE DB2-COD-SUSEP TO SAI-COD-SUSEP */
            _.Move(VARHOST.DB2_COD_SUSEP, WSS_FD_SAIDA.SAI_COD_SUSEP);

            /*" -340- MOVE SPACE TO SAI-COD-TEMPLATE */
            _.Move("", WSS_FD_SAIDA.SAI_COD_TEMPLATE);

            /*" -341- MOVE CLIENTES-CGCCPF TO SAI-CPF-CNPJ */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, WSS_FD_SAIDA.SAI_CPF_CNPJ);

            /*" -342- MOVE CLIENTES-NOME-RAZAO TO SAI-NOME */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, WSS_FD_SAIDA.SAI_NOME);

            /*" -343- MOVE CLIENEMA-EMAIL TO SAI-EMAIL */
            _.Move(CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL, WSS_FD_SAIDA.SAI_EMAIL);

            /*" -344- MOVE WSS-DDD-CELULAR TO SAI-CELULAR */
            _.Move(VARTEXT.WSS_DDD_CELULAR, WSS_FD_SAIDA.SAI_CELULAR);

            /*" -345- MOVE ENDERECO-ENDERECO TO SAI-LOGRADOURO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO, WSS_FD_SAIDA.SAI_LOGRADOURO);

            /*" -346- MOVE ENDERECO-BAIRRO TO SAI-BAIRRO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO, WSS_FD_SAIDA.SAI_BAIRRO);

            /*" -347- MOVE ENDERECO-CIDADE TO SAI-CIDADE */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, WSS_FD_SAIDA.SAI_CIDADE);

            /*" -348- MOVE ENDERECO-SIGLA-UF TO SAI-UF */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, WSS_FD_SAIDA.SAI_UF);

            /*" -349- MOVE ENDERECO-CEP TO SAI-CEP */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CEP, WSS_FD_SAIDA.SAI_CEP);

            /*" -350- MOVE HISLANCT-PRM-TOTAL TO SAI-VLR-CREDITO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_PRM_TOTAL, WSS_FD_SAIDA.SAI_VLR_CREDITO);

            /*" -352- MOVE HISLANCT-DATA-VENCIMENTO TO SAI-DTA-CREDITO */
            _.Move(HISLANCT.DCLHIST_LANC_CTA.HISLANCT_DATA_VENCIMENTO, WSS_FD_SAIDA.SAI_DTA_CREDITO);

            /*" -353- IF WSS-QTD-LIDOS EQUAL 1 */

            if (VARDISP.WSS_QTD_LIDOS == 1)
            {

                /*" -354- WRITE SAI-FD-VA0133B1 FROM WSS-FD-CABEC */
                _.Move(WSS_FD_CABEC.GetMoveValues(), SAI_FD_VA0133B1);

                VA0133B1.Write(SAI_FD_VA0133B1.GetMoveValues().ToString());

                /*" -355- WRITE SAI-FD-VA0133B2 FROM WSS-FD-CABEC */
                _.Move(WSS_FD_CABEC.GetMoveValues(), SAI_FD_VA0133B2);

                VA0133B2.Write(SAI_FD_VA0133B2.GetMoveValues().ToString());

                /*" -356- ADD 1 TO WSS-QTD-WRITE */
                VARDISP.WSS_QTD_WRITE.Value = VARDISP.WSS_QTD_WRITE + 1;

                /*" -358- END-IF */
            }


            /*" -362- IF HISLANCT-SIT-REGISTRO EQUAL SPACE */

            if (HISLANCT.DCLHIST_LANC_CTA.HISLANCT_SIT_REGISTRO == " ")
            {

                /*" -363- WRITE SAI-FD-VA0133B2 FROM WSS-FD-SAIDA */
                _.Move(WSS_FD_SAIDA.GetMoveValues(), SAI_FD_VA0133B2);

                VA0133B2.Write(SAI_FD_VA0133B2.GetMoveValues().ToString());

                /*" -364- ADD 1 TO WSS-QTD-REJ */
                VARDISP.WSS_QTD_REJ.Value = VARDISP.WSS_QTD_REJ + 1;

                /*" -365- ADD 1 TO WSS-QTD-WRITE */
                VARDISP.WSS_QTD_WRITE.Value = VARDISP.WSS_QTD_WRITE + 1;

                /*" -370- ELSE */
            }
            else
            {


                /*" -371- WRITE SAI-FD-VA0133B1 FROM WSS-FD-SAIDA */
                _.Move(WSS_FD_SAIDA.GetMoveValues(), SAI_FD_VA0133B1);

                VA0133B1.Write(SAI_FD_VA0133B1.GetMoveValues().ToString());

                /*" -372- ADD 1 TO WSS-QTD-PAGOS */
                VARDISP.WSS_QTD_PAGOS.Value = VARDISP.WSS_QTD_PAGOS + 1;

                /*" -373- ADD 1 TO WSS-QTD-WRITE */
                VARDISP.WSS_QTD_WRITE.Value = VARDISP.WSS_QTD_WRITE + 1;

                /*" -373- END-IF. */
            }


        }

        [StopWatch]
        /*" P9998-ERRO-DB2 */
        private void P9998_ERRO_DB2(bool isPerform = false)
        {
            /*" -379- MOVE SQLCODE TO WSS-COD-SQLC */
            _.Move(DB.SQLCODE, VARDISP.WSS_COD_SQLC);

            /*" -380- DISPLAY '//-**************************************-//' */
            _.Display($"//**************************************//");

            /*" -381- DISPLAY '  OCORRENCIA DE ERRO NO ACESSO A TABELA   ' */
            _.Display($"  OCORRENCIA DE ERRO NO ACESSO A TABELA   ");

            /*" -382- DISPLAY '//-**************************************-//' */
            _.Display($"//**************************************//");

            /*" -383- DISPLAY '  SQLCODE............ ' WSS-COD-SQLC */
            _.Display($"  SQLCODE............ {VARDISP.WSS_COD_SQLC}");

            /*" -384- DISPLAY '  SQLSTATE........... ' SQLSTATE */
            _.Display($"  SQLSTATE........... {DB.SQLSTATE}");

            /*" -385- DISPLAY '  SQLERRMC........... ' SQLERRMC */
            _.Display($"  SQLERRMC........... {DB.SQLERRMC}");

            /*" -386- DISPLAY '  POSICAO DO ERRO.... ' WSS-COD-ERRO */
            _.Display($"  POSICAO DO ERRO.... {VARDISP.WSS_COD_ERRO}");

            /*" -388- DISPLAY '//' */
            _.Display($"//");

            /*" -389- GO TO P9999-FINALIZA */

            P9999_FINALIZA(); //GOTO
            return;

            /*" -389- . */

        }

        [StopWatch]
        /*" P9998-DISPLAY-FETCH */
        private void P9998_DISPLAY_FETCH(bool isPerform = false)
        {
            /*" -394- IF WSS-QTD-LIDOS LESS 101 */

            if (VARDISP.WSS_QTD_LIDOS < 101)
            {

                /*" -395- DISPLAY '//DISPLAY-FETCH/SQLC=' SQLCODE */
                _.Display($"//DISPLAY-FETCH/SQLC={DB.SQLCODE}");

                /*" -396- DISPLAY '  NUM-CERTIFICADO   = ' HISLANCT-NUM-CERTIFICADO */
                _.Display($"  NUM-CERTIFICADO   = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_NUM_CERTIFICADO}");

                /*" -397- DISPLAY '  CODRET            = ' HISLANCT-CODRET */
                _.Display($"  CODRET            = {HISLANCT.DCLHIST_LANC_CTA.HISLANCT_CODRET}");

                /*" -398- DISPLAY '  COD-PRODUTO       = ' PROPOVA-COD-PRODUTO */
                _.Display($"  COD-PRODUTO       = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_PRODUTO}");

                /*" -399- DISPLAY '  COD-CLIENTE       = ' PROPOVA-COD-CLIENTE */
                _.Display($"  COD-CLIENTE       = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE}");

                /*" -400- DISPLAY '  NUM-APOLICE       = ' PROPOVA-NUM-APOLICE */
                _.Display($"  NUM-APOLICE       = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE}");

                /*" -401- DISPLAY '  NUM-PARCELA       = ' PROPOVA-NUM-PARCELA */
                _.Display($"  NUM-PARCELA       = {PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_PARCELA}");

                /*" -402- DISPLAY '  CGCCPF            = ' CLIENTES-CGCCPF */
                _.Display($"  CGCCPF            = {CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF}");

                /*" -403- DISPLAY '  NOME-RAZAO        = ' CLIENTES-NOME-RAZAO */
                _.Display($"  NOME-RAZAO        = {CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO}");

                /*" -404- DISPLAY '  OCORR-ENDERECO    = ' ENDERECO-OCORR-ENDERECO */
                _.Display($"  OCORR-ENDERECO    = {ENDERECO.DCLENDERECOS.ENDERECO_OCORR_ENDERECO}");

                /*" -405- DISPLAY '  ENDERECO          = ' ENDERECO-ENDERECO */
                _.Display($"  ENDERECO          = {ENDERECO.DCLENDERECOS.ENDERECO_ENDERECO}");

                /*" -406- DISPLAY '  BAIRRO            = ' ENDERECO-BAIRRO */
                _.Display($"  BAIRRO            = {ENDERECO.DCLENDERECOS.ENDERECO_BAIRRO}");

                /*" -407- DISPLAY '  CIDADE            = ' ENDERECO-CIDADE */
                _.Display($"  CIDADE            = {ENDERECO.DCLENDERECOS.ENDERECO_CIDADE}");

                /*" -408- DISPLAY '  SIGLA-UF          = ' ENDERECO-SIGLA-UF */
                _.Display($"  SIGLA-UF          = {ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF}");

                /*" -409- DISPLAY '  CEP               = ' ENDERECO-CEP */
                _.Display($"  CEP               = {ENDERECO.DCLENDERECOS.ENDERECO_CEP}");

                /*" -410- DISPLAY '  DDD               = ' ENDERECO-DDD */
                _.Display($"  DDD               = {ENDERECO.DCLENDERECOS.ENDERECO_DDD}");

                /*" -411- DISPLAY '  TELEFONE          = ' ENDERECO-TELEFONE */
                _.Display($"  TELEFONE          = {ENDERECO.DCLENDERECOS.ENDERECO_TELEFONE}");

                /*" -412- DISPLAY '  EMAIL             = ' CLIENEMA-EMAIL */
                _.Display($"  EMAIL             = {CLIENEMA.DCLCLIENTE_EMAIL.CLIENEMA_EMAIL}");

                /*" -413- DISPLAY '  SUSEP             = ' DB2-COD-SUSEP */
                _.Display($"  SUSEP             = {VARHOST.DB2_COD_SUSEP}");

                /*" -414- DISPLAY '//' */
                _.Display($"//");

                /*" -415- END-IF */
            }


            /*" -415- . */

        }

        [StopWatch]
        /*" P9999-FINALIZA */
        private void P9999_FINALIZA(bool isPerform = false)
        {
            /*" -419- PERFORM P9999_FINALIZA_DB_CLOSE_1 */

            P9999_FINALIZA_DB_CLOSE_1();

            /*" -423- CLOSE VA0133B1 VA0133B2 */
            VA0133B1.Close();
            VA0133B2.Close();

            /*" -424- IF WSS-COD-ERRO NOT EQUAL ZEROS */

            if (VARDISP.WSS_COD_ERRO != 00)
            {

                /*" -425- DISPLAY '//' */
                _.Display($"//");

                /*" -426- DISPLAY '//-**************************************-//' */
                _.Display($"//**************************************//");

                /*" -427- DISPLAY '  PROGRAMA VA0133B FINALIZADO COM ERRO    ' */
                _.Display($"  PROGRAMA VA0133B FINALIZADO COM ERRO    ");

                /*" -428- DISPLAY '//-**************************************-//' */
                _.Display($"//**************************************//");

                /*" -429- DISPLAY '  POSICAO DO ERRO.... ' WSS-COD-ERRO */
                _.Display($"  POSICAO DO ERRO.... {VARDISP.WSS_COD_ERRO}");

                /*" -430- DISPLAY '  Lidos.............. ' WSS-QTD-LIDOS */
                _.Display($"  Lidos.............. {VARDISP.WSS_QTD_LIDOS}");

                /*" -431- DISPLAY '   Aceitos........... ' WSS-QTD-PAGOS */
                _.Display($"   Aceitos........... {VARDISP.WSS_QTD_PAGOS}");

                /*" -432- DISPLAY '   Rejeitados........ ' WSS-QTD-REJ */
                _.Display($"   Rejeitados........ {VARDISP.WSS_QTD_REJ}");

                /*" -433- DISPLAY '//' */
                _.Display($"//");

                /*" -434- MOVE 99 TO RETURN-CODE */
                _.Move(99, RETURN_CODE);

                /*" -435- ELSE */
            }
            else
            {


                /*" -436- DISPLAY '//' */
                _.Display($"//");

                /*" -437- DISPLAY '//-***************************************-//' */
                _.Display($"//***************************************//");

                /*" -438- DISPLAY '  PROGRAMA VA0133B FINALIZADO COM EXITO    ' */
                _.Display($"  PROGRAMA VA0133B FINALIZADO COM EXITO    ");

                /*" -439- DISPLAY '//-***************************************-//' */
                _.Display($"//***************************************//");

                /*" -440- DISPLAY '  Lidos.............. ' WSS-QTD-LIDOS */
                _.Display($"  Lidos.............. {VARDISP.WSS_QTD_LIDOS}");

                /*" -441- DISPLAY '   Pagos............. ' WSS-QTD-PAGOS */
                _.Display($"   Pagos............. {VARDISP.WSS_QTD_PAGOS}");

                /*" -442- DISPLAY '   Rejeitados........ ' WSS-QTD-REJ */
                _.Display($"   Rejeitados........ {VARDISP.WSS_QTD_REJ}");

                /*" -443- DISPLAY '  Gravados........... ' WSS-QTD-WRITE */
                _.Display($"  Gravados........... {VARDISP.WSS_QTD_WRITE}");

                /*" -444- DISPLAY '   Pagos............. ' WSS-QTD-PAGOS */
                _.Display($"   Pagos............. {VARDISP.WSS_QTD_PAGOS}");

                /*" -445- DISPLAY '   Rejeitados........ ' WSS-QTD-REJ */
                _.Display($"   Rejeitados........ {VARDISP.WSS_QTD_REJ}");

                /*" -446- DISPLAY ' ' */
                _.Display($" ");

                /*" -447- END-IF */
            }


            /*" -447- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" P9999-FINALIZA-DB-CLOSE-1 */
        public void P9999_FINALIZA_DB_CLOSE_1()
        {
            /*" -419- EXEC SQL CLOSE C01 END-EXEC */

            C01.Close();

        }
    }
}