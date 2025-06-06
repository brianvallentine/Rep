using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0706B
{
    public class R0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1 : QueryBasis<R0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VAL_OPERACAO
            INTO :CBCONDEV-VAL-OPERACAO
            FROM SEGUROS.CB_CONTR_DEVPREMIO
            WHERE TIPO_MOVIMENTO = :CBCONDEV-TIPO-MOVIMENTO
            AND NUM_TITULO = :CBCONDEV-NUM-TITULO
            AND DATA_MOVIMENTO = :CBCONDEV-DATA-MOVIMENTO
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VAL_OPERACAO
											FROM SEGUROS.CB_CONTR_DEVPREMIO
											WHERE TIPO_MOVIMENTO = '{this.CBCONDEV_TIPO_MOVIMENTO}'
											AND NUM_TITULO = '{this.CBCONDEV_NUM_TITULO}'
											AND DATA_MOVIMENTO = '{this.CBCONDEV_DATA_MOVIMENTO}'
											WITH UR";

            return query;
        }
        public string CBCONDEV_VAL_OPERACAO { get; set; }
        public string CBCONDEV_TIPO_MOVIMENTO { get; set; }
        public string CBCONDEV_DATA_MOVIMENTO { get; set; }
        public string CBCONDEV_NUM_TITULO { get; set; }

        public static R0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1 Execute(R0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1 r0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1)
        {
            var ths = r0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0130_00_OBTER_PRM_DEV_DB_SELECT_1_Query1();
            var i = 0;
            dta.CBCONDEV_VAL_OPERACAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}