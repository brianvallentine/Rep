using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0048B
{
    public class R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1 : QueryBasis<R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT GRUPO_CAUSAS,
            DESCR_CAUSA
            INTO :SINISCAU-GRUPO-CAUSAS,
            :SINISCAU-DESCR-CAUSA
            FROM SEGUROS.SINISTRO_CAUSA
            WHERE COD_CAUSA = :SINISMES-COD-CAUSA
            AND RAMO_EMISSOR = :SINISMES-RAMO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT GRUPO_CAUSAS
							,
											DESCR_CAUSA
											FROM SEGUROS.SINISTRO_CAUSA
											WHERE COD_CAUSA = '{this.SINISMES_COD_CAUSA}'
											AND RAMO_EMISSOR = '{this.SINISMES_RAMO}'
											WITH UR";

            return query;
        }
        public string SINISCAU_GRUPO_CAUSAS { get; set; }
        public string SINISCAU_DESCR_CAUSA { get; set; }
        public string SINISMES_COD_CAUSA { get; set; }
        public string SINISMES_RAMO { get; set; }

        public static R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1 Execute(R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1 r1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1)
        {
            var ths = r1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1100_00_BUSCA_SINISCAU_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISCAU_GRUPO_CAUSAS = result[i++].Value?.ToString();
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();
            return dta;
        }

    }
}