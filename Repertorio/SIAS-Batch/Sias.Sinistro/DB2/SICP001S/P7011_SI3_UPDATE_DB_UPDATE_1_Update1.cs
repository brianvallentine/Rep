using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SICP001S
{
    public class P7011_SI3_UPDATE_DB_UPDATE_1_Update1 : QueryBasis<P7011_SI3_UPDATE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SINISTRO_HISTORICO
				SET
				DATA_MOVIMENTO =
				 '{this.SINISHIS_DATA_MOVIMENTO}'
				,HORA_OPERACAO =
				CURRENT TIME
				,SIT_REGISTRO =
				'1'
				,TIMESTAMP =
				CURRENT TIMESTAMP
				,NOM_PROGRAMA =
				 {FieldThreatment((this.WH_PROGRAMA_NULL?.ToInt() == -1 ? null : $"{this.SINISHIS_NOM_PROGRAMA}"))}
				WHERE  NUM_APOL_SINISTRO =  '{this.SINISHIS_NUM_APOL_SINISTRO}'
				AND OCORR_HISTORICO =  '{this.SINISHIS_OCORR_HISTORICO}'
				AND COD_OPERACAO =  '{this.SINISHIS_COD_OPERACAO}'";

            return query;
        }
        public string SINISHIS_NOM_PROGRAMA { get; set; }
        public string WH_PROGRAMA_NULL { get; set; }
        public string SINISHIS_DATA_MOVIMENTO { get; set; }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }

        public static void Execute(P7011_SI3_UPDATE_DB_UPDATE_1_Update1 p7011_SI3_UPDATE_DB_UPDATE_1_Update1)
        {
            var ths = p7011_SI3_UPDATE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override P7011_SI3_UPDATE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}