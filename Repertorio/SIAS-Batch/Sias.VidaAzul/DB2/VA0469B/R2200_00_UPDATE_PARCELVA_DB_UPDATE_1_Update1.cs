using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0469B
{
    public class R2200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1 : QueryBasis<R2200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS_VIDAZUL
				SET VLMULTA =  '{this.WHOST_JUROS}',
				OCORR_HISTORICO =  '{this.PARCEVID_OCORR_HISTORICO}'
				WHERE  NUM_CERTIFICADO =  '{this.RELATORI_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.RELATORI_NUM_PARCELA}'";

            return query;
        }
        public string PARCEVID_OCORR_HISTORICO { get; set; }
        public string WHOST_JUROS { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static void Execute(R2200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1 r2200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1)
        {
            var ths = r2200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2200_00_UPDATE_PARCELVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}