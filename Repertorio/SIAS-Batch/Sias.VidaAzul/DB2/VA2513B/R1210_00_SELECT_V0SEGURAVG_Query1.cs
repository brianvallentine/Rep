using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2513B
{
    public class R1210_00_SELECT_V0SEGURAVG_Query1 : QueryBasis<R1210_00_SELECT_V0SEGURAVG_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SIT_REGISTRO ,
            IDE_SEXO
            INTO :V0SEGV-SIT-REGISTRO ,
            :V0SEGV-IDE-SEXO
            FROM SEGUROS.V0SEGURAVG
            WHERE NUM_CERTIFICADO = :V0HIST-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIT_REGISTRO 
							,
											IDE_SEXO
											FROM SEGUROS.V0SEGURAVG
											WHERE NUM_CERTIFICADO = '{this.V0HIST_NRCERTIF}'";

            return query;
        }
        public string V0SEGV_SIT_REGISTRO { get; set; }
        public string V0SEGV_IDE_SEXO { get; set; }
        public string V0HIST_NRCERTIF { get; set; }

        public static R1210_00_SELECT_V0SEGURAVG_Query1 Execute(R1210_00_SELECT_V0SEGURAVG_Query1 r1210_00_SELECT_V0SEGURAVG_Query1)
        {
            var ths = r1210_00_SELECT_V0SEGURAVG_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1210_00_SELECT_V0SEGURAVG_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1210_00_SELECT_V0SEGURAVG_Query1();
            var i = 0;
            dta.V0SEGV_SIT_REGISTRO = result[i++].Value?.ToString();
            dta.V0SEGV_IDE_SEXO = result[i++].Value?.ToString();
            return dta;
        }

    }
}