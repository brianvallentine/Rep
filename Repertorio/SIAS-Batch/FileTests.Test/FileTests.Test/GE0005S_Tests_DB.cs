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
using static Code.GE0005S;

namespace FileTests.Test_DB
{
    [Collection("GE0005S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class GE0005S_Tests_DB
    {

        [Fact]
        public static void GE0005S_Database()
        {
            var program = new GE0005S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var pData = "2000-01-01";
            try { /*1*/
                program.CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.Value = pData;
                program.R0510_00_SELECT_CALENDAR_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*2*/
                program.GE292.DCLGE_GRUPO_SUSEP.GE292_DTH_INI_VIGENCIA.Value = pData;
                program.R1100_00_SELECT_GE292_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}