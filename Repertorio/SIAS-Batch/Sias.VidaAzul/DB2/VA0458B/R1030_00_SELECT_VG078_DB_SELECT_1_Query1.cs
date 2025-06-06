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
    public class R1030_00_SELECT_VG078_DB_SELECT_1_Query1 : QueryBasis<R1030_00_SELECT_VG078_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WHOST-ACOMP
            FROM SEGUROS.VG_ANDAMENTO_PROP
            WHERE NUM_CERTIFICADO = :V0PROP-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.VG_ANDAMENTO_PROP
											WHERE NUM_CERTIFICADO = '{this.V0PROP_NRCERTIF}'";

            return query;
        }
        public string WHOST_ACOMP { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static R1030_00_SELECT_VG078_DB_SELECT_1_Query1 Execute(R1030_00_SELECT_VG078_DB_SELECT_1_Query1 r1030_00_SELECT_VG078_DB_SELECT_1_Query1)
        {
            var ths = r1030_00_SELECT_VG078_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1030_00_SELECT_VG078_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1030_00_SELECT_VG078_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_ACOMP = result[i++].Value?.ToString();
            return dta;
        }

    }
}