using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC1111S
{
    public class R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1 : QueryBasis<R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOM_ROTINA,
            STA_ROTINA
            INTO :GE385-NOM-ROTINA,
            :GE385-STA-ROTINA
            FROM SEGUROS.GE_ROTINA_BATCH
            WHERE NOM_ROTINA = :GE385-NOM-ROTINA
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOM_ROTINA
							,
											STA_ROTINA
											FROM SEGUROS.GE_ROTINA_BATCH
											WHERE NOM_ROTINA = '{this.GE385_NOM_ROTINA}'";

            return query;
        }
        public string GE385_NOM_ROTINA { get; set; }
        public string GE385_STA_ROTINA { get; set; }

        public static R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1 Execute(R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1 r0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1)
        {
            var ths = r0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_SELECT_GE_ROT_BATCH_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE385_NOM_ROTINA = result[i++].Value?.ToString();
            dta.GE385_STA_ROTINA = result[i++].Value?.ToString();
            return dta;
        }

    }
}