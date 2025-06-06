using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0214B
{
    public class R100_PROCESSA_COBRANCA_DB_SELECT_1_Query1 : QueryBasis<R100_PROCESSA_COBRANCA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(H.VAL_OPERACAO,0),
            H.COD_PREST_SERVICO,
            H.COD_OPERACAO
            INTO :SINISHIS-VAL-OPERACAO,
            :SINISHIS-COD-PREST-SERVICO,
            :SINISHIS-COD-OPERACAO
            FROM SEGUROS.SINISTRO_HISTORICO H
            WHERE H.NUM_APOL_SINISTRO = :SI111-NUM-APOL-SINISTRO
            AND H.OCORR_HISTORICO = :SINISHIS-OCORR-HISTORICO
            AND H.COD_OPERACAO = 4260
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(H.VAL_OPERACAO
							,0)
							,
											H.COD_PREST_SERVICO
							,
											H.COD_OPERACAO
											FROM SEGUROS.SINISTRO_HISTORICO H
											WHERE H.NUM_APOL_SINISTRO = '{this.SI111_NUM_APOL_SINISTRO}'
											AND H.OCORR_HISTORICO = '{this.SINISHIS_OCORR_HISTORICO}'
											AND H.COD_OPERACAO = 4260
											WITH UR";

            return query;
        }
        public string SINISHIS_VAL_OPERACAO { get; set; }
        public string SINISHIS_COD_PREST_SERVICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SI111_NUM_APOL_SINISTRO { get; set; }

        public static R100_PROCESSA_COBRANCA_DB_SELECT_1_Query1 Execute(R100_PROCESSA_COBRANCA_DB_SELECT_1_Query1 r100_PROCESSA_COBRANCA_DB_SELECT_1_Query1)
        {
            var ths = r100_PROCESSA_COBRANCA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R100_PROCESSA_COBRANCA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R100_PROCESSA_COBRANCA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISHIS_VAL_OPERACAO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_PREST_SERVICO = result[i++].Value?.ToString();
            dta.SINISHIS_COD_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}