using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG1625B
{
    public class R3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1 : QueryBasis<R3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS_VIDAZUL
				SET PREMIO_VG =  '{this.WHOST_PRMVG}'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.PROPOVA_OCORR_HISTORICO}'";

            return query;
        }
        public string WHOST_PRMVG { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string PROPOVA_OCORR_HISTORICO { get; set; }

        public static void Execute(R3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1 r3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1)
        {
            var ths = r3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}