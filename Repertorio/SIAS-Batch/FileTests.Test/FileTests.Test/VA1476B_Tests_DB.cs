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
using static Code.VA1476B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("VA1476B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package03)]
    public class VA1476B_Tests_DB
    {

        [Fact]
        public static void VA1476B_Database()
        {
            var program = new VA1476B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0200_00_SELECT_RELATORI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*3*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0300_00_UPDATE_RELATORI_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*4*/
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = "2020-01-01";
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0900_00_DECLARE_MOVDIARIO_DB_DECLARE_1(); program.R0900_00_DECLARE_MOVDIARIO_DB_OPEN_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*5*/
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.Value = 123456;
                program.R1010_00_SELECT_PROPOVA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*6*/
                program.SISTEMAS_DATA_MOV_ABERTO_30.Value = "2020-01-01";
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.Value = 1;
                program.R1020_00_SELECT_PROPOVA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*7*/
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_OCORR_ENDERECO.Value = 1;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.Value = 1;
                program.R1030_00_SELECT_GECLIMOV_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*8*/
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.Value = 123;
                program.R1040_00_SELECT_BILHETE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*9*/
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_COD_SUBGRUPO.Value = 123;
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_APOLICE.Value = 123;
                program.R1050_00_SEL_VGCOBSUB_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*10*/
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.Value = 123;
                program.R1060_00_SELECT_SEGURVGA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*11*/
                program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_COD_SUBGRUPO.Value = 1;
                program.PRODUVG.DCLPRODUTOS_VG.PRODUVG_NUM_APOLICE.Value = 123456;
                program.R1070_00_SELECT_PRODUVG_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*12*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.Value = 123;
                program.R1100_00_SELECT_CLIENTE_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*13*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_COD_CLIENTE.Value = 123;
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_OCOREND.Value = 123;
                program.R1200_00_SELECT_ENDERECO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*14*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 123;
                program.R1300_00_SELECT_SEGURVGA_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*15*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_APOLICE.Value = 123456;
                program.R1400_00_SELECT_ENDOSSO_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*16*/
                program.PROPOVA.DCLPROPOSTAS_VA.PROPOVA_NUM_CERTIFICADO.Value = 123;
                program.R1500_00_SELECT_PROPOFID_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*17*/
                program.MOVIMVGA.DCLMOVIMENTO_VGAP.MOVIMVGA_NUM_CERTIFICADO.Value = 123;
                program.VGCOBSUB.DCLVG_COBERTURAS_SUBG.VGCOBSUB_COD_COBERTURA.Value = 123;
                program.R1600_SELECT_NOVA_ASSIST_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*18*/
                program.R5200_00_SELECT_PARAM_DB_SELECT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*19*/
                program.R5300_00_UPDATE_PARAM_DB_UPDATE_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }
            try
            { /*20*/
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PRODUTO.Value = 4000;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_CLIENTE.Value = 0;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_PROGRAMA.Value = "VA1476B";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_TIPO_SOLICITACAO.Value = 123;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_SOLICITACAO.Value = "2020-01-01";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_COD_USUARIO.Value = "123";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_DATA_PREV_PROC.Value = "2020-01-01";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_SIT_SOLICITACAO.Value = "0";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE01.Value = "9999-12-31";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE02.Value = "9999-12-31";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DATE03.Value = "9999-12-31";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT01.Value = 01;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT02.Value = 0;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_SMINT03.Value = 0;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG01.Value = 0;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG02.Value = 0;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_INTG03.Value = 0;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC01.Value = 0;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC02.Value = 0;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_DEC03.Value = 0;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT01.Value = 0;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_FLOAT02.Value = 0;
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR01.Value = "0";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR02.Value = "0";
                program.LTSOLPAR.DCLLT_SOLICITA_PARAM.LTSOLPAR_PARAM_CHAR03.Value = "0";
                program.R5600_00_INSERT_LT_SOLICITA_DB_INSERT_1();
            }
            catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}