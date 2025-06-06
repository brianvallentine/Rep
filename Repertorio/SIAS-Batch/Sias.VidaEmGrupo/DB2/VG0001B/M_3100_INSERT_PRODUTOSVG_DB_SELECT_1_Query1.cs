using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1 : QueryBasis<M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_PRODUTO
            INTO :PRODUTO-DESCR-PRODUTO
            FROM SEGUROS.PRODUTO
            WHERE COD_PRODUTO = :PRODUVG-COD-PRODUTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCR_PRODUTO
											FROM SEGUROS.PRODUTO
											WHERE COD_PRODUTO = '{this.PRODUVG_COD_PRODUTO}'
											WITH UR";

            return query;
        }
        public string PRODUTO_DESCR_PRODUTO { get; set; }
        public string PRODUVG_COD_PRODUTO { get; set; }

        public static M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1 Execute(M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1 m_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1)
        {
            var ths = m_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_3100_INSERT_PRODUTOSVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUTO_DESCR_PRODUTO = result[i++].Value?.ToString();
            return dta;
        }

    }
}