using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Bilhetes.DB2.BI0003S
{
    public class M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1 : QueryBasis<M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_EMAIL VALUES
            (:WS-COD-PES-ATU,
            :WS-MAX-SEQ-EMA,
            :DCLPESSOA-EMAIL.EMAIL,
            :DCLPESSOA-EMAIL.SITUACAO-EMAIL,
            :DCLPESSOA-EMAIL.COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_EMAIL VALUES ({FieldThreatment(this.WS_COD_PES_ATU)}, {FieldThreatment(this.WS_MAX_SEQ_EMA)}, {FieldThreatment(this.EMAIL)}, {FieldThreatment(this.SITUACAO_EMAIL)}, {FieldThreatment(this.COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string WS_COD_PES_ATU { get; set; }
        public string WS_MAX_SEQ_EMA { get; set; }
        public string EMAIL { get; set; }
        public string SITUACAO_EMAIL { get; set; }
        public string COD_USUARIO { get; set; }

        public static void Execute(M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1 m_71000_00_INS_EMAIL_DB_INSERT_1_Insert1)
        {
            var ths = m_71000_00_INS_EMAIL_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_71000_00_INS_EMAIL_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}