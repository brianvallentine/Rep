using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0020B
{
    public class M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1 : QueryBasis<M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCONTAVEND
            VALUES (:SQL-AGENCIA,
            :SQL-OPERACAO,
            :SQL-CONTA,
            :SQL-DV-CONTA,
            :SQL-MATRICULA,
            :SQL-CPF,
            CURRENT DATE,
            CURRENT TIME,
            'VP0020B' )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCONTAVEND VALUES ({FieldThreatment(this.SQL_AGENCIA)}, {FieldThreatment(this.SQL_OPERACAO)}, {FieldThreatment(this.SQL_CONTA)}, {FieldThreatment(this.SQL_DV_CONTA)}, {FieldThreatment(this.SQL_MATRICULA)}, {FieldThreatment(this.SQL_CPF)}, CURRENT DATE, CURRENT TIME, 'VP0020B' )";

            return query;
        }
        public string SQL_AGENCIA { get; set; }
        public string SQL_OPERACAO { get; set; }
        public string SQL_CONTA { get; set; }
        public string SQL_DV_CONTA { get; set; }
        public string SQL_MATRICULA { get; set; }
        public string SQL_CPF { get; set; }

        public static void Execute(M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1 m_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1)
        {
            var ths = m_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1210_ALTERA_AGENCIA_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}