using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0531S
{
    public class R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1 : QueryBasis<R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SIUS.GE_PESSOA_VALIDA_LOG
            (NUM_CPF_CNPJ
            ,SEQ_REGISTRO
            ,NUM_RAMO_EMISSOR
            ,COD_PRODUTO
            ,COD_FONTE
            ,NUM_PROPOSTA
            ,NUM_CERTIFICADO_EXT
            ,NUM_APOLICE
            ,NUM_ENDOSSO
            ,NUM_SINISTRO
            ,OCORR_HISTORICO
            ,COD_OPER_SINISTRO
            ,NOM_SEGURADO
            ,COD_CARGO
            ,DES_CARGO
            ,NOM_ORGAO
            ,COD_RELACAO_EXTERNO
            ,IND_TP_RELAC_INTERNO
            ,IND_TIPO_PESSOA
            ,IND_MOVIMENTO
            ,IND_EVENTO
            ,DTA_INCLUSAO
            ,STA_REGISTRO
            ,COD_ORIGEM
            ,COD_USUARIO
            ,NOM_PROGRAMA
            ,DTH_CADASTRAMENTO
            )
            VALUES
            (:GE615-NUM-CPF-CNPJ
            ,:GE615-SEQ-REGISTRO
            ,:GE615-NUM-RAMO-EMISSOR
            :GE615-NUM-RAMO-EMISSOR-NULO
            ,:GE615-COD-PRODUTO :GE615-COD-PRODUTO-NULO
            ,:GE615-COD-FONTE :GE615-COD-FONTE-NULO
            ,:GE615-NUM-PROPOSTA :GE615-NUM-PROPOSTA-NULO
            ,:GE615-NUM-CERTIFICADO-EXT
            ,:GE615-NUM-APOLICE
            ,:GE615-NUM-ENDOSSO
            ,:GE615-NUM-SINISTRO
            ,:GE615-OCORR-HISTORICO
            ,:GE615-COD-OPER-SINISTRO
            ,:GE615-NOM-SEGURADO :GE615-NOM-SEGURADO-NULO
            ,:GE615-COD-CARGO
            ,:GE615-DES-CARGO
            ,:GE615-NOM-ORGAO
            ,:GE615-COD-RELACAO-EXTERNO
            ,:GE615-IND-TP-RELAC-INTERNO
            :GE615-IND-TP-RELAC-INT-NULO
            ,:GE615-IND-TIPO-PESSOA
            :GE615-IND-TIPO-PESSOA-NULO
            ,:GE615-IND-MOVIMENTO :GE615-IND-MOVIMENTO-NULO
            ,:GE615-IND-EVENTO :GE615-IND-EVENTO-NULO
            ,:GE615-DTA-INCLUSAO
            ,:GE615-STA-REGISTRO :GE615-STA-REGISTRO-NULO
            ,:GE615-COD-ORIGEM :GE615-COD-ORIGEM-NULO
            ,:GE615-COD-USUARIO
            ,:GE615-NOM-PROGRAMA :GE615-NOM-PROGRAMA-NULO
            , CURRENT TIMESTAMP
            )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SIUS.GE_PESSOA_VALIDA_LOG (NUM_CPF_CNPJ ,SEQ_REGISTRO ,NUM_RAMO_EMISSOR ,COD_PRODUTO ,COD_FONTE ,NUM_PROPOSTA ,NUM_CERTIFICADO_EXT ,NUM_APOLICE ,NUM_ENDOSSO ,NUM_SINISTRO ,OCORR_HISTORICO ,COD_OPER_SINISTRO ,NOM_SEGURADO ,COD_CARGO ,DES_CARGO ,NOM_ORGAO ,COD_RELACAO_EXTERNO ,IND_TP_RELAC_INTERNO ,IND_TIPO_PESSOA ,IND_MOVIMENTO ,IND_EVENTO ,DTA_INCLUSAO ,STA_REGISTRO ,COD_ORIGEM ,COD_USUARIO ,NOM_PROGRAMA ,DTH_CADASTRAMENTO ) VALUES ({FieldThreatment(this.GE615_NUM_CPF_CNPJ)} ,{FieldThreatment(this.GE615_SEQ_REGISTRO)} , {FieldThreatment((this.GE615_NUM_RAMO_EMISSOR_NULO?.ToInt() == -1 ? null : this.GE615_NUM_RAMO_EMISSOR))} , {FieldThreatment((this.GE615_COD_PRODUTO_NULO?.ToInt() == -1 ? null : this.GE615_COD_PRODUTO))} , {FieldThreatment((this.GE615_COD_FONTE_NULO?.ToInt() == -1 ? null : this.GE615_COD_FONTE))} , {FieldThreatment((this.GE615_NUM_PROPOSTA_NULO?.ToInt() == -1 ? null : this.GE615_NUM_PROPOSTA))} ,{FieldThreatment(this.GE615_NUM_CERTIFICADO_EXT)} ,{FieldThreatment(this.GE615_NUM_APOLICE)} ,{FieldThreatment(this.GE615_NUM_ENDOSSO)} ,{FieldThreatment(this.GE615_NUM_SINISTRO)} ,{FieldThreatment(this.GE615_OCORR_HISTORICO)} ,{FieldThreatment(this.GE615_COD_OPER_SINISTRO)} , {FieldThreatment((this.GE615_NOM_SEGURADO_NULO?.ToInt() == -1 ? null : this.GE615_NOM_SEGURADO))} ,{FieldThreatment(this.GE615_COD_CARGO)} ,{FieldThreatment(this.GE615_DES_CARGO)} ,{FieldThreatment(this.GE615_NOM_ORGAO)} ,{FieldThreatment(this.GE615_COD_RELACAO_EXTERNO)} , {FieldThreatment((this.GE615_IND_TP_RELAC_INT_NULO?.ToInt() == -1 ? null : this.GE615_IND_TP_RELAC_INTERNO))} , {FieldThreatment((this.GE615_IND_TIPO_PESSOA_NULO?.ToInt() == -1 ? null : this.GE615_IND_TIPO_PESSOA))} , {FieldThreatment((this.GE615_IND_MOVIMENTO_NULO?.ToInt() == -1 ? null : this.GE615_IND_MOVIMENTO))} , {FieldThreatment((this.GE615_IND_EVENTO_NULO?.ToInt() == -1 ? null : this.GE615_IND_EVENTO))} ,{FieldThreatment(this.GE615_DTA_INCLUSAO)} , {FieldThreatment((this.GE615_STA_REGISTRO_NULO?.ToInt() == -1 ? null : this.GE615_STA_REGISTRO))} , {FieldThreatment((this.GE615_COD_ORIGEM_NULO?.ToInt() == -1 ? null : this.GE615_COD_ORIGEM))} ,{FieldThreatment(this.GE615_COD_USUARIO)} , {FieldThreatment((this.GE615_NOM_PROGRAMA_NULO?.ToInt() == -1 ? null : this.GE615_NOM_PROGRAMA))} , CURRENT TIMESTAMP )";

            return query;
        }
        public string GE615_NUM_CPF_CNPJ { get; set; }
        public string GE615_SEQ_REGISTRO { get; set; }
        public string GE615_NUM_RAMO_EMISSOR { get; set; }
        public string GE615_NUM_RAMO_EMISSOR_NULO { get; set; }
        public string GE615_COD_PRODUTO { get; set; }
        public string GE615_COD_PRODUTO_NULO { get; set; }
        public string GE615_COD_FONTE { get; set; }
        public string GE615_COD_FONTE_NULO { get; set; }
        public string GE615_NUM_PROPOSTA { get; set; }
        public string GE615_NUM_PROPOSTA_NULO { get; set; }
        public string GE615_NUM_CERTIFICADO_EXT { get; set; }
        public string GE615_NUM_APOLICE { get; set; }
        public string GE615_NUM_ENDOSSO { get; set; }
        public string GE615_NUM_SINISTRO { get; set; }
        public string GE615_OCORR_HISTORICO { get; set; }
        public string GE615_COD_OPER_SINISTRO { get; set; }
        public string GE615_NOM_SEGURADO { get; set; }
        public string GE615_NOM_SEGURADO_NULO { get; set; }
        public string GE615_COD_CARGO { get; set; }
        public string GE615_DES_CARGO { get; set; }
        public string GE615_NOM_ORGAO { get; set; }
        public string GE615_COD_RELACAO_EXTERNO { get; set; }
        public string GE615_IND_TP_RELAC_INTERNO { get; set; }
        public string GE615_IND_TP_RELAC_INT_NULO { get; set; }
        public string GE615_IND_TIPO_PESSOA { get; set; }
        public string GE615_IND_TIPO_PESSOA_NULO { get; set; }
        public string GE615_IND_MOVIMENTO { get; set; }
        public string GE615_IND_MOVIMENTO_NULO { get; set; }
        public string GE615_IND_EVENTO { get; set; }
        public string GE615_IND_EVENTO_NULO { get; set; }
        public string GE615_DTA_INCLUSAO { get; set; }
        public string GE615_STA_REGISTRO { get; set; }
        public string GE615_STA_REGISTRO_NULO { get; set; }
        public string GE615_COD_ORIGEM { get; set; }
        public string GE615_COD_ORIGEM_NULO { get; set; }
        public string GE615_COD_USUARIO { get; set; }
        public string GE615_NOM_PROGRAMA { get; set; }
        public string GE615_NOM_PROGRAMA_NULO { get; set; }

        public static void Execute(R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1 r1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1)
        {
            var ths = r1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1200_00_INSERIR_DADOS_LOG_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}