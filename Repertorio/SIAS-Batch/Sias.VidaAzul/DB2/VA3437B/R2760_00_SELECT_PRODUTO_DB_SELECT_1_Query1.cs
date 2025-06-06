using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3437B
{
    public class R2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_PRODUTO,
            COD_PRODUTO,
            NUM_PROCESSO_SUSEP
            INTO :PRODUTO-DESCR-PRODUTO,
            :PRODUTO-COD-PRODUTO,
            :PRODUTO-NUM-PROCESSO-SUSEP
            FROM SEGUROS.PRODUTO
            WHERE COD_PRODUTO = :PRODUVG-COD-PRODUTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCR_PRODUTO
							,
											COD_PRODUTO
							,
											NUM_PROCESSO_SUSEP
											FROM SEGUROS.PRODUTO
											WHERE COD_PRODUTO = '{this.PRODUVG_COD_PRODUTO}'
											WITH UR";

            return query;
        }
        public string PRODUTO_DESCR_PRODUTO { get; set; }
        public string PRODUTO_COD_PRODUTO { get; set; }
        public string PRODUTO_NUM_PROCESSO_SUSEP { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }

        public static R2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1 Execute(R2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1 r2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2760_00_SELECT_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTO_DESCR_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUTO_COD_PRODUTO = result[i++].Value?.ToString();
            dta.PRODUTO_NUM_PROCESSO_SUSEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}