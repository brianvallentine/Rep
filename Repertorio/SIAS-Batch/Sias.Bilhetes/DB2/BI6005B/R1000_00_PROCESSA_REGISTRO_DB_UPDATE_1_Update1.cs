using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI6005B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0NUMERO_AES
				SET SEQ_APOLICE =  '{this.V0NAES_SEQ_APOL}'
				WHERE  COD_ORGAO = 10
				AND COD_RAMO = 14";

            return query;
        }
        public string V0NAES_SEQ_APOL { get; set; }

        public static void Execute(R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1)
        {
            var ths = r1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}