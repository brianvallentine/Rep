using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0283B
{
    public class R0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1 : QueryBasis<R0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL SELECT SIGLUNIM
            INTO :V0MOED-SIGLUNIM
            FROM SEGUROS.V0MOEDA
            WHERE CODUNIMO = :V1RELA-CODUNIMO
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SIGLUNIM
											FROM SEGUROS.V0MOEDA
											WHERE CODUNIMO = '{this.V1RELA_CODUNIMO}'";

            return query;
        }
        public string V0MOED_SIGLUNIM { get; set; }
        public string V1RELA_CODUNIMO { get; set; }

        public static R0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1 Execute(R0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1 r0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1)
        {
            var ths = r0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0300_00_MONTA_CABECALHOS_DB_SELECT_2_Query1();
            var i = 0;
            dta.V0MOED_SIGLUNIM = result[i++].Value?.ToString();
            return dta;
        }

    }
}