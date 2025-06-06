using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R7000_JV1_BUSCA_RAMO_DB_SELECT_1_Query1 : QueryBasis<R7000_JV1_BUSCA_RAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_EMISSOR
            INTO :PRODUTO-RAMO-EMISSOR
            FROM SEGUROS.PRODUTO
            WHERE COD_PRODUTO = :PRODUTO-COD-PRODUTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_EMISSOR
											FROM SEGUROS.PRODUTO
											WHERE COD_PRODUTO = '{this.PRODUTO_COD_PRODUTO}'
											WITH UR";

            return query;
        }
        public string PRODUTO_RAMO_EMISSOR { get; set; }
        public string PRODUTO_COD_PRODUTO { get; set; }

        public static R7000_JV1_BUSCA_RAMO_DB_SELECT_1_Query1 Execute(R7000_JV1_BUSCA_RAMO_DB_SELECT_1_Query1 r7000_JV1_BUSCA_RAMO_DB_SELECT_1_Query1)
        {
            var ths = r7000_JV1_BUSCA_RAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R7000_JV1_BUSCA_RAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R7000_JV1_BUSCA_RAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTO_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}