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
    public class M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1 : QueryBasis<M_0055_INSERT_FITACEF_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0FITACEF
            VALUES (:SQL-NSAC,
            :FITCEF-DTRET,
            :FITCEF-VERSAO,
            :FITCEF-QTREG,
            0,
            0,
            0,
            :FITCEF-QTLANCCR,
            :FITCEF-TOTCREFET,
            :FITCEF-TOTCRNEFET,
            0,
            :FITCEF-QTCREFET)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0FITACEF VALUES ({FieldThreatment(this.SQL_NSAC)}, {FieldThreatment(this.FITCEF_DTRET)}, {FieldThreatment(this.FITCEF_VERSAO)}, {FieldThreatment(this.FITCEF_QTREG)}, 0, 0, 0, {FieldThreatment(this.FITCEF_QTLANCCR)}, {FieldThreatment(this.FITCEF_TOTCREFET)}, {FieldThreatment(this.FITCEF_TOTCRNEFET)}, 0, {FieldThreatment(this.FITCEF_QTCREFET)})";

            return query;
        }
        public string SQL_NSAC { get; set; }
        public string FITCEF_DTRET { get; set; }
        public string FITCEF_VERSAO { get; set; }
        public string FITCEF_QTREG { get; set; }
        public string FITCEF_QTLANCCR { get; set; }
        public string FITCEF_TOTCREFET { get; set; }
        public string FITCEF_TOTCRNEFET { get; set; }
        public string FITCEF_QTCREFET { get; set; }

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