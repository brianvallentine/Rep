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
using static Code.SPBVG009;

namespace FileTests.Test_DB
{
    [Collection("SPBVG009_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class SPBVG009_Tests_DB
    {

        [Fact]
        public static void SPBVG009_Database()
        {
            var program = new SPBVG009();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.P0050_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           
            try { /*2*/
                program.VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_SEQ_PESSOA_HIST.Value = 1;
                program.VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_COD_PESSOA.Value = 1;
                program.P0301_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.VG110.DCLVG_C612_RELAC_PROPOSTA.VG110_NUM_PROPOSTA.Value = 1;
                program.P3021_05_INICIO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}