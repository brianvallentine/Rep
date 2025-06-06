using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0140B
{
    public class R0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 : QueryBasis<R0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_INIVIGENCIA
            ,DATA_TERVIGENCIA
            ,IMP_MORNATU
            ,IMPMORACID
            ,IMPINVPERM
            ,IMPAMDS
            ,IMPDH
            ,IMPDIT
            ,VLPREMIO
            ,PRMDIT
            INTO :HISCOBPR-DATA-INIVIGENCIA
            ,:HISCOBPR-DATA-TERVIGENCIA
            ,:HISCOBPR-IMP-MORNATU
            ,:HISCOBPR-IMPMORACID
            ,:HISCOBPR-IMPINVPERM
            ,:HISCOBPR-IMPAMDS
            ,:HISCOBPR-IMPDH
            ,:HISCOBPR-IMPDIT
            ,:HISCOBPR-VLPREMIO
            ,:HISCOBPR-PRMDIT:VIND-NULL01
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :HISCONPA-NUM-CERTIFICADO
            AND DATA_TERVIGENCIA = '9999-12-31'
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT DATA_INIVIGENCIA
											,DATA_TERVIGENCIA
											,IMP_MORNATU
											,IMPMORACID
											,IMPINVPERM
											,IMPAMDS
											,IMPDH
											,IMPDIT
											,VLPREMIO
											,PRMDIT
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.HISCONPA_NUM_CERTIFICADO}'
											AND DATA_TERVIGENCIA = '9999-12-31'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string HISCOBPR_DATA_INIVIGENCIA { get; set; }
        public string HISCOBPR_DATA_TERVIGENCIA { get; set; }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string HISCOBPR_IMPMORACID { get; set; }
        public string HISCOBPR_IMPINVPERM { get; set; }
        public string HISCOBPR_IMPAMDS { get; set; }
        public string HISCOBPR_IMPDH { get; set; }
        public string HISCOBPR_IMPDIT { get; set; }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string HISCOBPR_PRMDIT { get; set; }
        public string VIND_NULL01 { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }

        public static R0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 Execute(R0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 r0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1)
        {
            var ths = r0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0320_00_SELECT_HISCOBPR_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_DATA_INIVIGENCIA = result[i++].Value?.ToString();
            dta.HISCOBPR_DATA_TERVIGENCIA = result[i++].Value?.ToString();
            dta.HISCOBPR_IMP_MORNATU = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPMORACID = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPINVPERM = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPAMDS = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPDH = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPDIT = result[i++].Value?.ToString();
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            dta.HISCOBPR_PRMDIT = result[i++].Value?.ToString();
            dta.VIND_NULL01 = string.IsNullOrWhiteSpace(dta.HISCOBPR_PRMDIT) ? "-1" : "0";
            return dta;
        }

    }
}