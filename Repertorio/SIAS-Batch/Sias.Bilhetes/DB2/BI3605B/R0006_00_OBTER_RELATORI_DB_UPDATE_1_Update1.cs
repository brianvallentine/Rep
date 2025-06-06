using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI3605B
{
    public class R0006_00_OBTER_RELATORI_DB_UPDATE_1_Update1 : QueryBasis<R0006_00_OBTER_RELATORI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET DATA_SOLICITACAO =  '{this.SISTEMAS_DATA_MOV_ABERTO}'
				WHERE  COD_USUARIO =  '{this.RELATORI_COD_USUARIO}'
				AND COD_RELATORIO =  '{this.RELATORI_COD_RELATORIO}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string RELATORI_COD_RELATORIO { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }

        public static void Execute(R0006_00_OBTER_RELATORI_DB_UPDATE_1_Update1 r0006_00_OBTER_RELATORI_DB_UPDATE_1_Update1)
        {
            var ths = r0006_00_OBTER_RELATORI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0006_00_OBTER_RELATORI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}