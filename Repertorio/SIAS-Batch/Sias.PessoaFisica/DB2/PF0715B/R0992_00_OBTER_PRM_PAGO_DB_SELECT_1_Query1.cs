using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0715B
{
    public class R0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1 : QueryBasis<R0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT COD_FONTE,
            NUM_RCAP,
            VAL_RCAP
            INTO :DCLRCAPS.RCAPS-COD-FONTE,
            :DCLRCAPS.RCAPS-NUM-RCAP,
            :DCLRCAPS.RCAPS-VAL-RCAP
            FROM SEGUROS.RCAPS
            WHERE NUM_CERTIFICADO =:DCLRCAPS.RCAPS-NUM-CERTIFICADO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT COD_FONTE
							,
											NUM_RCAP
							,
											VAL_RCAP
											FROM SEGUROS.RCAPS
											WHERE NUM_CERTIFICADO ='{this.RCAPS_NUM_CERTIFICADO}'
											WITH UR";

            return query;
        }
        public string RCAPS_COD_FONTE { get; set; }
        public string RCAPS_NUM_RCAP { get; set; }
        public string RCAPS_VAL_RCAP { get; set; }
        public string RCAPS_NUM_CERTIFICADO { get; set; }

        public static R0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1 Execute(R0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1 r0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1)
        {
            var ths = r0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0992_00_OBTER_PRM_PAGO_DB_SELECT_1_Query1();
            var i = 0;
            dta.RCAPS_COD_FONTE = result[i++].Value?.ToString();
            dta.RCAPS_NUM_RCAP = result[i++].Value?.ToString();
            dta.RCAPS_VAL_RCAP = result[i++].Value?.ToString();
            return dta;
        }

    }
}