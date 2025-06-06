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
    public class M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1 : QueryBasis<M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES
            (:WS-COD-PES-ATU,
            :DCLPESSOA-JURIDICA.CGC,
            :DCLPESSOA-JURIDICA.NOME-FANTASIA,
            :DCLPESSOA-JURIDICA.COD-USUARIO,
            CURRENT TIMESTAMP)
            END-EXEC
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.PESSOA_JURIDICA VALUES ({FieldThreatment(this.WS_COD_PES_ATU)}, {FieldThreatment(this.CGC)}, {FieldThreatment(this.NOME_FANTASIA)}, {FieldThreatment(this.COD_USUARIO)}, CURRENT TIMESTAMP)";

            return query;
        }
        public string WS_COD_PES_ATU { get; set; }
        public string CGC { get; set; }
        public string NOME_FANTASIA { get; set; }
        public string COD_USUARIO { get; set; }

        public static void Execute(M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1 m_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1)
        {
            var ths = m_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_31300_00_INS_PESSOA_JURIDICA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}