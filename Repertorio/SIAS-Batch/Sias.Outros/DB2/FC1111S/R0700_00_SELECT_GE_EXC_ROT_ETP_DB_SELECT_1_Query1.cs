using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC1111S
{
    public class R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1 : QueryBasis<R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            SELECT NOM_ROTINA,
            SEQ_ETAPA,
            DTH_INI_VIGENCIA,
            NUM_EXEC_ETAPA,
            DTA_INI_MOVIMENTO,
            DTA_FIM_MOVIMENTO,
            STA_EXECUCAO
            INTO :GE387-NOM-ROTINA,
            :GE387-SEQ-ETAPA,
            :GE387-DTH-INI-VIGENCIA:WS-NULL,
            :GE387-NUM-EXEC-ETAPA,
            :GE387-DTA-INI-MOVIMENTO:WS-NULL1,
            :GE387-DTA-FIM-MOVIMENTO:WS-NULL2,
            :GE387-STA-EXECUCAO
            FROM SEGUROS.GE_EXEC_ROTINA_ETAPA
            WHERE NOM_ROTINA = :GE387-NOM-ROTINA
            AND SEQ_ETAPA = :GE387-SEQ-ETAPA
            AND DTH_INI_VIGENCIA = :GE387-DTH-INI-VIGENCIA
            AND NUM_EXEC_ETAPA =
            (SELECT MAX (NUM_EXEC_ETAPA)
            FROM SEGUROS.GE_EXEC_ROTINA_ETAPA
            WHERE NOM_ROTINA = :GE387-NOM-ROTINA
            AND SEQ_ETAPA = :GE387-SEQ-ETAPA
            AND DTH_INI_VIGENCIA = :GE387-DTH-INI-VIGENCIA)
            WITH UR
            END-EXEC.
            */
            #endregion
            var query = @$"
				SELECT NOM_ROTINA
							,
											SEQ_ETAPA
							,
											DTH_INI_VIGENCIA
							,
											NUM_EXEC_ETAPA
							,
											DTA_INI_MOVIMENTO
							,
											DTA_FIM_MOVIMENTO
							,
											STA_EXECUCAO
											FROM SEGUROS.GE_EXEC_ROTINA_ETAPA
											WHERE NOM_ROTINA = '{this.GE387_NOM_ROTINA}'
											AND SEQ_ETAPA = '{this.GE387_SEQ_ETAPA}'
											AND DTH_INI_VIGENCIA = '{this.GE387_DTH_INI_VIGENCIA}'
											AND NUM_EXEC_ETAPA =
											(SELECT MAX (NUM_EXEC_ETAPA)
											FROM SEGUROS.GE_EXEC_ROTINA_ETAPA
											WHERE NOM_ROTINA = '{this.GE387_NOM_ROTINA}'
											AND SEQ_ETAPA = '{this.GE387_SEQ_ETAPA}'
											AND DTH_INI_VIGENCIA = '{this.GE387_DTH_INI_VIGENCIA}')
											WITH UR";

            return query;
        }
        public string GE387_NOM_ROTINA { get; set; }
        public string GE387_SEQ_ETAPA { get; set; }
        public string GE387_DTH_INI_VIGENCIA { get; set; }
        public string WS_NULL { get; set; }
        public string GE387_NUM_EXEC_ETAPA { get; set; }
        public string GE387_DTA_INI_MOVIMENTO { get; set; }
        public string WS_NULL1 { get; set; }
        public string GE387_DTA_FIM_MOVIMENTO { get; set; }
        public string WS_NULL2 { get; set; }
        public string GE387_STA_EXECUCAO { get; set; }

        public static R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1 Execute(R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1 r0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1)
        {
            var ths = r0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1;
            ths.SetQuery(ths.GetQuery());

            ths.Open();
            var isFetch = ths.Fetch();

            return isFetch ? ths : null;
        }

        public override R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1 OpenData(List<KeyValuePair<string, object>> result)
        {
            var dta = new R0700_00_SELECT_GE_EXC_ROT_ETP_DB_SELECT_1_Query1();
            var i = 0;
            dta.GE387_NOM_ROTINA = result[i++].Value?.ToString();
            dta.GE387_SEQ_ETAPA = result[i++].Value?.ToString();
            dta.GE387_DTH_INI_VIGENCIA = result[i++].Value?.ToString();
            dta.WS_NULL = string.IsNullOrWhiteSpace(dta.GE387_DTH_INI_VIGENCIA) ? "-1" : "0";
            dta.GE387_NUM_EXEC_ETAPA = result[i++].Value?.ToString();
            dta.GE387_DTA_INI_MOVIMENTO = result[i++].Value?.ToString();
            dta.WS_NULL1 = string.IsNullOrWhiteSpace(dta.GE387_DTA_INI_MOVIMENTO) ? "-1" : "0";
            dta.GE387_DTA_FIM_MOVIMENTO = result[i++].Value?.ToString();
            dta.WS_NULL2 = string.IsNullOrWhiteSpace(dta.GE387_DTA_FIM_MOVIMENTO) ? "-1" : "0";
            dta.GE387_STA_EXECUCAO = result[i++].Value?.ToString();
            return dta;
        }

    }
}