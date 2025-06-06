using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0094B
{
    public class R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1 : QueryBasis<R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            INTO :APOLICES-NUM-APOLICE
            FROM SEGUROS.APOLICES
            WHERE NUM_BILHETE = :APOLICES-NUM-BILHETE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											FROM SEGUROS.APOLICES
											WHERE NUM_BILHETE = '{this.APOLICES_NUM_BILHETE}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string APOLICES_NUM_APOLICE { get; set; }
        public string APOLICES_NUM_BILHETE { get; set; }

        public static R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1 Execute(R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1 r0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1)
        {
            var ths = r0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0260_00_SELECT_V0APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_NUM_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}