using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9211B
{
    public class R1060_00_LE_CAUSA_DB_SELECT_1_Query1 : QueryBasis<R1060_00_LE_CAUSA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT GRUPO_CAUSAS
            INTO :SINISCAU-GRUPO-CAUSAS
            FROM SEGUROS.SINISTRO_CAUSA
            WHERE RAMO_EMISSOR = :SIARDEVC-COD-RAMO
            AND COD_CAUSA = :SIARDEVC-COD-CAUSA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT GRUPO_CAUSAS
											FROM SEGUROS.SINISTRO_CAUSA
											WHERE RAMO_EMISSOR = '{this.SIARDEVC_COD_RAMO}'
											AND COD_CAUSA = '{this.SIARDEVC_COD_CAUSA}'";

            return query;
        }
        public string SINISCAU_GRUPO_CAUSAS { get; set; }
        public string SIARDEVC_COD_CAUSA { get; set; }
        public string SIARDEVC_COD_RAMO { get; set; }

        public static R1060_00_LE_CAUSA_DB_SELECT_1_Query1 Execute(R1060_00_LE_CAUSA_DB_SELECT_1_Query1 r1060_00_LE_CAUSA_DB_SELECT_1_Query1)
        {
            var ths = r1060_00_LE_CAUSA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1060_00_LE_CAUSA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1060_00_LE_CAUSA_DB_SELECT_1_Query1();
            var i = 0;
            dta.SINISCAU_GRUPO_CAUSAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}