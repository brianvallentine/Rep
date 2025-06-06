using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI8005B
{
    public class R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1 : QueryBasis<R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(QTD_SEGUROS, 0),
            VALUE(VLR_SOMA_IS, 0)
            INTO :GELMR-QTD-SEGUROS,
            :GELMR-VLR-SOMA-IS
            FROM SEGUROS.GE_LIMITE_DE_RISCO
            WHERE CGCCPF = :V0CLIE-CGCCPF
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(QTD_SEGUROS
							, 0)
							,
											VALUE(VLR_SOMA_IS
							, 0)
											FROM SEGUROS.GE_LIMITE_DE_RISCO
											WHERE CGCCPF = '{this.V0CLIE_CGCCPF}'
											WITH UR";

            return query;
        }
        public string GELMR_QTD_SEGUROS { get; set; }
        public string GELMR_VLR_SOMA_IS { get; set; }
        public string V0CLIE_CGCCPF { get; set; }

        public static R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1 Execute(R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1 r0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1)
        {
            var ths = r0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0320_00_SELECT_GELIMRISCO_DB_SELECT_1_Query1();
            var i = 0;
            dta.GELMR_QTD_SEGUROS = result[i++].Value?.ToString();
            dta.GELMR_VLR_SOMA_IS = result[i++].Value?.ToString();
            return dta;
        }

    }
}