using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2722B
{
    public class R0012_00_VER_PRODUVG_DB_SELECT_1_Query1 : QueryBasis<R0012_00_VER_PRODUVG_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ORIG_PRODU
            INTO :PRODUVG-ORIG-PRODU
            FROM SEGUROS.PRODUTOS_VG
            WHERE NUM_APOLICE = :RELATORI-NUM-APOLICE
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ORIG_PRODU
											FROM SEGUROS.PRODUTOS_VG
											WHERE NUM_APOLICE = '{this.RELATORI_NUM_APOLICE}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string PRODUVG_ORIG_PRODU { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }

        public static R0012_00_VER_PRODUVG_DB_SELECT_1_Query1 Execute(R0012_00_VER_PRODUVG_DB_SELECT_1_Query1 r0012_00_VER_PRODUVG_DB_SELECT_1_Query1)
        {
            var ths = r0012_00_VER_PRODUVG_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0012_00_VER_PRODUVG_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0012_00_VER_PRODUVG_DB_SELECT_1_Query1();
            var i = 0;
            dta.PRODUVG_ORIG_PRODU = result[i++].Value?.ToString();
            return dta;
        }

    }
}