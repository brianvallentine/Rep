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
using Sias.VidaEmGrupo.DB2.VG1601B;

namespace Code
{
    public class VG1601B
    {
        public bool IsCall { get; set; }

        public VG1601B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *--------------  ---------                                              */
        /*"      *                                                                       */
        /*"      ******************************************************************      */
        /*"      *   SISTEMA ................  VG - VIDA EM GRUPO                 *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMA ...............  VG1601B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA................  FREDERICO FONSECA                  *      */
        /*"      *                                                                *      */
        /*"      *   PROGRAMADOR ............  FREDERICO FONSECA                  *      */
        /*"      *                                                                *      */
        /*"      *   DATA CODIFICACAO .......  SETEMBRO / 2002                    *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  MANUTENCAO DE SEGURADOS DE VIDA    *      */
        /*"      *                             EM GRUPO VIA INTERFACE.            *      */
        /*"      *                                  (LAY-OUT VGSASSE)             *      */
        /*"      *                             . CANCELAMENTO DE SEGURADOS.       *      */
        /*"      *                                                                *      */
        /*"      ******************************************************************      */
        /*"      *                                                                *      */
        /*"      *   VERSAO 01 -   NSGD - CADMUS 103659.                          *      */
        /*"      *             -   NOVA SOLUCAO DE GESTAO DE DEPOSITOS            *      */
        /*"      *                                                                *      */
        /*"      *   EM 09/12/2014 - COREON                                       *      */
        /*"      *                                                                *      */
        /*"      *                                       PROCURE POR V.01         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                *      */
        #endregion


        #region VARIABLES

        public FileBasis _ARQUIVO_LEITURA { get; set; } = new FileBasis(new PIC("X", "400", "X(400)"));

