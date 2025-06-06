using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R1110_00_SELECT_RELATORI_Query1 : QueryBasis<R1110_00_SELECT_RELATORI_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT CODRELAT
            INTO :V0RELA-CODRELAT
            FROM SEGUROS.V0RELATORIOS
            WHERE NRCERTIF = :V0PROP-NRCERTIF
            AND CODRELAT = 'DECLINIO'
            AND SITUACAO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT CODRELAT
											FROM SEGUROS.V0RELATORIOS
											WHERE NRCERTIF = '{this.V0PROP_NRCERTIF}'
											AND CODRELAT = 'DECLINIO'
											AND SITUACAO = '1'
											WITH UR";

            return query;
        }
        public string V0RELA_CODRELAT { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1110_00_SELECT_RELATORI_Query1 Execute(R1110_00_SELECT_RELATORI_Query1 r1110_00_SELECT_RELATORI_Query1)
        {
            var ths = r1110_00_SELECT_RELATORI_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1110_00_SELECT_RELATORI_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1110_00_SELECT_RELATORI_Query1();
            var i = 0;
            dta.V0RELA_CODRELAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}