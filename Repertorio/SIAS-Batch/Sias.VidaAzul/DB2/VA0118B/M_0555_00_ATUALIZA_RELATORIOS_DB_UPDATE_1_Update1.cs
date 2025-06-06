using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1_Update1 : QueryBasis<M_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.RELATORIOS
				SET SIT_REGISTRO = '1'
				WHERE  NUM_CERTIFICADO =  '{this.PROPVA_NRCERTIF}'
				AND COD_RELATORIO =  '{this.RELATO_CODRELAT}'
				AND SIT_REGISTRO = '0'";

            return query;
        }
        public string PROPVA_NRCERTIF { get; set; }
        public string RELATO_CODRELAT { get; set; }

        public static void Execute(M_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1_Update1 m_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1_Update1)
        {
            var ths = m_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0555_00_ATUALIZA_RELATORIOS_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}