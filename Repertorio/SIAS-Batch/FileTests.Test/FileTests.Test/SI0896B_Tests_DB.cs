using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.SI0896B;

namespace FileTests.Test_DB
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0896B_Tests_DB")]
    public class SI0896B_Tests_DB
    {

        [Fact]
        public static void SI0896B_Database()
        {
            var program = new SI0896B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.Execute_DB_DECLARE_1(); program.Execute_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.RELATORI.DCLRELATORIOS.RELATORI_COD_PRODUTOR.Value = 1;
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.Value = "2020-01-01";
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Value = "2020-01-01";
                program.R030_DECLARE_CTRAB_DB_DECLARE_1(); program.R030_DECLARE_CTRAB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_000_900_FIM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO.Value = 123 ;
                program.SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST.Value = 123;
                program.R200_SELECT_NA_SINISHIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                program.SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO.Value = 123;
                program.R200_SELECT_NA_SINISHIS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO.Value = 231;
                program.SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST.Value = 123;
                program.R210_LE_SINI_PLANHABIT01_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO.Value = 123;
                program.SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST.Value = 123;
                program.R220_SELECT_NA_SINISHIS_OPER2_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_NUM_APOL_SINISTRO.Value = 123;
                program.SINIPLAN.DCLSINI_PLANHABIT01.SINIPLAN_OCORHIST.Value = 1 ;
                program.R230_SELECT_NA_SINISHIS_OPER28_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}