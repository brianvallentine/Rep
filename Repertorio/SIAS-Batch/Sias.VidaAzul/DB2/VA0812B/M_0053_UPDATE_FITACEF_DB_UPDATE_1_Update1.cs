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
    public class M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1 : QueryBasis<M_0053_UPDATE_FITACEF_DB_UPDATE_1_Update1>
    {
        string GetQuery()
        {
            var query = @$"
				UPDATE SEGUROS.V0FITACEF
				SET QTDE_LANC_CRED_RET =  '{this.FITCEF_QTLANCCR}',
				TOT_CRED_EFET =  '{this.FITCEF_TOTCREFET}',
				TOT_CRED_NAO_EFET =  '{this.FITCEF_TOTCRNEFET}',
				QTDE_CRED_EFET =  '{this.FITCEF_QTCREFET}'
				WHERE  NSAC =  '{this.SQL_NSAC}'";

            return query;
        }
        public string FITCEF_TOTCRNEFET { get; set; }
        public string FITCEF_TOTCREFET { get; set; }
        public string FITCEF_QTLANCCR { get; set; }
        public string FITCEF_QTCREFET { get; set; }
        public string SQL_NSAC { get; set; }

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