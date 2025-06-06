using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0040B
{
    public class M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1 : QueryBasis<M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET SITUACAO = '3' ,
				NRPRIPARATZ = 0,
				QTDPARATZ = 0,
				CODOPER =  '{this.MCOD_OPERACAO}',
				DTMOVTO =  '{this.MDATA_OPERACAO}',
				CODUSU =  '{this.MCOD_USUARIO}',
				NRPROPOS =  '{this.MNUM_PROPOSTA}',
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.MNUM_CERTIFICADO}'";

            return query;
        }
        public string MDATA_OPERACAO { get; set; }
        public string MCOD_OPERACAO { get; set; }
        public string MNUM_PROPOSTA { get; set; }
        public string MCOD_USUARIO { get; set; }
        public string MNUM_CERTIFICADO { get; set; }

        public static void Execute(M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1 m_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1)
        {
            var ths = m_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_420_000_UPDATE_V0PROPOSTAVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}