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
using static Code.BI0031B;

namespace FileTests.Test_DB
{
    [Collection("BI0031B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class BI0031B_Tests_DB
    {
        private static string pData = "2021-01-01";

        [Fact]
        public static void BI0031B_Database()
        {
            var program = new BI0031B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0010_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0015_00_MONTA_V1EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0020_00_DECLARE_V0PARAM_CONTA_DB_DECLARE_1(); program.R0020_00_DECLARE_V0PARAM_CONTA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0065_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1(); program.R0065_00_DECLARE_V0MOVDEBCC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0200_00_CARREGA_ORIGEM_DB_DECLARE_1(); program.R0200_00_CARREGA_ORIGEM_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0115_00_LE_V1BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0116_00_LE_V1BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.V0MOVDE_DTVENCTO.Value = pData;
                program.R0117_UPDATE_V1BILHETE_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/ program.R0118_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.V1BILH_NUMBIL.Value = 0;
                program.R0119_00_LE_PROPOFID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0121_00_LE_BILCOBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0126_00_LE_V1CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ 
                program.V0PARAMC_DTPROX_DEB.Value = pData;
                program.V1SISTE_DTCURRENT.Value = pData;
                program.R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ 
                program.V1SISTE_DTMOVABE.Value = pData;
                program.R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R0141_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R0151_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R8000_PESQUISA_HIS_COBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}