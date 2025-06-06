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
using static Code.PF0714B;

namespace FileTests.Test_DB
{
    [Collection("PF0714B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0714B_Tests_DB
    {

        [Fact]
        public static void PF0714B_Database()
        {
            var program = new PF0714B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0001_00_INICIALIZAR_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0020_00_OBTER_MAX_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2021-01-01";
                program.R0050_00_SELECIONA_MOVTO_DB_DECLARE_1(); 
                program.R0050_00_SELECIONA_MOVTO_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*4*/ program.R0450_00_OBTER_COBERTURA_DB_DECLARE_1(); program.R0450_00_OBTER_COBERTURA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0200_00_LER_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0220_00_LER_TERMO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                program.VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA.Value = "2021-11-11";
                program.R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1(); 
                program.R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*8*/ program.R0580_00_LER_HIST_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0860_LER_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/
                program.TERMOADE.DCLTERMO_ADESAO.TERMOADE_DATA_ADESAO.Value = "2022-02-02";
                program.R0870_LER_RAMOIND_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*11*/
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2021-01-01";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2022-02-02";
                program.R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.Value = "2021-04-04";
                program.R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*13*/ program.R3400_00_ATUALIZA_PROPOSTA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/ program.R3450_00_LER_PROP_SASSE_VIDA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R3500_00_PROP_SASSE_VIDA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}