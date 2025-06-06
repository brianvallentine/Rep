using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0601B
{
    public class R2243_10_FETCH_DB_SELECT_1_Query1 : QueryBasis<R2243_10_FETCH_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_MORNATU
            INTO :DCLHIS-COBER-PROPOST.IMP-MORNATU
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO =
            :PROPVA-NRCERTIF
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_MORNATU
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO =
											'{this.PROPVA_NRCERTIF}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string IMP_MORNATU { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static R2243_10_FETCH_DB_SELECT_1_Query1 Execute(R2243_10_FETCH_DB_SELECT_1_Query1 r2243_10_FETCH_DB_SELECT_1_Query1)
        {
            var ths = r2243_10_FETCH_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2243_10_FETCH_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2243_10_FETCH_DB_SELECT_1_Query1();
            var i = 0;
            dta.IMP_MORNATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}