using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0685B
{
    public class M_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1 : QueryBasis<M_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET PERI_INICIAL =  '{this.WSIST_DTCURREN}'
				WHERE COD_USUARIO = 'VA0685B'
				AND COD_RELATORIO = 'VA0685B'";

            return query;
        }
        public string WSIST_DTCURREN { get; set; }

        public static void Execute(M_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1 m_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1)
        {
            var ths = m_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0250_ATUALIZA_RELAT_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}