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
    public class M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1 : QueryBasis<M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0PROPOSTAVA
				SET CODOPER =  '{this.COD_OPERACAO}',
				DTMOVTO =  '{this.DATA_MOVIMENTO}',
				OCORHIST =  '{this.PROPVA_OCORHIST}',
				SIT_INTERFACE = '0' ,
				CODUSU = 'VA0130B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NRCERTIF =  '{this.PROPVA_NRCERTIF}'";

            return query;
        }
        public string PROPVA_OCORHIST { get; set; }
        public string DATA_MOVIMENTO { get; set; }
        public string COD_OPERACAO { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static void Execute(M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1 m_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1)
        {
            var ths = m_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_2000_MUDA_FAIXA_ETARIA_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}