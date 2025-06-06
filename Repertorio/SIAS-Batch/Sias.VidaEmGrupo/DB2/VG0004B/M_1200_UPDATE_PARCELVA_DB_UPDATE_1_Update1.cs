using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0004B
{
    public class M_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1 : QueryBasis<M_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS_VIDAZUL
				SET SIT_REGISTRO =
				 '{this.ENDOSSOS_SIT_REGISTRO}',
				TIMESTAMP =
				CURRENT TIMESTAMP
				WHERE  NUM_CERTIFICADO =
				 '{this.HISCONPA_NUM_CERTIFICADO}'
				AND NUM_PARCELA =
				 '{this.HISCONPA_NUM_PARCELA}'";

            return query;
        }
        public string ENDOSSOS_SIT_REGISTRO { get; set; }
        public string HISCONPA_NUM_CERTIFICADO { get; set; }
        public string HISCONPA_NUM_PARCELA { get; set; }

        public static void Execute(M_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1 m_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1)
        {
            var ths = m_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1200_UPDATE_PARCELVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}