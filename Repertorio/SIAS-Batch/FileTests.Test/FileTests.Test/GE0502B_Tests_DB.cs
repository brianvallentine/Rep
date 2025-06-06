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
using static Code.GE0502B;

namespace FileTests.Test_DB
{
    [Collection("GE0502B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class GE0502B_Tests_DB
    {

        [Fact]
        public static void GE0502B_Database()
        {
            var program = new GE0502B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.Execute_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*2*/
                program.OD001.DCLOD_PESSOA.OD001_DTH_CADASTRAMENTO.Value = "2020-01-01";
                program.OD007.DCLOD_PESSOA_ENDERECO.OD007_DTH_CADASTRAMENTO.Value = "2020-01-01";
                program.R200_CONSULTA_ENDERECO_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/
                program.OD007.DCLOD_PESSOA_ENDERECO.OD007_DTH_CADASTRAMENTO.Value = "2020-01-01";
                program.R100_INSERT_ENDERECO_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/
                program.OD007.DCLOD_PESSOA_ENDERECO.OD007_DTH_CADASTRAMENTO.Value = "2020-01-01";
                program.R100_INSERT_ENDERECO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/
                program.OD001.DCLOD_PESSOA.OD001_NUM_PESSOA.Value = 1006;
                program.R310_00_DECLARE_ENDERECO_DB_DECLARE_1(); 
                program.R310_00_DECLARE_ENDERECO_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}