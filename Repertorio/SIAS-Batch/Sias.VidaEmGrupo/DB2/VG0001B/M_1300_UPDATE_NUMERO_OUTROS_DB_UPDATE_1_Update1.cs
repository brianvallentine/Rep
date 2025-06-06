using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1 : QueryBasis<M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.NUMERO_OUTROS
				SET NUM_CERT_VGAP =  '{this.H_NUM_CERTIFICADO}'
				WHERE  NUM_CERT_VGAP =  '{this.NUMEROUT_NUM_CERT_VGAP}' - 1";

            return query;
        }
        public string H_NUM_CERTIFICADO { get; set; }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }

        public static void Execute(M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1 m_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1)
        {
            var ths = m_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1300_UPDATE_NUMERO_OUTROS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}