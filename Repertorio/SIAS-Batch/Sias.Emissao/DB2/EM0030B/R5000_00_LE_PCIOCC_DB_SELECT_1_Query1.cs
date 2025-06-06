using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class R5000_00_LE_PCIOCC_DB_SELECT_1_Query1 : QueryBasis<R5000_00_LE_PCIOCC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            PCIOF
            INTO :V1RAMO-PCIOF
            FROM SEGUROS.V1RAMOIND
            WHERE RAMO = :ENDO-RAMO
            AND DTINIVIG <= :ENDO-DTINIVIG
            AND DTTERVIG >= :ENDO-DTINIVIG
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											PCIOF
											FROM SEGUROS.V1RAMOIND
											WHERE RAMO = '{this.ENDO_RAMO}'
											AND DTINIVIG <= '{this.ENDO_DTINIVIG}'
											AND DTTERVIG >= '{this.ENDO_DTINIVIG}'
											WITH UR";

            return query;
        }
        public string V1RAMO_PCIOF { get; set; }
        public string ENDO_DTINIVIG { get; set; }
        public string ENDO_RAMO { get; set; }

        public static R5000_00_LE_PCIOCC_DB_SELECT_1_Query1 Execute(R5000_00_LE_PCIOCC_DB_SELECT_1_Query1 r5000_00_LE_PCIOCC_DB_SELECT_1_Query1)
        {
            var ths = r5000_00_LE_PCIOCC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R5000_00_LE_PCIOCC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R5000_00_LE_PCIOCC_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1RAMO_PCIOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}