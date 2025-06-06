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
    public class R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1 : QueryBasis<R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COUNT(*)
            INTO
            :HOST-CONT-PROC-JURID
            FROM SEGUROS.SI_PROCESSO_JURID
            WHERE NUM_APOL_SINISTRO = :SINISHIS-NUM-APOL-SINISTRO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COUNT(*)
											FROM SEGUROS.SI_PROCESSO_JURID
											WHERE NUM_APOL_SINISTRO = '{this.SINISHIS_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string HOST_CONT_PROC_JURID { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }

        public static R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1 Execute(R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1 r311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1)
        {
            var ths = r311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R311_PESQUISA_PROC_JURIDICO_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_CONT_PROC_JURID = result[i++].Value?.ToString();
            return dta;
        }

    }
}