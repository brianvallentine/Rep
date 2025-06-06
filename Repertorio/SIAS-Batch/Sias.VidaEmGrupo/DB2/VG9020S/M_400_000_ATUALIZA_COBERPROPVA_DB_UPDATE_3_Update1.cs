using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG9020S
{
    public class M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1 : QueryBasis<M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0PROPOSTAVA
				SET OCORHIST =  '{this.V0PROP_OCORHIST}',
				CODOPER =  '{this.MCOD_OPERACAO}',
				DTMOVTO =  '{this.MDATA_MOVIMENTO}',
				CODUSU =  '{this.MCOD_USUARIO}'
				WHERE 
				NRCERTIF =  '{this.MNUM_CERTIFICADO}'";

            return query;
        }
        public string V0PROP_OCORHIST { get; set; }
        public string MDATA_MOVIMENTO { get; set; }
        public string MCOD_OPERACAO { get; set; }
        public string MCOD_USUARIO { get; set; }
        public string MNUM_CERTIFICADO { get; set; }

        public static void Execute(M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1 m_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1)
        {
            var ths = m_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_400_000_ATUALIZA_COBERPROPVA_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}