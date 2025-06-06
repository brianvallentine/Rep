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
using static Code.VA0100S;

namespace FileTests.Test_DB
{
    [Collection("VA0100S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA0100S_Tests_DB
    {

        [Fact]
        public static void VA0100S_Database()
        {
            var program = new VA0100S();

            program.DTMOVTO.Value = "2000-10-10";
            program.DTINIVIG.Value = "2000-10-10";

            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.Execute_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.Execute_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0100_INCLUI_LANCAMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.Execute_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.Execute_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/  program.M_0200_ALTERA_LANCAMENTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_0300_CONTABIL_NOVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/  program.M_0400_INCLUI_LANCAMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_0500_ALTERA_LANCAMENTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}