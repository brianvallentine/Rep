using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1 : QueryBasis<M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.ENDOSSOS
				SET DATA_INIVIGENCIA =  '{this.WS_INIVIGENCIA}'
				, DATA_TERVIGENCIA =  '{this.WS_TERVIGENCIA}'
				WHERE  NUM_APOLICE =  '{this.SUBGVGAP_NUM_APOLICE}'
				AND NUM_ENDOSSO = 0";

            return query;
        }
        public string WS_INIVIGENCIA { get; set; }
        public string WS_TERVIGENCIA { get; set; }
        public string SUBGVGAP_NUM_APOLICE { get; set; }

        public static void Execute(M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1 m_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1)
        {
            var ths = m_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_5900_AJUSTA_INIVIGENCIA_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}