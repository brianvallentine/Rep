using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0020B
{
    public class M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1 : QueryBasis<M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.CARENCIAS_VGAP
				SET DATA_MOVIMENTO = CURRENT DATE,
				SITUACAO = '2' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_CERTIFICADO =  '{this.MNUM_CERTIFICADO}'
				AND OCORR_HISTORICO =  '{this.V0CAR_OCORHIST}'";

            return query;
        }
        public string MNUM_CERTIFICADO { get; set; }
        public string V0CAR_OCORHIST { get; set; }

        public static void Execute(M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1 m_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1)
        {
            var ths = m_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_420_020_ATUALIZA_CARENCIAS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}