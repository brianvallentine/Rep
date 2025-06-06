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
using static Code.SI0853B;

namespace FileTests.Test_DB
{
    [Collection("SI0853B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package04)]

    public class SI0853B_Tests_DB
    {

        [Fact]
        public static void SI0853B_Database()
        {
            var program = new SI0853B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try
            { /*1*/
                program.R0010_SELECT_SISTEMA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*2*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0020_DECLARE_SINISTROS_NOVAPT_DB_DECLARE_1(); program.R0020_DECLARE_SINISTROS_NOVAPT_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0040_DECLARE_SINISTROS_PPPT_DB_DECLARE_1(); program.R0040_DECLARE_SINISTROS_PPPT_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0060_DECLARE_SINISTROS_PTPP_DB_DECLARE_1(); program.R0060_DECLARE_SINISTROS_PTPP_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_CLIENTE.Value = 1;
                program.R1000_SELECT_CLIENTE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_FABRICANTE.Value = 1;
                program.APOLIAUT.DCLAPOLICE_AUTO.APOLIAUT_COD_VEICULO.Value = 1;
                program.VEICUDES.DCLVEICULOS_DESCRICAO.VEICUDES_VERSAO.Value = 1;
                program.R1100_SELECT_VEICULO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_APOLICE.Value = 1;
                program.ENDOSSOS.DCLENDOSSOS.ENDOSSOS_NUM_ENDOSSO.Value = 1;
                program.R1200_SELECT_ENDOSSO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 1;
                program.R2000_CAUSA_ANTERIOR_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.SINISMES.DCLSINISTRO_MESTRE.SINISMES_NUM_APOL_SINISTRO.Value = 123456;
                program.SINIMPSE.DCLSINISTRO_IMP_SEG.SINIMPSE_OCORR_HISTORICO.Value = 123;
                program.R2000_CAUSA_ANTERIOR_DB_SELECT_2();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}