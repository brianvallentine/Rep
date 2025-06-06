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
    public class M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1 : QueryBasis<M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_TELEFONE
            VALUES (:WS-COD-PES-ATU,
            :IND-TEL,
            :WS-MAX-SEQ-TEL,
            :DCLPESSOA-TELEFONE.DDI,
            :DCLPESSOA-TELEFONE.DDD,
            :DCLPESSOA-TELEFONE.NUM-FONE,
            :DCLPESSOA-TELEFONE.SITUACAO-FONE,
            :DCLPESSOA-TELEFONE.COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_TELEFONE VALUES ({FieldThreatment(this.WS_COD_PES_ATU)}, {FieldThreatment(this.IND_TEL)}, {FieldThreatment(this.WS_MAX_SEQ_TEL)}, {FieldThreatment(this.DDI)}, {FieldThreatment(this.DDD)}, {FieldThreatment(this.NUM_FONE)}, {FieldThreatment(this.SITUACAO_FONE)}, {FieldThreatment(this.COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string WS_COD_PES_ATU { get; set; }
        public string IND_TEL { get; set; }
        public string WS_MAX_SEQ_TEL { get; set; }
        public string DDI { get; set; }
        public string DDD { get; set; }
        public string NUM_FONE { get; set; }
        public string SITUACAO_FONE { get; set; }
        public string COD_USUARIO { get; set; }

        public static void Execute(M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1 m_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1)
        {
            var ths = m_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_51000_00_GRAVA_TELEFONE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}