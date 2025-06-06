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
using static Code.VA0415B;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace FileTests.Test_DB
{
    [Collection("VA0415B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA0415B_Tests_DB
    {
        private static string pData = "2022-01-01";

        [Fact]
        public static void VA0415B_Database()
        {
            var program = new VA0415B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R001_SELECT_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.V1SIST_DTMOVABE.Value = pData;
                program.R010_DECLARE_PROPOVA_DB_DECLARE_1(); program.R010_DECLARE_PROPOVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R040_SELECT_COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R050_SELECT_SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R060_SELECT_HISTSEGVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ 
                program.V0HSEG_DTREFER.Value = pData;
                program.R070_TRATA_TRANS_CREDITO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R070_TRATA_TRANS_CREDITO_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R080_TRATA_TRANS_DEBITO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.R080_TRATA_TRANS_DEBITO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R080_TRATA_TRANS_DEBITO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}