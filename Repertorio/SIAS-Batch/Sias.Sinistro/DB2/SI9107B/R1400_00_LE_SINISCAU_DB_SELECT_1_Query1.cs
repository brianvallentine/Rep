using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9107B
{
    public class R1400_00_LE_SINISCAU_DB_SELECT_1_Query1 : QueryBasis<R1400_00_LE_SINISCAU_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT GRUPO_CAUSAS
            INTO :SINISCAU-GRUPO-CAUSAS
            FROM SEGUROS.SINISTRO_CAUSA
            WHERE RAMO_EMISSOR = :SINISCAU-RAMO-EMISSOR
            AND COD_CAUSA = :SINISCAU-COD-CAUSA
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT GRUPO_CAUSAS
											FROM SEGUROS.SINISTRO_CAUSA
											WHERE RAMO_EMISSOR = '{this.SINISCAU_RAMO_EMISSOR}'
											AND COD_CAUSA = '{this.SINISCAU_COD_CAUSA}'";

            return query;
        }
        public string SINISCAU_GRUPO_CAUSAS { get; set; }
        public string SINISCAU_RAMO_EMISSOR { get; set; }
        public string SINISCAU_COD_CAUSA { get; set; }

        public static R1400_00_LE_SINISCAU_DB_SELECT_1_Query1 Execute(R1400_00_LE_SINISCAU_DB_SELECT_1_Query1 r1400_00_LE_SINISCAU_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_LE_SINISCAU_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_LE_SINISCAU_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_LE_SINISCAU_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISCAU_GRUPO_CAUSAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}