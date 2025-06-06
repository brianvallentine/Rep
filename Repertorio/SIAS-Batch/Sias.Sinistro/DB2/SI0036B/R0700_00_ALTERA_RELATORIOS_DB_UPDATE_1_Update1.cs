using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0036B
{
    public class R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1'
				WHERE  COD_RELATORIO = 'SI0036B'
				AND IDE_SISTEMA = 'SI'
				AND DATA_SOLICITACAO =  '{this.SISTEMAS_DATA_MOV_ABERTO}'
				AND SIT_REGISTRO = '0'";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }

        public static void Execute(R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1 r0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = r0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0700_00_ALTERA_RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}