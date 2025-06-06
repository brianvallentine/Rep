using System;
using IA_ConverterCommons;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Linq;
using _ = IA_ConverterCommons.Statements;
using DB = IA_ConverterCommons.DatabaseBasis;

namespace Sias.Geral.DB2.GE0306B
{
    public class R1060_INS_VIDA_SAP_DB_INSERT_1_Insert1 : QueryBasis<R1060_INS_VIDA_SAP_DB_INSERT_1_Insert1>
    {
        string GetQuery()
        {
            #region SQL_SOURCE
            /*EXEC SQL INSERT INTO SEGUROS.GE_VIDA_SAP
            ( NUM_OCORR_MOVTO ,
            NUM_CERTIFICADO ,
            NUM_PARCELA ,
            NUM_NOSSO_TITULO ,
            NSAS ,
            IDE_SISTEMA ,
            DTH_CADASTRAMENTO )
            VALUES
            (:GE095-NUM-OCORR-MOVTO ,
            :GE095-NUM-CERTIFICADO ,
            :GE095-NUM-PARCELA ,
            :GE095-NUM-NOSSO-TITULO ,
            :GE095-NSAS ,
            :GE095-IDE-SISTEMA ,
            CURRENT TIMESTAMP)
            END-EXEC.
            */
            #endregion
            var query = @$"
				INSERT INTO SEGUROS.GE_VIDA_SAP ( NUM_OCORR_MOVTO , NUM_CERTIFICADO , NUM_PARCELA , NUM_NOSSO_TITULO , NSAS , IDE_SISTEMA , DTH_CADASTRAMENTO ) VALUES ({FieldThreatment(this.GE095_NUM_OCORR_MOVTO)} , {FieldThreatment(this.GE095_NUM_CERTIFICADO)} , {FieldThreatment(this.GE095_NUM_PARCELA)} , {FieldThreatment(this.GE095_NUM_NOSSO_TITULO)} , {FieldThreatment(this.GE095_NSAS)} , {FieldThreatment(this.GE095_IDE_SISTEMA)} , CURRENT TIMESTAMP)";

            return query;
        }
        public string GE095_NUM_OCORR_MOVTO { get; set; }
        public string GE095_NUM_CERTIFICADO { get; set; }
        public string GE095_NUM_PARCELA { get; set; }
        public string GE095_NUM_NOSSO_TITULO { get; set; }
        public string GE095_NSAS { get; set; }
        public string GE095_IDE_SISTEMA { get; set; }

        public static void Execute(R1060_INS_VIDA_SAP_DB_INSERT_1_Insert1 r1060_INS_VIDA_SAP_DB_INSERT_1_Insert1)
        {
            var ths = r1060_INS_VIDA_SAP_DB_INSERT_1_Insert1;
            ths.SetQuery(ths.GetQuery());
            ths.ExecuteQuery();
        }

        public override R1060_INS_VIDA_SAP_DB_INSERT_1_Insert1 OpenData(List<KeyValuePair<string, object>> result)
        {
            throw new NotImplementedException();
        }

    }
}