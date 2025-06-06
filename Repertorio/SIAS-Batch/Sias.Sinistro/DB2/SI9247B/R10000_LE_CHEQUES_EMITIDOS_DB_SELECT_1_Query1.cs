using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9247B
{
    public class R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1 : QueryBasis<R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.NUM_CHEQUE_INTERNO,
            B.TIPO_PAGAMENTO,
            B.DATA_EMISSAO
            INTO :SISINCHE-NUM-CHEQUE-INTERNO,
            :CHEQUEMI-TIPO-PAGAMENTO,
            :CHEQUEMI-DATA-EMISSAO:IND-DATA-EMISSAO
            FROM SEGUROS.SI_SINI_CHEQUE A,
            SEGUROS.CHEQUES_EMITIDOS B
            WHERE A.NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO
            AND A.OCORR_HISTORICO = :SIARDEVC-OCORR-HISTORICO
            AND B.NUM_CHEQUE_INTERNO = A.NUM_CHEQUE_INTERNO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.NUM_CHEQUE_INTERNO
							,
											B.TIPO_PAGAMENTO
							,
											B.DATA_EMISSAO
											FROM SEGUROS.SI_SINI_CHEQUE A
							,
											SEGUROS.CHEQUES_EMITIDOS B
											WHERE A.NUM_APOL_SINISTRO = '{this.SIARDEVC_NUM_APOL_SINISTRO}'
											AND A.OCORR_HISTORICO = '{this.SIARDEVC_OCORR_HISTORICO}'
											AND B.NUM_CHEQUE_INTERNO = A.NUM_CHEQUE_INTERNO";

            return query;
        }
        public string SISINCHE_NUM_CHEQUE_INTERNO { get; set; }
        public string CHEQUEMI_TIPO_PAGAMENTO { get; set; }
        public string CHEQUEMI_DATA_EMISSAO { get; set; }
        public string IND_DATA_EMISSAO { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }
        public string SIARDEVC_OCORR_HISTORICO { get; set; }

        public static R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1 Execute(R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1 r10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1)
        {
            var ths = r10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R10000_LE_CHEQUES_EMITIDOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SISINCHE_NUM_CHEQUE_INTERNO = result[i++].Value?.ToString();
            dta.CHEQUEMI_TIPO_PAGAMENTO = result[i++].Value?.ToString();
            dta.CHEQUEMI_DATA_EMISSAO = result[i++].Value?.ToString();
            dta.IND_DATA_EMISSAO = string.IsNullOrWhiteSpace(dta.CHEQUEMI_DATA_EMISSAO) ? "-1" : "0";
            return dta;
        }

    }
}