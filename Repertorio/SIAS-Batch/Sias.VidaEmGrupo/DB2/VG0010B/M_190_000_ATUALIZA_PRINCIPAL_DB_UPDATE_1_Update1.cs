using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0010B
{
    public class M_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1_Update1 : QueryBasis<M_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0SEGURAVG
				SET PCT_CONJUGE_VG =  '{this.MPCT_CONJUGE_VG}',
				PCT_CONJUGE_AP =  '{this.MPCT_CONJUGE_AP}'
				WHERE  NUM_CERTIFICADO =  '{this.MNUM_CERTIFICADO}'
				AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string MPCT_CONJUGE_VG { get; set; }
        public string MPCT_CONJUGE_AP { get; set; }
        public string MNUM_CERTIFICADO { get; set; }

        public static void Execute(M_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1_Update1 m_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1_Update1)
        {
            var ths = m_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_190_000_ATUALIZA_PRINCIPAL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}