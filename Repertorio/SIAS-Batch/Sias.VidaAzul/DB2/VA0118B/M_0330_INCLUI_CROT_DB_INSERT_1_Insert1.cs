using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA0118B
{
    public class M_0330_INCLUI_CROT_DB_INSERT_1_Insert1 : QueryBasis<M_0330_INCLUI_CROT_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.V0CLIENTE_CROT
            VALUES (:CLIENT-CGCCPF,
            'N' ,
            'N' ,
            'S' ,
            :SISTEMA-DTMOVABE)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0CLIENTE_CROT VALUES ({FieldThreatment(this.CLIENT_CGCCPF)}, 'N' , 'N' , 'S' , {FieldThreatment(this.SISTEMA_DTMOVABE)})";

            return query;
        }
        public string CLIENT_CGCCPF { get; set; }
        public string SISTEMA_DTMOVABE { get; set; }

        public static void Execute(M_0330_INCLUI_CROT_DB_INSERT_1_Insert1 m_0330_INCLUI_CROT_DB_INSERT_1_Insert1)
        {
            var ths = m_0330_INCLUI_CROT_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override M_0330_INCLUI_CROT_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}