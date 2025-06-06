using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0077B
{
    public class R0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1 : QueryBasis<R0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_SICOB
            INTO :BILHETE-NUM-BILHETE
            FROM SEGUROS.CONVERSAO_SICOB
            WHERE NUM_PROPOSTA_SIVPF =
            :WSHOST-NUMSIV01
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_SICOB
											FROM SEGUROS.CONVERSAO_SICOB
											WHERE NUM_PROPOSTA_SIVPF =
											'{this.WSHOST_NUMSIV01}'
											WITH UR";

            return query;
        }
        public string BILHETE_NUM_BILHETE { get; set; }
        public string WSHOST_NUMSIV01 { get; set; }

        public static R0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1 Execute(R0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1 r0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1)
        {
            var ths = r0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0330_00_SELECT_CONVERSI_DB_SELECT_1_Query1();
            var i = 0;
            dta.BILHETE_NUM_BILHETE = result[i++].Value?.ToString();
            return dta;
        }

    }
}