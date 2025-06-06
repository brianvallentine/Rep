using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1016_00_CONS_SEGURAVG_Query1 : QueryBasis<R1016_00_CONS_SEGURAVG_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO
            INTO :V0SEGV-SITUACAO
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            AND TIPO_SEGURADO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'
											AND TIPO_SEGURADO = '1'
											WITH UR";

            return query;
        }
        public string V0SEGV_SITUACAO { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1016_00_CONS_SEGURAVG_Query1 Execute(R1016_00_CONS_SEGURAVG_Query1 r1016_00_CONS_SEGURAVG_Query1)
        {
            var ths = r1016_00_CONS_SEGURAVG_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1016_00_CONS_SEGURAVG_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1016_00_CONS_SEGURAVG_Query1();
            var i = 0;
            dta.V0SEGV_SITUACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}