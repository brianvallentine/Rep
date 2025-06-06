using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0075B
{
    public class R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1 : QueryBasis<R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0MOVDEBCC_CEF
				SET SIT_COBRANCA =  '{this.V1MVDB_SIT_COBRANCA}',
				COD_USUARIO = 'BI0075B' ,
				TIMESTAMP = CURRENT TIMESTAMP,
				NUM_LOTE =  '{this.V0AVIS_NRAVISO}'
				WHERE  NUM_APOLICE =  '{this.V1MVDB_NUM_APOLICE}'
				AND NRENDOS =  '{this.V1MVDB_NRENDOS}'
				AND COD_CONVENIO =  '{this.V1MVDB_COD_CONVENIO}'";

            return query;
        }
        public string V1MVDB_SIT_COBRANCA { get; set; }
        public string V0AVIS_NRAVISO { get; set; }
        public string V1MVDB_COD_CONVENIO { get; set; }
        public string V1MVDB_NUM_APOLICE { get; set; }
        public string V1MVDB_NRENDOS { get; set; }

        public static void Execute(R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1 r3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1)
        {
            var ths = r3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3460_00_UPDATE_V0MOVDEBCC_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}