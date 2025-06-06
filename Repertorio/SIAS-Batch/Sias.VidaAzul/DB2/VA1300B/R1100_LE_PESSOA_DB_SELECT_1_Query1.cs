using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1300B
{
    public class R1100_LE_PESSOA_DB_SELECT_1_Query1 : QueryBasis<R1100_LE_PESSOA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PESSOA ,
            IND_PESSOA
            INTO :OD001-NUM-PESSOA ,
            :OD001-IND-PESSOA
            FROM ODS.OD_PESSOA
            WHERE NUM_PESSOA = :GE368-NUM-PESSOA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PESSOA 
							,
											IND_PESSOA
											FROM ODS.OD_PESSOA
											WHERE NUM_PESSOA = '{this.GE368_NUM_PESSOA}'";

            return query;
        }
        public string OD001_NUM_PESSOA { get; set; }
        public string OD001_IND_PESSOA { get; set; }
        public string GE368_NUM_PESSOA { get; set; }

        public static R1100_LE_PESSOA_DB_SELECT_1_Query1 Execute(R1100_LE_PESSOA_DB_SELECT_1_Query1 r1100_LE_PESSOA_DB_SELECT_1_Query1)
        {
            var ths = r1100_LE_PESSOA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_LE_PESSOA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_LE_PESSOA_DB_SELECT_1_Query1();
            var i = 0;
            dta.OD001_NUM_PESSOA = result[i++].Value?.ToString();
            dta.OD001_IND_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}