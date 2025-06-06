using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0121B
{
    public class M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1 : QueryBasis<M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.OPCAO_PAG_VIDAZUL
				SET PERI_PAGAMENTO =  '{this.OPCAOP_PERIPGTO}',
				DIA_DEBITO =  '{this.OPCAOP_DIA_DEB}',
				OPCAO_PAGAMENTO =  '{this.OPCAOP_OPCAOPAG}'
				WHERE  NUM_CERTIFICADO =  '{this.PROPVA_NRCERTIF}'";

            return query;
        }
        public string OPCAOP_PERIPGTO { get; set; }
        public string OPCAOP_OPCAOPAG { get; set; }
        public string OPCAOP_DIA_DEB { get; set; }
        public string PROPVA_NRCERTIF { get; set; }

        public static void Execute(M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1 m_0100_OPCAOPAGVA_DB_UPDATE_1_Update1)
        {
            var ths = m_0100_OPCAOPAGVA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0100_OPCAOPAGVA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}