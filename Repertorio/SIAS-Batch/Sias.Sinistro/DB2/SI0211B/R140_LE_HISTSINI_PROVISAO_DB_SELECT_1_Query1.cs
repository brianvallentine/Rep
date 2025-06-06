using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0211B
{
    public class R140_LE_HISTSINI_PROVISAO_DB_SELECT_1_Query1 : QueryBasis<R140_LE_HISTSINI_PROVISAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT H.COD_EMPRESA ,
            H.TIPO_REGISTRO ,
            H.NUM_APOL_SINISTRO ,
            H.OCORR_HISTORICO ,
            H.COD_OPERACAO ,
            H.DATA_MOVIMENTO ,
            H.HORA_OPERACAO ,
            H.NOME_FAVORECIDO ,
            H.VAL_OPERACAO ,
            H.DATA_LIM_CORRECAO ,
            H.TIPO_FAVORECIDO ,
            H.DATA_NEGOCIADA ,
            H.FONTE_PAGAMENTO ,
            H.COD_PREST_SERVICO ,
            H.COD_SERVICO ,
            H.ORDEM_PAGAMENTO ,
            H.NUM_RECIBO ,
            H.NUM_MOV_SINISTRO ,
            H.COD_USUARIO ,
            H.SIT_CONTABIL ,
            H.SIT_REGISTRO ,
            H.TIMESTAMP ,
            H.NUM_APOLICE ,
            H.COD_PRODUTO ,
            H.NOM_PROGRAMA ,
            O.DES_OPERACAO ,
            O.IND_TIPO_FUNCAO ,
            O.FUNCAO_OPERACAO ,
            O.DES_ABREVIADA
            INTO :SINISHIS-COD-EMPRESA ,
            :SINISHIS-TIPO-REGISTRO ,
            :SINISHIS-NUM-APOL-SINISTRO,
            :SINISHIS-OCORR-HISTORICO,
            :SINISHIS-COD-OPERACAO,
            :SINISHIS-DATA-MOVIMENTO,
            :SINISHIS-HORA-OPERACAO,
            :SINISHIS-NOME-FAVORECIDO,
            :SINISHIS-VAL-OPERACAO,
            :SINISHIS-DATA-LIM-CORRECAO,
            :SINISHIS-TIPO-FAVORECIDO,
            :SINISHIS-DATA-NEGOCIADA,
            :SINISHIS-FONTE-PAGAMENTO,
            :SINISHIS-COD-PREST-SERVICO,
            :SINISHIS-COD-SERVICO,
            :SINISHIS-ORDEM-PAGAMENTO,
            :SINISHIS-NUM-RECIBO,
            :SINISHIS-NUM-MOV-SINISTRO,
            :SINISHIS-COD-USUARIO,
            :SINISHIS-SIT-CONTABIL,
            :SINISHIS-SIT-REGISTRO,
            :SINISHIS-TIMESTAMP,
            :SINISHIS-NUM-APOLICE,
            :SINISHIS-COD-PRODUTO,
            :SINISHIS-NOM-PROGRAMA,
            :GEOPERAC-DES-OPERACAO,
            :GEOPERAC-IND-TIPO-FUNCAO,
            :GEOPERAC-FUNCAO-OPERACAO,
            :GEOPERAC-DES-ABREVIADA
            FROM SEGUROS.SINISTRO_HISTORICO H,
            SEGUROS.GE_OPERACAO O
            WHERE H.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO
            AND H.OCORR_HISTORICO = :SI111-OCORR-HISTORICO
            AND H.COD_OPERACAO = :SI111-COD-OPERACAO
            AND O.COD_OPERACAO = H.COD_OPERACAO
            AND O.IDE_SISTEMA = 'SI'
            AND O.IND_TIPO_FUNCAO = 'RESSA-PRO'
            AND O.FUNCAO_OPERACAO = 'RSPPR'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT H.COD_EMPRESA 
							,
											H.TIPO_REGISTRO 
							,
											H.NUM_APOL_SINISTRO 
							,
											H.OCORR_HISTORICO 
							,
											H.COD_OPERACAO 
							,
											H.DATA_MOVIMENTO 
							,
											H.HORA_OPERACAO 
							,
											H.NOME_FAVORECIDO 
							,
											H.VAL_OPERACAO 
							,
											H.DATA_LIM_CORRECAO 
							,
											H.TIPO_FAVORECIDO 
							,
											H.DATA_NEGOCIADA 
							,
											H.FONTE_PAGAMENTO 
							,
											H.COD_PREST_SERVICO 
							,
											H.COD_SERVICO 
							,
											H.ORDEM_PAGAMENTO 
							,
											H.NUM_RECIBO 
							,
											H.NUM_MOV_SINISTRO 
							,
											H.COD_USUARIO 
							,
											H.SIT_CONTABIL 
							,
											H.SIT_REGISTRO 
							,
											H.TIMESTAMP 
							,
											H.NUM_APOLICE 
							,
											H.COD_PRODUTO 
							,
											H.NOM_PROGRAMA 
							,
											O.DES_OPERACAO 
							,
											O.IND_TIPO_FUNCAO 
							,
											O.FUNCAO_OPERACAO 
							,
											O.DES_ABREVIADA
											FROM SEGUROS.SINISTRO_HISTORICO H
							,
											SEGUROS.GE_OPERACAO O
											WHERE H.NUM_APOL_SINISTRO = '{this.SI111_NUM_APOL_SINISTRO}'
											AND H.OCORR_HISTORICO = '{this.SI111_OCORR_HISTORICO}'
											AND H.COD_OPERACAO = '{this.SI111_COD_OPERACAO}'
											AND O.COD_OPERACAO = H.COD_OPERACAO
											AND O.IDE_SISTEMA = 'SI'
											AND O.IND_TIPO_FUNCAO = 'RESSA-PRO'
											AND O.FUNCAO_OPERACAO = 'RSPPR'";

            return query;
        }
        public string SINISHIS_COD_EMPRESA { get; set; }
        public string SINISHIS_TIPO_REGISTRO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_HORA_OPERACAO { get; set; }
        public string SINISHIS_NOME_FAVORECIDO { get; set; }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_DATA_LIM_CORRECAO { get; set; }
        public string SINISHIS_TIPO_FAVORECIDO { get; set; }
        public string SINISHIS_DATA_NEGOCIADA { get; set; }
        public string SINISHIS_FONTE_PAGAMENTO { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }
        public string SINISHIS_COD_SERVICO { get; set; }
        public string SINISHIS_ORDEM_PAGAMENTO { get; set; }
        public string SINISHIS_NUM_RECIBO { get; set; }
        public string SINISHIS_NUM_MOV_SINISTRO { get; set; }
        public string SINISHIS_COD_USUARIO { get; set; }
        public string SINISHIS_SIT_CONTABIL { get; set; }
        public string SINISHIS_SIT_REGISTRO { get; set; }
        public string SINISHIS_TIMESTAMP { get; set; }
        public string SINISHIS_NUM_APOLICE { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }
        public string SINISHIS_NOM_PROGRAMA { get; set; }
        public string GEOPERAC_DES_OPERACAO { get; set; }
        public string GEOPERAC_IND_TIPO_FUNCAO { get; set; }
        public string GEOPERAC_FUNCAO_OPERACAO { get; set; }
        public string GEOPERAC_DES_ABREVIADA { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }
        public string SI111_OCORR_HISTORICO { get; set; }
        public string SI111_COD_OPERACAO { get; set; }

        public static R140_LE_HISTSINI_PROVISAO_DB_SELECT_1_Query1 Execute(R140_LE_HISTSINI_PROVISAO_DB_SELECT_1_Query1 r140_LE_HISTSINI_PROVISAO_DB_SELECT_1_Query1)
        {
            var ths = r140_LE_HISTSINI_PROVISAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R140_LE_HISTSINI_PROVISAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R140_LE_HISTSINI_PROVISAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_COD_EMPRESA = result[i++].Value?.ToString();
            dta.SINISHIS_TIPO_REGISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_OCORR_HISTORICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_MOVIMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_HORA_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_NOME_FAVORECIDO = result[i++].Value?.ToString();
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_LIM_CORRECAO = result[i++].Value?.ToString();
            dta.SINISHIS_TIPO_FAVORECIDO = result[i++].Value?.ToString();
            dta.SINISHIS_DATA_NEGOCIADA = result[i++].Value?.ToString();
            dta.SINISHIS_FONTE_PAGAMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PREST_SERVICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_SERVICO = result[i++].Value?.ToString();
            dta.SINISHIS_ORDEM_PAGAMENTO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_RECIBO = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_MOV_SINISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_USUARIO = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_CONTABIL = result[i++].Value?.ToString();
            dta.SINISHIS_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.SINISHIS_TIMESTAMP = result[i++].Value?.ToString();
            dta.SINISHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            dta.SINISHIS_NOM_PROGRAMA = result[i++].Value?.ToString();
            dta.GEOPERAC_DES_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_IND_TIPO_FUNCAO = result[i++].Value?.ToString();
            dta.GEOPERAC_FUNCAO_OPERACAO = result[i++].Value?.ToString();
            dta.GEOPERAC_DES_ABREVIADA = result[i++].Value?.ToString();
            return dta;
        }

    }
}