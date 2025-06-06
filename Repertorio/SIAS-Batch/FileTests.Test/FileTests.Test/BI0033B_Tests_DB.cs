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
using static Code.BI0033B;

namespace FileTests.Test_DB
{
    [Collection("BI0033B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class BI0033B_Tests_DB
    {

        [Fact]
        public static void BI0033B_Database()
        {
            var program = new BI0033B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0010_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0015_00_MONTA_V1EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/ program.V0PARAMC_TIPO_MOVTOCC.Value = 1;
                        program.V0PARAMC_SITUACAO.Value = "A";
                        program.R0020_00_DECLARE_V0PARAM_CONTA_DB_DECLARE_1(); program.R0020_00_DECLARE_V0PARAM_CONTA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0065_00_DECLARE_V0MOVDEBCC_DB_DECLARE_1(); program.R0065_00_DECLARE_V0MOVDEBCC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*5*/ program.V1BILH_NUMBIL.Value = 19;
                        program.V1BILH_COD_CLIENTE.Value = 145257;
                        program.R0115_00_LE_V1BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/
                       program.V0MOVDE_NUM_APOLICE.Value = 95422338954;
                       program.R0117_00_SELECT_MOVDEBCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/
                        program.V1CLIEN_COD_CLIENTE.Value = 10;
                        program.R0126_00_LE_V1CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
           
            try
            { /*8*/
                 program.V0PARAMC_DTPROX_DEB.Value= "2025-01-01";
                 program.V1SISTE_DTCURRENT.Value= "2025-01-01";
                 program.V0PARAMC_NSAS.Value = 0001;
                 program.V0PARAMC_TIPO_MOVTOCC.Value = 0000;
                 program.V0PARAMC_COD_CONVENIO.Value = 000000000;
                 program.V0PARAMC_SITUACAO.Value = "A";
                 program.R0130_00_UPDATE_V0PARAM_CONTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/
                program.V1SISTE_DTCURRENT.Value = "2025-01-01";
                program.V0PARAMC_NSAS.Value = 0001;
                program.V0MOVDE_SIT_COBRANCA.Value = "D";
                program.V0MOVDE_NUM_APOLICE.Value = 0103100012237;
                program.V0MOVDE_DTVENCTO.Value = "2025-01-01";
                program.R0140_00_UPDATE_V0MOVDEBCC_CEF_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/
                program.V0BILH_SITUACAO.Value = "6";
                program.V0BILH_NUMBIL.Value = 000103100012237;
                program.R0150_00_UPDATE_V0BILHETE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}