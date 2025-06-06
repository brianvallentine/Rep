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
using Sias.Bilhetes.DB2.BI0003S;

namespace Code
{
    public class BI0003S
    {
        public bool IsCall { get; set; }

        public BI0003S()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *-------------------------                                              */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  BI - BILHETES                      *      */
        /*"      *   PROGRAMA ...............  BI0003S.                           *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  CANETTA                            *      */
        /*"      *   PROGRAMADOR ............  CANETTA                            *      */
        /*"      *   DATA CODIFICACAO .......  04/2024                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"      *   FUNCAO .................  MANUTENCAO NAS BASES DE PESSOA     *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      * ALTERACOES                                                     *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.01  * VERSAO 01 EM 05/07/24  JAZZ 575149                             *      */
        /*"      *        CORRECAO IDENTIDADE/ORG-EXP/UF EXP/DATA EXP             *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.00                        CANETTA             *      */
        /*"      *                                                                *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        /*"V.00  * VERSAO XX EM XX/XXXX - JAZZ XXXXXX                             *      */
        /*"      *   XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX *      */
        /*"      *                                                                *      */
        /*"      *   PROCURAR POR V.00                        XXXXXXX             *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        #endregion


        #region VARIABLES

        /*"01           WS-WORKING.*/
        public BI0003S_WS_WORKING WS_WORKING { get; set; } = new BI0003S_WS_WORKING();
        public class BI0003S_WS_WORKING : VarBasis
        {
            /*"  03         WS-AUXILIARES.*/
            public BI0003S_WS_AUXILIARES WS_AUXILIARES { get; set; } = new BI0003S_WS_AUXILIARES();
            public class BI0003S_WS_AUXILIARES : VarBasis
            {
                /*"    05       WS-SQLCODE         PIC   ---9.*/
                public IntBasis WS_SQLCODE { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"    05       WS-COD-PES-ATU     PIC S9(009) COMP-3  VALUE +0.*/
                public IntBasis WS_COD_PES_ATU { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"    05       WS-MAX-SEQ-EMA     PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis WS_MAX_SEQ_EMA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-MAX-SEQ-TEL     PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis WS_MAX_SEQ_TEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       WS-MAX-OCO-END     PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis WS_MAX_OCO_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       IND-TEL            PIC S9(003) COMP-3  VALUE +0.*/
                public IntBasis IND_TEL { get; set; } = new IntBasis(new PIC("S9", "3", "S9(003)"));
                /*"    05       VIND-NULL01        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL01 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-NULL02        PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_NULL02 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-DTEXPEDI      PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_DTEXPEDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"    05       VIND-UNEXPEDI      PIC S9(004)    VALUE +0 COMP.*/
                public IntBasis VIND_UNEXPEDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  03         NIVEIS-88.*/
            }
            public BI0003S_NIVEIS_88 NIVEIS_88 { get; set; } = new BI0003S_NIVEIS_88();
            public class BI0003S_NIVEIS_88 : VarBasis
            {
                /*"    05       N88-CADASTRO-PESS  PIC  X(001)    VALUE '&'.*/

                public SelectorBasis N88_CADASTRO_PESS { get; set; } = new SelectorBasis("001", "&")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88     PESSOA-CADASTRADA                 VALUE 'S'. */
							new SelectorItemBasis("PESSOA_CADASTRADA", "S")
                }
                };

