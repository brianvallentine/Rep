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
using Dclgens;
using Code;
using static Code.PTTEXTOS;

namespace FileTests.Test_DB
{
    [Collection("PTTEXTOS_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class PTTEXTOS_Tests_DB
    {

        [Fact]
        public static void PTTEXTOS_Database()
        {
            var program = new PTTEXTOS();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R1200_00_INCLUI_CARTA_TEXTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R2100_00_ALTERA_CARTA_TEXTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}