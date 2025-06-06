using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0004S
{
    public class B0000_INS_RELAC_IDE_DB_SELECT_1_Query1 : QueryBasis<B0000_INS_RELAC_IDE_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(MAX(NUM_IDENTIFICACAO),0)
            INTO :WS-MAX-NUM-IDE
            FROM SEGUROS.IDENTIFICA_RELAC
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT VALUE(MAX(NUM_IDENTIFICACAO)
							,0)
											FROM SEGUROS.IDENTIFICA_RELAC
											WITH UR";

            return query;
        }
        public string WS_MAX_NUM_IDE { get; set; }

        public static B0000_INS_RELAC_IDE_DB_SELECT_1_Query1 Execute(B0000_INS_RELAC_IDE_DB_SELECT_1_Query1 b0000_INS_RELAC_IDE_DB_SELECT_1_Query1)
        {
            var ths = b0000_INS_RELAC_IDE_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B0000_INS_RELAC_IDE_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B0000_INS_RELAC_IDE_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_MAX_NUM_IDE = result[i++].Value?.ToString();
            return dta;
        }

    }
}