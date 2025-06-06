using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0402B
{
    public class R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1 : QueryBasis<R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO
            INTO :V0SUBG-NOMSUB
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V0SUBG-CODCLIEN
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0SUBG_CODCLIEN}'";

            return query;
        }
        public string V0SUBG_NOMSUB { get; set; }
        public string V0SUBG_CODCLIEN { get; set; }

        public static R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1 Execute(R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1 r2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1)
        {
            var ths = r2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2400_00_IMPRIME_SUBESTIP_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0SUBG_NOMSUB = result[i++].Value?.ToString();
            return dta;
        }

    }
}