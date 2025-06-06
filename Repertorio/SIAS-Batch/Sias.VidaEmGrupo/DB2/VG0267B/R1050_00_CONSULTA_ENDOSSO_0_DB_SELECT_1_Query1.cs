using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0267B
{
    public class R1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1_Query1 : QueryBasis<R1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COD_FONTE, 10)
            INTO :PROPOVA-COD-FONTE
            FROM SEGUROS.ENDOSSOS
            WHERE NUM_APOLICE = :V0HIST-NRAPOLICE
            AND NUM_ENDOSSO = 0
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COD_FONTE
							, 10)
											FROM SEGUROS.ENDOSSOS
											WHERE NUM_APOLICE = '{this.V0HIST_NRAPOLICE}'
											AND NUM_ENDOSSO = 0
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string PROPOVA_COD_FONTE { get; set; }
        public string V0HIST_NRAPOLICE { get; set; }

        public static R1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1_Query1 Execute(R1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1_Query1 r1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1_Query1)
        {
            var ths = r1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1050_00_CONSULTA_ENDOSSO_0_DB_SELECT_1_Query1();
            var i = 0;
            dta.PROPOVA_COD_FONTE = result[i++].Value?.ToString();
            return dta;
        }

    }
}