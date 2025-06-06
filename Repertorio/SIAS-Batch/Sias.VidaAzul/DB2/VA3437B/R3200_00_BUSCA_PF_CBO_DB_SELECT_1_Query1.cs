using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3437B
{
    public class R3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1 : QueryBasis<R3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_CBO
            INTO :WS-COD-CBO
            FROM SEGUROS.PF_CBO
            WHERE NUM_PROPOSTA_SIVPF = :WHOST-NRCERTIF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_CBO
											FROM SEGUROS.PF_CBO
											WHERE NUM_PROPOSTA_SIVPF = '{this.WHOST_NRCERTIF}'
											WITH UR";

            return query;
        }
        public string WS_COD_CBO { get; set; }
        public string WHOST_NRCERTIF { get; set; }

        public static R3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1 Execute(R3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1 r3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1)
        {
            var ths = r3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R3200_00_BUSCA_PF_CBO_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_COD_CBO = result[i++].Value?.ToString();
            return dta;
        }

    }
}