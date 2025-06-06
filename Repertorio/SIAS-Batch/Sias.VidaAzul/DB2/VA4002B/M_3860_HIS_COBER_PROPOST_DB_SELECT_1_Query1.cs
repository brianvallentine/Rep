using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1 : QueryBasis<M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT IMP_MORNATU,
            IMPMORACID,
            IMPINVPERM,
            IMPAMDS,
            IMPDH,
            IMPDIT,
            VLPREMIO,
            PRMVG,
            PRMAP
            INTO :HISCOBPR-IMP_MORNATU,
            :HISCOBPR-IMPMORACID,
            :HISCOBPR-IMPINVPERM,
            :HISCOBPR-IMPAMDS,
            :HISCOBPR-IMPDH,
            :HISCOBPR-IMPDIT,
            :HISCOBPR-VLPREMIO,
            :HISCOBPR-PRMVG,
            :HISCOBPR-PRMAP
            FROM SEGUROS.HIS_COBER_PROPOST
            WHERE NUM_CERTIFICADO = :PROPVA-NRCERTIF
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT IMP_MORNATU
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
							,
											VLPREMIO
							,
											PRMVG
							,
											PRMAP
											FROM SEGUROS.HIS_COBER_PROPOST
											WHERE NUM_CERTIFICADO = '{this.PROPVA_NRCERTIF}'";

            return query;
        }
        public string HISCOBPR_IMP_MORNATU { get; set; }
        public string HISCOBPR_IMPMORACID { get; set; }
        public string HISCOBPR_IMPINVPERM { get; set; }
        public string HISCOBPR_IMPAMDS { get; set; }
        public string HISCOBPR_IMPDH { get; set; }
        public string HISCOBPR_IMPDIT { get; set; }
        public string HISCOBPR_VLPREMIO { get; set; }
        public string HISCOBPR_PRMVG { get; set; }
        public string HISCOBPR_PRMAP { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1 Execute(M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1 m_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1)
        {
            var ths = m_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_3860_HIS_COBER_PROPOST_DB_SELECT_1_Query1();
            var i = 0;
            dta.HISCOBPR_IMP_MORNATU = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPMORACID = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPINVPERM = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPAMDS = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPDH = result[i++].Value?.ToString();
            dta.HISCOBPR_IMPDIT = result[i++].Value?.ToString();
            dta.HISCOBPR_VLPREMIO = result[i++].Value?.ToString();
            dta.HISCOBPR_PRMVG = result[i++].Value?.ToString();
            dta.HISCOBPR_PRMAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}