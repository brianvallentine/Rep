using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0050B
{
    public class R1300_SELECT_SUREG_DB_SELECT_1_Query1 : QueryBasis<R1300_SELECT_SUREG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_SUREG
            INTO :V0SURE-NOME-SUREG
            FROM SEGUROS.V0SUREG
            WHERE COD_SUREG = :V0FUNC-COD-SUREG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_SUREG
											FROM SEGUROS.V0SUREG
											WHERE COD_SUREG = '{this.V0FUNC_COD_SUREG}'";

            return query;
        }
        public string V0SURE_NOME_SUREG { get; set; }
        public string V0FUNC_COD_SUREG { get; set; }

        public static R1300_SELECT_SUREG_DB_SELECT_1_Query1 Execute(R1300_SELECT_SUREG_DB_SELECT_1_Query1 r1300_SELECT_SUREG_DB_SELECT_1_Query1)
        {
            var ths = r1300_SELECT_SUREG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_SELECT_SUREG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_SELECT_SUREG_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SURE_NOME_SUREG = result[i++].Value?.ToString();
            return dta;
        }

    }
}