                /*"01     BI0003L-LINKAGE.*/
            }
        }
        public BI0003S_BI0003L_LINKAGE BI0003L_LINKAGE { get; set; } = new BI0003S_BI0003L_LINKAGE();
        public class BI0003S_BI0003L_LINKAGE : VarBasis
        {
            /*" 03    BI0003L-E-CONTROLE.*/
            public BI0003S_BI0003L_E_CONTROLE BI0003L_E_CONTROLE { get; set; } = new BI0003S_BI0003L_E_CONTROLE();
            public class BI0003S_BI0003L_E_CONTROLE : VarBasis
            {
                /*"  05   BI0003L-E-COD-USU      PIC  X(008)         VALUE ZEROS.*/
                public StringBasis BI0003L_E_COD_USU { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
                /*"  05   BI0003L-E-DAT-SIS      PIC  X(010)         VALUE ZEROS.*/
                public StringBasis BI0003L_E_DAT_SIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
                /*" 03    BI0003L-E-PESSOA.*/
            }
            public BI0003S_BI0003L_E_PESSOA BI0003L_E_PESSOA { get; set; } = new BI0003S_BI0003L_E_PESSOA();
            public class BI0003S_BI0003L_E_PESSOA : VarBasis
            {
                /*"  05   BI0003L-E-NOM-PES        PIC  X(040).*/
                public StringBasis BI0003L_E_NOM_PES { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05   BI0003L-E-TIP-PES        PIC S9(001) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_TIP_PES { get; set; } = new IntBasis(new PIC("S9", "1", "S9(001)"));
                /*" 03    BI0003L-E-FISICA.*/
            }
            public BI0003S_BI0003L_E_FISICA BI0003L_E_FISICA { get; set; } = new BI0003S_BI0003L_E_FISICA();
            public class BI0003S_BI0003L_E_FISICA : VarBasis
            {
                /*"  05   BI0003L-E-NUM-CPF        PIC S9(011) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_NUM_CPF { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
                /*"  05   BI0003L-E-DAT-NAS        PIC  X(010).*/
                public StringBasis BI0003L_E_DAT_NAS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  05   BI0003L-E-SEX            PIC  X(001).*/
                public StringBasis BI0003L_E_SEX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05   BI0003L-E-EST-CIV        PIC  X(001).*/
                public StringBasis BI0003L_E_EST_CIV { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"  05   BI0003L-E-NUM-IDE        PIC  X(015).*/
                public StringBasis BI0003L_E_NUM_IDE { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"  05   BI0003L-E-ORG-EXP        PIC  X(005).*/
                public StringBasis BI0003L_E_ORG_EXP { get; set; } = new StringBasis(new PIC("X", "5", "X(005)."), @"");
                /*"  05   BI0003L-E-UF-EXP         PIC  X(002).*/
                public StringBasis BI0003L_E_UF_EXP { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"  05   BI0003L-E-DAT-EXP        PIC  X(010).*/
                public StringBasis BI0003L_E_DAT_EXP { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"  05   BI0003L-E-COD-CBO        PIC S9(009) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_COD_CBO { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*" 03    BI0003L-E-JURIDICA.*/
            }
            public BI0003S_BI0003L_E_JURIDICA BI0003L_E_JURIDICA { get; set; } = new BI0003S_BI0003L_E_JURIDICA();
            public class BI0003S_BI0003L_E_JURIDICA : VarBasis
            {
                /*"  05   BI0003L-E-NUM-CGC        PIC S9(015) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_NUM_CGC { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
                /*"  05   BI0003L-E-NOM-FAN        PIC  X(040).*/
                public StringBasis BI0003L_E_NOM_FAN { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*" 03    BI0003L-E-TELEFONE       OCCURS    003       TIMES.*/
            }
            public ListBasis<BI0003S_BI0003L_E_TELEFONE> BI0003L_E_TELEFONE { get; set; } = new ListBasis<BI0003S_BI0003L_E_TELEFONE>(003);
            public class BI0003S_BI0003L_E_TELEFONE : VarBasis
            {
                /*"  05   BI0003L-E-DDI            PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_DDI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05   BI0003L-E-DDD            PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05   BI0003L-E-NUM-FON        PIC S9(011) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_NUM_FON { get; set; } = new IntBasis(new PIC("S9", "11", "S9(011)"));
                /*"  05   BI0003L-E-SIT-FON        PIC  X(001).*/
                public StringBasis BI0003L_E_SIT_FON { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*" 03    BI0003L-E-EMAIL.*/
            }
            public BI0003S_BI0003L_E_EMAIL BI0003L_E_EMAIL { get; set; } = new BI0003S_BI0003L_E_EMAIL();
            public class BI0003S_BI0003L_E_EMAIL : VarBasis
            {
                /*"  05   BI0003L-E-LIT-EMA        PIC  X(040).*/
                public StringBasis BI0003L_E_LIT_EMA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05   BI0003L-E-SIT-EMA        PIC  X(001).*/
                public StringBasis BI0003L_E_SIT_EMA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*" 03    BI0003L-E-ENDERECO-FIS.*/
            }
            public BI0003S_BI0003L_E_ENDERECO_FIS BI0003L_E_ENDERECO_FIS { get; set; } = new BI0003S_BI0003L_E_ENDERECO_FIS();
            public class BI0003S_BI0003L_E_ENDERECO_FIS : VarBasis
            {
                /*"  05   BI0003L-E-LIT-END-F      PIC  X(040).*/
                public StringBasis BI0003L_E_LIT_END_F { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05   BI0003L-E-COM-END-F      PIC  X(015).*/
                public StringBasis BI0003L_E_COM_END_F { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"  05   BI0003L-E-LIT-BAI-F      PIC  X(020).*/
                public StringBasis BI0003L_E_LIT_BAI_F { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"  05   BI0003L-E-COD-CEP-F      PIC S9(009) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_COD_CEP_F { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"  05   BI0003L-E-LIT-CID-F      PIC  X(020).*/
                public StringBasis BI0003L_E_LIT_CID_F { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"  05   BI0003L-E-SIG-UF-F       PIC  X(002).*/
                public StringBasis BI0003L_E_SIG_UF_F { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*" 03    BI0003L-E-ENDERECO-JUR.*/
            }
            public BI0003S_BI0003L_E_ENDERECO_JUR BI0003L_E_ENDERECO_JUR { get; set; } = new BI0003S_BI0003L_E_ENDERECO_JUR();
            public class BI0003S_BI0003L_E_ENDERECO_JUR : VarBasis
            {
                /*"  05   BI0003L-E-LIT-END-J      PIC  X(040).*/
                public StringBasis BI0003L_E_LIT_END_J { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"  05   BI0003L-E-COM-END-J      PIC  X(015).*/
                public StringBasis BI0003L_E_COM_END_J { get; set; } = new StringBasis(new PIC("X", "15", "X(015)."), @"");
                /*"  05   BI0003L-E-LIT-BAI-J      PIC  X(020).*/
                public StringBasis BI0003L_E_LIT_BAI_J { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"  05   BI0003L-E-COD-CEP-J      PIC S9(009) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_E_COD_CEP_J { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"  05   BI0003L-E-LIT-CID-J      PIC  X(020).*/
                public StringBasis BI0003L_E_LIT_CID_J { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"  05   BI0003L-E-SIG-UF-J       PIC  X(002).*/
                public StringBasis BI0003L_E_SIG_UF_J { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*" 03    BI0003L-SAIDA.*/
            }
            public BI0003S_BI0003L_SAIDA BI0003L_SAIDA { get; set; } = new BI0003S_BI0003L_SAIDA();
            public class BI0003S_BI0003L_SAIDA : VarBasis
            {
                /*"  05   BI0003L-S-COD-ERR        PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_S_COD_ERR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
                /*"  05   BI0003L-S-COD-SQL        PIC   ---9.*/
                public IntBasis BI0003L_S_COD_SQL { get; set; } = new IntBasis(new PIC("9", "4", "---9."));
                /*"  05   BI0003L-S-LIT-ERR        PIC  X(030).*/
                public StringBasis BI0003L_S_LIT_ERR { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"  05   BI0003L-S-COD-PES        PIC S9(009) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_S_COD_PES { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
                /*"  05   BI0003L-S-OCO-END        PIC S9(004) COMP-3  VALUE +0.*/
                public IntBasis BI0003L_S_OCO_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.PESSOA PESSOA { get; set; } = new Dclgens.PESSOA();
        public Dclgens.PESFIS PESFIS { get; set; } = new Dclgens.PESFIS();
        public Dclgens.PESJUR PESJUR { get; set; } = new Dclgens.PESJUR();
        public Dclgens.PESENDER PESENDER { get; set; } = new Dclgens.PESENDER();
        public Dclgens.PESEMAIL PESEMAIL { get; set; } = new Dclgens.PESEMAIL();
        public Dclgens.PESFONE PESFONE { get; set; } = new Dclgens.PESFONE();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(BI0003S_BI0003L_LINKAGE BI0003S_BI0003L_LINKAGE_P) //PROCEDURE DIVISION USING 
        /*BI0003L_LINKAGE*/
        {
            try
            {
                this.BI0003L_LINKAGE = BI0003S_BI0003L_LINKAGE_P;

                /*" -0- FLUXCONTROL_PERFORM M-0000-00-BI0003S-SECTION */

                M_0000_00_BI0003S_SECTION();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { BI0003L_LINKAGE };
            return Result;
        }

        [StopWatch]
        /*" M-0000-00-BI0003S-SECTION */
        private void M_0000_00_BI0003S_SECTION()
        {
            /*" -171- DISPLAY '0000-00-BI0003S        ' */
            _.Display($"0000-00-BI0003S        ");

            /*" -172- DISPLAY '***' */
            _.Display($"***");

            /*" -173- DISPLAY 'BI0003L-E-COD-USU  : ' BI0003L-E-COD-USU */
            _.Display($"BI0003L-E-COD-USU  : {BI0003L_LINKAGE.BI0003L_E_CONTROLE.BI0003L_E_COD_USU}");

            /*" -174- DISPLAY 'BI0003L-E-DAT-SIS  : ' BI0003L-E-DAT-SIS */
            _.Display($"BI0003L-E-DAT-SIS  : {BI0003L_LINKAGE.BI0003L_E_CONTROLE.BI0003L_E_DAT_SIS}");

            /*" -175- DISPLAY 'BI0003L-E-NOM-PES  : ' BI0003L-E-NOM-PES */
            _.Display($"BI0003L-E-NOM-PES  : {BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_NOM_PES}");

            /*" -176- DISPLAY 'BI0003L-E-TIP-PES  : ' BI0003L-E-TIP-PES */
            _.Display($"BI0003L-E-TIP-PES  : {BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_TIP_PES}");

            /*" -177- DISPLAY 'BI0003L-E-NUM-CPF  : ' BI0003L-E-NUM-CPF */
            _.Display($"BI0003L-E-NUM-CPF  : {BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_NUM_CPF}");

            /*" -178- DISPLAY 'BI0003L-E-DAT-NAS  : ' BI0003L-E-DAT-NAS */
            _.Display($"BI0003L-E-DAT-NAS  : {BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_DAT_NAS}");

            /*" -179- DISPLAY 'BI0003L-E-SEX      : ' BI0003L-E-SEX */
            _.Display($"BI0003L-E-SEX      : {BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_SEX}");

            /*" -180- DISPLAY 'BI0003L-E-EST-CIV  : ' BI0003L-E-EST-CIV */
            _.Display($"BI0003L-E-EST-CIV  : {BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_EST_CIV}");

            /*" -181- DISPLAY 'BI0003L-E-NUM-IDE  : ' BI0003L-E-NUM-IDE */
            _.Display($"BI0003L-E-NUM-IDE  : {BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_NUM_IDE}");

            /*" -182- DISPLAY 'BI0003L-E-ORG-EXP  : ' BI0003L-E-ORG-EXP */
            _.Display($"BI0003L-E-ORG-EXP  : {BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_ORG_EXP}");

            /*" -183- DISPLAY 'BI0003L-E-UF-EXP   : ' BI0003L-E-UF-EXP */
            _.Display($"BI0003L-E-UF-EXP   : {BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_UF_EXP}");

            /*" -184- DISPLAY 'BI0003L-E-DAT-EXP  : ' BI0003L-E-DAT-EXP */
            _.Display($"BI0003L-E-DAT-EXP  : {BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_DAT_EXP}");

            /*" -185- DISPLAY 'BI0003L-E-COD-CBO  : ' BI0003L-E-COD-CBO */
            _.Display($"BI0003L-E-COD-CBO  : {BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_COD_CBO}");

            /*" -186- DISPLAY 'BI0003L-E-NUM-CGC  : ' BI0003L-E-NUM-CGC */
            _.Display($"BI0003L-E-NUM-CGC  : {BI0003L_LINKAGE.BI0003L_E_JURIDICA.BI0003L_E_NUM_CGC}");

            /*" -189- DISPLAY 'BI0003L-E-NOM-FAN  : ' BI0003L-E-NOM-FAN */
            _.Display($"BI0003L-E-NOM-FAN  : {BI0003L_LINKAGE.BI0003L_E_JURIDICA.BI0003L_E_NOM_FAN}");

            /*" -190- DISPLAY 'BI0003L-E-DDI(1)   : ' BI0003L-E-DDI(1) */
            _.Display($"BI0003L-E-DDI(1)   : {BI0003L_LINKAGE.BI0003L_E_TELEFONE[1]}");

            /*" -191- DISPLAY 'BI0003L-E-DDD(1)   : ' BI0003L-E-DDD(1) */
            _.Display($"BI0003L-E-DDD(1)   : {BI0003L_LINKAGE.BI0003L_E_TELEFONE[1]}");

            /*" -192- DISPLAY 'BI0003L-E-NUM-FON(1) ' BI0003L-E-NUM-FON(1) */
            _.Display($"BI0003L-E-NUM-FON(1) {BI0003L_LINKAGE.BI0003L_E_TELEFONE[1]}");

            /*" -196- DISPLAY 'BI0003L-E-SIT-FON(1) ' BI0003L-E-SIT-FON(1) */
            _.Display($"BI0003L-E-SIT-FON(1) {BI0003L_LINKAGE.BI0003L_E_TELEFONE[1]}");

            /*" -197- DISPLAY 'BI0003L-E-DDI(2)   : ' BI0003L-E-DDI(2) */
            _.Display($"BI0003L-E-DDI(2)   : {BI0003L_LINKAGE.BI0003L_E_TELEFONE[2]}");

            /*" -198- DISPLAY 'BI0003L-E-DDD(2)   : ' BI0003L-E-DDD(2) */
            _.Display($"BI0003L-E-DDD(2)   : {BI0003L_LINKAGE.BI0003L_E_TELEFONE[2]}");

            /*" -199- DISPLAY 'BI0003L-E-NUM-FON(2) ' BI0003L-E-NUM-FON(2) */
            _.Display($"BI0003L-E-NUM-FON(2) {BI0003L_LINKAGE.BI0003L_E_TELEFONE[2]}");

            /*" -203- DISPLAY 'BI0003L-E-SIT-FON(2) ' BI0003L-E-SIT-FON(2) */
            _.Display($"BI0003L-E-SIT-FON(2) {BI0003L_LINKAGE.BI0003L_E_TELEFONE[2]}");

            /*" -204- DISPLAY 'BI0003L-E-DDI(3)   : ' BI0003L-E-DDI(3) */
            _.Display($"BI0003L-E-DDI(3)   : {BI0003L_LINKAGE.BI0003L_E_TELEFONE[3]}");

            /*" -205- DISPLAY 'BI0003L-E-DDD(3)   : ' BI0003L-E-DDD(3) */
            _.Display($"BI0003L-E-DDD(3)   : {BI0003L_LINKAGE.BI0003L_E_TELEFONE[3]}");

            /*" -206- DISPLAY 'BI0003L-E-NUM-FON(3) ' BI0003L-E-NUM-FON(3) */
            _.Display($"BI0003L-E-NUM-FON(3) {BI0003L_LINKAGE.BI0003L_E_TELEFONE[3]}");

            /*" -208- DISPLAY 'BI0003L-E-SIT-FON(3) ' BI0003L-E-SIT-FON(3) */
            _.Display($"BI0003L-E-SIT-FON(3) {BI0003L_LINKAGE.BI0003L_E_TELEFONE[3]}");

            /*" -209- DISPLAY 'BI0003L-E-LIT-EMA  : ' BI0003L-E-LIT-EMA */
            _.Display($"BI0003L-E-LIT-EMA  : {BI0003L_LINKAGE.BI0003L_E_EMAIL.BI0003L_E_LIT_EMA}");

            /*" -210- DISPLAY 'BI0003L-E-SIT-EMA  : ' BI0003L-E-SIT-EMA */
            _.Display($"BI0003L-E-SIT-EMA  : {BI0003L_LINKAGE.BI0003L_E_EMAIL.BI0003L_E_SIT_EMA}");

            /*" -211- DISPLAY 'BI0003L-E-LIT-END-F: ' BI0003L-E-LIT-END-F */
            _.Display($"BI0003L-E-LIT-END-F: {BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_LIT_END_F}");

            /*" -212- DISPLAY 'BI0003L-E-COM-END-F: ' BI0003L-E-COM-END-F */
            _.Display($"BI0003L-E-COM-END-F: {BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_COM_END_F}");

            /*" -213- DISPLAY 'BI0003L-E-LIT-BAI-F: ' BI0003L-E-LIT-BAI-F */
            _.Display($"BI0003L-E-LIT-BAI-F: {BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_LIT_BAI_F}");

            /*" -214- DISPLAY 'BI0003L-E-COD-CEP-F: ' BI0003L-E-COD-CEP-F */
            _.Display($"BI0003L-E-COD-CEP-F: {BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_COD_CEP_F}");

            /*" -215- DISPLAY 'BI0003L-E-LIT-CID-F: ' BI0003L-E-LIT-CID-F */
            _.Display($"BI0003L-E-LIT-CID-F: {BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_LIT_CID_F}");

            /*" -216- DISPLAY 'BI0003L-E-SIG-UF-F : ' BI0003L-E-SIG-UF-F */
            _.Display($"BI0003L-E-SIG-UF-F : {BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_SIG_UF_F}");

            /*" -217- DISPLAY 'BI0003L-E-LIT-END-J: ' BI0003L-E-LIT-END-J */
            _.Display($"BI0003L-E-LIT-END-J: {BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_LIT_END_J}");

            /*" -218- DISPLAY 'BI0003L-E-COM-END-J: ' BI0003L-E-COM-END-J */
            _.Display($"BI0003L-E-COM-END-J: {BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_COM_END_J}");

            /*" -219- DISPLAY 'BI0003L-E-LIT-BAI-J: ' BI0003L-E-LIT-BAI-J */
            _.Display($"BI0003L-E-LIT-BAI-J: {BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_LIT_BAI_J}");

            /*" -220- DISPLAY 'BI0003L-E-COD-CEP-J: ' BI0003L-E-COD-CEP-J */
            _.Display($"BI0003L-E-COD-CEP-J: {BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_COD_CEP_J}");

            /*" -221- DISPLAY 'BI0003L-E-LIT-CID-J: ' BI0003L-E-LIT-CID-J */
            _.Display($"BI0003L-E-LIT-CID-J: {BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_LIT_CID_J}");

            /*" -224- DISPLAY 'BI0003L-E-SIG-UF-J : ' BI0003L-E-SIG-UF-J */
            _.Display($"BI0003L-E-SIG-UF-J : {BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_SIG_UF_J}");

            /*" -226- PERFORM 10000-00-INICIAL THRU 10000-99-SAIDA */

            M_10000_00_INICIAL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/


            /*" -228- PERFORM 30000-00-TRATA-PESSOA THRU 30000-99-SAIDA */

            M_30000_00_TRATA_PESSOA_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_30000_99_SAIDA*/


            /*" -232- PERFORM 50000-00-TRATA-TELEFONE THRU 50000-99-SAIDA VARYING IND-TEL FROM 001 BY 001 UNTIL IND-TEL GREATER 003 */

            for (WS_WORKING.WS_AUXILIARES.IND_TEL.Value = 001; !(WS_WORKING.WS_AUXILIARES.IND_TEL > 003); WS_WORKING.WS_AUXILIARES.IND_TEL.Value += 001)
            {

                M_50000_00_TRATA_TELEFONE_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_50000_99_SAIDA*/

            }

            /*" -234- PERFORM 70000-00-TRATA-EMAIL THRU 70000-99-SAIDA */

            M_70000_00_TRATA_EMAIL_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/


            /*" -236- PERFORM 90000-00-ENDERECO-FIS THRU 90000-99-SAIDA */

            M_90000_00_ENDERECO_FIS_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: M_90000_99_SAIDA*/


            /*" -238- PERFORM B0000-00-ENDERECO-JUR THRU B0000-99-SAIDA */

            B0000_00_ENDERECO_JUR_SECTION();
            /*Método Suprimido por falta de linha ou apenas EXIT nome: B0000_99_SAIDA*/


            /*" -240- GOBACK */

            throw new GoBack();

            /*" -240- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_0000_99_SAIDA*/

        [StopWatch]
        /*" M-10000-00-INICIAL-SECTION */
        private void M_10000_00_INICIAL_SECTION()
        {
            /*" -251- DISPLAY '10000-00-INICIAL       ' */
            _.Display($"10000-00-INICIAL       ");

            /*" -252- DISPLAY '=================================================' */
            _.Display($"=================================================");

            /*" -253- DISPLAY ' BI0003S - MANUTENCAO BASES PESSOAS - V.00       ' */
            _.Display($" BI0003S - MANUTENCAO BASES PESSOAS - V.00       ");

            /*" -254- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -260- DISPLAY ' VERSAO DE : ' FUNCTION WHEN-COMPILED(07:2) '/' FUNCTION WHEN-COMPILED(05:2) '/' FUNCTION WHEN-COMPILED(01:4) ' AS ' FUNCTION WHEN-COMPILED(09:2) ':' FUNCTION WHEN-COMPILED(11:2) ':' FUNCTION WHEN-COMPILED(13:2) */

            $" VERSAO DE : FUNCTION{_.WhenCompiled(7, 2)}/FUNCTION{_.WhenCompiled(5, 2)}/FUNCTION{_.WhenCompiled(1, 4)} AS FUNCTION{_.WhenCompiled(9, 2)}:FUNCTION{_.WhenCompiled(11, 2)}:FUNCTION{_.WhenCompiled(13, 2)}"
            .Display();

            /*" -261- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -270- DISPLAY ' DATA DE PROCESSAMENTO: ' FUNCTION CURRENT-DATE(07:2) '/' FUNCTION CURRENT-DATE(05:2) '/' FUNCTION CURRENT-DATE(01:4) ' AS ' FUNCTION CURRENT-DATE(09:2) ':' FUNCTION CURRENT-DATE(11:2) ':' FUNCTION CURRENT-DATE(13:2) */

            $" DATA DE PROCESSAMENTO: {_.CurrentDateAsDate():dd}/{_.CurrentDateAsDate():MM}/{_.CurrentDateAsDate():yyyy} AS {_.CurrentDateAsDate():HH}:{_.CurrentDateAsDate():mm}:{_.CurrentDateAsDate():ss}"
            .Display();

            /*" -274- MOVE ZEROS TO BI0003L-S-COD-ERR BI0003L-S-COD-SQL BI0003L-S-COD-PES BI0003L-S-OCO-END */
            _.Move(0, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_PES, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_OCO_END);

            /*" -276- MOVE 'PROCESSAMENTO NORMAL' TO BI0003L-S-LIT-ERR */
            _.Move("PROCESSAMENTO NORMAL", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

            /*" -279- IF (BI0003L-E-TIP-PES NOT NUMERIC) OR (BI0003L-E-TIP-PES EQUAL ZEROS) OR (BI0003L-E-TIP-PES GREATER 002) */

            if ((!BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_TIP_PES.IsNumeric()) || (BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_TIP_PES == 00) || (BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_TIP_PES > 002))
            {

                /*" -280- MOVE 001 TO BI0003L-S-COD-ERR */
                _.Move(001, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR);

                /*" -281- MOVE 'TIPO DE PESSOA INVALIDO' TO BI0003L-S-LIT-ERR */
                _.Move("TIPO DE PESSOA INVALIDO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -282- GOBACK */

                throw new GoBack();

                /*" -284- END-IF */
            }


            /*" -288- IF ((BI0003L-E-NUM-CPF NOT NUMERIC) OR (BI0003L-E-NUM-CPF EQUAL ZEROS)) AND ((BI0003L-E-NUM-CGC NOT NUMERIC) OR (BI0003L-E-NUM-CGC EQUAL ZEROS)) */

            if (((!BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_NUM_CPF.IsNumeric()) || (BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_NUM_CPF == 00)) && ((!BI0003L_LINKAGE.BI0003L_E_JURIDICA.BI0003L_E_NUM_CGC.IsNumeric()) || (BI0003L_LINKAGE.BI0003L_E_JURIDICA.BI0003L_E_NUM_CGC == 00)))
            {

                /*" -289- MOVE 002 TO BI0003L-S-COD-ERR */
                _.Move(002, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR);

                /*" -290- MOVE 'CPF E/OU CGC INVALIDO' TO BI0003L-S-LIT-ERR */
                _.Move("CPF E/OU CGC INVALIDO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -291- GOBACK */

                throw new GoBack();

                /*" -293- END-IF */
            }


            /*" -295- IF (BI0003L-E-TIP-PES EQUAL 001) AND (BI0003L-E-NUM-CPF EQUAL ZEROS) */

            if ((BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_TIP_PES == 001) && (BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_NUM_CPF == 00))
            {

                /*" -296- MOVE 003 TO BI0003L-S-COD-ERR */
                _.Move(003, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR);

                /*" -297- MOVE 'CPF/TIPO PESSOA INVALIDO' TO BI0003L-S-LIT-ERR */
                _.Move("CPF/TIPO PESSOA INVALIDO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -298- GOBACK */

                throw new GoBack();

                /*" -300- END-IF */
            }


            /*" -302- IF (BI0003L-E-TIP-PES EQUAL 001) AND (BI0003L-E-NOM-PES EQUAL SPACES) */

            if ((BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_TIP_PES == 001) && (BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_NOM_PES.IsEmpty()))
            {

                /*" -303- MOVE 004 TO BI0003L-S-COD-ERR */
                _.Move(004, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR);

                /*" -304- MOVE 'NOME PESSOA FISICA INVAL' TO BI0003L-S-LIT-ERR */
                _.Move("NOME PESSOA FISICA INVAL", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -305- GOBACK */

                throw new GoBack();

                /*" -307- END-IF */
            }


            /*" -309- IF (BI0003L-E-TIP-PES EQUAL 002) AND (BI0003L-E-NUM-CGC EQUAL ZEROS) */

            if ((BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_TIP_PES == 002) && (BI0003L_LINKAGE.BI0003L_E_JURIDICA.BI0003L_E_NUM_CGC == 00))
            {

                /*" -310- MOVE 005 TO BI0003L-S-COD-ERR */
                _.Move(005, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR);

                /*" -311- MOVE 'CGC/TIPO PESSOA INVALIDO' TO BI0003L-S-LIT-ERR */
                _.Move("CGC/TIPO PESSOA INVALIDO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -312- GOBACK */

                throw new GoBack();

                /*" -314- END-IF */
            }


            /*" -316- IF (BI0003L-E-TIP-PES EQUAL 002) AND (BI0003L-E-NOM-FAN EQUAL SPACES) */

            if ((BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_TIP_PES == 002) && (BI0003L_LINKAGE.BI0003L_E_JURIDICA.BI0003L_E_NOM_FAN.IsEmpty()))
            {

                /*" -317- MOVE 006 TO BI0003L-S-COD-ERR */
                _.Move(006, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR);

                /*" -318- MOVE 'NOME PESSOA JURIDICA INV' TO BI0003L-S-LIT-ERR */
                _.Move("NOME PESSOA JURIDICA INV", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -319- GOBACK */

                throw new GoBack();

                /*" -321- END-IF */
            }


            /*" -344- IF BI0003L-E-COD-CBO NOT NUMERIC OR BI0003L-E-DDI(001) NOT NUMERIC OR BI0003L-E-DDD(001) NOT NUMERIC OR BI0003L-E-NUM-FON(001) NOT NUMERIC OR BI0003L-E-DDI(002) NOT NUMERIC OR BI0003L-E-DDD(002) NOT NUMERIC OR BI0003L-E-NUM-FON(002) NOT NUMERIC OR BI0003L-E-DDI(003) NOT NUMERIC OR BI0003L-E-DDD(003) NOT NUMERIC OR BI0003L-E-NUM-FON(003) NOT NUMERIC OR BI0003L-E-COD-CEP-F NOT NUMERIC OR BI0003L-E-COD-CEP-J NOT NUMERIC */

            if (!BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_COD_CBO.IsNumeric() || !BI0003L_LINKAGE.BI0003L_E_TELEFONE[001].BI0003L_E_DDI.IsNumeric() || !BI0003L_LINKAGE.BI0003L_E_TELEFONE[001].BI0003L_E_DDD.IsNumeric() || !BI0003L_LINKAGE.BI0003L_E_TELEFONE[001].BI0003L_E_NUM_FON.IsNumeric() || !BI0003L_LINKAGE.BI0003L_E_TELEFONE[002].BI0003L_E_DDI.IsNumeric() || !BI0003L_LINKAGE.BI0003L_E_TELEFONE[002].BI0003L_E_DDD.IsNumeric() || !BI0003L_LINKAGE.BI0003L_E_TELEFONE[002].BI0003L_E_NUM_FON.IsNumeric() || !BI0003L_LINKAGE.BI0003L_E_TELEFONE[003].BI0003L_E_DDI.IsNumeric() || !BI0003L_LINKAGE.BI0003L_E_TELEFONE[003].BI0003L_E_DDD.IsNumeric() || !BI0003L_LINKAGE.BI0003L_E_TELEFONE[003].BI0003L_E_NUM_FON.IsNumeric() || !BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_COD_CEP_F.IsNumeric() || !BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_COD_CEP_J.IsNumeric())
            {

                /*" -345- MOVE 007 TO BI0003L-S-COD-ERR */
                _.Move(007, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR);

                /*" -346- MOVE 'CONTEUDO NAO NUMERICO' TO BI0003L-S-LIT-ERR */
                _.Move("CONTEUDO NAO NUMERICO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -347- GOBACK */

                throw new GoBack();

                /*" -349- END-IF */
            }


            /*" -349- . */

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_10000_99_SAIDA*/

        [StopWatch]
        /*" M-30000-00-TRATA-PESSOA-SECTION */
        private void M_30000_00_TRATA_PESSOA_SECTION()
        {
            /*" -361- DISPLAY '30000-00-TRATA-PESSOA   ' */
            _.Display($"30000-00-TRATA-PESSOA   ");

            /*" -362- IF BI0003L-E-TIP-PES EQUAL 001 */

            if (BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_TIP_PES == 001)
            {

                /*" -364- MOVE BI0003L-E-NUM-CPF TO CPF OF DCLPESSOA-FISICA */
                _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_NUM_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

                /*" -366- MOVE BI0003L-E-DAT-NAS TO DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_DAT_NAS, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

                /*" -368- MOVE BI0003L-E-SEX TO SEXO OF DCLPESSOA-FISICA */
                _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_SEX, PESFIS.DCLPESSOA_FISICA.SEXO);

                /*" -377- PERFORM M_30000_00_TRATA_PESSOA_DB_SELECT_1 */

                M_30000_00_TRATA_PESSOA_DB_SELECT_1();

                /*" -379- ELSE */
            }
            else
            {


                /*" -381- MOVE BI0003L-E-NUM-CGC TO CGC OF DCLPESSOA-JURIDICA */
                _.Move(BI0003L_LINKAGE.BI0003L_E_JURIDICA.BI0003L_E_NUM_CGC, PESJUR.DCLPESSOA_JURIDICA.CGC);

                /*" -387- PERFORM M_30000_00_TRATA_PESSOA_DB_SELECT_2 */

                M_30000_00_TRATA_PESSOA_DB_SELECT_2();

                /*" -390- END-IF */
            }


            /*" -392- DISPLAY 'MAX PESSOA_FISICA: ' WS-COD-PES-ATU ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA_FISICA: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -393- IF SQLCODE EQUAL ZEROS */

            if (DB.SQLCODE == 00)
            {

                /*" -394- IF WS-COD-PES-ATU EQUAL ZEROS */

                if (WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU == 00)
                {

                    /*" -395- MOVE 'N' TO N88-CADASTRO-PESS */
                    _.Move("N", WS_WORKING.NIVEIS_88.N88_CADASTRO_PESS);

                    /*" -396- PERFORM 31000-00-INS-PESSOA THRU 31000-99-SAIDA */

                    M_31000_00_INS_PESSOA_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_31000_99_SAIDA*/


                    /*" -397- ELSE */
                }
                else
                {


                    /*" -398- MOVE 'S' TO N88-CADASTRO-PESS */
                    _.Move("S", WS_WORKING.NIVEIS_88.N88_CADASTRO_PESS);

                    /*" -399- MOVE WS-COD-PES-ATU TO BI0003L-S-COD-PES */
                    _.Move(WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_PES);

                    /*" -400- PERFORM 33000-00-UPD-PESSOA THRU 33000-99-SAIDA */

                    M_33000_00_UPD_PESSOA_SECTION();
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_33000_99_SAIDA*/


                    /*" -401- END-IF */
                }


                /*" -402- ELSE */
            }
            else
            {


                /*" -405- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -406- MOVE 'ERRO MAX PESSOA F OU J' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX PESSOA F OU J", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -407- DISPLAY '***' */
                _.Display($"***");

                /*" -408- DISPLAY ' BI0003S - 30000-00-TRATA-PESSOA     ' */
                _.Display($" BI0003S - 30000-00-TRATA-PESSOA     ");

                /*" -409- DISPLAY ' ERRO MAX PESSOA F OU J (' WS-SQLCODE ')' */

                $" ERRO MAX PESSOA F OU J ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -410- DISPLAY '***' */
                _.Display($"***");

                /*" -411- MOVE 'ERRO MAX PESSOA F OU J' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX PESSOA F OU J", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -412- GOBACK */

                throw new GoBack();

                /*" -414- END-IF */
            }


            /*" -414- . */

        }

        [StopWatch]
        /*" M-30000-00-TRATA-PESSOA-DB-SELECT-1 */
        public void M_30000_00_TRATA_PESSOA_DB_SELECT_1()
        {
            /*" -377- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) INTO :WS-COD-PES-ATU FROM SEGUROS.PESSOA_FISICA WHERE CPF = :DCLPESSOA-FISICA.CPF AND DATA_NASCIMENTO = :DCLPESSOA-FISICA.DATA-NASCIMENTO AND SEXO = :DCLPESSOA-FISICA.SEXO WITH UR END-EXEC */

            var m_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1 = new M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1()
            {
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
            };

            var executed_1 = M_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1.Execute(m_30000_00_TRATA_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_PES_ATU, WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_30000_99_SAIDA*/

        [StopWatch]
        /*" M-30000-00-TRATA-PESSOA-DB-SELECT-2 */
        public void M_30000_00_TRATA_PESSOA_DB_SELECT_2()
        {
            /*" -387- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) INTO :WS-COD-PES-ATU FROM SEGUROS.PESSOA_JURIDICA WHERE CGC = :DCLPESSOA-JURIDICA.CGC WITH UR END-EXEC */

            var m_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1 = new M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1()
            {
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
            };

            var executed_1 = M_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1.Execute(m_30000_00_TRATA_PESSOA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_PES_ATU, WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU);
            }


        }

        [StopWatch]
        /*" M-31000-00-INS-PESSOA-SECTION */
        private void M_31000_00_INS_PESSOA_SECTION()
        {
            /*" -425- DISPLAY '31000-00-INS-PESSOA    ' */
            _.Display($"31000-00-INS-PESSOA    ");

            /*" -430- PERFORM M_31000_00_INS_PESSOA_DB_SELECT_1 */

            M_31000_00_INS_PESSOA_DB_SELECT_1();

            /*" -434- DISPLAY 'MAX PESSOA: ' WS-COD-PES-ATU ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -435- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -438- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -439- MOVE 'ERRO MAX PESSOA' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX PESSOA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -440- DISPLAY '***' */
                _.Display($"***");

                /*" -441- DISPLAY ' BI0003S - 31000-00-INS-PESSOA       ' */
                _.Display($" BI0003S - 31000-00-INS-PESSOA       ");

                /*" -442- DISPLAY ' ERRO MAX PESSOA (' WS-SQLCODE ')' */

                $" ERRO MAX PESSOA ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -443- DISPLAY '***' */
                _.Display($"***");

                /*" -444- MOVE 'ERRO MAX PESSOA' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX PESSOA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -445- GOBACK */

                throw new GoBack();

                /*" -448- END-IF */
            }


            /*" -451- COMPUTE WS-COD-PES-ATU BI0003L-S-COD-PES = (WS-COD-PES-ATU + 001) */
            BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_PES.Value = (WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU + 001);
            WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.Value = (WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU + 001);

            /*" -452- MOVE BI0003L-E-NOM-PES TO PESSOA-NOME-PESSOA */
            _.Move(BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_NOM_PES, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -453- IF BI0003L-E-TIP-PES EQUAL 001 */

            if (BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_TIP_PES == 001)
            {

                /*" -454- MOVE 'F' TO PESSOA-TIPO-PESSOA */
                _.Move("F", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

                /*" -455- ELSE */
            }
            else
            {


                /*" -456- MOVE 'J' TO PESSOA-TIPO-PESSOA */
                _.Move("J", PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA);

                /*" -457- END-IF */
            }


            /*" -460- MOVE BI0003L-E-COD-USU TO PESSOA-COD-USUARIO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_CONTROLE.BI0003L_E_COD_USU, PESSOA.DCLPESSOA.PESSOA_COD_USUARIO);

            /*" -468- PERFORM M_31000_00_INS_PESSOA_DB_INSERT_1 */

            M_31000_00_INS_PESSOA_DB_INSERT_1();

            /*" -472- DISPLAY 'INS PESSOA: ' WS-COD-PES-ATU ' SQLCODE: ' SQLCODE */

            $"INS PESSOA: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -474- IF (SQLCODE NOT EQUAL ZEROS) OR (PESSOA-NOME-PESSOA OF DCLPESSOA EQUAL SPACES) */

            if ((DB.SQLCODE != 00) || (PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.IsEmpty()))
            {

                /*" -477- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -478- MOVE 'ERRO INS PESSOA' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS PESSOA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -479- DISPLAY '***' */
                _.Display($"***");

                /*" -480- DISPLAY ' BI0003S - 31000-00-INS-PESSOA       ' */
                _.Display($" BI0003S - 31000-00-INS-PESSOA       ");

                /*" -481- DISPLAY ' ERRO INS PESSOA (' WS-SQLCODE ')' */

                $" ERRO INS PESSOA ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -482- DISPLAY '***' */
                _.Display($"***");

                /*" -483- MOVE 'ERRO INS PESSOA' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS PESSOA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -484- GOBACK */

                throw new GoBack();

                /*" -487- END-IF */
            }


            /*" -488- IF BI0003L-E-TIP-PES EQUAL 001 */

            if (BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_TIP_PES == 001)
            {

                /*" -489- PERFORM 31100-00-INS-PESSOA-FISICA */

                M_31100_00_INS_PESSOA_FISICA_SECTION();

                /*" -490- ELSE */
            }
            else
            {


                /*" -491- PERFORM 31300-00-INS-PESSOA-JURIDICA */

                M_31300_00_INS_PESSOA_JURIDICA_SECTION();

                /*" -493- END-IF */
            }


            /*" -493- . */

        }

        [StopWatch]
        /*" M-31000-00-INS-PESSOA-DB-SELECT-1 */
        public void M_31000_00_INS_PESSOA_DB_SELECT_1()
        {
            /*" -430- EXEC SQL SELECT VALUE(MAX(COD_PESSOA),0) INTO :WS-COD-PES-ATU FROM SEGUROS.PESSOA WITH UR END-EXEC */

            var m_31000_00_INS_PESSOA_DB_SELECT_1_Query1 = new M_31000_00_INS_PESSOA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_31000_00_INS_PESSOA_DB_SELECT_1_Query1.Execute(m_31000_00_INS_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_COD_PES_ATU, WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU);
            }


        }

        [StopWatch]
        /*" M-31000-00-INS-PESSOA-DB-INSERT-1 */
        public void M_31000_00_INS_PESSOA_DB_INSERT_1()
        {
            /*" -468- EXEC SQL INSERT INTO SEGUROS.PESSOA VALUES (:WS-COD-PES-ATU , :DCLPESSOA.PESSOA-NOME-PESSOA, CURRENT TIMESTAMP , :DCLPESSOA.PESSOA-COD-USUARIO, :DCLPESSOA.PESSOA-TIPO-PESSOA, NULL ) END-EXEC */

            var m_31000_00_INS_PESSOA_DB_INSERT_1_Insert1 = new M_31000_00_INS_PESSOA_DB_INSERT_1_Insert1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
                PESSOA_NOME_PESSOA = PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA.ToString(),
                PESSOA_COD_USUARIO = PESSOA.DCLPESSOA.PESSOA_COD_USUARIO.ToString(),
                PESSOA_TIPO_PESSOA = PESSOA.DCLPESSOA.PESSOA_TIPO_PESSOA.ToString(),
            };

            M_31000_00_INS_PESSOA_DB_INSERT_1_Insert1.Execute(m_31000_00_INS_PESSOA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_31000_99_SAIDA*/

        [StopWatch]
        /*" M-31100-00-INS-PESSOA-FISICA-SECTION */
        private void M_31100_00_INS_PESSOA_FISICA_SECTION()
        {
            /*" -504- DISPLAY '31100-00-INS-PESSOA-FISICA' */
            _.Display($"31100-00-INS-PESSOA-FISICA");

            /*" -506- MOVE BI0003L-E-NOM-PES TO PESSOA-NOME-PESSOA */
            _.Move(BI0003L_LINKAGE.BI0003L_E_PESSOA.BI0003L_E_NOM_PES, PESSOA.DCLPESSOA.PESSOA_NOME_PESSOA);

            /*" -507- MOVE BI0003L-E-NUM-CPF TO CPF OF DCLPESSOA-FISICA */
            _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_NUM_CPF, PESFIS.DCLPESSOA_FISICA.CPF);

            /*" -508- IF BI0003L-E-DAT-NAS EQUAL SPACES OR ZEROS */

            if (BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_DAT_NAS.In(string.Empty, "00"))
            {

                /*" -509- MOVE 008 TO BI0003L-S-COD-ERR */
                _.Move(008, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR);

                /*" -510- MOVE 'DATA NASCIMENTO INVALIDA' TO BI0003L-S-LIT-ERR */
                _.Move("DATA NASCIMENTO INVALIDA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -511- GOBACK */

                throw new GoBack();

                /*" -512- ELSE */
            }
            else
            {


                /*" -514- MOVE BI0003L-E-DAT-NAS TO DATA-NASCIMENTO OF DCLPESSOA-FISICA */
                _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_DAT_NAS, PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO);

                /*" -515- END-IF */
            }


            /*" -516- MOVE BI0003L-E-SEX TO SEXO OF DCLPESSOA-FISICA */
            _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_SEX, PESFIS.DCLPESSOA_FISICA.SEXO);

            /*" -518- MOVE SPACES TO TIPO-IDENT-SIVPF OF DCLPESSOA-FISICA */
            _.Move("", PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF);

            /*" -520- MOVE '0001-01-01' TO DATA-EXPEDICAO OF DCLPESSOA-FISICA */
            _.Move("0001-01-01", PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);

            /*" -521- IF BI0003L-E-EST-CIV EQUAL SPACES */

            if (BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_EST_CIV.IsEmpty())
            {

                /*" -523- MOVE 'O' TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                _.Move("O", PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                /*" -524- ELSE */
            }
            else
            {


                /*" -526- MOVE BI0003L-E-EST-CIV TO ESTADO-CIVIL OF DCLPESSOA-FISICA */
                _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_EST_CIV, PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL);

                /*" -528- END-IF */
            }


            /*" -529- IF BI0003L-E-NUM-IDE GREATER ZEROS */

            if (BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_NUM_IDE > 00)
            {

                /*" -532- MOVE BI0003L-E-NUM-IDE TO NUM-IDENTIDADE OF DCLPESSOA-FISICA */
                _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_NUM_IDE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);

                /*" -533- IF BI0003L-E-ORG-EXP EQUAL SPACES */

                if (BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_ORG_EXP.IsEmpty())
                {

                    /*" -535- MOVE 'NI' TO ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA */
                    _.Move("NI", PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);

                    /*" -536- ELSE */
                }
                else
                {


                    /*" -538- MOVE BI0003L-E-ORG-EXP TO ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA */
                    _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_ORG_EXP, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);

                    /*" -540- END-IF */
                }


                /*" -541- IF BI0003L-E-UF-EXP EQUAL SPACES */

                if (BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_UF_EXP.IsEmpty())
                {

                    /*" -543- MOVE 'NI' TO UF-EXPEDIDORA OF DCLPESSOA-FISICA */
                    _.Move("NI", PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);

                    /*" -544- ELSE */
                }
                else
                {


                    /*" -546- MOVE BI0003L-E-UF-EXP TO UF-EXPEDIDORA OF DCLPESSOA-FISICA */
                    _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_UF_EXP, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);

                    /*" -548- END-IF */
                }


                /*" -549- IF BI0003L-E-DAT-EXP EQUAL SPACES */

                if (BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_DAT_EXP.IsEmpty())
                {

                    /*" -551- MOVE '0001-01-01' TO DATA-EXPEDICAO OF DCLPESSOA-FISICA */
                    _.Move("0001-01-01", PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);

                    /*" -552- ELSE */
                }
                else
                {


                    /*" -554- MOVE BI0003L-E-DAT-EXP TO DATA-EXPEDICAO OF DCLPESSOA-FISICA */
                    _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_DAT_EXP, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);

                    /*" -555- END-IF */
                }


                /*" -557- END-IF */
            }


            /*" -560- MOVE BI0003L-E-COD-CBO TO COD-CBO OF DCLPESSOA-FISICA */
            _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_COD_CBO, PESFIS.DCLPESSOA_FISICA.COD_CBO);

            /*" -563- MOVE BI0003L-E-COD-USU TO COD-USUARIO OF DCLPESSOA-FISICA */
            _.Move(BI0003L_LINKAGE.BI0003L_E_CONTROLE.BI0003L_E_COD_USU, PESFIS.DCLPESSOA_FISICA.COD_USUARIO);

            /*" -578- PERFORM M_31100_00_INS_PESSOA_FISICA_DB_INSERT_1 */

            M_31100_00_INS_PESSOA_FISICA_DB_INSERT_1();

            /*" -583- DISPLAY 'INS PESSOA_FISICA: ' WS-COD-PES-ATU ' SQLCODE: ' SQLCODE */

            $"INS PESSOA_FISICA: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -584- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -587- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -588- MOVE 'ERRO INS PESSOA_FISICA' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS PESSOA_FISICA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -589- DISPLAY '***' */
                _.Display($"***");

                /*" -590- DISPLAY ' BI0003S - 31100-00-INS-PESSOA-FISICA' */
                _.Display($" BI0003S - 31100-00-INS-PESSOA-FISICA");

                /*" -591- DISPLAY ' ERRO INS PESSOA_FISICA    (' WS-SQLCODE ')' */

                $" ERRO INS PESSOA_FISICA    ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -592- DISPLAY ' CODIGO PESSOA... ' WS-COD-PES-ATU */
                _.Display($" CODIGO PESSOA... {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}");

                /*" -593- DISPLAY '***' */
                _.Display($"***");

                /*" -594- MOVE 'ERRO INS PESSOA_FISICA' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS PESSOA_FISICA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -595- GOBACK */

                throw new GoBack();

                /*" -597- END-IF */
            }


            /*" -597- . */

        }

        [StopWatch]
        /*" M-31100-00-INS-PESSOA-FISICA-DB-INSERT-1 */
        public void M_31100_00_INS_PESSOA_FISICA_DB_INSERT_1()
        {
            /*" -578- EXEC SQL INSERT INTO SEGUROS.PESSOA_FISICA VALUES (:WS-COD-PES-ATU, :DCLPESSOA-FISICA.CPF, :DCLPESSOA-FISICA.DATA-NASCIMENTO, :DCLPESSOA-FISICA.SEXO, :DCLPESSOA-FISICA.COD-USUARIO, :DCLPESSOA-FISICA.ESTADO-CIVIL, CURRENT TIMESTAMP, :DCLPESSOA-FISICA.NUM-IDENTIDADE, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR, :DCLPESSOA-FISICA.UF-EXPEDIDORA, :DCLPESSOA-FISICA.DATA-EXPEDICAO, :DCLPESSOA-FISICA.COD-CBO, :DCLPESSOA-FISICA.TIPO-IDENT-SIVPF) END-EXEC */

            var m_31100_00_INS_PESSOA_FISICA_DB_INSERT_1_Insert1 = new M_31100_00_INS_PESSOA_FISICA_DB_INSERT_1_Insert1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
                CPF = PESFIS.DCLPESSOA_FISICA.CPF.ToString(),
                DATA_NASCIMENTO = PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.ToString(),
                SEXO = PESFIS.DCLPESSOA_FISICA.SEXO.ToString(),
                COD_USUARIO = PESFIS.DCLPESSOA_FISICA.COD_USUARIO.ToString(),
                ESTADO_CIVIL = PESFIS.DCLPESSOA_FISICA.ESTADO_CIVIL.ToString(),
                NUM_IDENTIDADE = PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE.ToString(),
                ORGAO_EXPEDIDOR = PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR.ToString(),
                UF_EXPEDIDORA = PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA.ToString(),
                DATA_EXPEDICAO = PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.ToString(),
                COD_CBO = PESFIS.DCLPESSOA_FISICA.COD_CBO.ToString(),
                TIPO_IDENT_SIVPF = PESFIS.DCLPESSOA_FISICA.TIPO_IDENT_SIVPF.ToString(),
            };

            M_31100_00_INS_PESSOA_FISICA_DB_INSERT_1_Insert1.Execute(m_31100_00_INS_PESSOA_FISICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_31100_99_SAIDA*/

        [StopWatch]
        /*" M-31300-00-INS-PESSOA-JURIDICA-SECTION */
        private void M_31300_00_INS_PESSOA_JURIDICA_SECTION()
        {
            /*" -608- DISPLAY '31300-00-INS-PESSOA-JURIDI' */
            _.Display($"31300-00-INS-PESSOA-JURIDI");

            /*" -610- MOVE BI0003L-E-NUM-CGC TO CGC OF DCLPESSOA-JURIDICA */
            _.Move(BI0003L_LINKAGE.BI0003L_E_JURIDICA.BI0003L_E_NUM_CGC, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -612- MOVE BI0003L-E-NUM-CGC TO CGC OF DCLPESSOA-JURIDICA */
            _.Move(BI0003L_LINKAGE.BI0003L_E_JURIDICA.BI0003L_E_NUM_CGC, PESJUR.DCLPESSOA_JURIDICA.CGC);

            /*" -614- MOVE BI0003L-E-NOM-FAN TO NOME-FANTASIA OF DCLPESSOA-JURIDICA */
            _.Move(BI0003L_LINKAGE.BI0003L_E_JURIDICA.BI0003L_E_NOM_FAN, PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA);

            /*" -617- MOVE BI0003L-E-COD-USU TO COD-USUARIO OF DCLPESSOA-JURIDICA */
            _.Move(BI0003L_LINKAGE.BI0003L_E_CONTROLE.BI0003L_E_COD_USU, PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO);

            /*" -624- PERFORM M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1 */

            M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1();

            /*" -630- DISPLAY 'INS PESSOA_JURIDI: ' COD-PESSOA OF DCLPESSOA-JURIDICA ' SQLCODE: ' SQLCODE */

            $"INS PESSOA_JURIDI: {PESJUR.DCLPESSOA_JURIDICA.COD_PESSOA} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -631- IF (SQLCODE NOT EQUAL ZEROS) */

            if ((DB.SQLCODE != 00))
            {

                /*" -634- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -635- DISPLAY '***' */
                _.Display($"***");

                /*" -636- MOVE 'ERRO INS PESSOA_JURIDICA' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS PESSOA_JURIDICA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -637- DISPLAY ' BI0003S - 31300-00-INS-PESSOA-JURIDICA' */
                _.Display($" BI0003S - 31300-00-INS-PESSOA-JURIDICA");

                /*" -638- DISPLAY ' ERRO INS PESSOA_JURIDICA  (' WS-SQLCODE ')' */

                $" ERRO INS PESSOA_JURIDICA  ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -639- DISPLAY ' CODIGO PESSOA... ' WS-COD-PES-ATU */
                _.Display($" CODIGO PESSOA... {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}");

                /*" -640- DISPLAY '***' */
                _.Display($"***");

                /*" -641- MOVE 'ERRO INS PESSOA_JURIDICA' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS PESSOA_JURIDICA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -642- GOBACK */

                throw new GoBack();

                /*" -644- END-IF */
            }


            /*" -644- . */

        }

        [StopWatch]
        /*" M-31300-00-INS-PESSOA-JURIDICA-DB-INSERT-1 */
        public void M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1()
        {
            /*" -624- EXEC SQL INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES (:WS-COD-PES-ATU, :DCLPESSOA-JURIDICA.CGC, :DCLPESSOA-JURIDICA.NOME-FANTASIA, :DCLPESSOA-JURIDICA.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC */

            var m_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1 = new M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
                CGC = PESJUR.DCLPESSOA_JURIDICA.CGC.ToString(),
                NOME_FANTASIA = PESJUR.DCLPESSOA_JURIDICA.NOME_FANTASIA.ToString(),
                COD_USUARIO = PESJUR.DCLPESSOA_JURIDICA.COD_USUARIO.ToString(),
            };

            M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1.Execute(m_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_31300_99_SAIDA*/

        [StopWatch]
        /*" M-33000-00-UPD-PESSOA-SECTION */
        private void M_33000_00_UPD_PESSOA_SECTION()
        {
            /*" -656- DISPLAY '33000-00-UPD-PESSOA' */
            _.Display($"33000-00-UPD-PESSOA");

            /*" -668- PERFORM M_33000_00_UPD_PESSOA_DB_SELECT_1 */

            M_33000_00_UPD_PESSOA_DB_SELECT_1();

            /*" -673- DISPLAY 'SEL PESSOA_FISICA: ' WS-COD-PES-ATU ' SQLCODE: ' SQLCODE */

            $"SEL PESSOA_FISICA: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -674- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -677- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -678- MOVE 'ERRO SEL PESSOA_FISICA' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO SEL PESSOA_FISICA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -679- DISPLAY '***' */
                _.Display($"***");

                /*" -680- DISPLAY ' BI0003S - 33000-00-UPD-PESSOA-FISICA' */
                _.Display($" BI0003S - 33000-00-UPD-PESSOA-FISICA");

                /*" -681- DISPLAY ' ERRO SEL PESSOA_FISICA    (' WS-SQLCODE ')' */

                $" ERRO SEL PESSOA_FISICA    ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -682- DISPLAY ' CODIGO PESSOA... ' WS-COD-PES-ATU */
                _.Display($" CODIGO PESSOA... {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}");

                /*" -683- DISPLAY '***' */
                _.Display($"***");

                /*" -684- MOVE 'ERRO SEL PESSOA_FISICA' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO SEL PESSOA_FISICA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -685- GOBACK */

                throw new GoBack();

                /*" -688- END-IF */
            }


            /*" -695- IF (NUM-IDENTIDADE OF DCLPESSOA-FISICA EQUAL SPACES OR '000000000000000' ) OR (ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA EQUAL SPACES) OR (VIND-UNEXPEDI LESS ZEROS) OR (VIND-DTEXPEDI LESS ZEROS) */

            if ((PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE.In(string.Empty, "000000000000000")) || (PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR.IsEmpty()) || (WS_WORKING.WS_AUXILIARES.VIND_UNEXPEDI < 00) || (WS_WORKING.WS_AUXILIARES.VIND_DTEXPEDI < 00))
            {

                /*" -696- CONTINUE */

                /*" -697- ELSE */
            }
            else
            {


                /*" -698- GO TO 33000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_33000_99_SAIDA*/ //GOTO
                return;

                /*" -701- END-IF */
            }


            /*" -704- MOVE BI0003L-E-NUM-IDE TO NUM-IDENTIDADE OF DCLPESSOA-FISICA */
            _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_NUM_IDE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);

            /*" -705- IF BI0003L-E-ORG-EXP EQUAL SPACES */

            if (BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_ORG_EXP.IsEmpty())
            {

                /*" -707- MOVE 'NI' TO ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA */
                _.Move("NI", PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);

                /*" -708- ELSE */
            }
            else
            {


                /*" -710- MOVE BI0003L-E-ORG-EXP TO ORGAO-EXPEDIDOR OF DCLPESSOA-FISICA */
                _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_ORG_EXP, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);

                /*" -712- END-IF */
            }


            /*" -713- IF BI0003L-E-UF-EXP EQUAL SPACES */

            if (BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_UF_EXP.IsEmpty())
            {

                /*" -715- MOVE 'NI' TO UF-EXPEDIDORA OF DCLPESSOA-FISICA */
                _.Move("NI", PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);

                /*" -716- ELSE */
            }
            else
            {


                /*" -718- MOVE BI0003L-E-UF-EXP TO UF-EXPEDIDORA OF DCLPESSOA-FISICA */
                _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_UF_EXP, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);

                /*" -720- END-IF */
            }


            /*" -721- IF BI0003L-E-DAT-EXP EQUAL SPACES */

            if (BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_DAT_EXP.IsEmpty())
            {

                /*" -723- MOVE '0001-01-01' TO DATA-EXPEDICAO OF DCLPESSOA-FISICA */
                _.Move("0001-01-01", PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);

                /*" -724- ELSE */
            }
            else
            {


                /*" -726- MOVE BI0003L-E-DAT-EXP TO DATA-EXPEDICAO OF DCLPESSOA-FISICA */
                _.Move(BI0003L_LINKAGE.BI0003L_E_FISICA.BI0003L_E_DAT_EXP, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);

                /*" -729- END-IF */
            }


            /*" -740- PERFORM M_33000_00_UPD_PESSOA_DB_UPDATE_1 */

            M_33000_00_UPD_PESSOA_DB_UPDATE_1();

            /*" -745- DISPLAY 'UPD PESSOA_FISICA: ' WS-COD-PES-ATU ' SQLCODE: ' SQLCODE */

            $"UPD PESSOA_FISICA: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -746- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -749- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -750- MOVE 'ERRO UPD PESSOA_FISICA' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO UPD PESSOA_FISICA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -751- DISPLAY '***' */
                _.Display($"***");

                /*" -752- DISPLAY ' BI0003S - 33000-00-UPD-PESSOA-FISICA' */
                _.Display($" BI0003S - 33000-00-UPD-PESSOA-FISICA");

                /*" -753- DISPLAY ' ERRO UPD PESSOA_FISICA    (' WS-SQLCODE ')' */

                $" ERRO UPD PESSOA_FISICA    ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -754- DISPLAY ' CODIGO PESSOA... ' WS-COD-PES-ATU */
                _.Display($" CODIGO PESSOA... {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}");

                /*" -755- DISPLAY '***' */
                _.Display($"***");

                /*" -756- MOVE 'ERRO UPD PESSOA_FISICA' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO UPD PESSOA_FISICA", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -757- GOBACK */

                throw new GoBack();

                /*" -759- END-IF */
            }


            /*" -759- . */

        }

        [StopWatch]
        /*" M-33000-00-UPD-PESSOA-DB-SELECT-1 */
        public void M_33000_00_UPD_PESSOA_DB_SELECT_1()
        {
            /*" -668- EXEC SQL SELECT NUM_IDENTIDADE , ORGAO_EXPEDIDOR , UF_EXPEDIDORA , DATA_EXPEDICAO INTO :DCLPESSOA-FISICA.NUM-IDENTIDADE:VIND-NULL01, :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR:VIND-NULL02, :DCLPESSOA-FISICA.UF-EXPEDIDORA:VIND-UNEXPEDI, :DCLPESSOA-FISICA.DATA-EXPEDICAO:VIND-DTEXPEDI FROM SEGUROS.PESSOA_FISICA WHERE COD_PESSOA = :WS-COD-PES-ATU WITH UR END-EXEC */

            var m_33000_00_UPD_PESSOA_DB_SELECT_1_Query1 = new M_33000_00_UPD_PESSOA_DB_SELECT_1_Query1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
            };

            var executed_1 = M_33000_00_UPD_PESSOA_DB_SELECT_1_Query1.Execute(m_33000_00_UPD_PESSOA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.NUM_IDENTIDADE, PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE);
                _.Move(executed_1.VIND_NULL01, WS_WORKING.WS_AUXILIARES.VIND_NULL01);
                _.Move(executed_1.ORGAO_EXPEDIDOR, PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR);
                _.Move(executed_1.VIND_NULL02, WS_WORKING.WS_AUXILIARES.VIND_NULL02);
                _.Move(executed_1.UF_EXPEDIDORA, PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA);
                _.Move(executed_1.VIND_UNEXPEDI, WS_WORKING.WS_AUXILIARES.VIND_UNEXPEDI);
                _.Move(executed_1.DATA_EXPEDICAO, PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO);
                _.Move(executed_1.VIND_DTEXPEDI, WS_WORKING.WS_AUXILIARES.VIND_DTEXPEDI);
            }


        }

        [StopWatch]
        /*" M-33000-00-UPD-PESSOA-DB-UPDATE-1 */
        public void M_33000_00_UPD_PESSOA_DB_UPDATE_1()
        {
            /*" -740- EXEC SQL UPDATE SEGUROS.PESSOA_FISICA SET NUM_IDENTIDADE = :DCLPESSOA-FISICA.NUM-IDENTIDADE , ORGAO_EXPEDIDOR = :DCLPESSOA-FISICA.ORGAO-EXPEDIDOR , UF_EXPEDIDORA = :DCLPESSOA-FISICA.UF-EXPEDIDORA , DATA_EXPEDICAO = :DCLPESSOA-FISICA.DATA-EXPEDICAO WHERE COD_PESSOA = :WS-COD-PES-ATU END-EXEC */

            var m_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1 = new M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1()
            {
                ORGAO_EXPEDIDOR = PESFIS.DCLPESSOA_FISICA.ORGAO_EXPEDIDOR.ToString(),
                NUM_IDENTIDADE = PESFIS.DCLPESSOA_FISICA.NUM_IDENTIDADE.ToString(),
                DATA_EXPEDICAO = PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.ToString(),
                UF_EXPEDIDORA = PESFIS.DCLPESSOA_FISICA.UF_EXPEDIDORA.ToString(),
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
            };

            M_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1.Execute(m_33000_00_UPD_PESSOA_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_33000_99_SAIDA*/

        [StopWatch]
        /*" M-50000-00-TRATA-TELEFONE-SECTION */
        private void M_50000_00_TRATA_TELEFONE_SECTION()
        {
            /*" -770- DISPLAY '50000-00-TRATA-TELEFONE' */
            _.Display($"50000-00-TRATA-TELEFONE");

            /*" -776- IF (BI0003L-E-DDI(IND-TEL) NOT NUMERIC OR BI0003L-E-DDI(IND-TEL) EQUAL ZEROS) OR (BI0003L-E-DDD(IND-TEL) NOT NUMERIC OR BI0003L-E-DDD(IND-TEL) EQUAL ZEROS) OR (BI0003L-E-NUM-FON(IND-TEL) NOT NUMERIC OR BI0003L-E-NUM-FON(IND-TEL) EQUAL ZEROS) */

            if ((!BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_DDI.IsNumeric() || BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_DDI == 00) || (!BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_DDD.IsNumeric() || BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_DDD == 00) || (!BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_NUM_FON.IsNumeric() || BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_NUM_FON == 00))
            {

                /*" -777- DISPLAY '50000-99-SAIDA/' IND-TEL */
                _.Display($"50000-99-SAIDA/{WS_WORKING.WS_AUXILIARES.IND_TEL}");

                /*" -778- GO TO 50000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_50000_99_SAIDA*/ //GOTO
                return;

                /*" -781- END-IF */
            }


            /*" -788- PERFORM M_50000_00_TRATA_TELEFONE_DB_SELECT_1 */

            M_50000_00_TRATA_TELEFONE_DB_SELECT_1();

            /*" -794- DISPLAY 'MAX PESSOA_TELEFONE: ' WS-COD-PES-ATU '/' IND-TEL '/' WS-MAX-SEQ-TEL ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA_TELEFONE: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{WS_WORKING.WS_AUXILIARES.IND_TEL}/{WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -795- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -798- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -799- MOVE 'ERRO MAX TELEFONE' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX TELEFONE", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -800- DISPLAY '***' */
                _.Display($"***");

                /*" -801- DISPLAY ' BI0003S - 50000-00-TRATA-TELEFONE   ' */
                _.Display($" BI0003S - 50000-00-TRATA-TELEFONE   ");

                /*" -802- DISPLAY ' ERRO MAX TELEFONE (' WS-SQLCODE ')' */

                $" ERRO MAX TELEFONE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -803- DISPLAY '***' */
                _.Display($"***");

                /*" -804- MOVE 'ERRO MAX TELEFONE' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX TELEFONE", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -805- GOBACK */

                throw new GoBack();

                /*" -807- END-IF */
            }


            /*" -808- IF WS-MAX-SEQ-TEL EQUAL ZEROS */

            if (WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL == 00)
            {

                /*" -809- PERFORM 51000-00-GRAVA-TELEFONE */

                M_51000_00_GRAVA_TELEFONE_SECTION();

                /*" -810- GO TO 50000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_50000_99_SAIDA*/ //GOTO
                return;

                /*" -813- END-IF */
            }


            /*" -825- PERFORM M_50000_00_TRATA_TELEFONE_DB_SELECT_2 */

            M_50000_00_TRATA_TELEFONE_DB_SELECT_2();

            /*" -830- DISPLAY 'SEL PESSOA_TELEFONE: ' WS-COD-PES-ATU '/' WS-MAX-SEQ-TEL ' SQLCODE: ' SQLCODE */

            $"SEL PESSOA_TELEFONE: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -831- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -834- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -835- MOVE 'ERRO SEL TELEFONE' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO SEL TELEFONE", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -836- DISPLAY '***' */
                _.Display($"***");

                /*" -837- DISPLAY ' BI0003S - 50000-00-TRATA-TELEFONE   ' */
                _.Display($" BI0003S - 50000-00-TRATA-TELEFONE   ");

                /*" -838- DISPLAY ' ERRO SEL TELEFONE (' WS-SQLCODE ')' */

                $" ERRO SEL TELEFONE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -839- DISPLAY ' CODIGO PESSOA: ' WS-COD-PES-ATU */
                _.Display($" CODIGO PESSOA: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}");

                /*" -840- DISPLAY ' TIPO FONE ' IND-TEL */
                _.Display($" TIPO FONE {WS_WORKING.WS_AUXILIARES.IND_TEL}");

                /*" -841- DISPLAY ' SEQ FONE: ' WS-MAX-SEQ-TEL */
                _.Display($" SEQ FONE: {WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL}");

                /*" -842- DISPLAY '***' */
                _.Display($"***");

                /*" -843- MOVE 'ERRO SEL TELEFONE' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO SEL TELEFONE", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -844- GOBACK */

                throw new GoBack();

                /*" -846- END-IF */
            }


            /*" -852- IF (BI0003L-E-DDI(IND-TEL) NOT EQUAL DDI OF DCLPESSOA-TELEFONE) OR (BI0003L-E-DDD(IND-TEL) NOT EQUAL DDD OF DCLPESSOA-TELEFONE) OR (BI0003L-E-NUM-FON(IND-TEL) NOT EQUAL NUM-FONE OF DCLPESSOA-TELEFONE) */

            if ((BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_DDI != PESFONE.DCLPESSOA_TELEFONE.DDI) || (BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_DDD != PESFONE.DCLPESSOA_TELEFONE.DDD) || (BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_NUM_FON != PESFONE.DCLPESSOA_TELEFONE.NUM_FONE))
            {

                /*" -853- PERFORM 51000-00-GRAVA-TELEFONE */

                M_51000_00_GRAVA_TELEFONE_SECTION();

                /*" -855- END-IF */
            }


            /*" -855- . */

        }

        [StopWatch]
        /*" M-50000-00-TRATA-TELEFONE-DB-SELECT-1 */
        public void M_50000_00_TRATA_TELEFONE_DB_SELECT_1()
        {
            /*" -788- EXEC SQL SELECT VALUE(MAX(SEQ_FONE),0) INTO :WS-MAX-SEQ-TEL FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :WS-COD-PES-ATU AND TIPO_FONE = :IND-TEL WITH UR END-EXEC */

            var m_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1 = new M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
                IND_TEL = WS_WORKING.WS_AUXILIARES.IND_TEL.ToString(),
            };

            var executed_1 = M_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1.Execute(m_50000_00_TRATA_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_SEQ_TEL, WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_50000_99_SAIDA*/

        [StopWatch]
        /*" M-50000-00-TRATA-TELEFONE-DB-SELECT-2 */
        public void M_50000_00_TRATA_TELEFONE_DB_SELECT_2()
        {
            /*" -825- EXEC SQL SELECT DDI , DDD , NUM_FONE INTO :DCLPESSOA-TELEFONE.DDI , :DCLPESSOA-TELEFONE.DDD , :DCLPESSOA-TELEFONE.NUM-FONE FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :WS-COD-PES-ATU AND TIPO_FONE = :IND-TEL AND SEQ_FONE = :WS-MAX-SEQ-TEL WITH UR END-EXEC */

            var m_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1 = new M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
                WS_MAX_SEQ_TEL = WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL.ToString(),
                IND_TEL = WS_WORKING.WS_AUXILIARES.IND_TEL.ToString(),
            };

            var executed_1 = M_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1.Execute(m_50000_00_TRATA_TELEFONE_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DDI, PESFONE.DCLPESSOA_TELEFONE.DDI);
                _.Move(executed_1.DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);
                _.Move(executed_1.NUM_FONE, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);
            }


        }

        [StopWatch]
        /*" M-51000-00-GRAVA-TELEFONE-SECTION */
        private void M_51000_00_GRAVA_TELEFONE_SECTION()
        {
            /*" -867- DISPLAY '51000-00-GRAVA-TELEFONE' */
            _.Display($"51000-00-GRAVA-TELEFONE");

            /*" -873- PERFORM M_51000_00_GRAVA_TELEFONE_DB_SELECT_1 */

            M_51000_00_GRAVA_TELEFONE_DB_SELECT_1();

            /*" -878- DISPLAY 'MAX PESSOA_TELEFONE: ' WS-COD-PES-ATU '/' WS-MAX-SEQ-TEL ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA_TELEFONE: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -879- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -882- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -883- MOVE 'ERRO MAX TELEFONE' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX TELEFONE", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -884- DISPLAY '***' */
                _.Display($"***");

                /*" -885- DISPLAY ' BI0003S - 51000-01-GRAVA-TELEFONE   ' */
                _.Display($" BI0003S - 51000-01-GRAVA-TELEFONE   ");

                /*" -886- DISPLAY ' ERRO MAX TELEFONE (' WS-SQLCODE ')' */

                $" ERRO MAX TELEFONE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -887- DISPLAY '***' */
                _.Display($"***");

                /*" -888- MOVE 'ERRO MAX TELEFONE' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX TELEFONE", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -889- GOBACK */

                throw new GoBack();

                /*" -892- END-IF */
            }


            /*" -894- COMPUTE WS-MAX-SEQ-TEL = WS-MAX-SEQ-TEL + 001 */
            WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL.Value = WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL + 001;

            /*" -897- MOVE BI0003L-E-DDI(IND-TEL) TO DDI OF DCLPESSOA-TELEFONE */
            _.Move(BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_DDI, PESFONE.DCLPESSOA_TELEFONE.DDI);

            /*" -900- MOVE BI0003L-E-DDD(IND-TEL) TO DDD OF DCLPESSOA-TELEFONE */
            _.Move(BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_DDD, PESFONE.DCLPESSOA_TELEFONE.DDD);

            /*" -903- MOVE BI0003L-E-NUM-FON(IND-TEL) TO NUM-FONE OF DCLPESSOA-TELEFONE */
            _.Move(BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_NUM_FON, PESFONE.DCLPESSOA_TELEFONE.NUM_FONE);

            /*" -906- MOVE BI0003L-E-SIT-FON(IND-TEL) TO SITUACAO-FONE OF DCLPESSOA-TELEFONE */
            _.Move(BI0003L_LINKAGE.BI0003L_E_TELEFONE[WS_WORKING.WS_AUXILIARES.IND_TEL].BI0003L_E_SIT_FON, PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE);

            /*" -909- MOVE BI0003L-E-COD-USU TO COD-USUARIO OF DCLPESSOA-TELEFONE */
            _.Move(BI0003L_LINKAGE.BI0003L_E_CONTROLE.BI0003L_E_COD_USU, PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO);

            /*" -920- PERFORM M_51000_00_GRAVA_TELEFONE_DB_INSERT_1 */

            M_51000_00_GRAVA_TELEFONE_DB_INSERT_1();

            /*" -927- DISPLAY 'INS PESSOA_TELEFONE: ' WS-COD-PES-ATU '/' IND-TEL '/' WS-MAX-SEQ-TEL ' SQLCODE: ' SQLCODE */

            $"INS PESSOA_TELEFONE: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{WS_WORKING.WS_AUXILIARES.IND_TEL}/{WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -928- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -931- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -932- MOVE 'ERRO INS TELEFONE' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS TELEFONE", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -933- DISPLAY '***' */
                _.Display($"***");

                /*" -934- DISPLAY ' BI0003S - 51000-00-GRAVA-TELEFONE   ' */
                _.Display($" BI0003S - 51000-00-GRAVA-TELEFONE   ");

                /*" -935- DISPLAY ' ERRO INS TELEFONE (' WS-SQLCODE ')' */

                $" ERRO INS TELEFONE ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -936- DISPLAY ' CODIGO PESSOA: ' WS-COD-PES-ATU */
                _.Display($" CODIGO PESSOA: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}");

                /*" -937- DISPLAY ' SEQ FONE: ' WS-MAX-SEQ-TEL */
                _.Display($" SEQ FONE: {WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL}");

                /*" -938- DISPLAY '***' */
                _.Display($"***");

                /*" -939- MOVE 'ERRO INS TELEFONE' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS TELEFONE", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -940- GOBACK */

                throw new GoBack();

                /*" -942- END-IF */
            }


            /*" -942- . */

        }

        [StopWatch]
        /*" M-51000-00-GRAVA-TELEFONE-DB-SELECT-1 */
        public void M_51000_00_GRAVA_TELEFONE_DB_SELECT_1()
        {
            /*" -873- EXEC SQL SELECT VALUE(MAX(SEQ_FONE),0) INTO :WS-MAX-SEQ-TEL FROM SEGUROS.PESSOA_TELEFONE WHERE COD_PESSOA = :WS-COD-PES-ATU WITH UR END-EXEC */

            var m_51000_00_GRAVA_TELEFONE_DB_SELECT_1_Query1 = new M_51000_00_GRAVA_TELEFONE_DB_SELECT_1_Query1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
            };

            var executed_1 = M_51000_00_GRAVA_TELEFONE_DB_SELECT_1_Query1.Execute(m_51000_00_GRAVA_TELEFONE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_SEQ_TEL, WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL);
            }


        }

        [StopWatch]
        /*" M-51000-00-GRAVA-TELEFONE-DB-INSERT-1 */
        public void M_51000_00_GRAVA_TELEFONE_DB_INSERT_1()
        {
            /*" -920- EXEC SQL INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES (:WS-COD-PES-ATU, :IND-TEL, :WS-MAX-SEQ-TEL, :DCLPESSOA-TELEFONE.DDI, :DCLPESSOA-TELEFONE.DDD, :DCLPESSOA-TELEFONE.NUM-FONE, :DCLPESSOA-TELEFONE.SITUACAO-FONE, :DCLPESSOA-TELEFONE.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC */

            var m_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1 = new M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
                IND_TEL = WS_WORKING.WS_AUXILIARES.IND_TEL.ToString(),
                WS_MAX_SEQ_TEL = WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_TEL.ToString(),
                DDI = PESFONE.DCLPESSOA_TELEFONE.DDI.ToString(),
                DDD = PESFONE.DCLPESSOA_TELEFONE.DDD.ToString(),
                NUM_FONE = PESFONE.DCLPESSOA_TELEFONE.NUM_FONE.ToString(),
                SITUACAO_FONE = PESFONE.DCLPESSOA_TELEFONE.SITUACAO_FONE.ToString(),
                COD_USUARIO = PESFONE.DCLPESSOA_TELEFONE.COD_USUARIO.ToString(),
            };

            M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1.Execute(m_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_51000_99_SAIDA*/

        [StopWatch]
        /*" M-70000-00-TRATA-EMAIL-SECTION */
        private void M_70000_00_TRATA_EMAIL_SECTION()
        {
            /*" -954- DISPLAY '70000-00-TRATA-EMAIL    ' */
            _.Display($"70000-00-TRATA-EMAIL    ");

            /*" -955- IF BI0003L-E-LIT-EMA EQUAL SPACES */

            if (BI0003L_LINKAGE.BI0003L_E_EMAIL.BI0003L_E_LIT_EMA.IsEmpty())
            {

                /*" -956- DISPLAY '70000-99-SAIDA' */
                _.Display($"70000-99-SAIDA");

                /*" -957- GO TO 70000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/ //GOTO
                return;

                /*" -959- END-IF */
            }


            /*" -965- PERFORM M_70000_00_TRATA_EMAIL_DB_SELECT_1 */

            M_70000_00_TRATA_EMAIL_DB_SELECT_1();

            /*" -970- DISPLAY 'MAX PESSOA_EMAIL: ' WS-COD-PES-ATU '/' WS-MAX-SEQ-EMA ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA_EMAIL: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -971- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -974- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -975- MOVE 'ERRO MAX EMAIL' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX EMAIL", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -976- DISPLAY '***' */
                _.Display($"***");

                /*" -977- DISPLAY ' BI0003S - 70000-00-TRATA-EMAIL    ' */
                _.Display($" BI0003S - 70000-00-TRATA-EMAIL    ");

                /*" -978- DISPLAY ' ERRO MAX PESSOA_EMAIL (' WS-SQLCODE ')' */

                $" ERRO MAX PESSOA_EMAIL ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -979- DISPLAY '***' */
                _.Display($"***");

                /*" -980- MOVE 'ERRO MAX PESSOA_EMAIL' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX PESSOA_EMAIL", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -981- GOBACK */

                throw new GoBack();

                /*" -983- END-IF */
            }


            /*" -984- IF WS-MAX-SEQ-EMA EQUAL ZEROS */

            if (WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA == 00)
            {

                /*" -985- PERFORM 71000-00-INS-EMAIL */

                M_71000_00_INS_EMAIL_SECTION();

                /*" -986- GO TO 70000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/ //GOTO
                return;

                /*" -989- END-IF */
            }


            /*" -996- PERFORM M_70000_00_TRATA_EMAIL_DB_SELECT_2 */

            M_70000_00_TRATA_EMAIL_DB_SELECT_2();

            /*" -1001- DISPLAY 'SEL PESSOA_EMAIL: ' WS-COD-PES-ATU '/' WS-MAX-SEQ-EMA ' SQLCODE: ' SQLCODE */

            $"SEL PESSOA_EMAIL: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1002- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1005- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -1006- MOVE 'ERRO SEL EMAIL' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO SEL EMAIL", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1007- DISPLAY '***' */
                _.Display($"***");

                /*" -1008- DISPLAY ' 70000-00-TRATA-EMAIL      ' */
                _.Display($" 70000-00-TRATA-EMAIL      ");

                /*" -1009- DISPLAY ' ERRO SEL EMAIL (' WS-SQLCODE ')' */

                $" ERRO SEL EMAIL ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1010- DISPLAY ' CODIGO PESSOA: ' WS-COD-PES-ATU */
                _.Display($" CODIGO PESSOA: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}");

                /*" -1011- DISPLAY ' SEQ EMAIL: ' WS-MAX-SEQ-EMA */
                _.Display($" SEQ EMAIL: {WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA}");

                /*" -1012- DISPLAY '***' */
                _.Display($"***");

                /*" -1013- MOVE 'ERRO SEL PESSOA_EMAIL' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO SEL PESSOA_EMAIL", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1014- GOBACK */

                throw new GoBack();

                /*" -1016- END-IF */
            }


            /*" -1018- IF BI0003L-E-LIT-EMA NOT EQUAL EMAIL OF DCLPESSOA-EMAIL */

            if (BI0003L_LINKAGE.BI0003L_E_EMAIL.BI0003L_E_LIT_EMA != PESEMAIL.DCLPESSOA_EMAIL.EMAIL)
            {

                /*" -1019- PERFORM 71000-00-INS-EMAIL */

                M_71000_00_INS_EMAIL_SECTION();

                /*" -1021- END-IF */
            }


            /*" -1021- . */

        }

        [StopWatch]
        /*" M-70000-00-TRATA-EMAIL-DB-SELECT-1 */
        public void M_70000_00_TRATA_EMAIL_DB_SELECT_1()
        {
            /*" -965- EXEC SQL SELECT VALUE(MAX(SEQ_EMAIL),0) INTO :WS-MAX-SEQ-EMA FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :WS-COD-PES-ATU WITH UR END-EXEC */

            var m_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1 = new M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
            };

            var executed_1 = M_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1.Execute(m_70000_00_TRATA_EMAIL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_SEQ_EMA, WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_70000_99_SAIDA*/

        [StopWatch]
        /*" M-70000-00-TRATA-EMAIL-DB-SELECT-2 */
        public void M_70000_00_TRATA_EMAIL_DB_SELECT_2()
        {
            /*" -996- EXEC SQL SELECT EMAIL INTO :DCLPESSOA-EMAIL.EMAIL FROM SEGUROS.PESSOA_EMAIL WHERE COD_PESSOA = :WS-COD-PES-ATU AND SEQ_EMAIL = :WS-MAX-SEQ-EMA WITH UR END-EXEC */

            var m_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1 = new M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
                WS_MAX_SEQ_EMA = WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA.ToString(),
            };

            var executed_1 = M_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1.Execute(m_70000_00_TRATA_EMAIL_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.EMAIL, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);
            }


        }

        [StopWatch]
        /*" M-71000-00-INS-EMAIL-SECTION */
        private void M_71000_00_INS_EMAIL_SECTION()
        {
            /*" -1032- DISPLAY '71000-00-INS-EMAIL      ' */
            _.Display($"71000-00-INS-EMAIL      ");

            /*" -1035- COMPUTE WS-MAX-SEQ-EMA = WS-MAX-SEQ-EMA + 001 */
            WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA.Value = WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA + 001;

            /*" -1038- MOVE BI0003L-E-LIT-EMA TO EMAIL OF DCLPESSOA-EMAIL */
            _.Move(BI0003L_LINKAGE.BI0003L_E_EMAIL.BI0003L_E_LIT_EMA, PESEMAIL.DCLPESSOA_EMAIL.EMAIL);

            /*" -1042- MOVE BI0003L-E-SIT-EMA TO SITUACAO-EMAIL OF DCLPESSOA-EMAIL */
            _.Move(BI0003L_LINKAGE.BI0003L_E_EMAIL.BI0003L_E_SIT_EMA, PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL);

            /*" -1045- MOVE BI0003L-E-COD-USU TO COD-USUARIO OF DCLPESSOA-EMAIL */
            _.Move(BI0003L_LINKAGE.BI0003L_E_CONTROLE.BI0003L_E_COD_USU, PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO);

            /*" -1053- PERFORM M_71000_00_INS_EMAIL_DB_INSERT_1 */

            M_71000_00_INS_EMAIL_DB_INSERT_1();

            /*" -1058- DISPLAY 'INS PESSOA_EMAIL: ' WS-COD-PES-ATU '/' WS-MAX-SEQ-EMA ' SQLCODE: ' SQLCODE */

            $"INS PESSOA_EMAIL: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1059- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1062- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -1063- MOVE 'ERRO INS EMAIL' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS EMAIL", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1064- DISPLAY '***' */
                _.Display($"***");

                /*" -1065- DISPLAY ' BI0003S - 71000-00-INS-EMAIL        ' */
                _.Display($" BI0003S - 71000-00-INS-EMAIL        ");

                /*" -1066- DISPLAY ' ERRO INS EMAIL (' WS-SQLCODE ')' */

                $" ERRO INS EMAIL ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1067- DISPLAY ' CODIGO PESSOA: ' WS-COD-PES-ATU */
                _.Display($" CODIGO PESSOA: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}");

                /*" -1068- DISPLAY ' SEQ EMAIL: ' WS-MAX-SEQ-EMA */
                _.Display($" SEQ EMAIL: {WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA}");

                /*" -1069- DISPLAY '***' */
                _.Display($"***");

                /*" -1070- MOVE 'ERRO INS PESSOA_EMAIL' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS PESSOA_EMAIL", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1071- GOBACK */

                throw new GoBack();

                /*" -1073- END-IF */
            }


            /*" -1073- . */

        }

        [StopWatch]
        /*" M-71000-00-INS-EMAIL-DB-INSERT-1 */
        public void M_71000_00_INS_EMAIL_DB_INSERT_1()
        {
            /*" -1053- EXEC SQL INSERT INTO SEGUROS.PESSOA_EMAIL VALUES (:WS-COD-PES-ATU, :WS-MAX-SEQ-EMA, :DCLPESSOA-EMAIL.EMAIL, :DCLPESSOA-EMAIL.SITUACAO-EMAIL, :DCLPESSOA-EMAIL.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC */

            var m_71000_00_INS_EMAIL_DB_INSERT_1_Insert1 = new M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
                WS_MAX_SEQ_EMA = WS_WORKING.WS_AUXILIARES.WS_MAX_SEQ_EMA.ToString(),
                EMAIL = PESEMAIL.DCLPESSOA_EMAIL.EMAIL.ToString(),
                SITUACAO_EMAIL = PESEMAIL.DCLPESSOA_EMAIL.SITUACAO_EMAIL.ToString(),
                COD_USUARIO = PESEMAIL.DCLPESSOA_EMAIL.COD_USUARIO.ToString(),
            };

            M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1.Execute(m_71000_00_INS_EMAIL_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_71000_99_SAIDA*/

        [StopWatch]
        /*" M-90000-00-ENDERECO-FIS-SECTION */
        private void M_90000_00_ENDERECO_FIS_SECTION()
        {
            /*" -1084- DISPLAY '90000-00-ENDERECO-FIS      ' */
            _.Display($"90000-00-ENDERECO-FIS      ");

            /*" -1085- IF BI0003L-E-LIT-END-F EQUAL SPACES */

            if (BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_LIT_END_F.IsEmpty())
            {

                /*" -1086- DISPLAY '90000-99-SAIDA' */
                _.Display($"90000-99-SAIDA");

                /*" -1087- GO TO 90000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_90000_99_SAIDA*/ //GOTO
                return;

                /*" -1090- END-IF */
            }


            /*" -1097- PERFORM M_90000_00_ENDERECO_FIS_DB_SELECT_1 */

            M_90000_00_ENDERECO_FIS_DB_SELECT_1();

            /*" -1103- DISPLAY 'MAX PESSOA_END: ' WS-COD-PES-ATU '/' 001 '/' WS-MAX-OCO-END ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA_END: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/001/{WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1104- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1107- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -1108- MOVE 'ERRO MAX ENDERECO' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX ENDERECO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1109- DISPLAY '***' */
                _.Display($"***");

                /*" -1110- DISPLAY ' BI0003S - 90000-00-ENDERECO-FIS         ' */
                _.Display($" BI0003S - 90000-00-ENDERECO-FIS         ");

                /*" -1111- DISPLAY ' ERRO MAX ENDERECO (' WS-SQLCODE ')' */

                $" ERRO MAX ENDERECO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1112- DISPLAY '***' */
                _.Display($"***");

                /*" -1113- MOVE 'ERRO MAX ENDERECO' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX ENDERECO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1114- GOBACK */

                throw new GoBack();

                /*" -1116- END-IF */
            }


            /*" -1117- IF WS-MAX-OCO-END EQUAL ZEROS */

            if (WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END == 00)
            {

                /*" -1118- PERFORM 91000-00-INS-ENDERECO THRU 91000-99-SAIDA */

                M_91000_00_INS_ENDERECO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_91000_99_SAIDA*/


                /*" -1119- GO TO 90000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_90000_99_SAIDA*/ //GOTO
                return;

                /*" -1120- ELSE */
            }
            else
            {


                /*" -1121- MOVE WS-MAX-OCO-END TO BI0003L-S-OCO-END */
                _.Move(WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_OCO_END);

                /*" -1124- END-IF */
            }


            /*" -1132- PERFORM M_90000_00_ENDERECO_FIS_DB_SELECT_2 */

            M_90000_00_ENDERECO_FIS_DB_SELECT_2();

            /*" -1138- DISPLAY 'SEL PESSOA_END: ' WS-COD-PES-ATU '/' CEP OF DCLPESSOA-ENDERECO '/' WS-MAX-OCO-END ' SQLCODE: ' SQLCODE */

            $"SEL PESSOA_END: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{PESENDER.DCLPESSOA_ENDERECO.CEP}/{WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1139- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1142- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -1143- MOVE 'ERRO SEL ENDERECO' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO SEL ENDERECO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1144- DISPLAY '***' */
                _.Display($"***");

                /*" -1145- DISPLAY ' BI0003S - 90000-00-ENDERECO-FIS          ' */
                _.Display($" BI0003S - 90000-00-ENDERECO-FIS          ");

                /*" -1146- DISPLAY ' ERRO SEL ENDERECO (' WS-SQLCODE ')' */

                $" ERRO SEL ENDERECO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1147- DISPLAY ' CODIGO PESSOA: ' WS-MAX-OCO-END */
                _.Display($" CODIGO PESSOA: {WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END}");

                /*" -1148- DISPLAY ' OCORRENCIA: ' WS-MAX-OCO-END */
                _.Display($" OCORRENCIA: {WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END}");

                /*" -1149- DISPLAY '***' */
                _.Display($"***");

                /*" -1150- MOVE 'ERRO SEL ENDERECO' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO SEL ENDERECO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1151- GOBACK */

                throw new GoBack();

                /*" -1153- END-IF */
            }


            /*" -1155- IF CEP OF DCLPESSOA-ENDERECO NOT EQUAL BI0003L-E-COD-CEP-F */

            if (PESENDER.DCLPESSOA_ENDERECO.CEP != BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_COD_CEP_F)
            {

                /*" -1156- PERFORM 91000-00-INS-ENDERECO THRU 91000-99-SAIDA */

                M_91000_00_INS_ENDERECO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_91000_99_SAIDA*/


                /*" -1158- END-IF */
            }


            /*" -1158- . */

        }

        [StopWatch]
        /*" M-90000-00-ENDERECO-FIS-DB-SELECT-1 */
        public void M_90000_00_ENDERECO_FIS_DB_SELECT_1()
        {
            /*" -1097- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :WS-MAX-OCO-END FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :WS-COD-PES-ATU AND TIPO_ENDER = 001 WITH UR END-EXEC */

            var m_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1 = new M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
            };

            var executed_1 = M_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1.Execute(m_90000_00_ENDERECO_FIS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_OCO_END, WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_90000_99_SAIDA*/

        [StopWatch]
        /*" M-90000-00-ENDERECO-FIS-DB-SELECT-2 */
        public void M_90000_00_ENDERECO_FIS_DB_SELECT_2()
        {
            /*" -1132- EXEC SQL SELECT CEP INTO :DCLPESSOA-ENDERECO.CEP FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :WS-COD-PES-ATU AND TIPO_ENDER = 001 AND OCORR_ENDERECO = :WS-MAX-OCO-END WITH UR END-EXEC */

            var m_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1 = new M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
                WS_MAX_OCO_END = WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END.ToString(),
            };

            var executed_1 = M_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1.Execute(m_90000_00_ENDERECO_FIS_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
            }


        }

        [StopWatch]
        /*" M-91000-00-INS-ENDERECO-SECTION */
        private void M_91000_00_INS_ENDERECO_SECTION()
        {
            /*" -1169- DISPLAY '91000-00-INS-ENDERECO ' */
            _.Display($"91000-00-INS-ENDERECO ");

            /*" -1175- PERFORM M_91000_00_INS_ENDERECO_DB_SELECT_1 */

            M_91000_00_INS_ENDERECO_DB_SELECT_1();

            /*" -1180- DISPLAY 'MAX PESSOA_END: ' WS-COD-PES-ATU '/' WS-MAX-OCO-END ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA_END: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1181- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1184- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -1185- MOVE 'ERRO MAX ENDERECO' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX ENDERECO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1186- DISPLAY '***' */
                _.Display($"***");

                /*" -1187- DISPLAY ' BI0003S - 91000-00-INS-ENDERECO      ' */
                _.Display($" BI0003S - 91000-00-INS-ENDERECO      ");

                /*" -1188- DISPLAY ' ERRO MAX ENDERECO (' WS-SQLCODE ')' */

                $" ERRO MAX ENDERECO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1189- DISPLAY '***' */
                _.Display($"***");

                /*" -1190- GOBACK */

                throw new GoBack();

                /*" -1194- END-IF */
            }


            /*" -1197- COMPUTE WS-MAX-OCO-END BI0003L-S-OCO-END = WS-MAX-OCO-END + 001 */
            BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_OCO_END.Value = WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END + 001;
            WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END.Value = WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END + 001;

            /*" -1200- MOVE BI0003L-E-LIT-END-F TO ENDERECO OF DCLPESSOA-ENDERECO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_LIT_END_F, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);

            /*" -1203- MOVE 001 TO TIPO-ENDER OF DCLPESSOA-ENDERECO */
            _.Move(001, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);

            /*" -1206- MOVE BI0003L-E-LIT-BAI-F TO BAIRRO OF DCLPESSOA-ENDERECO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_LIT_BAI_F, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);

            /*" -1209- MOVE BI0003L-E-COD-CEP-F TO CEP OF DCLPESSOA-ENDERECO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_COD_CEP_F, PESENDER.DCLPESSOA_ENDERECO.CEP);

            /*" -1212- MOVE BI0003L-E-LIT-CID-F TO CIDADE OF DCLPESSOA-ENDERECO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_LIT_CID_F, PESENDER.DCLPESSOA_ENDERECO.CIDADE);

            /*" -1215- MOVE BI0003L-E-SIG-UF-F TO SIGLA-UF OF DCLPESSOA-ENDERECO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_ENDERECO_FIS.BI0003L_E_SIG_UF_F, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);

            /*" -1218- MOVE 'A' TO SITUACAO-ENDERECO OF DCLPESSOA-ENDERECO */
            _.Move("A", PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);

            /*" -1222- MOVE BI0003L-E-COD-USU TO COD-USUARIO OF DCLPESSOA-ENDERECO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_CONTROLE.BI0003L_E_COD_USU, PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO);

            /*" -1236- PERFORM M_91000_00_INS_ENDERECO_DB_INSERT_1 */

            M_91000_00_INS_ENDERECO_DB_INSERT_1();

            /*" -1241- DISPLAY 'INS PESSOA_END: ' WS-COD-PES-ATU '/' WS-MAX-OCO-END ' SQLCODE: ' SQLCODE */

            $"INS PESSOA_END: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1242- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1245- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -1246- MOVE 'ERRO INS ENDERECO' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS ENDERECO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1247- DISPLAY '***' */
                _.Display($"***");

                /*" -1248- DISPLAY ' BI0003S - 91000-00-INS-ENDERECO      ' */
                _.Display($" BI0003S - 91000-00-INS-ENDERECO      ");

                /*" -1249- DISPLAY ' ERRO INS ENDERECO (' WS-SQLCODE ')' */

                $" ERRO INS ENDERECO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1250- DISPLAY ' CODIGO PESSOA: ' WS-MAX-OCO-END */
                _.Display($" CODIGO PESSOA: {WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END}");

                /*" -1251- DISPLAY ' OCORRENCIA: ' WS-MAX-OCO-END */
                _.Display($" OCORRENCIA: {WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END}");

                /*" -1252- DISPLAY '***' */
                _.Display($"***");

                /*" -1253- MOVE 'ERRO INS ENDERECO' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS ENDERECO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1254- GOBACK */

                throw new GoBack();

                /*" -1256- END-IF */
            }


            /*" -1256- . */

        }

        [StopWatch]
        /*" M-91000-00-INS-ENDERECO-DB-SELECT-1 */
        public void M_91000_00_INS_ENDERECO_DB_SELECT_1()
        {
            /*" -1175- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :WS-MAX-OCO-END FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :WS-COD-PES-ATU WITH UR END-EXEC */

            var m_91000_00_INS_ENDERECO_DB_SELECT_1_Query1 = new M_91000_00_INS_ENDERECO_DB_SELECT_1_Query1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
            };

            var executed_1 = M_91000_00_INS_ENDERECO_DB_SELECT_1_Query1.Execute(m_91000_00_INS_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_OCO_END, WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END);
            }


        }

        [StopWatch]
        /*" M-91000-00-INS-ENDERECO-DB-INSERT-1 */
        public void M_91000_00_INS_ENDERECO_DB_INSERT_1()
        {
            /*" -1236- EXEC SQL INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES (:WS-COD-PES-ATU, :WS-MAX-OCO-END, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, NULL, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO, :DCLPESSOA-ENDERECO.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC */

            var m_91000_00_INS_ENDERECO_DB_INSERT_1_Insert1 = new M_91000_00_INS_ENDERECO_DB_INSERT_1_Insert1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
                WS_MAX_OCO_END = WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END.ToString(),
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                TIPO_ENDER = PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                SITUACAO_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO.ToString(),
                COD_USUARIO = PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO.ToString(),
            };

            M_91000_00_INS_ENDERECO_DB_INSERT_1_Insert1.Execute(m_91000_00_INS_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_91000_99_SAIDA*/

        [StopWatch]
        /*" B0000-00-ENDERECO-JUR-SECTION */
        private void B0000_00_ENDERECO_JUR_SECTION()
        {
            /*" -1267- DISPLAY 'B0000-00-ENDERECO-JUR       ' */
            _.Display($"B0000-00-ENDERECO-JUR       ");

            /*" -1268- IF BI0003L-E-LIT-END-J EQUAL SPACES */

            if (BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_LIT_END_J.IsEmpty())
            {

                /*" -1269- DISPLAY 'B0000-99-SAIDA' */
                _.Display($"B0000-99-SAIDA");

                /*" -1270- GO TO B0000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B0000_99_SAIDA*/ //GOTO
                return;

                /*" -1273- END-IF */
            }


            /*" -1280- PERFORM B0000_00_ENDERECO_JUR_DB_SELECT_1 */

            B0000_00_ENDERECO_JUR_DB_SELECT_1();

            /*" -1286- DISPLAY 'MAX PESSOA_END: ' WS-COD-PES-ATU '/' 002 '/' WS-MAX-OCO-END ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA_END: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/002/{WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1287- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1290- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -1291- MOVE 'ERRO MAX ENDERECO' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX ENDERECO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1292- DISPLAY '***' */
                _.Display($"***");

                /*" -1293- DISPLAY ' BI0003S - B0000-00-ENDERECO-JUR     ' */
                _.Display($" BI0003S - B0000-00-ENDERECO-JUR     ");

                /*" -1294- DISPLAY ' ERRO MAX ENDERECO (' WS-SQLCODE ')' */

                $" ERRO MAX ENDERECO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1295- DISPLAY '***' */
                _.Display($"***");

                /*" -1296- MOVE 'ERRO MAX ENDERECO JUR' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX ENDERECO JUR", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1297- GOBACK */

                throw new GoBack();

                /*" -1299- END-IF */
            }


            /*" -1300- IF WS-MAX-OCO-END EQUAL ZEROS */

            if (WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END == 00)
            {

                /*" -1301- PERFORM B1000-00-INS-ENDERECO THRU B1000-99-SAIDA */

                B1000_00_INS_ENDERECO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B1000_99_SAIDA*/


                /*" -1302- GO TO B0000-99-SAIDA */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B0000_99_SAIDA*/ //GOTO
                return;

                /*" -1303- ELSE */
            }
            else
            {


                /*" -1304- MOVE WS-MAX-OCO-END TO BI0003L-S-OCO-END */
                _.Move(WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_OCO_END);

                /*" -1307- END-IF */
            }


            /*" -1315- PERFORM B0000_00_ENDERECO_JUR_DB_SELECT_2 */

            B0000_00_ENDERECO_JUR_DB_SELECT_2();

            /*" -1320- DISPLAY 'SEL PESSOA_END: ' WS-COD-PES-ATU '/' WS-MAX-OCO-END ' SQLCODE: ' SQLCODE */

            $"SEL PESSOA_END: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1321- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1324- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -1325- MOVE 'ERRO SEL ENDERECO' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO SEL ENDERECO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1326- DISPLAY '***' */
                _.Display($"***");

                /*" -1327- DISPLAY ' BI0003S - B0000-00-ENDERECO-JUR          ' */
                _.Display($" BI0003S - B0000-00-ENDERECO-JUR          ");

                /*" -1328- DISPLAY ' ERRO SEL ENDERECO (' WS-SQLCODE ')' */

                $" ERRO SEL ENDERECO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1329- DISPLAY ' CODIGO PESSOA: ' WS-MAX-OCO-END */
                _.Display($" CODIGO PESSOA: {WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END}");

                /*" -1330- DISPLAY ' OCORRENCIA: ' WS-MAX-OCO-END */
                _.Display($" OCORRENCIA: {WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END}");

                /*" -1331- DISPLAY '***' */
                _.Display($"***");

                /*" -1332- MOVE 'ERRO SEL ENDERECO JUR' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO SEL ENDERECO JUR", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1333- GOBACK */

                throw new GoBack();

                /*" -1335- END-IF */
            }


            /*" -1337- IF CEP OF DCLPESSOA-ENDERECO NOT EQUAL BI0003L-E-COD-CEP-J */

            if (PESENDER.DCLPESSOA_ENDERECO.CEP != BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_COD_CEP_J)
            {

                /*" -1338- PERFORM B1000-00-INS-ENDERECO THRU B1000-99-SAIDA */

                B1000_00_INS_ENDERECO_SECTION();
                /*Método Suprimido por falta de linha ou apenas EXIT nome: B1000_99_SAIDA*/


                /*" -1340- END-IF */
            }


            /*" -1340- . */

        }

        [StopWatch]
        /*" B0000-00-ENDERECO-JUR-DB-SELECT-1 */
        public void B0000_00_ENDERECO_JUR_DB_SELECT_1()
        {
            /*" -1280- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :WS-MAX-OCO-END FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :WS-COD-PES-ATU AND TIPO_ENDER = 002 WITH UR END-EXEC */

            var b0000_00_ENDERECO_JUR_DB_SELECT_1_Query1 = new B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
            };

            var executed_1 = B0000_00_ENDERECO_JUR_DB_SELECT_1_Query1.Execute(b0000_00_ENDERECO_JUR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_OCO_END, WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B0000_99_SAIDA*/

        [StopWatch]
        /*" B0000-00-ENDERECO-JUR-DB-SELECT-2 */
        public void B0000_00_ENDERECO_JUR_DB_SELECT_2()
        {
            /*" -1315- EXEC SQL SELECT CEP INTO :DCLPESSOA-ENDERECO.CEP FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :WS-COD-PES-ATU AND TIPO_ENDER = 002 AND OCORR_ENDERECO = :WS-MAX-OCO-END WITH UR END-EXEC. */

            var b0000_00_ENDERECO_JUR_DB_SELECT_2_Query1 = new B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
                WS_MAX_OCO_END = WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END.ToString(),
            };

            var executed_1 = B0000_00_ENDERECO_JUR_DB_SELECT_2_Query1.Execute(b0000_00_ENDERECO_JUR_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CEP, PESENDER.DCLPESSOA_ENDERECO.CEP);
            }


        }

