using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP1111B
{
    public class R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1 : QueryBasis<R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.EF_ENVIO_MOVTO_SAP
				SET NOM_PROGRAMA= 'VP1111B'
				WHERE  NUM_OCORR_MOVTO =  '{this.EF150_NUM_OCORR_MOVTO}'
				AND NUM_CONTRATO_SEGUR =  '{this.EF150_NUM_CONTRATO_SEGUR}'";

            return query;
        }
        public string EF150_NUM_CONTRATO_SEGUR { get; set; }
        public string EF150_NUM_OCORR_MOVTO { get; set; }

        public static void Execute(R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1 r20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1)
        {
            var ths = r20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R20800_UPDATE_EF_SAP_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}