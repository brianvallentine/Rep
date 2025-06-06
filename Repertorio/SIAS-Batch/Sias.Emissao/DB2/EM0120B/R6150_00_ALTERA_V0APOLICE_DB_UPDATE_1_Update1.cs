using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0120B
{
    public class R6150_00_ALTERA_V0APOLICE_DB_UPDATE_1_Update1 : QueryBasis<R6150_00_ALTERA_V0APOLICE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0ENDOSSO
				SET SITUACAO = '2'
				,TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_APOLICE =  '{this.V0HISP_NUM_APOL}'
				AND NRENDOS = 0";

            return query;
        }
        public string V0HISP_NUM_APOL { get; set; }

        public static void Execute(R6150_00_ALTERA_V0APOLICE_DB_UPDATE_1_Update1 r6150_00_ALTERA_V0APOLICE_DB_UPDATE_1_Update1)
        {
            var ths = r6150_00_ALTERA_V0APOLICE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R6150_00_ALTERA_V0APOLICE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}