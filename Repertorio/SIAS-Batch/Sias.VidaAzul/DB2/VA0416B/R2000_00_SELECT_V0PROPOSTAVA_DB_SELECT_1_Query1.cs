using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0416B
{
    public class R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 : QueryBasis<R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.FONTE ,
            A.CODPRODU ,
            A.NUM_APOLICE ,
            A.CODSUBES ,
            B.DIA_FATURA ,
            B.ESTR_COBR ,
            B.ORIG_PRODU
            INTO :V0PROP-FONTE ,
            :V0PROP-CODPRODU ,
            :V0PROP-APOLICE ,
            :V0PROP-CODSUBES ,
            :V0PROP-DIA-FATURA:VIND-DIA-FATURA,
            :V0PROP-ESTR-COBR:VIND-ESTR-COBR,
            :V0PROP-ORIG-PRODU:VIND-ORIG-PRODU
            FROM SEGUROS.V0PROPOSTAVA A,
            SEGUROS.V0PRODUTOSVG B
            WHERE A.NRCERTIF = :V0HCOB-NRCERTIF
            AND B.NUM_APOLICE = A.NUM_APOLICE
            AND B.CODSUBES = A.CODSUBES
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.FONTE 
							,
											A.CODPRODU 
							,
											A.NUM_APOLICE 
							,
											A.CODSUBES 
							,
											B.DIA_FATURA 
							,
											B.ESTR_COBR 
							,
											B.ORIG_PRODU
											FROM SEGUROS.V0PROPOSTAVA A
							,
											SEGUROS.V0PRODUTOSVG B
											WHERE A.NRCERTIF = '{this.V0HCOB_NRCERTIF}'
											AND B.NUM_APOLICE = A.NUM_APOLICE
											AND B.CODSUBES = A.CODSUBES";

            return query;
        }
        public string V0PROP_FONTE { get; set; }
        public string V0PROP_CODPRODU { get; set; }
        public string V0PROP_APOLICE { get; set; }
        public string V0PROP_CODSUBES { get; set; }
        public string V0PROP_DIA_FATURA { get; set; }
        public string VIND_DIA_FATURA { get; set; }
        public string V0PROP_ESTR_COBR { get; set; }
        public string VIND_ESTR_COBR { get; set; }
        public string V0PROP_ORIG_PRODU { get; set; }
        public string VIND_ORIG_PRODU { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }

        public static R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 Execute(R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 r2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1)
        {
            var ths = r2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2000_00_SELECT_V0PROPOSTAVA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROP_FONTE = result[i++].Value?.ToString();
            dta.V0PROP_CODPRODU = result[i++].Value?.ToString();
            dta.V0PROP_APOLICE = result[i++].Value?.ToString();
            dta.V0PROP_CODSUBES = result[i++].Value?.ToString();
            dta.V0PROP_DIA_FATURA = result[i++].Value?.ToString();
            dta.VIND_DIA_FATURA = string.IsNullOrWhiteSpace(dta.V0PROP_DIA_FATURA) ? "-1" : "0";
            dta.V0PROP_ESTR_COBR = result[i++].Value?.ToString();
            dta.VIND_ESTR_COBR = string.IsNullOrWhiteSpace(dta.V0PROP_ESTR_COBR) ? "-1" : "0";
            dta.V0PROP_ORIG_PRODU = result[i++].Value?.ToString();
            dta.VIND_ORIG_PRODU = string.IsNullOrWhiteSpace(dta.V0PROP_ORIG_PRODU) ? "-1" : "0";
            return dta;
        }

    }
}