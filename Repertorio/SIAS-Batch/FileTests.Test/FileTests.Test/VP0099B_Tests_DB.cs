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
using static Code.VP0099B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("VP0099B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VP0099B_Tests_DB
    {
        private static string pData = "2020-02-02";

        [Fact]
        public static void VP0099B_Database()
        {
            var program = new VP0099B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try { /*1*/ program.R2000_PRINCIPAL_COMPRA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R4000_PRINCIPAL_CANCEL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1100_PEGAR_MAX_SEQ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R2300_LER_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R2400_LER_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R2500_LER_PESSOA_FISICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R2530_DESC_PROFISSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R2600_LER_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R2700_LER_TELEFONE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_DTA_INI_VIGENCIA.Value = pData;
                program.VG097.DCLVG_ACOPLADO_PRESTAMISTA.VG097_DTA_FIM_VIGENCIA.Value = pData;
                program.R2900_INS_VG_ACOPLADO_PREST_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R2950_UPT_PROPOSTAS_VA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}