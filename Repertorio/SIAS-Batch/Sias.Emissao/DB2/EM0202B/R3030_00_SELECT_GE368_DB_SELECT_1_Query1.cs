using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R3030_00_SELECT_GE368_DB_SELECT_1_Query1 : QueryBasis<R3030_00_SELECT_GE368_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DISTINCT NUM_PESSOA
            INTO :GE368-NUM-PESSOA
            FROM SEGUROS.GE_LEG_PESS_EVENTO
            WHERE NUM_OCORR_MOVTO = :CB041-NUM-OCORR-MOVTO
            ORDER BY NUM_PESSOA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DISTINCT NUM_PESSOA
											FROM SEGUROS.GE_LEG_PESS_EVENTO
											WHERE NUM_OCORR_MOVTO = '{this.CB041_NUM_OCORR_MOVTO}'
											ORDER BY NUM_PESSOA";

            return query;
        }
        public string GE368_NUM_PESSOA { get; set; }
        public string CB041_NUM_OCORR_MOVTO { get; set; }

        public static R3030_00_SELECT_GE368_DB_SELECT_1_Query1 Execute(R3030_00_SELECT_GE368_DB_SELECT_1_Query1 r3030_00_SELECT_GE368_DB_SELECT_1_Query1)
        {
            var ths = r3030_00_SELECT_GE368_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3030_00_SELECT_GE368_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3030_00_SELECT_GE368_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE368_NUM_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}