using System;
using IA_ConverterCommons;
using _ = IA_ConverterCommons.Statements;
using Xunit;
using Code;

namespace FileTests.Test_DB
{
    [Collection("EM0010B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0010B_Tests_DB
    {
        [Fact]
        public static void EM0010B_Database()
        {
            var program = new EM0010B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.ENDO_DTINIVIG.Value = "2000-10-10";
            program.PCOM_DTMOVTO.Value = "2000-10-10";
            program.SIST_DTMOVABE.Value = "2000-10-10";
            program.PCOM_DTCADAST.Value = "2000-10-10";
            program.PCOM_DATARCAP.Value = "2000-10-10";
            program.WHOST_DTINIVIG.Value = "2000-10-10";
            program.V0EDIA_DTMOVTO.Value = "2000-10-10";
            program.PCOM_HORAOPER.Value = "10:10:10";
            program.HIST_HORAOPER.Value = "10:10:10";
            program.HIST_DTMOVTO.Value = "10:10:10";

            program.V0RELA_PERI_INICIAL.Value = "2000-10-10";
            program.V0RELA_DATA_REFERENCIA.Value = "2000-10-10";
            program.V0RELA_PERI_FINAL.Value = "2000-10-10";
            program.V0RELA_DATA_SOLICITACAO.Value = "2000-10-10";
            program.ENDO_DATPRO.Value = "2000-10-10";

            program.AU071.DCLPARCELA_AUTO_COMPL.AU071_DTA_VENCTO.Value = "2000-10-10";
            program.AU077.DCLAU_PROD_COBERTURA.AU077_DTA_INI_VIGENCIA.Value = "2000-10-10";
            program.AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_DTA_INI_VIGENCIA.Value = "2000-10-10";

            program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01.Value = "2000-10-10";
            program.CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.Value = "2000-10-10";

            program.HIST_DTVENCTO.Value = "2000-10-10";
            program.HIST_DTQITBCO.Value = "2000-10-10";
            program.WHOST_DTCALEND2.Value = "2000-10-10";
            program.WHOST_DTCALEND1.Value = "2000-10-10";
            program.LTMVPRCO.DCLLT_MOV_PROP_COBER.LTMVPRCO_DATA_MOVIMENTO.Value = "2000-10-10";
            program.LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DT_INIVIG_PROPOSTA.Value = "2000-10-10";


            try { /*1*/ program.A1000_LE_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.A1000_LE_SISTEMA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.A1500_LE_V1PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.A1600_LE_V1PARAMETRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R2000_DECLARE_V0ENDOSSO_DB_DECLARE_1(); program.R2000_DECLARE_V0ENDOSSO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.A4500_LE_COBERAPOL_DB_DECLARE_1(); program.A4500_LE_COBERAPOL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.A3500_LE_SUBGRUPO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.A3510_LE_RAMOIND_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.A4000_LE_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.A4100_LE_PROPCOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.A4200_LE_AU085_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.B0100_DECLARE_V0APOLCOSCED_DB_DECLARE_1(); program.B0100_DECLARE_V0APOLCOSCED_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.A4600_LE_MR_APOL_COBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.A5000_LE_APOLITEM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.A6200_000_LE_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.A6200_000_LE_RCAP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.A6200_000_LE_RCAP_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.B2200_020_DECLARE_V0RCAPCOMP_DB_DECLARE_1(); program.B2200_020_DECLARE_V0RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.B1000_GRAVA_V0ORDECOSCED_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.B1050_LE_NUMERO_COSCED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.B1060_ATU_NUMERO_COSCED_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.B1100_LE_V2RAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.B2000_GRAVA_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.B2000_CONTINUA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.B2000_CONTINUA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.B2002_CONTINUA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.B2018_RECUPERA_AU084_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.B2020_SELECT_MR021_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.B2025_TRATA_2PCELA_CCA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.B2030_SELECT_MR022_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.B2031_SELECT_MRAPOITE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.B2035_SELECT_MRAPOCOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.B2040_SELECT_V0APOL_HABIT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.B2061_SELECT_LTMVPROP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.B2061_SELECT_LTMVPROP_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.B2061_00_SELECT_COBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.B2061_10_00_LER_PREMIO_2021_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.B2064_SELECT_LTMVPROP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.B2070_SELECT_V0NOVACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.B2080_SELECT_V0PREMIO_HAB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.B2080_SELECT_V0PREMIO_HAB_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.B2081_SELECT_V0PREMIO_HAB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.B2081_SELECT_V0PREMIO_HAB_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.B2090_00_SELECT_EFPREMIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.B2090_10_SELECT_EFFATURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.B2091_00_SELECT_EFPREMIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.B2091_20_SEL_EFPRM_POR_COB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.B2091_31_SEL_EFPRM_POR_COB_DFI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.B2091_32_SEL_EFPRM_POR_COB_RD_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.B2094_ALTERA_V0COBERAPOL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.B2095_ALTERA_V0COBERAPOL_EF_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.B2096_ALTERA_V0COBERAPOL_EF_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.B2200_010_ALTERA_V0RCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ program.B2200_040_ALTERA_V0RCAPCOMP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*58*/ program.B2200_050_INCLUI_V0RCAPCOMP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*59*/ program.B2500_LE_MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*60*/
                program.HIST_DTMOVTO.Value = "2000-10-10";
                program.B3000_GRAVA_HISTOPARC_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*61*/ program.B3005_PEGAR_ULTIMO_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*62*/ program.B3100_SELECT_V1RCAPCOMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*63*/ program.B3150_SELECT_V1RCAPCOMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*64*/ program.B3160_ALTERA_V0PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*65*/ program.B3200_SELECT_V1AVISALDOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*66*/ program.B3300_ALTERA_V0AVISALDOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*67*/ program.B4000_ATUALIZA_ENDOSSO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*68*/ program.B4055_00_VALIDA_TITULO_CAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*69*/ program.B4101_SELECT_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*70*/ program.B4102_SELECT_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*71*/ program.B4200_INCLUI_V0EMISDIARIA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*72*/ program.B4201_00_V1PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*73*/ program.B4210_00_INCLUI_RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*74*/ program.B4292_INCLUI_V0EMISDIARIA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*75*/ program.B4295_00_UPDATE_DATAPROP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*76*/ program.R0320_00_SELECT_V0CEDENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*77*/ program.R1110_00_RECUPERA_AU080_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*78*/ program.R1120_00_RECUPERA_AU077_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*79*/ program.R2060_00_ALTERA_V0CEDENTE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*80*/ program.R3000_LE_CUSTO_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*81*/ program.R5000_00_LE_PCIOCC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*82*/ program.R7100_00_INCLUI_PARC_COMPL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*83*/ program.R7210_00_APURA_QTD_DIAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*84*/ program.R7220_00_CONSULTA_NN_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*85*/ program.R7220_00_CONSULTA_NN_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*86*/ program.M_999_999_ROT_ERRO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}