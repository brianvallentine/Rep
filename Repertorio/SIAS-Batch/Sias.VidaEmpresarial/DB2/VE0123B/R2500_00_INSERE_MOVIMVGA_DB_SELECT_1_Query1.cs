using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0123B
{
    public class R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1 : QueryBasis<R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT ULT_PROP_AUTOMAT + 1
            INTO :WS-NUM-PROPOSTA-AUT
            FROM SEGUROS.FONTES
            WHERE COD_FONTE = :PROPOVA-COD-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT ULT_PROP_AUTOMAT + 1
											FROM SEGUROS.FONTES
											WHERE COD_FONTE = '{this.PROPOVA_COD_FONTE}'";

            return query;
        }
        public string WS_NUM_PROPOSTA_AUT { get; set; }
        public string PROPOVA_COD_FONTE { get; set; }

        public static R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1 Execute(R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1 r2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1)
        {
            var ths = r2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2500_00_INSERE_MOVIMVGA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_NUM_PROPOSTA_AUT = result[i++].Value?.ToString();
            return dta;
        }

    }
}