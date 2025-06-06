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
using static Code.AC0217B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]

    [Collection("AC0217B_Tests_DB")]
    public class AC0217B_Tests_DB
    {

        [Fact]
        public static void AC0217B_Database()
        {
            var dtTeste = "2024-01-01";
            var program = new AC0217B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*2*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = dtTeste;
                program.R0900_00_DECLARE_COSSEGURO_DB_DECLARE_1(); program.R0900_00_DECLARE_COSSEGURO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*3*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = dtTeste;
                program.R1100_00_PENDENTE_HISTORICO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*4*/ program.R1200_00_PENDENTE_01_2006_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1200_00_PENDENTE_01_2006_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*6*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = dtTeste;
                program.R1300_00_PENDENTE_COSSEG_01_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*7*/ program.R1200_00_PENDENTE_01_2006_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*8*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = dtTeste;
                program.DATA_TAPA_TEC.Value = dtTeste;
                program.R1400_00_PENDENTE_COSSEG_02_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*9*/
                program.WS_LAN_ANT.DT_MOVTO_ANT.Value = dtTeste;
                program.R1500_00_UPDATE_COSSEGURO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}