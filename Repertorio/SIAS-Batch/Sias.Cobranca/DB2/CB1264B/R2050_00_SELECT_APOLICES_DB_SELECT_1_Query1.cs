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
    public class R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1 : QueryBasis<R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            ORGAO_EMISSOR,
            RAMO_EMISSOR
            INTO
            :APOLICES-ORGAO-EMISSOR,
            :APOLICES-RAMO-EMISSOR
            FROM
            SEGUROS.APOLICES
            WHERE
            NUM_APOLICE = :CBAPOVIG-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											ORGAO_EMISSOR
							,
											RAMO_EMISSOR
											FROM
											SEGUROS.APOLICES
											WHERE
											NUM_APOLICE = '{this.CBAPOVIG_NUM_APOLICE}'";

            return query;
        }
        public string APOLICES_ORGAO_EMISSOR { get; set; }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string CBAPOVIG_NUM_APOLICE { get; set; }

        public static R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1 Execute(R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1 r2050_00_SELECT_APOLICES_DB_SELECT_1_Query1)
        {
            var ths = r2050_00_SELECT_APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2050_00_SELECT_APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_ORGAO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}