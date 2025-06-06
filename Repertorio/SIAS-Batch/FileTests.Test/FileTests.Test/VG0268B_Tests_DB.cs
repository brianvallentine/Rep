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
using static Code.VG0268B;

namespace FileTests.Test_DB
{
    [Collection("VG0268B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0268B_Tests_DB
    {

        [Fact]
        public static void VG0268B_Database()
        {
            var program = new VG0268B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_CARREGA_V0FAIXACEP_DB_DECLARE_1(); program.R0200_00_CARREGA_V0FAIXACEP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0500_00_DECLARE_V1AGENCEF_DB_DECLARE_1(); program.R0500_00_DECLARE_V1AGENCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0900_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1(); program.R0900_00_DECLARE_V0HISTCOBVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1200_00_SELECT_V0CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1300_00_SELECT_V0ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1500_00_SELECT_V1AGENCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*9*/
                program.WHOST_DATA1.Value = "2025-01-30";
                program.R2210_00_MONTA_DETALHE_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R2210_00_MONTA_DETALHE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R2340_00_SELECT_V0PARCELVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*12*/ 
                program.V0PARC_DTVENCTO_ORIG.Value = "2025-01-30";
                program.R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R2460_00_SELECT_V0COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R2652_00_BUSCA_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R2652_00_BUSCA_PARCELA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R2652_00_BUSCA_PARCELA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R2700_00_SELECT_V0PRODUTOSVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*22*/
                program.V0COBP_DTINIVIG_PARC.Value = "2025-01-30";
                program.R2652_00_BUSCA_PARCELA_DB_SELECT_4(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R2652_00_BUSCA_PARCELA_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R2710_00_SELECT_V0PRODUTOSVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R2800_00_SELECT_V0CEDENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R2910_00_OBTEM_NUMERACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R2910_10_INCLUI_RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*28*/
                program.CALENDAR.DCLCALENDARIO.CALENDAR_DATA_CALENDARIO.Value = "2025-01-30";
                program.AREA_DE_WORK.WHOST_PROXIMA_DATA.Value = "2025-01-30";
                program.R2930_00_CALCULA_DIA_UTIL_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R4000_00_GRAVA_OBJETO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R4000_02_INSERT_OBJETO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}