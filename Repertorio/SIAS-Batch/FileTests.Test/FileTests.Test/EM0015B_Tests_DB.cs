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
using static Code.EM0015B;

namespace FileTests.Test_DB
{
    [Collection("EM0015B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0015B_Tests_DB
    {

        [Fact]
        public static void EM0015B_Database()
        {
            var program = new EM0015B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0010_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*2*/
                program.V0EMISD_DTMOVTO.Value = "2025-01-27";
                program.R0020_00_DECLARE_V0EMISDIARIA_DB_DECLARE_1(); 
                program.R0040_00_ABRE_V0EMISDIARIA_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0030_00_DECLARE_V0HISTOPARC_DB_DECLARE_1(); program.R0120_00_ABRE_V0HISTOPARC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0035_00_DECLARE_V0APOLINDICA_DB_DECLARE_1(); program.R0400_00_ABRE_V0APOLINDICA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0070_00_LE_V0ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0080_00_LE_V0PROPCOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0090_00_LE_V0PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0100_00_INCLUI_V0APOLCOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0101_00_RECUPERA_AU085_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0105_00_UPDATE_MOVIMCOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0110_00_LE_V0PARAM_CONTACEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0150_00_UPDATE_V0EMISDIARIA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*13*/
                program.V0MOVDE_DTVENCTO.Value = "2025-01-27";
                program.V0MOVDE_DTMOVTO.Value = "2025-01-27";
                program.V0MOVDE_DTENVIO.Value = "2025-01-27";
                program.V0MOVDE_DTCREDITO.Value = "2025-01-27";
                program.R0160_00_INCLUI_V0MOVDE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*14*/
                program.V0PRODG_DATA_INIVIGENCIA.Value = "2025-01-27";
                program.V0PRODG_DATA_TERVIGENCIA.Value = "2025-01-27";
                program.R0541_00_LE_V0PRODGER_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R0541_05_LE_V0PRODGER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R0541_10_LE_V0PRODUTOR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R0542_00_LE_V0FUNCIOCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R0551_00_LE_V0AGENCIACEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*19*/
                program.V0PRODE_DATA_INIVIGENCIA.Value = "2025-01-27";
                program.V0PRODE_DATA_TERVIGENCIA.Value = "2025-01-27";
                program.R0552_00_LE_V0PRODESCNEG_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R0553_00_LE_V0FUNCIOCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R0570_00_UPDATE_V0APOLINDICA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R0600_00_LER_TITULO_LOTERICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R0600_00_LER_TITULO_LOTERICO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R0600_00_LER_TITULO_LOTERICO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R0600_00_LER_TITULO_LOTERICO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}