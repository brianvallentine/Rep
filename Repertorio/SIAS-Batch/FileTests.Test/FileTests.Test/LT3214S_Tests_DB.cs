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
using static Code.LT3214S;

namespace FileTests.Test_DB
{
    [Collection("LT3214S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3214S_Tests_DB
    {

        [Fact]
        public static void LT3214S_Database()
        {
            var program = new LT3214S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_CRITICA_PARAMETROS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_DATA_MOVIMENTO.Value = "2021-02-02";
                program.LTMVPROP.DCLLT_MOV_PROPOSTA.LTMVPROP_HORA_MOVIMENTO.Value = "14:41:27";
                program.R0900_00_DECLARE_PREMIOS_DB_DECLARE_1(); 
                program.R0900_00_DECLARE_PREMIOS_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}