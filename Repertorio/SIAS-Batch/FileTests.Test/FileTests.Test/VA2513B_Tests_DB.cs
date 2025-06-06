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
using static Code.VA2513B;

namespace FileTests.Test_DB
{
    [Collection("VA2513B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA2513B_Tests_DB
    {

        [Fact]
        public static void VA2513B_Database()
        {
            var program = new VA2513B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*2*/
                program.V1SIST_DTMOVABE.Value = "2020-01-01";
                program.R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1(); 
                program.R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/ program.R0300_00_CARREGA_V0MSGCOBR_DB_DECLARE_1(); program.R0300_00_CARREGA_V0MSGCOBR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1(); program.R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1(); program.R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*6*/
                program.V0CLIE_DTNASC.Value = "2020-01-01";
                program.R1200_00_SELECT_V0CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*7*/ program.R1210_00_SELECT_V0SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1300_00_SELECT_V0ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1500_00_SELECT_V1AGENCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R2610_00_SELECT_V0MULTIMENS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R2750_00_SELECT_V0CONDTEC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/
                program.V0COBE_DTINIVIG.Value = "2020-01-04";
                program.R2800_00_SELECT_V0COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*13*/ program.R2850_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R2910_00_OBTEM_NUMERACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/
                program.V1SIST_DTMOVABE.Value = "2020-01-04";
                program.R2910_10_INCLUI_RELATORIO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*16*/ 
                program.AREA_DE_WORK.WHOST_PROXIMA_DATA.Value = "2020-01-04";
                program.R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R2950_00_SELECT_V0PRODUTOSVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}