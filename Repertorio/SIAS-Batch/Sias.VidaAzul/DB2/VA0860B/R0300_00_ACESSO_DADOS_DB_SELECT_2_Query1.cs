using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0860B
{
    public class R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1 : QueryBasis<R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PARCELA
            INTO :HISLANCT-NUM-PARCELA
            FROM SEGUROS.HIST_LANC_CTA
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND NSAS = :HISLANCT-NSAS
            AND NSL = :HISLANCT-NSL
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_PARCELA
											FROM SEGUROS.HIST_LANC_CTA
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND NSAS = '{this.HISLANCT_NSAS}'
											AND NSL = '{this.HISLANCT_NSL}'
											WITH UR";

            return query;
        }
        public string HISLANCT_NUM_PARCELA { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string HISLANCT_NSAS { get; set; }
        public string HISLANCT_NSL { get; set; }

        public static R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1 Execute(R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1 r0300_00_ACESSO_DADOS_DB_SELECT_2_Query1)
        {
            var ths = r0300_00_ACESSO_DADOS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_ACESSO_DADOS_DB_SELECT_2_Query1();
            var i = 0;
            dta.HISLANCT_NUM_PARCELA = result[i++].Value?.ToString();
            return dta;
        }

    }
}