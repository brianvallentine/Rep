using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1139B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT GARAN_ADIC_IEA,
            GARAN_ADIC_IPA,
            GARAN_ADIC_IPD
            INTO :V0COND-IEA,
            :V0COND-IPA,
            :V0COND-IPD
            FROM SEGUROS.V0CONDTEC
            WHERE NUM_APOLICE = :V0ENDO-NUM-APOLICE
            AND COD_SUBGRUPO = :V0ENDO-CODSUBES
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT GARAN_ADIC_IEA
							,
											GARAN_ADIC_IPA
							,
											GARAN_ADIC_IPD
											FROM SEGUROS.V0CONDTEC
											WHERE NUM_APOLICE = '{this.V0ENDO_NUM_APOLICE}'
											AND COD_SUBGRUPO = '{this.V0ENDO_CODSUBES}'";

            return query;
        }
        public string V0COND_IEA { get; set; }
        public string V0COND_IPA { get; set; }
        public string V0COND_IPD { get; set; }
        public string V0ENDO_NUM_APOLICE { get; set; }
        public string V0ENDO_CODSUBES { get; set; }

        public static R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 Execute(R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1000_00_PROCESSA_REGISTRO_DB_SELECT_3_Query1();
            var i = 0;
            dta.V0COND_IEA = result[i++].Value?.ToString();
            dta.V0COND_IPA = result[i++].Value?.ToString();
            dta.V0COND_IPD = result[i++].Value?.ToString();
            return dta;
        }

    }
}