using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0139B
{
    public class R0700_10_10C1_DB_SELECT_8_Query1 : QueryBasis<R0700_10_10C1_DB_SELECT_8_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_GRUPO_SUSEP
            INTO :VG080-COD-GRUPO-SUSEP
            FROM SEGUROS.VG_PARAM_RAMO_CONJ
            WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE
            AND COD_SUBGRUPO = +0
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_GRUPO_SUSEP
											FROM SEGUROS.VG_PARAM_RAMO_CONJ
											WHERE NUM_APOLICE = '{this.V0ENDO_NUM_APOLICE}'
											AND COD_SUBGRUPO = +0";

            return query;
        }
        public string VG080_COD_GRUPO_SUSEP { get; set; }
        public string V0ENDO_NUM_APOLICE { get; set; }

        public static R0700_10_10C1_DB_SELECT_8_Query1 Execute(R0700_10_10C1_DB_SELECT_8_Query1 r0700_10_10C1_DB_SELECT_8_Query1)
        {
            var ths = r0700_10_10C1_DB_SELECT_8_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0700_10_10C1_DB_SELECT_8_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0700_10_10C1_DB_SELECT_8_Query1();
            var i = 0;
            dta.VG080_COD_GRUPO_SUSEP = result[i++].Value?.ToString();
            return dta;
        }

    }
}