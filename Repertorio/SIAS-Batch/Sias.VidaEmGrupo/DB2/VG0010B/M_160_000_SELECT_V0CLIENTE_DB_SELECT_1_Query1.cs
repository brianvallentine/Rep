using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1 : QueryBasis<M_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            DATA_NASCIMENTO
            INTO
            :CDATA-NASCIMENTO:CWDATA-NASCIMENTO
            FROM
            SEGUROS.V0CLIENTE
            WHERE
            COD_CLIENTE = :MCOD-CLIENTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DATA_NASCIMENTO
											FROM
											SEGUROS.V0CLIENTE
											WHERE
											COD_CLIENTE = '{this.MCOD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CDATA_NASCIMENTO { get; set; }
        public string CWDATA_NASCIMENTO { get; set; }
        public string MCOD_CLIENTE { get; set; }

        public static M_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1 Execute(M_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1 m_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1)
        {
            var ths = m_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_160_000_SELECT_V0CLIENTE_DB_SELECT_1_Query1();
            var i = 0;
            dta.CDATA_NASCIMENTO = result[i++].Value?.ToString();
            dta.CWDATA_NASCIMENTO = string.IsNullOrWhiteSpace(dta.CDATA_NASCIMENTO) ? "-1" : "0";
            return dta;
        }

    }
}