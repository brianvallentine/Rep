using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2720B
{
    public class R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1'
				, TIMESTAMP = CURRENT TIMESTAMP
				WHERE  DATA_SOLICITACAO =  '{this.RELATORI_DATA_SOLICITACAO}'
				AND COD_RELATORIO =  '{this.RELATORI_COD_RELATORIO}'
				AND NUM_CERTIFICADO =  '{this.RELATORI_NUM_CERTIFICADO}'
				AND NUM_PARCELA =  '{this.RELATORI_NUM_PARCELA}'";

            return query;
        }
        public string RELATORI_DATA_SOLICITACAO { get; set; }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_NUM_PARCELA { get; set; }

        public static void Execute(R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 r1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1160_UPDATE_RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}