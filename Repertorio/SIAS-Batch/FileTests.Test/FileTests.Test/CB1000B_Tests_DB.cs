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
using static Code.CB1000B;
using Xunit.Internal;

namespace FileTests.Test_DB
{
    [Collection("CB1000B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class CB1000B_Tests_DB
    {
        private static string pData = "2020-01-02";
        [Fact]
        public static void CB1000B_Database()
        {
            var program = new CB1000B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_SELECT_V1RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0300_00_DELETE_V0RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.WHOST_DATA_REF.Value = pData;
                program.R0900_00_DECLARE_V1PARCELA_DB_DECLARE_1(); program.R0900_00_DECLARE_V1PARCELA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R2000_00_SELECT_DATA_VENCTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R3100_00_SALDO_ANTERIOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.V1ENDO_DTINIVIG.Value = pData;
                program.R3500_00_SELECT_V1MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.WHOST_DTVENCTO.Value = pData;
                program.R3600_00_MOEDA_VENCIMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.V1SIST_DTMOVABE.Value = pData;
                program.R3700_00_SELECT_V0COTACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                //program.V0HISP_DACPARC.Value = pData;
                program.V0HISP_DTMOVTO.Value = pData;
                program.V0HISP_DTVENCTO.Value = pData;
                program.V0HISP_DTQITBCO.Value = pData;
                program.V0HISP_HORAOPER.Value = "10:10:10";
                program.R5000_00_INSERT_V0HISTOPARC_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R6000_00_UPDATE_V0PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}