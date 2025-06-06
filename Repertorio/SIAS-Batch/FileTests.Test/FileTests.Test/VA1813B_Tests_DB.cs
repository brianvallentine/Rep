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
using static Code.VA1813B;

namespace FileTests.Test_DB
{
    [Collection("VA1813B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VA1813B_Tests_DB
    {
        private static string pData = "2023-01-01";

        [Fact]
        public static void VA1813B_Database()
        {
            var program = new VA1813B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0020_00_PROCESSA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0020_00_PROCESSA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0020_00_PROCESSA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0020_00_PROCESSA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0023_00_ATUALIZA_ESTORNO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0030_00_ACESSO_CERTIF_DB_DECLARE_1(); program.R0030_00_ACESSO_CERTIF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/
                program.WHOST_CODCONV.Value = 0;
                program.R0035_00_ACESSO_NUMCTADEB_DB_DECLARE_1(); 
                program.R0035_00_ACESSO_NUMCTADEB_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/ program.R0036_00_ACESSO_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0050_00_GERA_FITACEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/
                program.V0FTCF_DTRET2.Value = pData;
                program.R0053_00_UPDATE_FITACEF_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*13*/ program.R0055_00_INSERT_FITACEF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.V0PARC_DTVENCTO.Value = pData;
                program.R1000_00_QUITA_PARCELA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/
                program.V0HCOB_DTVENCTO.Value = pData;
                program.R1000_00_QUITA_PARCELA_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*16*/ program.R1000_00_QUITA_PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1000_00_QUITA_PARCELA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1000_00_QUITA_PARCELA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/
                program.V0PARC_DTVENCTO.Value = pData;
                program.R1050_00_LOOP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1050_00_LOOP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1000_00_QUITA_PARCELA_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R1000_00_QUITA_PARCELA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R1000_00_QUITA_PARCELA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1000_00_QUITA_PARCELA_DB_UPDATE_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ 
                program.V0RCDG_DTREFER.Value = pData;
                program.R1099_00_INCLUI_CDG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R1000_00_QUITA_PARCELA_DB_UPDATE_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R1000_00_QUITA_PARCELA_DB_UPDATE_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R1100_00_REPASSA_CDG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ 
                program.V0SIST_DTMOVABE.Value = pData;
                program.R1100_00_REPASSA_CDG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R1000_00_QUITA_PARCELA_DB_UPDATE_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ 
                program.V0RSAF_DTREFER.Value = pData;
                program.R1199_00_INCLUI_SAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R1199_00_INCLUI_SAF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R1199_00_INCLUI_SAF_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R1200_00_REPASSA_SAF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R1200_00_REPASSA_SAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R2000_00_REJEITA_PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R2000_00_REJEITA_PARCELA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/
                program.V0HCOB_DTALTOPC.Value = pData; 
                program.R2100_00_MUDA_OPCAOPAG_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/
                
                program.R2100_00_MUDA_OPCAOPAG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R2000_00_REJEITA_PARCELA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R2000_00_REJEITA_PARCELA_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R8800_00_UPDATE_FOLLOWUP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R2000_00_REJEITA_PARCELA_DB_UPDATE_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R2000_00_REJEITA_PARCELA_DB_UPDATE_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}