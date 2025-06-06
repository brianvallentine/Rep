using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2721B
{
    public class R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 : QueryBasis<R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET DATA_SOLICITACAO =  '{this.SISTEMAS_DATA_MOV_ABERTO}'
				WHERE  IDE_SISTEMA = 'VA'
				AND COD_USUARIO = 'VA2721B'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static void Execute(R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 r8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1)
        {
            var ths = r8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R8000_00_UPDATE_RELATORI_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}