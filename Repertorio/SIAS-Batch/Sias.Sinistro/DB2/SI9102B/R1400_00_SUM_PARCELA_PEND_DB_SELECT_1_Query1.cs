using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI9102B
{
    public class R1400_00_SUM_PARCELA_PEND_DB_SELECT_1_Query1 : QueryBasis<R1400_00_SUM_PARCELA_PEND_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT VALUE(COUNT(*), 0),
            VALUE(SUM(PRM_TOTAL_IX), 0)
            INTO :HOST-QTD-PARCELA-PEND,
            :PARCELAS-PRM-TOTAL-IX
            FROM SEGUROS.PARCELAS
            WHERE NUM_APOLICE = :SIARDEVC-NUM-APOLICE
            AND SIT_REGISTRO = '0'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT VALUE(COUNT(*)
							, 0)
							,
											VALUE(SUM(PRM_TOTAL_IX)
							, 0)
											FROM SEGUROS.PARCELAS
											WHERE NUM_APOLICE = '{this.SIARDEVC_NUM_APOLICE}'
											AND SIT_REGISTRO = '0'
											WITH UR";

            return query;
        }
        public string HOST_QTD_PARCELA_PEND { get; set; }
        public string PARCELAS_PRM_TOTAL_IX { get; set; }
        public string SIARDEVC_NUM_APOLICE { get; set; }

        public static R1400_00_SUM_PARCELA_PEND_DB_SELECT_1_Query1 Execute(R1400_00_SUM_PARCELA_PEND_DB_SELECT_1_Query1 r1400_00_SUM_PARCELA_PEND_DB_SELECT_1_Query1)
        {
            var ths = r1400_00_SUM_PARCELA_PEND_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R1400_00_SUM_PARCELA_PEND_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R1400_00_SUM_PARCELA_PEND_DB_SELECT_1_Query1();
            var i = 0;
            dta.HOST_QTD_PARCELA_PEND = result[i++].Value?.ToString();
            dta.PARCELAS_PRM_TOTAL_IX = result[i++].Value?.ToString();
            return dta;
        }

    }
}