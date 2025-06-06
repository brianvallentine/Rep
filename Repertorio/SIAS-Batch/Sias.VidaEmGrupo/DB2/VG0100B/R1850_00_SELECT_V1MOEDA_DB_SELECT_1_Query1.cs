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
    public class R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 : QueryBasis<R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            CODUNIMO,
            VLCRUZAD
            INTO :V1MOED-CODUNIMO,
            :V1MOED-VLCRUZAD
            FROM SEGUROS.V1MOEDA
            WHERE TIPO_MOEDA = '0'
            AND SITUACAO = '0'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											CODUNIMO
							,
											VLCRUZAD
											FROM SEGUROS.V1MOEDA
											WHERE TIPO_MOEDA = '0'
											AND SITUACAO = '0'";

            return query;
        }
        public string V1MOED_CODUNIMO { get; set; }
        public string V1MOED_VLCRUZAD { get; set; }

        public static R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 Execute(R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 r1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1)
        {
            var ths = r1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1850_00_SELECT_V1MOEDA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1MOED_CODUNIMO = result[i++].Value?.ToString();
            dta.V1MOED_VLCRUZAD = result[i++].Value?.ToString();
            return dta;
        }

    }
}