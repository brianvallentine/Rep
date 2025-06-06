using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0282B
{
    public class R2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 : QueryBasis<R2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODCLIEN
            INTO :V1APOL-CODCLIEN
            FROM SEGUROS.V0APOLICE
            WHERE NUM_APOLICE = :V1RELA-NUM-APOL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODCLIEN
											FROM SEGUROS.V0APOLICE
											WHERE NUM_APOLICE = '{this.V1RELA_NUM_APOL}'";

            return query;
        }
        public string V1APOL_CODCLIEN { get; set; }
        public string V1RELA_NUM_APOL { get; set; }

        public static R2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 Execute(R2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 r2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2100_00_SELECT_V1APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1APOL_CODCLIEN = result[i++].Value?.ToString();
            return dta;
        }

    }
}