        public FileBasis ARQUIVO_LEITURA
        {
            get
            {
                _.Move(REGISTRO_LEITURA, _ARQUIVO_LEITURA); VarBasis.RedefinePassValue(REGISTRO_LEITURA, _ARQUIVO_LEITURA, REGISTRO_LEITURA); return _ARQUIVO_LEITURA;
            }
        }
        /*"01        REGISTRO-LEITURA.*/
        public VG1601B_REGISTRO_LEITURA REGISTRO_LEITURA { get; set; } = new VG1601B_REGISTRO_LEITURA();
        public class VG1601B_REGISTRO_LEITURA : VarBasis
        {
            /*"   05     REG-LEITURA         PIC  X(400).*/
            public StringBasis REG_LEITURA { get; set; } = new StringBasis(new PIC("X", "400", "X(400)."), @"");
        }

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"77       CHAVE-FIM                PIC  9(001)    VALUE  0.*/
        public IntBasis CHAVE_FIM { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"77       FLAG-82                  PIC  9(001)    VALUE  0.*/
        public IntBasis FLAG_82 { get; set; } = new IntBasis(new PIC("9", "1", "9(001)"));
        /*"77       VIND-NOME-RAZAO          PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_NOME_RAZAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-TIPO-PESSOA         PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_TIPO_PESSOA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-IDE-SEXO            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_IDE_SEXO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-EST-CIVIL           PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_EST_CIVIL { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-OCORR-END           PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_OCORR_END { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-ENDERECO            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-BAIRRO              PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_BAIRRO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-CIDADE              PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CIDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-SIGLA-UF            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_SIGLA_UF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-CEP                 PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CEP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-DDD                 PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_DDD { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-TELEFONE            PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_TELEFONE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-FAX                 PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_FAX { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-CGCCPF              PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-DTNASC              PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_DTNASC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       VIND-CODUSU              PIC S9(004)    VALUE +0 COMP-4*/
        public IntBasis VIND_CODUSU { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77       SISTEMAS-DATA-MOVIMENTO  PIC  X(010)    VALUE SPACES.*/
        public StringBasis SISTEMAS_DATA_MOVIMENTO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77       MOVIMVGA-IMP-DMH-ANT     PIC S9(013)V99 COMP-3 VALUE +0*/
        public DoubleBasis MOVIMVGA_IMP_DMH_ANT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  SDATA-ADMISSAO-I           PIC S9(004)      COMP   VALUE +0.*/
        public IntBasis SDATA_ADMISSAO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SDATA-NASCIMENTO-I         PIC S9(004)      COMP   VALUE +0.*/
        public IntBasis SDATA_NASCIMENTO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SCOD-EMPRESA-I             PIC S9(004)      COMP   VALUE +0.*/
        public IntBasis SCOD_EMPRESA_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  SLOT-EMP-SEGURADO-I        PIC S9(004)      COMP   VALUE +0.*/
        public IntBasis SLOT_EMP_SEGURADO_I { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          FATCON-NUM-APOL          PIC S9(013) COMP-3 VALUE +0*/
        public IntBasis FATCON_NUM_APOL { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          FATCON-COD-SUBG          PIC S9(004) COMP   VALUE +0*/
        public IntBasis FATCON_COD_SUBG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          FATCON-DATA-REFER        PIC  X(010) VALUE SPACES.*/
        public StringBasis FATCON_DATA_REFER { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  OCOD-CLIENTE               PIC S9(009)      COMP   VALUE +0.*/
        public IntBasis OCOD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  ONUM-APOLICE               PIC S9(013)      COMP-3 VALUE +0.*/
        public IntBasis ONUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  OCOD-BANCO                 PIC S9(004)      COMP   VALUE +0.*/
        public IntBasis OCOD_BANCO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  OCOD-AGENCIA               PIC S9(004)      COMP   VALUE +0.*/
        public IntBasis OCOD_AGENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  ONUM-CTA-CORRENTE          PIC S9(017)      COMP-3 VALUE +0.*/
        public IntBasis ONUM_CTA_CORRENTE { get; set; } = new IntBasis(new PIC("S9", "17", "S9(017)"));
        /*"77  ODAC-CTA-CORRENTE          PIC X(001).*/
        public StringBasis ODAC_CTA_CORRENTE { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"01          SUBG-NUM-APOLICE         PIC S9(013) COMP-3 VALUE +0*/
        public IntBasis SUBG_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          SUBG-COD-SUBGRUPO        PIC S9(004) COMP   VALUE +0*/
        public IntBasis SUBG_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SUBG-COD-CLIENTE         PIC S9(009) COMP   VALUE +0*/
        public IntBasis SUBG_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          SUBG-OCORR-ENDERECO      PIC S9(004) COMP   VALUE +0*/
        public IntBasis SUBG_OCORR_ENDERECO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SUBG-COD-FONTE           PIC S9(004) COMP   VALUE +0*/
        public IntBasis SUBG_COD_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SUBG-COD-PLANO           PIC S9(004) COMP   VALUE +0*/
        public IntBasis SUBG_COD_PLANO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SUBG-TIPO-PLANO          PIC  X(001) VALUE SPACES.*/
        public StringBasis SUBG_TIPO_PLANO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          SUBG-PLANO-ASSOCIA       PIC  X(001) VALUE SPACES.*/
        public StringBasis SUBG_PLANO_ASSOCIA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          SUBG-FORMA-AVERBA        PIC  X(001) VALUE SPACES.*/
        public StringBasis SUBG_FORMA_AVERBA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          SUBG-PERI-FATURAMENTO    PIC S9(004) COMP   VALUE +0*/
        public IntBasis SUBG_PERI_FATURAMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SUBG-PERI-RENOVACAO      PIC S9(004) COMP   VALUE +0*/
        public IntBasis SUBG_PERI_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SUBG-BCO-COBRANCA        PIC S9(004) COMP   VALUE +0*/
        public IntBasis SUBG_BCO_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SUBG-AGE-COBRANCA        PIC S9(004) COMP   VALUE +0*/
        public IntBasis SUBG_AGE_COBRANCA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          SUBG-DAC-COBRANCA        PIC X(001)  VALUE SPACES.*/
        public StringBasis SUBG_DAC_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          SUBG-TIPO-COBRANCA       PIC X(001)  VALUE SPACES.*/
        public StringBasis SUBG_TIPO_COBRANCA { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01          SUBG-PCT-CONJUGE-VG   PIC S9(003)V99 COMP-3 VALUE +0*/
        public DoubleBasis SUBG_PCT_CONJUGE_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01          SUBG-PCT-CONJUGE-AP   PIC S9(003)V99 COMP-3 VALUE +0*/
        public DoubleBasis SUBG_PCT_CONJUGE_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01          APCO-COD-CORR            PIC S9(009) COMP   VALUE +0*/
        public IntBasis APCO_COD_CORR { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          APOL-COD-CLIENTE         PIC S9(009) COMP   VALUE +0*/
        public IntBasis APOL_COD_CLIENTE { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"01          APOL-NUM-APOLICE         PIC S9(013) COMP-3 VALUE +0*/
        public IntBasis APOL_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"01          APOL-NUM-ITEM            PIC S9(004) COMP   VALUE +0*/
        public IntBasis APOL_NUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          APOL-MODALIDA            PIC S9(004) COMP   VALUE +0*/
        public IntBasis APOL_MODALIDA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          APOL-ORGAO               PIC S9(004) COMP   VALUE +0*/
        public IntBasis APOL_ORGAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          APOL-RAMO                PIC S9(004) COMP   VALUE +0*/
        public IntBasis APOL_RAMO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          APOL-NUMBIL              PIC S9(015) COMP-3 VALUE +0*/
        public IntBasis APOL_NUMBIL { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"01          APOL-TIPAPO              PIC  X(001) VALUE SPACES.*/
        public StringBasis APOL_TIPAPO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"01    COND-QTD-SAL-MORNATU     PIC S9(003)V99   COMP-3  VALUE +0*/
        public DoubleBasis COND_QTD_SAL_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01    COND-QTD-SAL-MORACID     PIC S9(003)V99   COMP-3  VALUE +0*/
        public DoubleBasis COND_QTD_SAL_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01    COND-QTD-SAL-INVPERM     PIC S9(003)V99   COMP-3  VALUE +0*/
        public DoubleBasis COND_QTD_SAL_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01    COND-TAXA-AP-MORACID     PIC S9(003)V9(6) COMP-3  VALUE +0*/
        public DoubleBasis COND_TAXA_AP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
        /*"01    COND-TAXA-AP-INVPERM     PIC S9(003)V9(6) COMP-3  VALUE +0*/
        public DoubleBasis COND_TAXA_AP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
        /*"01    COND-TAXA-AP-AMDS        PIC S9(003)V9(6) COMP-3  VALUE +0*/
        public DoubleBasis COND_TAXA_AP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
        /*"01    COND-TAXA-AP-DH          PIC S9(003)V9(6) COMP-3  VALUE +0*/
        public DoubleBasis COND_TAXA_AP_DH { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
        /*"01    COND-TAXA-AP-DIT         PIC S9(003)V9(6) COMP-3  VALUE +0*/
        public DoubleBasis COND_TAXA_AP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
        /*"01    COND-TAXA-AP             PIC S9(003)V9(6) COMP-3  VALUE +0*/
        public DoubleBasis COND_TAXA_AP { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(6)"), 6);
        /*"01    COND-LIM-CAP-MORNATU     PIC S9(013)V99   COMP-3  VALUE +0*/
        public DoubleBasis COND_LIM_CAP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    COND-LIM-CAP-MORACID     PIC S9(013)V99   COMP-3  VALUE +0*/
        public DoubleBasis COND_LIM_CAP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    COND-LIM-CAP-INVAPER     PIC S9(013)V99   COMP-3  VALUE +0*/
        public DoubleBasis COND_LIM_CAP_INVAPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01    GARAN-ADIC-IEA           PIC S9(005)V99   COMP-3  VALUE +0*/
        public DoubleBasis GARAN_ADIC_IEA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"01    GARAN-ADIC-IPA           PIC S9(005)V99   COMP-3  VALUE +0*/
        public DoubleBasis GARAN_ADIC_IPA { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"01    GARAN-ADIC-IPD           PIC S9(005)V99   COMP-3  VALUE +0*/
        public DoubleBasis GARAN_ADIC_IPD { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"01    GARAN-ADIC-HD            PIC S9(005)V99   COMP-3  VALUE +0*/
        public DoubleBasis GARAN_ADIC_HD { get; set; } = new DoubleBasis(new PIC("S9", "5", "S9(005)V99"), 2);
        /*"01          PLAVG-IMP-MORNATU   PIC S9(013)V99 COMP-3   VALUE +0*/
        public DoubleBasis PLAVG_IMP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          PLAVG-IMP-MORACID   PIC S9(013)V99 COMP-3   VALUE +0*/
        public DoubleBasis PLAVG_IMP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          PLAVG-IMP-INVPERM   PIC S9(013)V99 COMP-3   VALUE +0*/
        public DoubleBasis PLAVG_IMP_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          PLAVG-IMP-AMDS      PIC S9(013)V99 COMP-3   VALUE +0*/
        public DoubleBasis PLAVG_IMP_AMDS { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          PLAVG-IMP-DH        PIC S9(013)V99 COMP-3   VALUE +0*/
        public DoubleBasis PLAVG_IMP_DH { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          PLAVG-IMP-DIT       PIC S9(013)V99 COMP-3   VALUE +0*/
        public DoubleBasis PLAVG_IMP_DIT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          PLAVG-DATA-INIVIG   PIC  X(010) VALUE SPACES.*/
        public StringBasis PLAVG_DATA_INIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"01          FAIXAS-FAIXA        PIC S9(004)      COMP   VALUE +0*/
        public IntBasis FAIXAS_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          FAIXAS-TAXA-VG      PIC S9(003)V9999 COMP-3 VALUE +0*/
        public DoubleBasis FAIXAS_TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999"), 4);
        /*"01          FAIXAE-FAIXA        PIC S9(004)      COMP   VALUE +0*/
        public IntBasis FAIXAE_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          FAIXAE-TAXA-VG      PIC S9(003)V9999 COMP-3 VALUE +0*/
        public DoubleBasis FAIXAE_TAXA_VG { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9999"), 4);
        /*"01          PLAFS-FAIXA         PIC S9(004)      COMP   VALUE +0*/
        public IntBasis PLAFS_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          PLAFS-PRM-VG        PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis PLAFS_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          PLAFS-PRM-AP        PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis PLAFS_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          PLAFS-SALARIO       PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis PLAFS_SALARIO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          PLAFE-FAIXA         PIC S9(004)      COMP   VALUE +0*/
        public IntBasis PLAFE_FAIXA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          PLAFE-PRM-VG        PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis PLAFE_PRM_VG { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          PLAFE-PRM-AP        PIC S9(013)V99   COMP-3 VALUE +0*/
        public DoubleBasis PLAFE_PRM_AP { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01          PLAFE-IDADE         PIC S9(004)      COMP   VALUE +0*/
        public IntBasis PLAFE_IDADE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01       MULTSA-QTD-SAL-MORNATU   PIC S9(003)V99 COMP-3 VALUE +0*/
        public DoubleBasis MULTSA_QTD_SAL_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01       MULTSA-QTD-SAL-MORACID   PIC S9(003)V99 COMP-3 VALUE +0*/
        public DoubleBasis MULTSA_QTD_SAL_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01       MULTSA-QTD-SAL-INVPERM   PIC S9(003)V99 COMP-3 VALUE +0*/
        public DoubleBasis MULTSA_QTD_SAL_INVPERM { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V99"), 2);
        /*"01       MULTSA-LIM-CAP-MORNATU   PIC S9(013)V99 COMP-3 VALUE +0*/
        public DoubleBasis MULTSA_LIM_CAP_MORNATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       MULTSA-LIM-CAP-MORACID   PIC S9(013)V99 COMP-3 VALUE +0*/
        public DoubleBasis MULTSA_LIM_CAP_MORACID { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"01       MULTSA-LIM-CAP-INVAPER   PIC S9(013)V99 COMP-3 VALUE +0*/
        public DoubleBasis MULTSA_LIM_CAP_INVAPER { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77          FONTE-FONTE           PIC S9(004)    COMP   VALUE +0*/
        public IntBasis FONTE_FONTE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          FONTE-PROPAUTOM       PIC S9(009)    COMP   VALUE +0*/
        public IntBasis FONTE_PROPAUTOM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  CNUM-APOLICE             PIC S9(013)      COMP-3    VALUE +0*/
        public IntBasis CNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77  CNRENDOS                 PIC S9(009)      COMP      VALUE +0*/
        public IntBasis CNRENDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  CNUM-ITEM                PIC S9(009)      COMP      VALUE +0*/
        public IntBasis CNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  COCORHIST                PIC S9(004)      COMP      VALUE +0*/
        public IntBasis COCORHIST { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CRAMOFR                  PIC S9(004)      COMP      VALUE +0*/
        public IntBasis CRAMOFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CMODALIFR                PIC S9(004)      COMP      VALUE +0*/
        public IntBasis CMODALIFR { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CCOD-COBERTURA           PIC S9(004)      COMP      VALUE +0*/
        public IntBasis CCOD_COBERTURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CIMP-SEGURADA-IX         PIC S9(013)V99   COMP-3    VALUE +0*/
        public DoubleBasis CIMP_SEGURADA_IX { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
        /*"77  CPRM-TARIFARIO-IX        PIC S9(010)V9(5) COMP-3    VALUE +0*/
        public DoubleBasis CPRM_TARIFARIO_IX { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77  CFATOR-MULTIPLICA        PIC S9(004)      COMP      VALUE +0*/
        public IntBasis CFATOR_MULTIPLICA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  CDATA-INIVIGENCIA        PIC  X(010) VALUE SPACES.*/
        public StringBasis CDATA_INIVIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77  DVLCRUZAD-IMP             PIC S9(010)V9(5) COMP-3   VALUE +0*/
        public DoubleBasis DVLCRUZAD_IMP { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77  DVLCRUZAD-PRM             PIC S9(010)V9(5) COMP-3   VALUE +0*/
        public DoubleBasis DVLCRUZAD_PRM { get; set; } = new DoubleBasis(new PIC("S9", "10", "S9(010)V9(5)"), 5);
        /*"77  COD-PLANO-IN              PIC S9(004)      COMP     VALUE +0*/
        public IntBasis COD_PLANO_IN { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  COD-PLANO-FI              PIC S9(004)      COMP     VALUE +0*/
        public IntBasis COD_PLANO_FI { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-AVERBACAO           PIC S9(004)      COMP     VALUE +0*/
        public IntBasis WDATA_AVERBACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-ADMISSAO            PIC S9(004)      COMP     VALUE +0*/
        public IntBasis WDATA_ADMISSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-INCLUSAO            PIC S9(004)      COMP     VALUE +0*/
        public IntBasis WDATA_INCLUSAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-NASCIMENTO          PIC S9(004)      COMP     VALUE +0*/
        public IntBasis WDATA_NASCIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-FATURA              PIC S9(004)      COMP     VALUE +0*/
        public IntBasis WDATA_FATURA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-REFERENCIA          PIC S9(004)      COMP     VALUE +0*/
        public IntBasis WDATA_REFERENCIA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-MOVIMENTO           PIC S9(004)      COMP     VALUE +0*/
        public IntBasis WDATA_MOVIMENTO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WDATA-MOVIMENTO1          PIC S9(004)      COMP     VALUE +0*/
        public IntBasis WDATA_MOVIMENTO1 { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WCOD-EMPRESA              PIC S9(004)      COMP     VALUE +0*/
        public IntBasis WCOD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WLOT-EMP-SEG              PIC S9(004)      COMP     VALUE +0*/
        public IntBasis WLOT_EMP_SEG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  WNUM-ITEM                 PIC S9(004)      COMP     VALUE +0*/
        public IntBasis WNUM_ITEM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  W-PCT-AUMENTO             PIC S9(003)V9(7) COMP-3 VALUE +0.*/
        public DoubleBasis W_PCT_AUMENTO { get; set; } = new DoubleBasis(new PIC("S9", "3", "S9(003)V9(7)"), 7);
        /*"77          V1CONT-COD-EMPRESA   PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis V1CONT_COD_EMPRESA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1CONT-NUM-APOLICE   PIC S9(013)    VALUE +0 COMP-3.*/
        public IntBasis V1CONT_NUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          V1CONT-COD-SUBGRUPO  PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis V1CONT_COD_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1CONT-NRARQUIVO     PIC S9(004)    VALUE +0 COMP.*/
        public IntBasis V1CONT_NRARQUIVO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          V1CONT-DTGERACAO     PIC  X(010)    VALUE SPACES.*/
        public StringBasis V1CONT_DTGERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V1CONT-DTPROC        PIC  X(010)    VALUE SPACES.*/
        public StringBasis V1CONT_DTPROC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
        /*"77          V1CONT-QTLIDOS       PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis V1CONT_QTLIDOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1CONT-ACEITOS       PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis V1CONT_ACEITOS { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1CONT-REJEITA       PIC S9(009)    VALUE +0 COMP.*/
        public IntBasis V1CONT_REJEITA { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77          V1CONT-SITUACAO      PIC  X(001)    VALUE SPACES.*/
        public StringBasis V1CONT_SITUACAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
        /*"77          WNUM-APOLICE         PIC S9(013) VALUE +0 COMP-3.*/
        public IntBasis WNUM_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77          WSUBGRUPO            PIC S9(004) VALUE +0 COMP.*/
        public IntBasis WSUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77          WDATAREF             PIC  X(010).*/
        public StringBasis WDATAREF { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77  V1PAR-RAMO-VG             PIC S9(009)      COMP  VALUE +0.*/
        public IntBasis V1PAR_RAMO_VG { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  V1PAR-RAMO-AP             PIC S9(009)      COMP  VALUE +0.*/
        public IntBasis V1PAR_RAMO_AP { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
        /*"77  ECOD-MOEDA-IMP            PIC S9(004)      COMP  VALUE +0.*/
        public IntBasis ECOD_MOEDA_IMP { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77  ECOD-MOEDA-PRM            PIC S9(004)      COMP  VALUE +0.*/
        public IntBasis ECOD_MOEDA_PRM { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-CGCCPF         PIC S9(015) COMP-3 VALUE +0.*/
        public IntBasis WHOST_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         WHOST-DTNASC         PIC  X(010).*/
        public StringBasis WHOST_DTNASC { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-DTINIVIG       PIC  X(010).*/
        public StringBasis WHOST_DTINIVIG { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
        /*"77         WHOST-TIPO-SEGURADO  PIC  X(001).*/
        public StringBasis WHOST_TIPO_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"77         WHOST-APOLICE        PIC S9(013) COMP-3 VALUE +0.*/
        public IntBasis WHOST_APOLICE { get; set; } = new IntBasis(new PIC("S9", "13", "S9(013)"));
        /*"77         WHOST-SUBGRUPO       PIC S9(004) COMP   VALUE +0.*/
        public IntBasis WHOST_SUBGRUPO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-NRCERTIF       PIC S9(015) COMP-3 VALUE +0.*/
        public IntBasis WHOST_NRCERTIF { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         WHOST-NRCERTIF-PCP   PIC S9(015) COMP-3 VALUE +0.*/
        public IntBasis WHOST_NRCERTIF_PCP { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         WHOST-NRCERTIF-CNJ   PIC S9(015) COMP-3 VALUE +0.*/
        public IntBasis WHOST_NRCERTIF_CNJ { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         WHOST-NRCERTIF-MOV   PIC S9(015) COMP-3 VALUE +0.*/
        public IntBasis WHOST_NRCERTIF_MOV { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         WHOST-QTDE           PIC S9(004) COMP   VALUE +0.*/
        public IntBasis WHOST_QTDE { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         WHOST-QTDE-SEGVG     PIC S9(004) COMP   VALUE +0.*/
        public IntBasis WHOST_QTDE_SEGVG { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"77         NUMCERVG             PIC S9(015) COMP-3.*/
        public IntBasis NUMCERVG { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         H-NUM-CERTIFICADO    PIC S9(015) COMP-3.*/
        public IntBasis H_NUM_CERTIFICADO { get; set; } = new IntBasis(new PIC("S9", "15", "S9(015)"));
        /*"77         H-DAC-CERTIFICADO    PIC  X(001).*/
        public StringBasis H_DAC_CERTIFICADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
        /*"  01        HEADER-REGISTRO.*/
        public VG1601B_HEADER_REGISTRO HEADER_REGISTRO { get; set; } = new VG1601B_HEADER_REGISTRO();
        public class VG1601B_HEADER_REGISTRO : VarBasis
        {
            /*"    10      HEADER-TIPO-REG     PIC  X(001)   VALUE SPACES.*/
            public StringBasis HEADER_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
            /*"    10      HEADER-IDE-MOVTO    PIC  X(002)   VALUE SPACES.*/
            public StringBasis HEADER_IDE_MOVTO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"    10      HEADER-NOME-EMP     PIC  X(040)   VALUE SPACES.*/
            public StringBasis HEADER_NOME_EMP { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"    10      HEADER-NUM-APOL     PIC  9(013)   VALUE ZEROS.*/
            public IntBasis HEADER_NUM_APOL { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"    10      HEADER-COD-SUBGR    PIC  9(005)   VALUE ZEROS.*/
            public IntBasis HEADER_COD_SUBGR { get; set; } = new IntBasis(new PIC("9", "5", "9(005)"));
            /*"    10      HEADER-DATA-REFER   PIC  9(006)   VALUE ZEROS.*/
            public IntBasis HEADER_DATA_REFER { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"    10      HEADER-DATA-GERACAO PIC  9(008)   VALUE ZEROS.*/
            public IntBasis HEADER_DATA_GERACAO { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"    10      HEADER-NUM-ARQUIVO  PIC  9(004)   VALUE ZEROS.*/
            public IntBasis HEADER_NUM_ARQUIVO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"    10      HEADER-FILLER       PIC  X(321)   VALUE SPACES.*/
            public StringBasis HEADER_FILLER { get; set; } = new StringBasis(new PIC("X", "321", "X(321)"), @"");
            /*"  01        TRANSC-REGISTRO     REDEFINES      HEADER-REGISTRO.*/
        }
        private _REDEF_VG1601B_TRANSC_REGISTRO _transc_registro { get; set; }
        public _REDEF_VG1601B_TRANSC_REGISTRO TRANSC_REGISTRO
        {
            get { _transc_registro = new _REDEF_VG1601B_TRANSC_REGISTRO(); _.Move(HEADER_REGISTRO, _transc_registro); VarBasis.RedefinePassValue(HEADER_REGISTRO, _transc_registro, HEADER_REGISTRO); _transc_registro.ValueChanged += () => { _.Move(_transc_registro, HEADER_REGISTRO); }; return _transc_registro; }
            set { VarBasis.RedefinePassValue(value, _transc_registro, HEADER_REGISTRO); }
        }  //Redefines
        public class _REDEF_VG1601B_TRANSC_REGISTRO : VarBasis
        {
            /*"    10      TRANSC-TIPO-REG     PIC  X(001).*/
            public StringBasis TRANSC_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10      TRANSC-SEQUENCIA    PIC  9(007).*/
            public IntBasis TRANSC_SEQUENCIA { get; set; } = new IntBasis(new PIC("9", "7", "9(007)."));
            /*"    10      TRANSC-MATRICULA    PIC  9(015).*/
            public IntBasis TRANSC_MATRICULA { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"    10      TRANSC-SUBTP-REG    PIC  X(001).*/
            public StringBasis TRANSC_SUBTP_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10      TRANSP-PRINCIPAL.*/
            public VG1601B_TRANSP_PRINCIPAL TRANSP_PRINCIPAL { get; set; } = new VG1601B_TRANSP_PRINCIPAL();
            public class VG1601B_TRANSP_PRINCIPAL : VarBasis
            {
                /*"      15    TRANSP-NOME         PIC  X(040).*/
                public StringBasis TRANSP_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      15    TRANSP-SEXO         PIC  X(001).*/
                public StringBasis TRANSP_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      15    TRANSP-EST-CIVIL    PIC  X(001).*/
                public StringBasis TRANSP_EST_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      15    TRANSP-CPF          PIC  9(011).*/
                public IntBasis TRANSP_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"      15    TRANSP-CPF-R        REDEFINES      TRANSP-CPF.*/
                private _REDEF_VG1601B_TRANSP_CPF_R _transp_cpf_r { get; set; }
                public _REDEF_VG1601B_TRANSP_CPF_R TRANSP_CPF_R
                {
                    get { _transp_cpf_r = new _REDEF_VG1601B_TRANSP_CPF_R(); _.Move(TRANSP_CPF, _transp_cpf_r); VarBasis.RedefinePassValue(TRANSP_CPF, _transp_cpf_r, TRANSP_CPF); _transp_cpf_r.ValueChanged += () => { _.Move(_transp_cpf_r, TRANSP_CPF); }; return _transp_cpf_r; }
                    set { VarBasis.RedefinePassValue(value, _transp_cpf_r, TRANSP_CPF); }
                }  //Redefines
                public class _REDEF_VG1601B_TRANSP_CPF_R : VarBasis
                {
                    /*"        20  TRANSP-NUMCPF       PIC  9(009).*/
                    public IntBasis TRANSP_NUMCPF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                    /*"        20  TRANSP-DACCPF       PIC  9(002).*/
                    public IntBasis TRANSP_DACCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    TRANSP-DTNASC.*/

                    public _REDEF_VG1601B_TRANSP_CPF_R()
                    {
                        TRANSP_NUMCPF.ValueChanged += OnValueChanged;
                        TRANSP_DACCPF.ValueChanged += OnValueChanged;
                    }

                }
                public VG1601B_TRANSP_DTNASC TRANSP_DTNASC { get; set; } = new VG1601B_TRANSP_DTNASC();
                public class VG1601B_TRANSP_DTNASC : VarBasis
                {
                    /*"         20 TRANSP-DIA-NASC     PIC  9(002).*/
                    public IntBasis TRANSP_DIA_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"         20 TRANSP-MES-NASC     PIC  9(002).*/
                    public IntBasis TRANSP_MES_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"         20 TRANSP-ANO-NASC     PIC  9(004).*/
                    public IntBasis TRANSP_ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15    TRANSP-DTADMISS     PIC  9(008).*/
                }
                public IntBasis TRANSP_DTADMISS { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      15    TRANSP-ENDERECO     PIC  X(040).*/
                public StringBasis TRANSP_ENDERECO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      15    TRANSP-BAIRRO       PIC  X(020).*/
                public StringBasis TRANSP_BAIRRO { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      15    TRANSP-CIDADE       PIC  X(020).*/
                public StringBasis TRANSP_CIDADE { get; set; } = new StringBasis(new PIC("X", "20", "X(020)."), @"");
                /*"      15    TRANSP-UF           PIC  X(002).*/
                public StringBasis TRANSP_UF { get; set; } = new StringBasis(new PIC("X", "2", "X(002)."), @"");
                /*"      15    TRANSP-CEP          PIC  9(008).*/
                public IntBasis TRANSP_CEP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      15    TRANSP-CLASSIF      PIC  X(030).*/
                public StringBasis TRANSP_CLASSIF { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"      15    TRANSP-SALARIO      PIC  9(013)V99.*/
                public DoubleBasis TRANSP_SALARIO { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      15    TRANSP-TIPO-SAL     PIC  X(001).*/
                public StringBasis TRANSP_TIPO_SAL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      15    TRANSP-FILLER       PIC  X(008).*/
                public StringBasis TRANSP_FILLER { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
                /*"      15    TRANSP-DTINIVIG     PIC  9(008).*/
                public IntBasis TRANSP_DTINIVIG { get; set; } = new IntBasis(new PIC("9", "8", "9(008)."));
                /*"      15    TRANSP-COD-PLANO    PIC  9(004).*/
                public IntBasis TRANSP_COD_PLANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"      15    TRANSP-AGENCIADOR   PIC  9(009).*/
                public IntBasis TRANSP_AGENCIADOR { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                /*"      15    TRANSP-IS-MORNATU   PIC  9(013)V99.*/
                public DoubleBasis TRANSP_IS_MORNATU { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      15    TRANSP-IS-MORACID   PIC  9(013)V99.*/
                public DoubleBasis TRANSP_IS_MORACID { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      15    TRANSP-IS-INVPERM   PIC  9(013)V99.*/
                public DoubleBasis TRANSP_IS_INVPERM { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      15    TRANSP-IS-AMDS      PIC  9(013)V99.*/
                public DoubleBasis TRANSP_IS_AMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      15    TRANSP-QTD-SAL-NEW  PIC  9(003).*/
                public IntBasis TRANSP_QTD_SAL_NEW { get; set; } = new IntBasis(new PIC("9", "3", "9(003)."));
                /*"      15    TRANSP-RESERVADO    PIC  9(012).*/
                public IntBasis TRANSP_RESERVADO { get; set; } = new IntBasis(new PIC("9", "12", "9(012)."));
                /*"      15    TRANSP-IS-DH        PIC  9(013)V99.*/
                public DoubleBasis TRANSP_IS_DH { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      15    TRANSP-IS-DIT       PIC  9(013)V99.*/
                public DoubleBasis TRANSP_IS_DIT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      15    TRANSP-CUSTO-MES    PIC  9(013)V99.*/
                public DoubleBasis TRANSP_CUSTO_MES { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"      15    TRANSP-PADRAO       PIC  X(001).*/
                public StringBasis TRANSP_PADRAO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      15    TRANSP-LOTACAO      PIC  X(021).*/
                public StringBasis TRANSP_LOTACAO { get; set; } = new StringBasis(new PIC("X", "21", "X(021)."), @"");
                /*"    10      TRANSC-CONJUGE      REDEFINES      TRANSP-PRINCIPAL.*/

                public VG1601B_TRANSP_PRINCIPAL()
                {
                    TRANSP_NOME.ValueChanged += OnValueChanged;
                    TRANSP_SEXO.ValueChanged += OnValueChanged;
                    TRANSP_EST_CIVIL.ValueChanged += OnValueChanged;
                    TRANSP_CPF.ValueChanged += OnValueChanged;
                    TRANSP_CPF_R.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VG1601B_TRANSC_CONJUGE _transc_conjuge { get; set; }
            public _REDEF_VG1601B_TRANSC_CONJUGE TRANSC_CONJUGE
            {
                get { _transc_conjuge = new _REDEF_VG1601B_TRANSC_CONJUGE(); _.Move(TRANSP_PRINCIPAL, _transc_conjuge); VarBasis.RedefinePassValue(TRANSP_PRINCIPAL, _transc_conjuge, TRANSP_PRINCIPAL); _transc_conjuge.ValueChanged += () => { _.Move(_transc_conjuge, TRANSP_PRINCIPAL); }; return _transc_conjuge; }
                set { VarBasis.RedefinePassValue(value, _transc_conjuge, TRANSP_PRINCIPAL); }
            }  //Redefines
            public class _REDEF_VG1601B_TRANSC_CONJUGE : VarBasis
            {
                /*"      15    TRANSC-NOME         PIC  X(040).*/
                public StringBasis TRANSC_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      15    TRANSC-SEXO         PIC  X(001).*/
                public StringBasis TRANSC_SEXO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      15    TRANSC-EST-CIVIL    PIC  X(001).*/
                public StringBasis TRANSC_EST_CIVIL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"      15    TRANSC-CPF          PIC  9(011).*/
                public IntBasis TRANSC_CPF { get; set; } = new IntBasis(new PIC("9", "11", "9(011)."));
                /*"      15    TRANSC-CPF-R        REDEFINES      TRANSC-CPF.*/
                private _REDEF_VG1601B_TRANSC_CPF_R _transc_cpf_r { get; set; }
                public _REDEF_VG1601B_TRANSC_CPF_R TRANSC_CPF_R
                {
                    get { _transc_cpf_r = new _REDEF_VG1601B_TRANSC_CPF_R(); _.Move(TRANSC_CPF, _transc_cpf_r); VarBasis.RedefinePassValue(TRANSC_CPF, _transc_cpf_r, TRANSC_CPF); _transc_cpf_r.ValueChanged += () => { _.Move(_transc_cpf_r, TRANSC_CPF); }; return _transc_cpf_r; }
                    set { VarBasis.RedefinePassValue(value, _transc_cpf_r, TRANSC_CPF); }
                }  //Redefines
                public class _REDEF_VG1601B_TRANSC_CPF_R : VarBasis
                {
                    /*"        20  TRANSC-NUMCPF       PIC  9(009).*/
                    public IntBasis TRANSC_NUMCPF { get; set; } = new IntBasis(new PIC("9", "9", "9(009)."));
                    /*"        20  TRANSC-DACCPF       PIC  9(002).*/
                    public IntBasis TRANSC_DACCPF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15    TRANSC-DTNASC.*/

                    public _REDEF_VG1601B_TRANSC_CPF_R()
                    {
                        TRANSC_NUMCPF.ValueChanged += OnValueChanged;
                        TRANSC_DACCPF.ValueChanged += OnValueChanged;
                    }

                }
                public VG1601B_TRANSC_DTNASC TRANSC_DTNASC { get; set; } = new VG1601B_TRANSC_DTNASC();
                public class VG1601B_TRANSC_DTNASC : VarBasis
                {
                    /*"        20  TRANSC-DIA-NASC     PIC  9(002).*/
                    public IntBasis TRANSC_DIA_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        20  TRANSC-MES-NASC     PIC  9(002).*/
                    public IntBasis TRANSC_MES_NASC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"        20  TRANSC-ANO-NASC     PIC  9(004).*/
                    public IntBasis TRANSC_ANO_NASC { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                    /*"      15    TRANSC-FILLER       PIC  X(315).*/
                }
                public StringBasis TRANSC_FILLER { get; set; } = new StringBasis(new PIC("X", "315", "X(315)."), @"");
                /*"    10      TRANSB-BENEFICIARIO REDEFINES      TRANSP-PRINCIPAL.*/

                public _REDEF_VG1601B_TRANSC_CONJUGE()
                {
                    TRANSC_NOME.ValueChanged += OnValueChanged;
                    TRANSC_SEXO.ValueChanged += OnValueChanged;
                    TRANSC_EST_CIVIL.ValueChanged += OnValueChanged;
                    TRANSC_CPF.ValueChanged += OnValueChanged;
                    TRANSC_CPF_R.ValueChanged += OnValueChanged;
                }

            }
            private _REDEF_VG1601B_TRANSB_BENEFICIARIO _transb_beneficiario { get; set; }
            public _REDEF_VG1601B_TRANSB_BENEFICIARIO TRANSB_BENEFICIARIO
            {
                get { _transb_beneficiario = new _REDEF_VG1601B_TRANSB_BENEFICIARIO(); _.Move(TRANSP_PRINCIPAL, _transb_beneficiario); VarBasis.RedefinePassValue(TRANSP_PRINCIPAL, _transb_beneficiario, TRANSP_PRINCIPAL); _transb_beneficiario.ValueChanged += () => { _.Move(_transb_beneficiario, TRANSP_PRINCIPAL); }; return _transb_beneficiario; }
                set { VarBasis.RedefinePassValue(value, _transb_beneficiario, TRANSP_PRINCIPAL); }
            }  //Redefines
            public class _REDEF_VG1601B_TRANSB_BENEFICIARIO : VarBasis
            {
                /*"      15    TRANSB-SEQBENEF     PIC  9(002).*/
                public IntBasis TRANSB_SEQBENEF { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"      15    TRANSB-NOME         PIC  X(040).*/
                public StringBasis TRANSB_NOME { get; set; } = new StringBasis(new PIC("X", "40", "X(040)."), @"");
                /*"      15    TRANSB-PARENTE      PIC  X(010).*/
                public StringBasis TRANSB_PARENTE { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
                /*"      15    TRANSB-PCPARTIC     PIC  9(003)V99.*/
                public DoubleBasis TRANSB_PCPARTIC { get; set; } = new DoubleBasis(new PIC("9", "3", "9(003)V99."), 2);
                /*"      15    TRANSB-FILLER       PIC  X(319).*/
                public StringBasis TRANSB_FILLER { get; set; } = new StringBasis(new PIC("X", "319", "X(319)."), @"");
                /*"  01        TRAILL-REGISTRO     REDEFINES      HEADER-REGISTRO.*/

                public _REDEF_VG1601B_TRANSB_BENEFICIARIO()
                {
                    TRANSB_SEQBENEF.ValueChanged += OnValueChanged;
                    TRANSB_NOME.ValueChanged += OnValueChanged;
                    TRANSB_PARENTE.ValueChanged += OnValueChanged;
                    TRANSB_PCPARTIC.ValueChanged += OnValueChanged;
                    TRANSB_FILLER.ValueChanged += OnValueChanged;
                }

            }

            public _REDEF_VG1601B_TRANSC_REGISTRO()
            {
                TRANSC_TIPO_REG.ValueChanged += OnValueChanged;
                TRANSC_SEQUENCIA.ValueChanged += OnValueChanged;
                TRANSC_MATRICULA.ValueChanged += OnValueChanged;
                TRANSC_SUBTP_REG.ValueChanged += OnValueChanged;
                TRANSP_PRINCIPAL.ValueChanged += OnValueChanged;
            }

        }
        private _REDEF_VG1601B_TRAILL_REGISTRO _traill_registro { get; set; }
        public _REDEF_VG1601B_TRAILL_REGISTRO TRAILL_REGISTRO
        {
            get { _traill_registro = new _REDEF_VG1601B_TRAILL_REGISTRO(); _.Move(HEADER_REGISTRO, _traill_registro); VarBasis.RedefinePassValue(HEADER_REGISTRO, _traill_registro, HEADER_REGISTRO); _traill_registro.ValueChanged += () => { _.Move(_traill_registro, HEADER_REGISTRO); }; return _traill_registro; }
            set { VarBasis.RedefinePassValue(value, _traill_registro, HEADER_REGISTRO); }
        }  //Redefines
        public class _REDEF_VG1601B_TRAILL_REGISTRO : VarBasis
        {
            /*"    10      TRAILL-TIPO-REG     PIC  X(001).*/
            public StringBasis TRAILL_TIPO_REG { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
            /*"    10      TRAILL-FILLER       PIC  X(419).*/
            public StringBasis TRAILL_FILLER { get; set; } = new StringBasis(new PIC("X", "419", "X(419)."), @"");
            /*"01          FILLER.*/

            public _REDEF_VG1601B_TRAILL_REGISTRO()
            {
                TRAILL_TIPO_REG.ValueChanged += OnValueChanged;
                TRAILL_FILLER.ValueChanged += OnValueChanged;
            }

        }
        public VG1601B_FILLER_0 FILLER_0 { get; set; } = new VG1601B_FILLER_0();
        public class VG1601B_FILLER_0 : VarBasis
        {
            /*"  03        WSQLCODE3           PIC S9(009) COMP.*/
            public IntBasis WSQLCODE3 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"  03        AC-LIDOS-M          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_M { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-LIDOS            PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-LIDOS-S          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_LIDOS_S { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-M          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_M { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-E          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_E { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-C          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_C { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-D          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_D { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-B          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_B { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-1          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_1 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-2          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_2 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-3          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_3 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-4          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_4 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-5          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_5 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-GRAVA-6          PIC  9(007) VALUE ZEROS.*/
            public IntBasis AC_GRAVA_6 { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        WIMP-MORNATU-ATU    PIC S9(013)V99   COMP-3 VALUE +0*/
            public DoubleBasis WIMP_MORNATU_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WIMP-MORACID-ATU    PIC S9(013)V99   COMP-3 VALUE +0*/
            public DoubleBasis WIMP_MORACID_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WIMP-INVPERM-ATU    PIC S9(013)V99   COMP-3 VALUE +0*/
            public DoubleBasis WIMP_INVPERM_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WIMP-AMDS-ATU       PIC S9(013)V99   COMP-3 VALUE +0*/
            public DoubleBasis WIMP_AMDS_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WIMP-DH-ATU         PIC S9(013)V99   COMP-3 VALUE +0*/
            public DoubleBasis WIMP_DH_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        WIMP-DIT-ATU        PIC S9(013)V99   COMP-3 VALUE +0*/
            public DoubleBasis WIMP_DIT_ATU { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03            WS-TIME         PIC  X(008).*/
            public StringBasis WS_TIME { get; set; } = new StringBasis(new PIC("X", "8", "X(008)."), @"");
            /*"  03            WS-W01DTSQL.*/
            public VG1601B_WS_W01DTSQL WS_W01DTSQL { get; set; } = new VG1601B_WS_W01DTSQL();
            public class VG1601B_WS_W01DTSQL : VarBasis
            {
                /*"    05          WS-W01SCSQL         PIC  9(002).*/
                public IntBasis WS_W01SCSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01AASQL         PIC  9(002).*/
                public IntBasis WS_W01AASQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01T1SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W01T1SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W01MMSQL         PIC  9(002).*/
                public IntBasis WS_W01MMSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-W01T2SQL         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_W01T2SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-W01DDSQL         PIC  9(002).*/
                public IntBasis WS_W01DDSQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WK-DATA1.*/
            }
            public VG1601B_WK_DATA1 WK_DATA1 { get; set; } = new VG1601B_WK_DATA1();
            public class VG1601B_WK_DATA1 : VarBasis
            {
                /*"    10       WS-SEC1           PIC  9(002).*/
                public IntBasis WS_SEC1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WK-ANO1           PIC  9(002).*/
                public IntBasis WK_ANO1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WK-MES1           PIC  9(002).*/
                public IntBasis WK_MES1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WK-DIA1           PIC  9(002).*/
                public IntBasis WK_DIA1 { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-AUX.*/
            }
            public VG1601B_WS_DATA_AUX WS_DATA_AUX { get; set; } = new VG1601B_WS_DATA_AUX();
            public class VG1601B_WS_DATA_AUX : VarBasis
            {
                /*"    05          WS-ANO-AUX          PIC  9(004).*/
                public IntBasis WS_ANO_AUX { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    05          WS-TRA1-AUX         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-MES-AUX          PIC  9(002).*/
                public IntBasis WS_MES_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA2-AUX         PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2_AUX { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-DIA-AUX          PIC  9(002).*/
                public IntBasis WS_DIA_AUX { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03            WS-DATA-SQL.*/
            }
            public VG1601B_WS_DATA_SQL WS_DATA_SQL { get; set; } = new VG1601B_WS_DATA_SQL();
            public class VG1601B_WS_DATA_SQL : VarBasis
            {
                /*"    05          WS-SEC-SQL          PIC  9(002) VALUE 19.*/
                public IntBasis WS_SEC_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 19);
                /*"    05          WS-ANO-SQL          PIC  9(002).*/
                public IntBasis WS_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA1             PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-MES-SQL          PIC  9(002).*/
                public IntBasis WS_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    05          WS-TRA2             PIC  X(001) VALUE '-'.*/
                public StringBasis WS_TRA2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"-");
                /*"    05          WS-DIA-SQL          PIC  9(002).*/
                public IntBasis WS_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-DATA.*/
            }
            public VG1601B_WS_DATA WS_DATA { get; set; } = new VG1601B_WS_DATA();
            public class VG1601B_WS_DATA : VarBasis
            {
                /*"    10       WS-SEC            PIC  9(002)    VALUE 19.*/
                public IntBasis WS_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"), 19);
                /*"    10       WS-ANO            PIC  9(002).*/
                public IntBasis WS_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-MES            PIC  9(002).*/
                public IntBasis WS_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       FILLER            PIC  X(001).*/
                public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-DIA            PIC  9(002).*/
                public IntBasis WS_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         W01DTCSP          PIC  9(008)    VALUE ZEROS.*/
            }
            public IntBasis W01DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      W01DTCSP.*/
            private _REDEF_VG1601B_FILLER_5 _filler_5 { get; set; }
            public _REDEF_VG1601B_FILLER_5 FILLER_5
            {
                get { _filler_5 = new _REDEF_VG1601B_FILLER_5(); _.Move(W01DTCSP, _filler_5); VarBasis.RedefinePassValue(W01DTCSP, _filler_5, W01DTCSP); _filler_5.ValueChanged += () => { _.Move(_filler_5, W01DTCSP); }; return _filler_5; }
                set { VarBasis.RedefinePassValue(value, _filler_5, W01DTCSP); }
            }  //Redefines
            public class _REDEF_VG1601B_FILLER_5 : VarBasis
            {
                /*"    10       W01DDCSP          PIC  9(002).*/
                public IntBasis W01DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01MMCSP          PIC  9(002).*/
                public IntBasis W01MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01SCCSP          PIC  9(002).*/
                public IntBasis W01SCCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W01AACSP          PIC  9(002).*/
                public IntBasis W01AACSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         W02DTCSP          PIC  9(008)    VALUE ZEROS.*/

                public _REDEF_VG1601B_FILLER_5()
                {
                    W01DDCSP.ValueChanged += OnValueChanged;
                    W01MMCSP.ValueChanged += OnValueChanged;
                    W01SCCSP.ValueChanged += OnValueChanged;
                    W01AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis W02DTCSP { get; set; } = new IntBasis(new PIC("9", "8", "9(008)"));
            /*"  03         FILLER            REDEFINES      W02DTCSP.*/
            private _REDEF_VG1601B_FILLER_6 _filler_6 { get; set; }
            public _REDEF_VG1601B_FILLER_6 FILLER_6
            {
                get { _filler_6 = new _REDEF_VG1601B_FILLER_6(); _.Move(W02DTCSP, _filler_6); VarBasis.RedefinePassValue(W02DTCSP, _filler_6, W02DTCSP); _filler_6.ValueChanged += () => { _.Move(_filler_6, W02DTCSP); }; return _filler_6; }
                set { VarBasis.RedefinePassValue(value, _filler_6, W02DTCSP); }
            }  //Redefines
            public class _REDEF_VG1601B_FILLER_6 : VarBasis
            {
                /*"    10       W02DDCSP          PIC  9(002).*/
                public IntBasis W02DDCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02MMCSP          PIC  9(002).*/
                public IntBasis W02MMCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02SCCSP          PIC  9(002).*/
                public IntBasis W02SCCSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       W02AACSP          PIC  9(002).*/
                public IntBasis W02AACSP { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-DTREF          PIC  9(006)    VALUE ZEROS.*/

                public _REDEF_VG1601B_FILLER_6()
                {
                    W02DDCSP.ValueChanged += OnValueChanged;
                    W02MMCSP.ValueChanged += OnValueChanged;
                    W02SCCSP.ValueChanged += OnValueChanged;
                    W02AACSP.ValueChanged += OnValueChanged;
                }

            }
            public IntBasis WS_DTREF { get; set; } = new IntBasis(new PIC("9", "6", "9(006)"));
            /*"  03         FILLER            REDEFINES      WS-DTREF.*/
            private _REDEF_VG1601B_FILLER_7 _filler_7 { get; set; }
            public _REDEF_VG1601B_FILLER_7 FILLER_7
            {
                get { _filler_7 = new _REDEF_VG1601B_FILLER_7(); _.Move(WS_DTREF, _filler_7); VarBasis.RedefinePassValue(WS_DTREF, _filler_7, WS_DTREF); _filler_7.ValueChanged += () => { _.Move(_filler_7, WS_DTREF); }; return _filler_7; }
                set { VarBasis.RedefinePassValue(value, _filler_7, WS_DTREF); }
            }  //Redefines
            public class _REDEF_VG1601B_FILLER_7 : VarBasis
            {
                /*"    10       WS-REF-ANO        PIC  9(004).*/
                public IntBasis WS_REF_ANO { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-REF-MES        PIC  9(002).*/
                public IntBasis WS_REF_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03         WS-DTREF-SQL      PIC  X(010).*/

                public _REDEF_VG1601B_FILLER_7()
                {
                    WS_REF_ANO.ValueChanged += OnValueChanged;
                    WS_REF_MES.ValueChanged += OnValueChanged;
                }

            }
            public StringBasis WS_DTREF_SQL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)."), @"");
            /*"  03         FILLER            REDEFINES      WS-DTREF-SQL.*/
            private _REDEF_VG1601B_FILLER_8 _filler_8 { get; set; }
            public _REDEF_VG1601B_FILLER_8 FILLER_8
            {
                get { _filler_8 = new _REDEF_VG1601B_FILLER_8(); _.Move(WS_DTREF_SQL, _filler_8); VarBasis.RedefinePassValue(WS_DTREF_SQL, _filler_8, WS_DTREF_SQL); _filler_8.ValueChanged += () => { _.Move(_filler_8, WS_DTREF_SQL); }; return _filler_8; }
                set { VarBasis.RedefinePassValue(value, _filler_8, WS_DTREF_SQL); }
            }  //Redefines
            public class _REDEF_VG1601B_FILLER_8 : VarBasis
            {
                /*"    10       WS-REF-ANO-SQL    PIC  9(004).*/
                public IntBasis WS_REF_ANO_SQL { get; set; } = new IntBasis(new PIC("9", "4", "9(004)."));
                /*"    10       WS-REF-TRA1-SQL   PIC  X(001).*/
                public StringBasis WS_REF_TRA1_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-REF-MES-SQL    PIC  9(002).*/
                public IntBasis WS_REF_MES_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WS-REF-TRA2-SQL   PIC  X(001).*/
                public StringBasis WS_REF_TRA2_SQL { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WS-REF-DIA-SQL    PIC  9(002).*/
                public IntBasis WS_REF_DIA_SQL { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WPRMTOT                  PIC S9(013)V99                                        VALUE +0 COMP-3.*/

                public _REDEF_VG1601B_FILLER_8()
                {
                    WS_REF_ANO_SQL.ValueChanged += OnValueChanged;
                    WS_REF_TRA1_SQL.ValueChanged += OnValueChanged;
                    WS_REF_MES_SQL.ValueChanged += OnValueChanged;
                    WS_REF_TRA2_SQL.ValueChanged += OnValueChanged;
                    WS_REF_DIA_SQL.ValueChanged += OnValueChanged;
                }

            }
            public DoubleBasis WPRMTOT { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V99"), 2);
            /*"  03        AC-EMITIDOS              PIC  9(007) VALUE 0.*/
            public IntBasis AC_EMITIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        AC-SOLICITADOS           PIC  9(007) VALUE 0.*/
            public IntBasis AC_SOLICITADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-LIDOS                  PIC  9(007) VALUE 0.*/
            public IntBasis W_LIDOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        W-GRAVADOS               PIC  9(007) VALUE 0.*/
            public IntBasis W_GRAVADOS { get; set; } = new IntBasis(new PIC("9", "7", "9(007)"));
            /*"  03        FILLER.*/
            public VG1601B_FILLER_9 FILLER_9 { get; set; } = new VG1601B_FILLER_9();
            public class VG1601B_FILLER_9 : VarBasis
            {
                /*"    05      WTEM-SEGURADO                  PIC  X(001) VALUE ' '*/
                public StringBasis WTEM_SEGURADO { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @" ");
                /*"    05      FLAG-WFIM-MOVIMENTO            PIC  9(001) VALUE 0.*/

                public SelectorBasis FLAG_WFIM_MOVIMENTO { get; set; } = new SelectorBasis("001", "0")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-MOVIMENTO                  VALUE 1. */
							new SelectorItemBasis("FIM_MOVIMENTO", "1")
                }
                };

                /*"    05      FLAG-WFIM-SEGURADO             PIC  9(001) VALUE 0.*/

                public SelectorBasis FLAG_WFIM_SEGURADO { get; set; } = new SelectorBasis("001", "0")
                {
                    Items = new List<SelectorItemBasis> {
                            /*" 88    FIM-SEGURADO                   VALUE 1. */
							new SelectorItemBasis("FIM_SEGURADO", "1")
                }
                };

                /*"  03        WABEND.*/
            }
            public VG1601B_WABEND WABEND { get; set; } = new VG1601B_WABEND();
            public class VG1601B_WABEND : VarBasis
            {
                /*"    05      FILLER              PIC  X(010) VALUE           ' VG1601B'.*/
                public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @" VG1601B");
                /*"    05      FILLER              PIC  X(028) VALUE           ' *** ERRO  EXEC SQL  NUMERO '.*/
                public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @" *** ERRO  EXEC SQL  NUMERO ");
                /*"    05      WNR-EXEC-SQL        PIC  X(003) VALUE '000'.*/
                public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"000");
                /*"    05      FILLER              PIC  X(017) VALUE           ' *** PARAGRAFO = '.*/
                public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @" *** PARAGRAFO = ");
                /*"    05      PARAGRAFO           PIC  X(030) VALUE SPACES.*/
                public StringBasis PARAGRAFO { get; set; } = new StringBasis(new PIC("X", "30", "X(030)"), @"");
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE = '.*/
                public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE = ");
                /*"    05      WSQLCODE            PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE1= '.*/
                public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE1= ");
                /*"    05      WSQLCODE1           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE1 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"    05      FILLER              PIC  X(014) VALUE           '    SQLCODE2= '.*/
                public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"    SQLCODE2= ");
                /*"    05      WSQLCODE2           PIC  ZZZZZZ999- VALUE ZEROS.*/
                public IntBasis WSQLCODE2 { get; set; } = new IntBasis(new PIC("9", "10", "ZZZZZZ999-"));
                /*"  03        FILLER.*/
            }
            public VG1601B_FILLER_16 FILLER_16 { get; set; } = new VG1601B_FILLER_16();
            public class VG1601B_FILLER_16 : VarBasis
            {
                /*"    05      AUX-MORTE-NATURAL        PIC  9(013)V99.*/
                public DoubleBasis AUX_MORTE_NATURAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-MORTE-ACIDENTAL      PIC  9(013)V99.*/
                public DoubleBasis AUX_MORTE_ACIDENTAL { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-INV-PERMANENTE       PIC  9(013)V99.*/
                public DoubleBasis AUX_INV_PERMANENTE { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-AMDS                 PIC  9(013)V99.*/
                public DoubleBasis AUX_AMDS { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-DIARIA-HOSP          PIC  9(013)V99.*/
                public DoubleBasis AUX_DIARIA_HOSP { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-DIARIA-INT           PIC  9(013)V99.*/
                public DoubleBasis AUX_DIARIA_INT { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-DESPESA-MED          PIC  9(013)V99.*/
                public DoubleBasis AUX_DESPESA_MED { get; set; } = new DoubleBasis(new PIC("9", "13", "9(013)V99."), 2);
                /*"    05      AUX-TIPO-CLIENTE         PIC  X(030).*/
                public StringBasis AUX_TIPO_CLIENTE { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    05      AUX-TIPO-IMPORT          PIC  X(030).*/
                public StringBasis AUX_TIPO_IMPORT { get; set; } = new StringBasis(new PIC("X", "30", "X(030)."), @"");
                /*"    05      AUX-OUTROS               PIC  X(001) VALUE SPACES.*/
                public StringBasis AUX_OUTROS { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"");
                /*"    05      I                        PIC  9(002) VALUE ZEROS.*/
                public IntBasis I { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03        WDATA-REL           PIC  X(010)  VALUE SPACES.*/
            }
            public StringBasis WDATA_REL { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03        FILLER              REDEFINES    WDATA-REL.*/
            private _REDEF_VG1601B_FILLER_17 _filler_17 { get; set; }
            public _REDEF_VG1601B_FILLER_17 FILLER_17
            {
                get { _filler_17 = new _REDEF_VG1601B_FILLER_17(); _.Move(WDATA_REL, _filler_17); VarBasis.RedefinePassValue(WDATA_REL, _filler_17, WDATA_REL); _filler_17.ValueChanged += () => { _.Move(_filler_17, WDATA_REL); }; return _filler_17; }
                set { VarBasis.RedefinePassValue(value, _filler_17, WDATA_REL); }
            }  //Redefines
            public class _REDEF_VG1601B_FILLER_17 : VarBasis
            {
                /*"    10      WDAT-REL-SEC        PIC  9(002).*/
                public IntBasis WDAT_REL_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      WDAT-REL-ANO        PIC  9(002).*/
                public IntBasis WDAT_REL_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-MES        PIC  9(002).*/
                public IntBasis WDAT_REL_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10      FILLER              PIC  X(001).*/
                public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10      WDAT-REL-DIA        PIC  9(002).*/
                public IntBasis WDAT_REL_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"  03        WDAT-REL-LIT.*/

                public _REDEF_VG1601B_FILLER_17()
                {
                    WDAT_REL_SEC.ValueChanged += OnValueChanged;
                    WDAT_REL_ANO.ValueChanged += OnValueChanged;
                    FILLER_18.ValueChanged += OnValueChanged;
                    WDAT_REL_MES.ValueChanged += OnValueChanged;
                    FILLER_19.ValueChanged += OnValueChanged;
                    WDAT_REL_DIA.ValueChanged += OnValueChanged;
                }

            }
            public VG1601B_WDAT_REL_LIT WDAT_REL_LIT { get; set; } = new VG1601B_WDAT_REL_LIT();
            public class VG1601B_WDAT_REL_LIT : VarBasis
            {
                /*"    10      WDAT-LIT-DIA        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-MES        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      FILLER              PIC  X(001)  VALUE '/'.*/
                public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"/");
                /*"    10      WDAT-LIT-SEC        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_SEC { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"    10      WDAT-LIT-ANO        PIC  9(002)  VALUE ZEROS.*/
                public IntBasis WDAT_LIT_ANO { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
                /*"  03         WDATA-ALTERACAO   PIC  X(010)    VALUE SPACES.*/
            }
            public StringBasis WDATA_ALTERACAO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  03         FILLER            REDEFINES      WDATA-ALTERACAO.*/
            private _REDEF_VG1601B_FILLER_22 _filler_22 { get; set; }
            public _REDEF_VG1601B_FILLER_22 FILLER_22
            {
                get { _filler_22 = new _REDEF_VG1601B_FILLER_22(); _.Move(WDATA_ALTERACAO, _filler_22); VarBasis.RedefinePassValue(WDATA_ALTERACAO, _filler_22, WDATA_ALTERACAO); _filler_22.ValueChanged += () => { _.Move(_filler_22, WDATA_ALTERACAO); }; return _filler_22; }
                set { VarBasis.RedefinePassValue(value, _filler_22, WDATA_ALTERACAO); }
            }  //Redefines
            public class _REDEF_VG1601B_FILLER_22 : VarBasis
            {
                /*"    10       WCOR-ANO.*/
                public VG1601B_WCOR_ANO WCOR_ANO { get; set; } = new VG1601B_WCOR_ANO();
                public class VG1601B_WCOR_ANO : VarBasis
                {
                    /*"      15     WCOR-ANOS         PIC  9(002).*/
                    public IntBasis WCOR_ANOS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"      15     WCOR-ANOA         PIC  9(002).*/
                    public IntBasis WCOR_ANOA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                    /*"    10       WCOR-BR1          PIC  X(001).*/

                    public VG1601B_WCOR_ANO()
                    {
                        WCOR_ANOS.ValueChanged += OnValueChanged;
                        WCOR_ANOA.ValueChanged += OnValueChanged;
                    }

                }
                public StringBasis WCOR_BR1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WCOR-MES          PIC  9(002).*/
                public IntBasis WCOR_MES { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));
                /*"    10       WCOR-BR2          PIC  X(001).*/
                public StringBasis WCOR_BR2 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)."), @"");
                /*"    10       WCOR-DIA          PIC  9(002).*/
                public IntBasis WCOR_DIA { get; set; } = new IntBasis(new PIC("9", "2", "9(002)."));

                public _REDEF_VG1601B_FILLER_22()
                {
                    WCOR_ANO.ValueChanged += OnValueChanged;
                    WCOR_BR1.ValueChanged += OnValueChanged;
                    WCOR_MES.ValueChanged += OnValueChanged;
                    WCOR_BR2.ValueChanged += OnValueChanged;
                    WCOR_DIA.ValueChanged += OnValueChanged;
                }

            }
        }


        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.SEGURVGA SEGURVGA { get; set; } = new Dclgens.SEGURVGA();
        public Dclgens.SEGVGAPH SEGVGAPH { get; set; } = new Dclgens.SEGVGAPH();
        public Dclgens.APOLICOB APOLICOB { get; set; } = new Dclgens.APOLICOB();
        public Dclgens.MOVIMVGA MOVIMVGA { get; set; } = new Dclgens.MOVIMVGA();
        public Dclgens.FONTES FONTES { get; set; } = new Dclgens.FONTES();
        public Dclgens.FATURCON FATURCON { get; set; } = new Dclgens.FATURCON();
        public Dclgens.PARAMRAM PARAMRAM { get; set; } = new Dclgens.PARAMRAM();
        public VG1601B_CSEGURA CSEGURA { get; set; } = new VG1601B_CSEGURA();
        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string ARQUIVO_LEITURA_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                ARQUIVO_LEITURA.SetFile(ARQUIVO_LEITURA_FILE_NAME_P);

                /*" -0- FLUXCONTROL_PERFORM M-000-000-PRINCIPAL */

                M_000_000_PRINCIPAL();

            }
            catch (GoBack ex)
            {
            }

            if (!IsCall) DatabaseConnection.Instance.EndTransaction();

            Result = new { CodigoRetorno = RETURN_CODE.Value };
            return Result;
        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL */
        private void M_000_000_PRINCIPAL(bool isPerform = false)
        {
            /*" -585- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -587- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -589- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -593- OPEN INPUT ARQUIVO-LEITURA. */
            ARQUIVO_LEITURA.Open(REGISTRO_LEITURA);

            /*" -595- PERFORM 020-000-LE-MOVIMENTO. */

            M_020_000_LE_MOVIMENTO_SECTION();

            /*" -597- PERFORM 010-000-LER-TSISTEMA. */

            M_010_000_LER_TSISTEMA_SECTION();

            /*" -599- PERFORM 011-000-LER-PARAMRAMO. */

            M_011_000_LER_PARAMRAMO_SECTION();

            /*" -601- MOVE '000-000-PRINCIPAL ' TO PARAGRAFO. */
            _.Move("000-000-PRINCIPAL ", FILLER_0.WABEND.PARAGRAFO);

            /*" -603- MOVE '00A' TO WNR-EXEC-SQL. */
            _.Move("00A", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -665- PERFORM M_000_000_PRINCIPAL_DB_DECLARE_1 */

            M_000_000_PRINCIPAL_DB_DECLARE_1();

            /*" -668- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -670- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -672- PERFORM M_000_000_PRINCIPAL_DB_OPEN_1 */

            M_000_000_PRINCIPAL_DB_OPEN_1();

            /*" -675- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -677- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -679- PERFORM 030-000-SELECT-SEGURADOS. */

            M_030_000_SELECT_SEGURADOS_SECTION();

            /*" -679- PERFORM 050-000-PROCESSA UNTIL CHAVE-FIM = 1. */

            while (!(CHAVE_FIM == 1))
            {

                M_050_000_PROCESSA_SECTION();
            }

        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-DB-DECLARE-1 */
        public void M_000_000_PRINCIPAL_DB_DECLARE_1()
        {
            /*" -665- EXEC SQL DECLARE CSEGURA CURSOR FOR SELECT NUM_APOLICE, COD_SUBGRUPO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_SEGURADO, NUM_ITEM, TIPO_INCLUSAO, COD_CLIENTE, COD_FONTE, NUM_PROPOSTA, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, OCORR_HISTORICO, PERI_PAGAMENTO, PERI_RENOVACAO, NUM_CARNE, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, DATA_INIVIGENCIA, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_AP, TAXA_VG, SIT_REGISTRO, DATA_ADMISSAO, DATA_NASCIMENTO, OCORR_HISTORICO, COD_EMPRESA, LOT_EMP_SEGURADO FROM SEGUROS.SEGURADOS_VGAP WHERE NUM_APOLICE = :WHOST-APOLICE AND COD_SUBGRUPO = :WHOST-SUBGRUPO AND SIT_REGISTRO IN ( '0' , '1' ) AND COD_PROFISSAO = 0 END-EXEC. */
            CSEGURA = new VG1601B_CSEGURA(true);
            string GetQuery_CSEGURA()
            {
                var query = @$"SELECT 
							NUM_APOLICE
							, 
							COD_SUBGRUPO
							, 
							NUM_CERTIFICADO
							, 
							DAC_CERTIFICADO
							, 
							TIPO_SEGURADO
							, 
							NUM_ITEM
							, 
							TIPO_INCLUSAO
							, 
							COD_CLIENTE
							, 
							COD_FONTE
							, 
							NUM_PROPOSTA
							, 
							COD_AGENCIADOR
							, 
							COD_CORRETOR
							, 
							COD_PLANOVGAP
							, 
							COD_PLANOAP
							, 
							FAIXA
							, 
							AUTOR_AUM_AUTOMAT
							, 
							TIPO_BENEFICIARIO
							, 
							OCORR_HISTORICO
							, 
							PERI_PAGAMENTO
							, 
							PERI_RENOVACAO
							, 
							NUM_CARNE
							, 
							COD_OCUPACAO
							, 
							ESTADO_CIVIL
							, 
							IDE_SEXO
							, 
							COD_PROFISSAO
							, 
							NATURALIDADE
							, 
							OCORR_ENDERECO
							, 
							OCORR_END_COBRAN
							, 
							BCO_COBRANCA
							, 
							AGE_COBRANCA
							, 
							DAC_COBRANCA
							, 
							NUM_MATRICULA
							, 
							VAL_SALARIO
							, 
							TIPO_SALARIO
							, 
							TIPO_PLANO
							, 
							DATA_INIVIGENCIA
							, 
							PCT_CONJUGE_VG
							, 
							PCT_CONJUGE_AP
							, 
							QTD_SAL_MORNATU
							, 
							QTD_SAL_MORACID
							, 
							QTD_SAL_INVPERM
							, 
							TAXA_AP_MORACID
							, 
							TAXA_AP_INVPERM
							, 
							TAXA_AP_AMDS
							, 
							TAXA_AP_DH
							, 
							TAXA_AP_DIT
							, 
							TAXA_AP
							, 
							TAXA_VG
							, 
							SIT_REGISTRO
							, 
							DATA_ADMISSAO
							, 
							DATA_NASCIMENTO
							, 
							OCORR_HISTORICO
							, 
							COD_EMPRESA
							, 
							LOT_EMP_SEGURADO 
							FROM SEGUROS.SEGURADOS_VGAP 
							WHERE 
							NUM_APOLICE = '{WHOST_APOLICE}' AND 
							COD_SUBGRUPO = '{WHOST_SUBGRUPO}' AND 
							SIT_REGISTRO IN ( '0'
							, '1' ) AND 
							COD_PROFISSAO = 0";

                return query;
            }
            CSEGURA.GetQueryEvent += GetQuery_CSEGURA;

        }

        [StopWatch]
        /*" M-000-000-PRINCIPAL-DB-OPEN-1 */
        public void M_000_000_PRINCIPAL_DB_OPEN_1()
        {
            /*" -672- EXEC SQL OPEN CSEGURA END-EXEC. */

            CSEGURA.Open();

        }

        [StopWatch]
        /*" M-010-000-NEXT */
        private void M_010_000_NEXT(bool isPerform = false)
        {
            /*" -684- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -685- DISPLAY 'PROGRAMA VG1601B ' */
            _.Display($"PROGRAMA VG1601B ");

            /*" -686- DISPLAY 'TOTAIS PARA CONTROLE ' */
            _.Display($"TOTAIS PARA CONTROLE ");

            /*" -687- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -688- DISPLAY 'LIDOS NO MOVIMENTO ARQUIVO EMPRESA  = ' AC-LIDOS-M */
            _.Display($"LIDOS NO MOVIMENTO ARQUIVO EMPRESA  = {FILLER_0.AC_LIDOS_M}");

            /*" -689- DISPLAY 'LIDOS NO SEGURADOS VGAPC            = ' AC-LIDOS-S */
            _.Display($"LIDOS NO SEGURADOS VGAPC            = {FILLER_0.AC_LIDOS_S}");

            /*" -690- DISPLAY '------------------------------------- ' */
            _.Display($"------------------------------------- ");

            /*" -691- DISPLAY ' .CANCELAMENTO                      = ' AC-GRAVA-2 */
            _.Display($" .CANCELAMENTO                      = {FILLER_0.AC_GRAVA_2}");

            /*" -692- DISPLAY '-------------------------------------------------' */
            _.Display($"-------------------------------------------------");

            /*" -693- DISPLAY ' ' */
            _.Display($" ");

            /*" -695- DISPLAY ' *** VG1601B - FIM NORMAL ' . */
            _.Display($" *** VG1601B - FIM NORMAL ");

            /*" -695- PERFORM 900-000-FINALIZA. */

            M_900_000_FINALIZA_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_000_999_EXIT*/

        [StopWatch]
        /*" M-010-000-LER-TSISTEMA-SECTION */
        private void M_010_000_LER_TSISTEMA_SECTION()
        {
            /*" -709- MOVE '010-000-LER-TSISTEMA' TO PARAGRAFO. */
            _.Move("010-000-LER-TSISTEMA", FILLER_0.WABEND.PARAGRAFO);

            /*" -711- MOVE '010' TO WNR-EXEC-SQL. */
            _.Move("010", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -719- PERFORM M_010_000_LER_TSISTEMA_DB_SELECT_1 */

            M_010_000_LER_TSISTEMA_DB_SELECT_1();

            /*" -722- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -723- DISPLAY 'VG1601B - NAO CONSTA REGISTRO NA TSISTEMA' */
                _.Display($"VG1601B - NAO CONSTA REGISTRO NA TSISTEMA");

                /*" -724- DISPLAY 'IDSISTEM =  VG ' SQLCODE */
                _.Display($"IDSISTEM =  VG {DB.SQLCODE}");

                /*" -724- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-010-000-LER-TSISTEMA-DB-SELECT-1 */
        public void M_010_000_LER_TSISTEMA_DB_SELECT_1()
        {
            /*" -719- EXEC SQL SELECT DATA_MOV_ABERTO, DATA_MOV_ABERTO INTO :SISTEMAS-DATA-MOV-ABERTO, :SISTEMAS-DATA-MOVIMENTO FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'VG' END-EXEC. */

            var m_010_000_LER_TSISTEMA_DB_SELECT_1_Query1 = new M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_010_000_LER_TSISTEMA_DB_SELECT_1_Query1.Execute(m_010_000_LER_TSISTEMA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATA_MOVIMENTO, SISTEMAS_DATA_MOVIMENTO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_010_999_EXIT*/

        [StopWatch]
        /*" M-011-000-LER-PARAMRAMO-SECTION */
        private void M_011_000_LER_PARAMRAMO_SECTION()
        {
            /*" -739- MOVE '011-000-LER-PARAMRAMO' TO PARAGRAFO. */
            _.Move("011-000-LER-PARAMRAMO", FILLER_0.WABEND.PARAGRAFO);

            /*" -741- MOVE '01A' TO WNR-EXEC-SQL. */
            _.Move("01A", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -753- PERFORM M_011_000_LER_PARAMRAMO_DB_SELECT_1 */

            M_011_000_LER_PARAMRAMO_DB_SELECT_1();

            /*" -756- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -757- DISPLAY 'VG1601B - NAO CONSTA REGISTRO NA PARAMRAM' */
                _.Display($"VG1601B - NAO CONSTA REGISTRO NA PARAMRAM");

                /*" -757- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-011-000-LER-PARAMRAMO-DB-SELECT-1 */
        public void M_011_000_LER_PARAMRAMO_DB_SELECT_1()
        {
            /*" -753- EXEC SQL SELECT RAMO_VGAPC, RAMO_VG, RAMO_AP, NUM_RAMO_PRSTMISTA INTO :PARAMRAM-RAMO-VGAPC, :PARAMRAM-RAMO-VG, :PARAMRAM-RAMO-AP, :PARAMRAM-NUM-RAMO-PRSTMISTA FROM SEGUROS.PARAMETROS_RAMOS WHERE 1 = 1 END-EXEC. */

            var m_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1 = new M_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = M_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1.Execute(m_011_000_LER_PARAMRAMO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.PARAMRAM_RAMO_VGAPC, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VGAPC);
                _.Move(executed_1.PARAMRAM_RAMO_VG, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG);
                _.Move(executed_1.PARAMRAM_RAMO_AP, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP);
                _.Move(executed_1.PARAMRAM_NUM_RAMO_PRSTMISTA, PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_011_999_EXIT*/

        [StopWatch]
        /*" M-020-000-LE-MOVIMENTO-SECTION */
        private void M_020_000_LE_MOVIMENTO_SECTION()
        {
            /*" -772- MOVE '020-000-LE-MOVIMENTO' TO PARAGRAFO. */
            _.Move("020-000-LE-MOVIMENTO", FILLER_0.WABEND.PARAGRAFO);

            /*" -775- MOVE '020' TO WNR-EXEC-SQL. */
            _.Move("020", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -776- READ ARQUIVO-LEITURA INTO HEADER-REGISTRO AT END */
            try
            {
                ARQUIVO_LEITURA.Read(() =>
                {

                    /*" -778- MOVE 1 TO FLAG-WFIM-MOVIMENTO */
                    _.Move(1, FILLER_0.FILLER_9.FLAG_WFIM_MOVIMENTO);

                    /*" -780- GO TO 020-999-EXIT. */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/ //GOTO
                    return;
                });

                _.Move(ARQUIVO_LEITURA.Value, HEADER_REGISTRO); _.Move(ARQUIVO_LEITURA.Value, REGISTRO_LEITURA);

            }
            catch (GoToException ex)
            {
                return;
            }
            /*" -781- IF HEADER-TIPO-REG EQUAL '0' */

            if (HEADER_REGISTRO.HEADER_TIPO_REG == "0")
            {

                /*" -782- MOVE HEADER-NUM-APOL TO WNUM-APOLICE */
                _.Move(HEADER_REGISTRO.HEADER_NUM_APOL, WNUM_APOLICE);

                /*" -783- MOVE HEADER-COD-SUBGR TO WSUBGRUPO */
                _.Move(HEADER_REGISTRO.HEADER_COD_SUBGR, WSUBGRUPO);

                /*" -784- MOVE HEADER-DATA-REFER TO WS-DTREF */
                _.Move(HEADER_REGISTRO.HEADER_DATA_REFER, FILLER_0.WS_DTREF);

                /*" -785- MOVE WS-REF-ANO TO WS-REF-ANO-SQL */
                _.Move(FILLER_0.FILLER_7.WS_REF_ANO, FILLER_0.FILLER_8.WS_REF_ANO_SQL);

                /*" -786- MOVE WS-REF-MES TO WS-REF-MES-SQL */
                _.Move(FILLER_0.FILLER_7.WS_REF_MES, FILLER_0.FILLER_8.WS_REF_MES_SQL);

                /*" -787- MOVE 01 TO WS-REF-DIA-SQL */
                _.Move(01, FILLER_0.FILLER_8.WS_REF_DIA_SQL);

                /*" -788- MOVE '-' TO WS-REF-TRA1-SQL */
                _.Move("-", FILLER_0.FILLER_8.WS_REF_TRA1_SQL);

                /*" -789- MOVE '-' TO WS-REF-TRA2-SQL */
                _.Move("-", FILLER_0.FILLER_8.WS_REF_TRA2_SQL);

                /*" -790- MOVE WS-DTREF-SQL TO WDATAREF */
                _.Move(FILLER_0.WS_DTREF_SQL, WDATAREF);

                /*" -793- DISPLAY 'PROCESSANDO ARQUIVO ' HEADER-NUM-APOL ' ' HEADER-COD-SUBGR ' ' WDATAREF */

                $"PROCESSANDO ARQUIVO {HEADER_REGISTRO.HEADER_NUM_APOL} {HEADER_REGISTRO.HEADER_COD_SUBGR} {WDATAREF}"
                .Display();

                /*" -794- ELSE */
            }
            else
            {


                /*" -795- DISPLAY 'HEADER DO ARQUIVO INVALIDO - CANCELADO ' */
                _.Display($"HEADER DO ARQUIVO INVALIDO - CANCELADO ");

                /*" -796- CLOSE ARQUIVO-LEITURA */
                ARQUIVO_LEITURA.Close();

                /*" -798- STOP RUN. */

                throw new GoBack();   // => STOP RUN.
            }


            /*" -800- ADD 1 TO AC-LIDOS-M AC-LIDOS. */
            FILLER_0.AC_LIDOS_M.Value = FILLER_0.AC_LIDOS_M + 1;
            FILLER_0.AC_LIDOS.Value = FILLER_0.AC_LIDOS + 1;

            /*" -801- MOVE WNUM-APOLICE TO WHOST-APOLICE */
            _.Move(WNUM_APOLICE, WHOST_APOLICE);

            /*" -803- MOVE WSUBGRUPO TO WHOST-SUBGRUPO. */
            _.Move(WSUBGRUPO, WHOST_SUBGRUPO);

            /*" -803- CLOSE ARQUIVO-LEITURA. */
            ARQUIVO_LEITURA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_020_999_EXIT*/

        [StopWatch]
        /*" M-030-000-SELECT-SEGURADOS-SECTION */
        private void M_030_000_SELECT_SEGURADOS_SECTION()
        {
            /*" -814- MOVE '030-000-SELECT-SEGURADOS' TO PARAGRAFO. */
            _.Move("030-000-SELECT-SEGURADOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -816- MOVE '030' TO WNR-EXEC-SQL. */
            _.Move("030", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -872- PERFORM M_030_000_SELECT_SEGURADOS_DB_FETCH_1 */

            M_030_000_SELECT_SEGURADOS_DB_FETCH_1();

            /*" -875- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -876- IF SQLCODE EQUAL 100 */

                if (DB.SQLCODE == 100)
                {

                    /*" -877- MOVE 1 TO CHAVE-FIM */
                    _.Move(1, CHAVE_FIM);

                    /*" -877- PERFORM M_030_000_SELECT_SEGURADOS_DB_CLOSE_1 */

                    M_030_000_SELECT_SEGURADOS_DB_CLOSE_1();

                    /*" -879- GO TO 030-999-EXIT */
                    /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/ //GOTO
                    return;

                    /*" -880- ELSE */
                }
                else
                {


                    /*" -882- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -883- IF SLOT-EMP-SEGURADO-I LESS +0 */

            if (SLOT_EMP_SEGURADO_I < +0)
            {

                /*" -885- MOVE SPACES TO SEGURVGA-LOT-EMP-SEGURADO. */
                _.Move("", SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_LOT_EMP_SEGURADO);
            }


            /*" -885- ADD 1 TO AC-LIDOS-S. */
            FILLER_0.AC_LIDOS_S.Value = FILLER_0.AC_LIDOS_S + 1;

        }

        [StopWatch]
        /*" M-030-000-SELECT-SEGURADOS-DB-FETCH-1 */
        public void M_030_000_SELECT_SEGURADOS_DB_FETCH_1()
        {
            /*" -872- EXEC SQL FETCH CSEGURA INTO :SEGURVGA-NUM-APOLICE, :SEGURVGA-COD-SUBGRUPO, :SEGURVGA-NUM-CERTIFICADO, :SEGURVGA-DAC-CERTIFICADO, :SEGURVGA-TIPO-SEGURADO, :SEGURVGA-NUM-ITEM, :SEGURVGA-TIPO-INCLUSAO, :SEGURVGA-COD-CLIENTE, :SEGURVGA-COD-FONTE, :SEGURVGA-NUM-PROPOSTA, :SEGURVGA-COD-AGENCIADOR, :SEGURVGA-COD-CORRETOR, :SEGURVGA-COD-PLANOVGAP, :SEGURVGA-COD-PLANOAP, :SEGURVGA-FAIXA, :SEGURVGA-AUTOR-AUM-AUTOMAT, :SEGURVGA-TIPO-BENEFICIARIO, :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-PERI-PAGAMENTO, :SEGURVGA-PERI-RENOVACAO, :SEGURVGA-NUM-CARNE, :SEGURVGA-COD-OCUPACAO, :SEGURVGA-ESTADO-CIVIL, :SEGURVGA-IDE-SEXO, :SEGURVGA-COD-PROFISSAO, :SEGURVGA-NATURALIDADE, :SEGURVGA-OCORR-ENDERECO, :SEGURVGA-OCORR-END-COBRAN, :SEGURVGA-BCO-COBRANCA, :SEGURVGA-AGE-COBRANCA, :SEGURVGA-DAC-COBRANCA, :SEGURVGA-NUM-MATRICULA, :SEGURVGA-VAL-SALARIO, :SEGURVGA-TIPO-SALARIO, :SEGURVGA-TIPO-PLANO, :SEGURVGA-DATA-INIVIGENCIA, :SEGURVGA-PCT-CONJUGE-VG, :SEGURVGA-PCT-CONJUGE-AP, :SEGURVGA-QTD-SAL-MORNATU, :SEGURVGA-QTD-SAL-MORACID, :SEGURVGA-QTD-SAL-INVPERM, :SEGURVGA-TAXA-AP-MORACID, :SEGURVGA-TAXA-AP-INVPERM, :SEGURVGA-TAXA-AP-AMDS, :SEGURVGA-TAXA-AP-DH, :SEGURVGA-TAXA-AP-DIT, :SEGURVGA-TAXA-AP, :SEGURVGA-TAXA-VG, :SEGURVGA-SIT-REGISTRO, :SEGURVGA-DATA-ADMISSAO:SDATA-ADMISSAO-I, :SEGURVGA-DATA-NASCIMENTO:SDATA-NASCIMENTO-I, :SEGURVGA-OCORR-HISTORICO, :SEGURVGA-COD-EMPRESA:SCOD-EMPRESA-I, :SEGURVGA-LOT-EMP-SEGURADO:SLOT-EMP-SEGURADO-I END-EXEC. */

            if (CSEGURA.Fetch())
            {
                _.Move(CSEGURA.SEGURVGA_NUM_APOLICE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE);
                _.Move(CSEGURA.SEGURVGA_COD_SUBGRUPO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO);
                _.Move(CSEGURA.SEGURVGA_NUM_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO);
                _.Move(CSEGURA.SEGURVGA_DAC_CERTIFICADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DAC_CERTIFICADO);
                _.Move(CSEGURA.SEGURVGA_TIPO_SEGURADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO);
                _.Move(CSEGURA.SEGURVGA_NUM_ITEM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM);
                _.Move(CSEGURA.SEGURVGA_TIPO_INCLUSAO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_INCLUSAO);
                _.Move(CSEGURA.SEGURVGA_COD_CLIENTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE);
                _.Move(CSEGURA.SEGURVGA_COD_FONTE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE);
                _.Move(CSEGURA.SEGURVGA_NUM_PROPOSTA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_PROPOSTA);
                _.Move(CSEGURA.SEGURVGA_COD_AGENCIADOR, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_AGENCIADOR);
                _.Move(CSEGURA.SEGURVGA_COD_CORRETOR, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CORRETOR);
                _.Move(CSEGURA.SEGURVGA_COD_PLANOVGAP, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_PLANOVGAP);
                _.Move(CSEGURA.SEGURVGA_COD_PLANOAP, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_PLANOAP);
                _.Move(CSEGURA.SEGURVGA_FAIXA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_FAIXA);
                _.Move(CSEGURA.SEGURVGA_AUTOR_AUM_AUTOMAT, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_AUTOR_AUM_AUTOMAT);
                _.Move(CSEGURA.SEGURVGA_TIPO_BENEFICIARIO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_BENEFICIARIO);
                _.Move(CSEGURA.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(CSEGURA.SEGURVGA_PERI_PAGAMENTO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PERI_PAGAMENTO);
                _.Move(CSEGURA.SEGURVGA_PERI_RENOVACAO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PERI_RENOVACAO);
                _.Move(CSEGURA.SEGURVGA_NUM_CARNE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CARNE);
                _.Move(CSEGURA.SEGURVGA_COD_OCUPACAO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_OCUPACAO);
                _.Move(CSEGURA.SEGURVGA_ESTADO_CIVIL, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_ESTADO_CIVIL);
                _.Move(CSEGURA.SEGURVGA_IDE_SEXO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_IDE_SEXO);
                _.Move(CSEGURA.SEGURVGA_COD_PROFISSAO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_PROFISSAO);
                _.Move(CSEGURA.SEGURVGA_NATURALIDADE, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NATURALIDADE);
                _.Move(CSEGURA.SEGURVGA_OCORR_ENDERECO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO);
                _.Move(CSEGURA.SEGURVGA_OCORR_END_COBRAN, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_END_COBRAN);
                _.Move(CSEGURA.SEGURVGA_BCO_COBRANCA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_BCO_COBRANCA);
                _.Move(CSEGURA.SEGURVGA_AGE_COBRANCA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_AGE_COBRANCA);
                _.Move(CSEGURA.SEGURVGA_DAC_COBRANCA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DAC_COBRANCA);
                _.Move(CSEGURA.SEGURVGA_NUM_MATRICULA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA);
                _.Move(CSEGURA.SEGURVGA_VAL_SALARIO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_VAL_SALARIO);
                _.Move(CSEGURA.SEGURVGA_TIPO_SALARIO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SALARIO);
                _.Move(CSEGURA.SEGURVGA_TIPO_PLANO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_PLANO);
                _.Move(CSEGURA.SEGURVGA_DATA_INIVIGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_INIVIGENCIA);
                _.Move(CSEGURA.SEGURVGA_PCT_CONJUGE_VG, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PCT_CONJUGE_VG);
                _.Move(CSEGURA.SEGURVGA_PCT_CONJUGE_AP, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PCT_CONJUGE_AP);
                _.Move(CSEGURA.SEGURVGA_QTD_SAL_MORNATU, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_QTD_SAL_MORNATU);
                _.Move(CSEGURA.SEGURVGA_QTD_SAL_MORACID, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_QTD_SAL_MORACID);
                _.Move(CSEGURA.SEGURVGA_QTD_SAL_INVPERM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_QTD_SAL_INVPERM);
                _.Move(CSEGURA.SEGURVGA_TAXA_AP_MORACID, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_MORACID);
                _.Move(CSEGURA.SEGURVGA_TAXA_AP_INVPERM, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_INVPERM);
                _.Move(CSEGURA.SEGURVGA_TAXA_AP_AMDS, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_AMDS);
                _.Move(CSEGURA.SEGURVGA_TAXA_AP_DH, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_DH);
                _.Move(CSEGURA.SEGURVGA_TAXA_AP_DIT, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_DIT);
                _.Move(CSEGURA.SEGURVGA_TAXA_AP, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP);
                _.Move(CSEGURA.SEGURVGA_TAXA_VG, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_VG);
                _.Move(CSEGURA.SEGURVGA_SIT_REGISTRO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_SIT_REGISTRO);
                _.Move(CSEGURA.SEGURVGA_DATA_ADMISSAO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_ADMISSAO);
                _.Move(CSEGURA.SDATA_ADMISSAO_I, SDATA_ADMISSAO_I);
                _.Move(CSEGURA.SEGURVGA_DATA_NASCIMENTO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_NASCIMENTO);
                _.Move(CSEGURA.SDATA_NASCIMENTO_I, SDATA_NASCIMENTO_I);
                _.Move(CSEGURA.SEGURVGA_OCORR_HISTORICO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO);
                _.Move(CSEGURA.SEGURVGA_COD_EMPRESA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_EMPRESA);
                _.Move(CSEGURA.SCOD_EMPRESA_I, SCOD_EMPRESA_I);
                _.Move(CSEGURA.SEGURVGA_LOT_EMP_SEGURADO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_LOT_EMP_SEGURADO);
                _.Move(CSEGURA.SLOT_EMP_SEGURADO_I, SLOT_EMP_SEGURADO_I);
            }

        }

        [StopWatch]
        /*" M-030-000-SELECT-SEGURADOS-DB-CLOSE-1 */
        public void M_030_000_SELECT_SEGURADOS_DB_CLOSE_1()
        {
            /*" -877- EXEC SQL CLOSE CSEGURA END-EXEC */

            CSEGURA.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_030_999_EXIT*/

        [StopWatch]
        /*" M-050-000-PROCESSA-SECTION */
        private void M_050_000_PROCESSA_SECTION()
        {
            /*" -896- MOVE '050-000-PROCESSA        ' TO PARAGRAFO. */
            _.Move("050-000-PROCESSA        ", FILLER_0.WABEND.PARAGRAFO);

            /*" -898- MOVE '050' TO WNR-EXEC-SQL. */
            _.Move("050", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -911- PERFORM M_050_000_PROCESSA_DB_SELECT_1 */

            M_050_000_PROCESSA_DB_SELECT_1();

            /*" -914- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -916- IF SQLCODE EQUAL 100 NEXT SENTENCE */

                if (DB.SQLCODE == 100)
                {

                    /*" -917- ELSE */
                }
                else
                {


                    /*" -918- DISPLAY 'VG1601B - ERRO NA LEITURA DO MOVIMENTO  ' */
                    _.Display($"VG1601B - ERRO NA LEITURA DO MOVIMENTO  ");

                    /*" -919- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -920- ELSE */
                }

            }
            else
            {


                /*" -922- GO TO 050-899-NEXT. */

                M_050_899_NEXT(); //GOTO
                return;
            }


            /*" -923- MOVE 0401 TO MOVIMVGA-COD-OPERACAO. */
            _.Move(0401, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

            /*" -924- ADD 1 TO AC-GRAVA-2. */
            FILLER_0.AC_GRAVA_2.Value = FILLER_0.AC_GRAVA_2 + 1;

            /*" -926- MOVE '1' TO MOVIMVGA-SIT-REGISTRO. */
            _.Move("1", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO);

            /*" -926- PERFORM 625-000-TRATA-CANCELAMENTO. */

            M_625_000_TRATA_CANCELAMENTO_SECTION();

            /*" -0- FLUXCONTROL_PERFORM M_050_899_NEXT */

            M_050_899_NEXT();

        }

        [StopWatch]
        /*" M-050-000-PROCESSA-DB-SELECT-1 */
        public void M_050_000_PROCESSA_DB_SELECT_1()
        {
            /*" -911- EXEC SQL SELECT COD_OPERACAO INTO :MOVIMVGA-COD-OPERACAO FROM SEGUROS.MOVIMENTO_VGAP WHERE NUM_CERTIFICADO = :SEGURVGA-NUM-CERTIFICADO AND TIPO_SEGURADO = :SEGURVGA-TIPO-SEGURADO AND COD_OPERACAO BETWEEN 400 AND 499 AND DATA_INCLUSAO IS NULL AND DATA_AVERBACAO IS NOT NULL END-EXEC. */

            var m_050_000_PROCESSA_DB_SELECT_1_Query1 = new M_050_000_PROCESSA_DB_SELECT_1_Query1()
            {
                SEGURVGA_NUM_CERTIFICADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO.ToString(),
                SEGURVGA_TIPO_SEGURADO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO.ToString(),
            };

            var executed_1 = M_050_000_PROCESSA_DB_SELECT_1_Query1.Execute(m_050_000_PROCESSA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.MOVIMVGA_COD_OPERACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);
            }


        }

        [StopWatch]
        /*" M-050-899-NEXT */
        private void M_050_899_NEXT(bool isPerform = false)
        {
            /*" -929- PERFORM 030-000-SELECT-SEGURADOS. */

            M_030_000_SELECT_SEGURADOS_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_050_999_EXIT*/

        [StopWatch]
        /*" M-110-000-ACESSA-V1APOLICE-SECTION */
        private void M_110_000_ACESSA_V1APOLICE_SECTION()
        {
            /*" -945- MOVE '110-000-ACESSA-V1APOLICE' TO PARAGRAFO. */
            _.Move("110-000-ACESSA-V1APOLICE", FILLER_0.WABEND.PARAGRAFO);

            /*" -947- MOVE '110' TO WNR-EXEC-SQL. */
            _.Move("110", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -964- PERFORM M_110_000_ACESSA_V1APOLICE_DB_SELECT_1 */

            M_110_000_ACESSA_V1APOLICE_DB_SELECT_1();

            /*" -967- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -968- DISPLAY 'VG1601B - APOLICE NAO CADASTRADA ' */
                _.Display($"VG1601B - APOLICE NAO CADASTRADA ");

                /*" -969- DISPLAY 'APOLICE....... ' APOL-NUM-APOLICE */
                _.Display($"APOLICE....... {APOL_NUM_APOLICE}");

                /*" -971- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -972- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -973- DISPLAY 'VG1601B - ERRO NA LEITURA NA V1APOLICE  ' */
                _.Display($"VG1601B - ERRO NA LEITURA NA V1APOLICE  ");

                /*" -973- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-110-000-ACESSA-V1APOLICE-DB-SELECT-1 */
        public void M_110_000_ACESSA_V1APOLICE_DB_SELECT_1()
        {
            /*" -964- EXEC SQL SELECT CODCLIEN, NUM_APOLICE, MODALIDA, ORGAO, RAMO, NUMBIL, TIPAPO INTO :APOL-COD-CLIENTE, :APOL-NUM-APOLICE, :APOL-MODALIDA, :APOL-ORGAO, :APOL-RAMO, :APOL-NUMBIL, :APOL-TIPAPO FROM SEGUROS.V1APOLICE WHERE NUM_APOLICE = :APOL-NUM-APOLICE END-EXEC. */

            var m_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1 = new M_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1()
            {
                APOL_NUM_APOLICE = APOL_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1.Execute(m_110_000_ACESSA_V1APOLICE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.APOL_COD_CLIENTE, APOL_COD_CLIENTE);
                _.Move(executed_1.APOL_NUM_APOLICE, APOL_NUM_APOLICE);
                _.Move(executed_1.APOL_MODALIDA, APOL_MODALIDA);
                _.Move(executed_1.APOL_ORGAO, APOL_ORGAO);
                _.Move(executed_1.APOL_RAMO, APOL_RAMO);
                _.Move(executed_1.APOL_NUMBIL, APOL_NUMBIL);
                _.Move(executed_1.APOL_TIPAPO, APOL_TIPAPO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_110_999_EXIT*/

        [StopWatch]
        /*" M-120-000-ACESSA-V1SUBGRUPO-SECTION */
        private void M_120_000_ACESSA_V1SUBGRUPO_SECTION()
        {
            /*" -988- MOVE '120-000-ACESSA-V1SUBGRUPO' TO PARAGRAFO. */
            _.Move("120-000-ACESSA-V1SUBGRUPO", FILLER_0.WABEND.PARAGRAFO);

            /*" -990- MOVE '120' TO WNR-EXEC-SQL. */
            _.Move("120", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1022- PERFORM M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1 */

            M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1();

            /*" -1025- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1026- DISPLAY 'PARAGRAFO...' PARAGRAFO */
                _.Display($"PARAGRAFO...{FILLER_0.WABEND.PARAGRAFO}");

                /*" -1027- DISPLAY 'APOLICE.....' SUBG-NUM-APOLICE */
                _.Display($"APOLICE.....{SUBG_NUM_APOLICE}");

                /*" -1028- DISPLAY 'SUBGRUPO....' SUBG-COD-SUBGRUPO */
                _.Display($"SUBGRUPO....{SUBG_COD_SUBGRUPO}");

                /*" -1029- GO TO 120-999-EXIT */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/ //GOTO
                return;

            }


        }

        [StopWatch]
        /*" M-120-000-ACESSA-V1SUBGRUPO-DB-SELECT-1 */
        public void M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1()
        {
            /*" -1022- EXEC SQL SELECT COD_FONTE, TIPO_PLANO, FORMA_AVERBACAO, PERI_FATURAMENTO, PERI_RENOVACAO, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, PCT_CONJUGE_VG, PCT_CONJUGE_AP, IND_PLANO_ASSOCIA, TIPO_COBRANCA, COD_CLIENTE, OCORR_ENDERECO INTO :SUBG-COD-FONTE, :SUBG-TIPO-PLANO, :SUBG-FORMA-AVERBA, :SUBG-PERI-FATURAMENTO, :SUBG-PERI-RENOVACAO, :SUBG-BCO-COBRANCA, :SUBG-AGE-COBRANCA, :SUBG-DAC-COBRANCA, :SUBG-PCT-CONJUGE-VG, :SUBG-PCT-CONJUGE-AP, :SUBG-PLANO-ASSOCIA, :SUBG-TIPO-COBRANCA, :SUBG-COD-CLIENTE, :SUBG-OCORR-ENDERECO FROM SEGUROS.V1SUBGRUPO WHERE NUM_APOLICE = :SUBG-NUM-APOLICE AND COD_SUBGRUPO = :SUBG-COD-SUBGRUPO END-EXEC. */

            var m_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1 = new M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1()
            {
                SUBG_COD_SUBGRUPO = SUBG_COD_SUBGRUPO.ToString(),
                SUBG_NUM_APOLICE = SUBG_NUM_APOLICE.ToString(),
            };

            var executed_1 = M_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1.Execute(m_120_000_ACESSA_V1SUBGRUPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SUBG_COD_FONTE, SUBG_COD_FONTE);
                _.Move(executed_1.SUBG_TIPO_PLANO, SUBG_TIPO_PLANO);
                _.Move(executed_1.SUBG_FORMA_AVERBA, SUBG_FORMA_AVERBA);
                _.Move(executed_1.SUBG_PERI_FATURAMENTO, SUBG_PERI_FATURAMENTO);
                _.Move(executed_1.SUBG_PERI_RENOVACAO, SUBG_PERI_RENOVACAO);
                _.Move(executed_1.SUBG_BCO_COBRANCA, SUBG_BCO_COBRANCA);
                _.Move(executed_1.SUBG_AGE_COBRANCA, SUBG_AGE_COBRANCA);
                _.Move(executed_1.SUBG_DAC_COBRANCA, SUBG_DAC_COBRANCA);
                _.Move(executed_1.SUBG_PCT_CONJUGE_VG, SUBG_PCT_CONJUGE_VG);
                _.Move(executed_1.SUBG_PCT_CONJUGE_AP, SUBG_PCT_CONJUGE_AP);
                _.Move(executed_1.SUBG_PLANO_ASSOCIA, SUBG_PLANO_ASSOCIA);
                _.Move(executed_1.SUBG_TIPO_COBRANCA, SUBG_TIPO_COBRANCA);
                _.Move(executed_1.SUBG_COD_CLIENTE, SUBG_COD_CLIENTE);
                _.Move(executed_1.SUBG_OCORR_ENDERECO, SUBG_OCORR_ENDERECO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_120_999_EXIT*/

        [StopWatch]
        /*" M-130-000-ACESSA-V1FATURCONT-SECTION */
        private void M_130_000_ACESSA_V1FATURCONT_SECTION()
        {
            /*" -1045- MOVE '130-000-ACESSA-V1FATURCONT' TO PARAGRAFO. */
            _.Move("130-000-ACESSA-V1FATURCONT", FILLER_0.WABEND.PARAGRAFO);

            /*" -1047- MOVE '130' TO WNR-EXEC-SQL. */
            _.Move("130", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1048- IF FATCON-NUM-APOL NOT EQUAL 97010000889 */

            if (FATCON_NUM_APOL != 97010000889)
            {

                /*" -1049- MOVE ZEROS TO FATCON-COD-SUBG */
                _.Move(0, FATCON_COD_SUBG);

                /*" -1050- ELSE */
            }
            else
            {


                /*" -1052- MOVE WSUBGRUPO TO FATCON-COD-SUBG. */
                _.Move(WSUBGRUPO, FATCON_COD_SUBG);
            }


            /*" -1062- PERFORM M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1 */

            M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1();

            /*" -1065- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1066- DISPLAY 'APOLICE.....' SUBG-NUM-APOLICE */
                _.Display($"APOLICE.....{SUBG_NUM_APOLICE}");

                /*" -1067- DISPLAY 'SUBGRUPO....' SUBG-COD-SUBGRUPO */
                _.Display($"SUBGRUPO....{SUBG_COD_SUBGRUPO}");

                /*" -1068- MOVE WDATAREF TO FATCON-DATA-REFER */
                _.Move(WDATAREF, FATCON_DATA_REFER);

                /*" -1069- IF SQLCODE NOT EQUAL 100 */

                if (DB.SQLCODE != 100)
                {

                    /*" -1069- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


        }

        [StopWatch]
        /*" M-130-000-ACESSA-V1FATURCONT-DB-SELECT-1 */
        public void M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1()
        {
            /*" -1062- EXEC SQL SELECT NUM_APOLICE , COD_SUBGRUPO , DATA_REFERENCIA INTO :FATCON-NUM-APOL, :FATCON-COD-SUBG, :FATCON-DATA-REFER FROM SEGUROS.V1FATURCONT WHERE NUM_APOLICE = :FATCON-NUM-APOL AND COD_SUBGRUPO = :FATCON-COD-SUBG END-EXEC. */

            var m_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1 = new M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1()
            {
                FATCON_NUM_APOL = FATCON_NUM_APOL.ToString(),
                FATCON_COD_SUBG = FATCON_COD_SUBG.ToString(),
            };

            var executed_1 = M_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1.Execute(m_130_000_ACESSA_V1FATURCONT_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FATCON_NUM_APOL, FATCON_NUM_APOL);
                _.Move(executed_1.FATCON_COD_SUBG, FATCON_COD_SUBG);
                _.Move(executed_1.FATCON_DATA_REFER, FATCON_DATA_REFER);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_130_999_EXIT*/

        [StopWatch]
        /*" M-480-000-VE-TIPO-SECTION */
        private void M_480_000_VE_TIPO_SECTION()
        {
            /*" -1081- MOVE '480-000-VE-TIPO' TO PARAGRAFO. */
            _.Move("480-000-VE-TIPO", FILLER_0.WABEND.PARAGRAFO);

            /*" -1083- MOVE '480' TO WNR-EXEC-SQL. */
            _.Move("480", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1084- IF SEGURVGA-TIPO-SEGURADO EQUAL '1' */

            if (SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO == "1")
            {

                /*" -1085- PERFORM 511-000-MOVE-V1SEGURAVG */

                M_511_000_MOVE_V1SEGURAVG_SECTION();

                /*" -1086- ELSE */
            }
            else
            {


                /*" -1086- PERFORM 516-000-MOVE-V1SEGURAVG. */

                M_516_000_MOVE_V1SEGURAVG_SECTION();
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_480_999_EXIT*/

        [StopWatch]
        /*" M-500-000-GRAVA-V1MOVIMENTO-SECTION */
        private void M_500_000_GRAVA_V1MOVIMENTO_SECTION()
        {
            /*" -1104- MOVE '500-000-INSERE-V1MOVIMENTO' TO PARAGRAFO. */
            _.Move("500-000-INSERE-V1MOVIMENTO", FILLER_0.WABEND.PARAGRAFO);

            /*" -1104- MOVE '500' TO WNR-EXEC-SQL. */
            _.Move("500", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -0- FLUXCONTROL_PERFORM M_500_001_LOOP_GRAVA */

            M_500_001_LOOP_GRAVA();

        }

        [StopWatch]
        /*" M-500-001-LOOP-GRAVA */
        private void M_500_001_LOOP_GRAVA(bool isPerform = false)
        {
            /*" -1109- MOVE -1 TO WDATA-INCLUSAO WDATA-FATURA */
            _.Move(-1, WDATA_INCLUSAO, WDATA_FATURA);

            /*" -1263- PERFORM M_500_001_LOOP_GRAVA_DB_INSERT_1 */

            M_500_001_LOOP_GRAVA_DB_INSERT_1();

            /*" -1266- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -1267- IF SQLCODE EQUAL -803 */

                if (DB.SQLCODE == -803)
                {

                    /*" -1270- DISPLAY 'MOVIMVGA - PROPOSTA DUPL' ' CERT ' MOVIMVGA-NUM-CERTIFICADO ' PROP ' MOVIMVGA-NUM-PROPOSTA */

                    $"MOVIMVGA - PROPOSTA DUPL CERT {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO} PROP {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA}"
                    .Display();

                    /*" -1271- MOVE MOVIMVGA-COD-FONTE TO FONTE-FONTE */
                    _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE, FONTE_FONTE);

                    /*" -1272- PERFORM 520-000-ACESSA-FONTE */

                    M_520_000_ACESSA_FONTE_SECTION();

                    /*" -1273- PERFORM 530-000-ATUALIZA-FONTE */

                    M_530_000_ATUALIZA_FONTE_SECTION();

                    /*" -1274- MOVE FONTE-PROPAUTOM TO MOVIMVGA-NUM-PROPOSTA */
                    _.Move(FONTE_PROPAUTOM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA);

                    /*" -1275- GO TO 500-001-LOOP-GRAVA */
                    new Task(() => M_500_001_LOOP_GRAVA()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1276- ELSE */
                }
                else
                {


                    /*" -1278- DISPLAY 'VG1601B - PROBLEMAS NA INCLUSAO V0MOVIMENTO  ' MOVIMVGA-NUM-APOLICE ' ' MOVIMVGA-NUM-CERTIFICADO */

                    $"VG1601B - PROBLEMAS NA INCLUSAO V0MOVIMENTO  {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE} {MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO}"
                    .Display();

                    /*" -1279- DISPLAY MOVIMVGA-NUM-APOLICE */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE);

                    /*" -1280- DISPLAY MOVIMVGA-COD-SUBGRUPO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO);

                    /*" -1281- DISPLAY MOVIMVGA-COD-FONTE */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE);

                    /*" -1282- DISPLAY MOVIMVGA-NUM-PROPOSTA */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA);

                    /*" -1283- DISPLAY MOVIMVGA-TIPO-SEGURADO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO);

                    /*" -1284- DISPLAY MOVIMVGA-NUM-CERTIFICADO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);

                    /*" -1285- DISPLAY MOVIMVGA-DAC-CERTIFICADO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CERTIFICADO);

                    /*" -1286- DISPLAY MOVIMVGA-TIPO-INCLUSAO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_INCLUSAO);

                    /*" -1287- DISPLAY MOVIMVGA-COD-CLIENTE */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CLIENTE);

                    /*" -1288- DISPLAY MOVIMVGA-COD-AGENCIADOR */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR);

                    /*" -1289- DISPLAY MOVIMVGA-COD-CORRETOR */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CORRETOR);

                    /*" -1290- DISPLAY MOVIMVGA-COD-PLANOVGAP */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOVGAP);

                    /*" -1291- DISPLAY MOVIMVGA-COD-PLANOAP */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOAP);

                    /*" -1292- DISPLAY MOVIMVGA-FAIXA */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);

                    /*" -1293- DISPLAY MOVIMVGA-AUTOR-AUM-AUTOMAT */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AUTOR_AUM_AUTOMAT);

                    /*" -1294- DISPLAY MOVIMVGA-TIPO-BENEFICIARIO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_BENEFICIARIO);

                    /*" -1295- DISPLAY MOVIMVGA-PERI-PAGAMENTO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO);

                    /*" -1296- DISPLAY MOVIMVGA-PERI-RENOVACAO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_RENOVACAO);

                    /*" -1297- DISPLAY MOVIMVGA-COD-OCUPACAO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OCUPACAO);

                    /*" -1298- DISPLAY MOVIMVGA-ESTADO-CIVIL */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_ESTADO_CIVIL);

                    /*" -1299- DISPLAY MOVIMVGA-IDE-SEXO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO);

                    /*" -1300- DISPLAY MOVIMVGA-COD-PROFISSAO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PROFISSAO);

                    /*" -1301- DISPLAY MOVIMVGA-NATURALIDADE */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NATURALIDADE);

                    /*" -1302- DISPLAY MOVIMVGA-OCORR-ENDERECO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO);

                    /*" -1303- DISPLAY MOVIMVGA-OCORR-END-COBRAN */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_END_COBRAN);

                    /*" -1304- DISPLAY MOVIMVGA-BCO-COBRANCA */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_BCO_COBRANCA);

                    /*" -1305- DISPLAY MOVIMVGA-AGE-COBRANCA */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AGE_COBRANCA);

                    /*" -1306- DISPLAY MOVIMVGA-DAC-COBRANCA */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_COBRANCA);

                    /*" -1307- DISPLAY MOVIMVGA-NUM-MATRICULA */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA);

                    /*" -1308- DISPLAY MOVIMVGA-NUM-CTA-CORRENTE */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CTA_CORRENTE);

                    /*" -1309- DISPLAY MOVIMVGA-DAC-CTA-CORRENTE */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CTA_CORRENTE);

                    /*" -1310- DISPLAY MOVIMVGA-VAL-SALARIO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO);

                    /*" -1311- DISPLAY MOVIMVGA-TIPO-SALARIO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO);

                    /*" -1312- DISPLAY MOVIMVGA-TIPO-PLANO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO);

                    /*" -1313- DISPLAY MOVIMVGA-PCT-CONJUGE-VG */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_VG);

                    /*" -1314- DISPLAY MOVIMVGA-PCT-CONJUGE-AP */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_AP);

                    /*" -1315- DISPLAY MOVIMVGA-QTD-SAL-MORNATU */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);

                    /*" -1316- DISPLAY MOVIMVGA-QTD-SAL-MORACID */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID);

                    /*" -1317- DISPLAY MOVIMVGA-QTD-SAL-INVPERM */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM);

                    /*" -1318- DISPLAY MOVIMVGA-TAXA-AP-MORACID */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_MORACID);

                    /*" -1319- DISPLAY MOVIMVGA-TAXA-AP-INVPERM */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_INVPERM);

                    /*" -1320- DISPLAY MOVIMVGA-TAXA-AP-AMDS */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_AMDS);

                    /*" -1321- DISPLAY MOVIMVGA-TAXA-AP-DH */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH);

                    /*" -1322- DISPLAY MOVIMVGA-TAXA-AP-DIT */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DIT);

                    /*" -1323- DISPLAY MOVIMVGA-TAXA-VG */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

                    /*" -1324- DISPLAY MOVIMVGA-IMP-MORNATU-ANT */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT);

                    /*" -1325- DISPLAY MOVIMVGA-IMP-MORNATU-ATU */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);

                    /*" -1326- DISPLAY MOVIMVGA-IMP-MORACID-ANT */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT);

                    /*" -1327- DISPLAY MOVIMVGA-IMP-MORACID-ATU */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);

                    /*" -1328- DISPLAY MOVIMVGA-IMP-INVPERM-ANT */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT);

                    /*" -1329- DISPLAY MOVIMVGA-IMP-INVPERM-ATU */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);

                    /*" -1330- DISPLAY MOVIMVGA-IMP-AMDS-ANT */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT);

                    /*" -1331- DISPLAY MOVIMVGA-IMP-AMDS-ATU */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU);

                    /*" -1332- DISPLAY MOVIMVGA-IMP-DH-ANT */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT);

                    /*" -1333- DISPLAY MOVIMVGA-IMP-DH-ATU */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU);

                    /*" -1334- DISPLAY MOVIMVGA-IMP-DIT-ANT */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT);

                    /*" -1335- DISPLAY MOVIMVGA-IMP-DIT-ATU */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU);

                    /*" -1336- DISPLAY MOVIMVGA-PRM-VG-ANT */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);

                    /*" -1337- DISPLAY MOVIMVGA-PRM-VG-ATU */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

                    /*" -1338- DISPLAY MOVIMVGA-PRM-AP-ANT */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT);

                    /*" -1339- DISPLAY MOVIMVGA-PRM-AP-ATU */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);

                    /*" -1340- DISPLAY MOVIMVGA-COD-OPERACAO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO);

                    /*" -1341- DISPLAY MOVIMVGA-DATA-OPERACAO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);

                    /*" -1342- DISPLAY MOVIMVGA-COD-SUBGRUPO-TRANS */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS);

                    /*" -1343- DISPLAY MOVIMVGA-SIT-REGISTRO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO);

                    /*" -1344- DISPLAY MOVIMVGA-COD-USUARIO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_USUARIO);

                    /*" -1345- DISPLAY MOVIMVGA-DATA-AVERBACAO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);

                    /*" -1346- DISPLAY MOVIMVGA-DATA-ADMISSAO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO);

                    /*" -1347- DISPLAY MOVIMVGA-DATA-INCLUSAO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO);

                    /*" -1348- DISPLAY MOVIMVGA-DATA-NASCIMENTO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO);

                    /*" -1349- DISPLAY MOVIMVGA-DATA-FATURA */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_FATURA);

                    /*" -1350- DISPLAY MOVIMVGA-DATA-REFERENCIA */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA);

                    /*" -1351- DISPLAY MOVIMVGA-DATA-MOVIMENTO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO);

                    /*" -1352- DISPLAY MOVIMVGA-COD-EMPRESA */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_EMPRESA);

                    /*" -1353- DISPLAY MOVIMVGA-LOT-EMP-SEGURADO */
                    _.Display(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_LOT_EMP_SEGURADO);

                    /*" -1355- GO TO 999-999-ROT-ERRO. */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;
                }

            }


            /*" -1355- ADD 1 TO AC-GRAVA-M. */
            FILLER_0.AC_GRAVA_M.Value = FILLER_0.AC_GRAVA_M + 1;

        }

        [StopWatch]
        /*" M-500-001-LOOP-GRAVA-DB-INSERT-1 */
        public void M_500_001_LOOP_GRAVA_DB_INSERT_1()
        {
            /*" -1263- EXEC SQL INSERT INTO SEGUROS.V0MOVIMENTO ( NUM_APOLICE, COD_SUBGRUPO, COD_FONTE, NUM_PROPOSTA, TIPO_SEGURADO, NUM_CERTIFICADO, DAC_CERTIFICADO, TIPO_INCLUSAO, COD_CLIENTE, COD_AGENCIADOR, COD_CORRETOR, COD_PLANOVGAP, COD_PLANOAP, FAIXA, AUTOR_AUM_AUTOMAT, TIPO_BENEFICIARIO, PERI_PAGAMENTO, PERI_RENOVACAO, COD_OCUPACAO, ESTADO_CIVIL, IDE_SEXO, COD_PROFISSAO, NATURALIDADE, OCORR_ENDERECO, OCORR_END_COBRAN, BCO_COBRANCA, AGE_COBRANCA, DAC_COBRANCA, NUM_MATRICULA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE, VAL_SALARIO, TIPO_SALARIO, TIPO_PLANO, PCT_CONJUGE_VG, PCT_CONJUGE_AP, QTD_SAL_MORNATU, QTD_SAL_MORACID, QTD_SAL_INVPERM, TAXA_AP_MORACID, TAXA_AP_INVPERM, TAXA_AP_AMDS, TAXA_AP_DH, TAXA_AP_DIT, TAXA_VG, IMP_MORNATU_ANT, IMP_MORNATU_ATU, IMP_MORACID_ANT, IMP_MORACID_ATU, IMP_INVPERM_ANT, IMP_INVPERM_ATU, IMP_AMDS_ANT, IMP_AMDS_ATU, IMP_DH_ANT, IMP_DH_ATU, IMP_DIT_ANT, IMP_DIT_ATU, PRM_VG_ANT, PRM_VG_ATU, PRM_AP_ANT, PRM_AP_ATU, COD_OPERACAO, DATA_OPERACAO, COD_SUBGRUPO_TRANS, SIT_REGISTRO, COD_USUARIO, DATA_AVERBACAO, DATA_ADMISSAO, DATA_INCLUSAO, DATA_NASCIMENTO, DATA_FATURA, DATA_REFERENCIA, DATA_MOVIMENTO, COD_EMPRESA, LOT_EMP_SEGURADO) VALUES (:MOVIMVGA-NUM-APOLICE, :MOVIMVGA-COD-SUBGRUPO, :MOVIMVGA-COD-FONTE, :MOVIMVGA-NUM-PROPOSTA, :MOVIMVGA-TIPO-SEGURADO, :MOVIMVGA-NUM-CERTIFICADO, :MOVIMVGA-DAC-CERTIFICADO, :MOVIMVGA-TIPO-INCLUSAO, :MOVIMVGA-COD-CLIENTE, :MOVIMVGA-COD-AGENCIADOR, :MOVIMVGA-COD-CORRETOR, :MOVIMVGA-COD-PLANOVGAP, :MOVIMVGA-COD-PLANOAP, :MOVIMVGA-FAIXA, :MOVIMVGA-AUTOR-AUM-AUTOMAT, :MOVIMVGA-TIPO-BENEFICIARIO, :MOVIMVGA-PERI-PAGAMENTO, :MOVIMVGA-PERI-RENOVACAO, :MOVIMVGA-COD-OCUPACAO, :MOVIMVGA-ESTADO-CIVIL, :MOVIMVGA-IDE-SEXO, :MOVIMVGA-COD-PROFISSAO, :MOVIMVGA-NATURALIDADE, :MOVIMVGA-OCORR-ENDERECO, :MOVIMVGA-OCORR-END-COBRAN, :MOVIMVGA-BCO-COBRANCA, :MOVIMVGA-AGE-COBRANCA, :MOVIMVGA-DAC-COBRANCA, :MOVIMVGA-NUM-MATRICULA, :MOVIMVGA-NUM-CTA-CORRENTE, :MOVIMVGA-DAC-CTA-CORRENTE, :MOVIMVGA-VAL-SALARIO, :MOVIMVGA-TIPO-SALARIO, :MOVIMVGA-TIPO-PLANO, :MOVIMVGA-PCT-CONJUGE-VG, :MOVIMVGA-PCT-CONJUGE-AP, :MOVIMVGA-QTD-SAL-MORNATU, :MOVIMVGA-QTD-SAL-MORACID, :MOVIMVGA-QTD-SAL-INVPERM, :MOVIMVGA-TAXA-AP-MORACID, :MOVIMVGA-TAXA-AP-INVPERM, :MOVIMVGA-TAXA-AP-AMDS, :MOVIMVGA-TAXA-AP-DH, :MOVIMVGA-TAXA-AP-DIT, :MOVIMVGA-TAXA-VG, :MOVIMVGA-IMP-MORNATU-ANT, :MOVIMVGA-IMP-MORNATU-ATU, :MOVIMVGA-IMP-MORACID-ANT, :MOVIMVGA-IMP-MORACID-ATU, :MOVIMVGA-IMP-INVPERM-ANT, :MOVIMVGA-IMP-INVPERM-ATU, :MOVIMVGA-IMP-AMDS-ANT, :MOVIMVGA-IMP-AMDS-ATU, :MOVIMVGA-IMP-DH-ANT, :MOVIMVGA-IMP-DH-ATU, :MOVIMVGA-IMP-DIT-ANT, :MOVIMVGA-IMP-DIT-ATU, :MOVIMVGA-PRM-VG-ANT, :MOVIMVGA-PRM-VG-ATU, :MOVIMVGA-PRM-AP-ANT, :MOVIMVGA-PRM-AP-ATU, :MOVIMVGA-COD-OPERACAO, :MOVIMVGA-DATA-OPERACAO, :MOVIMVGA-COD-SUBGRUPO-TRANS, :MOVIMVGA-SIT-REGISTRO, :MOVIMVGA-COD-USUARIO, :MOVIMVGA-DATA-AVERBACAO:WDATA-AVERBACAO, :MOVIMVGA-DATA-ADMISSAO:WDATA-ADMISSAO, :MOVIMVGA-DATA-INCLUSAO:WDATA-INCLUSAO, :MOVIMVGA-DATA-NASCIMENTO, :MOVIMVGA-DATA-FATURA:WDATA-FATURA, :MOVIMVGA-DATA-REFERENCIA, :MOVIMVGA-DATA-MOVIMENTO, :MOVIMVGA-COD-EMPRESA:WCOD-EMPRESA, :MOVIMVGA-LOT-EMP-SEGURADO:WLOT-EMP-SEG) END-EXEC. */

            var m_500_001_LOOP_GRAVA_DB_INSERT_1_Insert1 = new M_500_001_LOOP_GRAVA_DB_INSERT_1_Insert1()
            {
                MOVIMVGA_NUM_APOLICE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE.ToString(),
                MOVIMVGA_COD_SUBGRUPO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.ToString(),
                MOVIMVGA_COD_FONTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE.ToString(),
                MOVIMVGA_NUM_PROPOSTA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA.ToString(),
                MOVIMVGA_TIPO_SEGURADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO.ToString(),
                MOVIMVGA_NUM_CERTIFICADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.ToString(),
                MOVIMVGA_DAC_CERTIFICADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CERTIFICADO.ToString(),
                MOVIMVGA_TIPO_INCLUSAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_INCLUSAO.ToString(),
                MOVIMVGA_COD_CLIENTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CLIENTE.ToString(),
                MOVIMVGA_COD_AGENCIADOR = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR.ToString(),
                MOVIMVGA_COD_CORRETOR = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CORRETOR.ToString(),
                MOVIMVGA_COD_PLANOVGAP = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOVGAP.ToString(),
                MOVIMVGA_COD_PLANOAP = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOAP.ToString(),
                MOVIMVGA_FAIXA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA.ToString(),
                MOVIMVGA_AUTOR_AUM_AUTOMAT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AUTOR_AUM_AUTOMAT.ToString(),
                MOVIMVGA_TIPO_BENEFICIARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_BENEFICIARIO.ToString(),
                MOVIMVGA_PERI_PAGAMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO.ToString(),
                MOVIMVGA_PERI_RENOVACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_RENOVACAO.ToString(),
                MOVIMVGA_COD_OCUPACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OCUPACAO.ToString(),
                MOVIMVGA_ESTADO_CIVIL = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_ESTADO_CIVIL.ToString(),
                MOVIMVGA_IDE_SEXO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO.ToString(),
                MOVIMVGA_COD_PROFISSAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PROFISSAO.ToString(),
                MOVIMVGA_NATURALIDADE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NATURALIDADE.ToString(),
                MOVIMVGA_OCORR_ENDERECO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO.ToString(),
                MOVIMVGA_OCORR_END_COBRAN = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_END_COBRAN.ToString(),
                MOVIMVGA_BCO_COBRANCA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_BCO_COBRANCA.ToString(),
                MOVIMVGA_AGE_COBRANCA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AGE_COBRANCA.ToString(),
                MOVIMVGA_DAC_COBRANCA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_COBRANCA.ToString(),
                MOVIMVGA_NUM_MATRICULA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA.ToString(),
                MOVIMVGA_NUM_CTA_CORRENTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CTA_CORRENTE.ToString(),
                MOVIMVGA_DAC_CTA_CORRENTE = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CTA_CORRENTE.ToString(),
                MOVIMVGA_VAL_SALARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO.ToString(),
                MOVIMVGA_TIPO_SALARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO.ToString(),
                MOVIMVGA_TIPO_PLANO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO.ToString(),
                MOVIMVGA_PCT_CONJUGE_VG = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_VG.ToString(),
                MOVIMVGA_PCT_CONJUGE_AP = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_AP.ToString(),
                MOVIMVGA_QTD_SAL_MORNATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU.ToString(),
                MOVIMVGA_QTD_SAL_MORACID = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID.ToString(),
                MOVIMVGA_QTD_SAL_INVPERM = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM.ToString(),
                MOVIMVGA_TAXA_AP_MORACID = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_MORACID.ToString(),
                MOVIMVGA_TAXA_AP_INVPERM = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_INVPERM.ToString(),
                MOVIMVGA_TAXA_AP_AMDS = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_AMDS.ToString(),
                MOVIMVGA_TAXA_AP_DH = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH.ToString(),
                MOVIMVGA_TAXA_AP_DIT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DIT.ToString(),
                MOVIMVGA_TAXA_VG = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG.ToString(),
                MOVIMVGA_IMP_MORNATU_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT.ToString(),
                MOVIMVGA_IMP_MORNATU_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU.ToString(),
                MOVIMVGA_IMP_MORACID_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT.ToString(),
                MOVIMVGA_IMP_MORACID_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU.ToString(),
                MOVIMVGA_IMP_INVPERM_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT.ToString(),
                MOVIMVGA_IMP_INVPERM_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU.ToString(),
                MOVIMVGA_IMP_AMDS_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT.ToString(),
                MOVIMVGA_IMP_AMDS_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU.ToString(),
                MOVIMVGA_IMP_DH_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT.ToString(),
                MOVIMVGA_IMP_DH_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU.ToString(),
                MOVIMVGA_IMP_DIT_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT.ToString(),
                MOVIMVGA_IMP_DIT_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU.ToString(),
                MOVIMVGA_PRM_VG_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT.ToString(),
                MOVIMVGA_PRM_VG_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU.ToString(),
                MOVIMVGA_PRM_AP_ANT = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT.ToString(),
                MOVIMVGA_PRM_AP_ATU = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU.ToString(),
                MOVIMVGA_COD_OPERACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OPERACAO.ToString(),
                MOVIMVGA_DATA_OPERACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO.ToString(),
                MOVIMVGA_COD_SUBGRUPO_TRANS = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS.ToString(),
                MOVIMVGA_SIT_REGISTRO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_SIT_REGISTRO.ToString(),
                MOVIMVGA_COD_USUARIO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_USUARIO.ToString(),
                MOVIMVGA_DATA_AVERBACAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO.ToString(),
                WDATA_AVERBACAO = WDATA_AVERBACAO.ToString(),
                MOVIMVGA_DATA_ADMISSAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO.ToString(),
                WDATA_ADMISSAO = WDATA_ADMISSAO.ToString(),
                MOVIMVGA_DATA_INCLUSAO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO.ToString(),
                WDATA_INCLUSAO = WDATA_INCLUSAO.ToString(),
                MOVIMVGA_DATA_NASCIMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO.ToString(),
                MOVIMVGA_DATA_FATURA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_FATURA.ToString(),
                WDATA_FATURA = WDATA_FATURA.ToString(),
                MOVIMVGA_DATA_REFERENCIA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA.ToString(),
                MOVIMVGA_DATA_MOVIMENTO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO.ToString(),
                MOVIMVGA_COD_EMPRESA = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_EMPRESA.ToString(),
                WCOD_EMPRESA = WCOD_EMPRESA.ToString(),
                MOVIMVGA_LOT_EMP_SEGURADO = MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_LOT_EMP_SEGURADO.ToString(),
                WLOT_EMP_SEG = WLOT_EMP_SEG.ToString(),
            };

            M_500_001_LOOP_GRAVA_DB_INSERT_1_Insert1.Execute(m_500_001_LOOP_GRAVA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_500_999_EXIT*/

        [StopWatch]
        /*" M-502-000-LER-V0SEGURAVG-SECTION */
        private void M_502_000_LER_V0SEGURAVG_SECTION()
        {
            /*" -1373- MOVE '502-000-LER-V0SEGURAVG' TO WNR-EXEC-SQL. */
            _.Move("502-000-LER-V0SEGURAVG", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1379- PERFORM M_502_000_LER_V0SEGURAVG_DB_SELECT_1 */

            M_502_000_LER_V0SEGURAVG_DB_SELECT_1();

            /*" -1382- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1383- DISPLAY 'ERRO DE ACESSO A CONTAGEM DE REG. SEGURAVG' */
                _.Display($"ERRO DE ACESSO A CONTAGEM DE REG. SEGURAVG");

                /*" -1384- DISPLAY 'APOLICE   = ' WNUM-APOLICE ' ' WSUBGRUPO */

                $"APOLICE   = {WNUM_APOLICE} {WSUBGRUPO}"
                .Display();

                /*" -1384- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-502-000-LER-V0SEGURAVG-DB-SELECT-1 */
        public void M_502_000_LER_V0SEGURAVG_DB_SELECT_1()
        {
            /*" -1379- EXEC SQL SELECT VALUE(COUNT(*),0) INTO :WHOST-QTDE-SEGVG FROM SEGUROS.V0SEGURAVG WHERE NUM_APOLICE = :WHOST-APOLICE AND COD_SUBGRUPO = :WHOST-SUBGRUPO END-EXEC. */

            var m_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1 = new M_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1()
            {
                WHOST_SUBGRUPO = WHOST_SUBGRUPO.ToString(),
                WHOST_APOLICE = WHOST_APOLICE.ToString(),
            };

            var executed_1 = M_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1.Execute(m_502_000_LER_V0SEGURAVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_QTDE_SEGVG, WHOST_QTDE_SEGVG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_502_999_EXIT*/

        [StopWatch]
        /*" M-505-000-LER-V1SUBGRUPO-SECTION */
        private void M_505_000_LER_V1SUBGRUPO_SECTION()
        {
            /*" -1402- MOVE '505-000-LER-V1SUBGRUPO' TO WNR-EXEC-SQL. */
            _.Move("505-000-LER-V1SUBGRUPO", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1408- PERFORM M_505_000_LER_V1SUBGRUPO_DB_SELECT_1 */

            M_505_000_LER_V1SUBGRUPO_DB_SELECT_1();

            /*" -1411- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1412- DISPLAY 'ERRO DE ACESSO A TABELA V1SUBGRUPO DTINIVIG' */
                _.Display($"ERRO DE ACESSO A TABELA V1SUBGRUPO DTINIVIG");

                /*" -1413- DISPLAY 'APOLICE   = ' WNUM-APOLICE ' ' WSUBGRUPO */

                $"APOLICE   = {WNUM_APOLICE} {WSUBGRUPO}"
                .Display();

                /*" -1413- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-505-000-LER-V1SUBGRUPO-DB-SELECT-1 */
        public void M_505_000_LER_V1SUBGRUPO_DB_SELECT_1()
        {
            /*" -1408- EXEC SQL SELECT DTINIVIG INTO :WHOST-DTINIVIG FROM SEGUROS.V1SUBGRUPO WHERE NUM_APOLICE = :WHOST-APOLICE AND COD_SUBGRUPO = :WHOST-SUBGRUPO END-EXEC. */

            var m_505_000_LER_V1SUBGRUPO_DB_SELECT_1_Query1 = new M_505_000_LER_V1SUBGRUPO_DB_SELECT_1_Query1()
            {
                WHOST_SUBGRUPO = WHOST_SUBGRUPO.ToString(),
                WHOST_APOLICE = WHOST_APOLICE.ToString(),
            };

            var executed_1 = M_505_000_LER_V1SUBGRUPO_DB_SELECT_1_Query1.Execute(m_505_000_LER_V1SUBGRUPO_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.WHOST_DTINIVIG, WHOST_DTINIVIG);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_505_999_EXIT*/

        [StopWatch]
        /*" M-511-000-MOVE-V1SEGURAVG-SECTION */
        private void M_511_000_MOVE_V1SEGURAVG_SECTION()
        {
            /*" -1425- MOVE '511-000-MOVE-V1SEGURAVG' TO PARAGRAFO. */
            _.Move("511-000-MOVE-V1SEGURAVG", FILLER_0.WABEND.PARAGRAFO);

            /*" -1427- MOVE '511' TO WNR-EXEC-SQL. */
            _.Move("511", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1428- MOVE SEGURVGA-NUM-APOLICE TO MOVIMVGA-NUM-APOLICE */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE);

            /*" -1429- MOVE SEGURVGA-COD-SUBGRUPO TO MOVIMVGA-COD-SUBGRUPO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO);

            /*" -1430- MOVE SEGURVGA-COD-FONTE TO MOVIMVGA-COD-FONTE */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE);

            /*" -1431- MOVE FONTE-PROPAUTOM TO MOVIMVGA-NUM-PROPOSTA */
            _.Move(FONTE_PROPAUTOM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA);

            /*" -1432- MOVE SEGURVGA-TIPO-SEGURADO TO MOVIMVGA-TIPO-SEGURADO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO);

            /*" -1433- MOVE SEGURVGA-NUM-CERTIFICADO TO MOVIMVGA-NUM-CERTIFICADO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);

            /*" -1434- MOVE SEGURVGA-DAC-CERTIFICADO TO MOVIMVGA-DAC-CERTIFICADO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DAC_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CERTIFICADO);

            /*" -1435- MOVE SEGURVGA-TIPO-INCLUSAO TO MOVIMVGA-TIPO-INCLUSAO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_INCLUSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_INCLUSAO);

            /*" -1436- MOVE SEGURVGA-COD-CLIENTE TO MOVIMVGA-COD-CLIENTE */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CLIENTE);

            /*" -1437- MOVE SEGURVGA-COD-AGENCIADOR TO MOVIMVGA-COD-AGENCIADOR */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_AGENCIADOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR);

            /*" -1438- MOVE SEGURVGA-COD-CORRETOR TO MOVIMVGA-COD-CORRETOR */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CORRETOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CORRETOR);

            /*" -1439- MOVE SEGURVGA-COD-PLANOVGAP TO MOVIMVGA-COD-PLANOVGAP */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_PLANOVGAP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOVGAP);

            /*" -1440- MOVE SEGURVGA-COD-PLANOAP TO MOVIMVGA-COD-PLANOAP */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_PLANOAP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOAP);

            /*" -1441- MOVE SEGURVGA-FAIXA TO MOVIMVGA-FAIXA */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_FAIXA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);

            /*" -1442- MOVE SEGURVGA-AUTOR-AUM-AUTOMAT TO MOVIMVGA-AUTOR-AUM-AUTOMAT */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_AUTOR_AUM_AUTOMAT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AUTOR_AUM_AUTOMAT);

            /*" -1443- MOVE SEGURVGA-TIPO-BENEFICIARIO TO MOVIMVGA-TIPO-BENEFICIARIO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_BENEFICIARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_BENEFICIARIO);

            /*" -1444- MOVE SEGURVGA-PERI-PAGAMENTO TO MOVIMVGA-PERI-PAGAMENTO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PERI_PAGAMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO);

            /*" -1445- MOVE SEGURVGA-PERI-RENOVACAO TO MOVIMVGA-PERI-RENOVACAO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PERI_RENOVACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_RENOVACAO);

            /*" -1446- MOVE SEGURVGA-COD-OCUPACAO TO MOVIMVGA-COD-OCUPACAO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_OCUPACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OCUPACAO);

            /*" -1447- MOVE SEGURVGA-ESTADO-CIVIL TO MOVIMVGA-ESTADO-CIVIL */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_ESTADO_CIVIL, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_ESTADO_CIVIL);

            /*" -1448- MOVE SEGURVGA-IDE-SEXO TO MOVIMVGA-IDE-SEXO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_IDE_SEXO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO);

            /*" -1449- MOVE SEGURVGA-COD-PROFISSAO TO MOVIMVGA-COD-PROFISSAO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_PROFISSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PROFISSAO);

            /*" -1450- MOVE SEGURVGA-NATURALIDADE TO MOVIMVGA-NATURALIDADE */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NATURALIDADE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NATURALIDADE);

            /*" -1451- MOVE SEGURVGA-OCORR-ENDERECO TO MOVIMVGA-OCORR-ENDERECO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO);

            /*" -1452- MOVE SEGURVGA-OCORR-END-COBRAN TO MOVIMVGA-OCORR-END-COBRAN */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_END_COBRAN, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_END_COBRAN);

            /*" -1453- MOVE SEGURVGA-BCO-COBRANCA TO MOVIMVGA-BCO-COBRANCA */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_BCO_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_BCO_COBRANCA);

            /*" -1454- MOVE SEGURVGA-AGE-COBRANCA TO MOVIMVGA-AGE-COBRANCA */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_AGE_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AGE_COBRANCA);

            /*" -1455- MOVE SEGURVGA-DAC-COBRANCA TO MOVIMVGA-DAC-COBRANCA */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DAC_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_COBRANCA);

            /*" -1456- MOVE SEGURVGA-NUM-MATRICULA TO MOVIMVGA-NUM-MATRICULA */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA);

            /*" -1457- MOVE ONUM-CTA-CORRENTE TO MOVIMVGA-NUM-CTA-CORRENTE */
            _.Move(ONUM_CTA_CORRENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CTA_CORRENTE);

            /*" -1458- MOVE ODAC-CTA-CORRENTE TO MOVIMVGA-DAC-CTA-CORRENTE. */
            _.Move(ODAC_CTA_CORRENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CTA_CORRENTE);

            /*" -1459- MOVE SEGURVGA-VAL-SALARIO TO MOVIMVGA-VAL-SALARIO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_VAL_SALARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO);

            /*" -1460- MOVE SEGURVGA-TIPO-SALARIO TO MOVIMVGA-TIPO-SALARIO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SALARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO);

            /*" -1461- MOVE SEGURVGA-TIPO-PLANO TO MOVIMVGA-TIPO-PLANO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_PLANO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO);

            /*" -1462- MOVE SEGURVGA-PCT-CONJUGE-VG TO MOVIMVGA-PCT-CONJUGE-VG. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PCT_CONJUGE_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_VG);

            /*" -1463- MOVE SEGURVGA-PCT-CONJUGE-AP TO MOVIMVGA-PCT-CONJUGE-AP. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PCT_CONJUGE_AP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_AP);

            /*" -1464- MOVE SEGURVGA-QTD-SAL-MORNATU TO MOVIMVGA-QTD-SAL-MORNATU. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_QTD_SAL_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);

            /*" -1465- MOVE SEGURVGA-QTD-SAL-MORACID TO MOVIMVGA-QTD-SAL-MORACID. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_QTD_SAL_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID);

            /*" -1466- MOVE SEGURVGA-QTD-SAL-INVPERM TO MOVIMVGA-QTD-SAL-INVPERM. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_QTD_SAL_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM);

            /*" -1467- MOVE SEGURVGA-TAXA-AP-MORACID TO MOVIMVGA-TAXA-AP-MORACID. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_MORACID);

            /*" -1468- MOVE SEGURVGA-TAXA-AP-INVPERM TO MOVIMVGA-TAXA-AP-INVPERM. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_INVPERM);

            /*" -1469- MOVE SEGURVGA-TAXA-AP-AMDS TO MOVIMVGA-TAXA-AP-AMDS. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_AMDS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_AMDS);

            /*" -1470- MOVE SEGURVGA-TAXA-AP-DH TO MOVIMVGA-TAXA-AP-DH. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_DH, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH);

            /*" -1471- MOVE SEGURVGA-TAXA-AP-DIT TO MOVIMVGA-TAXA-AP-DIT. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_DIT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DIT);

            /*" -1472- MOVE SEGURVGA-TAXA-VG TO MOVIMVGA-TAXA-VG. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

            /*" -1473- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMVGA-DATA-OPERACAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);

            /*" -1475- MOVE 0 TO MOVIMVGA-COD-SUBGRUPO-TRANS. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS);

            /*" -1476- MOVE 'VG1601B' TO MOVIMVGA-COD-USUARIO. */
            _.Move("VG1601B", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_USUARIO);

            /*" -1477- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMVGA-DATA-AVERBACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);

            /*" -1478- MOVE 0 TO WDATA-AVERBACAO. */
            _.Move(0, WDATA_AVERBACAO);

            /*" -1479- MOVE SEGURVGA-DATA-ADMISSAO TO MOVIMVGA-DATA-ADMISSAO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_ADMISSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO);

            /*" -1480- MOVE -1 TO WDATA-INCLUSAO. */
            _.Move(-1, WDATA_INCLUSAO);

            /*" -1481- MOVE SEGURVGA-DATA-NASCIMENTO TO MOVIMVGA-DATA-NASCIMENTO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_NASCIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO);

            /*" -1482- MOVE -1 TO WDATA-FATURA. */
            _.Move(-1, WDATA_FATURA);

            /*" -1483- MOVE FATCON-DATA-REFER TO MOVIMVGA-DATA-REFERENCIA. */
            _.Move(FATCON_DATA_REFER, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA);

            /*" -1484- MOVE SISTEMAS-DATA-MOVIMENTO TO MOVIMVGA-DATA-MOVIMENTO */
            _.Move(SISTEMAS_DATA_MOVIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO);

            /*" -1486- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -1487- IF SDATA-ADMISSAO-I < 0 */

            if (SDATA_ADMISSAO_I < 0)
            {

                /*" -1489- MOVE -1 TO WDATA-ADMISSAO. */
                _.Move(-1, WDATA_ADMISSAO);
            }


            /*" -1489- MOVE SEGURVGA-LOT-EMP-SEGURADO TO MOVIMVGA-LOT-EMP-SEGURADO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_LOT_EMP_SEGURADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_LOT_EMP_SEGURADO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_511_999_EXIT*/

        [StopWatch]
        /*" M-516-000-MOVE-V1SEGURAVG-SECTION */
        private void M_516_000_MOVE_V1SEGURAVG_SECTION()
        {
            /*" -1501- MOVE '516-000-MOVE-V1SEGURAVG' TO PARAGRAFO. */
            _.Move("516-000-MOVE-V1SEGURAVG", FILLER_0.WABEND.PARAGRAFO);

            /*" -1503- MOVE '516' TO WNR-EXEC-SQL. */
            _.Move("516", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1504- MOVE SEGURVGA-NUM-APOLICE TO MOVIMVGA-NUM-APOLICE. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE);

            /*" -1505- MOVE SEGURVGA-COD-SUBGRUPO TO MOVIMVGA-COD-SUBGRUPO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO);

            /*" -1506- MOVE SEGURVGA-COD-FONTE TO MOVIMVGA-COD-FONTE. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_FONTE);

            /*" -1507- MOVE FONTE-PROPAUTOM TO MOVIMVGA-NUM-PROPOSTA. */
            _.Move(FONTE_PROPAUTOM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_PROPOSTA);

            /*" -1508- MOVE SEGURVGA-TIPO-SEGURADO TO MOVIMVGA-TIPO-SEGURADO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SEGURADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SEGURADO);

            /*" -1509- MOVE SEGURVGA-NUM-CERTIFICADO TO MOVIMVGA-NUM-CERTIFICADO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO);

            /*" -1510- MOVE SEGURVGA-DAC-CERTIFICADO TO MOVIMVGA-DAC-CERTIFICADO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DAC_CERTIFICADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CERTIFICADO);

            /*" -1511- MOVE SEGURVGA-TIPO-INCLUSAO TO MOVIMVGA-TIPO-INCLUSAO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_INCLUSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_INCLUSAO);

            /*" -1512- MOVE SEGURVGA-COD-CLIENTE TO MOVIMVGA-COD-CLIENTE. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CLIENTE);

            /*" -1513- MOVE SEGURVGA-COD-AGENCIADOR TO MOVIMVGA-COD-AGENCIADOR. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_AGENCIADOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_AGENCIADOR);

            /*" -1514- MOVE SEGURVGA-COD-CORRETOR TO MOVIMVGA-COD-CORRETOR. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CORRETOR, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_CORRETOR);

            /*" -1515- MOVE SEGURVGA-COD-PLANOVGAP TO MOVIMVGA-COD-PLANOVGAP. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_PLANOVGAP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOVGAP);

            /*" -1516- MOVE SEGURVGA-COD-PLANOAP TO MOVIMVGA-COD-PLANOAP. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_PLANOAP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PLANOAP);

            /*" -1517- MOVE SEGURVGA-FAIXA TO MOVIMVGA-FAIXA. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_FAIXA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_FAIXA);

            /*" -1518- MOVE SEGURVGA-AUTOR-AUM-AUTOMAT TO MOVIMVGA-AUTOR-AUM-AUTOMAT */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_AUTOR_AUM_AUTOMAT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AUTOR_AUM_AUTOMAT);

            /*" -1519- MOVE SEGURVGA-TIPO-BENEFICIARIO TO MOVIMVGA-TIPO-BENEFICIARIO */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_BENEFICIARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_BENEFICIARIO);

            /*" -1520- MOVE SEGURVGA-PERI-PAGAMENTO TO MOVIMVGA-PERI-PAGAMENTO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PERI_PAGAMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_PAGAMENTO);

            /*" -1521- MOVE SEGURVGA-PERI-RENOVACAO TO MOVIMVGA-PERI-RENOVACAO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PERI_RENOVACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PERI_RENOVACAO);

            /*" -1522- MOVE SEGURVGA-COD-OCUPACAO TO MOVIMVGA-COD-OCUPACAO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_OCUPACAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_OCUPACAO);

            /*" -1523- MOVE SEGURVGA-ESTADO-CIVIL TO MOVIMVGA-ESTADO-CIVIL. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_ESTADO_CIVIL, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_ESTADO_CIVIL);

            /*" -1524- MOVE SEGURVGA-IDE-SEXO TO MOVIMVGA-IDE-SEXO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_IDE_SEXO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IDE_SEXO);

            /*" -1525- MOVE SEGURVGA-COD-PROFISSAO TO MOVIMVGA-COD-PROFISSAO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_PROFISSAO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_PROFISSAO);

            /*" -1526- MOVE SEGURVGA-NATURALIDADE TO MOVIMVGA-NATURALIDADE. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NATURALIDADE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NATURALIDADE);

            /*" -1527- MOVE SEGURVGA-OCORR-ENDERECO TO MOVIMVGA-OCORR-ENDERECO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_ENDERECO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO);

            /*" -1528- MOVE SEGURVGA-OCORR-END-COBRAN TO MOVIMVGA-OCORR-END-COBRAN. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_END_COBRAN, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_END_COBRAN);

            /*" -1529- MOVE SEGURVGA-BCO-COBRANCA TO MOVIMVGA-BCO-COBRANCA. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_BCO_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_BCO_COBRANCA);

            /*" -1530- MOVE SEGURVGA-AGE-COBRANCA TO MOVIMVGA-AGE-COBRANCA. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_AGE_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_AGE_COBRANCA);

            /*" -1531- MOVE SEGURVGA-DAC-COBRANCA TO MOVIMVGA-DAC-COBRANCA. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DAC_COBRANCA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_COBRANCA);

            /*" -1532- MOVE SEGURVGA-NUM-MATRICULA TO MOVIMVGA-NUM-MATRICULA. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_MATRICULA, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_MATRICULA);

            /*" -1533- MOVE ONUM-CTA-CORRENTE TO MOVIMVGA-NUM-CTA-CORRENTE. */
            _.Move(ONUM_CTA_CORRENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CTA_CORRENTE);

            /*" -1534- MOVE ODAC-CTA-CORRENTE TO MOVIMVGA-DAC-CTA-CORRENTE. */
            _.Move(ODAC_CTA_CORRENTE, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DAC_CTA_CORRENTE);

            /*" -1535- MOVE SEGURVGA-VAL-SALARIO TO MOVIMVGA-VAL-SALARIO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_VAL_SALARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_VAL_SALARIO);

            /*" -1536- MOVE SEGURVGA-TIPO-SALARIO TO MOVIMVGA-TIPO-SALARIO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_SALARIO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_SALARIO);

            /*" -1537- MOVE SEGURVGA-TIPO-PLANO TO MOVIMVGA-TIPO-PLANO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TIPO_PLANO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TIPO_PLANO);

            /*" -1538- MOVE SEGURVGA-PCT-CONJUGE-VG TO MOVIMVGA-PCT-CONJUGE-VG. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PCT_CONJUGE_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_VG);

            /*" -1539- MOVE SEGURVGA-PCT-CONJUGE-AP TO MOVIMVGA-PCT-CONJUGE-AP. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_PCT_CONJUGE_AP, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PCT_CONJUGE_AP);

            /*" -1540- MOVE SEGURVGA-QTD-SAL-MORNATU TO MOVIMVGA-QTD-SAL-MORNATU. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_QTD_SAL_MORNATU, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORNATU);

            /*" -1541- MOVE SEGURVGA-QTD-SAL-MORACID TO MOVIMVGA-QTD-SAL-MORACID. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_QTD_SAL_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_MORACID);

            /*" -1542- MOVE SEGURVGA-QTD-SAL-INVPERM TO MOVIMVGA-QTD-SAL-INVPERM. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_QTD_SAL_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_QTD_SAL_INVPERM);

            /*" -1543- MOVE SEGURVGA-TAXA-AP-MORACID TO MOVIMVGA-TAXA-AP-MORACID. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_MORACID, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_MORACID);

            /*" -1544- MOVE SEGURVGA-TAXA-AP-INVPERM TO MOVIMVGA-TAXA-AP-INVPERM. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_INVPERM, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_INVPERM);

            /*" -1545- MOVE SEGURVGA-TAXA-AP-AMDS TO MOVIMVGA-TAXA-AP-AMDS. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_AMDS, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_AMDS);

            /*" -1546- MOVE SEGURVGA-TAXA-AP-DH TO MOVIMVGA-TAXA-AP-DH. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_DH, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DH);

            /*" -1547- MOVE SEGURVGA-TAXA-AP-DIT TO MOVIMVGA-TAXA-AP-DIT. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_AP_DIT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_AP_DIT);

            /*" -1548- MOVE SEGURVGA-TAXA-VG TO MOVIMVGA-TAXA-VG. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_TAXA_VG, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_TAXA_VG);

            /*" -1549- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMVGA-DATA-OPERACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO);

            /*" -1551- MOVE 0 TO MOVIMVGA-COD-SUBGRUPO-TRANS. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO_TRANS);

            /*" -1552- MOVE 'VG1601B' TO MOVIMVGA-COD-USUARIO. */
            _.Move("VG1601B", MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_USUARIO);

            /*" -1553- MOVE SISTEMAS-DATA-MOV-ABERTO TO MOVIMVGA-DATA-AVERBACAO. */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO);

            /*" -1554- MOVE 0 TO WDATA-AVERBACAO. */
            _.Move(0, WDATA_AVERBACAO);

            /*" -1555- MOVE -1 TO WDATA-ADMISSAO. */
            _.Move(-1, WDATA_ADMISSAO);

            /*" -1556- MOVE -1 TO WDATA-INCLUSAO. */
            _.Move(-1, WDATA_INCLUSAO);

            /*" -1557- MOVE SEGURVGA-DATA-NASCIMENTO TO MOVIMVGA-DATA-NASCIMENTO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_DATA_NASCIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO);

            /*" -1558- MOVE -1 TO WDATA-FATURA. */
            _.Move(-1, WDATA_FATURA);

            /*" -1559- MOVE FATCON-DATA-REFER TO MOVIMVGA-DATA-REFERENCIA. */
            _.Move(FATCON_DATA_REFER, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA);

            /*" -1560- MOVE SISTEMAS-DATA-MOVIMENTO TO MOVIMVGA-DATA-MOVIMENTO. */
            _.Move(SISTEMAS_DATA_MOVIMENTO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO);

            /*" -1561- MOVE -1 TO WCOD-EMPRESA. */
            _.Move(-1, WCOD_EMPRESA);

            /*" -1561- MOVE SEGURVGA-LOT-EMP-SEGURADO TO MOVIMVGA-LOT-EMP-SEGURADO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_LOT_EMP_SEGURADO, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_LOT_EMP_SEGURADO);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_516_999_EXIT*/

        [StopWatch]
        /*" M-520-000-ACESSA-FONTE-SECTION */
        private void M_520_000_ACESSA_FONTE_SECTION()
        {
            /*" -1575- MOVE '520' TO WNR-EXEC-SQL. */
            _.Move("520", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1579- MOVE '520-000-ACESSA-FONTE' TO PARAGRAFO. */
            _.Move("520-000-ACESSA-FONTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -1586- PERFORM M_520_000_ACESSA_FONTE_DB_SELECT_1 */

            M_520_000_ACESSA_FONTE_DB_SELECT_1();

            /*" -1589- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1590- DISPLAY 'VG1601B - FONTE NAO CADASTRADA   ' */
                _.Display($"VG1601B - FONTE NAO CADASTRADA   ");

                /*" -1591- DISPLAY 'FONTE ........ ' SUBG-COD-FONTE */
                _.Display($"FONTE ........ {SUBG_COD_FONTE}");

                /*" -1593- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1594- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1595- DISPLAY 'VG1601B - ERRO NA LEITURA DA V1FONTE  ' */
                _.Display($"VG1601B - ERRO NA LEITURA DA V1FONTE  ");

                /*" -1597- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1597- COMPUTE FONTE-PROPAUTOM = FONTE-PROPAUTOM + 1. */
            FONTE_PROPAUTOM.Value = FONTE_PROPAUTOM + 1;

        }

        [StopWatch]
        /*" M-520-000-ACESSA-FONTE-DB-SELECT-1 */
        public void M_520_000_ACESSA_FONTE_DB_SELECT_1()
        {
            /*" -1586- EXEC SQL SELECT PROPAUTOM INTO :FONTE-PROPAUTOM FROM SEGUROS.V1FONTE WHERE FONTE = :FONTE-FONTE END-EXEC. */

            var m_520_000_ACESSA_FONTE_DB_SELECT_1_Query1 = new M_520_000_ACESSA_FONTE_DB_SELECT_1_Query1()
            {
                FONTE_FONTE = FONTE_FONTE.ToString(),
            };

            var executed_1 = M_520_000_ACESSA_FONTE_DB_SELECT_1_Query1.Execute(m_520_000_ACESSA_FONTE_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.FONTE_PROPAUTOM, FONTE_PROPAUTOM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_520_999_EXIT*/

        [StopWatch]
        /*" M-530-000-ATUALIZA-FONTE-SECTION */
        private void M_530_000_ATUALIZA_FONTE_SECTION()
        {
            /*" -1609- MOVE '530' TO WNR-EXEC-SQL. */
            _.Move("530", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1613- MOVE '530-000-ATUALIZA-FONTE' TO PARAGRAFO. */
            _.Move("530-000-ATUALIZA-FONTE", FILLER_0.WABEND.PARAGRAFO);

            /*" -1618- PERFORM M_530_000_ATUALIZA_FONTE_DB_UPDATE_1 */

            M_530_000_ATUALIZA_FONTE_DB_UPDATE_1();

            /*" -1621- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1622- DISPLAY 'VG1601B - FONTE NAO CADASTRADA   ' */
                _.Display($"VG1601B - FONTE NAO CADASTRADA   ");

                /*" -1623- DISPLAY 'FONTE ........ ' SUBG-COD-FONTE */
                _.Display($"FONTE ........ {SUBG_COD_FONTE}");

                /*" -1625- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1626- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1627- DISPLAY 'VG1601B - ERRO NA ATUALIZACAO DA V0FONTE' */
                _.Display($"VG1601B - ERRO NA ATUALIZACAO DA V0FONTE");

                /*" -1627- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-530-000-ATUALIZA-FONTE-DB-UPDATE-1 */
        public void M_530_000_ATUALIZA_FONTE_DB_UPDATE_1()
        {
            /*" -1618- EXEC SQL UPDATE SEGUROS.V0FONTE SET PROPAUTOM = :FONTE-PROPAUTOM, TIMESTAMP = CURRENT TIMESTAMP WHERE FONTE = :FONTE-FONTE END-EXEC. */

            var m_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1 = new M_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1()
            {
                FONTE_PROPAUTOM = FONTE_PROPAUTOM.ToString(),
                FONTE_FONTE = FONTE_FONTE.ToString(),
            };

            M_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1.Execute(m_530_000_ATUALIZA_FONTE_DB_UPDATE_1_Update1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_530_999_EXIT*/

        [StopWatch]
        /*" M-625-000-TRATA-CANCELAMENTO-SECTION */
        private void M_625_000_TRATA_CANCELAMENTO_SECTION()
        {
            /*" -1642- MOVE '625-000-TRATA-CANCELAMENTO ' TO PARAGRAFO. */
            _.Move("625-000-TRATA-CANCELAMENTO ", FILLER_0.WABEND.PARAGRAFO);

            /*" -1644- MOVE '625' TO WNR-EXEC-SQL. */
            _.Move("625", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1645- MOVE SEGURVGA-NUM-APOLICE TO APOL-NUM-APOLICE. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE, APOL_NUM_APOLICE);

            /*" -1647- PERFORM 110-000-ACESSA-V1APOLICE. */

            M_110_000_ACESSA_V1APOLICE_SECTION();

            /*" -1649- PERFORM 800-000-VERIFICA-PREMIOS. */

            M_800_000_VERIFICA_PREMIOS_SECTION();

            /*" -1650- MOVE SEGURVGA-NUM-APOLICE TO SUBG-NUM-APOLICE */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE, SUBG_NUM_APOLICE);

            /*" -1651- MOVE SEGURVGA-COD-SUBGRUPO TO SUBG-COD-SUBGRUPO. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO, SUBG_COD_SUBGRUPO);

            /*" -1653- PERFORM 120-000-ACESSA-V1SUBGRUPO. */

            M_120_000_ACESSA_V1SUBGRUPO_SECTION();

            /*" -1654- MOVE 0 TO ONUM-CTA-CORRENTE */
            _.Move(0, ONUM_CTA_CORRENTE);

            /*" -1655- MOVE ' ' TO ODAC-CTA-CORRENTE */
            _.Move(" ", ODAC_CTA_CORRENTE);

            /*" -1656- MOVE 0 TO OCOD-BANCO */
            _.Move(0, OCOD_BANCO);

            /*" -1657- MOVE 0 TO OCOD-AGENCIA. */
            _.Move(0, OCOD_AGENCIA);

            /*" -1658- IF SUBG-TIPO-COBRANCA EQUAL '3' */

            if (SUBG_TIPO_COBRANCA == "3")
            {

                /*" -1660- PERFORM 840-000-ACESSA-V1CONTACOR. */

                M_840_000_ACESSA_V1CONTACOR_SECTION();
            }


            /*" -1661- MOVE SEGURVGA-NUM-APOLICE TO FATCON-NUM-APOL */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE, FATCON_NUM_APOL);

            /*" -1662- IF APOL-TIPAPO EQUAL '4' */

            if (APOL_TIPAPO == "4")
            {

                /*" -1663- MOVE 0 TO FATCON-COD-SUBG */
                _.Move(0, FATCON_COD_SUBG);

                /*" -1664- ELSE */
            }
            else
            {


                /*" -1666- MOVE SEGURVGA-COD-SUBGRUPO TO FATCON-COD-SUBG. */
                _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_SUBGRUPO, FATCON_COD_SUBG);
            }


            /*" -1668- PERFORM 130-000-ACESSA-V1FATURCONT. */

            M_130_000_ACESSA_V1FATURCONT_SECTION();

            /*" -1669- MOVE MOVIMVGA-IMP-MORNATU-ANT TO MOVIMVGA-IMP-MORNATU-ATU. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ATU);

            /*" -1670- MOVE MOVIMVGA-IMP-MORACID-ANT TO MOVIMVGA-IMP-MORACID-ATU. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ATU);

            /*" -1671- MOVE MOVIMVGA-IMP-INVPERM-ANT TO MOVIMVGA-IMP-INVPERM-ATU. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ATU);

            /*" -1672- MOVE MOVIMVGA-IMP-AMDS-ANT TO MOVIMVGA-IMP-AMDS-ATU. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ATU);

            /*" -1673- MOVE MOVIMVGA-IMP-DH-ANT TO MOVIMVGA-IMP-DH-ATU. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ATU);

            /*" -1674- MOVE MOVIMVGA-IMP-DIT-ANT TO MOVIMVGA-IMP-DIT-ATU. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ATU);

            /*" -1675- MOVE MOVIMVGA-PRM-VG-ANT TO MOVIMVGA-PRM-VG-ATU. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ATU);

            /*" -1677- MOVE MOVIMVGA-PRM-AP-ANT TO MOVIMVGA-PRM-AP-ATU. */
            _.Move(MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ATU);

            /*" -1679- MOVE SEGURVGA-COD-FONTE TO FONTE-FONTE. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_FONTE, FONTE_FONTE);

            /*" -1680- PERFORM 520-000-ACESSA-FONTE */

            M_520_000_ACESSA_FONTE_SECTION();

            /*" -1682- PERFORM 530-000-ATUALIZA-FONTE. */

            M_530_000_ATUALIZA_FONTE_SECTION();

            /*" -1684- PERFORM 480-000-VE-TIPO */

            M_480_000_VE_TIPO_SECTION();

            /*" -1684- PERFORM 500-000-GRAVA-V1MOVIMENTO. */

            M_500_000_GRAVA_V1MOVIMENTO_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_625_999_EXIT*/

        [StopWatch]
        /*" M-800-000-VERIFICA-PREMIOS-SECTION */
        private void M_800_000_VERIFICA_PREMIOS_SECTION()
        {
            /*" -1697- MOVE '800-000-VERIFICA-PREMIOS' TO PARAGRAFO. */
            _.Move("800-000-VERIFICA-PREMIOS", FILLER_0.WABEND.PARAGRAFO);

            /*" -1700- MOVE '800' TO WNR-EXEC-SQL. */
            _.Move("800", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1710- MOVE 0 TO MOVIMVGA-IMP-MORNATU-ANT MOVIMVGA-IMP-MORACID-ANT MOVIMVGA-IMP-INVPERM-ANT MOVIMVGA-IMP-AMDS-ANT MOVIMVGA-IMP-DH-ANT MOVIMVGA-IMP-DIT-ANT MOVIMVGA-IMP-DMH-ANT MOVIMVGA-PRM-VG-ANT MOVIMVGA-PRM-AP-ANT. */
            _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT, MOVIMVGA_IMP_DMH_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT);

            /*" -1711- MOVE SEGURVGA-NUM-APOLICE TO CNUM-APOLICE. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE, CNUM_APOLICE);

            /*" -1712- MOVE SEGURVGA-NUM-ITEM TO CNUM-ITEM. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM, CNUM_ITEM);

            /*" -1714- MOVE SEGURVGA-OCORR-HISTORICO TO COCORHIST. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO, COCORHIST);

            /*" -1715- IF APOL-RAMO = PARAMRAM-RAMO-VGAPC */

            if (APOL_RAMO == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VGAPC)
            {

                /*" -1717- MOVE PARAMRAM-RAMO-VG TO CRAMOFR. */
                _.Move(PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG, CRAMOFR);
            }


            /*" -1718- IF APOL-RAMO = PARAMRAM-RAMO-VG */

            if (APOL_RAMO == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG)
            {

                /*" -1720- MOVE PARAMRAM-RAMO-VG TO CRAMOFR. */
                _.Move(PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_VG, CRAMOFR);
            }


            /*" -1721- IF APOL-RAMO = PARAMRAM-NUM-RAMO-PRSTMISTA */

            if (APOL_RAMO == PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA)
            {

                /*" -1723- MOVE PARAMRAM-NUM-RAMO-PRSTMISTA TO CRAMOFR. */
                _.Move(PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_NUM_RAMO_PRSTMISTA, CRAMOFR);
            }


            /*" -1725- MOVE 11 TO CCOD-COBERTURA. */
            _.Move(11, CCOD_COBERTURA);

            /*" -1727- PERFORM 810-000-SELECT-V1COBERAPOL. */

            M_810_000_SELECT_V1COBERAPOL_SECTION();

            /*" -1728- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1730- MOVE 0 TO MOVIMVGA-IMP-MORNATU-ANT MOVIMVGA-PRM-VG-ANT */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT);

                /*" -1731- ELSE */
            }
            else
            {


                /*" -1734- COMPUTE MOVIMVGA-IMP-MORNATU-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP */
                MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORNATU_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;

                /*" -1736- COMPUTE MOVIMVGA-PRM-VG-ANT ROUNDED = CPRM-TARIFARIO-IX * CFATOR-MULTIPLICA * DVLCRUZAD-PRM. */
                MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_VG_ANT.Value = CPRM_TARIFARIO_IX * CFATOR_MULTIPLICA * DVLCRUZAD_PRM;
            }


            /*" -0- FLUXCONTROL_PERFORM M_801_000_VERIFICA_PREMIO_AP */

            M_801_000_VERIFICA_PREMIO_AP();

        }

        [StopWatch]
        /*" M-801-000-VERIFICA-PREMIO-AP */
        private void M_801_000_VERIFICA_PREMIO_AP(bool isPerform = false)
        {
            /*" -1742- MOVE ZEROS TO FLAG-82. */
            _.Move(0, FLAG_82);

            /*" -1743- MOVE '801-000-VERIFICA-PREMIO-AP' TO PARAGRAFO. */
            _.Move("801-000-VERIFICA-PREMIO-AP", FILLER_0.WABEND.PARAGRAFO);

            /*" -1745- MOVE '801' TO WNR-EXEC-SQL. */
            _.Move("801", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1746- MOVE 81 TO CRAMOFR. */
            _.Move(81, CRAMOFR);

            /*" -1746- MOVE 1 TO CCOD-COBERTURA. */
            _.Move(1, CCOD_COBERTURA);

        }

        [StopWatch]
        /*" M-801-000-LE-DENOVO */
        private void M_801_000_LE_DENOVO(bool isPerform = false)
        {
            /*" -1752- PERFORM 810-000-SELECT-V1COBERAPOL. */

            M_810_000_SELECT_V1COBERAPOL_SECTION();

            /*" -1753- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1754- IF FLAG-82 EQUAL ZEROS */

                if (FLAG_82 == 00)
                {

                    /*" -1755- MOVE 1 TO FLAG-82 */
                    _.Move(1, FLAG_82);

                    /*" -1756- MOVE PARAMRAM-RAMO-AP TO CRAMOFR */
                    _.Move(PARAMRAM.DCLPARAMETROS_RAMOS.PARAMRAM_RAMO_AP, CRAMOFR);

                    /*" -1757- GO TO 801-000-LE-DENOVO */
                    new Task(() => M_801_000_LE_DENOVO()).RunSynchronously(); //GOTO
                    return;//Recursividade detectada, cuidado...

                    /*" -1758- ELSE */
                }
                else
                {


                    /*" -1760- MOVE 0 TO MOVIMVGA-IMP-MORACID-ANT MOVIMVGA-PRM-AP-ANT */
                    _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT);

                    /*" -1761- END-IF */
                }


                /*" -1762- ELSE */
            }
            else
            {


                /*" -1765- COMPUTE MOVIMVGA-IMP-MORACID-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP */
                MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_MORACID_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;

                /*" -1767- COMPUTE MOVIMVGA-PRM-AP-ANT ROUNDED = CPRM-TARIFARIO-IX * CFATOR-MULTIPLICA * DVLCRUZAD-PRM. */
                MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_PRM_AP_ANT.Value = CPRM_TARIFARIO_IX * CFATOR_MULTIPLICA * DVLCRUZAD_PRM;
            }


        }

        [StopWatch]
        /*" M-802-000-VERIFICA-INVPERM */
        private void M_802_000_VERIFICA_INVPERM(bool isPerform = false)
        {
            /*" -1772- MOVE '802-000-VERIFICA-INVPERM' TO PARAGRAFO. */
            _.Move("802-000-VERIFICA-INVPERM", FILLER_0.WABEND.PARAGRAFO);

            /*" -1774- MOVE '802' TO WNR-EXEC-SQL. */
            _.Move("802", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1776- MOVE 2 TO CCOD-COBERTURA. */
            _.Move(2, CCOD_COBERTURA);

            /*" -1778- PERFORM 810-000-SELECT-V1COBERAPOL. */

            M_810_000_SELECT_V1COBERAPOL_SECTION();

            /*" -1779- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1780- MOVE 0 TO MOVIMVGA-IMP-INVPERM-ANT */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT);

                /*" -1781- ELSE */
            }
            else
            {


                /*" -1783- COMPUTE MOVIMVGA-IMP-INVPERM-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP. */
                MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_INVPERM_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;
            }


        }

        [StopWatch]
        /*" M-803-000-VERIFICA-AMDS */
        private void M_803_000_VERIFICA_AMDS(bool isPerform = false)
        {
            /*" -1788- MOVE '803-000-VERIFICA-AMDS' TO PARAGRAFO. */
            _.Move("803-000-VERIFICA-AMDS", FILLER_0.WABEND.PARAGRAFO);

            /*" -1790- MOVE '803' TO WNR-EXEC-SQL. */
            _.Move("803", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1792- MOVE 3 TO CCOD-COBERTURA. */
            _.Move(3, CCOD_COBERTURA);

            /*" -1794- PERFORM 810-000-SELECT-V1COBERAPOL. */

            M_810_000_SELECT_V1COBERAPOL_SECTION();

            /*" -1795- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1796- MOVE 0 TO MOVIMVGA-IMP-AMDS-ANT */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT);

                /*" -1797- ELSE */
            }
            else
            {


                /*" -1799- COMPUTE MOVIMVGA-IMP-AMDS-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP. */
                MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_AMDS_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;
            }


        }

        [StopWatch]
        /*" M-804-000-VERIFICA-DH */
        private void M_804_000_VERIFICA_DH(bool isPerform = false)
        {
            /*" -1804- MOVE '804-000-VERIFICA-DH' TO PARAGRAFO. */
            _.Move("804-000-VERIFICA-DH", FILLER_0.WABEND.PARAGRAFO);

            /*" -1806- MOVE '804' TO WNR-EXEC-SQL. */
            _.Move("804", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1808- MOVE 4 TO CCOD-COBERTURA. */
            _.Move(4, CCOD_COBERTURA);

            /*" -1810- PERFORM 810-000-SELECT-V1COBERAPOL. */

            M_810_000_SELECT_V1COBERAPOL_SECTION();

            /*" -1811- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1812- MOVE 0 TO MOVIMVGA-IMP-DH-ANT */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT);

                /*" -1813- ELSE */
            }
            else
            {


                /*" -1815- COMPUTE MOVIMVGA-IMP-DH-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP. */
                MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DH_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;
            }


        }

        [StopWatch]
        /*" M-805-000-VERIFICA-DIT */
        private void M_805_000_VERIFICA_DIT(bool isPerform = false)
        {
            /*" -1820- MOVE '805-000-VERIFICA-DIT' TO PARAGRAFO. */
            _.Move("805-000-VERIFICA-DIT", FILLER_0.WABEND.PARAGRAFO);

            /*" -1822- MOVE '805' TO WNR-EXEC-SQL. */
            _.Move("805", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1824- MOVE 5 TO CCOD-COBERTURA. */
            _.Move(5, CCOD_COBERTURA);

            /*" -1826- PERFORM 810-000-SELECT-V1COBERAPOL. */

            M_810_000_SELECT_V1COBERAPOL_SECTION();

            /*" -1827- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1828- MOVE 0 TO MOVIMVGA-IMP-DIT-ANT */
                _.Move(0, MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT);

                /*" -1829- ELSE */
            }
            else
            {


                /*" -1831- COMPUTE MOVIMVGA-IMP-DIT-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP. */
                MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_IMP_DIT_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;
            }


        }

        [StopWatch]
        /*" M-806-000-VERIFICA-DMH */
        private void M_806_000_VERIFICA_DMH(bool isPerform = false)
        {
            /*" -1836- MOVE '806-000-VERIFICA-DMH' TO PARAGRAFO. */
            _.Move("806-000-VERIFICA-DMH", FILLER_0.WABEND.PARAGRAFO);

            /*" -1838- MOVE '806' TO WNR-EXEC-SQL. */
            _.Move("806", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1840- MOVE 6 TO CCOD-COBERTURA. */
            _.Move(6, CCOD_COBERTURA);

            /*" -1842- PERFORM 810-000-SELECT-V1COBERAPOL. */

            M_810_000_SELECT_V1COBERAPOL_SECTION();

            /*" -1843- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1844- MOVE 0 TO MOVIMVGA-IMP-DMH-ANT */
                _.Move(0, MOVIMVGA_IMP_DMH_ANT);

                /*" -1845- ELSE */
            }
            else
            {


                /*" -1847- COMPUTE MOVIMVGA-IMP-DMH-ANT ROUNDED = CIMP-SEGURADA-IX * CFATOR-MULTIPLICA * DVLCRUZAD-IMP. */
                MOVIMVGA_IMP_DMH_ANT.Value = CIMP_SEGURADA_IX * CFATOR_MULTIPLICA * DVLCRUZAD_IMP;
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_800_999_EXIT*/

        [StopWatch]
        /*" M-810-000-SELECT-V1COBERAPOL-SECTION */
        private void M_810_000_SELECT_V1COBERAPOL_SECTION()
        {
            /*" -1860- MOVE '810-000-SELECT-V1COBERAPOL' TO PARAGRAFO. */
            _.Move("810-000-SELECT-V1COBERAPOL", FILLER_0.WABEND.PARAGRAFO);

            /*" -1862- MOVE '810' TO WNR-EXEC-SQL. */
            _.Move("810", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1897- PERFORM M_810_000_SELECT_V1COBERAPOL_DB_SELECT_1 */

            M_810_000_SELECT_V1COBERAPOL_DB_SELECT_1();

            /*" -1901- IF SQLCODE EQUAL 100 NEXT SENTENCE */

            if (DB.SQLCODE == 100)
            {

                /*" -1902- ELSE */
            }
            else
            {


                /*" -1903- IF SQLCODE NOT EQUAL 0 */

                if (DB.SQLCODE != 0)
                {

                    /*" -1905- DISPLAY 'VG1601B - NAO EXISTE CAPITAL NA COBERAPOL ' SEGURVGA-NUM-APOLICE */
                    _.Display($"VG1601B - NAO EXISTE CAPITAL NA COBERAPOL {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}");

                    /*" -1906- GO TO 999-999-ROT-ERRO */

                    M_999_999_ROT_ERRO_SECTION(); //GOTO
                    return;

                    /*" -1907- ELSE */
                }
                else
                {


                    /*" -1907- PERFORM 820-000-ACESSA-HISTSEGVG. */

                    M_820_000_ACESSA_HISTSEGVG_SECTION();
                }

            }


        }

        [StopWatch]
        /*" M-810-000-SELECT-V1COBERAPOL-DB-SELECT-1 */
        public void M_810_000_SELECT_V1COBERAPOL_DB_SELECT_1()
        {
            /*" -1897- EXEC SQL SELECT NUM_APOLICE, NRENDOS, NUM_ITEM, OCORHIST, RAMOFR, MODALIFR, COD_COBERTURA, IMP_SEGURADA_IX, PRM_TARIFARIO_IX, FATOR_MULTIPLICA, DATA_INIVIGENCIA INTO :CNUM-APOLICE, :CNRENDOS, :CNUM-ITEM, :COCORHIST, :CRAMOFR, :CMODALIFR, :CCOD-COBERTURA, :CIMP-SEGURADA-IX, :CPRM-TARIFARIO-IX, :CFATOR-MULTIPLICA, :CDATA-INIVIGENCIA FROM SEGUROS.V1COBERAPOL WHERE NUM_APOLICE = :CNUM-APOLICE AND NRENDOS = 0 AND NUM_ITEM = :CNUM-ITEM AND OCORHIST = :COCORHIST AND MODALIFR = 0 AND COD_COBERTURA = :CCOD-COBERTURA AND RAMOFR = :CRAMOFR END-EXEC. */

            var m_810_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1 = new M_810_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1()
            {
                CCOD_COBERTURA = CCOD_COBERTURA.ToString(),
                CNUM_APOLICE = CNUM_APOLICE.ToString(),
                CNUM_ITEM = CNUM_ITEM.ToString(),
                COCORHIST = COCORHIST.ToString(),
                CRAMOFR = CRAMOFR.ToString(),
            };

            var executed_1 = M_810_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1.Execute(m_810_000_SELECT_V1COBERAPOL_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.CNUM_APOLICE, CNUM_APOLICE);
                _.Move(executed_1.CNRENDOS, CNRENDOS);
                _.Move(executed_1.CNUM_ITEM, CNUM_ITEM);
                _.Move(executed_1.COCORHIST, COCORHIST);
                _.Move(executed_1.CRAMOFR, CRAMOFR);
                _.Move(executed_1.CMODALIFR, CMODALIFR);
                _.Move(executed_1.CCOD_COBERTURA, CCOD_COBERTURA);
                _.Move(executed_1.CIMP_SEGURADA_IX, CIMP_SEGURADA_IX);
                _.Move(executed_1.CPRM_TARIFARIO_IX, CPRM_TARIFARIO_IX);
                _.Move(executed_1.CFATOR_MULTIPLICA, CFATOR_MULTIPLICA);
                _.Move(executed_1.CDATA_INIVIGENCIA, CDATA_INIVIGENCIA);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_810_999_EXIT*/

        [StopWatch]
        /*" M-820-000-ACESSA-HISTSEGVG-SECTION */
        private void M_820_000_ACESSA_HISTSEGVG_SECTION()
        {
            /*" -1920- MOVE '820-000-ACESSA-HISTSEGVG' TO PARAGRAFO. */
            _.Move("820-000-ACESSA-HISTSEGVG", FILLER_0.WABEND.PARAGRAFO);

            /*" -1922- MOVE '820' TO WNR-EXEC-SQL. */
            _.Move("820", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1935- PERFORM M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1 */

            M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1();

            /*" -1938- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1940- DISPLAY 'VG1601B - NAO EXISTE ENDOSSO PARA A APOLICE ' SEGURVGA-NUM-APOLICE */
                _.Display($"VG1601B - NAO EXISTE ENDOSSO PARA A APOLICE {SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE}");

                /*" -1942- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1943- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1944- DISPLAY 'VG1601B - ERRO NO SELECT  NA V1ENDOSSO  ' */
                _.Display($"VG1601B - ERRO NO SELECT  NA V1ENDOSSO  ");

                /*" -1946- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1946- PERFORM 830-000-ACESSA-V1MOEDA. */

            M_830_000_ACESSA_V1MOEDA_SECTION();

        }

        [StopWatch]
        /*" M-820-000-ACESSA-HISTSEGVG-DB-SELECT-1 */
        public void M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1()
        {
            /*" -1935- EXEC SQL SELECT VALUE(COD_MOEDA_IMP,01), VALUE(COD_MOEDA_PRM,01) INTO :ECOD-MOEDA-IMP, :ECOD-MOEDA-PRM FROM SEGUROS.SEGURADOSVGAP_HIST WHERE NUM_APOLICE = :SEGURVGA-NUM-APOLICE AND NUM_ITEM = :SEGURVGA-NUM-ITEM AND OCORR_HISTORICO = :SEGURVGA-OCORR-HISTORICO END-EXEC. */

            var m_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1 = new M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1()
            {
                SEGURVGA_OCORR_HISTORICO = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_OCORR_HISTORICO.ToString(),
                SEGURVGA_NUM_APOLICE = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE.ToString(),
                SEGURVGA_NUM_ITEM = SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_ITEM.ToString(),
            };

            var executed_1 = M_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1.Execute(m_820_000_ACESSA_HISTSEGVG_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.ECOD_MOEDA_IMP, ECOD_MOEDA_IMP);
                _.Move(executed_1.ECOD_MOEDA_PRM, ECOD_MOEDA_PRM);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_820_999_EXIT*/

        [StopWatch]
        /*" M-830-000-ACESSA-V1MOEDA-SECTION */
        private void M_830_000_ACESSA_V1MOEDA_SECTION()
        {
            /*" -1959- MOVE '830-000-ACESSA-V1MOEDA' TO PARAGRAFO. */
            _.Move("830-000-ACESSA-V1MOEDA", FILLER_0.WABEND.PARAGRAFO);

            /*" -1961- MOVE '830' TO WNR-EXEC-SQL. */
            _.Move("830", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -1970- PERFORM M_830_000_ACESSA_V1MOEDA_DB_SELECT_1 */

            M_830_000_ACESSA_V1MOEDA_DB_SELECT_1();

            /*" -1973- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -1975- DISPLAY 'VG1601B - NAO CONSTA REGISTRO NA V1MOEDA ' ECOD-MOEDA-IMP ' ' SISTEMAS-DATA-MOV-ABERTO */

                $"VG1601B - NAO CONSTA REGISTRO NA V1MOEDA {ECOD_MOEDA_IMP} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -1977- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1978- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -1979- DISPLAY 'VG1601B - ERRO NO SELECT  NA V1MOEDA  1 ' */
                _.Display($"VG1601B - ERRO NO SELECT  NA V1MOEDA  1 ");

                /*" -1981- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -1982- IF ECOD-MOEDA-IMP EQUAL ECOD-MOEDA-PRM */

            if (ECOD_MOEDA_IMP == ECOD_MOEDA_PRM)
            {

                /*" -1983- MOVE DVLCRUZAD-IMP TO DVLCRUZAD-PRM */
                _.Move(DVLCRUZAD_IMP, DVLCRUZAD_PRM);

                /*" -1986- GO TO 830-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_830_999_EXIT*/ //GOTO
                return;
            }


            /*" -1995- PERFORM M_830_000_ACESSA_V1MOEDA_DB_SELECT_2 */

            M_830_000_ACESSA_V1MOEDA_DB_SELECT_2();

            /*" -1998- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2000- DISPLAY 'VG1601B - NAO CONSTA REGISTRO NA V1MOEDA ' ECOD-MOEDA-PRM ' ' SISTEMAS-DATA-MOV-ABERTO */

                $"VG1601B - NAO CONSTA REGISTRO NA V1MOEDA {ECOD_MOEDA_PRM} {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}"
                .Display();

                /*" -2002- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


            /*" -2003- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2004- DISPLAY 'VG1601B - ERRO NO SELECT  NA V1MOEDA  2 ' */
                _.Display($"VG1601B - ERRO NO SELECT  NA V1MOEDA  2 ");

                /*" -2004- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-830-000-ACESSA-V1MOEDA-DB-SELECT-1 */
        public void M_830_000_ACESSA_V1MOEDA_DB_SELECT_1()
        {
            /*" -1970- EXEC SQL SELECT VLCRUZAD INTO :DVLCRUZAD-IMP FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :ECOD-MOEDA-IMP AND DTINIVIG <= :SISTEMAS-DATA-MOV-ABERTO AND DTTERVIG >= :SISTEMAS-DATA-MOV-ABERTO AND SITUACAO = '0' END-EXEC. */

            var m_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1 = new M_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                ECOD_MOEDA_IMP = ECOD_MOEDA_IMP.ToString(),
            };

            var executed_1 = M_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1.Execute(m_830_000_ACESSA_V1MOEDA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DVLCRUZAD_IMP, DVLCRUZAD_IMP);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_830_999_EXIT*/

        [StopWatch]
        /*" M-830-000-ACESSA-V1MOEDA-DB-SELECT-2 */
        public void M_830_000_ACESSA_V1MOEDA_DB_SELECT_2()
        {
            /*" -1995- EXEC SQL SELECT VLCRUZAD INTO :DVLCRUZAD-PRM FROM SEGUROS.V1MOEDA WHERE CODUNIMO = :ECOD-MOEDA-PRM AND DTINIVIG <= :SISTEMAS-DATA-MOV-ABERTO AND DTTERVIG >= :SISTEMAS-DATA-MOV-ABERTO AND SITUACAO = '0' END-EXEC. */

            var m_830_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1 = new M_830_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1()
            {
                SISTEMAS_DATA_MOV_ABERTO = SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.ToString(),
                ECOD_MOEDA_PRM = ECOD_MOEDA_PRM.ToString(),
            };

            var executed_1 = M_830_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1.Execute(m_830_000_ACESSA_V1MOEDA_DB_SELECT_2_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.DVLCRUZAD_PRM, DVLCRUZAD_PRM);
            }


        }

        [StopWatch]
        /*" M-840-000-ACESSA-V1CONTACOR-SECTION */
        private void M_840_000_ACESSA_V1CONTACOR_SECTION()
        {
            /*" -2020- MOVE '840-000-ACESSA-V1CONTACOR' TO PARAGRAFO. */
            _.Move("840-000-ACESSA-V1CONTACOR", FILLER_0.WABEND.PARAGRAFO);

            /*" -2023- MOVE '840' TO WNR-EXEC-SQL. */
            _.Move("840", FILLER_0.WABEND.WNR_EXEC_SQL);

            /*" -2024- MOVE SEGURVGA-COD-CLIENTE TO OCOD-CLIENTE. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_COD_CLIENTE, OCOD_CLIENTE);

            /*" -2027- MOVE SEGURVGA-NUM-APOLICE TO ONUM-APOLICE. */
            _.Move(SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_NUM_APOLICE, ONUM_APOLICE);

            /*" -2047- PERFORM M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1 */

            M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1();

            /*" -2050- IF SQLCODE EQUAL 100 */

            if (DB.SQLCODE == 100)
            {

                /*" -2051- MOVE 0 TO ONUM-CTA-CORRENTE */
                _.Move(0, ONUM_CTA_CORRENTE);

                /*" -2052- MOVE ' ' TO ODAC-CTA-CORRENTE */
                _.Move(" ", ODAC_CTA_CORRENTE);

                /*" -2053- MOVE 0 TO OCOD-BANCO */
                _.Move(0, OCOD_BANCO);

                /*" -2054- MOVE 0 TO OCOD-AGENCIA */
                _.Move(0, OCOD_AGENCIA);

                /*" -2056- GO TO 840-999-EXIT. */
                /*Método Suprimido por falta de linha ou apenas EXIT nome: M_840_999_EXIT*/ //GOTO
                return;
            }


            /*" -2057- MOVE OCOD-BANCO TO SEGURVGA-BCO-COBRANCA */
            _.Move(OCOD_BANCO, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_BCO_COBRANCA);

            /*" -2059- MOVE OCOD-AGENCIA TO SEGURVGA-AGE-COBRANCA */
            _.Move(OCOD_AGENCIA, SEGURVGA.DCLSEGURADOS_VGAP.SEGURVGA_AGE_COBRANCA);

            /*" -2060- IF SQLCODE NOT EQUAL 0 */

            if (DB.SQLCODE != 0)
            {

                /*" -2062- DISPLAY 'VG1601B - PROBLEMAS NO ACESSO V1CONTACOR  ' ONUM-APOLICE ' ' OCOD-CLIENTE */

                $"VG1601B - PROBLEMAS NO ACESSO V1CONTACOR  {ONUM_APOLICE} {OCOD_CLIENTE}"
                .Display();

                /*" -2062- GO TO 999-999-ROT-ERRO. */

                M_999_999_ROT_ERRO_SECTION(); //GOTO
                return;
            }


        }

        [StopWatch]
        /*" M-840-000-ACESSA-V1CONTACOR-DB-SELECT-1 */
        public void M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1()
        {
            /*" -2047- EXEC SQL SELECT COD_CLIENTE, NUM_APOLICE, COD_BANCO, COD_AGENCIA, NUM_CTA_CORRENTE, DAC_CTA_CORRENTE INTO :OCOD-CLIENTE, :ONUM-APOLICE, :OCOD-BANCO, :OCOD-AGENCIA, :ONUM-CTA-CORRENTE, :ODAC-CTA-CORRENTE FROM SEGUROS.V1CONTACOR WHERE COD_CLIENTE = :OCOD-CLIENTE AND NUM_APOLICE = :ONUM-APOLICE END-EXEC. */

            var m_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1 = new M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1()
            {
                OCOD_CLIENTE = OCOD_CLIENTE.ToString(),
                ONUM_APOLICE = ONUM_APOLICE.ToString(),
            };

            var executed_1 = M_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1.Execute(m_840_000_ACESSA_V1CONTACOR_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.OCOD_CLIENTE, OCOD_CLIENTE);
                _.Move(executed_1.ONUM_APOLICE, ONUM_APOLICE);
                _.Move(executed_1.OCOD_BANCO, OCOD_BANCO);
                _.Move(executed_1.OCOD_AGENCIA, OCOD_AGENCIA);
                _.Move(executed_1.ONUM_CTA_CORRENTE, ONUM_CTA_CORRENTE);
                _.Move(executed_1.ODAC_CTA_CORRENTE, ODAC_CTA_CORRENTE);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_840_999_EXIT*/

        [StopWatch]
        /*" M-900-000-FINALIZA-SECTION */
        private void M_900_000_FINALIZA_SECTION()
        {
            /*" -2073- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -2077- MOVE ZEROS TO RETURN-CODE */
            _.Move(0, RETURN_CODE);

            /*" -2077- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: M_900_999_EXIT*/

        [StopWatch]
        /*" R9900-00-ENCERRA-SEM-MOVTO-SECTION */
        private void R9900_00_ENCERRA_SEM_MOVTO_SECTION()
        {
            /*" -2090- MOVE SISTEMAS-DATA-MOV-ABERTO TO WDATA-REL */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, FILLER_0.WDATA_REL);

            /*" -2091- MOVE WDAT-REL-DIA TO WDAT-LIT-DIA */
            _.Move(FILLER_0.FILLER_17.WDAT_REL_DIA, FILLER_0.WDAT_REL_LIT.WDAT_LIT_DIA);

            /*" -2092- MOVE WDAT-REL-MES TO WDAT-LIT-MES */
            _.Move(FILLER_0.FILLER_17.WDAT_REL_MES, FILLER_0.WDAT_REL_LIT.WDAT_LIT_MES);

            /*" -2093- MOVE WDAT-REL-SEC TO WDAT-LIT-SEC */
            _.Move(FILLER_0.FILLER_17.WDAT_REL_SEC, FILLER_0.WDAT_REL_LIT.WDAT_LIT_SEC);

            /*" -2095- MOVE WDAT-REL-ANO TO WDAT-LIT-ANO */
            _.Move(FILLER_0.FILLER_17.WDAT_REL_ANO, FILLER_0.WDAT_REL_LIT.WDAT_LIT_ANO);

            /*" -2096- DISPLAY '*--------------------------------------------*' */
            _.Display($"*--------------------------------------------*");

            /*" -2097- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -2098- DISPLAY '*  VG1601B - CONSISTENCIA LOGICA MOVIMENTO   *' */
            _.Display($"*  VG1601B - CONSISTENCIA LOGICA MOVIMENTO   *");

            /*" -2099- DISPLAY '*  -------   ------------ ------ ---------   *' */
            _.Display($"*  -------   ------------ ------ ---------   *");

            /*" -2100- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -2101- DISPLAY '*     NAO HOUVE MOVIMENTACAO NESTA DATA      *' */
            _.Display($"*     NAO HOUVE MOVIMENTACAO NESTA DATA      *");

            /*" -2103- DISPLAY '*               ' WDAT-REL-LIT '                     *' */

            $"*               {FILLER_0.WDAT_REL_LIT}                     *"
            .Display();

            /*" -2104- DISPLAY '*                                            *' */
            _.Display($"*                                            *");

            /*" -2104- DISPLAY '*--------------------------------------------*' . */
            _.Display($"*--------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" M-999-999-ROT-ERRO-SECTION */
        private void M_999_999_ROT_ERRO_SECTION()
        {
            /*" -2117- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -2118- MOVE SQLCODE TO WSQLCODE */
                _.Move(DB.SQLCODE, FILLER_0.WABEND.WSQLCODE);

                /*" -2119- MOVE SQLERRD(1) TO WSQLCODE1 */
                _.Move(DB.SQLERRD[1], FILLER_0.WABEND.WSQLCODE1);

                /*" -2120- MOVE SQLERRD(2) TO WSQLCODE2 */
                _.Move(DB.SQLERRD[2], FILLER_0.WABEND.WSQLCODE2);

                /*" -2121- MOVE SQLCODE TO WSQLCODE3 */
                _.Move(DB.SQLCODE, FILLER_0.WSQLCODE3);

                /*" -2122- DISPLAY WABEND */
                _.Display(FILLER_0.WABEND);

                /*" -2123- DISPLAY SPACES */
                _.Display($"");

                /*" -2125- DISPLAY REGISTRO-LEITURA. */
                _.Display(REGISTRO_LEITURA);
            }


            /*" -2127- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -2131- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -2134- MOVE 99 TO RETURN-CODE */
            _.Move(99, RETURN_CODE);

            /*" -2134- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
    }
}