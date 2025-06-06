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
using static Code.SI0133B;

namespace FileTests.Test_DB
{
    [Collection("SI0133B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class SI0133B_Tests_DB
    {

        [Fact]
        public static void SI0133B_Database()
        {
            var program = new SI0133B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try
            { /*1*/
                program.M_015_000_CABECALHOS_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.M_060_000_LER_TSISTEMA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.M_090_000_CURSOR_TRELSIN_JOIN_E_DB_DECLARE_1();
                program.M_090_000_CURSOR_TRELSIN_JOIN_E_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.M_140_000_BENEFICIARIOS_DB_DECLARE_1();
                program.M_140_000_BENEFICIARIOS_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.M_125_000_CREDITO_HABITACIONAL_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.M_126_000_PELA_V0SINI_ITEM_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.M_127_000_SELECT_V0AGENCIACEF_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.M_129_000_ACESSA_PRODUTO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.M_134_000_REATIVACAO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.M_135_000_CANCELAMENTO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.M_170_000_CURSOR_THISTSIN_DB_DECLARE_1();
                program.M_170_000_CURSOR_THISTSIN_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.M_182_000_CURSOR_FAVOREC_DB_DECLARE_1();
                program.M_182_000_CURSOR_FAVOREC_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*14*/
                program.M_187_000_ULT_MOVIMENTACAO_DB_DECLARE_1();
                program.M_187_000_ULT_MOVIMENTACAO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.M_186_000_ACESSA_PROC_JURID_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.M_300_000_CURSOR_TAPDCORR_DB_DECLARE_1();
                program.M_300_000_CURSOR_TAPDCORR_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*17*/
                program.M_190_000_ACESSA_AVISO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.M_200_000_ACESSA_OPERACAO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*19*/
                program.M_220_200_ACESSA_TGEFONTE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*20*/
                program.M_230_200_ACESSA_TGERAMO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*21*/
                program.M_240_000_LER_TAPOLICE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*22*/
                program.MEST_DATORR.Value = fullDataMock;


                program.M_241_000_LER_APOLCOSCED_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*23*/
                program.M_270_000_LER_TENDOSSO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*24*/
                program.M_400_000_CURSOR_THISTSIN_RESERV_DB_DECLARE_1();
                program.M_400_000_CURSOR_THISTSIN_RESERV_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*25*/
                program.M_360_200_ACESSA_PRODUTOR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*26*/
                program.M_390_200_ACESSA_TCAUSA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*27*/
                program.M_391_003_LER_TCAUSA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*28*/
                program.M_420_000_CURSOR_TPARCELA_DB_DECLARE_1();
                program.M_420_000_CURSOR_TPARCELA_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*29*/
                program.M_480_000_LER_THISTPAR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*30*/
                program.M_500_000_LER_FORNECEDOR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*31*/
                program.M_510_FOLHA_SEPARADORA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            {
                /*32*/
                program.WGEUNIMO_DTINIVIG.Value = fullDataMock;
                program.WGEUNIMO_DTTERVIG.Value = fullDataMock;

                program.M_610_000_LER_TGEUNIMO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}