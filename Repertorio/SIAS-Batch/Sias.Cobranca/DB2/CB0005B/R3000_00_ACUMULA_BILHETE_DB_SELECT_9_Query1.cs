using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB0005B
{
    public class R3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1 : QueryBasis<R3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VERSAO_BIL ,
            VALADT_IND +
            VALADT_GER +
            VALADT_SUN
            INTO :V0BILFX-VERSAO ,
            :V0BILFX-VALADT
            FROM SEGUROS.BILHETE_FAIXA
            WHERE NUMBIL_INI <= :V0BILH-NUMBIL
            AND NUMBIL_FIM >= :V0BILH-NUMBIL
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VERSAO_BIL 
							,
											VALADT_IND +
											VALADT_GER +
											VALADT_SUN
											FROM SEGUROS.BILHETE_FAIXA
											WHERE NUMBIL_INI <= '{this.V0BILH_NUMBIL}'
											AND NUMBIL_FIM >= '{this.V0BILH_NUMBIL}'";

            return query;
        }
        public string V0BILFX_VERSAO { get; set; }
        public string V0BILFX_VALADT { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1 Execute(R3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1 r3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1)
        {
            var ths = r3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3000_00_ACUMULA_BILHETE_DB_SELECT_9_Query1();
            var i = 0;
            dta.V0BILFX_VERSAO = result[i++].Value?.ToString();
            dta.V0BILFX_VALADT = result[i++].Value?.ToString();
            return dta;
        }

    }
}