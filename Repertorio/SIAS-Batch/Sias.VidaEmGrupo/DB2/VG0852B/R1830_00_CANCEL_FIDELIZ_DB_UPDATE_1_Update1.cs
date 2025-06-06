using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0852B
{
    public class R1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1 : QueryBasis<R1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET SITUACAO_ENVIO = 'R' ,
				COD_USUARIO = 'VG0852B' ,
				SIT_PROPOSTA = 'CAN' ,
				NSAS_SIVPF =  '{this.PROPOFID_NSAS_SIVPF}',
				NSL =  '{this.PROPOFID_NSL}' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_PROPOSTA_SIVPF =  '{this.PROPOVA_NUM_CERTIFICADO}'
				OR NUM_SICOB =  '{this.PROPOVA_NUM_CERTIFICADO}'
				AND SIT_PROPOSTA <> 'CAN'";

            return query;
        }
        public string PROPOFID_NSAS_SIVPF { get; set; }
        public string PROPOFID_NSL { get; set; }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }

        public static void Execute(R1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1 r1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1)
        {
            var ths = r1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1830_00_CANCEL_FIDELIZ_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}