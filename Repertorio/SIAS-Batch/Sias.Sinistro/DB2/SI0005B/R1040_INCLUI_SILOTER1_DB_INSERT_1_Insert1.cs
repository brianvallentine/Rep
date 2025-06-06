using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Sinistro.DB2.SI0005B
{
    public class R1040_INCLUI_SILOTER1_DB_INSERT_1_Insert1 : QueryBasis<R1040_INCLUI_SILOTER1_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINI_LOTERICO01
            ( COD_LOT_FENAL
            ,NUM_APOLICE
            ,NUM_APOL_SINISTRO
            ,NUM_CONTROLE_FENAL
            ,COD_LOT_CEF
            ,COD_CLIENTE
            ,SITUACAO
            ,DATA_GERA_MOV
            ,COD_ORIGEM_AVISO
            ,DTINIVIG
            ,TIMESTAMP
            ,COD_COBERTURA
            )
            VALUES
            (:SINILT01-COD-LOT-FENAL
            ,:SINILT01-NUM-APOLICE
            ,:SINILT01-NUM-APOL-SINISTRO
            ,:SINILT01-NUM-CONTROLE-FENAL
            ,:SINILT01-COD-LOT-CEF
            ,:SINILT01-COD-CLIENTE
            ,:SINILT01-SITUACAO
            ,:SINILT01-DATA-GERA-MOV
            ,:SINILT01-COD-ORIGEM-AVISO
            ,:SINILT01-DTINIVIG
            , CURRENT TIMESTAMP
            ,:SINILT01-COD-COBERTURA
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINI_LOTERICO01 ( COD_LOT_FENAL ,NUM_APOLICE ,NUM_APOL_SINISTRO ,NUM_CONTROLE_FENAL ,COD_LOT_CEF ,COD_CLIENTE ,SITUACAO ,DATA_GERA_MOV ,COD_ORIGEM_AVISO ,DTINIVIG ,TIMESTAMP ,COD_COBERTURA ) VALUES ({FieldThreatment(this.SINILT01_COD_LOT_FENAL)} ,{FieldThreatment(this.SINILT01_NUM_APOLICE)} ,{FieldThreatment(this.SINILT01_NUM_APOL_SINISTRO)} ,{FieldThreatment(this.SINILT01_NUM_CONTROLE_FENAL)} ,{FieldThreatment(this.SINILT01_COD_LOT_CEF)} ,{FieldThreatment(this.SINILT01_COD_CLIENTE)} ,{FieldThreatment(this.SINILT01_SITUACAO)} ,{FieldThreatment(this.SINILT01_DATA_GERA_MOV)} ,{FieldThreatment(this.SINILT01_COD_ORIGEM_AVISO)} ,{FieldThreatment(this.SINILT01_DTINIVIG)} , CURRENT TIMESTAMP ,{FieldThreatment(this.SINILT01_COD_COBERTURA)} )";

            return query;
        }
        public string SINILT01_COD_LOT_FENAL { get; set; }
        public string SINILT01_NUM_APOLICE { get; set; }
        public string SINILT01_NUM_APOL_SINISTRO { get; set; }
        public string SINILT01_NUM_CONTROLE_FENAL { get; set; }
        public string SINILT01_COD_LOT_CEF { get; set; }
        public string SINILT01_COD_CLIENTE { get; set; }
        public string SINILT01_SITUACAO { get; set; }
        public string SINILT01_DATA_GERA_MOV { get; set; }
        public string SINILT01_COD_ORIGEM_AVISO { get; set; }
        public string SINILT01_DTINIVIG { get; set; }
        public string SINILT01_COD_COBERTURA { get; set; }

        public static void Execute(R1040_INCLUI_SILOTER1_DB_INSERT_1_Insert1 r1040_INCLUI_SILOTER1_DB_INSERT_1_Insert1)
        {
            var ths = r1040_INCLUI_SILOTER1_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1040_INCLUI_SILOTER1_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}