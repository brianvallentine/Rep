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
using Sias.Cosseguro.DB2.AC0008B;

namespace Code
{
    public class AC0008B
    {
        public bool IsCall { get; set; }

        public AC0008B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------------------------------                                 */
        /*"      *                                                                       */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  ADMINISTRACAO DE COSSEGURO         *      */
        /*"      *   PROGRAMA ...............  AC0008B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA/PROGRAMADOR....  CARLOS ALBERTO                     *      */
        /*"      *   DATA CODIFICACAO .......  AGOSTO / 1997                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................- CONSISTENCIA DOS DOCUMENTOS DE     *      */
        /*"      *                             COSSEGURO CEDIDO DE BILHETE E      *      */
        /*"      *                             CONVENIO QUE ENTRARAO NO DIA.      *      */
        /*"      *                           - SE EH ENDOSSO OU NAO EH OPERACAO DE*      */
        /*"      *                             EMISSAO, VERIFICAR A NECESSIDADE DE*      */
        /*"      *                             CARREGAR O DOCUMENTO A PARTIR DAS  *      */
        /*"      *                             TABELAS DO EXPURGO DO CTA CORRENTE *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELA                              VIEW              ACESSO   *      */
        /*"      * ----------------------------------- ----------------- -------- *      */
        /*"      * SISTEMAS                            V0SISTEMA         INPUT    *      */
        /*"      * HISTORICO PARCELAS                  V0HISTOPARC       INPUT    *      */
        /*"      * PREMIOS DE COSSEGURO                V0COSSEG_PREM     OUTPUT   *      */
        /*"      * HISTORICO DE COSSEGURO              V0COSSEG_HISTPRE  I-O      *      */
        /*"      * EXPURGO - COSSEG_HISTPRE (CARTUCHO) COSSHIST          INPUT    *      */
        /*"      * EXPURGO - COSSEG_PREM    (CARTUCHO) COSSPREM          INPUT    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * ALTERACAO - PROJETO AUTO                           07/06/2011  *      */
        /*"      *             TROCAR NA ROTINA R0900 O CRITERIO DE PESQUISA      *      */
        /*"      * TE39902     ORGAO > 100 POR  ORGAO > 200.  PROCURAR POR WV1106 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A COLUNA CODIGO DE EMPRESA PARA RECEBER  *      */
        /*"      *              A INFORMACAO DO CODIGO CORRESPONDENTE             *      */
        /*"      * 03/10/2018 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 173142 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *  ALTERACAO - PREPARAR A ROTINA PARA TRATAR/INCLUIR O ORGAO 300 *      */
        /*"      * 21/01/2019 - GILSON PINTO DA SILVA    JAZZ - HISTORIA - 188194 *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _COSSHIST { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis COSSHIST
        {
            get
            {
                _.Move(REG_COSSHIST, _COSSHIST); VarBasis.RedefinePassValue(REG_COSSHIST, _COSSHIST, REG_COSSHIST); return _COSSHIST;
            }
        }
        public FileBasis _COSSPREM { get; set; } = new FileBasis(new PIC("X", "0", "X(0)"));

        public FileBasis COSSPREM
        {
            get
            {
                _.Move(REG_COSSPREM, _COSSPREM); VarBasis.RedefinePassValue(REG_COSSPREM, _COSSPREM, REG_COSSPREM); return _COSSPREM;
            }
        }
        /*"01         REG-COSSHIST.*/
        public AC0008B_REG_COSSHIST REG_COSSHIST { get; set; } = new AC0008B_REG_COSSHIST();
        public class AC0008B_REG_COSSHIST : VarBasis
        {
            /*"  05       CHIST-CONGENER             PIC S9(004)        COMP.*/
            public IntBasis CHIST_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       CHIST-NUM-APOL             PIC S9(013)        COMP-3.*/
            public IntBasis CHIST_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05       CHIST-NRENDOS              PIC S9(009)        COMP.*/
            public IntBasis CHIST_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       CHIST-NRPARCEL             PIC S9(004)        COMP.*/
            public IntBasis CHIST_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       CHIST-OCORHIST             PIC S9(004)        COMP.*/
            public IntBasis CHIST_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       CHIST-OPERACAO             PIC S9(004)        COMP.*/
            public IntBasis CHIST_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       CHIST-DTMOVTO              PIC  9(008)        COMP.*/
            public IntBasis CHIST_DTMOVTO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05       CHIST-PRM-TAR              PIC S9(013)V9(02)  COMP-3.*/
            public DoubleBasis CHIST_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
            /*"  05       CHIST-VAL-DES              PIC S9(013)V9(02)  COMP-3.*/
            public DoubleBasis CHIST_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
            /*"  05       CHIST-VLPRMLIQ             PIC S9(013)V9(02)  COMP-3.*/
            public DoubleBasis CHIST_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
            /*"  05       CHIST-VLADIFRA             PIC S9(013)V9(02)  COMP-3.*/
            public DoubleBasis CHIST_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
            /*"  05       CHIST-VLCOMIS              PIC S9(013)V9(02)  COMP-3.*/
            public DoubleBasis CHIST_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
            /*"  05       CHIST-VLPRMTOT             PIC S9(013)V9(02)  COMP-3.*/
            public DoubleBasis CHIST_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(02)"), 2);
            /*"  05       CHIST-DTQITBCO             PIC  9(008)        COMP.*/
            public IntBasis CHIST_DTQITBCO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05       CHIST-SIT-FINANC           PIC  X(001).*/
            public StringBasis CHIST_SIT_FINANC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       CHIST-SIT-LIBRECUP         PIC  X(001).*/
            public StringBasis CHIST_SIT_LIBRECUP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       CHIST-NUMOCOR              PIC S9(004)        COMP.*/
            public IntBasis CHIST_NUMOCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01         REG-COSSPREM.*/
        }
        public AC0008B_REG_COSSPREM REG_COSSPREM { get; set; } = new AC0008B_REG_COSSPREM();
        public class AC0008B_REG_COSSPREM : VarBasis
        {
            /*"  05       CPREM-CONGENER             PIC S9(004)        COMP.*/
            public IntBasis CPREM_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       CPREM-NUM-ORDEM            PIC S9(015)        COMP-3.*/
            public IntBasis CPREM_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
            /*"  05       CPREM-NUM-APOL             PIC S9(013)        COMP-3.*/
            public IntBasis CPREM_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05       CPREM-NRENDOS              PIC S9(009)        COMP.*/
            public IntBasis CPREM_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  05       CPREM-NRPARCEL             PIC S9(004)        COMP.*/
            public IntBasis CPREM_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"  05       CPREM-PRM-TAR-IX           PIC S9(010)V9(05)  COMP-3.*/
            public DoubleBasis CPREM_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
            /*"  05       CPREM-VAL-DES-IX           PIC S9(010)V9(05)  COMP-3.*/
            public DoubleBasis CPREM_VAL_DES_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
            /*"  05       CPREM-OTNPRLIQ             PIC S9(010)V9(05)  COMP-3.*/
            public DoubleBasis CPREM_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
            /*"  05       CPREM-OTNADFRA             PIC S9(010)V9(05)  COMP-3.*/
            public DoubleBasis CPREM_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
            /*"  05       CPREM-VLCOMISIX            PIC S9(010)V9(05)  COMP-3.*/
            public DoubleBasis CPREM_VLCOMISIX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
            /*"  05       CPREM-OTNTOTAL             PIC S9(010)V9(05)  COMP-3.*/
            public DoubleBasis CPREM_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
            /*"  05       CPREM-SITUACAO             PIC  X(001).*/
            public StringBasis CPREM_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       CPREM-SIT-CONG             PIC  X(001).*/
            public StringBasis CPREM_SIT_CONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"  05       CPREM-OCORHIST             PIC S9(004)        COMP.*/
            public IntBasis CPREM_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77         VIND-OCR-HIST             PIC S9(004)         COMP.*/
        public IntBasis VIND_OCR_HIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-DTQITBCO             PIC S9(004)         COMP.*/
        public IntBasis VIND_DTQITBCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIT-FINC             PIC S9(004)         COMP.*/
        public IntBasis VIND_SIT_FINC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-SIT-LIBR             PIC S9(004)         COMP.*/
        public IntBasis VIND_SIT_LIBR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         VIND-NUM-OCOR             PIC S9(004)         COMP.*/
        public IntBasis VIND_NUM_OCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-COUNT               PIC S9(004)         COMP.*/
        public IntBasis WHOST_COUNT { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0SIST-DTMOVABE           PIC  X(010).*/
        public StringBasis V0SIST_DTMOVABE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0HISP-NUM-APOL           PIC S9(013)         COMP-3.*/
        public IntBasis V0HISP_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0HISP-NRENDOS            PIC S9(009)         COMP.*/
        public IntBasis V0HISP_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0HISP-NRPARCEL           PIC S9(004)         COMP.*/
        public IntBasis V0HISP_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-OCORHIST           PIC S9(004)         COMP.*/
        public IntBasis V0HISP_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-OPERACAO           PIC S9(004)         COMP.*/
        public IntBasis V0HISP_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0HISP-DTMOVTO            PIC  X(010).*/
        public StringBasis V0HISP_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0APOL-NUM-APOL           PIC S9(013)         COMP-3.*/
        public IntBasis V0APOL_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0APOL-RAMO               PIC S9(004)         COMP.*/
        public IntBasis V0APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-NUMBIL             PIC S9(015)         COMP-3.*/
        public IntBasis V0APOL_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0APOL-QTCOSSEG           PIC S9(004)         COMP.*/
        public IntBasis V0APOL_QTCOSSEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0APOL-PCTCED             PIC S9(004)V9(5)    COMP-3.*/
        public DoubleBasis V0APOL_PCTCED { get; set; } = new DoubleBasis(new PIC("S9", "4", "S9(004)V9(5)"), 5);
        /*"77         V0CPRE-COD-EMPR           PIC S9(009)         COMP.*/
        public IntBasis V0CPRE_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CPRE-TIPSGU             PIC  X(001).*/
        public StringBasis V0CPRE_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CPRE-CONGENER           PIC S9(004)         COMP.*/
        public IntBasis V0CPRE_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CPRE-NUM-ORDEM          PIC S9(015)         COMP-3.*/
        public IntBasis V0CPRE_NUM_ORDEM { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         V0CPRE-NUM-APOL           PIC S9(013)         COMP-3.*/
        public IntBasis V0CPRE_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0CPRE-NRENDOS            PIC S9(009)         COMP.*/
        public IntBasis V0CPRE_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CPRE-NRPARCEL           PIC S9(004)         COMP.*/
        public IntBasis V0CPRE_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CPRE-PRM-TAR-IX         PIC S9(010)V9(05)   COMP-3.*/
        public DoubleBasis V0CPRE_PRM_TAR_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77         V0CPRE-VAL-DES-IX         PIC S9(010)V9(05)   COMP-3.*/
        public DoubleBasis V0CPRE_VAL_DES_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77         V0CPRE-OTNPRLIQ           PIC S9(010)V9(05)   COMP-3.*/
        public DoubleBasis V0CPRE_OTNPRLIQ { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77         V0CPRE-OTNADFRA           PIC S9(010)V9(05)   COMP-3.*/
        public DoubleBasis V0CPRE_OTNADFRA { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77         V0CPRE-VLCOMISIX          PIC S9(010)V9(05)   COMP-3.*/
        public DoubleBasis V0CPRE_VLCOMISIX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77         V0CPRE-OTNTOTAL           PIC S9(010)V9(05)   COMP-3.*/
        public DoubleBasis V0CPRE_OTNTOTAL { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(05)"), 5);
        /*"77         V0CPRE-SITUACAO           PIC  X(001).*/
        public StringBasis V0CPRE_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CPRE-SIT-CONG           PIC  X(001).*/
        public StringBasis V0CPRE_SIT_CONG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CPRE-OCORHIST           PIC S9(004)         COMP.*/
        public IntBasis V0CPRE_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-COD-EMPR           PIC S9(009)         COMP.*/
        public IntBasis V0CHIS_COD_EMPR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CHIS-CONGENER           PIC S9(004)         COMP.*/
        public IntBasis V0CHIS_CONGENER { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-NUM-APOL           PIC S9(013)         COMP-3.*/
        public IntBasis V0CHIS_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         V0CHIS-NRENDOS            PIC S9(009)         COMP.*/
        public IntBasis V0CHIS_NRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77         V0CHIS-NRPARCEL           PIC S9(004)         COMP.*/
        public IntBasis V0CHIS_NRPARCEL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-OCORHIST           PIC S9(004)         COMP.*/
        public IntBasis V0CHIS_OCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-OPERACAO           PIC S9(004)         COMP.*/
        public IntBasis V0CHIS_OPERACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         V0CHIS-DTMOVTO            PIC  X(010).*/
        public StringBasis V0CHIS_DTMOVTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CHIS-TIPSGU             PIC  X(001).*/
        public StringBasis V0CHIS_TIPSGU { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CHIS-PRM-TAR            PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHIS_PRM_TAR { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VAL-DES            PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHIS_VAL_DES { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VLPRMLIQ           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHIS_VLPRMLIQ { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VLADIFRA           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHIS_VLADIFRA { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VLCOMIS            PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHIS_VLCOMIS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-VLPRMTOT           PIC S9(013)V99      COMP-3.*/
        public DoubleBasis V0CHIS_VLPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77         V0CHIS-DTQITBCO           PIC  X(010).*/
        public StringBasis V0CHIS_DTQITBCO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         V0CHIS-SIT-FINANC         PIC  X(001).*/
        public StringBasis V0CHIS_SIT_FINANC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CHIS-SIT-LIBRECUP       PIC  X(001).*/
        public StringBasis V0CHIS_SIT_LIBRECUP { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         V0CHIS-NUMOCOR            PIC S9(004)         COMP.*/
        public IntBasis V0CHIS_NUMOCOR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          AREA-DE-WORK.*/
        public AC0008B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new AC0008B_AREA_DE_WORK();
        public class AC0008B_AREA_DE_WORK : VarBasis
        {
            /*"  05       WSTATUS              PIC  9(002)    VALUE ZEROS.*/
            public IntBasis WSTATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05       WFIM-V0HISTOPARC     PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_V0HISTOPARC { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WFIM-COSSHIST        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_COSSHIST { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       WFIM-COSSPREM        PIC  X(001)    VALUE SPACES.*/
            public StringBasis WFIM_COSSPREM { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"  05       AC-L-V0HISTOPARC     PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AC_L_V0HISTOPARC { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05       AC-L-COSSHIST        PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AC_L_COSSHIST { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05       AC-L-COSSPREM        PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AC_L_COSSPREM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05       AC-I-V0COSSEGPREM    PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AC_I_V0COSSEGPREM { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05       AC-I-V0COSSEGHIST    PIC  9(009)    VALUE ZEROS.*/
            public IntBasis AC_I_V0COSSEGHIST { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05       WNUM-APOL-ANT        PIC S9(013)    VALUE +0 COMP-3.*/
            public IntBasis WNUM_APOL_ANT { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
            /*"  05       WHORA-ACCEPT.*/
            public AC0008B_WHORA_ACCEPT WHORA_ACCEPT { get; set; } = new AC0008B_WHORA_ACCEPT();
            public class AC0008B_WHORA_ACCEPT : VarBasis
            {
                /*"    10     WHH-ACCEPT           PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHH_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WMM-ACCEPT           PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WMM_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WSS-ACCEPT           PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WSS_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     WCC-ACCEPT           PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WCC_ACCEPT { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05       WHORA-CABEC.*/
            }
            public AC0008B_WHORA_CABEC WHORA_CABEC { get; set; } = new AC0008B_WHORA_CABEC();
            public class AC0008B_WHORA_CABEC : VarBasis
            {
                /*"    10     WHH-CABEC            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WHH_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     FILLER               PIC  X(001)    VALUE ':'.*/
                public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10     WMM-CABEC            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WMM_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10     FILLER               PIC  X(001)    VALUE ':'.*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @":");
                /*"    10     WSS-CABEC            PIC  9(002)    VALUE ZEROS.*/
                public IntBasis WSS_CABEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  05       WDATA                PIC  9(008)    VALUE ZEROS.*/
            }
            public IntBasis WDATA { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  05       WDATA-R              REDEFINES      WDATA.*/
            private _REDEF_AC0008B_WDATA_R _wdata_r { get; set; }
            public _REDEF_AC0008B_WDATA_R WDATA_R
            {
                get { _wdata_r = new _REDEF_AC0008B_WDATA_R(); _.Move(WDATA, _wdata_r); VarBasis.RedefinePassValue(WDATA, _wdata_r, WDATA); _wdata_r.ValueChanged += () => { _.Move(_wdata_r, WDATA); }; return _wdata_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_r, WDATA); }
            }  //Redefines
            public class _REDEF_AC0008B_WDATA_R : VarBasis
            {
                /*"    10     WDATA-ANO            PIC  9(004).*/
                public IntBasis WDATA_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10     WDATA-MES            PIC  9(002).*/
                public IntBasis WDATA_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10     WDATA-DIA            PIC  9(002).*/
                public IntBasis WDATA_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  05       WDATA-SQL            PIC  X(010)    VALUE SPACES.*/

                public _REDEF_AC0008B_WDATA_R()
                {
                    WDATA_ANO.ValueChanged += OnValueChanged;
                    WDATA_MES.ValueChanged += OnValueChanged;
                    WDATA_DIA.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WDATA_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05       WDATA-SQL-R          REDEFINES      WDATA-SQL.*/
            private _REDEF_AC0008B_WDATA_SQL_R _wdata_sql_r { get; set; }
            public _REDEF_AC0008B_WDATA_SQL_R WDATA_SQL_R
            {
                get { _wdata_sql_r = new _REDEF_AC0008B_WDATA_SQL_R(); _.Move(WDATA_SQL, _wdata_sql_r); VarBasis.RedefinePassValue(WDATA_SQL, _wdata_sql_r, WDATA_SQL); _wdata_sql_r.ValueChanged += () => { _.Move(_wdata_sql_r, WDATA_SQL); }; return _wdata_sql_r; }
                set { VarBasis.RedefinePassValue(value, _wdata_sql_r, WDATA_SQL); }
            }  //Redefines
            public class _REDEF_AC0008B_WDATA_SQL_R : VarBasis
            {
                /*"    10     WDATA-SQL-ANO        PIC  9(004).*/
                public IntBasis WDATA_SQL_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10     WDATA-SQL-T1         PIC  X(001).*/
                public StringBasis WDATA_SQL_T1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10     WDATA-SQL-MES        PIC  9(002).*/
                public IntBasis WDATA_SQL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10     WDATA-SQL-T2         PIC  X(001).*/
                public StringBasis WDATA_SQL_T2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10     WDATA-SQL-DIA        PIC  9(002).*/
                public IntBasis WDATA_SQL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"01         WABEND.*/

                public _REDEF_AC0008B_WDATA_SQL_R()
                {
                    WDATA_SQL_ANO.ValueChanged += OnValueChanged;
                    WDATA_SQL_T1.ValueChanged += OnValueChanged;
                    WDATA_SQL_MES.ValueChanged += OnValueChanged;
                    WDATA_SQL_T2.ValueChanged += OnValueChanged;
                    WDATA_SQL_DIA.ValueChanged += OnValueChanged;
                }

            }
        }
        public AC0008B_WABEND WABEND { get; set; } = new AC0008B_WABEND();
        public class AC0008B_WABEND : VarBasis
        {
            /*"  05       FILLER               PIC  X(010)    VALUE ' AC0008B'.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" AC0008B");
            /*"  05       FILLER               PIC  X(026)    VALUE          ' *** ERRO EXEC SQL NUMERO '.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "26", "X(026)"), @" *** ERRO EXEC SQL NUMERO ");
            /*"  05       WNR-EXEC-SQL         PIC  X(003)    VALUE '000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
            /*"  05       FILLER               PIC  X(013)    VALUE          ' *** SQLCODE '.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05       WSQLCODE             PIC  ZZZZZ999- VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public AC0008B_V0HISTOPARC V0HISTOPARC { get; set; } = new AC0008B_V0HISTOPARC();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string COSSHIST_FILE_NAME_P, string COSSPREM_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                COSSHIST.SetFile(COSSHIST_FILE_NAME_P);
                COSSPREM.SetFile(COSSPREM_FILE_NAME_P);

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
            /*" -302- MOVE '000' TO WNR-EXEC-SQL. */
            _.Move("000", WABEND.WNR_EXEC_SQL);

            /*" -303- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -306- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -309- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -315- PERFORM R0100-00-SELECT-V0SISTEMA. */

            R0100_00_SELECT_V0SISTEMA_SECTION();

            /*" -316- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -317- MOVE WHH-ACCEPT TO WHH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHH_CABEC);

            /*" -318- MOVE WMM-ACCEPT TO WMM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WMM_CABEC);

            /*" -319- MOVE WSS-ACCEPT TO WSS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WSS_CABEC);

            /*" -321- DISPLAY 'INICIO  DECLARE  -  ' WHORA-CABEC. */
            _.Display($"INICIO  DECLARE  -  {AREA_DE_WORK.WHORA_CABEC}");

            /*" -323- PERFORM R0900-00-DECLARE-V0HISTOPARC. */

            R0900_00_DECLARE_V0HISTOPARC_SECTION();

            /*" -324- ACCEPT WHORA-ACCEPT FROM TIME. */
            _.Move(_.AcceptDate("TIME"), AREA_DE_WORK.WHORA_ACCEPT);

            /*" -325- MOVE WHH-ACCEPT TO WHH-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WHH_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WHH_CABEC);

            /*" -326- MOVE WMM-ACCEPT TO WMM-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WMM_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WMM_CABEC);

            /*" -327- MOVE WSS-ACCEPT TO WSS-CABEC. */
            _.Move(AREA_DE_WORK.WHORA_ACCEPT.WSS_ACCEPT, AREA_DE_WORK.WHORA_CABEC.WSS_CABEC);

            /*" -329- DISPLAY 'FIM     DECLARE  -  ' WHORA-CABEC. */
            _.Display($"FIM     DECLARE  -  {AREA_DE_WORK.WHORA_CABEC}");

            /*" -331- PERFORM R0910-00-FETCH-V0HISTOPARC. */

            R0910_00_FETCH_V0HISTOPARC_SECTION();

            /*" -332- IF WFIM-V0HISTOPARC NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_V0HISTOPARC.IsEmpty())
            {

                /*" -333- PERFORM R9900-00-ENCERRA-SEM-MOVTO */

                R9900_00_ENCERRA_SEM_MOVTO_SECTION();

                /*" -337- GO TO R0000-90-FINALIZA. */

                R0000_90_FINALIZA(); //GOTO
                return;
            }


            /*" -339- OPEN INPUT COSSHIST. */
            COSSHIST.Open(REG_COSSHIST, AREA_DE_WORK.WSTATUS);

            /*" -340- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -341- DISPLAY 'R0000- ERRO NA ABERTURA DO ARQUIVO - COSSHIST' */
                _.Display($"R0000- ERRO NA ABERTURA DO ARQUIVO - COSSHIST");

                /*" -343- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -345- PERFORM R0920-00-READ-COSSHIST. */

            R0920_00_READ_COSSHIST_SECTION();

            /*" -346- IF WFIM-COSSHIST NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_COSSHIST.IsEmpty())
            {

                /*" -347- DISPLAY 'R0000- ARQUIVO COSSHIST VAZIO' */
                _.Display($"R0000- ARQUIVO COSSHIST VAZIO");

                /*" -351- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -353- OPEN INPUT COSSPREM. */
            COSSPREM.Open(REG_COSSPREM, AREA_DE_WORK.WSTATUS);

            /*" -354- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -355- DISPLAY 'R0000- ERRO NA ABERTURA DO ARQUIVO - COSSPREM' */
                _.Display($"R0000- ERRO NA ABERTURA DO ARQUIVO - COSSPREM");

                /*" -357- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -359- PERFORM R0930-00-READ-COSSPREM. */

            R0930_00_READ_COSSPREM_SECTION();

            /*" -360- IF WFIM-COSSPREM NOT EQUAL SPACES */

            if (!AREA_DE_WORK.WFIM_COSSPREM.IsEmpty())
            {

                /*" -361- DISPLAY 'R0000- ARQUIVO COSSPREM VAZIO' */
                _.Display($"R0000- ARQUIVO COSSPREM VAZIO");

                /*" -365- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -368- PERFORM R1000-00-PROCESSA-HISTOPARC UNTIL WFIM-V0HISTOPARC NOT EQUAL SPACES. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTOPARC.IsEmpty()))
            {

                R1000_00_PROCESSA_HISTOPARC_SECTION();
            }

            /*" -369- CLOSE COSSHIST COSSPREM. */
            COSSHIST.Close();
            COSSPREM.Close();

            /*" -0- FLUXCONTROL_PERFORM R0000_90_FINALIZA */

            R0000_90_FINALIZA();

        }

        [StopWatch]
        /*" R0000-90-FINALIZA */
        private void R0000_90_FINALIZA(bool isPerform = false)
        {
            /*" -374- DISPLAY 'DOCUMENTOS LIDOS : ' . */
            _.Display($"DOCUMENTOS LIDOS : ");

            /*" -375- DISPLAY ' . HISTORICOS           ' AC-L-V0HISTOPARC. */
            _.Display($" . HISTORICOS           {AREA_DE_WORK.AC_L_V0HISTOPARC}");

            /*" -376- DISPLAY ' . COSSHIST             ' AC-L-COSSHIST. */
            _.Display($" . COSSHIST             {AREA_DE_WORK.AC_L_COSSHIST}");

            /*" -377- DISPLAY ' . COSSPREM             ' AC-L-COSSPREM. */
            _.Display($" . COSSPREM             {AREA_DE_WORK.AC_L_COSSPREM}");

            /*" -378- DISPLAY 'DOCUMENTOS INSERIDOS : ' . */
            _.Display($"DOCUMENTOS INSERIDOS : ");

            /*" -379- DISPLAY ' . PREMIOS COSSEGURO    ' AC-I-V0COSSEGPREM. */
            _.Display($" . PREMIOS COSSEGURO    {AREA_DE_WORK.AC_I_V0COSSEGPREM}");

            /*" -380- DISPLAY ' . HISTORICOS COSSEGURO ' AC-I-V0COSSEGHIST. */
            _.Display($" . HISTORICOS COSSEGURO {AREA_DE_WORK.AC_I_V0COSSEGHIST}");

            /*" -382- DISPLAY '****    AC0008B  -  FIM NORMAL    ****' . */
            _.Display($"****    AC0008B  -  FIM NORMAL    ****");

            /*" -382- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -386- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -386- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-SECTION */
        private void R0100_00_SELECT_V0SISTEMA_SECTION()
        {
            /*" -399- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", WABEND.WNR_EXEC_SQL);

            /*" -404- PERFORM R0100_00_SELECT_V0SISTEMA_DB_SELECT_1 */

            R0100_00_SELECT_V0SISTEMA_DB_SELECT_1();

            /*" -407- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -408- DISPLAY 'R0100 - ERRO NO SELECT V0SISTEMA' */
                _.Display($"R0100 - ERRO NO SELECT V0SISTEMA");

                /*" -409- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -410- ELSE */
            }
            else
            {


                /*" -410- DISPLAY 'DATA DO SISTEMA AC - ' V0SIST-DTMOVABE. */
                _.Display($"DATA DO SISTEMA AC - {V0SIST_DTMOVABE}");
            }


        }

        [StopWatch]
        /*" R0100-00-SELECT-V0SISTEMA-DB-SELECT-1 */
        public void R0100_00_SELECT_V0SISTEMA_DB_SELECT_1()
        {
            /*" -404- EXEC SQL SELECT DTMOVABE INTO :V0SIST-DTMOVABE FROM SEGUROS.V0SISTEMA WHERE IDSISTEM = 'AC' END-EXEC. */

            var r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1 = new R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_V0SISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.V0SIST_DTMOVABE, V0SIST_DTMOVABE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTOPARC-SECTION */
        private void R0900_00_DECLARE_V0HISTOPARC_SECTION()
        {
            /*" -423- MOVE '090' TO WNR-EXEC-SQL. */
            _.Move("090", WABEND.WNR_EXEC_SQL);

            /*" -447- PERFORM R0900_00_DECLARE_V0HISTOPARC_DB_DECLARE_1 */

            R0900_00_DECLARE_V0HISTOPARC_DB_DECLARE_1();

            /*" -449- PERFORM R0900_00_DECLARE_V0HISTOPARC_DB_OPEN_1 */

            R0900_00_DECLARE_V0HISTOPARC_DB_OPEN_1();

            /*" -452- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -453- DISPLAY 'R0900 - ERRO NO DECLARE DA V0HISTOPARC' */
                _.Display($"R0900 - ERRO NO DECLARE DA V0HISTOPARC");

                /*" -454- GO TO R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;

                /*" -455- ELSE */
            }
            else
            {


                /*" -455- MOVE SPACES TO WFIM-V0HISTOPARC. */
                _.Move("", AREA_DE_WORK.WFIM_V0HISTOPARC);
            }


        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTOPARC-DB-DECLARE-1 */
        public void R0900_00_DECLARE_V0HISTOPARC_DB_DECLARE_1()
        {
            /*" -447- EXEC SQL DECLARE V0HISTOPARC CURSOR FOR SELECT A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.OCORHIST , A.OPERACAO , A.DTMOVTO , B.RAMO , B.NUMBIL , B.PCTCED , B.QTCOSSEG FROM SEGUROS.V0HISTOPARC A, SEGUROS.V0APOLICE B WHERE A.DTMOVTO = :V0SIST-DTMOVABE AND A.OPERACAO BETWEEN 0100 AND 0599 AND B.TIPSGU = '1' AND (B.NUMBIL > 0 OR B.ORGAO > 300) AND B.NUM_APOLICE = A.NUM_APOLICE ORDER BY A.NUM_APOLICE , A.NRENDOS , A.NRPARCEL , A.OCORHIST END-EXEC. */
            V0HISTOPARC = new AC0008B_V0HISTOPARC(true);
            string GetQuery_V0HISTOPARC()
            {
                var query = @$"SELECT A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.OCORHIST
							, 
							A.OPERACAO
							, 
							A.DTMOVTO
							, 
							B.RAMO
							, 
							B.NUMBIL
							, 
							B.PCTCED
							, 
							B.QTCOSSEG 
							FROM SEGUROS.V0HISTOPARC A
							, 
							SEGUROS.V0APOLICE B 
							WHERE A.DTMOVTO = '{V0SIST_DTMOVABE}' 
							AND A.OPERACAO BETWEEN 0100 AND 0599 
							AND B.TIPSGU = '1' 
							AND (B.NUMBIL > 0 
							OR B.ORGAO > 300) 
							AND B.NUM_APOLICE = A.NUM_APOLICE 
							ORDER BY A.NUM_APOLICE
							, 
							A.NRENDOS
							, 
							A.NRPARCEL
							, 
							A.OCORHIST";

                return query;
            }
            V0HISTOPARC.GetQueryEvent += GetQuery_V0HISTOPARC;

        }

        [StopWatch]
        /*" R0900-00-DECLARE-V0HISTOPARC-DB-OPEN-1 */
        public void R0900_00_DECLARE_V0HISTOPARC_DB_OPEN_1()
        {
            /*" -449- EXEC SQL OPEN V0HISTOPARC END-EXEC. */

            V0HISTOPARC.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0900_99_SAIDA*/

        [StopWatch]
        /*" R0910-00-FETCH-V0HISTOPARC-SECTION */
        private void R0910_00_FETCH_V0HISTOPARC_SECTION()
        {
            /*" -466- MOVE '910' TO WNR-EXEC-SQL. */
            _.Move("910", WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM R0910_10_LER_V0HISTOPARC */

            R0910_10_LER_V0HISTOPARC();

        }

        [StopWatch]
        /*" R0910-10-LER-V0HISTOPARC */
        private void R0910_10_LER_V0HISTOPARC(bool isPerform = false)
        {
            /*" -481- PERFORM R0910_10_LER_V0HISTOPARC_DB_FETCH_1 */

            R0910_10_LER_V0HISTOPARC_DB_FETCH_1();

            /*" -484- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -485- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -486- MOVE 'S' TO WFIM-V0HISTOPARC */
                    _.Move("S", AREA_DE_WORK.WFIM_V0HISTOPARC);

                    /*" -486- PERFORM R0910_10_LER_V0HISTOPARC_DB_CLOSE_1 */

                    R0910_10_LER_V0HISTOPARC_DB_CLOSE_1();

                    /*" -488- ELSE */
                }
                else
                {


                    /*" -489- DISPLAY 'R0910 - ERRO NO FETCH DA V0HISTOPARC' */
                    _.Display($"R0910 - ERRO NO FETCH DA V0HISTOPARC");

                    /*" -490- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -491- ELSE */
                }

            }
            else
            {


                /*" -492- IF V0APOL-NUMBIL = ZEROS */

                if (V0APOL_NUMBIL == 00)
                {

                    /*" -493- ADD 1 TO AC-L-V0HISTOPARC */
                    AREA_DE_WORK.AC_L_V0HISTOPARC.Value = AREA_DE_WORK.AC_L_V0HISTOPARC + 1;

                    /*" -494- ELSE */
                }
                else
                {


                    /*" -496- IF V0APOL-PCTCED = ZEROS AND V0APOL-QTCOSSEG = ZEROS */

                    if (V0APOL_PCTCED == 00 && V0APOL_QTCOSSEG == 00)
                    {

                        /*" -497- GO TO R0910-10-LER-V0HISTOPARC */
                        new Task(() => R0910_10_LER_V0HISTOPARC()).RunSynchronously(); //GOTO
                        return;//Recursividade detectada, cuidado...

                        /*" -498- ELSE */
                    }
                    else
                    {


                        /*" -498- ADD 1 TO AC-L-V0HISTOPARC. */
                        AREA_DE_WORK.AC_L_V0HISTOPARC.Value = AREA_DE_WORK.AC_L_V0HISTOPARC + 1;
                    }

                }

            }


        }

        [StopWatch]
        /*" R0910-10-LER-V0HISTOPARC-DB-FETCH-1 */
        public void R0910_10_LER_V0HISTOPARC_DB_FETCH_1()
        {
            /*" -481- EXEC SQL FETCH V0HISTOPARC INTO :V0HISP-NUM-APOL , :V0HISP-NRENDOS , :V0HISP-NRPARCEL , :V0HISP-OCORHIST , :V0HISP-OPERACAO , :V0HISP-DTMOVTO , :V0APOL-RAMO , :V0APOL-NUMBIL , :V0APOL-PCTCED , :V0APOL-QTCOSSEG END-EXEC. */

            if (V0HISTOPARC.Fetch())
            {
                _.Move(V0HISTOPARC.V0HISP_NUM_APOL, V0HISP_NUM_APOL);
                _.Move(V0HISTOPARC.V0HISP_NRENDOS, V0HISP_NRENDOS);
                _.Move(V0HISTOPARC.V0HISP_NRPARCEL, V0HISP_NRPARCEL);
                _.Move(V0HISTOPARC.V0HISP_OCORHIST, V0HISP_OCORHIST);
                _.Move(V0HISTOPARC.V0HISP_OPERACAO, V0HISP_OPERACAO);
                _.Move(V0HISTOPARC.V0HISP_DTMOVTO, V0HISP_DTMOVTO);
                _.Move(V0HISTOPARC.V0APOL_RAMO, V0APOL_RAMO);
                _.Move(V0HISTOPARC.V0APOL_NUMBIL, V0APOL_NUMBIL);
                _.Move(V0HISTOPARC.V0APOL_PCTCED, V0APOL_PCTCED);
                _.Move(V0HISTOPARC.V0APOL_QTCOSSEG, V0APOL_QTCOSSEG);
            }

        }

        [StopWatch]
        /*" R0910-10-LER-V0HISTOPARC-DB-CLOSE-1 */
        public void R0910_10_LER_V0HISTOPARC_DB_CLOSE_1()
        {
            /*" -486- EXEC SQL CLOSE V0HISTOPARC END-EXEC */

            V0HISTOPARC.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0910_99_SAIDA*/

        [StopWatch]
        /*" R0920-00-READ-COSSHIST-SECTION */
        private void R0920_00_READ_COSSHIST_SECTION()
        {
            /*" -511- MOVE '092' TO WNR-EXEC-SQL. */
            _.Move("092", WABEND.WNR_EXEC_SQL);

            /*" -512- READ COSSHIST AT END */
            try
            {
                COSSHIST.Read(() =>
                {

                    /*" -513- MOVE 'S' TO WFIM-COSSHIST */
                    _.Move("S", AREA_DE_WORK.WFIM_COSSHIST);

                    /*" -514- MOVE 9999999999999 TO CHIST-NUM-APOL */
                    _.Move(9999999999999, REG_COSSHIST.CHIST_NUM_APOL);

                    /*" -515- DISPLAY 'FIM  -  COSSHIST' */
                    _.Display($"FIM  -  COSSHIST");

                    /*" -517- GO TO R0920-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(COSSHIST.Value, REG_COSSHIST);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -518- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -520- DISPLAY 'R0920 - ERRO NA LEITURA - COSSHIST' ' ' WSTATUS */

                $"R0920 - ERRO NA LEITURA - COSSHIST {AREA_DE_WORK.WSTATUS}"
                .Display();

                /*" -522- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -522- ADD 1 TO AC-L-COSSHIST. */
            AREA_DE_WORK.AC_L_COSSHIST.Value = AREA_DE_WORK.AC_L_COSSHIST + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0920_99_SAIDA*/

        [StopWatch]
        /*" R0930-00-READ-COSSPREM-SECTION */
        private void R0930_00_READ_COSSPREM_SECTION()
        {
            /*" -535- MOVE '093' TO WNR-EXEC-SQL. */
            _.Move("093", WABEND.WNR_EXEC_SQL);

            /*" -536- READ COSSPREM AT END */
            try
            {
                COSSPREM.Read(() =>
                {

                    /*" -537- MOVE 'S' TO WFIM-COSSPREM */
                    _.Move("S", AREA_DE_WORK.WFIM_COSSPREM);

                    /*" -538- MOVE 9999999999999 TO CPREM-NUM-APOL */
                    _.Move(9999999999999, REG_COSSPREM.CPREM_NUM_APOL);

                    /*" -539- DISPLAY 'FIM  -  COSSPREM' */
                    _.Display($"FIM  -  COSSPREM");

                    /*" -541- GO TO R0930-99-SAIDA. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_99_SAIDA*/ //GOTO
                    return;
                });

                _.Move(COSSPREM.Value, REG_COSSPREM);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -542- IF WSTATUS NOT EQUAL ZEROS */

            if (AREA_DE_WORK.WSTATUS != 00)
            {

                /*" -544- DISPLAY 'R0930 - ERRO NA LEITURA - COSSPREM' ' ' WSTATUS */

                $"R0930 - ERRO NA LEITURA - COSSPREM {AREA_DE_WORK.WSTATUS}"
                .Display();

                /*" -546- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -546- ADD 1 TO AC-L-COSSPREM. */
            AREA_DE_WORK.AC_L_COSSPREM.Value = AREA_DE_WORK.AC_L_COSSPREM + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0930_99_SAIDA*/

        [StopWatch]
        /*" R1000-00-PROCESSA-HISTOPARC-SECTION */
        private void R1000_00_PROCESSA_HISTOPARC_SECTION()
        {
            /*" -559- MOVE '100' TO WNR-EXEC-SQL. */
            _.Move("100", WABEND.WNR_EXEC_SQL);

            /*" -561- MOVE V0HISP-NUM-APOL TO WNUM-APOL-ANT. */
            _.Move(V0HISP_NUM_APOL, AREA_DE_WORK.WNUM_APOL_ANT);

            /*" -563- IF V0HISP-NRENDOS EQUAL 0 AND V0HISP-OPERACAO LESS 200 */

            if (V0HISP_NRENDOS == 0 && V0HISP_OPERACAO < 200)
            {

                /*" -567- GO TO R1000-90-LER-REGISTRO. */

                R1000_90_LER_REGISTRO(); //GOTO
                return;
            }


            /*" -569- PERFORM R1300-00-SELECT-V0COSSEGHIST. */

            R1300_00_SELECT_V0COSSEGHIST_SECTION();

            /*" -570- IF WHOST-COUNT NOT = ZEROS */

            if (WHOST_COUNT != 00)
            {

                /*" -572- GO TO R1000-90-LER-REGISTRO. */

                R1000_90_LER_REGISTRO(); //GOTO
                return;
            }


            /*" -574- DISPLAY '----> APOLICE - ' V0HISP-NUM-APOL. */
            _.Display($"----> APOLICE - {V0HISP_NUM_APOL}");

            /*" -578- PERFORM R0920-00-READ-COSSHIST UNTIL WFIM-COSSHIST NOT = SPACES OR CHIST-NUM-APOL = WNUM-APOL-ANT. */

            while (!(!AREA_DE_WORK.WFIM_COSSHIST.IsEmpty() || REG_COSSHIST.CHIST_NUM_APOL == AREA_DE_WORK.WNUM_APOL_ANT))
            {

                R0920_00_READ_COSSHIST_SECTION();
            }

            /*" -579- IF WFIM-COSSHIST NOT = SPACES */

            if (!AREA_DE_WORK.WFIM_COSSHIST.IsEmpty())
            {

                /*" -580- DISPLAY 'R1000- NAO ACHOU A APOLICE - COSSHIST' */
                _.Display($"R1000- NAO ACHOU A APOLICE - COSSHIST");

                /*" -581- DISPLAY 'NUM-APOL ' WNUM-APOL-ANT */
                _.Display($"NUM-APOL {AREA_DE_WORK.WNUM_APOL_ANT}");

                /*" -583- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -585- PERFORM R1500-00-PROCESSA-COSSHIST UNTIL WFIM-COSSHIST NOT = SPACES OR CHIST-NUM-APOL NOT = WNUM-APOL-ANT. */

            while (!(!AREA_DE_WORK.WFIM_COSSHIST.IsEmpty() || REG_COSSHIST.CHIST_NUM_APOL != AREA_DE_WORK.WNUM_APOL_ANT))
            {

                R1500_00_PROCESSA_COSSHIST_SECTION();
            }

            /*" -0- FLUXCONTROL_PERFORM R1000_90_LER_REGISTRO */

            R1000_90_LER_REGISTRO();

        }

        [StopWatch]
        /*" R1000-90-LER-REGISTRO */
        private void R1000_90_LER_REGISTRO(bool isPerform = false)
        {
            /*" -591- PERFORM R0910-00-FETCH-V0HISTOPARC UNTIL WFIM-V0HISTOPARC NOT EQUAL SPACES OR V0HISP-NUM-APOL NOT EQUAL WNUM-APOL-ANT. */

            while (!(!AREA_DE_WORK.WFIM_V0HISTOPARC.IsEmpty() || V0HISP_NUM_APOL != AREA_DE_WORK.WNUM_APOL_ANT))
            {

                R0910_00_FETCH_V0HISTOPARC_SECTION();
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1300-00-SELECT-V0COSSEGHIST-SECTION */
        private void R1300_00_SELECT_V0COSSEGHIST_SECTION()
        {
            /*" -604- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", WABEND.WNR_EXEC_SQL);

            /*" -616- PERFORM R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1 */

            R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1();

            /*" -619- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -620- DISPLAY 'R1300-00 - ERRO NO SELECT DA V0COSSEG_HISTPRE' */
                _.Display($"R1300-00 - ERRO NO SELECT DA V0COSSEG_HISTPRE");

                /*" -621- DISPLAY 'NUM-APOL - ' V0HISP-NUM-APOL */
                _.Display($"NUM-APOL - {V0HISP_NUM_APOL}");

                /*" -621- GO TO R9999-00-ROT-ERRO. */

                R9999_00_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" R1300-00-SELECT-V0COSSEGHIST-DB-SELECT-1 */
        public void R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1()
        {
            /*" -616- EXEC SQL SELECT VALUE(COUNT(*),+0) INTO :WHOST-COUNT FROM SEGUROS.V0COSSEG_HISTPRE WHERE CONGENER IN (5240,5495,5886, 6238,6858) AND NUM_APOLICE = :V0HISP-NUM-APOL AND NRENDOS = 00 AND NRPARCEL IN (00,01) AND OCORHIST = 1 AND OPERACAO < 200 AND TIPSGU = '1' END-EXEC. */

            var r1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1 = new R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1()
            {
                V0HISP_NUM_APOL = V0HISP_NUM_APOL.ToString(),
            };

            var executed_1 = R1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1.Execute(r1300_00_SELECT_V0COSSEGHIST_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_COUNT, WHOST_COUNT);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1300_99_SAIDA*/

        [StopWatch]
        /*" R1500-00-PROCESSA-COSSHIST-SECTION */
        private void R1500_00_PROCESSA_COSSHIST_SECTION()
        {
            /*" -634- MOVE '150' TO WNR-EXEC-SQL. */
            _.Move("150", WABEND.WNR_EXEC_SQL);

            /*" -635- IF CHIST-OPERACAO LESS 200 */

            if (REG_COSSHIST.CHIST_OPERACAO < 200)
            {

                /*" -641- PERFORM R0930-00-READ-COSSPREM UNTIL WFIM-COSSPREM NOT = SPACES OR (CPREM-NUM-APOL = CHIST-NUM-APOL AND CPREM-NRENDOS = CHIST-NRENDOS AND CPREM-NRPARCEL = CHIST-NRPARCEL AND CPREM-CONGENER = CHIST-CONGENER) */

                while (!(!AREA_DE_WORK.WFIM_COSSPREM.IsEmpty() || (REG_COSSPREM.CPREM_NUM_APOL == REG_COSSHIST.CHIST_NUM_APOL && REG_COSSPREM.CPREM_NRENDOS == REG_COSSHIST.CHIST_NRENDOS && REG_COSSPREM.CPREM_NRPARCEL == REG_COSSHIST.CHIST_NRPARCEL && REG_COSSPREM.CPREM_CONGENER == REG_COSSHIST.CHIST_CONGENER)))
                {

                    R0930_00_READ_COSSPREM_SECTION();
                }

                /*" -642- IF WFIM-COSSPREM NOT = SPACES */

                if (!AREA_DE_WORK.WFIM_COSSPREM.IsEmpty())
                {

                    /*" -643- DISPLAY 'R1500- NAO ACHOU DOCUMENTO - COSSPREM' */
                    _.Display($"R1500- NAO ACHOU DOCUMENTO - COSSPREM");

                    /*" -644- DISPLAY 'NUM-APOL ' CHIST-NUM-APOL */
                    _.Display($"NUM-APOL {REG_COSSHIST.CHIST_NUM_APOL}");

                    /*" -645- DISPLAY 'NRENDOS  ' CHIST-NRENDOS */
                    _.Display($"NRENDOS  {REG_COSSHIST.CHIST_NRENDOS}");

                    /*" -646- DISPLAY 'NRPARCEL ' CHIST-NRPARCEL */
                    _.Display($"NRPARCEL {REG_COSSHIST.CHIST_NRPARCEL}");

                    /*" -647- DISPLAY 'CONGENER ' CHIST-CONGENER */
                    _.Display($"CONGENER {REG_COSSHIST.CHIST_CONGENER}");

                    /*" -648- GO TO R9999-00-ROT-ERRO */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -649- ELSE */
                }
                else
                {


                    /*" -650- PERFORM R2100-00-MONTA-V0COSSEGPREM */

                    R2100_00_MONTA_V0COSSEGPREM_SECTION();

                    /*" -652- PERFORM R2300-00-INSERT-V0COSSEGPREM. */

                    R2300_00_INSERT_V0COSSEGPREM_SECTION();
                }

            }


            /*" -654- PERFORM R2500-00-MONTA-V0COSSEGHIST. */

            R2500_00_MONTA_V0COSSEGHIST_SECTION();

            /*" -657- PERFORM R2700-00-INSERT-V0COSSEGHIST. */

            R2700_00_INSERT_V0COSSEGHIST_SECTION();

            /*" -657- PERFORM R0920-00-READ-COSSHIST. */

            R0920_00_READ_COSSHIST_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1500_99_SAIDA*/

        [StopWatch]
        /*" R2100-00-MONTA-V0COSSEGPREM-SECTION */
        private void R2100_00_MONTA_V0COSSEGPREM_SECTION()
        {
            /*" -670- MOVE '210' TO WNR-EXEC-SQL. */
            _.Move("210", WABEND.WNR_EXEC_SQL);

            /*" -671- MOVE ZEROS TO V0CPRE-COD-EMPR. */
            _.Move(0, V0CPRE_COD_EMPR);

            /*" -672- MOVE '1' TO V0CPRE-TIPSGU. */
            _.Move("1", V0CPRE_TIPSGU);

            /*" -673- MOVE CPREM-CONGENER TO V0CPRE-CONGENER. */
            _.Move(REG_COSSPREM.CPREM_CONGENER, V0CPRE_CONGENER);

            /*" -674- MOVE CPREM-NUM-ORDEM TO V0CPRE-NUM-ORDEM. */
            _.Move(REG_COSSPREM.CPREM_NUM_ORDEM, V0CPRE_NUM_ORDEM);

            /*" -675- MOVE CPREM-NUM-APOL TO V0CPRE-NUM-APOL. */
            _.Move(REG_COSSPREM.CPREM_NUM_APOL, V0CPRE_NUM_APOL);

            /*" -676- MOVE CPREM-NRENDOS TO V0CPRE-NRENDOS. */
            _.Move(REG_COSSPREM.CPREM_NRENDOS, V0CPRE_NRENDOS);

            /*" -678- MOVE CPREM-NRPARCEL TO V0CPRE-NRPARCEL. */
            _.Move(REG_COSSPREM.CPREM_NRPARCEL, V0CPRE_NRPARCEL);

            /*" -679- MOVE CPREM-PRM-TAR-IX TO V0CPRE-PRM-TAR-IX. */
            _.Move(REG_COSSPREM.CPREM_PRM_TAR_IX, V0CPRE_PRM_TAR_IX);

            /*" -680- MOVE CPREM-VAL-DES-IX TO V0CPRE-VAL-DES-IX. */
            _.Move(REG_COSSPREM.CPREM_VAL_DES_IX, V0CPRE_VAL_DES_IX);

            /*" -681- MOVE CPREM-OTNPRLIQ TO V0CPRE-OTNPRLIQ. */
            _.Move(REG_COSSPREM.CPREM_OTNPRLIQ, V0CPRE_OTNPRLIQ);

            /*" -682- MOVE CPREM-OTNADFRA TO V0CPRE-OTNADFRA. */
            _.Move(REG_COSSPREM.CPREM_OTNADFRA, V0CPRE_OTNADFRA);

            /*" -683- MOVE CPREM-VLCOMISIX TO V0CPRE-VLCOMISIX. */
            _.Move(REG_COSSPREM.CPREM_VLCOMISIX, V0CPRE_VLCOMISIX);

            /*" -684- MOVE CPREM-OTNTOTAL TO V0CPRE-OTNTOTAL. */
            _.Move(REG_COSSPREM.CPREM_OTNTOTAL, V0CPRE_OTNTOTAL);

            /*" -685- MOVE CPREM-SITUACAO TO V0CPRE-SITUACAO. */
            _.Move(REG_COSSPREM.CPREM_SITUACAO, V0CPRE_SITUACAO);

            /*" -687- MOVE CPREM-SIT-CONG TO V0CPRE-SIT-CONG. */
            _.Move(REG_COSSPREM.CPREM_SIT_CONG, V0CPRE_SIT_CONG);

            /*" -688- IF CPREM-OCORHIST EQUAL 9999 */

            if (REG_COSSPREM.CPREM_OCORHIST == 9999)
            {

                /*" -689- MOVE -1 TO VIND-OCR-HIST */
                _.Move(-1, VIND_OCR_HIST);

                /*" -690- MOVE ZEROS TO V0CPRE-OCORHIST */
                _.Move(0, V0CPRE_OCORHIST);

                /*" -691- ELSE */
            }
            else
            {


                /*" -692- MOVE +1 TO VIND-OCR-HIST */
                _.Move(+1, VIND_OCR_HIST);

                /*" -692- MOVE CPREM-OCORHIST TO V0CPRE-OCORHIST. */
                _.Move(REG_COSSPREM.CPREM_OCORHIST, V0CPRE_OCORHIST);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2100_99_SAIDA*/

        [StopWatch]
        /*" R2300-00-INSERT-V0COSSEGPREM-SECTION */
        private void R2300_00_INSERT_V0COSSEGPREM_SECTION()
        {
            /*" -705- MOVE '230' TO WNR-EXEC-SQL. */
            _.Move("230", WABEND.WNR_EXEC_SQL);

            /*" -724- PERFORM R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1 */

            R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1();

            /*" -727- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -728- DISPLAY 'CONGENER - ' V0CPRE-CONGENER */
                _.Display($"CONGENER - {V0CPRE_CONGENER}");

                /*" -729- DISPLAY 'NUM-APOL - ' V0CPRE-NUM-APOL */
                _.Display($"NUM-APOL - {V0CPRE_NUM_APOL}");

                /*" -730- DISPLAY 'NRENDOS  - ' V0CPRE-NRENDOS */
                _.Display($"NRENDOS  - {V0CPRE_NRENDOS}");

                /*" -731- DISPLAY 'NRPARCEL - ' V0CPRE-NRPARCEL */
                _.Display($"NRPARCEL - {V0CPRE_NRPARCEL}");

                /*" -732- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -733- DISPLAY 'R2300 - REGISTRO DUPLICADO' */
                    _.Display($"R2300 - REGISTRO DUPLICADO");

                    /*" -734- GO TO R2300-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/ //GOTO
                    return;

                    /*" -735- ELSE */
                }
                else
                {


                    /*" -736- DISPLAY 'R2300 - PROBLEMAS NA INSERCAO' */
                    _.Display($"R2300 - PROBLEMAS NA INSERCAO");

                    /*" -738- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -738- ADD 1 TO AC-I-V0COSSEGPREM. */
            AREA_DE_WORK.AC_I_V0COSSEGPREM.Value = AREA_DE_WORK.AC_I_V0COSSEGPREM + 1;

        }

        [StopWatch]
        /*" R2300-00-INSERT-V0COSSEGPREM-DB-INSERT-1 */
        public void R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1()
        {
            /*" -724- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_PREM VALUES (:V0CPRE-COD-EMPR , :V0CPRE-TIPSGU , :V0CPRE-CONGENER , :V0CPRE-NUM-ORDEM , :V0CPRE-NUM-APOL , :V0CPRE-NRENDOS , :V0CPRE-NRPARCEL , :V0CPRE-PRM-TAR-IX , :V0CPRE-VAL-DES-IX , :V0CPRE-OTNPRLIQ , :V0CPRE-OTNADFRA , :V0CPRE-VLCOMISIX , :V0CPRE-OTNTOTAL , :V0CPRE-SITUACAO , :V0CPRE-SIT-CONG , CURRENT TIMESTAMP , :V0CPRE-OCORHIST:VIND-OCR-HIST) END-EXEC. */

            var r2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1 = new R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1()
            {
                V0CPRE_COD_EMPR = V0CPRE_COD_EMPR.ToString(),
                V0CPRE_TIPSGU = V0CPRE_TIPSGU.ToString(),
                V0CPRE_CONGENER = V0CPRE_CONGENER.ToString(),
                V0CPRE_NUM_ORDEM = V0CPRE_NUM_ORDEM.ToString(),
                V0CPRE_NUM_APOL = V0CPRE_NUM_APOL.ToString(),
                V0CPRE_NRENDOS = V0CPRE_NRENDOS.ToString(),
                V0CPRE_NRPARCEL = V0CPRE_NRPARCEL.ToString(),
                V0CPRE_PRM_TAR_IX = V0CPRE_PRM_TAR_IX.ToString(),
                V0CPRE_VAL_DES_IX = V0CPRE_VAL_DES_IX.ToString(),
                V0CPRE_OTNPRLIQ = V0CPRE_OTNPRLIQ.ToString(),
                V0CPRE_OTNADFRA = V0CPRE_OTNADFRA.ToString(),
                V0CPRE_VLCOMISIX = V0CPRE_VLCOMISIX.ToString(),
                V0CPRE_OTNTOTAL = V0CPRE_OTNTOTAL.ToString(),
                V0CPRE_SITUACAO = V0CPRE_SITUACAO.ToString(),
                V0CPRE_SIT_CONG = V0CPRE_SIT_CONG.ToString(),
                V0CPRE_OCORHIST = V0CPRE_OCORHIST.ToString(),
                VIND_OCR_HIST = VIND_OCR_HIST.ToString(),
            };

            R2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1.Execute(r2300_00_INSERT_V0COSSEGPREM_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R2500-00-MONTA-V0COSSEGHIST-SECTION */
        private void R2500_00_MONTA_V0COSSEGHIST_SECTION()
        {
            /*" -751- MOVE '250' TO WNR-EXEC-SQL. */
            _.Move("250", WABEND.WNR_EXEC_SQL);

            /*" -752- MOVE ZEROS TO V0CHIS-COD-EMPR. */
            _.Move(0, V0CHIS_COD_EMPR);

            /*" -753- MOVE CHIST-CONGENER TO V0CHIS-CONGENER. */
            _.Move(REG_COSSHIST.CHIST_CONGENER, V0CHIS_CONGENER);

            /*" -754- MOVE CHIST-NUM-APOL TO V0CHIS-NUM-APOL. */
            _.Move(REG_COSSHIST.CHIST_NUM_APOL, V0CHIS_NUM_APOL);

            /*" -755- MOVE CHIST-NRENDOS TO V0CHIS-NRENDOS. */
            _.Move(REG_COSSHIST.CHIST_NRENDOS, V0CHIS_NRENDOS);

            /*" -756- MOVE CHIST-NRPARCEL TO V0CHIS-NRPARCEL. */
            _.Move(REG_COSSHIST.CHIST_NRPARCEL, V0CHIS_NRPARCEL);

            /*" -757- MOVE CHIST-OCORHIST TO V0CHIS-OCORHIST. */
            _.Move(REG_COSSHIST.CHIST_OCORHIST, V0CHIS_OCORHIST);

            /*" -759- MOVE CHIST-OPERACAO TO V0CHIS-OPERACAO. */
            _.Move(REG_COSSHIST.CHIST_OPERACAO, V0CHIS_OPERACAO);

            /*" -760- MOVE CHIST-DTMOVTO TO WDATA. */
            _.Move(REG_COSSHIST.CHIST_DTMOVTO, AREA_DE_WORK.WDATA);

            /*" -761- MOVE WDATA-ANO TO WDATA-SQL-ANO. */
            _.Move(AREA_DE_WORK.WDATA_R.WDATA_ANO, AREA_DE_WORK.WDATA_SQL_R.WDATA_SQL_ANO);

            /*" -762- MOVE '-' TO WDATA-SQL-T1. */
            _.Move("-", AREA_DE_WORK.WDATA_SQL_R.WDATA_SQL_T1);

            /*" -763- MOVE WDATA-MES TO WDATA-SQL-MES. */
            _.Move(AREA_DE_WORK.WDATA_R.WDATA_MES, AREA_DE_WORK.WDATA_SQL_R.WDATA_SQL_MES);

            /*" -764- MOVE '-' TO WDATA-SQL-T2. */
            _.Move("-", AREA_DE_WORK.WDATA_SQL_R.WDATA_SQL_T2);

            /*" -765- MOVE WDATA-DIA TO WDATA-SQL-DIA. */
            _.Move(AREA_DE_WORK.WDATA_R.WDATA_DIA, AREA_DE_WORK.WDATA_SQL_R.WDATA_SQL_DIA);

            /*" -767- MOVE WDATA-SQL TO V0CHIS-DTMOVTO. */
            _.Move(AREA_DE_WORK.WDATA_SQL, V0CHIS_DTMOVTO);

            /*" -769- MOVE '1' TO V0CHIS-TIPSGU. */
            _.Move("1", V0CHIS_TIPSGU);

            /*" -770- MOVE CHIST-PRM-TAR TO V0CHIS-PRM-TAR. */
            _.Move(REG_COSSHIST.CHIST_PRM_TAR, V0CHIS_PRM_TAR);

            /*" -771- MOVE CHIST-VAL-DES TO V0CHIS-VAL-DES. */
            _.Move(REG_COSSHIST.CHIST_VAL_DES, V0CHIS_VAL_DES);

            /*" -772- MOVE CHIST-VLPRMLIQ TO V0CHIS-VLPRMLIQ. */
            _.Move(REG_COSSHIST.CHIST_VLPRMLIQ, V0CHIS_VLPRMLIQ);

            /*" -773- MOVE CHIST-VLADIFRA TO V0CHIS-VLADIFRA. */
            _.Move(REG_COSSHIST.CHIST_VLADIFRA, V0CHIS_VLADIFRA);

            /*" -774- MOVE CHIST-VLCOMIS TO V0CHIS-VLCOMIS. */
            _.Move(REG_COSSHIST.CHIST_VLCOMIS, V0CHIS_VLCOMIS);

            /*" -776- MOVE CHIST-VLPRMTOT TO V0CHIS-VLPRMTOT. */
            _.Move(REG_COSSHIST.CHIST_VLPRMTOT, V0CHIS_VLPRMTOT);

            /*" -777- IF CHIST-DTQITBCO EQUAL ZEROS */

            if (REG_COSSHIST.CHIST_DTQITBCO == 00)
            {

                /*" -778- MOVE -1 TO VIND-DTQITBCO */
                _.Move(-1, VIND_DTQITBCO);

                /*" -779- MOVE SPACES TO V0CHIS-DTQITBCO */
                _.Move("", V0CHIS_DTQITBCO);

                /*" -780- ELSE */
            }
            else
            {


                /*" -781- MOVE +1 TO VIND-DTQITBCO */
                _.Move(+1, VIND_DTQITBCO);

                /*" -782- MOVE CHIST-DTQITBCO TO WDATA */
                _.Move(REG_COSSHIST.CHIST_DTQITBCO, AREA_DE_WORK.WDATA);

                /*" -783- MOVE WDATA-ANO TO WDATA-SQL-ANO */
                _.Move(AREA_DE_WORK.WDATA_R.WDATA_ANO, AREA_DE_WORK.WDATA_SQL_R.WDATA_SQL_ANO);

                /*" -784- MOVE '-' TO WDATA-SQL-T1 */
                _.Move("-", AREA_DE_WORK.WDATA_SQL_R.WDATA_SQL_T1);

                /*" -785- MOVE WDATA-MES TO WDATA-SQL-MES */
                _.Move(AREA_DE_WORK.WDATA_R.WDATA_MES, AREA_DE_WORK.WDATA_SQL_R.WDATA_SQL_MES);

                /*" -786- MOVE '-' TO WDATA-SQL-T2 */
                _.Move("-", AREA_DE_WORK.WDATA_SQL_R.WDATA_SQL_T2);

                /*" -787- MOVE WDATA-DIA TO WDATA-SQL-DIA */
                _.Move(AREA_DE_WORK.WDATA_R.WDATA_DIA, AREA_DE_WORK.WDATA_SQL_R.WDATA_SQL_DIA);

                /*" -789- MOVE WDATA-SQL TO V0CHIS-DTQITBCO. */
                _.Move(AREA_DE_WORK.WDATA_SQL, V0CHIS_DTQITBCO);
            }


            /*" -790- IF CHIST-SIT-FINANC EQUAL '?' */

            if (REG_COSSHIST.CHIST_SIT_FINANC == "?")
            {

                /*" -791- MOVE -1 TO VIND-SIT-FINC */
                _.Move(-1, VIND_SIT_FINC);

                /*" -792- MOVE SPACES TO V0CHIS-SIT-FINANC */
                _.Move("", V0CHIS_SIT_FINANC);

                /*" -793- ELSE */
            }
            else
            {


                /*" -794- MOVE +1 TO VIND-SIT-FINC */
                _.Move(+1, VIND_SIT_FINC);

                /*" -796- MOVE CHIST-SIT-FINANC TO V0CHIS-SIT-FINANC. */
                _.Move(REG_COSSHIST.CHIST_SIT_FINANC, V0CHIS_SIT_FINANC);
            }


            /*" -797- IF CHIST-SIT-LIBRECUP EQUAL '?' */

            if (REG_COSSHIST.CHIST_SIT_LIBRECUP == "?")
            {

                /*" -798- MOVE -1 TO VIND-SIT-LIBR */
                _.Move(-1, VIND_SIT_LIBR);

                /*" -799- MOVE SPACES TO V0CHIS-SIT-LIBRECUP */
                _.Move("", V0CHIS_SIT_LIBRECUP);

                /*" -800- ELSE */
            }
            else
            {


                /*" -801- MOVE +1 TO VIND-SIT-LIBR */
                _.Move(+1, VIND_SIT_LIBR);

                /*" -803- MOVE CHIST-SIT-LIBRECUP TO V0CHIS-SIT-LIBRECUP. */
                _.Move(REG_COSSHIST.CHIST_SIT_LIBRECUP, V0CHIS_SIT_LIBRECUP);
            }


            /*" -804- IF CHIST-NUMOCOR EQUAL 9999 */

            if (REG_COSSHIST.CHIST_NUMOCOR == 9999)
            {

                /*" -805- MOVE -1 TO VIND-NUM-OCOR */
                _.Move(-1, VIND_NUM_OCOR);

                /*" -806- MOVE ZEROS TO V0CHIS-NUMOCOR */
                _.Move(0, V0CHIS_NUMOCOR);

                /*" -807- ELSE */
            }
            else
            {


                /*" -808- MOVE +1 TO VIND-NUM-OCOR */
                _.Move(+1, VIND_NUM_OCOR);

                /*" -808- MOVE CHIST-NUMOCOR TO V0CHIS-NUMOCOR. */
                _.Move(REG_COSSHIST.CHIST_NUMOCOR, V0CHIS_NUMOCOR);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2500_99_SAIDA*/

        [StopWatch]
        /*" R2700-00-INSERT-V0COSSEGHIST-SECTION */
        private void R2700_00_INSERT_V0COSSEGHIST_SECTION()
        {
            /*" -821- MOVE '270' TO WNR-EXEC-SQL. */
            _.Move("270", WABEND.WNR_EXEC_SQL);

            /*" -843- PERFORM R2700_00_INSERT_V0COSSEGHIST_DB_INSERT_1 */

            R2700_00_INSERT_V0COSSEGHIST_DB_INSERT_1();

            /*" -846- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -852- DISPLAY V0CHIS-CONGENER ' ' V0CHIS-NUM-APOL ' ' V0CHIS-NRENDOS ' ' V0CHIS-NRPARCEL ' ' V0CHIS-OCORHIST ' ' V0CHIS-OPERACAO */

                $"{V0CHIS_CONGENER} {V0CHIS_NUM_APOL} {V0CHIS_NRENDOS} {V0CHIS_NRPARCEL} {V0CHIS_OCORHIST} {V0CHIS_OPERACAO}"
                .Display();

                /*" -853- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -854- DISPLAY '... R2700-00 - REGISTRO DUPLICADO' */
                    _.Display($"... R2700-00 - REGISTRO DUPLICADO");

                    /*" -855- GO TO R2700-99-SAIDA */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/ //GOTO
                    return;

                    /*" -856- ELSE */
                }
                else
                {


                    /*" -857- DISPLAY '... R2700-00 - PROBLEMAS NA INSERCAO' */
                    _.Display($"... R2700-00 - PROBLEMAS NA INSERCAO");

                    /*" -859- GO TO R9999-00-ROT-ERRO. */

                    R9999_00_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -859- ADD 1 TO AC-I-V0COSSEGHIST. */
            AREA_DE_WORK.AC_I_V0COSSEGHIST.Value = AREA_DE_WORK.AC_I_V0COSSEGHIST + 1;

        }

        [StopWatch]
        /*" R2700-00-INSERT-V0COSSEGHIST-DB-INSERT-1 */
        public void R2700_00_INSERT_V0COSSEGHIST_DB_INSERT_1()
        {
            /*" -843- EXEC SQL INSERT INTO SEGUROS.V0COSSEG_HISTPRE VALUES (:V0CHIS-COD-EMPR , :V0CHIS-CONGENER , :V0CHIS-NUM-APOL , :V0CHIS-NRENDOS , :V0CHIS-NRPARCEL , :V0CHIS-OCORHIST , :V0CHIS-OPERACAO , :V0CHIS-DTMOVTO , :V0CHIS-TIPSGU , :V0CHIS-PRM-TAR , :V0CHIS-VAL-DES , :V0CHIS-VLPRMLIQ , :V0CHIS-VLADIFRA , :V0CHIS-VLCOMIS , :V0CHIS-VLPRMTOT , CURRENT TIMESTAMP , :V0CHIS-DTQITBCO:VIND-DTQITBCO , :V0CHIS-SIT-FINANC:VIND-SIT-FINC , :V0CHIS-SIT-LIBRECUP:VIND-SIT-LIBR , :V0CHIS-NUMOCOR:VIND-NUM-OCOR) END-EXEC. */

            var r2700_00_INSERT_V0COSSEGHIST_DB_INSERT_1_Insert1 = new R2700_00_INSERT_V0COSSEGHIST_DB_INSERT_1_Insert1()
            {
                V0CHIS_COD_EMPR = V0CHIS_COD_EMPR.ToString(),
                V0CHIS_CONGENER = V0CHIS_CONGENER.ToString(),
                V0CHIS_NUM_APOL = V0CHIS_NUM_APOL.ToString(),
                V0CHIS_NRENDOS = V0CHIS_NRENDOS.ToString(),
                V0CHIS_NRPARCEL = V0CHIS_NRPARCEL.ToString(),
                V0CHIS_OCORHIST = V0CHIS_OCORHIST.ToString(),
                V0CHIS_OPERACAO = V0CHIS_OPERACAO.ToString(),
                V0CHIS_DTMOVTO = V0CHIS_DTMOVTO.ToString(),
                V0CHIS_TIPSGU = V0CHIS_TIPSGU.ToString(),
                V0CHIS_PRM_TAR = V0CHIS_PRM_TAR.ToString(),
                V0CHIS_VAL_DES = V0CHIS_VAL_DES.ToString(),
                V0CHIS_VLPRMLIQ = V0CHIS_VLPRMLIQ.ToString(),
                V0CHIS_VLADIFRA = V0CHIS_VLADIFRA.ToString(),
                V0CHIS_VLCOMIS = V0CHIS_VLCOMIS.ToString(),
                V0CHIS_VLPRMTOT = V0CHIS_VLPRMTOT.ToString(),
                V0CHIS_DTQITBCO = V0CHIS_DTQITBCO.ToString(),
                VIND_DTQITBCO = VIND_DTQITBCO.ToString(),
                V0CHIS_SIT_FINANC = V0CHIS_SIT_FINANC.ToString(),
                VIND_SIT_FINC = VIND_SIT_FINC.ToString(),
                V0CHIS_SIT_LIBRECUP = V0CHIS_SIT_LIBRECUP.ToString(),
                VIND_SIT_LIBR = VIND_SIT_LIBR.ToString(),
                V0CHIS_NUMOCOR = V0CHIS_NUMOCOR.ToString(),
                VIND_NUM_OCOR = VIND_NUM_OCOR.ToString(),
            };

            R2700_00_INSERT_V0COSSEGHIST_DB_INSERT_1_Insert1.Execute(r2700_00_INSERT_V0COSSEGHIST_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2700_99_SAIDA*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -872- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -873- DISPLAY '*   AC0008B - ATUALIZACAO DB DE COSSEGURO  *' . */
            _.Display($"*   AC0008B - ATUALIZACAO DB DE COSSEGURO  *");

            /*" -874- DISPLAY '*   -------   ----------- -- -- ---------  *' . */
            _.Display($"*   -------   ----------- -- -- ---------  *");

            /*" -875- DISPLAY '*             COSSEGURO CEDIDO             *' . */
            _.Display($"*             COSSEGURO CEDIDO             *");

            /*" -876- DISPLAY '*             --------- ------             *' . */
            _.Display($"*             --------- ------             *");

            /*" -877- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -878- DISPLAY '*   NAO HOUVE MOVIMENTACAO NESTA DATA      *' . */
            _.Display($"*   NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -880- DISPLAY '*              ' V0SIST-DTMOVABE '                    *' . */

            $"*              {V0SIST_DTMOVABE}                    *"
            .Display();

            /*" -880- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -895- CLOSE COSSHIST COSSPREM. */
            COSSHIST.Close();
            COSSPREM.Close();

            /*" -897- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -899- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -899- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -903- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -903- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}