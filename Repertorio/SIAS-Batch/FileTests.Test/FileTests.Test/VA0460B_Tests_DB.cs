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
using static Code.VA0460B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("VA0460B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class VA0460B_Tests_DB
    {

        [Fact]
        public static void VA0460B_Database()
        {
            var program = new VA0460B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V0SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0150_00_SELECT_V0EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0300_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1(); program.R0300_00_DECLARE_V0HISTCOBVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R3700_00_DECLARE_V0RCAPCOMP_DB_DECLARE_1(); program.R3700_00_DECLARE_V0RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0380_00_SELECT_V0CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0400_00_SELECT_V0RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0420_00_SELECT_V0AGENCIACEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0440_00_SELECT_V0ESCNEG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0460_00_SELECT_V0FONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0500_00_SELECT_V0ENDERECOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0520_00_SELECT_V0DEVOLUCAOVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0530_00_SELECT_V0HISTCONTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0540_00_SELECT_V0USUARIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R0560_00_SELECT_V0PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R3600_00_UPDATE_V0RCAP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*16*/ 
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.Value = "2024-12-10";
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_HORA_OPERACAO.Value = "12:28:03";
                program.R3850_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*17*/ 
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_MOVIMENTO.Value = "2024-12-10";
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_RCAP.Value = "2024-12-10";
                program.RCAPCOMP.DCLRCAP_COMPLEMENTAR.RCAPCOMP_DATA_CADASTRAMENTO.Value = "2024-12-10";
                program.R3900_00_INSERT_V0RCAPCOMP_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R3950_00_UPDATE_V0RCAPCOMP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R4100_00_SELECT_V0AVISO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R4200_00_UPDATE_V0AVISO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try 
            { /*21*/
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Value = "2024-12-10";
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_INICIAL.Value = "2024-12-10";
                program.RELATORI.DCLRELATORIOS.RELATORI_PERI_FINAL.Value = "2024-12-10";
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = "2024-12-10";
                program.R5000_00_INSERT_V0RELATORIOS_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R5500_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}