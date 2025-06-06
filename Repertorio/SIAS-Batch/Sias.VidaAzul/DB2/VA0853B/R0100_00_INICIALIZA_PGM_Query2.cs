using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0853B
{
    public class R0100_00_INICIALIZA_PGM_Query2 : QueryBasis<R0100_00_INICIALIZA_PGM_Query2>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATE(:LK-DT-PROCESSAMENTO) ,
            DATE(:LK-DT-PROCESSAMENTO) + 14 DAYS ,
            DATE(:LK-DT-PROCESSAMENTO) + 17 DAYS ,
            DATE(:LK-DT-PROCESSAMENTO) ,
            DATE(:LK-DT-PROCESSAMENTO) ,
            DATE(:LK-DT-PROCESSAMENTO) - 18 DAYS ,
            DATE(:LK-DT-PROCESSAMENTO) - 1 YEAR
            INTO :V1SIST-DTMOVABE ,
            :V1SIST-DT-15D-UTIL ,
            :V1SIST-DT-18D-UTIL ,
            :V1SIST-DTHOJE ,
            :V1SIST-DTVENFIM-6D-UTIL,
            :V1SIST-DTVENFIM-CN-GE853S,
            :V1SIST-DTVENFIM-1Y-GE853S
            FROM SEGUROS.SISTEMAS
            WHERE IDE_SISTEMA = 'VA'
            WITH UR
            END-EXEC
            */
            #endregion
            var query = @$"
				SELECT DATE('{this.LK_DT_PROCESSAMENTO}') 
							,
											DATE('{this.LK_DT_PROCESSAMENTO}') + 14 DAYS 
							,
											DATE('{this.LK_DT_PROCESSAMENTO}') + 17 DAYS 
							,
											DATE('{this.LK_DT_PROCESSAMENTO}') 
							,
											DATE('{this.LK_DT_PROCESSAMENTO}') 
							,
											DATE('{this.LK_DT_PROCESSAMENTO}') - 18 DAYS 
							,
											DATE('{this.LK_DT_PROCESSAMENTO}') - 1 YEAR
											FROM SEGUROS.SISTEMAS
											WHERE IDE_SISTEMA = 'VA'
											WITH UR";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1SIST_DT_15D_UTIL { get; set; }
        public string V1SIST_DT_18D_UTIL { get; set; }
        public string V1SIST_DTHOJE { get; set; }
        public string V1SIST_DTVENFIM_6D_UTIL { get; set; }
        public string V1SIST_DTVENFIM_CN_GE853S { get; set; }
        public string V1SIST_DTVENFIM_1Y_GE853S { get; set; }
        public string LK_DT_PROCESSAMENTO { get; set; }

        public static R0100_00_INICIALIZA_PGM_Query2 Execute(R0100_00_INICIALIZA_PGM_Query2 r0100_00_INICIALIZA_PGM_Query2)
        {
            var ths = r0100_00_INICIALIZA_PGM_Query2;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_INICIALIZA_PGM_Query2 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_INICIALIZA_PGM_Query2();
            var i = 0;
            dta.V1SIST_DTMOVABE = result[i++].Value?.ToString();
            dta.V1SIST_DT_15D_UTIL = result[i++].Value?.ToString();
            dta.V1SIST_DT_18D_UTIL = result[i++].Value?.ToString();
            dta.V1SIST_DTHOJE = result[i++].Value?.ToString();
            dta.V1SIST_DTVENFIM_6D_UTIL = result[i++].Value?.ToString();
            dta.V1SIST_DTVENFIM_CN_GE853S = result[i++].Value?.ToString();
            dta.V1SIST_DTVENFIM_1Y_GE853S = result[i++].Value?.ToString();
            return dta;
        }

    }
}