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
using Sias.Outros.DB2.RG0805B;

namespace Code
{
    public class RG0805B
    {
        public bool IsCall { get; set; }

        public RG0805B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  REGISTROS                          *      */
        /*"      *   PROGRAMA ...............  RG0805B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  HEIDER COELHO                      *      */
        /*"      *   PROGRAMADOR ............  JOSE AGNALDO                       *      */
        /*"      *   DATA CODIFICACAO .......  JUNHO/92                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  INSERIR NA TABELA V0RELATORIOS OS  *      */
        /*"      *   PARAMETROS DE EXECUCAO DO FECHAMENTO MENSAL DO SINISTRO      *      */
        /*"      *                             (R.O.'S DE SINISTRO)               *      */
        /*"      *  #ATENCAO# FOI CRIADO O PROGRAMA RG0806B QUE EH UMA COPIA DESTE*      */
        /*"      *  PARA GRAVAR NA RELATORIOS APENAS PARA OS PROGRAMA RG0052B,    *      */
        /*"      *  RG00062B E SI0300B NO CASO DE ERRO NO PROCESSAMENTO NORMAL.   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                            VIEW                 ACESSO  *      */
        /*"      * --------------------------------- -----------------    ------- *      */
        /*"      * SISTEMAS                          V0SISTEMA            INPUT   *      */
        /*"      * RELATORIOS                        V0RELATORIOS         I-O     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - RILDO SICO 28/03/2000                              *      */
        /*"      *             INCLUSAO DO RELATORIO SI0029B - PROCURAR - RS001   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - RILDO SICO 22/11/2001                              *      */
        /*"      *             INCLUSAO DO RELATORIO SI0805B - PROCURAR - RS002   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - JUCINEYDE R. OLIVEIRA  15/07/2003.                 *      */
        /*"      *             INCLUSAO DOS ARQUIVOS TXT RG0052B E RG0062B QUE    *      */
        /*"      *             CORRESPODEM AO RG0050B E RG0060B. PROCURAR - JU0703*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - GILSON PINTO DA SILVA  22/06/2004.                 *      */
        /*"      *             INCLUSAO DOS ARQUIVOS TXT RG0053B E RG0063B QUE    *      */
        /*"      *             CORRESPODEM AO RG0050B E RG0060B. PROCURAR - GPS   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - ALEXIS VEAS ITURRIAGA  11/04/2005.                 *      */
        /*"      *             INCLUSAO DA SOLICITACAO DO PROGRAMA SI0873B,       *      */
        /*"      *             PROCURAR AV1104.                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - GILSON PINTO DA SILVA  31/05/2005.                 *      */
        /*"      *             INCLUSAO DO  ARQUIVO  TXT RG0054B                  *      */
        /*"      *             REGISTRO OFICIAL DE SINISTROS EM TRANSITO          *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - ALEXIS VEAS ITURRIAGA  05/06/2006.                 *      */
        /*"      *             INCLUSAO DA SOLICITACAO DO PROGRAMA SI0215B        *      */
        /*"      *             PROCURAR AV0506.                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - ALEXIS VEAS ITURRIAGA  27/06/2006.                 *      */
        /*"      *             INCLUSAO DA SOLICITACAO DO PROGRAMA SI0871B        *      */
        /*"      *             PROCURAR AV2706.                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - OLIVEIRA       -       18/05/2007.                 *      */
        /*"      *             INCLUSAO DA SOLICITACAO DO PROGRAMA SI0897B/SI898B *      */
        /*"      *             PROCURAR OL1805.                                   *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 03/07/2008  BRSEG(VANDO) - SSI.11540/2006 - PROCURE: BR.V01    *      */
        /*"      *             INCLUSAO DA SOLICITACAO PARA OS PROGRAMAS :        *      */
        /*"      *             RG0055B - SINISTROS PENDENTES NOSSA LIDERANCA      *      */
        /*"      *             RG0064B - SINISTROS PENDENTES COSSEGURO ACEITO     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 23/07/2008  BRSEG(VANDO) - SSI.18295/2007 - PROCURE: BR.V02    *      */
        /*"      *             INCLUSAO DA SOLICITACAO PARA O PROGRAMA :          *      */
        /*"      *             RG0904B - RESERVA DE SINISTROS A LIQUIDAR DE COS-  *      */
        /*"      *                       SEGURO CEDIDO PRO CIA. CONGENERE.        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * 19/08/2010  HERVAL - PROCURAR POR C46102                       *      */
        /*"      *             INCLUSAO DA SOLICITACAO PARA O PROGRAMA :          *      */
        /*"      *             RG0401B E RG0422B.                                 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - DESLIGAMENTO DE ROTINAS E PROGRAMAS               *      */
        /*"      * 24/01/2013 - WELLINGTON VERAS (TE39902) - PROCURAR POR C74620  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - TROCAR NA TABELA SITEMAS A SIGLA SI PARA RG       *      */
        /*"      * 02/08/2013 - WELLINGTON VERAS (TE39902) - PROCURAR POR C74620  *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INIBIR A SOLICITACAO DE EXECUCAO DO PROGM RG0002B *      */
        /*"      * 07/04/2014 - GILSON PINTO DA SILVA  -  PROCURAR POR DIASIA     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INCLUIR A SOLICITACAO DOS PROGMS RG0403B E RG0406B*      */
        /*"      * 24/04/2014 - GILSON PINTO DA SILVA  -  PROCURAR POR DIASIA     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - ALTERAR NOME DO PROGRAMA SI0873B POR SI0879B      *      */
        /*"      *  MELHORIA DO PROEJTO FGV-2, ONDE FORAM TROCADOS OS PROGRAMAS   *      */
        /*"      * 20/04/2016 - DIEGO DIAS             -  PROCURAR POR DDIAS      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - INCLUSAO DOS PROGRAMAS RG0056B PARA EXTRACAO DE   *      */
        /*"      *  DADOS DO PROJETO BDPO                                         *      */
        /*"      * 20/09/2017 - WANGER C SILVA         -  PROCURAR POR WANGER     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77          VIND-COD-EMPR       PIC S9(004)               COMP.*/
        public IntBasis VIND_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-PERI-RENOV     PIC S9(004)               COMP.*/
        public IntBasis VIND_PERI_RENOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          VIND-PCT-AUMENTO    PIC S9(004)               COMP.*/
        public IntBasis VIND_PCT_AUMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0SIST-DTMOVABE      PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0SIST-DTCURRENT     PIC  X(010).*/
        public StringBasis V0SIST_DTCURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0RELA-CODUSU        PIC  X(008).*/
        public StringBasis V0RELA_CODUSU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77          V0RELA-DT-SOLIC      PIC  X(010).*/
        public StringBasis V0RELA_DT_SOLIC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0RELA-IDSISTEM      PIC  X(002).*/
        public StringBasis V0RELA_IDSISTEM { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
        /*"77          V0RELA-CODRELAT      PIC  X(008).*/
        public StringBasis V0RELA_CODRELAT { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
        /*"77          V0RELA-NRCOPIAS      PIC S9(004)              COMP.*/
        public IntBasis V0RELA_NRCOPIAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-QTDE          PIC S9(004)              COMP.*/
        public IntBasis V0RELA_QTDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-PERI-INIC     PIC  X(010).*/
        public StringBasis V0RELA_PERI_INIC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0RELA-PERI-FINAL    PIC  X(010).*/
        public StringBasis V0RELA_PERI_FINAL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0RELA-DATA-REFER    PIC  X(010).*/
        public StringBasis V0RELA_DATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77          V0RELA-MES-REFER     PIC S9(004)              COMP.*/
        public IntBasis V0RELA_MES_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-ANO-REFER     PIC S9(004)              COMP.*/
        public IntBasis V0RELA_ANO_REFER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-ORGAO         PIC S9(004)              COMP.*/
        public IntBasis V0RELA_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-FONTE         PIC S9(004)              COMP.*/
        public IntBasis V0RELA_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-CODPDT        PIC S9(009)              COMP.*/
        public IntBasis V0RELA_CODPDT { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0RELA-RAMO          PIC S9(004)              COMP.*/
        public IntBasis V0RELA_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-MODALID       PIC S9(004)              COMP.*/
        public IntBasis V0RELA_MODALID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-CONGENER      PIC S9(004)              COMP.*/
        public IntBasis V0RELA_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-NUM-APOL      PIC S9(013)              COMP-3*/
        public IntBasis V0RELA_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0RELA-NRENDOS       PIC S9(009)              COMP.*/
        public IntBasis V0RELA_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0RELA-NRPARCEL      PIC S9(004)              COMP.*/
        public IntBasis V0RELA_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-NRCERTIF      PIC S9(015)              COMP-3*/
        public IntBasis V0RELA_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V0RELA-NRTIT         PIC S9(013)              COMP-3*/
        public IntBasis V0RELA_NRTIT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0RELA-CODSUBES      PIC S9(004)              COMP.*/
        public IntBasis V0RELA_CODSUBES { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-OPERACAO      PIC S9(004)              COMP.*/
        public IntBasis V0RELA_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-COD-PLANO     PIC S9(004)              COMP.*/
        public IntBasis V0RELA_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-OCORHIST      PIC S9(004)              COMP.*/
        public IntBasis V0RELA_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-APOL-LIDER    PIC  X(015).*/
        public StringBasis V0RELA_APOL_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77          V0RELA-ENDS-LIDER    PIC  X(015).*/
        public StringBasis V0RELA_ENDS_LIDER { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77          V0RELA-NRPARC-LID    PIC S9(004)              COMP.*/
        public IntBasis V0RELA_NRPARC_LID { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-NUM-SINIST    PIC S9(013)              COMP-3*/
        public IntBasis V0RELA_NUM_SINIST { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V0RELA-NSINI-LID     PIC  X(015).*/
        public StringBasis V0RELA_NSINI_LID { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
        /*"77          V0RELA-NUM-ORDEM     PIC S9(015)              COMP-3*/
        public IntBasis V0RELA_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77          V0RELA-CODUNIMO      PIC S9(004)              COMP.*/
        public IntBasis V0RELA_CODUNIMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-CORRECAO      PIC  X(001).*/
        public StringBasis V0RELA_CORRECAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0RELA-SITUACAO      PIC  X(001).*/
        public StringBasis V0RELA_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0RELA-PRV-DEF       PIC  X(001).*/
        public StringBasis V0RELA_PRV_DEF { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0RELA-ANAL-RESU     PIC  X(001).*/
        public StringBasis V0RELA_ANAL_RESU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77          V0RELA-COD-EMPR      PIC S9(009)              COMP.*/
        public IntBasis V0RELA_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V0RELA-PERI-RENOV    PIC S9(004)              COMP.*/
        public IntBasis V0RELA_PERI_RENOV { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V0RELA-PCT-AUMENTO   PIC S9(003)V99           COMP-3*/
        public DoubleBasis V0RELA_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01          AREA-DE-WORK.*/
        public RG0805B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new RG0805B_AREA_DE_WORK();
        public class RG0805B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WSL-SQLCODE         PIC  9(009)      VALUE ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        WRESTO              PIC S9(003)      VALUE +0 COMP-3*/
            public IntBasis WRESTO { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
            /*"  05        WDATA-CURRENT       PIC  X(010)      VALUE SPACES.*/
            public StringBasis WDATA_CURRENT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        WDATA-CURR-R        REDEFINES        WDATA-CURRENT.*/
            private _REDEF_RG0805B_WDATA_CURR_R _wdata_curr_r { get; set; }
            public _REDEF_RG0805B_WDATA_CURR_R WDATA_CURR_R
            {
                get { _wdata_curr_r = new _REDEF_RG0805B_WDATA_CURR_R(); _.Move(WDATA_CURRENT, _wdata_curr_r); VarBasis.RedefinePassValue(WDATA_CURRENT, _wdata_curr_r, WDATA_CURRENT); _wdata_curr_r.ValueChanged += () => { _.Move(_wdata_curr_r, WDATA_CURRENT); }; return _wdata_curr_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_curr_r, WDATA_CURRENT); }
            }  //Redefines
            public class _REDEF_RG0805B_WDATA_CURR_R : VarBasis
            {
                /*"    10      WDATA-CURR-ANO      PIC  9(004).*/
                public IntBasis WDATA_CURR_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-CURR-MES      PIC  9(002).*/
                public IntBasis WDATA_CURR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-CURR-DIA      PIC  9(002).*/
                public IntBasis WDATA_CURR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDATA-REF           PIC  X(010)      VALUE SPACES.*/

                public _REDEF_RG0805B_WDATA_CURR_R()
                {
                    WDATA_CURR_ANO.ValueChanged += OnValueChanged;
                    FILLER_0.ValueChanged += OnValueChanged;
                    WDATA_CURR_MES.ValueChanged += OnValueChanged;
                    FILLER_1.ValueChanged += OnValueChanged;
                    WDATA_CURR_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_REF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        WDATA-REF-R         REDEFINES        WDATA-REF.*/
            private _REDEF_RG0805B_WDATA_REF_R _wdata_ref_r { get; set; }
            public _REDEF_RG0805B_WDATA_REF_R WDATA_REF_R
            {
                get { _wdata_ref_r = new _REDEF_RG0805B_WDATA_REF_R(); _.Move(WDATA_REF, _wdata_ref_r); VarBasis.RedefinePassValue(WDATA_REF, _wdata_ref_r, WDATA_REF); _wdata_ref_r.ValueChanged += () => { _.Move(_wdata_ref_r, WDATA_REF); }; return _wdata_ref_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_ref_r, WDATA_REF); }
            }  //Redefines
            public class _REDEF_RG0805B_WDATA_REF_R : VarBasis
            {
                /*"    10      WDAT-REF-ANO        PIC  9(004).*/
                public IntBasis WDAT_REF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REF-MES        PIC  9(002).*/
                public IntBasis WDAT_REF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REF-DIA        PIC  9(002).*/
                public IntBasis WDAT_REF_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WREFE-DATA-INI      PIC  X(010)      VALUE SPACES.*/

                public _REDEF_RG0805B_WDATA_REF_R()
                {
                    WDAT_REF_ANO.ValueChanged += OnValueChanged;
                    FILLER_2.ValueChanged += OnValueChanged;
                    WDAT_REF_MES.ValueChanged += OnValueChanged;
                    FILLER_3.ValueChanged += OnValueChanged;
                    WDAT_REF_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WREFE_DATA_INI { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        WREF-DAT-INI-R      REDEFINES        WREFE-DATA-INI.*/
            private _REDEF_RG0805B_WREF_DAT_INI_R _wref_dat_ini_r { get; set; }
            public _REDEF_RG0805B_WREF_DAT_INI_R WREF_DAT_INI_R
            {
                get { _wref_dat_ini_r = new _REDEF_RG0805B_WREF_DAT_INI_R(); _.Move(WREFE_DATA_INI, _wref_dat_ini_r); VarBasis.RedefinePassValue(WREFE_DATA_INI, _wref_dat_ini_r, WREFE_DATA_INI); _wref_dat_ini_r.ValueChanged += () => { _.Move(_wref_dat_ini_r, WREFE_DATA_INI); }; return _wref_dat_ini_r; }
                set { VarBasis.RedefinePassValue(value, _wref_dat_ini_r, WREFE_DATA_INI); }
            }  //Redefines
            public class _REDEF_RG0805B_WREF_DAT_INI_R : VarBasis
            {
                /*"    10      WREFE-ANO-INI       PIC  9(004).*/
                public IntBasis WREFE_ANO_INI { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WREFE-BR1-INI       PIC  X(001).*/
                public StringBasis WREFE_BR1_INI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WREFE-MES-INI       PIC  9(002).*/
                public IntBasis WREFE_MES_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WREFE-BR2-INI       PIC  X(001).*/
                public StringBasis WREFE_BR2_INI { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WREFE-DIA-INI       PIC  9(002).*/
                public IntBasis WREFE_DIA_INI { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WREFE-DATA-TER      PIC  X(010)      VALUE SPACES.*/

                public _REDEF_RG0805B_WREF_DAT_INI_R()
                {
                    WREFE_ANO_INI.ValueChanged += OnValueChanged;
                    WREFE_BR1_INI.ValueChanged += OnValueChanged;
                    WREFE_MES_INI.ValueChanged += OnValueChanged;
                    WREFE_BR2_INI.ValueChanged += OnValueChanged;
                    WREFE_DIA_INI.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WREFE_DATA_TER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        WREF-DAT-TER-R      REDEFINES        WREFE-DATA-TER.*/
            private _REDEF_RG0805B_WREF_DAT_TER_R _wref_dat_ter_r { get; set; }
            public _REDEF_RG0805B_WREF_DAT_TER_R WREF_DAT_TER_R
            {
                get { _wref_dat_ter_r = new _REDEF_RG0805B_WREF_DAT_TER_R(); _.Move(WREFE_DATA_TER, _wref_dat_ter_r); VarBasis.RedefinePassValue(WREFE_DATA_TER, _wref_dat_ter_r, WREFE_DATA_TER); _wref_dat_ter_r.ValueChanged += () => { _.Move(_wref_dat_ter_r, WREFE_DATA_TER); }; return _wref_dat_ter_r; }
                set { VarBasis.RedefinePassValue(value, _wref_dat_ter_r, WREFE_DATA_TER); }
            }  //Redefines
            public class _REDEF_RG0805B_WREF_DAT_TER_R : VarBasis
            {
                /*"    10      WREFE-ANO-TER       PIC  9(004).*/
                public IntBasis WREFE_ANO_TER { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WREFE-BR1-TER       PIC  X(001).*/
                public StringBasis WREFE_BR1_TER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WREFE-MES-TER       PIC  9(002).*/
                public IntBasis WREFE_MES_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WREFE-BR2-TER       PIC  X(001).*/
                public StringBasis WREFE_BR2_TER { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WREFE-DIA-TER       PIC  9(002).*/
                public IntBasis WREFE_DIA_TER { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        WDATA-SOLICIT       PIC  X(010)      VALUE SPACES.*/

                public _REDEF_RG0805B_WREF_DAT_TER_R()
                {
                    WREFE_ANO_TER.ValueChanged += OnValueChanged;
                    WREFE_BR1_TER.ValueChanged += OnValueChanged;
                    WREFE_MES_TER.ValueChanged += OnValueChanged;
                    WREFE_BR2_TER.ValueChanged += OnValueChanged;
                    WREFE_DIA_TER.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_SOLICIT { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05        WDATA-SOLIC-R       REDEFINES        WDATA-SOLICIT.*/
            private _REDEF_RG0805B_WDATA_SOLIC_R _wdata_solic_r { get; set; }
            public _REDEF_RG0805B_WDATA_SOLIC_R WDATA_SOLIC_R
            {
                get { _wdata_solic_r = new _REDEF_RG0805B_WDATA_SOLIC_R(); _.Move(WDATA_SOLICIT, _wdata_solic_r); VarBasis.RedefinePassValue(WDATA_SOLICIT, _wdata_solic_r, WDATA_SOLICIT); _wdata_solic_r.ValueChanged += () => { _.Move(_wdata_solic_r, WDATA_SOLICIT); }; return _wdata_solic_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_solic_r, WDATA_SOLICIT); }
            }  //Redefines
            public class _REDEF_RG0805B_WDATA_SOLIC_R : VarBasis
            {
                /*"    10      WDATA-ANO-SOL       PIC  9(004).*/
                public IntBasis WDATA_ANO_SOL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      WDATA-BR1-SOL       PIC  X(001).*/
                public StringBasis WDATA_BR1_SOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-MES-SOL       PIC  9(002).*/
                public IntBasis WDATA_MES_SOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WDATA-BR2-SOL       PIC  X(001).*/
                public StringBasis WDATA_BR2_SOL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDATA-DIA-SOL       PIC  9(002).*/
                public IntBasis WDATA_DIA_SOL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01          WS-DATA-COMPILACAO.*/

                public _REDEF_RG0805B_WDATA_SOLIC_R()
                {
                    WDATA_ANO_SOL.ValueChanged += OnValueChanged;
                    WDATA_BR1_SOL.ValueChanged += OnValueChanged;
                    WDATA_MES_SOL.ValueChanged += OnValueChanged;
                    WDATA_BR2_SOL.ValueChanged += OnValueChanged;
                    WDATA_DIA_SOL.ValueChanged += OnValueChanged;
                }

            }
        }
        public RG0805B_WS_DATA_COMPILACAO WS_DATA_COMPILACAO { get; set; } = new RG0805B_WS_DATA_COMPILACAO();
        public class RG0805B_WS_DATA_COMPILACAO : VarBasis
        {
            /*"  05        WDATA-COBOL         PIC  X(021)      VALUE SPACES.*/
            public StringBasis WDATA_COBOL { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
            /*"  05        FILLER              REDEFINES        WDATA-COBOL.*/
            private _REDEF_RG0805B_FILLER_4 _filler_4 { get; set; }
            public _REDEF_RG0805B_FILLER_4 FILLER_4
            {
                get { _filler_4 = new _REDEF_RG0805B_FILLER_4(); _.Move(WDATA_COBOL, _filler_4); VarBasis.RedefinePassValue(WDATA_COBOL, _filler_4, WDATA_COBOL); _filler_4.ValueChanged += () => { _.Move(_filler_4, WDATA_COBOL); }; return _filler_4; }
                set { VarBasis.RedefinePassValue(value, _filler_4, WDATA_COBOL); }
            }  //Redefines
            public class _REDEF_RG0805B_FILLER_4 : VarBasis
            {
                /*"    10      CT-ANO              PIC  9(004).*/
                public IntBasis CT_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10      CT-MES              PIC  9(002).*/
                public IntBasis CT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      CT-DIA              PIC  9(002).*/
                public IntBasis CT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      CT-HORA             PIC  9(002).*/
                public IntBasis CT_HORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      CT-MIN              PIC  9(002).*/
                public IntBasis CT_MIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      CT-SEG              PIC  9(002).*/
                public IntBasis CT_SEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      CT-DECSEG           PIC  9(002).*/
                public IntBasis CT_DECSEG { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      CT-GREEN            PIC  X(001).*/
                public StringBasis CT_GREEN { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      CT-GHORA            PIC  9(002).*/
                public IntBasis CT_GHORA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      CT-GMIN             PIC  9(002).*/
                public IntBasis CT_GMIN { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05        DATA-CATALOGACAO    PIC  X(028)      VALUE  SPACES.*/

                public _REDEF_RG0805B_FILLER_4()
                {
                    CT_ANO.ValueChanged += OnValueChanged;
                    CT_MES.ValueChanged += OnValueChanged;
                    CT_DIA.ValueChanged += OnValueChanged;
                    CT_HORA.ValueChanged += OnValueChanged;
                    CT_MIN.ValueChanged += OnValueChanged;
                    CT_SEG.ValueChanged += OnValueChanged;
                    CT_DECSEG.ValueChanged += OnValueChanged;
                    CT_GREEN.ValueChanged += OnValueChanged;
                    CT_GHORA.ValueChanged += OnValueChanged;
                    CT_GMIN.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis DATA_CATALOGACAO { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"");
            /*"01          WABEND.*/
        }
        public RG0805B_WABEND WABEND { get; set; } = new RG0805B_WABEND();
        public class RG0805B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(010)      VALUE           ' RG0805B'.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" RG0805B");
            /*"  05        FILLER              PIC  X(026)      VALUE           ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05        WNR-EXEC-SQL        PIC  X(003)      VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05        FILLER              PIC  X(013)      VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZZ999-  VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute() //PROCEDURE DIVISION 
        /**/
        {
            try
            {

                /*" -0- FLUXCONTROL_PERFORM R0000-00-PRINCIPAL-SECTION */

                R0000_00_PRINCIPAL_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            return Result;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -297- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -298- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -301- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -304- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -310- MOVE FUNCTION WHEN-COMPILED TO WDATA-COBOL. */
            _.Move(_.WhenCompiled(), WS_DATA_COMPILACAO.WDATA_COBOL);

            /*" -322- STRING CT-ANO '-' CT-MES '-' CT-DIA 'T' CT-HORA ':' CT-MIN ':' CT-SEG ',' CT-DECSEG CT-GREEN CT-GHORA ':' CT-GMIN DELIMITED BY SIZE INTO DATA-CATALOGACAO. */
            #region STRING
            var spl1 = WS_DATA_COMPILACAO.FILLER_4.CT_ANO.GetMoveValues();
            spl1 += "-";
            var spl2 = WS_DATA_COMPILACAO.FILLER_4.CT_MES.GetMoveValues();
            spl2 += "-";
            var spl3 = WS_DATA_COMPILACAO.FILLER_4.CT_DIA.GetMoveValues();
            spl3 += "T";
            var spl4 = WS_DATA_COMPILACAO.FILLER_4.CT_HORA.GetMoveValues();
            spl4 += ":";
            var spl5 = WS_DATA_COMPILACAO.FILLER_4.CT_MIN.GetMoveValues();
            spl5 += ":";
            var spl6 = WS_DATA_COMPILACAO.FILLER_4.CT_SEG.GetMoveValues();
            spl6 += ",";
            var spl7 = WS_DATA_COMPILACAO.FILLER_4.CT_DECSEG.GetMoveValues();
            var spl8 = WS_DATA_COMPILACAO.FILLER_4.CT_GREEN.GetMoveValues();
            var spl9 = WS_DATA_COMPILACAO.FILLER_4.CT_GHORA.GetMoveValues();
            spl9 += ":";
            var spl10 = WS_DATA_COMPILACAO.FILLER_4.CT_GMIN.GetMoveValues();
            var results11 = spl1 + spl2 + spl3 + spl4 + spl5 + spl6 + spl7 + spl8 + spl9 + spl10;
            _.Move(results11, WS_DATA_COMPILACAO.DATA_CATALOGACAO);
            #endregion

            /*" -324- DISPLAY '----------------------------------------------------------' . */
            _.Display($"----------------------------------------------------------");

            /*" -325- DISPLAY '  PROGRAMA .....: RG0805B                        ' . */
            _.Display($"  PROGRAMA .....: RG0805B                        ");

            /*" -326- DISPLAY '  CRIACAO ......: JUL/1992                       ' . */
            _.Display($"  CRIACAO ......: JUL/1992                       ");

            /*" -327- DISPLAY '  ALTERACAO.....: SET/2017                       ' . */
            _.Display($"  ALTERACAO.....: SET/2017                       ");

            /*" -328- DISPLAY '  VERSAO........: 02.00                          ' . */
            _.Display($"  VERSAO........: 02.00                          ");

            /*" -329- DISPLAY '  CATALOGACAO...: ' DATA-CATALOGACAO '   ' . */

            $"  CATALOGACAO...: {WS_DATA_COMPILACAO.DATA_CATALOGACAO}   "
            .Display();

            /*" -331- DISPLAY '----------------------------------------------------------' . */
            _.Display($"----------------------------------------------------------");

            /*" -333- DISPLAY '  ' . */
            _.Display($"  ");

            /*" -335- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -337- PERFORM R0200-00-DELETE-V0RELATORIO. */

            R0200_00_DELETE_V0RELATORIO_SECTION();

            /*" -339- PERFORM R0300-00-MONTA-SOLIC-RELAT. */

            R0300_00_MONTA_SOLIC_RELAT_SECTION();

            /*" -341- PERFORM R0400-00-GRAVA-SOLIC-RELAT. */

            R0400_00_GRAVA_SOLIC_RELAT_SECTION();

            /*" -342- DISPLAY '/////////////////////////////////////////' . */
            _.Display($"/////////////////////////////////////////");

            /*" -343- DISPLAY '/////////////////////////////////////////' . */
            _.Display($"/////////////////////////////////////////");

            /*" -344- DISPLAY '//                                     //' . */
            _.Display($"//                                     //");

            /*" -345- DISPLAY '//     ==>     RG0805B      <==        //' . */
            _.Display($"//     ==>     RG0805B      <==        //");

            /*" -346- DISPLAY '//                                     //' . */
            _.Display($"//                                     //");

            /*" -347- DISPLAY '//     ==>  TERMINO NORMAL  <==        //' . */
            _.Display($"//     ==>  TERMINO NORMAL  <==        //");

            /*" -348- DISPLAY '//                                     //' . */
            _.Display($"//                                     //");

            /*" -349- DISPLAY '// ==> GERACAO OK NA V0RELATORIOS  <== //' . */
            _.Display($"// ==> GERACAO OK NA V0RELATORIOS  <== //");

            /*" -350- DISPLAY '//                                     //' . */
            _.Display($"//                                     //");

            /*" -351- DISPLAY '/////////////////////////////////////////' . */
            _.Display($"/////////////////////////////////////////");

            /*" -353- DISPLAY '/////////////////////////////////////////' . */
            _.Display($"/////////////////////////////////////////");

            /*" -353- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -357- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -357- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -370- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -377- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -380- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -381- DISPLAY 'R0100 - ERRO NO SELECT DA V0SISTEMA' */
                _.Display($"R0100 - ERRO NO SELECT DA V0SISTEMA");

                /*" -382- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -383- ELSE */
            }
            else
            {


                /*" -385- DISPLAY 'DATA DO SISTEMA RG - ' V0SIST-DTMOVABE. */
                _.Display($"DATA DO SISTEMA RG - {V0SIST_DTMOVABE}");
            }


            /*" -387- MOVE V0SIST-DTMOVABE TO WDATA-REF. */
            _.Move(V0SIST_DTMOVABE, AREA_DE_WORK.WDATA_REF);

            /*" -388- MOVE WDAT-REF-ANO TO WREFE-ANO-TER. */
            _.Move(AREA_DE_WORK.WDATA_REF_R.WDAT_REF_ANO, AREA_DE_WORK.WREF_DAT_TER_R.WREFE_ANO_TER);

            /*" -390- MOVE WDAT-REF-MES TO WREFE-MES-TER. */
            _.Move(AREA_DE_WORK.WDATA_REF_R.WDAT_REF_MES, AREA_DE_WORK.WREF_DAT_TER_R.WREFE_MES_TER);

            /*" -391- IF WDAT-REF-MES = 04 OR 06 OR 09 OR 11 */

            if (AREA_DE_WORK.WDATA_REF_R.WDAT_REF_MES.In("04", "06", "09", "11"))
            {

                /*" -392- MOVE 30 TO WREFE-DIA-TER */
                _.Move(30, AREA_DE_WORK.WREF_DAT_TER_R.WREFE_DIA_TER);

                /*" -393- ELSE */
            }
            else
            {


                /*" -394- IF WDAT-REF-MES = 02 */

                if (AREA_DE_WORK.WDATA_REF_R.WDAT_REF_MES == 02)
                {

                    /*" -397- COMPUTE WRESTO = WDAT-REF-ANO - (WDAT-REF-ANO / 4 * 4) */
                    AREA_DE_WORK.WRESTO.Value = AREA_DE_WORK.WDATA_REF_R.WDAT_REF_ANO - (AREA_DE_WORK.WDATA_REF_R.WDAT_REF_ANO / 4 * 4);

                    /*" -398- IF WRESTO = ZEROS */

                    if (AREA_DE_WORK.WRESTO == 00)
                    {

                        /*" -399- MOVE 29 TO WREFE-DIA-TER */
                        _.Move(29, AREA_DE_WORK.WREF_DAT_TER_R.WREFE_DIA_TER);

                        /*" -400- ELSE */
                    }
                    else
                    {


                        /*" -401- MOVE 28 TO WREFE-DIA-TER */
                        _.Move(28, AREA_DE_WORK.WREF_DAT_TER_R.WREFE_DIA_TER);

                        /*" -402- ELSE */
                    }

                }
                else
                {


                    /*" -404- MOVE 31 TO WREFE-DIA-TER. */
                    _.Move(31, AREA_DE_WORK.WREF_DAT_TER_R.WREFE_DIA_TER);
                }

            }


            /*" -405- MOVE WREFE-DATA-TER TO WREFE-DATA-INI. */
            _.Move(AREA_DE_WORK.WREFE_DATA_TER, AREA_DE_WORK.WREFE_DATA_INI);

            /*" -407- MOVE 01 TO WREFE-DIA-INI. */
            _.Move(01, AREA_DE_WORK.WREF_DAT_INI_R.WREFE_DIA_INI);

            /*" -408- MOVE V0SIST-DTCURRENT TO WDATA-CURRENT */
            _.Move(V0SIST_DTCURRENT, AREA_DE_WORK.WDATA_CURRENT);

            /*" -409- MOVE WDATA-CURR-DIA TO WDATA-DIA-SOL */
            _.Move(AREA_DE_WORK.WDATA_CURR_R.WDATA_CURR_DIA, AREA_DE_WORK.WDATA_SOLIC_R.WDATA_DIA_SOL);

            /*" -410- MOVE WDATA-CURR-MES TO WDATA-MES-SOL */
            _.Move(AREA_DE_WORK.WDATA_CURR_R.WDATA_CURR_MES, AREA_DE_WORK.WDATA_SOLIC_R.WDATA_MES_SOL);

            /*" -412- MOVE WDATA-CURR-ANO TO WDATA-ANO-SOL */
            _.Move(AREA_DE_WORK.WDATA_CURR_R.WDATA_CURR_ANO, AREA_DE_WORK.WDATA_SOLIC_R.WDATA_ANO_SOL);

            /*" -417- MOVE '-' TO WREFE-BR1-INI WREFE-BR2-INI WREFE-BR1-TER WREFE-BR2-TER WDATA-BR1-SOL WDATA-BR2-SOL. */
            _.Move("-", AREA_DE_WORK.WREF_DAT_INI_R.WREFE_BR1_INI);
            _.Move("-", AREA_DE_WORK.WREF_DAT_INI_R.WREFE_BR2_INI);
            _.Move("-", AREA_DE_WORK.WREF_DAT_TER_R.WREFE_BR1_TER);
            _.Move("-", AREA_DE_WORK.WREF_DAT_TER_R.WREFE_BR2_TER);
            _.Move("-", AREA_DE_WORK.WDATA_SOLIC_R.WDATA_BR1_SOL);
            _.Move("-", AREA_DE_WORK.WDATA_SOLIC_R.WDATA_BR2_SOL);


        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -377- EXEC SQL SELECT DTMOVABE, CURRENT DATE INTO :V0SIST-DTMOVABE, :V0SIST-DTCURRENT FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'RG' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
                _.Move(executed_1.V0SIST_DTCURRENT, V0SIST_DTCURRENT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0200-00-DELETE-V0RELATORIO-SECTION */
        private void R0200_00_DELETE_V0RELATORIO_SECTION()
        {
            /*" -430- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", WABEND.WNR_EXEC_SQL);

            /*" -434- PERFORM R0200_00_DELETE_V0RELATORIO_DB_DELETE_1 */

            R0200_00_DELETE_V0RELATORIO_DB_DELETE_1();

            /*" -437- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -439- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -440- ELSE */
                }
                else
                {


                    /*" -441- DISPLAY 'R0200 - ERRO NO DELETE DA V0RELATORIOS' */
                    _.Display($"R0200 - ERRO NO DELETE DA V0RELATORIOS");

                    /*" -441- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" R0200-00-DELETE-V0RELATORIO-DB-DELETE-1 */
        public void R0200_00_DELETE_V0RELATORIO_DB_DELETE_1()
        {
            /*" -434- EXEC SQL DELETE FROM SEGUROS.V0RELATORIOS WHERE IDSISTEM = 'RG' AND CODUSU = 'RG0805B' END-EXEC. */

            var r0200_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1 = new R0200_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1()
            {
            };

            R0200_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1.Execute(r0200_00_DELETE_V0RELATORIO_DB_DELETE_1_Delete1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0200_99_SAIDA*/

        [StopWatch]
        /*" R0300-00-MONTA-SOLIC-RELAT-SECTION */
        private void R0300_00_MONTA_SOLIC_RELAT_SECTION()
        {
            /*" -454- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", WABEND.WNR_EXEC_SQL);

            /*" -455- MOVE 'RG0805B ' TO V0RELA-CODUSU. */
            _.Move("RG0805B ", V0RELA_CODUSU);

            /*" -456- MOVE WREFE-DATA-TER TO V0RELA-DT-SOLIC. */
            _.Move(AREA_DE_WORK.WREFE_DATA_TER, V0RELA_DT_SOLIC);

            /*" -458- MOVE SPACES TO V0RELA-IDSISTEM. */
            _.Move("", V0RELA_IDSISTEM);

            /*" -461- MOVE ZEROS TO V0RELA-NRCOPIAS V0RELA-QTDE. */
            _.Move(0, V0RELA_NRCOPIAS, V0RELA_QTDE);

            /*" -463- MOVE WREFE-DATA-INI TO V0RELA-PERI-INIC. */
            _.Move(AREA_DE_WORK.WREFE_DATA_INI, V0RELA_PERI_INIC);

            /*" -466- MOVE WREFE-DATA-TER TO V0RELA-PERI-FINAL V0RELA-DATA-REFER. */
            _.Move(AREA_DE_WORK.WREFE_DATA_TER, V0RELA_PERI_FINAL, V0RELA_DATA_REFER);

            /*" -467- MOVE WDAT-REF-MES TO V0RELA-MES-REFER. */
            _.Move(AREA_DE_WORK.WDATA_REF_R.WDAT_REF_MES, V0RELA_MES_REFER);

            /*" -469- MOVE WDAT-REF-ANO TO V0RELA-ANO-REFER. */
            _.Move(AREA_DE_WORK.WDATA_REF_R.WDAT_REF_ANO, V0RELA_ANO_REFER);

            /*" -485- MOVE ZEROS TO V0RELA-ORGAO V0RELA-FONTE V0RELA-CODPDT V0RELA-RAMO V0RELA-MODALID V0RELA-CONGENER V0RELA-NUM-APOL V0RELA-NRENDOS V0RELA-NRPARCEL V0RELA-NRCERTIF V0RELA-NRTIT V0RELA-CODSUBES V0RELA-OPERACAO V0RELA-COD-PLANO V0RELA-OCORHIST. */
            _.Move(0, V0RELA_ORGAO, V0RELA_FONTE, V0RELA_CODPDT, V0RELA_RAMO, V0RELA_MODALID, V0RELA_CONGENER, V0RELA_NUM_APOL, V0RELA_NRENDOS, V0RELA_NRPARCEL, V0RELA_NRCERTIF, V0RELA_NRTIT, V0RELA_CODSUBES, V0RELA_OPERACAO, V0RELA_COD_PLANO, V0RELA_OCORHIST);

            /*" -488- MOVE SPACES TO V0RELA-APOL-LIDER V0RELA-ENDS-LIDER. */
            _.Move("", V0RELA_APOL_LIDER, V0RELA_ENDS_LIDER);

            /*" -491- MOVE ZEROS TO V0RELA-NRPARC-LID V0RELA-NUM-SINIST. */
            _.Move(0, V0RELA_NRPARC_LID, V0RELA_NUM_SINIST);

            /*" -493- MOVE SPACES TO V0RELA-NSINI-LID. */
            _.Move("", V0RELA_NSINI_LID);

            /*" -496- MOVE ZEROS TO V0RELA-NUM-ORDEM V0RELA-CODUNIMO. */
            _.Move(0, V0RELA_NUM_ORDEM, V0RELA_CODUNIMO);

            /*" -497- MOVE SPACES TO V0RELA-CORRECAO. */
            _.Move("", V0RELA_CORRECAO);

            /*" -498- MOVE '0' TO V0RELA-SITUACAO. */
            _.Move("0", V0RELA_SITUACAO);

            /*" -499- MOVE 'D' TO V0RELA-PRV-DEF. */
            _.Move("D", V0RELA_PRV_DEF);

            /*" -501- MOVE 'A' TO V0RELA-ANAL-RESU. */
            _.Move("A", V0RELA_ANAL_RESU);

            /*" -505- MOVE ZEROS TO V0RELA-COD-EMPR V0RELA-PERI-RENOV V0RELA-PCT-AUMENTO. */
            _.Move(0, V0RELA_COD_EMPR, V0RELA_PERI_RENOV, V0RELA_PCT_AUMENTO);

            /*" -507- MOVE -1 TO VIND-COD-EMPR VIND-PERI-RENOV VIND-PCT-AUMENTO. */
            _.Move(-1, VIND_COD_EMPR, VIND_PERI_RENOV, VIND_PCT_AUMENTO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0300_99_SAIDA*/

        [StopWatch]
        /*" R0400-00-GRAVA-SOLIC-RELAT-SECTION */
        private void R0400_00_GRAVA_SOLIC_RELAT_SECTION()
        {
            /*" -530- MOVE '040' TO WNR-EXEC-SQL. */
            _.Move("040", WABEND.WNR_EXEC_SQL);

            /*" -531- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -532- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -533- MOVE 'RG0051B1' TO V0RELA-CODRELAT. */
            _.Move("RG0051B1", V0RELA_CODRELAT);

            /*" -535- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -536- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -537- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -538- MOVE 'RG0052B1' TO V0RELA-CODRELAT. */
            _.Move("RG0052B1", V0RELA_CODRELAT);

            /*" -540- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -541- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -542- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -543- MOVE 'RG0053B1' TO V0RELA-CODRELAT. */
            _.Move("RG0053B1", V0RELA_CODRELAT);

            /*" -545- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -546- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -547- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -548- MOVE 'RG0054B1' TO V0RELA-CODRELAT. */
            _.Move("RG0054B1", V0RELA_CODRELAT);

            /*" -550- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -551- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -552- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -553- MOVE 'RG0055B1' TO V0RELA-CODRELAT. */
            _.Move("RG0055B1", V0RELA_CODRELAT);

            /*" -555- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -556- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -557- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -558- MOVE 'RG0056B1' TO V0RELA-CODRELAT. */
            _.Move("RG0056B1", V0RELA_CODRELAT);

            /*" -565- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -566- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -567- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -568- MOVE 'RG0062B1' TO V0RELA-CODRELAT. */
            _.Move("RG0062B1", V0RELA_CODRELAT);

            /*" -570- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -571- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -572- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -573- MOVE 'RG0063B1' TO V0RELA-CODRELAT. */
            _.Move("RG0063B1", V0RELA_CODRELAT);

            /*" -575- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -576- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -577- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -578- MOVE 'RG0064B1' TO V0RELA-CODRELAT. */
            _.Move("RG0064B1", V0RELA_CODRELAT);

            /*" -585- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -586- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -587- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -588- MOVE 'RG0401B1' TO V0RELA-CODRELAT. */
            _.Move("RG0401B1", V0RELA_CODRELAT);

            /*" -590- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -591- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -592- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -593- MOVE 'RG0403B1' TO V0RELA-CODRELAT. */
            _.Move("RG0403B1", V0RELA_CODRELAT);

            /*" -595- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -596- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -597- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -598- MOVE 'RG0406B1' TO V0RELA-CODRELAT. */
            _.Move("RG0406B1", V0RELA_CODRELAT);

            /*" -600- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -601- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -602- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -603- MOVE 'RG0409B1' TO V0RELA-CODRELAT. */
            _.Move("RG0409B1", V0RELA_CODRELAT);

            /*" -605- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -606- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -607- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -608- MOVE 'RG0222B1' TO V0RELA-CODRELAT. */
            _.Move("RG0222B1", V0RELA_CODRELAT);

            /*" -610- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -611- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -612- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -613- MOVE 'RG0422B1' TO V0RELA-CODRELAT. */
            _.Move("RG0422B1", V0RELA_CODRELAT);

            /*" -615- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -616- MOVE 'RG' TO V0RELA-IDSISTEM. */
            _.Move("RG", V0RELA_IDSISTEM);

            /*" -617- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -618- MOVE 'RG0522B1' TO V0RELA-CODRELAT. */
            _.Move("RG0522B1", V0RELA_CODRELAT);

            /*" -620- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -621- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -622- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -623- MOVE 'SI0029B' TO V0RELA-CODRELAT. */
            _.Move("SI0029B", V0RELA_CODRELAT);

            /*" -625- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -626- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -627- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -628- MOVE 'SI0165B' TO V0RELA-CODRELAT. */
            _.Move("SI0165B", V0RELA_CODRELAT);

            /*" -630- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -631- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -632- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -633- MOVE 'SI0166B' TO V0RELA-CODRELAT. */
            _.Move("SI0166B", V0RELA_CODRELAT);

            /*" -635- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -636- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -637- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -638- MOVE 'SI0167B' TO V0RELA-CODRELAT. */
            _.Move("SI0167B", V0RELA_CODRELAT);

            /*" -640- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -641- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -642- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -643- MOVE 'SI0215B' TO V0RELA-CODRELAT. */
            _.Move("SI0215B", V0RELA_CODRELAT);

            /*" -645- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -646- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -647- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -648- MOVE 'SI0300B' TO V0RELA-CODRELAT. */
            _.Move("SI0300B", V0RELA_CODRELAT);

            /*" -650- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -651- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -652- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -653- MOVE 'SI0854B' TO V0RELA-CODRELAT. */
            _.Move("SI0854B", V0RELA_CODRELAT);

            /*" -655- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -656- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -657- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -658- MOVE 'SI0871B' TO V0RELA-CODRELAT. */
            _.Move("SI0871B", V0RELA_CODRELAT);

            /*" -660- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -661- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -662- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -664- MOVE 'SI0879B' TO V0RELA-CODRELAT. */
            _.Move("SI0879B", V0RELA_CODRELAT);

            /*" -666- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -667- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -668- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -669- MOVE 'SI0897B' TO V0RELA-CODRELAT. */
            _.Move("SI0897B", V0RELA_CODRELAT);

            /*" -671- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

            /*" -672- MOVE 'SI' TO V0RELA-IDSISTEM. */
            _.Move("SI", V0RELA_IDSISTEM);

            /*" -673- MOVE ZEROS TO V0RELA-ORGAO. */
            _.Move(0, V0RELA_ORGAO);

            /*" -674- MOVE 'SI0898B' TO V0RELA-CODRELAT. */
            _.Move("SI0898B", V0RELA_CODRELAT);

            /*" -674- PERFORM R0500-00-INSERT-V0RELATORIO. */

            R0500_00_INSERT_V0RELATORIO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0400_99_SAIDA*/

        [StopWatch]
        /*" R0500-00-INSERT-V0RELATORIO-SECTION */
        private void R0500_00_INSERT_V0RELATORIO_SECTION()
        {
            /*" -687- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", WABEND.WNR_EXEC_SQL);

            /*" -730- PERFORM R0500_00_INSERT_V0RELATORIO_DB_INSERT_1 */

            R0500_00_INSERT_V0RELATORIO_DB_INSERT_1();

            /*" -733- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -734- DISPLAY 'R0500-00- (ERRO INSERT NA V0RELATORIOS)' */
                _.Display($"R0500-00- (ERRO INSERT NA V0RELATORIOS)");

                /*" -734- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R0500-00-INSERT-V0RELATORIO-DB-INSERT-1 */
        public void R0500_00_INSERT_V0RELATORIO_DB_INSERT_1()
        {
            /*" -730- EXEC SQL INSERT INTO SEGUROS.V0RELATORIOS VALUES (:V0RELA-CODUSU , :V0RELA-DT-SOLIC , :V0RELA-IDSISTEM , :V0RELA-CODRELAT , :V0RELA-NRCOPIAS , :V0RELA-QTDE , :V0RELA-PERI-INIC , :V0RELA-PERI-FINAL , :V0RELA-DATA-REFER , :V0RELA-MES-REFER , :V0RELA-ANO-REFER , :V0RELA-ORGAO , :V0RELA-FONTE , :V0RELA-CODPDT , :V0RELA-RAMO , :V0RELA-MODALID , :V0RELA-CONGENER , :V0RELA-NUM-APOL , :V0RELA-NRENDOS , :V0RELA-NRPARCEL , :V0RELA-NRCERTIF , :V0RELA-NRTIT , :V0RELA-CODSUBES , :V0RELA-OPERACAO , :V0RELA-COD-PLANO , :V0RELA-OCORHIST , :V0RELA-APOL-LIDER , :V0RELA-ENDS-LIDER , :V0RELA-NRPARC-LID , :V0RELA-NUM-SINIST , :V0RELA-NSINI-LID , :V0RELA-NUM-ORDEM , :V0RELA-CODUNIMO , :V0RELA-CORRECAO , :V0RELA-SITUACAO , :V0RELA-PRV-DEF , :V0RELA-ANAL-RESU , :V0RELA-COD-EMPR:VIND-COD-EMPR , :V0RELA-PERI-RENOV:VIND-PERI-RENOV , :V0RELA-PCT-AUMENTO:VIND-PCT-AUMENTO, CURRENT TIMESTAMP) END-EXEC. */

            var r0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1 = new R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1()
            {
                V0RELA_CODUSU = V0RELA_CODUSU.ToString(),
                V0RELA_DT_SOLIC = V0RELA_DT_SOLIC.ToString(),
                V0RELA_IDSISTEM = V0RELA_IDSISTEM.ToString(),
                V0RELA_CODRELAT = V0RELA_CODRELAT.ToString(),
                V0RELA_NRCOPIAS = V0RELA_NRCOPIAS.ToString(),
                V0RELA_QTDE = V0RELA_QTDE.ToString(),
                V0RELA_PERI_INIC = V0RELA_PERI_INIC.ToString(),
                V0RELA_PERI_FINAL = V0RELA_PERI_FINAL.ToString(),
                V0RELA_DATA_REFER = V0RELA_DATA_REFER.ToString(),
                V0RELA_MES_REFER = V0RELA_MES_REFER.ToString(),
                V0RELA_ANO_REFER = V0RELA_ANO_REFER.ToString(),
                V0RELA_ORGAO = V0RELA_ORGAO.ToString(),
                V0RELA_FONTE = V0RELA_FONTE.ToString(),
                V0RELA_CODPDT = V0RELA_CODPDT.ToString(),
                V0RELA_RAMO = V0RELA_RAMO.ToString(),
                V0RELA_MODALID = V0RELA_MODALID.ToString(),
                V0RELA_CONGENER = V0RELA_CONGENER.ToString(),
                V0RELA_NUM_APOL = V0RELA_NUM_APOL.ToString(),
                V0RELA_NRENDOS = V0RELA_NRENDOS.ToString(),
                V0RELA_NRPARCEL = V0RELA_NRPARCEL.ToString(),
                V0RELA_NRCERTIF = V0RELA_NRCERTIF.ToString(),
                V0RELA_NRTIT = V0RELA_NRTIT.ToString(),
                V0RELA_CODSUBES = V0RELA_CODSUBES.ToString(),
                V0RELA_OPERACAO = V0RELA_OPERACAO.ToString(),
                V0RELA_COD_PLANO = V0RELA_COD_PLANO.ToString(),
                V0RELA_OCORHIST = V0RELA_OCORHIST.ToString(),
                V0RELA_APOL_LIDER = V0RELA_APOL_LIDER.ToString(),
                V0RELA_ENDS_LIDER = V0RELA_ENDS_LIDER.ToString(),
                V0RELA_NRPARC_LID = V0RELA_NRPARC_LID.ToString(),
                V0RELA_NUM_SINIST = V0RELA_NUM_SINIST.ToString(),
                V0RELA_NSINI_LID = V0RELA_NSINI_LID.ToString(),
                V0RELA_NUM_ORDEM = V0RELA_NUM_ORDEM.ToString(),
                V0RELA_CODUNIMO = V0RELA_CODUNIMO.ToString(),
                V0RELA_CORRECAO = V0RELA_CORRECAO.ToString(),
                V0RELA_SITUACAO = V0RELA_SITUACAO.ToString(),
                V0RELA_PRV_DEF = V0RELA_PRV_DEF.ToString(),
                V0RELA_ANAL_RESU = V0RELA_ANAL_RESU.ToString(),
                V0RELA_COD_EMPR = V0RELA_COD_EMPR.ToString(),
                VIND_COD_EMPR = VIND_COD_EMPR.ToString(),
                V0RELA_PERI_RENOV = V0RELA_PERI_RENOV.ToString(),
                VIND_PERI_RENOV = VIND_PERI_RENOV.ToString(),
                V0RELA_PCT_AUMENTO = V0RELA_PCT_AUMENTO.ToString(),
                VIND_PCT_AUMENTO = VIND_PCT_AUMENTO.ToString(),
            };

            R0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1.Execute(r0500_00_INSERT_V0RELATORIO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0500_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -749- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -751- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -751- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -755- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -755- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}