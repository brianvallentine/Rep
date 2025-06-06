using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI1630B
{
    public class M_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1 : QueryBasis<M_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.CLIENTE_EMAIL
            VALUES (:WS-COD-CLI-ATU ,
            :WS-SEQ-EMA-ATU ,
            :BI0005L-S-EMAIL )
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.CLIENTE_EMAIL VALUES ({FieldThreatment(this.WS_COD_CLI_ATU)} , {FieldThreatment(this.WS_SEQ_EMA_ATU)} , {FieldThreatment(this.BI0005L_S_EMAIL)} )";

            return query;
        }
        public string WS_COD_CLI_ATU { get; set; }
        public string WS_SEQ_EMA_ATU { get; set; }
        public string BI0005L_S_EMAIL { get; set; }

        public static void Execute(M_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1 m_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1)
        {
            var ths = m_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1C100_00_INS_EMAIL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}