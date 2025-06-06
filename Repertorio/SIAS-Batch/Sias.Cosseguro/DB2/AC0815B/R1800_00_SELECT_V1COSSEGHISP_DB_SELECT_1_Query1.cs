using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cosseguro.DB2.AC0815B
{
    public class R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1 : QueryBasis<R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            DTMOVTO
            INTO
            :WHOST-DTMOVTO-EM
            FROM
            SEGUROS.V1COSSEG_HISTPRE
            WHERE
            CONGENER = :V1CHIS-CONGENER
            AND NUM_APOLICE = :V1CHIS-NUM-APOL
            AND NRENDOS = :V1CHIS-NUM-ENDS
            AND NRPARCEL = :V1CHIS-NRPARCEL
            AND OCORHIST = 01
            AND OPERACAO < 0200
            AND TIPSGU = '1'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DTMOVTO
											FROM
											SEGUROS.V1COSSEG_HISTPRE
											WHERE
											CONGENER = '{this.V1CHIS_CONGENER}'
											AND NUM_APOLICE = '{this.V1CHIS_NUM_APOL}'
											AND NRENDOS = '{this.V1CHIS_NUM_ENDS}'
											AND NRPARCEL = '{this.V1CHIS_NRPARCEL}'
											AND OCORHIST = 01
											AND OPERACAO < 0200
											AND TIPSGU = '1'";

            return query;
        }
        public string WHOST_DTMOVTO_EM { get; set; }
        public string V1CHIS_CONGENER { get; set; }
        public string V1CHIS_NUM_APOL { get; set; }
        public string V1CHIS_NUM_ENDS { get; set; }
        public string V1CHIS_NRPARCEL { get; set; }

        public static R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1 Execute(R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1 r1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1)
        {
            var ths = r1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1800_00_SELECT_V1COSSEGHISP_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DTMOVTO_EM = result[i++].Value?.ToString();
            return dta;
        }

    }
}