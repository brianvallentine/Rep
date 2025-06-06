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
using static Code.LT3250S;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("LT3250S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT3250S_Tests_DB
    {

        [Fact]
        public static void LT3250S_Database()
        {
            var program = new LT3250S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_MODALIDA_COBERTURA.Value = 2;
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.Value = 71;
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA.Value = 1;
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL.Value = 1;
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE.Value = 107100032687;
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG.Value = "1999-08-11";
                program.R1010_00_LER_TAXA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.Value = 71;
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_COBERTURA.Value = 1;
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL.Value = 1;
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE.Value = 107100032687;
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG.Value = "1999-08-11";
                program.R1110_00_LER_COEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/

                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_RAMO_COBERTURA.Value = 71;
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_COD_LOT_FENAL.Value = 1;
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_NUM_APOLICE.Value = 107100032687;
                program.LOTTAX01.DCLLOTTAXA01.LOTTAX01_DTINIVIG.Value = "1999-08-11";              
                program.R1250_00_LER_PCT_PLURI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.LBLT3250.LT3250_AREA_PARAMETROS.LT3250_DTINIVIG.Value= "2021-12-31";
                program.WS_DATA.Value = "2021-06-01";
                program.R1260_00_CALC_QTD_DIAS_VIG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}