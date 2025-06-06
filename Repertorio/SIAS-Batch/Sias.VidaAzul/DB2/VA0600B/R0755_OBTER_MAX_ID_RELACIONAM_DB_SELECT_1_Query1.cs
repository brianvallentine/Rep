using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0600B
{
    public class R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1 : QueryBasis<R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_IDENTIFICACAO),0)
            INTO :DCLIDENTIFICA-RELAC.NUM-IDENTIFICACAO
            FROM SEGUROS.IDENTIFICA_RELAC
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_IDENTIFICACAO)
							,0)
											FROM SEGUROS.IDENTIFICA_RELAC";

            return query;
        }
        public string NUM_IDENTIFICACAO { get; set; }

        public static R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1 Execute(R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1 r0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1)
        {
            var ths = r0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0755_OBTER_MAX_ID_RELACIONAM_DB_SELECT_1_Query1();
            var i = 0;
            dta.NUM_IDENTIFICACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}