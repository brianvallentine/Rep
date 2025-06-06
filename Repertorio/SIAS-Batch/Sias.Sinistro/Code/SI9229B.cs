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
using Sias.Sinistro.DB2.SI9229B;

namespace Code
{
    public class SI9229B
    {
        public bool IsCall { get; set; }

        public SI9229B()
        {
            AppSettings.Load();
        }

        #region PROG HEADER
        /*"      *----------------------------------------------------------------*      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   SISTEMA ................  SINISTRO                           *      */
        /*"      *   PROGRAMA ...............  SI9229B                            *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   ANALISTA ...............  ANTONIO PAULINO                    *      */
        /*"      *   PROGRAMADOR ............  ANTONIO PAULINO                    *      */
        /*"      *   DATA CODIFICACAO .......  MAR�O  / 2018                      *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *   FUNCAO .................  GERA RELATORIO COM PERIODICIDADE   *      */
        /*"      *                             DIARIO DOS SINISTROS AVISADOS.     *      */
        /*"      *   V.01                                                         *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      * TABELAS                     DCLGEN                    ACESSO   *      */
        /*"      * -------------------------------------------------------------- *      */
        /*"      * ENDOSSOS                    ENDOSSOS                  INPUT    *      */
        /*"      * SINISTRO_HISTORICO          SINISHIS                  INPUT    *      */
        /*"      * SINISTRO_MESTRE             SINISMES                  INPUT    *      */
        /*"      * SEGUROS.APOLICES            APOLICES                  INPUT    *      */
        /*"      * PRODUTO                     PRODUTO                   INPUT    *      */
        /*"      * SEGUROS.SISTEMAS            SISTEMAS                  INPUT    *      */
        /*"      * SEGUROS.CLIENTES            CLIENTES                  INPUT    *      */
        /*"      * SI_AR_DETALHE_VC            SIARDEVC                  INPUT    *      */
        /*"      * SEGUROS.ENDERECOS           ENDERECO                  INPUT    *      */
        /*"      * SEGUROS.GE_SIS_FUNCAO_OPER  GESISFUO                  INPUT    *      */
        /*"      * SEGUROS.GE_AR_DETALHE       GEARDETA                  INPUT    *      */
        /*"      * SEGUROS.CAUSA_COBERTURA     CAUSACOB                  INPUT    *      */
        /*"      * SEGUROS.SINISTRO_CAUSA      SINISCAU                  INPUT    *      */
        /*"      * SEGUROS.COBERTURAS_DESCR    COBERDES                  INPUT    *      */
        /*"      * SEGUROS.RAMOS               RAMOS                     INPUT    *      */
        /*"      *                                                                       */
        /*"      * APOLICE_AUTO                APOLIAUT                  INPUT    *      */
        /*"      * VEICULOS_DESCRICAO          VEICUDES                  INPUT    *      */
        /*"      * SINISTRO_CAUSA              SINISCAU                  INPUT    *      */
        /*"      *                                                                       */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                     A L T E R A C O E S                        *      */
        /*"      *----------------------------------------------------------------*      */
        /*"      *                                                                       */
        #endregion


        #region VARIABLES

        public FileBasis _SIAVISAD { get; set; } = new FileBasis(new PIC("X", "468", "X(468)"));

        public FileBasis SIAVISAD
        {
            get
            {
                _.Move(REG_SIAVISAD, _SIAVISAD); VarBasis.RedefinePassValue(REG_SIAVISAD, _SIAVISAD, REG_SIAVISAD); return _SIAVISAD;
            }
        }
        /*"01  REG-SIAVISAD            PIC X(468).*/
        public StringBasis REG_SIAVISAD { get; set; } = new StringBasis(new PIC("X", "468", "X(468)."), @"");

