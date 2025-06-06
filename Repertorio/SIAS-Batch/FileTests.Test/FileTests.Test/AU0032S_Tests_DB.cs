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
using static Code.AU0032S;

namespace FileTests.Test_DB
{
    [Collection("AU0032S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class AU0032S_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void AU0032S_Database()
        {
            var program = new AU0032S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.TXACE_DTINIVIG.Value = pData;
                program.M_020_000_PESQ_TATTXACE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ 
                program.BONUS_DTINIVIG.Value = pData;
                program.M_060_000_PESQ_TATBONUS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ 
                program.PRAZO_DTINIVIG.Value = pData;
                program.M_120_000_PESQ_TATPRAZO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ 
                program.CATTF_DTINIVIG.Value = pData;
                program.M_180_000_PESQ_V1CATTARIFA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}