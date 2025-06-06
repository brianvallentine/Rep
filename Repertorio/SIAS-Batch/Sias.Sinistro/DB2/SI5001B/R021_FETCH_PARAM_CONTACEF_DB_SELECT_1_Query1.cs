using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5001B
{
    public class R021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1 : QueryBasis<R021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT COD_CONVENIO,
            DESCR_CONVENIO
            INTO :PARAMCON-COD-CONVENIO,
            :PARAMCON-DESCR-CONVENIO
            FROM SEGUROS.PARAM_CONTACEF
            WHERE TIPO_MOVTO_CC = 1
            AND COD_CONVENIO = :HOST-COD-CONVENIO
            ORDER BY COD_CONVENIO,
            DESCR_CONVENIO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DISTINCT COD_CONVENIO
							,
											DESCR_CONVENIO
											FROM SEGUROS.PARAM_CONTACEF
											WHERE TIPO_MOVTO_CC = 1
											AND COD_CONVENIO = '{this.HOST_COD_CONVENIO}'
											ORDER BY COD_CONVENIO
							,
											DESCR_CONVENIO";

            return query;
        }
        public string PARAMCON_COD_CONVENIO { get; set; }
        public string PARAMCON_DESCR_CONVENIO { get; set; }
        public string HOST_COD_CONVENIO { get; set; }

        public static R021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1 Execute(R021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1 r021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1)
        {
            var ths = r021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R021_FETCH_PARAM_CONTACEF_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAMCON_COD_CONVENIO = result[i++].Value?.ToString();
            dta.PARAMCON_DESCR_CONVENIO = result[i++].Value?.ToString();
            return dta;
        }

    }
}