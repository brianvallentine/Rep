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
using static Code.VF0118B;

namespace FileTests.Test_DB
{
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    [Collection("VF0118B_Tests_DB")]
    public class VF0118B_Tests_DB
    {

        [Fact]
        public static void VF0118B_Database()
        {
            var program = new VF0118B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.M_0000_PRINCIPAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.M_0000_PRINCIPAL_DB_DECLARE_1(); program.M_0000_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.M_2200_MONTA_BENEFICIARIOS_DB_DECLARE_1(); program.M_2200_MONTA_BENEFICIARIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.M_0000_PRINCIPAL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.M_0000_PRINCIPAL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.M_0100_PROCESSA_PROPOSTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.M_0100_PROCESSA_PROPOSTA_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.M_1000_INTEGRA_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.M_1000_AJUSTA_DTPROXVEN_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.M_1000_AJUSTA_DTPROXVEN_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.M_1100_GERA_1A_PARCELA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.M_1100_GERA_1A_PARCELA_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.M_1100_GERA_1A_PARCELA_DB_INSERT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.M_1200_ATUALIZA_1A_PARCELA_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.M_1300_GERA_AJUSTE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.M_1400_CONTABILIZA_PREMIO_PAGO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.M_2000_INTEGRA_VG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.M_2000_INTEGRA_VG_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.M_2100_CALC_PROP_AUTOM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.M_2100_CALC_PROP_AUTOM_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.M_2000_INTEGRA_VG_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.M_2000_INTEGRA_VG_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.M_2000_INTEGRA_VG_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.M_2400_GERA_EVENTO_DB_DECLARE_1(); program.M_2400_GERA_EVENTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.M_2200_LOOP_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.M_2300_CONCEDE_SAF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.M_2300_CONCEDE_SAF_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.M_2310_ELIMINA_SAF_DB_DELETE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.M_2320_INCLUI_SAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.M_2330_INCLUI_REPASSE_SAF_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.M_2330_INCLUI_REPASSE_SAF_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.M_2420_GERA_EVENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.M_2420_GERA_EVENTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.M_2420_GERA_EVENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.M_8700_GERA_DEBITO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}