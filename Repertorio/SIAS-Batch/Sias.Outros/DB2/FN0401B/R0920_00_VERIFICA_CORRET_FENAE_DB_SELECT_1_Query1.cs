using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0401B
{
    public class R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 : QueryBasis<R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.CODCORR
            INTO :WHOST-CODCORR
            FROM SEGUROS.V1APOLCORRET A,
            SEGUROS.V1PRODUTOR B
            WHERE A.NUM_APOLICE = :V1HIST-NUMAPOL
            AND A.CODSUBES = :V0ENDO-CODSUBES
            AND A.DTINIVIG <= :V0ENDO-DTINIVIG
            AND A.DTTERVIG >= :V0ENDO-DTINIVIG
            AND A.CODCORR = B.CODPDT
            AND B.CGCCPF IN (42278473000103,
            29552064000187)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.CODCORR
											FROM SEGUROS.V1APOLCORRET A
							,
											SEGUROS.V1PRODUTOR B
											WHERE A.NUM_APOLICE = '{this.V1HIST_NUMAPOL}'
											AND A.CODSUBES = '{this.V0ENDO_CODSUBES}'
											AND A.DTINIVIG <= '{this.V0ENDO_DTINIVIG}'
											AND A.DTTERVIG >= '{this.V0ENDO_DTINIVIG}'
											AND A.CODCORR = B.CODPDT
											AND B.CGCCPF IN (42278473000103
							,
											29552064000187)
											WITH UR";

            return query;
        }
        public string WHOST_CODCORR { get; set; }
        public string V0ENDO_CODSUBES { get; set; }
        public string V0ENDO_DTINIVIG { get; set; }
        public string V1HIST_NUMAPOL { get; set; }

        public static R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 Execute(R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 r0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1)
        {
            var ths = r0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0920_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_CODCORR = result[i++].Value?.ToString();
            return dta;
        }

    }
}