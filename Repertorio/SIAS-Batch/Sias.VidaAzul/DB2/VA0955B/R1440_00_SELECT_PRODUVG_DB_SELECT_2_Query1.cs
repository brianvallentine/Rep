using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0955B
{
    public class R1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1 : QueryBasis<R1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            DESCR_PRODUTO
            INTO :PRODUVG-NOME-PRODUTO
            FROM SEGUROS.PRODUTO
            WHERE COD_PRODUTO = :WHOST-COD-PRODUTO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT
											DESCR_PRODUTO
											FROM SEGUROS.PRODUTO
											WHERE COD_PRODUTO = '{this.WHOST_COD_PRODUTO}'";

            return query;
        }
        public string PRODUVG_NOME_PRODUTO { get; set; }
        public string WHOST_COD_PRODUTO { get; set; }

        public static R1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1 Execute(R1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1 r1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1)
        {
            var ths = r1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1440_00_SELECT_PRODUVG_DB_SELECT_2_Query1();
            var i = 0;
            dta.PRODUVG_NOME_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}