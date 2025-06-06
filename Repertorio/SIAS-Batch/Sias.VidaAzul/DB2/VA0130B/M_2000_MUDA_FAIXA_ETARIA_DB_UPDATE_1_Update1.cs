using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0130B
{
    public class M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1 : QueryBasis<M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0SEGURAVG
				SET FAIXA =  '{this.PLAVAVGA_FAIXA}'
				WHERE  NUM_CERTIFICADO =  '{this.PROPVA_NRCERTIF}'
				AND TIPO_SEGURADO = '1'";

            return query;
        }
        public string PLAVAVGA_FAIXA { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static void Execute(M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1 m_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1)
        {
            var ths = m_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}