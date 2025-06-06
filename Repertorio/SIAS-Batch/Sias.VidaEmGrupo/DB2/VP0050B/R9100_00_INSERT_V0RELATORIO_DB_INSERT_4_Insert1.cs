using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VP0050B
{
    public class R9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1 : QueryBasis<R9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0RELATORIOS
            VALUES ( 'VP0050B' ,
            :V1SIST-DTMOVABE,
            'VP' ,
            'VA1419B1' ,
            0,
            0,
            :V1SIST-DTMOVABE,
            :V1SIST-DTMOVABE,
            :V1SIST-DTMOVABE,
            :V1RELA-MES-REFER,
            :V1RELA-ANO-REFER,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
            0,
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
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'VP0050B' , {FieldThreatment(this.V1SIST_DTMOVABE)}, 'VP' , 'VA1419B1' , 0, 0, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1RELA_MES_REFER)}, {FieldThreatment(this.V1RELA_ANO_REFER)}, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V1RELA_MES_REFER { get; set; }
        public string V1RELA_ANO_REFER { get; set; }

        public static void Execute(R9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1 r9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1)
        {
            var ths = r9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R9100_00_INSERT_V0RELATORIO_DB_INSERT_4_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}