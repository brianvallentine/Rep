using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9169B
{
    public class R1210_00_LE_SINISMES_DB_SELECT_1_Query1 : QueryBasis<R1210_00_LE_SINISMES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE,
            NUM_PROTOCOLO_SINI
            INTO :SINISMES-COD-FONTE,
            :SINISMES-NUM-PROTOCOLO-SINI
            FROM SEGUROS.SINISTRO_MESTRE
            WHERE NUM_APOL_SINISTRO = :SIARDEVC-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
							,
											NUM_PROTOCOLO_SINI
											FROM SEGUROS.SINISTRO_MESTRE
											WHERE NUM_APOL_SINISTRO = '{this.SIARDEVC_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINISMES_COD_FONTE { get; set; }
        public string SINISMES_NUM_PROTOCOLO_SINI { get; set; }
        public string SIARDEVC_NUM_APOL_SINISTRO { get; set; }

        public static R1210_00_LE_SINISMES_DB_SELECT_1_Query1 Execute(R1210_00_LE_SINISMES_DB_SELECT_1_Query1 r1210_00_LE_SINISMES_DB_SELECT_1_Query1)
        {
            var ths = r1210_00_LE_SINISMES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1210_00_LE_SINISMES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1210_00_LE_SINISMES_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISMES_COD_FONTE = result[i++].Value?.ToString();
            dta.SINISMES_NUM_PROTOCOLO_SINI = result[i++].Value?.ToString();
            return dta;
        }

    }
}