        [StopWatch]
        /*" B1000-00-INS-ENDERECO-SECTION */
        private void B1000_00_INS_ENDERECO_SECTION()
        {
            /*" -1351- DISPLAY 'B1000-00-INS-ENDERECO ' */
            _.Display($"B1000-00-INS-ENDERECO ");

            /*" -1357- PERFORM B1000_00_INS_ENDERECO_DB_SELECT_1 */

            B1000_00_INS_ENDERECO_DB_SELECT_1();

            /*" -1362- DISPLAY 'MAX PESSOA_END: ' WS-COD-PES-ATU '/' WS-MAX-OCO-END ' SQLCODE: ' SQLCODE */

            $"MAX PESSOA_END: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1363- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1366- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -1367- MOVE 'ERRO MAX ENDERECO' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO MAX ENDERECO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1368- DISPLAY '***' */
                _.Display($"***");

                /*" -1369- DISPLAY ' BI0003S - B1000-00-INS-ENDERECO     ' */
                _.Display($" BI0003S - B1000-00-INS-ENDERECO     ");

                /*" -1370- DISPLAY ' ERRO MAX ENDERECO (' WS-SQLCODE ')' */

                $" ERRO MAX ENDERECO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1371- DISPLAY '***' */
                _.Display($"***");

                /*" -1372- GOBACK */

                throw new GoBack();

                /*" -1376- END-IF */
            }


