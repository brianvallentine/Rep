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
using static Code.PF0619B;
using Dclgens;

namespace FileTests.Test_DB
{
    [Collection("PF0619B_Tests_DB")]
    [Trait(IA_ConverterCommons.Utils.TestTraits.TestType.Name, IA_ConverterCommons.Utils.TestTraits.TestType.Values.DatabaseTesting)]
    [Trait(IA_ConverterCommons.Utils.TestTraits.Package.Name, IA_ConverterCommons.Utils.TestTraits.Package.Values.Package01)]
    public class PF0619B_Tests_DB
    {

        [Fact]
        public static void PF0619B_Database()
        {
            var program = new PF0619B();
            AppSettings.TestSet.DB_Test.Is_DB_Test = true;
            try { /*1*/ program.R0005_00_OBTER_DATA_DIA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*2*/ program.R0007_00_OBTER_DT_PROCE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*3*/ program.R0020_00_OBTER_MAX_NSAS_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*4*/
                program.SISTEMAS.DCLSISTEMAS.SISTEMAS_DATA_MOV_ABERTO.Value = "2000-10-10";
                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = "2000-10-10";


                program.R0050_00_SELECIONA_MOVTO_DB_DECLARE_1(); program.R0050_00_SELECIONA_MOVTO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*5*/ program.R0410_00_LER_CBO_DB_DECLARE_1(); program.R0410_00_LER_CBO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*6*/ program.R0200_00_LER_PROP_FIDELIZ_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*7*/
                //Erro de timeOut 
                program.R0250_00_UPDATE_FIDELIZ_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*8*/ program.R0300_00_LER_CLIENTE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*9*/ program.R0350_00_LER_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*10*/ program.R0410_00_LER_CBO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*11*/ program.R0520_00_LER_PARCELVA_DB_DECLARE_1(); program.R0520_00_LER_PARCELVA_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*12*/ program.R0450_00_LER_PRODUTOS_SIVPF_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*13*/ program.R0500_00_LER_RCAP_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*14*/
                //Erro de timeOut
                program.R0570_00_LER_COMISSAO_DB_DECLARE_1(); program.R0570_00_LER_COMISSAO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*15*/ program.R0521_00_TRATA_COBER_PROPST_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*16*/

                program.WAREA_AUXILIAR.HOST_DT_TERVIG2.Value = "2000-10-10";
                program.WAREA_AUXILIAR.HOST_DT_TERVIG1.Value = "2000-10-10";


                program.R0550_00_LER_OPCAOPAGVA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*17*/ program.R0800_00_CURSOR_BENEFICIARIOS_DB_DECLARE_1(); program.R0800_00_CURSOR_BENEFICIARIOS_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*18*/ program.R0580_00_OBTER_VAL_TARIFA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*19*/ program.R0620_00_DADOS_RG_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*20*/ program.R3136_RELACIONA_EMAIL_DB_DECLARE_1(); program.R3135_INCLUIR_END_EMAIL_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*21*/

                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = "2000-10-10";

                program.R0880_00_UPDATE_RELATORIOS_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*22*/
                //erro de Foreign Key
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_PROCESSAMENTO.Value = "2000-10-10";
                program.ARQSIVPF.DCLARQUIVOS_SIVPF.ARQSIVPF_DATA_GERACAO.Value = "2000-10-10";

                program.R1050_00_CONTROLAR_ARQ_ENVIADO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*23*/

                program.PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.Value = "2000-10-10";

                program.R3105_LER_PESSOA_FISICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*24*/ program.R3110_LER_PESSOA_JURIDICA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*25*/
                //AN INSERTED OR UPDATED VALUE IS INVALID BECAUSE INDEX IN INDEX SPACE IPGET121 CONSTRAINS COLUMNS OF THE TABLE SO NO TWO ROWS CAN CONTAIN DUPLICATE VALUES IN THOSE COLUMNS
                program.R3120_INCLUIR_TAB_PESSOA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*26*/ program.R3121_OBTER_MAX_COD_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*27*/
                //ERRO de Foreign Key
                program.PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.Value = "2000-10-10";
                program.PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.Value = "2000-10-10";

                program.R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*28*/
                //ERRO de Foreign Key
                program.PESFIS.DCLPESSOA_FISICA.DATA_EXPEDICAO.Value = "2000-10-10";
                program.PESFIS.DCLPESSOA_FISICA.DATA_NASCIMENTO.Value = "2000-10-10";

                program.R3125_INCLUIR_PESSOA_FISICA_DB_INSERT_2(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*29*/
                //ERRO de Foreign Key
                program.R3130_INCLUIR_PESSOA_JURIDICA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*30*/ program.R3205_RELACIONA_ENDERECO_DB_DECLARE_1(); program.R3201_TRATA_ENDERECO_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*31*/ program.R3140_OBTER_MAX_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*32*/
                //ERRO de Foreign Key

                program.R3141_INCLUIR_EMAIL_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*33*/ program.R3155_LER_TAB_PESSOA_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*34*/ program.R31551_CORRIGE_PESSOA_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*35*/ program.R3165_OBTER_MAX_EMAIL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*36*/ program.R3170_LER_EMAIL_ATUAL_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*37*/

                program.RELATORI.DCLRELATORIOS.RELATORI_DATA_REFERENCIA.Value = "2000-10-10";

                program.R5050_00_SELECIONA_BILHETE_DB_DECLARE_1(); program.R5050_00_SELECIONA_BILHETE_DB_OPEN_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*38*/ program.R3225_OBTER_MAX_ENDERECO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*39*/
                //The insert or update value of the FOREIGN KEY "FK00028" is not equal to any value of the parent key of the parent table
                program.R3230_INCLUIR_ENDERECO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*40*/ program.R3255_LER_TELEFONE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*41*/ program.R3265_OBTER_MAX_TELEFONE_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*42*/
                //Erro Foreign Key
                program.R3270_INCLUIR_TELEFONE_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*43*/ program.R3315_DETERMINA_RELACIONAMENTO_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*44*/ program.R3320_VERIFICA_EXISTE_RELACION_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*45*/
                //Erro Foreign Key
                program.R3330_GERA_RELACIONAMENTO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*46*/
                //Erro Foreign Key
                program.R3350_TRATA_TAB_IDE_RELACIONAM_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*47*/ program.R3355_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*48*/
                //THE REQUESTED OPERATION IS NOT ALLOWED BECAUSE A ROW DOES NOT SATISFY THE CHECK CONSTRAINT PF002C2
                program.PROPFID.DCLPROPOSTA_FIDELIZ.DATA_NASC_CONJUGE.Value = "2000-10-10";
                program.PROPFID.DCLPROPOSTA_FIDELIZ.DATA_CREDITO.Value = "2000-10-10";
                program.PROPFID.DCLPROPOSTA_FIDELIZ.DATA_PROPOSTA.Value = "2000-10-10";
                program.PROPFID.DCLPROPOSTA_FIDELIZ.DTQITBCO.Value = "2000-10-10";
                //program.VIND_DTNASC_ESPOSA.Value = "2000-10-10";

                program.R3360_TRATA_PROP_FIDELIZACAO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*49*/
                //Erro Foreign Key
                program.R3365_TRATA_PROP_ESPECIFICA_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*50*/
                //quantia de parametros menor que a tabela
                program.PROPFIDH.DCLHIST_PROP_FIDELIZ.PROPFIDH_DATA_SITUACAO.Value = "2000-10-10";

                program.R3390_GERA_HIST_FIDELIZACAO_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*51*/ program.R3392_ACESSAR_CONVERSAO_SICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*52*/ program.R3393_NUMERAR_SICOB_DB_SELECT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*53*/ program.R3393_NUMERAR_SICOB_DB_UPDATE_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
            try { /*54*/
                //Foreign Key
                program.COVSICOB.DCLCONVERSAO_SICOB.DATA_QUITACAO.Value = "2000-10-10";
                program.COVSICOB.DCLCONVERSAO_SICOB.DATA_OPERACAO.Value = "2000-10-10";

                program.R3394_GERA_DE_PARA_NR_SICOB_DB_INSERT_1(); } catch (Exception ex) { _.ThreatableTestError(ex); }
        }
    }
}