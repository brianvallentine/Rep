using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1625B
{
    public class R2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1 : QueryBasis<R2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            VALUE (MIN (COD_PLANO),0)
            INTO
            :PLANOVGA-COD-PLANO
            FROM
            SEGUROS.PLANOS_VGAP
            WHERE NUM_APOLICE = :PROPOVA-NUM-APOLICE
            AND SIT_REGISTRO = '0'
            AND COD_SUBGRUPO = :PROPOVA-COD-SUBGRUPO
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT
											VALUE (MIN (COD_PLANO)
							,0)
											FROM
											SEGUROS.PLANOS_VGAP
											WHERE NUM_APOLICE = '{this.PROPOVA_NUM_APOLICE}'
											AND SIT_REGISTRO = '0'
											AND COD_SUBGRUPO = '{this.PROPOVA_COD_SUBGRUPO}'";

            return query;
        }
        public string PLANOVGA_COD_PLANO { get; set; }
        public string PROPOVA_COD_SUBGRUPO { get; set; }
        public string PROPOVA_NUM_APOLICE { get; set; }

        public static R2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1 Execute(R2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1 r2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1)
        {
            var ths = r2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R2460_SELECT_00_MIN_PLAN_DB_SELECT_1_Query1();
            var i = 0;
            dta.PLANOVGA_COD_PLANO = result[i++].Value?.ToString();
            return dta;
        }

    }
}