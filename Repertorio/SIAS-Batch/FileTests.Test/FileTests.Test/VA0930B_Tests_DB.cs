using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;
using Xunit;
using Dclgens;
using Code;
using static Code.VA0930B;

namespace FileTests.Test_DB
{
    [Collection("VA0930B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]
    public class VA0930B_Tests_DB
    {

        [Fact]
        public static void VA0930B_Database()
        {
            var program = new VA0930B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var fullDataMock = DateTime.Now.AddDays(-100).ToString("yyyy-MM-dd");

            try { /*1*/ program.R0100_00_SELECT_V1SISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0900_00_DECLARE_V0RELATORIO_DB_DECLARE_1(); program.R0900_00_DECLARE_V0RELATORIO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R1020_00_SELECT_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R1030_00_SELECT_CERTIFICADO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R1030_00_SELECT_CERTIFICADO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R1040_00_SELECT_PRODUTOSVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R1030_00_SELECT_CERTIFICADO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R1040_00_SELECT_PRODUTOSVG_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1050_00_SELECT_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1060_00_SELECT_USUARIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1080_SELECT_NRCERTIF_APOL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R1080_SELECT_NRCERTIF_APOL_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1102_00_VERIFICA_CAMPOS_CB58A_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_SOLICITACAO.Value = fullDataMock;

                program.R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1104_00_VERIFICA_CONJUGUE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1103_00_VERIFICA_RESTITUICAO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1104_00_VERIFICA_CONJUGUE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R1104_00_VERIFICA_CONJUGUE_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R1105_00_VERIFICA_CANCELAMENTO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R1106_00_BUSCA_DADOS_VLN9A_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R1108_00_VERIFICA_CAPITAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R1109_00_RECUPERA_NOVO_CERT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R1110_00_RECUPERA_DADOS_REST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R1112_00_RECUPERA_PROPOSTAS_VA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R1113_00_BUSCA_ENDERECO_TELE_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}