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
using static Code.VA0061B;

namespace FileTests.Test_DB
{
    [Collection("VA0061B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0061B_Tests_DB
    {

        [Fact]
        public static void VA0061B_Database()
        {
            var program = new VA0061B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try { /*1*/ program.R1400_00_OPEN_CURSOR01_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R2400_00_OPEN_CURSOR02_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1600_00_PROCESSA_CURSOR01_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1700_00_LE_BUSCA_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1750_VE_SE_ESTA_EM_CRITICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1755_00_SELECT_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/

                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2000-10-10";

                program.R1800_LE_TAB_PLANO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1800_LE_TAB_PLANO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R2000_DELETA_ERROS_PROP_VDAZUL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}