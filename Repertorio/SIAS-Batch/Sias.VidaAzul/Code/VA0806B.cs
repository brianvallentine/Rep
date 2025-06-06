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
using Sias.VidaAzul.DB2.VA0806B;

namespace Code
{
    public class VA0806B
    {
        public bool IsCall { get; set; }

        public VA0806B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      ******************************************************************      */
        /*"      ******************************************************************      */
        /*"      *      GERA A VG_FOLLOW_UP    (VAD00)                            *      */
        /*"      *          (TABELA QUE GUARDA OS LANCAMENTOS EM CONTA)           *      */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *  DESCRICAO SUMARIA                             15.01.2004      *      */
        /*"      *                                                                *      */
        /*"      *         O PROGRAMA LE O MOVIMENTO DE RETORNO DOS LANCAMENTOS   *      */
        /*"      *     DE DEBITO E CREDITO E EFETUA A INCLUSAO NA TABELA VG_FUP   *      */
        /*"      *     PARA POSTERIOR VERIFICACAO DAS OPERACOES NAO EFETUADAS.    *      */
        /*"      *                                                                *      */
        /*"      *                                    FREDERICO FONSECA           *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *     ALTERACAO XXXX                                                    */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 03...: INCIDENTE 534456                                 *      */
        /*"      *               RESOLVER -803 NA GE_AR_DETALHE (SEQ_GERACAO)     *      */
        /*"      * DATA .......: 21/09/2023                                       *      */
        /*"      * RESPONSAVEL.: KINKAS                              PROCURE V.03 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * VERSAO 02...: INCIDENTE 325585/TAREFA 327740                   *      */
        /*"      *               ACERTAR DISPLAY PARA IDENTIFICACAO DO PROBLEMA   *      */
        /*"      * DATA .......: 15/10/2021                                       *      */
        /*"      * RESPONSAVEL.: HUSNI ALI HUSNI                                  *      */
        /*"      *                                                   PROCURE V.02 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * PROJETO FGV (ALTERACOES)     (WELLINGTON VERAS (POLITEC))      *      */
        /*"      *                                                                *      */
        /*"      * 25/08/2008   INCLUIR CLAUS WITH UR NO COMANDO SELECT- WV0808   *      */
        /*"      * 16/09/2008   INIBIR O COMANDO DISPLAY               - WV0908   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *               - NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 21/07/2015 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"1     ******************************************************************      */
        #endregion


        #region VARIABLES

