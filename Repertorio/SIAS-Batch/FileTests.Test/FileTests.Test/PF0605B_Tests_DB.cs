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
using static Code.PF0605B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("PF0605B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0605B_Tests_DB
    {

        [Fact]
        public static void PF0605B_Database()
        {
            
            var program = new PF0605B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0005_00_OBTER_DATA_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0020_00_OBTER_MAX_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0050_00_SELECIONA_MOVTO_DB_DECLARE_1(); program.R0050_00_SELECIONA_MOVTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/ program.R0182_00_SEL_ERRO_SEGURADO_DB_DECLARE_1(); program.R0182_00_SEL_ERRO_SEGURADO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0150_00_PROCESSAR_MOVIMENTO_DB_UPDATE_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0180_00_GERA_H_PROP_FIDEL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.M_0610_GRAVA_RELATORIO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0188_00_SEL_BILHETE_ERROS_DB_DECLARE_1(); program.R0188_00_SEL_BILHETE_ERROS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0185_DE_PARA_COD_ERRO_VG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/
                program.PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA.Value = "2024-01-01";
                program.R0240_00_SELECIONA_BIL_COB_DB_DECLARE_1(); 
                program.R0240_00_SELECIONA_BIL_COB_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*12*/ program.R0187_DE_PARA_ERRO_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.Value = "2024-01-01";
                program.R0195_BUSCA_DADOS_HISPROFI_DB_SELECT_2(); 
            } 
            catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/ program.R0220_00_LER_BILHETE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/ program.R0230_00_LER_ENDOSSO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R0246_00_OBTER_COB_VALOR_DB_DECLARE_1(); program.R0246_00_OBTER_COB_VALOR_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R0284_00_ACESSAR_SEGURAVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R0286_00_ACESSAR_HISTSEGVG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R0520_00_ACESSA_COBERPROPVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R0523_00_ACESSA_PROP_SASSE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R0525_00_ACESSA_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/
                program.RAMOCOMP.DCLRAMO_COMPLEMENTAR.RAMOCOMP_DATA_INIVIGENCIA.Value = "2024-02-02";
                program.R0527_00_OBTER_PCT_IOF_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*24*/ program.R0530_00_ACESSAR_PROPOSTAVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/ program.R0560_00_OBTER_PERIPGTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R0585_00_ACESSA_MOVIMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R0586_00_ACESSA_MOVIMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/
                program.APOLICOB.DCLAPOLICE_COBERTURAS.APOLICOB_DATA_INIVIGENCIA.Value = "2024-02-02";
                program.R0590_00_ACESSA_COBERAPOL_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*29*/ program.R0598_00_SELECT_QUANT_BIL_RENO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/
                program.NUM_APOL_ANT.Value = 80000000017;
                program.R0599_00_SELECT_PROPOFID_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*31*/
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2024-01-01";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2024-02-02";
                program.R0850_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}