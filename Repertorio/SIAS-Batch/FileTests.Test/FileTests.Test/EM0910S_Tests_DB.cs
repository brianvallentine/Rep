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
using static Code.EM0910S;

namespace FileTests.Test_DB
{
    [Collection("EM0910S_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class EM0910S_Tests_DB
    {
        private static string pData = "2021-02-02";

        [Fact]
        public static void EM0910S_Database()
        {
            var program = new EM0910S();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0900_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R1100_00_SELECT_V1ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.WHOST_DTINIVIG.Value = pData;
                program.R1200_00_SELECT_V1MOEDA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/ program.R2100_00_DECLARE_V1AUTOPROP_DB_DECLARE_1(); program.R2100_00_DECLARE_V1AUTOPROP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R2200_00_DECLARE_V1AUTARIPROP_DB_DECLARE_1(); program.R2200_00_DECLARE_V1AUTARIPROP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/
                program.V0AUTO_DTINIVIG.Value = pData;
                program.V0AUTO_DTTERVIG.Value = pData;
                program.V0AUTO_DTBAIXA.Value = pData;
                program.V0AUTO_DTIVEXTP.Value = pData;
                program.R2110_00_INCLUI_V0AUTOAPOL_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.R2300_00_DECLARE_V1AUTCOBPROP_DB_DECLARE_1(); program.R2300_00_DECLARE_V1AUTCOBPROP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/
                program.V0TARI_DTINIVIG.Value = pData;
                program.V0TARI_DTTERVIG.Value = pData;
                program.V0TARI_DATEND.Value = pData;
                program.R2210_00_INCLUI_V0AUTOTARIFA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/ program.R2400_00_DECLARE_V1PROPACES_DB_DECLARE_1(); program.R2400_00_DECLARE_V1PROPACES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.V0AUCB_DTINIVIG.Value = pData;
                program.V0AUCB_DTTERVIG.Value = pData;
                program.R2310_00_INCLUI_V0AUTOCOBER_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/ program.R2500_00_DECLARE_V1PROPCLAU_DB_DECLARE_1(); program.R2500_00_DECLARE_V1PROPCLAU_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ 
                program.V0APAC_DTINIVIG.Value = pData;
                program.V0APAC_DTTERVIG.Value = pData;
                program.R2410_00_INCLUI_V0APOLACES_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*13*/ program.R2600_00_DECLARE_AUPROPCOMPL_DB_DECLARE_1(); program.R2600_00_DECLARE_AUPROPCOMPL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.V0APCL_DTINIVIG.Value = pData;
                program.V0APCL_DTTERVIG.Value = pData;
                program.R2510_00_INCLUI_V0APOLCLAU_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/ program.R4200_00_DECLARE_V1COBERPROP_DB_DECLARE_1(); program.R4200_00_DECLARE_V1COBERPROP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R2610_00_INCLUI_AUAPOLCOMPL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ 
                program.V0EDIA_DTMOVTO.Value = pData;
                program.R3100_00_INCLUI_V0EMISDIARIA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*18*/ program.R4100_00_SELECT_V1COBERPROP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/
                program.V0COBA_DATA_INIVI.Value = pData;
                program.V0COBA_DATA_TERVI.Value = pData;
                program.R4600_00_INSERE_V0COBERAPOL_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*20*/ program.R5000_00_UPDATE_V0COBERAPOL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R7010_00_INCLUI_AU055_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ 
                program.AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_OPERACAO.Value = pData;
                program.AU055.DCLAU_HIS_PROP_CONV.AU055_DTH_MOVTO_ARQUIVO.Value = pData;
                program.R7010_00_INCLUI_AU055_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*23*/ program.R7010_00_INCLUI_AU055_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R7020_00_UPDATE_AU057_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R7030_00_SELECT_AU055_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ 
                program.AU050.DCLAU_PROP_COBRNCA_VC.AU050_DTH_MOVIMENTO.Value = pData;
                program.R7040_00_INCLUI_AU050_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}