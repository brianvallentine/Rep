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
using static Code.SI0822B;

namespace FileTests.Test_DB
{
    [Collection("SI0822B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI0822B_Tests_DB
    {

        [Fact]
        public static void SI0822B_Database()
        {
            var program = new SI0822B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/

                program.V0RELA_PERI_FINAL.Value = "2000-10-10";
                program.V0RELA_PERI_INICIAL.Value = "2000-10-10";


                program.M_0000_00_DECLARE_CEDIDO_DB_DECLARE_1(); program.M_0000_00_DECLARE_CEDIDO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0000_00_DECLARE_ACEITO_DB_DECLARE_1(); program.M_0000_00_DECLARE_ACEITO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0000_00_DECLARE_V0RELATORIOS_DB_DECLARE_1(); program.M_0000_00_DECLARE_V0RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_0000_00_MONTA_CABECALHO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_0000_00_SELECT_CONGENERE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_0000_00_DELETE_V0RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}