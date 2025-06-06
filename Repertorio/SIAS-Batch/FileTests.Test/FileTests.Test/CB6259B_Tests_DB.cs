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
using static Code.CB6259B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("CB6259B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class CB6259B_Tests_DB
    {

        [Fact]
        public static void CB6259B_Database()
        {
            var program = new CB6259B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0300_00_DECLARE_MOVIMCOB_DB_DECLARE_1(); program.R0300_00_DECLARE_MOVIMCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0360_00_SELECT_V0BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0700_00_SELECT_V0RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1100_00_SELECT_AGENCIAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*6*/
                program.RCAPS.DCLRCAPS.RCAPS_DATA_CADASTRAMENTO.Value = "2025-01-27";
                program.RCAPS.DCLRCAPS.RCAPS_DATA_MOVIMENTO.Value = "2025-01-27";

                program.R1310_00_INSERT_RCAPS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*7*/
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.Value = "2025-01-27";
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.Value = "2025-01-27";
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO.Value = "2025-01-27";
                program.R1320_00_INSERT_RCAPCOMP_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*8*/
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO.Value = "2025-01-27";
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO.Value = "00:00:00";
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO.Value = "2025-01-27";
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_QUITACAO.Value = "2025-01-27";
                program.R4100_00_INSERT_FOLLOWUP_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R4200_00_UPDATE_V0MOVICOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R4210_00_UPDATE_V0MOVICOB_TIT_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R5100_00_SELECT_CONDESCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R5200_00_UPDATE_CONDESCE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*13*/ 
                program.CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_MOVIMENTO.Value = "2025-01-27";
                program.CONDESCE.DCLCONTROL_DESPES_CEF.CONDESCE_DATA_AVISO.Value = "2025-01-27";
                program.R5300_00_INSERT_CONDESCE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}