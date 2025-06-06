using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0031B
{
    public class R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1 : QueryBasis<R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT PROPAUTOM
            INTO :V0FONTE-PROPAUTOM
            FROM SEGUROS.V0FONTE
            WHERE FONTE = :V0SEG-COD-FONTE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT PROPAUTOM
											FROM SEGUROS.V0FONTE
											WHERE FONTE = '{this.V0SEG_COD_FONTE}'";

            return query;
        }
        public string V0FONTE_PROPAUTOM { get; set; }
        public string V0SEG_COD_FONTE { get; set; }

        public static R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1 Execute(R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1 r0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1)
        {
            var ths = r0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0224_25_OBTER_NUM_PROPOSTA_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0FONTE_PROPAUTOM = result[i++].Value?.ToString();
            return dta;
        }

    }
}