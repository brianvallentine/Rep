using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0048B
{
    public class R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1 : QueryBasis<R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CLIENTE
            INTO :SINIITEM-COD-CLIENTE
            FROM SEGUROS.SINISTRO_ITEM
            WHERE NUM_APOL_SINISTRO = :SINISMES-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CLIENTE
											FROM SEGUROS.SINISTRO_ITEM
											WHERE NUM_APOL_SINISTRO = '{this.SINISMES_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINIITEM_COD_CLIENTE { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1 Execute(R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1 r2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1)
        {
            var ths = r2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2220_00_ACESSA_SINIITEM_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINIITEM_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}