using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0003B
{
    public class R0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1 : QueryBasis<R0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NUM_TITULO
            INTO :V0CTIT-NRTIT
            FROM SEGUROS.CONTROLE_TITULO
            WHERE NUM_TITULO >= :V0CTIT-NRTIT1
            AND NUM_TITULO <= :V0CTIT-NRTIT2
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NUM_TITULO
											FROM SEGUROS.CONTROLE_TITULO
											WHERE NUM_TITULO >= '{this.V0CTIT_NRTIT1}'
											AND NUM_TITULO <= '{this.V0CTIT_NRTIT2}'
											WITH UR";

            return query;
        }
        public string V0CTIT_NRTIT { get; set; }
        public string V0CTIT_NRTIT1 { get; set; }
        public string V0CTIT_NRTIT2 { get; set; }

        public static R0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1 Execute(R0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1 r0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1)
        {
            var ths = r0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0940_00_SELECT_V0CONTROLE_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0CTIT_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}