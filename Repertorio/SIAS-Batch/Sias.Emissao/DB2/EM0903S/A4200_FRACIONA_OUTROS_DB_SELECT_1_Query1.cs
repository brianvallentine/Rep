using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0903S
{
    public class A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1 : QueryBasis<A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT INDPRLIQ,
            INDADIC
            INTO :FRAC-INDPRLIQ,
            :FRAC-INDADIC
            FROM SEGUROS.V1FRACIONAMENTO
            WHERE RAMO = :FRAC-RAMO
            AND DTINIVIG <= :FRAC-DTINIVIG
            AND DTTERVIG >= :FRAC-DTINIVIG
            AND NRPARCEL = :FRAC-NRPARCEL
            AND QTPARCEL = :FRAC-QTPARCEL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT INDPRLIQ
							,
											INDADIC
											FROM SEGUROS.V1FRACIONAMENTO
											WHERE RAMO = '{this.FRAC_RAMO}'
											AND DTINIVIG <= '{this.FRAC_DTINIVIG}'
											AND DTTERVIG >= '{this.FRAC_DTINIVIG}'
											AND NRPARCEL = '{this.FRAC_NRPARCEL}'
											AND QTPARCEL = '{this.FRAC_QTPARCEL}'";

            return query;
        }
        public string FRAC_INDPRLIQ { get; set; }
        public string FRAC_INDADIC { get; set; }
        public string FRAC_DTINIVIG { get; set; }
        public string FRAC_NRPARCEL { get; set; }
        public string FRAC_QTPARCEL { get; set; }
        public string FRAC_RAMO { get; set; }

        public static A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1 Execute(A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1 a4200_FRACIONA_OUTROS_DB_SELECT_1_Query1)
        {
            var ths = a4200_FRACIONA_OUTROS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new A4200_FRACIONA_OUTROS_DB_SELECT_1_Query1();
            var i = 0;
            dta.FRAC_INDPRLIQ = result[i++].Value?.ToString();
            dta.FRAC_INDADIC = result[i++].Value?.ToString();
            return dta;
        }

    }
}