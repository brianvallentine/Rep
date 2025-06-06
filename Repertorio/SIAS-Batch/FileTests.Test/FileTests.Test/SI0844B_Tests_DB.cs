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
using static Code.SI0844B;

namespace FileTests.Test_DB
{
    [Collection("SI0844B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0844B_Tests_DB
    {

        [Fact]
        public static void SI0844B_Database()
        {
            var program = new SI0844B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0150_00_SELECT_V1RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0400_00_MONTA_CABECALHO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0800_00_DELETE_V0RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0900_00_DECLARE_SINISTRO_DB_DECLARE_1(); program.R0900_00_DECLARE_SINISTRO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R2200_00_SELECT_V1RAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R2300_00_SELECT_V1SINICAUSA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R2400_00_SELECT_V1APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}