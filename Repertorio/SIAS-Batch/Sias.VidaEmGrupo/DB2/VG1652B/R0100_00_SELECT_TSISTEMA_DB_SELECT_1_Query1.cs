using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1652B
{
    public class R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1 : QueryBasis<R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT
            CURRENT DATE,
            CURRENT DATE + 15 DAYS,
            DAY(CURRENT DATE + 15 DAYS),
            DATA_MOV_ABERTO,
            DATA_MOV_ABERTO,
            LAST_DAY(LAST_DAY(DATA_MOV_ABERTO) + 1 DAY)
            INTO
            :WHOST-DATA-HOJE,
            :WHOST-DATA-HOJE-MAIS15,
            :WHOST-DIA-HOJE-MAIS15,
            :SISTEMAS-DATA-MOV-ABERTO,
            :WHOST-DATA-FATURAMENTO,
            :WHOST-DTTERVIG
            FROM
            SEGUROS.SISTEMAS
            WHERE
            IDE_SISTEMA = 'VG'
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT
											CURRENT DATE
							,
											CURRENT DATE + 15 DAYS
							,
											DAY(CURRENT DATE + 15 DAYS)
							,
											DATA_MOV_ABERTO
							,
											DATA_MOV_ABERTO
							,
											LAST_DAY(LAST_DAY(DATA_MOV_ABERTO) + 1 DAY)
											FROM
											SEGUROS.SISTEMAS
											WHERE
											IDE_SISTEMA = 'VG'
											WITH UR";

            return query;
        }
        public string WHOST_DATA_HOJE { get; set; }
        public string WHOST_DATA_HOJE_MAIS15 { get; set; }
        public string WHOST_DIA_HOJE_MAIS15 { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string WHOST_DATA_FATURAMENTO { get; set; }
        public string WHOST_DTTERVIG { get; set; }

        public static R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1 Execute(R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1 r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1)
        {
            var ths = r0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0100_00_SELECT_TSISTEMA_DB_SELECT_1_Query1();
            var i = 0;
            dta.WHOST_DATA_HOJE = result[i++].Value?.ToString();
            dta.WHOST_DATA_HOJE_MAIS15 = result[i++].Value?.ToString();
            dta.WHOST_DIA_HOJE_MAIS15 = result[i++].Value?.ToString();
            dta.SISTEMAS_DATA_MOV_ABERTO = result[i++].Value?.ToString();
            dta.WHOST_DATA_FATURAMENTO = result[i++].Value?.ToString();
            dta.WHOST_DTTERVIG = result[i++].Value?.ToString();
            return dta;
        }

    }
}