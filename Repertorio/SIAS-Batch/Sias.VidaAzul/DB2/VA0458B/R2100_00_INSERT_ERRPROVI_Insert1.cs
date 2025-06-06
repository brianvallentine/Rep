using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0458B
{
    public class R2100_00_INSERT_ERRPROVI_Insert1 : QueryBasis<R2100_00_INSERT_ERRPROVI_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.ERROS_PROP_VIDAZUL
            VALUES ( :V0PROP-NRCERTIF,
            1846 )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.ERROS_PROP_VIDAZUL VALUES ( {FieldThreatment(this.V0PROP_NRCERTIF)}, 1846 )";

            return query;
        }
        public string V0PROP_NRCERTIF { get; set; }

        public static void Execute(R2100_00_INSERT_ERRPROVI_Insert1 r2100_00_INSERT_ERRPROVI_Insert1)
        {
            var ths = r2100_00_INSERT_ERRPROVI_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2100_00_INSERT_ERRPROVI_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}