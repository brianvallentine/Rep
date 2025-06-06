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
    public class M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1 : QueryBasis<M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET CODOPER = 820,
				DTMOVTO =  '{this.PROPVA_DTMOVTO}',
				OCORHIST =  '{this.PROPVA_OCORHIST}',
				SIT_INTERFACE = '0' ,
				TIMESTAMP = CURRENT TIMESTAMP,
				CODUSU = 'VA0130B' ,
				IDADE =  '{this.PROPVA_IDADE}'
				WHERE  NRCERTIF =  '{this.PROPVA_NRCERTIF}'";

            return query;
        }
        public string PROPVA_OCORHIST { get; set; }
        public string PROPVA_DTMOVTO { get; set; }
        public string PROPVA_IDADE { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static void Execute(M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1 m_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1)
        {
            var ths = m_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}