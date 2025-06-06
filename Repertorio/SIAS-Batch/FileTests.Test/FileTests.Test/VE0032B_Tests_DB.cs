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
using static Code.VE0032B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("VE0032B_Tests_DB")]
    public class VE0032B_Tests_DB
    {
        private static string pData = "2020-02-02";
        [Fact]
        public static void VE0032B_Database()
        {
            var program = new VE0032B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0000_00_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0800_00_DECLER_V0RELATORIOS_DB_DECLARE_1(); program.R0800_00_DECLER_V0RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0850_00_PROCESSA_V0RELATORIOS_DB_DECLARE_1(); program.R0850_00_PROCESSA_V0RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0850_00_PROCESSA_V0RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0850_00_PROCESSA_V0RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R2000_00_UPDATE_V0RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R6000_00_CANCELA_SEGURO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R6000_10_LOOP_PROPAUTOM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R6000_10_LOOP_PROPAUTOM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.FATURCON.DCLFATURAS_CONTROLE.FATURCON_DATA_REFERENCIA.Value = pData;
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Value = pData;
                program.R6000_10_LOOP_PROPAUTOM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R6000_00_CANCELA_SEGURO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R6000_00_CANCELA_SEGURO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R6000_00_CANCELA_SEGURO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R6000_00_CANCELA_SEGURO_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R6000_00_CANCELA_SEGURO_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R6000_00_CANCELA_SEGURO_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R6000_00_CANCELA_SEGURO_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}