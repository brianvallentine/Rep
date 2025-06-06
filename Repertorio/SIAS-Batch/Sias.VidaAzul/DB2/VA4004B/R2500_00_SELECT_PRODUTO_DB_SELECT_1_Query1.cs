using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4004B
{
    public class R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1 : QueryBasis<R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOMPRODU
            INTO :V0PROD-NOMPRODU
            FROM SEGUROS.V0PRODUTOSVG
            WHERE NUM_APOLICE = :WHOST-APOLICE
            AND CODSUBES = :WHOST-CODSUBES
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOMPRODU
											FROM SEGUROS.V0PRODUTOSVG
											WHERE NUM_APOLICE = '{this.WHOST_APOLICE}'
											AND CODSUBES = '{this.WHOST_CODSUBES}'
											WITH UR";

            return query;
        }
        public string V0PROD_NOMPRODU { get; set; }
        public string WHOST_CODSUBES { get; set; }
        public string WHOST_APOLICE { get; set; }

        public static R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1 Execute(R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1 r2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1)
        {
            var ths = r2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2500_00_SELECT_PRODUTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROD_NOMPRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}