using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R1415_00_SEL_TITULO_Query3 : QueryBasis<R1415_00_SEL_TITULO_Query3>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NRTIT
            INTO :V0BANC-NRTIT
            FROM SEGUROS.V0BANCO
            WHERE BANCO = 104
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT NRTIT
											FROM SEGUROS.V0BANCO
											WHERE BANCO = 104
											WITH UR";

            return query;
        }
        public string V0BANC_NRTIT { get; set; }

        public static R1415_00_SEL_TITULO_Query3 Execute(R1415_00_SEL_TITULO_Query3 r1415_00_SEL_TITULO_Query3)
        {
            var ths = r1415_00_SEL_TITULO_Query3;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1415_00_SEL_TITULO_Query3 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1415_00_SEL_TITULO_Query3();
            var i = 0;
            dta.V0BANC_NRTIT = result[i++].Value?.ToString();
            return dta;
        }

    }
}