        public FileBasis _RETDEB { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RETDEB
        {
            get
            {
                _.Move(RETDEB_RECORD, _RETDEB); VarBasis.RedefinePassValue(RETDEB_RECORD, _RETDEB, RETDEB_RECORD); return _RETDEB;
            }
        }
        public FileBasis _RETCRE { get; set; } = new FileBasis(new PIC("X", "150", "X(150)"));

        public FileBasis RETCRE
        {
            get
            {
                _.Move(RETCRE_RECORD, _RETCRE); VarBasis.RedefinePassValue(RETCRE_RECORD, _RETCRE, RETCRE_RECORD); return _RETCRE;
            }
        }
        /*"01         RETDEB-RECORD       PIC X(150).*/
        public StringBasis RETDEB_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01         RET-HEADER.*/
        public VA0806B_RET_HEADER RET_HEADER { get; set; } = new VA0806B_RET_HEADER();
        public class VA0806B_RET_HEADER : VarBasis
        {
            /*"      05   RA-COD-REG          PIC X(001).*/
            public StringBasis RA_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      05   RA-COD-REMESSA      PIC 9(001).*/
            public IntBasis RA_COD_REMESSA { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"      05   RA-COD-CONVENIO     PIC 9(006).*/
            public IntBasis RA_COD_CONVENIO { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"      05   FILLER              PIC X(014).*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"      05   RA-NOME-EMPRESA     PIC X(020).*/
            public StringBasis RA_NOME_EMPRESA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"      05   RA-COD-BANCO        PIC 9(003).*/
            public IntBasis RA_COD_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"      05   RA-NOME-BANCO       PIC X(020).*/
            public StringBasis RA_NOME_BANCO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"      05   RA-DATA-GERACAO.*/
            public VA0806B_RA_DATA_GERACAO RA_DATA_GERACAO { get; set; } = new VA0806B_RA_DATA_GERACAO();
            public class VA0806B_RA_DATA_GERACAO : VarBasis
            {
                /*"       10  RA-AA-GER           PIC X(004).*/
                public StringBasis RA_AA_GER { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       10  RA-MM-GER           PIC X(002).*/
                public StringBasis RA_MM_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10  RA-DD-GER           PIC X(002).*/
                public StringBasis RA_DD_GER { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      05   RA-NSA              PIC 9(006).*/
            }
            public IntBasis RA_NSA { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"      05   RA-VERSAO-LAYOUT    PIC 9(002).*/
            public IntBasis RA_VERSAO_LAYOUT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      05   RA-SERVICO          PIC X(017).*/
            public StringBasis RA_SERVICO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"      05   RA-RESERVADO        PIC X(052).*/
            public StringBasis RA_RESERVADO { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01         RET-CADASTRAMENTO.*/
        }
        public VA0806B_RET_CADASTRAMENTO RET_CADASTRAMENTO { get; set; } = new VA0806B_RET_CADASTRAMENTO();
        public class VA0806B_RET_CADASTRAMENTO : VarBasis
        {
            /*"    05   RF-COD-REG          PIC X(001).*/
            public StringBasis RF_COD_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05   RF-IDENT-CLI-EMPRESA.*/
            public VA0806B_RF_IDENT_CLI_EMPRESA RF_IDENT_CLI_EMPRESA { get; set; } = new VA0806B_RF_IDENT_CLI_EMPRESA();
            public class VA0806B_RF_IDENT_CLI_EMPRESA : VarBasis
            {
                /*"       10  RF-IDENTIF-CLI      PIC 9(015).*/
                public IntBasis RF_IDENTIF_CLI { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10  RF-IDENTIF-CLI-R REDEFINES           RF-IDENTIF-CLI.*/
                private _REDEF_VA0806B_RF_IDENTIF_CLI_R _rf_identif_cli_r { get; set; }
                public _REDEF_VA0806B_RF_IDENTIF_CLI_R RF_IDENTIF_CLI_R
                {
                    get { _rf_identif_cli_r = new _REDEF_VA0806B_RF_IDENTIF_CLI_R(); _.Move(RF_IDENTIF_CLI, _rf_identif_cli_r); VarBasis.RedefinePassValue(RF_IDENTIF_CLI, _rf_identif_cli_r, RF_IDENTIF_CLI); _rf_identif_cli_r.ValueChanged += () => { _.Move(_rf_identif_cli_r, RF_IDENTIF_CLI); }; return _rf_identif_cli_r; }
                    set { VarBasis.RedefinePassValue(value, _rf_identif_cli_r, RF_IDENTIF_CLI); }
                }  //Redefines
                public class _REDEF_VA0806B_RF_IDENTIF_CLI_R : VarBasis
                {
                    /*"           15 FILLER           PIC X(015).*/
                    public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10  RF-IDENTIF-NSA      PIC 9(005).*/

                    public _REDEF_VA0806B_RF_IDENTIF_CLI_R()
                    {
                        FILLER_1.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis RF_IDENTIF_NSA { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10  FILLER              PIC X(005).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    05 RF-AGECTADEB            PIC 9(004).*/
            }
            public IntBasis RF_AGECTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 RF-IDENT-CLI-BANCO.*/
            public VA0806B_RF_IDENT_CLI_BANCO RF_IDENT_CLI_BANCO { get; set; } = new VA0806B_RF_IDENT_CLI_BANCO();
            public class VA0806B_RF_IDENT_CLI_BANCO : VarBasis
            {
                /*"       10  RF-COD-OPRCTADEB    PIC 9(004).*/
                public IntBasis RF_COD_OPRCTADEB { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  RF-NUM-NUMCTADEB    PIC 9(012).*/
                public IntBasis RF_NUM_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10  RF-DIG-NUMCTADEB    PIC 9(001).*/
                public IntBasis RF_DIG_NUMCTADEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10  FILLER              PIC X(002).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RF-DATA-REAL.*/
            }
            public VA0806B_RF_DATA_REAL RF_DATA_REAL { get; set; } = new VA0806B_RF_DATA_REAL();
            public class VA0806B_RF_DATA_REAL : VarBasis
            {
                /*"       10  RF-ANO-REAL         PIC 9(004).*/
                public IntBasis RF_ANO_REAL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  RF-MES-REAL         PIC 9(002).*/
                public IntBasis RF_MES_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10  RF-DIA-REAL         PIC 9(002).*/
                public IntBasis RF_DIA_REAL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 RF-VLPRMTOT             PIC 9(013)V99.*/
            }
            public DoubleBasis RF_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05 RF-COD-RETORNO          PIC 9(002).*/
            public IntBasis RF_COD_RETORNO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 RF-USO-EMPRESA.*/
            public VA0806B_RF_USO_EMPRESA RF_USO_EMPRESA { get; set; } = new VA0806B_RF_USO_EMPRESA();
            public class VA0806B_RF_USO_EMPRESA : VarBasis
            {
                /*"       10  RF-NSA              PIC 9(003).*/
                public IntBasis RF_NSA { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  RF-NSL              PIC 9(008).*/
                public IntBasis RF_NSL { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10  FILLER              PIC X(047).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)."), @"");
                /*"    05 RF-RESERVADO            PIC X(017).*/
            }
            public StringBasis RF_RESERVADO { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RF-COD-MOVIMENTO        PIC 9(001).*/
            public IntBasis RF_COD_MOVIMENTO { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01         RETCRE-RECORD       PIC X(150).*/
        }
        public StringBasis RETCRE_RECORD { get; set; } = new StringBasis(new PIC("X", "150", "X(150)."), @"");
        /*"01         RET-HEADERC.*/
        public VA0806B_RET_HEADERC RET_HEADERC { get; set; } = new VA0806B_RET_HEADERC();
        public class VA0806B_RET_HEADERC : VarBasis
        {
            /*"      05   RA-COD-REGC         PIC X(001).*/
            public StringBasis RA_COD_REGC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"      05   RA-COD-REMESSAC     PIC 9(001).*/
            public IntBasis RA_COD_REMESSAC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"      05   RA-COD-CONVENIOC    PIC 9(006).*/
            public IntBasis RA_COD_CONVENIOC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"      05   FILLER              PIC X(014).*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)."), @"");
            /*"      05   RA-NOME-EMPRESAC    PIC X(020).*/
            public StringBasis RA_NOME_EMPRESAC { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"      05   RA-COD-BANCOC       PIC 9(003).*/
            public IntBasis RA_COD_BANCOC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
            /*"      05   RA-NOME-BANCOC      PIC X(020).*/
            public StringBasis RA_NOME_BANCOC { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
            /*"      05   RA-DATA-GERACAOC.*/
            public VA0806B_RA_DATA_GERACAOC RA_DATA_GERACAOC { get; set; } = new VA0806B_RA_DATA_GERACAOC();
            public class VA0806B_RA_DATA_GERACAOC : VarBasis
            {
                /*"       10  RA-AA-GERC          PIC X(004).*/
                public StringBasis RA_AA_GERC { get; set; } = new StringBasis(new PIC("X", "4", "X(004)."), @"");
                /*"       10  RA-MM-GERC          PIC X(002).*/
                public StringBasis RA_MM_GERC { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"       10  RA-DD-GERC          PIC X(002).*/
                public StringBasis RA_DD_GERC { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      05   RA-NSAC             PIC 9(006).*/
            }
            public IntBasis RA_NSAC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"      05   RA-VERSAO-LAYOUTC   PIC 9(002).*/
            public IntBasis RA_VERSAO_LAYOUTC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"      05   RA-SERVICOC         PIC X(017).*/
            public StringBasis RA_SERVICOC { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"      05   RA-RESERVADOC       PIC X(052).*/
            public StringBasis RA_RESERVADOC { get; set; } = new StringBasis(new PIC("X", "52", "X(052)."), @"");
            /*"01         RET-CADASTRAMENTOC.*/
        }
        public VA0806B_RET_CADASTRAMENTOC RET_CADASTRAMENTOC { get; set; } = new VA0806B_RET_CADASTRAMENTOC();
        public class VA0806B_RET_CADASTRAMENTOC : VarBasis
        {
            /*"    05   RF-COD-REGC         PIC X(001).*/
            public StringBasis RF_COD_REGC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05   RF-IDENT-CLI-EMPRESAC.*/
            public VA0806B_RF_IDENT_CLI_EMPRESAC RF_IDENT_CLI_EMPRESAC { get; set; } = new VA0806B_RF_IDENT_CLI_EMPRESAC();
            public class VA0806B_RF_IDENT_CLI_EMPRESAC : VarBasis
            {
                /*"       10  RF-IDENTIF-CLIC     PIC 9(015).*/
                public IntBasis RF_IDENTIF_CLIC { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
                /*"       10  RF-IDENTIF-CLI-RC REDEFINES           RF-IDENTIF-CLIC.*/
                private _REDEF_VA0806B_RF_IDENTIF_CLI_RC _rf_identif_cli_rc { get; set; }
                public _REDEF_VA0806B_RF_IDENTIF_CLI_RC RF_IDENTIF_CLI_RC
                {
                    get { _rf_identif_cli_rc = new _REDEF_VA0806B_RF_IDENTIF_CLI_RC(); _.Move(RF_IDENTIF_CLIC, _rf_identif_cli_rc); VarBasis.RedefinePassValue(RF_IDENTIF_CLIC, _rf_identif_cli_rc, RF_IDENTIF_CLIC); _rf_identif_cli_rc.ValueChanged += () => { _.Move(_rf_identif_cli_rc, RF_IDENTIF_CLIC); }; return _rf_identif_cli_rc; }
                    set { VarBasis.RedefinePassValue(value, _rf_identif_cli_rc, RF_IDENTIF_CLIC); }
                }  //Redefines
                public class _REDEF_VA0806B_RF_IDENTIF_CLI_RC : VarBasis
                {
                    /*"           15 FILLER           PIC X(015).*/
                    public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                    /*"       10  RF-IDENTIF-NSAC     PIC 9(005).*/

                    public _REDEF_VA0806B_RF_IDENTIF_CLI_RC()
                    {
                        FILLER_6.ValueChanged += OnValueChanged;
                    }

                }
                public IntBasis RF_IDENTIF_NSAC { get; set; } = new IntBasis(new PIC("9", "5", "9(005)."));
                /*"       10  FILLER              PIC X(005).*/
                public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"    05 RF-AGECTADEBC           PIC 9(004).*/
            }
            public IntBasis RF_AGECTADEBC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 RF-IDENT-CLI-BANCOC.*/
            public VA0806B_RF_IDENT_CLI_BANCOC RF_IDENT_CLI_BANCOC { get; set; } = new VA0806B_RF_IDENT_CLI_BANCOC();
            public class VA0806B_RF_IDENT_CLI_BANCOC : VarBasis
            {
                /*"       10  RF-COD-OPRCTADEBC   PIC 9(004).*/
                public IntBasis RF_COD_OPRCTADEBC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  RF-NUM-NUMCTADEBC   PIC 9(012).*/
                public IntBasis RF_NUM_NUMCTADEBC { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"       10  RF-DIG-NUMCTADEBC   PIC 9(001).*/
                public IntBasis RF_DIG_NUMCTADEBC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
                /*"       10  FILLER              PIC X(002).*/
                public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"    05 RF-DATA-REALC.*/
            }
            public VA0806B_RF_DATA_REALC RF_DATA_REALC { get; set; } = new VA0806B_RF_DATA_REALC();
            public class VA0806B_RF_DATA_REALC : VarBasis
            {
                /*"       10  RF-ANO-REALC        PIC 9(004).*/
                public IntBasis RF_ANO_REALC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"       10  RF-MES-REALC        PIC 9(002).*/
                public IntBasis RF_MES_REALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"       10  RF-DIA-REALC        PIC 9(002).*/
                public IntBasis RF_DIA_REALC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 RF-VLPRMTOTC            PIC 9(013)V99.*/
            }
            public DoubleBasis RF_VLPRMTOTC { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
            /*"    05 RF-COD-RETORNOC         PIC 9(002).*/
            public IntBasis RF_COD_RETORNOC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
            /*"    05 RF-USO-EMPRESAC.*/
            public VA0806B_RF_USO_EMPRESAC RF_USO_EMPRESAC { get; set; } = new VA0806B_RF_USO_EMPRESAC();
            public class VA0806B_RF_USO_EMPRESAC : VarBasis
            {
                /*"       10  RF-NSAC             PIC 9(003).*/
                public IntBasis RF_NSAC { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"       10  RF-NSLC             PIC 9(008).*/
                public IntBasis RF_NSLC { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"       10  FILLER              PIC X(047).*/
                public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "47", "X(047)."), @"");
                /*"    05 RF-RESERVADOC           PIC X(017).*/
            }
            public StringBasis RF_RESERVADOC { get; set; } = new StringBasis(new PIC("X", "17", "X(017)."), @"");
            /*"    05 RF-COD-MOVIMENTOC       PIC 9(001).*/
            public IntBasis RF_COD_MOVIMENTOC { get; set; } = new IntBasis(new PIC("9", "1", "9(001)."));
            /*"01  RET-TRAILLERC.*/
        }
        public VA0806B_RET_TRAILLERC RET_TRAILLERC { get; set; } = new VA0806B_RET_TRAILLERC();
        public class VA0806B_RET_TRAILLERC : VarBasis
        {
            /*"    05 RZ-COD-REGC             PIC X(001).*/
            public StringBasis RZ_COD_REGC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    05 RZ-QTDE-REGISTROSC      PIC 9(006).*/
            public IntBasis RZ_QTDE_REGISTROSC { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
            /*"    05 RZ-TOT-DEB-CRUZC        PIC 9(015)V99.*/
            public DoubleBasis RZ_TOT_DEB_CRUZC { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 RZ-TOT-CRED-CRUZC       PIC 9(015)V99.*/
            public DoubleBasis RZ_TOT_CRED_CRUZC { get; set; } = new DoubleBasis(new PIC("9", "15", "9(015)V99."), 2);
            /*"    05 RZ-RESERVADOC           PIC X(109).*/
            public StringBasis RZ_RESERVADOC { get; set; } = new StringBasis(new PIC("X", "109", "X(109)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"*/
        public IntBasis WS_PRD { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_TIP { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"*/
        public IntBasis WS_SIT { get; set; } = new IntBasis(new PIC("9", "4", "9(4)"));
        /*"01  VIND-RISCO                       PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_RISCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-TEM-SAF                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_TEM_SAF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-TEM-CDG                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_TEM_CDG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-DTMOVTO                     PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_DTMOVTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WHOST-SITUACAO                   PIC  X(01).*/
        public StringBasis WHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0SIST-DTMOVABE                  PIC X(10).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0FTCF-DTRET                     PIC X(10).*/
        public StringBasis V0FTCF_DTRET { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0FTCF-DTRET2                    PIC X(10).*/
        public StringBasis V0FTCF_DTRET2 { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0FTCF-NSAC                      PIC S9(04)    COMP.*/
        public IntBasis V0FTCF_NSAC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-NSAC                          PIC  9(09).*/
        public IntBasis WS_NSAC { get; set; } = new IntBasis(new PIC("9", "9", "9(09)."));
        /*"01  WS-BANCO                         PIC  9(03).*/
        public IntBasis WS_BANCO { get; set; } = new IntBasis(new PIC("9", "3", "9(03)."));
        /*"01  V0FTCF-NSAC1                     PIC S9(04)    COMP.*/
        public IntBasis V0FTCF_NSAC1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0FTCF-QTLANCDB                  PIC S9(09)    COMP.*/
        public IntBasis V0FTCF_QTLANCDB { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0FTCF-QTREG                     PIC S9(09)    COMP.*/
        public IntBasis V0FTCF_QTREG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0FTCF-QTDBEFET                  PIC S9(09)    COMP.*/
        public IntBasis V0FTCF_QTDBEFET { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0FTCF-TOTDBEFET                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0FTCF_TOTDBEFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0FTCF-TOTDBNEFET                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0FTCF_TOTDBNEFET { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0FTCF-VERSAO                    PIC S9(04)    COMP.*/
        public IntBasis V0FTCF_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  WS-VERSAO                        PIC S9(04)    COMP.*/
        public IntBasis WS_VERSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTVA-PRMVG                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTVA_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTVA-PRMAP                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTVA_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTVA-VLCOBADIC                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTVA_VLCOBADIC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0CAPI-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0CAPI_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PRVG-RISCO                     PIC  X(01).*/
        public StringBasis V0PRVG_RISCO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-TEM-SAF                   PIC  X(01).*/
        public StringBasis V0PRVG_TEM_SAF { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-TEM-CDG                   PIC  X(01).*/
        public StringBasis V0PRVG_TEM_CDG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-ORIG-PRODU                PIC  X(10).*/
        public StringBasis V0PRVG_ORIG_PRODU { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PRVG-CUSTOCAP-TOTAL            PIC  X(01).*/
        public StringBasis V0PRVG_CUSTOCAP_TOTAL { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PRVG-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0PRVG_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCTA-AGECTADEB                 PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_AGECTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-CODRET                    PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_CODRET { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-DIGCTADEB                 PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_DIGCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-NUMCTADEB                 PIC S9(13)    COMP-3.*/
        public IntBasis V0HCTA_NUMCTADEB { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0HCTA-NRCERTIF                  PIC S9(15)    COMP-3.*/
        public IntBasis V0HCTA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0HCTA-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-NSAS                      PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_NSAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-NSL                       PIC S9(09)    COMP.*/
        public IntBasis V0HCTA_NSL { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0HCTA-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0HCTA_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCTA-OPRCTADEB                 PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_OPRCTADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-OCORHISTCTA               PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_OCORHISTCTA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTA-SITUACAO                  PIC  X(01).*/
        public StringBasis V0HCTA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCTA-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCTA_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCTA-OCORHISTCOB               PIC S9(04)    COMP.*/
        public IntBasis V0HCTA_OCORHISTCOB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCTB-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0HCTB_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PARC-DTVENCTO                  PIC  X(10).*/
        public StringBasis V0PARC_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0PARC-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0PARC_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PARC-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-PRMTOT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0PARC-PRMTOTVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0PARC_PRMTOTVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0RCDG-DTREFER                   PIC  X(10).*/
        public StringBasis V0RCDG_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RCDG-SITUACAO                  PIC  X(01).*/
        public StringBasis V0RCDG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0RSAF-DTREFER                   PIC  X(10).*/
        public StringBasis V0RSAF_DTREFER { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0RSAF-SITUACAO                  PIC  X(01).*/
        public StringBasis V0RSAF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0PROP-CODCLIEN                  PIC S9(09)    COMP.*/
        public IntBasis V0PROP_CODCLIEN { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0PROP-CODSUBES                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-CODPRODU                  PIC S9(04)    COMP.*/
        public IntBasis V0PROP_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-FONTE                     PIC S9(04)    COMP.*/
        public IntBasis V0PROP_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-NRPARCE                   PIC S9(04)    COMP.*/
        public IntBasis V0PROP_NRPARCE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-NUM-APOLICE               PIC S9(13)    COMP-3.*/
        public IntBasis V0PROP_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0PROP-NRMATRFUN                 PIC S9(15)    COMP-3.*/
        public IntBasis V0PROP_NRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "15", "S9(15)"));
        /*"01  V0PROP-INRMATRFUN                PIC S9(04)    COMP.*/
        public IntBasis V0PROP_INRMATRFUN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-QTDPARATZ                 PIC S9(04)    COMP.*/
        public IntBasis V0PROP_QTDPARATZ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0PROP-SITUACAO                  PIC  X(01).*/
        public StringBasis V0PROP_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0COBP-VLPREMIO                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLPREMIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-PRMVG                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_PRMVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-PRMAP                     PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_PRMAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPSEGCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-IMPSEGAUXF                PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_IMPSEGAUXF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-VLCUSTAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBP_VLCUSTAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBP-IMPSEGAUXF-I              PIC S9(04)    COMP.*/
        public IntBasis V0COBP_IMPSEGAUXF_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0COBP-VLCUSTCAP                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0COBP_VLCUSTCAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0COBP-QTTITCAP                  PIC S9(04)    COMP.*/
        public IntBasis V0COBP_QTTITCAP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0CDGC-VLCUSTCDG                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0CDGC_VLCUSTCDG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0SAFC-VLCUSTSAF                 PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SAFC_VLCUSTSAF { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCOB-DTALTOPC                  PIC  X(10).*/
        public StringBasis V0HCOB_DTALTOPC { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0HCOB-DTVENCTO                  PIC  X(10).*/
        public StringBasis V0HCOB_DTVENCTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0HCOB-NRTIT                     PIC S9(13)    COMP-3.*/
        public IntBasis V0HCOB_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(13)"));
        /*"01  V0HCOB-OCORHIST                  PIC S9(04)    COMP.*/
        public IntBasis V0HCOB_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0HCOB-SITUACAO                  PIC  X(01).*/
        public StringBasis V0HCOB_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0HCOB-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0HCOB_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0HCOB-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0HCOB_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0OPCP-DIADEB                    PIC S9(04)    COMP.*/
        public IntBasis V0OPCP_DIADEB { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0OPCP-OPCAOPAG                  PIC  X(01).*/
        public StringBasis V0OPCP_OPCAOPAG { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0OPCP-PERIPGTO                  PIC S9(04)    COMP.*/
        public IntBasis V0OPCP_PERIPGTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0DIFP-CODOPER                   PIC S9(04)    COMP.*/
        public IntBasis V0DIFP_CODOPER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0DIFP-NRPARCEL                  PIC S9(04)    COMP.*/
        public IntBasis V0DIFP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0DIFP-PRMDEVVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDEVVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMDEVAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDEVAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMPAGVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMPAGVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMPAGAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMPAGAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMDIFVG                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFVG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0DIFP-PRMDIFAP                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0DIFP_PRMDIFAP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-BCOAVISO                  PIC S9(04)    COMP VALUE +0*/
        public IntBasis V0AVIS_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-AGEAVISO                  PIC S9(04)    COMP VALUE +0*/
        public IntBasis V0AVIS_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-NRAVISO                   PIC S9(09)    COMP VALUE +0*/
        public IntBasis V0AVIS_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0AVIS-NRSEQ                     PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_NRSEQ { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-DTMOVTO                   PIC X(10).*/
        public StringBasis V0AVIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0AVIS-OPERACAO                  PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-TIPAVI                    PIC X(01).*/
        public StringBasis V0AVIS_TIPAVI { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0AVIS-DTAVISO                   PIC X(10).*/
        public StringBasis V0AVIS_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0AVIS-VLIOCC                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-VLDESPES                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLDESPES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-PRECED                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_PRECED { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-VLPRMLIQ                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-VLPRMTOT                  PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0AVIS-SITCONTB                  PIC X(01).*/
        public StringBasis V0AVIS_SITCONTB { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0AVIS-CODEMP                    PIC S9(09)    COMP.*/
        public IntBasis V0AVIS_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0AVIS-ORIGAVISO                 PIC S9(04)    COMP.*/
        public IntBasis V0AVIS_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0AVIS-VALADT                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0AVIS_VALADT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  VIND-CODEMP                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_CODEMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-ORIGAVISO                   PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_ORIGAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  VIND-VALADT                      PIC S9(04)    COMP VALUE +0*/
        public IntBasis VIND_VALADT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0SALD-CODEMP                    PIC S9(09)    COMP.*/
        public IntBasis V0SALD_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0SALD-BCOAVISO                  PIC S9(04)    COMP.*/
        public IntBasis V0SALD_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0SALD-AGEAVISO                  PIC S9(04)    COMP.*/
        public IntBasis V0SALD_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(04)"));
        /*"01  V0SALD-TIPSGU                    PIC X(01).*/
        public StringBasis V0SALD_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01  V0SALD-NRAVISO                   PIC S9(09)    COMP.*/
        public IntBasis V0SALD_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01  V0SALD-DTAVISO                   PIC X(10).*/
        public StringBasis V0SALD_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SALD-DTMOVTO                   PIC X(10).*/
        public StringBasis V0SALD_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(10)."), @"");
        /*"01  V0SALD-SDOATU                    PIC S9(13)V99 COMP-3.*/
        public DoubleBasis V0SALD_SDOATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(13)V99"), 2);
        /*"01  V0SALD-SITUACAO                  PIC X(01).*/
        public StringBasis V0SALD_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(01)."), @"");
        /*"01    WSHOST-CODPRODU           PIC S9(004)    COMP.*/
        public IntBasis WSHOST_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    WSHOST-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-VLBALCAO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-VLDESCON           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis WSHOST_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    WSHOST-SITUACAO           PIC  X(001).*/
        public StringBasis WSHOST_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    WHOST-CODCONV             PIC S9(09)      COMP.*/
        public IntBasis WHOST_CODCONV { get; set; } = new IntBasis(new PIC("S9", "9", "S9(09)"));
        /*"01    V0PROD-CODPRODU           PIC S9(004)    VALUE +0   COMP.*/
        public IntBasis V0PROD_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-CODEMP             PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_CODEMP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0DPCF-ANOREF             PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_ANOREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-MESREF             PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_MESREF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-BCOAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_BCOAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-AGEAVISO           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_AGEAVISO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-NRAVISO            PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_NRAVISO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0DPCF-CODPRODU           PIC S9(004)     COMP.*/
        public IntBasis V0DPCF_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01    V0DPCF-TIPOREG            PIC  X(001).*/
        public StringBasis V0DPCF_TIPOREG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0DPCF-SITUACAO           PIC  X(001).*/
        public StringBasis V0DPCF_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0DPCF-TIPOCOB            PIC  X(001).*/
        public StringBasis V0DPCF_TIPOCOB { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01    V0DPCF-DTMOVTO            PIC  X(010).*/
        public StringBasis V0DPCF_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01    V0DPCF-DTAVISO            PIC  X(010).*/
        public StringBasis V0DPCF_DTAVISO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"01    V0DPCF-QTDREG             PIC S9(009)     COMP.*/
        public IntBasis V0DPCF_QTDREG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01    V0DPCF-VLPRMTOT           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLPRMLIQ           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLTARIFA           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLBALCAO           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLIOCC             PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLDESCON           PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLJUROS            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLJUROS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    V0DPCF-VLMULTA            PIC S9(013)V99  COMP-3.*/
        public DoubleBasis V0DPCF_VLMULTA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01  WORK-AREA.*/
        public VA0806B_WORK_AREA WORK_AREA { get; set; } = new VA0806B_WORK_AREA();
        public class VA0806B_WORK_AREA : VarBasis
        {
            /*"    05 AC-LIDOS                      PIC 9(7) VALUE 0.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05 AC-CONTA                      PIC 9(7) VALUE 0.*/
            public IntBasis AC_CONTA { get; set; } = new IntBasis(new PIC("9", "7", "9(7)"));
            /*"    05      DATA-SQL.*/
            public VA0806B_DATA_SQL DATA_SQL { get; set; } = new VA0806B_DATA_SQL();
            public class VA0806B_DATA_SQL : VarBasis
            {
                /*"      10    ANO-SQL                  PIC  9(004).*/
                public IntBasis ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    MES-SQL                  PIC  9(002).*/
                public IntBasis MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10    FILLER                   PIC  X(001) VALUE '-'.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"      10    DIA-SQL                  PIC  9(002).*/
                public IntBasis DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-TIME                       PIC  X(008).*/
            }
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 WS-DATA-INV.*/
            public VA0806B_WS_DATA_INV WS_DATA_INV { get; set; } = new VA0806B_WS_DATA_INV();
            public class VA0806B_WS_DATA_INV : VarBasis
            {
                /*"      10 WS-ANO-INV                  PIC  9(004).*/
                public IntBasis WS_ANO_INV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10 WS-MES-INV                  PIC  9(002).*/
                public IntBasis WS_MES_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10 WS-DIA-INV                  PIC  9(002).*/
                public IntBasis WS_DIA_INV { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05 WS-ARQUIVO                    PIC  X(008).*/
            }
            public StringBasis WS_ARQUIVO { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"    05 WS-ARQUIVO-R REDEFINES WS-ARQUIVO.*/
            private _REDEF_VA0806B_WS_ARQUIVO_R _ws_arquivo_r { get; set; }
            public _REDEF_VA0806B_WS_ARQUIVO_R WS_ARQUIVO_R
            {
                get { _ws_arquivo_r = new _REDEF_VA0806B_WS_ARQUIVO_R(); _.Move(WS_ARQUIVO, _ws_arquivo_r); VarBasis.RedefinePassValue(WS_ARQUIVO, _ws_arquivo_r, WS_ARQUIVO); _ws_arquivo_r.ValueChanged += () => { _.Move(_ws_arquivo_r, WS_ARQUIVO); }; return _ws_arquivo_r; }
                set { VarBasis.RedefinePassValue(value, _ws_arquivo_r, WS_ARQUIVO); }
            }  //Redefines
            public class _REDEF_VA0806B_WS_ARQUIVO_R : VarBasis
            {
                /*"      10 WS-INICIAL-ARQ              PIC  X(001).*/
                public StringBasis WS_INICIAL_ARQ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10 WS-CONVENIO-ARQ             PIC  9(006).*/
                public IntBasis WS_CONVENIO_ARQ { get; set; } = new IntBasis(new PIC("9", "6", "9(006)."));
                /*"      10 WS-CONVENIO-ARQ-R REDEFINES WS-CONVENIO-ARQ.*/
                private _REDEF_VA0806B_WS_CONVENIO_ARQ_R _ws_convenio_arq_r { get; set; }
                public _REDEF_VA0806B_WS_CONVENIO_ARQ_R WS_CONVENIO_ARQ_R
                {
                    get { _ws_convenio_arq_r = new _REDEF_VA0806B_WS_CONVENIO_ARQ_R(); _.Move(WS_CONVENIO_ARQ, _ws_convenio_arq_r); VarBasis.RedefinePassValue(WS_CONVENIO_ARQ, _ws_convenio_arq_r, WS_CONVENIO_ARQ); _ws_convenio_arq_r.ValueChanged += () => { _.Move(_ws_convenio_arq_r, WS_CONVENIO_ARQ); }; return _ws_convenio_arq_r; }
                    set { VarBasis.RedefinePassValue(value, _ws_convenio_arq_r, WS_CONVENIO_ARQ); }
                }  //Redefines
                public class _REDEF_VA0806B_WS_CONVENIO_ARQ_R : VarBasis
                {
                    /*"         15  WS-CONVENIO-4           PIC  9(004).*/
                    public IntBasis WS_CONVENIO_4 { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"         15  WS-CONVENIO-2           PIC  9(002).*/
                    public IntBasis WS_CONVENIO_2 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      10 WS-FINAL-ARQ                PIC  X(001).*/

                    public _REDEF_VA0806B_WS_CONVENIO_ARQ_R()
                    {
                        WS_CONVENIO_4.ValueChanged += OnValueChanged;
                        WS_CONVENIO_2.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WS_FINAL_ARQ { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    05      WS-EOF                   PIC  9(001) VALUE 0.*/

                public _REDEF_VA0806B_WS_ARQUIVO_R()
                {
                    WS_INICIAL_ARQ.ValueChanged += OnValueChanged;
                    WS_CONVENIO_ARQ.ValueChanged += OnValueChanged;
                    WS_CONVENIO_ARQ_R.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_EOF { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-EOF-C                 PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOF_C { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-EOF-D                 PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOF_D { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-EOF-CRE               PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOF_CRE { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-EOF-DEB               PIC  9(001) VALUE 0.*/
            public IntBasis WS_EOF_DEB { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WS-NAO-ACHEI             PIC  9(001) VALUE 0.*/
            public IntBasis WS_NAO_ACHEI { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
            /*"    05      WGEARDETA-SEQ-GERACAO    PIC S9(009) COMP VALUE 0.*/
            public IntBasis WGEARDETA_SEQ_GERACAO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05      WS-CODCONV               PIC  9(004).*/
            public IntBasis WS_CODCONV { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
            /*"    05 WS-REGISTROS              PIC  9(9)      VALUE  0.*/
            public IntBasis WS_REGISTROS { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
            /*"    05 WS-QTDBEFET               PIC  9(9)      VALUE  0.*/
            public IntBasis WS_QTDBEFET { get; set; } = new IntBasis(new PIC("9", "9", "9(9)"));
            /*"    05 WS-ACG-TOTDBEFET          PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis WS_ACG_TOTDBEFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-ACG-TOTDBNEFET         PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis WS_ACG_TOTDBNEFET { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-DIFERENCA              PIC  9(13)V99  VALUE  0.*/
            public DoubleBasis WS_DIFERENCA { get; set; } = new DoubleBasis(new PIC("9", "13", "9(13)V99"), 2);
            /*"    05 WS-PC-VG                  PIC  9(03)V9(7) VALUE  0.*/
            public DoubleBasis WS_PC_VG { get; set; } = new DoubleBasis(new PIC("9", "3", "9(03)V9(7)"), 7);
            /*"    05 WS-AC-CRE                 PIC  9(13)      VALUE  0.*/
            public IntBasis WS_AC_CRE { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    05 WS-AC-DEB                 PIC  9(13)      VALUE  0.*/
            public IntBasis WS_AC_DEB { get; set; } = new IntBasis(new PIC("9", "13", "9(13)"));
            /*"    05       WS-SUBS           PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WS-SUBS1          PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS1 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WS-SUBS2          PIC  9(005)    VALUE ZEROS.*/
            public IntBasis WS_SUBS2 { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    05       WFIM-PRODUTO      PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_PRODUTO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    05       WDATA-REL         PIC  X(010)    VALUE SPACES.*/
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"    05       FILLER            REDEFINES      WDATA-REL.*/
            private _REDEF_VA0806B_FILLER_12 _filler_12 { get; set; }
            public _REDEF_VA0806B_FILLER_12 FILLER_12
            {
                get { _filler_12 = new _REDEF_VA0806B_FILLER_12(); _.Move(WDATA_REL, _filler_12); VarBasis.RedefinePassValue(WDATA_REL, _filler_12, WDATA_REL); _filler_12.ValueChanged += () => { _.Move(_filler_12, WDATA_REL); }; return _filler_12; }
                set { VarBasis.RedefinePassValue(value, _filler_12, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VA0806B_FILLER_12 : VarBasis
            {
                /*"      10     WDAT-REL-ANO      PIC  9(004).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-MES      PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      10     FILLER            PIC  X(001).*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      10     WDAT-REL-DIA      PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01           WS-EDIT.*/

                public _REDEF_VA0806B_FILLER_12()
                {
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_13.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_14.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
        }
        public VA0806B_WS_EDIT WS_EDIT { get; set; } = new VA0806B_WS_EDIT();
        public class VA0806B_WS_EDIT : VarBasis
        {
            /*"    05         WS-INTEGER        PIC  999999999 OCCURS 5 TIMES.*/
            public ListBasis<IntBasis, Int64> WS_INTEGER { get; set; } = new ListBasis<IntBasis, Int64>(new PIC("9", "9", "999999999"), 5);
            /*"    05 WSQLCODE3                     PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"    05      WABEND.*/
            public VA0806B_WABEND WABEND { get; set; } = new VA0806B_WABEND();
            public class VA0806B_WABEND : VarBasis
            {
                /*"      10    FILLER                   PIC  X(010) VALUE            'VA0806B  '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"VA0806B  ");
                /*"      10    FILLER                   PIC  X(028) VALUE            ' *** ERRO  EXEC SQL ***'.*/
                public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL ***");
                /*"      10    FILLER                   PIC  X(014) VALUE            '    SQLCODE = '.*/
                public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"      10    WSQLCODE                 PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD1 = '.*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD1 = ");
                /*"      10    WSQLERRD1                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD1 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"      10    WSQLERRD2                PIC  ZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLERRD2 { get; set; } = new IntBasis(new PIC("9", "8", "ZZZZ999-"));
                /*"      10    FILLER                   PIC  X(014)   VALUE            '   SQLERRD2 = '.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"   SQLERRD2 = ");
                /*"    05      LOCALIZA-ABEND-1.*/
            }
            public VA0806B_LOCALIZA_ABEND_1 LOCALIZA_ABEND_1 { get; set; } = new VA0806B_LOCALIZA_ABEND_1();
            public class VA0806B_LOCALIZA_ABEND_1 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'PARAGRAFO = '.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"PARAGRAFO = ");
                /*"      10    PARAGRAFO                PIC  X(040)   VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
                /*"    05      LOCALIZA-ABEND-2.*/
            }
            public VA0806B_LOCALIZA_ABEND_2 LOCALIZA_ABEND_2 { get; set; } = new VA0806B_LOCALIZA_ABEND_2();
            public class VA0806B_LOCALIZA_ABEND_2 : VarBasis
            {
                /*"      10    FILLER                   PIC  X(012)   VALUE            'COMANDO   = '.*/
                public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"COMANDO   = ");
                /*"      10    COMANDO                  PIC  X(060)   VALUE SPACES.*/
                public StringBasis COMANDO { get; set; } = new StringBasis(new PIC("X", "60", "X(060)"), @"");
                /*"01  AUX-TABELAS.*/
            }
        }
        public VA0806B_AUX_TABELAS AUX_TABELAS { get; set; } = new VA0806B_AUX_TABELAS();
        public class VA0806B_AUX_TABELAS : VarBasis
        {
            /*"  03          WTABG-VALORES.*/
            public VA0806B_WTABG_VALORES WTABG_VALORES { get; set; } = new VA0806B_WTABG_VALORES();
            public class VA0806B_WTABG_VALORES : VarBasis
            {
                /*"    05        WTABG-OCORREPRD     OCCURS       500   TIMES                                  INDEXED      BY    WS-PRD.*/
                public ListBasis<VA0806B_WTABG_OCORREPRD> WTABG_OCORREPRD { get; set; } = new ListBasis<VA0806B_WTABG_OCORREPRD>(500);
                public class VA0806B_WTABG_OCORREPRD : VarBasis
                {
                    /*"      10      WTABG-CODPRODU      PIC S9(004)        COMP.*/
                    public IntBasis WTABG_CODPRODU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                    /*"      10      WTABG-OCORRETIP     OCCURS       003   TIMES                                  INDEXED      BY    WS-TIP.*/
                    public ListBasis<VA0806B_WTABG_OCORRETIP> WTABG_OCORRETIP { get; set; } = new ListBasis<VA0806B_WTABG_OCORRETIP>(003);
                    public class VA0806B_WTABG_OCORRETIP : VarBasis
                    {
                        /*"        15    WTABG-TIPO          PIC  X(001).*/
                        public StringBasis WTABG_TIPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                        /*"        15    WTABG-OCORRESIT     OCCURS       002   TIMES                                  INDEXED      BY    WS-SIT.*/
                        public ListBasis<VA0806B_WTABG_OCORRESIT> WTABG_OCORRESIT { get; set; } = new ListBasis<VA0806B_WTABG_OCORRESIT>(002);
                        public class VA0806B_WTABG_OCORRESIT : VarBasis
                        {
                            /*"          20  WTABG-SITUACAO      PIC  X(001).*/
                            public StringBasis WTABG_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                            /*"          20  WTABG-QTDE          PIC S9(009)        COMP.*/
                            public IntBasis WTABG_QTDE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                            /*"          20  WTABG-VLPRMTOT      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLTARIFA      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLTARIFA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLBALCAO      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLBALCAO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLIOCC        PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLIOCC { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"          20  WTABG-VLDESCON      PIC S9(013)V99     COMP-3.*/
                            public DoubleBasis WTABG_VLDESCON { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                            /*"01    WS-HORAS.*/
                        }
                    }
                }
            }
        }
        public VA0806B_WS_HORAS WS_HORAS { get; set; } = new VA0806B_WS_HORAS();
        public class VA0806B_WS_HORAS : VarBasis
        {
            /*"  03  WS-HORA-INI               PIC  X(008).*/
            public StringBasis WS_HORA_INI { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-INI-R REDEFINES WS-HORA-INI.*/
            private _REDEF_VA0806B_WS_HORA_INI_R _ws_hora_ini_r { get; set; }
            public _REDEF_VA0806B_WS_HORA_INI_R WS_HORA_INI_R
            {
                get { _ws_hora_ini_r = new _REDEF_VA0806B_WS_HORA_INI_R(); _.Move(WS_HORA_INI, _ws_hora_ini_r); VarBasis.RedefinePassValue(WS_HORA_INI, _ws_hora_ini_r, WS_HORA_INI); _ws_hora_ini_r.ValueChanged += () => { _.Move(_ws_hora_ini_r, WS_HORA_INI); }; return _ws_hora_ini_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_ini_r, WS_HORA_INI); }
            }  //Redefines
            public class _REDEF_VA0806B_WS_HORA_INI_R : VarBasis
            {
                /*"      05  HI                    PIC  9(002).*/
                public IntBasis HI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MI                    PIC  9(002).*/
                public IntBasis MI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SI                    PIC  9(002).*/
                public IntBasis SI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DI                    PIC  9(002).*/
                public IntBasis DI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  WS-HORA-FIM               PIC  X(008).*/

                public _REDEF_VA0806B_WS_HORA_INI_R()
                {
                    HI.ValueChanged += OnValueChanged;
                    MI.ValueChanged += OnValueChanged;
                    SI.ValueChanged += OnValueChanged;
                    DI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_HORA_FIM { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03  WS-HORA-FIM-R REDEFINES WS-HORA-FIM.*/
            private _REDEF_VA0806B_WS_HORA_FIM_R _ws_hora_fim_r { get; set; }
            public _REDEF_VA0806B_WS_HORA_FIM_R WS_HORA_FIM_R
            {
                get { _ws_hora_fim_r = new _REDEF_VA0806B_WS_HORA_FIM_R(); _.Move(WS_HORA_FIM, _ws_hora_fim_r); VarBasis.RedefinePassValue(WS_HORA_FIM, _ws_hora_fim_r, WS_HORA_FIM); _ws_hora_fim_r.ValueChanged += () => { _.Move(_ws_hora_fim_r, WS_HORA_FIM); }; return _ws_hora_fim_r; }
                set { VarBasis.RedefinePassValue(value, _ws_hora_fim_r, WS_HORA_FIM); }
            }  //Redefines
            public class _REDEF_VA0806B_WS_HORA_FIM_R : VarBasis
            {
                /*"      05  HF                    PIC  9(002).*/
                public IntBasis HF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  MF                    PIC  9(002).*/
                public IntBasis MF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  SF                    PIC  9(002).*/
                public IntBasis SF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      05  DF                    PIC  9(002).*/
                public IntBasis DF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03  SIT                       PIC S9(013)V99 COMP-3 VALUE +0.*/

                public _REDEF_VA0806B_WS_HORA_FIM_R()
                {
                    HF.ValueChanged += OnValueChanged;
                    MF.ValueChanged += OnValueChanged;
                    SF.ValueChanged += OnValueChanged;
                    DF.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis SIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SFT                       PIC S9(013)V99 COMP-3 VALUE +0.*/
            public DoubleBasis SFT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03  SII                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis SII { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  IND                       PIC S9(004)    COMP   VALUE +0.*/
            public IntBasis IND { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  03  STT-DISP                  PIC --.---.---.---.--9,99.*/
            public DoubleBasis STT_DISP { get; set; } = new DoubleBasis(new PIC("9", "14", "--.---.---.---.--9V99."), 2);
            /*"01  TOTAIS-ROT.*/
        }
        public VA0806B_TOTAIS_ROT TOTAIS_ROT { get; set; } = new VA0806B_TOTAIS_ROT();
        public class VA0806B_TOTAIS_ROT : VarBasis
        {
            /*"    03  FILLER  OCCURS 50 TIMES.*/
            public ListBasis<VA0806B_FILLER_23> FILLER_23 { get; set; } = new ListBasis<VA0806B_FILLER_23>(50);
            public class VA0806B_FILLER_23 : VarBasis
            {
                /*"        05  STT                       PIC S9(013)V99 COMP-3.*/
                public DoubleBasis STT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
                /*"        05  SQT                       PIC S9(015)    COMP-3.*/
                public IntBasis SQT { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            }
        }


        public Dclgens.GEARDETA GEARDETA { get; set; } = new Dclgens.GEARDETA();
        public Dclgens.VGFOLLOW VGFOLLOW { get; set; } = new Dclgens.VGFOLLOW();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string RETDEB_FILE_NAME_P, string RETCRE_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                RETDEB.SetFile(RETDEB_FILE_NAME_P);
                RETCRE.SetFile(RETCRE_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-0000-PRINCIPAL-SECTION */

                M_0000_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-0000-PRINCIPAL-SECTION */
        private void M_0000_PRINCIPAL_SECTION()
        {
            /*" -557- DISPLAY ' ' */
            _.Display($" ");

            /*" -558- DISPLAY '================================================' */
            _.Display($"================================================");

            /*" -560- DISPLAY '================================================' '================================================' */
            _.Display($"================================================================================================");

            /*" -562- DISPLAY 'VERSAO V.03 - INCIDENTE 534456 - ' FUNCTION WHEN-COMPILED */

            $"VERSAO V.03 - INCIDENTE 534456 - FUNCTION{_.WhenCompiled()}"
            .Display();

            /*" -563- DISPLAY '================================================' */
            _.Display($"================================================");

            /*" -565- DISPLAY '================================================' '================================================' */
            _.Display($"================================================================================================");

            /*" -566- DISPLAY ' ' */
            _.Display($" ");

            /*" -574- DISPLAY 'INICIOU PROCESSAMENTO EM: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $"INICIOU PROCESSAMENTO EM: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -578- INITIALIZE TOTAIS-ROT. */
            _.Initialize(
                TOTAIS_ROT
            );

            /*" -580- PERFORM R2000-00-VERIFICA-FITAS. */

            R2000_00_VERIFICA_FITAS_SECTION();

            /*" -582- OPEN INPUT RETDEB RETCRE. */
            RETDEB.Open(RETDEB_RECORD);
            RETCRE.Open(RETCRE_RECORD);

            /*" -584- PERFORM DB010-ACESSA-SISTEMA */

            DB010_ACESSA_SISTEMA_SECTION();

            /*" -585- IF WS-AC-DEB GREATER 02 */

            if (WORK_AREA.WS_AC_DEB > 02)
            {

                /*" -586- DISPLAY 'PROCESSANDO FITA DE DEBITO ... ' WS-AC-DEB */
                _.Display($"PROCESSANDO FITA DE DEBITO ... {WORK_AREA.WS_AC_DEB}");

                /*" -587- ELSE */
            }
            else
            {


                /*" -588- DISPLAY 'FITA DE DEBITO VAZIA ......... ' WS-AC-DEB */
                _.Display($"FITA DE DEBITO VAZIA ......... {WORK_AREA.WS_AC_DEB}");

                /*" -590- GO TO R0001-00-FITA-CREDITO. */

                R0001_00_FITA_CREDITO(); //GOTO
                return;
            }


            /*" -591- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -593- DISPLAY '*** VA0806B *** MOV. DEB  RETORNO VAZIO' */
                    _.Display($"*** VA0806B *** MOV. DEB  RETORNO VAZIO");

                    /*" -594- GO TO R0001-00-FITA-CREDITO */

                    R0001_00_FITA_CREDITO(); //GOTO
                    return;

                    /*" -596- END-READ. */
                });

                _.Move(RETDEB.Value, RETDEB_RECORD);
                _.Move(RETDEB.Value, RET_HEADER);
                _.Move(RETDEB.Value, RET_CADASTRAMENTO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -597- IF RA-COD-REG NOT EQUAL 'A' */

            if (RET_HEADER.RA_COD_REG != "A")
            {

                /*" -598- DISPLAY '*** VA0806B *** FITA DEB SEM HEADER' */
                _.Display($"*** VA0806B *** FITA DEB SEM HEADER");

                /*" -600- GO TO R0001-00-FITA-CREDITO. */

                R0001_00_FITA_CREDITO(); //GOTO
                return;
            }


            /*" -601- MOVE 'R' TO WS-INICIAL-ARQ. */
            _.Move("R", WORK_AREA.WS_ARQUIVO_R.WS_INICIAL_ARQ);

            /*" -602- MOVE RA-COD-CONVENIO TO WS-CONVENIO-ARQ. */
            _.Move(RET_HEADER.RA_COD_CONVENIO, WORK_AREA.WS_ARQUIVO_R.WS_CONVENIO_ARQ);

            /*" -603- MOVE SPACES TO WS-FINAL-ARQ. */
            _.Move("", WORK_AREA.WS_ARQUIVO_R.WS_FINAL_ARQ);

            /*" -605- MOVE WS-ARQUIVO TO GEARDETA-NOM-ARQUIVO. */
            _.Move(WORK_AREA.WS_ARQUIVO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO);

            /*" -607- MOVE RA-NSA TO GEARDETA-SEQ-GERACAO. */
            _.Move(RET_HEADER.RA_NSA, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO);

            /*" -609- MOVE RA-NSA TO WS-NSAC. */
            _.Move(RET_HEADER.RA_NSA, WS_NSAC);

            /*" -611- MOVE RA-COD-BANCO TO WS-BANCO. */
            _.Move(RET_HEADER.RA_COD_BANCO, WS_BANCO);

            /*" -613- MOVE RA-DATA-GERACAO TO WS-DATA-INV. */
            _.Move(RET_HEADER.RA_DATA_GERACAO, WORK_AREA.WS_DATA_INV);

            /*" -614- PERFORM DB015-ACESSA-GEARDETALHE */

            DB015_ACESSA_GEARDETALHE_SECTION();

            /*" -616- IF SQLCODE = 000 */

            if (DB.SQLCODE == 000)
            {

                /*" -617- DISPLAY '*** ENCONTROU SEQUENCIA.' */
                _.Display($"*** ENCONTROU SEQUENCIA.");

                /*" -618- DISPLAY ' GEARDETA-NOM-ARQUIVO=' GEARDETA-NOM-ARQUIVO */
                _.Display($" GEARDETA-NOM-ARQUIVO={GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO}");

                /*" -619- DISPLAY ' GEARDETA-SEQ-GERACAO=' GEARDETA-SEQ-GERACAO */
                _.Display($" GEARDETA-SEQ-GERACAO={GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO}");

                /*" -621- DISPLAY ' GEARDETA-DTH-ANO-REFERENCIA=' GEARDETA-DTH-ANO-REFERENCIA */
                _.Display($" GEARDETA-DTH-ANO-REFERENCIA={GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA}");

                /*" -623- DISPLAY ' GEARDETA-DTH-MES-REFERENCIA=' GEARDETA-DTH-MES-REFERENCIA */
                _.Display($" GEARDETA-DTH-MES-REFERENCIA={GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA}");

                /*" -624- DISPLAY ' WS-ANO-INV          =' WS-ANO-INV */
                _.Display($" WS-ANO-INV          ={WORK_AREA.WS_DATA_INV.WS_ANO_INV}");

                /*" -625- DISPLAY ' WS-MES-INV          =' WS-MES-INV */
                _.Display($" WS-MES-INV          ={WORK_AREA.WS_DATA_INV.WS_MES_INV}");

                /*" -629- IF (GEARDETA-DTH-ANO-REFERENCIA < WS-ANO-INV) OR ( GEARDETA-DTH-ANO-REFERENCIA = WS-ANO-INV AND GEARDETA-DTH-MES-REFERENCIA < WS-MES-INV) */

                if ((GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA < WORK_AREA.WS_DATA_INV.WS_ANO_INV) || (GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA == WORK_AREA.WS_DATA_INV.WS_ANO_INV && GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA < WORK_AREA.WS_DATA_INV.WS_MES_INV))
                {

                    /*" -630- PERFORM DB017-ACESSA-MAX-SEQUENCIA */

                    DB017_ACESSA_MAX_SEQUENCIA_SECTION();

                    /*" -631- ELSE */
                }
                else
                {


                    /*" -632- MOVE GEARDETA-SEQ-GERACAO TO WS-INTEGER(01) */
                    _.Move(GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO, WS_EDIT.WS_INTEGER[01]);

                    /*" -635- DISPLAY '*** VA0806B *** FITA JA PROCESSADA ' '<GEARDETA-NOM-ARQUIVO=' GEARDETA-NOM-ARQUIVO '>' '<GEARDETA-SEQ-GERACAO=' WS-INTEGER(01) '>' */

                    $"*** VA0806B *** FITA JA PROCESSADA <GEARDETA-NOM-ARQUIVO={GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO}><GEARDETA-SEQ-GERACAO={WS_EDIT.WS_INTEGER[1]}>"
                    .Display();

                    /*" -636- GO TO R0001-00-FIM-ANORMAL */

                    R0001_00_FIM_ANORMAL(); //GOTO
                    return;

                    /*" -637- END-IF */
                }


                /*" -638- END-IF */
            }


            /*" -639- MOVE WS-ANO-INV TO ANO-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_ANO_INV, WORK_AREA.DATA_SQL.ANO_SQL);

            /*" -640- MOVE WS-ANO-INV TO GEARDETA-DTH-ANO-REFERENCIA. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_ANO_INV, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA);

            /*" -641- MOVE WS-MES-INV TO MES-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_MES_INV, WORK_AREA.DATA_SQL.MES_SQL);

            /*" -642- MOVE WS-MES-INV TO GEARDETA-DTH-MES-REFERENCIA. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_MES_INV, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA);

            /*" -644- MOVE WS-DIA-INV TO DIA-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_DIA_INV, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -646- MOVE V0SIST-DTMOVABE TO GEARDETA-DTH-MOVIMENTO. */
            _.Move(V0SIST_DTMOVABE, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MOVIMENTO);

            /*" -648- MOVE DATA-SQL TO GEARDETA-DTH-GERACAO. */
            _.Move(WORK_AREA.DATA_SQL, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_GERACAO);

            /*" -649- MOVE V0SIST-DTMOVABE TO GEARDETA-DTH-RECEPCAO. */
            _.Move(V0SIST_DTMOVABE, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_RECEPCAO);

            /*" -650- MOVE 'E' TO GEARDETA-IND-MEIO-ENVIO. */
            _.Move("E", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_IND_MEIO_ENVIO);

            /*" -651- MOVE 'R' TO GEARDETA-STA-ENVIO-RECEPCAO. */
            _.Move("R", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_STA_ENVIO_RECEPCAO);

            /*" -652- MOVE 'TXT' TO GEARDETA-COD-TIPO-ARQUIVO. */
            _.Move("TXT", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_COD_TIPO_ARQUIVO);

            /*" -653- MOVE ZEROS TO GEARDETA-QTD-REG-PROCESSADO. */
            _.Move(0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO);

            /*" -654- MOVE ZEROS TO GEARDETA-QTD-REG-REJEITADOS. */
            _.Move(0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_REJEITADOS);

            /*" -656- MOVE ZEROS TO GEARDETA-QTD-REG-ACEITOS. */
            _.Move(0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_ACEITOS);

            /*" -658- PERFORM DB020-INSERT-GEARDETALHE */

            DB020_INSERT_GEARDETALHE_SECTION();

            /*" -660- MOVE RA-VERSAO-LAYOUT TO WS-VERSAO. */
            _.Move(RET_HEADER.RA_VERSAO_LAYOUT, WS_VERSAO);

            /*" -662- MOVE GEARDETA-SEQ-GERACAO TO WGEARDETA-SEQ-GERACAO. */
            _.Move(GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO, WORK_AREA.WGEARDETA_SEQ_GERACAO);

            /*" -663- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -664- DISPLAY '*** VA0806B *** FITA DEB SEM MOVIMENTO ' */
                    _.Display($"*** VA0806B *** FITA DEB SEM MOVIMENTO ");

                    /*" -666- GO TO R0001-00-FITA-CREDITO. */

                    R0001_00_FITA_CREDITO(); //GOTO
                    return;
                });

                _.Move(RETDEB.Value, RETDEB_RECORD);
                _.Move(RETDEB.Value, RET_HEADER);
                _.Move(RETDEB.Value, RET_CADASTRAMENTO);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -667- IF RA-COD-REG NOT EQUAL 'F' AND 'Z' */

            if (!RET_HEADER.RA_COD_REG.In("F", "Z"))
            {

                /*" -668- DISPLAY 'COD REGISTRO NAO ESPERADO' */
                _.Display($"COD REGISTRO NAO ESPERADO");

                /*" -670- GO TO R0001-00-FIM-ANORMAL. */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;
            }


            /*" -671- IF RA-COD-REG EQUAL 'Z' */

            if (RET_HEADER.RA_COD_REG == "Z")
            {

                /*" -677- GO TO R0001-00-FITA-CREDITO. */

                R0001_00_FITA_CREDITO(); //GOTO
                return;
            }


            /*" -681- PERFORM R0020-00-PROCESSA UNTIL WS-EOF = 1 OR RA-COD-REG NOT EQUAL 'F' . */

            while (!(WORK_AREA.WS_EOF == 1 || RET_HEADER.RA_COD_REG != "F"))
            {

                R0020_00_PROCESSA_SECTION();
            }

            /*" -682- IF WS-EOF = 1 */

            if (WORK_AREA.WS_EOF == 1)
            {

                /*" -683- DISPLAY '*** VA0806B *** FITA SEM TRAILLER' */
                _.Display($"*** VA0806B *** FITA SEM TRAILLER");

                /*" -684- GO TO R0001-00-FIM-ANORMAL */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;

                /*" -685- ELSE */
            }
            else
            {


                /*" -686- IF RA-COD-REG NOT EQUAL 'Z' */

                if (RET_HEADER.RA_COD_REG != "Z")
                {

                    /*" -687- DISPLAY 'FIM INESPERADO *** ' */
                    _.Display($"FIM INESPERADO *** ");

                    /*" -688- DISPLAY 'COD REGISTRO NAO ESPERADO' */
                    _.Display($"COD REGISTRO NAO ESPERADO");

                    /*" -688- GO TO R0001-00-FIM-ANORMAL. */

                    R0001_00_FIM_ANORMAL(); //GOTO
                    return;
                }

            }


            /*" -0- FLUXCONTROL_PERFORM R0001_00_FITA_CREDITO */

            R0001_00_FITA_CREDITO();

        }

        [StopWatch]
        /*" R0001-00-FITA-CREDITO */
        private void R0001_00_FITA_CREDITO(bool isPerform = false)
        {
            /*" -696- MOVE ZEROS TO WS-REGISTROS. */
            _.Move(0, WORK_AREA.WS_REGISTROS);

            /*" -698- MOVE ZEROS TO WS-EOF. */
            _.Move(0, WORK_AREA.WS_EOF);

            /*" -699- IF WS-AC-CRE GREATER 02 */

            if (WORK_AREA.WS_AC_CRE > 02)
            {

                /*" -700- DISPLAY 'PROCESSANDO FITA DE CREDITO .. ' WS-AC-CRE */
                _.Display($"PROCESSANDO FITA DE CREDITO .. {WORK_AREA.WS_AC_CRE}");

                /*" -701- ELSE */
            }
            else
            {


                /*" -702- DISPLAY 'FITA DE CREDITO VAZIA ........ ' WS-AC-CRE */
                _.Display($"FITA DE CREDITO VAZIA ........ {WORK_AREA.WS_AC_CRE}");

                /*" -704- GO TO R0001-00-FIM-NORMAL. */

                R0001_00_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -705- READ RETCRE AT END */
            try
            {
                RETCRE.Read(() =>
                {

                    /*" -706- DISPLAY '*** VA0806B *** MOV. CRED RETORNO VAZIO' */
                    _.Display($"*** VA0806B *** MOV. CRED RETORNO VAZIO");

                    /*" -708- GO TO R0001-00-FIM-NORMAL. */

                    R0001_00_FIM_NORMAL(); //GOTO
                    return;
                });

                _.Move(RETCRE.Value, RETCRE_RECORD);
                _.Move(RETCRE.Value, RET_HEADERC);
                _.Move(RETCRE.Value, RET_CADASTRAMENTOC);
                _.Move(RETCRE.Value, RET_TRAILLERC);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -709- IF RA-COD-REGC NOT EQUAL 'A' */

            if (RET_HEADERC.RA_COD_REGC != "A")
            {

                /*" -710- DISPLAY '*** VA0806B *** FITA CRED SEM HEADER' */
                _.Display($"*** VA0806B *** FITA CRED SEM HEADER");

                /*" -712- GO TO R0001-00-FIM-ANORMAL. */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;
            }


            /*" -713- MOVE 'R' TO WS-INICIAL-ARQ. */
            _.Move("R", WORK_AREA.WS_ARQUIVO_R.WS_INICIAL_ARQ);

            /*" -714- MOVE RA-COD-CONVENIOC TO WS-CONVENIO-ARQ. */
            _.Move(RET_HEADERC.RA_COD_CONVENIOC, WORK_AREA.WS_ARQUIVO_R.WS_CONVENIO_ARQ);

            /*" -715- MOVE SPACES TO WS-FINAL-ARQ. */
            _.Move("", WORK_AREA.WS_ARQUIVO_R.WS_FINAL_ARQ);

            /*" -717- MOVE WS-ARQUIVO TO GEARDETA-NOM-ARQUIVO. */
            _.Move(WORK_AREA.WS_ARQUIVO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO);

            /*" -718- MOVE RA-NSAC TO GEARDETA-SEQ-GERACAO. */
            _.Move(RET_HEADERC.RA_NSAC, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO);

            /*" -720- MOVE RA-NSAC TO WS-NSAC. */
            _.Move(RET_HEADERC.RA_NSAC, WS_NSAC);

            /*" -722- MOVE RA-COD-BANCOC TO WS-BANCO. */
            _.Move(RET_HEADERC.RA_COD_BANCOC, WS_BANCO);

            /*" -723- MOVE RA-DATA-GERACAOC TO WS-DATA-INV. */
            _.Move(RET_HEADERC.RA_DATA_GERACAOC, WORK_AREA.WS_DATA_INV);

            /*" -724- MOVE WS-ANO-INV TO ANO-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_ANO_INV, WORK_AREA.DATA_SQL.ANO_SQL);

            /*" -725- MOVE WS-ANO-INV TO GEARDETA-DTH-ANO-REFERENCIA. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_ANO_INV, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA);

            /*" -726- MOVE WS-MES-INV TO MES-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_MES_INV, WORK_AREA.DATA_SQL.MES_SQL);

            /*" -727- MOVE WS-MES-INV TO GEARDETA-DTH-MES-REFERENCIA. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_MES_INV, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA);

            /*" -729- MOVE WS-DIA-INV TO DIA-SQL. */
            _.Move(WORK_AREA.WS_DATA_INV.WS_DIA_INV, WORK_AREA.DATA_SQL.DIA_SQL);

            /*" -731- MOVE V0SIST-DTMOVABE TO GEARDETA-DTH-MOVIMENTO. */
            _.Move(V0SIST_DTMOVABE, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MOVIMENTO);

            /*" -733- MOVE DATA-SQL TO GEARDETA-DTH-GERACAO. */
            _.Move(WORK_AREA.DATA_SQL, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_GERACAO);

            /*" -734- MOVE V0SIST-DTMOVABE TO GEARDETA-DTH-RECEPCAO. */
            _.Move(V0SIST_DTMOVABE, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_RECEPCAO);

            /*" -735- MOVE 'E' TO GEARDETA-IND-MEIO-ENVIO. */
            _.Move("E", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_IND_MEIO_ENVIO);

            /*" -736- MOVE 'R' TO GEARDETA-STA-ENVIO-RECEPCAO. */
            _.Move("R", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_STA_ENVIO_RECEPCAO);

            /*" -737- MOVE 'TXT' TO GEARDETA-COD-TIPO-ARQUIVO. */
            _.Move("TXT", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_COD_TIPO_ARQUIVO);

            /*" -738- MOVE ZEROS TO GEARDETA-QTD-REG-PROCESSADO. */
            _.Move(0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO);

            /*" -739- MOVE ZEROS TO GEARDETA-QTD-REG-REJEITADOS. */
            _.Move(0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_REJEITADOS);

            /*" -741- MOVE ZEROS TO GEARDETA-QTD-REG-ACEITOS. */
            _.Move(0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_ACEITOS);

            /*" -743- MOVE 'INSERT GE_AR_DETALHE ' TO COMANDO. */
            _.Move("INSERT GE_AR_DETALHE ", WS_EDIT.LOCALIZA_ABEND_2.COMANDO);

            /*" -744- MOVE 12 TO SII */
            _.Move(12, WS_HORAS.SII);

            /*" -746- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -776- PERFORM R0001_00_FITA_CREDITO_DB_INSERT_1 */

            R0001_00_FITA_CREDITO_DB_INSERT_1();

            /*" -780- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -781- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -782- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -783- IF GEARDETA-SEQ-GERACAO NOT EQUAL WGEARDETA-SEQ-GERACAO */

                    if (GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO != WORK_AREA.WGEARDETA_SEQ_GERACAO)
                    {

                        /*" -784- MOVE GEARDETA-SEQ-GERACAO TO WS-INTEGER(01) */
                        _.Move(GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO, WS_EDIT.WS_INTEGER[01]);

                        /*" -785- MOVE WGEARDETA-SEQ-GERACAO TO WS-INTEGER(02) */
                        _.Move(WORK_AREA.WGEARDETA_SEQ_GERACAO, WS_EDIT.WS_INTEGER[02]);

                        /*" -789- DISPLAY '*** VA0806B *** FITA CRED JA PROCESSADA ' '<GEARDETA-NOM-ARQUIVO=' GEARDETA-NOM-ARQUIVO '>' '<GEARDETA-SEQ-GERACAO=' WS-INTEGER(01) '>' '<WGEARDETA-SEQ-GERACAO=' WS-INTEGER(02) '>' */

                        $"*** VA0806B *** FITA CRED JA PROCESSADA <GEARDETA-NOM-ARQUIVO={GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO}><GEARDETA-SEQ-GERACAO={WS_EDIT.WS_INTEGER[1]}><WGEARDETA-SEQ-GERACAO={WS_EDIT.WS_INTEGER[2]}>"
                        .Display();

                        /*" -790- GO TO R0001-00-FIM-ANORMAL */

                        R0001_00_FIM_ANORMAL(); //GOTO
                        return;

                        /*" -791- END-IF */
                    }


                    /*" -792- ELSE */
                }
                else
                {


                    /*" -794- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -796- MOVE RA-VERSAO-LAYOUTC TO WS-VERSAO. */
            _.Move(RET_HEADERC.RA_VERSAO_LAYOUTC, WS_VERSAO);

            /*" -797- READ RETCRE AT END */
            try
            {
                RETCRE.Read(() =>
                {

                    /*" -798- DISPLAY '*** VA0806B *** FITA CRED SEM MOVIMENTO ' */
                    _.Display($"*** VA0806B *** FITA CRED SEM MOVIMENTO ");

                    /*" -800- GO TO R0001-00-FIM-NORMAL. */

                    R0001_00_FIM_NORMAL(); //GOTO
                    return;
                });

                _.Move(RETCRE.Value, RETCRE_RECORD);
                _.Move(RETCRE.Value, RET_HEADERC);
                _.Move(RETCRE.Value, RET_CADASTRAMENTOC);
                _.Move(RETCRE.Value, RET_TRAILLERC);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -801- IF RA-COD-REGC NOT EQUAL 'F' AND 'Z' */

            if (!RET_HEADERC.RA_COD_REGC.In("F", "Z"))
            {

                /*" -802- DISPLAY 'CRED - COD REGISTRO NAO ESPERADO' */
                _.Display($"CRED - COD REGISTRO NAO ESPERADO");

                /*" -804- GO TO R0001-00-FIM-ANORMAL. */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;
            }


            /*" -805- IF RA-COD-REGC EQUAL 'Z' */

            if (RET_HEADERC.RA_COD_REGC == "Z")
            {

                /*" -811- GO TO R0001-00-FIM-NORMAL. */

                R0001_00_FIM_NORMAL(); //GOTO
                return;
            }


            /*" -815- PERFORM R0220-00-PROCESSA UNTIL WS-EOF = 1 OR RA-COD-REGC NOT EQUAL 'F' . */

            while (!(WORK_AREA.WS_EOF == 1 || RET_HEADERC.RA_COD_REGC != "F"))
            {

                R0220_00_PROCESSA_SECTION();
            }

            /*" -816- IF WS-EOF = 1 */

            if (WORK_AREA.WS_EOF == 1)
            {

                /*" -817- DISPLAY '*** VA0806B *** FITA CRED SEM TRAILLER' */
                _.Display($"*** VA0806B *** FITA CRED SEM TRAILLER");

                /*" -818- GO TO R0001-00-FIM-ANORMAL */

                R0001_00_FIM_ANORMAL(); //GOTO
                return;

                /*" -819- ELSE */
            }
            else
            {


                /*" -820- IF RA-COD-REGC NOT EQUAL 'Z' */

                if (RET_HEADERC.RA_COD_REGC != "Z")
                {

                    /*" -821- DISPLAY 'FIM INESPERADO - CRED *** ' */
                    _.Display($"FIM INESPERADO - CRED *** ");

                    /*" -822- DISPLAY 'COD REGISTRO NAO ESPERADO' */
                    _.Display($"COD REGISTRO NAO ESPERADO");

                    /*" -822- GO TO R0001-00-FIM-ANORMAL. */

                    R0001_00_FIM_ANORMAL(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0001-00-FITA-CREDITO-DB-INSERT-1 */
        public void R0001_00_FITA_CREDITO_DB_INSERT_1()
        {
            /*" -776- EXEC SQL INSERT INTO SEGUROS.GE_AR_DETALHE (NOM_ARQUIVO, SEQ_GERACAO, DTH_ANO_REFERENCIA, DTH_MES_REFERENCIA, DTH_MOVIMENTO, DTH_GERACAO, DTH_RECEPCAO, IND_MEIO_ENVIO, STA_ENVIO_RECEPCAO, COD_TIPO_ARQUIVO, QTD_REG_PROCESSADO, QTD_REG_REJEITADOS, QTD_REG_ACEITOS, DTH_TIMESTAMP) VALUES (:GEARDETA-NOM-ARQUIVO, :GEARDETA-SEQ-GERACAO, :GEARDETA-DTH-ANO-REFERENCIA, :GEARDETA-DTH-MES-REFERENCIA, :GEARDETA-DTH-MOVIMENTO, :GEARDETA-DTH-GERACAO, :GEARDETA-DTH-RECEPCAO, :GEARDETA-IND-MEIO-ENVIO, :GEARDETA-STA-ENVIO-RECEPCAO, :GEARDETA-COD-TIPO-ARQUIVO, :GEARDETA-QTD-REG-PROCESSADO, :GEARDETA-QTD-REG-REJEITADOS, :GEARDETA-QTD-REG-ACEITOS, CURRENT TIMESTAMP) END-EXEC. */

            var r0001_00_FITA_CREDITO_DB_INSERT_1_Insert1 = new R0001_00_FITA_CREDITO_DB_INSERT_1_Insert1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
                GEARDETA_SEQ_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.ToString(),
                GEARDETA_DTH_ANO_REFERENCIA = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA.ToString(),
                GEARDETA_DTH_MES_REFERENCIA = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA.ToString(),
                GEARDETA_DTH_MOVIMENTO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MOVIMENTO.ToString(),
                GEARDETA_DTH_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_GERACAO.ToString(),
                GEARDETA_DTH_RECEPCAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_RECEPCAO.ToString(),
                GEARDETA_IND_MEIO_ENVIO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_IND_MEIO_ENVIO.ToString(),
                GEARDETA_STA_ENVIO_RECEPCAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_STA_ENVIO_RECEPCAO.ToString(),
                GEARDETA_COD_TIPO_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_COD_TIPO_ARQUIVO.ToString(),
                GEARDETA_QTD_REG_PROCESSADO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO.ToString(),
                GEARDETA_QTD_REG_REJEITADOS = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_REJEITADOS.ToString(),
                GEARDETA_QTD_REG_ACEITOS = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_ACEITOS.ToString(),
            };

            R0001_00_FITA_CREDITO_DB_INSERT_1_Insert1.Execute(r0001_00_FITA_CREDITO_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0001-00-FIM-NORMAL */
        private void R0001_00_FIM_NORMAL(bool isPerform = false)
        {
            /*" -829- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -833- CLOSE RETDEB RETCRE. */
            RETDEB.Close();
            RETCRE.Close();

            /*" -834- DISPLAY '*** VA0806B *** TERMINO NORMAL' . */
            _.Display($"*** VA0806B *** TERMINO NORMAL");

            /*" -836- DISPLAY ' ' . */
            _.Display($" ");

            /*" -838- PERFORM R9900-00-MOSTRA-TOTAIS. */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -840- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -840- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0001-00-FIM-ANORMAL */
        private void R0001_00_FIM_ANORMAL(bool isPerform = false)
        {
            /*" -846- DISPLAY '*** VA0806B PROCESSAMENTO TERMINOU COM ERRO ***' . */
            _.Display($"*** VA0806B PROCESSAMENTO TERMINOU COM ERRO ***");

            /*" -846- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -850- CLOSE RETDEB RETCRE. */
            RETDEB.Close();
            RETCRE.Close();

            /*" -852- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -852- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }

        [StopWatch]
        /*" R0020-00-PROCESSA-SECTION */
        private void R0020_00_PROCESSA_SECTION()
        {
            /*" -860- MOVE '0020-PROCESSA' TO PARAGRAFO. */
            _.Move("0020-PROCESSA", WS_EDIT.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -862- ADD 1 TO WS-REGISTROS. */
            WORK_AREA.WS_REGISTROS.Value = WORK_AREA.WS_REGISTROS + 1;

            /*" -863- MOVE WS-ARQUIVO TO VGFOLLOW-NOM-ARQUIVO. */
            _.Move(WORK_AREA.WS_ARQUIVO, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NOM_ARQUIVO);

            /*" -864- MOVE GEARDETA-SEQ-GERACAO TO VGFOLLOW-SEQ-GERACAO. */
            _.Move(GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_SEQ_GERACAO);

            /*" -865- MOVE GEARDETA-SEQ-GERACAO TO VGFOLLOW-NUM-FITA-CEF. */
            _.Move(GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_FITA_CEF);

            /*" -866- MOVE RF-IDENTIF-NSA TO VGFOLLOW-NUM-NOSSA-FITA. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_NSA, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA);

            /*" -867- MOVE RF-NSL TO VGFOLLOW-NUM-LANCAMENTO. */
            _.Move(RET_CADASTRAMENTO.RF_USO_EMPRESA.RF_NSL, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO);

            /*" -868- MOVE WS-CONVENIO-4 TO VGFOLLOW-COD-CONVENIO. */
            _.Move(WORK_AREA.WS_ARQUIVO_R.WS_CONVENIO_ARQ_R.WS_CONVENIO_4, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_CONVENIO);

            /*" -869- MOVE RF-IDENTIF-CLI TO VGFOLLOW-NUM-CERTIFICADO. */
            _.Move(RET_CADASTRAMENTO.RF_IDENT_CLI_EMPRESA.RF_IDENTIF_CLI, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO);

            /*" -870- MOVE WS-BANCO TO VGFOLLOW-COD-BANCO. */
            _.Move(WS_BANCO, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_BANCO);

            /*" -871- MOVE 'N' TO VGFOLLOW-STA-PROCESSAMENTO. */
            _.Move("N", VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_STA_PROCESSAMENTO);

            /*" -872- MOVE WS-VERSAO TO VGFOLLOW-NUM-VERSAO-LAYOUT. */
            _.Move(WS_VERSAO, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_VERSAO_LAYOUT);

            /*" -873- MOVE RET-CADASTRAMENTO TO VGFOLLOW-REG-LANCAMENTO. */
            _.Move(RETDEB?.Value, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_REG_LANCAMENTO);

            /*" -875- MOVE 'VA0806B' TO VGFOLLOW-COD-USUARIO. */
            _.Move("VA0806B", VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_USUARIO);

            /*" -877- MOVE 'INSERT VG_FOLLOW_UP  ' TO COMANDO. */
            _.Move("INSERT VG_FOLLOW_UP  ", WS_EDIT.LOCALIZA_ABEND_2.COMANDO);

            /*" -878- MOVE 03 TO SII */
            _.Move(03, WS_HORAS.SII);

            /*" -880- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -908- PERFORM R0020_00_PROCESSA_DB_INSERT_1 */

            R0020_00_PROCESSA_DB_INSERT_1();

            /*" -911- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -913- IF SQLCODE NOT EQUAL ZEROS AND -803 */

            if (!DB.SQLCODE.In("00", "-803"))
            {

                /*" -914- DISPLAY 'ERRO INSERT VG_FOLLOW_UP ' */
                _.Display($"ERRO INSERT VG_FOLLOW_UP ");

                /*" -915- DISPLAY 'FITA DE DEBITO           ' */
                _.Display($"FITA DE DEBITO           ");

                /*" -916- DISPLAY 'NOM-ARQUIVO ' VGFOLLOW-NOM-ARQUIVO */
                _.Display($"NOM-ARQUIVO {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NOM_ARQUIVO}");

                /*" -917- DISPLAY 'SEQ-GERACAO ' VGFOLLOW-SEQ-GERACAO */
                _.Display($"SEQ-GERACAO {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_SEQ_GERACAO}");

                /*" -918- DISPLAY 'FITA-CEF ' VGFOLLOW-NUM-FITA-CEF */
                _.Display($"FITA-CEF {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_FITA_CEF}");

                /*" -919- DISPLAY 'NOSSA-FITA ' VGFOLLOW-NUM-NOSSA-FITA */
                _.Display($"NOSSA-FITA {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA}");

                /*" -920- DISPLAY 'LANCAMENTO ' VGFOLLOW-NUM-LANCAMENTO */
                _.Display($"LANCAMENTO {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO}");

                /*" -921- DISPLAY 'CONVENIO ' VGFOLLOW-COD-CONVENIO */
                _.Display($"CONVENIO {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_CONVENIO}");

                /*" -922- DISPLAY 'CERTIFICADO ' VGFOLLOW-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO}");

                /*" -922- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R0020_00_NEXT */

            R0020_00_NEXT();

        }

        [StopWatch]
        /*" R0020-00-PROCESSA-DB-INSERT-1 */
        public void R0020_00_PROCESSA_DB_INSERT_1()
        {
            /*" -908- EXEC SQL INSERT INTO SEGUROS.VG_FOLLOW_UP (NOM_ARQUIVO, SEQ_GERACAO, NUM_FITA_CEF, NUM_NOSSA_FITA, NUM_LANCAMENTO, COD_CONVENIO, NUM_CERTIFICADO, COD_BANCO, STA_PROCESSAMENTO, NUM_VERSAO_LAYOUT, REG_LANCAMENTO, COD_USUARIO, DTH_ATUALIZACAO) VALUES (:VGFOLLOW-NOM-ARQUIVO, :VGFOLLOW-SEQ-GERACAO, :VGFOLLOW-NUM-FITA-CEF, :VGFOLLOW-NUM-NOSSA-FITA, :VGFOLLOW-NUM-LANCAMENTO, :VGFOLLOW-COD-CONVENIO, :VGFOLLOW-NUM-CERTIFICADO, :VGFOLLOW-COD-BANCO, :VGFOLLOW-STA-PROCESSAMENTO, :VGFOLLOW-NUM-VERSAO-LAYOUT, :VGFOLLOW-REG-LANCAMENTO, :VGFOLLOW-COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0020_00_PROCESSA_DB_INSERT_1_Insert1 = new R0020_00_PROCESSA_DB_INSERT_1_Insert1()
            {
                VGFOLLOW_NOM_ARQUIVO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NOM_ARQUIVO.ToString(),
                VGFOLLOW_SEQ_GERACAO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_SEQ_GERACAO.ToString(),
                VGFOLLOW_NUM_FITA_CEF = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_FITA_CEF.ToString(),
                VGFOLLOW_NUM_NOSSA_FITA = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA.ToString(),
                VGFOLLOW_NUM_LANCAMENTO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO.ToString(),
                VGFOLLOW_COD_CONVENIO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_CONVENIO.ToString(),
                VGFOLLOW_NUM_CERTIFICADO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO.ToString(),
                VGFOLLOW_COD_BANCO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_BANCO.ToString(),
                VGFOLLOW_STA_PROCESSAMENTO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_STA_PROCESSAMENTO.ToString(),
                VGFOLLOW_NUM_VERSAO_LAYOUT = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_VERSAO_LAYOUT.ToString(),
                VGFOLLOW_REG_LANCAMENTO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_REG_LANCAMENTO.ToString(),
                VGFOLLOW_COD_USUARIO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_USUARIO.ToString(),
            };

            R0020_00_PROCESSA_DB_INSERT_1_Insert1.Execute(r0020_00_PROCESSA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0020-00-NEXT */
        private void R0020_00_NEXT(bool isPerform = false)
        {
            /*" -926- READ RETDEB AT END */
            try
            {
                RETDEB.Read(() =>
                {

                    /*" -926- MOVE 1 TO WS-EOF. */
                    _.Move(1, WORK_AREA.WS_EOF);
                });

                _.Move(RETDEB.Value, RETDEB_RECORD);
                _.Move(RETDEB.Value, RET_HEADER);
                _.Move(RETDEB.Value, RET_CADASTRAMENTO);

            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0020_99_SAIDA*/

        [StopWatch]
        /*" R0220-00-PROCESSA-SECTION */
        private void R0220_00_PROCESSA_SECTION()
        {
            /*" -936- MOVE '0220-PROCESSA' TO PARAGRAFO. */
            _.Move("0220-PROCESSA", WS_EDIT.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -938- ADD 1 TO WS-REGISTROS. */
            WORK_AREA.WS_REGISTROS.Value = WORK_AREA.WS_REGISTROS + 1;

            /*" -939- MOVE WS-ARQUIVO TO VGFOLLOW-NOM-ARQUIVO. */
            _.Move(WORK_AREA.WS_ARQUIVO, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NOM_ARQUIVO);

            /*" -940- MOVE GEARDETA-SEQ-GERACAO TO VGFOLLOW-SEQ-GERACAO. */
            _.Move(GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_SEQ_GERACAO);

            /*" -941- MOVE GEARDETA-SEQ-GERACAO TO VGFOLLOW-NUM-FITA-CEF. */
            _.Move(GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_FITA_CEF);

            /*" -942- MOVE RF-IDENTIF-NSAC TO VGFOLLOW-NUM-NOSSA-FITA. */
            _.Move(RET_CADASTRAMENTOC.RF_IDENT_CLI_EMPRESAC.RF_IDENTIF_NSAC, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA);

            /*" -943- MOVE RF-NSLC TO VGFOLLOW-NUM-LANCAMENTO. */
            _.Move(RET_CADASTRAMENTOC.RF_USO_EMPRESAC.RF_NSLC, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO);

            /*" -944- MOVE WS-CONVENIO-4 TO VGFOLLOW-COD-CONVENIO. */
            _.Move(WORK_AREA.WS_ARQUIVO_R.WS_CONVENIO_ARQ_R.WS_CONVENIO_4, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_CONVENIO);

            /*" -945- MOVE RF-IDENTIF-CLIC TO VGFOLLOW-NUM-CERTIFICADO. */
            _.Move(RET_CADASTRAMENTOC.RF_IDENT_CLI_EMPRESAC.RF_IDENTIF_CLIC, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO);

            /*" -946- MOVE WS-BANCO TO VGFOLLOW-COD-BANCO. */
            _.Move(WS_BANCO, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_BANCO);

            /*" -947- MOVE 'N' TO VGFOLLOW-STA-PROCESSAMENTO. */
            _.Move("N", VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_STA_PROCESSAMENTO);

            /*" -948- MOVE WS-VERSAO TO VGFOLLOW-NUM-VERSAO-LAYOUT. */
            _.Move(WS_VERSAO, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_VERSAO_LAYOUT);

            /*" -949- MOVE RET-CADASTRAMENTOC TO VGFOLLOW-REG-LANCAMENTO. */
            _.Move(RETCRE?.Value, VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_REG_LANCAMENTO);

            /*" -951- MOVE 'VA0806B' TO VGFOLLOW-COD-USUARIO. */
            _.Move("VA0806B", VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_USUARIO);

            /*" -953- MOVE 'INSERT VG_FOLLOW_UP  ' TO COMANDO. */
            _.Move("INSERT VG_FOLLOW_UP  ", WS_EDIT.LOCALIZA_ABEND_2.COMANDO);

            /*" -954- MOVE 13 TO SII */
            _.Move(13, WS_HORAS.SII);

            /*" -956- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -984- PERFORM R0220_00_PROCESSA_DB_INSERT_1 */

            R0220_00_PROCESSA_DB_INSERT_1();

            /*" -988- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -989- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -990- DISPLAY 'ERRO INSERT VG_FOLLOW_UP ' */
                _.Display($"ERRO INSERT VG_FOLLOW_UP ");

                /*" -991- DISPLAY 'FITA DE CREDITO          ' */
                _.Display($"FITA DE CREDITO          ");

                /*" -992- DISPLAY 'NOM-ARQUIVO ' VGFOLLOW-NOM-ARQUIVO */
                _.Display($"NOM-ARQUIVO {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NOM_ARQUIVO}");

                /*" -993- DISPLAY 'SEQ-GERACAO ' VGFOLLOW-SEQ-GERACAO */
                _.Display($"SEQ-GERACAO {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_SEQ_GERACAO}");

                /*" -994- DISPLAY 'FITA-CEF ' VGFOLLOW-NUM-FITA-CEF */
                _.Display($"FITA-CEF {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_FITA_CEF}");

                /*" -995- DISPLAY 'NOSSA-FITA ' VGFOLLOW-NUM-NOSSA-FITA */
                _.Display($"NOSSA-FITA {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA}");

                /*" -996- DISPLAY 'LANCAMENTO ' VGFOLLOW-NUM-LANCAMENTO */
                _.Display($"LANCAMENTO {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO}");

                /*" -997- DISPLAY 'CONVENIO ' VGFOLLOW-COD-CONVENIO */
                _.Display($"CONVENIO {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_CONVENIO}");

                /*" -998- DISPLAY 'CERTIFICADO ' VGFOLLOW-NUM-CERTIFICADO */
                _.Display($"CERTIFICADO {VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO}");

                /*" -998- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -0- FLUXCONTROL_PERFORM R0220_00_NEXT */

            R0220_00_NEXT();

        }

        [StopWatch]
        /*" R0220-00-PROCESSA-DB-INSERT-1 */
        public void R0220_00_PROCESSA_DB_INSERT_1()
        {
            /*" -984- EXEC SQL INSERT INTO SEGUROS.VG_FOLLOW_UP (NOM_ARQUIVO, SEQ_GERACAO, NUM_FITA_CEF, NUM_NOSSA_FITA, NUM_LANCAMENTO, COD_CONVENIO, NUM_CERTIFICADO, COD_BANCO, STA_PROCESSAMENTO, NUM_VERSAO_LAYOUT, REG_LANCAMENTO, COD_USUARIO, DTH_ATUALIZACAO) VALUES (:VGFOLLOW-NOM-ARQUIVO, :VGFOLLOW-SEQ-GERACAO, :VGFOLLOW-NUM-FITA-CEF, :VGFOLLOW-NUM-NOSSA-FITA, :VGFOLLOW-NUM-LANCAMENTO, :VGFOLLOW-COD-CONVENIO, :VGFOLLOW-NUM-CERTIFICADO, :VGFOLLOW-COD-BANCO, :VGFOLLOW-STA-PROCESSAMENTO, :VGFOLLOW-NUM-VERSAO-LAYOUT, :VGFOLLOW-REG-LANCAMENTO, :VGFOLLOW-COD-USUARIO, CURRENT TIMESTAMP) END-EXEC. */

            var r0220_00_PROCESSA_DB_INSERT_1_Insert1 = new R0220_00_PROCESSA_DB_INSERT_1_Insert1()
            {
                VGFOLLOW_NOM_ARQUIVO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NOM_ARQUIVO.ToString(),
                VGFOLLOW_SEQ_GERACAO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_SEQ_GERACAO.ToString(),
                VGFOLLOW_NUM_FITA_CEF = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_FITA_CEF.ToString(),
                VGFOLLOW_NUM_NOSSA_FITA = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_NOSSA_FITA.ToString(),
                VGFOLLOW_NUM_LANCAMENTO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_LANCAMENTO.ToString(),
                VGFOLLOW_COD_CONVENIO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_CONVENIO.ToString(),
                VGFOLLOW_NUM_CERTIFICADO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_CERTIFICADO.ToString(),
                VGFOLLOW_COD_BANCO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_BANCO.ToString(),
                VGFOLLOW_STA_PROCESSAMENTO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_STA_PROCESSAMENTO.ToString(),
                VGFOLLOW_NUM_VERSAO_LAYOUT = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_NUM_VERSAO_LAYOUT.ToString(),
                VGFOLLOW_REG_LANCAMENTO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_REG_LANCAMENTO.ToString(),
                VGFOLLOW_COD_USUARIO = VGFOLLOW.DCLVG_FOLLOW_UP.VGFOLLOW_COD_USUARIO.ToString(),
            };

            R0220_00_PROCESSA_DB_INSERT_1_Insert1.Execute(r0220_00_PROCESSA_DB_INSERT_1_Insert1);

        }

        [StopWatch]
        /*" R0220-00-NEXT */
        private void R0220_00_NEXT(bool isPerform = false)
        {
            /*" -1002- READ RETCRE AT END */
            try
            {
                RETCRE.Read(() =>
                {

                    /*" -1002- MOVE 1 TO WS-EOF. */
                    _.Move(1, WORK_AREA.WS_EOF);
                });

                _.Move(RETCRE.Value, RETCRE_RECORD);
                _.Move(RETCRE.Value, RET_HEADERC);
                _.Move(RETCRE.Value, RET_CADASTRAMENTOC);
                _.Move(RETCRE.Value, RET_TRAILLERC);

            }
            catch (GoToException ex)
            {
                return;
            }
        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0220_99_SAIDA*/

        [StopWatch]
        /*" R2000-00-VERIFICA-FITAS-SECTION */
        private void R2000_00_VERIFICA_FITAS_SECTION()
        {
            /*" -1010- OPEN INPUT RETDEB. */
            RETDEB.Open(RETDEB_RECORD);

            /*" -1012- OPEN INPUT RETCRE. */
            RETCRE.Open(RETCRE_RECORD);

            /*" -1014- PERFORM R2100-00-VERIFICA-FITADEB 5 TIMES. */

            for (int i = 0; i < 5; i++)
            {

                R2100_00_VERIFICA_FITADEB_SECTION();

            }

            /*" -1016- PERFORM R2200-00-VERIFICA-FITACRE 5 TIMES. */

            for (int i = 0; i < 5; i++)
            {

                R2200_00_VERIFICA_FITACRE_SECTION();

            }

            /*" -1017- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -1017- CLOSE RETCRE. */
            RETCRE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-VERIFICA-FITADEB-SECTION */
        private void R2100_00_VERIFICA_FITADEB_SECTION()
        {
            /*" -1024- IF WS-EOF-DEB EQUAL ZEROS */

            if (WORK_AREA.WS_EOF_DEB == 00)
            {

                /*" -1024- READ RETDEB AT END */
                try
                {
                    RETDEB.Read(() =>
                    {

                        /*" -1026- MOVE 1 TO WS-EOF-DEB. */
                        _.Move(1, WORK_AREA.WS_EOF_DEB);
                    });

                    _.Move(RETDEB.Value, RETDEB_RECORD);
                    _.Move(RETDEB.Value, RET_HEADER);
                    _.Move(RETDEB.Value, RET_CADASTRAMENTO);

                }
                catch (GoToException ex)
                {
                    return;
                }
            }
            /*" -1027- IF WS-EOF-DEB EQUAL ZEROS */

            if (WORK_AREA.WS_EOF_DEB == 00)
            {

                /*" -1027- ADD 1 TO WS-AC-DEB. */
                WORK_AREA.WS_AC_DEB.Value = WORK_AREA.WS_AC_DEB + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2200-00-VERIFICA-FITACRE-SECTION */
        private void R2200_00_VERIFICA_FITACRE_SECTION()
        {
            /*" -1034- IF WS-EOF-CRE EQUAL ZEROS */

            if (WORK_AREA.WS_EOF_CRE == 00)
            {

                /*" -1034- READ RETCRE AT END */
                try
                {
                    RETCRE.Read(() =>
                    {

                        /*" -1036- MOVE 1 TO WS-EOF-CRE. */
                        _.Move(1, WORK_AREA.WS_EOF_CRE);
                    });

                    _.Move(RETCRE.Value, RETCRE_RECORD);
                    _.Move(RETCRE.Value, RET_HEADERC);
                    _.Move(RETCRE.Value, RET_CADASTRAMENTOC);
                    _.Move(RETCRE.Value, RET_TRAILLERC);

                }
                catch (GoToException ex)
                {
                    return;
                }
            }
            /*" -1037- IF WS-EOF-CRE EQUAL ZEROS */

            if (WORK_AREA.WS_EOF_CRE == 00)
            {

                /*" -1037- ADD 1 TO WS-AC-CRE. */
                WORK_AREA.WS_AC_CRE.Value = WORK_AREA.WS_AC_CRE + 1;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2200_99_SAIDA*/

        [StopWatch]
        /*" DB010-ACESSA-SISTEMA-SECTION */
        private void DB010_ACESSA_SISTEMA_SECTION()
        {
            /*" -1046- MOVE 'DB010-ACESSA-SISTEMA' TO PARAGRAFO. */
            _.Move("DB010-ACESSA-SISTEMA", WS_EDIT.LOCALIZA_ABEND_1.PARAGRAFO);

            /*" -1048- MOVE 'SELECT V1SISTEMA' TO COMANDO. */
            _.Move("SELECT V1SISTEMA", WS_EDIT.LOCALIZA_ABEND_2.COMANDO);

            /*" -1049- MOVE 01 TO SII. */
            _.Move(01, WS_HORAS.SII);

            /*" -1051- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1057- PERFORM DB010_ACESSA_SISTEMA_DB_SELECT_1 */

            DB010_ACESSA_SISTEMA_DB_SELECT_1();

            /*" -1061- PERFORM R9100-00-TERMINO */

            R9100_00_TERMINO_SECTION();

            /*" -1062- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1063- DISPLAY 'SISTEMA "VA" NAO ENCONTRADO' */

                $"SISTEMA VA NAO ENCONTRADO"
                .Display();

                /*" -1064- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1066- END-IF */
            }


            /*" -1067- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1068- DISPLAY 'ERRO SELECT SEGUROS.V1SISTEMA' */
                _.Display($"ERRO SELECT SEGUROS.V1SISTEMA");

                /*" -1069- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1070- END-IF */
            }


            /*" -1070- . */

        }

        [StopWatch]
        /*" DB010-ACESSA-SISTEMA-DB-SELECT-1 */
        public void DB010_ACESSA_SISTEMA_DB_SELECT_1()
        {
            /*" -1057- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V1SISTEMA WHERE IDSISTEM = 'VA' WITH UR END-EXEC. */

            var dB010_ACESSA_SISTEMA_DB_SELECT_1_Query1 = new DB010_ACESSA_SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = DB010_ACESSA_SISTEMA_DB_SELECT_1_Query1.Execute(dB010_ACESSA_SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: DB010_ACESSA_SISTEMA_EXIT*/

        [StopWatch]
        /*" DB015-ACESSA-GEARDETALHE-SECTION */
        private void DB015_ACESSA_GEARDETALHE_SECTION()
        {
            /*" -1077- DISPLAY 'DB015-ACESSA-GEARDETALHE' */
            _.Display($"DB015-ACESSA-GEARDETALHE");

            /*" -1079- MOVE 'SELECT GE_AR_DETALHE ' TO COMANDO. */
            _.Move("SELECT GE_AR_DETALHE ", WS_EDIT.LOCALIZA_ABEND_2.COMANDO);

            /*" -1080- MOVE 14 TO SII */
            _.Move(14, WS_HORAS.SII);

            /*" -1082- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1090- PERFORM DB015_ACESSA_GEARDETALHE_DB_SELECT_1 */

            DB015_ACESSA_GEARDETALHE_DB_SELECT_1();

            /*" -1092- DISPLAY 'SQLCODE = ' SQLCODE */
            _.Display($"SQLCODE = {DB.SQLCODE}");

            /*" -1093- DISPLAY 'WHERE NOM_ARQUIVO = ' GEARDETA-NOM-ARQUIVO */
            _.Display($"WHERE NOM_ARQUIVO = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO}");

            /*" -1094- DISPLAY '  AND SEQ_GERACAO = ' GEARDETA-SEQ-GERACAO */
            _.Display($"  AND SEQ_GERACAO = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO}");

            /*" -1095- DISPLAY ' INTO DTH-ANO-REF = ' GEARDETA-DTH-ANO-REFERENCIA */
            _.Display($" INTO DTH-ANO-REF = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA}");

            /*" -1097- DISPLAY '      DTH-MES-REF = ' GEARDETA-DTH-MES-REFERENCIA */
            _.Display($"      DTH-MES-REF = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA}");

            /*" -1099- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1100- IF SQLCODE NOT = 000 AND +100 */

            if (!DB.SQLCODE.In("000", "+100"))
            {

                /*" -1101- DISPLAY '*** VA0806B *** ERRO SELECT GE_AR_DETALHE ***' */
                _.Display($"*** VA0806B *** ERRO SELECT GE_AR_DETALHE ***");

                /*" -1102- DISPLAY ' NOM_ARQUIVO = ' GEARDETA-NOM-ARQUIVO */
                _.Display($" NOM_ARQUIVO = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO}");

                /*" -1103- DISPLAY ' SEQ_GERACAO = ' GEARDETA-SEQ-GERACAO */
                _.Display($" SEQ_GERACAO = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO}");

                /*" -1104- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1105- END-IF */
            }


            /*" -1105- . */

        }

        [StopWatch]
        /*" DB015-ACESSA-GEARDETALHE-DB-SELECT-1 */
        public void DB015_ACESSA_GEARDETALHE_DB_SELECT_1()
        {
            /*" -1090- EXEC SQL SELECT DTH_ANO_REFERENCIA , DTH_MES_REFERENCIA INTO :GEARDETA-DTH-ANO-REFERENCIA , :GEARDETA-DTH-MES-REFERENCIA FROM SEGUROS.GE_AR_DETALHE WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO AND SEQ_GERACAO = :GEARDETA-SEQ-GERACAO END-EXEC. */

            var dB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1 = new DB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
                GEARDETA_SEQ_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.ToString(),
            };

            var executed_1 = DB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1.Execute(dB015_ACESSA_GEARDETALHE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEARDETA_DTH_ANO_REFERENCIA, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA);
                _.Move(executed_1.GEARDETA_DTH_MES_REFERENCIA, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: DB015_ACESSA_GEARDETALHE_EXIT*/

        [StopWatch]
        /*" DB017-ACESSA-MAX-SEQUENCIA-SECTION */
        private void DB017_ACESSA_MAX_SEQUENCIA_SECTION()
        {
            /*" -1112- DISPLAY 'DB017-ACESSA-MAX-SEQUENCIA' */
            _.Display($"DB017-ACESSA-MAX-SEQUENCIA");

            /*" -1114- MOVE 'SELECT MAX GE_AR_DETALHE ' TO COMANDO. */
            _.Move("SELECT MAX GE_AR_DETALHE ", WS_EDIT.LOCALIZA_ABEND_2.COMANDO);

            /*" -1116- INITIALIZE GEARDETA-SEQ-GERACAO */
            _.Initialize(
                GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO
            );

            /*" -1117- MOVE 15 TO SII */
            _.Move(15, WS_HORAS.SII);

            /*" -1119- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1124- PERFORM DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1 */

            DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1();

            /*" -1126- DISPLAY 'SQLCODE = ' SQLCODE */
            _.Display($"SQLCODE = {DB.SQLCODE}");

            /*" -1127- DISPLAY 'WHERE NOM_ARQUIVO = ' GEARDETA-NOM-ARQUIVO */
            _.Display($"WHERE NOM_ARQUIVO = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO}");

            /*" -1129- DISPLAY ' MAX(SEQ_GERACAO) = ' GEARDETA-SEQ-GERACAO */
            _.Display($" MAX(SEQ_GERACAO) = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO}");

            /*" -1131- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1132- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -1133- DISPLAY '*** VA0806B ** ERRO SELECT MAX GE_AR_DETALHE ***' */
                _.Display($"*** VA0806B ** ERRO SELECT MAX GE_AR_DETALHE ***");

                /*" -1134- DISPLAY ' NOM_ARQUIVO = ' GEARDETA-NOM-ARQUIVO */
                _.Display($" NOM_ARQUIVO = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO}");

                /*" -1135- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1137- END-IF */
            }


            /*" -1138- ADD 1 TO GEARDETA-SEQ-GERACAO */
            GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.Value = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO + 1;

            /*" -1138- . */

        }

        [StopWatch]
        /*" DB017-ACESSA-MAX-SEQUENCIA-DB-SELECT-1 */
        public void DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1()
        {
            /*" -1124- EXEC SQL SELECT MAX(SEQ_GERACAO) INTO :GEARDETA-SEQ-GERACAO FROM SEGUROS.GE_AR_DETALHE WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO END-EXEC. */

            var dB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1 = new DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
            };

            var executed_1 = DB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1.Execute(dB017_ACESSA_MAX_SEQUENCIA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEARDETA_SEQ_GERACAO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: DB017_ACESSA_MAX_SEQUENC_EXIT*/

        [StopWatch]
        /*" DB020-INSERT-GEARDETALHE-SECTION */
        private void DB020_INSERT_GEARDETALHE_SECTION()
        {
            /*" -1145- DISPLAY 'DB020-INSERT-GEARDETALHE' */
            _.Display($"DB020-INSERT-GEARDETALHE");

            /*" -1147- MOVE 'INSERT GE_AR_DETALHE ' TO COMANDO. */
            _.Move("INSERT GE_AR_DETALHE ", WS_EDIT.LOCALIZA_ABEND_2.COMANDO);

            /*" -1148- MOVE 02 TO SII */
            _.Move(02, WS_HORAS.SII);

            /*" -1150- PERFORM R9000-00-INICIO */

            R9000_00_INICIO_SECTION();

            /*" -1180- PERFORM DB020_INSERT_GEARDETALHE_DB_INSERT_1 */

            DB020_INSERT_GEARDETALHE_DB_INSERT_1();

            /*" -1182- DISPLAY 'SQLCODE = ' SQLCODE */
            _.Display($"SQLCODE = {DB.SQLCODE}");

            /*" -1183- DISPLAY ' NOM_ARQUIVO = ' GEARDETA-NOM-ARQUIVO */
            _.Display($" NOM_ARQUIVO = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO}");

            /*" -1184- DISPLAY ' SEQ_GERACAO = ' GEARDETA-SEQ-GERACAO */
            _.Display($" SEQ_GERACAO = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO}");

            /*" -1185- DISPLAY ' DTH-ANO-REF = ' GEARDETA-DTH-ANO-REFERENCIA */
            _.Display($" DTH-ANO-REF = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA}");

            /*" -1186- DISPLAY ' DTH-MES-REF = ' GEARDETA-DTH-MES-REFERENCIA */
            _.Display($" DTH-MES-REF = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA}");

            /*" -1187- DISPLAY ' DTH-MOVIMENT= ' GEARDETA-DTH-MOVIMENTO */
            _.Display($" DTH-MOVIMENT= {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MOVIMENTO}");

            /*" -1189- DISPLAY ' DTH-GERACAO = ' GEARDETA-DTH-GERACAO */
            _.Display($" DTH-GERACAO = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_GERACAO}");

            /*" -1191- PERFORM R9100-00-TERMINO. */

            R9100_00_TERMINO_SECTION();

            /*" -1192- IF SQLCODE NOT = 000 */

            if (DB.SQLCODE != 000)
            {

                /*" -1193- DISPLAY '*** VA0806B *** ERRO INSERT GE_AR_DETALHE ***' */
                _.Display($"*** VA0806B *** ERRO INSERT GE_AR_DETALHE ***");

                /*" -1194- MOVE GEARDETA-SEQ-GERACAO TO WS-INTEGER(01) */
                _.Move(GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO, WS_EDIT.WS_INTEGER[01]);

                /*" -1195- DISPLAY '*** VA0806B *** ERRO SELECT GE_AR_DETALHE ***' */
                _.Display($"*** VA0806B *** ERRO SELECT GE_AR_DETALHE ***");

                /*" -1196- DISPLAY ' NOM_ARQUIVO        = ' GEARDETA-NOM-ARQUIVO */
                _.Display($" NOM_ARQUIVO        = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO}");

                /*" -1197- DISPLAY ' SEQ_GERACAO        = ' WS-INTEGER(01) */
                _.Display($" SEQ_GERACAO        = {WS_EDIT.WS_INTEGER[1]}");

                /*" -1199- DISPLAY ' DTH-ANO-REFERENCIA = ' GEARDETA-DTH-ANO-REFERENCIA */
                _.Display($" DTH-ANO-REFERENCIA = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA}");

                /*" -1201- DISPLAY ' DTH-MES-REFERENCIA = ' GEARDETA-DTH-MES-REFERENCIA */
                _.Display($" DTH-MES-REFERENCIA = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA}");

                /*" -1202- DISPLAY ' DTH-MOVIMENTO      = ' GEARDETA-DTH-MOVIMENTO */
                _.Display($" DTH-MOVIMENTO      = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MOVIMENTO}");

                /*" -1203- DISPLAY ' DTH-GERACAO        = ' GEARDETA-DTH-GERACAO */
                _.Display($" DTH-GERACAO        = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_GERACAO}");

                /*" -1204- DISPLAY ' DTH-RECEPCAO       = ' GEARDETA-DTH-RECEPCAO */
                _.Display($" DTH-RECEPCAO       = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_RECEPCAO}");

                /*" -1205- DISPLAY ' IND-MEIO-ENVIO     = ' GEARDETA-IND-MEIO-ENVIO */
                _.Display($" IND-MEIO-ENVIO     = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_IND_MEIO_ENVIO}");

                /*" -1207- DISPLAY ' STA-ENVIO-RECEPCAO = ' GEARDETA-STA-ENVIO-RECEPCAO */
                _.Display($" STA-ENVIO-RECEPCAO = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_STA_ENVIO_RECEPCAO}");

                /*" -1208- DISPLAY ' COD-TIPO-ARQUIVO   = ' GEARDETA-COD-TIPO-ARQUIVO */
                _.Display($" COD-TIPO-ARQUIVO   = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_COD_TIPO_ARQUIVO}");

                /*" -1210- DISPLAY ' QTD-REG-PROCESSADO = ' GEARDETA-QTD-REG-PROCESSADO */
                _.Display($" QTD-REG-PROCESSADO = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO}");

                /*" -1212- DISPLAY ' QTD-REG-REJEITADOS = ' GEARDETA-QTD-REG-REJEITADOS */
                _.Display($" QTD-REG-REJEITADOS = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_REJEITADOS}");

                /*" -1213- DISPLAY ' QTD-REG-ACEITOS    = ' GEARDETA-QTD-REG-ACEITOS */
                _.Display($" QTD-REG-ACEITOS    = {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_ACEITOS}");

                /*" -1214- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -1215- END-IF */
            }


            /*" -1215- . */

        }

        [StopWatch]
        /*" DB020-INSERT-GEARDETALHE-DB-INSERT-1 */
        public void DB020_INSERT_GEARDETALHE_DB_INSERT_1()
        {
            /*" -1180- EXEC SQL INSERT INTO SEGUROS.GE_AR_DETALHE (NOM_ARQUIVO, SEQ_GERACAO, DTH_ANO_REFERENCIA, DTH_MES_REFERENCIA, DTH_MOVIMENTO, DTH_GERACAO, DTH_RECEPCAO, IND_MEIO_ENVIO, STA_ENVIO_RECEPCAO, COD_TIPO_ARQUIVO, QTD_REG_PROCESSADO, QTD_REG_REJEITADOS, QTD_REG_ACEITOS, DTH_TIMESTAMP) VALUES (:GEARDETA-NOM-ARQUIVO, :GEARDETA-SEQ-GERACAO, :GEARDETA-DTH-ANO-REFERENCIA, :GEARDETA-DTH-MES-REFERENCIA, :GEARDETA-DTH-MOVIMENTO, :GEARDETA-DTH-GERACAO, :GEARDETA-DTH-RECEPCAO, :GEARDETA-IND-MEIO-ENVIO, :GEARDETA-STA-ENVIO-RECEPCAO, :GEARDETA-COD-TIPO-ARQUIVO, :GEARDETA-QTD-REG-PROCESSADO, :GEARDETA-QTD-REG-REJEITADOS, :GEARDETA-QTD-REG-ACEITOS, CURRENT TIMESTAMP) END-EXEC. */

            var dB020_INSERT_GEARDETALHE_DB_INSERT_1_Insert1 = new DB020_INSERT_GEARDETALHE_DB_INSERT_1_Insert1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
                GEARDETA_SEQ_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.ToString(),
                GEARDETA_DTH_ANO_REFERENCIA = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA.ToString(),
                GEARDETA_DTH_MES_REFERENCIA = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA.ToString(),
                GEARDETA_DTH_MOVIMENTO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MOVIMENTO.ToString(),
                GEARDETA_DTH_GERACAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_GERACAO.ToString(),
                GEARDETA_DTH_RECEPCAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_RECEPCAO.ToString(),
                GEARDETA_IND_MEIO_ENVIO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_IND_MEIO_ENVIO.ToString(),
                GEARDETA_STA_ENVIO_RECEPCAO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_STA_ENVIO_RECEPCAO.ToString(),
                GEARDETA_COD_TIPO_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_COD_TIPO_ARQUIVO.ToString(),
                GEARDETA_QTD_REG_PROCESSADO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO.ToString(),
                GEARDETA_QTD_REG_REJEITADOS = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_REJEITADOS.ToString(),
                GEARDETA_QTD_REG_ACEITOS = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_ACEITOS.ToString(),
            };

            DB020_INSERT_GEARDETALHE_DB_INSERT_1_Insert1.Execute(dB020_INSERT_GEARDETALHE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: DB020_INSERT_GEARDETALHE_EXIT*/

        [StopWatch]
        /*" R9000-00-INICIO-SECTION */
        private void R9000_00_INICIO_SECTION()
        {
            /*" -1222- ACCEPT WS-HORA-INI FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_INI);

            /*" -1223- COMPUTE SIT = (HI * 60 * 60) + (MI * 60) + SI + (DI / 100). */
            WS_HORAS.SIT.Value = (WS_HORAS.WS_HORA_INI_R.HI * 60 * 60) + (WS_HORAS.WS_HORA_INI_R.MI * 60) + WS_HORAS.WS_HORA_INI_R.SI + (WS_HORAS.WS_HORA_INI_R.DI / 100f);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9000_99_SAIDA*/

        [StopWatch]
        /*" R9100-00-TERMINO-SECTION */
        private void R9100_00_TERMINO_SECTION()
        {
            /*" -1232- ACCEPT WS-HORA-FIM FROM TIME */
            _.Move(_.AcceptDate("TIME"), WS_HORAS.WS_HORA_FIM);

            /*" -1233- COMPUTE SFT = (HF * 60 * 60) + (MF * 60) + SF + (DF / 100) */
            WS_HORAS.SFT.Value = (WS_HORAS.WS_HORA_FIM_R.HF * 60 * 60) + (WS_HORAS.WS_HORA_FIM_R.MF * 60) + WS_HORAS.WS_HORA_FIM_R.SF + (WS_HORAS.WS_HORA_FIM_R.DF / 100f);

            /*" -1234- SUBTRACT SIT FROM SFT */
            WS_HORAS.SFT.Value = WS_HORAS.SFT - WS_HORAS.SIT;

            /*" -1235- ADD SFT TO STT(SII) */
            TOTAIS_ROT.FILLER_23[WS_HORAS.SII].STT.Value = TOTAIS_ROT.FILLER_23[WS_HORAS.SII].STT + WS_HORAS.SFT;

            /*" -1236- ADD 1 TO SQT(SII). */
            TOTAIS_ROT.FILLER_23[WS_HORAS.SII].SQT.Value = TOTAIS_ROT.FILLER_23[WS_HORAS.SII].SQT + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9100_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-MOSTRA-TOTAIS-SECTION */
        private void R9900_00_MOSTRA_TOTAIS_SECTION()
        {
            /*" -1245- DISPLAY ' ' . */
            _.Display($" ");

            /*" -1246- MOVE ZEROS TO SII. */
            _.Move(0, WS_HORAS.SII);

            /*" -0- FLUXCONTROL_PERFORM R9900_10_MOSTRA_TOTAIS */

            R9900_10_MOSTRA_TOTAIS();

        }

        [StopWatch]
        /*" R9900-10-MOSTRA-TOTAIS */
        private void R9900_10_MOSTRA_TOTAIS(bool isPerform = false)
        {
            /*" -1251- ADD 1 TO SII. */
            WS_HORAS.SII.Value = WS_HORAS.SII + 1;

            /*" -1252- IF SII < 51 */

            if (WS_HORAS.SII < 51)
            {

                /*" -1253- MOVE STT(SII) TO STT-DISP */
                _.Move(TOTAIS_ROT.FILLER_23[WS_HORAS.SII].STT, WS_HORAS.STT_DISP);

                /*" -1255- DISPLAY 'PARAGRAFO:' SII ' TOTAL= ' STT-DISP ' QTDE= ' SQT(SII) */

                $"PARAGRAFO:{WS_HORAS.SII} TOTAL= {WS_HORAS.STT_DISP} QTDE= {TOTAIS_ROT.FILLER_23[WS_HORAS.SII]}"
                .Display();

                /*" -1257- GO TO R9900-10-MOSTRA-TOTAIS. */
                new Task(() => R9900_10_MOSTRA_TOTAIS()).RunSynchronously(); //GOTO
                return;//Recursividade detectada, cuidado...
            }


            /*" -1258- DISPLAY ' ' . */
            _.Display($" ");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -1270- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WS_EDIT.WABEND.WSQLCODE);

            /*" -1271- MOVE SQLERRD(1) TO WSQLERRD1. */
            _.Move(DB.SQLERRD[1], WS_EDIT.WABEND.WSQLERRD1);

            /*" -1272- MOVE SQLERRD(2) TO WSQLERRD2. */
            _.Move(DB.SQLERRD[2], WS_EDIT.WABEND.WSQLERRD2);

            /*" -1273- DISPLAY WABEND. */
            _.Display(WS_EDIT.WABEND);

            /*" -1274- DISPLAY LOCALIZA-ABEND-1. */
            _.Display(WS_EDIT.LOCALIZA_ABEND_1);

            /*" -1275- DISPLAY LOCALIZA-ABEND-2. */
            _.Display(WS_EDIT.LOCALIZA_ABEND_2);

            /*" -1277- DISPLAY 'SQLERRMC=' SQLERRMC */
            _.Display($"SQLERRMC={DB.SQLERRMC}");

            /*" -1278- CLOSE RETDEB. */
            RETDEB.Close();

            /*" -1280- CLOSE RETCRE. */
            RETCRE.Close();

            /*" -1280- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -1284- PERFORM R9900-00-MOSTRA-TOTAIS. */

            R9900_00_MOSTRA_TOTAIS_SECTION();

            /*" -1286- MOVE 9 TO RETURN-CODE. */
            _.Move(9, RETURN_CODE);

            /*" -1286- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}