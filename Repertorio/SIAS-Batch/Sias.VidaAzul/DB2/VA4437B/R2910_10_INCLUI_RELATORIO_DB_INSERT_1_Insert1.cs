using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.VidaAzul.DB2.VA4437B
{
    public class R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1 : QueryBasis<R2910_10_INCLUI_RELATORIO_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.RELATORIOS
            VALUES ( 'EM0600B' ,
            :SISTEMAS-DATA-MOV-ABERTO,
            'EM' ,
            'CARTAECT' ,
            :RELATORI-NUM-COPIAS,
            0,
            :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DATA-MOV-ABERTO,
            :SISTEMAS-DATA-MOV-ABERTO,
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
				INSERT INTO SEGUROS.RELATORIOS VALUES ( 'EM0600B' , {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, 'EM' , 'CARTAECT' , {FieldThreatment(this.RELATORI_NUM_COPIAS)}, 0, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.SISTEMAS_DATA_MOV_ABERTO)}, {FieldThreatment(this.V1SIST_MESREFER)}, {FieldThreatment(this.V1SIST_ANOREFER)}, 0, 0, 0, 0, 0, 0, {FieldThreatment(this.WHOST_NRAPOLICE)}, 0, 0, 0, 0, {FieldThreatment(this.WHOST_CODSUBES)}, 0, 0, 0, ' ' , ' ' , 0, 0, ' ' , 0, 0, ' ' , '0' , ' ' , ' ' , 0, 0, 0, CURRENT TIMESTAMP)";

            return query;
        }
        public string SISTEMAS_DATA_MOV_ABERTO { get; set; }
        public string RELATORI_NUM_COPIAS { get; set; }
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