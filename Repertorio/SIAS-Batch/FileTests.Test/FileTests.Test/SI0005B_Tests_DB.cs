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
using static Code.SI0005B;

namespace FileTests.Test_DB
{
    [Collection("SI0005B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class SI0005B_Tests_DB
    {

        [Fact]
        public static void SI0005B_Database()
        {
            var program = new SI0005B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            program.HOST_DATA_GERACAO.Value = "2000-10-10";
            program.HOST_DATA_OCORRENCIA.Value = "2000-10-10";
            program.HOST_DATA_AVISO.Value = "2000-10-10";
            program.HOST_DATA_ULTIMO_DOC.Value = "2000-10-10";
            program.HOST_HORA_OCORRENCIA.Value = "20:20:20";
            program.HOST_DATA_AVISO.Value = "2000-10-10";
            program.SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_HORA_OPERACAO.Value = "20:20:20";
            program.SINISACO.DCLSINISTRO_ACOMPANHA.SINISACO_DATA_OPERACAO.Value = "2000-10-10";
            program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_ULT_MOVIMENTO.Value = "2000-10-10";
            program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_TECNICA.Value = "2000-10-10";
            program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_OCORRENCIA.Value = "2000-10-10";
            program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_DATA_COMUNICADO.Value = "2000-10-10";

            program.SINILT01.DCLSINI_LOTERICO01.SINILT01_DATA_GERA_MOV.Value = "2000-10-10";
            program.SINILT01.DCLSINI_LOTERICO01.SINILT01_DTINIVIG.Value = "2000-10-10";

            program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_NEGOCIADA.Value = "2000-10-10";
            program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_LIM_CORRECAO.Value = "2000-10-10";
            program.SINISHIS.DCLSINISTRO_HISTORICO.SINISHIS_DATA_MOVIMENTO.Value = "2000-10-10";

            program.SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_GERACAO_MOV.Value = "2000-10-10";
            program.SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_ULT_DOC.Value = "2000-10-10";
            program.SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_MOVIMENTO.Value = "2000-10-10";
            program.SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_HORA_AVISO.Value = "20:20:20";
            program.SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_AVISO.Value = "2000-10-10";
            program.SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_HORA_OCORRENCIA.Value = "20:20:20";
            program.SIMOLOT1.DCLSI_MOV_LOTERICO1.SIMOLOT1_DATA_OCORRENCIA.Value = "2000-10-10";

            program.SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_DATA_RECEBE.Value = "2000-10-10";
            program.SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_DATA_SOLICITA.Value = "2000-10-10";
            program.SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_TMSP_MOV_SOLICITA.Value = "2000-10-10 10:10:10.100";
            program.SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_TMSP_MOV_RECEBE.Value = "2000-10-10 10:10:10.100";
            program.SINLOTDO.DCLSINI_LOT_DOC01.SINLOTDO_TMSP_MOV_SITUACAO.Value = "2000-10-10 10:10:10.100";

            try { /*1*/ program.R010_LE_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R020_LE_MONTA_NOME_EMPRESA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R030_SELECT_FONTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R035_SELECT_NUMERO_AES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R050_ALTERA_FONTES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R055_ALTERA_NUMERO_AES_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R105_ROTINA_CRITICA_HEADER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R110_ROTINA_CRITICA_DADOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R110_ROTINA_CRITICA_DADOS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R111_VERIFICA_PGTO_PREMIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R110_ROTINA_CRITICA_DADOS_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R111_VERIFICA_PGTO_PREMIO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R111_VERIFICA_PGTO_PREMIO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R110_ROTINA_CRITICA_DADOS_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R111_VERIFICA_PGTO_PREMIO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R110_ROTINA_CRITICA_DADOS_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R112_BUSCA_DATA_CANCELAMENTO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R110_ROTINA_CRITICA_DADOS_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R500_CRITICA_APOL_ADMINIST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R110_ROTINA_CRITICA_DADOS_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R110_ROTINA_CRITICA_DADOS_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R700_CRITICA_APOL_POR_LOT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R110_ROTINA_CRITICA_DADOS_DB_SELECT_9(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R700_CRITICA_APOL_POR_LOT_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R110_ROTINA_CRITICA_DADOS_DB_SELECT_10(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R110_ROTINA_CRITICA_DADOS_DB_SELECT_11(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R710_CONSULTA_PRAZO_CURTO_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R710_CONSULTA_PRAZO_CURTO_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R750_ACHA_VALOR_BASE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R710_CONSULTA_PRAZO_CURTO_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R8000_DECLARE_SINISTROS_APOL_DB_DECLARE_1(); program.R8000_DECLARE_SINISTROS_APOL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R1090_INCLUI_DOC01_DB_DECLARE_1(); program.R1090_INCLUI_DOC01_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R8100_INDENIZ_EFETIVADAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R8101_BUSCA_FRANQUIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R8150_EST_INDENIZ_EFETIVADAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R8002_BUSCA_ADIANTAMENTOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R9001_LE_PERCETUAL_ADIANTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R1000_GRAVA_SINISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R1000_GRAVA_SINISTRO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R130_IMPRIME_GERA_AVISO_OK_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R1010_INCLUI_SINISCON_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R1020_INCLUI_SINISACO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.R1030_INCLUI_SINISMES_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/ program.R1040_INCLUI_SILOTER1_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.R1050_INCLUI_SINIITEM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/ program.R1070_INCLUI_SINISHIS_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.R1080_INCLUI_SIMOLOT1_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.R1080_INCLUI_SIMOLOT1_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.R1080_INCLUI_SIMOLOT1_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/ program.R2010_DECLARE_ADIANT_PENDENTES_DB_DECLARE_1(); program.R2010_DECLARE_ADIANT_PENDENTES_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*55*/ program.R1090_LE_NOVAMENTE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*56*/ program.R7019_00_BUSCAR_COD_SOCIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*57*/ program.R7020_00_BUSCAR_DADOS_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}