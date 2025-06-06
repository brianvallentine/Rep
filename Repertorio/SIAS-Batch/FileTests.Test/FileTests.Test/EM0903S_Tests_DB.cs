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
using static Code.EM0903S;

namespace FileTests.Test_DB
{
    [Collection("EM0903S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class EM0903S_Tests_DB
    {
        private static string pData = "2020-02-02";

        [Fact]
        public static void EM0903S_Database()
        {
            var program = new EM0903S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.MOED_DTINIVIG.Value = pData;
                program.A2000_LE_MOEDA_DB_DECLARE_1(); 
                program.A2000_LE_MOEDA_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*2*/
                program.FRAC_DTINIVIG.Value = pData;
                program.A4100_FRACIONA_ESPECIAL_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/ program.A4200_FRACIONA_OUTROS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ 
                program.AU080.DCLAU_PARAM_PLANO_PRDTO.AU080_DTA_INI_VIGENCIA.Value = pData;
                program.R6010_00_SELECT_AU_PLANO_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}