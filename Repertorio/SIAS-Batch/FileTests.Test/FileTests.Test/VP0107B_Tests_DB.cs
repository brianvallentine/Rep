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
using static Code.VP0107B;

namespace FileTests.Test_DB
{
    [Collection("VP0107B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VP0107B_Tests_DB
    {
        [Fact]
        public static void VP0107B_Database()
        {
            var program = new VP0107B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.XDATA_MOVIMENTO.Value = "2000-10-10";

            try { /*1*/ program.M_010_000_INICIO_PROCESSO_DB_DECLARE_1(); program.M_010_000_INICIO_PROCESSO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_090_000_CURSOR_V0FUNCIOCEF_DB_DECLARE_1(); program.M_090_000_CURSOR_V0FUNCIOCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_012_000_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_015_000_PROCESSA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_091_000_CURSOR_V0FUNCIOSUR_DB_DECLARE_1(); program.M_091_000_CURSOR_V0FUNCIOSUR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_150_000_SELECT_V0SUREG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_230_000_SELECT_V0COBERAPOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_1000_000_COTACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_1200_ACESSA_V1MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_1200_ACESSA_V1MOEDA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}