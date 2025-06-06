using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1264B
{
    public class R1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE(COUNT(*),+0)
            INTO
            :WS-HOST-QTD-SINISTROS
            FROM
            SEGUROS.SINISTRO_MESTRE
            WHERE
            NUM_APOLICE = :CBAPOVIG-NUM-APOLICE
            AND SIT_REGISTRO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											VALUE(COUNT(*)
							,+0)
											FROM
											SEGUROS.SINISTRO_MESTRE
											WHERE
											NUM_APOLICE = '{this.CBAPOVIG_NUM_APOLICE}'
											AND SIT_REGISTRO = '0'";

            return query;
        }
        public string WS_HOST_QTD_SINISTROS { get; set; }
        public string CBAPOVIG_NUM_APOLICE { get; set; }

        public static R1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1 r1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_SINISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_HOST_QTD_SINISTROS = result[i++].Value?.ToString();
            return dta;
        }

    }
}