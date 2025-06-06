using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA1471B
{
    public class M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1 : QueryBasis<M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.MOVIMENTO_EA
            VALUES (:PROPOVA-NUM-CERTIFICADO,
            :CONARQEA-NSAS,
            :MOVIMEA-TIPO-MOVIMENTO,
            'VA1471B' ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.MOVIMENTO_EA VALUES ({FieldThreatment(this.PROPOVA_NUM_CERTIFICADO)}, {FieldThreatment(this.CONARQEA_NSAS)}, {FieldThreatment(this.MOVIMEA_TIPO_MOVIMENTO)}, 'VA1471B' , CURRENT TIMESTAMP)";

            return query;
        }
        public string PROPOVA_NUM_CERTIFICADO { get; set; }
        public string CONARQEA_NSAS { get; set; }
        public string MOVIMEA_TIPO_MOVIMENTO { get; set; }

        public static void Execute(M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1 m_0200_INSERT_REPSAF_DB_INSERT_1_Insert1)
        {
            var ths = m_0200_INSERT_REPSAF_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0200_INSERT_REPSAF_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}