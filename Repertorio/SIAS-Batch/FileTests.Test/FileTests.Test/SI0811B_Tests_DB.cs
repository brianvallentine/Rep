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
using static Code.SI0811B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0811B_Tests_DB")]
    public class SI0811B_Tests_DB
    {

        [Fact]
        public static void SI0811B_Database()
        {
            var program = new SI0811B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_00_ACESSA_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0000_00_ACESSA_EMPRESAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_0000_00_SELECT_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_0000_00_SELECT_V1SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_0000_00_SELECT_V1CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_0000_00_ACESSA_COTACAO_MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_0000_00_DECLARE_V1RELATORIOS_DB_DECLARE_1(); program.M_0000_00_DECLARE_V1RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*8*/


                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Value = "2025-04-02";

                program.M_0000_00_DECLARE_JOIN_HIST_MEST_DB_DECLARE_1();
                program.M_0000_00_DECLARE_JOIN_HIST_MEST_DB_OPEN_1();
            }
            catch (Exception ex)
            {
                _.ThreatableTestError(ex);
            }

            try { /*9*/ program.M_0000_00_DELETE_V1RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}