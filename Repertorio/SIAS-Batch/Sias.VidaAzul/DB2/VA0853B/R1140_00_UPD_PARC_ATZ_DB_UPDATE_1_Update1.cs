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
    public class R1140_00_UPD_PARC_ATZ_DB_UPDATE_1_Update1 : QueryBasis<R1140_00_UPD_PARC_ATZ_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS_VIDAZUL
				SET SIT_REGISTRO = ' ' ,
				OCORR_HISTORICO =  '{this.V0HIST_OCORRHISTCTA}',
				TIMESTAMP = CURRENT_TIMESTAMP
				WHERE NUM_CERTIFICADO =  '{this.V0PROP_NRCERTIF}'
				AND NUM_PARCELA =  '{this.WS_ATZ_NUM_PARCELA}'";

            return query;
        }
        public string V0HIST_OCORRHISTCTA { get; set; }
        public string WS_ATZ_NUM_PARCELA { get; set; }
        public string V0PROP_NRCERTIF { get; set; }

        public static void Execute(R1140_00_UPD_PARC_ATZ_DB_UPDATE_1_Update1 r1140_00_UPD_PARC_ATZ_DB_UPDATE_1_Update1)
        {
            var ths = r1140_00_UPD_PARC_ATZ_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1140_00_UPD_PARC_ATZ_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}