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
    public class R0100_00_INICIALIZA_PGM_Query1 : QueryBasis<R0100_00_INICIALIZA_PGM_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT DATA_MOV_ABERTO ,
            DATA_MOV_ABERTO + 14 DAYS ,
            DATA_MOV_ABERTO + 17 DAYS ,
            CURRENT DATE ,
            CURRENT DATE ,
            CURRENT DATE - 18 DAYS ,
            DATE(DATA_MOV_ABERTO) - 1 YEAR
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
				SELECT DATA_MOV_ABERTO 
							,
											DATA_MOV_ABERTO + 14 DAYS 
							,
											DATA_MOV_ABERTO + 17 DAYS 
							,
											CURRENT DATE 
							,
											CURRENT DATE 
							,
											CURRENT DATE - 18 DAYS 
							,
											DATE(DATA_MOV_ABERTO) - 1 YEAR
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

        public static R0100_00_INICIALIZA_PGM_Query1 Execute(R0100_00_INICIALIZA_PGM_Query1 r0100_00_INICIALIZA_PGM_Query1)
        {
            var ths = r0100_00_INICIALIZA_PGM_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_INICIALIZA_PGM_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_INICIALIZA_PGM_Query1();
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