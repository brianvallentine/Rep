using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0010B
{
    public class B3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1 : QueryBasis<B3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT SDOATU
            INTO :V1ASAL-SDOATU
            FROM SEGUROS.V1AVISOS_SALDOS
            WHERE BCOAVISO = :V1ASAL-BCOAVISO
            AND AGEAVISO = :V1ASAL-AGEAVISO
            AND NRAVISO = :V1ASAL-NRAVISO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT SDOATU
											FROM SEGUROS.V1AVISOS_SALDOS
											WHERE BCOAVISO = '{this.V1ASAL_BCOAVISO}'
											AND AGEAVISO = '{this.V1ASAL_AGEAVISO}'
											AND NRAVISO = '{this.V1ASAL_NRAVISO}'
											WITH UR";

            return query;
        }
        public string V1ASAL_SDOATU { get; set; }
        public string V1ASAL_BCOAVISO { get; set; }
        public string V1ASAL_AGEAVISO { get; set; }
        public string V1ASAL_NRAVISO { get; set; }

        public static B3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1 Execute(B3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1 b3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1)
        {
            var ths = b3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override B3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new B3200_SELECT_V1AVISALDOS_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1ASAL_SDOATU = result[i++].Value?.ToString();
            return dta;
        }

    }
}