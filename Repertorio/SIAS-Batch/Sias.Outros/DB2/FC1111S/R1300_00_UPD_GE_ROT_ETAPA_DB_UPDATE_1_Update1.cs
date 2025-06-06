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
    public class R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1 : QueryBasis<R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.GE_ROTINA_ETAPA
				SET QTD_EXEC_ETAPA =  '{this.GE386_QTD_EXEC_ETAPA}'
				WHERE  NOM_ROTINA =  '{this.GE386_NOM_ROTINA}'
				AND SEQ_ETAPA =  '{this.GE386_SEQ_ETAPA}'
				AND DTH_INI_VIGENCIA =  '{this.GE386_DTH_INI_VIGENCIA}'
				AND DTH_FIM_VIGENCIA IS NULL
				AND IND_TIPO_ETAPA =  '{this.GE386_IND_TIPO_ETAPA}'
				AND NOM_PROGRAMA =  '{this.GE386_NOM_PROGRAMA}'";

            return query;
        }
        public string GE386_QTD_EXEC_ETAPA { get; set; }
        public string GE386_DTH_INI_VIGENCIA { get; set; }
        public string GE386_IND_TIPO_ETAPA { get; set; }
        public string GE386_NOM_PROGRAMA { get; set; }
        public string GE386_NOM_ROTINA { get; set; }
        public string GE386_SEQ_ETAPA { get; set; }

        public static void Execute(R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1 r1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1)
        {
            var ths = r1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1300_00_UPD_GE_ROT_ETAPA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}