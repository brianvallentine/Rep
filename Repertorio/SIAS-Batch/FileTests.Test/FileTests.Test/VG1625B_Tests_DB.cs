using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Copies;
using Code;
using static Code.VG1625B;

namespace FileTests.Test_DB
{
    [Collection("VG1625B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VG1625B_Tests_DB
    {

        [Fact]
        public static void VG1625B_Database()
        {
            var program = new VG1625B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0900_00_DECLA_PROPOVA_DB_DECLARE_1(); program.R0900_00_DECLA_PROPOVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R2100_00_SELECT_SEGURVGA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R2200_00_SELECT_SUBGVGAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R2250_00_SELECT_PARCEVID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R2300_00_SELECT_COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R2400_00_SELECT_FXAETA_PLAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R2450_SELECT_00_MAX_PLAN_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R2460_SELECT_00_MIN_PLAN_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R2470_UPDATE_PLAN_VGAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Value = "2021-01-01";
                program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA.Value = "2022-01-01";
                program.R2900_00_INSERT_COBERPROPVA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/ program.R2910_00_UPDATE_COBERPROPVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R2920_00_UPDATE_PROPOSTAVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R3100_00_UPDATE_COBERPROPVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R3200_00_UPDATE_PARCELVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R3300_00_UPDATE_HISTCOBVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}