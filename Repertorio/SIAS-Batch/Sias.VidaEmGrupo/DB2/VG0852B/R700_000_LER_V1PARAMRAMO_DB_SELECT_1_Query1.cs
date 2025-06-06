using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class R700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 : QueryBasis<R700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT RAMO_AP
            INTO :PARAMRAM-RAMO-AP
            FROM SEGUROS.PARAMETROS_RAMOS
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT RAMO_AP
											FROM SEGUROS.PARAMETROS_RAMOS
											WITH UR";

            return query;
        }
        public string PARAMRAM_RAMO_AP { get; set; }

        public static R700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 Execute(R700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 r700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1)
        {
            var ths = r700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R700_000_LER_V1PARAMRAMO_DB_SELECT_1_Query1();
            var i = 0;
            dta.PARAMRAM_RAMO_AP = result[i++].Value?.ToString();
            return dta;
        }

    }
}