using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB1260B
{
    public class R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1 : QueryBasis<R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*),+0)
            INTO :WS-HOST-QTD-PARCELAS
            FROM SEGUROS.PARCELAS
            WHERE NUM_APOLICE = :PARCELAS-NUM-APOLICE
            AND NUM_ENDOSSO = :PARCELAS-NUM-ENDOSSO
            AND NUM_PARCELA > :PARCELAS-NUM-PARCELA
            AND SIT_REGISTRO = '1'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							,+0)
											FROM SEGUROS.PARCELAS
											WHERE NUM_APOLICE = '{this.PARCELAS_NUM_APOLICE}'
											AND NUM_ENDOSSO = '{this.PARCELAS_NUM_ENDOSSO}'
											AND NUM_PARCELA > '{this.PARCELAS_NUM_PARCELA}'
											AND SIT_REGISTRO = '1'
											WITH UR";

            return query;
        }
        public string WS_HOST_QTD_PARCELAS { get; set; }
        public string PARCELAS_NUM_APOLICE { get; set; }
        public string PARCELAS_NUM_ENDOSSO { get; set; }
        public string PARCELAS_NUM_PARCELA { get; set; }

        public static R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1 Execute(R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1 r1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1)
        {
            var ths = r1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1300_00_SELECT_PARCELAS_DB_SELECT_1_Query1();
            var i = 0;
            dta.WS_HOST_QTD_PARCELAS = result[i++].Value?.ToString();
            return dta;
        }

    }
}