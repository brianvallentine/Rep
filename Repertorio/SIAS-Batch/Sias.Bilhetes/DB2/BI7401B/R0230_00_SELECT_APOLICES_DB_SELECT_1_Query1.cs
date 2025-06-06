using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI7401B
{
    public class R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1 : QueryBasis<R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_MODALIDADE
            ,COD_PRODUTO
            INTO :APOLICES-COD-MODALIDADE
            ,:APOLICES-COD-PRODUTO
            FROM SEGUROS.APOLICES
            WHERE NUM_BILHETE = :RELATORI-NUM-TITULO
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_MODALIDADE
											,COD_PRODUTO
											FROM SEGUROS.APOLICES
											WHERE NUM_BILHETE = '{this.RELATORI_NUM_TITULO}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string APOLICES_COD_MODALIDADE { get; set; }
        public string APOLICES_COD_PRODUTO { get; set; }
        public string RELATORI_NUM_TITULO { get; set; }

        public static R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1 Execute(R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1 r0230_00_SELECT_APOLICES_DB_SELECT_1_Query1)
        {
            var ths = r0230_00_SELECT_APOLICES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0230_00_SELECT_APOLICES_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_COD_MODALIDADE = result[i++].Value?.ToString();
            dta.APOLICES_COD_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}