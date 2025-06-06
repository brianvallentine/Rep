using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2722B
{
    public class R0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1 : QueryBasis<R0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1'
				WHERE  NUM_APOLICE =  '{this.RELATORI_NUM_APOLICE}'
				AND NUM_CERTIFICADO =  '{this.RELATORI_NUM_CERTIFICADO}'";

            return query;
        }
        public string RELATORI_NUM_CERTIFICADO { get; set; }
        public string RELATORI_NUM_APOLICE { get; set; }

        public static void Execute(R0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1 r0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1)
        {
            var ths = r0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0013_00_UPDATE_RELAT_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}