using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1 : QueryBasis<R1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_PESSOA
            INTO :PESSOA-COD-PESSOA
            FROM SEGUROS.PESSOA_FISICA
            WHERE CPF = :PESSOFIS-CPF
            ORDER BY COD_PESSOA DESC
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_PESSOA
											FROM SEGUROS.PESSOA_FISICA
											WHERE CPF = '{this.PESSOFIS_CPF}'
											ORDER BY COD_PESSOA DESC
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string PESSOFIS_CPF { get; set; }

        public static R1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1 Execute(R1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1 r1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1)
        {
            var ths = r1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_00_SELECT_PESSOFIS_DB_SELECT_1_Query1();
            var i = 0;
            dta.PESSOA_COD_PESSOA = result[i++].Value?.ToString();
            return dta;
        }

    }
}