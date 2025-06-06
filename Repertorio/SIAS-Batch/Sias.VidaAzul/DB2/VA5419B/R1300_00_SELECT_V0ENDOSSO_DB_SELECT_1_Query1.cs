using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA5419B
{
    public class R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT A.DTEMIS,
            B.RAMO
            INTO :V0ENDO-DTEMIS,
            :V0ENDO-RAMO
            FROM SEGUROS.V0ENDOSSO A,
            SEGUROS.V0APOLICE B
            WHERE A.NUM_APOLICE = :V0RSAF-NUM-APOLICE
            AND A.NRENDOS = 0
            AND A.NUM_APOLICE = B.NUM_APOLICE
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT A.DTEMIS
							,
											B.RAMO
											FROM SEGUROS.V0ENDOSSO A
							,
											SEGUROS.V0APOLICE B
											WHERE A.NUM_APOLICE = '{this.V0RSAF_NUM_APOLICE}'
											AND A.NRENDOS = 0
											AND A.NUM_APOLICE = B.NUM_APOLICE";

            return query;
        }
        public string V0ENDO_DTEMIS { get; set; }
        public string V0ENDO_RAMO { get; set; }
        public string V0RSAF_NUM_APOLICE { get; set; }

        public static R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 r1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_V0ENDOSSO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0ENDO_DTEMIS = result[i++].Value?.ToString();
            dta.V0ENDO_RAMO = result[i++].Value?.ToString();
            return dta;
        }

    }
}