            /*" -1379- COMPUTE WS-MAX-OCO-END BI0003L-S-OCO-END = WS-MAX-OCO-END + 001 */
            BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_OCO_END.Value = WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END + 001;
            WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END.Value = WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END + 001;

            /*" -1382- MOVE BI0003L-E-LIT-END-J TO ENDERECO OF DCLPESSOA-ENDERECO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_LIT_END_J, PESENDER.DCLPESSOA_ENDERECO.ENDERECO);

            /*" -1385- MOVE 002 TO TIPO-ENDER OF DCLPESSOA-ENDERECO */
            _.Move(002, PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER);

            /*" -1388- MOVE BI0003L-E-LIT-BAI-J TO BAIRRO OF DCLPESSOA-ENDERECO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_LIT_BAI_J, PESENDER.DCLPESSOA_ENDERECO.BAIRRO);

            /*" -1391- MOVE BI0003L-E-COD-CEP-J TO CEP OF DCLPESSOA-ENDERECO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_COD_CEP_J, PESENDER.DCLPESSOA_ENDERECO.CEP);

            /*" -1394- MOVE BI0003L-E-LIT-CID-J TO CIDADE OF DCLPESSOA-ENDERECO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_LIT_CID_J, PESENDER.DCLPESSOA_ENDERECO.CIDADE);

            /*" -1397- MOVE BI0003L-E-SIG-UF-J TO SIGLA-UF OF DCLPESSOA-ENDERECO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_ENDERECO_JUR.BI0003L_E_SIG_UF_J, PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF);

            /*" -1400- MOVE 'A' TO SITUACAO-ENDERECO OF DCLPESSOA-ENDERECO */
            _.Move("A", PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO);

