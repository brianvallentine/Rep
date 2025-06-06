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
    public class A3510_LE_RAMOIND_DB_SELECT_1_Query1 : QueryBasis<A3510_LE_RAMOIND_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT PCIOF / 100 + 1
            , PCIOF / 100
            INTO :RAMOIND-PCIOF
            , :RAMO-PERC-IOF
            FROM SEGUROS.V0RAMOIND
            WHERE RAMO = :ENDO-RAMO
            AND DTINIVIG <= :SIST-DTMOVABE
            AND DTTERVIG >= :SIST-DTMOVABE
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCIOF / 100 + 1
											, PCIOF / 100
											FROM SEGUROS.V0RAMOIND
											WHERE RAMO = '{this.ENDO_RAMO}'
											AND DTINIVIG <= '{this.SIST_DTMOVABE}'
											AND DTTERVIG >= '{this.SIST_DTMOVABE}'
											WITH UR";

            return query;
        }
        public string RAMOIND_PCIOF { get; set; }
        public string RAMO_PERC_IOF { get; set; }
        public string SIST_DTMOVABE { get; set; }
        public string ENDO_RAMO { get; set; }

        public static A3510_LE_RAMOIND_DB_SELECT_1_Query1 Execute(A3510_LE_RAMOIND_DB_SELECT_1_Query1 a3510_LE_RAMOIND_DB_SELECT_1_Query1)
        {
            var ths = a3510_LE_RAMOIND_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override A3510_LE_RAMOIND_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new A3510_LE_RAMOIND_DB_SELECT_1_Query1();
            var i = 0;
            dta.RAMOIND_PCIOF = result[i++].Value?.ToString();
            dta.RAMO_PERC_IOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}