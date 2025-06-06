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
    public class R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SITUACAO
            INTO :V1CREN-SITUACAO
            FROM SEGUROS.V1CONT_RENO_BIL
            WHERE NUMBIL = :V1BILH-NUMBIL
            AND SITUACAO <> '*'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SITUACAO
											FROM SEGUROS.V1CONT_RENO_BIL
											WHERE NUMBIL = '{this.V1BILH_NUMBIL}'
											AND SITUACAO <> '*'";

            return query;
        }
        public string V1CREN_SITUACAO { get; set; }
        public string V1BILH_NUMBIL { get; set; }

        public static R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1 r1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_CONT_REN_BIL_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1CREN_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}