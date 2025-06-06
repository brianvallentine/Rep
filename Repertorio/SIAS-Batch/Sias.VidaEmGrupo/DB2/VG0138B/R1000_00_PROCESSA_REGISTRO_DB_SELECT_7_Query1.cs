using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0138B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PROPAUTOM
            INTO :V1FONT-PROPAUTOM
            FROM SEGUROS.V1FONTE
            WHERE FONTE = :V0ENDO-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PROPAUTOM
											FROM SEGUROS.V1FONTE
											WHERE FONTE = '{this.V0ENDO_FONTE}'";

            return query;
        }
        public string V1FONT_PROPAUTOM { get; set; }
        public string V0ENDO_FONTE { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_7_Query1();
            var i = 0;
            dta.V1FONT_PROPAUTOM = result[i++].Value?.ToString();
            return dta;
        }

    }
}