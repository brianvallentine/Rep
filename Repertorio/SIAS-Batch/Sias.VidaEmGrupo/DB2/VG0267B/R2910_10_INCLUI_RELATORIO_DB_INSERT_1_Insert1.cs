using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaEmGrupo.DB2.VG0267B
{
    public class R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1 : QueryBasis<R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT
            INTO SEGUROS.V0RELATORIOS
            VALUES ( 'EM0600B' ,
            :V1SIST-DTMOVABE,
            'EM' ,
            'CARTAECT' ,
            :V0RELA-NRCOPIAS,
            0,
            :V1SIST-DTMOVABE,
            :V1SIST-DTMOVABE,
            :V1SIST-DTMOVABE,
            :V1SIST-MESREFER,
            :V1SIST-ANOREFER,
            0,
            0,
            0,
            0,
            0,
            0,
            :WHOST-NRAPOLICE,
            0,
            0,
            0,
            0,
            :WHOST-CODSUBES,
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
				INSERT INTO SEGUROS.V0RELATORIOS VALUES ( 'EM0600B' , {FieldThreatment(this.V1SIST_DTMOVABE)}, 'EM' , 'CARTAECT' , {FieldThreatment(this.V0RELA_NRCOPIAS)}, 0, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1SIST_DTMOVABE)}, {FieldThreatment(this.V1SIST_MESREFER)}, {FieldThreatment(this.V1SIST_ANOREFER)}, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.WHOST_NRAPOLICE)}, 0, 0, 0, 0, {FieldThreatment(this.WHOST_CODSUBES)}, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string V1SIST_DTMOVABE { get; set; }
        public string V0RELA_NRCOPIAS { get; set; }
        public string V1SIST_MESREFER { get; set; }
        public string V1SIST_ANOREFER { get; set; }
        public string WHOST_NRAPOLICE { get; set; }
        public string WHOST_CODSUBES { get; set; }

        public static void Execute(R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1 r2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1)
        {
            var ths = r2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}