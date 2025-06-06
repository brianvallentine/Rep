using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0874B
{
    public class R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1 : QueryBasis<R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SUM(VAL_OPERACAO)
            INTO
            :HOST-VLR-AVISADO
            FROM SEGUROS.SINISTRO_HISTORICO H
            WHERE H.NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            AND H.COD_OPERACAO = 101
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SUM(VAL_OPERACAO)
											FROM SEGUROS.SINISTRO_HISTORICO H
											WHERE H.NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'
											AND H.COD_OPERACAO = 101";

            return query;
        }
        public string HOST_VLR_AVISADO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1 Execute(R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1 r312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1)
        {
            var ths = r312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R312_PESQUISA_VAL_AVISADO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_VLR_AVISADO = result[i++].Value?.ToString();
            return dta;
        }

    }
}