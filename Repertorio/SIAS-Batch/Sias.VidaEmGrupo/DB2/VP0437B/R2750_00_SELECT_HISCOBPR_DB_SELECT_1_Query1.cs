using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            QTMDIT
            INTO
            :HISCOBPR-QTMDIT:VIND-QTMDIT
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :WHOST-NRCERTIF
            AND DATA_INIVIGENCIA <= CURRENT DATE
            AND DATA_TERVIGENCIA >= CURRENT DATE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											QTMDIT
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.WHOST_NRCERTIF}'
											AND DATA_INIVIGENCIA <= CURRENT DATE
											AND DATA_TERVIGENCIA >= CURRENT DATE";

            return query;
        }
        public string HISCOBPR_QTMDIT { get; set; }
        public string VIND_QTMDIT { get; set; }
        public string WHOST_NRCERTIF { get; set; }

        public static R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2750_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_QTMDIT = result[i++].Value?.ToString();
            dta.VIND_QTMDIT = string.IsNullOrWhiteSpace(dta.HISCOBPR_QTMDIT) ? "-1" : "0";
            return dta;
        }

    }
}