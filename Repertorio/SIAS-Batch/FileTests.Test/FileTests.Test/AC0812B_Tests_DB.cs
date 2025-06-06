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
using static Code.AC0812B;

namespace FileTests.Test_DB
{
    [Collection("AC0812B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package05)]
    public class AC0812B_Tests_DB
    {

        [Fact]
        public static void AC0812B_Database()
        {
            var program = new AC0812B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_DECLARE_V1RELATORIOS_DB_DECLARE_1(); program.R0200_00_DECLARE_V1RELATORIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.V1CCHQ_DTLIBERA.Value = fullDataMock;
                
                program.V1RELA_DATA_SOL.Value = fullDataMock;
                program.V1SIST_DTMOVABE.Value = fullDataMock;
                  
                program.R0700_00_DECLARE_V0COSCED_CHQ_DB_DECLARE_1(); program.R0700_00_DECLARE_V0COSCED_CHQ_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0500_00_SELECT_V0RELATORIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0500_00_SELECT_V0RELATORIOS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0600_00_SELECT_RELAT_CONG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0500_00_SELECT_V0RELATORIOS_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0600_00_SELECT_RELAT_CONG_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.WHOST_DTMOVTO.Value = fullDataMock;              
                program.V1RELA_DATA_REF.Value = fullDataMock;

                program.R0800_00_DECLARE_V1COSGHISTP_DB_DECLARE_1(); program.R0800_00_DECLARE_V1COSGHISTP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.WHOST_DTMOVTO.Value = fullDataMock;
                program.V1RELA_DATA_REF.Value = fullDataMock;
                program.R1500_00_DECLARE_V1COSSEGHIS_DB_DECLARE_1(); program.R1500_00_DECLARE_V1COSSEGHIS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ 
                program.V1MOED_DTINIVIG.Value = fullDataMock;
                program.R1000_00_SELECT_V1MOEDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1200_00_DELETE_V0RELATORIOS_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1400_00_SELECT_V0COSCED_CHQ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1700_00_SELECT_V0ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1800_00_SELECT_V1COSSEG_PREM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1900_00_OPERACAO_ORIGINAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R2000_00_SOMA_CORRECAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/
                program.V1COTA_DTINIVIG.Value = fullDataMock;
                program.V1COTA_DTINIVIG.Value = fullDataMock;
                program.R2400_00_SELECT_V1COTACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/

                program.V0CHIS_DAT_MOVT.Value = fullDataMock;
                program.V0CHIS_DTQITBCO.Value = fullDataMock;
                program.R2500_00_INSERT_COSSEGHIS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R2600_00_UPDATE_COSSEGPRE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R2700_00_UPDATE_COSSEGHIS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/
                
                program.WHOST_DTMOVTO_AC.Value = fullDataMock;

                program.R3100_00_SELECT_V0COSCED_CHQ_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/
                program.V0CCHQ_DTMOVTO_AC.Value = fullDataMock;
                program.V0CCHQ_DTLIBERA.Value = fullDataMock;
                program.V0CCHQ_DTMOVTO_FI.Value = fullDataMock;
                program.VIND_DTMOVTO_FI.Value = 15;
                program.V0CCHQ_DTCORRECAO.Value = fullDataMock;
                program.VIND_DTCORRECAO.Value = 15;

                program.R3200_00_INSERT_V0COSCED_CHQ_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}