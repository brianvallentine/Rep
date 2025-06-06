using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1 : QueryBasis<R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOL_SINISTRO, COD_CLIENTE
            INTO :SINIITEM-NUM-APOL-SINISTRO,
            :SINIITEM-COD-CLIENTE
            FROM SEGUROS.SINISTRO_ITEM
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOL_SINISTRO
							, COD_CLIENTE
											FROM SEGUROS.SINISTRO_ITEM
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINIITEM_NUM_APOL_SINISTRO { get; set; }
        public string SINIITEM_COD_CLIENTE { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1 Execute(R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1 r1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1)
        {
            var ths = r1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1500_ACESSO_SINISTRO_ITEM_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINIITEM_NUM_APOL_SINISTRO = result[i++].Value?.ToString();
            dta.SINIITEM_COD_CLIENTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}