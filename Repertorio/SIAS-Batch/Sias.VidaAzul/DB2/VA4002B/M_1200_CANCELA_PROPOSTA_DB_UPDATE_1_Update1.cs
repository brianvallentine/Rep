using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4002B
{
    public class M_1200_CANCELA_PROPOSTA_DB_UPDATE_1_Update1 : QueryBasis<M_1200_CANCELA_PROPOSTA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTAS_VA
				SET SIT_REGISTRO = '4' ,
				COD_USUARIO = 'VA4002B'
				WHERE  NUM_CERTIFICADO =  '{this.PROPVA_NRCERTIF}'";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }

        public static void Execute(M_1200_CANCELA_PROPOSTA_DB_UPDATE_1_Update1 m_1200_CANCELA_PROPOSTA_DB_UPDATE_1_Update1)
        {
            var ths = m_1200_CANCELA_PROPOSTA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1200_CANCELA_PROPOSTA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}