        /*"*/
        public IntBasis RETURN_CODE { get; set; } = new IntBasis(new PIC("S9", "04", "S9(04)"));
        /*"01 HDR-TITULO                   PIC  X(468)  VALUE SPACES.*/
        public StringBasis HDR_TITULO { get; set; } = new StringBasis(new PIC("X", "468", "X(468)"), @"");
        /*"01 HDR-SI9229B0.*/
        public SI9229B_HDR_SI9229B0 HDR_SI9229B0 { get; set; } = new SI9229B_HDR_SI9229B0();
        public class SI9229B_HDR_SI9229B0 : VarBasis
        {
            /*"  05 HDR-COD-PRODUTO            PIC  X(014)     VALUE 'CODIGO PRODUTO'.*/
            public StringBasis HDR_COD_PRODUTO { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"CODIGO PRODUTO");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_0 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-COD-CAUSA              PIC  X(012)     VALUE 'CODIGO CAUSA'.*/
            public StringBasis HDR_COD_CAUSA { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"CODIGO CAUSA");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_1 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-DES-CAUSA              PIC  X(015)     VALUE 'DESCRI��O CAUSA'.*/
            public StringBasis HDR_DES_CAUSA { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"DESCRI��O CAUSA");
            /*"  05 FILLER                     PIC  X(025) VALUE SPACES.*/
            public StringBasis FILLER_2 { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_3 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-COBERTURA              PIC  X(009)     VALUE 'COBERTURA'.*/
            public StringBasis HDR_COBERTURA { get; set; } = new StringBasis(new PIC("X", "9", "X(009)"), @"COBERTURA");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_4 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-DES-COBERTURA          PIC  X(019)     VALUE 'DESCRI��O COBERTURA'.*/
            public StringBasis HDR_DES_COBERTURA { get; set; } = new StringBasis(new PIC("X", "19", "X(019)"), @"DESCRI��O COBERTURA");
            /*"  05 FILLER                     PIC  X(021) VALUE SPACES.*/
            public StringBasis FILLER_5 { get; set; } = new StringBasis(new PIC("X", "21", "X(021)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_6 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-NUM-APOLICE            PIC  X(011)     VALUE 'NUM APOLICE'.*/
            public StringBasis HDR_NUM_APOLICE { get; set; } = new StringBasis(new PIC("X", "11", "X(011)"), @"NUM APOLICE");
            /*"  05 FILLER                     PIC  X(002) VALUE SPACES.*/
            public StringBasis FILLER_7 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_8 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-CPF-CNPJ-SEGURADO      PIC  X(012)     VALUE 'CPF SEGURADO'.*/
            public StringBasis HDR_CPF_CNPJ_SEGURADO { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"CPF SEGURADO");
            /*"  05 FILLER                     PIC  X(003) VALUE SPACES.*/
            public StringBasis FILLER_9 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_10 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-NOME-SEGURADO          PIC  X(013)     VALUE 'NOME SEGURADO'.*/
            public StringBasis HDR_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"NOME SEGURADO");
            /*"  05 FILLER                     PIC  X(027) VALUE SPACES.*/
            public StringBasis FILLER_11 { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_12 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-INI-VIGENCIA           PIC  X(020)     VALUE 'DATA INICIO VIGENCIA'.*/
            public StringBasis HDR_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"DATA INICIO VIGENCIA");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_13 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-FIM-VIGENCIA           PIC  X(020)     VALUE 'DATA FIM DE VIGENCIA'.*/
            public StringBasis HDR_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "20", "X(020)"), @"DATA FIM DE VIGENCIA");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_14 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-NUM-SINISTRO           PIC  X(012)     VALUE 'NUM SINISTRO'.*/
            public StringBasis HDR_NUM_SINISTRO { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"NUM SINISTRO");
            /*"  05 FILLER                     PIC  X(003) VALUE SPACES.*/
            public StringBasis FILLER_15 { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_16 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-DT-OCORR-SINIS         PIC  X(027)     VALUE 'DATA OCORRENCIA DO SINISTRO'.*/
            public StringBasis HDR_DT_OCORR_SINIS { get; set; } = new StringBasis(new PIC("X", "27", "X(027)"), @"DATA OCORRENCIA DO SINISTRO");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_17 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-DT-AVISO-SINIS         PIC  X(025)     VALUE 'DATA DO AVISO DO SINISTRO'.*/
            public StringBasis HDR_DT_AVISO_SINIS { get; set; } = new StringBasis(new PIC("X", "25", "X(025)"), @"DATA DO AVISO DO SINISTRO");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_18 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-VL-AVISADO             PIC  X(013)     VALUE 'VALOR AVISADO'.*/
            public StringBasis HDR_VL_AVISADO { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @"VALOR AVISADO");
            /*"  05 FILLER                     PIC  X(002) VALUE SPACES.*/
            public StringBasis FILLER_19 { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_20 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-ENDOSSO                PIC  X(015)     VALUE 'POSSUI ENDOSSO?'.*/
            public StringBasis HDR_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"POSSUI ENDOSSO?");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_21 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-DT-INI-VIG-ENDOSSO     PIC  X(028)     VALUE 'DATA IN�CIO VIG�NCIA ENDOSSO'.*/
            public StringBasis HDR_DT_INI_VIG_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "28", "X(028)"), @"DATA IN�CIO VIG�NCIA ENDOSSO");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_22 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-UF-RISCO               PIC  X(014)     VALUE 'UF LOCAL RISCO'.*/
            public StringBasis HDR_UF_RISCO { get; set; } = new StringBasis(new PIC("X", "14", "X(014)"), @"UF LOCAL RISCO");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_23 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-CIDADE-RISCO           PIC  X(018)     VALUE 'CIDADE LOCAL RISCO'.*/
            public StringBasis HDR_CIDADE_RISCO { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"CIDADE LOCAL RISCO");
            /*"  05 FILLER                     PIC  X(054) VALUE SPACES.*/
            public StringBasis FILLER_24 { get; set; } = new StringBasis(new PIC("X", "54", "X(054)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_25 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 HDR-AVISO-PREMATURO        PIC  X(015)     VALUE 'AVISO PREMATURO'.*/
            public StringBasis HDR_AVISO_PREMATURO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"AVISO PREMATURO");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_26 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01 DETALHE-SI9229B0.*/
        }
        public SI9229B_DETALHE_SI9229B0 DETALHE_SI9229B0 { get; set; } = new SI9229B_DETALHE_SI9229B0();
        public class SI9229B_DETALHE_SI9229B0 : VarBasis
        {
            /*"  05 DET-COD-PRODUTO            PIC  9(009) VALUE ZEROS.*/
            public IntBasis DET_COD_PRODUTO { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05 FILLER                     PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_27 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_28 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-COD-CAUSA              PIC  9(004) VALUE ZEROS.*/
            public IntBasis DET_COD_CAUSA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05 FILLER                     PIC  X(008) VALUE SPACES.*/
            public StringBasis FILLER_29 { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_30 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-DES-CAUSA              PIC  X(040) VALUE SPACES.*/
            public StringBasis DET_DES_CAUSA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_31 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-COBERTURA              PIC  9(004) VALUE ZEROS.*/
            public IntBasis DET_COBERTURA { get; set; } = new IntBasis(new PIC("9", "4", "9(004)"));
            /*"  05 FILLER                     PIC  X(005) VALUE SPACES.*/
            public StringBasis FILLER_32 { get; set; } = new StringBasis(new PIC("X", "5", "X(005)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_33 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-DES-COBERTURA          PIC  X(040) VALUE SPACES.*/
            public StringBasis DET_DES_COBERTURA { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_34 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-NUM-APOLICE            PIC  9(013) VALUE ZEROS.*/
            public IntBasis DET_NUM_APOLICE { get; set; } = new IntBasis(new PIC("9", "13", "9(013)"));
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_35 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-CPF-CNPJ-SEGURADO      PIC  9(015).*/
            public IntBasis DET_CPF_CNPJ_SEGURADO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)."));
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_36 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-NOME-SEGURADO          PIC  X(040) VALUE SPACES.*/
            public StringBasis DET_NOME_SEGURADO { get; set; } = new StringBasis(new PIC("X", "40", "X(040)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_37 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-INI-VIGENCIA           PIC  X(010) VALUE SPACES.*/
            public StringBasis DET_INI_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05 FILLER                     PIC  X(010) VALUE SPACES.*/
            public StringBasis FILLER_38 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_39 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-FIM-VIGENCIA           PIC  X(010) VALUE SPACES.*/
            public StringBasis DET_FIM_VIGENCIA { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05 FILLER                     PIC  X(010) VALUE SPACES.*/
            public StringBasis FILLER_40 { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_41 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-NUM-SINISTRO           PIC  9(015) VALUE ZEROS.*/
            public IntBasis DET_NUM_SINISTRO { get; set; } = new IntBasis(new PIC("9", "15", "9(015)"));
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_42 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-DT-OCORR-SINIS         PIC  X(010) VALUE SPACES.*/
            public StringBasis DET_DT_OCORR_SINIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05 FILLER                     PIC  X(017) VALUE SPACES.*/
            public StringBasis FILLER_43 { get; set; } = new StringBasis(new PIC("X", "17", "X(017)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_44 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-DT-AVISO-SINIS         PIC  X(010) VALUE SPACES.*/
            public StringBasis DET_DT_AVISO_SINIS { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05 FILLER                     PIC  X(015) VALUE SPACES.*/
            public StringBasis FILLER_45 { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_46 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-VL-AVISADO             PIC  X(015) VALUE '0,00'.*/
            public StringBasis DET_VL_AVISADO { get; set; } = new StringBasis(new PIC("X", "15", "X(015)"), @"0,00");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_47 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-ENDOSSO                PIC  X(003).*/
            public StringBasis DET_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)."), @"");
            /*"  05 FILLER                     PIC  X(012) VALUE SPACES.*/
            public StringBasis FILLER_48 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_49 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-DT-INI-VIG-ENDOSSO     PIC  X(010) VALUE SPACES.*/
            public StringBasis DET_DT_INI_VIG_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "10", "X(010)"), @"");
            /*"  05 FILLER                     PIC  X(018) VALUE SPACES.*/
            public StringBasis FILLER_50 { get; set; } = new StringBasis(new PIC("X", "18", "X(018)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_51 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-UF-RISCO               PIC  X(002) VALUE SPACES.*/
            public StringBasis DET_UF_RISCO { get; set; } = new StringBasis(new PIC("X", "2", "X(002)"), @"");
            /*"  05 FILLER                     PIC  X(012) VALUE SPACES.*/
            public StringBasis FILLER_52 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_53 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-CIDADE-RISCO           PIC  X(072) VALUE SPACES.*/
            public StringBasis DET_CIDADE_RISCO { get; set; } = new StringBasis(new PIC("X", "72", "X(072)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_54 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"  05 DET-AVISO-PREMATURO        PIC  X(003) VALUE SPACES.*/
            public StringBasis DET_AVISO_PREMATURO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
            /*"  05 FILLER                     PIC  X(012) VALUE SPACES.*/
            public StringBasis FILLER_55 { get; set; } = new StringBasis(new PIC("X", "12", "X(012)"), @"");
            /*"  05 FILLER                     PIC  X(001) VALUE ';'.*/
            public StringBasis FILLER_56 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @";");
            /*"01 HOST-TRATA-NULOS.*/
        }
        public SI9229B_HOST_TRATA_NULOS HOST_TRATA_NULOS { get; set; } = new SI9229B_HOST_TRATA_NULOS();
        public class SI9229B_HOST_TRATA_NULOS : VarBasis
        {
            /*"   05 HOST-IND-TP-RENOVACAO     PIC S9(004)          COMP.*/
            public IntBasis HOST_IND_TP_RENOVACAO { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 HOST-NUM-APOL-VC          PIC S9(004)          COMP.*/
            public IntBasis HOST_NUM_APOL_VC { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"   05 HOST-CGCCPF               PIC S9(004)          COMP.*/
            public IntBasis HOST_CGCCPF { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
            /*"01  WS-ACUMULADORES.*/
        }
        public SI9229B_WS_ACUMULADORES WS_ACUMULADORES { get; set; } = new SI9229B_WS_ACUMULADORES();
        public class SI9229B_WS_ACUMULADORES : VarBasis
        {
            /*"    05  WS-QTD-SI9229B0         PIC  S9(009) USAGE COMP        VALUE ZEROS.*/
            public IntBasis WS_QTD_SI9229B0 { get; set; } = new IntBasis(new PIC("S9", "9", "S9(009)"));
            /*"01 WS-VLR-AVISADO               PIC  S9(013)V9(2) USAGE COMP-3.*/
        }
        public DoubleBasis WS_VLR_AVISADO { get; set; } = new DoubleBasis(new PIC("S9", "13", "S9(013)V9(2)"), 2);
        /*"01 WS-VLR-AVISADO-E             PIC  ZZZ.ZZZ.ZZ9,99-.*/
        public DoubleBasis WS_VLR_AVISADO_E { get; set; } = new DoubleBasis(new PIC("9", "9", "ZZZ.ZZZ.ZZ9V99-."), 3);
        /*"01 WS-E-ENDOSSO                 PIC   X(003) VALUE SPACES.*/
        public StringBasis WS_E_ENDOSSO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01 WS-E-PREMATURO               PIC   X(003) VALUE SPACES.*/
        public StringBasis WS_E_PREMATURO { get; set; } = new StringBasis(new PIC("X", "3", "X(003)"), @"");
        /*"01 WS-PROGRAMA                  PIC   X(008) VALUE SPACES.*/
        public StringBasis WS_PROGRAMA { get; set; } = new StringBasis(new PIC("X", "8", "X(008)"), @"");
        /*"01 HOST-ANO-MOV-SISTEMAS        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis HOST_ANO_MOV_SISTEMAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01 HOST-MES-MOV-SISTEMAS        PIC S9(004)      VALUE +0 COMP.*/
        public IntBasis HOST_MES_MOV_SISTEMAS { get; set; } = new IntBasis(new PIC("S9", "4", "S9(004)"));
        /*"01          AREA-DE-WORK.*/
        public SI9229B_AREA_DE_WORK AREA_DE_WORK { get; set; } = new SI9229B_AREA_DE_WORK();
        public class SI9229B_AREA_DE_WORK : VarBasis
        {
            /*"  05        WSL-SQLCODE         PIC  9(009)      VALUE  ZEROS.*/
            public IntBasis WSL_SQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "9(009)"));
            /*"  05        WSTATUS             PIC  9(002)      VALUE  ZEROS.*/
            public IntBasis WSTATUS { get; set; } = new IntBasis(new PIC("9", "2", "9(002)"));
            /*"  05        WS-FIM-CUR01        PIC  X(001)      VALUE 'N'.*/
            public StringBasis WS_FIM_CUR01 { get; set; } = new StringBasis(new PIC("X", "1", "X(001)"), @"N");
            /*"01          WABEND.*/
        }
        public SI9229B_WABEND WABEND { get; set; } = new SI9229B_WABEND();
        public class SI9229B_WABEND : VarBasis
        {
            /*"  05        FILLER              PIC  X(007)      VALUE 'SI9229B'*/
            public StringBasis FILLER_57 { get; set; } = new StringBasis(new PIC("X", "7", "X(007)"), @"SI9229B");
            /*"  05        FILLER              PIC  X(035)      VALUE           ' *** ERRO OCORRIDO NO PARAGRAFO NR '.*/
            public StringBasis FILLER_58 { get; set; } = new StringBasis(new PIC("X", "35", "X(035)"), @" *** ERRO OCORRIDO NO PARAGRAFO NR ");
            /*"  05        WNR-EXEC-SQL        PIC  X(004)      VALUE '0000'.*/
            public StringBasis WNR_EXEC_SQL { get; set; } = new StringBasis(new PIC("X", "4", "X(004)"), @"0000");
            /*"  05        FILLER              PIC  X(013)      VALUE           ' *** SQLCODE '.*/
            public StringBasis FILLER_59 { get; set; } = new StringBasis(new PIC("X", "13", "X(013)"), @" *** SQLCODE ");
            /*"  05        WSQLCODE            PIC  ZZZZZ999-   VALUE ZEROS.*/
            public IntBasis WSQLCODE { get; set; } = new IntBasis(new PIC("9", "9", "ZZZZZ999-"));
        }


        public Dclgens.ENDOSSOS ENDOSSOS { get; set; } = new Dclgens.ENDOSSOS();
        public Dclgens.SINISHIS SINISHIS { get; set; } = new Dclgens.SINISHIS();
        public Dclgens.APOLICES APOLICES { get; set; } = new Dclgens.APOLICES();
        public Dclgens.PRODUTO PRODUTO { get; set; } = new Dclgens.PRODUTO();
        public Dclgens.SISTEMAS SISTEMAS { get; set; } = new Dclgens.SISTEMAS();
        public Dclgens.CLIENTES CLIENTES { get; set; } = new Dclgens.CLIENTES();
        public Dclgens.SIARDEVC SIARDEVC { get; set; } = new Dclgens.SIARDEVC();
        public Dclgens.ENDERECO ENDERECO { get; set; } = new Dclgens.ENDERECO();
        public Dclgens.GESISFUO GESISFUO { get; set; } = new Dclgens.GESISFUO();
        public Dclgens.SINISMES SINISMES { get; set; } = new Dclgens.SINISMES();
        public Dclgens.CALENDAR CALENDAR { get; set; } = new Dclgens.CALENDAR();
        public Dclgens.GEARDETA GEARDETA { get; set; } = new Dclgens.GEARDETA();
        public Dclgens.CAUSACOB CAUSACOB { get; set; } = new Dclgens.CAUSACOB();
        public Dclgens.SINISCAU SINISCAU { get; set; } = new Dclgens.SINISCAU();
        public Dclgens.COBERDES COBERDES { get; set; } = new Dclgens.COBERDES();
        public Dclgens.RAMOS RAMOS { get; set; } = new Dclgens.RAMOS();

        public SI9229B_CUR01_HIST_MESTRE CUR01_HIST_MESTRE { get; set; } = new SI9229B_CUR01_HIST_MESTRE(true);
        string GetQuery_CUR01_HIST_MESTRE()
        {
            var query = @$"SELECT A.COD_PRODUTO AS PRODUTO
							, B.COD_CAUSA AS COD_CAUSA
							, J.DESCR_CAUSA AS DESCR_CAUSA
							, VALUE(I.COD_COBERTURA
							,0) AS COBERTURA
							, VALUE(L.DESCR_COBERTURA
							,' ') AS DESC_COBERTURA
							, B.NUM_APOLICE AS NUM_APOLICE
							, VALUE(E.CGCCPF
							,0) AS CPF_CNPJ_SEGURADO
							, VALUE(E.NOME_RAZAO
							,' ') AS NOME_SEGURADO
							, VALUE(F.DATA_INIVIGENCIA
							,'9999-12-31') AS INICIO_VIGENCIA
							, VALUE(F.DATA_TERVIGENCIA
							,'999912-31') AS TERMINO_VIGENCIA
							, VALUE(A.NUM_APOL_SINISTRO
							,0) AS NUM_SINISTRO
							, VALUE(B.DATA_OCORRENCIA
							,'9999-12-31') AS DATA_OCORRENCIA
							, VALUE(B.DATA_TECNICA
							,'9999-12-31') AS DATA_AVISO
							, VALUE((SELECT (SUM(X.VAL_OPERACAO * B.NUM_FATOR))
							FROM SEGUROS.SINISTRO_HISTORICO X
							, SEGUROS.GE_SIS_FUNCAO_OPER B WHERE X.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO AND B.IDE_SISTEMA = 'SI' AND B.COD_FUNCAO = 4 AND B.IDE_SISTEMA_OPER = 'SI' AND B.TIPO_ENDOSSO = '9' AND B.COD_OPERACAO = X.COD_OPERACAO )
							,0) AS VLR_AVISADO
							, VALUE((CASE WHEN B.NUM_ENDOSSO = 0 THEN 'NAO' ELSE 'SIM' END )
							,' ') AS E_ENDOSSO
							, VALUE((CASE WHEN B.NUM_ENDOSSO = 0 THEN '9999-12-31' ELSE
							(SELECT  (P.DATA_EMISSAO)
							FROM SEGUROS.ENDOSSOS P WHERE P.NUM_APOLICE = A.NUM_APOLICE AND P.NUM_ENDOSSO =
							(SELECT  MAX(Q.NUM_ENDOSSO)
							FROM SEGUROS.ENDOSSOS Q WHERE Q.NUM_APOLICE = A.NUM_APOLICE )) END )
							,'9999-12-31') AS ULTIMA_EMISSAO
							, VALUE(H.SIGLA_UF
							,' ') AS UF
							, VALUE(H.CIDADE
							,' ') AS CIDADE
							, CASE WHEN VALUE(DATE(DAYS(B.DATA_TECNICA) - 60)
							,'9999-12-31') < VALUE(F.DATA_INIVIGENCIA
							,'9999-12-31') THEN 'SIM' ELSE 'N�O' END AS E_PREMATURO
							FROM SEGUROS.SINISTRO_HISTORICO A
							JOIN SEGUROS.SINISTRO_MESTRE B ON B.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO
							JOIN SEGUROS.PRODUTO C ON C.COD_PRODUTO = A.COD_PRODUTO
							JOIN SEGUROS.APOLICES D ON D.NUM_APOLICE = A.NUM_APOLICE
							LEFT JOIN SEGUROS.CLIENTES E ON E.COD_CLIENTE = D.COD_CLIENTE
							LEFT JOIN SEGUROS.ENDOSSOS F ON F.NUM_APOLICE = A.NUM_APOLICE AND F.NUM_ENDOSSO = 0 LEFT OUTER
							JOIN SEGUROS.SI_AR_DETALHE_VC G ON G.OCORR_HISTORICO = A.OCORR_HISTORICO AND G.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO AND G.COD_OPERACAO = A.COD_OPERACAO
							LEFT JOIN SEGUROS.ENDERECOS H ON H.COD_CLIENTE = D.COD_CLIENTE AND H.OCORR_ENDERECO = F.OCORR_ENDERECO
							LEFT JOIN SEGUROS.CAUSA_COBERTURA I ON I.COD_CAUSA = B.COD_CAUSA AND I.RAMO = B.RAMO
							LEFT JOIN SEGUROS.SINISTRO_CAUSA J ON J.COD_CAUSA = B.COD_CAUSA AND J.RAMO_EMISSOR = B.RAMO
							LEFT JOIN SEGUROS.COBERTURAS_DESCR L ON L.RAMO_COBERTURA = B.RAMO AND ((TRIM(SUBSTR(DIGITS(L.COD_COBERTURA)
							,2
							,2)) = B.RAMO AND TRIM(SUBSTR(DIGITS(L.COD_COBERTURA)
							,4
							,2)) = I.COD_COBERTURA) OR (L.COD_COBERTURA = I.COD_COBERTURA)) WHERE A.COD_PRODUTO IN (1803
							, 1805
							, 3172
							, 3173
							, 3174
							, 3175
							, 3176
							, 3177
							, 3178
							, 3179
							, 3180
							, 3181
							, 3182
							, 3183
							, 5302
							, 5303
							, 5304) AND ((A.COD_OPERACAO = 1001 AND EXISTS
							(SELECT  (Z.NUM_APOL_SINISTRO)
							FROM SEGUROS.SINISTRO_HISTORICO Z WHERE Z.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO AND Z.COD_OPERACAO = 101)) OR (A.COD_OPERACAO = 101 AND NOT EXISTS
							(SELECT  (Z.NUM_APOL_SINISTRO)
							FROM SEGUROS.SINISTRO_HISTORICO Z WHERE Z.NUM_APOL_SINISTRO = A.NUM_APOL_SINISTRO AND Z.ORDEM_PAGAMENTO <> 0 ))) AND A.DATA_MOVIMENTO BETWEEN '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN}' AND '{SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}' ORDER BY A.NUM_APOL_SINISTRO
							, B.COD_CAUSA
							, B.DATA_TECNICA";

            return query;
        }

        public dynamic Result { get; set; }

        #endregion

        [StopWatch]
        /*" Execute */
        public dynamic Execute(string SIAVISAD_FILE_NAME_P) //PROCEDURE DIVISION 
        /**/
        {
            try
            {
                SIAVISAD.SetFile(SIAVISAD_FILE_NAME_P);
                InitializeGetQuery();

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

        public void InitializeGetQuery()
        {
            CUR01_HIST_MESTRE.GetQueryEvent += GetQuery_CUR01_HIST_MESTRE;
        }

        [StopWatch]
        /*" R0000-00-PRINCIPAL-SECTION */
        private void R0000_00_PRINCIPAL_SECTION()
        {
            /*" -402- MOVE '0000' TO WNR-EXEC-SQL. */
            _.Move("0000", WABEND.WNR_EXEC_SQL);

            /*" -402- EXEC SQL WHENEVER SQLWARNING CONTINUE END-EXEC. */

            /*" -403- EXEC SQL WHENEVER SQLERROR CONTINUE END-EXEC. */

            /*" -404- EXEC SQL WHENEVER NOT FOUND CONTINUE END-EXEC. */

            /*" -408- OPEN OUTPUT SIAVISAD */
            SIAVISAD.Open(REG_SIAVISAD);

            /*" -409- MOVE 'SIAVISAD' TO GEARDETA-NOM-ARQUIVO */
            _.Move("SIAVISAD", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO);

            /*" -411- PERFORM R0050-00-MAX-GEARDETA */

            R0050_00_MAX_GEARDETA_SECTION();

            /*" -413- PERFORM R0100-00-SELECT-SISTEMAS */

            R0100_00_SELECT_SISTEMAS_SECTION();

            /*" -415- DISPLAY ' DATA DA PESQUISA = ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($" DATA DA PESQUISA = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -416- PERFORM R2000-TRATA-SINISTRO */

            R2000_TRATA_SINISTRO_SECTION();

            /*" -417- PERFORM R6000-00-INCLUI-GEARDETA */

            R6000_00_INCLUI_GEARDETA_SECTION();

            /*" -417- PERFORM R5000-00-FINALIZAR. */

            R5000_00_FINALIZAR_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0000_99_SAIDA*/

        [StopWatch]
        /*" R0050-00-MAX-GEARDETA-SECTION */
        private void R0050_00_MAX_GEARDETA_SECTION()
        {
            /*" -431- MOVE '0050' TO WNR-EXEC-SQL. */
            _.Move("0050", WABEND.WNR_EXEC_SQL);

            /*" -437- PERFORM R0050_00_MAX_GEARDETA_DB_SELECT_1 */

            R0050_00_MAX_GEARDETA_DB_SELECT_1();

            /*" -440- IF SQLCODE NOT EQUAL ZEROS AND 100 */

            if (!DB.SQLCODE.In("00", "100"))
            {

                /*" -442- DISPLAY 'ERRO MAX GE_AR_DETALHE ' GEARDETA-NOM-ARQUIVO */
                _.Display($"ERRO MAX GE_AR_DETALHE {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO}");

                /*" -443- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -445- END-IF */
            }


            /*" -446- ADD 1 TO GEARDETA-SEQ-GERACAO */
            GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO.Value = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO + 1;

            /*" -446- DISPLAY 'NOVO SEQ MAXIMA ARQUIVO: ' GEARDETA-SEQ-GERACAO. */
            _.Display($"NOVO SEQ MAXIMA ARQUIVO: {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO}");

        }

        [StopWatch]
        /*" R0050-00-MAX-GEARDETA-DB-SELECT-1 */
        public void R0050_00_MAX_GEARDETA_DB_SELECT_1()
        {
            /*" -437- EXEC SQL SELECT VALUE(MAX(SEQ_GERACAO),0) INTO :GEARDETA-SEQ-GERACAO FROM SEGUROS.GE_AR_DETALHE WHERE NOM_ARQUIVO = :GEARDETA-NOM-ARQUIVO AND SEQ_GERACAO < 999999999 END-EXEC. */

            var r0050_00_MAX_GEARDETA_DB_SELECT_1_Query1 = new R0050_00_MAX_GEARDETA_DB_SELECT_1_Query1()
            {
                GEARDETA_NOM_ARQUIVO = GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO.ToString(),
            };

            var executed_1 = R0050_00_MAX_GEARDETA_DB_SELECT_1_Query1.Execute(r0050_00_MAX_GEARDETA_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.GEARDETA_SEQ_GERACAO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0050_99_SAIDA*/

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-SECTION */
        private void R0100_00_SELECT_SISTEMAS_SECTION()
        {
            /*" -457- MOVE '0100' TO WNR-EXEC-SQL. */
            _.Move("0100", WABEND.WNR_EXEC_SQL);

            /*" -468- PERFORM R0100_00_SELECT_SISTEMAS_DB_SELECT_1 */

            R0100_00_SELECT_SISTEMAS_DB_SELECT_1();

            /*" -471- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -472- DISPLAY 'R0100 - ERRO CURRENT DATE' */
                _.Display($"R0100 - ERRO CURRENT DATE");

                /*" -473- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -475- END-IF */
            }


            /*" -476- DISPLAY 'SEGUROS.SISTEMAS - DATA DA PESQUISA=' */
            _.Display($"SEGUROS.SISTEMAS - DATA DA PESQUISA=");

            /*" -477- DISPLAY 'DATA-MOV-ABERTO    = ' SISTEMAS-DATA-MOV-ABERTO */
            _.Display($"DATA-MOV-ABERTO    = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO}");

            /*" -477- DISPLAY 'DATYLT-PROCESSAMEN = ' SISTEMAS-DATULT-PROCESSAMEN. */
            _.Display($"DATYLT-PROCESSAMEN = {SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN}");

        }

        [StopWatch]
        /*" R0100-00-SELECT-SISTEMAS-DB-SELECT-1 */
        public void R0100_00_SELECT_SISTEMAS_DB_SELECT_1()
        {
            /*" -468- EXEC SQL SELECT DATA_MOV_ABERTO ,DATULT_PROCESSAMEN ,YEAR(DATA_MOV_ABERTO) ,MONTH(DATA_MOV_ABERTO) INTO :SISTEMAS-DATA-MOV-ABERTO ,:SISTEMAS-DATULT-PROCESSAMEN ,:HOST-ANO-MOV-SISTEMAS ,:HOST-MES-MOV-SISTEMAS FROM SEGUROS.SISTEMAS WHERE IDE_SISTEMA = 'SI' END-EXEC. */

            var r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1 = new R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1()
            {
            };

            var executed_1 = R0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1.Execute(r0100_00_SELECT_SISTEMAS_DB_SELECT_1_Query1);
            if (executed_1 != null)
            {
                _.Move(executed_1.SISTEMAS_DATA_MOV_ABERTO, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO);
                _.Move(executed_1.SISTEMAS_DATULT_PROCESSAMEN, SISTEMAS.DCLSISTEMAS.SISTEMAS_DATULT_PROCESSAMEN);
                _.Move(executed_1.HOST_ANO_MOV_SISTEMAS, HOST_ANO_MOV_SISTEMAS);
                _.Move(executed_1.HOST_MES_MOV_SISTEMAS, HOST_MES_MOV_SISTEMAS);
            }


        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R0100_99_SAIDA*/

        [StopWatch]
        /*" R2000-TRATA-SINISTRO-SECTION */
        private void R2000_TRATA_SINISTRO_SECTION()
        {
            /*" -487- MOVE '2000' TO WNR-EXEC-SQL. */
            _.Move("2000", WABEND.WNR_EXEC_SQL);

            /*" -490- MOVE 'RELAT�RIO DI�RIO SINISTROS AVISADOS-SIAS' TO HDR-TITULO */
            _.Move("RELAT�RIO DI�RIO SINISTROS AVISADOS-SIAS", HDR_TITULO);

            /*" -491- WRITE REG-SIAVISAD FROM HDR-TITULO */
            _.Move(HDR_TITULO.GetMoveValues(), REG_SIAVISAD);

            SIAVISAD.Write(REG_SIAVISAD.GetMoveValues().ToString());

            /*" -493- WRITE REG-SIAVISAD FROM HDR-SI9229B0 */
            _.Move(HDR_SI9229B0.GetMoveValues(), REG_SIAVISAD);

            SIAVISAD.Write(REG_SIAVISAD.GetMoveValues().ToString());

            /*" -495- PERFORM R1000-OPEN-CUR01-HIST-MESTRE */

            R1000_OPEN_CUR01_HIST_MESTRE_SECTION();

            /*" -497- PERFORM R1100-FETCH-HIST-MESTRE */

            R1100_FETCH_HIST_MESTRE_SECTION();

            /*" -498- IF WS-FIM-CUR01 EQUAL 'S' */

            if (AREA_DE_WORK.WS_FIM_CUR01 == "S")
            {

                /*" -499- PERFORM R9900-00-SEM-REGISTRO-B0 */

                R9900_00_SEM_REGISTRO_B0_SECTION();

                /*" -500- ELSE */
            }
            else
            {


                /*" -501- PERFORM UNTIL WS-FIM-CUR01 EQUAL 'S' */

                while (!(AREA_DE_WORK.WS_FIM_CUR01 == "S"))
                {

                    /*" -502- PERFORM R2310-GRAVA-DETALHE */

                    R2310_GRAVA_DETALHE_SECTION();

                    /*" -503- PERFORM R1100-FETCH-HIST-MESTRE */

                    R1100_FETCH_HIST_MESTRE_SECTION();

                    /*" -505- END-PERFORM */
                }

                /*" -507- END-IF. */
            }


            /*" -507- PERFORM R2300-CLOSE-HIST-MESTRE. */

            R2300_CLOSE_HIST_MESTRE_SECTION();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2000_99_SAIDA*/

        [StopWatch]
        /*" R2310-GRAVA-DETALHE-SECTION */
        private void R2310_GRAVA_DETALHE_SECTION()
        {
            /*" -518- MOVE '2310' TO WNR-EXEC-SQL. */
            _.Move("2310", WABEND.WNR_EXEC_SQL);

            /*" -519- MOVE SINISHIS-COD-PRODUTO TO DET-COD-PRODUTO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO, DETALHE_SI9229B0.DET_COD_PRODUTO);

            /*" -520- MOVE SINISMES-COD-CAUSA TO DET-COD-CAUSA */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA, DETALHE_SI9229B0.DET_COD_CAUSA);

            /*" -521- MOVE SINISCAU-DESCR-CAUSA TO DET-DES-CAUSA */
            _.Move(SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA, DETALHE_SI9229B0.DET_DES_CAUSA);

            /*" -522- MOVE CAUSACOB-COD-COBERTURA TO DET-COBERTURA */
            _.Move(CAUSACOB.DCLCAUSA_COBERTURA.CAUSACOB_COD_COBERTURA, DETALHE_SI9229B0.DET_COBERTURA);

            /*" -523- MOVE COBERDES-DESCR-COBERTURA TO DET-DES-COBERTURA */
            _.Move(COBERDES.DCLCOBERTURAS_DESCR.COBERDES_DESCR_COBERTURA, DETALHE_SI9229B0.DET_DES_COBERTURA);

            /*" -524- MOVE SINISMES-NUM-APOLICE TO DET-NUM-APOLICE */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE, DETALHE_SI9229B0.DET_NUM_APOLICE);

            /*" -525- MOVE CLIENTES-CGCCPF TO DET-CPF-CNPJ-SEGURADO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF, DETALHE_SI9229B0.DET_CPF_CNPJ_SEGURADO);

            /*" -526- MOVE CLIENTES-NOME-RAZAO TO DET-NOME-SEGURADO */
            _.Move(CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO, DETALHE_SI9229B0.DET_NOME_SEGURADO);

            /*" -527- MOVE ENDOSSOS-DATA-INIVIGENCIA TO DET-INI-VIGENCIA */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA, DETALHE_SI9229B0.DET_INI_VIGENCIA);

            /*" -528- MOVE ENDOSSOS-DATA-TERVIGENCIA TO DET-FIM-VIGENCIA */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA, DETALHE_SI9229B0.DET_FIM_VIGENCIA);

            /*" -529- MOVE SINISHIS-NUM-APOL-SINISTRO TO DET-NUM-SINISTRO */
            _.Move(SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO, DETALHE_SI9229B0.DET_NUM_SINISTRO);

            /*" -530- MOVE SINISMES-DATA-OCORRENCIA TO DET-DT-OCORR-SINIS */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA, DETALHE_SI9229B0.DET_DT_OCORR_SINIS);

            /*" -531- MOVE SINISMES-DATA-TECNICA TO DET-DT-AVISO-SINIS */
            _.Move(SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_TECNICA, DETALHE_SI9229B0.DET_DT_AVISO_SINIS);

            /*" -532- MOVE WS-VLR-AVISADO TO WS-VLR-AVISADO-E */
            _.Move(WS_VLR_AVISADO, WS_VLR_AVISADO_E);

            /*" -533- MOVE WS-VLR-AVISADO-E TO DET-VL-AVISADO */
            _.Move(WS_VLR_AVISADO_E, DETALHE_SI9229B0.DET_VL_AVISADO);

            /*" -534- MOVE WS-E-ENDOSSO TO DET-ENDOSSO */
            _.Move(WS_E_ENDOSSO, DETALHE_SI9229B0.DET_ENDOSSO);

            /*" -535- MOVE ENDOSSOS-DATA-EMISSAO TO DET-DT-INI-VIG-ENDOSSO */
            _.Move(ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO, DETALHE_SI9229B0.DET_DT_INI_VIG_ENDOSSO);

            /*" -536- MOVE ENDERECO-SIGLA-UF TO DET-UF-RISCO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF, DETALHE_SI9229B0.DET_UF_RISCO);

            /*" -537- MOVE ENDERECO-CIDADE TO DET-CIDADE-RISCO */
            _.Move(ENDERECO.DCLENDERECOS.ENDERECO_CIDADE, DETALHE_SI9229B0.DET_CIDADE_RISCO);

            /*" -539- MOVE WS-E-PREMATURO TO DET-AVISO-PREMATURO */
            _.Move(WS_E_PREMATURO, DETALHE_SI9229B0.DET_AVISO_PREMATURO);

            /*" -540- WRITE REG-SIAVISAD FROM DETALHE-SI9229B0 */
            _.Move(DETALHE_SI9229B0.GetMoveValues(), REG_SIAVISAD);

            SIAVISAD.Write(REG_SIAVISAD.GetMoveValues().ToString());

            /*" -540- ADD 1 TO WS-QTD-SI9229B0. */
            WS_ACUMULADORES.WS_QTD_SI9229B0.Value = WS_ACUMULADORES.WS_QTD_SI9229B0 + 1;

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2310_99_SAIDA*/

        [StopWatch]
        /*" R1000-OPEN-CUR01-HIST-MESTRE-SECTION */
        private void R1000_OPEN_CUR01_HIST_MESTRE_SECTION()
        {
            /*" -551- MOVE '1000' TO WNR-EXEC-SQL. */
            _.Move("1000", WABEND.WNR_EXEC_SQL);

            /*" -553- PERFORM R1000_OPEN_CUR01_HIST_MESTRE_DB_OPEN_1 */

            R1000_OPEN_CUR01_HIST_MESTRE_DB_OPEN_1();

            /*" -556- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -557- DISPLAY 'R1000 - ERRO NO OPEN DO DO CURSOR CUR01-HIT' */
                _.Display($"R1000 - ERRO NO OPEN DO DO CURSOR CUR01-HIT");

                /*" -558- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -558- END-IF. */
            }


        }

        [StopWatch]
        /*" R1000-OPEN-CUR01-HIST-MESTRE-DB-OPEN-1 */
        public void R1000_OPEN_CUR01_HIST_MESTRE_DB_OPEN_1()
        {
            /*" -553- EXEC SQL OPEN CUR01-HIST-MESTRE END-EXEC */

            CUR01_HIST_MESTRE.Open();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1000_99_SAIDA*/

        [StopWatch]
        /*" R1100-FETCH-HIST-MESTRE-SECTION */
        private void R1100_FETCH_HIST_MESTRE_SECTION()
        {
            /*" -569- MOVE '3200' TO WNR-EXEC-SQL */
            _.Move("3200", WABEND.WNR_EXEC_SQL);

            /*" -590- PERFORM R1100_FETCH_HIST_MESTRE_DB_FETCH_1 */

            R1100_FETCH_HIST_MESTRE_DB_FETCH_1();

            /*" -593- IF SQLCODE NOT EQUAL ZEROS AND + 100 */

            if (!DB.SQLCODE.In("00", "+100"))
            {

                /*" -594- DISPLAY 'R1100 - ERRO NA LEITURA DO CURSOR' */
                _.Display($"R1100 - ERRO NA LEITURA DO CURSOR");

                /*" -595- DISPLAY 'SQLCODE: ' SQLCODE */
                _.Display($"SQLCODE: {DB.SQLCODE}");

                /*" -596- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -598- END-IF. */
            }


            /*" -599- IF SQLCODE EQUAL +100 */

            if (DB.SQLCODE == +100)
            {

                /*" -600- MOVE 'S' TO WS-FIM-CUR01 */
                _.Move("S", AREA_DE_WORK.WS_FIM_CUR01);

                /*" -600- END-IF. */
            }


        }

        [StopWatch]
        /*" R1100-FETCH-HIST-MESTRE-DB-FETCH-1 */
        public void R1100_FETCH_HIST_MESTRE_DB_FETCH_1()
        {
            /*" -590- EXEC SQL FETCH CUR01-HIST-MESTRE INTO :SINISHIS-COD-PRODUTO , :SINISMES-COD-CAUSA , :SINISCAU-DESCR-CAUSA , :CAUSACOB-COD-COBERTURA , :COBERDES-DESCR-COBERTURA , :SINISMES-NUM-APOLICE , :CLIENTES-CGCCPF , :CLIENTES-NOME-RAZAO , :ENDOSSOS-DATA-INIVIGENCIA , :ENDOSSOS-DATA-TERVIGENCIA , :SINISHIS-NUM-APOL-SINISTRO , :SINISMES-DATA-OCORRENCIA , :SINISMES-DATA-TECNICA , :WS-VLR-AVISADO , :WS-E-ENDOSSO , :ENDOSSOS-DATA-EMISSAO , :ENDERECO-SIGLA-UF , :ENDERECO-CIDADE , :WS-E-PREMATURO END-EXEC */

            if (CUR01_HIST_MESTRE.Fetch())
            {
                _.Move(CUR01_HIST_MESTRE.SINISHIS_COD_PRODUTO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_COD_PRODUTO);
                _.Move(CUR01_HIST_MESTRE.SINISMES_COD_CAUSA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_CAUSA);
                _.Move(CUR01_HIST_MESTRE.SINISCAU_DESCR_CAUSA, SINISCAU.DCLSINISTRO_CAUSA.SINISCAU_DESCR_CAUSA);
                _.Move(CUR01_HIST_MESTRE.CAUSACOB_COD_COBERTURA, CAUSACOB.DCLCAUSA_COBERTURA.CAUSACOB_COD_COBERTURA);
                _.Move(CUR01_HIST_MESTRE.COBERDES_DESCR_COBERTURA, COBERDES.DCLCOBERTURAS_DESCR.COBERDES_DESCR_COBERTURA);
                _.Move(CUR01_HIST_MESTRE.SINISMES_NUM_APOLICE, SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOLICE);
                _.Move(CUR01_HIST_MESTRE.CLIENTES_CGCCPF, CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF);
                _.Move(CUR01_HIST_MESTRE.CLIENTES_NOME_RAZAO, CLIENTES.DCLCLIENTES.CLIENTES_NOME_RAZAO);
                _.Move(CUR01_HIST_MESTRE.ENDOSSOS_DATA_INIVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_INIVIGENCIA);
                _.Move(CUR01_HIST_MESTRE.ENDOSSOS_DATA_TERVIGENCIA, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_TERVIGENCIA);
                _.Move(CUR01_HIST_MESTRE.SINISHIS_NUM_APOL_SINISTRO, SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_NUM_APOL_SINISTRO);
                _.Move(CUR01_HIST_MESTRE.SINISMES_DATA_OCORRENCIA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA);
                _.Move(CUR01_HIST_MESTRE.SINISMES_DATA_TECNICA, SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_TECNICA);
                _.Move(CUR01_HIST_MESTRE.WS_VLR_AVISADO, WS_VLR_AVISADO);
                _.Move(CUR01_HIST_MESTRE.WS_E_ENDOSSO, WS_E_ENDOSSO);
                _.Move(CUR01_HIST_MESTRE.ENDOSSOS_DATA_EMISSAO, ENDOSSOS.DCLENDOSSOS.ENDOSSOS_DATA_EMISSAO);
                _.Move(CUR01_HIST_MESTRE.ENDERECO_SIGLA_UF, ENDERECO.DCLENDERECOS.ENDERECO_SIGLA_UF);
                _.Move(CUR01_HIST_MESTRE.ENDERECO_CIDADE, ENDERECO.DCLENDERECOS.ENDERECO_CIDADE);
                _.Move(CUR01_HIST_MESTRE.WS_E_PREMATURO, WS_E_PREMATURO);
            }

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R1100_99_SAIDA*/

        [StopWatch]
        /*" R2300-CLOSE-HIST-MESTRE-SECTION */
        private void R2300_CLOSE_HIST_MESTRE_SECTION()
        {
            /*" -611- MOVE '2300' TO WNR-EXEC-SQL */
            _.Move("2300", WABEND.WNR_EXEC_SQL);

            /*" -613- PERFORM R2300_CLOSE_HIST_MESTRE_DB_CLOSE_1 */

            R2300_CLOSE_HIST_MESTRE_DB_CLOSE_1();

            /*" -616- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -617- DISPLAY 'R2300 - ERRO NO CLOSE DO DO CURSOR' */
                _.Display($"R2300 - ERRO NO CLOSE DO DO CURSOR");

                /*" -618- DISPLAY 'SQLCODE: ' SQLCODE */
                _.Display($"SQLCODE: {DB.SQLCODE}");

                /*" -619- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -619- END-IF. */
            }


        }

        [StopWatch]
        /*" R2300-CLOSE-HIST-MESTRE-DB-CLOSE-1 */
        public void R2300_CLOSE_HIST_MESTRE_DB_CLOSE_1()
        {
            /*" -613- EXEC SQL CLOSE CUR01-HIST-MESTRE END-EXEC. */

            CUR01_HIST_MESTRE.Close();

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R2300_99_SAIDA*/

        [StopWatch]
        /*" R5000-00-FINALIZAR-SECTION */
        private void R5000_00_FINALIZAR_SECTION()
        {
            /*" -629- CLOSE SIAVISAD */
            SIAVISAD.Close();

            /*" -630- DISPLAY '*-------------------------------------------*' . */
            _.Display($"*-------------------------------------------*");

            /*" -631- DISPLAY '*      RELATORIO GERAL DA EXECUCAO          *' . */
            _.Display($"*      RELATORIO GERAL DA EXECUCAO          *");

            /*" -632- DISPLAY '*-------------------------------------------*' . */
            _.Display($"*-------------------------------------------*");

            /*" -633- DISPLAY '*                                           *' . */
            _.Display($"*                                           *");

            /*" -634- DISPLAY '*APOLICE/ENDOSSOS EMITIDOS: ' WS-QTD-SI9229B0 */
            _.Display($"*APOLICE/ENDOSSOS EMITIDOS: {WS_ACUMULADORES.WS_QTD_SI9229B0}");

            /*" -635- DISPLAY '*-------------------------------------------*' . */
            _.Display($"*-------------------------------------------*");

            /*" -636- DISPLAY '*          SIAVISAD  -  FIM NORMAL          *' . */
            _.Display($"*          SIAVISAD  -  FIM NORMAL          *");

            /*" -638- DISPLAY '*-------------------------------------------*' . */
            _.Display($"*-------------------------------------------*");

            /*" -638- EXEC SQL COMMIT WORK END-EXEC. */

            DatabaseConnection.Instance.CommitTransaction();

            /*" -642- MOVE ZEROS TO RETURN-CODE. */
            _.Move(0, RETURN_CODE);

            /*" -642- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R5000_99_SAIDA*/

        [StopWatch]
        /*" R6000-00-INCLUI-GEARDETA-SECTION */
        private void R6000_00_INCLUI_GEARDETA_SECTION()
        {
            /*" -652- MOVE '6000' TO WNR-EXEC-SQL */
            _.Move("6000", WABEND.WNR_EXEC_SQL);

            /*" -653- MOVE 'E' TO GEARDETA-IND-MEIO-ENVIO */
            _.Move("E", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_IND_MEIO_ENVIO);

            /*" -654- MOVE 'R' TO GEARDETA-STA-ENVIO-RECEPCAO */
            _.Move("R", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_STA_ENVIO_RECEPCAO);

            /*" -655- MOVE 'TXT' TO GEARDETA-COD-TIPO-ARQUIVO */
            _.Move("TXT", GEARDETA.DCLGE_AR_DETALHE.GEARDETA_COD_TIPO_ARQUIVO);

            /*" -656- MOVE WS-QTD-SI9229B0 TO GEARDETA-QTD-REG-PROCESSADO */
            _.Move(WS_ACUMULADORES.WS_QTD_SI9229B0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_PROCESSADO);

            /*" -657- MOVE HOST-ANO-MOV-SISTEMAS TO GEARDETA-DTH-ANO-REFERENCIA */
            _.Move(HOST_ANO_MOV_SISTEMAS, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_ANO_REFERENCIA);

            /*" -658- MOVE HOST-MES-MOV-SISTEMAS TO GEARDETA-DTH-MES-REFERENCIA */
            _.Move(HOST_MES_MOV_SISTEMAS, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MES_REFERENCIA);

            /*" -661- MOVE SISTEMAS-DATA-MOV-ABERTO TO GEARDETA-DTH-MOVIMENTO GEARDETA-DTH-GERACAO GEARDETA-DTH-RECEPCAO */
            _.Move(SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_MOVIMENTO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_GERACAO, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_DTH_RECEPCAO);

            /*" -664- MOVE ZEROS TO GEARDETA-QTD-REG-REJEITADOS GEARDETA-QTD-REG-ACEITOS. */
            _.Move(0, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_REJEITADOS, GEARDETA.DCLGE_AR_DETALHE.GEARDETA_QTD_REG_ACEITOS);

            /*" -694- PERFORM R6000_00_INCLUI_GEARDETA_DB_INSERT_1 */

            R6000_00_INCLUI_GEARDETA_DB_INSERT_1();

            /*" -697- IF SQLCODE NOT EQUAL ZEROS */

            if (DB.SQLCODE != 00)
            {

                /*" -700- DISPLAY 'PROBLEMAS NO INSERT GE_AR_DETALHE' ' ' GEARDETA-NOM-ARQUIVO ' ' GEARDETA-SEQ-GERACAO */

                $"PROBLEMAS NO INSERT GE_AR_DETALHE {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_NOM_ARQUIVO} {GEARDETA.DCLGE_AR_DETALHE.GEARDETA_SEQ_GERACAO}"
                .Display();

                /*" -701- PERFORM R9999-00-ROT-ERRO */

                R9999_00_ROT_ERRO_SECTION();

                /*" -701- END-IF. */
            }


        }

        [StopWatch]
        /*" R6000-00-INCLUI-GEARDETA-DB-INSERT-1 */
        public void R6000_00_INCLUI_GEARDETA_DB_INSERT_1()
        {
            /*" -694- EXEC SQL INSERT INTO SEGUROS.GE_AR_DETALHE (NOM_ARQUIVO, SEQ_GERACAO, DTH_ANO_REFERENCIA, DTH_MES_REFERENCIA, DTH_MOVIMENTO, DTH_GERACAO, DTH_RECEPCAO, IND_MEIO_ENVIO, STA_ENVIO_RECEPCAO, COD_TIPO_ARQUIVO, QTD_REG_PROCESSADO, QTD_REG_REJEITADOS, QTD_REG_ACEITOS, DTH_TIMESTAMP) VALUES (:GEARDETA-NOM-ARQUIVO, :GEARDETA-SEQ-GERACAO, :GEARDETA-DTH-ANO-REFERENCIA, :GEARDETA-DTH-MES-REFERENCIA, :GEARDETA-DTH-MOVIMENTO, :GEARDETA-DTH-GERACAO, :GEARDETA-DTH-RECEPCAO, :GEARDETA-IND-MEIO-ENVIO, :GEARDETA-STA-ENVIO-RECEPCAO, :GEARDETA-COD-TIPO-ARQUIVO, :GEARDETA-QTD-REG-PROCESSADO, :GEARDETA-QTD-REG-REJEITADOS, :GEARDETA-QTD-REG-ACEITOS, CURRENT TIMESTAMP) END-EXEC. */

            var r6000_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1 = new R6000_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1()
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

            R6000_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1.Execute(r6000_00_INCLUI_GEARDETA_DB_INSERT_1_Insert1);

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R6000_00_EXIT*/

        [StopWatch]
        /*" R9900-00-SEM-REGISTRO-B0-SECTION */
        private void R9900_00_SEM_REGISTRO_B0_SECTION()
        {
            /*" -714- MOVE '9900' TO WNR-EXEC-SQL. */
            _.Move("9900", WABEND.WNR_EXEC_SQL);

            /*" -715- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

            /*" -716- DISPLAY '*                SIAVISAD                  *' . */
            _.Display($"*                SIAVISAD                  *");

            /*" -717- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -718- DISPLAY '*         NAO HOUVE PAGAMENTOS DE SINISTROS*' . */
            _.Display($"*         NAO HOUVE PAGAMENTOS DE SINISTROS*");

            /*" -719- DISPLAY '*                                          *' . */
            _.Display($"*                                          *");

            /*" -719- DISPLAY '*------------------------------------------*' . */
            _.Display($"*------------------------------------------*");

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9900_99_SAIDA*/

        [StopWatch]
        /*" R9999-00-ROT-ERRO-SECTION */
        private void R9999_00_ROT_ERRO_SECTION()
        {
            /*" -730- MOVE '9999' TO WNR-EXEC-SQL. */
            _.Move("9999", WABEND.WNR_EXEC_SQL);

            /*" -732- CLOSE SIAVISAD */
            SIAVISAD.Close();

            /*" -734- MOVE SQLCODE TO WSQLCODE. */
            _.Move(DB.SQLCODE, WABEND.WSQLCODE);

            /*" -736- DISPLAY WABEND. */
            _.Display(WABEND);

            /*" -736- EXEC SQL ROLLBACK WORK END-EXEC. */

            DatabaseConnection.Instance.RollbackTransaction();

            /*" -740- MOVE 99 TO RETURN-CODE. */
            _.Move(99, RETURN_CODE);

            /*" -740- STOP RUN. */

            throw new GoBack();   // => STOP RUN.

        }
        /*Método Suprimido por falta de linha ou apenas EXIT nome: R9999_99_SAIDA*/
    }
}