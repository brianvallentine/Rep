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
using static Code.VG0781B;

namespace FileTests.Test_DB
{
    [Collection("VG0781B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0781B_Tests_DB
    {

        [Fact]
        public static void VG0781B_Database()
        {
            var program = new VG0781B();

            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            try { /*1*/ program.M_000_100_SELECT_V1EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_000_200_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_000_300_DECLARE_RELATORIOS_DB_DECLARE_1(); program.M_000_300_DECLARE_RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*4*/
                program.V1RELATORIOS_DATA1.Value = "2020-01-01";
                program.V1RELATORIOS_DATA2.Value = "2020-01-01";
                program.M_600_100_DECLARA_ENDOSSO_DB_DECLARE_1();
                program.M_1500_100_OPEN_ENDOSSO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/ program.M_000_500_SELECT_V0CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_000_700_UPDATE_V1RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*7*/
                program.V0ENDOPARC_DTQITBCO.Value = "2020-01-01";
                program.M_200_100_SELECT_V1MOEDA_DB_SELECT_1();
            }

            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*8*/
                program.V0ENDOPARC_DTQITBCO.Value = "2020-01-01";
                program.V0ENDOPARC_DTMOVTO.Value = "2020-01-01";
                
                program.M_800_100_BUSCA_HISTORICO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/ program.M_1000_100_BUSCA_COBERTURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}