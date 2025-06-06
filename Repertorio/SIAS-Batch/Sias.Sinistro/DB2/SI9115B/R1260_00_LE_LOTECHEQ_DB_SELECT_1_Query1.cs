using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9115B
{
    public class R1260_00_LE_LOTECHEQ_DB_SELECT_1_Query1 : QueryBasis<R1260_00_LE_LOTECHEQ_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SERIE_CHEQUE
            INTO :LOTECHEQ-SERIE-CHEQUE
            FROM SEGUROS.LOTE_CHEQUES
            WHERE NUM_CHEQUE_INTERNO =
            :SIARDEVC-NUM-CHEQUE-INTERNO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SERIE_CHEQUE
											FROM SEGUROS.LOTE_CHEQUES
											WHERE NUM_CHEQUE_INTERNO =
											'{this.SIARDEVC_NUM_CHEQUE_INTERNO}'";

            return query;
        }
        public string LOTECHEQ_SERIE_CHEQUE { get; set; }
        public string SIARDEVC_NUM_CHEQUE_INTERNO { get; set; }

        public static R1260_00_LE_LOTECHEQ_DB_SELECT_1_Query1 Execute(R1260_00_LE_LOTECHEQ_DB_SELECT_1_Query1 r1260_00_LE_LOTECHEQ_DB_SELECT_1_Query1)
        {
            var ths = r1260_00_LE_LOTECHEQ_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1260_00_LE_LOTECHEQ_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1260_00_LE_LOTECHEQ_DB_SELECT_1_Query1();
            var i = 0;
            dta.LOTECHEQ_SERIE_CHEQUE = result[i++].Value?.ToString();
            return dta;
        }

    }
}