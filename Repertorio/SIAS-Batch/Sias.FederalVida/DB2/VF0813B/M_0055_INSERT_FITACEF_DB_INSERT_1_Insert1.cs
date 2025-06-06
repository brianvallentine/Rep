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
    public class M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1 : QueryBasis<M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0FITACEF
            VALUES (:V0FTCF-NSAC,
            :V0FTCF-DTRET,
            :V0FTCF-VERSAO,
            :V0FTCF-QTREG,
            :V0FTCF-QTLANCDB,
            :V0FTCF-TOTDBEFET,
            :V0FTCF-TOTDBNEFET,
            0,
            0,
            0,
            :V0FTCF-QTDBEFET,
            0)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FITACEF VALUES ({FieldThreatment(this.V0FTCF_NSAC)}, {FieldThreatment(this.V0FTCF_DTRET)}, {FieldThreatment(this.V0FTCF_VERSAO)}, {FieldThreatment(this.V0FTCF_QTREG)}, {FieldThreatment(this.V0FTCF_QTLANCDB)}, {FieldThreatment(this.V0FTCF_TOTDBEFET)}, {FieldThreatment(this.V0FTCF_TOTDBNEFET)}, 0, 0, 0, {FieldThreatment(this.V0FTCF_QTDBEFET)}, 0)";

            return query;
        }
        public string V0FTCF_NSAC { get; set; }
        public string V0FTCF_DTRET { get; set; }
        public string V0FTCF_VERSAO { get; set; }
        public string V0FTCF_QTREG { get; set; }
        public string V0FTCF_QTLANCDB { get; set; }
        public string V0FTCF_TOTDBEFET { get; set; }
        public string V0FTCF_TOTDBNEFET { get; set; }
        public string V0FTCF_QTDBEFET { get; set; }

        public static void Execute(M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1 m_0055_INSERT_FITACEF_DB_INSERT_1_Insert1)
        {
            var ths = m_0055_INSERT_FITACEF_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}