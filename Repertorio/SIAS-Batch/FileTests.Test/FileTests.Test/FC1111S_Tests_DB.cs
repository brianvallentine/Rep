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
using static Code.FC1111S;

namespace FileTests.Test_DB
{
    [Collection("FC1111S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class FC1111S_Tests_DB
    {

        [Fact]
        public static void FC1111S_Database()
        {
            var program = new FC1111S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0500_00_SELECT_GE_ROT_ETAPA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTH_INI_VIGENCIA.Value = "2016-08-14 14:32:30.214";
                program.R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/ program.R0900_00_CRITICA_EXEC_ETP_POS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.GE387.DCLGE_EXEC_ROTINA_ETAPA.GE387_DTA_FIM_MOVIMENTO.Value = "2020-01-01";
                program.R1100_00_SELECT_CALENDARIO_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.R1200_00_INS_GE_EXC_ROT_ETP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.GE386.DCLGE_ROTINA_ETAPA.GE386_DTH_INI_VIGENCIA.Value = "2016-08-14 14:32:30.214";
                program.R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/ program.R1500_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}