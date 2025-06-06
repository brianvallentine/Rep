using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1650B
{
    public class R8030_00_SELECT_FONTES_DB_SELECT_1_Query1 : QueryBasis<R8030_00_SELECT_FONTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            ULT_PROP_AUTOMAT
            INTO
            :FONTES-ULT-PROP-AUTOMAT
            FROM
            SEGUROS.FONTES
            WHERE
            COD_FONTE = :WHOST-COD-FONTE-ANT
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											ULT_PROP_AUTOMAT
											FROM
											SEGUROS.FONTES
											WHERE
											COD_FONTE = '{this.WHOST_COD_FONTE_ANT}'";

            return query;
        }
        public string FONTES_ULT_PROP_AUTOMAT { get; set; }
        public string WHOST_COD_FONTE_ANT { get; set; }

        public static R8030_00_SELECT_FONTES_DB_SELECT_1_Query1 Execute(R8030_00_SELECT_FONTES_DB_SELECT_1_Query1 r8030_00_SELECT_FONTES_DB_SELECT_1_Query1)
        {
            var ths = r8030_00_SELECT_FONTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8030_00_SELECT_FONTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8030_00_SELECT_FONTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_ULT_PROP_AUTOMAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}