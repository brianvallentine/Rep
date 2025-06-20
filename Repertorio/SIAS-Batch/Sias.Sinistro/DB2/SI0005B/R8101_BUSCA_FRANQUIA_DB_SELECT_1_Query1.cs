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
    public class R8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1 : QueryBasis<R8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(SUM(H.VAL_OPERACAO),0)
            INTO :W-HOST-VALOR-FRANQUIA
            FROM SEGUROS.SINISTRO_HISTORICO H
            WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND H.COD_OPERACAO IN (21)
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(SUM(H.VAL_OPERACAO)
							,0)
											FROM SEGUROS.SINISTRO_HISTORICO H
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND H.COD_OPERACAO IN (21)";

            return query;
        }
        public string W_HOST_VALOR_FRANQUIA { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1 Execute(R8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1 r8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1)
        {
            var ths = r8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R8101_BUSCA_FRANQUIA_DB_SELECT_1_Query1();
            var i = 0;
            dta.W_HOST_VALOR_FRANQUIA = result[i++].Value?.ToString();
            return dta;
        }

    }
}