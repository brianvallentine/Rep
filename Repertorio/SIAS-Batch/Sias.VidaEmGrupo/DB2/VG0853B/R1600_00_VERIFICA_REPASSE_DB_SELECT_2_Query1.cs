using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0853B
{
    public class R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1 : QueryBasis<R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VLCUSTAUX
            INTO :V0SAFC-VLCUSTSAF
            FROM SEGUROS.V0SAFCOBER
            WHERE CODCLIEN = :V0PROP-CODCLIEN
            AND DTTERVIG IN ( '1999-12-31' , '9999-12-31' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VLCUSTAUX
											FROM SEGUROS.V0SAFCOBER
											WHERE CODCLIEN = '{this.V0PROP_CODCLIEN}'
											AND DTTERVIG IN ( '1999-12-31' 
							, '9999-12-31' )";

            return query;
        }
        public string V0SAFC_VLCUSTSAF { get; set; }
        public string V0PROP_CODCLIEN { get; set; }

        public static R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1 Execute(R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1 r1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1)
        {
            var ths = r1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1600_00_VERIFICA_REPASSE_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0SAFC_VLCUSTSAF = result[i++].Value?.ToString();
            return dta;
        }

    }
}