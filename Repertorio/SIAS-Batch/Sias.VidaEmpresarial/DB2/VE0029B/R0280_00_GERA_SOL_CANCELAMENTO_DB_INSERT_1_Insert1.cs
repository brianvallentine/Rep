using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmpresarial.DB2.VE0029B
{
    public class R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1 : QueryBasis<R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0RELATORIOS
            VALUES ( 'VE0029B' ,
            :V1SIST-DTMOVABE,
            'VE' ,
            'VE0030B' ,
            0,
            0,
            :V1SIST-DTMOVABE,
            :V1SIST-DTMOVABE,
            :V1SIST-DTMOVABE,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            :V0PEND-NUM-APOL,
            0,
            0,
            0,
            0,
            :V0PEND-COD-SUBG,
            0,
            0,
            0,
            ' ' ,
            ' ' ,
            0,
            0,
            ' ' ,
            0,
            0,
            ' ' ,
            '0' ,
            ' ' ,
            ' ' ,
            0,
            0,
            0,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VE0029B' , {FieldThreatment(this.V1SIST_DTMOVABE)}, 'VE' , 'VE0030B' , 0, 0, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, 0, 0, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.V0PEND_NUM_APOL)}, 0, 0, 0, 0, {FieldThreatment(this.V0PEND_COD_SUBG)}, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0PEND_NUM_APOL { get; set; }
        public string V0PEND_COD_SUBG { get; set; }

        public static void Execute(R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1 r0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1)
        {
            var ths = r0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R0280_00_GERA_SOL_CANCELAMENTO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}