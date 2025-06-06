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
using static Code.VG5705B;

namespace FileTests.Test_DB
{
    [Collection("VG5705B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG5705B_Tests_DB
    {

        [Fact]
        public static void VG5705B_Database()
        {
            var program = new VG5705B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0000_INICIO_DB_DECLARE_1(); program.M_0000_INICIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*3*/
                program.SQL_DTMOVTO.Value = "2025-01-28";
                program.M_1500_NOVAS_COMISSOES_DB_DECLARE_1(); 
                program.M_1500_NOVAS_COMISSOES_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_0000_INICIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_1500_NOVAS_COMISSOES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_1500_NOVAS_COMISSOES_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_1600_PROCESSA_PLANOS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}