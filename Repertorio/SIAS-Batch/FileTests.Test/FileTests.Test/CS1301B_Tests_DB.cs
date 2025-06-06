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
using static Code.CS1301B;

namespace FileTests.Test_DB
{

    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("CS1301B_Tests_DB")]
    public class CS1301B_Tests_DB
    {

        [Fact]
        public static void CS1301B_Database()
        {
            var program = new CS1301B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_SELECT_RELATORI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value =  "2020-01-01" ;
                program.RELATORI_PROX_INICIAL.Value = "2020-01-01";
                program.RELATORI_PROX_FINAL.Value = "2020-01-01";
                program.R0210_00_UPDATE_RELATORI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.WS_COD_CONGENERE.Value =1 ;
			    program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = "2020-01-01";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R1100_00_DECLARE_PARCELAS_DB_DECLARE_1(); program.R1100_00_DECLARE_PARCELAS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}