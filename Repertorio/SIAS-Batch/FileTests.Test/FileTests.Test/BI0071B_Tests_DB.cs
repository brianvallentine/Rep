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
using static Code.BI0071B;

namespace FileTests.Test_DB
{
    [Collection("BI0071B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class BI0071B_Tests_DB
    {

        [Fact]
        public static void BI0071B_Database()
        {
            var program = new BI0071B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0010_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0013_00_SELECT_TIMESTAMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0015_00_MONTA_V1EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0020_00_DECLARE_V0PARAM_CONTA_DB_DECLARE_1(); program.R0020_00_DECLARE_V0PARAM_CONTA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0065_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1(); program.R0065_00_DECLARE_V0MOVDEBCC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                //query demorada mais de 5 milhoes de dados recuperados
                
                program.R0114_00_LE_V1BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0115_00_LE_V1BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/

                program.V0MOVDE_DTVENCTO.Value = "2000-10-10";

                program.R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0121_00_LE_CONVERSI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0121_00_LE_CONVERSI_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0122_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0121_00_LE_CONVERSI_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0123_00_LE_APOLCOBR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R0126_00_LE_V1CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/

                program.V0PARAMC_DTPROX_DEB.Value = "2000-10-10";

                program.R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R4150_00_SELECT_BILCOBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R4300_00_INSERT_COMFEDCA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R4350_00_INSERT_RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R4370_00_SELECIONA_TITULO_CAP_DB_CALL_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R5000_00_SELECT_EMP_CAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}