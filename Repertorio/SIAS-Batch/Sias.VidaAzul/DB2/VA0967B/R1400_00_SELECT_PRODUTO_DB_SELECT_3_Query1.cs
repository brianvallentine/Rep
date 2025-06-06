using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0967B
{
    public class R1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1 : QueryBasis<R1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            COD_PRODUTO ,
            DESCR_PRODUTO
            INTO
            :PRODUTO-COD-PRODUTO ,
            :PRODUTO-DESCR-PRODUTO
            FROM
            SEGUROS.PRODUTO
            WHERE
            COD_PRODUTO = :APOLICES-COD-PRODUTO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											COD_PRODUTO 
							,
											DESCR_PRODUTO
											FROM
											SEGUROS.PRODUTO
											WHERE
											COD_PRODUTO = '{this.APOLICES_COD_PRODUTO}'";

            return query;
        }
        public string PRODUTO_COD_PRODUTO { get; set; }
        public string PRODUTO_DESCR_PRODUTO { get; set; }
        public string APOLICES_COD_PRODUTO { get; set; }

        public static R1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1 Execute(R1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1 r1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1)
        {
            var ths = r1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SELECT_PRODUTO_DB_SELECT_3_Query1();
            var i = 0;
            dta.PRODUTO_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUTO_DESCR_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}