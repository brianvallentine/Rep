using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0952B
{
    public class R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOME_RAZAO,
            CGCCPF
            INTO :V0CLIE-NOME-RAZAO,
            :V0CLIE-CGCCPF
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :V0PROP-CODCLIEN
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOME_RAZAO
							,
											CGCCPF
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.V0PROP_CODCLIEN}'";

            return query;
        }
        public string V0CLIE_NOME_RAZAO { get; set; }
        public string V0CLIE_CGCCPF { get; set; }
        public string V0PROP_CODCLIEN { get; set; }

        public static R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 Execute(R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 r1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_SELECT_V0CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CLIE_NOME_RAZAO = result[i++].Value?.ToString();
            dta.V0CLIE_CGCCPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}