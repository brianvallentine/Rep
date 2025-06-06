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
using static Code.SI0220B;

namespace FileTests.Test_DB
{
    [Collection("SI0220B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0220B_Tests_DB
    {

        [Fact]
        public static void SI0220B_Database()
        {
            var program = new SI0220B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R010_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R015_LE_MONTA_NOME_EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R020_LE_PROVISAO_DIA_DB_DECLARE_1(); program.R020_LE_PROVISAO_DIA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R110_LE_CONTRATO_CLIENTE_DB_DECLARE_1(); program.R110_LE_CONTRATO_CLIENTE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R110_LE_CONTRATO_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R110_LE_CONTRATO_CLIENTE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R120_BUSCA_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R130_LE_AGENCIA_CONTRATO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}