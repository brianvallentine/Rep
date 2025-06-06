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
    public class R1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1_Query1 : QueryBasis<R1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(IND_IOF, 'S' )
            INTO :V0SUBG-IND-IOF
            FROM SEGUROS.SUBGRUPOS_VGAP
            WHERE NUM_APOLICE = :V0HIST-NRAPOLICE
            AND COD_SUBGRUPO = :V0HIST-CODSUBES
            FETCH FIRST 1 ROW ONLY
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(IND_IOF
							, 'S' )
											FROM SEGUROS.SUBGRUPOS_VGAP
											WHERE NUM_APOLICE = '{this.V0HIST_NRAPOLICE}'
											AND COD_SUBGRUPO = '{this.V0HIST_CODSUBES}'
											FETCH FIRST 1 ROW ONLY
											WITH UR";

            return query;
        }
        public string V0SUBG_IND_IOF { get; set; }
        public string V0HIST_NRAPOLICE { get; set; }
        public string V0HIST_CODSUBES { get; set; }

        public static R1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1_Query1 Execute(R1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1_Query1 r1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1_Query1)
        {
            var ths = r1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1060_00_CONSULTA_IOF_BOLETO_DB_SELECT_1_Query1();
            var i = 0;
            dta.V0SUBG_IND_IOF = result[i++].Value?.ToString();
            return dta;
        }

    }
}