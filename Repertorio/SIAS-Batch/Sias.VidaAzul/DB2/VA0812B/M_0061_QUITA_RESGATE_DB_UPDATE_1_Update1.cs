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
    public class M_0061_QUITA_RESGATE_DB_UPDATE_1_Update1 : QueryBasis<M_0061_QUITA_RESGATE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0RESGATE_CAP_VG
				SET SITUACAO = '1' ,
				DTCREDITO =  '{this.V0RESG_DTCREDITO}',
				NSAC =  '{this.SQL_NSAC}',
				TIMESTAMP = CURRENT TIMESTAMP,
				CODRET =  '{this.MVCOM_COD_RETORNO}'
				WHERE  NRCERTIF =  '{this.V0RESG_NRCERTIF}'
				AND NSAS =  '{this.MVCOM_NSAS}'";

            return query;
        }
        public string MVCOM_COD_RETORNO { get; set; }
        public string V0RESG_DTCREDITO { get; set; }
        public string SQL_NSAC { get; set; }
        public string V0RESG_NRCERTIF { get; set; }
        public string MVCOM_NSAS { get; set; }

        public static void Execute(M_0061_QUITA_RESGATE_DB_UPDATE_1_Update1 m_0061_QUITA_RESGATE_DB_UPDATE_1_Update1)
        {
            var ths = m_0061_QUITA_RESGATE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0061_QUITA_RESGATE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}