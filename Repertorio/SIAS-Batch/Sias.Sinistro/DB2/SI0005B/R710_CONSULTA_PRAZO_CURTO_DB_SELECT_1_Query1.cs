using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1 : QueryBasis<R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(PRM_TARIFARIO),0)
            INTO :W-HOST-TOT-PREMIO-TAR
            FROM SEGUROS.PARCELA_HISTORICO
            WHERE NUM_APOLICE = :LOTERI01-NUM-APOLICE
            AND COD_OPERACAO = 101
            AND NUM_ENDOSSO = 0
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(PRM_TARIFARIO)
							,0)
											FROM SEGUROS.PARCELA_HISTORICO
											WHERE NUM_APOLICE = '{this.LOTERI01_NUM_APOLICE}'
											AND COD_OPERACAO = 101
											AND NUM_ENDOSSO = 0
											WITH UR";

            return query;
        }
        public string W_HOST_TOT_PREMIO_TAR { get; set; }
        public string LOTERI01_NUM_APOLICE { get; set; }

        public static R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1 Execute(R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1 r710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1)
        {
            var ths = r710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R710_CONSULTA_PRAZO_CURTO_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_HOST_TOT_PREMIO_TAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}