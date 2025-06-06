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
using static Code.VG0656B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("VG0656B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.Skip)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VG0656B_Tests_DB
    {

        [Fact]
        public static void VG0656B_Database()
        {
            var program = new VG0656B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
          
            try { /*2*/
                program.WHOST_DT_INICIO.Value = "2001-07-31";
                program.WHOST_DT_FIM.Value = "2005-07-31";
                program.R0900_00_DECLARE_PROPOVA_DB_DECLARE_1(); program.R0900_00_DECLARE_PROPOVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*3*/
                program.CLIENTES.DCLCLIENTES.CLIENTES_COD_CLIENTE.Value = 1;
                program.R2500_00_SELECT_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/ 
                program.REG_ARQSORT1.SVA_NUM_CERTIFICADO.Value = 211523067;
                program.R2600_00_SELECT_HISCOBPR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*5*/
                  program.AGENCCEF.DCLAGENCIAS_CEF.AGENCCEF_COD_AGENCIA.Value = 1014;
                  program.R2700_00_SELECT_AGENCCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*6*/
                program.WHOST_CODSUBES.Value = 93010000890;
                program.WHOST_APOLICE.Value = 1;
                program.R2800_00_SELECT_PRODUVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*7*/
                  program.OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_NUM_CERTIFICADO.Value = 100000266;
                  program.R2900_BUSCA_DADOS_OPCAO_PAGTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*8*/
                 program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 0;
                 program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_SUBGRUPO.Value = 0;
                 program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.Value = 0;
                 program.R2910_BUSCA_NUM_CHEQUE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*9*/
                program.COBHISVI.DCLCOBER_HIST_VIDAZUL.COBHISVI_NUM_CERTIFICADO.Value = 8464327696;
                 program.R2920_BUSCA_MOTIVO_CANCEL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*10*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 10026443843;
                program.ERRPROVI.DCLERROS_PROP_VIDAZUL.ERRPROVI_COD_ERRO.Value = 1501;
                program.R2921_00_SELECT_ERRPROVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 10026443843;
                 program.R2922_00_SELECT_ERRPROVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/
                 program.FONTES.DCLFONTES.FONTES_COD_FONTE.Value = 1;
                 program.R3050_00_SELECT_FONTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}