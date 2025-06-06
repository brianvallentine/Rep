using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.VP1111B;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]

    [Collection("VP1111B_Tests_DB")]
    public class VP1111B_Tests_DB
    {

        [Fact]
        public static void VP1111B_Database()
        {
            var program = new VP1111B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            program.InitializeGetQuery();

            try { /*1*/ program.R20000_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R20000_PRINCIPAL_DB_OPEN_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*3*/
                program.WS_DT_INI.Value = "2023-01-01";
                program.WS_DT_FIM.Value = "2024-01-01";
                program.R20000_PRINCIPAL_DB_OPEN_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*4*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2024-01-01";
                program.R10000_INICIALIZA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*5*/
                program.WS_DT_INI.Value = "2023-01-01";
                program.WS_DT_FIM.Value = "2024-01-01";                
                program.R10000_INICIALIZA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*6*/ program.R20400_UPDATE_FIDELIZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R20650_TRATA_NUM_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R20800_UPDATE_EF_SAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R21110_PEGAR_NUM_CONT_TERC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R21120_UPDATE_EF_ENVIO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}