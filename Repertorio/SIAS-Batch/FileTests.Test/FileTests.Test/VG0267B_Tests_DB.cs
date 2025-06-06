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
using static Code.VG0267B;

namespace FileTests.Test_DB
{
    [Collection("VG0267B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]

    public class VG0267B_Tests_DB
    {
        private static string pData = "2023-03-03";

        [Fact]
        public static void VG0267B_Database()
        {
            var program = new VG0267B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0150_00_DECLARE_V1AGENCEF_DB_DECLARE_1(); program.R0150_00_DECLARE_V1AGENCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.WH_DATA_VENCIMENTO.Value = pData;
                program.V1SIST_DTMOVABE_30.Value = pData;
                program.R0300_00_DECLARE_V0HISTCOBVA_DB_DECLARE_1();
                program.R0300_00_DECLARE_V0HISTCOBVA_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*4*/
                program.V1SIST_DTMOVABE.Value = pData;
                program.R0400_00_CARREGA_V0FAIXACEP_DB_DECLARE_1();
                program.R0400_00_CARREGA_V0FAIXACEP_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/ program.R0350_00_SELECT_V0PRODUTOSVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.WHOST_NRTITCOMP.Value = 1;
                program.R2350_00_TRATA_PARCELAS_DB_DECLARE_1();
                program.R2350_00_TRATA_PARCELAS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1070_00_CONSULTA_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1200_00_SELECT_V0CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1300_00_SELECT_V0ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1500_00_SELECT_V1AGENCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1510_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*14*/
                program.WHOST_DATA1.Value = pData;
                program.R2200_00_PROCESSA_FAC_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R2340_00_SELECT_V0PARCELVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*17*/
                program.V0PARC_DTVENCTO_ORIG.Value = pData;
                program.R2450_00_SELECT_V0COBERPROPVA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*18*/ program.R2350_10_LOOP_V0HISTCOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R2600_00_UPDATE_V0HISTCOBVA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R2652_00_BUSCA_PARCELA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R2651_00_BUSCA_ESTIPULANTE_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R2652_00_BUSCA_PARCELA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R2652_00_BUSCA_PARCELA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*26*/
                program.V0COBP_DTINIVIG_PARC.Value = pData;
                program.R2655_00_CALCULA_INIVIGENCIA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*27*/ program.R2652_00_BUSCA_PARCELA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*28*/
                program.WS_DTINIVIG_PARC.Value = pData;
                program.WS_DTCALC_PARC.Value = pData;
                program.R2657_00_CALCULA_TERVIGENCIA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*29*/ program.R2800_00_SELECT_V0CEDENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R2910_00_OBTEM_NUMERACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R2910_10_INCLUI_RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R9100_00_INSERT_GEOBJECT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}