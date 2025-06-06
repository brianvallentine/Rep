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
using static Code.VE0029B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("VE0029B_Tests_DB")]
    public class VE0029B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void VE0029B_Database()
        {
            var program = new VE0029B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/
                program.V1SIST_DTMOVABE.Value = pData;
                program.R0200_00_DECLER_V0ENDOSSO_DB_DECLARE_1(); program.R0200_00_DECLER_V0ENDOSSO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.V0PEND_DTVENCTO.Value = pData;
                program.R0235_00_SEL_PERCELAS_ANT_DB_DECLARE_1(); program.R0235_00_SEL_PERCELAS_ANT_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0225_00_LER_V0TERMOADESAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ 
                program.V0PEND_DTVENCTO.Value = pData;
                program.R0230_00_HOUVE_PGTO_FUTURO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0250_00_VERIFICA_PGTO_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0260_00_VERIFICA_PGTO_HISPARC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0275_00_VERIFICA_SOLICITACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ 
                program.V1SIST_DTMOVABE.Value = pData;
                program.R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}