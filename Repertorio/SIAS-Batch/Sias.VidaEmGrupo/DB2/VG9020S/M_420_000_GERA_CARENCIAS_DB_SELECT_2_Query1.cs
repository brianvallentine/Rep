using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9020S
{
    public class M_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1 : QueryBasis<M_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_NASCIMENTO
            INTO :CLIE-DTNASC:WDATA-NASC
            FROM SEGUROS.V0CLIENTE
            WHERE COD_CLIENTE = :MCOD-CLIENTE
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATA_NASCIMENTO
											FROM SEGUROS.V0CLIENTE
											WHERE COD_CLIENTE = '{this.MCOD_CLIENTE}'
											WITH UR";

            return query;
        }
        public string CLIE_DTNASC { get; set; }
        public string WDATA_NASC { get; set; }
        public string MCOD_CLIENTE { get; set; }

        public static M_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1 Execute(M_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1 m_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1)
        {
            var ths = m_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_420_000_GERA_CARENCIAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.CLIE_DTNASC = result[i++].Value?.ToString();
            dta.WDATA_NASC = string.IsNullOrWhiteSpace(dta.CLIE_DTNASC) ? "-1" : "0";
            return dta;
        }

    }
}