using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class P7420_GE1_INSERT_DB_INSERT_1_Insert1 : QueryBasis<P7420_GE1_INSERT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.GE_MOVTO_ENVIO_MCP (
            NUM_ID_ENVIO
            ,SEQ_ID_ENVIO_HIST
            ,STA_ENVIO_MOVIMENTO
            ,COD_EMPRESA_SAP
            ,COD_SISTEMA_SAP
            ,COD_EVENTO_SAP
            ,COD_CHAVE_NEGOCIO
            ,COD_USUARIO_LIB
            ,NOM_PROGRAMA
            ,NOM_RAZ_SOCIAL
            ,IND_TIPO_PESSOA
            ,IND_SEXO
            ,NUM_CPF_CNPJ
            ,NUM_CPF_CNPJ_BENEF
            ,NOM_LOGRADOURO
            ,DES_NUM_RESIDENCIA
            ,DES_COMPL_ENDERECO
            ,NOM_BAIRRO
            ,NOM_CIDADE
            ,COD_UF
            ,COD_CEP
            ,DES_EMAIL
            ,NUM_TELEFONE
            ,DES_FAX
            ,NUM_INSC_MUNICIPAL
            ,NUM_INSC_ESTADUAL
            ,IND_OPT_SIMPLES_FEDERAL
            ,COD_CONVENIO
            ,IND_TP_CONVENIO
            ,IND_FORMA_PAG_COB
            ,TXT_EMPRESA
            ,COD_DOC_SIACC
            ,DTA_SOL_PAGTO
            ,COD_BANCO
            ,COD_AGENCIA
            ,NUM_DV_AGENCIA
            ,NUM_OPERACAO_CONTA
            ,NUM_CC
            ,NUM_DV_CONTA
            ,VLR_PAGTO
            ,VLR_ATU_MONETARIA
            ,VLR_ATU_JUROS
            ,COD_CONGENERE
            ,COD_FONTE_SIAS
            ,COD_RAMO_SUSEP
            ,COD_PRODUTO
            ,NUM_APOLICE
            ,NUM_SINISTRO
            ,COD_OPERACAO
            ,NUM_OCORR_HISTORICO
            ,DTA_AVISO
            ,DTA_COMUNICACAO
            ,DTA_SENTENCA_JUDICIAL
            ,DTA_COMUNIC_SENTEN
            ,COD_PROCES_JURID
            ,COD_SERVICO_SAP
            ,COD_FONTE_ISS
            ,NUM_DOC_FISCAL
            ,NUM_SERIE_DOC_FISCAL
            ,COD_AGRUPADOR
            ,NUM_CPF_CNPJ_TOMADOR
            ,COD_INDICATIVO_OBRA
            ,COD_NACIONAL_OBRA
            ,DTA_NOTA_FISCAL
            ,COD_CNAE_CPRB
            ,COD_PROCESSO_JUD
            ,COD_TP_SERVICO_INSS
            ,VLR_DEDUCAO_MEAT
            ,VLR_RET_NOTA_FISC
            ,VLR_RET_PRINCIPAL
            ,COD_IMPOSTO_LIMINAR
            ,NUM_PROPOSTA
            ,NUM_CERTIFICADO
            ,NUM_ENDOSSO
            ,NUM_PARCELA
            ,NUM_NIT_INSS
            ,COD_CANAL_VENDA
            ,NUM_TITULO
            ,COD_CEDENTE
            ,COD_COMPROMISSO
            ,TXT_INFO_CART_CRED
            ,QTD_PARCELA
            ,NUM_IDLG_MCP
            ,NUM_IDLG_SAP
            ,DTA_ENVIO_MCP
            ,DTA_RETORNO_SAP_ARQG
            ,DTA_RETORNO_SAP_ARQH
            ,DTA_EFETIVO_PGTO_COB
            ,COD_MODULO_SAP
            ,NOM_PROG_GRAVOU
            ,DTH_CADASTRAMENTO
            )
            VALUES (
            :GE420-NUM-ID-ENVIO
            ,:GE420-SEQ-ID-ENVIO-HIST
            ,:GE420-STA-ENVIO-MOVIMENTO
            ,:GE420-COD-EMPRESA-SAP
            ,:GE420-COD-SISTEMA-SAP
            ,:GE420-COD-EVENTO-SAP
            ,:GE420-COD-CHAVE-NEGOCIO
            ,:GE420-COD-USUARIO-LIB
            ,:GE420-NOM-PROGRAMA
            ,:GE420-NOM-RAZ-SOCIAL
            ,:GE420-IND-TIPO-PESSOA
            ,:GE420-IND-SEXO
            :WH-SEXO-NULL
            ,:GE420-NUM-CPF-CNPJ
            ,:GE420-NUM-CPF-CNPJ-BENEF
            :WH-CPF-CNPJ-BENEF-NULL
            ,:GE420-NOM-LOGRADOURO
            :WH-LOGRADOURO-NULL
            ,:GE420-DES-NUM-RESIDENCIA
            :WH-NUM-RESIDENCIA-NULL
            ,:GE420-DES-COMPL-ENDERECO
            :WH-COMPL-ENDERECO-NULL
            ,:GE420-NOM-BAIRRO
            :WH-BAIRRO-NULL
            ,:GE420-NOM-CIDADE
            :WH-CIDADE-NULL
            ,:GE420-COD-UF
            :WH-UF-NULL
            ,:GE420-COD-CEP
            :WH-CEP-NULL
            ,:GE420-DES-EMAIL
            :WH-EMAIL-NULL
            ,:GE420-NUM-TELEFONE
            :WH-TELEFONE-NULL
            ,:GE420-DES-FAX
            :WH-FAX-NULL
            ,:GE420-NUM-INSC-MUNICIPAL
            :WH-INSC-MUNICIPAL-NULL
            ,:GE420-NUM-INSC-ESTADUAL
            :WH-INSC-ESTADUAL-NULL
            ,:GE420-IND-OPT-SIMPLES-FEDERAL
            :WH-OPT-SIMPLES-FEDERAL-NULL
            ,:GE420-COD-CONVENIO
            :WH-CONVENIO-NULL
            ,:GE420-IND-TP-CONVENIO
            :WH-TP-CONVENIO-NULL
            ,:GE420-IND-FORMA-PAG-COB
            :WH-FORMA-PAG-COB-NULL
            ,:GE420-TXT-EMPRESA
            ,:GE420-COD-DOC-SIACC
            :WH-DOC-SIACC-NULL
            ,:GE420-DTA-SOL-PAGTO
            ,:GE420-COD-BANCO
            :WH-BANCO-NULL
            ,:GE420-COD-AGENCIA
            :WH-AGENCIA-NULL
            ,:GE420-NUM-DV-AGENCIA
            :WH-DV-AGENCIA-NULL
            ,:GE420-NUM-OPERACAO-CONTA
            :WH-OPERACAO-CONTA-NULL
            ,:GE420-NUM-CC
            :WH-CC-NULL
            ,:GE420-NUM-DV-CONTA
            :WH-DV-CONTA-NULL
            ,:GE420-VLR-PAGTO
            ,:GE420-VLR-ATU-MONETARIA
            ,:GE420-VLR-ATU-JUROS
            ,:GE420-COD-CONGENERE
            :WH-CONGENERE-NULL
            ,:GE420-COD-FONTE-SIAS
            :WH-FONTE-SIAS-NULL
            ,:GE420-COD-RAMO-SUSEP
            :WH-RAMO-SUSEP-NULL
            ,:GE420-COD-PRODUTO
            :WH-PRODUTO-NULL
            ,:GE420-NUM-APOLICE
            :WH-APOLICE-NULL
            ,:GE420-NUM-SINISTRO
            ,:GE420-COD-OPERACAO
            :WH-OPERACAO-NULL
            ,:GE420-NUM-OCORR-HISTORICO
            :WH-OCORR-HISTORICO-NULL
            ,:GE420-DTA-AVISO
            :WH-AVISO-NULL
            ,:GE420-DTA-COMUNICACAO
            :WH-COMUNICACAO-NULL
            ,:GE420-DTA-SENTENCA-JUDICIAL
            :WH-SENTENCA-JUDICIAL-NULL
            ,:GE420-DTA-COMUNIC-SENTEN
            :WH-COMUNIC-SENTEN-NULL
            ,:GE420-COD-PROCES-JURID
            :WH-PROCES-JURID-NULL
            ,:GE420-COD-SERVICO-SAP
            :WH-SERVICO-SAP-NULL
            ,:GE420-COD-FONTE-ISS
            :WH-FONTE-ISS-NULL
            ,:GE420-NUM-DOC-FISCAL
            :WH-DOC-FISCAL-NULL
            ,:GE420-NUM-SERIE-DOC-FISCAL
            :WH-SERIE-DOC-FISCAL-NULL
            ,:GE420-COD-AGRUPADOR
            :WH-AGRUPADOR-NULL
            ,:GE420-NUM-CPF-CNPJ-TOMADOR
            :WH-CPF-CNPJ-TOMADOR-NULL
            ,:GE420-COD-INDICATIVO-OBRA
            :WH-INDICATIVO-OBRA-NULL
            ,:GE420-COD-NACIONAL-OBRA
            :WH-NACIONAL-OBRA-NULL
            ,:GE420-DTA-NOTA-FISCAL
            :WH-NOTA-FISCAL-NULL
            ,:GE420-COD-CNAE-CPRB
            :WH-CNAE-CPRB-NULL
            ,:GE420-COD-PROCESSO-JUD
            :WH-PROCESSO-JUD-NULL
            ,:GE420-COD-TP-SERVICO-INSS
            :WH-TP-SERVICO-INSS-NULL
            ,:GE420-VLR-DEDUCAO-MEAT
            ,:GE420-VLR-RET-NOTA-FISC
            ,:GE420-VLR-RET-PRINCIPAL
            ,:GE420-COD-IMPOSTO-LIMINAR
            :WH-IMPOSTO-LIMINAR-NULL
            ,:GE420-NUM-PROPOSTA
            :WH-PROPOSTA-NULL
            ,:GE420-NUM-CERTIFICADO
            :WH-CERTIFICADO-NULL
            ,:GE420-NUM-ENDOSSO
            :WH-ENDOSSO-NULL
            ,:GE420-NUM-PARCELA
            :WH-PARCELA-NULL
            ,:GE420-NUM-NIT-INSS
            :WH-NIT-INSS-NULL
            ,:GE420-COD-CANAL-VENDA
            :WH-CANAL-VENDA-NULL
            ,:GE420-NUM-TITULO
            :WH-TITULO-NULL
            ,:GE420-COD-CEDENTE
            :WH-CEDENTE-NULL
            ,:GE420-COD-COMPROMISSO
            :WH-COMPROMISSO-NULL
            ,:GE420-TXT-INFO-CART-CRED
            :WH-INFO-CART-CRED-NULL
            ,:GE420-QTD-PARCELA
            :WH-QTD-PARCELA-NULL
            ,:GE420-NUM-IDLG-MCP
            :WH-IDLG-MCP-NULL
            ,:GE420-NUM-IDLG-SAP
            :WH-IDLG-SAP-NULL
            ,:GE420-DTA-ENVIO-MCP
            :WH-ENVIO-MCP-NULL
            ,:GE420-DTA-RETORNO-SAP-ARQG
            :WH-RETORNO-SAP-ARQG-NULL
            ,:GE420-DTA-RETORNO-SAP-ARQH
            :WH-RETORNO-SAP-ARQH-NULL
            ,:GE420-DTA-EFETIVO-PGTO-COB
            :WH-EFETIVO-PGTO-COB-NULL
            ,:GE420-COD-MODULO-SAP
            , 'SICP001S'
            , CURRENT TIMESTAMP
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_MOVTO_ENVIO_MCP ( NUM_ID_ENVIO ,SEQ_ID_ENVIO_HIST ,STA_ENVIO_MOVIMENTO ,COD_EMPRESA_SAP ,COD_SISTEMA_SAP ,COD_EVENTO_SAP ,COD_CHAVE_NEGOCIO ,COD_USUARIO_LIB ,NOM_PROGRAMA ,NOM_RAZ_SOCIAL ,IND_TIPO_PESSOA ,IND_SEXO ,NUM_CPF_CNPJ ,NUM_CPF_CNPJ_BENEF ,NOM_LOGRADOURO ,DES_NUM_RESIDENCIA ,DES_COMPL_ENDERECO ,NOM_BAIRRO ,NOM_CIDADE ,COD_UF ,COD_CEP ,DES_EMAIL ,NUM_TELEFONE ,DES_FAX ,NUM_INSC_MUNICIPAL ,NUM_INSC_ESTADUAL ,IND_OPT_SIMPLES_FEDERAL ,COD_CONVENIO ,IND_TP_CONVENIO ,IND_FORMA_PAG_COB ,TXT_EMPRESA ,COD_DOC_SIACC ,DTA_SOL_PAGTO ,COD_BANCO ,COD_AGENCIA ,NUM_DV_AGENCIA ,NUM_OPERACAO_CONTA ,NUM_CC ,NUM_DV_CONTA ,VLR_PAGTO ,VLR_ATU_MONETARIA ,VLR_ATU_JUROS ,COD_CONGENERE ,COD_FONTE_SIAS ,COD_RAMO_SUSEP ,COD_PRODUTO ,NUM_APOLICE ,NUM_SINISTRO ,COD_OPERACAO ,NUM_OCORR_HISTORICO ,DTA_AVISO ,DTA_COMUNICACAO ,DTA_SENTENCA_JUDICIAL ,DTA_COMUNIC_SENTEN ,COD_PROCES_JURID ,COD_SERVICO_SAP ,COD_FONTE_ISS ,NUM_DOC_FISCAL ,NUM_SERIE_DOC_FISCAL ,COD_AGRUPADOR ,NUM_CPF_CNPJ_TOMADOR ,COD_INDICATIVO_OBRA ,COD_NACIONAL_OBRA ,DTA_NOTA_FISCAL ,COD_CNAE_CPRB ,COD_PROCESSO_JUD ,COD_TP_SERVICO_INSS ,VLR_DEDUCAO_MEAT ,VLR_RET_NOTA_FISC ,VLR_RET_PRINCIPAL ,COD_IMPOSTO_LIMINAR ,NUM_PROPOSTA ,NUM_CERTIFICADO ,NUM_ENDOSSO ,NUM_PARCELA ,NUM_NIT_INSS ,COD_CANAL_VENDA ,NUM_TITULO ,COD_CEDENTE ,COD_COMPROMISSO ,TXT_INFO_CART_CRED ,QTD_PARCELA ,NUM_IDLG_MCP ,NUM_IDLG_SAP ,DTA_ENVIO_MCP ,DTA_RETORNO_SAP_ARQG ,DTA_RETORNO_SAP_ARQH ,DTA_EFETIVO_PGTO_COB ,COD_MODULO_SAP ,NOM_PROG_GRAVOU ,DTH_CADASTRAMENTO ) VALUES ( {FieldThreatment(this.GE420_NUM_ID_ENVIO)} ,{FieldThreatment(this.GE420_SEQ_ID_ENVIO_HIST)} ,{FieldThreatment(this.GE420_STA_ENVIO_MOVIMENTO)} ,{FieldThreatment(this.GE420_COD_EMPRESA_SAP)} ,{FieldThreatment(this.GE420_COD_SISTEMA_SAP)} ,{FieldThreatment(this.GE420_COD_EVENTO_SAP)} ,{FieldThreatment(this.GE420_COD_CHAVE_NEGOCIO)} ,{FieldThreatment(this.GE420_COD_USUARIO_LIB)} ,{FieldThreatment(this.GE420_NOM_PROGRAMA)} ,{FieldThreatment(this.GE420_NOM_RAZ_SOCIAL)} ,{FieldThreatment(this.GE420_IND_TIPO_PESSOA)} , {FieldThreatment((this.WH_SEXO_NULL?.ToInt() == -1 ? null : this.GE420_IND_SEXO))} ,{FieldThreatment(this.GE420_NUM_CPF_CNPJ)} , {FieldThreatment((this.WH_CPF_CNPJ_BENEF_NULL?.ToInt() == -1 ? null : this.GE420_NUM_CPF_CNPJ_BENEF))} , {FieldThreatment((this.WH_LOGRADOURO_NULL?.ToInt() == -1 ? null : this.GE420_NOM_LOGRADOURO))} , {FieldThreatment((this.WH_NUM_RESIDENCIA_NULL?.ToInt() == -1 ? null : this.GE420_DES_NUM_RESIDENCIA))} , {FieldThreatment((this.WH_COMPL_ENDERECO_NULL?.ToInt() == -1 ? null : this.GE420_DES_COMPL_ENDERECO))} , {FieldThreatment((this.WH_BAIRRO_NULL?.ToInt() == -1 ? null : this.GE420_NOM_BAIRRO))} , {FieldThreatment((this.WH_CIDADE_NULL?.ToInt() == -1 ? null : this.GE420_NOM_CIDADE))} , {FieldThreatment((this.WH_UF_NULL?.ToInt() == -1 ? null : this.GE420_COD_UF))} , {FieldThreatment((this.WH_CEP_NULL?.ToInt() == -1 ? null : this.GE420_COD_CEP))} , {FieldThreatment((this.WH_EMAIL_NULL?.ToInt() == -1 ? null : this.GE420_DES_EMAIL))} , {FieldThreatment((this.WH_TELEFONE_NULL?.ToInt() == -1 ? null : this.GE420_NUM_TELEFONE))} , {FieldThreatment((this.WH_FAX_NULL?.ToInt() == -1 ? null : this.GE420_DES_FAX))} , {FieldThreatment((this.WH_INSC_MUNICIPAL_NULL?.ToInt() == -1 ? null : this.GE420_NUM_INSC_MUNICIPAL))} , {FieldThreatment((this.WH_INSC_ESTADUAL_NULL?.ToInt() == -1 ? null : this.GE420_NUM_INSC_ESTADUAL))} , {FieldThreatment((this.WH_OPT_SIMPLES_FEDERAL_NULL?.ToInt() == -1 ? null : this.GE420_IND_OPT_SIMPLES_FEDERAL))} , {FieldThreatment((this.WH_CONVENIO_NULL?.ToInt() == -1 ? null : this.GE420_COD_CONVENIO))} , {FieldThreatment((this.WH_TP_CONVENIO_NULL?.ToInt() == -1 ? null : this.GE420_IND_TP_CONVENIO))} , {FieldThreatment((this.WH_FORMA_PAG_COB_NULL?.ToInt() == -1 ? null : this.GE420_IND_FORMA_PAG_COB))} ,{FieldThreatment(this.GE420_TXT_EMPRESA)} , {FieldThreatment((this.WH_DOC_SIACC_NULL?.ToInt() == -1 ? null : this.GE420_COD_DOC_SIACC))} ,{FieldThreatment(this.GE420_DTA_SOL_PAGTO)} , {FieldThreatment((this.WH_BANCO_NULL?.ToInt() == -1 ? null : this.GE420_COD_BANCO))} , {FieldThreatment((this.WH_AGENCIA_NULL?.ToInt() == -1 ? null : this.GE420_COD_AGENCIA))} , {FieldThreatment((this.WH_DV_AGENCIA_NULL?.ToInt() == -1 ? null : this.GE420_NUM_DV_AGENCIA))} , {FieldThreatment((this.WH_OPERACAO_CONTA_NULL?.ToInt() == -1 ? null : this.GE420_NUM_OPERACAO_CONTA))} , {FieldThreatment((this.WH_CC_NULL?.ToInt() == -1 ? null : this.GE420_NUM_CC))} , {FieldThreatment((this.WH_DV_CONTA_NULL?.ToInt() == -1 ? null : this.GE420_NUM_DV_CONTA))} ,{FieldThreatment(this.GE420_VLR_PAGTO)} ,{FieldThreatment(this.GE420_VLR_ATU_MONETARIA)} ,{FieldThreatment(this.GE420_VLR_ATU_JUROS)} , {FieldThreatment((this.WH_CONGENERE_NULL?.ToInt() == -1 ? null : this.GE420_COD_CONGENERE))} , {FieldThreatment((this.WH_FONTE_SIAS_NULL?.ToInt() == -1 ? null : this.GE420_COD_FONTE_SIAS))} , {FieldThreatment((this.WH_RAMO_SUSEP_NULL?.ToInt() == -1 ? null : this.GE420_COD_RAMO_SUSEP))} , {FieldThreatment((this.WH_PRODUTO_NULL?.ToInt() == -1 ? null : this.GE420_COD_PRODUTO))} , {FieldThreatment((this.WH_APOLICE_NULL?.ToInt() == -1 ? null : this.GE420_NUM_APOLICE))} ,{FieldThreatment(this.GE420_NUM_SINISTRO)} , {FieldThreatment((this.WH_OPERACAO_NULL?.ToInt() == -1 ? null : this.GE420_COD_OPERACAO))} , {FieldThreatment((this.WH_OCORR_HISTORICO_NULL?.ToInt() == -1 ? null : this.GE420_NUM_OCORR_HISTORICO))} , {FieldThreatment((this.WH_AVISO_NULL?.ToInt() == -1 ? null : this.GE420_DTA_AVISO))} , {FieldThreatment((this.WH_COMUNICACAO_NULL?.ToInt() == -1 ? null : this.GE420_DTA_COMUNICACAO))} , {FieldThreatment((this.WH_SENTENCA_JUDICIAL_NULL?.ToInt() == -1 ? null : this.GE420_DTA_SENTENCA_JUDICIAL))} , {FieldThreatment((this.WH_COMUNIC_SENTEN_NULL?.ToInt() == -1 ? null : this.GE420_DTA_COMUNIC_SENTEN))} , {FieldThreatment((this.WH_PROCES_JURID_NULL?.ToInt() == -1 ? null : this.GE420_COD_PROCES_JURID))} , {FieldThreatment((this.WH_SERVICO_SAP_NULL?.ToInt() == -1 ? null : this.GE420_COD_SERVICO_SAP))} , {FieldThreatment((this.WH_FONTE_ISS_NULL?.ToInt() == -1 ? null : this.GE420_COD_FONTE_ISS))} , {FieldThreatment((this.WH_DOC_FISCAL_NULL?.ToInt() == -1 ? null : this.GE420_NUM_DOC_FISCAL))} , {FieldThreatment((this.WH_SERIE_DOC_FISCAL_NULL?.ToInt() == -1 ? null : this.GE420_NUM_SERIE_DOC_FISCAL))} , {FieldThreatment((this.WH_AGRUPADOR_NULL?.ToInt() == -1 ? null : this.GE420_COD_AGRUPADOR))} , {FieldThreatment((this.WH_CPF_CNPJ_TOMADOR_NULL?.ToInt() == -1 ? null : this.GE420_NUM_CPF_CNPJ_TOMADOR))} , {FieldThreatment((this.WH_INDICATIVO_OBRA_NULL?.ToInt() == -1 ? null : this.GE420_COD_INDICATIVO_OBRA))} , {FieldThreatment((this.WH_NACIONAL_OBRA_NULL?.ToInt() == -1 ? null : this.GE420_COD_NACIONAL_OBRA))} , {FieldThreatment((this.WH_NOTA_FISCAL_NULL?.ToInt() == -1 ? null : this.GE420_DTA_NOTA_FISCAL))} , {FieldThreatment((this.WH_CNAE_CPRB_NULL?.ToInt() == -1 ? null : this.GE420_COD_CNAE_CPRB))} , {FieldThreatment((this.WH_PROCESSO_JUD_NULL?.ToInt() == -1 ? null : this.GE420_COD_PROCESSO_JUD))} , {FieldThreatment((this.WH_TP_SERVICO_INSS_NULL?.ToInt() == -1 ? null : this.GE420_COD_TP_SERVICO_INSS))} ,{FieldThreatment(this.GE420_VLR_DEDUCAO_MEAT)} ,{FieldThreatment(this.GE420_VLR_RET_NOTA_FISC)} ,{FieldThreatment(this.GE420_VLR_RET_PRINCIPAL)} , {FieldThreatment((this.WH_IMPOSTO_LIMINAR_NULL?.ToInt() == -1 ? null : this.GE420_COD_IMPOSTO_LIMINAR))} , {FieldThreatment((this.WH_PROPOSTA_NULL?.ToInt() == -1 ? null : this.GE420_NUM_PROPOSTA))} , {FieldThreatment((this.WH_CERTIFICADO_NULL?.ToInt() == -1 ? null : this.GE420_NUM_CERTIFICADO))} , {FieldThreatment((this.WH_ENDOSSO_NULL?.ToInt() == -1 ? null : this.GE420_NUM_ENDOSSO))} , {FieldThreatment((this.WH_PARCELA_NULL?.ToInt() == -1 ? null : this.GE420_NUM_PARCELA))} , {FieldThreatment((this.WH_NIT_INSS_NULL?.ToInt() == -1 ? null : this.GE420_NUM_NIT_INSS))} , {FieldThreatment((this.WH_CANAL_VENDA_NULL?.ToInt() == -1 ? null : this.GE420_COD_CANAL_VENDA))} , {FieldThreatment((this.WH_TITULO_NULL?.ToInt() == -1 ? null : this.GE420_NUM_TITULO))} , {FieldThreatment((this.WH_CEDENTE_NULL?.ToInt() == -1 ? null : this.GE420_COD_CEDENTE))} , {FieldThreatment((this.WH_COMPROMISSO_NULL?.ToInt() == -1 ? null : this.GE420_COD_COMPROMISSO))} , {FieldThreatment((this.WH_INFO_CART_CRED_NULL?.ToInt() == -1 ? null : this.GE420_TXT_INFO_CART_CRED))} , {FieldThreatment((this.WH_QTD_PARCELA_NULL?.ToInt() == -1 ? null : this.GE420_QTD_PARCELA))} , {FieldThreatment((this.WH_IDLG_MCP_NULL?.ToInt() == -1 ? null : this.GE420_NUM_IDLG_MCP))} , {FieldThreatment((this.WH_IDLG_SAP_NULL?.ToInt() == -1 ? null : this.GE420_NUM_IDLG_SAP))} , {FieldThreatment((this.WH_ENVIO_MCP_NULL?.ToInt() == -1 ? null : this.GE420_DTA_ENVIO_MCP))} , {FieldThreatment((this.WH_RETORNO_SAP_ARQG_NULL?.ToInt() == -1 ? null : this.GE420_DTA_RETORNO_SAP_ARQG))} , {FieldThreatment((this.WH_RETORNO_SAP_ARQH_NULL?.ToInt() == -1 ? null : this.GE420_DTA_RETORNO_SAP_ARQH))} , {FieldThreatment((this.WH_EFETIVO_PGTO_COB_NULL?.ToInt() == -1 ? null : this.GE420_DTA_EFETIVO_PGTO_COB))} ,{FieldThreatment(this.GE420_COD_MODULO_SAP)} , 'SICP001S' , CURRENT TIMESTAMP )";

            return query;
        }
        public string GE420_NUM_ID_ENVIO { get; set; }
        public string GE420_SEQ_ID_ENVIO_HIST { get; set; }
        public string GE420_STA_ENVIO_MOVIMENTO { get; set; }
        public string GE420_COD_EMPRESA_SAP { get; set; }
        public string GE420_COD_SISTEMA_SAP { get; set; }
        public string GE420_COD_EVENTO_SAP { get; set; }
        public string GE420_COD_CHAVE_NEGOCIO { get; set; }
        public string GE420_COD_USUARIO_LIB { get; set; }
        public string GE420_NOM_PROGRAMA { get; set; }
        public string GE420_NOM_RAZ_SOCIAL { get; set; }
        public string GE420_IND_TIPO_PESSOA { get; set; }
        public string GE420_IND_SEXO { get; set; }
        public string WH_SEXO_NULL { get; set; }
        public string GE420_NUM_CPF_CNPJ { get; set; }
        public string GE420_NUM_CPF_CNPJ_BENEF { get; set; }
        public string WH_CPF_CNPJ_BENEF_NULL { get; set; }
        public string GE420_NOM_LOGRADOURO { get; set; }
        public string WH_LOGRADOURO_NULL { get; set; }
        public string GE420_DES_NUM_RESIDENCIA { get; set; }
        public string WH_NUM_RESIDENCIA_NULL { get; set; }
        public string GE420_DES_COMPL_ENDERECO { get; set; }
        public string WH_COMPL_ENDERECO_NULL { get; set; }
        public string GE420_NOM_BAIRRO { get; set; }
        public string WH_BAIRRO_NULL { get; set; }
        public string GE420_NOM_CIDADE { get; set; }
        public string WH_CIDADE_NULL { get; set; }
        public string GE420_COD_UF { get; set; }
        public string WH_UF_NULL { get; set; }
        public string GE420_COD_CEP { get; set; }
        public string WH_CEP_NULL { get; set; }
        public string GE420_DES_EMAIL { get; set; }
        public string WH_EMAIL_NULL { get; set; }
        public string GE420_NUM_TELEFONE { get; set; }
        public string WH_TELEFONE_NULL { get; set; }
        public string GE420_DES_FAX { get; set; }
        public string WH_FAX_NULL { get; set; }
        public string GE420_NUM_INSC_MUNICIPAL { get; set; }
        public string WH_INSC_MUNICIPAL_NULL { get; set; }
        public string GE420_NUM_INSC_ESTADUAL { get; set; }
        public string WH_INSC_ESTADUAL_NULL { get; set; }
        public string GE420_IND_OPT_SIMPLES_FEDERAL { get; set; }
        public string WH_OPT_SIMPLES_FEDERAL_NULL { get; set; }
        public string GE420_COD_CONVENIO { get; set; }
        public string WH_CONVENIO_NULL { get; set; }
        public string GE420_IND_TP_CONVENIO { get; set; }
        public string WH_TP_CONVENIO_NULL { get; set; }
        public string GE420_IND_FORMA_PAG_COB { get; set; }
        public string WH_FORMA_PAG_COB_NULL { get; set; }
        public string GE420_TXT_EMPRESA { get; set; }
        public string GE420_COD_DOC_SIACC { get; set; }
        public string WH_DOC_SIACC_NULL { get; set; }
        public string GE420_DTA_SOL_PAGTO { get; set; }
        public string GE420_COD_BANCO { get; set; }
        public string WH_BANCO_NULL { get; set; }
        public string GE420_COD_AGENCIA { get; set; }
        public string WH_AGENCIA_NULL { get; set; }
        public string GE420_NUM_DV_AGENCIA { get; set; }
        public string WH_DV_AGENCIA_NULL { get; set; }
        public string GE420_NUM_OPERACAO_CONTA { get; set; }
        public string WH_OPERACAO_CONTA_NULL { get; set; }
        public string GE420_NUM_CC { get; set; }
        public string WH_CC_NULL { get; set; }
        public string GE420_NUM_DV_CONTA { get; set; }
        public string WH_DV_CONTA_NULL { get; set; }
        public string GE420_VLR_PAGTO { get; set; }
        public string GE420_VLR_ATU_MONETARIA { get; set; }
        public string GE420_VLR_ATU_JUROS { get; set; }
        public string GE420_COD_CONGENERE { get; set; }
        public string WH_CONGENERE_NULL { get; set; }
        public string GE420_COD_FONTE_SIAS { get; set; }
        public string WH_FONTE_SIAS_NULL { get; set; }
        public string GE420_COD_RAMO_SUSEP { get; set; }
        public string WH_RAMO_SUSEP_NULL { get; set; }
        public string GE420_COD_PRODUTO { get; set; }
        public string WH_PRODUTO_NULL { get; set; }
        public string GE420_NUM_APOLICE { get; set; }
        public string WH_APOLICE_NULL { get; set; }
        public string GE420_NUM_SINISTRO { get; set; }
        public string GE420_COD_OPERACAO { get; set; }
        public string WH_OPERACAO_NULL { get; set; }
        public string GE420_NUM_OCORR_HISTORICO { get; set; }
        public string WH_OCORR_HISTORICO_NULL { get; set; }
        public string GE420_DTA_AVISO { get; set; }
        public string WH_AVISO_NULL { get; set; }
        public string GE420_DTA_COMUNICACAO { get; set; }
        public string WH_COMUNICACAO_NULL { get; set; }
        public string GE420_DTA_SENTENCA_JUDICIAL { get; set; }
        public string WH_SENTENCA_JUDICIAL_NULL { get; set; }
        public string GE420_DTA_COMUNIC_SENTEN { get; set; }
        public string WH_COMUNIC_SENTEN_NULL { get; set; }
        public string GE420_COD_PROCES_JURID { get; set; }
        public string WH_PROCES_JURID_NULL { get; set; }
        public string GE420_COD_SERVICO_SAP { get; set; }
        public string WH_SERVICO_SAP_NULL { get; set; }
        public string GE420_COD_FONTE_ISS { get; set; }
        public string WH_FONTE_ISS_NULL { get; set; }
        public string GE420_NUM_DOC_FISCAL { get; set; }
        public string WH_DOC_FISCAL_NULL { get; set; }
        public string GE420_NUM_SERIE_DOC_FISCAL { get; set; }
        public string WH_SERIE_DOC_FISCAL_NULL { get; set; }
        public string GE420_COD_AGRUPADOR { get; set; }
        public string WH_AGRUPADOR_NULL { get; set; }
        public string GE420_NUM_CPF_CNPJ_TOMADOR { get; set; }
        public string WH_CPF_CNPJ_TOMADOR_NULL { get; set; }
        public string GE420_COD_INDICATIVO_OBRA { get; set; }
        public string WH_INDICATIVO_OBRA_NULL { get; set; }
        public string GE420_COD_NACIONAL_OBRA { get; set; }
        public string WH_NACIONAL_OBRA_NULL { get; set; }
        public string GE420_DTA_NOTA_FISCAL { get; set; }
        public string WH_NOTA_FISCAL_NULL { get; set; }
        public string GE420_COD_CNAE_CPRB { get; set; }
        public string WH_CNAE_CPRB_NULL { get; set; }
        public string GE420_COD_PROCESSO_JUD { get; set; }
        public string WH_PROCESSO_JUD_NULL { get; set; }
        public string GE420_COD_TP_SERVICO_INSS { get; set; }
        public string WH_TP_SERVICO_INSS_NULL { get; set; }
        public string GE420_VLR_DEDUCAO_MEAT { get; set; }
        public string GE420_VLR_RET_NOTA_FISC { get; set; }
        public string GE420_VLR_RET_PRINCIPAL { get; set; }
        public string GE420_COD_IMPOSTO_LIMINAR { get; set; }
        public string WH_IMPOSTO_LIMINAR_NULL { get; set; }
        public string GE420_NUM_PROPOSTA { get; set; }
        public string WH_PROPOSTA_NULL { get; set; }
        public string GE420_NUM_CERTIFICADO { get; set; }
        public string WH_CERTIFICADO_NULL { get; set; }
        public string GE420_NUM_ENDOSSO { get; set; }
        public string WH_ENDOSSO_NULL { get; set; }
        public string GE420_NUM_PARCELA { get; set; }
        public string WH_PARCELA_NULL { get; set; }
        public string GE420_NUM_NIT_INSS { get; set; }
        public string WH_NIT_INSS_NULL { get; set; }
        public string GE420_COD_CANAL_VENDA { get; set; }
        public string WH_CANAL_VENDA_NULL { get; set; }
        public string GE420_NUM_TITULO { get; set; }
        public string WH_TITULO_NULL { get; set; }
        public string GE420_COD_CEDENTE { get; set; }
        public string WH_CEDENTE_NULL { get; set; }
        public string GE420_COD_COMPROMISSO { get; set; }
        public string WH_COMPROMISSO_NULL { get; set; }
        public string GE420_TXT_INFO_CART_CRED { get; set; }
        public string WH_INFO_CART_CRED_NULL { get; set; }
        public string GE420_QTD_PARCELA { get; set; }
        public string WH_QTD_PARCELA_NULL { get; set; }
        public string GE420_NUM_IDLG_MCP { get; set; }
        public string WH_IDLG_MCP_NULL { get; set; }
        public string GE420_NUM_IDLG_SAP { get; set; }
        public string WH_IDLG_SAP_NULL { get; set; }
        public string GE420_DTA_ENVIO_MCP { get; set; }
        public string WH_ENVIO_MCP_NULL { get; set; }
        public string GE420_DTA_RETORNO_SAP_ARQG { get; set; }
        public string WH_RETORNO_SAP_ARQG_NULL { get; set; }
        public string GE420_DTA_RETORNO_SAP_ARQH { get; set; }
        public string WH_RETORNO_SAP_ARQH_NULL { get; set; }
        public string GE420_DTA_EFETIVO_PGTO_COB { get; set; }
        public string WH_EFETIVO_PGTO_COB_NULL { get; set; }
        public string GE420_COD_MODULO_SAP { get; set; }

        public static void Execute(P7420_GE1_INSERT_DB_INSERT_1_Insert1 p7420_GE1_INSERT_DB_INSERT_1_Insert1)
        {
            var ths = p7420_GE1_INSERT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P7420_GE1_INSERT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}