using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0001B
{
    public class M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1 : QueryBasis<M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PARCELAS_VIDAZUL
				SET SIT_REGISTRO = '1' ,
				TIMESTAMP = CURRENT_TIMESTAMP
				WHERE  NUM_CERTIFICADO =  '{this.NUMEROUT_NUM_CERT_VGAP}'
				AND NUM_PARCELA = 1";

            return query;
        }
        public string NUMEROUT_NUM_CERT_VGAP { get; set; }

        public static void Execute(M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1 m_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1)
        {
            var ths = m_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_5520_UPDATE_SIT_PARCELA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}