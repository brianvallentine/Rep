using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_11000_00_ATUALIZA_DB_UPDATE_1_Update1 : QueryBasis<M_11000_00_ATUALIZA_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.PROPOSTA_FIDELIZ
				SET SIT_PROPOSTA =  '{this.WS_SIT_ATU_BIL}' ,
				SITUACAO_ENVIO = 'S' ,
				DTQITBCO =  '{this.PROPOFID_DTQITBCO}' ,
				VAL_PAGO =  '{this.PROPOFID_VAL_PAGO}' ,
				DATA_CREDITO =  '{this.PROPOFID_DATA_CREDITO}'
				WHERE  NUM_PROPOSTA_SIVPF =  '{this.PROPOFID_NUM_PROPOSTA_SIVPF}'";

            return query;
        }
        public string PROPOFID_DATA_CREDITO { get; set; }
        public string PROPOFID_DTQITBCO { get; set; }
        public string PROPOFID_VAL_PAGO { get; set; }
        public string WS_SIT_ATU_BIL { get; set; }
        public string PROPOFID_NUM_PROPOSTA_SIVPF { get; set; }

        public static void Execute(M_11000_00_ATUALIZA_DB_UPDATE_1_Update1 m_11000_00_ATUALIZA_DB_UPDATE_1_Update1)
        {
            var ths = m_11000_00_ATUALIZA_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_11000_00_ATUALIZA_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}