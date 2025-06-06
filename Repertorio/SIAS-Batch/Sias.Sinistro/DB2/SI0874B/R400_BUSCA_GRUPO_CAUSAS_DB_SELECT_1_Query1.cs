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
    public class R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1 : QueryBasis<R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DESCR_CAUSA,
            GRUPO_CAUSAS
            INTO :SINISCAU-DESCR-CAUSA,
            :SINISCAU-GRUPO-CAUSAS
            FROM SEGUROS.SINISTRO_CAUSA
            WHERE RAMO_EMISSOR = :SINISMES-RAMO
            AND COD_CAUSA = :HOST-COD-CAUSA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DESCR_CAUSA
							,
											GRUPO_CAUSAS
											FROM SEGUROS.SINISTRO_CAUSA
											WHERE RAMO_EMISSOR = '{this.SINISMES_RAMO}'
											AND COD_CAUSA = '{this.HOST_COD_CAUSA}'";

            return query;
        }
        public string SINISCAU_DESCR_CAUSA { get; set; }
        public string SINISCAU_GRUPO_CAUSAS { get; set; }
        public string HOST_COD_CAUSA { get; set; }
        public string SINISMES_RAMO { get; set; }

        public static R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1 Execute(R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1 r400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1)
        {
            var ths = r400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R400_BUSCA_GRUPO_CAUSAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISCAU_DESCR_CAUSA = result[i++].Value?.ToString();
            dta.SINISCAU_GRUPO_CAUSAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}