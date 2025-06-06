using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0850B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.CODPRODU,
            A.SITUACAO,
            B.ESTR_COBR,
            B.ORIG_PRODU
            INTO :V0PROP-CODPRODU,
            :V0PROP-SITUACAO,
            :V0PROP-ESTR-COBR:VIND-ESTR-COBR,
            :V0PROP-ORIG-PRODU:VIND-ORIG-PRODU
            FROM SEGUROS.V0PROPOSTAVA A,
            SEGUROS.V0PRODUTOSVG B
            WHERE A.NRCERTIF = :V0HCOB-NRCERTIF
            AND B.NUM_APOLICE= A.NUM_APOLICE
            AND B.CODSUBES = A.CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.CODPRODU
							,
											A.SITUACAO
							,
											B.ESTR_COBR
							,
											B.ORIG_PRODU
											FROM SEGUROS.V0PROPOSTAVA A
							,
											SEGUROS.V0PRODUTOSVG B
											WHERE A.NRCERTIF = '{this.V0HCOB_NRCERTIF}'
											AND B.NUM_APOLICE= A.NUM_APOLICE
											AND B.CODSUBES = A.CODSUBES";

            return query;
        }
        public string V0PROP_CODPRODU { get; set; }
        public string V0PROP_SITUACAO { get; set; }
        public string V0PROP_ESTR_COBR { get; set; }
        public string VIND_ESTR_COBR { get; set; }
        public string V0PROP_ORIG_PRODU { get; set; }
        public string VIND_ORIG_PRODU { get; set; }
        public string V0HCOB_NRCERTIF { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0PROP_CODPRODU = result[i++].Value?.ToString();
            dta.V0PROP_SITUACAO = result[i++].Value?.ToString();
            dta.V0PROP_ESTR_COBR = result[i++].Value?.ToString();
            dta.VIND_ESTR_COBR = string.IsNullOrWhiteSpace(dta.V0PROP_ESTR_COBR) ? "-1" : "0";
            dta.V0PROP_ORIG_PRODU = result[i++].Value?.ToString();
            dta.VIND_ORIG_PRODU = string.IsNullOrWhiteSpace(dta.V0PROP_ORIG_PRODU) ? "-1" : "0";
            return dta;
        }

    }
}