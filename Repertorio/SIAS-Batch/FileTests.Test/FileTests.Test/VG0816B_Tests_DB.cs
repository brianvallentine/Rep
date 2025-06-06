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
using static Code.VG0816B;

namespace FileTests.Test_DB
{
    [Collection("VG0816B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG0816B_Tests_DB
    {

        [Fact]
        public static void VG0816B_Database()
        {
            var program = new VG0816B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0160_00_DECLARE_MOVIMCOB_DB_DECLARE_1(); program.R0160_00_DECLARE_MOVIMCOB_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/

                program.WHOST_DTVENCTO1.Value = "2000-10-10";

                program.R0600_00_DECLARE_VGRAMOCOMP_DB_DECLARE_1(); program.R0600_00_DECLARE_VGRAMOCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0200_00_SELECT_V0HISTCOBVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0210_00_SELECT_GE403_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0220_00_SELECT_MOVDEBCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0240_00_SELECT_COBHISVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/

                program.V0MOVC_DTMOVTO.Value  = "2000-10-10";
                program.V0MOVC_DTQITBCO.Value = "2000-10-10";
                program.V0FOLL_DTLIBER.Value  = "2000-10-10";
                program.V0FOLL_HORAOPER.Value = "10:10:10";

                program.R0310_00_INSERT_V0FOLLOWUP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0320_00_UPDATE_V0MOVIMCOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0400_00_SELECT_V0PROPOVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0420_00_SELECT_V0PARCELVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0440_00_SELECT_V0COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0450_00_SELECT_V0COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R0460_00_SELECT_V0OPCAOPAGVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R0510_00_INSERT_HISTCONTABIL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R0560_00_SELECT_V0CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1040_REPASSA_ATRASO_DB_DECLARE_1(); program.R1040_REPASSA_ATRASO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R0760_00_LEITURA_VGCOBSUB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R0770_00_SELECT_CONDITEC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R0800_00_INSERT_VGHISTCONT_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1000_00_PROCESSA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R1000_00_PROCESSA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R1000_00_PROCESSA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1000_00_PROCESSA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/
                //foreign key
                program.V0RCDG_DTREFER.Value = "2000-10-10";

                program.R1020_00_INCLUI_CDG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R1000_00_PROCESSA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R1000_00_PROCESSA_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R1040_00_REPASSA_CDG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R1040_00_REPASSA_CDG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R1140_REPASSA_ATRASO_DB_DECLARE_1(); program.R1140_REPASSA_ATRASO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R1060_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R1060_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/
                //Foreign Key
                program.V0RSAF_DTREFER.Value = "2000-10-10";

                program.R1120_00_INCLUI_SAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R1120_00_INCLUI_SAF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R1120_00_INCLUI_SAF_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R1140_00_REPASSA_SAF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R1140_00_REPASSA_SAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R1250_00_BAIXA_DO_FEDERAL_DB_DECLARE_1(); program.R1250_00_BAIXA_DO_FEDERAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R1160_00_PROCESSA_V0DIFPARCEL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R1160_00_PROCESSA_V0DIFPARCEL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R1210_50_LOOP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R1230_00_BAIXA_DO_MULTI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R1230_00_BAIXA_DO_MULTI_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R1280_00_PROC_COMPOSICAO_DB_DECLARE_1(); program.R1280_00_PROC_COMPOSICAO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R1230_00_BAIXA_DO_MULTI_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R1230_00_BAIXA_DO_MULTI_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.R1280_00_PROC_COMPOSICAO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.R1280_00_PROC_COMPOSICAO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.R1300_00_GERA_EVENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.R1300_50_LOOP_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.R1300_50_LOOP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.R1320_00_AJUSTA_VIGENCIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.R1320_00_AJUSTA_VIGENCIA_DB_UPDATE_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}