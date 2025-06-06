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
using static Code.CB0110B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("CB0110B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class CB0110B_Tests_DB
    {

        [Fact]
        public static void CB0110B_Database()
        {
            var program = new CB0110B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.Execute_DB_DECLARE_1(); program.P20000_00_PRINCIPAL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.P10000_00_INICIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.P10100_00_SELECT_CHEQUEMI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.P10200_00_SELECT_CBCONDEV_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/ program.P22000_00_TRATA_REGISTRO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.P22100_00_SELECT_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.P22200_00_SELECT_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.P22310_00_SELECT_GE381_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.P22320_00_SELECT_AGENCCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.P22352_00_SELECT_CB040_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_CANCELAMENTO.Value = "2020-01-01";                
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_OCORRENCIA.Value = "2020-01-01";
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_MOVIMENTO.Value = "2020-01-01";
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_DATA_QUITACAO.Value = "2020-01-01";
                //hora
                program.CBCONDEV.DCLCB_CONTR_DEVPREMIO.CBCONDEV_HORA_OPERACAO.Value = "10:02:02";
                program.P22354_00_INCLUI_CBCONDEV_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/
                program.CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_MOVIMENTO.Value = "2020-01-01";
                program.CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_EMISSAO.Value = "2020-01-01";
                program.CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_COMPETENCIA.Value = "2020-01-01";
                program.CHEQUEMI.DCLCHEQUES_EMITIDOS.CHEQUEMI_DATA_LANCAMENTO.Value = "2020-01-01";
                program.P22362_00_INCLUI_CHEQUEMI_DB_INSERT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*13*/
                program.HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DATA_MOVIMENTO.Value = "2020-01-01";
                program.HISTOCHE.DCLHISTORICO_CHEQUES.HISTOCHE_DATA_COMPENSACAO.Value = "2020-01-01";
                program.P22363_00_INCLUI_HISTOCHE_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*14*/
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_LIBERACAO.Value = "2020-01-01";
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_DATA_MOVIMENTO.Value = "2020-01-01";
                //hora
                program.FOLLOUP.DCLFOLLOW_UP.FOLLOUP_HORA_OPERACAO.Value = "10:02:02";
                program.P22400_00_ATUALIZACOES_DB_UPDATE_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/ program.P22400_00_ATUALIZACOES_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.P22400_00_ATUALIZACOES_DB_UPDATE_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}