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
    public class M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3_Update1 : QueryBasis<M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0CAMPMULTSUP
				SET SITUACAO =  '{this.CAMP_SITUACAO}',
				NSAC =  '{this.SQL_NSAC}',
				CODRET =  '{this.CAMP_CODRET}'
				WHERE  NSAS =  '{this.MVCOM_NSAS}'
				AND NSL =  '{this.MVCOM_NSL}'";

            return query;
        }
        public string CAMP_SITUACAO { get; set; }
        public string CAMP_CODRET { get; set; }
        public string SQL_NSAC { get; set; }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_NSL { get; set; }

        public static void Execute(M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3_Update1 m_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3_Update1)
        {
            var ths = m_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0034_LOCALIZA_PREMIACAO_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}