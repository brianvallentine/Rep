using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM8006B
{
    public class R2250_00_SELECT_APOLICES_DB_SELECT_1_Query1 : QueryBasis<R2250_00_SELECT_APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_PRODUTO
            INTO
            :APOLICES-COD-PRODUTO
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :MOVDEBCE-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_PRODUTO
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.MOVDEBCE_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOLICES_COD_PRODUTO { get; set; }
        public string MOVDEBCE_NUM_APOLICE { get; set; }

        public static R2250_00_SELECT_APOLICES_DB_SELECT_1_Query1 Execute(R2250_00_SELECT_APOLICES_DB_SELECT_1_Query1 r2250_00_SELECT_APOLICES_DB_SELECT_1_Query1)
        {
            var ths = r2250_00_SELECT_APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2250_00_SELECT_APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2250_00_SELECT_APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}