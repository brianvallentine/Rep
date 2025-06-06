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
using Dclgens;
using Code;
using static Code.SI0891B;

namespace FileTests.Test_DB
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0891B_Tests_DB")]
    public class SI0891B_Tests_DB
    {

        [Fact]
        public static void SI0891B_Database()
        {
            var program = new SI0891B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R010_LE_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R030_DECLARE_CTRAB_DB_DECLARE_1(); program.R030_DECLARE_CTRAB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_COD_FONTE.Value = 1;
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_PROTOCOLO_SINI.Value = 2;
                program.R110_PESQUISA_MOTIVO_DB_DECLARE_1(); program.R110_PESQUISA_MOTIVO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}