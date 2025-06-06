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
using static Code.LT2036B;

namespace FileTests.Test_DB
{
    [Collection("LT2036B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class LT2036B_Tests_DB
    {
        private static string pData = "2023-02-02";

        [Fact]
        public static void LT2036B_Database()
        {
            var program = new LT2036B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0110_INPUT_SORT_DB_DECLARE_1(); program.R0110_INPUT_SORT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0210_SELECT_IMP_SEG_DB_DECLARE_1(); program.R0210_SELECT_IMP_SEG_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0130_DEL_V0RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0160_SELECT_V0LOTERICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.AREA_DE_WORK.WS_MAX_DTINIVIG.Value = pData;
                program.R0160_SELECT_V0LOTERICO_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.R0180_SELECT_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0180_SELECT_APOLICE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0190_SELECT_DTINIVIG_INI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R2500_00_COBERTURAS_DB_DECLARE_1(); program.R2501_00_OPEN_CURS02_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0230_SELECT_BONUS_DB_DECLARE_1(); program.R0230_SELECT_BONUS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.V0RELA_PERI_INICIAL.Value = pData;
                program.V0RELA_PERI_FINAL.Value = pData;
                program.V0RELA_DATA_SOLICITACAO.Value = pData;
                program.V0RELA_DATA_REFERENCIA.Value = pData;
                program.R8901_00_INSERT_RELATORIO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}