            /*" -1404- MOVE BI0003L-E-COD-USU TO COD-USUARIO OF DCLPESSOA-ENDERECO */
            _.Move(BI0003L_LINKAGE.BI0003L_E_CONTROLE.BI0003L_E_COD_USU, PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO);

            /*" -1418- PERFORM B1000_00_INS_ENDERECO_DB_INSERT_1 */

            B1000_00_INS_ENDERECO_DB_INSERT_1();

            /*" -1423- DISPLAY 'INS PESSOA_END: ' WS-COD-PES-ATU '/' WS-MAX-OCO-END ' SQLCODE: ' SQLCODE */

            $"INS PESSOA_END: {WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU}/{WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END} SQLCODE: {DB.SQLCODE}"
            .Display();

            /*" -1424- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1427- MOVE SQLCODE TO WS-SQLCODE BI0003L-S-COD-ERR BI0003L-S-COD-SQL */
                _.Move(DB.SQLCODE, WS_WORKING.WS_AUXILIARES.WS_SQLCODE, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_ERR, BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_COD_SQL);

                /*" -1428- MOVE 'ERRO INS ENDERECO' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS ENDERECO", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1429- DISPLAY '***' */
                _.Display($"***");

                /*" -1430- DISPLAY ' BI0003S - B1000-00-INS-ENDERECO' */
                _.Display($" BI0003S - B1000-00-INS-ENDERECO");

