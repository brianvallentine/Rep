using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI5066B
{
    public class R0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1 : QueryBasis<R0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SINISTRO_HISTORICO
				SET SIT_REGISTRO = '1' ,
				NOM_PROGRAMA = 'SI5066B'
				WHERE  NUM_APOL_SINISTRO =  '{this.SINISHIS_NUM_APOL_SINISTRO}'
				AND OCORR_HISTORICO =  '{this.SINISHIS_OCORR_HISTORICO}'
				AND COD_OPERACAO =  '{this.SINISHIS_COD_OPERACAO}'";

            return query;
        }
        public string SINISHIS_NUM_APOL_SINISTRO { get; set; }
        public string SINISHIS_OCORR_HISTORICO { get; set; }
        public string SINISHIS_COD_OPERACAO { get; set; }

        public static void Execute(R0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1 r0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1)
        {
            var ths = r0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0420_UPDATE_HISTSINI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}