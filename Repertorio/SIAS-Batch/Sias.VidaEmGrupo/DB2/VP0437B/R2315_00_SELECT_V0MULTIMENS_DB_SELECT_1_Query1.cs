using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0437B
{
    public class R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1 : QueryBasis<R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT JDE,
            JDL
            INTO :COBMENVG-JDE,
            :COBMENVG-JDL
            FROM SEGUROS.COBRANCA_MENS_VGAP
            WHERE IDFORM = 'A4'
            AND NUM_APOLICE =
            :COBMENVG-NUM-APOLICE
            AND CODSUBES = :COBMENVG-CODSUBES
            AND COD_OPERACAO = 2
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT JDE
							,
											JDL
											FROM SEGUROS.COBRANCA_MENS_VGAP
											WHERE IDFORM = 'A4'
											AND NUM_APOLICE =
											'{this.COBMENVG_NUM_APOLICE}'
											AND CODSUBES = '{this.COBMENVG_CODSUBES}'
											AND COD_OPERACAO = 2";

            return query;
        }
        public string COBMENVG_JDE { get; set; }
        public string COBMENVG_JDL { get; set; }
        public string COBMENVG_NUM_APOLICE { get; set; }
        public string COBMENVG_CODSUBES { get; set; }

        public static R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1 Execute(R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1 r2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1)
        {
            var ths = r2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2315_00_SELECT_V0MULTIMENS_DB_SELECT_1_Query1();
            var i = 0;
            dta.COBMENVG_JDE = result[i++].Value?.ToString();
            dta.COBMENVG_JDL = result[i++].Value?.ToString();
            return dta;
        }

    }
}