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
using static Code.PF0642B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("PF0642B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0642B_Tests_DB
    {

        [Fact]
        public static void PF0642B_Database()
        {
            var program = new PF0642B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0005_00_OBTER_DATA_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0020_00_OBTER_MAX_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0020_00_OBTER_MAX_NSAS_DB_SELECT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*4*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2020-01-01";
                program.R0050_00_SELECIONA_MOVTO_DB_DECLARE_1(); 
                program.R0050_00_SELECIONA_MOVTO_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*5*/ program.R0205_00_LER_RCAPCOMP_DB_DECLARE_1(); program.R0205_00_LER_RCAPCOMP_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0085_00_LER_PRODUTOS_SIVPF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/ program.R0200_00_LER_RCAPS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0205_00_LER_RCAPCOMP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0350_00_DECLER_ENDERECO_DB_DECLARE_1(); program.R0350_00_DECLER_ENDERECO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0210_00_LER_PRP_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0300_00_LER_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*12*/
                program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_TERVIGENCIA.Value = "2020-01-01";
                program.R0450_00_OBTER_COBERTURA_DB_DECLARE_1(); 
                program.R0450_00_OBTER_COBERTURA_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*13*/ program.R0400_00_LER_SUBGRUPO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*14*/
                program.OPCPAGVI.DCLOPCAO_PAG_VIDAZUL.OPCPAGVI_DATA_TERVIGENCIA.Value = "2020-01-01";
                program.R0500_00_OBTER_OPCAOPAG_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*15*/
                program.FDCOMVA.DCLFUNDO_COMISSAO_VA.NUM_CERTIFICADO.Value = 84654460000028;
                program.WHOST_NUM_TERMO.Value = 84654460000028;
                program.FDCOMVA.DCLFUNDO_COMISSAO_VA.COD_OPERACAO.Value = 1101;
                program.R0570_00_LER_COMISSAO_DB_DECLARE_1(); 
                program.R0570_00_LER_COMISSAO_DB_OPEN_1(); 

            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*16*/ program.R0470_00_LER_PROPOSTA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*17*/
                program.VGTERNIV.DCLVG_TERMO_NIVEL.VGTERNIV_DTH_INI_VIGENCIA.Value = "2020-01-01";

                program.R0710_OBTER_NIVEL_EMPRESA_DB_DECLARE_1(); 
                program.R0710_OBTER_NIVEL_EMPRESA_DB_OPEN_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }
            
            try { /*18*/ program.R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*19*/
                program.VGFUNCOB.DCLVG_FUNC_COBERTURA.VGFUNCOB_DTH_INI_VIGENCIA.Value = "2020-01-01";
                program.R0708_OBTER_VALOR_FATURA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }


            try { /*20*/ 
                program.VGMOVFUN.DCLVG_MOV_FUNCIONARIO.VGMOVFUN_DTH_FIM_VIGENCIA.Value = "2020-01-01";
                program.R0745_OBTER_FUNC_EMPRESA_DB_DECLARE_1(); program.R0745_OBTER_FUNC_EMPRESA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/ program.R0775_OBTER_COBERTURA_FUNC_DB_DECLARE_1(); program.R0775_OBTER_COBERTURA_FUNC_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/ program.R3136_RELACIONA_EMAIL_DB_DECLARE_1(); program.R3135_INCLUIR_END_EMAIL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/ program.R0860_LER_APOLICE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*24*/
                program.HISCOBPR.DCLHIS_COBER_PROPOST.HISCOBPR_DATA_INIVIGENCIA.Value = "2020-01-01";
                program.R0870_LER_RAMOIND_DB_SELECT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*25*/

                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2020-02-01";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2020-01-01";
                program.R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*26*/ program.R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/ program.R3110_LER_PESSOA_JURIDICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/ program.R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/ program.R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R3205_RELACIONA_ENDERECO_DB_DECLARE_1(); program.R3201_TRATA_ENDERECO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/ program.R3140_OBTER_MAX_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R3141_INCLUIR_EMAIL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R3155_LER_TAB_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R3165_OBTER_MAX_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R3170_LER_EMAIL_ATUAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/ program.R6000_00_DECLARE_AGENCEF_DB_DECLARE_1(); program.R6000_00_DECLARE_AGENCEF_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R3225_OBTER_MAX_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/ program.R3230_INCLUIR_ENDERECO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R3255_LER_TELEFONE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R3265_OBTER_MAX_TELEFONE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/ program.R3270_INCLUIR_TELEFONE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R3330_GERA_RELACIONAMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/ program.R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/ program.R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*47*/
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_PROPOSTA.Value = "2020-01-01";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DTQITBCO.Value = "2020-01-01";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_NASC_CONJUGE.Value = "2020-01-01";
                program.PROPOFID.DCLPROPOSTA_FIDELIZ.PROPOFID_DATA_CREDITO.Value = "2020-01-01";
                program.R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1(); 
            } catch (Exception ex) { _.ThreatableTestError(ex); }

            try { /*48*/ program.R3370_GERA_PROP_VIDA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/ program.R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}