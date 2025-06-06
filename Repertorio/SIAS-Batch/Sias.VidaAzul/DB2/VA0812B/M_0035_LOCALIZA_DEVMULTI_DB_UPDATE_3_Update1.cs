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
    public class M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1 : QueryBasis<M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0HISTCONTAVA A
				SET A.SITUACAO =  '{this.HCTA_SITUACAO}',
				A.NSAC =  '{this.SQL_NSAC}',
				A.CODRET =  '{this.HCTA_CODRET}',
				A.TIMESTAMP = CURRENT_TIMESTAMP,
				A.CODUSU = 'VA0812B'
				WHERE  A.CODCONV =  '{this.WHOST_CODCONV}'
				AND A.NSAS =  '{this.MVCOM_NSAS}'
				AND A.NSL =  '{this.MVCOM_NSL}'";

            return query;
        }
        public string HCTA_SITUACAO { get; set; }
        public string HCTA_CODRET { get; set; }
        public string SQL_NSAC { get; set; }
        public string WHOST_CODCONV { get; set; }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_NSL { get; set; }

        public static void Execute(M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1 m_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1)
        {
            var ths = m_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0035_LOCALIZA_DEVMULTI_DB_UPDATE_3_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}