                /*" -1431- DISPLAY ' ERRO INS ENDERECO (' WS-SQLCODE ')' */

                $" ERRO INS ENDERECO ({WS_WORKING.WS_AUXILIARES.WS_SQLCODE})"
                .Display();

                /*" -1432- DISPLAY ' CODIGO PESSOA: ' WS-MAX-OCO-END */
                _.Display($" CODIGO PESSOA: {WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END}");

                /*" -1433- DISPLAY ' OCORRENCIA: ' WS-MAX-OCO-END */
                _.Display($" OCORRENCIA: {WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END}");

                /*" -1434- DISPLAY '***' */
                _.Display($"***");

                /*" -1435- MOVE 'ERRO INS ENDERECO JUR' TO BI0003L-S-LIT-ERR */
                _.Move("ERRO INS ENDERECO JUR", BI0003L_LINKAGE.BI0003L_SAIDA.BI0003L_S_LIT_ERR);

                /*" -1436- GOBACK */

                throw new GoBack();

                /*" -1438- END-IF */
            }


            /*" -1438- . */

        }

        [StopWatch]
        /*" B1000-00-INS-ENDERECO-DB-SELECT-1 */
        public void B1000_00_INS_ENDERECO_DB_SELECT_1()
        {
            /*" -1357- EXEC SQL SELECT VALUE(MAX(OCORR_ENDERECO),0) INTO :WS-MAX-OCO-END FROM SEGUROS.PESSOA_ENDERECO WHERE COD_PESSOA = :WS-COD-PES-ATU WITH UR END-EXEC */

            var b1000_00_INS_ENDERECO_DB_SELECT_1_Query1 = new B1000_00_INS_ENDERECO_DB_SELECT_1_Query1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
            };

