using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.PessoaFisica.DB2.PF0002B
{
    public class R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1 : QueryBasis<R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET DATA_CREDITO =  '{this.V0RCOM_DTMOVTO}' ,
				AGEPGTO =  '{this.CONVSICOB_AGEPGTO}' ,
				DTQITBCO =  '{this.CONVSICOB_DTQITBCO}' ,
				VAL_PAGO =  '{this.CONVSICOB_VAL_RCAP}'
				WHERE NUM_PROPOSTA_SIVPF =  '{this.V0FILT_NUMSIVPF}'";

            return query;
        }
        public string CONVSICOB_DTQITBCO { get; set; }
        public string CONVSICOB_VAL_RCAP { get; set; }
        public string CONVSICOB_AGEPGTO { get; set; }
        public string V0RCOM_DTMOVTO { get; set; }
        public string V0FILT_NUMSIVPF { get; set; }

        public static void Execute(R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1 r3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1)
        {
            var ths = r3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R3950_00_UPDATE_CONVERSAO_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}