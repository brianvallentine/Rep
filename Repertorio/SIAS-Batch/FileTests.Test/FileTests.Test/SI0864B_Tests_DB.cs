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
using static Code.SI0864B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("SI0864B_Tests_DB")]
    public class SI0864B_Tests_DB
    {

        [Fact]
        public static void SI0864B_Database()
        {
            var program = new SI0864B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.Execute_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R010_SELECT_SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R020_DECLARE_RELATORIO_DB_DECLARE_1(); program.R020_DECLARE_RELATORIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*4*/
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Value = "2025-01-01";
                program.R040_DECLARE_MESTRE_DB_DECLARE_1();
                program.R040_DECLARE_MESTRE_DB_OPEN_1();
            }
            catch (Exception ex)
            {
                _.ThreatableTestError(ex);
            }

            try { /*5*/ program.R021_FETCH_RELATORIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*6*/
                program.SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG.Value = "2025-02-05";
                program.R110_DECLARE_BONUS_DB_DECLARE_1();
                program.R110_DECLARE_BONUS_DB_OPEN_1();
            }
            catch (Exception ex)
            {
                _.ThreatableTestError(ex);
            }

            try
            { /*7*/
                program.SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG.Value = "2025-01-01";
                program.R100_BUSCAR_INFO_LOTERICO01_DB_SELECT_1();
            }
            catch (Exception ex)
            {
                _.ThreatableTestError(ex);
            }

            try { /*8*/ program.R140_BUSCA_DESCR_BONUS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*9*/
                program.SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG.Value = "2025-01-01";
                program.R150_BUSCAR_IMP_SEGURADA_DB_SELECT_1();
            }
            catch (Exception ex)
            {
                _.ThreatableTestError(ex);
            }

            try { /*10*/ program.R160_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R170_BUSCAR_DATA_PAGAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}