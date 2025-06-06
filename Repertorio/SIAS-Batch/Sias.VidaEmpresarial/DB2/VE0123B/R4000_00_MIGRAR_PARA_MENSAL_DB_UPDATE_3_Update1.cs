using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0123B
{
    public class R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1 : QueryBasis<R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.OPCAO_PAG_VIDAZUL
				SET DATA_TERVIGENCIA = '9999-12-31'
				WHERE  NUM_CERTIFICADO =  '{this.PROPOVA_NUM_CERTIFICADO}'
				AND DATA_TERVIGENCIA = '9998-12-31'";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1 r4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1)
        {
            var ths = r4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R4000_00_MIGRAR_PARA_MENSAL_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}