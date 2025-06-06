using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.FC1112S
{
    public class R0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1 : QueryBasis<R0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_EXEC_ROTINA_ETAPA
				SET QTD_REG_LIDOS =  '{this.GE387_QTD_REG_LIDOS}',
				QTD_REG_PROCS =  '{this.GE387_QTD_REG_PROCS}',
				QTD_REG_GRAVD =  '{this.GE387_QTD_REG_GRAVD}',
				QTD_REG_ALTER =  '{this.GE387_QTD_REG_ALTER}',
				QTD_REG_EXCLU =  '{this.GE387_QTD_REG_EXCLU}',
				STA_EXECUCAO =  '{this.GE387_STA_EXECUCAO}',
				DTH_FIM_EXECUCAO = CURRENT TIMESTAMP
				WHERE  NOM_ROTINA =  '{this.GE387_NOM_ROTINA}'
				AND SEQ_ETAPA =  '{this.GE387_SEQ_ETAPA}'
				AND DTH_INI_VIGENCIA =  '{this.GE387_DTH_INI_VIGENCIA}'
				AND NUM_EXEC_ETAPA =
				( SELECT MAX (NUM_EXEC_ETAPA)
				FROM SEGUROS.GE_EXEC_ROTINA_ETAPA
				WHERE  NOM_ROTINA =  '{this.GE387_NOM_ROTINA}'
				AND SEQ_ETAPA =  '{this.GE387_SEQ_ETAPA}' )";

            return query;
        }
        public string GE387_QTD_REG_LIDOS { get; set; }
        public string GE387_QTD_REG_PROCS { get; set; }
        public string GE387_QTD_REG_GRAVD { get; set; }
        public string GE387_QTD_REG_ALTER { get; set; }
        public string GE387_QTD_REG_EXCLU { get; set; }
        public string GE387_STA_EXECUCAO { get; set; }
        public string GE387_DTH_INI_VIGENCIA { get; set; }
        public string GE387_NOM_ROTINA { get; set; }
        public string GE387_SEQ_ETAPA { get; set; }

        public static void Execute(R0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1 r0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1)
        {
            var ths = r0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0300_00_UPD_FC_EXC_ROT_ETP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}