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
using static Code.VG1613B;

namespace FileTests.Test_DB
{
    [Collection("VG1613B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VG1613B_Tests_DB
    {

        [Fact]
        public static void VG1613B_Database()
        {
            var program = new VG1613B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            var pData = "2000-01-01";
            try { /*1*/ program.R0080_00_LER_PARAMRAMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0100_00_SELECT_TSISTEMA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0120_00_SELECT_NUMEROUT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R2015_00_UPDATE_SEGURVGA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R2016_00_UPDATE_SEGURVGA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R2030_00_ACESSA_PLANOFAI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R2040_00_ACESSA_PLANFSAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R2050_00_ACESSA_PLANOVGA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R2055_00_ACESSA_PLANOVGA_DB_DECLARE_1(); program.R2055_00_ACESSA_PLANOVGA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.CLIENTES.DCLCLIENTES.CLIENTES_CGCCPF.Value = 0;
                program.SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_NUM_APOLICE.Value = 0;
                program.SUBGVGAP.DCLSUBGRUPOS_VGAP.SUBGVGAP_COD_SUBGRUPO.Value = 0;
                program.R2200_00_SELECT_SEGURVGA_DB_DECLARE_1(); 
                program.R2200_00_SELECT_SEGURVGA_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R2060_00_ACESSA_PLANOMUL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R2080_00_ACESSA_FAIXAETA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R2085_00_ACESSA_FAIXAETA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R2090_00_ACESSA_FAIXASAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R2095_00_ACESSA_FAIXA_SEMSAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R2160_00_SELECT_PRODUTOSVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R8000_00_DECLARE_SUBGVGAP_DB_DECLARE_1(); program.R8000_00_DECLARE_SUBGVGAP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R2400_00_SELECT_ERROSVID_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R2500_00_SELECT_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R2600_00_UPDATE_SEGURVGA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R2700_00_SELECT_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R2700_00_SELECT_PROPOSTA_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R2800_00_SELECT_COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R2900_00_COMPARA_VALOR_IS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R3205_00_SELECT_APOLICES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R3210_00_SELECT_SUBGVGAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R3215_00_SELECT_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R3220_00_SELECT_CONDITEC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R3230_00_SELECT_FONTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R3235_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R3240_00_UPDATE_FONTE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R3910_00_SELECT_SUBGVGAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/
                program.CLIENTES.DCLCLIENTES.CLIENTES_DATA_NASCIMENTO.Value = pData;
                program.R4200_10_GRAVA_CLIENTES_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R4210_00_MOVE_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R4220_00_TRATA_SEXO_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R4220_00_TRATA_SEXO_CLIENTE_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R4300_00_INSERT_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R4300_00_INSERT_ENDERECO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_OPERACAO.Value = pData;
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_AVERBACAO.Value = pData;
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_ADMISSAO.Value = pData;
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_INCLUSAO.Value = pData;
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_NASCIMENTO.Value = pData;
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_FATURA.Value = pData;
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_REFERENCIA.Value = pData;
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_DATA_MOVIMENTO.Value = pData;
                program.R4400_00_INSERT_MOVIMVGA_DB_INSERT_1();
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R6000_00_INSERE_RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R8200_00_UPDATE_NUMEROUT_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}