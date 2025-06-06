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
    public class R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1 : QueryBasis<R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET SIT_PROPOSTA =  '{this.WHOST_SIT_PROP_FIDELIZ}',
				SITUACAO_ENVIO =  '{this.WHOST_SITUACAO_ENVIO}',
				DTQITBCO =  '{this.SIVPF_DTQITBCO}',
				VAL_PAGO =  '{this.SIVPF_VAL_PAGO}',
				DATA_CREDITO =  '{this.SIVPF_DATA_CREDITO}',
				OPCAO_COBER =  '{this.SIVPF_OPCAO_COBER}',
				COD_USUARIO = 'VA0118B' ,
				TIMESTAMP = CURRENT TIMESTAMP
				WHERE  NUM_PROPOSTA_SIVPF =  '{this.SIVPF_NR_PROPOSTA}'";

            return query;
        }
        public string WHOST_SIT_PROP_FIDELIZ { get; set; }
        public string WHOST_SITUACAO_ENVIO { get; set; }
        public string SIVPF_DATA_CREDITO { get; set; }
        public string SIVPF_OPCAO_COBER { get; set; }
        public string SIVPF_DTQITBCO { get; set; }
        public string SIVPF_VAL_PAGO { get; set; }
        public string SIVPF_NR_PROPOSTA { get; set; }

        public static void Execute(R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1 r7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1)
        {
            var ths = r7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R7775_00_UPD_PROP_SIVPF_SIVPF_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}