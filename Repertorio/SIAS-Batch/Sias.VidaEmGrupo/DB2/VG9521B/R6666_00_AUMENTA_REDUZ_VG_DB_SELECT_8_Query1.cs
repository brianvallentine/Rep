using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9521B
{
    public class R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1 : QueryBasis<R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ULT_PROP_AUTOMAT
            INTO :FONTES-ULT-PROP-AUTOMAT
            FROM SEGUROS.FONTES
            WHERE COD_FONTE = :SEGURVGA-COD-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ULT_PROP_AUTOMAT
											FROM SEGUROS.FONTES
											WHERE COD_FONTE = '{this.SEGURVGA_COD_FONTE}'";

            return query;
        }
        public string FONTES_ULT_PROP_AUTOMAT { get; set; }
        public string SEGURVGA_COD_FONTE { get; set; }

        public static R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1 Execute(R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1 r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1)
        {
            var ths = r6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R6666_00_AUMENTA_REDUZ_VG_DB_SELECT_8_Query1();
            var i = 0;
            dta.FONTES_ULT_PROP_AUTOMAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}