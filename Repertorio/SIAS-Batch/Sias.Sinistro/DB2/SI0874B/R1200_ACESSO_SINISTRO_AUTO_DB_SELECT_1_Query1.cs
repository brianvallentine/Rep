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
    public class R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1 : QueryBasis<R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_ITEM
            INTO :SINISAUT-NUM-ITEM
            FROM SEGUROS.SINISTRO_AUTO1
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_ITEM
											FROM SEGUROS.SINISTRO_AUTO1
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											WITH UR";

            return query;
        }
        public string SINISAUT_NUM_ITEM { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1 Execute(R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1 r1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1)
        {
            var ths = r1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_ACESSO_SINISTRO_AUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISAUT_NUM_ITEM = result[i++].Value?.ToString();
            return dta;
        }

    }
}