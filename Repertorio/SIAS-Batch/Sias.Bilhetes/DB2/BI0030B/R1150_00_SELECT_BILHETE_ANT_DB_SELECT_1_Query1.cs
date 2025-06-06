using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0030B
{
    public class R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1 : QueryBasis<R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :V0BILH-ANT-SITUACAO
            FROM SEGUROS.V0BILHETE
            WHERE NUMBIL = :V1BILH-NUM-APOL-ANT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V0BILHETE
											WHERE NUMBIL = '{this.V1BILH_NUM_APOL_ANT}'";

            return query;
        }
        public string V0BILH_ANT_SITUACAO { get; set; }
        public string V1BILH_NUM_APOL_ANT { get; set; }

        public static R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1 Execute(R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1 r1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1)
        {
            var ths = r1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1150_00_SELECT_BILHETE_ANT_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0BILH_ANT_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}