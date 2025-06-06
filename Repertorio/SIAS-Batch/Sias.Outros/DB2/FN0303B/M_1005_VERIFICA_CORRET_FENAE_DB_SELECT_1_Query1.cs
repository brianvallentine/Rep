using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FN0303B
{
    public class M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 : QueryBasis<M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.CODCORR
            INTO :APOLCORR-CODCORR
            FROM SEGUROS.V1APOLCORRET A,
            SEGUROS.V1PRODUTOR B
            WHERE A.NUM_APOLICE = :NRAPOLICE
            AND A.CODSUBES = :CODSUBES
            AND A.CODCORR = B.CODPDT
            AND B.CGCCPF IN (42278473000103,
            29552064000187)
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT A.CODCORR
											FROM SEGUROS.V1APOLCORRET A
							,
											SEGUROS.V1PRODUTOR B
											WHERE A.NUM_APOLICE = '{this.NRAPOLICE}'
											AND A.CODSUBES = '{this.CODSUBES}'
											AND A.CODCORR = B.CODPDT
											AND B.CGCCPF IN (42278473000103
							,
											29552064000187)
											WITH UR";

            return query;
        }
        public string APOLCORR_CODCORR { get; set; }
        public string NRAPOLICE { get; set; }
        public string CODSUBES { get; set; }

        public static M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 Execute(M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 m_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1)
        {
            var ths = m_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new M_1005_VERIFICA_CORRET_FENAE_DB_SELECT_1_Query1();
            var i = 0;
            dta.APOLCORR_CODCORR = result[i++].Value?.ToString();
            return dta;
        }

    }
}