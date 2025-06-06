using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2720B
{
    public class R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            IMP_MORNATU,
            IMPMORACID,
            IMPINVPERM,
            IMPAMDS,
            IMPDH,
            IMPDIT
            INTO
            :HISCOBPR-IMP-MORNATU,
            :HISCOBPR-IMPMORACID,
            :HISCOBPR-IMPINVPERM,
            :HISCOBPR-IMPAMDS,
            :HISCOBPR-IMPDH,
            :HISCOBPR-IMPDIT
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											IMP_MORNATU
							,
											IMPMORACID
							,
											IMPINVPERM
							,
											IMPAMDS
							,
											IMPDH
							,
											IMPDIT
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'";

            return query;
        }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string HISCOBPR_IMPMORACID { get; set; }
        public string HISCOBPR_IMPINVPERM { get; set; }
        public string HISCOBPR_IMPAMDS { get; set; }
        public string HISCOBPR_IMPDH { get; set; }
        public string HISCOBPR_IMPDIT { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1510_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_IMP_MORNATU = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPMORACID = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPINVPERM = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPAMDS = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPDH = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPDIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}