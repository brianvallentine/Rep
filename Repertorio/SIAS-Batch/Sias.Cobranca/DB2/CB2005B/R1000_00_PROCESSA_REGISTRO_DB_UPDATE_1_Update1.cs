using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Cobranca.DB2.CB2005B
{
    public class R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1 : QueryBasis<R1000_00_PROCESSA_REGISTRO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0NUMERO_AES
				SET SEQ_APOLICE =  '{this.V0NAES_SEQ_APOL}'
				WHERE  COD_ORGAO =  '{this.WH_JV1_COD_ORGAO}'
				AND COD_RAMO =  '{this.WWORK_RAMO_ANT}'";

            return query;
        }
        public string V0NAES_SEQ_APOL { get; set; }
        public string WH_JV1_COD_ORGAO { get; set; }
        public string WWORK_RAMO_ANT { get; set; }

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