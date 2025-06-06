using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5437B
{
    public class R2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1 : QueryBasis<R2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_RELATORIO
            INTO :WS-COD-RELAT-CAR
            FROM SEGUROS.RELATORIOS
            WHERE NUM_CERTIFICADO = :PROPOVA-NUM-CERTIFICADO
            AND COD_RELATORIO = 'CARENCIA'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT COD_RELATORIO
											FROM SEGUROS.RELATORIOS
											WHERE NUM_CERTIFICADO = '{this.PROPOVA_NUM_CERTIFICADO}'
											AND COD_RELATORIO = 'CARENCIA'
											WITH UR";

            return query;
        }
        public string WS_COD_RELAT_CAR { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static R2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1 Execute(R2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1 r2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1)
        {
            var ths = r2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2203_VERIFICA_CARENCIAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COD_RELAT_CAR = result[i++].Value?.ToString();
            return dta;
        }

    }
}