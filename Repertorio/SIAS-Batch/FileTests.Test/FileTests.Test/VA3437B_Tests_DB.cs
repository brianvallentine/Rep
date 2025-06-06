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
using static Code.VA3437B;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace FileTests.Test_DB
{
    [Collection("VA3437B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package02)]
    public class VA3437B_Tests_DB
    {

        [Fact]
        public static void VA3437B_Database()
        {
            var program = new VA3437B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;

            var pdata = "2020-01-01";
            program.LK_PARAMETROS.LK_DT_PROCESSAMENTO.Value = pdata;

            program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2001-01-01";
            program.SISTEMAS_DATA_MOV_ABERTO_15D.Value = pdata;
            program.RELATORI.DCLRELATORIOS.RELATORI_TIMESTAMP.Value = "2011-05-03 16:39:15.532";
            program.WHOST_DTQUIT.Value = pdata;

            try { /*1*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0100_00_SELECT_SISTEMAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0200_00_CARREGA_FAIXACEP_DB_DECLARE_1(); program.R0200_00_CARREGA_FAIXACEP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }            
            try { /*4*/ program.R0300_00_CARREGA_COBMENVG_DB_DECLARE_1(); program.R0300_00_CARREGA_COBMENVG_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0400_00_CARREGA_FCPLANO_DB_DECLARE_1(); program.R0400_00_CARREGA_FCPLANO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0500_00_DECLARE_AGENCCEF_DB_DECLARE_1(); program.R0500_00_DECLARE_AGENCCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*7*/
                program.SISTEMAS_DATA_MOV_ABERTO_15D.Value = "2024-07-04";
                program.R0900_00_DECLARE_RELATORI_DB_DECLARE_1(); 
                program.R0900_00_DECLARE_RELATORI_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*8*/ program.R1120_00_DECLARE_TITFEDCA_DB_DECLARE_1(); program.R1120_00_DECLARE_TITFEDCA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R1000_00_PROCESSA_INPUT_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R1010_00_SELECT_SEGURVGA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R1100_00_SELECT_OPCPAGVI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R2210_00_IMP_CAPITAIS_DB_DECLARE_1(); program.R2210_00_IMP_CAPITAIS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R1145_00_SELECT_PROC_SUSEP_CAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R1200_00_SELECT_CLIENTES_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R1210_00_SELECT_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R1300_00_SELECT_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R1400_00_SELECT_HISCOBPR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R1500_00_SELECT_AGENCCEF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R1600_00_SELECT_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R1640_00_SELECT_ENDOSSOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R1800_00_SELECT_CONDITEC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R2200_00_PROCESSA_FAC_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R2200_00_PROCESSA_FAC_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R2200_00_PROCESSA_FAC_DB_SELECT_3(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R2200_00_PROCESSA_FAC_DB_SELECT_4(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R2205_00_SELECT_USUARIOS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R2200_00_PROCESSA_FAC_DB_SELECT_5(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R2200_00_PROCESSA_FAC_DB_SELECT_6(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R2400_00_BENEFICIARIOS_DB_DECLARE_1(); program.R2400_00_BENEFICIARIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R2200_00_PROCESSA_FAC_DB_SELECT_7(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R2200_00_PROCESSA_FAC_DB_SELECT_8(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R2215_00_FETCH_COBER_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R2230_00_SELECT_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R2500_00_UPDATE_RELATORI_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R2700_00_SELECT_PRODUVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R2710_00_SELECT_ESTIP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R2715_00_SELECT_SUBESTIP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R2750_00_SELECT_HISCOBPR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R2760_00_SELECT_PRODUTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R2800_00_SELECT_SEGURVGA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R2910_00_OBTEM_NUMERACAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R2910_10_INCLUI_RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R3100_00_BUSCA_PROFISSAO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R3200_00_BUSCA_PF_CBO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R9200_00_PESQUISA_FORMULARIO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}