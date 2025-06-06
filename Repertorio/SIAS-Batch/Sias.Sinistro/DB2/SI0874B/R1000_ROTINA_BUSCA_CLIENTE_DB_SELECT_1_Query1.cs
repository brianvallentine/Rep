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
    public class R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1 : QueryBasis<R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_EMISSOR
            INTO :APOLICES-RAMO-EMISSOR
            FROM SEGUROS.APOLICES
            WHERE NUM_APOLICE = :SINISMES-NUM-APOLICE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_EMISSOR
											FROM SEGUROS.APOLICES
											WHERE NUM_APOLICE = '{this.SINISMES_NUM_APOLICE}'
											WITH UR";

            return query;
        }
        public string APOLICES_RAMO_EMISSOR { get; set; }
        public string SINISMES_NUM_APOLICE { get; set; }

        public static R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1 Execute(R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1 r1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = r1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_ROTINA_BUSCA_CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLICES_RAMO_EMISSOR = result[i++].Value?.ToString();
            return dta;
        }

    }
}