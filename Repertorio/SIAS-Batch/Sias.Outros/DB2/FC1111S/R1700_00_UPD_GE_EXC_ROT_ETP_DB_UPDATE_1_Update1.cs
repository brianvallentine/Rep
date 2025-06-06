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
    public class R1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1 : QueryBasis<R1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_EXEC_ROTINA_ETAPA
				SET DTA_FIM_MOVIMENTO =  '{this.GE387_DTA_FIM_MOVIMENTO}',
				QTD_REG_LIDOS =  '{this.GE387_QTD_REG_LIDOS}',
				QTD_REG_PROCS =  '{this.GE387_QTD_REG_PROCS}',
				QTD_REG_GRAVD =  '{this.GE387_QTD_REG_GRAVD}',
				QTD_REG_ALTER =  '{this.GE387_QTD_REG_ALTER}',
				QTD_REG_EXCLU =  '{this.GE387_QTD_REG_EXCLU}',
				STA_EXECUCAO =  '{this.GE387_STA_EXECUCAO}',
				DTH_INI_EXECUCAO = CURRENT TIMESTAMP,
				DTH_FIM_EXECUCAO = NULL
				WHERE  NOM_ROTINA =  '{this.GE387_NOM_ROTINA}'
				AND SEQ_ETAPA =  '{this.GE387_SEQ_ETAPA}'
				AND DTH_INI_VIGENCIA =  '{this.GE387_DTH_INI_VIGENCIA}'
				AND NUM_EXEC_ETAPA =  '{this.GE387_NUM_EXEC_ETAPA}'";

            return query;
        }
        public string GE387_DTA_FIM_MOVIMENTO { get; set; }
        public string GE387_QTD_REG_LIDOS { get; set; }
        public string GE387_QTD_REG_PROCS { get; set; }
        public string GE387_QTD_REG_GRAVD { get; set; }
        public string GE387_QTD_REG_ALTER { get; set; }
        public string GE387_QTD_REG_EXCLU { get; set; }
        public string GE387_STA_EXECUCAO { get; set; }
        public string GE387_DTH_INI_VIGENCIA { get; set; }
        public string GE387_NUM_EXEC_ETAPA { get; set; }
        public string GE387_NOM_ROTINA { get; set; }
        public string GE387_SEQ_ETAPA { get; set; }

        public static void Execute(R1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1 r1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1)
        {
            var ths = r1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1700_00_UPD_GE_EXC_ROT_ETP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}