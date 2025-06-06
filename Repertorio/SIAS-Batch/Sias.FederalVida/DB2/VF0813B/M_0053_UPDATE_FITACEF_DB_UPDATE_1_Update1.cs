using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.FederalVida.DB2.VF0813B
{
    public class M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1 : QueryBasis<M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FITACEF
				SET QTDE_LANC_DEB_RET =  '{this.V0FTCF_QTLANCDB}',
				TOT_DEB_EFET =  '{this.V0FTCF_TOTDBEFET}',
				TOT_DEB_NAO_EFET =  '{this.V0FTCF_TOTDBNEFET}',
				QTDE_DEB_EFET =  '{this.V0FTCF_QTDBEFET}'
				WHERE  NSAC =  '{this.V0FTCF_NSAC}'";

            return query;
        }
        public string V0FTCF_TOTDBNEFET { get; set; }
        public string V0FTCF_TOTDBEFET { get; set; }
        public string V0FTCF_QTLANCDB { get; set; }
        public string V0FTCF_QTDBEFET { get; set; }
        public string V0FTCF_NSAC { get; set; }

        public static void Execute(M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1 m_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1)
        {
            var ths = m_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}