            var executed_1 = B1000_00_INS_ENDERECO_DB_SELECT_1_Query1.Execute(b1000_00_INS_ENDERECO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WS_MAX_OCO_END, WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END);
            }


        }

        [StopWatch]
        /*" B1000-00-INS-ENDERECO-DB-INSERT-1 */
        public void B1000_00_INS_ENDERECO_DB_INSERT_1()
        {
            /*" -1418- EXEC SQL INSERT INTO SEGUROS.PESSOA_ENDERECO VALUES (:WS-COD-PES-ATU, :WS-MAX-OCO-END, :DCLPESSOA-ENDERECO.ENDERECO, :DCLPESSOA-ENDERECO.TIPO-ENDER, NULL, :DCLPESSOA-ENDERECO.BAIRRO, :DCLPESSOA-ENDERECO.CEP, :DCLPESSOA-ENDERECO.CIDADE, :DCLPESSOA-ENDERECO.SIGLA-UF, :DCLPESSOA-ENDERECO.SITUACAO-ENDERECO, :DCLPESSOA-ENDERECO.COD-USUARIO, CURRENT TIMESTAMP) END-EXEC */

            var b1000_00_INS_ENDERECO_DB_INSERT_1_Insert1 = new B1000_00_INS_ENDERECO_DB_INSERT_1_Insert1()
            {
                WS_COD_PES_ATU = WS_WORKING.WS_AUXILIARES.WS_COD_PES_ATU.ToString(),
                WS_MAX_OCO_END = WS_WORKING.WS_AUXILIARES.WS_MAX_OCO_END.ToString(),
                ENDERECO = PESENDER.DCLPESSOA_ENDERECO.ENDERECO.ToString(),
                TIPO_ENDER = PESENDER.DCLPESSOA_ENDERECO.TIPO_ENDER.ToString(),
                BAIRRO = PESENDER.DCLPESSOA_ENDERECO.BAIRRO.ToString(),
                CEP = PESENDER.DCLPESSOA_ENDERECO.CEP.ToString(),
                CIDADE = PESENDER.DCLPESSOA_ENDERECO.CIDADE.ToString(),
                SIGLA_UF = PESENDER.DCLPESSOA_ENDERECO.SIGLA_UF.ToString(),
                SITUACAO_ENDERECO = PESENDER.DCLPESSOA_ENDERECO.SITUACAO_ENDERECO.ToString(),
                COD_USUARIO = PESENDER.DCLPESSOA_ENDERECO.COD_USUARIO.ToString(),
            };

            B1000_00_INS_ENDERECO_DB_INSERT_1_Insert1.Execute(b1000_00_INS_ENDERECO_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: B1000_99_SAIDA*/
    }
}