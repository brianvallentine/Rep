using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0034B
{
    public class R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1 : QueryBasis<R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOVTO_DOCACO
            INTO :HOST-DATA-CARTA
            FROM SEGUROS.SI_DOCUMENTO_ACOMP
            WHERE NUM_CARTA = :SIDOCACO-NUM-CARTA
            AND COD_EVENTO = 2012
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_MOVTO_DOCACO
											FROM SEGUROS.SI_DOCUMENTO_ACOMP
											WHERE NUM_CARTA = '{this.SIDOCACO_NUM_CARTA}'
											AND COD_EVENTO = 2012";

            return query;
        }
        public string HOST_DATA_CARTA { get; set; }
        public string SIDOCACO_NUM_CARTA { get; set; }

        public static R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1 Execute(R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1 r3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1)
        {
            var ths = r3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3300_00_CARTA_ORIGINAL_DB_SELECT_2_Query1();
            var i = 0;
            dta.HOST_DATA_CARTA = result[i++].Value?.ToString();
            return dta;
        }

    }
}