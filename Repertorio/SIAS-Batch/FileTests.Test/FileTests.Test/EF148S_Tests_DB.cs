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
using static Code.EF148S;

namespace FileTests.Test_DB
{
    [Collection("EF148S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EF148S_Tests_DB
    {

        [Fact]
        public static void EF148S_Database()
        {
            var program = new EF148S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            program.EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_INI_VIGENCIA.Value = "2000-10-10";
            program.EF148.DCLEF_PROD_ACESSORIO.EF148_DTH_FIM_VIGENCIA.Value = "2000-10-10";
            try { /*1*/ program.P010_INS_PROC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.P020_UPD_PROC_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.P030_DEL_PROC_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.P040_SEL_PROC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.P041_SEL_PROC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}