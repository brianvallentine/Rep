using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1 : QueryBasis<R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_PROPOSTA_SIVPF
            INTO :V0CONV-NUM-PROPOSTA-SIVPF
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_SICOB = :V0BILH-NUMBIL
            FETCH FIRST 1 ROWS ONLY
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NUM_PROPOSTA_SIVPF
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_SICOB = '{this.V0BILH_NUMBIL}'
											FETCH FIRST 1 ROWS ONLY
											WITH UR";

            return query;
        }
        public string V0CONV_NUM_PROPOSTA_SIVPF { get; set; }
        public string V0BILH_NUMBIL { get; set; }

        public static R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1 Execute(R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1 r0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1)
        {
            var ths = r0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0280_00_SELECT_CONVERSI_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CONV_NUM_PROPOSTA_SIVPF = result[i++].Value?.ToString();
            return dta;
        }

    }
}