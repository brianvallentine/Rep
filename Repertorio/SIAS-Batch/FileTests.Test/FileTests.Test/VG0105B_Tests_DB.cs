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
using static Code.VG0105B;

namespace FileTests.Test_DB
{
    [Collection("VG0105B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0105B_Tests_DB
    {

        [Fact]
        public static void VG0105B_Database()
        {
            var program = new VG0105B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            program.V1FATC_DATA_REFER.Value = "2000-10-10";
            program.V1RIND_DTINIVIG.Value = "2000-10-10";
            program.V0FATR_DATA_VENC.Value = "2000-10-10";
            program.V0FATR_DATA_RCAP.Value = "2000-10-10";
            program.V0FATR_DATA_FATUR.Value = "2000-10-10";
            program.V0FATR_DATA_TERVIG.Value = "2000-10-10";
            program.V0FATR_DATA_INIVIG.Value = "2000-10-10";
            program.V1FATC_DATA_REFER.Value = "2000-10-10";
            program.V0MOVI_DATA_FATURA.Value = "2000-10-10";

            try { /*1*/ program.R0050_00_SELECT_V1PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0060_00_LEITURA_V1TERMOADESAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0900_00_DECLARE_V1SOLICFAT_DB_DECLARE_1(); program.R0900_00_DECLARE_V1SOLICFAT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1300_00_SELECT_V1FATTOT_ANT_DB_DECLARE_1(); program.R1300_00_SELECT_V1FATTOT_ANT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1100_00_SELECT_V1SUBGRUPO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1200_00_SELECT_V1FATURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1280_00_SELECT_V1FATURA_ANT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1500_00_DECLARE_V1SUBGR_DB_DECLARE_1(); program.R1500_00_DECLARE_V1SUBGR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1700_00_ACESSA_TOTAIS_DB_DECLARE_1(); program.R1700_00_ACESSA_TOTAIS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1600_00_SELECT_V1APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R6100_00_DECLARE_V0MOVIMENTO_DB_DECLARE_1(); program.R6100_00_DECLARE_V0MOVIMENTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1900_00_SELECT_V1RAMOIND_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R2315_00_SELECT_V1FATURCONT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R2330_00_SELECT_V1FATURCONT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R3100_00_INSERT_V0FATURAS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R3200_00_INSERT_V0FATURASTOT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R3500_00_SELECT_V1FATURAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R4100_00_DELETE_V0FATURASTOT_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R5100_00_DELETE_V0FATURAS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R5300_00_UPDATE_V0SOLICFAT_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R6500_00_UPDATE_MOVIMENTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}