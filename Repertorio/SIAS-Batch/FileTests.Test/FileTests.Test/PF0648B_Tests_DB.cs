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
using static Code.PF0648B;

namespace FileTests.Test_DB
{
    [Collection("PF0648B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0648B_Tests_DB
    {

        [Fact]
        public static void PF0648B_Database()
        {
            var program = new PF0648B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0005_00_OBTER_DATA_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0020_00_OBTER_MAX_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0050_00_SELECIONA_MOVTO_DB_DECLARE_1(); program.R0050_00_SELECIONA_MOVTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*4*/
                program.FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO.Value = 1103;
                program.FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO.Value = 10026534336;
                program.R0570_00_LER_COMISSAO_DB_DECLARE_1();
                program.R0570_00_LER_COMISSAO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/ program.R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*6*/
                program.PROPFID.DCLPROPOSTA_FIDELIZ.NUM_SICOB.Value = 80000000025;
                program.R0210_00_LER_SICOB_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/ program.R0250_00_LER_PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0300_00_LER_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0350_00_LER_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0410_00_LER_CBO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0550_00_LER_OPCAOPAGVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0710_00_OBTER_DATA_CREDITO_DB_DECLARE_1(); program.R0710_00_OBTER_DATA_CREDITO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R0610_00_SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R0620_00_DADOS_RG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R0750_00_OBTER_DADOS_LANC_DB_DECLARE_1(); program.R0750_00_OBTER_DADOS_LANC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R0720_00_OBTER_DADOS_LANC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*18*/
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2020-01-01";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2020-01-01";
                program.R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*19*/ program.R0740_00_UPDATE_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try
            { /*20*/
                program.PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO.Value = "2020-01-01";
                program.PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO.Value = "2020-01-01";
                program.R0730_ATUALIZA_FIDELIZACAO_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}