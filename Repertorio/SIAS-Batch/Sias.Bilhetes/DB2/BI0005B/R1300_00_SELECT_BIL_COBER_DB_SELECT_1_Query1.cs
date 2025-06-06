using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0005B
{
    public class R1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(VAL_COBERTURA_IX, 0)
            INTO :V1BILC-IMPSEG-IX
            FROM SEGUROS.V0BILHETE_COBER
            WHERE RAMOFR = 72
            AND MODALIFR = 0
            AND COD_OPCAO = :V0BILH-OPCAO-COBER
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(VAL_COBERTURA_IX
							, 0)
											FROM SEGUROS.V0BILHETE_COBER
											WHERE RAMOFR = 72
											AND MODALIFR = 0
											AND COD_OPCAO = '{this.V0BILH_OPCAO_COBER}'";

            return query;
        }
        public string V1BILC_IMPSEG_IX { get; set; }
        public string V0BILH_OPCAO_COBER { get; set; }

        public static R1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1 r1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_BIL_COBER_DB_SELECT_1_Query1();
            var i = 0;
            dta.V1BILC_IMPSEG_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}