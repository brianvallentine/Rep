using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA2601B
{
    public class R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1 : QueryBasis<R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET SIT_PROPOSTA =  '{this.WHOST_SIT_PROPOSTA}',
				SITUACAO_ENVIO =  '{this.WHOST_SIT_ENVIO}',
				NRMATRVEN =  '{this.PROPOFID_NRMATRVEN}',
				COD_USUARIO = 'VA2601B' ,
				DTQITBCO =  '{this.WHOST_DATA_AGENDAMENTO}'
				WHERE  NUM_PROPOSTA_SIVPF =
				 '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string PROPOFID_NRMATRVEN { get; set; }
        public string WHOST_DATA_AGENDAMENTO { get; set; }
        public string WHOST_SIT_PROPOSTA { get; set; }
        public string WHOST_SIT_ENVIO { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1 r1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1)
        {
            var ths = r1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1600_00_UPDATE_PROPFID_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}