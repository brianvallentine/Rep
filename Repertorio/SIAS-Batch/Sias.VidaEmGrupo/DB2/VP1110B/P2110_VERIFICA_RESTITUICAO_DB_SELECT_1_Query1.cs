using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP1110B
{
    public class P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1 : QueryBasis<P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO :WS-CT-RESTITUICAO
            FROM SEGUROS.RELATORIOS RELATORI
            WHERE RELATORI.NUM_CERTIFICADO =
            :PROPOVA-NUM-CERTIFICADO
            AND RELATORI.COD_RELATORIO = 'VA0469B'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.RELATORIOS RELATORI
											WHERE RELATORI.NUM_CERTIFICADO =
											'{this.PROPOVA_NUM_CERTIFICADO}'
											AND RELATORI.COD_RELATORIO = 'VA0469B'
											WITH UR";

            return query;
        }
        public string WS_CT_RESTITUICAO { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1 Execute(P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1 p2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1)
        {
            var ths = p2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new P2110_VERIFICA_RESTITUICAO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_CT_RESTITUICAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}