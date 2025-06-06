using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8070B
{
    public class R1200_00_SELECT_FONTES_DB_SELECT_1_Query1 : QueryBasis<R1200_00_SELECT_FONTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ULT_PROP_AUTOMAT
            INTO :FONTES-ULT-PROP-AUTOMAT
            FROM SEGUROS.FONTES
            WHERE COD_FONTE = :ENDOSSOS-COD-FONTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ULT_PROP_AUTOMAT
											FROM SEGUROS.FONTES
											WHERE COD_FONTE = '{this.ENDOSSOS_COD_FONTE}'
											WITH UR";

            return query;
        }
        public string FONTES_ULT_PROP_AUTOMAT { get; set; }
        public string ENDOSSOS_COD_FONTE { get; set; }

        public static R1200_00_SELECT_FONTES_DB_SELECT_1_Query1 Execute(R1200_00_SELECT_FONTES_DB_SELECT_1_Query1 r1200_00_SELECT_FONTES_DB_SELECT_1_Query1)
        {
            var ths = r1200_00_SELECT_FONTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1200_00_SELECT_FONTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1200_00_SELECT_FONTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_ULT_PROP_AUTOMAT = result[i++].Value?.ToString();
            return dta;
        }

    }
}