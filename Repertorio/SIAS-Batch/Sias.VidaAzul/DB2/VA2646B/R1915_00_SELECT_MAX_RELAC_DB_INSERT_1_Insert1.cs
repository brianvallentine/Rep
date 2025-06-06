using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2646B
{
    public class R1915_00_SELECT_MAX_RELAC_DB_INSERT_1_Insert1 : QueryBasis<R1915_00_SELECT_MAX_RELAC_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES
            (
            :PESSOA-COD-PESSOA,
            :IDENTREL-COD-RELAC
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.R_PESSOA_TIPORELAC VALUES ( {FieldThreatment(this.PESSOA_COD_PESSOA)}, {FieldThreatment(this.IDENTREL_COD_RELAC)} )";

            return query;
        }
        public string PESSOA_COD_PESSOA { get; set; }
        public string IDENTREL_COD_RELAC { get; set; }

        public static void Execute(R1915_00_SELECT_MAX_RELAC_DB_INSERT_1_Insert1 r1915_00_SELECT_MAX_RELAC_DB_INSERT_1_Insert1)
        {
            var ths = r1915_00_SELECT_MAX_RELAC_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1915_00_SELECT_MAX_RELAC_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}