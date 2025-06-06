using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA3437B
{
    public class R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1 : QueryBasis<R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:LK-DT-PROCESSAMENTO),
            DATE(:LK-DT-PROCESSAMENTO) - 1 YEAR,
            DATE(:LK-DT-PROCESSAMENTO) - 15 DAYS,
            MONTH(DATE(:LK-DT-PROCESSAMENTO)),
            YEAR(DATE(:LK-DT-PROCESSAMENTO))
            INTO :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DATA-MOV-ABERTO-1,
            :SISTEMAS-DATA-MOV-ABERTO-15D,
            :V1SIST-MESREFER,
            :V1SIST-ANOREFER
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'FI'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.LK_DT_PROCESSAMENTO}')
							,
											DATE('{this.LK_DT_PROCESSAMENTO}') - 1 YEAR
							,
											DATE('{this.LK_DT_PROCESSAMENTO}') - 15 DAYS
							,
											MONTH(DATE('{this.LK_DT_PROCESSAMENTO}'))
							,
											YEAR(DATE('{this.LK_DT_PROCESSAMENTO}'))
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'FI'
											WITH UR";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO_1 { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO_15D { get; set; }
        public string V1SIST_MESREFER { get; set; }
        public string V1SIST_ANOREFER { get; set; }
        public string LK_DT_PROCESSAMENTO { get; set; }

        public static R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1 Execute(R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1 r0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1)
        {
            var ths = r0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_SISTEMAS_DB_SELECT_2_Query1();
            var i = 0;
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.SISTEMAS_DATA_MOV_ABERTO_1 = result[i++].Value?.ToString();
            dta.SISTEMAS_DATA_MOV_ABERTO_15D = result[i++].Value?.ToString();
            dta.V1SIST_MESREFER = result[i++].Value?.ToString();
            dta.V1SIST_ANOREFER = result[i++].Value?.ToString();
            return dta;
        }

    }
}