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
using static Code.SI1000B;

namespace FileTests.Test_DB
{
    [Collection("SI1000B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SI1000B_Tests_DB
    {

        [Fact]
        public static void SI1000B_Database()
        {
            var program = new SI1000B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.W1MOED_DTINIVIG.Value = "2023-01-01";
                program.R0200_00_SELECT_V1MOEDA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/
                program.V1SIST_DTMOVABE.Value = "2021-01-01";
                program.R0900_00_DECLARE_V1MESTSINI_DB_DECLARE_1();
                program.R0900_00_DECLARE_V1MESTSINI_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/
                program.V0HSIN_DTMOVTO.Value = "2023-01-01";
                program.V0HSIN_HORAOPER.Value = "12:12:12";
                program.V0HSIN_LIMCRR.Value = "2021-01-01";
                program.V0HSIN_DATNEG.Value = "2021-05-05";
                program.R4000_00_INSERT_V0HISTSINI_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/ program.R5000_00_ATUALIZA_V0MESTSINI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R6000_00_ACESSA_DATA_CORRECAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}