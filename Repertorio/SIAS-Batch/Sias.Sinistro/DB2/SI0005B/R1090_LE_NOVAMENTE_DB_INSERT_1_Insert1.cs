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
    public class R1090_LE_NOVAMENTE_DB_INSERT_1_Insert1 : QueryBasis<R1090_LE_NOVAMENTE_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL
            INSERT INTO SEGUROS.SINI_LOT_DOC01
            ( NUM_APOL_SINISTRO
            ,COD_DOCUMENTO
            ,DATA_RECEBE
            ,TMSP_MOV_RECEBE
            ,CODUSU_RECEBE
            ,DATA_SOLICITA
            ,TMSP_MOV_SOLICITA
            ,CODUSU_SOLICITA
            ,SITUACAO
            ,TMSP_MOV_SITUACAO
            ,CODUSU_SITUACAO
            ,TIMESTAMP
            )
            VALUES
            (:SINLOTDO-NUM-APOL-SINISTRO
            ,:SINLOTDO-COD-DOCUMENTO
            ,:SINLOTDO-DATA-RECEBE
            , CURRENT TIMESTAMP
            ,:SINLOTDO-CODUSU-RECEBE
            ,:SINLOTDO-DATA-SOLICITA
            ,:SINLOTDO-TMSP-MOV-SOLICITA
            ,:SINLOTDO-CODUSU-SOLICITA
            ,:SINLOTDO-SITUACAO
            ,:SINLOTDO-TMSP-MOV-SITUACAO
            ,:SINLOTDO-CODUSU-SITUACAO
            , CURRENT TIMESTAMP
            )
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.SINI_LOT_DOC01 ( NUM_APOL_SINISTRO ,COD_DOCUMENTO ,DATA_RECEBE ,TMSP_MOV_RECEBE ,CODUSU_RECEBE ,DATA_SOLICITA ,TMSP_MOV_SOLICITA ,CODUSU_SOLICITA ,SITUACAO ,TMSP_MOV_SITUACAO ,CODUSU_SITUACAO ,TIMESTAMP ) VALUES ({FieldThreatment(this.SINLOTDO_NUM_APOL_SINISTRO)} ,{FieldThreatment(this.SINLOTDO_COD_DOCUMENTO)} ,{FieldThreatment(this.SINLOTDO_DATA_RECEBE)} , CURRENT TIMESTAMP ,{FieldThreatment(this.SINLOTDO_CODUSU_RECEBE)} ,{FieldThreatment(this.SINLOTDO_DATA_SOLICITA)} ,{FieldThreatment(this.SINLOTDO_TMSP_MOV_SOLICITA)} ,{FieldThreatment(this.SINLOTDO_CODUSU_SOLICITA)} ,{FieldThreatment(this.SINLOTDO_SITUACAO)} ,{FieldThreatment(this.SINLOTDO_TMSP_MOV_SITUACAO)} ,{FieldThreatment(this.SINLOTDO_CODUSU_SITUACAO)} , CURRENT TIMESTAMP )";

            return query;
        }
        public string SINLOTDO_NUM_APOL_SINISTRO { get; set; }
        public string SINLOTDO_COD_DOCUMENTO { get; set; }
        public string SINLOTDO_DATA_RECEBE { get; set; }
        public string SINLOTDO_CODUSU_RECEBE { get; set; }
        public string SINLOTDO_DATA_SOLICITA { get; set; }
        public string SINLOTDO_TMSP_MOV_SOLICITA { get; set; }
        public string SINLOTDO_CODUSU_SOLICITA { get; set; }
        public string SINLOTDO_SITUACAO { get; set; }
        public string SINLOTDO_TMSP_MOV_SITUACAO { get; set; }
        public string SINLOTDO_CODUSU_SITUACAO { get; set; }

        public static void Execute(R1090_LE_NOVAMENTE_DB_INSERT_1_Insert1 r1090_LE_NOVAMENTE_DB_INSERT_1_Insert1)
        {
            var ths = r1090_LE_NOVAMENTE_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1090_LE_NOVAMENTE_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}