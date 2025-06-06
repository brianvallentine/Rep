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
    public class M_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1 : QueryBasis<M_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0MOVIMENTO
				SET NUM_CERTIFICADO =  '{this.H_NUM_CERTIFICADO}',
				DAC_CERTIFICADO =  '{this.DAC_CERTIFICADO}'
				WHERE  COD_FONTE =  '{this.MCOD_FONTE}'
				AND NUM_PROPOSTA =  '{this.MNUM_PROPOSTA}'
				AND TIPO_SEGURADO =  '{this.MTIPO_SEGURADO}'";

            return query;
        }
        public string H_NUM_CERTIFICADO { get; set; }
        public string DAC_CERTIFICADO { get; set; }
        public string MTIPO_SEGURADO { get; set; }
        public string MNUM_PROPOSTA { get; set; }
        public string MCOD_FONTE { get; set; }

        public static void Execute(M_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1 m_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1)
        {
            var ths = m_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_520_000_UPDATE_MOVIMENTO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}