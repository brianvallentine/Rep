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
using static Code.SI4922B;

namespace FileTests.Test_DB
{
    [Collection("SI4922B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI4922B_Tests_DB
    {

        [Fact]
        public static void SI4922B_Database()
        {
            var program = new SI4922B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            try { /*1*/
                program.AREA_DE_WORK.HOST_DATA_SISTEMA.Value = "1988-04-30";
                program.R000_INICIO_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*2*/
                program.AREA_DE_WORK.HOST_DATA_NEGOCIADA.Value = "1988-04-30";
                program.R000_INICIO_DB_SELECT_2(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/ program.R100_LIMITE_MAXIMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/
                program.AREA_DE_WORK.W_DATA_LIMITE_MAXIMO.Value = "1988-04-30";
                program.AREA_DE_WORK.HOST_DATA_SISTEMA.Value = "1987-04-30";
                program.R110_PROXIMO_DIA_UTIL_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/
                program.AREA_DE_WORK.W_DATA_LIMITE_MAXIMO.Value = "1988-04-30";
                program.AREA_DE_WORK.HOST_DATA_SISTEMA.Value = "1987-04-30";
                program.R120_DATA_PARA_CONVENIO_DB_DECLARE_1(); program.R120_DATA_PARA_CONVENIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}