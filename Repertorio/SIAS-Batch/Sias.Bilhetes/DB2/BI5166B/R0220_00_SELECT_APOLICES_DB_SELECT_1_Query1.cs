using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI5166B
{
    public class R0220_00_SELECT_APOLICES_DB_SELECT_1_Query1 : QueryBasis<R0220_00_SELECT_APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_APOLICE
            INTO :APOLICES-NUM-APOLICE
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :BILHETE-NUM-APOLICE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_APOLICE
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.BILHETE_NUM_APOLICE}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string APOLICES_NUM_APOLICE { get; set; }
        public string BILHETE_NUM_APOLICE { get; set; }

        public static R0220_00_SELECT_APOLICES_DB_SELECT_1_Query1 Execute(R0220_00_SELECT_APOLICES_DB_SELECT_1_Query1 r0220_00_SELECT_APOLICES_DB_SELECT_1_Query1)
        {
            var ths = r0220_00_SELECT_APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0220_00_SELECT_APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0220_00_SELECT_APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_NUM_APOLICE = result[i++].Value?.ToString();
            return dta;
        }

    }
}