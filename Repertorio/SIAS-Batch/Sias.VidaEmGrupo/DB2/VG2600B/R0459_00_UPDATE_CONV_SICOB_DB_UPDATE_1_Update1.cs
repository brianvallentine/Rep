using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG2600B
{
    public class R0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1_Update1 : QueryBasis<R0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CONVERSAO_SICOB
				SET NUM_SICOB =  '{this.CONVERSI_NUM_SICOB}'
				WHERE NUM_PROPOSTA_SIVPF =  '{this.CONVERSI_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string CONVERSI_NUM_SICOB { get; set; }
        public string CONVERSI_NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1_Update1 r0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1_Update1)
        {
            var ths = r0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0459_00_UPDATE_CONV_SICOB_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}