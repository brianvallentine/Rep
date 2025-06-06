using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1 : QueryBasis<R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SINISTRO_MESTRE
				SET OCORR_HISTORICO =  '{this.SINISMES_OCORR_HISTORICO}',
				DATA_ULT_MOVIMENTO =  '{this.SISTEMAS_DATA_MOV_ABERTO}',
				SIT_REGISTRO = '2'
				WHERE  NUM_APOL_SINISTRO =  '{this.SINISMES_NUM_APOL_SINISTRO}'";

            return query;
        }
        public string SINISMES_OCORR_HISTORICO { get; set; }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static void Execute(R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1 r3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1)
        {
            var ths = r3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3100_00_ATUALI_SINI_MESTRE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}