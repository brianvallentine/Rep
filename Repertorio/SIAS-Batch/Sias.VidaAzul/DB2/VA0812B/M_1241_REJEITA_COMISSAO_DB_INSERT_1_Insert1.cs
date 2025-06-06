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
    public class M_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1 : QueryBasis<M_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0RETORNOCOMIS VALUES
            (:SQL-NSAC,
            :MVCOM-NSAS,
            :MVCOM-NSL,
            :MVCOM-COD-RETORNO,
            :DTMOVABE,
            :MVCOM-DATA-MOV)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RETORNOCOMIS VALUES ({FieldThreatment(this.SQL_NSAC)}, {FieldThreatment(this.MVCOM_NSAS)}, {FieldThreatment(this.MVCOM_NSL)}, {FieldThreatment(this.MVCOM_COD_RETORNO)}, {FieldThreatment(this.DTMOVABE)}, {FieldThreatment(this.MVCOM_DATA_MOV)})";

            return query;
        }
        public string SQL_NSAC { get; set; }
        public string MVCOM_NSAS { get; set; }
        public string MVCOM_NSL { get; set; }
        public string MVCOM_COD_RETORNO { get; set; }
        public string DTMOVABE { get; set; }
        public string MVCOM_DATA_MOV { get; set; }

        public static void Execute(M_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1 m_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1)
        {
            var ths = m_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_1241_REJEITA_COMISSAO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}