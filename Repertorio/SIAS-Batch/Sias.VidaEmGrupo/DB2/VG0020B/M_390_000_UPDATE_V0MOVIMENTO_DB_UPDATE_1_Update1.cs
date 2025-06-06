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
    public class M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1 : QueryBasis<M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0MOVIMENTO
				SET DATA_INCLUSAO =  '{this.V1SISTEMA_DTMOVABE}',
				DATA_REFERENCIA =  '{this.MDATA_REFERENCIA}',
				PERI_RENOVACAO =  '{this.MPERI_RENOVACAO}'
				WHERE 
				COD_FONTE =  '{this.MCOD_FONTE}'
				AND NUM_PROPOSTA =  '{this.MNUM_PROPOSTA}'
				AND TIPO_SEGURADO =  '{this.MTIPO_SEGURADO}'";

            return query;
        }
        public string V1SISTEMA_DTMOVABE { get; set; }
        public string MDATA_REFERENCIA { get; set; }
        public string MPERI_RENOVACAO { get; set; }
        public string MTIPO_SEGURADO { get; set; }
        public string MNUM_PROPOSTA { get; set; }
        public string MCOD_FONTE { get; set; }

        public static void Execute(M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1 m_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1)
        {
            var ths = m_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_390_000_UPDATE_V0MOVIMENTO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}