using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Outros.DB2.CS1301B
{
    public class R0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 : QueryBasis<R0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET DATA_SOLICITACAO =  '{this.SISTEMAS_DATA_MOV_ABERTO}',
				DATA_REFERENCIA =  '{this.SISTEMAS_DATA_MOV_ABERTO}',
				PERI_INICIAL =  '{this.RELATORI_PROX_INICIAL}',
				PERI_FINAL =  '{this.RELATORI_PROX_FINAL}'
				WHERE  COD_RELATORIO = 'CS1301B1'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string RELATORI_PROX_INICIAL { get; set; }
        public string RELATORI_PROX_FINAL { get; set; }

        public static void Execute(R0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 r0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1)
        {
            var ths = r0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0210_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}