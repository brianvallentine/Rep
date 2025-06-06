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
    public class M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1 : QueryBasis<M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FITASASSE
				SET QTDE_LANC_CRED_RET =
				QTDE_LANC_CRED_RET + 1,
				TOT_CRED_EFET =
				TOT_CRED_EFET +  '{this.FITSAS_CREDEFET}',
				TOT_CRED_NAO_EFET =
				TOT_CRED_NAO_EFET +  '{this.FITSAS_CREDNEFET}'
				WHERE  COD_CONVENIO =  '{this.WHOST_CODCONV}'
				AND NSAS =  '{this.MVCOM_NSAS}'";

            return query;
        }
        public string FITSAS_CREDNEFET { get; set; }
        public string FITSAS_CREDEFET { get; set; }
        public string WHOST_CODCONV { get; set; }
        public string MVCOM_NSAS { get; set; }

        public static void Execute(M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1 m_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1)
        {
            var ths = m_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0025_ATUALIZA_FITASASSE_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}