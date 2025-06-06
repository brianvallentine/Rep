using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0301B
{
    public class R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 : QueryBasis<R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.CODCORR
            INTO :WHOST-CODCORR
            FROM SEGUROS.V1APOLCORRET A,
            SEGUROS.V1PRODUTOR B
            WHERE A.NUM_APOLICE = :V1HISP-NUMAPOL
            AND A.CODSUBES = :V1ENDO-CODSUBES
            AND A.DTINIVIG <= :V1ENDO-DTINIVIG
            AND A.DTTERVIG >= :V1ENDO-DTINIVIG
            AND A.CODCORR = B.CODPDT
            AND B.CGCCPF IN (42278473000103,
            29552064000187,
            14143271000100)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.CODCORR
											FROM SEGUROS.V1APOLCORRET A
							,
											SEGUROS.V1PRODUTOR B
											WHERE A.NUM_APOLICE = '{this.V1HISP_NUMAPOL}'
											AND A.CODSUBES = '{this.V1ENDO_CODSUBES}'
											AND A.DTINIVIG <= '{this.V1ENDO_DTINIVIG}'
											AND A.DTTERVIG >= '{this.V1ENDO_DTINIVIG}'
											AND A.CODCORR = B.CODPDT
											AND B.CGCCPF IN (42278473000103
							,
											29552064000187
							,
											14143271000100)
											WITH UR";

            return query;
        }
        public string WHOST_CODCORR { get; set; }
        public string V1ENDO_CODSUBES { get; set; }
        public string V1ENDO_DTINIVIG { get; set; }
        public string V1HISP_NUMAPOL { get; set; }

        public static R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 Execute(R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 r0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1)
        {
            var ths = r0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0910_00_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_CODCORR = result[i++].Value?.ToString();
            return dta;
        }

    }
}