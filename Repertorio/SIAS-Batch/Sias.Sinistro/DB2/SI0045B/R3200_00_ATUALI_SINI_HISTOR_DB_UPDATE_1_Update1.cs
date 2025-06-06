using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0045B
{
    public class R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1 : QueryBasis<R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.SINISTRO_HISTORICO
				SET SIT_REGISTRO = '2'
				WHERE  NUM_APOL_SINISTRO =  '{this.SINISMES_NUM_APOL_SINISTRO}'
				AND COD_OPERACAO IN (1181,1182,1183,1184,1081,
				1082,1083,1084,9000)
				AND SIT_REGISTRO IN ( '0' , '1' )";

            return query;
        }
        public string SINISMES_NUM_APOL_SINISTRO { get; set; }

        public static void Execute(R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1 r3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1)
        {
            var ths = r3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3200_00_ATUALI_SINI_HISTOR_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}