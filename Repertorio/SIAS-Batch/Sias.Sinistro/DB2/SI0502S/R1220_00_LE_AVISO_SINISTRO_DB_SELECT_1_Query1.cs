using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0502S
{
    public class R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1 : QueryBasis<R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_EMPRESA,
            TIPO_REGISTRO,
            DATA_LIM_CORRECAO,
            TIPO_FAVORECIDO,
            DATA_NEGOCIADA,
            FONTE_PAGAMENTO,
            COD_PREST_SERVICO,
            COD_SERVICO,
            ORDEM_PAGAMENTO,
            NUM_RECIBO,
            NUM_MOV_SINISTRO,
            COD_USUARIO,
            SIT_CONTABIL,
            NUM_APOLICE,
            COD_PRODUTO
            INTO :SINISHIS-COD-EMPRESA,
            :SINISHIS-TIPO-REGISTRO,
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
            :SINISHIS-NUM-APOLICE,
            :SINISHIS-COD-PRODUTO
            FROM SEGUROS.SINISTRO_HISTORICO
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND OCORR_HISTORICO = 1
            AND COD_OPERACAO = 101
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_EMPRESA
							,
											TIPO_REGISTRO
							,
											DATA_LIM_CORRECAO
							,
											TIPO_FAVORECIDO
							,
											DATA_NEGOCIADA
							,
											FONTE_PAGAMENTO
							,
											COD_PREST_SERVICO
							,
											COD_SERVICO
							,
											ORDEM_PAGAMENTO
							,
											NUM_RECIBO
							,
											NUM_MOV_SINISTRO
							,
											COD_USUARIO
							,
											SIT_CONTABIL
							,
											NUM_APOLICE
							,
											COD_PRODUTO
											FROM SEGUROS.SINISTRO_HISTORICO
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND OCORR_HISTORICO = 1
											AND COD_OPERACAO = 101";

            return query;
        }
        public string SINISHIS_COD_EMPRESA { get; set; }
        public string SINISHIS_TIPO_REGISTRO { get; set; }
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
        public string SINISHIS_NUM_APOLICE { get; set; }
        public string SINISHIS_COD_PRODUTO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1 Execute(R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1 r1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1)
        {
            var ths = r1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1220_00_LE_AVISO_SINISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_COD_EMPRESA = result[i++].Value?.ToString();
            dta.SINISHIS_TIPO_REGISTRO = result[i++].Value?.ToString();
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
            dta.SINISHIS_NUM_APOLICE = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}