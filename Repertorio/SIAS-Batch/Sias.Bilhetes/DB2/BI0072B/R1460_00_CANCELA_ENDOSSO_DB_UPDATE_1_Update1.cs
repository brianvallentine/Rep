using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0072B
{
    public class R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1 : QueryBasis<R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0ENDOSSO
				SET SITUACAO = '2' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.V1MVDB_NUM_APOLICE}'
				AND NRENDOS =  '{this.V1MVDB_NRENDOS}'";

            return query;
        }
        public string V1MVDB_NUM_APOLICE { get; set; }
        public string V1MVDB_NRENDOS { get; set; }

        public static void Execute(R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1 r1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1)
        {
            var ths = r1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1460_00_CANCELA_ENDOSSO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}