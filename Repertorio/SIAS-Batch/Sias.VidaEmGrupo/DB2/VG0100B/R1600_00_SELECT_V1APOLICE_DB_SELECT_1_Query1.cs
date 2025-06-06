using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0100B
{
    public class R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 : QueryBasis<R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            ORGAO,
            RAMO,
            MODALIDA
            INTO :V1APOL-ORGAO,
            :V1APOL-RAMO,
            :V1APOL-MODALIDA
            FROM SEGUROS.V1APOLICE
            WHERE NUM_APOLICE = :V1SOLF-NUM-APOL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											ORGAO
							,
											RAMO
							,
											MODALIDA
											FROM SEGUROS.V1APOLICE
											WHERE NUM_APOLICE = '{this.V1SOLF_NUM_APOL}'";

            return query;
        }
        public string V1APOL_ORGAO { get; set; }
        public string V1APOL_RAMO { get; set; }
        public string V1APOL_MODALIDA { get; set; }
        public string V1SOLF_NUM_APOL { get; set; }

        public static R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 Execute(R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 r1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1)
        {
            var ths = r1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_SELECT_V1APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1APOL_ORGAO = result[i++].Value?.ToString();
            dta.V1APOL_RAMO = result[i++].Value?.ToString();
            dta.V1APOL_MODALIDA = result[i++].Value?.ToString();
            return dta;
        }

    }
}