using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0844B
{
    public class R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 : QueryBasis<R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME
            INTO :V1APOL-NOME
            FROM SEGUROS.V1APOLICE
            WHERE NUM_APOLICE = :V1MSIN-NUM-APOL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME
											FROM SEGUROS.V1APOLICE
											WHERE NUM_APOLICE = '{this.V1MSIN_NUM_APOL}'";

            return query;
        }
        public string V1APOL_NOME { get; set; }
        public string V1MSIN_NUM_APOL { get; set; }

        public static R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 Execute(R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 r2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_SELECT_V1APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1APOL_NOME = result[i++].Value?.ToString();
            return dta;
        }

    }
}