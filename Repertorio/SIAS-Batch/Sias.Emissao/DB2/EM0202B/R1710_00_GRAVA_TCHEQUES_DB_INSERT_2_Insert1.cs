using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Emissao.DB2.EM0202B
{
    public class R1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1 : QueryBasis<R1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0HISTCHEQ
            VALUES (:V0HCHE-CHQINT ,
            :V0HCHE-DIGINT ,
            :V0HCHE-DTMOVTO ,
            CURRENT TIME ,
            :V0HCHE-OPERACAO,
            :V0HCHE-EMPRESA ,
            CURRENT TIMESTAMP,
            NULL)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0HISTCHEQ VALUES ({FieldThreatment(this.V0HCHE_CHQINT)} , {FieldThreatment(this.V0HCHE_DIGINT)} , {FieldThreatment(this.V0HCHE_DTMOVTO)} , CURRENT TIME , {FieldThreatment(this.V0HCHE_OPERACAO)}, {FieldThreatment(this.V0HCHE_EMPRESA)} , CURRENT TIMESTAMP, NULL)";

            return query;
        }
        public string V0HCHE_CHQINT { get; set; }
        public string V0HCHE_DIGINT { get; set; }
        public string V0HCHE_DTMOVTO { get; set; }
        public string V0HCHE_OPERACAO { get; set; }
        public string V0HCHE_EMPRESA { get; set; }

        public static void Execute(R1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1 r1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1)
        {
            var ths = r1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1710_00_GRAVA_TCHEQUES_DB_INSERT_2_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}