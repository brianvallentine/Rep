using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0003B
{
    public class R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1 : QueryBasis<R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(VALCREDR_IX),
            COUNT(*)
            INTO :V1NOTA-VALCREDR-IX:SQL-VALCREDR,
            :W1-COUNT
            FROM SEGUROS.V1NOTASCRED
            WHERE NUM_APOLICE = :V1PARC-NUM-APOL
            AND NRENDOSC = :V1PARC-NRENDOS
            AND NRPARCELC = :V1PARC-NRPARCEL
            AND SITUACAO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(VALCREDR_IX)
							,
											COUNT(*)
											FROM SEGUROS.V1NOTASCRED
											WHERE NUM_APOLICE = '{this.V1PARC_NUM_APOL}'
											AND NRENDOSC = '{this.V1PARC_NRENDOS}'
											AND NRPARCELC = '{this.V1PARC_NRPARCEL}'
											AND SITUACAO = '0'
											WITH UR";

            return query;
        }
        public string V1NOTA_VALCREDR_IX { get; set; }
        public string SQL_VALCREDR { get; set; }
        public string W1_COUNT { get; set; }
        public string V1PARC_NUM_APOL { get; set; }
        public string V1PARC_NRPARCEL { get; set; }
        public string V1PARC_NRENDOS { get; set; }

        public static R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1 Execute(R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1 r1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1)
        {
            var ths = r1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1705_00_SUMARIZA_NOTASCRED_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1NOTA_VALCREDR_IX = result[i++].Value?.ToString();
            dta.SQL_VALCREDR = string.IsNullOrWhiteSpace(dta.V1NOTA_VALCREDR_IX) ? "-1" : "0";
            dta.W1_COUNT = result[i++].Value?.ToString();
            return dta;
        }

    }
}