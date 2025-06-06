using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0812B
{
    public class M_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1 : QueryBasis<M_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0MOVCOMIS
				SET SITUACAO = '0' ,
				DATA_SAIDA = NULL
				WHERE  NSAS =  '{this.MVCOM_NSAS}'
				AND NSL =  '{this.MVCOM_NSL}'";

            return query;
        }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_NSL { get; set; }

        public static void Execute(M_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1 m_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1)
        {
            var ths = m_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1432_REJEITA_COMISSAO_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}