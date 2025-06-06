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
using static Code.PF0705B;

namespace FileTests.Test_DB
{
    [Collection("PF0705B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0705B_Tests_DB
    {

        [Fact]
        public static void PF0705B_Database()
        {
            var program = new PF0705B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0005_00_OBTER_DATA_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0015_00_OBTER_MAX_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0020_00_SELECIONA_MOVTO_DB_DECLARE_1(); program.R0020_00_SELECIONA_MOVTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0090_00_OBTER_PRM_PAGO_DB_DECLARE_1(); program.R0090_00_OBTER_PRM_PAGO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0043_00_LER_H_PROP_FIDEL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0044_00_LER_H_PROP_FIDEL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0045_00_ACESSAR_PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0046_00_ALTERA_PROPFIDEL_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0050_00_GERA_H_PROP_FIDEL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0060_00_ACESSA_COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0070_00_ACESSA_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*12*/
                program.RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA.Value = "2020-01-01";
                program.R0075_00_OBTER_PCT_IOF_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*13*/
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2020-01-01";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2020-01-01";
                program.R0110_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*14*/ program.R0200_00_LER_ERROS_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R0220_00_CONV_ERRO_SIVPF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

        }
    }
}