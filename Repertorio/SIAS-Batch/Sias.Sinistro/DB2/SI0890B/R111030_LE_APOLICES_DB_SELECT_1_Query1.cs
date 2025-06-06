using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0890B
{
    public class R111030_LE_APOLICES_DB_SELECT_1_Query1 : QueryBasis<R111030_LE_APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            RAMO_EMISSOR,
            COD_MODALIDADE
            INTO
            :APOLICES-RAMO-EMISSOR,
            :APOLICES-COD-MODALIDADE
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :APOLICES-NUM-APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											RAMO_EMISSOR
							,
											COD_MODALIDADE
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.APOLICES_NUM_APOLICE}'";

            return query;
        }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string APOLICES_NUM_APOLICE { get; set; }

        public static R111030_LE_APOLICES_DB_SELECT_1_Query1 Execute(R111030_LE_APOLICES_DB_SELECT_1_Query1 r111030_LE_APOLICES_DB_SELECT_1_Query1)
        {
            var ths = r111030_LE_APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R111030_LE_APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R111030_LE_APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            dta.APOLICES_COD_MODALIDADE = result[i++].Value?.ToString();
            return dta;
        }

    }
}