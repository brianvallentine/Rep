using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0030B
{
    public class M_430_000_UPDATE_CARENCIAS_DB_UPDATE_1_Update1 : QueryBasis<M_430_000_UPDATE_CARENCIAS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.CARENCIAS_VGAP
				SET DATA_MOVIMENTO = CURRENT DATE,
				SITUACAO = '2' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_CERTIFICADO =  '{this.MNUM_CERTIFICADO}'
				AND SITUACAO = '0'";

            return query;
        }
        public string MNUM_CERTIFICADO { get; set; }

        public static void Execute(M_430_000_UPDATE_CARENCIAS_DB_UPDATE_1_Update1 m_430_000_UPDATE_CARENCIAS_DB_UPDATE_1_Update1)
        {
            var ths = m_430_000_UPDATE_CARENCIAS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_430_000_UPDATE_CARENCIAS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}