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
using static Code.SPBVG015;

namespace FileTests.Test_DB
{
    [Collection("SPBVG015_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class SPBVG015_Tests_DB
    {
        private static string pData = "2024-01-01";

        [Fact]
        public static void SPBVG015_Database()
        {
            var program = new SPBVG015();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try
            { /*1*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = pData;
                program.P8000_05_INICIO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*2*/ program.P8100_05_INICIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.P0050_05_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.SPGE051W.LK_GE051_TRACE.Value = "S";
                program.SPGE051W.LK_GE051_NUM_CPF_CNPJ.Value = 03574845928;
                program.SPGE051W.LK_GE051_S_QTD_CNTR_PREST.Value = 1;
                program.SPGE051W.LK_GE051_S_VLR_IS_ACUM_PREST.Value = 123;
                program.SPGE051W.LK_GE051_S_QTD_CONTR_VIDA.Value = 1;
                program.SPGE051W.LK_GE051_S_VLR_IS_ACUM_VIDA.Value = 222;
                program.SPGE051W.LK_GE051_S_QTD_CNTR_PREV.Value = 1;
                program.SPGE051W.LK_GE051_S_VLR_IS_ACUM_PREV.Value = 33;
                program.SPGE051W.LK_GE051_S_QTD_CONTR_HABIT.Value = 1;
                program.SPGE051W.LK_GE051_S_VLR_IS_ACUM_HABIT.Value = 22;
                program.SPGE051W.LK_GE051_S_QTD_TOTAL_CNTR.Value = 1;
                program.SPGE051W.LK_GE051_S_VLR_TOTAL_CNTR.Value = 44;
                program.SPGE051W.LK_GE051_IND_ERRO.Value = 0;
                program.SPGE051W.LK_GE051_MSG_ERRO.Value = "";
                program.SPGE051W.LK_GE051_NOM_TABELA.Value = "";
                program.SPGE051W.LK_GE051_SQLCODE.Value = 0;
                program.SPGE051W.LK_GE051_SQLERRMC.Value = "";
                program.SPGE051W.LK_GE051_S_DTH_CAD_PREST.Value = pData;
                program.SPGE051W.LK_GE051_S_DTH_CAD_VIDA.Value = pData;
                program.SPGE051W.LK_GE051_S_DTH_CAD_PREV.Value = pData;
                program.SPGE051W.LK_GE051_S_DTH_CAD_HABIT.Value = pData;
                program.SPGE051W.LK_GE051_S_DTH_CADASTRAMENTO.Value = pData;
                program.P0310_05_INICIO_DB_CALL_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}