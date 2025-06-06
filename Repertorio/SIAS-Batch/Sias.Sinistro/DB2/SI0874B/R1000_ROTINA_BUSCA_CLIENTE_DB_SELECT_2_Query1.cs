using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1 : QueryBasis<R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),0)
            INTO :HOST-COUNT
            FROM SEGUROS.BILHETE
            WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,0)
											FROM SEGUROS.BILHETE
											WHERE NUM_APOLICE = '{this.SINISMES_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string HOST_COUNT { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }

        public static R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1 Execute(R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1 r1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1)
        {
            var ths = r1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_2_Query1();
            var i = 0;
            dta.HOST_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}