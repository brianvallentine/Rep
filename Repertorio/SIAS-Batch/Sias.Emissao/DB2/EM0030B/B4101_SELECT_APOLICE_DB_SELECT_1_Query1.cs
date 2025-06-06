using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0030B
{
    public class B4101_SELECT_APOLICE_DB_SELECT_1_Query1 : QueryBasis<B4101_SELECT_APOLICE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT
            DISTINCT(CODCORR)
            INTO :V0EDIA-CODCORR
            FROM SEGUROS.V1APOLCORRET
            WHERE INDCRT = '1'
            AND TIPCOM = '1'
            AND NUM_APOLICE = :ENDO-NUM-APOLICE
            AND CODSUBES = :ENDO-CODSUBES
            AND DTINIVIG <= :ENDO-DTINIVIG
            AND DTTERVIG >= :ENDO-DTINIVIG
            ORDER BY CODCORR
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											DISTINCT(CODCORR)
											FROM SEGUROS.V1APOLCORRET
											WHERE INDCRT = '1'
											AND TIPCOM = '1'
											AND NUM_APOLICE = '{this.ENDO_NUM_APOLICE}'
											AND CODSUBES = '{this.ENDO_CODSUBES}'
											AND DTINIVIG <= '{this.ENDO_DTINIVIG}'
											AND DTTERVIG >= '{this.ENDO_DTINIVIG}'
											ORDER BY CODCORR
											WITH UR";

            return query;
        }
        public string V0EDIA_CODCORR { get; set; }
        public string ENDO_NUM_APOLICE { get; set; }
        public string ENDO_CODSUBES { get; set; }
        public string ENDO_DTINIVIG { get; set; }

        public static B4101_SELECT_APOLICE_DB_SELECT_1_Query1 Execute(B4101_SELECT_APOLICE_DB_SELECT_1_Query1 b4101_SELECT_APOLICE_DB_SELECT_1_Query1)
        {
            var ths = b4101_SELECT_APOLICE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B4101_SELECT_APOLICE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B4101_SELECT_APOLICE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0EDIA_CODCORR = result[i++].Value?.ToString();
            return dta;
        }

    }
}