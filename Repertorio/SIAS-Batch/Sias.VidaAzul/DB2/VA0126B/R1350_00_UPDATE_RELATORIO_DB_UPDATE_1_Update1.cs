using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0126B
{
    public class R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1 : QueryBasis<R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET DATA_SOLICITACAO =  '{this.SISTEMAS_DATA_MOV_ABERTO}'
				,TIMESTAMP = CURRENT TIMESTAMP
				WHERE  COD_USUARIO =  '{this.RELATORI_COD_USUARIO}'
				AND IDE_SISTEMA =  '{this.RELATORI_IDE_SISTEMA}'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string RELATORI_COD_USUARIO { get; set; }
        public string RELATORI_IDE_SISTEMA { get; set; }

        public static void Execute(R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1 r1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1)
        {
            var ths = r1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1350_00_UPDATE_RELATORIO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}