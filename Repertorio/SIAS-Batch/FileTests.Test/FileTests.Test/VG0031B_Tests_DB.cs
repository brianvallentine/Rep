using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Code;
using static Code.VG0031B;

namespace FileTests.Test_DB
{
    [Collection("VG0031B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0031B_Tests_DB
    {

        [Fact]
        public static void VG0031B_Database()
        {
            var program = new VG0031B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var pdata = "2020-01-01";
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_DECLER_V0RELATORIOS_DB_DECLARE_1(); program.R0200_00_DECLER_V0RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0221_00_DECLER_V0SUBGRUPO_DB_DECLARE_1(); program.R0221_00_DECLER_V0SUBGRUPO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0215_00_LER_V1PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0220_10_UPDATE_ENDOSSO_ZERO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0220_20_UPDATE_SUBGRUPO_ZERO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0224_10_DECLER_V0SEGURAVG_DB_DECLARE_1(); program.R0224_10_DECLER_V0SEGURAVG_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0223_00_PROCESSA_V0SUBGRUPO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0224_00_OBTER_DT_REFERENCIA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0230_05_DECLER_V1ENDOSSO_DB_DECLARE_1(); program.R0230_05_DECLER_V1ENDOSSO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.RB224_00_LER_APOL_EXPURGO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.RD224_00_LER_RETORNO_EXPURGO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.RE224_00_GRAVAR_TORNO_EXPURGO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R0224_25_OBTER_NUM_PROPOSTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R0224_30_SELECT_V0HISTSEG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R0224_32_UPD_SEGURAVG_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*20*/
                program.V1HSEG_DT_MOVTO.Value = "2020-01-01";
                program.R0224_35_OBTER_MOEDA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R0224_35_OBTER_MOEDA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R0224_45_SELECT_V1COBERAPOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R0224_46_SELECT_V1COBERAPOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R0224_50_OBTER_CONTA_CORR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*25*/
                program.V1SIST_DTMOVABE.Value = pdata;
                program.V0SEG_DT_ADMISSAO.Value = pdata;
                program.V0SEG_DT_NASCI.Value = pdata;
                program.V1FATC_DT_REFER.Value = pdata;
                program.R0224_55_CANCELA_SEGURADO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R0230_20_DECLARE_V1PARCELA_DB_DECLARE_1(); program.R0230_20_DECLARE_V1PARCELA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R0230_35_SELECT_NUMERO_AES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R0230_40_UPDATE_NUMERO_AES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R0230_50_ACUMULA_CORRECAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*30*/
                program.V0HISP_DTMOVTO.Value = pdata;
                program.V0HISP_DTVENCTO.Value = pdata;
                program.V0HISP_DTQITBCO.Value = pdata;
                program.V0HISP_HORAOPER.Value = "10:10:10";
                program.R0230_60_INSERT_V0HISTOPARC_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R0230_65_ACUMULA_PREMIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R0230_75_UPDATE_V0PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R0230_80_UPDATE_V0ENDOSSO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/
                program.V1SIST_DTMOVABE.Value = pdata;
                program.R0260_00_CANCELA_V0SUBGRUPO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R0410_00_UPDATE_V0RELATORIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}