using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Auto.DB2.AU0025S
{
    public class M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1 : QueryBasis<M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT PCDESC
            INTO
            :FRFAC-PCDESC
            FROM SEGUROS.V1FRANQFAC
            WHERE CODTAB = :FRFAC-CODTAB
            AND CLASSEFR = :FRFAC-CLASSEFR
            AND DTINIVIG <= :FRFAC-DTINIVIG
            AND DTTERVIG >= :FRFAC-DTINIVIG
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PCDESC
											FROM SEGUROS.V1FRANQFAC
											WHERE CODTAB = '{this.FRFAC_CODTAB}'
											AND CLASSEFR = '{this.FRFAC_CLASSEFR}'
											AND DTINIVIG <= '{this.FRFAC_DTINIVIG}'
											AND DTTERVIG >= '{this.FRFAC_DTINIVIG}'";

            return query;
        }
        public string FRFAC_PCDESC { get; set; }
        public string FRFAC_CLASSEFR { get; set; }
        public string FRFAC_DTINIVIG { get; set; }
        public string FRFAC_CODTAB { get; set; }

        public static M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1 Execute(M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1 m_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1)
        {
            var ths = m_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_072_000_PESQ_V1FRANQFAC_DB_SELECT_1_Query1();
            var i = 0;
            dta.FRFAC_PCDESC = result[i++].Value?.ToString();
            return dta;
        }

    }
}