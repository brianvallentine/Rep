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
using static Code.AC0011B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    [Collection("AC0011B_Tests_DB")]
    public class AC0011B_Tests_DB
    {

        [Fact]
        public static void AC0011B_Database()
        {
            var program = new AC0011B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_CHECA_EXECUCAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0500_00_DECLARE_V1HISTOPARC_DB_DECLARE_1(); program.R0500_00_DECLARE_V1HISTOPARC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try 
            { /*4*/

                program.V0ENDO_DTINIVIG.Value = "2024-01-01";
                program.R0900_00_DECLARE_V1APOLCOSCED_DB_DECLARE_1(); 
                program.R0900_00_DECLARE_V1APOLCOSCED_DB_OPEN_1(); 
            } catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }

            try { /*5*/ program.R0800_00_SELECT_V0ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try 
            { /*6*/
                program.V1HISP_DTMOVTO.Value = "2024-01-01";
                program.R4100_00_DECLARE_V2HISTOPARC_DB_DECLARE_1(); 
                program.R4100_00_DECLARE_V2HISTOPARC_DB_OPEN_1(); 
            } catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }
            
            try { /*7*/ program.R1100_00_SELECT_V1ORDCOSCED_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1200_00_SELECT_V0COSSEGPROD_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1500_00_SELECT_V1PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1700_00_SELECT_V1PARC_COMPL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R2100_00_SELECT_V1PLANCOMIS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R2200_00_SUM_V0PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R2300_00_SUM_V0HISTOPARC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R2400_00_SUM_V0PARC_COMPL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R2700_00_INSERT_V0COSSEG_PREM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try 
            { /*16*/
                program.V0CHIS_DTMOVTO.Value = "2024-01-01";
                program.V0CHIS_DTQITBCO.Value = "2024-01-01";

                program.R2900_00_INSERT_V0COSSEG_HIST_DB_INSERT_1(); 
            } catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }
            
            try { /*17*/ program.R3100_00_SELECT_V0HISTOPARC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R3200_00_SELECT_V1COSSEG_PREM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R3300_00_SELECT_V0COSSEG_HISTP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R3600_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R4500_00_INSERT_V0COSSEG_PREM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try 
            { /*22*/
                program.V2CHIS_DTMOVTO.Value = "2024-01-01";
                program.V2CHIS_DTQITBCO.Value = "2024-01-01";
                program.R4700_00_INSERT_V0COSSEG_HPRE_DB_INSERT_1(); 
            } catch (Exception ex) 
            { 
                _.ThreatableTestError(ex); 
            }
            
            try { /*23*/ program.R4800_00_UPDATE_V0COSSEG_PREM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}