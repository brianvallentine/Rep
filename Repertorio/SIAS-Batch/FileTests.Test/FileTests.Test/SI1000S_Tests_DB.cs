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
using static Code.SI1000S;

namespace FileTests.Test_DB
{
    [Collection("SI1000S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI1000S_Tests_DB
    {

        [Fact]
        public static void SI1000S_Database()
        {
            var program = new SI1000S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0110_00_LE_GE_SISTEMA_FUNCAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0120_00_LE_SINISTRO_MESTRE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/

                program.CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.Value = "2000-10-10";

                program.R0130_00_LE_CALENDARIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                
                program.HOST_DATA_FIM.Value = "2000-10-10";
                program.HOST_DATA_INICIO.Value = "2000-10-10";


                program.R0300_00_SUM_FUNCAO_SINISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/
                
                program.HOST_DATA_FIM.Value = "2000-10-10";
                program.HOST_DATA_INICIO.Value = "2000-10-10";

                program.R0400_00_SUM_FUNCAO_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0500_00_SUM_FUNCAO_RAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}