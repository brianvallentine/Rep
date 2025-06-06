using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0403B
{
    public class R1100_00_MONTA_SORT_DB_SELECT_2_Query1 : QueryBasis<R1100_00_MONTA_SORT_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO
            INTO :V0CLIE-NOME-RAZAO
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V0PRVA-CODCLIEN
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0PRVA_CODCLIEN}'";

            return query;
        }
        public string V0CLIE_NOME_RAZAO { get; set; }
        public string V0PRVA_CODCLIEN { get; set; }

        public static R1100_00_MONTA_SORT_DB_SELECT_2_Query1 Execute(R1100_00_MONTA_SORT_DB_SELECT_2_Query1 r1100_00_MONTA_SORT_DB_SELECT_2_Query1)
        {
            var ths = r1100_00_MONTA_SORT_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_MONTA_SORT_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_MONTA_SORT_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0CLIE_NOME_RAZAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}