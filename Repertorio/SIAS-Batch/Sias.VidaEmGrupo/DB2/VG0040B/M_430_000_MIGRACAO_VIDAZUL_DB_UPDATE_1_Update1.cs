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
    public class M_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1_Update1 : QueryBasis<M_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE
				SEGUROS.V0SEGURAVG
				SET NUM_CARNE =  '{this.SNUM_CARNE}'
				WHERE 
				NUM_CERTIFICADO =  '{this.MNUM_CERTIFICADO}'
				AND TIPO_SEGURADO =  '{this.MTIPO_SEGURADO}'";

            return query;
        }
        public string SNUM_CARNE { get; set; }
        public string MNUM_CERTIFICADO { get; set; }
        public string MTIPO_SEGURADO { get; set; }

        public static void Execute(M_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1_Update1 m_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1_Update1)
        {
            var ths = m_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_430_000_MIGRACAO_VIDAZUL_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}