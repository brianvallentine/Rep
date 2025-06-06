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
    public class M_0033_LOCALIZA_RESSARC_DB_UPDATE_2_Update1 : QueryBasis<M_0033_LOCALIZA_RESSARC_DB_UPDATE_2_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RESSARCIAZUL
				SET SITUACAO = '0' ,
				NSAC =  {FieldThreatment((this.SQL_NOT_NULL?.ToInt() == -1 ? null : $"{this.SQL_NSAC}"))},
				DATA_RESSARCIDO = NULL
				WHERE  NSAS =  '{this.MVCOM_NSAS}'
				AND NSL =  '{this.MVCOM_NSL1}'";

            return query;
        }
        public string SQL_NSAC { get; set; }
        public string SQL_NOT_NULL { get; set; }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_NSL1 { get; set; }

        public static void Execute(M_0033_LOCALIZA_RESSARC_DB_UPDATE_2_Update1 m_0033_LOCALIZA_RESSARC_DB_UPDATE_2_Update1)
        {
            var ths = m_0033_LOCALIZA_RESSARC_DB_UPDATE_2_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0033_LOCALIZA_RESSARC_DB_UPDATE_2_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}