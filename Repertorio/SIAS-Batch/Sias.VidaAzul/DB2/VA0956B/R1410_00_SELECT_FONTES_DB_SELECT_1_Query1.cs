using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0956B
{
    public class R1410_00_SELECT_FONTES_DB_SELECT_1_Query1 : QueryBasis<R1410_00_SELECT_FONTES_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            NOME_FONTE
            INTO :FONTES-NOME-FONTE
            FROM SEGUROS.FONTES
            WHERE COD_FONTE = :V0MSIN-FONTE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											NOME_FONTE
											FROM SEGUROS.FONTES
											WHERE COD_FONTE = '{this.V0MSIN_FONTE}'
											WITH UR";

            return query;
        }
        public string FONTES_NOME_FONTE { get; set; }
        public string V0MSIN_FONTE { get; set; }

        public static R1410_00_SELECT_FONTES_DB_SELECT_1_Query1 Execute(R1410_00_SELECT_FONTES_DB_SELECT_1_Query1 r1410_00_SELECT_FONTES_DB_SELECT_1_Query1)
        {
            var ths = r1410_00_SELECT_FONTES_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1410_00_SELECT_FONTES_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1410_00_SELECT_FONTES_DB_SELECT_1_Query1();
            var i = 0;
            dta.FONTES_NOME_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}